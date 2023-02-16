using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text highScore1Txt;
    [SerializeField] TMP_Text highScore2Txt;
    [SerializeField] TMP_Text highScore3Txt;

    [SerializeField] GameObject powerUp;

    int score;
    List<int> highScores = new List<int>();
    public DificuldadeType dificuldade;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        scoreTxt.text = "Score: " + score;

        highScores.Add(PlayerPrefs.GetInt("score1", 0));
        highScores.Add(PlayerPrefs.GetInt("score2", 0));
        highScores.Add(PlayerPrefs.GetInt("score3", 0));       

        dificuldade = DificuldadeType.Easy;
    }

    public void UpdateScore (int value)
    {
        score += value;
        scoreTxt.text = "Score: " + score;
        if(score >= 500)
        {
            dificuldade = DificuldadeType.Medium;
        }
        if (score >= 2000)
        {
            dificuldade = DificuldadeType.Hard;
        }
        if(score % 200 == 0)
        {
            InstantiatePowerUp();
        }
    }

    public void UpdateHighScores()
    {
        highScores.Add(score);
        highScores.Sort();

        highScore1Txt.text = "1: " + highScores[3];
        highScore2Txt.text = "2: " + highScores[2];
        highScore3Txt.text = "3: " + highScores[1];

        PlayerPrefs.SetInt("score1", highScores[3]);
        PlayerPrefs.SetInt("score2", highScores[2]);
        PlayerPrefs.SetInt("score3", highScores[1]);

    }

    void InstantiatePowerUp()
    {
        Instantiate(powerUp, new Vector3(Random.Range(-0.37f, 0.1f), -0.8f, 0f), transform.rotation);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] GameObject canvasPause;
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject powerUpEffect;

    [SerializeField] Image[] lives;

    int life;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        ResetTimeScale();
        life = lives.Length;
    }

    public void StartGame()
    {
        SoundManager.instance.PlayMenuSound();        
        Time.timeScale = 1f;
        SceneController.instance.StartGame();
    }

    public void PauseGame()
    {
        SoundManager.instance.PlayMenuSound();
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        ScoreManager.instance.UpdateHighScores();
        canvasGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SoundManager.instance.PlayMenuSound();        
        Time.timeScale = 1f;
        SceneController.instance.LoadTitleScreen();
    }

    public void ResumeGame()
    {
        SoundManager.instance.PlayMenuSound();
        canvasPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetTimeScale()
    {        
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SoundManager.instance.PlayMenuSound();
        SceneController.instance.QuitGame();
    }

    public void SufferDamage()
    {        
        if (--life >= 0)
        {
            lives[life].enabled = false;
        }

        SoundManager.instance.PlayPlayerHitSound();

        if (life <= 0)
        {            
            GameOver();
        }

    }

    public void SlowDown()
    {
        StartCoroutine(SlowCoolDown());
    }

    IEnumerator SlowCoolDown()
    {
        Time.timeScale = .5f;
        powerUpEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        Time.timeScale = 1f;
        powerUpEffect.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartGame()
    {
        SoundManager.instance.PlayGameplayMusic();
        SoundManager.instance.PlayMenuSound();
        StartCoroutine(LoadSceneWithFade(1));
    }

    public void LoadTitleScreen()
    {
        SoundManager.instance.PlayTitleMusic();
        StartCoroutine(LoadSceneWithFade(0));
    }

    public void QuitGame()
    {
        SoundManager.instance.PlayMenuSound();
        Application.Quit();
    }

    IEnumerator LoadSceneWithFade(int scene)
    {
        FadeController.inst.FadeToBlack();
        
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
        FadeController.inst.FadeFromBlack();

        //yield return null;
    }
    
}

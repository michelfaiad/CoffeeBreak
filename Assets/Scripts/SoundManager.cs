using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Sources")]
    [SerializeField] AudioSource sourceMusic;
    [SerializeField] AudioSource sourceFX;
    [SerializeField] AudioSource sourcePlayerFX;
    [Header("Clips")]    
    [SerializeField] AudioClip soundPlayerHit;
    [SerializeField] AudioClip soundDonutHit;
    [SerializeField] AudioClip soundWaffleHit;
    [SerializeField] AudioClip soundPowerupShow;
    [SerializeField] AudioClip soundPowerupHit;
    [SerializeField] AudioClip soundMenu;
    [SerializeField] AudioClip musicGameplay;
    [SerializeField] AudioClip musicTitle;

    float fadeDuration = .7f;
        
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetMusicVolume(float value)
    {
        sourceMusic.volume = value;
    }
    public float GetMusicVolume()
    {
        return sourceMusic.volume;
    }

    public void SetFXVolume(float value)
    {
        sourceFX.volume = value;
        sourcePlayerFX.volume = value;
    }
    public float GetFXVolume()
    {        
        return sourcePlayerFX.volume;
    }

    public void PlayMenuSound()
    {
        sourcePlayerFX.clip = soundMenu;
        sourcePlayerFX.Play();
    }    

    public void PlayPlayerHitSound()
    {
        sourcePlayerFX.clip = soundPlayerHit;
        sourcePlayerFX.Play();
    }

    public void PlayDonutHitSound()
    {
        sourceFX.clip = soundDonutHit;
        sourceFX.Play();
    }

    public void PlayWaffleHitSound()
    {
        sourceFX.clip = soundWaffleHit;
        sourceFX.Play();
    }

    public void PlayPowerupShowSound()
    {
        sourceFX.clip = soundPowerupShow;
        sourceFX.Play();
    }

    public void PlayPowerupHitSound()
    {
        sourceFX.clip = soundPowerupHit;
        sourceFX.Play();
    }

    public void PlayGameplayMusic()
    {
        StartCoroutine(ChangeMusicWithFade(sourceMusic, musicGameplay, fadeDuration));
    }

    public void PlayTitleMusic()
    {
        StartCoroutine(ChangeMusicWithFade(sourceMusic, musicTitle, fadeDuration));
    }

    private static IEnumerator ChangeMusicWithFade(AudioSource source, AudioClip clip, float fadeTime)
    {
        float volumeInit = source.volume;
        while (source.volume > 0.01f)
        {
            source.volume -= 0.5f * Time.deltaTime / fadeTime;
            yield return null;
        }
        source.Stop();
        source.clip = clip;
        source.Play();

        while (source.volume < volumeInit)
        {
            source.volume += 0.5f * Time.deltaTime / fadeTime;
            yield return null;
        }


    }
}

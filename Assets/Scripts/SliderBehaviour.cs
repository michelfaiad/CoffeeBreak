using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider fxSlider;

    private void Start()
    {
        musicSlider.value = SoundManager.instance.GetMusicVolume();
        fxSlider.value = SoundManager.instance.GetFXVolume();
    }

    public void onMusicValueChange()
    {
        SoundManager.instance.SetMusicVolume(musicSlider.value);
    }

    public void onFXValueChange()
    {
        SoundManager.instance.SetFXVolume(fxSlider.value);
    }

}

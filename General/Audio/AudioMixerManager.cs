using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class AudioMixerManager : MonoBehaviour
{
    public AudioMixer mixer;

    public bool isMuted = false;

    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SoundFXVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void SetMasterVolume(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20f);
    }

    public void SetMenuMusicVolume()
    {
        if (isMuted == false)
        {
            mixer.SetFloat("MenuMusic", -80f);
            isMuted = true;
        }
        else
        {
            mixer.SetFloat("MenuMusic", 0f);
            isMuted = false;
        }
    }
}

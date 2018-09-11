using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class overallVolumeSlider : MonoBehaviour {

    public AudioMixer Master;
    public AudioMixer Music;
    public AudioMixer SFX;


    public void setVolume(float volume)
    {
        Master.SetFloat("Volume", volume);
    }

    public void setMusicVolume(float musicVolume)
    {
        Music.SetFloat("MusicVolume", musicVolume);
    }

    public void setSFXVolume(float SFXVolume)
    {
        SFX.SetFloat("SFXVolume", SFXVolume);
    }
}

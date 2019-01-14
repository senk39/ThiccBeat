using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class overallVolumeSlider : MonoBehaviour {

    public AudioMixer Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;


    public void setVolume(float volume)
    {
        Master.SetFloat("Volume", volume);
    }

    public void setMusicVolume(float musicVolume)
    {
        Music.audioMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void setSFXVolume(float SFXVolume)
    {
        SFX.audioMixer.SetFloat("SFXVolume", SFXVolume);
    }
}

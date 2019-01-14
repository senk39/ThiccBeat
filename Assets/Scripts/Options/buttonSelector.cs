using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;



public class buttonSelector : MonoBehaviour
{

    public GameObject btn_overall;
    public GameObject btn_music;
    public GameObject btn_sfx;
    public GameObject btn_mute;
    public GameObject btn_resolution;
    public GameObject btn_fullscreen;

    public  GameObject overallVolumeSlider;
    public  GameObject musicVolumeSlider;
    public  GameObject SFXVolumeSlider;

    public static GameObject muteToggle;

    public GameObject resolutionDropdown;

    public static GameObject fullscreenToggle;

    public AudioMixer Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;


    void Awake()
    {
        btn_overall = GameObject.Find("btn_overall");
        btn_music = GameObject.Find("btn_music");
        btn_sfx = GameObject.Find("btn_sfx");
        btn_mute = GameObject.Find("btn_mute");
        btn_resolution = GameObject.Find("btn_resolution");
        btn_fullscreen = GameObject.Find("btn_fullscreen");

        overallVolumeSlider = GameObject.Find("Overall volume");
        musicVolumeSlider = GameObject.Find("Music volume");
        SFXVolumeSlider = GameObject.Find("SFX volume");

        muteToggle = GameObject.Find("Mute key effects");

        resolutionDropdown = GameObject.Find("Dropdown");

        fullscreenToggle = GameObject.Find("Fullscreen");



}

    void Start()
    {
        float tempMasterVolume;
        float tempMusicVolume;
        float tempSFXVolume;
        
        
        Master.GetFloat("Volume", out tempMasterVolume);
        Music.audioMixer.GetFloat("MusicVolume", out tempMusicVolume);
        SFX.audioMixer.GetFloat("SFXVolume", out tempSFXVolume);

        overallVolumeSlider.GetComponent<Slider>().value = tempMasterVolume;
        musicVolumeSlider.GetComponent<Slider>().value = tempMusicVolume;
        SFXVolumeSlider.GetComponent<Slider>().value = tempSFXVolume;

    }

    void Update()
    {

        if (EventSystem.current.currentSelectedGameObject == btn_overall)
        {
            OverallVolumeSelected();
        }
        else if (EventSystem.current.currentSelectedGameObject == btn_music)
        {
            MusicVolumeSelected();
        }
        else if (EventSystem.current.currentSelectedGameObject == btn_sfx)
        {
            SFXVolumeSelected();
        }
        else if (EventSystem.current.currentSelectedGameObject == btn_mute)
        {
            MuteSelected();
        }
        else if (EventSystem.current.currentSelectedGameObject == btn_resolution)
        {
            ResolutionSelected();
        }
        else if (EventSystem.current.currentSelectedGameObject == btn_fullscreen)
        {
            FullscreenSelected();
        }
        else
        {
            Debug.Log("Error: There's no option selected in options menu.");
            //btn_overall = EventSystem.current.currentSelectedGameObject;
            //EventSystem.Equals(btn_overall);

            //  \/  \/  \/
            //EventSystem.current.SetSelectedGameObject(btn_overall);       
            //  /\  /\  /\
            //TO BYŁO POTRZEBNE GDY DZIAŁAŁ DROPDOWN ABY ZAZNACZENIE TRWAŁO DALEJ!^^^
        }

    }

    void OverallVolumeSelected()
    {
        if (Input.GetKey("left"))
        {
            overallVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right"))
        {
            overallVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void MusicVolumeSelected()
    {
        if (Input.GetKey("left"))
        {
            musicVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right"))
        {
            musicVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void SFXVolumeSelected()
    {
        if (Input.GetKey("left"))
        {
            SFXVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right"))
        {
            SFXVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void MuteSelected()
    {
        if (Input.GetKeyDown("return") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            if (muteToggle.GetComponent<Toggle>().isOn == true)
            {
                muteToggle.GetComponent<Toggle>().isOn = false;
            }
            else
            {
                muteToggle.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    void ResolutionSelected()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            resolutionDropdown.GetComponent<Dropdown>().Show();
        }

        //EventSystem.current.SetSelectedGameObject(btn_resolution);

    }

    void FullscreenSelected()
    {

        if (Input.GetKeyDown("return") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            if (fullscreenToggle.GetComponent<Toggle>().isOn == true)
            {
                fullscreenToggle.GetComponent<Toggle>().isOn = false;
            }
            else
            {
                fullscreenToggle.GetComponent<Toggle>().isOn = true;
            }
        }
    }
}

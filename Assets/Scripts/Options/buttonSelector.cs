using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class buttonSelector : MonoBehaviour
{
    short index;

    AudioSource acChangeOption;
    AudioSource acChangeDiff;
    AudioSource acBack;
    AudioSource acEnter;

    public GameObject acConChangeOption;
    public GameObject acConChangeDiff;
    public GameObject acConBack;
    public GameObject acConEnter;

    public GameObject btn_overall;
    public GameObject btn_music;
    public GameObject btn_sfx;
    public GameObject btn_mute;
    public GameObject btn_resolution;
    public GameObject btn_reset;

    public  GameObject overallVolumeSlider;
    public  GameObject musicVolumeSlider;
    public  GameObject SFXVolumeSlider;

    public static GameObject muteToggle;

    public GameObject resolutionDropdown;

    public static GameObject resetToggle;

    public AudioMixer Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;

    public GameObject resetConfirm;

    void Awake()
    {        
        resetConfirm = GameObject.Find("window_confirm");
        resetConfirm.SetActive(false);

        index = 1;

        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();

        btn_overall = GameObject.Find("btn_overall");
        btn_music = GameObject.Find("btn_music");
        btn_sfx = GameObject.Find("btn_sfx");
        btn_mute = GameObject.Find("btn_mute");
        btn_resolution = GameObject.Find("btn_resolution");
        btn_reset = GameObject.Find("btn_reset");

        overallVolumeSlider = GameObject.Find("Overall volume");
        musicVolumeSlider = GameObject.Find("Music volume");
        SFXVolumeSlider = GameObject.Find("SFX volume");

        muteToggle = GameObject.Find("Mute key effects");

        resolutionDropdown = GameObject.Find("Dropdown");

        resetToggle = GameObject.Find("Reset high scores");
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
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.O)))
        {
            if (!resetConfirm.activeInHierarchy && index < 6)
            {
                index++;
                acChangeOption.Play();
            }

            else if (resetConfirm.activeInHierarchy)
            {
                acChangeOption.Play();
            }
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Q)))
        {
            if (!resetConfirm.activeInHierarchy && index > 1)
            {
                index--;
                acChangeOption.Play();
            }

            else if (resetConfirm.activeInHierarchy)
            {
                acChangeOption.Play();
            }
        }

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
        else if (EventSystem.current.currentSelectedGameObject == btn_reset)
        {
            resetHighScoreSelected();
        }
        else
        {
            //Debug.Log("Błąd: nic nie zostało zaznaczone!");
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
        if (Input.GetKey("left") || Input.GetKey(KeyCode.D))
        {
            overallVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.J))
        {
            overallVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void MusicVolumeSelected()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.D))
        {
            musicVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.J))
        {
            musicVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void SFXVolumeSelected()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.D))
        {
            SFXVolumeSlider.GetComponent<Slider>().value -= 1;
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.J))
        {
            SFXVolumeSlider.GetComponent<Slider>().value += 1;
        }
    }

    void MuteSelected()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown("return") || Input.GetKeyDown("left") || Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.G))
        {
            if (muteToggle.GetComponent<Toggle>().isOn == true)
            {
                acChangeDiff.Play();
                muteToggle.GetComponent<Toggle>().isOn = false;
                PlayerPrefs.SetInt("areButtonsMute", 0);
            }
            else
            {
                acChangeDiff.Play();
                muteToggle.GetComponent<Toggle>().isOn = true;
                PlayerPrefs.SetInt("areButtonsMute", 1);
            }
        }
    }

    void ResolutionSelected()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown("space") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            resolutionDropdown.GetComponent<Dropdown>().Show();
        }

        //EventSystem.current.SetSelectedGameObject(btn_resolution);

    }

    void resetHighScoreSelected()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            resetConfirm.SetActive(true);
            GameObject.Find("NO").GetComponent<Button>().Select();
            /*
            if (Input.GetKey("left") || Input.GetKey(KeyCode.D))
            {
                SFXVolumeSlider.GetComponent<Slider>().value -= 1;
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.J))
            {
                SFXVolumeSlider.GetComponent<Slider>().value += 1;
            }*/


        }

    }

    public void deleteHighScores()
    {
        acEnter.Play();
        for (int sIndex = 0; sIndex < 1; sIndex++)
        {
            PlayerPrefs.SetInt(sIndex + "GoldScoreeasy", 0);
            PlayerPrefs.SetInt(sIndex + "SilverScoreeasy", 0);
            PlayerPrefs.SetInt(sIndex + "BronzeScoreeasy", 0);

            PlayerPrefs.SetInt(sIndex + "GoldComboeasy", 0);
            PlayerPrefs.SetInt(sIndex + "SilverComboeasy", 0);
            PlayerPrefs.SetInt(sIndex + "BronzeComboeasy", 0);

            PlayerPrefs.SetInt(sIndex + "GoldScorehard", 0);
            PlayerPrefs.SetInt(sIndex + "SilverScorehard", 0);
            PlayerPrefs.SetInt(sIndex + "BronzeScorehard", 0);

            PlayerPrefs.SetInt(sIndex + "GoldCombohard", 0);
            PlayerPrefs.SetInt(sIndex + "SilverCombohard", 0);
            PlayerPrefs.SetInt(sIndex + "BronzeCombohard", 0);
        }
    }

    public void cancelReset()
    {
        acBack.Play();
        Invoke("cancelReset2", 0.4f);
    }

    public void cancelReset2()
    {
        resetConfirm.SetActive(false);
        btn_reset.GetComponent<Button>().Select();
    }
}

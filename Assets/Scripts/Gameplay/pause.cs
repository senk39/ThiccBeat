using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

    // MUSISZ ZROBIĆ ZABEZPIECZENIE UNIEMOŻLIWIAJĄCE PAUZOWANIE GRY PRZED ODTWARZANIEM MUZYKI (3S)

    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;

    private KeyCode tempKey1;
    private KeyCode tempKey2;
    private KeyCode tempKey3;
    private KeyCode tempKey4;
    private KeyCode tempKey5;
    private KeyCode tempKey6;
    private KeyCode tempKey7;

    public Button firstButton;

    public AudioSource songAudio;

    void Start () {
        pauseMenuUI.SetActive(false);

         tempKey1 = button1.GetComponent<pressingNotes1>().key;
         tempKey2 = button2.GetComponent<pressingNotes2>().key;
         tempKey3 = button3.GetComponent<pressingNotes3>().key;
         tempKey4 = button4.GetComponent<pressingNotes4>().key;
         tempKey5 = button5.GetComponent<pressingNotes5>().key;
         tempKey6 = button6.GetComponent<pressingNotes6>().key;
         tempKey7 = button7.GetComponent<pressingNotes7>().key;
    }

    void Awake()
    {
        songAudio = GameObject.Find("Song Player").GetComponent<AudioSource>();
        isGamePaused = false;
    }

    void Update () {
        
        if(isGamePaused == false)
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.O)) && isGamePaused == false && songAudio.timeSamples > 0)
        {
            enterPause();
        }

        if(pauseControl.isResumeClicked == true && isGamePaused == true)
        {
            exitPause();
        }
	}


    void enterPause()
    {
        firstButton.Select();

        pauseMenuUI.SetActive(true);
        isGamePaused = true;
        GameObject.Find("Song Player").GetComponent<AudioSource>().Pause();
        disablingIndicators();
        Time.timeScale = 0.001f;
    }

    public void exitPause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        GameObject.Find("Song Player").GetComponent<AudioSource>().Play();
        enablingIndicators();
        pauseControl.isResumeClicked = false;
    }

    void disablingIndicators()
    {
        button1.GetComponent<pressingNotes1>().key = KeyCode.None;
        button2.GetComponent<pressingNotes2>().key = KeyCode.None;
        button3.GetComponent<pressingNotes3>().key = KeyCode.None;
        button4.GetComponent<pressingNotes4>().key = KeyCode.None;
        button5.GetComponent<pressingNotes5>().key = KeyCode.None;
        button6.GetComponent<pressingNotes6>().key = KeyCode.None;
        button7.GetComponent<pressingNotes7>().key = KeyCode.None;

        button1.GetComponent<pressedKeyColor>().enabled = false;
        button2.GetComponent<pressedKeyColor>().enabled = false;
        button3.GetComponent<pressedKeyColor>().enabled = false;
        button4.GetComponent<pressedKeyColor>().enabled = false;
        button5.GetComponent<pressedKeyColor>().enabled = false;
        button6.GetComponent<pressedKeyColor>().enabled = false;
        button7.GetComponent<pressedKeyColor>().enabled = false;
    }

    void enablingIndicators()
    {
        button1.GetComponent<pressingNotes>().key = tempKey1;
        button2.GetComponent<pressingNotes>().key = tempKey2;
        button3.GetComponent<pressingNotes>().key = tempKey3;
        button4.GetComponent<pressingNotes>().key = tempKey4;
        button5.GetComponent<pressingNotes>().key = tempKey5;
        button6.GetComponent<pressingNotes>().key = tempKey6;
        button7.GetComponent<pressingNotes>().key = tempKey7;

        button1.GetComponent<pressedKeyColor>().enabled = true;
        button2.GetComponent<pressedKeyColor>().enabled = true;
        button3.GetComponent<pressedKeyColor>().enabled = true;
        button4.GetComponent<pressedKeyColor>().enabled = true;
        button5.GetComponent<pressedKeyColor>().enabled = true;
        button6.GetComponent<pressedKeyColor>().enabled = true;
        button7.GetComponent<pressedKeyColor>().enabled = true;
    }


}

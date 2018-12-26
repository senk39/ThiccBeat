using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject buttonBar;

    private KeyCode tempKey1;
    private KeyCode tempKey2;
    private KeyCode tempKey3;
    private KeyCode tempKey4;
    private KeyCode tempKey5;
    private KeyCode tempKey6;
    private KeyCode tempKeySpecial;

    void Start () {
        pauseMenuUI.SetActive(false);

         tempKey1 = button1.GetComponent<pressingNotes>().key;
         tempKey2 = button2.GetComponent<pressingNotes>().key;
         tempKey3 = button3.GetComponent<pressingNotes>().key;
         tempKey4 = button4.GetComponent<pressingNotes>().key;
         tempKey5 = button5.GetComponent<pressingNotes>().key;
         tempKey6 = button6.GetComponent<pressingNotes>().key;
         tempKeySpecial = buttonBar.GetComponent<pressingNotesBar>().key;
    }

    void Awake()
    {
        pause.isGamePaused = false;
    }

    void Update () {
        
        if(isGamePaused == false)
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || pauseControl.isResumeClicked == true)
        {
            if(isGamePaused == true)
            {
                exitPause();
            }

            else
            {
                enterPause();
            }
        }	
	}


    void enterPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.001f;
        isGamePaused = true;
        GameObject.Find("SongPlayer").GetComponent<AudioSource>().Pause();
        disablingIndicators();
    }

    void exitPause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        GameObject.Find("SongPlayer").GetComponent<AudioSource>().Play();
        enablingIndicators();
        pauseControl.isResumeClicked = false;
    }

    void disablingIndicators()
    {
        button1.GetComponent<pressingNotes>().key = KeyCode.None;
        button2.GetComponent<pressingNotes>().key = KeyCode.None;
        button3.GetComponent<pressingNotes>().key = KeyCode.None;
        button4.GetComponent<pressingNotes>().key = KeyCode.None;
        button5.GetComponent<pressingNotes>().key = KeyCode.None;
        button6.GetComponent<pressingNotes>().key = KeyCode.None;
        buttonBar.GetComponent<pressingNotesBar>().key = KeyCode.None;

        button1.GetComponent<pressedKeyColor>().enabled = false;
        button2.GetComponent<pressedKeyColor>().enabled = false;
        button3.GetComponent<pressedKeyColor>().enabled = false;
        button4.GetComponent<pressedKeyColor>().enabled = false;
        button5.GetComponent<pressedKeyColor>().enabled = false;
        button6.GetComponent<pressedKeyColor>().enabled = false;
        buttonBar.GetComponent<pressedKeyColor>().enabled = false;
    }

    void enablingIndicators()
    {
        button1.GetComponent<pressingNotes>().key = tempKey1;
        button2.GetComponent<pressingNotes>().key = tempKey2;
        button3.GetComponent<pressingNotes>().key = tempKey3;
        button4.GetComponent<pressingNotes>().key = tempKey4;
        button5.GetComponent<pressingNotes>().key = tempKey5;
        button6.GetComponent<pressingNotes>().key = tempKey6;
        buttonBar.GetComponent<pressingNotesBar>().key = tempKeySpecial;

        button1.GetComponent<pressedKeyColor>().enabled = true;
        button2.GetComponent<pressedKeyColor>().enabled = true;
        button3.GetComponent<pressedKeyColor>().enabled = true;
        button4.GetComponent<pressedKeyColor>().enabled = true;
        button5.GetComponent<pressedKeyColor>().enabled = true;
        button6.GetComponent<pressedKeyColor>().enabled = true;
        buttonBar.GetComponent<pressedKeyColor>().enabled = true;
    }


}

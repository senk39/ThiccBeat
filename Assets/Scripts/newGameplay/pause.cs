using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

    // MUSISZ ZROBIĆ ZABEZPIECZENIE UNIEMOŻLIWIAJĄCE PAUZOWANIE GRY PRZED ODTWARZANIEM MUZYKI (3S)
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;

    public GameObject noteIndicator1;
    public GameObject noteIndicator2;
    public GameObject noteIndicator3;
    public GameObject noteIndicator4;
    public GameObject noteIndicator5;
    public GameObject noteIndicator6;
    public GameObject noteIndicatorSpecial;

    private KeyCode tempKey1;
    private KeyCode tempKey2;
    private KeyCode tempKey3;
    private KeyCode tempKey4;
    private KeyCode tempKey5;
    private KeyCode tempKey6;
    private KeyCode tempKeySpecial;

    void Start () {
        pauseMenuUI.SetActive(false);

         tempKey1 = noteIndicator1.GetComponent<pressingNotes>().key;
         tempKey2 = noteIndicator2.GetComponent<pressingNotes>().key;
         tempKey3 = noteIndicator3.GetComponent<pressingNotes>().key;
         tempKey4 = noteIndicator4.GetComponent<pressingNotes>().key;
         tempKey5 = noteIndicator5.GetComponent<pressingNotes>().key;
         tempKey6 = noteIndicator6.GetComponent<pressingNotes>().key;
         tempKeySpecial = noteIndicatorSpecial.GetComponent<pressingNotesBar>().key;
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

        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    void disablingIndicators()
    {
        noteIndicator1.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicator2.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicator3.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicator4.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicator5.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicator6.GetComponent<pressingNotes>().key = KeyCode.None;
        noteIndicatorSpecial.GetComponent<pressingNotesBar>().key = KeyCode.None;

        noteIndicator1.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicator2.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicator3.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicator4.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicator5.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicator6.GetComponent<pressedKeyColor>().enabled = false;
        noteIndicatorSpecial.GetComponent<pressedKeyColor>().enabled = false;


    }

    void enablingIndicators()
    {
        noteIndicator1.GetComponent<pressingNotes>().key = tempKey1;
        noteIndicator2.GetComponent<pressingNotes>().key = tempKey2;
        noteIndicator3.GetComponent<pressingNotes>().key = tempKey3;
        noteIndicator4.GetComponent<pressingNotes>().key = tempKey4;
        noteIndicator5.GetComponent<pressingNotes>().key = tempKey5;
        noteIndicator6.GetComponent<pressingNotes>().key = tempKey6;
        noteIndicatorSpecial.GetComponent<pressingNotesBar>().key = tempKeySpecial;

        noteIndicator1.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicator2.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicator3.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicator4.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicator5.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicator6.GetComponent<pressedKeyColor>().enabled = true;
        noteIndicatorSpecial.GetComponent<pressedKeyColor>().enabled = true;
    }


}

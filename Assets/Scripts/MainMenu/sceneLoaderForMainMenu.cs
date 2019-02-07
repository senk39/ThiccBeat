using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoaderForMainMenu : MonoBehaviour
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

    void Awake()
    {
        index = 1;


        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && index < 3)
        {
            index++;
            acChangeOption.Play();
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && index > 1)
        {
            index--;
            acChangeOption.Play();
        }
    }

    public void clickPlayBtn()
    {
        acEnter.Play();
        Invoke("loadSongList", 0.8f);
    }

    public void clickOptionsBtn()
    {
        SceneManager.LoadScene(3);
    }

    public void clickQuitBtn()
    {
        acBack.Play();
        Invoke("loadQuit", 1f);

    }


    void loadSongList()
    {
        SceneManager.LoadScene(2);

    }
    /*
    void loadOptions()
    {
        SceneManager.LoadScene(3);

    }
    */
    void loadQuit()
    {
        Application.Quit();

    }


}


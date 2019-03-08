using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitController : MonoBehaviour {


    bool isYesSelected;

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
        isYesSelected = true;

        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();
    }

    void Update () {

        
            if (Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.Q) ||
            (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.O)))
            {
            if(isYesSelected == true)
                {
                    isYesSelected = false;
                    acChangeOption.Play();

            }
            else
                {
                    isYesSelected = true;
                    acChangeOption.Play();
                }
            }
        }
    public void quitTheGame()
    {
        acBack.Play();
        Invoke("quitTheGame2", 0.4f);

    }
    public void quitTheGame2()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}

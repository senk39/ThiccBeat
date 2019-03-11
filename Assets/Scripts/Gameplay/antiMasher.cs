using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiMasher : MonoBehaviour
{
    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject button1;
    public bool b1pressed;

    public GameObject button2;
    public bool b2pressed;

    public GameObject button3;
    public bool b3pressed;

    public GameObject button4;
    public bool b4pressed;

    public GameObject button5;
    public bool b5pressed;

    public GameObject button6;
    public bool b6pressed;

    //==================================
        //POSTANOWIŁEM NIE BRAĆ POD UWAGĘ KLAWISZA 7 BO MASHOWANIE TEGO PRZYCISKU NIE UŁATWIA ROZGRYWKI ANI TROCHĘ
    //==================================

    //public GameObject button7;
    //public bool b7pressed;


    void Awake()
    {
        playerScoreContainer = GameObject.Find("Score");
        playerComboContainer = GameObject.Find("Combo");
        button1 = GameObject.Find("button 1");
        button2 = GameObject.Find("button 2");
        button3 = GameObject.Find("button 3");
        button4 = GameObject.Find("button 4");
        button5 = GameObject.Find("button 5");
        button6 = GameObject.Find("button 6");
        //button7 = GameObject.Find("bar");
}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        b1pressed = button1.GetComponent<pressingNotes>().isActive;
        b2pressed = button2.GetComponent<pressingNotes>().isActive;
        b3pressed = button3.GetComponent<pressingNotes>().isActive;
        b4pressed = button4.GetComponent<pressingNotes>().isActive;
        b5pressed = button5.GetComponent<pressingNotes>().isActive;
        b6pressed = button6.GetComponent<pressingNotes>().isActive;
        //b7pressed = button7.GetComponent<pressingNotesBar>().isActive;

        checkingIfAnyActive();
    }


    void checkingIfAnyActive()
    {
        if (b1pressed == true ||
            b2pressed == true ||
            b3pressed == true ||
            b4pressed == true ||
            b5pressed == true ||
            b6pressed == true)
        {
            if (Input.GetKeyDown(button1.GetComponent<pressingNotes>().key) && b1pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }

            if (Input.GetKeyDown(button2.GetComponent<pressingNotes>().key) && b2pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }

            if (Input.GetKeyDown(button3.GetComponent<pressingNotes>().key) && b3pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }

            if (Input.GetKeyDown(button4.GetComponent<pressingNotes>().key) && b4pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }

            if (Input.GetKeyDown(button5.GetComponent<pressingNotes>().key) && b5pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }

            if (Input.GetKeyDown(button6.GetComponent<pressingNotes>().key) && b6pressed == false)
            {
                playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }
            /*
            if (Input.GetKeyDown(button7.GetComponent<pressingNotesBar>().key) && b7pressed == false)
            {
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            }
            */


            if (Input.GetKey(button1.GetComponent<pressingNotes>().key) && b1pressed == false)
            {
                GameObject.Find("button 1").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }
            if (Input.GetKey(button2.GetComponent<pressingNotes>().key) && b2pressed == false)
            {
                GameObject.Find("button 2").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }
            if (Input.GetKey(button3.GetComponent<pressingNotes>().key) && b3pressed == false)
            {
                GameObject.Find("button 3").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }
            if (Input.GetKey(button4.GetComponent<pressingNotes>().key) && b4pressed == false)
            {
                GameObject.Find("button 4").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }
            if (Input.GetKey(button5.GetComponent<pressingNotes>().key) && b5pressed == false)
            {
                GameObject.Find("button 5").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }
            if (Input.GetKey(button6.GetComponent<pressingNotes>().key) && b6pressed == false)
            {
                GameObject.Find("button 6").gameObject.GetComponent<pressingNotes>().antiMasherConnector = true;
            }

            if (Input.GetKeyUp(button1.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 1").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
            if (Input.GetKeyUp(button2.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 2").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
            if (Input.GetKeyUp(button3.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 3").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
            if (Input.GetKeyUp(button4.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 4").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
            if (Input.GetKeyUp(button5.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 5").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
            if (Input.GetKeyUp(button6.GetComponent<pressingNotes>().key))
            {
                GameObject.Find("button 6").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            }
        }
        else
        {
            GameObject.Find("button 1").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            GameObject.Find("button 2").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            GameObject.Find("button 3").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            GameObject.Find("button 4").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            GameObject.Find("button 5").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;
            GameObject.Find("button 6").gameObject.GetComponent<pressingNotes>().antiMasherConnector = false;

        }
    }

}

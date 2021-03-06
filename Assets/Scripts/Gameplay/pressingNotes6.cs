﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes6 : MonoBehaviour
{
    public KeyCode key;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    private const float row6X = 5.1f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note6;

    void Update()
    {       
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            note6 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek();
        }
        else
        {
            note6 = null;
        }   

        setNoteContainer();
        setNote();
      
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            if (Input.GetKeyDown(key) && note6.GetComponent<note>().isActive)
            {
                if (key == KeyCode.L && transform.position.x == row6X)
                {
                    doWhenKeyPressedAndNoteIsInPressablePlace();
                    dequeueAndDestroy();
                }
            }
        }       
    }

    void incrementCombo()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
        playerScoreContainer.GetComponent<playerScore>().playerCorrectNotes += 1;
        playerComboContainer.GetComponent<playerCombo>().currentCombo++;
    }

    void dequeueAndDestroy()
    {       
        if (noteContainer.GetComponent<noteClass>().keyNumber == 6 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Dequeue();
        }              
    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek().transform.GetChild(0).gameObject;
        }       
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek();
        }       
        else
        {
            noteContainer = null;
        }
    }

    void doWhenKeyPressedAndNoteIsInPressablePlace()
    {
        incrementCombo();
        GameObject.Find("buttons").GetComponent<AudioSource>().Play();
    }
}


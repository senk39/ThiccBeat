﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes1 : MonoBehaviour
{
    public KeyCode key;


    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    //GameObject note1;

    public GameObject n1;
    public GameObject nc1;
    public Queue<GameObject> notesQueue1 = new Queue<GameObject>();
    private const float row1X = -5.1f;
    GameObject[] allNotes;

    void Start()
    {
        allNotes = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {
        
        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue1.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc1.GetComponent<note>().isActive)
            {
                    doWhenKeyPressedAndNoteIsInPressablePlace();
                    dequeueAndDestroy();              
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

        if (nc1.GetComponent<noteClass>().keyNumber == 1 && notesQueue1.Count > 0)
        {
            nc1.GetComponent<note>().enabled = false;
            nc1.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -330)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue1.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue1.Count > 0)
        {
            noteItself = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue1.Count > 0)
        {
            noteContainer = notesQueue1.Peek();
        }
        else
        {
            noteContainer = null;
        }
    }

    void doWhenKeyPressedAndNoteIsInPressablePlace()
    {
        incrementCombo();

        //RemoveFromQueue();

        GameObject.Find("buttons").GetComponent<AudioSource>().Play();

    }
    void setAsTheLowest()
    {
        if (notesQueue1.Count > 0)
        {
            notesQueue1.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue1.Count > 0)
        {
            nc1 = notesQueue1.Peek();
            n1 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc1 = null;
            n1 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 1)
            {
                notesQueue1.Enqueue(nutkowyKontener);
            }
        }
    }
}


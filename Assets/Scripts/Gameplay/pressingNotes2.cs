﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes2 : MonoBehaviour
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

    public GameObject n2;
    public GameObject nc2;
    public Queue<GameObject> notesQueue2 = new Queue<GameObject>();
    private const float row1X = -3.1f;
    GameObject[] allNotes2;

    void Start()
    {
        allNotes2 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue2.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc2.GetComponent<note>().isActive)
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

        if (nc2.GetComponent<noteClass>().keyNumber == 2 && notesQueue2.Count > 0)
        {
            nc2.GetComponent<note>().enabled = false;
            nc2.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue2.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue2.Count > 0)
        {
            noteItself = notesQueue2.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue2.Count > 0)
        {
            noteContainer = notesQueue2.Peek();
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
        if (notesQueue2.Count > 0)
        {
            notesQueue2.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue2.Count > 0)
        {
            nc2 = notesQueue2.Peek();
            n2 = notesQueue2.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc2 = null;
            n2 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes2)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                notesQueue2.Enqueue(nutkowyKontener);
            }
        }
    }
}


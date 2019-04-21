﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes4 : MonoBehaviour
{
    public KeyCode key;

    KeyCode key1 = KeyCode.A;
    KeyCode key2 = KeyCode.W;
    KeyCode key3 = KeyCode.D;
    KeyCode key4 = KeyCode.J;
    KeyCode key5 = KeyCode.I;
    KeyCode key6 = KeyCode.L;
    KeyCode key7 = KeyCode.G;

    public GameObject notMash;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row4X = 1.1f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note4;

    void Update()
    {

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            note4 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek();
        }
        else
        {
            note4 = null;
        }

        setNoteContainer();
        setNote();

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            if (Input.GetKeyDown(key) && note4.GetComponent<note>().isActive)
            {
                if (key == KeyCode.J && transform.position.x == row4X)
                {
                    Debug.Log("j");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note4.SetActive(false);
                    //Destroy(note4);
                }
            }
        }
    }


    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is4Active == true)
        {
            if ((Input.GetKey(key1) == false && notMash.GetComponent<notMash>().is1Active == false) ||
                (Input.GetKey(key2) == false && notMash.GetComponent<notMash>().is2Active == false) ||
                (Input.GetKey(key3) == false && notMash.GetComponent<notMash>().is3Active == false) ||
                (Input.GetKey(key5) == false && notMash.GetComponent<notMash>().is5Active == false) ||
                (Input.GetKey(key6) == false && notMash.GetComponent<notMash>().is6Active == false) ||
                (Input.GetKey(key7) == false && notMash.GetComponent<notMash>().is7Active == false))
            {
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            }
        }
    }

    void dequeueAndDestroy()
    {
        
       
        if (noteContainer.GetComponent<noteClass>().keyNumber == 4 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is4Active = false;
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Dequeue();           
        }

        
    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek().transform.GetChild(0).gameObject;
        }
       
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
       if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek();
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

}


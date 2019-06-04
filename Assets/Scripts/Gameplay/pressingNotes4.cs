using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes4 : MonoBehaviour
{
    public KeyCode key;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

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
        
       
        if (noteContainer.GetComponent<noteClass>().keyNumber == 4 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
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


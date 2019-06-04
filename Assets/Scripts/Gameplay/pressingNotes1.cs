using System.Collections;
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


    private const float row1X = -5.1f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note1;

    void Update()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            note1 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek();
        }
        else
        {
            note1 = null;
        }

        setNoteContainer();
        setNote();

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            if (Input.GetKeyDown(key) && note1.GetComponent<note>().isActive)
            {
                if (key == KeyCode.A && transform.position.x == row1X)
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
        
        if (noteContainer.GetComponent<noteClass>().keyNumber == 1 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Dequeue();
        }
       
        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }
        
    }

    void setNote()
    {
        if(GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek().transform.GetChild(0).gameObject;
        }       
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek();
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


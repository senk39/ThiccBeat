using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes7 : MonoBehaviour
{
    public KeyCode key;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row7X = 2.8f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note7;

    void Update()
    {     
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            note7 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek();
        }
        else
        {
            note7 = null;
        }

        setNoteContainer();
        setNote();
     
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            if (Input.GetKeyDown(key) && note7.GetComponent<note>().isActive)
            {
                if (key == KeyCode.G && transform.position.x == row7X)
                {
                    Debug.Log("G");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note7.SetActive(false);
                    //Destroy(note7);
                }
            }
        }
    }


    void incrementCombo()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
        playerComboContainer.GetComponent<playerCombo>().currentCombo++;
    }

    void dequeueAndDestroy()
    {
        
        if (noteContainer.GetComponent<noteClass>().keyNumber == 7 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Dequeue();
        }      
    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek().transform.GetChild(0).gameObject;

        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek();

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


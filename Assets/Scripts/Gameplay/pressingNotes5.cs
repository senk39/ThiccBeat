using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes5 : MonoBehaviour
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

    private const float row5X = 3.1f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note5;

    void Update()
    {     
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            note5 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek();
        }
        else
        {
            note5 = null;
        }   

        setNoteContainer();
        setNote();

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            if (Input.GetKeyDown(key) && note5.GetComponent<note>().isActive)
            {
                if (key == KeyCode.I && transform.position.x == row5X)
                {
                    Debug.Log("i");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note5.SetActive(false);
                    //Destroy(note5);
                }
            }
        }       
    }
    
    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is5Active == true)
        {
            if ((Input.GetKey(key1) == false && notMash.GetComponent<notMash>().is1Active == false) ||
                (Input.GetKey(key2) == false && notMash.GetComponent<notMash>().is2Active == false) ||
                (Input.GetKey(key3) == false && notMash.GetComponent<notMash>().is3Active == false) ||
                (Input.GetKey(key4) == false && notMash.GetComponent<notMash>().is4Active == false) ||
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
        if (noteContainer.GetComponent<noteClass>().keyNumber == 5 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is5Active = false;
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Dequeue();
        }        
    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek().transform.GetChild(0).gameObject;

        }      
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {      
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek();
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


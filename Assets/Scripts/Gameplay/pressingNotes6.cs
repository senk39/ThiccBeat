using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes6 : MonoBehaviour
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
                    Debug.Log("L");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note6.SetActive(false);
                    //Destroy(note6);
                }
            }
        }       
    }

    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is6Active == true)
        {
            if ((Input.GetKey(key1) == false && notMash.GetComponent<notMash>().is1Active == false) ||
                (Input.GetKey(key2) == false && notMash.GetComponent<notMash>().is2Active == false) ||
                (Input.GetKey(key3) == false && notMash.GetComponent<notMash>().is3Active == false) ||
                (Input.GetKey(key4) == false && notMash.GetComponent<notMash>().is4Active == false) ||
                (Input.GetKey(key5) == false && notMash.GetComponent<notMash>().is5Active == false) ||
                (Input.GetKey(key7) == false && notMash.GetComponent<notMash>().is7Active == false))
            {
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            }
        }
    }

    void dequeueAndDestroy()
    {       
        if (noteContainer.GetComponent<noteClass>().keyNumber == 6 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is6Active = false;
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

        //RemoveFromQueue();

        GameObject.Find("buttons").GetComponent<AudioSource>().Play();
    }

}


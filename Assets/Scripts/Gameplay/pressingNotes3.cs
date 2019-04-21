using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes3 : MonoBehaviour
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

    private const float row3X = -1.1f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note3;

    void Update()
    {

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            note3 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek();
        }
        else
        {
            note3 = null;
        }

        setNoteContainer();
        setNote();



        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            if (Input.GetKeyDown(key) && note3.GetComponent<note>().isActive)
            {
                if (key == KeyCode.D && transform.position.x == row3X)
                {
                    Debug.Log("D");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note3.SetActive(false);
                    //Destroy(note3);
                }
            }
        }
    }



    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is3Active == true)
        {
            if ((Input.GetKey(key1) == false && notMash.GetComponent<notMash>().is1Active == false) ||
                (Input.GetKey(key2) == false && notMash.GetComponent<notMash>().is2Active == false) ||
                (Input.GetKey(key4) == false && notMash.GetComponent<notMash>().is4Active == false) ||
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
        
       if (noteContainer.GetComponent<noteClass>().keyNumber == 3 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is3Active = false;
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Dequeue();
        }       
        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }
        
    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek().transform.GetChild(0).gameObject;
        }        
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
       if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek();
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


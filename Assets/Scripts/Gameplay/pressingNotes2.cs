using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes2 : MonoBehaviour
{
    public KeyCode key;

    KeyCode key1 = KeyCode.A;
    KeyCode key2 = KeyCode.W;
    KeyCode key3 = KeyCode.D;
    KeyCode key4 = KeyCode.J;
    KeyCode key5 = KeyCode.I;
    KeyCode key6 = KeyCode.L;
    KeyCode key7 = KeyCode.G;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    public GameObject notMash;

    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row2X = -3.1f;


    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note2;

    void Update()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            note2 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek();
        }
        else
        {
            note2 = null;
        }

        setNoteContainer();
        setNote();

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            if (Input.GetKeyDown(key) && note2.GetComponent<note>().isActive)
            {
                if (key == KeyCode.W && transform.position.x == row2X)
                {
                    Debug.Log("W");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    dequeueAndDestroy();
                    //note2.SetActive(false);
                    //Destroy(note2);
                }
            }
        }
    }


    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is2Active == true)
        {
            if ((Input.GetKey(key1) == false && notMash.GetComponent<notMash>().is1Active == false) ||
                (Input.GetKey(key3) == false && notMash.GetComponent<notMash>().is3Active == false) ||
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

        if (noteContainer.GetComponent<noteClass>().keyNumber == 2 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is2Active = false;
            noteContainer.GetComponent<note>().enabled = false;
            noteContainer.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30));
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek();
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


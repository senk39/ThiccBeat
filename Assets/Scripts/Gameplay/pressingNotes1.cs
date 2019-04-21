using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes1 : MonoBehaviour
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
                    //Debug.Log("A");
                    doWhenKeyPressedAndNoteIsInPressablePlace();
                    dequeueAndDestroy();
                }
            }
        }
    }

    void incrementCombo()
    {
        if (notMash.GetComponent<notMash>().is1Active == true)
        {
            if ((Input.GetKey(key2) == false && notMash.GetComponent<notMash>().is2Active == false) ||
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

        if (noteContainer.GetComponent<noteClass>().keyNumber == 1 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            GameObject.Find("MashRemover").GetComponent<notMash>().is1Active = false;
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
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
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


    private void OnTriggerEnter(Collider col)
    {
        //if (col.tag == "noteContainer")
        //{
        //    GameObject.Find("MashRemover").GetComponent<notMash>().is1Active = true;
        //}
    }
}


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

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    //GameObject note1;

    public GameObject n4;
    public GameObject nc4;
    public Queue<GameObject> notesQueue4 = new Queue<GameObject>();
    private const float row4X = 1.1f;
    GameObject[] allNotes4;

    void Start()
    {
        allNotes4 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue4.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc4.GetComponent<note>().isActive)
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

        if (nc4.GetComponent<noteClass>().keyNumber == 4 && notesQueue4.Count > 0)
        {
            nc4.GetComponent<note>().enabled = false;
            nc4.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -330)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue4.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue4.Count > 0)
        {
            noteItself = notesQueue4.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue4.Count > 0)
        {
            noteContainer = notesQueue4.Peek();
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
        if (notesQueue4.Count > 0)
        {
            notesQueue4.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue4.Count > 0)
        {
            nc4 = notesQueue4.Peek();
            n4 = notesQueue4.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc4 = null;
            n4 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes4)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                notesQueue4.Enqueue(nutkowyKontener);
            }
        }
    }
}


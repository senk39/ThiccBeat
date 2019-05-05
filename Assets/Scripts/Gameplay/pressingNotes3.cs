using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes3 : MonoBehaviour
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

    public GameObject n3;
    public GameObject nc3;
    public Queue<GameObject> notesQueue3 = new Queue<GameObject>();
    private const float row3X = -1.1f;
    GameObject[] allNotes3;

    void Start()
    {
        allNotes3 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue3.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc3.GetComponent<note>().isActive)
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

        if (nc3.GetComponent<noteClass>().keyNumber == 3 && notesQueue3.Count > 0)
        {
            nc3.GetComponent<note>().enabled = false;
            nc3.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue3.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue3.Count > 0)
        {
            noteItself = notesQueue3.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue3.Count > 0)
        {
            noteContainer = notesQueue3.Peek();
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
        if (notesQueue3.Count > 0)
        {
            notesQueue3.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue3.Count > 0)
        {
            nc3 = notesQueue3.Peek();
            n3 = notesQueue3.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc3 = null;
            n3 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes3)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                notesQueue3.Enqueue(nutkowyKontener);
            }
        }
    }
}


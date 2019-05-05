using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes5 : MonoBehaviour
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

    public GameObject n5;
    public GameObject nc5;
    public Queue<GameObject> notesQueue5 = new Queue<GameObject>();
    private const float row5X = 3.1f;
    GameObject[] allNotes5;

    void Start()
    {
        allNotes5 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue5.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc5.GetComponent<note>().isActive)
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

        if (nc5.GetComponent<noteClass>().keyNumber == 5 && notesQueue5.Count > 0)
        {
            nc5.GetComponent<note>().enabled = false;
            nc5.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue5.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue5.Count > 0)
        {
            noteItself = notesQueue5.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue5.Count > 0)
        {
            noteContainer = notesQueue5.Peek();
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
        if (notesQueue5.Count > 0)
        {
            notesQueue5.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue5.Count > 0)
        {
            nc5 = notesQueue5.Peek();
            n5 = notesQueue5.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc5 = null;
            n5 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes5)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                notesQueue5.Enqueue(nutkowyKontener);
            }
        }
    }
}


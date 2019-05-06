using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes6 : MonoBehaviour
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

    public GameObject n6;
    public GameObject nc6;
    public Queue<GameObject> notesQueue6 = new Queue<GameObject>();
    private const float row6X = 5.1f;
    GameObject[] allNotes6;

    void Start()
    {
        allNotes6 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue6.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc6.GetComponent<note>().isActive)
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

        if (nc6.GetComponent<noteClass>().keyNumber == 6 && notesQueue6.Count > 0)
        {
            nc6.GetComponent<note>().enabled = false;
            nc6.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -330)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue6.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue6.Count > 0)
        {
            noteItself = notesQueue6.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue6.Count > 0)
        {
            noteContainer = notesQueue6.Peek();
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
        if (notesQueue6.Count > 0)
        {
            notesQueue6.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue6.Count > 0)
        {
            nc6 = notesQueue6.Peek();
            n6 = notesQueue6.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc6 = null;
            n6 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes6)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                notesQueue6.Enqueue(nutkowyKontener);
            }
        }
    }
}


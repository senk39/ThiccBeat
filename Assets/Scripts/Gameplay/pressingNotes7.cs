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

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    //GameObject note1;

    public GameObject n7;
    public GameObject nc7;
    public Queue<GameObject> notesQueue7 = new Queue<GameObject>();
    private const float row7X = 2.8f;
    GameObject[] allNotes7;

    void Start()
    {
        allNotes7 = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
    }

    void Update()
    {

        setAsTheLowest();
        addTheLowestNotesToGameObjects();
        //setNoteContainer();
        //setNote();

        if (notesQueue7.Count > 0)
        {
            if (Input.GetKeyDown(key) && nc7.GetComponent<note>().isActive)
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

        if (nc7.GetComponent<noteClass>().keyNumber == 7 && notesQueue7.Count > 0)
        {
            nc7.GetComponent<note>().enabled = false;
            nc7.GetComponent<Rigidbody>().MovePosition(new Vector3(0, 0, -30)); // TERAZ NIE USUWAMY A PRZENOSIMY!
            notesQueue7.Dequeue();
        }

        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }

    }

    void setNote()
    {
        if (notesQueue7.Count > 0)
        {
            noteItself = notesQueue7.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (notesQueue7.Count > 0)
        {
            noteContainer = notesQueue7.Peek();
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
        if (notesQueue7.Count > 0)
        {
            notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
        }
    }

    void addTheLowestNotesToGameObjects()
    {
        if (notesQueue7.Count > 0)
        {
            nc7 = notesQueue7.Peek();
            n7 = notesQueue7.Peek().transform.GetChild(0).gameObject;
        }
        else
        {
            nc7 = null;
            n7 = null;
        }
    }

    void createQueues()
    {
        foreach (var nutkowyKontener in allNotes7)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                notesQueue7.Enqueue(nutkowyKontener);
            }
        }
    }
}


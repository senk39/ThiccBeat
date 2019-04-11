using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    public Queue<GameObject> notesQueue1 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue2 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue3 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue4 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue5 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue6 = new Queue<GameObject>();
    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row1X = -5.1f;
    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
    //private const float row7X = 2.67f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject[] allNotes;

    void Awake()
    {
        allNotes = GameObject.FindGameObjectsWithTag("noteContainer");
        createQueues();
        
    }

    void Start()
    {
        setInitialNoteContainersAsTheLowest();

    }
    void Update()
    {
        if (noteItself != null)
        {
            if (Input.GetKeyDown(key) && isActive && noteContainer.GetComponent<note>().isTheLowest && noteContainer.GetComponent<note>().isActive)
            {
                incrementCombo();

            //RemoveFromQueue();


                Destroy(noteContainer.gameObject);
                GameObject.Find("buttons").GetComponent<AudioSource>().Play();

            }
        }
    }





    void incrementCombo()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
        playerComboContainer.GetComponent<playerCombo>().currentCombo++;
    }


    void createQueues()
    {
        
        foreach (var nutkowyKontener in allNotes)
        {
            if(nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 1)
            {
                 notesQueue1.Enqueue(nutkowyKontener);
                //Debug.Log("nutkontener1: " + nutkowyKontener.transform.GetChild(0));
                Debug.Log("nutkontener1: " + notesQueue1.Peek().name);
                
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                notesQueue2.Enqueue(nutkowyKontener);
                Debug.Log("nutkontener2: " + notesQueue2.Peek().name);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                notesQueue3.Enqueue(nutkowyKontener);
                Debug.Log("nutkontener3: " + notesQueue3.Peek().name);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                notesQueue4.Enqueue(nutkowyKontener);
                Debug.Log("nutkontener4: " + notesQueue4.Peek().name);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                notesQueue5.Enqueue(nutkowyKontener);
                Debug.Log("nutkontener5: " + notesQueue5.Peek().name);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                notesQueue6.Enqueue(nutkowyKontener);
                Debug.Log("nutkontener6: " + notesQueue6.Peek().name);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                //notesQueue7.Enqueue(nutkowyKontener);
                //Debug.Log("nutkontener7: " + notesQueue7.Peek().transform.GetChild(0).name);
            }
        }

    }

    void setInitialNoteContainersAsTheLowest()
    {
        notesQueue1.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue2.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue3.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue4.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue5.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue6.Peek().GetComponent<note>().isTheLowest = true;
        //notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
    }

    void setNoteAsActive()
    {
        foreach (var nutkowyKontener in allNotes)
        {
            if (nutkowyKontener.transform.position.z < ActiveStart && nutkowyKontener.transform.position.z > ActiveEnd)
            {
                nutkowyKontener.GetComponent<note>().isActive = true;
            }
            else
            {
                nutkowyKontener.GetComponent<note>().isActive = false;
            }
        }
    }
}


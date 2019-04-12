using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastNote : MonoBehaviour
{
    public GameObject[] noteItself = new GameObject[7]; // 0 to bar
    public GameObject[] noteContainer = new GameObject[7]; // 0 to bar
    public GameObject n1;
    public GameObject n2;
    public GameObject n3;
    public GameObject n4;
    public GameObject n5;
    public GameObject n6;

    public GameObject nc1;
    public GameObject nc2;
    public GameObject nc3;
    public GameObject nc4;
    public GameObject nc5;
    public GameObject nc6;

    public Queue<GameObject> notesQueue1 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue2 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue3 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue4 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue5 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue6 = new Queue<GameObject>();
    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    public GameObject keyElement1;
    public GameObject keyElement2;
    public GameObject keyElement3;
    public GameObject keyElement4;
    public GameObject keyElement5;
    public GameObject keyElement6;
    public GameObject keyElement7;

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
        

    }

    void Update()
    {
        setAsTheLowest();
        addTheLowestNotesToGameObjects();
    }

    void createQueues()
    {

        foreach (var nutkowyKontener in allNotes)
        {
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 1)
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

    void setAsTheLowest()
    {
        notesQueue1.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue2.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue3.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue4.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue5.Peek().GetComponent<note>().isTheLowest = true;
        notesQueue6.Peek().GetComponent<note>().isTheLowest = true;
        //notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
    }

    void addTheLowestNotesToGameObjects()
    {
        if(notesQueue1.Count > 0)
        {
            nc1 = notesQueue1.Peek();
            n1 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }

        if (notesQueue2.Count > 0)
        {
            nc2 = notesQueue2.Peek();
            n2 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        if (notesQueue3.Count > 0)
        {
            nc3 = notesQueue3.Peek();
            n3 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        if (notesQueue4.Count > 0)
        {
            nc4 = notesQueue4.Peek();
            n4 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        if (notesQueue5.Count > 0)
        {
            nc5 = notesQueue5.Peek();
            n5 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        if (notesQueue6.Count > 0)
        {
            nc6 = notesQueue6.Peek();
            n6 = notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
    }
}


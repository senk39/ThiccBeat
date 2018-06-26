using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    Transform tf;


    private uint missOrNotActivated = 0;
    private uint great = 50;
    private uint perfect = 200;
    public uint actualNoteValue;

    public bool isNoteActive = false;

    static List<GameObject> ListOfNotes = new List<GameObject>();
    int ListOfNotesSize;
    public bool isTheLowest = false;
    float notex;

    public GameObject earlyActivator;
    public GameObject perfectActivator;
    public GameObject lateActivator;

    private float row1 = -5.1f;
    private float row2 = -3.1f;
    private float row3 = -1.1f;
    //====================
    private float row4 = 1.1f;
    private float row5 = 3.1f;
    private float row6 = 5.1f;


    public GameObject notePrefab;
    public GameObject[] allNotes;

    void Awake()
    {
        tf = GetComponent<Transform>();

       
    }


    // Use this for initialization
    void Start()
    {
        actualNoteValue = missOrNotActivated;
        autoIndicatorSetter();
        checkIfItsTheLowestNoteInARow();

        addNotesToList();


    }

    // Update is called once per frame
    void Update()
    {
        addNotesToList();
        if (actualNoteValue > 0)
        {
            isNoteActive = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Indicator")
        {
            actualNoteValue = perfect;
        }
        if (col.gameObject.tag == "TooEarlyIndicator" || col.gameObject.tag == "TooLateIndicator")
        {
            actualNoteValue = great;

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Indicator")
        {
            actualNoteValue = great;
        }
        if (col.gameObject.tag == "TooLateIndicator")
        {
            actualNoteValue = missOrNotActivated;
        }
    }

   void autoIndicatorSetter()
    {
        if (tf.position.x == row1)
        {
            earlyActivator = GameObject.Find("too early note indicator 1");
            perfectActivator = GameObject.Find("note indicator 1");
            lateActivator = GameObject.Find("too late note indicator 1");
        }

        if (tf.position.x == row2)
        {
            earlyActivator = GameObject.Find("too early note indicator 2");
            perfectActivator = GameObject.Find("note indicator 2");
            lateActivator = GameObject.Find("too late note indicator 2");
        }

        if (tf.position.x == row3)
        {
            earlyActivator = GameObject.Find("too early note indicator 3");
            perfectActivator = GameObject.Find("note indicator 3");
            lateActivator = GameObject.Find("too late note indicator 3");
        }

        if (tf.position.x == row4)
        {
            earlyActivator = GameObject.Find("too early note indicator 4");
            perfectActivator = GameObject.Find("note indicator 4");
            lateActivator = GameObject.Find("too late note indicator 4");
        }

        if (tf.position.x == row5)
        {
            earlyActivator = GameObject.Find("too early note indicator 5");
            perfectActivator = GameObject.Find("note indicator 5");
            lateActivator = GameObject.Find("too late note indicator 5");
        }

        if (tf.position.x == row6)
        {
            earlyActivator = GameObject.Find("too early note indicator 6");
            perfectActivator = GameObject.Find("note indicator 6");
            lateActivator = GameObject.Find("too late note indicator 6");
        }
    }


    void checkIfItsTheLowestNoteInARow()
    {
        notex = GetComponent<Transform>().position.x;
        //Debug.Log(notex);

    }

    void addNotesToList2()
    {
        if (GameObject.FindGameObjectWithTag("Note"))
        {
           // ListOfNotes.Add;
            //Debug.Log(ListOfNotes);

        }
    }

    void addNotesToList()
    {
        if (allNotes == null)
            allNotes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject note in allNotes)
        {

        }
    }

    /*
 
    void Start()
    {
        if (allNotes == null)
            allNotes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject note in allNotes)
        {
            
        }
    } 
    
    --
    
    public GameObject respawnPrefab;
    public GameObject[] respawns;
    void Start()
    {
        if (respawns == null)
            respawns = GameObject.FindGameObjectsWithTag("Respawn");

        foreach (GameObject respawn in respawns)
        {
            Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
        }
    } 
     */
}

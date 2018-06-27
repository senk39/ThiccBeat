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
    }

    // Update is called once per frame
    void Update()
    {

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





 
}

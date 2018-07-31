using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    Transform tf;

    private uint missOrNotActivated = 0;
    public uint great = 50;
    public uint perfect = 200;
    public uint actualNoteValue;

    public bool isNoteActive = false;

    public GameObject earlyActivator;
    public GameObject perfectActivator;
    public GameObject lateActivator;

    public GameObject tooLateNoteDestroyer;


  


    void Awake()
    {
        tf = GetComponent<Transform>();
        tooLateNoteDestroyer = GameObject.Find("late miss indicator");
    }

    // Use this for initialization
    void Start()
    {
        actualNoteValue = missOrNotActivated;
    }

    // Update is called once per frame
    void Update()
    {
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

        /*
        if (col.gameObject == tooLateNoteDestroyer)
        {
            Debug.Log("39");
            Destroy(gameObject);
        }
        */
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
        //if(col.gameObject.)
    }

    
}
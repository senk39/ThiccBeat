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

    public GameObject pinkBar;
    private float positionZero;

    private const float perfectDistance = 2.5f;
    private const float greatDistance = 6f;

    private float row1x = -5.1f;
    private float row2x = -3.1f;
    private float row3x = -1.1f;
    private float row4x = 1.1f;
    private float row5x = 3.1f;
    private float row6x = 5.1f;

    public bool row1 = false;
    public bool row2 = false;
    public bool row3 = false;
    public bool row4 = false;
    public bool row5 = false;
    public bool row6 = false;


    public List<GameObject> notesInRow1 = new List<GameObject>();
    List<GameObject> notesInRow2 = new List<GameObject>();
    List<GameObject> notesInRow3 = new List<GameObject>();
    List<GameObject> notesInRow4 = new List<GameObject>();
    List<GameObject> notesInRow5 = new List<GameObject>();
    List<GameObject> notesInRow6 = new List<GameObject>();



    void Awake()
    {
        tf = GetComponent<Transform>();
    }

    void Start()
    {
        actualNoteValue = missOrNotActivated; // gdy nuta jest tworzona dostaje wartosc 0 punktów.
        pinkBar = GameObject.Find("pink stripe 1");
        positionZero = pinkBar.transform.position.z; // punkt perfect jest tam gdzie różowa pozioma belka


    }

    void Update()
    {
        
        if (actualNoteValue > 0) //ten warunek jest do zmiany z pewnością jeśli chcesz aby nutki się klikały w dobrej kolejności 
        {

            //hycnij te nutki
            isNoteActive = true;
        }
        noteValueChanger();
        checkRow();
    }

    void noteValueChanger()
    {
        float noteZPos = tf.position.z;
       
        if (Mathf.Abs(noteZPos - positionZero) <= perfectDistance)
        {
            actualNoteValue = perfect;
        }
        else if (Mathf.Abs(noteZPos - positionZero) <= greatDistance)
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

    void checkRow()
    {
       
        float noteXPos = tf.position.x;

        if (noteXPos == row1x)
        {
            row1 = true;
        }

        else if (noteXPos == row2x)
        {
            row2 = true;
        }

        else if (noteXPos == row3x)
        {
            row3 = true;
        }

        else if (noteXPos == row4x)
        {
            row4 = true;
        }

        else if (noteXPos == row5x)
        {
            row5 = true;
        }

        else if (noteXPos == row6x)
        {
            row6 = true;
        }
    }

}
    


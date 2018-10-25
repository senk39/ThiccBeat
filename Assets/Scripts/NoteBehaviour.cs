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




    void Awake()
    {
        tf = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start()
    {
        actualNoteValue = missOrNotActivated; // gdy nuta jest tworzona dostaje wartosc 0 punktów.
        pinkBar = GameObject.Find("pink stripe 1");
        positionZero = pinkBar.transform.position.z; // punkt perfect jest tam gdzie różowa pozioma belka


    }

    // Update is called once per frame
    void Update()
    {
        
        if (actualNoteValue > 0) //ten warunek jest do zmiany z pewnością jeśli chcesz aby nutki się klikały w dobrej kolejności :V 
        {

            //hycnij te nutki
            isNoteActive = true;

        }
        noteValueChanger();
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
        //if(col.gameObject.)
    }
}
    


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class noteGenerator : MonoBehaviour
{


    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    // GENERATOR
    public TextAsset row1;
    public TextAsset row2;
    public TextAsset row3;
    public TextAsset row4;
    public TextAsset row5;
    public TextAsset row6;
    public string textContent1;


    public float firstNote = 105.15f;
    public bool notesGenerator = true;
    public GameObject gnote;
    Vector3 gnotevector = new Vector3(0f, 0.35f, -14.19f);
    Quaternion gnoteq = new Quaternion(0f, 0f, 0f, 0f);

    //BPM
    public float bpm = 195f;
    public float distBetweenNotes;

    

    // Use this for initialization
    void Start()
    {
        distBetweenNotes = (60/bpm);

        InvokeRepeating("noteInstantiateForGenerator", 3f, distBetweenNotes);

        textContent1 = row1.text;

    }

    // Update is called once per frame
    void Update()
    {

        
     
            //if (Input.GetKeyDown(key))
            //{
            //Debug.Log(Time.deltaTime);
            //Instantiate(gnote, gnotevector,gnoteq);
            //}
        


    }

    void noteInstantiateForGenerator()
    {
        Instantiate(gnote, gnotevector, gnoteq);
    }
}
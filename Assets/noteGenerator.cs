using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteGenerator : MonoBehaviour
{


    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    // GENERATOR
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
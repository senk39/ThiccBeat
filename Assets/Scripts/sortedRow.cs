using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortedRow : MonoBehaviour {

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


    private float row1 = -5.1f;
    private float row2 = -3.1f;
    private float row3 = -1.1f;
    //====================
    private float row4 = 1.1f;
    private float row5 = 3.1f;
    private float row6 = 5.1f;
    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        tf = GetComponent<Transform>();
        tooLateNoteDestroyer = GameObject.Find("late miss indicator");
    }

    // Update is called once per frame
    void Update () {
		
	}

    void addNoteToProperList()
    {
        if (tf.position.x == row1)
        {
        }

        if (tf.position.x == row2)
        {

        }

        if (tf.position.x == row3)
        {

        }

        if (tf.position.x == row4)
        {

        }

        if (tf.position.x == row5)
        {

        }

        if (tf.position.x == row6)
        {

        }
    }


}

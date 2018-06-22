using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour {

    private uint missOrNotActivated = 0;
    private uint great = 50;
    private uint perfect = 200;
    public uint actualNoteValue;

    public GameObject earlyActivator;
    public GameObject perfectActivator;
    public GameObject lateActivator;



    // Use this for initialization
    void Start () {

        actualNoteValue = missOrNotActivated;

}

// Update is called once per frame
void Update () {

		
	}

    void OnCollisionStay(Collider col)
    {
        if (col.gameObject.tag == "TooEarlyIndicator" || col.gameObject.tag == "TooLateIndicator")
        {
            actualNoteValue = great;
        }
        if (col.gameObject.tag == "Indicator")
        {
            actualNoteValue = perfect;
        }
    }

}

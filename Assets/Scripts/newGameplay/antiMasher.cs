using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiMasher : MonoBehaviour
{

    private float row1 = -5.1f;
    private float row2 = -3.1f;
    private float row3 = -1.1f;
    private float row4 = 1.1f;
    private float row5 = 3.1f;
    private float row6 = 5.1f;

    public bool thereIsANoteOnRow1 = false;
   // bool key2IsAllowed = true;
   // bool key3IsAllowed = true;
   // bool key4IsAllowed = true;
   // bool key5IsAllowed = true;
   // bool key6IsAllowed = true;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Note")
        {
            if (col.gameObject.transform.position.x == row1)
            {
                thereIsANoteOnRow1 = true;
            }

            else if (col.gameObject.transform.position.x == row2)
            {

            }

            else if (col.gameObject.transform.position.x == row3)
            {

            }
            else if (col.gameObject.transform.position.x == row4)
            {

            }
            else if (col.gameObject.transform.position.x == row5)
            {

            }
            else if (col.gameObject.transform.position.x == row6)
            {

            }
        }

    }

            private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note")
        {
            if (col.gameObject.transform.position.x == row1)
            {
                thereIsANoteOnRow1 = false;
            }

            else if (col.gameObject.transform.position.x == row2)
            {

            }

            else if (col.gameObject.transform.position.x == row3)
            {

            }
            else if (col.gameObject.transform.position.x == row4)
            {

            }
            else if (col.gameObject.transform.position.x == row5)
            {

            }
            else if (col.gameObject.transform.position.x == row6)
            {

            }
        }
    }

}

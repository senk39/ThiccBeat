using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Indicator")
        {
            col.gameObject.GetComponent<pressingNotes>().isActive = true;
            col.gameObject.GetComponent<pressingNotes>().go = transform.gameObject;

        }

        if (col.tag == "TooLateIndicator")
        {
            col.gameObject.GetComponent<pressingNotes>().go = null;
            Destroy(gameObject);
        }


    }

    private void OnTriggerExit(Collider col) 
    {
        if (col.tag == "Indicator")
        {
            col.gameObject.GetComponent<pressingNotes>().isActive = false;

        }
    }

    
}
*/
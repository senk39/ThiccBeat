using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    Rigidbody rb;
    public float notesVelocity = 20;

    GameObject activator;

    public GameObject TooEarlyIndicator;
    public GameObject TooLateIndicator;
    public GameObject PerfectIndicator;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {

        rb.velocity = new Vector3(0, 0, -notesVelocity);
	}
	
	// Update is called once per frame
	void Update () {		
	}



    void whenNoteCollidesWithTwoActivators(Collider col)


    {

        bool isTooEarlyIndicatorTrue = TooEarlyIndicator.GetComponent<activator>().active;
        bool isTooLateIndicatorTrue = TooLateIndicator.GetComponent<activator>().active;
        bool isPerfectIndicatorTrue = PerfectIndicator.GetComponent<activator>().active;


        int currentNoteValue = PerfectIndicator.GetComponent<activator>().currentNoteValue;
        int perfectHitPoints = PerfectIndicator.GetComponent<activator>().perfectHitPoints;

        if (isPerfectIndicatorTrue == true && isTooEarlyIndicatorTrue == true)
        {

            TooEarlyIndicator.GetComponent<Collider>().enabled = false;

            //isTooEarlyIndicatorTrue = false;
            //currentNoteValue = perfectHitPoints;
            //Physics.IgnoreCollision(TooEarlyIndicator.collider, collider);

        }

        if (isPerfectIndicatorTrue == true && isTooLateIndicatorTrue == true)
        {
            TooLateIndicator.GetComponent<Collider>().enabled = false;


            //isTooLateIndicatorTrue = false;
            //currentNoteValue = perfectHitPoints;
        }
        if (isPerfectIndicatorTrue == true)
        {
            currentNoteValue = perfectHitPoints;
        }
    }
      













    /*
    bool isTooEarlyIndicatorTrue    = TooEarlyIndicator.GetComponent<activator>().active;
    bool isTooLateIndicatorTrue     = TooLateIndicator.GetComponent<activator>().active;



    if (col.gameObject.tag == "Indicator")
    {

        //currentNoteValue = pointsPerNote;

        if(isTooEarlyIndicatorTrue)
        {
            isTooEarlyIndicatorTrue = false;
        }

        if (isTooLateIndicatorTrue)
        {
            isTooLateIndicatorTrue = false;
        }


    }
    */


}



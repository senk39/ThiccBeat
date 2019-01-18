using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Indicator")
        {
            Debug.Log("uwu");
        }

        if (col.tag == "TooLateIndicator")
        {
            Destroy(gameObject);
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastNoteBehaviour : MonoBehaviour {

    static public bool lastNoteDone;

    void Awake()
    {
        lastNoteDone = false;
    }
    void Start (){
        
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pink Bar")
        {
            lastNoteDone = true;
        }
    }
}

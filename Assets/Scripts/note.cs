﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    Rigidbody rb;
    //activator akti;
    public float notesVelocity = 20;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //akti = GetComponent<activator>();
    }

	// Use this for initialization
	void Start () {

        rb.velocity = new Vector3(0, 0, -notesVelocity);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

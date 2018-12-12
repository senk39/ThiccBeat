﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    Rigidbody rb;
    public float notesVelocity = 1;
    public bool isTheLowest = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        if(Time.fixedTime < 0.5f)
        {
            rb.velocity = new Vector3(0, 0, (-notesVelocity / Time.deltaTime));
        }
        else
        {
            //rb.velocity = new Vector3(0, 0, -notesVelocity / Time.deltaTime);
            rb.velocity = new Vector3(0, 0, (-notesVelocity / Time.deltaTime));

        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
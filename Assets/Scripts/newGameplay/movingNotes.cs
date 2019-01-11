﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingNotes : MonoBehaviour {

    public float noteVelocity = 1;
    Rigidbody rb;

    bool startPlay = false;

    // Use this for initialization
    void Start () {
		
	}
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isGamePaused == false)
        {
            if (Input.anyKeyDown)
            {
                startPlay = true;
            }
            if (startPlay == true)
            {
                rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
            }


        }
        
    }

}
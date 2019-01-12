using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    public float noteVelocity = 0.7f;
    Rigidbody rb;

    bool anyKeyPressedToStart = false;

    public bool isTheLowest = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        if(rb.gameObject.tag=="NoteBar")
        {
            isTheLowest = true;
        }
        
    }

	void Start () {

    }

    void Update() {

        if (Input.anyKeyDown)
        {
            anyKeyPressedToStart = true;
        }
        
        if (pause.isGamePaused == false && anyKeyPressedToStart == true)
        {
            rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
        }
        
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    public float noteVelocity = 1;
    Rigidbody rb;


    public bool isTheLowest = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if(rb.gameObject.tag=="NoteBar")
        {
            isTheLowest = true;
        }
    }

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update() {
        if (pause.isGamePaused == false)
        {
            rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
            Debug.Log(Time.deltaTime);
        }
    }
}
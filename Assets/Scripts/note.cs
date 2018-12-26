using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class note : MonoBehaviour {

    Rigidbody rb;
    public float notesVelocity = 1;
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
            rb.velocity = new Vector3(0, 0, (-notesVelocity / Time.deltaTime));
        }
    }
}
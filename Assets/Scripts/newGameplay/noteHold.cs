using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class noteHold : MonoBehaviour {

    Rigidbody rb;
    public float notesVelocity = 39;
    public bool isTheLowest = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

        rb.velocity = new Vector3(0, 0, -notesVelocity);
    }

    // Update is called once per frame
    void Update()
    {
    }



}



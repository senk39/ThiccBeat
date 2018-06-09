﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activator : MonoBehaviour {

    public KeyCode key;
    public bool active = false;
    GameObject note;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            //score.scoreValue += 1;
            active = false;

        }

    }
    void OnTriggerEnter(Collider col)
    {
        active = true;
        if(col.gameObject.tag=="Note")
        {
            note = col.gameObject;

        }
    }

    void OnTriggerExit(Collider col)
    {
        active = false;

    }
}

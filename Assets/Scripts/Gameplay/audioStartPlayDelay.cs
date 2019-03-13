﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStartPlayDelay : MonoBehaviour {

    AudioSource songAudio;

    public bool anyKeyPressedToStart = false;

    // Use this for initialization
    void Start () {

        songAudio = GetComponent<AudioSource>();


        //songAudio.PlayDelayed(3f);

	}
	
	// Update is called once per frame
	void Update () {
        if (anyKeyPressedToStart == false)
        {
            if (Input.anyKeyDown)
            {
                anyKeyPressedToStart = true;
                songAudio.PlayDelayed(3);

            }
        }

    }
}
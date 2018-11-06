using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStartPlayDelay : MonoBehaviour {

    AudioSource songAudio;

	// Use this for initialization
	void Start () {

        songAudio = GetComponent<AudioSource>();
        songAudio.PlayDelayed(3f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

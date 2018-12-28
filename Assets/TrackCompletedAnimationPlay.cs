using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCompletedAnimationPlay : MonoBehaviour {
    public Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.Play("Idle");
    }
	
	// Update is called once per frame
	void Update () {
        if (lastNoteBehaviour.lastNoteDone == true)
        {
            anim.Play("TrackCompleted");
        }
	}
}

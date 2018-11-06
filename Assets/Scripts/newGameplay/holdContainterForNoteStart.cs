using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteStart : MonoBehaviour {

    public GameObject holdMid;
    public GameObject holdEnd;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform.parent)
        {
            if (child.name != this.name)
            {
                Debug.Log("Found sibling " + child.name);
                // work with child here
                if(child.name == "noteMid")
                {
                    holdMid = child.gameObject;
                }
                else if (child.name == "noteEnd")
                {
                    holdEnd = child.gameObject;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

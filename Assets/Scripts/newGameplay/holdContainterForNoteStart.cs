using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteStart : MonoBehaviour {

    public GameObject holdMid;
    public GameObject holdEnd;

    void Start () {
        foreach (Transform child in transform.parent)
        {
            if (child.name != this.name)
            {
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
}

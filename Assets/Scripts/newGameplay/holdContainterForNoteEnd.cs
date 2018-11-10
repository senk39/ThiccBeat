﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteEnd : MonoBehaviour {

    public GameObject holdMid;
    public GameObject holdStart;

    void Start () {
        foreach (Transform child in transform.parent)
        {
            if (child.name != this.name)
            {
                if(child.name == "pivot")
                {
                    //holdMid = child.gameObject;
                    holdMid = child.Find("noteMid").gameObject;
                }
                else if (child.name == "noteStart")
                {
                    holdStart = child.gameObject;
                }
            }
        }
    }
}

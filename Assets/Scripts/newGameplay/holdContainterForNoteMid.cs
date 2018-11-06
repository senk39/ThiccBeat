using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteMid : MonoBehaviour {

    public GameObject holdStart;
    public GameObject holdEnd;

    void Start () {
        foreach (Transform child in transform.parent)
        {
            if (child.name != this.name)
            {
                if(child.name == "noteStart")
                {
                    holdStart = child.gameObject;
                }
                else if (child.name == "noteEnd")
                {
                    holdEnd = child.gameObject;
                }
            }
        }
    }
}

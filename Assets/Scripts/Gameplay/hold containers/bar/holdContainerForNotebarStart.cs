using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainerForNotebarStart : MonoBehaviour {

    public GameObject holdMid;
    public GameObject holdEnd;

    void Start()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.name != this.name)
            {
                if (child.name == "pivot")
                {
                    holdMid = child.Find("notebarMid").gameObject;
                }
                else if (child.name == "notebarEnd")
                {
                    holdEnd = child.gameObject;
                }
            }
        }
    }
}

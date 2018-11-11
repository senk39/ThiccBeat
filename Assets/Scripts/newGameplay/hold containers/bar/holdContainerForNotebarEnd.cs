using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainerForNotebarEnd : MonoBehaviour {

    public GameObject holdMid;
    public GameObject holdStart;

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
                else if (child.name == "notebarStart")
                {
                    holdStart = child.gameObject;
                }
            }
        }
    }
}

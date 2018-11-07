﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteMid : MonoBehaviour {

    public GameObject holdStart;
    public GameObject holdEnd;

    public GameObject pivot;

    public bool isActivated = false;
   // Transform tf;
    Vector3 tfv3;
    Vector3 posv3;

    public float shrinkSpeed;

    void Start () {
        //tf = transform;

        
        if(transform.parent.name == "pivot")
        {
            pivot = transform.parent.gameObject;
        }

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

    void Update()
    {
        posv3 = pivot.transform.position;
        tfv3 = pivot.transform.localScale;
        if (holdStart == null)
        {
            isActivated = true;
        }
    }

    void OnTriggerStay(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Pink Bar" && isActivated)
        {
            if (tfv3.z > 0)
            {
                posv3.z = -14.2f;
                pivot.GetComponent<note>().notesVelocity = 0;
                GetComponent<note>().notesVelocity = 0;
                tfv3.z -= 1.1f;
                //posv3.z -= 11f;
                //transform.position = posv3;
                pivot.transform.localScale = tfv3;
            }
            else
            {
                Destroy(transform.gameObject);
            }
            
        }
    }
}

using System.Collections;
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

    public float pivotZPos;

    public bool noteStartIsClicked = false;

    void Start () {
        //tf = transform;

        
        if(transform.parent.name == "pivot")
        {
            pivot = transform.parent.gameObject;
            pivotZPos = pivot.transform.position.z;
        }

        foreach (Transform child in transform.parent.parent)
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
        if(collisionInfo.gameObject.tag == "Pink Bar" && isActivated && noteStartIsClicked)
        {
            if (tfv3.z > 0)
            {
                posv3.z = -14.2f;
                pivot.GetComponent<note>().notesVelocity = 0;
                GetComponent<note>().notesVelocity = 0;
                tfv3.z -= 0.22f;
                //posv3.z -= 11f;
                //transform.position = posv3;
                pivot.transform.localScale = tfv3;
                pivot.transform.position = posv3;
            }
            else
            {
                tfv3.z = 0f;
                pivot.transform.localScale = tfv3; 
                Destroy(transform.gameObject);

                Destroy(holdEnd);
            }
            
        }
    }
}

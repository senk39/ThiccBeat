using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAllStripes : MonoBehaviour {

    public Vector3 pos;
    public Transform tf;
    public float speed;
    

void Start () {
        pos = tf.position;
        speed = 1f;
	}

void Update()
    {
        if (pos.x >= (580f))        

        {
            pos.x = 0f;
        }
        else
        {
            pos.x += speed;
            tf.position = pos;
        }
    }
}

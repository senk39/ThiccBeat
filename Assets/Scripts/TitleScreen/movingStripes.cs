using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingStripes : MonoBehaviour {

    RectTransform tf;
    
    public float posx;
    
    int scrollingSpeed = 5;
    public float x;
    public float y;
    public float z;



// Use this for initialization
void Start () {
        tf = GetComponent<RectTransform>();
        posx = tf.position.x;
        y = tf.position.y;
        z = tf.position.z;
        tf.TransformVector(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
        

        if (x < 355)
        {
            x += scrollingSpeed;

        }
        else
        {
            x = -455;
        }


    }
}

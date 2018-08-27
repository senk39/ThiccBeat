using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAllStripes : MonoBehaviour {

    public Vector3 pos;
    public Transform tf;
    public float speed;
    

// Use this for initialization
void Start () {
        pos = tf.position;
        speed = 5f;
        Debug.Log(pos);

	}

    // Update is called once per frame
    void Update()
    {
        //pos.y = 180f;
        if (pos.x >= 755f)           //755 było prawie ok wartocią

        {
            pos.x = -455f;
           

        }
        else
        {
            pos.x += speed;
            tf.position = pos;
        }
    }
}

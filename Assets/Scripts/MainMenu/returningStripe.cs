using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class returningStripe : MonoBehaviour {

    public Vector3 pos;
    public Transform tf;
    public float speed;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = tf.position;
        speed = 5f;
        
            if (pos.x >= (4761f))

            {
                pos.x = -3240f;
                tf.position = pos;
            }
            else
            {
                pos.x += speed;
                tf.position = pos;
            }
        
    }
}

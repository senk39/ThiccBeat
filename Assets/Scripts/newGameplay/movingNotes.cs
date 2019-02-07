using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingNotes : MonoBehaviour {

    public float noteVelocity = 1f;
    Rigidbody rb;

    bool startPlay = false;



    // Use this for initialization
    void Start () {
		
	}
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.isGamePaused == false)
        {
            if (Input.anyKeyDown)
            {
                startPlay = true;
            }
            if (startPlay == true)
            {
                rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
                //rb.transform.position += ((-Vector3.forward*100) * Time.deltaTime);
            }


        }
        
    }

}

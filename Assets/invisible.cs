using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour {
    // MeshRenderer meshr;
    //Renderer rend;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().enabled = false;




    }

    // Update is called once per frame
    void Update () {
		
	}
}

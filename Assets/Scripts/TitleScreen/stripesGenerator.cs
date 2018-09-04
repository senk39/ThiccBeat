using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripesGenerator : MonoBehaviour {

    public GameObject stripe;
    public Transform stripeTr;
    public GameObject father;
    public Transform fatherTr;


    // Use this for initialization
    void Start () {
        stripe = GameObject.Find("SingleStripe");
        stripeTr = GameObject.Find("SingleStripe").transform;
        father = GameObject.Find("Stripes");
        fatherTr = GameObject.Find("Stripes").transform;


        for (int i = 0; i < 10; i++)
        {
            Instantiate(stripeTr, new Vector3(i * 20.0F, 0, 0), Quaternion.identity);
            stripeTr.parent = fatherTr;
            

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

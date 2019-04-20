using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HaniaWelcomesYou : MonoBehaviour {

    AudioClip[] HaniaWelcome = new AudioClip[13];
    public List<AudioClip> HaniaList = new List<AudioClip>();
    public GameObject[] HaniaObjArray = new GameObject[13];


    // Use this for initialization
    void Awake () {

        HaniaObjArray = GameObject.FindGameObjectsWithTag("Hania");

        for (int i = 0; i < HaniaObjArray.Length; i++)
        {
            HaniaList.Add(HaniaObjArray[i].gameObject.GetComponent<AudioSource>().clip);
        }

       // GetComponent<AudioSource>().clip = HaniaList[Random.Range(0,13)];
        //GetComponent<AudioSource>().Play();
        InvokeRepeating("sayAgain", 1f, 20f);
    }
	
	// Update is called once per frame
	void Update () {

        

        

    }

    void sayAgain()
    {
        GetComponent<AudioSource>().clip = HaniaList[Random.Range(0, 13)];

        GetComponent<AudioSource>().Play();
    }
}

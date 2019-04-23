using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HaniaWelcomesYou : MonoBehaviour {

    AudioClip[] HaniaWelcome = new AudioClip[13];
    public List<AudioClip> HaniaList = new List<AudioClip>();
    public GameObject[] HaniaObjArray;
    int HaniaCounter;

    int randomNumber2 = 500;


    void Awake () {

        HaniaCounter = GameObject.FindGameObjectsWithTag("Hania").Length;
        HaniaObjArray = new GameObject[HaniaCounter];
        
        HaniaObjArray = GameObject.FindGameObjectsWithTag("Hania");


        for (int i = 0; i < HaniaObjArray.Length; i++)
        {
            HaniaList.Add(HaniaObjArray[i].gameObject.GetComponent<AudioSource>().clip);
        }

        //  GetComponent<AudioSource>().clip = HaniaList[Random.Range(0,13)];
        //  GetComponent<AudioSource>().Play();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            InvokeRepeating("sayAgain", 1f, 20f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            InvokeRepeating("sayAgain", 1f, 15f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8) //QUIT MENU
        {
            Invoke("sayAgain", 0.39f);
        }
    }

    
	
    void sayAgain()
    {
        
        int randomNumber = Random.Range(0, HaniaObjArray.Length);
        if(randomNumber2 != randomNumber)
        {
            GetComponent<AudioSource>().clip = HaniaList[randomNumber];
            GetComponent<AudioSource>().Play();
            Debug.Log("Wylosowano: " +HaniaList[randomNumber]);
            randomNumber2 = randomNumber;
        }
        else
        {
            Debug.Log("byly takie same!!!");
            sayAgain();
        }
        

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && Input.GetKeyDown(KeyCode.G))
        {
            int randomNumber = Random.Range(0, HaniaObjArray.Length);
            GetComponent<AudioSource>().clip = HaniaList[randomNumber];
            GetComponent<AudioSource>().Play();
        }
    }


}

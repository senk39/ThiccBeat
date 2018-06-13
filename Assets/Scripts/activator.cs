using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {
    public GameObject playerScoreObject;

    playerScore skor;

    // Use this for initialization
    
    //
    public KeyCode key;
    public bool active = false;
    public int currentNoteValue = 0;
    GameObject note;
    // int myCube = GameObject.FindObjectOfType<playerScore>.GetComponent<playerCurrentScreen>;


  

    // Use this for initialization
    void Start () {
        skor = GetComponent<playerScore>();

    }

    // Update is called once per frame
    void Update () {

        //playerScoreAsText.text = playerCurrentScore.ToString();


        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            AddScore();
            active = false;
            skor.playerCurrentScore += 69;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        active = true;
        if(col.gameObject.tag=="Note")
        {
            currentNoteValue = 50;
            note = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        active = false;
        currentNoteValue = 0;
    }

   public void AddScore()
    {

        // += 50;

        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
    }
}

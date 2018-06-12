using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public int playerScore;
    public KeyCode keyA = KeyCode.A;
    public Text playerScoreAsText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerScoreAsText.text = playerScore.ToString();
        if (Input.GetKeyDown(keyA))
        {

            playerScore += 100;
        }
    }
}

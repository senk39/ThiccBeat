
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{

    public int playerCurrentScore;
    public KeyCode keyA = KeyCode.A;
    public Text playerScoreAsText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

        //playerScoreAsText.text = playerCurrentScore.ToString();



        if (Input.GetKeyDown(KeyCode.A))
        {
            playerCurrentScore += 4;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{

    public int playerCurrentScore = 0;
    public KeyCode keyA = KeyCode.A;
    public Text playerScoreAsText;

    

    // Update is called once per frame
    public void Update()
    {

        playerScoreAsText.text = playerCurrentScore.ToString();



        if (Input.GetKeyDown(KeyCode.A))
        {
            playerCurrentScore += 2;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerCurrentScore += 4;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerCurrentScore += 8;

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            playerCurrentScore += 16;

        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            playerCurrentScore += 32;

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            playerCurrentScore += 64;

        }
    }
}

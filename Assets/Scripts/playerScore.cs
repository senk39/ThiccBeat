
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{

    public int playerCurrentScore;
    public Text playerScoreAsText;

    public void Awake()
    {
        playerCurrentScore = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        playerScoreAsText.text = playerCurrentScore.ToString();

        if (lastNoteBehaviour.lastNoteDone == true)
        {
            PlayerPrefs.SetInt("lastGameScore", playerCurrentScore);
        }
    }

}


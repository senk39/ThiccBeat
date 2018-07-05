
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour
{

    public int playerCurrentScore = 0;
    public Text playerScoreAsText;

    // Update is called once per frame
    public void Update()
    {
        playerScoreAsText.text = playerCurrentScore.ToString();
    }

}


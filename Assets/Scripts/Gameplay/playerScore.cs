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

    public void Update()
    {
        playerScoreAsText.text = playerCurrentScore.ToString();

        if (lastNoteBehaviour.lastNoteDone == true)
        {
            PlayerPrefs.SetInt("lastGameScore", playerCurrentScore);
        }
    }
}


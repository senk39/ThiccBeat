using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class currentSong : SongListV2
{

    Song playedSong;
    public GameObject titleElement;
    public TextMeshProUGUI titleLabel;

    public GameObject artistElement;
    public TextMeshProUGUI artistLabel;

    public GameObject diffElement;
    public TextMeshProUGUI diffLabel;

    public GameObject scoreElement;
    public TextMeshProUGUI scoreLabel;

    public GameObject comboElement;
    public TextMeshProUGUI comboLabel;

    public GameObject goldScoreElement;
    public TextMeshProUGUI goldScoreLabel;

    public GameObject goldComboElement;
    public TextMeshProUGUI goldComboLabel;

    public GameObject silverScoreElement;
    public TextMeshProUGUI silverScoreLabel;

    public GameObject silverComboElement;
    public TextMeshProUGUI silverComboLabel;

    public GameObject bronzeScoreElement;
    public TextMeshProUGUI bronzeScoreLabel;

    public GameObject bronzeComboElement;
    public TextMeshProUGUI bronzeComboLabel;


    int combo;
    int score;

    int sIndex;

    int goldScore;
    int silverScore;
    int bronzeScore;

    int goldCombo;
    int silverCombo;
    int bronzeCombo;

    void Awake ()
    {
        
        playedSong = allSongs[selectedSongByUser];

        titleLabel = titleElement.GetComponent<TMPro.TextMeshProUGUI>();
        artistLabel = artistElement.GetComponent<TMPro.TextMeshProUGUI>();
        diffLabel = diffElement.GetComponent<TMPro.TextMeshProUGUI>();
        scoreLabel = scoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        comboLabel = comboElement.GetComponent<TMPro.TextMeshProUGUI>();

        goldScoreLabel = goldScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        goldComboLabel = goldComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverScoreLabel = silverScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverComboLabel = silverComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeScoreLabel = bronzeScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeComboLabel = bronzeComboElement.GetComponent<TMPro.TextMeshProUGUI>();


        combo = PlayerPrefs.GetInt("lastGameMaxCombo");
        score = PlayerPrefs.GetInt("lastGameScore");
        highScore();
        displayTop3Info();
        displaySongInfo();

        displayScoreInfo();
    }

    private void displayTop3Info()
    {
        goldScoreLabel.text = goldScore.ToString();
        goldComboLabel.text = goldCombo.ToString();
        silverScoreLabel.text = silverScore.ToString();
        silverComboLabel.text = silverCombo.ToString();
        bronzeScoreLabel.text = bronzeScore.ToString();
        bronzeComboLabel.text = bronzeCombo.ToString();
    }

    private void displaySongInfo()
    {
        titleLabel.text = playedSong.title;
        artistLabel.text = playedSong.artist;

        if (isCurrentDifficultyIsEasy == true)
        {   diffLabel.text = "EASY";    }
        else
        {   diffLabel.text = "HARD";    }
    }

    private void displayScoreInfo()
    {
        scoreLabel.text = score.ToString();
        comboLabel.text = combo.ToString();

        //deletePlayerPrefsKeys();
    }

    private static void deletePlayerPrefsKeys()
    {
        PlayerPrefs.DeleteKey("lastGameScore");
        PlayerPrefs.DeleteKey("lastGameMaxCombo");
    }

    public void highScore()
    {
        sIndex = playedSong.index;

        goldScore = PlayerPrefs.GetInt(sIndex + "GoldScore");
        silverScore = PlayerPrefs.GetInt(sIndex + "SilverScore");
        bronzeScore = PlayerPrefs.GetInt(sIndex + "BronzeScore");

        if(goldScore<score)
        {
            PlayerPrefs.SetInt(sIndex + "GoldScore", score);
            PlayerPrefs.SetInt(sIndex + "GoldCombo", combo);
            goldScore = score;
            goldCombo = combo;
            
        }
        else if (silverScore < score)
        {
            PlayerPrefs.SetInt(sIndex + "SilverScore", score);
            PlayerPrefs.SetInt(sIndex + "SilverCombo", combo);
            silverScore = score;
            silverCombo = combo;

        }
        else if (bronzeScore < score)
        {
            PlayerPrefs.SetInt(sIndex + "BronzeScore", score);
            PlayerPrefs.SetInt(sIndex + "BronzeCombo", combo);
            bronzeScore = score;
            bronzeCombo = combo;
        }

        Debug.Log(PlayerPrefs.GetInt(sIndex + "BronzeScore"));  //0
        Debug.Log(sIndex + "GoldScore"); //4Gold
    }


    void Update () {
        backtoSongSelectMenu();
    }

    public void backtoSongSelectMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
    }


}

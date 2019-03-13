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

    public GameObject diffStarsElement;
    public TextMeshProUGUI diffStarsLabel;

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

    public GameObject newHighScoreText;


    int combo;
    int score;

    uint sIndex;

    int goldScore;
    int silverScore;
    int bronzeScore;

    int goldCombo;
    int silverCombo;
    int bronzeCombo;

    string currentDiff;

    void Awake()
    {
        combo = PlayerPrefs.GetInt("lastGameMaxCombo");
        score = PlayerPrefs.GetInt("lastGameScore");

        newHighScoreText.SetActive(false);

        playedSong = allSongs[selectedSongByUser];

        titleLabel = titleElement.GetComponent<TMPro.TextMeshProUGUI>();
        artistLabel = artistElement.GetComponent<TMPro.TextMeshProUGUI>();
        diffLabel = diffElement.GetComponent<TMPro.TextMeshProUGUI>();
        diffStarsLabel = diffStarsElement.GetComponent<TMPro.TextMeshProUGUI>();
        scoreLabel = scoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        comboLabel = comboElement.GetComponent<TMPro.TextMeshProUGUI>();

        goldScoreLabel = goldScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        goldComboLabel = goldComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverScoreLabel = silverScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverComboLabel = silverComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeScoreLabel = bronzeScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeComboLabel = bronzeComboElement.GetComponent<TMPro.TextMeshProUGUI>();

        displaySongInfo();
        highScore();
        displayScoreInfo();
        displayTop3Info();
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
        artistLabel.text = playedSong.composer;

        string starSymbol = @"<sprite name=""star full""> ";
        int multiplierEasy = allSongs[selectedSongByUser].difficultyEasy;
        int multiplierHard = allSongs[selectedSongByUser].difficultyHard;

        if (isCurrentDifficultyIsEasy == true)
        {
            diffLabel.text = "EASY";
            currentDiff = "easy";
            diffStarsLabel.text = string.Join(starSymbol, new string[multiplierEasy + 1]);
        }
        else
        {
            diffLabel.text = "HARD";
            currentDiff = "hard";
            diffStarsLabel.text = string.Join(starSymbol, new string[multiplierHard + 1]);
        }
    }

    private void displayScoreInfo()
    {
        scoreLabel.text = score.ToString();
        comboLabel.text = combo.ToString();
    }

    public void highScore()
    {
        sIndex = playedSong.index;

        Debug.Log("song Index: " + playedSong.index + "currDiff: " + currentDiff);

        goldScore = PlayerPrefs.GetInt(sIndex + "GoldScore" + currentDiff);
        silverScore = PlayerPrefs.GetInt(sIndex + "SilverScore" + currentDiff);
        bronzeScore = PlayerPrefs.GetInt(sIndex + "BronzeScore" + currentDiff);

        goldCombo = PlayerPrefs.GetInt(sIndex + "GoldCombo" + currentDiff);
        silverCombo = PlayerPrefs.GetInt(sIndex + "SilverCombo" + currentDiff);
        bronzeCombo = PlayerPrefs.GetInt(sIndex + "BronzeCombo" + currentDiff);

        if (goldScore < score)
        {
            newHighScoreText.SetActive(true);

            PlayerPrefs.SetInt(sIndex + "GoldScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "GoldCombo" + currentDiff, combo);
            goldScore = score;
            goldCombo = combo;
            
        }
        else if (silverScore < score)
        {
            PlayerPrefs.SetInt(sIndex + "SilverScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "SilverCombo" + currentDiff, combo);
            silverScore = score;
            silverCombo = combo;

        }
        else if (bronzeScore < score)
        {
            PlayerPrefs.SetInt(sIndex + "BronzeScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "BronzeCombo" + currentDiff, combo);
            bronzeScore = score;
            bronzeCombo = combo;
        }
    }

    void Update () {
        backtoSongSelectMenu();
    }

    public void backtoSongSelectMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(2);
        }
    }
}
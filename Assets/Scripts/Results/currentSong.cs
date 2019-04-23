using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

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

    public GameObject accuracyElement;
    public TextMeshProUGUI accuracyLabel;


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
    

    public GameObject goldAccuracyElement;
    public TextMeshProUGUI goldAccuracyLabel;

    public GameObject silverAccuracyElement;
    public TextMeshProUGUI silverAccuracyLabel;

    public GameObject bronzeAccuracyElement;
    public TextMeshProUGUI bronzeAccuracyLabel;

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

    string goldAccuracy;
    string silverAccuracy;
    string bronzeAccuracy;

    string currentDiff;

    int correctNotes;
    double percentageScore;

    void Awake()
    {
        combo = PlayerPrefs.GetInt("lastGameMaxCombo");
        score = PlayerPrefs.GetInt("lastGameScore");
        correctNotes = PlayerPrefs.GetInt("lastGameCorrectNotes");
        countPercentageScoreX100();

        newHighScoreText.SetActive(false);

        playedSong = allSongs[selectedSongByUser];

        titleLabel = titleElement.GetComponent<TMPro.TextMeshProUGUI>();
        artistLabel = artistElement.GetComponent<TMPro.TextMeshProUGUI>();

        diffLabel = diffElement.GetComponent<TMPro.TextMeshProUGUI>();
        diffStarsLabel = diffStarsElement.GetComponent<TMPro.TextMeshProUGUI>();

        scoreLabel = scoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        comboLabel = comboElement.GetComponent<TMPro.TextMeshProUGUI>();
        accuracyLabel = accuracyElement.GetComponent<TMPro.TextMeshProUGUI>();

        goldScoreLabel = goldScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        goldComboLabel = goldComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        goldAccuracyLabel = goldAccuracyElement.GetComponent<TMPro.TextMeshProUGUI>();

        silverScoreLabel = silverScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverComboLabel = silverComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        silverAccuracyLabel = silverAccuracyElement.GetComponent<TMPro.TextMeshProUGUI>();

        bronzeScoreLabel = bronzeScoreElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeComboLabel = bronzeComboElement.GetComponent<TMPro.TextMeshProUGUI>();
        bronzeAccuracyLabel = bronzeAccuracyElement.GetComponent<TMPro.TextMeshProUGUI>();

        displaySongInfo();
        displayAccuracy();
        highScore();
        displayScoreInfo();
        displayTop3Info();
    }

    private void displayTop3Info()
    {
        goldScoreLabel.text = PlayerPrefs.GetInt(sIndex + "GoldScore" + currentDiff).ToString();
        goldComboLabel.text = PlayerPrefs.GetInt(sIndex + "GoldCombo" + currentDiff).ToString();
        goldAccuracyLabel.text = PlayerPrefs.GetString(sIndex + "GoldAccuracy" + currentDiff).ToString();

        silverScoreLabel.text = PlayerPrefs.GetInt(sIndex + "SilverScore" + currentDiff).ToString();
        silverComboLabel.text = PlayerPrefs.GetInt(sIndex + "SilverCombo" + currentDiff).ToString();
        silverAccuracyLabel.text = PlayerPrefs.GetString(sIndex + "SilverAccuracy" + currentDiff).ToString();

        bronzeScoreLabel.text = PlayerPrefs.GetInt(sIndex + "BronzeScore" + currentDiff).ToString();
        bronzeComboLabel.text = PlayerPrefs.GetInt(sIndex + "BronzeCombo" + currentDiff).ToString();
        bronzeAccuracyLabel.text = PlayerPrefs.GetString(sIndex + "BronzeAccuracy" + currentDiff).ToString();
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
        

        //str.Substring(0, Math.Min(str.Length, maxLength));
    }

    public void highScore()
    {
        sIndex = playedSong.index;

        //Debug.Log("song Index: " + playedSong.index + "currDiff: " + currentDiff);

        goldScore = PlayerPrefs.GetInt(sIndex + "GoldScore" + currentDiff);
        silverScore = PlayerPrefs.GetInt(sIndex + "SilverScore" + currentDiff);
        bronzeScore = PlayerPrefs.GetInt(sIndex + "BronzeScore" + currentDiff);

        goldCombo = PlayerPrefs.GetInt(sIndex + "GoldCombo" + currentDiff);
        silverCombo = PlayerPrefs.GetInt(sIndex + "SilverCombo" + currentDiff);
        bronzeCombo = PlayerPrefs.GetInt(sIndex + "BronzeCombo" + currentDiff);

        goldAccuracy = PlayerPrefs.GetString(sIndex + "GoldAccuracy" + currentDiff);
        silverAccuracy = PlayerPrefs.GetString(sIndex + "SilverAccuracy" + currentDiff);
        bronzeAccuracy = PlayerPrefs.GetString(sIndex + "BronzeAccuracy" + currentDiff);

        if (goldScore < score)
        {
            newHighScoreText.SetActive(true);
            if(goldScore > 0)
            {
                PlayerPrefs.SetInt(sIndex + "SilverScore" + currentDiff, goldScore);
                PlayerPrefs.SetInt(sIndex + "SilverCombo" + currentDiff, goldCombo);
                PlayerPrefs.SetString(sIndex + "SilverAccuracy" + currentDiff, goldAccuracy);
                silverScore = goldScore;
                silverCombo = silverCombo;
                silverAccuracy = silverAccuracy;
            }
            if (silverScore > 0)
            {
                PlayerPrefs.SetInt(sIndex + "BronzeScore" + currentDiff, silverScore);
                PlayerPrefs.SetInt(sIndex + "BronzeCombo" + currentDiff, silverCombo);
                PlayerPrefs.SetString(sIndex + "BronzeAccuracy" + currentDiff, silverAccuracy);
                bronzeScore = silverScore;
                bronzeCombo = silverCombo;
                bronzeAccuracy = silverAccuracy;
            }

            PlayerPrefs.SetInt(sIndex + "GoldScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "GoldCombo" + currentDiff, combo);
            PlayerPrefs.SetString(sIndex + "GoldAccuracy" + currentDiff, accuracyLabel.text);
            goldScore = score;
            goldCombo = combo;
            goldAccuracy = accuracyLabel.text;

        }
        else if (silverScore < score)
        {
            if (silverScore > 0)
            {
                PlayerPrefs.SetInt(sIndex + "BronzeScore" + currentDiff, silverScore);
                PlayerPrefs.SetInt(sIndex + "BronzeCombo" + currentDiff, silverCombo);
                PlayerPrefs.SetString(sIndex + "BronzeAccuracy" + currentDiff, silverAccuracy);
                bronzeScore = silverScore;
                bronzeCombo = silverCombo;
                bronzeAccuracy = silverAccuracy;
            }

            PlayerPrefs.SetInt(sIndex + "SilverScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "SilverCombo" + currentDiff, combo);
            PlayerPrefs.SetString(sIndex + "SilverAccuracy" + currentDiff, accuracyLabel.text);
            silverScore = score;
            silverCombo = combo;
            silverAccuracy = accuracyLabel.text;

        }
        else if (bronzeScore < score)
        {
            PlayerPrefs.SetInt(sIndex + "BronzeScore" + currentDiff, score);
            PlayerPrefs.SetInt(sIndex + "BronzeCombo" + currentDiff, combo);
            PlayerPrefs.SetString(sIndex + "BronzeAccuracy" + currentDiff, accuracyLabel.text);
            bronzeScore = score;
            bronzeCombo = combo;
            bronzeAccuracy = accuracyLabel.text;
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

    void countPercentageScoreX100()
    {
        double percents;
        if (isCurrentDifficultyIsEasy == true)
        {
            Debug.Log("coreectbites" + correctNotes);
            percents = correctNotes * 10000 / allSongs[selectedSongByUser].notesEasy;
            //Debug.Log("cn/allnotes*100 easy" + correctNotes * 100 / allSongs[selectedSongByUser].notesEasy);
            percentageScore = Math.Truncate(percents);
            Debug.Log(percentageScore);
        }
        else
        {
            Debug.Log("coreectbites" + correctNotes);
            percents = correctNotes * 10000 / allSongs[selectedSongByUser].notesHard;
            //Debug.Log("cn/allnotes*100 hard" + correctNotes * 100 / allSongs[selectedSongByUser].notesHard);
            percentageScore = Math.Truncate(percents);
            Debug.Log(percentageScore);
        }
    }

    void displayAccuracy()
    {
        accuracyLabel.text = percentageScore.ToString();
        if (accuracyLabel.text.Length == 4)
        {
            accuracyLabel.text = accuracyLabel.text.Insert(2, ",") + "%";
        }
        else if (accuracyLabel.text.Length == 5)
        {
            accuracyLabel.text = accuracyLabel.text.Insert(3, ",") + "%";
        }
        else if (accuracyLabel.text.Length == 3)
        {
            accuracyLabel.text = accuracyLabel.text.Insert(1, ",") + "%";
        }
    }
}
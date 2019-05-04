using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SongListV2 : MonoBehaviour
{
    static public List<Song> allSongs = new List<Song>();
    Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    GameObject parentObjForSelected;

    // ZMIENNE DLA ZAZNACZONEGO UTWORU
    public GameObject selArtistObj;
    TextMeshProUGUI selArtistLabel;

    public GameObject selTitleObj;
    TextMeshProUGUI selTitleLabel;

    public GameObject selDiffObj;
    TextMeshProUGUI selDiffLabel;

    public GameObject selDiffAltObj;
    TextMeshProUGUI selDiffAltLabel;

    public GameObject starEmpty;
    GameObject starFilled;

    public GameObject selGenreObj;
    TextMeshProUGUI selGenreLabel;

    public TextMeshProUGUI selHighScore1;
    TextMeshProUGUI selHighScore1Label;

    public TextMeshProUGUI selHighScore2;
    TextMeshProUGUI selHighScore2Label;

    public TextMeshProUGUI selHighScore3;
    TextMeshProUGUI selHighScore3Label;

    public TextMeshProUGUI selHighScore1Acc;
    TextMeshProUGUI selHighScore1LabelAcc;

    public TextMeshProUGUI selHighScore2Acc;
    TextMeshProUGUI selHighScore2LabelAcc;

    public TextMeshProUGUI selHighScore3Acc;
    TextMeshProUGUI selHighScore3LabelAcc;

    public TextMeshProUGUI selHighScore1Combo;
    TextMeshProUGUI selHighScore1LabelCombo;

    public TextMeshProUGUI selHighScore2Combo;
    TextMeshProUGUI selHighScore2LabelCombo;

    public TextMeshProUGUI selHighScore3Combo;
    TextMeshProUGUI selHighScore3LabelCombo;

    public GameObject selCoverObj;

    public static int selectedSongByUser;

    AudioSource clickAudio;

    static public bool isCurrentDifficultyIsEasy = false;

    public Sprite hardBorder;
    public Sprite easyBorder;

    public Sprite hardTab;
    public Sprite easyTab;




    int goldScoreLabel;
    int silverScoreLabel;
    int bronzeScoreLabel;


    AudioSource acChangeSong;
    AudioSource acChangeDiff;
    AudioSource acBack;
    AudioSource acEnter;

    public GameObject acConChangeSong;
    public GameObject acConChangeDiff;
    public GameObject acConBack;
    public GameObject acConEnter;

    public class Song
    {
        public static uint totalAmount = 0;

        public uint index;

        public string title { get; set; }
        public string composer;
        public string vocalist;
        public string illustrator;
        public string lyricist;
        public string genre1;
        public string genre2;
        public ushort BPM;

        public string audioLength;
        public uint notesEasy;
        public uint notesHard;

        public byte difficultyEasy;
        public byte difficultyHard;

        public Sprite cover;

        public bool isSelectedInMenu;
        public Song()  // KONSTRUKTOR
        {
            index = 0;
            title = "Unknown title";
            composer = "Unknown artist";
            vocalist = "Unknown vocalist";
            illustrator = "Unknown illustrator";
            lyricist = "Unknown lyricist";
            genre1 = "Unknown Genre";
            genre2 = null;
            BPM = 0;
            isSelectedInMenu = false;

            totalAmount++;
        }

        public Song(uint _index, string _title, string _composer, string _vocalist, string _illustrator,
                    string _lyricist, string _genre1, string _genre2, ushort _BPM,
                    string _audioLength, uint _notesEasy, uint _notesHard, byte _difficultyEasy, byte _difficultyHard)  // KONSTRUKTOR
        {
            index = _index;
            title = _title;
            composer = _composer;
            vocalist = _vocalist;
            illustrator = _illustrator;
            lyricist = _lyricist;
            genre1 = _genre1;
            genre2 = _genre2;
            BPM = _BPM;

            audioLength = _audioLength;
            notesEasy = _notesEasy;
            notesHard = _notesHard;

            difficultyEasy = _difficultyEasy;
            difficultyHard = _difficultyHard;

            totalAmount++;
        }

        public void showInfoForDebugging()
        {
            Debug.Log(title);
            Debug.Log("index: " + index);
            Debug.Log("title: " + title);
            Debug.Log("composer: " + composer);
            Debug.Log("vocalist: " + vocalist);
            Debug.Log("illustrator: " + illustrator);
            Debug.Log("lyricist: " + lyricist);
            Debug.Log("genre1: " + genre1);
            Debug.Log("genre2: " + genre2);
            Debug.Log("BPM: " + BPM);
        }
    }


    static Song aiaiai = new Song(
        0, "AIAIAI", "Yasutaka Nakata", "Kizuna AI", null, null, "electropop", "virtual youtuber", 128, "3:13", 324, 667, 2, 10);

    static Song sixtrillion = new Song(
        1, "A Tale of Six Trillion Years and a Night", "kemu", "IA", null, null, "synth-rock", "vocaloid", 186, "1:42", 272, 522, 4, 10);

    static Song hitorigoto = new Song(
        2, "Hitorigoto", "ClariS", null, null, null, "j-pop", "anime", 165, "3:13", 203, 367, 2, 7);

    static Song killthislove = new Song(
        3, "Kill This Love", "BLACKPINK", null, null, null, "k-pop", null, 132, "3:13", 1, 485, 1, 5);

    static Song badapple = new Song(
        4, "Bad Apple!!", "Alstroemeria Records", "nomico", null, null, "edm", "touhou", 138, "3:13", 247, 451, 3, 6);

    static Song japaripark = new Song(
        5, "Youkoso Japari Park e", "Doubutsu Biscuits × PPP", null, null, null, "j-pop", "anime", 170, "3:13", 122, 344, 4, 8);

    static Song dejavu = new Song(
        6, "Deja Vu", "Dave Rodgers", null, null, null, "eurobeat", "anime", 154, "1:32", 171, 350, 4, 7);

    static Song miraclewave = new Song(
        7, "MIRACLE WAVE", "Aqours", null, null, null, "j-pop", "Love Live!", 183, "1:34", 283, 422, 5, 7);

    //static Song test260 = new Song(
    //    10, "TEST230", "TEST", "Kizuna AI", null, null, "TEST", "TEST", 230, "3:13", 301, 672, 2, 10);

    //static Song uwu = new Song(
    //    11, "TURBOOOF", "TEST", "Kizuna AI", null, null, "TEST", "TEST", 230, "3:13", 301, 672, 2, 10);



    void Awake()
    {
        selArtistLabel = selArtistObj.GetComponent<TMPro.TextMeshProUGUI>();
        selTitleLabel = selTitleObj.GetComponent<TMPro.TextMeshProUGUI>();
        selGenreLabel = selGenreObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffLabel = selDiffObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffAltLabel = selDiffAltObj.GetComponent<TMPro.TextMeshProUGUI>();

        selHighScore1Label = selHighScore1.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore2Label = selHighScore2.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore3Label = selHighScore3.GetComponent<TMPro.TextMeshProUGUI>();

        selHighScore1LabelAcc = selHighScore1Acc.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore2LabelAcc = selHighScore2Acc.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore3LabelAcc = selHighScore3Acc.GetComponent<TMPro.TextMeshProUGUI>();

        selHighScore1LabelCombo = selHighScore1Combo.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore2LabelCombo = selHighScore2Combo.GetComponent<TMPro.TextMeshProUGUI>();
        selHighScore3LabelCombo = selHighScore3Combo.GetComponent<TMPro.TextMeshProUGUI>();

        acChangeSong = acConChangeSong.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();

        addingSongsToList();
        allSongs[0].isSelectedInMenu = true;
        creatingSelectedSongEntryInUI(selectedSongByUser = 0);

        deletePlayerPrefsKeys();

        GameObject.Find("preview" + selectedSongByUser).GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        changeSong();
        changeDifficulty();
        backToMainMenu();
        chooseSongAndMoveToGame();
        borderColorGenerator(isCurrentDifficultyIsEasy);
        //highScores();
    }

    void addingSongsToList()
    {
        //allSongs.Add(stalemate);
        //allSongs.Add(comfyplace);
        allSongs.Add(aiaiai);
        allSongs.Add(sixtrillion);
        allSongs.Add(hitorigoto);
        allSongs.Add(killthislove);
        allSongs.Add(badapple);
        allSongs.Add(japaripark);
        allSongs.Add(dejavu);
        allSongs.Add(miraclewave);
        //allSongs.Add(test260);
        //allSongs.Add(uwu);

    }

    void creatingSelectedSongEntryInUI(int selectedSongByUser)
    {
        fillingDataInSelectedSong();
    }

    void changeSong()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (selectedSongByUser < Song.totalAmount - 1)
            {
                acChangeSong.Play();
                if (GameObject.Find("preview" + selectedSongByUser) != null)
                {
                    GameObject.Find("preview" + selectedSongByUser).GetComponent<AudioSource>().Stop();
                }
                selectedSongByUser++;
                fillingDataInSelectedSong();
                movingOtherSongsUp();
                if (GameObject.Find("preview" + selectedSongByUser) != null)
                {
                    GameObject.Find("preview" + selectedSongByUser).GetComponent<AudioSource>().Play();
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedSongByUser > 0)
            {
                acChangeSong.Play();
                if (GameObject.Find("preview" + selectedSongByUser) != null)
                {
                    GameObject.Find("preview" + selectedSongByUser).GetComponent<AudioSource>().Stop();
                }
                selectedSongByUser--;
                fillingDataInSelectedSong();
                movingOtherSongsDown();
                if (GameObject.Find("preview" + selectedSongByUser) != null)
                {
                    GameObject.Find("preview" + selectedSongByUser).GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    void fillingDataInSelectedSong()
    {
        //ARTIST FIELD
        if (allSongs[selectedSongByUser].vocalist != null)
        {
            selArtistLabel.text = allSongs[selectedSongByUser].composer + " feat. " + allSongs[selectedSongByUser].vocalist;

        }
        else
        {
            selArtistLabel.text = allSongs[selectedSongByUser].composer;
        }

        //TITLE FIELD
        selTitleLabel.text = allSongs[selectedSongByUser].title;

        //COVER FIELD
        selCoverObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Maps/" + allSongs[selectedSongByUser].index + "/cover");

        //GENRE FIELD
        if (allSongs[selectedSongByUser].genre2 == null)
        {
            selGenreLabel.text = allSongs[selectedSongByUser].genre1;
        }
        else
        {
            selGenreLabel.text = allSongs[selectedSongByUser].genre1 + " / " + allSongs[selectedSongByUser].genre2;
        }

        //DIFF FIELD
        starGenerator();
        //HIGH SCORE FIELD
        highScores();
    }

    void movingOtherSongsUp()
    {
        Vector3 posy;
        foreach (GameObject foo in GameObject.FindGameObjectsWithTag("NonSelectedSongBox"))
        {
            float tilt = 570f;
            posy = foo.GetComponent<Transform>().position;

            if (posy.y == tilt - 482)
            {
                posy.y += 302f;
            }
            else if (posy.y == tilt - 180)
            {
                posy.y += 114f;
            }
            else if (posy.y == tilt - 572)
            {
                posy.y += 392f;
            }
            else
            {
                posy.y += 90f;
            }

            foo.GetComponent<Transform>().position = posy;
        }
    }

    void movingOtherSongsDown()
    {
        Vector3 posy;
        //NonSelectedSongBox
        foreach (GameObject foo in GameObject.FindGameObjectsWithTag("NonSelectedSongBox"))
        {
            float tilt = 570f;
            posy = foo.GetComponent<Transform>().position;

            if (posy.y == tilt - 66)
            {
                posy.y -= 114f;
            }
            else if (posy.y == tilt - 180)
            {
                posy.y -= 392f;
            }
            else
            {
                posy.y -= 90f;
            }
            foo.GetComponent<Transform>().position = posy;
        }

    }

    void starGenerator()
    {
        string starSymbol = @"<sprite name=""star full""> ";
        int multiplierEasy = allSongs[selectedSongByUser].difficultyEasy;

        int multiplierHard = allSongs[selectedSongByUser].difficultyHard;

        if (isCurrentDifficultyIsEasy)
        {
            selDiffLabel.text = string.Join(starSymbol, new string[multiplierEasy + 1]);
        }

        else
        {
            selDiffLabel.text = string.Join(starSymbol, new string[multiplierHard + 1]);
        }
        alternativeDifficultyTextGenerator();
    }

    void borderColorGenerator(bool isCurrentDifficultyIsEasy)
    {
        if (isCurrentDifficultyIsEasy == true)
        {
            GameObject.Find("Selected Song").GetComponent<Image>().sprite = easyBorder;
            GameObject.Find("Difficulty Tab").GetComponent<Image>().sprite = easyTab;

        }
        else
        {
            GameObject.Find("Selected Song").GetComponent<Image>().sprite = hardBorder;
            GameObject.Find("Difficulty Tab").GetComponent<Image>().sprite = hardTab;
        }
    }

    void highScores()
    {
        if (isCurrentDifficultyIsEasy == true)
        {
            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldScoreeasy") > 1)
            {
                selHighScore1Label.text = "1. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldScoreeasy").ToString();
                if(selHighScore1LabelAcc.text != null && selHighScore1LabelAcc.text != "xD" && selHighScore1LabelAcc.text != "0")
                {
                    selHighScore1LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "GoldAccuracyeasy");
                    selHighScore1LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldComboeasy").ToString();

                }
                else
                {
                    selHighScore1LabelAcc.text = " ";
                    selHighScore1LabelCombo.text = " ";
                }

            }
            else
            {
                selHighScore1Label.text = "1. ---";
                selHighScore1LabelAcc.text = " ";
                selHighScore1LabelCombo.text = " ";
            }

            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverScoreeasy") > 1)
            {
                selHighScore2Label.text = "2. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverScoreeasy").ToString();
                if (selHighScore2LabelAcc.text != null && selHighScore2LabelAcc.text != "xD" && selHighScore2LabelAcc.text != "0")
                {
                    selHighScore2LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "SilverAccuracyeasy");
                    selHighScore2LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverComboeasy").ToString();

                }
                else
                {
                    selHighScore2LabelAcc.text = " ";
                    selHighScore2LabelCombo.text = " ";
                }
            }
            else
            {
                selHighScore2Label.text = "2. ---";
                selHighScore2LabelAcc.text = " ";
                selHighScore2LabelCombo.text = " ";

            }

            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeScoreeasy") > 1)
            {
                selHighScore3Label.text = "3. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeScoreeasy").ToString();
                if (selHighScore3LabelAcc.text != null && selHighScore3LabelAcc.text != "xD" && selHighScore3LabelAcc.text != "0")
                {
                    selHighScore3LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "BronzeAccuracyeasy");
                    selHighScore3LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeComboeasy").ToString();

                }
                else
                {
                    selHighScore3LabelAcc.text = " ";
                    selHighScore3LabelCombo.text = " ";
                }
            }
            else
            {
                selHighScore3Label.text = "3. ---";
                selHighScore3LabelAcc.text = " ";
                selHighScore3LabelCombo.text = " ";
            }

        }
        else
        {
            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldScorehard") > 1)
            {
                selHighScore1Label.text = "1. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldScorehard").ToString();
                if (selHighScore1LabelAcc.text != null && selHighScore1LabelAcc.text != "xD" && selHighScore1LabelAcc.text != "0")
                {
                    selHighScore1LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "GoldAccuracyhard");
                    selHighScore1LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "GoldCombohard").ToString();

                }
                else
                {
                    //selHighScore1Label.text = "1. ---";
                    selHighScore1LabelAcc.text = " ";
                    selHighScore1LabelCombo.text = " ";
                }
            }
            else
            {
                selHighScore1Label.text = "1. ---";
                selHighScore1LabelAcc.text = " ";
                selHighScore1LabelCombo.text = " ";
            }

            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverScorehard") > 1)
            {
                selHighScore2Label.text = "2. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverScorehard").ToString();
                if (selHighScore2LabelAcc.text != null && selHighScore2LabelAcc.text != "xD" && selHighScore2LabelAcc.text != "0")
                {
                    selHighScore2LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "SilverAccuracyhard");
                    selHighScore2LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "SilverCombohard").ToString();

                }
                else
                {
                    //selHighScore2Label.text = "2. ---";
                    selHighScore2LabelAcc.text = " ";
                    selHighScore2LabelCombo.text = " ";
                }
            }
            else
            {
                selHighScore2Label.text = "2. ---";
                selHighScore2LabelAcc.text = " ";
                selHighScore2LabelCombo.text = " ";
            }

            if (PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeScorehard") > 1)
            {
                selHighScore3Label.text = "3. " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeScorehard").ToString();
                if (selHighScore3LabelAcc.text != null && selHighScore3LabelAcc.text != "xD" && selHighScore3LabelAcc.text != "0")
                {
                    selHighScore3LabelAcc.text = PlayerPrefs.GetString(allSongs[selectedSongByUser].index + "BronzeAccuracyhard");
                    selHighScore3LabelCombo.text = "combo: " + PlayerPrefs.GetInt(allSongs[selectedSongByUser].index + "BronzeCombohard").ToString();

                }
                else
                {
                    //selHighScore3Label.text = "3. ---";
                    selHighScore3LabelAcc.text = " ";
                    selHighScore3LabelCombo.text = " ";
                }
            }
            else
            {
                selHighScore3Label.text = "3. ---";
                selHighScore3LabelAcc.text = " ";
                selHighScore3LabelCombo.text = " ";
            }
        }


    }

    void alternativeDifficultyTextGenerator()
    {
        if (isCurrentDifficultyIsEasy)
        {
            selDiffAltLabel.text = allSongs[selectedSongByUser].difficultyHard.ToString();
        }

        else
        {
            selDiffAltLabel.text = allSongs[selectedSongByUser].difficultyEasy.ToString();
        }
    }

    void changeDifficulty()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.J))
        {
            if (isCurrentDifficultyIsEasy == false)
            {
                acChangeDiff.Play();
                isCurrentDifficultyIsEasy = true;
                starGenerator();
                highScores();
            }

            else
            {
                acChangeDiff.Play();
                isCurrentDifficultyIsEasy = false;
                starGenerator();
                highScores();
            }
        }
    }

    public void chooseSongAndMoveToGame()
    {
        if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.G)))
        {
            acEnter.Play();
            Invoke("loadGameplay", 1.8f);
        }
    }

    public void backToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.A)))
        {
            acBack.Play();
            Invoke("loadMainMenu", 1.3f);
        }
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    void loadGameplay()
    {
        SceneManager.LoadScene(4);
    }

    private static void deletePlayerPrefsKeys()
    {
        PlayerPrefs.DeleteKey("lastGameScore");
        PlayerPrefs.DeleteKey("lastGameMaxCombo");
        PlayerPrefs.DeleteKey("lastGameCorrectNotes");      
    }
}
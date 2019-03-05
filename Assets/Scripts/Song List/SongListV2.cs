using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;



public class SongListV2 : MonoBehaviour
{
    static public List<Song> allSongs = new List<Song>();
    public Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    public GameObject parentObjForSelected;

    // ZMIENNE DLA ZAZNACZONEGO UTWORU
    public GameObject selArtistObj;
    public TextMeshProUGUI selArtistLabel;

    public GameObject selTitleObj;
    public TextMeshProUGUI selTitleLabel;

    public GameObject selDiffObj;
    public TextMeshProUGUI selDiffLabel;

    public GameObject selDiffAltObj;
    public TextMeshProUGUI selDiffAltLabel;

    public GameObject starEmpty;

    public GameObject starFilled;

    public GameObject selGenreObj;
    public TextMeshProUGUI selGenreLabel;

    public GameObject selCoverObj;

    public static int selectedSongByUser;

    AudioSource clickAudio;

    static public bool isCurrentDifficultyIsEasy = false;

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

    // START TWORZENIA UTWORÓW
    static Song stalemate = new Song(
        0, "Stalemate", "P. Dawidziak", "Yuzuki Yukari", null, null, "Synth-rock", "Vocaloid", 195, "4:17", 322, 1011, 3, 7);

    static Song comfyplace = new Song(
        1, "Comfy Place", "P. Dawidziak", null, null, "P. Dawidziak", "Future bass", "Instrumental", 187, "1:33", 301, 672, 4, 9);



    void Awake()
    {
        selArtistLabel = selArtistObj.GetComponent<TMPro.TextMeshProUGUI>();
        selTitleLabel = selTitleObj.GetComponent<TMPro.TextMeshProUGUI>();
        selGenreLabel = selGenreObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffLabel = selDiffObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffAltLabel = selDiffAltObj.GetComponent<TMPro.TextMeshProUGUI>();

        acChangeSong = acConChangeSong.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();


        addingSongsToList();

        allSongs[0].isSelectedInMenu = true;

        creatingSelectedSongEntryInUI(selectedSongByUser = 0);
    }

    void Update()
    {
        changeSong();
        changeDifficulty();
        backToMainMenu();
        chooseSongAndMoveToGame();
    }

    void addingSongsToList()
    {
        allSongs.Add(stalemate);
        allSongs.Add(comfyplace);
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
                selectedSongByUser++;
                fillingDataInSelectedSong();
                movingOtherSongsUp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedSongByUser > 0)
            {
                acChangeSong.Play();
                selectedSongByUser--;
                fillingDataInSelectedSong();
                movingOtherSongsDown();
            }
        }
    }

    void fillingDataInSelectedSong()
    {
        //ARTIST FIELD
        selArtistLabel.text = allSongs[selectedSongByUser].composer;

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
            }

            else
            {
                acChangeDiff.Play();
                isCurrentDifficultyIsEasy = false;
                starGenerator();
            }
        }

    }

    public void chooseSongAndMoveToGame()
    {

        if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.G)))
        {
            acEnter.Play();
            SceneManager.LoadScene(4);
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
}

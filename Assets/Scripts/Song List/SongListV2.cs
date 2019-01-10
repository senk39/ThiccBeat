using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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

    //List<GameObject> allStars = new List<GameObject>();

    static public bool isCurrentDifficultyIsEasy = false;

    //static public int songEntered;





    public class Song
    {
        public static uint totalAmount = 0;

        public int index;

        public string title { get; set; }
        public string artist;
        public string illustrator;
        public string lyricist;
        public string genre1;
        public string genre2;
        public ushort BPM;

        public string audioLength;
        public uint notes;

        public byte difficultyEasy;
        public byte difficultyHard;

        public Sprite cover;
        public AudioClip audioFile;

        public bool isSelectedInMenu;


        public Song()  // KONSTRUKTOR
        {
            index = 0;
            title = "Unknown title";
            artist = "Unknown artist";
            illustrator = "Unknown illustrator";
            lyricist = "Unknown lyricist";
            genre1 = "Unknown Genre";
            genre2 = null;
            BPM = 0;
            isSelectedInMenu = false;

            totalAmount++;
        }

        public Song(int _index, string _title, string _artist, string _illustrator,
                    string _lyricist, string _genre1, string _genre2, ushort _BPM,
                    string _audioLength, uint _notes, byte _difficultyEasy, byte _difficultyHard)  // KONSTRUKTOR
        {
            index = _index;
            title = _title;
            artist = _artist;
            illustrator = _illustrator;
            lyricist = _lyricist;
            genre1 = _genre1;
            genre2 = _genre2;
            BPM = _BPM;

            audioLength = _audioLength;
            notes = _notes;

            difficultyEasy = _difficultyEasy;
            difficultyHard = _difficultyHard;

            totalAmount++;
        }

        public void showInfo()
        {
            Debug.Log(title);
            Debug.Log("index: " + index);
            Debug.Log("title: " + title);
            Debug.Log("artist: " + artist);
            Debug.Log("illustrator: " + illustrator);
            Debug.Log("lyricist: " + lyricist);
            Debug.Log("genre1: " + genre1);
            Debug.Log("genre2: " + genre2);
            Debug.Log("BPM: " + BPM);
        }
    }

    // START TWORZENIA PIOSENKÓW
    static Song stalemate = new Song(
        0, "Stalemate", "P. Dawidziak", null, null, "Synth-rock", "Vocaloid", 195, "4:17", 999, 3, 7);

    static Song comfyplace = new Song(
        1, "Comfy Place", "P. Dawidziak", null, "P. Dawidziak", "Future bass", "Instrumental", 187, "1:33", 999, 4, 9);



    void Awake()
    {
        selArtistLabel = selArtistObj.GetComponent<TMPro.TextMeshProUGUI>();
        selTitleLabel = selTitleObj.GetComponent<TMPro.TextMeshProUGUI>();
        selGenreLabel = selGenreObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffLabel = selDiffObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffAltLabel = selDiffAltObj.GetComponent<TMPro.TextMeshProUGUI>();

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedSongByUser < Song.totalAmount - 1)
            {
                selectedSongByUser++;
                fillingDataInSelectedSong();
                movingOtherSongsUp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (selectedSongByUser > 0)
            {
                selectedSongByUser--;
                fillingDataInSelectedSong();
                movingOtherSongsDown();
            }
        }
    }

    void fillingDataInSelectedSong()
    {
        //ARTIST FIELD
        selArtistLabel.text = allSongs[selectedSongByUser].artist;

        //TITLE FIELD
        selTitleLabel.text = allSongs[selectedSongByUser].title;

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isCurrentDifficultyIsEasy == false)
            {
                isCurrentDifficultyIsEasy = true;
                starGenerator();
            }

            else
            {
                isCurrentDifficultyIsEasy = false;
                starGenerator();
            }
        }

    }

    public void chooseSongAndMoveToGame()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(4);
        }
    }


    public void backToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}

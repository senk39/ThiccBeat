using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SongListV2 : MonoBehaviour {

    public List<Song> allSongs = new List<Song>();
    public Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    public GameObject parentObjForSelected;

    // ZMIENNE DLA ZAZNACZONEGO UTWORU
    public GameObject selArtistObj;
    public TextMeshProUGUI selArtistLabel;

    public GameObject selTitleObj;
    public TextMeshProUGUI selTitleLabel;

    public GameObject starEmpty;

    public GameObject starFilled;

    public GameObject selGenreObj;
    public TextMeshProUGUI selGenreLabel;

    public GameObject selCoverObj;

    int selectedSongByUser;

    public class Song
    {
        public static uint totalAmount = 0;

        public uint index;

        public string title;
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

            title               = "Unknown title";
            artist              = "Unknown artist";
            illustrator         = "Unknown illustrator";
            lyricist            = "Unknown lyricist";
            genre1              = "Unknown Genre";
            genre2              = null;
            BPM                 = 0;
            isSelectedInMenu    = false;

            totalAmount++;
        }

        public Song(uint _index, string _title, string _artist, string _illustrator,
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
    Song piosenkaOPociagach = new Song(
        0, "Piosenka o Pociagach", "Marvyanaka", "Marvyanaka", "Marvyanaka", "electropop", "Vocaloid", 150, "3:27", 429, 3, 7);

    Song stardust = new Song(
        1, "Stardust", "Senketsu", "NixieBlue", "yuyechka", "pop-rock", "Vocaloid", 150, "5:28", 594, 2, 6);

    Song despacito = new Song(
        2, "Despacito", "Louis Fonsi", "Louis Fonsi", null, "reggaeton", "latin pop", 120, "4:42", 666, 5, 9);

    Song actionGirl = new Song(
        3, "ACTION GIRL", "Senketsu", null, "yuyechka", "synth-rock", "Vocaloid", 220, "3:39", 2137, 6, 10);


    void Start() {

        selArtistLabel = selArtistObj.GetComponent<TMPro.TextMeshProUGUI>();
        selTitleLabel = selTitleObj.GetComponent<TMPro.TextMeshProUGUI>();
        selGenreLabel = selGenreObj.GetComponent<TMPro.TextMeshProUGUI>();

        addingSongsToList();

        //Debug.Log(allSongs[0].title);
        //Debug.Log(allSongs[1].title);
        //Debug.Log(allSongs[2].title);
        //Debug.Log(allSongs[3].title);

        creatingSelectedSongEntryInUI(selectedSongByUser = 0);
    }

    void Update()
    {
        changeSong();
    }

    void addingSongsToList()
    {
        allSongs.Add(piosenkaOPociagach);
        allSongs.Add(stardust);
        allSongs.Add(despacito);
        allSongs.Add(actionGirl);
    }

    void creatingSelectedSongEntryInUI(int selectedSongByUser)
    {
        fillingDataInSelectedSong();
        

        //EASY DIFF FIELD
        //easyDiffLabel.text = allSongs[0].difficultyEasy.ToString();

        //HARD DIFF FIELD
        //hardDiffLabel.text = allSongs[0].difficultyHard.ToString();

        starsGeneratorForSelectedSong();

        //Instantiate(selEasyDiffObj, new Vector3(500f, 291f, 0), Quaternion.identity, parentObj.transform);
        //Instantiate(selHardDiffObj, new Vector3(570f, 291f, 0), Quaternion.identity, parentObj.transform);
    }

    void starsGeneratorForSelectedSong()
    {

        for (int i = 0; i < 10; i++)
        {
            Instantiate(starEmpty, new Vector3(576.5f + (35*i), 695f, -365f), Quaternion.identity, parentObjForSelected.transform);
            starEmpty.GetComponent<Image>().color = Color.green;

            for (int j = 0; j < allSongs[0].difficultyEasy; j++)
            {
                Instantiate(starFilled, new Vector3(576.5f + (35 * j), 695f, -365f), Quaternion.identity, parentObjForSelected.transform);
                starFilled.GetComponent<Image>().color = Color.green;
            }
        }
    }

    void changeSong()
    {
        if (Input.GetKeyDown(KeyCode.S))
            {
            if (selectedSongByUser < allSongs.Capacity-1)
                { 
                    selectedSongByUser++;
                    fillingDataInSelectedSong();
                }
            }
        else if(Input.GetKeyDown(KeyCode.W))
            {
            if (selectedSongByUser > 0)
            {
                selectedSongByUser--;
                fillingDataInSelectedSong();
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
    }
}
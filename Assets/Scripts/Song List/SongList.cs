using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongList : MonoBehaviour {

    public List<Song> allSongs =  new List<Song>();
    public Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    public GameObject songEntryBox;
    public GameObject parentObj;

    public GameObject artistObj;
    public TextMeshProUGUI artistLabel;

    public GameObject titleObj;
    public TextMeshProUGUI titleLabel;

    public GameObject easyDiff;
    public TextMeshProUGUI easyDiffLabel;

    public GameObject hardDiff;
    public TextMeshProUGUI hardDiffLabel;

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
        2, "Despacito", "Louis Fonsi", "Louis Fonsi", null, "reggaeton", "latin pop", 120, "4:42", 666, 5, 10);

    Song actionGirl = new Song(
        3, "ACTION GIRL", "Senketsu", null, "yuyechka", "synth-rock", "Vocaloid", 220, "3:39", 2137, 6, 10);

    void Start() {

        artistLabel = artistObj.GetComponent<TMPro.TextMeshProUGUI>();
        titleLabel = titleObj.GetComponent<TMPro.TextMeshProUGUI>();
        easyDiffLabel = easyDiff.GetComponent<TMPro.TextMeshProUGUI>();
        hardDiffLabel = hardDiff.GetComponent<TMPro.TextMeshProUGUI>();





        addingSongsToList();
        
        //Debug.Log(allSongs[0].title);
        //Debug.Log(allSongs[1].title);
        //Debug.Log(allSongs[2].title);
        //Debug.Log(allSongs[3].title);

        creatingSongEntryInUI();
    }

    void addingSongsToList()
    {
        allSongs.Add(piosenkaOPociagach);
        allSongs.Add(stardust);
        allSongs.Add(despacito);
        allSongs.Add(actionGirl);

    }

    void creatingSongEntryInUI()
    {
        for (int i = 0; i < allSongs.Count; i++)
        {
           

            //ARTIST FIELD
            artistLabel.text = allSongs[i].artist;

            //TITLE FIELD
            titleLabel.text = allSongs[i].title;

            //EASY DIFF FIELD
            easyDiffLabel.text = allSongs[i].difficultyEasy.ToString();

            //HARD DIFF FIELD
            hardDiffLabel.text = allSongs[i].difficultyHard.ToString();

            Instantiate(songEntryBox, new Vector3(459.5f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(artistObj, new Vector3(271.2f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(titleObj, new Vector3(656.5f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(easyDiff, new Vector3(500f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(hardDiff, new Vector3(570f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);

        }
    }

}
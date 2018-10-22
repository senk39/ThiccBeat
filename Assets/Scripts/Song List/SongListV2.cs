using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SongListV2 : MonoBehaviour
{
    public List<Song> allSongs = new List<Song>();
    public Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    public GameObject parentObjForSelected;

    // ZMIENNE DLA ZAZNACZONEGO UTWORU
    public GameObject selArtistObj;
    public TextMeshProUGUI selArtistLabel;

    public GameObject selTitleObj;
    public TextMeshProUGUI selTitleLabel;

    public GameObject selDiffObj;
    public TextMeshProUGUI selDiffLabel;

    public GameObject starEmpty;

    public GameObject starFilled;

    public GameObject selGenreObj;
    public TextMeshProUGUI selGenreLabel;

    public GameObject selCoverObj;

    int selectedSongByUser;

    List<GameObject> allStars = new List<GameObject>();

    public bool isCurrentDifficultyIsEasy = false;


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
        0, "Piosenka o Pociagach", "Marvyanaka", "Marvyanaka", "Marvyanaka", "Electropop", "Vocaloid", 150, "3:27", 429, 3, 7);

    Song stardust = new Song(
        1, "Stardust", "Senketsu", "NixieBlue", "yuyechka", "Pop-rock", "Vocaloid", 150, "5:28", 594, 2, 6);

    Song despacito = new Song(
        2, "Despacito", "Louis Fonsi", "Louis Fonsi", null, "Reggaeton", "Latin pop", 120, "4:42", 631, 5, 9);

    Song actionGirl = new Song(
        3, "ACTION GIRL", "Senketsu", null, "yuyechka", "Synth-rock", "Vocaloid", 220, "3:39", 2137, 6, 10);

    Song badApple = new Song(
        4, "Bad Apple!!", "Alstroemeria Records", "Alstroemeria Records", "Nomico", "Electropop", "Touhou", 138, "3:39", 720, 1, 5);

    Song sixTrillion = new Song(
        5, "A Tale of Six Trillion Years and a Night", "kemu", null, "kemu", "Synth-rock", "Vocaloid", 186, "3:36", 695, 3, 7);

    Song wakuseiRabbit = new Song(
        6, "Wakusei Rabbit", "Yunomi", null, "TORIENA", "kawaii future bass", null, 174, "3:24", 783, 5, 8);


    void Start()
    {
        selArtistLabel = selArtistObj.GetComponent<TMPro.TextMeshProUGUI>();
        selTitleLabel = selTitleObj.GetComponent<TMPro.TextMeshProUGUI>();
        selGenreLabel = selGenreObj.GetComponent<TMPro.TextMeshProUGUI>();
        selDiffLabel = selDiffObj.GetComponent<TMPro.TextMeshProUGUI>();

        addingSongsToList();

        allSongs[0].isSelectedInMenu = true;

        creatingSelectedSongEntryInUI(selectedSongByUser = 0);
    }

    void Update()
    {
        changeSong();
        changeDifficulty();
    }

    void addingSongsToList()
    {
        allSongs.Add(piosenkaOPociagach);
        allSongs.Add(stardust);
        allSongs.Add(despacito);
        allSongs.Add(actionGirl);
        allSongs.Add(badApple);
        allSongs.Add(sixTrillion);
        allSongs.Add(wakuseiRabbit);
    }

    void creatingSelectedSongEntryInUI(int selectedSongByUser)
    {
        fillingDataInSelectedSong();
    }

    void changeSong()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedSongByUser < allSongs.Capacity - 2)
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

            if (posy.y == tilt-482)
                {
                    posy.y += 302f;
                }
            else if(posy.y == tilt - 180)
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

            if (posy.y == tilt-66)
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
    }

    void changeDifficulty()
    {
        
            if(Input.GetKeyDown(KeyCode.F))
                {
                    if(isCurrentDifficultyIsEasy == false)
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
}
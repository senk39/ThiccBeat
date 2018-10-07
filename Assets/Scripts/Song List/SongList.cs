﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour {

    public List<Song> allSongs =  new List<Song>();
    public Vector3 firstSongBoxPosition = new Vector3(459.5f, 291f);
    public GameObject songEntryBox;
    public GameObject parentObj;
    public GameObject artist;
    public GameObject title;

    public TMPro.TextMeshProUGUI titleTextBox; //może zrób z tego tablicę idk


    public class Song
    {
        public static uint totalAmount = 0;

        public uint index;

        public string title;
        public string producer;
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
            producer = "Unknown producer";
            illustrator = "Unknown illustrator";
            lyricist = "Unknown lyricist";
            genre1 = "Unknown Genre";
            genre2 = null;
            BPM = 0;

            totalAmount++;
        }

        public Song(uint _index, string _title, string _producer, string _illustrator, 
                    string _lyricist, string _genre1, string _genre2, ushort _BPM, 
                    string _audioLength, uint _notes, byte _difficultyEasy, byte _difficultyHard)  // KONSTRUKTOR

        {
            index = _index;
            title = _title;
            producer = _producer;
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
            Debug.Log("producer: " + producer);
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

        addingSongsToList();
        /*
        Debug.Log(allSongs[0].title);
        Debug.Log(allSongs[1].title);
        Debug.Log(allSongs[2].title);
        */
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
            Instantiate(songEntryBox, new Vector3(459.5f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(artist, new Vector3(271.2f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            Instantiate(title, new Vector3(656.5f, (291f - (i * 87)), 0), Quaternion.identity, parentObj.transform);
            titleTextBox.text = "despatitlo";//no i tutaj tablicuj uwu

            foreach (Transform child in songEntryBox.GetComponentsInChildren<Transform>())
            {
                //TU COŚ WYKMIŃ XD
            }
                
        }

    }
}
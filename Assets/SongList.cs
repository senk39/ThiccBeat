using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour {

    // Use this for initialization



    class Song
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

        //time
        //notes

        public GameObject cover;
        public GameObject audioFile;



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

        public Song(uint _index, string _title, string _producer, string _illustrator, string _lyricist, string _genre1, string _genre2, ushort _BPM)  // KONSTRUKTOR
        {
            index = _index;
            title = _title;
            producer = _producer;
            illustrator = _illustrator;
            lyricist = _lyricist;
            genre1 = _genre1;
            genre2 = _genre2;
            BPM = _BPM;

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

    //Song Despacito = new Song();
    


    void Start() {

        Song piosenkaOPociagach = new Song(
            0, "Piosenka o Pociagach", "Marvyanaka", "Marvyanaka", "Marvyanaka", "electropop", "Vocaloid", 150);


        Song stardust = new Song(
            1, "Stardust", "Senketsu", "NixieBlue", "yuyechka", "pop-rock", "Vocaloid", 150);

        Song despacito = new Song(
            2,
            "Despacito", "Louis Fonsi", "Andrzej Sapkowski", null, "pop", null, 120);


        piosenkaOPociagach.showInfo();
        stardust.showInfo();
   }

}













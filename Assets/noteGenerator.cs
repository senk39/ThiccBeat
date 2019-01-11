﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class noteGenerator : MonoBehaviour
{

    int selectedSong;
    AudioSource audioSongSource;
    AudioClip audioSong;

    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();


    /*
     
FULL BEAT: 12.09

1/2: 6.045

1/4: 3.0225 //ustawiona jako standardowa odległość między nutami - 48 jednostek

1/8: 1.51125

1/16: 0.755625

1 nuta: 48 jednostek midi

48/3.0225 = ilość jednostek midi mieszczących się 
     */

    // GENERATOR

    public TextAsset row1;
    public TextAsset row2;
    public TextAsset row3;
    public TextAsset row4;
    public TextAsset row5;
    public TextAsset row6;
    public TextAsset row7;

    private string textContent1;
    private string textContent2;
    private string textContent3;
    private string textContent4;
    private string textContent5;
    private string textContent6;
    private string textContent7;

    public string[] textContentSplit1;

    //public float firstNote = 105.15f;
    const float offset = 172.2f;

    //const float oneMidiLength = 0.1259375f;
    //const float oneMidiLength = 0.1607f;      TO BYŁO OK PRZED SYNCHRONIZACJĄ NUT DO KLATEK
    const float oneMidiLength = 0.19375f;

    public bool notesGenerator = false;
    public GameObject note;
    public GameObject bar;

    GameObject noteContainer;

    public GameObject endTrack;

    Quaternion noteQuaternion = new Quaternion(0f, 0f, 0f, 0f);
    Quaternion barQuaternion = new Quaternion(180f, 0f, 0f, 0f);


    //BPM
    public float bpm;
    public float distBetweenNotes;

    public int tempValueRow1 = 0;
    public int tempValueRow2 = 0;
    public int tempValueRow3 = 0;
    public int tempValueRow4 = 0;
    public int tempValueRow5 = 0;
    public int tempValueRow6 = 0;
    public int tempValueRow7 = 0;

    public int biggestRow;

    private const float row1X = -5.1f;
    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
    private const float row7X = 2.67f;
    private const float rowY = 0.35f;

    void Awake()
    {
        noteContainer = GameObject.Find("NOTES");
        selectedSong = SongListV2.selectedSongByUser;

        bpm = SongListV2.allSongs[selectedSong].BPM;

        audioSongSource = GetComponent<AudioSource>();
        audioSong = Resources.Load<AudioClip>("Maps/" + selectedSong + "/audio");
        GameObject.Find("SongPlayer").GetComponent<AudioSource>().clip = audioSong;


        row1 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/1");
        row2 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/2");
        row3 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/3");
        row4 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/4");
        row5 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/5");
        row6 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/6");
        row7 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/7");

        distBetweenNotes = (60 / bpm);

        if (notesGenerator)
        {
            InvokeRepeating("noteInstantiateForGenerator", 3f, distBetweenNotes);
        }

        textContent1 = row1.text;
        textContent2 = row2.text;
        textContent3 = row3.text;
        textContent4 = row4.text;
        textContent5 = row5.text;
        textContent6 = row6.text;
        textContent7 = row7.text;

        string[] textContentSplit1 = textContent1.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit2 = textContent2.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit3 = textContent3.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit4 = textContent4.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit5 = textContent5.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit6 = textContent6.Split(new char[] { ' ', ',', '.', '\n' });
        string[] textContentSplit7 = textContent7.Split(new char[] { ' ', ',', '.', '\n', '\t' });

        foreach (string s in textContentSplit1)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow1);
                Instantiate(note, new Vector3
                    (row1X, rowY, (offset + (tempValueRow1 * oneMidiLength))),
                    noteQuaternion);
                //newNote.transform.parent = noteContainer.transform;
            }
        }
        foreach (string s in textContentSplit2)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow2);
                Instantiate(note, new Vector3(row2X, rowY, (offset + (tempValueRow2 * oneMidiLength))), noteQuaternion);
                //newNote.transform.parent = noteContainer.transform;
            }
        }
        foreach (string s in textContentSplit3)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow3);
                Instantiate(note, new Vector3(row3X, rowY, (offset + (tempValueRow3 * oneMidiLength))), noteQuaternion);
            }
        }
        foreach (string s in textContentSplit4)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow4);
                //Debug.Log(tempValueRow4);
                Instantiate(note, new Vector3(row4X, rowY, (offset + (tempValueRow4 * oneMidiLength))), noteQuaternion);
            }
        }
        foreach (string s in textContentSplit5)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow5);
                //Debug.Log(tempValueRow5);
                Instantiate(note, new Vector3(row5X, rowY, (offset + (tempValueRow5 * oneMidiLength))), noteQuaternion);
            }
        }
        foreach (string s in textContentSplit6)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow6);
                //Debug.Log(tempValueRow6);
                Instantiate(note, new Vector3(row6X, rowY, (offset + (tempValueRow6 * oneMidiLength))), noteQuaternion);
            }
        }
        foreach (string s in textContentSplit7)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow7);
                Instantiate(bar, new Vector3
                    (row7X, rowY, (offset + (tempValueRow7 * oneMidiLength))),
                    barQuaternion);
            }
        }

        checkTheLastestNote();
        generateTheLastestNote();
    }

    void Update()
    {
    }

    void checkTheLastestNote()
    {
        //int[] lastestNotes = { tempValueRow1, tempValueRow2, tempValueRow3, tempValueRow4, tempValueRow5, tempValueRow6, tempValueRow7 };
        List<int> lastestNotes = new List<int>();
        lastestNotes.Add(tempValueRow1);
        lastestNotes.Add(tempValueRow2);
        lastestNotes.Add(tempValueRow3);
        lastestNotes.Add(tempValueRow4);
        lastestNotes.Add(tempValueRow5);
        lastestNotes.Add(tempValueRow6);
        lastestNotes.Add(tempValueRow7);

        biggestRow = lastestNotes.Max();
    }

    void generateTheLastestNote()
    {
        Instantiate(endTrack, new Vector3
        (0, 0.38f, (offset + (biggestRow * oneMidiLength) + 100f)),
        noteQuaternion);
    }
}


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

    //SYNC

    const float offset = 315f;
    const float oneMidiLength = 65.93f;


    public bool notesGenerator = false;
    public GameObject note;
    public GameObject bar;

    GameObject noteContainer;

    public GameObject endTrack;

    Quaternion noteQuaternion = new Quaternion(0f, 0f, 0f, 0f);
    Quaternion barQuaternion = new Quaternion(180f, 0f, 0f, 0f);

    bool isHard;
    GameObject noteHolder;

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

    public float oneMidiLengthPerBpm;

    void Awake()
    {
        noteHolder = GameObject.Find("Note Holder");
        isHard = !(SongListV2.isCurrentDifficultyIsEasy);
        noteContainer = GameObject.Find("NOTES");
        selectedSong = SongListV2.selectedSongByUser;

        bpm = SongListV2.allSongs[selectedSong].BPM;
        oneMidiLengthPerBpm = oneMidiLength / bpm;

        audioSongSource = GetComponent<AudioSource>();
        audioSong = Resources.Load<AudioClip>("Maps/" + selectedSong + "/audio");
        GameObject.Find("SongPlayer").GetComponent<AudioSource>().clip = audioSong;

        if(isHard == true)
        {
            row1 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/1");
            row2 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/2");
            row3 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/3");
            row4 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/4");
            row5 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/5");
            row6 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/6");
            row7 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard/7");
        }
        else
        {
            row1 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/1");
            row2 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/2");
            row3 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/3");
            row4 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/4");
            row5 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/5");
            row6 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/6");
            row7 = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy/7");
        }


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

        for (int i = 0; i < textContentSplit1.Length-1; i++)
        {
            if (textContentSplit1[i].Trim() != "")
            {
                int.TryParse(textContentSplit1[i], out tempValueRow1);
                GameObject newNote = Instantiate(note, new Vector3
                    (row1X, rowY, (offset + (tempValueRow1 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if(i<9)
                {
                newNote.name = "row1_note0" + (i+1);
                }
                else{
                    newNote.name = "row1_note" + (i+1);
                }
            }
        }
        /*
        foreach (string s in textContentSplit1)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow1);
                GameObject newNote = Instantiate(note, new Vector3
                    (row1X, rowY, (offset + (tempValueRow1 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);
            }
        }
        */
        for (int i = 0; i < textContentSplit2.Length - 1; i++)
        {
            if (textContentSplit2[i].Trim() != "")
            {
                int.TryParse(textContentSplit2[i], out tempValueRow2);
                GameObject newNote = Instantiate(note, new Vector3
                    (row2X, rowY, (offset + (tempValueRow2 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "row2_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "row2_note" + (i + 1);
                }
            }
        }

        for (int i = 0; i < textContentSplit3.Length - 1; i++)
        {
            if (textContentSplit3[i].Trim() != "")
            {
                int.TryParse(textContentSplit3[i], out tempValueRow3);
                GameObject newNote = Instantiate(note, new Vector3
                    (row3X, rowY, (offset + (tempValueRow3 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "row3_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "row3_note" + (i + 1);
                }
            }
        }

        for (int i = 0; i < textContentSplit4.Length - 1; i++)
        {
            if (textContentSplit4[i].Trim() != "")
            {
                int.TryParse(textContentSplit4[i], out tempValueRow4);
                GameObject newNote = Instantiate(note, new Vector3
                    (row4X, rowY, (offset + (tempValueRow4 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "row4_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "row4_note" + (i + 1);
                }
            }
        }

        for (int i = 0; i < textContentSplit5.Length - 1; i++)
        {
            if (textContentSplit5[i].Trim() != "")
            {
                int.TryParse(textContentSplit5[i], out tempValueRow5);
                GameObject newNote = Instantiate(note, new Vector3
                    (row5X, rowY, (offset + (tempValueRow5 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "row5_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "row5_note" + (i + 1);
                }
            }
        }

        for (int i = 0; i < textContentSplit6.Length - 1; i++)
        {
            if (textContentSplit6[i].Trim() != "")
            {
                int.TryParse(textContentSplit6[i], out tempValueRow6);
                GameObject newNote = Instantiate(note, new Vector3
                    (row6X, rowY, (offset + (tempValueRow6 * oneMidiLengthPerBpm))),
                    noteQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "row6_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "row6_note" + (i + 1);
                }
            }
        }

        for (int i = 0; i < textContentSplit7.Length - 1; i++)
        {
            if (textContentSplit7[i].Trim() != "")
            {
                int.TryParse(textContentSplit7[i], out tempValueRow7);
                GameObject newNote = Instantiate(bar, new Vector3
                    (row7X, rowY, (offset + (tempValueRow7 * oneMidiLengthPerBpm))),
                    barQuaternion);
                newNote.transform.SetParent(noteHolder.transform);

                if (i < 9)
                {
                    newNote.name = "bar_note0" + (i + 1);
                }
                else
                {
                    newNote.name = "bar_note" + (i + 1);
                }
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
        (0, 0.38f, (offset + (biggestRow * oneMidiLengthPerBpm) + 100f)),
        noteQuaternion);
    }
}


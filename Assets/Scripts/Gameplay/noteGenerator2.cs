using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class noteGenerator2 : MonoBehaviour
{

    int selectedSong;
    AudioSource audioSongSource;
    AudioClip audioSong;

    public GameObject active1;
    public GameObject active2;
    public GameObject active3;
    public GameObject active4;
    public GameObject active5;
    public GameObject active6;
    public GameObject active7;


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
    public TextAsset fullMap;

    private string textContent;
 

    public string[] textContentSplit1;
   


    //SYNC
    const float offset = 315f;
    const float oneMidiLength = 65.915f;


    public bool notesGenerator = false;
    public GameObject note;
    public GameObject bar;

    public GameObject endTrack;

    Quaternion noteQuaternion = new Quaternion(0f, 0f, 0f, 0f);
    Quaternion barQuaternion = new Quaternion(180f, 0f, 0f, 0f);

    bool isHard;
    GameObject noteHolder;

    //BPM
    public float bpm;

    public float distBetweenNotes;

    public int tempValueRow = 0;


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
        selectedSong = SongListV2.selectedSongByUser;

        bpm = SongListV2.allSongs[selectedSong].BPM;
        oneMidiLengthPerBpm = oneMidiLength / bpm;

        audioSongSource = GetComponent<AudioSource>();
        audioSong = Resources.Load<AudioClip>("Maps/" + selectedSong + "/audio");
        GameObject.Find("Song Player").GetComponent<AudioSource>().clip = audioSong;

        /*  //TEST WYBRANEGO UTWORU
        Debug.Log("selectedSong: " + selectedSong);
        if (isHard)
        {
            Debug.Log("selectedDiff: Hard");
        }
        else
        {
            Debug.Log("selectedDiff: Easy");
        }
        */

        if (isHard == true)
        {
            fullMap = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard");
        }

        else
        {
            fullMap = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy");
        }


        distBetweenNotes = (60 / bpm);

        if (notesGenerator)
        {
            InvokeRepeating("noteInstantiateForGenerator", 3f, distBetweenNotes);
        }

        textContent = fullMap.text;

        string[] textContentSplit1 = textContent.Split(new char[] { 'x' });

        for (int i = 0; i < textContentSplit1.Length-1; i++)
        {
            if (textContentSplit1[i].Trim() != "")
            {
                int.TryParse(textContentSplit1[i], out tempValueRow);
                GameObject newNote = Instantiate(note, new Vector3
                    (row1X, rowY, (offset + (tempValueRow * oneMidiLengthPerBpm))),
                    noteQuaternion);
                //newNote.transform.SetParent(noteHolder.transform);

                    newNote.name = "row1_note" + (i+1);      
            }
        }

        checkTheLastestNote();
        generateTheLastestNote();
    }

    void Update()
    {
        labelTheLowestAsActive();
    }

    void checkTheLastestNote()
    {
        List<int> lastestNotes = new List<int>();
        lastestNotes.Add(tempValueRow);

        biggestRow = lastestNotes.Max();
    }

    void generateTheLastestNote()
    {
        Instantiate(endTrack, new Vector3
        (0, 0.38f, (offset + (biggestRow * oneMidiLengthPerBpm) + 100f)),
        noteQuaternion);
    }

    void labelTheLowestAsActive()
    {
        for (int i = 0; i < 500 - 1; i++)
        {
            string foo = "row1_note" + (i + 1);
            //Debug.Log(foo);
            active1 = GameObject.Find("row1_note" + (i + 1));
            //GameObject.Find("button 1").GetComponent<pressingNotes>().go = active1;

            if (active1 != null)
            {
                GameObject.Find(foo).GetComponent<note>().isTheLowest = true;
                break;
            }
        }

        for (int i = 0; i < 500 - 1; i++)
        {
            active2 = GameObject.Find("row2_note" + (i + 1));
            //GameObject.Find("button 2").GetComponent<pressingNotes>().go = active2;

            if (active2 != null)
            {
                GameObject.Find("row2_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }
        for (int i = 0; i < 500 - 1; i++)
        {
            active3 = GameObject.Find("row3_note" + (i + 1));
            //GameObject.Find("button 3").GetComponent<pressingNotes>().go = active3;

            if (active3 != null)
            {
                GameObject.Find("row3_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }
        for (int i = 0; i < 500 - 1; i++)
        {
            active4 = GameObject.Find("row4_note" + (i + 1));
            //GameObject.Find("button 4").GetComponent<pressingNotes>().go = active4;

            if (active4 != null)
            {
                GameObject.Find("row4_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }

        for (int i = 0; i < 500 - 1; i++)
        {
            active5 = GameObject.Find("row5_note" + (i + 1));
            //GameObject.Find("button 5").GetComponent<pressingNotes>().go = active5;

            if (active5 != null)
            {
                GameObject.Find("row5_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }
        for (int i = 0; i < 500 - 1; i++)
        {
            active6 = GameObject.Find("row6_note" + (i + 1));
           // GameObject.Find("button 6").GetComponent<pressingNotes>().go = active6;

            if (active6 != null)
            {
                GameObject.Find("row6_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }
        for (int i = 0; i < 500 - 1; i++)
        {
            active7 = GameObject.Find("bar_note" + (i + 1));
            // GameObject.Find("button 6").GetComponent<pressingNotes>().go = active6;

            if (active7 != null)
            {
                GameObject.Find("bar_note" + (i + 1)).GetComponent<note>().isTheLowest = true;
                break;
            }
        }
        /*
        for (int i = 0; i < textContentSplit7.Length - 1; i++)
        {
            active7 = GameObject.Find("bar_note" + (i + 1));
            if (active7 != null)
            {
                GameObject.Find("button 7").GetComponent<pressingNotes>().go = active7;
            }
            else
            {
                break;
            }
        }
        */
    }
}


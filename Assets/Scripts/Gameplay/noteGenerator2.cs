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

    public GameObject noteShort;
    public GameObject noteHoldStart;
    public GameObject noteHoldMiddle;
    public GameObject noteHoldEnd;
    public GameObject noteEndTrack;
    public GameObject noteContainer;


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


    public string[] textContentSplit;



    //SYNC
    const float offset = 315f;
    const float oneMidiLength = 65.915f;


    public bool notesGenerator = false;

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

        if (isHard == true)
        {
            fullMap = Resources.Load<TextAsset>("Maps/" + selectedSong + "/hard");
        }

        else
        {
            fullMap = Resources.Load<TextAsset>("Maps/" + selectedSong + "/easy");
        }


        textContent = fullMap.text;

        string[] textContentSplit = textContent.Split(new char[] { 'x' });

        for (int i = 0; i < textContentSplit.Length - 1; i++)
        {
            //Debug.Log(textContentSplit[i+1]);  //GENERUJE NUTKI OK MORDO
            List<string> eachNoteSplit = textContentSplit[i + 1].Split(new char[] { ' ', '\n' }).ToList<string>();
            //120 On n=5
            //132 Off n=5
       
            eachNoteSplit.RemoveAt(0);
            eachNoteSplit.RemoveAt(1);
            eachNoteSplit.RemoveAt(3);
            eachNoteSplit.RemoveAt(1);

            // teraz wygląda następująco: 120 | 132 | n=5

            //stwórz pusty obiekt który będzie zawierał w sobie podobiekt nutki - albo krótkiej, albo holda.
            //ten pusty obiekt będzie posiadał właściwości na temat długości nutki
            
            GameObject newNoteContainer = Instantiate(noteContainer, new Vector3(0, 0, 0), noteQuaternion);
            GameObject newNote = Instantiate(noteShort, new Vector3(row1X, rowY, 0), noteQuaternion);
            newNote.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newNote
            
            //ustal nazwę obiektu



        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

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

    public GameObject noteBar;

    public GameObject noteHoldStart;
    public GameObject noteHoldMiddle;
    public GameObject noteHoldEnd;

    public GameObject noteBarStart;
    public GameObject noteBarMiddle;
    public GameObject noteBarEnd;

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
    private const float row7X = 2.8f;

    float[] rows = new float[] {
        0f, -5.1f, -3.1f, -1.1f, 1.1f, 3.1f, 5.1f, 2.8f
    };

    private const float rowY = 0.35f;

    private const float rowZ = 124f;


    void Awake()
    {
        noteHolder = GameObject.Find("Note Holder");
        isHard = !(SongListV2.isCurrentDifficultyIsEasy);
        selectedSong = SongListV2.selectedSongByUser;

        bpm = SongListV2.allSongs[selectedSong].BPM;

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



        for (int i = 0; i < textContentSplit.Length - 2; i++)
        {

            //Debug.Log(textContentSplit[i+1]);  //GENERUJE NUTKI OK MORDO
            List<string> eachNoteSplit = textContentSplit[i + 1].Split(new char[] { ' ', '\n' }).ToList<string>();
            //120 On n=5
            //132 Off n=5
            try
            {

                eachNoteSplit.RemoveAt(0);
               // Debug.Log(eachNoteSplit[1]);
                eachNoteSplit.RemoveAt(1);
               // Debug.Log(eachNoteSplit[3]);
                eachNoteSplit.RemoveAt(3);
                //Debug.Log(eachNoteSplit[1]);
                eachNoteSplit.RemoveAt(1);
                //Debug.Log("[0]: " + eachNoteSplit[0]);  //GENERUJE NUTKI OK MORDO
                //Debug.Log("[1]: " + eachNoteSplit[1]);  //GENERUJE NUTKI OK MORDO
                //Debug.Log("[2]: " + eachNoteSplit[2]);  //GENERUJE NUTKI OK MORDO
            }
            catch (Exception)
            {
                Debug.LogError("nie udalo sie zmapowac.");
                throw;
            }
            

            // teraz wygląda następująco: 120 | 132 | n=5

            //stwórz pusty obiekt który będzie zawierał w sobie podobiekt nutki - albo krótkiej, albo holda.
            //ten pusty obiekt będzie posiadał właściwości na temat długości nutki
            
            GameObject newNoteContainer = Instantiate(noteContainer, new Vector3(0, 0, 0), noteQuaternion);
            newNoteContainer.tag = "noteContainer";

            for (int i2 = 1; i2 < 8; i2++)
            {
                noteClass currentNoteClass = newNoteContainer.GetComponent<noteClass>();

                if (eachNoteSplit[2].Contains(i2.ToString()) && i2 < 7)
                {
                    currentNoteClass.startPoint = Int32.Parse(eachNoteSplit[0]);
                    currentNoteClass.endPoint = Int32.Parse(eachNoteSplit[1]);
                    currentNoteClass.keyNumber = i2;
                    currentNoteClass.noteLength = currentNoteClass.endPoint - currentNoteClass.startPoint;

                    if (currentNoteClass.noteLength <= 12)
                    {
                        currentNoteClass.isHold = false;
                        currentNoteClass.isShort = true;
                        GameObject newNote = Instantiate(noteShort, new Vector3(0, 0, 0), noteQuaternion);
                        newNote.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newNote
                        newNoteContainer.gameObject.transform.SetPositionAndRotation(new Vector3(rows[i2], rowY, rowZ), noteQuaternion);

                        if (i < 9)
                        {
                            newNote.transform.name = "note00" + (i + 1);
                        }
                        else if (i < 99)
                        {
                            newNote.transform.name = "note0" + (i + 1);
                        }
                        else
                        {
                            newNote.transform.name = "note" + (i + 1);
                        }
                    }

                    else
                    {
                        currentNoteClass.isHold = true;
                        currentNoteClass.isShort = false;

                        GameObject newNote = Instantiate(noteShort, new Vector3(0, 0, 0), noteQuaternion);
                        newNote.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newNote

                        if (i < 9)
                        {
                            newNote.transform.name = "startNote00" + (i + 1);
                        }
                        else if (i < 99)
                        {
                            newNote.transform.name = "startNote0" + (i + 1);
                        }
                        else
                        {
                            newNote.transform.name = "startNote" + (i + 1);
                        }

                        GameObject newNoteEnd = Instantiate(noteShort, new Vector3(0, 0, (0 + (0.56483941145f * currentNoteClass.noteLength))), noteQuaternion);
                        newNoteEnd.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newNote                       
                        newNoteContainer.gameObject.transform.SetPositionAndRotation(new Vector3(rows[i2], rowY, rowZ), noteQuaternion);

                        if (i < 9)
                        {
                            newNoteEnd.transform.name = "endNote00" + (i + 1);
                        }
                        else if (i < 99)
                        {
                            newNoteEnd.transform.name = "endNote0" + (i + 1);
                        }
                        else
                        {
                            newNoteEnd.transform.name = "endNote" + (i + 1);
                        }                        
                    }                       
                    break;
                }
                else if (eachNoteSplit[2].Contains("7"))
                {
                    newNoteContainer.tag = "noteContainer";

                    GameObject newBarNote = Instantiate(noteBar, new Vector3(0, 0, 0), barQuaternion);
                    newBarNote.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newBarNote
                    newNoteContainer.gameObject.transform.SetPositionAndRotation(new Vector3(row7X, rowY, rowZ), noteQuaternion);
                    //GENEROWANIE BARA
                    currentNoteClass.startPoint = Int32.Parse(eachNoteSplit[0]);
                    currentNoteClass.endPoint = Int32.Parse(eachNoteSplit[1]);
                    currentNoteClass.keyNumber = 7;
                    currentNoteClass.noteLength = currentNoteClass.endPoint - currentNoteClass.startPoint;
                    if (currentNoteClass.noteLength > 12)
                    {
                        GameObject newBarNoteEnd = Instantiate(noteBar, new Vector3(0, 0, 0), barQuaternion);
                        newBarNoteEnd.transform.parent = newNoteContainer.transform;            //osadź newNoteContainer jako rodzica obiektu newNote
                        newNoteContainer.gameObject.transform.SetPositionAndRotation(new Vector3(rows[i2], rowY, rowZ), noteQuaternion);
                    }
                    break;
                }
            }                      
           
            if (i < 9)
            {
                newNoteContainer.transform.name = "note00" + (i + 1);
            }
            else if (i < 99)
            {
                newNoteContainer.transform.name = "note0" + (i + 1);
            }
            else
            {
                newNoteContainer.transform.name = "note" + (i + 1);
            }


            //ustal nazwę obiektu



        }

    }


    void generateBar()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour {

    public float noteVelocity;
    Rigidbody rb;

    public bool isTheLowest = false;

    public bool isActive = false;
    private float ZPosToActive;
    private float ZPosToDestroy;

    bool move = false;

    public AudioSource songAudio;
    //public int actualTimeSamples;

    private float zPos;

    public float offset;
    public float speed;
    public float speed2;
    public float bpm;
    int selectedSong;

    bool dequeueIfTrue = true;
    public bool isMoving = false;

    int startPoint;
    bool isHoldNote;

    GameObject butt1;
    GameObject butt2;
    GameObject butt3;
    GameObject butt4;
    GameObject butt5;
    GameObject butt6;
    GameObject butt7;

    //GetComponent<AudioSource>()

    void Awake()
    {
        butt1 = GameObject.Find("button 1");
        butt2 = GameObject.Find("button 2");
        butt3 = GameObject.Find("button 3");
        butt4 = GameObject.Find("button 4");
        butt5 = GameObject.Find("button 5");
        butt6 = GameObject.Find("button 6");
        butt7 = GameObject.Find("bar");




        selectedSong = SongListV2.selectedSongByUser;

        rb = GetComponent<Rigidbody>();
        ZPosToActive = -7f;
        ZPosToDestroy = -28f;
        songAudio = GameObject.Find("Song Player").GetComponent<AudioSource>();

        bpm = SongListV2.allSongs[selectedSong].BPM;
        noteVelocity = 12f; //pr�dko�� przemieszczania si� nut - im wi�ksza, tym szybciej
        speed = 27560; // g�sto�� roz�o�enia nut, odwrotnie proporcjonalna do noteVelocity - im mniejsza, tym g�ciej        
        offset = bpm * 5.01f;

        if(SongListV2.allSongs[selectedSong].index == 0)
        {
            offset =  580f;
        }


        //PARAMETRY PASUJ�CE DO 180-187 BPM IDEALNIE:
        //noteVelocity = 12f;
        //speed = 27560;
        //offset = 907f;

        //907f/187*bpm; - taki offsset nie dzia�a

        //offset 60 BPM: 295f
        //offset 80 BPM: 
        //offset 120 BPM: 600f   600/120 = 5
        //offset 150 BPM: 
        //offset 180 = 907f;   907/180 = 5.039
        //offset 205 = 
        //offset 230 = 1153f 1153/230 = 5,013

    }

    void Start()
    {
        zPos = rb.position.z;

        startPoint = GetComponent<noteClass>().startPoint;
        if (GetComponent<noteClass>().isHold == true)
        {
            isHoldNote = true;
        }
        else
        {
            isHoldNote = false;
        }
    }
    
    void Update() {

        if (Input.anyKeyDown)
        {
            isMoving = true;           
        }

        if (isHoldNote == false)
        {
            if (gameObject.transform.position.z < ZPosToActive && gameObject.transform.position.z > ZPosToDestroy)
            {
                isActive = true;
            }
            else if (gameObject.transform.position.z < (ZPosToDestroy - 300))
            {
                isActive = false;
                resetCombo();
                isTheLowest = false;
                dequeue();

                isMoving = false;
                this.enabled = false;
            }
        }
        else if (isHoldNote == true) // TU HOLDY
        {
            if (gameObject.transform.position.z < ZPosToActive && gameObject.transform.position.z > ZPosToDestroy)
            {
                isActive = true;
            }
            else if (transform.GetChild(1).transform.position.z < ZPosToDestroy)
            {
                isActive = false;
                resetCombo();
                isTheLowest = false;
                dequeue();

                isMoving = false;
                this.enabled = false;
            }
        }

    }

    void FixedUpdate()
    {
        //Debug.Log("bpm: " + bpm);
        if (pause.isGamePaused == false && isMoving == true)
        {           
                if ((songAudio.timeSamples * ((1 / speed) * bpm) - offset) > startPoint) //TEMPO RUCHU ZMIENISZ TUTAJ, POMY�L TE� O BPM!!!
                {
                    Vector3 movement = new Vector3(0, 0, 0);
                    rb.MovePosition(transform.position - transform.forward / 9 / 187 * 195 * noteVelocity);
                }           
        }
    }

    void resetCombo()
    {
        GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
    }

    void pauses()
    {
        Debug.Break();
    }

    void dequeue()
    {
        if (dequeueIfTrue == true)
        {        
            if (gameObject.GetComponent<noteClass>().keyNumber == 1)
            {
                butt1.GetComponent<pressingNotes1>().notesQueue1.Dequeue();             
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                butt2.GetComponent<pressingNotes2>().notesQueue2.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                butt3.GetComponent<pressingNotes3>().notesQueue3.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                butt4.GetComponent<pressingNotes4>().notesQueue4.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                butt5.GetComponent<pressingNotes5>().notesQueue5.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                butt6.GetComponent<pressingNotes6>().notesQueue6.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                butt7.GetComponent<pressingNotes7>().notesQueue7.Dequeue();
            }
            else
            {
                Debug.LogError("Error: nutka nie mo�e zosta� usuni�ta, gdy� jej atrybut keyNumber nie mie�ci si� w przedziale 1-7");
            }
            dequeueIfTrue = false;
        }
    }
}
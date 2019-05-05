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


    //GetComponent<AudioSource>()

    void Awake()
    {
        selectedSong = SongListV2.selectedSongByUser;

        rb = GetComponent<Rigidbody>();
        ZPosToActive = -7f;
        ZPosToDestroy = -28f;
        songAudio = GameObject.Find("Song Player").GetComponent<AudioSource>();

        bpm = SongListV2.allSongs[selectedSong].BPM;
        noteVelocity = 12f; //prêdkoœæ przemieszczania siê nut - im wiêksza, tym szybciej
        speed = 27560; // gêstoœæ roz³o¿enia nut, odwrotnie proporcjonalna do noteVelocity - im mniejsza, tym gêœciej        
        offset = bpm * 5.01f;

        if(SongListV2.allSongs[selectedSong].index == 0)
        {
            offset =  580f;
        }


        //PARAMETRY PASUJ¥CE DO 180-187 BPM IDEALNIE:
        //noteVelocity = 12f;
        //speed = 27560;
        //offset = 907f;

        //907f/187*bpm; - taki offsset nie dzia³a

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
    }
    
    void Update() {

        if (Input.anyKeyDown)
        {
            isMoving = true;           
        }
       

        if (gameObject.transform.position.z < ZPosToActive && gameObject.transform.position.z > ZPosToDestroy)
        {
            isActive = true;
        }
        else if (gameObject.transform.position.z < ZPosToDestroy)
        {
            isActive = false;
            resetCombo();
            isTheLowest = false;
            dequeue();

            isMoving = false;
            this.enabled = false;           
        }
    }

    void FixedUpdate()
    {
        //Debug.Log("bpm: " + bpm);
        if (pause.isGamePaused == false && isMoving == true)
        {
            if ((songAudio.timeSamples * ((1 / speed) * bpm) - offset) > GetComponent<noteClass>().startPoint) //TEMPO RUCHU ZMIENISZ TUTAJ, POMYŒL TE¯ O BPM!!!
            {
                Vector3 movement = new Vector3(0, 0, 0);
                rb.MovePosition(transform.position - transform.forward / 9/187*195 * noteVelocity);
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
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Dequeue();              
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Dequeue();
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Dequeue();
            }
            else
            {
                Debug.LogError("Error: nutka nie mo¿e zostaæ usuniêta, gdy¿ jej atrybut keyNumber nie mieœci siê w przedziale 1-7");
            }
            dequeueIfTrue = false;
        }
    }
}
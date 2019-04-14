using UnityEngine;

public class note : MonoBehaviour {

    public float noteVelocity;
    Rigidbody rb;

    bool anyKeyPressedToStart = false;

    public bool isTheLowest = false;

    public bool isActive = false;
    private float ZPosToActive;
    private float ZPosToDestroy;

    bool move = false;

    public AudioSource songAudio;
    public int actualTimeSamples;

    public float offset;
    public float speed;
    public float bpm;
    int selectedSong;

    //GetComponent<AudioSource>()

    void Awake()
    {
        selectedSong = SongListV2.selectedSongByUser;


        rb = GetComponent<Rigidbody>();
        ZPosToActive = -8f;
        ZPosToDestroy = -28f;
        songAudio = GameObject.Find("Song Player").GetComponent<AudioSource>();

        noteVelocity = 1.8f;  // faktyczna prêdkoœæ poruszania siê nut, odwrotnie proporcjonalna do speed
        speed = 29500; // gêstoœæ roz³o¿enia nut, odwrotnie proporcjonalna do noteVelocity - im mniejsza, tym gêœciej

        offset = 550f;
        bpm = SongListV2.allSongs[selectedSong].BPM;

        //LICZNIK KTÓRY ODMIERZA RUCH NUT NIE MO¯E BAZOWAÆ NA SONGAUDIO.TIMESAMPLES BO NUTY MUSZ¥ MÓC SIÊ PORUSZAÆ ZANIM ODGRYWANA JEST MUZYKA!
    }
    
    void Update() {

        if (Input.anyKeyDown)
        {
            anyKeyPressedToStart = true;
        }
        
        if (pause.isGamePaused == false && anyKeyPressedToStart == true)
        {
            if((songAudio.timeSamples*((1/speed) * bpm) - offset) > GetComponent<noteClass>().startPoint) //TEMPO RUCHU ZMIENISZ TUTAJ, POMYŒL TE¯ O BPM!!!
            {
                rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
                actualTimeSamples = songAudio.timeSamples;
            }
        }

        if (gameObject.transform.position.z < ZPosToActive && gameObject.transform.position.z > ZPosToDestroy)
        {
            isActive = true;
        }

        if (gameObject.transform.position.z < ZPosToDestroy)
        {
            isActive = false;
            resetCombo();

            dequeue();

            Destroy(gameObject);
            
        }
    }

    void resetCombo()
    {
        //GameObject.Find("Score").GetComponent<playerScore>().playerCurrentScore += 200;
        GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
    }

    void dequeue()
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
    }
}
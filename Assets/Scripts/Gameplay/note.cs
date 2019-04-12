using UnityEngine;

public class note : MonoBehaviour {

    public float noteVelocity = 1.75f;
    Rigidbody rb;

    bool anyKeyPressedToStart = false;

    public bool isTheLowest = false;

    public bool isActive = false;
    private float ZPosToActive;
    private float ZPosToDestroy;

    bool move = false;

    public AudioSource songAudio;
    public int actualTimeSamples;


    //GetComponent<AudioSource>()

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ZPosToActive = -8f;
        ZPosToDestroy = -28f;
       songAudio = GameObject.Find("Song Player").GetComponent<AudioSource>();
    }
    
    void Update() {

        if (Input.anyKeyDown)
        {
            anyKeyPressedToStart = true;
        }
        
        if (pause.isGamePaused == false && anyKeyPressedToStart == true)
        {
            if(songAudio.timeSamples/200 > GetComponent<noteClass>().startPoint) //TEMPO RUCHU ZMIENISZ TUTAJ, POMYŒL TE¯ O BPM!!!
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

            if(gameObject.GetComponent<noteClass>().keyNumber == 1)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Dequeue();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                //GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Dequeue();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Error: nutka nie mo¿e zostaæ usuniêta, gdy¿ jej atrybut keyNumber nie mieœci siê w przedziale 1-7");
            }
        }
    }
}
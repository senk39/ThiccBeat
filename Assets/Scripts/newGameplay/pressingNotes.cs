using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject go;
    //public GameObject goc;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public bool antiMasherConnector = false;
    // GENERATOR
    public bool notesGenerator = true;
    public GameObject gnote;
    Vector3 gnotevector = new Vector3(0f, 0.35f, -14.19f);
    Quaternion gnoteq = new Quaternion(0f, 0f, 0f, 0f);

    //BPM
    public int bpm = 195;

    public AudioSource hitOrMiss;

    void Awake()
    {
        antiMasherConnector = false;
        hitOrMiss = GameObject.Find("BUTTONS").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notesGenerator)
        {  
            InvokeRepeating("noteInstantiateForGenerator", 3.0f, 3f);
        }

            go = GetComponent<noteGenerator>().active1;
      





        if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest && antiMasherConnector == false)
            {
                hitOrMiss.Play();
                if (go.tag == "h_note_start")
                {
                    //go.transform.parent.Find("pivot").Find("noteMid").GetComponent<holdContainterForNoteMid>().counterForBlockMultipleClicks++;
                    go.transform.parent.Find("pivot").Find("noteMid").GetComponent<holdContainterForNoteMid>().noteStartIsClicked = true;
                    // Debug.Log("to sie zdarzylo");

                }
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;

                Destroy(go);
                isActive = false;
            }

            if (Input.GetKeyUp(key) && isActive && go.GetComponent<note>().isTheLowest)
            {
                if (go.tag == "h_note_start")
                {
                    //go.transform.parent.Find("pivot").Find("noteMid").GetComponent<holdContainterForNoteMid>().counterForBlockMultipleClicks++;
                }
            }

        

        //antiMasher();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Note")
        {
            isActive = true;
        }

        else if (col.tag == "h_note_start")
        {
            isActive = true;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note" && notesGenerator == false)
        {
            isActive = false;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;
        }
        if ((col.tag == "h_note_start" || col.tag == "h_note_end") && notesGenerator == false)
        {
            isActive = false;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;
        }
        if (col.tag == "h_note_mid" && notesGenerator == false)
        {
            isActive = false;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }


    }

    void noteInstantiateForGenerator()
    {
        Instantiate(gnote, gnotevector, gnoteq);
    }

  
}
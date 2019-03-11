using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject go;
    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

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

    void Awake()
    {
        antiMasherConnector = false;
    }

    void Update()
    {
        if (notesGenerator)
        {
            InvokeRepeating("noteInstantiateForGenerator", 3.0f, 3f);
        }

        if (go != null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest && go.GetComponent<note>().isActive /*&& antiMasherConnector == false*/)
            {
            playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            
            notesList.Remove(go);
            Destroy(go);
            GameObject.Find("BUTTONS").GetComponent<AudioSource>().Play();

                if (notesList.Count == 0)
                {
                    isActive = false;
                }
            }
        }
        //antiMasher();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Note")
        {
            notesList.AddLast(col.gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;
        }

        else if (col.tag == "h_note_start")
        {
            notesList.AddLast(col.gameObject);
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note")
        {
            notesList.Remove(col.gameObject); 
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;

            if (notesList.Count > 0)
            {
                go = notesList.First.Value.gameObject;
            }

            else
            {
                go = null;
                isActive = false;
            }
        }

        if ((col.tag == "h_note_start" || col.tag == "h_note_end") && notesGenerator == false)
        {
            notesList.Remove(col.gameObject);
            isActive = false;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;
            go = notesList.First.Value.gameObject;
        }

        if (col.tag == "h_note_mid" && notesGenerator == false)
        {
            notesList.Remove(col.gameObject);
            isActive = false;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            go = notesList.First.Value.gameObject;
        }
    }

    void noteInstantiateForGenerator()
    {
        Instantiate(gnote, gnotevector, gnoteq);
    }
}
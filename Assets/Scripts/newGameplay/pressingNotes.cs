using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{

    public KeyCode key;

    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject go;

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

    // Use this for initialization
    void Awake()
    {
        antiMasherConnector = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (notesGenerator)
        {
            InvokeRepeating("noteInstantiateForGenerator", 3.0f, 3f);
        }



        if (go != null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest && antiMasherConnector == false)
            {

                if (go.tag == "h_note_start")
                {
                    //go.transform.parent.Find("pivot").Find("noteMid").GetComponent<holdContainterForNoteMid>().counterForBlockMultipleClicks++;
                    go.transform.parent.Find("pivot").Find("noteMid").GetComponent<holdContainterForNoteMid>().noteStartIsClicked = true;
                    // Debug.Log("to sie zdarzylo");

                }



                notesList.RemoveFirst();
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

        }

        //antiMasher();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Note")
        {
            notesList.AddLast(col.gameObject);
        }

        else if (col.tag == "h_note_start")
        {
            notesList.AddLast(col.gameObject);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Note")
        {
            isActive = true;
            //go = notesList.First.Value.gameObject;
        }

        else if (col.tag == "h_note_start")
        {
            isActive = true;
            //go = notesList.First.Value.gameObject;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note")
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;
        }
        if ((col.tag == "h_note_start" || col.tag == "h_note_end") && notesGenerator == false)
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
            antiMasherConnector = false;
        }
        if (col.tag == "h_note_mid" && notesGenerator == false)
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }


    }

    void noteInstantiateForGenerator()
    {
        Instantiate(gnote, gnotevector, gnoteq);
    }


}
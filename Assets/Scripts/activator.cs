using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {

    //public int greatHitPoints = 50;
    //public int perfectHitPoints = 200;

    public KeyCode key;
    public bool active = false;
    public uint currentNoteValue = 0;
    public GameObject note;

    public GameObject earlyTrigger;
    public GameObject lateTrigger;


    public enum ActivatorType { Perfect, Great, Miss, Awaiting };
    public ActivatorType activatorType;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;
    public GameObject NoteWithValue;
    public uint actNoteValue;

    
    List<GameObject> currentlyTriggeredNotes;
    GameObject[] zValuesOfCurrentlyTriggeredNotes;

    // Use this for initialization
    void Start () {
        currentlyTriggeredNotes = new List<GameObject>();

    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(currentlyTriggeredNotes.Count);

        if (Input.GetKeyDown(key) && active && GetComponent<NoteBehaviour>().isNoteTheLowest)
        {
            addScore();
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            active = false;        
            Destroy(note);

        }
    }

    void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag=="Note")
        {
            active = true;
            note = col.gameObject;
            currentlyTriggeredNotes.Add(col.gameObject);
            destroyIfTooLate();       
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Note")
        {
            active = false;
            currentNoteValue = 0;
            currentlyTriggeredNotes.Remove(col.gameObject);
        }
    }

   public void addScore()
    {
        actNoteValue = note.GetComponent<NoteBehaviour>().actualNoteValue;
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += actNoteValue;
    }

    public void destroyIfTooLate()
    {
        
       if (activatorType == ActivatorType.Miss)
        {
            Destroy(note);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
        }
    }

   

}

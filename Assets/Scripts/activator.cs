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
    GameObject note;

    public GameObject earlyTrigger;
    public GameObject lateTrigger;


    public enum ActivatorType { Perfect, Great, Miss, Awaiting };
    public ActivatorType activatorType;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;
    public GameObject NoteWithValue;
    public uint actNoteValue;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key) && active)
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
            checkPressedActivatorType();
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Note")
        {
            active = false;
            currentNoteValue = 0;
        }
    }

   public void addScore()
    {
        actNoteValue = note.GetComponent<NoteBehaviour>().actualNoteValue;
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += actNoteValue;
    }

    void checkPressedActivatorType()
    {
        if (activatorType == ActivatorType.Perfect)
        {
            //blockNonPerfectHits();
        }

       if (activatorType == ActivatorType.Great)
        {
            //unblockNonPerfectHits();    
        }

       if (activatorType == ActivatorType.Miss)
        {
            Destroy(note);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
        }
    }

    void blockNonPerfectHits()
    {
        earlyTrigger.SetActive(false);
        lateTrigger.SetActive(false);
    }

    void unblockNonPerfectHits()
    {
        active = true;

        //earlyTrigger.SetActive(true);
        //lateTrigger.SetActive(true);
    }

}

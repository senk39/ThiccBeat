using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {

    //public int greatHitPoints = 50;
    //public int perfectHitPoints = 200;

    public KeyCode key;
    public bool active = false;
    GameObject note;

    public GameObject earlyTrigger;
    public GameObject lateTrigger;


    public enum ActivatorType { Perfect, EarlyGreat, LateGreat, Miss, Awaiting };
    public ActivatorType activatorType;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject NoteWithValue;
    public uint actNoteValue;

    public int incrementator = 0;

    List<GameObject> currentCollisions = new List<GameObject>();


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

       // Debug.Log(incrementator);

        if (Input.GetKeyDown(key) && active)
        {
            incrementator--;
            addScore();
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            active = false;
            destroyNote();
            incrementator--;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Note")
        {
            incrementator++;
            addToReadyNotesList();


            active = true;
            note = col.gameObject;
            missNote();
            /*
            if (incrementator == 0 || incrementator == 1)
            {

                active = true;
                note = col.gameObject;
                missNote();
            }*/
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Note")
        {
            incrementator--;
            active = false;
            actNoteValue = 0;
        }
        
    }

   public void addScore()
    {
        actNoteValue = note.GetComponent<NoteBehaviour>().actualNoteValue;
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += actNoteValue;
    }

    void missNote()
    {
        if (activatorType == ActivatorType.Miss)
        {
            destroyNote();
            incrementator--;
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
        }
    }

    void addToReadyNotesList()
    {
        if (activatorType == ActivatorType.EarlyGreat)
        {
            currentCollisions.Add(note);
            Debug.Log("array: " + currentCollisions);
        }
    }


    void destroyNote()
    {
        Destroy(note);
        currentCollisions.Remove(note);
    }
}

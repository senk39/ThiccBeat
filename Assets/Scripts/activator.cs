using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {

<<<<<<< HEAD
    //public int greatHitPoints = 50;
    //public int perfectHitPoints = 200;
=======
    public int greatHitPoints = 1;
    public int perfectHitPoints = 1000;
>>>>>>> parent of 50d9172... SCORE COUNTER DONE

    public KeyCode key;
    public bool active = false;
    public uint currentNoteValue = 0;
    public GameObject note;

<<<<<<< HEAD
    public GameObject earlyTrigger;
    public GameObject lateTrigger;


=======
    //ActivatorType currentActivatorType = ActivatorType.Awaiting;
>>>>>>> parent of 50d9172... SCORE COUNTER DONE
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
            note.SetActive(false);

        }

    }

    void OnTriggerEnter(Collider col)
    {
        active = true;
        if(col.gameObject.tag=="Note")
        {
            if (activatorType == ActivatorType.Perfect)
            {
                currentNoteValue = perfectHitPoints;
            }

            else
            {
                currentNoteValue = greatHitPoints;
            }

            note = col.gameObject;
<<<<<<< HEAD
            currentlyTriggeredNotes.Add(col.gameObject);
            destroyIfTooLate();       
=======
>>>>>>> parent of 50d9172... SCORE COUNTER DONE
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

<<<<<<< HEAD
    public void destroyIfTooLate()
    {
        
       if (activatorType == ActivatorType.Miss)
        {
            //Destroy(note);
            note.SetActive(false);
            note.GetComponent<MeshRenderer>().enabled = false;

            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
        }
    }

   

=======
    
>>>>>>> parent of 50d9172... SCORE COUNTER DONE
}

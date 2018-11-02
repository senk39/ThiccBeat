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

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public uint actNoteValue;

    public int collisionsCounter = 0;

    //public int howManyNotesAreInActiveField = 0;


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {



    }

    void OnTriggerEnter(Collider col)
    {
            if (col.gameObject.tag == "Note")
        {
            collisionsCounter++;
            active = true;

            if (col.gameObject.GetComponent<NoteBehaviour>().isTheLowest)
            {
                note = col.gameObject;
            }
        }
         
              
            
    }

    void OnTriggerStay(Collider col)
    {
        keyClick();
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Note")
        {
            collisionsCounter--;
            active = false;
            actNoteValue = 0;
           // destroyNote();
        }
        
    }

   public void addScore()
    {
        //actNoteValue = note.GetComponent<NoteBehaviour>().actualNoteValue; ///// DODAJ TU JAKIEGOŚ IF IF NOT DESTROYED BO MI ODWOŁUJE SIĘ DO ROZWALONEJ NUTKI
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += actNoteValue;
    }





    void destroyNote()
    {
        Destroy(note);
        collisionsCounter--;
    }

    void keyClick()
    {
        if (Input.GetKeyDown(key) && active)
        {
            if (note.GetComponent<NoteBehaviour>().isTheLowest)
            {
                addScore();
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;
                active = false;
                destroyNote();
            }
        }
    }
}

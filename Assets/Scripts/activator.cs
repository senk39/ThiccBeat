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

    public GameObject NoteWithValue;
    public uint actNoteValue;

    public int incrementator = 0;
    public bool isTheLowest = false;

    //public int howManyNotesAreInActiveField = 0;


    List<GameObject> currentCollisions = new List<GameObject>();


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

       // Debug.Log(incrementator);

        if (Input.GetKeyDown(key) && active)
        {
            addScore();
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            active = false;
            destroyNote();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Note")
        {
            
            addToReadyNotesList();


            active = true;
            note = col.gameObject;  // TU JEST BŁĄD. PRZY KAŻDEJ NOWEJ KOLIZJI OBIEKT NUTA JEST ZAMIENIANY PRZEZ NOWĄ SPADAJĄCĄ NUTKĘ
            
 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Note")
        {
            active = false;
            actNoteValue = 0;
            destroyNote();
        }
        
    }

   public void addScore()
    {
        actNoteValue = note.GetComponent<NoteBehaviour>().actualNoteValue; ///// DODAJ TU JAKIEGOŚ IF IF NOT DESTROYED BO MI ODWOŁUJE SIĘ DO ROZWALONEJ NUTKI
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += actNoteValue;
    }


    void addToReadyNotesList()
    {
      
            currentCollisions.Add(note);
        Debug.Log("array: " + currentCollisions);
           
        
    }


    void destroyNote()
    {
        currentCollisions.Remove(note);
        Destroy(note);
    }
}

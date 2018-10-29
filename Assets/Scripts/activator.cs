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

    //public int howManyNotesAreInActiveField = 0;

    public List<float> zParamOfNote = new List<float>();


    List<GameObject> currentCollisions = new List<GameObject>();

    List<GameObject> currentCollisions2 = new List<GameObject>();




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
            destroyNote();
        }
    }

    void OnTriggerEnter(Collider col)
    {

        //zParamOfNote.Add(col.gameObject.GetComponent<Transform>().position.z);

        float nearestDistanceFromActivator = 9999f;
        /*
        foreach (GameObject note in currentCollisions2)
        {
            if (nearestDistanceFromActivator > GetComponent<Transform>().position.z)
                {
                    nearestDistanceFromActivator = GetComponent<Transform>().position.z;
                }
        }
        */

        


            if (col.gameObject.tag == "Note")
            {
            currentCollisions2.Add(col.gameObject);

            for (int i = 0; i < currentCollisions2.Count; i++)
            {
                if (nearestDistanceFromActivator > GetComponent<Transform>().position.z)
                {
                    nearestDistanceFromActivator = GetComponent<Transform>().position.z;
                    note = col.gameObject;  // TU JEST BŁĄD. PRZY KAŻDEJ NOWEJ KOLIZJI OBIEKT NUTA JEST ZAMIENIANY PRZEZ NOWĄ SPADAJĄCĄ NUTKĘ

                }
            }

            addToReadyNotesList();


                active = true;


            }
        
    }

    void thisNewMethodToSortNotes()
    {

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
   
        //Debug.Log("array: " + currentCollisions);


    }


    void destroyNote()
    {
        currentCollisions.Remove(note);
        Destroy(note);
    }
}

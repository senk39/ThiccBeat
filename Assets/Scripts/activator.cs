using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {

    public int greatHitPoints = 1;
    public int perfectHitPoints = 1000;

    public KeyCode key;
    public bool active = false;
    public int currentNoteValue = 0;
    GameObject note;

    //ActivatorType currentActivatorType = ActivatorType.Awaiting;
    public enum ActivatorType { Perfect, Great, Miss, Awaiting };
    public ActivatorType activatorType;

    public GameObject playerScoreContainer;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            addScore();
            active = false;
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
        }
    }

    void OnTriggerExit(Collider col)
    {
        active = false;
        currentNoteValue = 0;
    }

   public void addScore()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += currentNoteValue;
    }

    
}

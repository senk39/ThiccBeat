using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activator : MonoBehaviour {

    public int greatHitPoints = 50;
    public int perfectHitPoints = 200;

    public KeyCode key;
    public bool active = false;
    public int currentNoteValue = 0;
    GameObject note;

    public GameObject earlyTrigger;
    public GameObject lateTrigger;


    public enum ActivatorType { Perfect, Great, Miss, Awaiting };
    public ActivatorType activatorType;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            addScore();
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            active = false;
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
        active = false;
        currentNoteValue = 0;
    }

   public void addScore()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += currentNoteValue;
    }

    void checkPressedActivatorType()
    {
        if (activatorType == ActivatorType.Perfect)
        {
            blockNonPerfectHits();
        }

       if (activatorType == ActivatorType.Great)
        {
            currentNoteValue = greatHitPoints;
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
        active = true;
        currentNoteValue = perfectHitPoints;
    }

}

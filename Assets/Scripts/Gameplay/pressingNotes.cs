using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject go;
    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    void Update()
    {
        if (go != null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest && go.GetComponent<note>().isActive)
            {
            playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;
            
            notesList.Remove(go);
            Destroy(go.transform.parent.gameObject);

            GameObject.Find("buttons").GetComponent<AudioSource>().Play();

                if (notesList.Count == 0)
                {
                    isActive = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "noteContainer")
        {
            notesList.AddLast(col.transform.FindChild("note(clone)").gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;

        }

        else if (col.tag == "Note")
        {
            notesList.AddLast(col.gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note")
        {
            notesList.Remove(col.gameObject); 
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject.transform.parent.gameObject);

            if (notesList.Count > 0)
            {
                go = notesList.First.Value.gameObject;
            }

            else
            {
                go = null;
                isActive = false;
            }
        }
    }
}
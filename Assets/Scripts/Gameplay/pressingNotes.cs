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
            Debug.Log("onTriggerEnter: notecontainer");
            notesList.AddLast(col.transform.Find("note(Clone)").gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;

        }

        else if (col.tag == "noteContainerBar")
        {
            Debug.Log("BAR onTriggerEnter: notecontainer");
            notesList.AddLast(col.transform.Find("barNote(Clone)").gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;

        }

        else if (col.tag == "Note")
        {
            Debug.Log("onTriggerEnter: note");
            notesList.AddLast(col.gameObject);
            isActive = true;
            go = notesList.First.Value.gameObject;
        }
        else
        {
            Debug.Log("onTriggerEnter: else");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "noteContainer")
        {
            Debug.Log("onTriggerExit: notecontainer");
            notesList.Remove(col.transform.Find("note(Clone)").gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);

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

        else if (col.tag == "Note")
        {
            Debug.Log("onTriggerExit: note");
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

/*

    gdy następuje dotyk nutki 


    */
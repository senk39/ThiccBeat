using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotesBar : MonoBehaviour
{
    public KeyCode key;
    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();
    public bool isActive = false;
    public GameObject go;
    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    void Update()
    {
        if (go != null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest)
            {
                notesList.RemoveFirst();
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;

                GameObject.Find("buttons").GetComponent<AudioSource>().Play();
                Destroy(go);
                isActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            notesList.AddLast(col.gameObject);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            isActive = true;
            go = notesList.First.Value.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }
    }
}

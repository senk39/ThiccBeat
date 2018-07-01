using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortNotes1 : MonoBehaviour {

    public List<GameObject> noteList1 = new List<GameObject>();

    public enum SelectedRow { row1, row2, row3, row4, row5, row6 };
    public SelectedRow selectedRow;

    private float r1 = -5.1f;
    private float r2 = -3.1f;
    private float r3 = -1.1f;
    //====================
    private float r4 = 1.1f;
    private float r5 = 3.1f;
    private float r6 = 5.1f;

    GameObject tooLateBlock;

    float min = 5000f;



    // Use this for initialization

    void Awake ()
    {
        tooLateBlock = GameObject.Find("late miss indicator");
    }

    void Start () {
        

    }

    // Update is called once per frame
    void Update () {
        rowSelector();
    }


    void rowSelector()
    {
        addingNotesToList();
        findTheLowestZValue();
        settingTheLowestBoolToTheNote();
    }

    /*
    public void removeNotesFromList()
    {
        if (selectedRow == SelectedRow.row1)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note")) //NIE DLA KAŻDEGO A TYLKO DLA JEDNEJ NUTY
            {
                if (singleNote.GetComponent<Transform>().position.x == r1)
                {
                    noteList1.Remove(singleNote);
                }
            }
        }
    }*/

    void addingNotesToList()
    {
        if (selectedRow == SelectedRow.row1)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note"))
            {
                if (singleNote.GetComponent<Transform>().position.x == r1 && !noteList1.Contains(singleNote) && singleNote.GetComponent<Transform>().position.z != null)
                {
                    noteList1.Add(singleNote);
                }
            }
        }
    }

    void findTheLowestZValue()
    {
        foreach (GameObject singleNote in noteList1)
        {
            if (singleNote.GetComponent<Transform>().position.z < min && singleNote.GetComponent<Transform>().position.z != null)
            {
                min = singleNote.GetComponent<Transform>().position.z;
            }

        }
    }

    void settingTheLowestBoolToTheNote()
    {
        foreach (GameObject singleNote in noteList1)
        {
            if (singleNote.GetComponent<Transform>().position.z == min && singleNote.GetComponent<Transform>().position.z != null)
            {
                singleNote.GetComponent<NoteBehaviour>().isNoteTheLowest = true;
            }

            else
            {
                singleNote.GetComponent<NoteBehaviour>().isNoteTheLowest = false;
            }
        }
    }

}
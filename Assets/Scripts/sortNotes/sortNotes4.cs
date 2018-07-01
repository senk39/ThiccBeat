using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortNotes4 : MonoBehaviour
{

    public List<GameObject> noteList4 = new List<GameObject>();


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

    void Awake()
    {
        tooLateBlock = GameObject.Find("late miss indicator");
    }

    void Start()
    {
        rowSelector();

    }

    // Update is called once per frame
    void Update()
    {
    }


    void rowSelector()
    {
        if (selectedRow == SelectedRow.row4)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note"))
            {

                if (singleNote.GetComponent<Transform>().position.x == r4)
                {
                    noteList4.Add(singleNote);
                }

                if (singleNote.GetComponent<Transform>().position.x == r4)
                {
                    noteList4.Add(singleNote);
                }


            }

        }

        foreach (GameObject singleNote in noteList4) //THIS IS CHECKING THE LOWEST Z POSITION
        {
            Debug.Log(singleNote.GetComponent<Transform>().position.z);

            if (singleNote.GetComponent<Transform>().position.z < min)
            {

                min = singleNote.GetComponent<Transform>().position.z;
                Debug.Log("min" + min);
            }

        }
        foreach (GameObject singleNote in noteList4) // THIS ONE IS ASSIGNING THE LOWEST SCORE TO ONE NOTE
        {
            if (singleNote.GetComponent<Transform>().position.z == min)
            {
                singleNote.GetComponent<NoteBehaviour>().isNoteTheLowest = true;

            }
            else
            {
                singleNote.GetComponent<NoteBehaviour>().isNoteTheLowest = false;

            }

        }




    }

    public void removeNotesFromList()
    {
        if (selectedRow == SelectedRow.row4)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note")) //NIE DLA KAŻDEGO A TYLKO DLA JEDNEJ NUTY
            {
                if (singleNote.GetComponent<Transform>().position.x == r4)
                {
                    noteList4.Remove(singleNote);
                }
            }
        }


    }



}
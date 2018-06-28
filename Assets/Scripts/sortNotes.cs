using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortNotes : MonoBehaviour {

    public List<GameObject> noteList = new List<GameObject>();

    GameObject tooLateBlock = GameObject.Find("late miss indicator");

    public enum SelectedRow { row1, row2, row3, row4, row5, row6 };
    public SelectedRow selectedRow;

    private float r1 = -5.1f;
    private float r2 = -3.1f;
    private float r3 = -1.1f;
    //====================
    private float r4 = 1.1f;
    private float r5 = 3.1f;
    private float r6 = 5.1f;


    // Use this for initialization
   

    void Start () {
        rowSelector();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void rowSelector()
    {
        if (selectedRow == SelectedRow.row1)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note"))
            {
                if (singleNote.GetComponent<Transform>().position.x == r1)
                {
                    noteList.Add(singleNote);
                }
            }
        }
    }

    void removeNotesFromList()
    {
        if (selectedRow == SelectedRow.row1)
        {
            foreach (GameObject singleNote in GameObject.FindGameObjectsWithTag("Note"))
            {
                if (singleNote.GetComponent<Transform>().position.x == r1)
                {
                    noteList.Add(singleNote);
                }
            }
        }
    }



}
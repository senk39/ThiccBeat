using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingNotes : MonoBehaviour
{
    private float row1x = -5.1f;
    private float row2x = -3.1f;
    private float row3x = -1.1f;
    private float row4x = 1.1f;
    private float row5x = 3.1f;
    private float row6x = 5.1f;
    private float rowbarx = 2.83f;

    List<GameObject> row1 = new List<GameObject>();
    List<GameObject> row2 = new List<GameObject>();
    List<GameObject> row3 = new List<GameObject>();
    List<GameObject> row4 = new List<GameObject>();
    List<GameObject> row5 = new List<GameObject>();
    List<GameObject> row6 = new List<GameObject>();
    List<GameObject> rowbar = new List<GameObject>();

    void Start()
    {
    }

    void Update()
    {
        addNotesToLists();

        checkIfTheLowestRow1();
        checkIfTheLowestRow2();
        checkIfTheLowestRow3();
        checkIfTheLowestRow4();
        checkIfTheLowestRow5();
        checkIfTheLowestRow6();
        checkIfTheLowestRowbar();

        deleteNotesFromLists();
    }

    void checkIfTheLowestRow1()
    {

        if (row1.Count > 1)
        {

            float min = float.MaxValue;
            float max = float.MinValue;

            int minIndex = 0;

            //float minimum = float.MaxValue;
            //int correctIndex = row1.Count - 1;

            for (int i = 0; i < row1.Count; i++)
            {


                if (row1[i].transform.position.z < min)
                {
                    min = row1[i].transform.position.z;
                    //row1[i].GetComponent<note>().isTheLowest = true;
                    minIndex = i;
                }
                if (row1[i].transform.position.z > max)
                {
                    max = row1[i].transform.position.z;
                    row1[i].GetComponent<note>().isTheLowest = false;
                }
            }

            //Debug.Log("minimum: " + minimum);
            //Debug.Log("correct Index: " + correctIndex);

            row1[minIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row1.Count == 1)
        {
            row1[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRow2()
    {

        if (row2.Count > 1)
        {
            //float minimum = float.MaxValue;
            int correctIndex = row2.Count - 1;

            for (int i = 0; i < row2.Count - 1; i++)
            {
                if (row2[i].transform.position.z < row2[i + 1].transform.position.z)
                {
                    // minimum = row2[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    row2[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }
            //Debug.Log("minimum: " + minimum);
            //Debug.Log("correct Index: " + correctIndex);

            row2[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row2.Count == 1)
        {
            row2[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRow3()
    {

        if (row3.Count > 1)
        {
            //float minimum = float.MaxValue;
            int correctIndex = row3.Count - 1;

            for (int i = 0; i < row3.Count - 1; i++)
            {
                if (row3[i].transform.position.z < row3[i + 1].transform.position.z)
                {
                    // minimum = row3[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    row3[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }
            //Debug.Log("minimum: " + minimum);
            //Debug.Log("correct Index: " + correctIndex);

            row3[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row3.Count == 1)
        {
            row3[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRow4()
    {

        if (row4.Count > 1)
        {
            //float minimum = float.MaxValue;
            int correctIndex = row4.Count - 1;

            for (int i = 0; i < row4.Count - 1; i++)
            {
                if (row4[i].transform.position.z < row4[i + 1].transform.position.z)
                {
                    //minimum = row4[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    row4[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }
            //Debug.Log("minimum: " + minimum);
            //Debug.Log("correct Index: " + correctIndex);

            row4[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row4.Count == 1)
        {
            row4[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRow5()
    {

        if (row5.Count > 1)
        {
            // minimum = float.MaxValue;
            int correctIndex = row5.Count - 1;

            for (int i = 0; i < row5.Count - 1; i++)
            {
                if (row5[i].transform.position.z < row5[i + 1].transform.position.z)
                {
                    //minimum = row5[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    row5[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }
            //Debug.Log("minimum: " + minimum);
            //Debug.Log("correct Index: " + correctIndex);

            row5[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row5.Count == 1)
        {
            row5[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRow6()
    {
        if (row6.Count > 1)
        {
            float minimum = float.MaxValue;
            int correctIndex = row6.Count - 1;

            for (int i = 0; i < row6.Count - 1; i++)
            {
                if (row6[i].transform.position.z < row6[i + 1].transform.position.z)
                {
                    minimum = row6[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    row6[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }
            row6[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (row6.Count == 1)
        {
            row6[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void checkIfTheLowestRowbar()
    {
        if (rowbar.Count > 1)
        {
            float minimum = float.MaxValue;
            int correctIndex = rowbar.Count - 1;

            for (int i = 0; i < rowbar.Count - 1; i++)
            {
                if (rowbar[i].transform.position.z < rowbar[i + 1].transform.position.z)
                {
                    minimum = rowbar[i].transform.position.z;
                    correctIndex = i;
                }
                else
                {
                    rowbar[correctIndex].GetComponent<note>().isTheLowest = false;
                }
            }

            rowbar[correctIndex].GetComponent<note>().isTheLowest = true;
        }
        else if (rowbar.Count == 1)
        {
            rowbar[0].GetComponent<note>().isTheLowest = true;
        }
    }

    void addNotesToLists()
    {
        foreach (GameObject songNote in GameObject.FindGameObjectsWithTag("Note"))
        {
            if (songNote.transform.position.x == row1x)
            {
                row1.Add(songNote);
            }
            else if (songNote.transform.position.x == row2x)
            {
                row2.Add(songNote);
            }
            else if (songNote.transform.position.x == row3x)
            {
                row3.Add(songNote);
            }
            else if (songNote.transform.position.x == row4x)
            {
                row4.Add(songNote);
            }
            else if (songNote.transform.position.x == row5x)
            {
                row5.Add(songNote);
            }
            else if (songNote.transform.position.x == row6x)
            {
                row6.Add(songNote);
            }
        }

        foreach (GameObject songNote in GameObject.FindGameObjectsWithTag("NoteBar"))
        {
            if (songNote.transform.position.x == rowbarx)
            {
                rowbar.Add(songNote);
            }
        }

        foreach (GameObject songNote in GameObject.FindGameObjectsWithTag("h_note_start"))
        {
            if (songNote.transform.position.x == row1x)
            {
                row1.Add(songNote);
            }
            else if (songNote.transform.position.x == row2x)
            {
                row2.Add(songNote);
            }
            else if (songNote.transform.position.x == row3x)
            {
                row3.Add(songNote);
            }
            else if (songNote.transform.position.x == row4x)
            {
                row4.Add(songNote);
            }
            else if (songNote.transform.position.x == row5x)
            {
                row5.Add(songNote);
            }
            else if (songNote.transform.position.x == row6x)
            {
                row6.Add(songNote);
            }
        }
    }

        void deleteNotesFromLists()
    {
            row1.Clear();
            row2.Clear();
            row3.Clear();
            row4.Clear();
            row5.Clear();
            row6.Clear();
            rowbar.Clear();
        }
    }
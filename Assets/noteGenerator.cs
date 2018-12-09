using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class noteGenerator : MonoBehaviour
{


    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();


    /*
     
FULL BEAT: 12.09

1/2: 6.045

1/4: 3.0225 //ustawiona jako standardowa odległość między nutami - 48 jednostek

1/8: 1.51125

1/16: 0.755625

1 nuta: 48 jednostek midi

48/3.0225 = ilość jednostek midi mieszczących się 
     */

    // GENERATOR
    public TextAsset row1;
    public TextAsset row2;
    public TextAsset row3;
    public TextAsset row4;
    public TextAsset row5;
    public TextAsset row6;

    public string textContent1;
    public string textContent2;
    public string textContent3;
    public string textContent4;
    public string textContent5;
    public string textContent6;


    public string[] textContentSplit1;


    public float firstNote = 105.15f;
    public bool notesGenerator = true;
    public GameObject gnote;
    Vector3 gnotevector = new Vector3(0f, 0.35f, -14.19f);
    Quaternion gnoteq = new Quaternion(0f, 0f, 0f, 0f);

    //BPM
    public float bpm = 195f;
    public float distBetweenNotes;


    int[] numbers;
    int tempValueRow1 = 0;
    int tempValueRow2 = 0;
    int tempValueRow3 = 0;
    int tempValueRow4 = 0;
    int tempValueRow5 = 0;
    int tempValueRow6 = 0;

    const float link = 15.8808933002f;
    //const float oneMidiLength = 0.1259375f;
    const float oneMidiLength = 0.12565f;


    //const float firstNotePos = 105.15f;
    // const float firstNotePos = 90f;

    const float firstNotePos = 104.8f;




    // Use this for initialization
    void Start()
    {
        distBetweenNotes = (60 / bpm);

       // InvokeRepeating("noteInstantiateForGenerator", 3f, distBetweenNotes);

        textContent1 = row1.text;
        textContent2 = row2.text;
        textContent3 = row3.text;
        textContent4 = row4.text;
        textContent5 = row5.text;
        textContent6 = row6.text;


        string[] textContentSplit1 = textContent1.Split(new char[] { ' ', ',', '.', '\n', '\t' });
        string[] textContentSplit2 = textContent2.Split(new char[] { ' ', ',', '.', '\n', '\t' });
        string[] textContentSplit3 = textContent3.Split(new char[] { ' ', ',', '.', '\n', '\t' });
        string[] textContentSplit4 = textContent4.Split(new char[] { ' ', ',', '.', '\n', '\t' });
        string[] textContentSplit5 = textContent5.Split(new char[] { ' ', ',', '.', '\n', '\t' });
        string[] textContentSplit6 = textContent6.Split(new char[] { ' ', ',', '.', '\n', '\t' });


        foreach (string s in textContentSplit1)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow1);
                //Debug.Log(tempValueRow1);
                Instantiate(gnote, new Vector3(-5.1f, 0.35f, (firstNotePos + (tempValueRow1 * oneMidiLength))), gnoteq);
            }
        }

        foreach (string s in textContentSplit2)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow2);
                //Debug.Log(tempValueRow2);
                //Instantiate(gnote, new Vector3(-3.1f, 0.35f, (105.15f + (tempValueRow2 / link))), gnoteq);
                Instantiate(gnote, new Vector3(-3.1f, 0.35f, (firstNotePos + (tempValueRow2 * oneMidiLength))), gnoteq);
            }
        }

        foreach (string s in textContentSplit3)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow3);
                //Debug.Log(tempValueRow3);
                Instantiate(gnote, new Vector3(-1.1f, 0.35f, (firstNotePos + (tempValueRow3 * oneMidiLength))), gnoteq);
            }
        }
        foreach (string s in textContentSplit4)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow4);
                //Debug.Log(tempValueRow4);
                Instantiate(gnote, new Vector3(1.1f, 0.35f, (firstNotePos + (tempValueRow4 * oneMidiLength))), gnoteq);
            }
        }
        foreach (string s in textContentSplit5)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow5);
                //Debug.Log(tempValueRow5);
                Instantiate(gnote, new Vector3(3.1f, 0.35f, (firstNotePos + (tempValueRow5 * oneMidiLength))), gnoteq);
            }
        }
        foreach (string s in textContentSplit6)
        {
            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow6);
                //Debug.Log(tempValueRow6);
                Instantiate(gnote, new Vector3(5.1f, 0.35f, (firstNotePos + (tempValueRow6 * oneMidiLength))), gnoteq);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
     
            //if (Input.GetKeyDown(key))
            //{
            //Debug.Log(Time.deltaTime);
            //Instantiate(gnote, gnotevector,gnoteq);
            //}
        


    }

    void noteInstantiateForGenerator()
    {
        //Instantiate(gnote, gnotevector, gnoteq);
    }



}
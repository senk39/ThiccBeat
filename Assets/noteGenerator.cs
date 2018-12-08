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
    const float link = 15.8808933002f;





    // Use this for initialization
    void Start()
    {
        distBetweenNotes = (60 / bpm);

       // InvokeRepeating("noteInstantiateForGenerator", 3f, distBetweenNotes);

        textContent1 = row1.text;

        string[] textContentSplit1 = textContent1.Split(new char[] { ' ', ',', '.', '\n', '\t' });

        foreach (string s in textContentSplit1)
        {

            if (s.Trim() != "")
            {
                int.TryParse(s, out tempValueRow1);
                Debug.Log(tempValueRow1);
                Instantiate(gnote, new Vector3(-5.1f, 0.35f, (105.15f+(tempValueRow1/link))), gnoteq);


                //tempValueRow1++;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastNote : MonoBehaviour
{





    public GameObject n2;
    public GameObject n3;
    public GameObject n4;
    public GameObject n5;
    public GameObject n6;
    public GameObject n7;

    public GameObject nc2;
    public GameObject nc3;
    public GameObject nc4;
    public GameObject nc5;
    public GameObject nc6;
    public GameObject nc7;

    public Queue<GameObject> notesQueue2 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue3 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue4 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue5 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue6 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    public GameObject keyElement2;
    public GameObject keyElement3;
    public GameObject keyElement4;
    public GameObject keyElement5;
    public GameObject keyElement6;
    public GameObject keyElement7;

    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
    private const float row7X = 2.8f;

    // const float ActiveStart = -8f;
    // const float ActiveEnd = -30f;

    public bool isSongFinished = false;




    //void Update()
    //{
    //    checkEndOfSong();
    //}



    //void checkEndOfSong()
    //{
    //    if (notesQueue1.Count == 0 && 
    //        notesQueue2.Count == 0 && 
    //        notesQueue3.Count == 0 &&
    //        notesQueue4.Count == 0 &&
    //        notesQueue5.Count == 0 &&
    //        notesQueue6.Count == 0 &&
    //        notesQueue7.Count == 0)
    //    {           
    //        isSongFinished = true;
    //    }
    //}
}


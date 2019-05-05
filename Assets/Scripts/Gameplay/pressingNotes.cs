using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row1X = -5.1f;
    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
    private const float row7X = 2.8f;

    const float ActiveStart = -8f;
    const float ActiveEnd = -30f;

    GameObject note1;
    GameObject note2;
    GameObject note3;
    GameObject note4;
    GameObject note5;
    GameObject note6;
    GameObject note7;


    void Awake()
    {


    }

    void Start()
    {

    }
    void Update()
    {

    }
}
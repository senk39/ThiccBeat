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
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            note1 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek();
        }
        else
        {
            note1 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            note2 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek();
        }
        else
        {
            note2 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            note3 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek();
        }
        else
        {
            note3 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            note4 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek();
        }
        else
        {
            note4 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            note5 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek();
        }
        else
        {
            note5 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            note6 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek();
        }
        else
        {
            note6 = null;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            note7 = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek();
        }
        else
        {
            note7 = null;
        }

        setNoteContainer();
        setNote();

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            if (Input.GetKeyDown(key) && note1.GetComponent<note>().isActive)
            {
                if (key == KeyCode.A && transform.position.x == row1X)
                {
                    Debug.Log("A");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Dequeue();
                    Destroy(note1);
                }
            }
        }
        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            if (Input.GetKeyDown(key) && note2.GetComponent<note>().isActive)
            {
                if (key == KeyCode.W && transform.position.x == row2X)
                {
                    Debug.Log("W");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Dequeue();
                    Destroy(note2);
                }
            }
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            if (Input.GetKeyDown(key) && note3.GetComponent<note>().isActive)
            {
                if (key == KeyCode.D && transform.position.x == row3X)
                {
                    Debug.Log("D");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Dequeue();
                    Destroy(note3);
                }
            }
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            if (Input.GetKeyDown(key) && note4.GetComponent<note>().isActive)
            {
                if (key == KeyCode.J && transform.position.x == row4X)
                {
                    Debug.Log("j");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Dequeue();
                    Destroy(note4);
                }
            }
        }


        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            if (Input.GetKeyDown(key) && note5.GetComponent<note>().isActive)
            {
                if (key == KeyCode.I && transform.position.x == row5X)
                {
                    Debug.Log("i");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Dequeue();
                    Destroy(note5);
                }
            }
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            if (Input.GetKeyDown(key) && note6.GetComponent<note>().isActive)
            {
                if (key == KeyCode.L && transform.position.x == row6X)
                {
                    Debug.Log("L");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Dequeue();
                    Destroy(note6);
                }
            }
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            if (Input.GetKeyDown(key) && note7.GetComponent<note>().isActive)
            {
                if (key == KeyCode.G && transform.position.x == row7X)
                {
                    Debug.Log("G");
                    doWhenKeyPressedAndNoteIsInPressablePlace();

                    GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Dequeue();
                    Destroy(note7);
                }
            }
        }
    }
    

    void incrementCombo()
    {
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
        playerComboContainer.GetComponent<playerCombo>().currentCombo++;
    }

    void dequeueAndDestroy()
    {
        
        if (gameObject.GetComponent<noteClass>().keyNumber == 1 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 2 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 3 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 4 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 5 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 6 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Dequeue();
            //Destroy(gameObject); ma być destroy nutka;
        }
        else if (gameObject.GetComponent<noteClass>().keyNumber == 7 && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Dequeue();
            //Destroy(gameObject); ma być destroy nutka
        }
        else
        {
            //Debug.LogError("Error: nutka nie może zostać usunięta, gdyż jej atrybut keyNumber nie mieści się w przedziale 1-7");
        }
        
    }

    void setNote()
    {
        if(transform.position.x == row1X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek().transform.GetChild(0).gameObject;
        }
        else if (transform.position.x == row2X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek().transform.GetChild(0).gameObject;

        }
        else if (transform.position.x == row3X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek().transform.GetChild(0).gameObject;

        }
        else if (transform.position.x == row4X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek().transform.GetChild(0).gameObject;

        }
        else if (transform.position.x == row5X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek().transform.GetChild(0).gameObject;

        }
        else if (transform.position.x == row6X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek().transform.GetChild(0).gameObject;

        }
        else if (transform.position.x == row7X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            noteItself = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek().transform.GetChild(0).gameObject;

        }
        else
        {
            noteItself = null;
        }
    }

    void setNoteContainer()
    {
        if (transform.position.x == row1X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue1.Peek();
        }
        else if (transform.position.x == row2X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue2.Peek();

        }
        else if (transform.position.x == row3X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue3.Peek();

        }
        else if (transform.position.x == row4X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue4.Peek();

        }
        else if (transform.position.x == row5X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue5.Peek();

        }
        else if (transform.position.x == row6X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue6.Peek();

        }
        else if (transform.position.x == row7X && GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Count > 0)
        {
            noteContainer = GameObject.Find("Last Note").GetComponent<lastNote>().notesQueue7.Peek();

        }
        else
        {
            noteContainer = null;
        }
    }

    void doWhenKeyPressedAndNoteIsInPressablePlace()
    {
        incrementCombo();

        //RemoveFromQueue();

        GameObject.Find("buttons").GetComponent<AudioSource>().Play();

    }

}


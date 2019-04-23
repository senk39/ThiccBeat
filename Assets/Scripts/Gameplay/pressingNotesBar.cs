using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotesBar : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row7X = 2.8f;


    void Update()
    {
        if (noteItself != null)
        {
            if (Input.GetKeyDown(key) && isActive && noteContainer.GetComponent<note>().isTheLowest && noteContainer.GetComponent<note>().isActive)
            {
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerScoreContainer.GetComponent<playerScore>().playerCorrectNotes += 1;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;

                RemoveFromQueue();

                Destroy(noteContainer.gameObject);

                GameObject.Find("buttons").GetComponent<AudioSource>().Play();
            }
            checkTheLowest();
        }

        updatingNoteContainerandNoteItself();
        setNoteContainerAsTheLowestNoteContainer();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "noteContainer" && col.transform.position.x == 2.8f)
        {

            noteContainer = col.gameObject;
            Debug.Log("dupło");

            isActive = true;



            addToQueue();

            //setNoteContainerAsTheLowestNoteContainer();


        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "noteContainer" && col.transform.position.x == row7X)
        {
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;

            if (col != null)
            {
                RemoveFromQueue();
                isActive = false;

                Destroy(col.gameObject);
            }

            
        }
    }

    void addToQueue()
    {

        if (noteContainer.GetComponent<noteClass>().keyNumber == 7)
        {
            notesQueue7.Enqueue(noteContainer);
            //noteContainer.GetComponent<note>().isTheLowest = true;
        }
        else
        {
            Debug.Log("cholibka, żaden z przypadków w addQueue z barem nie został spełniony!");
        }

    }

    void RemoveFromQueue()
    {
        if (noteContainer.GetComponent<noteClass>().keyNumber == 7)
        {
            if (notesQueue7.Count > 0)
            {
                notesQueue7.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue7.Dequeue();
            }
            else
            {
                //isActive = false;
            }
        }
        else
        {
            Debug.Log("cholibka, żaden z przypadków w removeFromQueue z barem nie został spełniony!");
        }
        // }
    }



    void checkTheLowest()
    {
        if (notesQueue7.Count > 0)
        {
            notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row7X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;

        }
    }

    void updatingNoteContainerandNoteItself()
    {
       if (transform.position.x == row7X && notesQueue7.Count > 0)
        {
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
            noteItself = notesQueue7.Peek().gameObject.transform.GetChild(0).gameObject;
        }
        else
        {
            noteItself = null;
        }

    }

    void setNoteContainerAsTheLowestNoteContainer()
    {
       if (transform.position.x == row7X && notesQueue7.Count > 0)
        {
            noteContainer = notesQueue7.Peek().gameObject;
        }
        else
        {
            noteContainer = null;
        }
    }
}

//NO SPRAWA MA SIĘ TAK ŻE MUSIMY NAJPIERW USTAWIĆ NOTECONTAINER I NOTEITSELF ZANIM BĘDĄ CHCIAŁY ZOSTAĆ DODANE W FUNKCJI ADDTOQUEUE LOLZ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour
{
    public KeyCode key;

    public bool isActive = false;
    public bool isHolding = false;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    public GameObject noteItself;
    public GameObject noteContainer;

    public Queue<GameObject> notesQueue1 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue2 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue3 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue4 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue5 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue6 = new Queue<GameObject>();
    public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row1X = -5.1f;
    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
    private const float row7X = 2.67f;


    void Update()
    {
        if (noteItself != null)
        {
            if (Input.GetKeyDown(key) && isActive && noteContainer.GetComponent<note>().isTheLowest && noteContainer.GetComponent<note>().isActive)
            {
            playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
            playerComboContainer.GetComponent<playerCombo>().currentCombo++;

            RemoveFromQueue();

            Destroy(noteContainer.gameObject);

            GameObject.Find("buttons").GetComponent<AudioSource>().Play();
            }
        }
        checkTheLowest();

        updatingNoteContainerandNoteItself();

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "noteContainer")
        {
            isActive = true;

           
            
            addToQueue();
            
            
            

        }

        else if (col.tag == "noteContainerBar")
        {
            isActive = true;
            //noteItself = notesList.First.Value.gameObject;
            //noteContainer = noteItself.transform.parent.gameObject;
            //addToQueue();   //uaktywnij gdy będziesz się zabierał za bara. 2 powyższe linijki także zrób na wzór normalnych nutek
        }
        /*
        else if (col.tag == "Note")
        {
            Debug.Log("onTriggerEnter: note");
            notesList.AddLast(col.gameObject);
            isActive = true;
            noteItself = notesList.First.Value.gameObject;
            noteContainer = noteItself.transform.parent.gameObject;
            addToQueue();
        }
        */
        else
        {
            Debug.Log("onTriggerEnter: else");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "noteContainer")
        {
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;

            if(col != null)
            {
                RemoveFromQueue();
                noteItself = null;
                noteContainer = null;
            }


            isActive = false;

            Destroy(col.gameObject);

            

        }
        /*
        else if (col.tag == "Note")
        {
            Debug.Log("onTriggerExit: note");
            notesList.Remove(col.gameObject); 
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject.transform.parent.gameObject);

            if (notesList.Count > 0)
            {
                noteItself = notesList.First.Value.gameObject;
            }

          
            noteItself = null;
            noteContainer = null;
            isActive = false;

          
        }*/
    }
    void addToQueue()
    {
        
            if (noteContainer.GetComponent<noteClass>().keyNumber == 1)
            {
                notesQueue1.Enqueue(noteContainer);
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 2)
            {
                notesQueue2.Enqueue(noteContainer);
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 3)
            {
                notesQueue3.Enqueue(noteContainer);
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 4)
            {
                notesQueue4.Enqueue(noteContainer);
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 5)
            {
                notesQueue5.Enqueue(noteContainer);
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 6)
            {
                notesQueue6.Enqueue(noteContainer);
               //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 7)
            {
                //noteContainer.GetComponent<note>().isTheLowest = true;
            }
            else
            {
            Debug.Log("dupa jasna, żaden z przypadków w addQueue nie został spełniony!");
            }
        
    }

    void RemoveFromQueue()
    {
        //if (noteContainer != null)
        //{
        if (noteContainer.GetComponent<noteClass>().keyNumber == 1)
        {
            if (notesQueue1.Count > 0)
            {
                notesQueue1.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue1.Dequeue();
            }
            else
            {
                isActive = false;
               
            }

        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 2)
        {
            if (notesQueue2.Count > 0)
            {
                notesQueue2.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue2.Dequeue();
            }
            else
            {
                isActive = false;
                
            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 3)
        {
            if (notesQueue3.Count > 0)
            {
                notesQueue3.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue3.Dequeue();
            }
            else
            {
                isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 4)
        {
            if (notesQueue4.Count > 0)
            {
                notesQueue4.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue4.Dequeue();
            }
            else
            {
                isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 5)
        {
            if (notesQueue5.Count > 0)
            {
                notesQueue5.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue5.Dequeue();
            }
            else
            {
                isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 6)
        {
            if (notesQueue6.Count > 0)
            {
                notesQueue6.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue6.Dequeue();
            }
            else
            {
                isActive = false;
            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 7)
        {
            //notesQueue7.Dequeue();
            //noteContainer.GetComponent<note>().isTheLowest = true;
        }
        else
        {
            Debug.Log("dupa jasna, żaden z przypadków w removeFromQueue nie został spełniony!");
        }
        // }
    }



    void checkTheLowest()
    {
        if(notesQueue1.Count > 0)
        {
            notesQueue1.Peek().GetComponent<note>().isTheLowest = true;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
            
        }
        if (notesQueue2.Count > 0)
        {
            notesQueue2.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
        if (notesQueue3.Count > 0)
        {
            notesQueue3.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
        if (notesQueue4.Count > 0)
        {
            notesQueue4.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
        if (notesQueue5.Count > 0)
        {
            notesQueue5.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
        if (notesQueue6.Count > 0)
        {
            notesQueue6.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
        if (notesQueue7.Count > 0)
        {
            notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
        }
        else
        {
            isActive = false;
            noteItself = null;
            noteContainer = null;
        }
    }

    void updatingNoteContainerandNoteItself()
    {
        if(transform.position.x == row1X && notesQueue1.Count > 1)
        {
            noteContainer = notesQueue1.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;

        }
        if (transform.position.x == row2X && notesQueue2.Count > 1)
        {
            noteContainer = notesQueue2.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        if (transform.position.x == row3X && notesQueue3.Count > 1)
        {
            noteContainer = notesQueue3.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        if (transform.position.x == row4X && notesQueue4.Count > 1)
        {
            noteContainer = notesQueue4.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        if (transform.position.x == row5X && notesQueue5.Count > 1)
        {
            noteContainer = notesQueue5.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        if (transform.position.x == row6X && notesQueue6.Count > 1)
        {
            noteContainer = notesQueue6.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        if (transform.position.x == row7X && notesQueue7.Count > 1)
        {
            noteContainer = notesQueue7.Peek().gameObject;
            noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        
    }
}

//NO SPRAWA MA SIĘ TAK ŻE MUSIMY NAJPIERW USTAWIĆ NOTECONTAINER I NOTEITSELF ZANIM BĘDĄ CHCIAŁY ZOSTAĆ DODANE W FUNKCJI ADDTOQUEUE LOLZ
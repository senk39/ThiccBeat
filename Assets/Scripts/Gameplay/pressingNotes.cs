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
    //public Queue<GameObject> notesQueue7 = new Queue<GameObject>();

    private const float row1X = -5.1f;
    private const float row2X = -3.1f;
    private const float row3X = -1.1f;
    private const float row4X = 1.1f;
    private const float row5X = 3.1f;
    private const float row6X = 5.1f;
   // private const float row7X = 2.67f;


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
            checkTheLowest();
        }
        updatingNoteContainerandNoteItself();

        setNoteContainerAsTheLowestNoteContainer();


    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "noteContainer" && col.transform.position.x != 2.67f)
        {

            noteContainer = col.gameObject;

            isActive = true;

           
            
            addToQueue();

            //setNoteContainerAsTheLowestNoteContainer();


        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "noteContainer" && col.transform.position.x != 2.67f)
        {
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;

            if(col != null)
            {
                RemoveFromQueue();
                isActive = false;

                //Destroy(col.gameObject);
            }


            

            

        }
    }
    void addToQueue()
    {

        

            if (noteContainer.GetComponent<noteClass>().keyNumber == 1)
            {
                notesQueue1.Enqueue(noteContainer);
            Debug.Log("added to notesQueue1");
            
                //noteItself = noteContainer.transform.GetChild(0).gameObject;
            }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 2)
            {
                notesQueue2.Enqueue(noteContainer);
            Debug.Log("added to notesQueue2");
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 3)
            {
                notesQueue3.Enqueue(noteContainer);
            Debug.Log("added to notesQueue3");
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 4)
            {
                notesQueue4.Enqueue(noteContainer);
            Debug.Log("added to notesQueue4");
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 5)
            {
                notesQueue5.Enqueue(noteContainer);
            Debug.Log("added to notesQueue5");
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
            else if (noteContainer.GetComponent<noteClass>().keyNumber == 6)
            {
                notesQueue6.Enqueue(noteContainer);
            Debug.Log("added to notesQueue6");
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        //    else if (noteContainer.GetComponent<noteClass>().keyNumber == 7)
        //    {
        //        notesQueue7.Enqueue(noteContainer);
        //    //noteContainer.GetComponent<note>().isTheLowest = true;
        //}
        else
            {
            Debug.Log("cholibka, żaden z przypadków w addQueue nie został spełniony!");
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
                Debug.Log("deleted from notesQueue1");
            }
            else
            {
                //isActive = false;
               
            }

        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 2)
        {
            if (notesQueue2.Count > 0)
            {
                notesQueue2.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue2.Dequeue();
                Debug.Log("deleted from notesQueue2");

            }
            else
            {
                //isActive = false;
                
            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 3)
        {
            if (notesQueue3.Count > 0)
            {
                notesQueue3.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue3.Dequeue();
                Debug.Log("deleted from notesQueue3");

            }
            else
            {
                //isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 4)
        {
            if (notesQueue4.Count > 0)
            {
                notesQueue4.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue4.Dequeue();
                Debug.Log("deleted from notesQueue4");

            }
            else
            {
                //isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 5)
        {
            if (notesQueue5.Count > 0)
            {
                notesQueue5.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue5.Dequeue();
                Debug.Log("deleted from notesQueue5");

            }
            else
            {
               // isActive = false;

            }
        }
        else if (noteContainer.GetComponent<noteClass>().keyNumber == 6)
        {
            if (notesQueue6.Count > 0)
            {
                notesQueue6.Peek().GetComponent<note>().isTheLowest = false;
                notesQueue6.Dequeue();
                Debug.Log("deleted from notesQueue6");

            }
            else
            {
                //isActive = false;
            }
        }
        else
        {
            Debug.Log("dupa jasna, żaden z przypadków w removeFromQueue nie został spełniony!");
        }
        
    }



    void checkTheLowest()
    {
        if(notesQueue1.Count > 0)
        {
            notesQueue1.Peek().GetComponent<note>().isTheLowest = true;
            if(gameObject.transform.position.x == row1X)
            {
                isActive = true;
            }
            
        }
        else
        {
            //isActive = false;
            
            
        }
        if (notesQueue2.Count > 0)
        {
            notesQueue2.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row2X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;
            
        }
        if (notesQueue3.Count > 0)
        {
            notesQueue3.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row3X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;
            
        }
        if (notesQueue4.Count > 0)
        {
            notesQueue4.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row4X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;
            
        }
        if (notesQueue5.Count > 0)
        {
            notesQueue5.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row5X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;
            
        }
        if (notesQueue6.Count > 0)
        {
            notesQueue6.Peek().GetComponent<note>().isTheLowest = true;
            if (gameObject.transform.position.x == row6X)
            {
                isActive = true;
            }
        }
        else
        {
            //isActive = false;
           
        }
        //if (notesQueue7.Count > 0)
        //{
        //    notesQueue7.Peek().GetComponent<note>().isTheLowest = true;
        //    if (gameObject.transform.position.x == row7X)
        //    {
        //        isActive = true;
        //    }
        //}
        //else
        //{
        //    //isActive = false;
            
        //}
    }

    void updatingNoteContainerandNoteItself()
    {
        if(transform.position.x == row1X && notesQueue1.Count > 0)
        {
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
            try
            {
                noteItself = notesQueue1.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek1 fail");
                throw;
            }

        }
        else if (transform.position.x == row2X && notesQueue2.Count > 0)
        {
            try
            {
                noteItself = notesQueue2.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek2 fail");
                throw;
            }
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
            
        }
        else if (transform.position.x == row3X && notesQueue3.Count > 0)
        {
            try
            {
                noteItself = notesQueue3.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek3 fail");
                throw;
            }
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        else if(transform.position.x == row4X && notesQueue4.Count > 0)
        {
            try
            {
                noteItself = notesQueue4.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek4 fail");
                throw;
            }
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        else if(transform.position.x == row5X && notesQueue5.Count > 0)
        {
            try
            {
                noteItself = notesQueue5.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek5 fail");
                throw;
            }
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        else if(transform.position.x == row6X && notesQueue6.Count > 0)
        {
            try
            {
                noteItself = notesQueue6.Peek().gameObject.transform.GetChild(0).gameObject;
            }
            catch (System.Exception)
            {
                Debug.Log("Peek6 fail");
                throw;
            }
            //noteItself = noteContainer.transform.GetChild(0).gameObject;
        }
        //else if(transform.position.x == row7X && notesQueue7.Count > 0)
        //{
        //    //noteItself = noteContainer.transform.GetChild(0).gameObject;
        //    noteItself = notesQueue7.Peek().gameObject.transform.GetChild(0).gameObject;
        //}
        else
        {
            noteItself = null;
        }
        
    }

    void setNoteContainerAsTheLowestNoteContainer()
    {
        if (notesQueue1.Count > 0)
        {
            if (transform.position.x == row1X)
            {
                noteContainer = notesQueue1.Peek().gameObject;
            }
            else if (transform.position.x == row2X)
            {
                noteContainer = notesQueue2.Peek().gameObject;
            }
            else if (transform.position.x == row3X)
            {
                noteContainer = notesQueue3.Peek().gameObject;
            }
            else if (transform.position.x == row4X)
            {
                noteContainer = notesQueue4.Peek().gameObject;
            }
            else if (transform.position.x == row5X)
            {
                noteContainer = notesQueue5.Peek().gameObject;
            }
            else if (transform.position.x == row6X)
            {
                noteContainer = notesQueue6.Peek().gameObject;
            }
        }
        //else if (transform.position.x == row7X && notesQueue7.Count > 0)
        //{
        //    noteContainer = notesQueue7.Peek().gameObject;
        //}
        else
        {
            noteContainer = null;
        }
        
        
    }

    void destroyNote()
    {
        
    }

    void createQueues()
    {
        GameObject[] allNotes = GameObject.FindGameObjectsWithTag("noteContainer");
        foreach (var nutkowyKontener in allNotes)
        {
            if(nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 1)
            {
                 notesQueue1.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 2)
            {
                notesQueue2.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 3)
            {
                notesQueue3.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 4)
            {
                notesQueue4.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 5)
            {
                notesQueue5.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 6)
            {
                notesQueue6.Enqueue(nutkowyKontener);
            }
            if (nutkowyKontener.gameObject.GetComponent<noteClass>().keyNumber == 7)
            {
                //notesQueue7.Enqueue(nutkowyKontener);
            }
        }

        //(noteContainer.GetComponent<noteClass>().keyNumber == 5)
    }
}

//NO SPRAWA MA SIĘ TAK ŻE MUSIMY NAJPIERW USTAWIĆ NOTECONTAINER I NOTEITSELF ZANIM BĘDĄ CHCIAŁY ZOSTAĆ DODANE W FUNKCJI ADDTOQUEUE LOLZ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotesBar : MonoBehaviour
{

    public KeyCode key;

    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    public bool isActive = false;

    public GameObject go;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (go != null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest)
            {
                if (go.tag == "h_notebar_start")
                {
                    go.transform.parent.Find("pivot").Find("notebarMid").GetComponent<holdContainerForNotebarMid>().noteStartIsClicked = true;
                }

                //Destroy(notesList.First.Value.gameObject);
                notesList.RemoveFirst();
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;

                GameObject.Find("BUTTONS").GetComponent<AudioSource>().Play();
                Destroy(go);
                isActive = false;
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            notesList.AddLast(col.gameObject);
        }
        else if (col.tag == "h_notebar_start")
        {
            notesList.AddLast(col.gameObject);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            isActive = true;

            go = notesList.First.Value.gameObject;
        }

        else if (col.tag == "h_notebar_start")
        {
            isActive = true;
            go = notesList.First.Value.gameObject;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteBar")
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }
        if (col.tag == "h_notebar_start" || col.tag == "h_notebar_end")
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }
        if (col.tag == "h_notebar_mid")
        {
            isActive = false;
            notesList.Remove(col.gameObject);
            playerComboContainer.GetComponent<playerCombo>().currentCombo = 0;
            Destroy(col.gameObject);
        }
    }
}

/*

CO POWINNO SIĘ TU ZNALEŹĆ:

1. NUTKI SPADAJĄ W DÓŁ (TO JEST JUŻ GOTOWE POPRZEZ INNY SKRYPT) 
2. NUTKA JEST AKTYWNA GDY MA ODPOWIEDNIĄ POZYCJĘ
3. NUTKA SIĘ KASUJE GDY NASTĄPI KLIKNIĘCIE ODPOWIEDNIEGO KLAWISZA A ONA JEST AKTYWNA
    - wtedy następna nutka powinna zostać tą aktywną
    - licznik combo się inkrementuje o 1
    - ilość punktów zwiększa się
    - rozróżnij to, czy gracz wcisnął nutkę ok czy perfekcyjnie
4. NUTKA SIĘ KASUJE GDY GRACZ NIE NACIŚNIE KLAWISZA
    - licznik combo się resetuje

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressingNotes : MonoBehaviour {

    public KeyCode key;

    public LinkedList<GameObject> notesList = new LinkedList<GameObject>();

    public bool isActive = false;

    public GameObject go;

    public GameObject playerScoreContainer;
    public GameObject playerComboContainer;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if(go!=null)
        {
            if (Input.GetKeyDown(key) && isActive && go.GetComponent<note>().isTheLowest)
            {
                //Destroy(notesList.First.Value.gameObject);
                notesList.RemoveFirst();
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                playerComboContainer.GetComponent<playerCombo>().currentCombo++;

                Destroy(go);
                isActive = false;
            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Note")
        {
            notesList.AddLast(col.gameObject);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Note")
        {
            isActive = true;

            go = notesList.First.Value.gameObject;

           
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Note")
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
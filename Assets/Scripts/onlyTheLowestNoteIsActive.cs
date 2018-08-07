using UnityEngine;
using System.Collections;
using System.Collections.Generic;    // Don't forget to add this if using a List.

public class onlyTheLowestNoteIsActive : MonoBehaviour
{

    // Declare and initialize a new List of GameObjects called currentCollisions.
    List<GameObject> currentCollisions = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collision col)
    {

        if (col.gameObject.tag == "Note")
        {
            addToReadyNotesList();


            active = true;
            note = col.gameObject;
            missNote();

        }

        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }

    void OnCollisionExit(Collision col)
    {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);

        // Print the entire list to the console.
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }
}
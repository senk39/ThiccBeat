﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseControl : MonoBehaviour
{
    public GameObject[] notes;

    public void clickResumeBtn()
    {
        SceneManager.LoadScene(2);
    }


    public void clickRestartBtn()
    {
        /*
        if (notes == null)
            notes = GameObject.FindGameObjectsWithTag("Note");

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Note");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Debug.Log("delete");
            Destroy(gameObjects[i]);
        }

        // Scene scene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(scene.buildIndex);
        */
        SceneManager.LoadScene(5);


        pause.isGamePaused = false;

    }

    public void clickQuitBtn()
    {
        Application.Quit();
    }
}

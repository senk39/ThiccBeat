using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseController : MonoBehaviour {



    public void clickResumeBtn()
    {
        SceneManager.LoadScene(2);
    }


    public void clickRestartBtn()
    {
       GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Note");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Debug.Log("delete");
            Destroy(gameObjects[i]);
        }


        Scene scene = SceneManager.GetActiveScene();        
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void clickQuitBtn()
    {
        Application.Quit();
    }
}

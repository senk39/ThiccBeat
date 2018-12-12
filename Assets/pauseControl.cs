using System.Collections;
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
        if (notes == null)
            notes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject note in notes)
        {
            Debug.Log("xD");
            //TO PÓKI CO NIE DZIAŁA I TU STANĄŁEM
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void clickQuitBtn()
    {
        Application.Quit();
    }
}

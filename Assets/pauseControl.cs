using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseControl : MonoBehaviour
{
    public GameObject[] notes;
    static public bool isResumeClicked = false;

    public void clickResumeBtn()
    {
        isResumeClicked = true;
    }


    public void clickRestartBtn()
    {
        SceneManager.LoadScene(5);
        pause.isGamePaused = false;
    }

    public void clickQuitBtn()
    {
        SceneManager.LoadScene(2);
    }
}

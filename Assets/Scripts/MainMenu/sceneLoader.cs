using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public void clickPlayBtn()
    {
        SceneManager.LoadScene(2);
    }

    public void clickOptionsBtn()
    {
        SceneManager.LoadScene(3);
    }

    public void clickQuitBtn()
    {
        Application.Quit();
    }

}
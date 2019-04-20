using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoaderForMainMenu : MonoBehaviour
{
    short index;

    AudioSource acChangeOption;
    AudioSource acBack;
    AudioSource acEnter;

    public GameObject acConChangeOption;
    public GameObject acConBack;
    public GameObject acConEnter;

    void Awake()
    {
        index = 1;

        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Q)) && index > 1)
        {
            acChangeOption.Play();
            index--;  
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.O)) && index < 4 )
        {
            acChangeOption.Play();
            index++;
        }
    }

    public void clickPlayBtn()
    {
        acEnter.Play();
        Invoke("loadSongList", 0.8f);
    }

    public void clickOptionsBtn()
    {
        SceneManager.LoadScene(3);
    }

    public void clickAboutBtn()
    {
        SceneManager.LoadScene(7);
    }

    public void clickQuitBtn()
    {
        acBack.Play();
        Invoke("loadQuit", 0.3f);

    }

    void loadSongList()
    {
        SceneManager.LoadScene(2);

    }

    void loadQuit()
    {
        SceneManager.LoadScene(8);
    }
}


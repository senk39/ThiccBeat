using UnityEngine;
using UnityEngine.SceneManagement;

public class quitController : MonoBehaviour {

    bool isYesSelected;

    AudioSource acChangeOption;
    AudioSource acChangeDiff;
    AudioSource acBack;
    AudioSource acEnter;

    public GameObject acConChangeOption;
    public GameObject acConChangeDiff;
    public GameObject acConBack;
    public GameObject acConEnter;

    void Awake()
    {
        isYesSelected = false;

        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.Q) ||
            (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.O)))
        {
            if (isYesSelected == false)
            {
                isYesSelected = true;
                acChangeOption.Play();
            }

            else
            {
                isYesSelected = false;
                acChangeOption.Play();
            }
        }
    }
    public void quitTheGame()
    {
        acBack.Play();
        Invoke("quitTheGame2", 0.7f);
    }

    public void quitTheGame2()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void loadMainMenuAgain()
    {
        acBack.Play();
        Invoke("loadMainMenuAgain2", 0.7f);
    }

    public void loadMainMenuAgain2()
    {
        SceneManager.LoadScene(1);
    }
}

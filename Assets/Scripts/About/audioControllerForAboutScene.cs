using UnityEngine;
using UnityEngine.SceneManagement;

public class audioControllerForAboutScene : MonoBehaviour
{
    AudioSource acChangeOption;
    AudioSource acChangeDiff;
    AudioSource acBack;
    AudioSource acEnter;

    public GameObject acConChangeOption;
    public GameObject acConChangeDiff;
    public GameObject acConBack;
    public GameObject acConEnter;

    public Animator animator1;

    void Awake()
    {
        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();

        animator1 = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.G) ||
            (Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.O)))
        {
            quitAbout();
        }
    }

    public void quitAbout()
    {
        acBack.Play();
        //animator1.Play("unhiddingButtonsInOptions");
        Invoke("quitAbout2", 0.4f);
    }

    public void quitAbout2()
    {
        SceneManager.LoadScene(1);
    }
}


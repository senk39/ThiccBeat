using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exitFromAboutMenu : MonoBehaviour
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
    public GameObject buttons;
    public float posXOfButtons;

    void Start()
    {
        animator1 = GetComponent<Animator>();
        buttons = GameObject.Find("buttons");
        posXOfButtons = buttons.transform.position.x;

        acChangeOption = acConChangeOption.GetComponent<AudioSource>();
        acChangeDiff = acConChangeDiff.GetComponent<AudioSource>();
        acBack = acConBack.GetComponent<AudioSource>();
        acEnter = acConEnter.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.O))
        {
            try
            {
                acBack.Play();
                animator1.Play("unhiddingButtonsInOptions");
                Invoke("loadMainMenuAgain", 0.7f);
            }
            catch
            {
                Debug.Log("hiding about scene failed");
            }
        }
    }

    private void loadMainMenuAgain()
    {
        SceneManager.LoadScene(1);
    }
}


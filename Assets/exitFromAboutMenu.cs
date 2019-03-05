using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exitFromAboutMenu : MonoBehaviour
{

    public Animator animator1;
    public GameObject buttons;
    public float posXOfButtons;
    //public bool isMenuReturnedCompletely = false;

    // Use this for initialization
    void Start()
    {
        animator1 = GetComponent<Animator>();
        buttons = GameObject.Find("buttons");
        posXOfButtons = buttons.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(buttons.transform.position.x);

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Find("Button Controller").GetComponent<audioControllerForAboutScene>().acConBack.GetComponent<AudioSource>().Play();
            animator1.Play("unhiddingButtonsInOptions");
            //isMenuReturnedCompletely = true;
            Invoke("loadMainMenuAgain", 0.7f);
        }

        /*
        
        if (posXOfButtons > 793 && isMenuReturnedCompletely == true)
        {
            SceneManager.LoadScene(1);
        }

        */


    }

    private void loadMainMenuAgain()
    {
        SceneManager.LoadScene(1);
    }
}


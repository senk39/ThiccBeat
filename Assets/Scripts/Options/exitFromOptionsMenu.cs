using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class exitFromOptionsMenu : MonoBehaviour
{
    public Animator animator1;
    public GameObject buttons;
    public float posXOfButtons;

    void Start()
    {
        animator1 = GetComponent<Animator>();
        buttons = GameObject.Find("buttons");
        posXOfButtons = buttons.transform.position.x;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Button Controller").GetComponent<buttonSelector>().acConBack.GetComponent<AudioSource>().Play();
            animator1.Play("unhiddingButtonsInOptions");
            Invoke("loadMainMenuAgain", 0.7f);
        }
    }

    private void loadMainMenuAgain()
    {
        SceneManager.LoadScene(1);
    }
}


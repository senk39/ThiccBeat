using System.Collections;
using System.Collections.Generic;
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

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnyKeyCatcher : MonoBehaviour {


    AudioSource pressingButtonSound;

    public GameObject thiccBeatLogo;
    public GameObject anyKeyText;
    public Animator anim;


    void Start ()
    {
        pressingButtonSound = GetComponent<AudioSource>();
        anim = GameObject.Find("ThiccBeatLogo").GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKey)
        {
            anim.Play("ThiccBeatLogoFadeOut");
            pressingButtonSound.Play();
            anyKeyText.GetComponent<fadingText>().newTransparency--;


            Invoke("loadMainMenu", 1.5f);
        }
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}

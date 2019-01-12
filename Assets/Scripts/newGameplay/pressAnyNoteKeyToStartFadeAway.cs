using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressAnyNoteKeyToStartFadeAway : MonoBehaviour {

    public Animator anim;

    void Start () {
        anim = GetComponent<Animator>();

        Invoke("playFadeInAnim", 1f);


    }

    void Update () {

        if (Input.anyKeyDown)
        {
            anim.Play("FadeOutText");
            Invoke("destroyTextObject", 2f);
           

        }

    }

    void destroyTextObject()
    {
        Destroy(GameObject.Find("PRESS ANY NOTE KEY TO START"));
    }
    void playFadeInAnim()
    {
        anim.Play("FadeInText");
    }
}

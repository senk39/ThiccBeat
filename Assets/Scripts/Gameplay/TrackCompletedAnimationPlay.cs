using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackCompletedAnimationPlay : MonoBehaviour {
    public Animator anim;


    void Awake () {
        anim = GetComponent<Animator>();
        anim.Play("Idle");
    }
	
	void Update () {

        if (GameObject.Find("Last Note").GetComponent<lastNote>().isSongFinished == true)
        {
            anim.Play("TrackCompleted");
            Invoke("goToHighScoreScreen", 5f);
        }
    }

    void goToHighScoreScreen()
    {
        SceneManager.LoadScene(6);
    }
}

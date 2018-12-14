using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSongSceneWriter : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.buildIndex);

        lastSongSceneCatcher.lastPlayedSongSceneIndex = scene.buildIndex;


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

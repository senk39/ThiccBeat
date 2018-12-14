using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSongSceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(lastSongSceneCatcher.lastPlayedSongSceneIndex);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

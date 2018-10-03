using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongIndex : MonoBehaviour {

    SongList listWithSongs;

	// Use this for initialization
	void Start () {
        listWithSongs = GameObject.Find("Song List Itself").GetComponent<SongList>();


    }

    // Update is called once per frame
    void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleText : MonoBehaviour {


    public TMPro.TextMeshProUGUI titleTextBox;

	// Use this for initialization
	void Start () {
       // songListImporter = GetComponent<SongList>();
        titleTextBox = GetComponent<TMPro.TextMeshProUGUI>();
        titleTextBox.text = "title";

        //titleTextBox.text = SongList.Song;

    }

    // Update is called once per frame
    void Update () {
		
	}
}

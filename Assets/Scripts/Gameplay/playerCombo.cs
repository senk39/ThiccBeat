﻿using UnityEngine;
using UnityEngine.UI;

public class playerCombo : MonoBehaviour {

    public int maxCombo;
    public int currentCombo;
    public Text currentComboAsText;

    public void Awake()
    {
        maxCombo = 0;
        currentCombo = 0;
    }

    public void Update () {
        currentComboAsText.text = currentCombo.ToString();


        if (currentCombo>maxCombo)
        {
            maxCombo = currentCombo;
        }

        if (GameObject.Find("Last Note").GetComponent<lastNote>().isSongFinished == true)
        {
            PlayerPrefs.SetInt("lastGameMaxCombo", maxCombo);
        }
    }
}

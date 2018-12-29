using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombo : MonoBehaviour {

    public int maxCombo;
    public int currentCombo;
    public Text currentComboAsText;

    

    public void Awake()
    {
        maxCombo = 0;
        currentCombo = 0;
        PlayerPrefs.SetInt("currentScore", maxCombo);
    }



    // Update is called once per frame
    public void Update () {
        currentComboAsText.text = currentCombo.ToString();


        if (currentCombo>maxCombo)
        {
            maxCombo = currentCombo;

        }

        if (lastNoteBehaviour.lastNoteDone == true)
        {
            PlayerPrefs.SetInt("lastGameMaxCombo", maxCombo);
        }
    }
}

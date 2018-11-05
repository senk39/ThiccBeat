using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombo : MonoBehaviour {

    public int maxCombo = 0;
    public int currentCombo = 0;
    public Text currentComboAsText;


	
	// Update is called once per frame
	void Update () {
        currentComboAsText.text = currentCombo.ToString();


        if (currentCombo>maxCombo)
        {
            maxCombo = currentCombo;

        }

        //Jeśli nuta będzie kolidować z colliderem aktywatra missa to tu wstaw kod zerowania currentCombo 

    }
}

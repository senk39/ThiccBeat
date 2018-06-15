using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombo : MonoBehaviour {

    public ushort maxCombo = 0;
    public ushort currentCombo = 0;
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

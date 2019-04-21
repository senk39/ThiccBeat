using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notMash : MonoBehaviour {

    public bool is1Active = false;
    public bool is2Active = false;
    public bool is3Active = false;
    public bool is4Active = false;
    public bool is5Active = false;
    public bool is6Active = false;
    public bool is7Active = false;

    public bool isAnyActive = false;

    public KeyCode key1 = KeyCode.A;
    public KeyCode key2 = KeyCode.W;
    public KeyCode key3 = KeyCode.D;
    public KeyCode key4 = KeyCode.J;
    public KeyCode key5 = KeyCode.I;
    public KeyCode key6 = KeyCode.L;
    public KeyCode key7 = KeyCode.G;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(is1Active == true || is2Active == true || is3Active == true || is4Active == true || is5Active == true || is6Active == true || is7Active == true)
        {
            isAnyActive = true;
            checkIsTheKeyIsWrong();
        }
        else
        {
            isAnyActive = false;
        }
	}


    void checkIsTheKeyIsWrong()
    {
        if(Input.GetKey(key1) && is1Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key2) && is2Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key3) && is3Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key4) && is4Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key5) && is5Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key6) && is6Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
        else if (Input.GetKey(key7) && is7Active == false)
        {
            GameObject.Find("Combo").GetComponent<playerCombo>().currentCombo = 0;
        }
    }
}

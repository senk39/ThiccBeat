using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsingLogo : MonoBehaviour {

    public RectTransform trans;
    private float newScale;
    private int freezeTime = 1;
    private float sinus;


    void Start () {
        newScale = 1.0f;
        trans.localScale = new UnityEngine.Vector3(newScale, newScale, 1.0f);
	}
	

	void Update () {

        if (Time.timeSinceLevelLoad > freezeTime)
        {
            sinus = (Mathf.Sin((Time.timeSinceLevelLoad - freezeTime) * 2));
            newScale = 1f + sinus/12;
            trans.localScale = new Vector3(newScale, newScale, 1.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsingLogo : MonoBehaviour {

    public RectTransform trans;
    public float newScale;
    public int freezeTime = 1;
    float sinus;

    // Use this for initialization
    void Start () {
        newScale = 1.0f;
        trans.localScale = new UnityEngine.Vector3(newScale, newScale, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad > freezeTime)
        {
            sinus = (Mathf.Sin((Time.timeSinceLevelLoad - freezeTime) * 3));
            newScale = 1f + sinus/12;
            trans.localScale = new UnityEngine.Vector3(newScale, newScale, 1.0f);

        }

    }
}

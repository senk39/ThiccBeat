using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadingText : MonoBehaviour {

    public RectTransform trans;
    public GameObject obb;

    private float cosinus;

    private int freezeTime = 1;

    private float newScale;

    private float newTransparency;

    void Start()
    {
        newScale = 1.0f;
        newTransparency = 0;
        trans.localScale = new UnityEngine.Vector3(newScale, newScale, 1.0f);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > freezeTime)
        {
            cosinus = -(Mathf.Cos((Time.timeSinceLevelLoad - freezeTime) * 2));

            //SKALOWANIE
            newScale = 1f + cosinus / 32;
            trans.localScale = new Vector3(newScale, newScale, 1.0f);

            //PRZEZROCZYSTOŚĆ
            newTransparency = 1f + cosinus;
            obb.GetComponent<CanvasGroup>().alpha = newTransparency;
        }

    }
}

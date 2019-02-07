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

    public float newTransparency;

    private bool keyPressed;

    void Start()
    {
        keyPressed = false;
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
            if (Input.anyKeyDown)
            {
                keyPressed = true;
            }

            if(keyPressed == true)
            {
                newTransparency = 1f + cosinus;
                obb.GetComponent<CanvasGroup>().alpha = newTransparency;
                for (int i = 0; i < 222; i++)
                {
                    obb.GetComponent<CanvasGroup>().alpha = obb.GetComponent<CanvasGroup>().alpha - 0.01f;

                }
            }
         
            
            else
            {
                newTransparency = 1f + cosinus;
                obb.GetComponent<CanvasGroup>().alpha = newTransparency;
            }
               
        }

    }
}

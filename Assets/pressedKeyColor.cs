﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressedKeyColor : MonoBehaviour
{

    public KeyCode key;
    public Material[] material;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];

        }
    }
}

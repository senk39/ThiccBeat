using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteClass : MonoBehaviour
{
    public int startPoint; //wystarczająco długi
    public int endPoint;
    public int keyNumber; //albo GameObject NoteRow albo jakoś tak
    public bool isShort = false;
    public bool isHold = false;
    public int length;

    public GameObject noteShort;

    Quaternion noteQuaternion = new Quaternion(0f, 0f, 0f, 0f);
    Quaternion barQuaternion = new Quaternion(180f, 0f, 0f, 0f);


    void Awake()
    {
        //length = endPoint - startPoint;
        isHold = checkIfHold();
        isShort = !checkIfHold();
    }

    public bool checkIfHold()
    {
        
        if (length <= 12)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

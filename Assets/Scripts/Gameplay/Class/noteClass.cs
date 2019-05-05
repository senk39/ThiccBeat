using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteClass : MonoBehaviour
{
    public int startPoint; //wystarczająco długi
    public int endPoint;
    public int keyNumber; //albo GameObject NoteRow albo jakoś tak
    public int noteLength;
    public bool isShort = false;
    public bool isHold = false;

    void Awake()
    {
        isHold = checkIfHold();
        isShort = !checkIfHold();
    }

    public bool checkIfHold()
    {
        if (endPoint - startPoint <= 12)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

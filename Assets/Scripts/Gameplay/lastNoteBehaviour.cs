using UnityEngine;

public class lastNoteBehaviour : MonoBehaviour {

    static public bool lastNoteDone;

    void Awake()
    {
        lastNoteDone = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pink Bar")
        {
            lastNoteDone = true;
        }
    }
}

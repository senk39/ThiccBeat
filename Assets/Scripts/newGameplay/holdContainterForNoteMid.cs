using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainterForNoteMid : MonoBehaviour {

    private GameObject holdStart;
    private GameObject holdEnd;

    private GameObject pivot;

    private GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    private KeyCode keyMid;

    public bool isActivated = false;
    private Vector3 tfv3;
    private Vector3 posv3;

    private float pivotZPos;

    public bool noteStartIsClicked = false;

    public float toleranceForTooEarlyUnclick = 3.5f;

    public int counterForBlockMultipleClicks;

    private float pinkBarZPos;

    //public float initialNoteLength;

    void Start () {

        //initialNoteLength = GetComponent<Transform>().parent.localScale.z;
        pinkBarZPos = GameObject.Find("pink stripe 3").transform.position.z;
        Debug.Log("pinkZPos: " + pinkBarZPos);

        playerScoreContainer = GameObject.Find("Score");

        checkKey();

        if (transform.parent.name == "pivot")
        {
            pivot = transform.parent.gameObject;
            pivotZPos = pivot.transform.position.z;
        }

        foreach (Transform child in transform.parent.parent)
        {
            if (child.name != this.name)
            {
                if(child.name == "noteStart")
                {
                    holdStart = child.gameObject;
                }
                else if (child.name == "noteEnd")
                {
                    holdEnd = child.gameObject;
                }
            }
        }
    }

    void Update()
    {

        posv3 = pivot.transform.position;
        tfv3 = pivot.transform.localScale;
        if (holdStart == null)
        {
            isActivated = true;
        }
        if(holdStart==null)
        {
            if (Input.GetKeyDown(keyMid))
            {
                Debug.Log("isNull");
                counterForBlockMultipleClicks++;
            }
        }
    }

        void OnTriggerStay(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Pink Bar" && isActivated && noteStartIsClicked && counterForBlockMultipleClicks<1)
        {

            if (Input.GetKeyUp(keyMid))
            {
                counterForBlockMultipleClicks++;
                Debug.Log(counterForBlockMultipleClicks);
            }
            if (Input.GetKey(keyMid))
            {
                if (tfv3.z > Mathf.Abs(holdEnd.transform.position.z - pinkBarZPos))
                {
                    tfv3.z -= Mathf.Abs(tfv3.z - Mathf.Abs(holdEnd.transform.position.z - pinkBarZPos));
                    Debug.Log("dluzsze niz byc powinno!");
                }
                posv3.z = -14.2f;
                pivot.GetComponent<note>().notesVelocity = 0;
                GetComponent<note>().notesVelocity = 0;
                tfv3.z -= 0.22f;
                pivot.transform.localScale = tfv3;
                pivot.transform.position = posv3;
                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore +=2;

               


                if (tfv3.z > 0) { }       
        }

            else
            {
                if (tfv3.z < toleranceForTooEarlyUnclick)
                {
                    tfv3.z = 0f;
                    pivot.transform.localScale = tfv3;
                    Destroy(transform.gameObject);
                    Destroy(holdEnd);
                    playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                }
            }
        }
    }

    void checkKey()
    {
        if (gameObject.transform.parent.transform.position.x == -5.1f)
        {
            keyMid = KeyCode.A;
        }
        else if (gameObject.transform.parent.transform.position.x == -3.1f)
        {
            keyMid = KeyCode.W;
        }
        else if (gameObject.transform.parent.transform.position.x == -1.1f)
        {
            keyMid = KeyCode.D;
        }
        else if (gameObject.transform.parent.transform.position.x == 1.1f)
        {
            keyMid = KeyCode.J;
        }
        else if (gameObject.transform.parent.transform.position.x == 3.1f)
        {
            keyMid = KeyCode.I;
        }
        else if (gameObject.transform.parent.transform.position.x == 5.1f)
        {
            keyMid = KeyCode.L;
        }
    }
}

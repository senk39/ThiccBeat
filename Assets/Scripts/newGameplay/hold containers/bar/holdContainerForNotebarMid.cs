using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdContainerForNotebarMid : MonoBehaviour {

    private GameObject holdStart;
    private GameObject holdEnd;

    private GameObject pivot;

    private GameObject playerScoreContainer;
    public GameObject playerComboContainer;

    private KeyCode keyMid;

    public bool isActivated = false;
    private Vector3 tfv3;
    private Vector3 posv3;

    const float ZPosWhenHoldsWillDie = -14.2f;

    public bool noteStartIsClicked = false;

    public float toleranceForTooEarlyUnclick = 3.5f;

    public int counterForBlockMultipleClicks;

    private float barButtonOnDownZPos;

    void Start()
    {
        
        dataInit();
    }

    void Update()
    {

        posv3 = pivot.transform.position;
        tfv3 = pivot.transform.localScale;
        if (holdStart == null)
        {
            isActivated = true;
        }
        if (holdStart == null)
        {
            if (Input.GetKeyDown(keyMid))
            {
                counterForBlockMultipleClicks++;
            }
        }
    }

    void OnTriggerStay(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Indicator" && isActivated && noteStartIsClicked && counterForBlockMultipleClicks < 1)
        {

            if (Input.GetKeyUp(keyMid))
            {
                counterForBlockMultipleClicks++;
            }

            if (Input.GetKey(keyMid))
            {
                LimitingMidKeyToEndNotePosition();

                shrinkingDownOfPressedHoldNote();

                playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 2;

                if (holdEnd.transform.position.z < ZPosWhenHoldsWillDie)
                {
                    Destroy(holdEnd.gameObject);
                    Destroy(gameObject);
                    playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
                }
            }


            else
            {
                if (tfv3.z < toleranceForTooEarlyUnclick)
                {
                    onDestroyNote();
                }
            }
        }
    }

    void shrinkingDownOfPressedHoldNote()
    {
        posv3.z = -14.2f;
        pivot.GetComponent<note>().noteVelocity = 0;
        GetComponent<note>().noteVelocity = 0;
        tfv3.z -= 0.22f;
        pivot.transform.localScale = tfv3;
        pivot.transform.position = posv3;
    }

    void onDestroyNote()
    {
        tfv3.z = 0f;
        pivot.transform.localScale = tfv3;
        Destroy(transform.gameObject);
        Destroy(holdEnd);
        playerScoreContainer.GetComponent<playerScore>().playerCurrentScore += 200;
    }

    void LimitingMidKeyToEndNotePosition()
    {
        if (tfv3.z > Mathf.Abs(holdEnd.transform.position.z - barButtonOnDownZPos))
        {
            tfv3.z -= Mathf.Abs(tfv3.z - Mathf.Abs(holdEnd.transform.position.z - barButtonOnDownZPos));
        }
        else if (tfv3.z < Mathf.Abs(holdEnd.transform.position.z - barButtonOnDownZPos))
            {
                tfv3.z += Mathf.Abs(tfv3.z - Mathf.Abs(holdEnd.transform.position.z - barButtonOnDownZPos));
            }
        
    }

    void dataInit()
    {
        barButtonOnDownZPos = GameObject.Find("barButton").transform.position.z;

        playerScoreContainer = GameObject.Find("Score");

        keyMid = KeyCode.Space;

        if (transform.parent.name == "pivot")
        {
            pivot = transform.parent.gameObject;
        }

        foreach (Transform child in transform.parent.parent)
        {
            if (child.name != this.name)
            {
                if (child.name == "notebarStart")
                {
                    holdStart = child.gameObject;
                }
                else if (child.name == "notebarEnd")
                {
                    holdEnd = child.gameObject;
                }
            }
        }
    }
}

using UnityEngine;

public class note : MonoBehaviour {

    public float noteVelocity = 1.75f;
    Rigidbody rb;

    bool anyKeyPressedToStart = false;

    public bool isTheLowest = false;

    public bool isActive = false;
    private float ZPosToActive;
    private float ZPosToDestroy;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ZPosToActive = 0f;
        ZPosToDestroy = -24f;
    }
    
    void Update() {

        if (Input.anyKeyDown)
        {
            anyKeyPressedToStart = true;
        }
        
        if (pause.isGamePaused == false && anyKeyPressedToStart == true)
        {
            rb.velocity = new Vector3(0, 0, (-noteVelocity / Time.deltaTime));
        }

        if (gameObject.transform.position.z < ZPosToActive && gameObject.transform.position.z > ZPosToDestroy)
        {
            isActive = true;
        }

        if (gameObject.transform.position.z < ZPosToDestroy)
        {
            isActive = false;
        }
    }
}
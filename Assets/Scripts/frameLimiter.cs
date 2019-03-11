using UnityEngine;

public class frameLimiter : MonoBehaviour
{
    public int targetFrameRate = 90;

    private void Awake()

    {
        //QualitySettings.vSyncCount = 0;
       // Application.targetFrameRate = targetFrameRate;
    }
}
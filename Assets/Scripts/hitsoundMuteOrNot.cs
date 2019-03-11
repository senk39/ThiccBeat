using UnityEngine;

public class hitsoundMuteOrNot : MonoBehaviour {

	void Awake () {
        if(PlayerPrefs.GetInt("areButtonsMute") == 0)
        {
           GameObject.Find("BUTTONS").GetComponent<AudioSource>().mute = false;
        }

        else if (PlayerPrefs.GetInt("areButtonsMute") == 1)
        {
            GameObject.Find("BUTTONS").GetComponent<AudioSource>().mute = true;
        }
    }
}

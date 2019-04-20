using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSongSceneLoader : MonoBehaviour {

	void Start () {
        SceneManager.LoadScene(lastSongSceneCatcher.lastPlayedSongSceneIndex);
    }
}

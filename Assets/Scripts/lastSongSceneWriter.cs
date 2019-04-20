using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSongSceneWriter : MonoBehaviour {

	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        lastSongSceneCatcher.lastPlayedSongSceneIndex = scene.buildIndex;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader instance;

    public Animator transition;

    public float transitionTime = 1f;

    void Start() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // instance = this;
    }

    public void LoadNextLevel(bool async = false) {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, async));
    }

    public void LoadLevelAtIndex(int levelIndex, bool async = false) {
        StartCoroutine(LoadLevel(levelIndex, async));
    }

    IEnumerator LoadLevel(int levelIndex, bool async) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (async) {
            SceneManager.LoadSceneAsync(levelIndex);
        }
        else {
            SceneManager.LoadScene(levelIndex);
        }
    }
}

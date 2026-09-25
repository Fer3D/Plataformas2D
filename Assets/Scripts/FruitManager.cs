using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;

    private bool levelFinished;

    private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {
        if (levelFinished || transform.childCount > 0)
            return;

        levelFinished = true;

        if (levelCleared != null)
            levelCleared.gameObject.SetActive(true);
        if (transition != null)
            transition.SetActive(true);

        Invoke(nameof(ChangeScene), 1);
    }

    void ChangeScene()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(next);
    }
}

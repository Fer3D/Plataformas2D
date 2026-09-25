using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (text != null)
            text.gameObject.SetActive(true);
        inDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (text != null)
            text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            inDoor = false;
            if (text != null)
                text.gameObject.SetActive(false);
            SceneManager.LoadScene(levelName);
        }
    }
}

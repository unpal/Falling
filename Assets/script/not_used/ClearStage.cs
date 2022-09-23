using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour
{
    public GameObject gamewin;
    public bool Clear = false;
    GameObject player;

    void Start()
    {
        gamewin.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Clear)
        {
            PlayerPrefs.DeleteAll();
            Scene scene = SceneManager.GetActiveScene();
            int currentScene = scene.buildIndex;
            int nextScene = currentScene + 1;
            SceneManager.LoadScene(nextScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            gamewin.SetActive(true);
            Clear = true;
        }
    }
}

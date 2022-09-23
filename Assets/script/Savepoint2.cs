using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savepoint2 : MonoBehaviour
{
    GameObject player;
    public int check = 0;
    public bool reset = false;

    void Start()
    {
        if (reset)
        {
            PlayerPrefs.DeleteAll();
            reset = false;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        check = PlayerPrefs.GetInt("check");

        if (check == 2)
        {
            Restartcheckpoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("check", 2);
            Scene scene = SceneManager.GetActiveScene();
            int currentScene = scene.buildIndex;
            PlayerPrefs.SetInt("stage", currentScene);
        }
    }

    void Restartcheckpoint()
    {
        player.gameObject.transform.position = gameObject.transform.position;
    }
}

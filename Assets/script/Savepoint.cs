using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savepoint : MonoBehaviour
{
    // 세이브포인트 스크립트
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

        if (check == 1)
        {
            Restartcheckpoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("check", 1);
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

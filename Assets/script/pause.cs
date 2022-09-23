using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // esc 누르면 일시정지
    bool pausestate;
    public GameObject pauseUI;
    public GameObject player;

    void Start()
    {
        pausestate = false;
        pauseUI.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausestate)
            {
                Time.timeScale = 0;
                pausestate = true;
                pauseUI.gameObject.SetActive(true);
                player.gameObject.GetComponent<main>().enabled = false;
            }

            else
            {
                Time.timeScale = 1;
                pausestate = false;
                pauseUI.gameObject.SetActive(false);
                player.gameObject.GetComponent<main>().enabled = true;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class start : MonoBehaviour
{
    public VideoPlayer video;
    GameObject main;

    private void Start()
    {
        main = GameObject.Find("main");
        video.loopPointReached += CheckOver;
    }
    // 타이틀 씬에서 메인 씬으로 이동
    public void OnClickStartButton()
    {
        main.SetActive(false);
        video.Play();
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp) 
    {

        SceneManager.LoadScene("Main");
    }
}

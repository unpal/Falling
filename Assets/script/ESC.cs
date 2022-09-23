using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC : MonoBehaviour
{
    public void OnclickReStartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnClicksettingButton()
    {

    }
    public void OnClickExitMainMenu()
    {
        SceneManager.LoadScene("title");
    }
    public void OnClickExitDesttop()
    {
        Application.Quit();
    }
}

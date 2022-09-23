using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gosetting : MonoBehaviour
{
    GameObject setting;
    GameObject keyboard;
    GameObject main;
    void Start()
    {
        setting = GameObject.Find("setting");
        keyboard = GameObject.Find("keyboardcan");
        main = GameObject.Find("main");
        setting.SetActive(false);
        keyboard.SetActive(false);
    }

    public void OnClickSetting()
    {
        main.SetActive(false);
        setting.SetActive(true);
    }
    public void OnClickSettingBackButton()
    {
        setting.SetActive(false);
        main.SetActive(true);
    }
    public void OnClickKeyboardButton()
    {
        setting.SetActive(false);
        keyboard.SetActive(true);
    }
    public void OnClickKeyBoardBackButton()
    {
        keyboard.SetActive(false);
        setting.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingingame : MonoBehaviour
{
    GameObject setting;
    GameObject keyboard;
    void Start()
    {
        setting = GameObject.Find("setting");
        keyboard = GameObject.Find("keyboardcan");
        setting.SetActive(false);
        keyboard.SetActive(false);
 }

    public void OnClicksettingkButton()
    {
        setting.SetActive(true);
    }
    public void OnClickbackButton()
    {
        setting.SetActive(false);
    }
    public void OnClickKeyButton()
    {
        setting.SetActive(false);
        keyboard.SetActive(true);
    }
    public void OnClickKeyBackButton()
    {
        setting.SetActive(true);
        keyboard.SetActive(false);
    }
}

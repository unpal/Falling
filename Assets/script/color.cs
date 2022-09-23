using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    public Button high;
    public Button on;
    bool highClick;
    bool OnClick;
    void OnEnable()
    {
        highClick = false;
        OnClick = false;
    }
    private void Update()
    {
        ColorBlock high1 = high.colors;
        if (!highClick)
            high1.normalColor = new Color32(255, 212, 0, 255);
        else
            high1.normalColor = new Color32(255, 255, 255, 255);
        high.colors = high1;
        ColorBlock on1 = on.colors;
        if (!OnClick)
            on1.normalColor = new Color32(255, 212, 0, 255);
        else
            on1.normalColor = new Color32(255, 255, 255, 255);
        on.colors = on1;
    }
    // Update is called once per frame
    public void OnClickOtherButton()
    {
        highClick = true;
    }
    public void OnClickOffButton()
    {
        OnClick = true;
    }
}

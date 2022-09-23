using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboardColor : MonoBehaviour
{
    public Button space;
    public Button grap;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ColorBlock space1 = space.colors;
        if (Input.GetKey(KeyCode.Space))
            space1.normalColor = new Color32(255, 212, 0, 255);
        else
            space1.normalColor = new Color32(255, 255, 255, 255);
        space.colors = space1;
        ColorBlock grap1 = grap.colors;
        if (Input.GetKey(KeyCode.Z))
            grap1.normalColor = new Color32(255, 212, 0, 255);
        else
            grap1.normalColor = new Color32(255, 255, 255, 255);
        grap.colors = grap1;
    }
}

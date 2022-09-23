using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallball4 : MonoBehaviour
{
    private Rcheck Bood;
    public bool R;

    void Start()
    {
        Bood = GameObject.Find("rock4").GetComponent<Rcheck>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bood.R = true;
        }
    }
}

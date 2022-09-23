using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotrope : MonoBehaviour
{
    // 썪은 로프 구현
    private main Fdie;
    Rigidbody2D rr;
    

    void Start()
    {
        Fdie = GameObject.Find("Main").GetComponent<main>();
        rr = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("ST1", 1f);
        }
    }

    void ST1()
    {
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
    }
}

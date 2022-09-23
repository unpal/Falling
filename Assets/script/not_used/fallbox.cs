using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallbox : MonoBehaviour
{
    Rigidbody2D FA;
    public GameObject fallb;
    public int fb = 0;

    void Start()
    {
        FA = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject && fb <= 0)
        {
            Instantiate(fallb, new Vector3(20, 30, 0), Quaternion.identity);
            fb++;
        }
    }
}

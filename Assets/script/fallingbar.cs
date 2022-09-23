using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingbar : MonoBehaviour
{
    // 밟으면 사라지는 발판 스크립트
    private main Fdie;
    [SerializeField] float destroySec = 0.0f;
    Rigidbody2D rb;
    void Start()
    {
        Fdie = GameObject.Find("Main").GetComponent<main>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Main") && Fdie.onland)
        {
            Destroy(gameObject, destroySec);
            Fdie.fall_die = true;
        }
    }
}

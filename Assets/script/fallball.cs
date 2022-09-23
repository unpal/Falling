using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallball : MonoBehaviour
{
    // 메인 캐릭터가 해당 구역에 도착 시 돌이 떨어지는 스크립트
    private Rcheck Bood; // Rcheck 스크립트 연동
    public bool R;

    void Start()
    {
        Bood = GameObject.Find("rock1").GetComponent<Rcheck>();
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

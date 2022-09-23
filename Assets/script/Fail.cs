using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    // 패배, 죽음 이펙트 관련 스크립트
    public GameObject Ma; // 메인 캐릭터
    public GameObject Death; // 죽음 이펙트
    public GameObject Finish; // 패배 시 뜨는 UI
    public bool fail = false;
    private main FD;

    void Start()
    {
        FD = GameObject.Find("Main").GetComponent<main>();
        Finish.SetActive(false);
    }

    void Update()
    {
        Falldie();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rock")
        {
            Die();
        }
    }

    void Falldie()
    {
        if (FD.onland && FD.fall_die)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(Death, transform.position, transform.rotation);
        Ma.SetActive(false);
        Finish.SetActive(true);
        fail = true;
    }
}

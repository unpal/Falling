using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    // �й�, ���� ����Ʈ ���� ��ũ��Ʈ
    public GameObject Ma; // ���� ĳ����
    public GameObject Death; // ���� ����Ʈ
    public GameObject Finish; // �й� �� �ߴ� UI
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

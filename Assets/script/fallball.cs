using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallball : MonoBehaviour
{
    // ���� ĳ���Ͱ� �ش� ������ ���� �� ���� �������� ��ũ��Ʈ
    private Rcheck Bood; // Rcheck ��ũ��Ʈ ����
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

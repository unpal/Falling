using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rcheck : MonoBehaviour
{
    // �� �������� ��ũ��Ʈ
    public bool R;
    Rigidbody2D FB;
    public float DestroyTime = 3.0f; // 3�� �� �ı�
    void Start()
    {
        R = false;
        FB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Ball();
    }

    void Ball()
    {
        if (R == true)
        {
            FB.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, DestroyTime);
        }
    }
}

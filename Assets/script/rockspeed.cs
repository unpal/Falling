using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspeed : MonoBehaviour
{
    // ������ ���� ���ǵ�, 3���� �ı�
    Rigidbody2D rig;
    public float power = 20f;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(gameObject.transform.localScale.x, 0) * power, ForceMode2D.Impulse);
    }

    void Update()
    {
        Destroy(gameObject, 3);
    }
}

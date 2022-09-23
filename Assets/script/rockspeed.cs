using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspeed : MonoBehaviour
{
    // 던지는 돌의 스피드, 3초후 파괴
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_rock : MonoBehaviour
{
    // ���� �����̸� �ݰ� ������ Ȯ���ϴ� ��ũ��Ʈ
    public bool pick;
    private main Throw;

    void Start()
    {
        Throw = GameObject.Find("Main").GetComponent<main>();
        Throw.tt_rock = 0;
    }


    void Update()
    {
        if (pick && Input.GetKeyDown(KeyCode.Z))
            Pickup();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            pick = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            pick = false;
        }
    }

    void Pickup()
    {
        Destroy(gameObject);
        Throw.tt_rock ++;
    }
}

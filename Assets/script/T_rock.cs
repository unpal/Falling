using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_rock : MonoBehaviour
{
    // 땅의 돌멩이를 줍고 개수를 확인하는 스크립트
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

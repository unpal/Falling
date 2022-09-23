using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finalclear : MonoBehaviour
{
    // Ŭ���� �� Ÿ��Ʋ ȭ������ ���ư��� ��ũ��Ʈ
    public GameObject gamewin;
    public bool Clear = false;
    GameObject player;

    void Start()
    {
        gamewin.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Clear)
        {
            SceneManager.LoadScene("title");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            gamewin.SetActive(true);
            Clear = true;
        }
    }
}

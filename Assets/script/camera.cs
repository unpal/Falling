using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // ī�޶� ����ĳ���� ���󰡴� ��ũ��Ʈ
    public Camera m_camera;
    public Transform m_player;

    void Start()
    {

    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = m_player.position + new Vector3(0, 0, -1);

        m_camera.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}

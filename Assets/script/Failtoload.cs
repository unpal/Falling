using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failtoload : MonoBehaviour
{
    // �й� �� ����� ��ũ��Ʈ
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void End()
    {
        Application.Quit();
    }
}

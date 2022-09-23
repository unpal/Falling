using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;


public class balloonmove : MonoBehaviour
{
    public Transform[] move;
    public float speed = 5f;
    int moveNum = 0;
    bool canmove;
    public int check = 0;
    GameObject checkpoint;
    GameObject checkpointTwo;
    bool firstcheck;
    bool secondcheck;
    public SkeletonAnimation skeleton3D;
    void Start()
    {
        firstcheck = true;
        secondcheck = true;
        transform.position = move[moveNum].transform.position;
        canmove = true;
        checkpoint = GameObject.Find("save1");
        checkpointTwo = GameObject.Find("save2");
        check = PlayerPrefs.GetInt("check");
        if (check == 1)
        {
            transform.position = checkpoint.transform.position;
            moveNum = 2;
        }
        if (check == 2)
        {
            transform.position = checkpointTwo.transform.position;
            moveNum = 4;
            canmove = false;
            StartCoroutine(WaitForIt());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetAnim("Ballon");
        }

        movePath();
        if (moveNum > 3 && firstcheck)
        {
            firstcheck = false;
            PlayerPrefs.SetInt("check", 1);
            Scene scene = SceneManager.GetActiveScene();
            int currentScene = scene.buildIndex;
            PlayerPrefs.SetInt("stage", currentScene);
        }
        if(moveNum > 4 && secondcheck)
        {
            secondcheck = false;
            PlayerPrefs.SetInt("check", 2);
            Scene scene = SceneManager.GetActiveScene();
            int currentScene = scene.buildIndex;
            PlayerPrefs.SetInt("stage", currentScene);
        }
        if (moveNum == 6)
            Destroy(gameObject);


    }

    public void movePath()
    {
        if (moveNum < 6)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, move[moveNum].transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canmove)
        {

                if (collision.gameObject.name == "Main")
                {
                    moveNum++;
                    canmove =false;
                    StartCoroutine(WaitForIt());
                }
            }
        }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1.0f);
        canmove = true;
    }

    void SetAnim(string _name, bool _loop = true)
    {
        if (skeleton3D != null) //스파인 적용하는 경우
        {
            skeleton3D.AnimationState.SetAnimation(0, _name, _loop);   //스파인 에니메이션
        }
    }
}

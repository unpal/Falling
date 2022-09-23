using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barmove_LR : MonoBehaviour
{
    public int speed = 0;
    SpriteRenderer sprite;
    public float walktime;
    public float stoptime;
    Vector3 movement = Vector3.zero;

    void Start()
    {
        gameObject.transform.position = new Vector3(68, 0, 0);
        sprite = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("WalkLeft");
    }

    void Update()
    {
        transform.position += movement * Time.deltaTime * (speed);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        sprite.color = Color.white;
    }

    IEnumerator WalkLeft()
    {
        movement = Vector3.left;
        yield return new WaitForSeconds(walktime);
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        movement = Vector3.zero;
        yield return new WaitForSeconds(stoptime);
        StartCoroutine(WalkRight());
    }

    IEnumerator WalkRight()
    {
        movement = Vector3.right;
        yield return new WaitForSeconds(walktime);
        StartCoroutine(Stop2());
    }

    IEnumerator Stop2()
    {
        movement = Vector3.zero;
        yield return new WaitForSeconds(stoptime);
        StartCoroutine(WalkLeft());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}

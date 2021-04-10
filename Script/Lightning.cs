using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject cloud;
    Transform cloudTr;

    public Animator anim;

    private void Awake()
    {
        cloudTr = cloud.GetComponent<Transform>();
    }

    void Return()
    {
        transform.position = cloudTr.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            GameManager.instance.MissionFail();
        }
        else
        {
            anim.SetTrigger("Crash");

            Invoke("Return", 4.0f);

        }
    }
}

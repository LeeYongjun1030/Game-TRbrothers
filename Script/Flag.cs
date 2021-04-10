using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    string triggerGojTag;
    Animator flagAnim;

    private void Awake()
    {
        flagAnim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            triggerGojTag = collision.gameObject.tag;
             GameManager.instance.CheckClear();
        }
    }

    public void ClearSprite()
    {
        string motionTrigger = triggerGojTag == "Rabbit" ? "Rabbit" : "Turtle";
        flagAnim.SetTrigger(motionTrigger);
    }
}

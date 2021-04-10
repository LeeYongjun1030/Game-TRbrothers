using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Dissapear()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            if (collision.gameObject.tag == gameObject.name.Split('C')[0])
            {
                EffectSoundManager.soundManager.CoinSound();
                anim.SetTrigger("Catch");
                Invoke("Dissapear", 1.0f);
                GameManager.instance.GetCoin(collision.gameObject.tag);
            }

        }
    }
}

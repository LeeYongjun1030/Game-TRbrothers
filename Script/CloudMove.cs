using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    public Sprite[] image;
    public float speed;
    public bool isVertical;
    public float moveTime;
    SpriteRenderer cloudSp;
    Rigidbody2D rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cloudSp = gameObject.GetComponent<SpriteRenderer>();
    }
    void VerticalMove()
    {
        CancelInvoke();
        rb.velocity = new Vector2(rb.velocity.x, speed);
        Invoke("StopMove", moveTime);
    }
    void HorizontalMove()
    {
        CancelInvoke();
        cloudSp.sprite = image[1];
        rb.velocity = new Vector2(speed, rb.velocity.y);
        Invoke("StopMove", moveTime);
    }
    void StopMove()
    {
        cloudSp.sprite = image[0];
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
          
            if (isVertical)
            {
                
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                VerticalMove();
                
            }
            else
            {
                EffectSoundManager.soundManager.CloudSound();
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                HorizontalMove();

            }

        }
    }
}

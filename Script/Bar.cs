using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float speed;
    public bool isVertical;
    public float moveTime;
    Rigidbody2D rb;
    int moveDir;
   
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveDir = -1;

        if (isVertical)
        {
            VerticalMove();
        }
        else
        {
            HorizontalMove();
        }
    }
    void VerticalMove()
    {
        moveDir *= -1;
        rb.velocity = new Vector2(rb.velocity.x, speed * moveDir);
        Invoke("VerticalMove", moveTime);
    }
    void HorizontalMove()
    {
        moveDir *= -1;
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
        Invoke("HorizontalMove", moveTime);
    }

}

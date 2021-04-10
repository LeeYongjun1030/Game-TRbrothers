using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCloud : MonoBehaviour
{
    public float speed;
    public float moveTime;
    Rigidbody2D rb;
    int moveDir;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveDir = -1;

        HorizontalMove();
       
    }
    void HorizontalMove()
    {
        moveDir *= -1;
        rb.velocity = new Vector2(speed * moveDir, rb.velocity.y);
        Invoke("HorizontalMove", moveTime);
    }
}

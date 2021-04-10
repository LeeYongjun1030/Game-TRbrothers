using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

    [Header("Move")]
    public ParticleSystem destroyPar;
    public float speed;
    Rigidbody2D rg;
    SpriteRenderer sr;
    int nextMove;
    int layerMask;

    private void Awake()
    {
        layerMask = (1 << LayerMask.NameToLayer("Monster"));
        rg = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        Think();
        StartCoroutine("PlatformCheck");
    }

    IEnumerator PlatformCheck()
    {
        while (true)
        {
            rg.velocity = new Vector2(speed * nextMove, rg.velocity.y);

            Vector2 frontVec = new Vector2(rg.position.x + nextMove * 1.0f, rg.position.y);
            Debug.DrawRay(frontVec, Vector2.down * 1.2f, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down * 1.2f, 2,~layerMask);

            if (rayHit.collider == null)
            {
                
                nextMove *= -1;
                if (nextMove == 1)
                {
                    sr.flipX = true;
                }
                else if (nextMove == -1)
                {
                    sr.flipX = false;
                }
                CancelInvoke();
                Invoke("Think", 1.0f);
            }

            yield return null;
        }
    }


    void Think()
    {
        nextMove = Random.Range(-1, 2);


        if (nextMove == 1)
        {
            sr.flipX = true;
        }
        else if (nextMove == -1)
        {
            sr.flipX = false;
        }
        Invoke("Think", 1.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            destroyPar.transform.position = gameObject.transform.position;
            destroyPar.Play();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Rabbit"| collision.gameObject.tag == "Turtle")
        {
            GameManager.instance.MissionFail();
            destroyPar.transform.position = gameObject.transform.position;
            destroyPar.Play();
            gameObject.SetActive(false);
        }

    }
}

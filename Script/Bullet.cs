using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int direction;
    public ParticleSystem destroyPar;
    Transform playerTr;
    Transform bulletTr;

    private void Awake()
    {
        bulletTr = gameObject.transform;
        playerTr = player.GetComponent<Transform>();
    }

    private void OnEnable()
    {
        int i = (int)playerTr.localScale.x;
        direction = i;
        bulletTr.localScale = new Vector3(i,1,1);
    }
    private void FixedUpdate()
    {
        bulletTr.position = new Vector2(bulletTr.position.x + direction * speed , bulletTr.position.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        gameObject.SetActive(false);
        
    }

    private void OnDisable()
    {
        destroyPar.transform.position = gameObject.transform.position;
        destroyPar.Play();
    }
}

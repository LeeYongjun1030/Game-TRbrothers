using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
 
    public ParticleSystem destroyPar;
    public float speed;
    public float lifeTime;
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(speed, rg.velocity.y);

        Invoke("SelfDestroy", lifeTime);
    }
    private void SelfDestroy()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            GameManager.instance.MissionFail();
          
        }
        EffectSoundManager.soundManager.BirdSound();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        destroyPar.transform.position = gameObject.transform.position;
        destroyPar.Play();
    }
}

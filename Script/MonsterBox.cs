using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBox : MonoBehaviour
{
    public ParticleSystem destroyPar;
    public GameObject fly;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            EffectSoundManager.soundManager.ExplosionSound();
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        destroyPar.transform.position = gameObject.transform.position;
        destroyPar.Play();

        fly.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.05f);
        fly.SetActive(true);
    }
}

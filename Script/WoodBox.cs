using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    public ParticleSystem destroyPar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            EffectSoundManager.soundManager.ExplosionSound();
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        
        destroyPar.transform.position = gameObject.transform.position;
        destroyPar.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Animator bridge;
    bool bridgeOn;

    private void Start()
    {
        bridgeOn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EffectSoundManager.soundManager.BridgeSound();
            collision.gameObject.SetActive(false);
            if (bridgeOn)
            {
                bridge.SetBool("On", false);
                bridgeOn = false;
            }
            else
            {
                bridge.SetBool("On", true);
                bridgeOn = true;
            }

        }
    }
}

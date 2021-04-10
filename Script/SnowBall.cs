using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float resetTime;
    public float initDelay;
    Vector2 initPos;
    
    // Start is called before the first frame update
    void Start()
    {
        initPos = gameObject.transform.position;
        Invoke("ResetBall", initDelay);
    }

    void ResetBall()
    {
        gameObject.transform.position = initPos;

        Invoke("ResetBall", resetTime);
    }
}

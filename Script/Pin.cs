using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            GameManager.instance.MissionFail();
        }

    }
}

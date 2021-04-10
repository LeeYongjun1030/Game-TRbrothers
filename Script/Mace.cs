using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Rabbit" | collision.gameObject.tag == "Turtle")
        {
            
            GameManager.instance.MissionFail();
        }

    }
}

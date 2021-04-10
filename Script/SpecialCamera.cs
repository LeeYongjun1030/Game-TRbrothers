using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCamera : MonoBehaviour
{
    public Transform rabbitTr;
    public Transform turtleTr;
    public Move charMove;
    public float MoveSpeed;

    Transform playerTr;
    Transform tr;
    public float cameraX;
    public float cameraY;
    private void Awake()
    {
        tr = gameObject.transform;
        StartCoroutine("PlayerPosCheck");
    }
    IEnumerator PlayerPosCheck()
    {
        while (true)
        {
            if (charMove.chosenCharacter == "Rabbit")
            {
                playerTr = rabbitTr;
            }
            else
            {
                playerTr = turtleTr;
            }
            cameraX = Mathf.Clamp(playerTr.position.x, 4.0f, 8.0f);
            cameraY = Mathf.Clamp(playerTr.position.y, 1.7f,9.0f);
            Vector3 target = new Vector3(cameraX, cameraY, -10.0f);

            float dist = Vector3.Distance(tr.position, target);
            tr.position = Vector3.MoveTowards(tr.position, target, MoveSpeed * dist * Time.deltaTime);

            yield return null;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpBtn : MonoBehaviour, IPointerDownHandler
{
    public Move rabbitMove;
    public Move turtleMove;
    public void OnPointerDown(PointerEventData eventData)
    {
        rabbitMove.Jump();
        turtleMove.Jump();
    }
}

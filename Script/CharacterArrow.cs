using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArrow : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Disappear", 1.0f);
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}

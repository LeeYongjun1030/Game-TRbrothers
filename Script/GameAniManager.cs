using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAniManager : MonoBehaviour
{
    public GameObject menuPanel;

    Animator menuAniCtr;
    private void Awake()
    {
        menuAniCtr = menuPanel.GetComponent<Animator>();
    }
    public void closeMenu()
    {
        menuAniCtr.SetTrigger("Cancel");
        Invoke("InactiveMenu", 0.5f);
    }

    void InactiveMenu()
    {
        menuPanel.SetActive(false);
    }
}

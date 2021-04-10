using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuPanel : MonoBehaviour
{
    HorizontalLayoutGroup vlg;
    public GameObject[] button;
    Transform[] btnTr;
    Image[] btnImage;
    int btnNum;
    int i;
    public string btnName;
    void Awake()
    {
        //아무 버튼도 선택되지 않은 상황을 10으로 함.
        i = 10;

        vlg = GetComponent<HorizontalLayoutGroup>();

        btnNum = gameObject.transform.childCount;
        button = new GameObject[btnNum];
        btnTr = new Transform[btnNum];
        btnImage = new Image[btnNum];

        for (int k = 0; k < btnNum; k++)
        {
            button[k] = gameObject.transform.GetChild(k).gameObject;
            btnTr[k] = button[k].GetComponent<Transform>();
            btnImage[k] = button[k].GetComponent<Image>();
        }

    }

    public void ChangeBtnSize()
    {
        btnName = EventSystem.current.currentSelectedGameObject.name;
        int m = int.Parse(btnName.Split('n')[1]);

        for (int k = 0; k < btnNum; k++)
        {
            if (m == k)
            {
                btnTr[k].localScale = new Vector3(1.3f, 1.3f, 1f);
            }
            else
            {
                btnTr[k].localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

        }

        vlg.SetLayoutVertical();
       
    }

}

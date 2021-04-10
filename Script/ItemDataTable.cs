using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;

public class ItemDataTable : MonoBehaviour
{
    //dataTable는 4개 생성하며, 각각의 테이블 이름은 2글자로 되어있다. 
    //첫번째는 rabbit/turtle 구분
    //두번째는 faceDeco, bodyDeco 구분
    // ex) RF, RB, TF, TB 인덱스도 이 순서대로 지정.
    //item 속성 : id, name, function, cost(int,string,string,int)로 정한다.
   
    public static ItemDataTable itemDataTable;//전역변수를 위한 인스턴스 생성

    public DataTable[] dt;
    int tableNum;

    public Sprite[] rfSprite;
    public Sprite[] rbSprite;
    public Sprite[] tfSprite;
    public Sprite[] tbSprite;


    //사용자가 어느 항목을 보려하는지 체크
    public GameObject itemPanel;
    public GameObject itemImageObj;
    public GameObject itemInfo;
    public bool isRabbitBtnChosen;
    public string chosenPart;
    Image itemImage;
    Text itemInfoText;

    private void Awake()
    {
        itemDataTable = this;

        itemImage = itemImageObj.GetComponent<Image>();
        itemInfoText = itemInfo.GetComponent<Text>();
    }
    private void Start()
    { //init setting : rabbit + face
        isRabbitBtnChosen = true;
        chosenPart = "face";

       CreateTable();
       CreateData();
    }
    void CreateTable()
    {
        tableNum = 4;
        dt = new DataTable[tableNum];
        dt[0] = new DataTable("RFItems");
        dt[1] = new DataTable("RBItems");
        dt[2] = new DataTable("TFItems");
        dt[3] = new DataTable("TBItems");

        for (int i = 0; i < tableNum; i++)
        {
            dt[i].Columns.Add("ID");
            dt[i].Columns.Add("IMAGE");
            dt[i].Columns.Add("NAME");
            dt[i].Columns.Add("FUNC");
            dt[i].Columns.Add("COST");
        }

    }
    void CreateData()
    {
        //RF
        AddItem(0, 0, rfSprite[0], "rf0", "rf0~", 1);
        AddItem(0, 1, rfSprite[1], "rf1", "rf1~", 1);
        AddItem(0, 2, rfSprite[2], "rf2", "rf2~", 1);
        AddItem(0, 3, rfSprite[3], "rf3", "rf3~", 1);
        AddItem(0, 4, rfSprite[4], "rf4", "rf4~", 1);

        //RB
        AddItem(1, 0, rfSprite[0], "rb0", "rb0~", 1);
        AddItem(1, 1, rfSprite[0], "rb1", "rb1~", 1);
        AddItem(1, 2, rfSprite[0], "rb2", "rb2~", 1);
        AddItem(1, 3, rfSprite[0], "rb3", "rb3~", 1);
        AddItem(1, 4, rfSprite[0], "rb4", "rb4~", 1);

        //TF
        AddItem(2, 0, rfSprite[0], "tf0", "tf0~", 1);
        AddItem(2, 1, rfSprite[0], "tf1", "tf1~", 1);
        AddItem(2, 2, rfSprite[0], "tf2", "tf2~", 1);
        AddItem(2, 3, rfSprite[0], "tf3", "tf3~", 1);
        AddItem(2, 4, rfSprite[0], "tf4", "tf4~", 1);

        //TB
        AddItem(3, 0, rfSprite[0], "tb0", "tb0~", 1);
        AddItem(3, 1, rfSprite[0], "tb1", "tb1~", 1);
        AddItem(3, 2, rfSprite[0], "tb2", "tb2~", 1);
        AddItem(3, 3, rfSprite[0], "tb3", "tb3~", 1);
        AddItem(3, 4, rfSprite[0], "tb4", "tb4~", 1);
    }

    void AddItem(int tableNum, int id, Sprite sprite, string name, string func, int cost)
    {
        DataRow dr = dt[tableNum].NewRow();
        dr["ID"] = id;
        dr["IMAGE"] = sprite;
        dr["NAME"] = name;
        dr["FUNC"] = func;
        dr["COST"] = cost;
        dt[tableNum].Rows.Add(dr);
    }

    public void ChosenCharChange()
    {
        ///isRabbitBtnChosen = !isRabbitBtnChosen;
        UpdateItemPanel();
    }

    public void FaceTab()
    {
        chosenPart = "face";
        UpdateItemPanel();
    }
    public void BodyTab()
    {
        chosenPart = "body";
        UpdateItemPanel();
    }

    public void UpdateItemPanel()
    {
        itemPanel.SetActive(false); 
        itemPanel.SetActive(true);
        ShowItemInfo();
    }
    public void ShowItemInfo()
    {
        string ch = isRabbitBtnChosen? "R":"T";
        string part;
        if (chosenPart == "face") {
            part = "F";
                } 
        else {
            part = "B";
        }
        string tableName = ch + part + "Items";
        for (int i = 0; i < tableNum; i++)
        {
            if(tableName == dt[i].TableName)
            {
                
                itemInfoText.text = tableName;
            }
        }
       
    }
}

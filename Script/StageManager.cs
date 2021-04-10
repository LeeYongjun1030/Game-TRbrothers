using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageManager : MonoBehaviour
{
    public GameObject ScrollView;
    public GameObject stageInfoPanel;
    GameObject scViewContent;
    Button[] stageBtn;
    GameObject[] rockImage;
    int stageNum;
    public int chosenStage;

    // Start is called before the first frame update
    void Awake()
    {
        scViewContent = ScrollView.transform.GetChild(0).GetChild(0).gameObject;
        stageNum = scViewContent.transform.childCount;
        stageBtn = new Button[stageNum];
        rockImage = new GameObject[stageNum];
        for (int i = 0; i < stageNum; i++)
        {
            stageBtn[i] = scViewContent.transform.GetChild(i).GetComponent<Button>();
            stageBtn[i].transform.GetChild(0).GetComponent<Text>().text = i+1+"";
            rockImage[i] = stageBtn[i].transform.GetChild(1).gameObject;
        }

        
    }

    private void Start()
    {
        RockStage();

    }
    void RockStage()
    {

        //도전중인 스테이지인덱스라 이해해야 편함
        int chStage = PlayerPrefs.GetInt("ChallengingStage");

        for (int i = 0; i < stageNum; i++)
        {
            if (i > chStage)
            {
                //이전 스테이지가 클리어되지 않았다면 버튼도 눌려지지 않아야 하고 잠금표시도 되어있어야함.
                stageBtn[i].interactable = false;
                rockImage[i].SetActive(true);
            }
            else
            {
                stageBtn[i].GetComponent<Button>().interactable = true;
                rockImage[i].SetActive(false);
            }
        }
    }

    public void StageBtnClick()
    {
       string tempString = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text;
       chosenStage =int.Parse(tempString);

       stageInfoPanel.SetActive(true);
       stageInfoPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "STGAE " + tempString + " ?";

        //index를 넣어줘야해서 -1
       PlayerPrefs.SetInt("SelectedStage",chosenStage-1);
    }
    public void Tutorial()
    {
        PlayerPrefs.SetInt("SelectedStage",0);
        SceneManager.LoadScene("TutorialScene");

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Stage"+chosenStage);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

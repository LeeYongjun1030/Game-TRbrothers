using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;//전역변수를 위한 인스턴스 생성

    public Text timeNum;
    public GameObject topPanel;
    public Text stageText;
    public GameObject bottomPanel;
    public GameObject failPanel;
    public GameObject clearPanel;
    public int limitTime;
    public GameObject rabbitCoin;
    public GameObject turtleCoin;
    public GameObject coinInfoText;
    public GameObject[] player;
    public GameObject[] cryingPlayer;
    public GameObject flag;
    int activeStageNum;
    private void Awake()
    {
        instance = this;

        string[] temp = SceneManager.GetActiveScene().name.Split('e');

        if (temp[1] == "n")
        {
            stageText.text = "TUTORIAL ";
        }
        else
        {
            stageText.text = "STAGE " + temp[1];
            activeStageNum = int.Parse(temp[1]);
        }
        

        StartCoroutine("CountDown");
    }
  

    IEnumerator CountDown()
    {
        while (limitTime > 0)
        {
            limitTime -= 1;
            timeNum.text = limitTime + "";


            if (limitTime == 0)
            {
                MissionFail();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    void MissionClear()
    {
        if (activeStageNum != 40)
        {
            BGMusicManager.bgmManager.StopBGM();
            EffectSoundManager.soundManager.WinSound();
            bottomPanel.SetActive(false);
            topPanel.SetActive(false);
            clearPanel.SetActive(true);
            player[0].SetActive(false);
            player[1].SetActive(false);

            //ads
            AdmobManager.adManager.ShowBannerAds();

            NextStageUnlock();
        }
        else
        {
            SceneManager.LoadScene("EndingScene");
        }
       
    }
    public void MissionFail()
    {
        BGMusicManager.bgmManager.StopBGM();
        EffectSoundManager.soundManager.DieSound();
        bottomPanel.SetActive(false);
        topPanel.SetActive(false);

        for (int i = 0; i < 2; i++)
        {
            cryingPlayer[i].transform.position = player[i].transform.position;
            cryingPlayer[i].SetActive(true);
            player[i].SetActive(false);

        } 
        Invoke("ShowFailPanel", 2.0f);
    }
    void ShowFailPanel()
    {  //ads
        AdmobManager.adManager.ShowBannerAds();

        EffectSoundManager.soundManager.LoseSound();
        failPanel.SetActive(true);
    }

    void NextStageUnlock()
    {
        //해당 스테이지 첫 클리어시, 다음 스테이지 잠금 해제
        int thisStageIndex = PlayerPrefs.GetInt("SelectedStage");
        int chStageIndex = PlayerPrefs.GetInt("ChallengingStage");

        if (thisStageIndex.Equals(chStageIndex))
        {
            //두 정수가 같다면 도전중인 스테이지를 깼다는 의미. 새로운 스테이지를 열어야 함
            PlayerPrefs.SetInt("ChallengingStage", chStageIndex + 1);
        }

    }
    public void CheckClear()
    {
        if (rabbitCoin.activeSelf&&turtleCoin.activeSelf)
        {
            MissionClear();
            flag.GetComponent<Flag>().ClearSprite();
        }
        else
        {
            StartCoroutine("ShowInfo");
        }
    }
    IEnumerator ShowInfo()
    {
        EffectSoundManager.soundManager.ErrorSound();
        coinInfoText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        coinInfoText.SetActive(false);
        yield return null;
    }
    public void GetCoin(string tag)
    {
        if (tag == "Rabbit")
        {
            rabbitCoin.SetActive(true);
        }
        else
        {
            turtleCoin.SetActive(true);
        }
        
    }
   
    public void SceneChangeToMain()
    {   //ads
        AdmobManager.adManager.ShowScreenAds();

        SceneManager.LoadScene("MainScene");
    }
    public void SceneRestart()
    {   //ads
        AdmobManager.adManager.ShowScreenAds();


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Stage2Start()
    {
        PlayerPrefs.SetInt("SelectedStage", 1);
        SceneManager.LoadScene("Stage2");
    }
    public void NextStageStart()
    {   
        string[] temp  = SceneManager.GetActiveScene().name.Split('e');
        int nextStage = int.Parse(temp[1])+1;

        //index를 넣어줘야해서 -1
        PlayerPrefs.SetInt("SelectedStage", nextStage - 1);


        string nextSceneName = "Stage" + nextStage;
        SceneManager.LoadScene(nextSceneName);
    }
}

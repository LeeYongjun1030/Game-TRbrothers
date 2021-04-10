using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemaManager : MonoBehaviour
{
    public GameObject subCamera;
    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject talkPanel;
    public GameObject btnExpPanel;
    public GameObject changeBtn;
    public GameObject skillBtn;
    public GameObject textObj;
    public Text tutorialText;
    public List<string> talkData;
    public GameObject[] arrow;
    Animator subCameraAnim;
    Transform subCameraTr;
    int i;
    private void Awake()
    {
        subCameraTr = subCamera.transform;
        subCameraAnim = subCamera.GetComponent<Animator>();
        i = 0;
        MakeTalkData();
      Invoke("StartTalk",1.0f);
        
    }

    void MakeTalkData()
    {
        talkData.Add("0:Welcome to Wonder Brothers !");
        talkData.Add("0:This is a tutorial stage.");
        talkData.Add("0:Let me explain the rules of the game.");
        talkData.Add("1:character");
        talkData.Add("0:you have to control both characters.");
        talkData.Add("2:chagneBtn");
        talkData.Add("0:You can select the player through the change button.");
        talkData.Add("3:flag_camera");
        talkData.Add("0:To move on to the next stage, you must touch the flag.");
        talkData.Add("0:But before that, there are some requirements.");
        talkData.Add("4:coin_camera");
        talkData.Add("0:There are two kinds of coins in the map.");
        talkData.Add("0:You must obtain these coins before you reach the flag.");
        talkData.Add("5:obstacle");
        talkData.Add("0:Many obstacles are waiting for you.");
        talkData.Add("6:skillBtn");
        talkData.Add("0:If you touch skill button, The player will throw things.");
        talkData.Add("7:zoomOut");
        talkData.Add("0:That's it! The whole explanation is finished.");
        talkData.Add("0:It looks easy? This game will be harder than you think.");
        talkData.Add("0:Let's get started!");
        talkData.Add("8:game start");

    }
    void StartTalk()
    {
       
        talkPanel.SetActive(true);
        textObj.SetActive(true);
        NextTalk();
       
    }

    public void NextTalk()
    {
        char sp = ':';
        string[] splitedTalk = talkData[i].Split(sp);
        int cinematicEffectIndex = int.Parse(splitedTalk[0]);
        string dialog = splitedTalk[1];
       
        //씨네마틱 효과
        if (cinematicEffectIndex != 0)
        {
            string cinemaName = "Cinema" + cinematicEffectIndex;
            StartCoroutine(cinemaName);
        }
        else
        {
            tutorialText.text = splitedTalk[1];
        }
        i++;
    }

    IEnumerator Cinema1()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        subCamera.SetActive(true);

        yield return null;
    }


    IEnumerator Cinema2()
    {
        yield return new WaitForSeconds(0.2f);
        changeBtn.SetActive(true);
        arrow[0].SetActive(true);
        NextTalk();
       
        yield return null;
    }


    IEnumerator Cinema3()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        changeBtn.SetActive(false);
        subCameraAnim.SetTrigger("Flag");

        yield return null;
    }

    IEnumerator Cinema4()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        subCameraAnim.SetTrigger("Coin");

        yield return null;
    }
    IEnumerator Cinema5()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        subCameraAnim.SetTrigger("Obstacle");

        yield return null;
    }
    IEnumerator Cinema6()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        skillBtn.SetActive(true);
        changeBtn.SetActive(true);
        yield return null;
    }
    IEnumerator Cinema7()
    {
        yield return new WaitForSeconds(0.2f);
        NextTalk();
        subCameraAnim.SetTrigger("ZoomOut");
        btnExpPanel.SetActive(false);
        yield return null;
    }
    IEnumerator Cinema8()
    {
        yield return new WaitForSeconds(0.2f);
        subCamera.SetActive(false);
        topPanel.SetActive(true);
        bottomPanel.SetActive(true);
        talkPanel.SetActive(false);
        arrow[0].SetActive(true);
        arrow[1].SetActive(false);
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingCinema : MonoBehaviour
{
    public GameObject subCamera;
    public GameObject talkPanel;
    public GameObject textObj;
    public Text tutorialText;
    public List<string> talkData;

    public GameObject endingBlind;
    public GameObject endingText;
    Animator subCameraAnim;
    Transform subCameraTr;
    int i;
    private void Awake()
    {
        subCameraTr = subCamera.transform;
        subCameraAnim = subCamera.GetComponent<Animator>();
        i = 0;
        MakeTalkData();
        Invoke("StartTalk", 7.0f);

    }

    void MakeTalkData()
    {
        talkData.Add("0:Congratulation !");
        talkData.Add("0:You've cleared all the stages!");
        talkData.Add("0:Thank you for enjoying!");
        talkData.Add("0:TR Brothers will return...");
        talkData.Add("0:...maybe..?");
        talkData.Add("1:THE END");
        talkData.Add("0:THE END");


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

        Invoke("NextTalk", 5.0f);
    }

    IEnumerator Cinema1()
    {
        //CancelInvoke();
        yield return new WaitForSeconds(0.2f);
        endingBlind.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        endingText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        GameManager.instance.SceneChangeToMain();
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
  
}

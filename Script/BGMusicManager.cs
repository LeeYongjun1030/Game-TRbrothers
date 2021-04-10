using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMusicManager : MonoBehaviour
{
    public static BGMusicManager bgmManager;//전역변수를 위한 인스턴스 생성
    //clip info
    // 0forest// 1desert// 2ice // 3castle //4auqa //5mine //6sky
    public AudioClip[] audioClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        bgmManager = this;
        audioSource = gameObject.GetComponent<AudioSource>();

        if(SceneManager.GetActiveScene().name != "TutorialScene"&& SceneManager.GetActiveScene().name != "EndingScene")
        {
            string[] temp = SceneManager.GetActiveScene().name.Split('e');
            int stageNum = int.Parse(temp[1]);

            SelectBGM(stageNum);
        }
       
    }

    void SelectBGM(int i)
    {
        //1~ 5 forest
        //6~11 desert
        //12~16 forest
        //17~21 ice
        //22~25 castle
        //26~30 aqua
        //31~35 mine
        //36~ sky
        if (i < 6)
        {
            audioSource.clip = audioClip[0];
            audioSource.Play();

        }
        else if (6 <= i && i <= 11)
        {
            audioSource.clip = audioClip[1];
            audioSource.Play();
        }
        else if (12 <= i && i <= 16)
        {
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        else if (17 <= i && i <= 21)
        {
            audioSource.clip = audioClip[2];
            audioSource.Play();
        }
        else if (22 <= i && i <= 25)
        {
            audioSource.clip = audioClip[3];
            audioSource.Play();
        }
        else if (26<= i && i <= 30)
        {
            audioSource.clip = audioClip[4];
            audioSource.Play();
        }
        else if (31 <= i && i <= 35)
        {
            audioSource.clip = audioClip[5];
            audioSource.Play();
        }
        else if (36 <= i && i <= 40)
        {
            audioSource.clip = audioClip[6];
            audioSource.Play();
        }

    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}

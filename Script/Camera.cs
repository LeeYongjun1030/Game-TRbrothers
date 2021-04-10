using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Camera : MonoBehaviour
{
    public Transform rabbitTr;
    public Transform turtleTr;
    public Move charMove;
    public float MoveSpeed;

    Transform playerTr;
    Transform tr;
    public float cameraX;
    public float cameraY;

    
    Dictionary<int, float[]> stageSizeDic;

    public float maxXsize;
    public float maxYsize;

    private void Awake()
    {
        tr = gameObject.transform;
        StartCoroutine("PlayerPosCheck");

        stageSizeDic = new Dictionary<int, float[]>();
        MakeStageSizeDictionary();
        ApplyStageSize();
    }

    void MakeStageSizeDictionary()
    {
        stageSizeDic.Add(0, new float[] {10.0f, 8.0f}); //tutorial
        stageSizeDic.Add(1, new float[] { 18.0f, 8.0f }); // stage2
        stageSizeDic.Add(2, new float[] { 18.0f, 8.0f }); // stage3
        stageSizeDic.Add(3, new float[] { 18.3f, 15.0f }); // stage4
        stageSizeDic.Add(4, new float[] { 18.0f, 9.0f });//5
        stageSizeDic.Add(5, new float[] { 18.3f, 15.0f });//6
        stageSizeDic.Add(6, new float[] { 23.3f, 8.0f });//7
        stageSizeDic.Add(7, new float[] { 29.3f, 8.0f });//8
        stageSizeDic.Add(8, new float[] { 26.3f, 15.0f });//9
        stageSizeDic.Add(9, new float[] { 31.3f, 15.0f });//10
        stageSizeDic.Add(10, new float[] { 31.3f, 15.0f });//11
        stageSizeDic.Add(11, new float[] { 31.3f, 15.0f });//12
        stageSizeDic.Add(12, new float[] { 37.3f, 15.0f });//13
        stageSizeDic.Add(13, new float[] { 31.3f, 15.0f });//14
        stageSizeDic.Add(14, new float[] { 18.0f, 30.0f });//15
        stageSizeDic.Add(15, new float[] { 40.3f, 15.0f });//16
        stageSizeDic.Add(16, new float[] { 37.0f, 15.0f });//17
        stageSizeDic.Add(17, new float[] { 37.0f, 15.0f });//18
        stageSizeDic.Add(18, new float[] { 37.0f, 40.0f });//19
        stageSizeDic.Add(19, new float[] { 47.0f, 15.0f });//20
        stageSizeDic.Add(20, new float[] { 50.0f, 15.0f });//21
        stageSizeDic.Add(21, new float[] { 35.0f, 15.0f });//22
        stageSizeDic.Add(22, new float[] { 35.0f, 15.0f });//23
        stageSizeDic.Add(23, new float[] { 35.0f, 15.0f });//24
        stageSizeDic.Add(24, new float[] { 35.0f, 15.0f });//25
        stageSizeDic.Add(25, new float[] { 35.0f, 4.0f });//26
        stageSizeDic.Add(26, new float[] { 35.0f, 4.0f });//27
        stageSizeDic.Add(27, new float[] { 35.0f, 4.0f });//28
        stageSizeDic.Add(28, new float[] { 35.0f, 4.0f });//29
        stageSizeDic.Add(29, new float[] { 27.0f, 40.0f });//30
        stageSizeDic.Add(30, new float[] { 50.0f, 30.0f });//31
        stageSizeDic.Add(31, new float[] { 180.0f, 15.0f });//32
        stageSizeDic.Add(32, new float[] { 28.0f, 8.0f });//33
        stageSizeDic.Add(33, new float[] { 14.0f, 13.0f });//34
        stageSizeDic.Add(34, new float[] { 27.0f, 8.0f });//35
        stageSizeDic.Add(35, new float[] { 30.0f, 30.0f });//36
        stageSizeDic.Add(36, new float[] { 38.0f, 25.0f });//37
        stageSizeDic.Add(37, new float[] { 38.0f, 12.0f });//38
        stageSizeDic.Add(38, new float[] { 20.0f, 35.0f });//39
        stageSizeDic.Add(39, new float[] { 42.0f, 16.0f });//40


        stageSizeDic.Add(100, new float[] { 200.0f, 25.0f });//endingScene
    }

    void ApplyStageSize()
    {
        if( SceneManager.GetActiveScene().name != "EndingScene")
        {
            int stageIndex = PlayerPrefs.GetInt("SelectedStage");
            maxXsize = stageSizeDic[stageIndex][0];
            maxYsize = stageSizeDic[stageIndex][1];
        }
        else
        {
            maxXsize = stageSizeDic[100][0];
            maxYsize = stageSizeDic[100][1];
        }
        
    }
    IEnumerator PlayerPosCheck()
    {
        while (true)
        {
            if(charMove.chosenCharacter == "Rabbit")
            {
                playerTr = rabbitTr;
            }
            else
            {
                playerTr = turtleTr;
            }
            cameraX = Mathf.Clamp(playerTr.position.x, 0.0f, maxXsize);
            cameraY = Mathf.Clamp(playerTr.position.y, 0.0f, maxYsize);
            Vector3 target = new Vector3(cameraX, cameraY, -10.0f);

            float dist = Vector3.Distance(tr.position, target);
            tr.position = Vector3.MoveTowards(tr.position, target, MoveSpeed * dist * Time.deltaTime);

            yield return null;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintPakage : MonoBehaviour
{
    public Text hintText;

    Dictionary<int, string> hintDic;
    string stageHint;
  

    // Start is called before the first frame update
    void Start()
    {
        hintDic = new Dictionary<int, string>();
        MakeHintDictionary();
        LoadHint();
    }

    void MakeHintDictionary()
    {
        hintDic.Add(0, "You can move the stone."); //tutorial
        hintDic.Add(1, "Step on the stone."); //2
        hintDic.Add(2, "Move the stone."); //3
        hintDic.Add(3, "Stack."); //4
        hintDic.Add(4, "Turtle is important."); //5
        hintDic.Add(5, "There is a stone."); //6
        hintDic.Add(6, "Rabbit needs stone to go."); //7
        hintDic.Add(7, "Calm down...you can do it."); //8
        hintDic.Add(8, "Rabbit is good at jumping."); //9
        hintDic.Add(9, "The chance is once. The bar does not return."); //10
        hintDic.Add(10, "The jump is actually unnecessary."); //11
        hintDic.Add(11, "You need something to go up."); //12
        hintDic.Add(12, "Watch out the birds. That's it."); //13
        hintDic.Add(13, "Jump is the key."); //14
        hintDic.Add(14, "See the unseen."); //15
        hintDic.Add(15, "Escape is the key."); //16
        hintDic.Add(16, "Turtle first."); //17
        hintDic.Add(17, "Stack."); //18
        hintDic.Add(18, "No other way. Go ahead."); //19
        hintDic.Add(19, "Turtle is busy. Where does he go first?"); //20
        hintDic.Add(20, "Jump is very important."); //21
        hintDic.Add(21, "Rabbit needs something."); //22
        hintDic.Add(22, "Rabbit needs something."); //23
        hintDic.Add(23, "To use the stone, rabbit should receive it."); //24
        hintDic.Add(24, "There is a trick."); //25
        hintDic.Add(25, "Everything has a reason."); //26
        hintDic.Add(26, "Who owns the flag?"); //27
        hintDic.Add(27, "Need agility."); //28
        hintDic.Add(28, "Carry it."); //29
        hintDic.Add(29, "Watch out for starfish."); //30
        hintDic.Add(30, "Find a shortcut."); //31
        hintDic.Add(31, "Don't get off the cart."); //32
        hintDic.Add(32, "To go up, hit and jump quickly."); //33
        hintDic.Add(33, "Cooperation is important. Try many times."); //34
        hintDic.Add(34, "The rabbit needs help to go up. Move turtle."); //35
        hintDic.Add(35, "Hit the cloud."); //36
        hintDic.Add(36, "The rabbit can't touch the flag.. then?"); //37
        hintDic.Add(37, "A stone on a turtle shell."); //38
        hintDic.Add(38, "Turtle leads."); //39
        hintDic.Add(39, "Make stairs for rabbit."); //40 ending
    }

    void LoadHint()
    {
        int stageIndex = PlayerPrefs.GetInt("SelectedStage");
        stageHint = hintDic[stageIndex];
        hintText.text = stageHint;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillBtn : MonoBehaviour, IPointerDownHandler
{
    public Move rabbitMove;
    public Move turtleMove;
    Button btn;
    Image coolTimeImage;
    Animator coolTimeAni;
   
    void Awake()
    {
        btn = gameObject.GetComponent<Button>();
        coolTimeImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        coolTimeAni = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable.Equals(true))
        {
            rabbitMove.Skill();
            turtleMove.Skill();
            StartCoroutine("SkillEffect");
        }
       
    }
   
    IEnumerator SkillEffect()
    {
      
        btn.interactable = false;
        coolTimeAni.SetTrigger("Inactive");
        yield return new WaitForSeconds(1.0f);
        btn.interactable = true;
        
        yield return null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobManager : MonoBehaviour
{
    public static AdmobManager adManager;
    public GameObject bannerObject;
    public GameObject screenObject;
    public GameObject videoAdObject;

    AdmobBanner admobBanner;
    AdmobScreen admobScreen;
    AdmobRewaredAd admobRewardedAd;

    public GameObject hintPanel;
    public GameObject adInfoNotice;

    private void Awake()
    {
        //onestore
        //PlayerPrefs.SetInt("AdDeleted", 1);

        adManager = this;
        admobBanner = bannerObject.GetComponent<AdmobBanner>();
        admobScreen = screenObject.GetComponent<AdmobScreen>();
        admobRewardedAd = videoAdObject.GetComponent<AdmobRewaredAd>();
    }

    public void ShowBannerAds()
    {
        if (PlayerPrefs.GetInt("AdDeleted") != 1)
        {
           // admobBanner.ShowBanner(true);
        }
    }
    public void HideBanner()
    {
        admobBanner.ShowBanner(false);
    }
    public void ShowScreenAds()
    {
        if (PlayerPrefs.GetInt("AdDeleted") != 1)
        {
            //admobScreen.Show();
        }
    }

    public void ShowRewardedVideo()
    {
        if (PlayerPrefs.GetInt("AdDeleted") != 1)
        {//ad is not blocked
            admobRewardedAd.ShowVideoAd();
        }
        else
        {
            //ad is blocked => show hint directly
            EffectSoundManager.soundManager.RewardSound();
            adInfoNotice.SetActive(false);
            hintPanel.SetActive(true);

        }

    }
}

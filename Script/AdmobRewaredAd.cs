using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobRewaredAd : MonoBehaviour
{
   // private readonly string unitID = "ca-app-pub-3308391231186761/1689228919";//free
    private readonly string unitID = "ca-app-pub-3308391231186761/1689228919";//vip

    private readonly string test_unitID = "ca-app-pub-3940256099942544/5224354917";

    private RewardedAd videoAd;
  
    //custom
    public GameObject adInfoNotice;
    public GameObject videoFailedNotice;
    public GameObject hintPanel;


    // Start is called before the first frame update
    void Start()
    {
       
        InitAd();

    }
    private void InitAd()
    {
        string id = Debug.isDebugBuild ? test_unitID : unitID;

        videoAd = new RewardedAd(id);


        // Called when an ad request has successfully loaded.
        videoAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        videoAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        videoAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        videoAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        videoAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        videoAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        videoAd.LoadAd(request);

    }

    public void ShowVideoAd()
    {
        StartCoroutine("ShowRewardedAd");
    }

    public IEnumerator ShowRewardedAd()
    {
        if (videoAd.IsLoaded())
        {
            videoAd.Show();
        }
        yield return null;
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {// Called when an ad request has successfully loaded.

    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        // Called when an ad request failed to load.
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {  // Called when an ad is shown.


      
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    { // Called when an ad request failed to show.
       
        EffectSoundManager.soundManager.ErrorSound();
        videoFailedNotice.SetActive(true);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {  
        adInfoNotice.SetActive(false);
        InitAd();

    }

    public void HandleUserEarnedReward(object sender, Reward args)
    { 
        EffectSoundManager.soundManager.RewardSound();
        adInfoNotice.SetActive(false);
        hintPanel.SetActive(true);
    }
}

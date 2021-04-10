using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdmobScreen : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3308391231186761/7273314818";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd screenAd;

    private void Start()
    {
        InitAd();
    }
    private void InitAd()
    {
        string id = Debug.isDebugBuild ? test_unitID : unitID;

        screenAd = new InterstitialAd(id);

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
    }

    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    public IEnumerator ShowScreenAd()
    {
        if (screenAd.IsLoaded())
        {
            screenAd.Show();
        }
        yield return null;
    }
}

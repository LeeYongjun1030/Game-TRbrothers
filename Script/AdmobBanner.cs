using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdmobBanner : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3308391231186761/4838723163";
    private readonly string test_unitID = "ca-app-pub-3940256099942544/6300978111";

    public BannerView banner;

    public AdPosition position;

    private void Start()
    {
        InitAd();
    }
    private void InitAd()
    {
        string id = Debug.isDebugBuild ? test_unitID : unitID;

        banner = new BannerView(id, AdSize.Banner, position);

        AdRequest request = new AdRequest.Builder().Build();

        if (PlayerPrefs.GetInt("AdDeleted") != 1)
        {
            banner.LoadAd(request);
            ShowBanner(false);
        };
       
    }

    public void ShowBanner(bool active)
    {
        if (active)
        {
            banner.Show();
        }
        else
        {
            banner.Hide();
        }
    }

    public void DestroyAd()
    {
        banner.Destroy();
    }

    void OnDisable()
    {
        banner.Destroy();

    }
}

using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class UnityAds : MonoBehaviour
{

    public static UnityAds ads;
    public string rewardZone;

    void Start()
    {
        ads = this;

        if (Application.platform == RuntimePlatform.Android)
        {
            Advertisement.Initialize("1252986", false);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Advertisement.Initialize("1252987", false);
        }
        else
        {
            Advertisement.Initialize("1252987", false);
        }

    }

    public void ShowAd()
    {

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackHandler;

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

    }

    void AdCallbackHandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}

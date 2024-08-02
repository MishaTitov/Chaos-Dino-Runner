using GoogleMobileAds.Api;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    [SerializeField] TextMeshProUGUI textAdStatus;

    //#if UNITY_EDITOR
    //    private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    //    private string rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";
    //#elif UNITY_ANDROID
    //    private string bannerAdUnitId = "ca-app-pub-8217856609214846/2932003564";
    //    private string rewardedAdUnitId = "ca-app-pub-8217856609214846/9692250397";
    //#endif

    // for tests
    //private string rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917";
    //private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
    // real ones
    private string rewardedAdUnitId = "ca-app-pub-8217856609214846/9692250397";
    private string bannerAdUnitId = "ca-app-pub-8217856609214846/2932003564";

    private RewardedAd rewardedAd;
    private BannerView bannerAd;


    // Your AdsManager implementation...

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            RequestBannerAd();
            LoadRewardedAd();
        }
        else if (bannerAd != null)
        {
            bannerAd.Destroy();
            bannerAd = null;
        }
        textAdStatus.enabled = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }

    private void HandleSceneLoaded(Scene scene, LoadSceneMode mdoe)
    {
        if (scene.buildIndex == 1)
        {
            RequestBannerAd();
            LoadRewardedAd();

        }
        else if (bannerAd != null)
        {
            bannerAd.Destroy();
            bannerAd = null;
        }
    }

    private void RequestBannerAd()
    {
        if (bannerAd != null)
        {
            bannerAd.Destroy();
            bannerAd = null;
        }

        bannerAd = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest();

        bannerAd.LoadAd(request);
    }

    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            //rewardedAd.OnAdFullScreenContentClosed -= HandleAdFullScreenContentClosed;
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        AdRequest adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(rewardedAdUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
                RegisterEventHandlers(rewardedAd);
            });
    }

    private void CheckRewardedAdIsReady()
    {
        if (rewardedAd == null)
            LoadRewardedAd();
        if (rewardedAd.CanShowAd())
            return;
        WaitForRewardedAd();
    }


    //TODO add some text for add
    IEnumerator WaitForRewardedAd()
    {
        textAdStatus.enabled = true;
        // Wait until the rewarded ad is ready to show
        while (!rewardedAd.CanShowAd())
        {
            yield return null;
        }
        textAdStatus.enabled = false;
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg = "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        CheckRewardedAdIsReady();

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            HandleAdFullScreenContentClosed();
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
            HandleAdFullScreenContentClosed();
            LoadRewardedAd();
        };
    }

    private void HandleAdFullScreenContentClosed()
    {
        Time.timeScale = 1f;
        AudioManager.instance.PlayDefaultMusic();
        GameManager.instance.isGameOver = false;
    }
}
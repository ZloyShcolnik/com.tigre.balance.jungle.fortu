using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement; // ��� ������ � ���������� ����� �������

public class AdmobAdsManager : MonoBehaviour
{
    private static AdmobAdsManager Instance { get; set; }

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    // ������� ��� ������������ ����� ����
    private int sceneCount = 0;
    private int sceneThreshold = 3; // ����� � 3 ����� ����� ������� �������

    // ������� ���� ��������� ID ��� Android � iOS
#if UNITY_ANDROID
    private string bannerAdUnitId = "ca-app-pub-8810509868076536/9080809944";
    private string interstitialAdUnitId = "ca-app-pub-8810509868076536/7116991581";
#elif UNITY_IPHONE
    private string bannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string bannerAdUnitId = "unused";
    private string interstitialAdUnitId = "unused";
#endif

    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // ������������� SDK
        MobileAds.Initialize(initStatus => {
            Debug.Log("Google Mobile Ads SDK Initialized");
        });

        // ������������� �� ������� ����� �����
        SceneManager.activeSceneChanged += OnSceneChanged;

        // ������ �� �������� ������� � ������������� �������
        RequestBannerAd();
        RequestInterstitialAd();
    }

    // �����, ���������� ��� ����� �����
    private void OnSceneChanged(Scene current, Scene next)
    {
        sceneCount++;

        if (sceneCount >= sceneThreshold)
        {
            sceneCount = 0; // ���������� �������
            ShowInterstitialAd(); // ���������� �������
        }
    }

    // ������ ��������� �������
    private void RequestBannerAd()
    {
        // ���������� ������ ������, ���� �� ����������
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }

        // ������� ����� ������ ����� ������
        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

        // �������� �� �������
        bannerView.OnBannerAdLoaded += OnBannerAdLoaded;
        bannerView.OnBannerAdLoadFailed += OnBannerAdLoadFailed;
        bannerView.OnAdClicked += OnBannerAdClicked;
        bannerView.OnAdImpressionRecorded += OnBannerAdImpressionRecorded;

        // ������� � ��������� ��������� ������
        AdRequest request = new AdRequest();
        bannerView.LoadAd(request);
    }

    // ������ ������������� �������
    private void RequestInterstitialAd()
    {
        // ���������� ������ �������, ���� ��� ����������
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        // ��������� ������������� �������
        InterstitialAd.Load(interstitialAdUnitId, new AdRequest(),
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("Interstitial ad failed to load with error: " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded successfully.");
                interstitialAd = ad;

                // ������������� �� ������� ������������� �������
                interstitialAd.OnAdFullScreenContentClosed += OnInterstitialAdClosed;
                interstitialAd.OnAdFullScreenContentFailed += OnInterstitialAdFailed;
                interstitialAd.OnAdPaid += OnInterstitialAdPaid;
            });
    }

    // ����� ������������� �������
    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    // ����������� ������� ��������� �������
    private void OnBannerAdLoaded()
    {
        Debug.Log("Banner ad loaded successfully.");
    }

    private void OnBannerAdLoadFailed(LoadAdError error)
    {
        Debug.LogError("Banner ad failed to load with error: " + error);
    }

    private void OnBannerAdClicked()
    {
        Debug.Log("Banner ad was clicked.");
    }

    private void OnBannerAdImpressionRecorded()
    {
        Debug.Log("Banner ad impression recorded.");
    }

    // ����������� ������� ������������� �������
    private void OnInterstitialAdClosed()
    {
        Debug.Log("Interstitial ad closed.");
        RequestInterstitialAd();  // ��������� ��������� �������
    }

    private void OnInterstitialAdFailed(AdError error)
    {
        Debug.LogError("Interstitial ad failed with error: " + error);
        RequestInterstitialAd();  // ��������� ��������� �������
    }

    private void OnInterstitialAdPaid(AdValue adValue)
    {
        Debug.Log($"Interstitial ad paid {adValue.Value} {adValue.CurrencyCode}");
    }

    private void OnDestroy()
    {
        // ������������ �� ������� ����� �����
        SceneManager.activeSceneChanged -= OnSceneChanged;

        // ���������� �������, ����� �������� ������ ������
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }
}
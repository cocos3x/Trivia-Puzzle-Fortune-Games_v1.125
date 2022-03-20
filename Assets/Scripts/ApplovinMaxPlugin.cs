using UnityEngine;
public class ApplovinMaxPlugin : MonoSingleton<ApplovinMaxPlugin>
{
    // Fields
    private ApplovinMaxPlugin.BannerState currentBannerState;
    private ApplovinMaxPlugin.BannerState setBannerState;
    private static int frameSkipValue;
    private bool forceRefresh;
    private static string bannerAdUnitId;
    private static string rewardedAdUnitId;
    private static string interstitialAdUnitId;
    private static bool adUnitsSet;
    private static bool initialized;
    public System.Action<bool> BannerAdsStateChanged;
    public System.Action<bool> RewardVideoLoaded;
    private static bool bannersFetched;
    private UnityEngine.Rect bannerDimenions;
    public System.Action<bool> IncentivizedVideoCallback;
    private HeyZapAdTag currentVideoAdTag;
    private bool hack_noVideoAdsAvailable;
    private System.Action<bool> InterstitialCallback;
    
    // Properties
    private static int RetryLoadAd { get; }
    private float tabletBannerHeight { get; }
    private float phoneBannerHeight { get; }
    public UnityEngine.Rect BannerDimensions { get; }
    
    // Methods
    private static int get_RetryLoadAd()
    {
        return 2;
    }
    private float get_tabletBannerHeight()
    {
        float val_2 = 0.092f;
        val_2 = (float)UnityEngine.Screen.height * val_2;
        return (float)val_2;
    }
    private float get_phoneBannerHeight()
    {
        float val_2 = 0.092f;
        val_2 = (float)UnityEngine.Screen.height * val_2;
        return (float)val_2;
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        this.AddBannerConsumer();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.InitializeSDK());
    }
    private void InitializeMediation()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.InitializeSDK());
    }
    private System.Collections.IEnumerator InitializeSDK()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ApplovinMaxPlugin.<InitializeSDK>d__18();
    }
    private void AddBannerConsumer()
    {
        UnityEngine.SceneManagement.SceneManager.add_sceneLoaded(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>(object:  this, method:  System.Void ApplovinMaxPlugin::OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)));
        FrameSkipper val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_3._framesToSkip = ApplovinMaxPlugin.frameSkipValue;
        val_3.updateLogic = new System.Action(object:  this, method:  System.Void ApplovinMaxPlugin::ConsumeBannerState());
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        this.forceRefresh = true;
    }
    private void ConsumeBannerState()
    {
        if(this.currentBannerState == this.setBannerState)
        {
                if(this.forceRefresh == false)
        {
                return;
        }
        
        }
        
        this.currentBannerState = this.setBannerState;
        if(this.setBannerState == 1)
        {
                this.ShowBannerFromMediation();
        }
        else
        {
                this.HideBannerFromMediation(destroy:  false);
        }
        
        this.forceRefresh = false;
    }
    private void OnSDKInitialized(MaxSdkBase.SdkConfiguration obj)
    {
        MaxSdkAndroid.SetHasUserConsent(hasUserConsent:  true);
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.InitializeInterstitials());
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.InitializeBanners());
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.InitializeRewardedVideos());
    }
    private void SetFANTrackingFlag(MaxSdkBase.SdkConfiguration obj)
    {
    
    }
    private void SetupAdUnits()
    {
        var val_4;
        AppConfigs val_1 = App.Configuration;
        val_4 = null;
        val_4 = null;
        ApplovinMaxPlugin.bannerAdUnitId = null;
        AppConfigs val_2 = App.Configuration;
        ApplovinMaxPlugin.interstitialAdUnitId = val_2.appConfig.Free_Android;
        AppConfigs val_3 = App.Configuration;
        ApplovinMaxPlugin.rewardedAdUnitId = val_3.appConfig.Free_Android;
        ApplovinMaxPlugin.adUnitsSet = true;
    }
    private void PauseAudio(bool pause)
    {
        if((MonoSingleton<WGAudioController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGAudioController>.Instance.ToggleMute(mute:  pause);
    }
    public void ShowAdMediationSuite()
    {
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        MaxSdkAndroid.ShowMediationDebugger();
    }
    public UnityEngine.Rect get_BannerDimensions()
    {
        return new UnityEngine.Rect() {m_XMin = this.bannerDimenions};
    }
    public void ShowBanner()
    {
        this.setBannerState = 1;
    }
    private void ShowBannerFromMediation()
    {
        var val_3;
        var val_5;
        var val_6;
        var val_7;
        string val_8;
        BannerPosition val_9;
        var val_10;
        val_3 = null;
        val_3 = null;
        if(ApplovinMaxPlugin.initialized == false)
        {
                return;
        }
        
        if(ApplovinMaxPlugin.adUnitsSet == false)
        {
                return;
        }
        
        this.ResizeBannerAndNotify();
        val_5 = null;
        val_5 = null;
        if(ApplovinMaxPlugin.bannersFetched != true)
        {
                GameBehavior val_1 = App.getBehavior;
            val_6 = null;
            if((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField, b:  "BOTTOM")) != false)
        {
                val_7 = null;
            val_8 = ApplovinMaxPlugin.bannerAdUnitId;
            val_9 = 7;
        }
        else
        {
                val_10 = null;
            val_8 = ApplovinMaxPlugin.bannerAdUnitId;
            val_9 = 1;
        }
        
            MaxSdkAndroid.CreateBanner(adUnitIdentifier:  val_8, bannerPosition:  val_9);
            val_5 = null;
            val_5 = null;
            ApplovinMaxPlugin.bannersFetched = true;
        }
        
        val_5 = null;
        MaxSdkAndroid.ShowBanner(adUnitIdentifier:  ApplovinMaxPlugin.bannerAdUnitId);
    }
    private void ResizeBannerAndNotify()
    {
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        bool val_2 = this.IsTablet();
        float val_6 = (float)UnityEngine.Screen.height;
        val_6 = val_6 * 0.092f;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  val_6);
        UnityEngine.Rect val_5 = new UnityEngine.Rect(position:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, size:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
        this.bannerDimenions = val_5.m_XMin;
        if(this.BannerAdsStateChanged == null)
        {
                return;
        }
        
        this.BannerAdsStateChanged.Invoke(obj:  true);
    }
    private bool IsTablet()
    {
        var val_8;
        float val_9;
        var val_10;
        if(UnityEngine.Application.platform != 11)
        {
                if(UnityEngine.Application.platform != 8)
        {
            goto label_2;
        }
        
        }
        
        val_8 = UnityEngine.Screen.width;
        float val_9 = (float)UnityEngine.Screen.height;
        float val_8 = (float)val_8;
        val_8 = val_8 / UnityEngine.Screen.dpi;
        val_8 = val_8 * val_8;
        val_9 = (val_9 / UnityEngine.Screen.dpi) * (val_9 / UnityEngine.Screen.dpi);
        val_9 = val_8 + val_9;
        if(val_8 >= _TYPE_MAX_)
        {
                val_9 = val_9;
        }
        
        if(val_9 < 6.5f)
        {
                label_2:
            val_10 = 0;
            return (bool)val_10;
        }
        
        val_10 = 1;
        return (bool)val_10;
    }
    public void HideBanner()
    {
        this.setBannerState = 2;
        if(this.BannerAdsStateChanged == null)
        {
                return;
        }
        
        this.BannerAdsStateChanged.Invoke(obj:  false);
    }
    private void HideBannerFromMediation(bool destroy = False)
    {
        var val_2;
        var val_4;
        var val_5;
        var val_6;
        val_2 = null;
        val_2 = null;
        if(ApplovinMaxPlugin.initialized == false)
        {
                return;
        }
        
        if(ApplovinMaxPlugin.adUnitsSet == false)
        {
                return;
        }
        
        if(DeviceIdPlugin.IsEmulator() != false)
        {
                return;
        }
        
        val_4 = null;
        if(destroy != false)
        {
                val_5 = null;
            MaxSdkAndroid.DestroyBanner(adUnitIdentifier:  ApplovinMaxPlugin.bannerAdUnitId);
            return;
        }
        
        val_6 = null;
        MaxSdkAndroid.HideBanner(adUnitIdentifier:  ApplovinMaxPlugin.bannerAdUnitId);
    }
    private System.Collections.IEnumerator InitializeBanners()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ApplovinMaxPlugin.<InitializeBanners>d__39();
    }
    private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        this.TrackAdRevenuePaid(revenue:  adInfo.<Revenue>k__BackingField, adType:  "Banner");
    }
    private void MaxSdkCallbacks_OnBannerAdLoadedEvent(string obj)
    {
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = null;
        val_2 = null;
        App.trackerManager.track(eventName:  Events.AD_SEEN_NON_REWARDED);
        val_3 = null;
        val_3 = null;
        App.trackerManager.track(eventName:  Events.AD_SEEN_ALL);
        val_4 = null;
        val_4 = null;
        App.trackerManager.track(eventName:  Events.AD_SEEN_BANNER);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "TYPE", value:  "Banner");
        val_5 = null;
        val_5 = null;
        App.trackerManager.track(eventName:  "Ad Display", data:  val_1);
    }
    private void MaxSdkCallbacks_OnBannerAdExpandedEvent(string obj)
    {
    
    }
    private void MaxSdkCallbacks_OnBannerAdCollapsedEvent(string obj)
    {
    
    }
    private void MaxSdkCallbacks_OnBannerAdClickedEvent(string obj)
    {
        var val_4;
        TrackingComponent.CurrentIntent = 3;
        WGGenericNotificationsManager.SendPostAdNotification(QAHACK_Force:  false);
        Player val_1 = App.Player;
        int val_4 = val_1.num_ad_clicks;
        val_4 = val_4 + 1;
        val_1.num_ad_clicks = val_4;
        Player val_2 = App.Player;
        if(val_2.total_purchased <= 0f)
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "altPayer", value:  1);
        }
        
        TrackAdsClicked();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "TYPE", value:  "Banner");
        val_4 = null;
        val_4 = null;
        App.trackerManager.track(eventName:  "Ad Clicked", data:  val_3);
    }
    private void MaxSdkCallbacks_OnBannerAdLoadFailedEvent(string arg1, int arg2)
    {
        this.HideBanner();
        if(this.BannerAdsStateChanged == null)
        {
                return;
        }
        
        this.BannerAdsStateChanged.Invoke(obj:  false);
    }
    public void SetIncentivizedVideoCallback(System.Action<bool> callback)
    {
        this.IncentivizedVideoCallback = callback;
    }
    public bool ShowVideo(HeyZapAdTag heyZapAdTag)
    {
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        val_8 = 0;
        if(this.hack_noVideoAdsAvailable == true)
        {
                return (bool)val_8;
        }
        
        this.currentVideoAdTag = heyZapAdTag;
        val_7 = 1152921504888156160;
        val_9 = null;
        val_9 = null;
        if((MaxSdkAndroid.IsRewardedAdReady(adUnitIdentifier:  ApplovinMaxPlugin.rewardedAdUnitId)) == false)
        {
            goto label_6;
        }
        
        TrackingComponent.CurrentIntent = 3;
        this.PauseAudio(pause:  true);
        val_10 = null;
        val_10 = null;
        MaxSdkAndroid.ShowRewardedAd(adUnitIdentifier:  ApplovinMaxPlugin.rewardedAdUnitId, placement:  0, customData:  0);
        val_11 = null;
        val_11 = null;
        App.trackerManager.track(eventName:  Events.AD_SEEN_ALL);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "TYPE", value:  "Video");
        if((this.currentVideoAdTag | 2) != 3)
        {
            goto label_22;
        }
        
        val_12 = 1;
        goto label_23;
        label_6:
        val_8 = 0;
        mem[1152921515683672176] = 0;
        return (bool)val_8;
        label_22:
        label_23:
        val_2.Add(key:  "Ads Control", value:  (this.currentVideoAdTag == 2) ? 1 : 0.ToString());
        val_7 = mem[1152921515683672176];
        mem[1152921515683672176] = 1179403647;
        val_2.Add(key:  "Entry_Point", value:  mem[1152921515683672176].ToString());
        val_13 = null;
        val_13 = null;
        App.trackerManager.track(eventName:  "Ad Display", data:  val_2);
        val_8 = 1;
        return (bool)val_8;
    }
    public bool IsVideoAvailable()
    {
        null = null;
        bool val_1 = MaxSdkAndroid.IsRewardedAdReady(adUnitIdentifier:  ApplovinMaxPlugin.rewardedAdUnitId);
        if(val_1 != true)
        {
                val_1.LoadRewardedVideo();
        }
        
        val_1 = val_1;
        return (bool)val_1;
    }
    public void Hack_NoVideoAdsAvailable()
    {
        bool val_1 = this.hack_noVideoAdsAvailable;
        val_1 = val_1 ^ 1;
        this.hack_noVideoAdsAvailable = val_1;
    }
    private System.Collections.IEnumerator InitializeRewardedVideos()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ApplovinMaxPlugin.<InitializeRewardedVideos>d__53();
    }
    private void OnVideoRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adinfo)
    {
        this.TrackAdRevenuePaid(revenue:  adinfo.<Revenue>k__BackingField, adType:  "Rewarded Video");
    }
    private void TrackAdRevenuePaid(double revenue, string adType)
    {
        var val_2;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "Ad Type", value:  adType);
        val_1.Add(key:  "Revenue", value:  revenue);
        val_1.Add(key:  "$revenue", value:  revenue);
        val_1.Add(key:  "$quantity", value:  1);
        val_1.Add(key:  "price", value:  revenue);
        val_2 = null;
        val_2 = null;
        App.trackerManager.track(eventName:  Events.AD_REVENUE, data:  val_1);
    }
    private void LoadRewardedVideo()
    {
        null = null;
        MaxSdkAndroid.LoadRewardedAd(adUnitIdentifier:  ApplovinMaxPlugin.rewardedAdUnitId);
    }
    private void MaxSdkCallbacks_OnRewardedAdDisplayedEvent(string obj)
    {
    
    }
    private void OnVideoLoaded(string adUnitId)
    {
        if(this.RewardVideoLoaded == null)
        {
                return;
        }
        
        this.RewardVideoLoaded.Invoke(obj:  true);
    }
    private void OnVideoHidden(string adUnitId)
    {
        this.LoadRewardedVideo();
        this.PauseAudio(pause:  false);
    }
    private void OnVideoLoadFailed(string adUnitId, int errorCode)
    {
        if(this.RewardVideoLoaded != null)
        {
                this.RewardVideoLoaded.Invoke(obj:  false);
        }
        
        this.Invoke(methodName:  "LoadRewardedVideo", time:  2f);
    }
    private void OnVideoFailedToShow(string adUnitId, int errorCode)
    {
        this.LoadRewardedVideo();
    }
    private void OnVideoClicked(string adUnitId)
    {
        var val_5;
        TrackingComponent.CurrentIntent = 3;
        WGGenericNotificationsManager.SendPostAdNotification(QAHACK_Force:  false);
        Player val_1 = App.Player;
        int val_5 = val_1.num_ad_clicks;
        val_5 = val_5 + 1;
        val_1.num_ad_clicks = val_5;
        Player val_2 = App.Player;
        if(val_2.total_purchased <= 0f)
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "altPayer", value:  1);
        }
        
        TrackAdsClicked();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "TYPE", value:  "Video");
        mem2[0] = this.currentVideoAdTag;
        val_3.Add(key:  "Entry_Point", value:  this.currentVideoAdTag.ToString());
        val_5 = null;
        val_5 = null;
        App.trackerManager.track(eventName:  "Ad Clicked", data:  val_3);
    }
    private void OnVideoRewardReceived(string adUnitId, MaxSdkBase.Reward reward)
    {
        var val_2;
        if(this.IncentivizedVideoCallback != null)
        {
                this.IncentivizedVideoCallback.Invoke(obj:  true);
        }
        
        val_2 = null;
        val_2 = null;
        App.trackerManager.track(eventName:  Events.AD_SEEN_REW_VID);
        Player val_1 = App.Player;
        int val_2 = val_1.properties.incentivisedVideosWatched;
        val_2 = val_2 + 1;
        val_1.properties.incentivisedVideosWatched = val_2;
        val_1.LoadRewardedVideo();
        val_1.PauseAudio(pause:  false);
        val_1.TrackRewardVidsSeen();
    }
    public void SetInterstitialCallback(System.Action<bool> action)
    {
        this.InterstitialCallback = action;
    }
    public void CheckInterstitialAvailable()
    {
        var val_3;
        if(DeviceIdPlugin.IsEmulator() == true)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        bool val_2 = MaxSdkAndroid.IsInterstitialReady(adUnitIdentifier:  ApplovinMaxPlugin.interstitialAdUnitId);
        if(val_2 != false)
        {
                return;
        }
        
        val_2.LoadInterstitial();
    }
    public bool ShowInterstitial(InterstitialContext context = 2)
    {
        string val_7;
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        if(DeviceIdPlugin.IsEmulator() != true)
        {
                val_8 = null;
            val_8 = null;
            val_7 = ApplovinMaxPlugin.interstitialAdUnitId;
            if((MaxSdkAndroid.IsInterstitialReady(adUnitIdentifier:  val_7)) != false)
        {
                val_9 = null;
            val_9 = null;
            App.trackerManager.track(eventName:  Events.AD_SEEN_ALL);
            val_10 = null;
            val_10 = null;
            App.trackerManager.track(eventName:  Events.AD_SEEN_NON_REWARDED);
            val_11 = null;
            val_11 = null;
            App.trackerManager.track(eventName:  Events.AD_SEEN_INT);
            App.trackerManager.PauseAudio(pause:  true);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_3.Add(key:  "TYPE", value:  "Interstitial");
            val_12 = null;
            val_12 = null;
            App.trackerManager.track(eventName:  "Ad Display", data:  val_3);
            TrackingComponent.CurrentIntent = 3;
            if(App.Player <= 29)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_13 = null;
            val_13 = null;
            AdInfo val_6 = MaxSdkAndroid.GetAdInfo(adUnitIdentifier:  ApplovinMaxPlugin.interstitialAdUnitId);
            val_5.Add(key:  "Creative ID", value:  val_6.<CreativeIdentifier>k__BackingField);
            val_14 = null;
            val_14 = null;
            App.trackerManager.track(eventName:  "Interstitial Shown", data:  val_5);
        }
        
            val_15 = null;
            val_15 = null;
            val_7 = ApplovinMaxPlugin.interstitialAdUnitId;
            MaxSdkAndroid.ShowInterstitial(adUnitIdentifier:  val_7, placement:  0, customData:  0);
            val_16 = 1;
            return (bool)val_16;
        }
        
        }
        
        val_16 = 0;
        return (bool)val_16;
    }
    private System.Collections.IEnumerator InitializeInterstitials()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ApplovinMaxPlugin.<InitializeInterstitials>d__68();
    }
    private void LoadInterstitial()
    {
        if(ApplovinMaxPlugin.initialized == false)
        {
                return;
        }
        
        null = null;
        if(ApplovinMaxPlugin.adUnitsSet == false)
        {
                return;
        }
        
        MaxSdkAndroid.LoadInterstitial(adUnitIdentifier:  ApplovinMaxPlugin.interstitialAdUnitId);
    }
    private void OnInterstitialLoaded(string adUnit)
    {
    
    }
    private void OnInterstitialFailed(string adUnit, int errorCode)
    {
        this.Invoke(methodName:  "LoadInterstitial", time:  2f);
    }
    private void OnInterstitialFailedToDisplay(string adUnit, int errorCode)
    {
        this.Invoke(methodName:  "LoadInterstitial", time:  2f);
        this.InterstitialCallback.Invoke(obj:  false);
    }
    private void OnInterstitialHidden(string adUnit)
    {
        this.Invoke(methodName:  "LoadInterstitial", time:  2f);
        this.PauseAudio(pause:  false);
        this.InterstitialCallback.Invoke(obj:  false);
    }
    private void OnInterstitialDisplayedEvent(string adUnit)
    {
        this.InterstitialCallback.Invoke(obj:  true);
    }
    private void OnInterstitialClicked(string adUnitClicked)
    {
        var val_4;
        TrackingComponent.CurrentIntent = 3;
        WGGenericNotificationsManager.SendPostAdNotification(QAHACK_Force:  false);
        Player val_1 = App.Player;
        int val_4 = val_1.num_ad_clicks;
        val_4 = val_4 + 1;
        val_1.num_ad_clicks = val_4;
        Player val_2 = App.Player;
        if(val_2.total_purchased <= 0f)
        {
                UnityEngine.PlayerPrefs.SetInt(key:  "altPayer", value:  1);
        }
        
        TrackAdsClicked();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "TYPE", value:  "Interstitial");
        val_4 = null;
        val_4 = null;
        App.trackerManager.track(eventName:  "Ad Clicked", data:  val_3);
    }
    private void OnInterstitialAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        this.TrackAdRevenuePaid(revenue:  adInfo.<Revenue>k__BackingField, adType:  "Interstitial");
    }
    private void TrackAdsClicked()
    {
        var val_8;
        TrackerManager val_9;
        string val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        Player val_1 = App.Player;
        if(val_1.num_ad_clicks == 5)
        {
                val_8 = null;
            val_8 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_05;
        }
        else
        {
                Player val_2 = App.Player;
            if(val_2.num_ad_clicks == 10)
        {
                val_11 = null;
            val_11 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_10;
        }
        else
        {
                Player val_3 = App.Player;
            if(val_3.num_ad_clicks == 15)
        {
                val_12 = null;
            val_12 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_15;
        }
        else
        {
                Player val_4 = App.Player;
            if(val_4.num_ad_clicks == 20)
        {
                val_13 = null;
            val_13 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_20;
        }
        else
        {
                Player val_5 = App.Player;
            if(val_5.num_ad_clicks == 30)
        {
                val_14 = null;
            val_14 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_30;
        }
        else
        {
                Player val_6 = App.Player;
            if(val_6.num_ad_clicks == 50)
        {
                val_15 = null;
            val_15 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_50;
        }
        else
        {
                Player val_7 = App.Player;
            if(val_7.num_ad_clicks != 100)
        {
                return;
        }
        
            val_16 = null;
            val_16 = null;
            val_9 = App.trackerManager;
            val_10 = Events.AD_CLICK_100;
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        val_9.track(eventName:  val_10);
    }
    private void TrackRewardVidsSeen()
    {
        TrackerManager val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        Player val_1 = App.Player;
        if(val_1.properties.incentivisedVideosWatched == 5)
        {
                val_11 = null;
            val_11 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_05);
        }
        
        Player val_2 = App.Player;
        if(val_2.properties.incentivisedVideosWatched == 10)
        {
                val_12 = null;
            val_12 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_10);
        }
        
        Player val_3 = App.Player;
        if(val_3.properties.incentivisedVideosWatched == 15)
        {
                val_13 = null;
            val_13 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_15);
        }
        
        Player val_4 = App.Player;
        if(val_4.properties.incentivisedVideosWatched == 20)
        {
                val_14 = null;
            val_14 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_20);
        }
        
        Player val_5 = App.Player;
        if(val_5.properties.incentivisedVideosWatched == 25)
        {
                val_15 = null;
            val_15 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_25);
        }
        
        Player val_6 = App.Player;
        if(val_6.properties.incentivisedVideosWatched == 50)
        {
                val_16 = null;
            val_16 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_50);
        }
        
        Player val_7 = App.Player;
        if(val_7.properties.incentivisedVideosWatched == 100)
        {
                val_17 = null;
            val_17 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_100);
        }
        
        Player val_8 = App.Player;
        if(val_8.properties.incentivisedVideosWatched == 250)
        {
                val_18 = null;
            val_18 = null;
            val_10 = App.trackerManager;
            val_10.track(eventName:  Events.REW_VID_250);
        }
        
        Player val_9 = App.Player;
        if(val_9.properties.incentivisedVideosWatched != 500)
        {
                return;
        }
        
        val_19 = null;
        val_19 = null;
        App.trackerManager.track(eventName:  Events.REW_VID_500);
    }
    public ApplovinMaxPlugin()
    {
        this.currentBannerState = 2;
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
        UnityEngine.Rect val_3 = new UnityEngine.Rect(position:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, size:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
        this.bannerDimenions = val_3.m_XMin;
    }
    private static ApplovinMaxPlugin()
    {
        ApplovinMaxPlugin.frameSkipValue = 90;
        ApplovinMaxPlugin.bannerAdUnitId = "";
        ApplovinMaxPlugin.rewardedAdUnitId = "";
        ApplovinMaxPlugin.interstitialAdUnitId = "";
        ApplovinMaxPlugin.adUnitsSet = false;
        ApplovinMaxPlugin.initialized = false;
        ApplovinMaxPlugin.bannersFetched = false;
    }

}

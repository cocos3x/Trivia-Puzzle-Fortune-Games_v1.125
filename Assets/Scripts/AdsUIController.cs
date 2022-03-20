using UnityEngine;
public class AdsUIController : MonoSingleton<AdsUIController>
{
    // Fields
    private bool showAdsOnDataReady;
    private bool toggleAdsOnSceneChange;
    private AdsUIController_BannerAds bannerController;
    private AdsUIController_Gameplay gameplayController;
    private WGLobbyRightColUIController wgLobbyRightColUIController;
    private WGLobbyRightColUIController levelCompleteRightColUIController;
    private const string Pref_SeenAdsControl = "seen_adscontrol";
    private const string Pref_SeenAdsControlDate = "seen_ads_date";
    private const string Pref_SeenFreeHint = "seen_freehint";
    private const string Pref_SeenPostLevelOffer = "seen_postlevel";
    private int bannerAdsUnblocked;
    public const string OnVideoResponse = "OnVideoResponse";
    public const string Event_OnCanvasResized = "OnCanvasResized";
    public const string OnInterstitialResponse = "OnInterstitialResponse";
    public UnityEngine.Events.UnityEvent onAdToggled;
    
    // Properties
    public UnityEngine.GameObject HintButtonGroup { get; }
    public UnityEngine.GameObject MegaHintButtonGroup { get; }
    public UnityEngine.GameObject PickerHintButtonGroup { get; }
    public UnityEngine.GameObject FreeHintButtonGroup { get; }
    public UnityEngine.GameObject ShuffleButtonGroup { get; }
    public WGLobbyRightColUIController LevelCompleteRightColUIController { set; }
    public bool BannerAdsUnblocked { set; }
    public bool BannerAdsBlockedByUI { get; }
    public static bool AdsAllowed { get; }
    public bool BannerAdsAllowed { get; }
    private bool InterstitialAdsAllowed { get; }
    public bool VideoAdsAllowed { get; }
    
    // Methods
    public UnityEngine.GameObject get_HintButtonGroup()
    {
        if(this.gameplayController == 0)
        {
                return 0;
        }
        
        0 = this.gameplayController.hintButtonGroup;
        return 0;
    }
    public UnityEngine.GameObject get_MegaHintButtonGroup()
    {
        if(this.gameplayController == 0)
        {
                return 0;
        }
        
        0 = this.gameplayController.megaHintButtonGroup;
        return 0;
    }
    public UnityEngine.GameObject get_PickerHintButtonGroup()
    {
        if(this.gameplayController == 0)
        {
                return 0;
        }
        
        0 = this.gameplayController.pickerHintButtonGroup;
        return 0;
    }
    public UnityEngine.GameObject get_FreeHintButtonGroup()
    {
        if(this.gameplayController == 0)
        {
                return 0;
        }
        
        0 = this.gameplayController.incentivizedButton;
        return 0;
    }
    public UnityEngine.GameObject get_ShuffleButtonGroup()
    {
        if(this.gameplayController == 0)
        {
                return 0;
        }
        
        0 = this.gameplayController.shuffleButtonGroup;
        return 0;
    }
    public void set_LevelCompleteRightColUIController(WGLobbyRightColUIController value)
    {
        this.levelCompleteRightColUIController = value;
    }
    public void set_BannerAdsUnblocked(bool value)
    {
        int val_2 = this.bannerAdsUnblocked;
        val_2 = val_2 + (((value & true) != 0) ? (-0) : 0);
        this.bannerAdsUnblocked = val_2;
    }
    public bool get_BannerAdsBlockedByUI()
    {
        return (bool)(this.bannerAdsUnblocked > 0) ? 1 : 0;
    }
    public static bool get_AdsAllowed()
    {
        return AdsManager.AdsCanShow;
    }
    public bool get_BannerAdsAllowed()
    {
        var val_6;
        var val_7;
        var val_8;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.BannerEnabled()) != false)
        {
                val_6 = null;
            if(AdsManager.AdsCanShow != false)
        {
                val_7 = null;
            if(AdsManager.AdsAllowedByScene != false)
        {
                var val_5 = (this.bannerAdsUnblocked < 1) ? 1 : 0;
            return (bool)val_8;
        }
        
        }
        
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    private bool get_InterstitialAdsAllowed()
    {
        var val_4;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.InterstitialEnabled()) == false)
        {
                return false;
        }
        
        val_4 = null;
        if(AdsManager.AdsCanShow == false)
        {
                return false;
        }
        
        return AdsManager.AdsAllowedByScene;
    }
    private bool InterstitialAdsAllowedByContext(InterstitialContext context)
    {
        InterstitialContext val_4;
        var val_5;
        val_4 = context;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.InterstitialContextEnabled(context:  val_4)) == false)
        {
                return false;
        }
        
        val_4 = 1152921504887623680;
        val_5 = null;
        if(AdsManager.AdsCanShow == false)
        {
                return false;
        }
        
        return AdsManager.AdsAllowedByScene;
    }
    public bool get_VideoAdsAllowed()
    {
        return MonoSingletonSelfGenerating<AdsManager>.Instance.VideoEnabledAndUnlocked();
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  public System.Void AdsUIController::OnSceneChanged(SceneType type)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_3.OnSceneLoaded = val_5;
        SceneDictator val_6 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_8 = System.Delegate.Combine(a:  val_6.OnSceneUnloaded, b:  new System.Action<SceneType>(object:  this, method:  public System.Void AdsUIController::OnSceneChanged(SceneType type)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        val_6.OnSceneUnloaded = val_8;
        return;
        label_12:
    }
    private void Start()
    {
        ApplovinMaxPlugin val_1 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_1.IncentivizedVideoCallback = new System.Action<System.Boolean>(object:  this, method:  public System.Void AdsUIController::OnVideoAdWatched(bool success));
        ApplovinMaxPlugin val_3 = MonoSingleton<ApplovinMaxPlugin>.Instance;
        val_3.InterstitialCallback = new System.Action<System.Boolean>(object:  this, method:  public System.Void AdsUIController::OnInterstitialDisplayed(bool displayed));
    }
    public void OnSceneChanged(SceneType type)
    {
        this.ToggleIncentivizedButton();
        if(this.toggleAdsOnSceneChange == false)
        {
                return;
        }
        
        if(this.bannerController == 0)
        {
                if((MonoSingleton<ApplovinMaxPlugin>.Instance) != 0)
        {
                MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
            return;
        }
        
        }
        
        this.bannerController.ShowOrHideBanner();
    }
    private void OnDeferredReady()
    {
        this.ReadyOrServerSyncy();
    }
    private void OnServerSync()
    {
        this.ReadyOrServerSyncy();
    }
    private void ReadyOrServerSyncy()
    {
        this.ToggleIncentivizedButton();
        if(this.showAdsOnDataReady == false)
        {
                return;
        }
        
        if(this.bannerController == 0)
        {
                return;
        }
        
        this.bannerController.ShowOrHideBanner();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        var val_4;
        var val_5;
        var val_6;
        this.ToggleIncentivizedButton();
        if(pauseStatus != false)
        {
                val_4 = null;
            val_4 = null;
            if(TrackingComponent.lastIntent != 3)
        {
                return;
        }
        
            WGGenericNotificationsManager.SendPostAdNotification(QAHACK_Force:  false);
            return;
        }
        
        val_5 = null;
        val_5 = null;
        if(TrackingComponent.lastIntent == 3)
        {
                WGGenericNotificationsManager.CancelPostAdNotification();
            val_5 = null;
        }
        
        val_6 = null;
        val_6 = null;
        if(TrackingComponent.lastIntent != 0)
        {
                return;
        }
        
        if((InAppPurchasesManager.<inPurchaseIntent>k__BackingField) == true)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        bool val_2 = val_1.<metaGameBehavior>k__BackingField.ShowInterstitial(context:  1);
    }
    public void ToggleIncentivizedButton()
    {
        if(this.gameplayController != 0)
        {
                this.gameplayController.ToggleIncentivizedButton();
        }
        
        if(this.wgLobbyRightColUIController != 0)
        {
                this.wgLobbyRightColUIController.ToggleTopSlotButtons();
        }
        
        if(this.levelCompleteRightColUIController == 0)
        {
                return;
        }
        
        this.levelCompleteRightColUIController.ToggleTopSlotButtons();
    }
    private void OnDestroy()
    {
        if((MonoSingletonSelfGenerating<SceneDictator>.InstanceExists) == false)
        {
                return;
        }
        
        SceneDictator val_2 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_4 = System.Delegate.Remove(source:  val_2.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  public System.Void AdsUIController::OnSceneChanged(SceneType type)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_2.OnSceneLoaded = val_4;
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_7 = System.Delegate.Remove(source:  val_5.OnSceneUnloaded, value:  new System.Action<SceneType>(object:  this, method:  public System.Void AdsUIController::OnSceneChanged(SceneType type)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_11;
        }
        
        }
        
        val_5.OnSceneUnloaded = val_7;
        return;
        label_11:
    }
    public void ShowOrHideBanner()
    {
        if(this.bannerController == 0)
        {
                return;
        }
        
        this.bannerController.ShowOrHideBanner();
    }
    public float GetBannerAdHeight()
    {
        if(this.bannerController != 0)
        {
                return this.bannerController.GetBannerHeight();
        }
        
        return 0f;
    }
    public float GetBannerAdCanvasHeight()
    {
        if(this.bannerController != 0)
        {
                return this.bannerController.GetBannerCanvasHeight();
        }
        
        return 0f;
    }
    public bool ShowInterstitial(InterstitialContext context)
    {
        if((this.InterstitialAdsAllowedByContext(context:  context)) == false)
        {
                return false;
        }
        
        return MonoSingleton<ApplovinMaxPlugin>.Instance.ShowInterstitial(context:  2);
    }
    public bool ShowIncentivizedVideo(HeyZapAdTag tag, bool adCapExempt = False)
    {
        if(this.VideoAdsAllowed == false)
        {
                return false;
        }
        
        if(((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) == false) || (adCapExempt == true))
        {
                return MonoSingleton<ApplovinMaxPlugin>.Instance.ShowVideo(heyZapAdTag:  tag);
        }
        
        return false;
    }
    public void OnVideoAdWatched(bool success)
    {
        bool val_1 = success;
        this.ToggleIncentivizedButton();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnVideoResponse", aData:  new System.Collections.Hashtable());
    }
    public void OnInterstitialDisplayed(bool displayed)
    {
        bool val_1 = displayed;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnInterstitialResponse", aData:  new System.Collections.Hashtable());
    }
    public void HandlePurchase()
    {
        if(AdsUIController.AdsAllowed != true)
        {
                MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
        }
        
        this.ToggleIncentivizedButton();
    }
    public void AdControlVideoWatched()
    {
        if(AdsUIController.AdsAllowed != false)
        {
                return;
        }
        
        MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
    }
    public void CheckOrFetchInterstitial()
    {
        MonoSingleton<ApplovinMaxPlugin>.Instance.CheckInterstitialAvailable();
    }
    public static HeyZapAdTag GetTagForPurchasePoint(TrackerPurchasePoints entryPoint)
    {
        if((entryPoint - 20) <= 24)
        {
                var val_2 = 32560208 + ((entryPoint - 20)) << 2;
            val_2 = val_2 + 32560208;
        }
        else
        {
                if(entryPoint == 111)
        {
                return 44;
        }
        
            if(entryPoint != 112)
        {
                return 5;
        }
        
            return 43;
        }
    
    }
    public static string GetFreeCoinsEventForPurchasePoint(TrackerPurchasePoints entryPoint)
    {
        var val_3;
        if((entryPoint - 20) <= 10)
        {
                var val_2 = 32560308 + ((entryPoint - 20)) << 2;
            val_2 = val_2 + 32560308;
        }
        else
        {
                if(entryPoint == 121)
        {
                return (string)Events.AD_SEEN_REW_VID_MG_OOC;
        }
        
            val_3 = null;
            val_3 = null;
            return (string)Events.AD_SEEN_REW_VID_MG_OOC;
        }
    
    }
    public static CurrencyRewardType GetCurrencyRewardForPurchasePoint(TrackerPurchasePoints entryPoint)
    {
        return (CurrencyRewardType)(entryPoint == 76) ? 1 : 0;
    }
    public void TryShowPromptVideo(TrackerPurchasePoints entryPoint = 0, bool showAsFlyout = False)
    {
        var val_11;
        var val_12;
        if(this.VideoAdsAllowed == false)
        {
                return;
        }
        
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) != false)
        {
                return;
        }
        
        if(showAsFlyout != false)
        {
                GameBehavior val_4 = App.getBehavior;
            val_11 = val_4.<metaGameBehavior>k__BackingField;
        }
        else
        {
                GameBehavior val_6 = App.getBehavior;
            val_11 = val_6.<metaGameBehavior>k__BackingField;
        }
        
        HeyZapAdTag val_8 = AdsUIController.GetTagForPurchasePoint(entryPoint:  entryPoint);
        string val_9 = AdsUIController.GetFreeCoinsEventForPurchasePoint(entryPoint:  entryPoint);
        val_12 = null;
        val_12 = null;
        var val_10 = (PurchaseProxy.currentPurchasePoint == 76) ? 1 : 0;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
    }
    public bool CanShowAdsControlPopup(bool adWaterfallOn = False)
    {
        int val_13;
        var val_14;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return val_1.<metaGameBehavior>k__BackingField.CanShowAdsControlV2();
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        GameBehavior val_3 = App.getBehavior;
        GameEcon val_4 = App.getGameEcon;
        val_13 = val_4.adsControlPopupLevel;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_3.<metaGameBehavior>k__BackingField, knobValue:  val_13)) == false)
        {
                return false;
        }
        
        val_13 = 1152921513404906384;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.InterstitialEnabled()) != true)
        {
                if((MonoSingletonSelfGenerating<AdsManager>.Instance.BannerEnabled()) == false)
        {
                return false;
        }
        
        }
        
        val_14 = null;
        if(AdsManager.AdsCanShow == false)
        {
                return false;
        }
        
        if(adWaterfallOn != true)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "seen_adscontrol")) != false)
        {
                return false;
        }
        
        }
        
        GameBehavior val_12 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_320;
    }
    private bool CanShowAdsControlV2()
    {
        int val_21;
        var val_22;
        var val_23;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_21 = val_2.<metaGameBehavior>k__BackingField;
        GameEcon val_3 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_21, knobValue:  val_3.adsControlPopupLevel)) == false)
        {
                return false;
        }
        
        val_21 = 1152921504893267968;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.InterstitialEnabled()) != true)
        {
                if((MonoSingletonSelfGenerating<AdsManager>.Instance.BannerEnabled()) == false)
        {
                return false;
        }
        
        }
        
        val_22 = null;
        if(AdsManager.AdsCanShow == false)
        {
                return false;
        }
        
        if(App.Player.RemovedAds == true)
        {
                return false;
        }
        
        val_21 = UnityEngine.PlayerPrefs.GetInt(key:  "seen_adscontrol", defaultValue:  0);
        GameEcon val_13 = App.getGameEcon;
        if(val_21 < val_13.adsControlMaxViews)
        {
                string val_14 = UnityEngine.PlayerPrefs.GetString(key:  "seen_ads_date", defaultValue:  "");
            if((System.String.IsNullOrEmpty(value:  val_14)) == true)
        {
                return false;
        }
        
            val_23 = null;
            val_23 = null;
            System.DateTime val_16 = SLCDateTime.ParseInvariant(dateTime:  val_14, defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
            System.DateTime val_17 = val_16.dateData.Date;
            val_21 = val_17.dateData;
            System.DateTime val_18 = DateTimeCheat.UtcNow;
            System.DateTime val_19 = val_18.dateData.Date;
            if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_21}, d2:  new System.DateTime() {dateData = val_19.dateData})) == false)
        {
                return false;
        }
        
        }
        
        return false;
    }
    public void SawAdsControl()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "seen_adscontrol", value:  (UnityEngine.PlayerPrefs.GetInt(key:  "seen_adscontrol", defaultValue:  0)) + 1);
        UnityEngine.PlayerPrefs.Save();
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        UnityEngine.PlayerPrefs.SetString(key:  "seen_ads_date", value:  SLCDateTime.SerializeInvariant(dateTime:  new System.DateTime() {dateData = val_3.dateData}));
    }
    public bool CanShowFreeHintPopup()
    {
        System.Object[] val_24;
        int val_25;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_3 = new object[6];
            val_24 = val_3;
            GameEcon val_4 = App.getGameEcon;
            val_24[0] = val_4.freeHintPopupLevel;
            val_24[1] = SceneDictator.IsInGameScene();
            GameBehavior val_7 = App.getBehavior;
            GameEcon val_8 = App.getGameEcon;
            val_25 = val_8.freeHintPopupLevel;
            val_24[2] = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_7.<metaGameBehavior>k__BackingField, knobValue:  val_25);
            Player val_11 = App.Player;
            val_24[3] = (val_11.total_purchased <= 0f) ? 1 : 0;
            object val_24 = ~(UnityEngine.PlayerPrefs.HasKey(key:  "seen_freehint"));
            val_24 = val_24 & 1;
            val_24[4] = val_24;
            object val_25 = ~(MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached);
            val_25 = val_25 & 1;
            val_24[5] = val_25;
            UnityEngine.Debug.LogFormat(format:  "CanShowFreeHintPopup lvl:{0} v:{1} {2} {3} {4} {5}", args:  val_3);
        }
        
        if(SceneDictator.IsInGameScene() == false)
        {
                return false;
        }
        
        val_25 = 1152921504884269056;
        GameBehavior val_17 = App.getBehavior;
        val_24 = val_17.<metaGameBehavior>k__BackingField;
        GameEcon val_18 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_24, knobValue:  val_18.freeHintPopupLevel)) == false)
        {
                return false;
        }
        
        Player val_20 = App.Player;
        if(val_20.total_purchased > 0f)
        {
                return false;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "seen_freehint")) != true)
        {
                if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) == false)
        {
                return false;
        }
        
        }
        
        return false;
    }
    public void SawFreeHint()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "seen_freehint", value:  1);
    }
    public bool CanShowPostLevelOffer()
    {
        GameEcon val_2 = App.getGameEcon;
        GameEcon val_3 = App.getGameEcon;
        return (bool)(App.Player >= ((UnityEngine.Random.Range(min:  val_2.postLevelRewardedVideo_minLevels, max:  val_3.postLevelRewardedVideo_maxLevels + 1)) + (UnityEngine.PlayerPrefs.GetInt(key:  "seen_postlevel", defaultValue:  0)))) ? 1 : 0;
    }
    public bool CanShowPostLevelRewardedVideo(int playerLevel)
    {
        int val_8;
        var val_9;
        var val_10;
        val_8 = playerLevel;
        GameEcon val_1 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_8, knobValue:  val_1.postLevelRewardedVideo_Level)) != false)
        {
                Player val_3 = App.Player;
            if(val_3.total_purchased <= 0f)
        {
                bool val_5 = App.Player.networkPurchaserExcludedFromAds;
            if(val_5 != true)
        {
                if(val_5.VideoAdsAllowed != false)
        {
                val_8 = 1152921504886665216;
            val_9 = null;
            val_9 = null;
            var val_7 = (NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null) ? 1 : 0;
            return (bool)val_10;
        }
        
        }
        
        }
        
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    public void SawPostLevelOffer()
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "seen_postlevel", value:  App.Player);
    }
    public bool CanShowPostLevelAdsControlOffer(int playerLevel)
    {
        var val_13;
        var val_14;
        if(App.Player.RemovedAds != true)
        {
                val_13 = 0;
            if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == true)
        {
                return (bool)val_13;
        }
        
            val_14 = null;
            int val_5 = AdsManager.noAdsStartLevel;
            if(((val_5 & 2147483648) != 0) && (val_5.VideoAdsAllowed != false))
        {
                Player val_7 = App.Player;
            if(val_7.total_purchased <= 0f)
        {
                if(App.Player.networkPurchaserExcludedFromAds == false)
        {
            goto label_20;
        }
        
        }
        
        }
        
        }
        
        val_13 = 0;
        return (bool)val_13;
        label_20:
        GameEcon val_11 = App.getGameEcon;
        var val_12 = (App.Player >= val_11.postLevelAdsControl_minLvl) ? 1 : 0;
        return (bool)val_13;
    }
    public AdsUIController()
    {
        this.showAdsOnDataReady = true;
        this.toggleAdsOnSceneChange = true;
        this.onAdToggled = new UnityEngine.Events.UnityEvent();
    }

}

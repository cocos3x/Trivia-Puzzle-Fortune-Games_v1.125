using UnityEngine;
public class AdsManager : MonoSingletonSelfGenerating<AdsManager>
{
    // Fields
    private AdConfig videoConfig;
    private AdConfig bannerConfig;
    private AdConfig interstitialConfig;
    public static int playerLevel_gotd;
    private int cooldownMonths;
    private int cooldownHours;
    private int requiredVideos;
    private int nonClickerThreshold;
    private bool _offersEnabled;
    private bool _surveysEnabled;
    private int _surveyRequestLevel;
    private int _offerwallRequestLevel;
    private int _applovinRefreshRate;
    private bool rewVidCapInitd;
    private int _rewardedVideoCap;
    private int _videosWatchedToday;
    private System.DateTime lastCheckedVideoCap;
    private bool initialized;
    private const string KEY_INTERSTITIAL_LEVEL = "PP_tu6zxj0";
    private const string KEY_VIDEO_LEVEL = "PP_myzp291";
    private const string KEY_BANNER_LEVEL = "PP_93k016x";
    private const string ADS_UNLOCK_LVL = "25";
    private const string ADS_WATCHED_COUNT_PREF = "wg_ads_watched_count";
    private const string ADS_WATCHED_COOLDOWN_PREF = "wg_ads_watched_cooldown";
    private int ads_watched_count;
    private System.DateTime ads_watched_cooldown_end;
    private System.Collections.Generic.List<string> AdsEventsList;
    
    // Properties
    public static int CooldownMonths { get; }
    public static int CooldownHours { get; }
    public static int RequiredVideos { get; }
    public static int getNonClickerThreshold { get; }
    public static int noAdsStartLevel { get; set; }
    public static bool offersEnabled { get; }
    public static bool surveysEnabled { get; }
    public static int SurveyRequestLevel { get; }
    public static int OfferwallRequestLevel { get; }
    public static int ApplovinRefreshRate { get; }
    public int rewardedVideoCap { get; }
    private int pstTimeOffet { get; }
    public System.DateTime offsetServerTime { get; }
    public bool rewardVideoCapReached { get; }
    public int InterstitialSeconds { get; }
    public static bool isInPurchaseCooldown { get; }
    public static System.DateTime LastPurchaseCooldownEnd { get; }
    public static bool isInVideoCooldown { get; }
    public static System.DateTime AdsCooldownEnd { get; }
    public static bool AdsCanShow { get; }
    public static bool AdsAllowedByScene { get; }
    private int AdsWatchedCount { get; set; }
    public static int AdsWatched { get; set; }
    public System.DateTime AdsWatchedCooldownEnd { get; set; }
    public System.Collections.Generic.List<string> AdsEventsFromAPI { get; }
    
    // Methods
    public static int get_CooldownMonths()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1.cooldownMonths;
    }
    public static int get_CooldownHours()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1.cooldownHours;
    }
    public static int get_RequiredVideos()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1.requiredVideos;
    }
    public static int get_getNonClickerThreshold()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1.nonClickerThreshold;
    }
    public static int get_noAdsStartLevel()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "no_ads_start_lvl", defaultValue:  0);
    }
    public static void set_noAdsStartLevel(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "no_ads_start_lvl", value:  value);
    }
    public static bool get_offersEnabled()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (bool)val_1._offersEnabled;
    }
    public static bool get_surveysEnabled()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (bool)val_1._surveysEnabled;
    }
    public static int get_SurveyRequestLevel()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1._surveyRequestLevel;
    }
    public static int get_OfferwallRequestLevel()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1._offerwallRequestLevel;
    }
    public static int get_ApplovinRefreshRate()
    {
        AdsManager val_1 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (int)val_1._applovinRefreshRate;
    }
    public int get_rewardedVideoCap()
    {
        return (int)this._rewardedVideoCap;
    }
    private int get_pstTimeOffet()
    {
        return 17;
    }
    public System.DateTime get_offsetServerTime()
    {
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
        }
        else
        {
                System.DateTime val_4 = ServerHandler.ServerTime;
        }
        
        System.DateTime val_5 = val_4.dateData.AddHours(value:  17);
        return (System.DateTime)val_5.dateData;
    }
    public bool get_rewardVideoCapReached()
    {
        var val_8;
        if(this._rewardedVideoCap != 1)
        {
                System.DateTime val_1 = this.lastCheckedVideoCap.Date;
            System.DateTime val_2 = val_1.dateData.offsetServerTime;
            System.DateTime val_3 = val_2.dateData.Date;
            bool val_4 = System.DateTime.op_Inequality(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
            if(val_4 != false)
        {
                this._videosWatchedToday = 0;
            System.DateTime val_5 = val_4.offsetServerTime;
            this.lastCheckedVideoCap = val_5;
            this.SaveWatchedVideos();
        }
        
            var val_6 = (this._videosWatchedToday >= this._rewardedVideoCap) ? 1 : 0;
            return (bool)val_8;
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    public int get_InterstitialSeconds()
    {
        if(this.interstitialConfig != null)
        {
                return (int)this.interstitialConfig.InterstitialSeconds;
        }
        
        throw new NullReferenceException();
    }
    private void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        MaxSdkCallbacks.add_OnSdkInitializedEvent(value:  new System.Action<SdkConfiguration>(object:  this, method:  System.Void AdsManager::<Awake>b__48_0(MaxSdkBase.SdkConfiguration <p0>)));
        MaxSdkCallbacks.add_OnVariablesUpdatedEvent(value:  new System.Action(object:  this, method:  System.Void AdsManager::<Awake>b__48_1()));
        MaxSdkCallbacks.add_OnBannerAdLoadedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_2(string <p0>)));
        MaxSdkCallbacks.add_OnBannerAdLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  this, method:  System.Void AdsManager::<Awake>b__48_3(string <p0>, int <p1>)));
        MaxSdkCallbacks.add_OnBannerAdClickedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_4(string <p0>)));
        MaxSdkCallbacks.add_OnBannerAdExpandedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_5(string <p0>)));
        MaxSdkCallbacks.add_OnBannerAdCollapsedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_6(string <p0>)));
        MaxSdkCallbacks.add_OnInterstitialLoadedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_7(string <p0>)));
        MaxSdkCallbacks.add_OnInterstitialLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  this, method:  System.Void AdsManager::<Awake>b__48_8(string <p0>, int <p1>)));
        MaxSdkCallbacks.add_OnInterstitialHiddenEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_9(string <p0>)));
        MaxSdkCallbacks.add_OnInterstitialDisplayedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_10(string <p0>)));
        MaxSdkCallbacks.add_OnInterstitialAdFailedToDisplayEvent(value:  new System.Action<System.String, System.Int32>(object:  this, method:  System.Void AdsManager::<Awake>b__48_11(string <p0>, int <p1>)));
        MaxSdkCallbacks.add_OnInterstitialClickedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_12(string <p0>)));
        MaxSdkCallbacks.add_OnRewardedAdLoadedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_13(string <p0>)));
        MaxSdkCallbacks.add_OnRewardedAdLoadFailedEvent(value:  new System.Action<System.String, System.Int32>(object:  this, method:  System.Void AdsManager::<Awake>b__48_14(string <p0>, int <p1>)));
        MaxSdkCallbacks.add_OnRewardedAdDisplayedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_15(string <p0>)));
        MaxSdkCallbacks.add_OnRewardedAdHiddenEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_16(string <p0>)));
        MaxSdkCallbacks.add_OnRewardedAdClickedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void AdsManager::<Awake>b__48_17(string <p0>)));
        MaxSdkCallbacks.add_OnRewardedAdFailedToDisplayEvent(value:  new System.Action<System.String, System.Int32>(object:  this, method:  System.Void AdsManager::<Awake>b__48_18(string <p0>, int <p1>)));
        MaxSdkCallbacks.add_OnRewardedAdReceivedRewardEvent(value:  new System.Action<System.String, Reward>(object:  this, method:  System.Void AdsManager::<Awake>b__48_19(string <p0>, MaxSdkBase.Reward <p1>)));
    }
    private void OnDeferredReady()
    {
        this.ReadFromKnobs();
    }
    private void OnServerSync()
    {
        this.ReadFromKnobs();
        this.InitVideoCap();
    }
    private void Initialize()
    {
        if(this.initialized != false)
        {
                return;
        }
        
        this.ReadFromKnobs();
        this.initialized = true;
    }
    private void ReadFromKnobs()
    {
        var val_104;
        var val_105;
        var val_106;
        var val_107;
        string val_108;
        var val_109;
        string val_110;
        string val_111;
        string val_112;
        string val_113;
        string val_114;
        string val_115;
        string val_116;
        string val_117;
        var val_118;
        val_104 = this;
        object val_2 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "ad_display", defaultValue:  "{}"));
        val_105 = 1152921504685600768;
        if(val_2.Keys.Count < 2)
        {
                return;
        }
        
        if((val_2.ContainsKey(key:  "android_playerLevel_gotw")) != false)
        {
                val_106 = null;
            val_106 = null;
            bool val_7 = System.Int32.TryParse(s:  val_2.Item["android_playerLevel_gotw"], result: out  void* val_7 = AdsManager.__il2cppRuntimeField_static_fields);
        }
        
        if((val_2.ContainsKey(key:  "android_non_clicker_threshold")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_2.Item["android_non_clicker_threshold"], result: out  this.nonClickerThreshold);
        }
        
        if((val_2.ContainsKey(key:  "r_r")) != false)
        {
                bool val_15 = System.Int32.TryParse(s:  val_2.Item["r_r"], result: out  this._applovinRefreshRate);
        }
        
        object val_16 = AdSegmentation.GetSegementedConfig(key:  "banner_ads", knobs:  val_2, addSegment:  true);
        if(val_16 != null)
        {
                val_107 = 1152921510214912464;
            if(val_16.Item["enabled"] != null)
        {
                val_108 = val_16.Item["enabled"];
        }
        else
        {
                val_108 = "true";
        }
        
            val_109 = "level";
            this.bannerConfig.Enabled = System.Boolean.Parse(value:  val_108);
            if(val_16.Item["level"] != null)
        {
                object val_22 = val_16.Item["level"];
        }
        else
        {
                val_110 = "1";
        }
        
            this.bannerConfig.UnlockLevel = System.Int32.Parse(s:  val_110, style:  511);
        }
        
        object val_24 = AdSegmentation.GetSegementedConfig(key:  "interstitial_ads", knobs:  val_2, addSegment:  true);
        if(val_24 != null)
        {
                val_109 = 1152921510214912464;
            if(val_24.Item["on_quit"] != null)
        {
                val_111 = val_24.Item["on_quit"];
        }
        else
        {
                val_111 = "true";
        }
        
            if(val_24.Item["on_minimize"] != null)
        {
                val_112 = val_24.Item["on_minimize"];
        }
        else
        {
                val_112 = "true";
        }
        
            object val_31 = val_24.Item["on_level"];
            if(val_31.Item["enabled"] != null)
        {
                val_113 = val_31.Item["enabled"];
        }
        else
        {
                val_113 = "true";
        }
        
            val_107 = System.Boolean.Parse(value:  val_113);
            if(val_31.Item["level"] != null)
        {
                object val_36 = val_31.Item["level"];
        }
        else
        {
                val_114 = "8";
        }
        
            this.interstitialConfig.UnlockLevel = System.Int32.Parse(s:  val_114, style:  511);
            if(val_31.Item["seconds"] != null)
        {
                object val_39 = val_31.Item["seconds"];
        }
        else
        {
                val_115 = "60";
        }
        
            this.interstitialConfig.InterstitialSeconds = System.Int32.Parse(s:  val_115, style:  511);
            this.interstitialConfig.AllowedContext = new System.Collections.Generic.List<InterstitialContext>();
            val_105 = 1152921504685600768;
            if((System.Boolean.Parse(value:  val_111)) != false)
        {
                this.interstitialConfig.AllowedContext.Add(item:  3);
        }
        
            if((System.Boolean.Parse(value:  val_112)) != false)
        {
                this.interstitialConfig.AllowedContext.Add(item:  1);
        }
        
            if(val_107 != false)
        {
                this.interstitialConfig.AllowedContext.Add(item:  2);
        }
        
        }
        
        object val_42 = AdSegmentation.GetSegementedConfig(key:  "video_ads", knobs:  val_2, addSegment:  true);
        if(val_42 != null)
        {
                val_107 = 1152921510214912464;
            if(val_42.Item["enabled"] != null)
        {
                val_116 = val_42.Item["enabled"];
        }
        else
        {
                val_116 = "true";
        }
        
            val_109 = val_105;
            this.videoConfig.Enabled = System.Boolean.Parse(value:  val_116);
            if(val_42.Item["level"] != null)
        {
                object val_48 = val_42.Item["level"];
        }
        else
        {
                val_117 = "1";
        }
        
            this.videoConfig.UnlockLevel = System.Int32.Parse(s:  val_117, style:  511);
            if((val_42.ContainsKey(key:  "spin_ul")) != false)
        {
                GameEcon val_52 = App.getGameEcon;
            bool val_54 = System.Int32.TryParse(s:  val_42.Item["spin_ul"], result: out  val_52.watchAdForSpinUnlockSpins);
        }
        
            if((val_42.ContainsKey(key:  "coin_ul")) != false)
        {
                GameEcon val_57 = App.getGameEcon;
            bool val_59 = System.Int32.TryParse(s:  val_42.Item["coin_ul"], result: out  val_57.watchAdForCoinUnlockLevel);
        }
        
            if((val_42.ContainsKey(key:  "ad_cap")) != false)
        {
                object val_61 = val_42.Item["ad_cap"];
            GameEcon val_63 = App.getGameEcon;
            bool val_65 = System.Int32.TryParse(s:  val_61.Item["no_p"], result: out  val_63.nonPurchaserCap);
            GameEcon val_67 = App.getGameEcon;
            bool val_69 = System.Int32.TryParse(s:  val_61.Item["low_p"], result: out  val_67.lowPurchaserCap);
            GameEcon val_71 = App.getGameEcon;
            bool val_73 = System.Int32.TryParse(s:  val_61.Item["high_p"], result: out  val_71.highPurchaserCap);
            GameEcon val_75 = App.getGameEcon;
            bool val_77 = System.Int32.TryParse(s:  val_61.Item["rep"], result: out  val_75.repeatPurchaserCap);
        }
        
        }
        
        if((val_2.ContainsKey(key:  "x_nw_p")) != false)
        {
                Player val_80 = App.Player;
            bool val_82 = System.Boolean.TryParse(value:  val_2.Item["x_nw_p"], result: out  val_80.adExcludedNetworkPurchaser);
        }
        
        if((val_2.ContainsKey(key:  "ow_en")) != false)
        {
                bool val_86 = System.Boolean.TryParse(value:  val_2.Item["ow_en"], result: out  this._offersEnabled);
        }
        
        if((val_2.ContainsKey(key:  "su_en")) != false)
        {
                bool val_90 = System.Boolean.TryParse(value:  val_2.Item["su_en"], result: out  this._surveysEnabled);
        }
        
        if((val_2.ContainsKey(key:  "ow_r_lv")) != false)
        {
                bool val_94 = System.Int32.TryParse(s:  val_2.Item["ow_r_lv"], result: out  this._offerwallRequestLevel);
        }
        
        if((val_2.ContainsKey(key:  "su_r_lv")) != false)
        {
                bool val_98 = System.Int32.TryParse(s:  val_2.Item["su_r_lv"], result: out  this._surveyRequestLevel);
        }
        
        val_104 = "android_app_rating_level";
        if((val_2.ContainsKey(key:  "android_app_rating_level")) == false)
        {
                return;
        }
        
        val_118 = null;
        val_118 = null;
        bool val_101 = System.Int32.TryParse(s:  val_2.Item["android_app_rating_level"], result: out  void* val_102 = WGReviewManager.__il2cppRuntimeField_static_fields);
    }
    private void InitVideoCap()
    {
        var val_16;
        ulong val_17;
        if(this.rewVidCapInitd == true)
        {
                return;
        }
        
        this.rewVidCapInitd = true;
        this.CalculateCurrentVideoCap();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_16 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((CPlayerPrefs.HasKey(key:  "rewVidCap")) != false)
        {
                val_16 = 0;
        }
        
        System.DateTime val_6 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "rewVidCap")).offsetServerTime;
        System.DateTime val_9 = System.DateTime.UtcNow;
        System.DateTime val_10 = SLCDateTime.Parse(dateTime:  EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "date", defaultValue:  val_6.dateData.ToString()), defaultValue:  new System.DateTime() {dateData = val_9.dateData});
        System.DateTime val_11 = val_10.dateData.Date;
        val_17 = val_11.dateData;
        System.DateTime val_12 = val_11.dateData.offsetServerTime;
        System.DateTime val_13 = val_12.dateData.Date;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_17}, d2:  new System.DateTime() {dateData = val_13.dateData})) != false)
        {
                val_17 = 1152921504619999232;
            object val_15 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "watched", defaultValue:  0);
            this._videosWatchedToday = null;
        }
        else
        {
                this._videosWatchedToday = 0;
        }
        
        this.lastCheckedVideoCap = val_10;
    }
    private void CalculateCurrentVideoCap()
    {
        int val_9;
        Player val_1 = App.Player;
        if(val_1.num_purchase == 0)
        {
            goto label_4;
        }
        
        Player val_2 = App.Player;
        if(val_2.num_purchase != 1)
        {
            goto label_12;
        }
        
        Player val_3 = App.Player;
        if(val_3.lastPurchasePrice >= 0)
        {
            goto label_12;
        }
        
        GameEcon val_4 = App.getGameEcon;
        val_9 = val_4.lowPurchaserCap;
        goto label_28;
        label_12:
        Player val_5 = App.Player;
        if(val_5.num_purchase != 1)
        {
            goto label_20;
        }
        
        GameEcon val_6 = App.getGameEcon;
        val_9 = val_6.highPurchaserCap;
        goto label_28;
        label_4:
        GameEcon val_7 = App.getGameEcon;
        val_9 = val_7.nonPurchaserCap;
        goto label_28;
        label_20:
        GameEcon val_8 = App.getGameEcon;
        val_9 = val_8.repeatPurchaserCap;
        label_28:
        this._rewardedVideoCap = val_9;
    }
    private void SaveWatchedVideos()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.DateTime val_2 = val_1.offsetServerTime;
        val_1.Add(key:  "date", value:  val_2);
        val_1.Add(key:  "watched", value:  this._videosWatchedToday);
        CPlayerPrefs.SetString(key:  "rewVidCap", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
    }
    public bool InterstitialEnabled()
    {
        var val_7;
        var val_8;
        val_7 = this;
        if((this.AdsAllowed() == false) || (this.interstitialConfig.Enabled == false))
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) < this.interstitialConfig.UnlockLevel)
        {
                return false;
        }
        
        val_8 = null;
        if((AdsManager.noAdsStartLevel & 2147483648) == 0)
        {
                val_7 = App.Player;
            GameEcon val_6 = App.getGameEcon;
            int val_7 = val_6.postLevelAdsControl_duration;
            val_7 = val_7 + AdsManager.noAdsStartLevel;
            if(val_7 < val_7)
        {
                return false;
        }
        
        }
        
        AdsManager.noAdsStartLevel = 0;
        return false;
    }
    public bool InterstitialContextEnabled(InterstitialContext context)
    {
        if(this.InterstitialEnabled() == false)
        {
                return false;
        }
        
        if((this.interstitialConfig.AllowedContext.Contains(item:  context)) != false)
        {
                if(DeviceIdPlugin.IsEmulator() == false)
        {
            goto label_7;
        }
        
        }
        
        return false;
        label_7:
        if(context != 2)
        {
                return false;
        }
        
        System.DateTime val_4 = ServerHandler.ServerTime;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = this.interstitialConfig.LastInterstitial});
        if(val_5._ticks.TotalSeconds < 0)
        {
                return false;
        }
        
        System.DateTime val_7 = ServerHandler.ServerTime;
        this.interstitialConfig.LastInterstitial = val_7;
        return false;
    }
    public bool VideoEnabledAndUnlocked()
    {
        if(this.videoConfig != null)
        {
                if(this.videoConfig.Enabled == false)
        {
                return false;
        }
        
            return this.VideoAllowedAndUnlocked();
        }
        
        throw new NullReferenceException();
    }
    private bool VideoAllowedAndUnlocked()
    {
        var val_6;
        var val_7;
        if(this.VideoAdsAllowed() == false)
        {
            goto label_1;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((WADPetsManager.GetUnlockedPetByAbility(ability:  4)) == true)
        {
            goto label_7;
        }
        
        }
        
        val_6 = null;
        val_6 = null;
        if(App.game != 20)
        {
            goto label_13;
        }
        
        label_7:
        val_7 = 1;
        return (bool)((val_4.<metaGameBehavior>k__BackingField) >= this.videoConfig.UnlockLevel) ? 1 : 0;
        label_1:
        val_7 = 0;
        return (bool)((val_4.<metaGameBehavior>k__BackingField) >= this.videoConfig.UnlockLevel) ? 1 : 0;
        label_13:
        GameBehavior val_4 = App.getBehavior;
        return (bool)((val_4.<metaGameBehavior>k__BackingField) >= this.videoConfig.UnlockLevel) ? 1 : 0;
    }
    public bool BannerEnabled()
    {
        var val_9;
        var val_11;
        val_9 = this;
        if((this.AdsAllowed() == false) || (this.bannerConfig.Enabled == false))
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                GameBehavior val_3 = App.getBehavior;
            if((val_3.<metaGameBehavior>k__BackingField) < this.bannerConfig.UnlockLevel)
        {
                return false;
        }
        
        }
        
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                val_11 = null;
            if((AdsManager.noAdsStartLevel & 2147483648) == 0)
        {
                val_9 = App.Player;
            GameEcon val_8 = App.getGameEcon;
            int val_9 = val_8.postLevelAdsControl_duration;
            val_9 = val_9 + AdsManager.noAdsStartLevel;
            if(val_9 < val_9)
        {
                return false;
        }
        
        }
        
        }
        
        AdsManager.noAdsStartLevel = 0;
        return false;
    }
    public bool AdsAllowed()
    {
        UnityEngine.Object val_11;
        if(App.Player.RemovedAds == true)
        {
                return false;
        }
        
        val_11 = MonoSingleton<WGSubscriptionManager>.Instance;
        if(val_11 != 0)
        {
                if((MonoSingleton<WGSubscriptionManager>.Instance.hasAnySubscription()) == true)
        {
                return false;
        }
        
        }
        
        if(DeviceIdPlugin.IsEmulator() != false)
        {
                return false;
        }
        
        if((DefaultHandler<ServerHandler>.Instance) == 0)
        {
                return false;
        }
        
        ServerHandler val_10 = DefaultHandler<ServerHandler>.Instance;
        if(val_10._allowServerConnect == false)
        {
                return false;
        }
        
        return false;
    }
    private bool VideoAdsAllowed()
    {
        UnityEngine.Object val_5;
        var val_6;
        if(DeviceIdPlugin.IsEmulator() == false)
        {
            goto label_3;
        }
        
        label_13:
        val_6 = 0;
        return (bool)val_6;
        label_3:
        val_5 = DefaultHandler<ServerHandler>.Instance;
        if(val_5 == 0)
        {
            goto label_9;
        }
        
        ServerHandler val_4 = DefaultHandler<ServerHandler>.Instance;
        if(val_4._allowServerConnect == false)
        {
            goto label_13;
        }
        
        label_9:
        val_6 = 1;
        return (bool)val_6;
    }
    private bool AnyAdsLevelReached()
    {
        GameBehavior val_1 = App.getBehavior;
        return (bool)((val_1.<metaGameBehavior>k__BackingField) >= (UnityEngine.Mathf.Min(a:  this.interstitialConfig.UnlockLevel, b:  this.bannerConfig.UnlockLevel))) ? 1 : 0;
    }
    public bool AdsControlEnabled()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        if((val_1.<metaGameBehavior>k__BackingField.AdsAllowed()) == false)
        {
                return false;
        }
        
        return this.AnyAdsLevelReached();
    }
    public static void AddNoAdsCooldown(double seconds)
    {
        var val_7;
        Player val_1 = App.Player;
        val_7 = null;
        if(AdsManager.isInPurchaseCooldown != false)
        {
                Player val_3 = App.Player;
        }
        else
        {
                System.DateTime val_4 = ServerHandler.ServerTime;
        }
        
        System.DateTime val_5 = val_4.dateData.AddSeconds(value:  seconds);
        val_1.properties.NoAdsEndTime = val_5;
        MonoSingletonSelfGenerating<AdsManager>.Instance.CalculateCurrentVideoCap();
    }
    public static void HandlePurchase()
    {
        System.DateTime val_9;
        var val_10;
        var val_11;
        int val_12;
        Player val_1 = App.Player;
        val_9 = 1152921504887623680;
        val_10 = null;
        if(AdsManager.isInPurchaseCooldown != false)
        {
                Player val_3 = App.Player;
            val_11 = null;
            val_9 = val_3.properties.NoAdsEndTime;
            val_12 = AdsManager.CooldownMonths;
        }
        else
        {
                System.DateTime val_5 = ServerHandler.ServerTime;
            val_12 = AdsManager.CooldownMonths;
        }
        
        System.DateTime val_7 = val_5.dateData.AddMonths(months:  val_12);
        val_1.properties.NoAdsEndTime = val_7;
        MonoSingletonSelfGenerating<AdsManager>.Instance.CalculateCurrentVideoCap();
    }
    public static bool get_isInPurchaseCooldown()
    {
        Player val_1 = App.Player;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                System.DateTime val_4 = DateTimeCheat.UtcNow;
            return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.properties.NoAdsEndTime}, t2:  new System.DateTime() {dateData = val_5.dateData})) > 0) ? 1 : 0;
        }
        
        System.DateTime val_5 = ServerHandler.ServerTime;
        return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.properties.NoAdsEndTime}, t2:  new System.DateTime() {dateData = val_5.dateData})) > 0) ? 1 : 0;
    }
    public static System.DateTime get_LastPurchaseCooldownEnd()
    {
        Player val_1 = App.Player;
        return (System.DateTime)val_1.properties.NoAdsEndTime;
    }
    public static bool get_isInVideoCooldown()
    {
        System.DateTime val_2 = MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        System.DateTime val_3 = ServerHandler.ServerTime;
        return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = val_3.dateData})) > 0) ? 1 : 0;
    }
    public static System.DateTime get_AdsCooldownEnd()
    {
        var val_4;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance) != 0)
        {
                return MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        }
        
        val_4 = null;
        val_4 = null;
        return (System.DateTime)System.DateTime.MinValue;
    }
    public static bool get_AdsCanShow()
    {
        var val_10;
        var val_11;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.AdsAllowed()) == false)
        {
                return (bool)0 & 1;
        }
        
        val_10 = null;
        if(AdsManager.isInPurchaseCooldown == true)
        {
                return (bool)0 & 1;
        }
        
        val_11 = null;
        if(AdsManager.isInVideoCooldown != true)
        {
                if(App.Player.networkPurchaserExcludedFromAds == false)
        {
            goto label_14;
        }
        
        }
        
        return (bool)0 & 1;
        label_14:
        Player val_8 = App.Player;
        bool val_10 = val_8.properties.ShouldShowGdprConsent() ^ 1;
        return (bool)0 & 1;
    }
    public static bool ShowAdsControlButtons(bool fromSettings = False)
    {
        var val_15;
        var val_16;
        var val_17;
        val_15 = fromSettings;
        if(val_15 != false)
        {
                if((MonoSingletonSelfGenerating<AdsManager>.Instance.AdsControlEnabled()) == false)
        {
                return false;
        }
        
            val_16 = null;
            if(AdsManager.isInPurchaseCooldown == true)
        {
                return false;
        }
        
            val_15 = 1152921504884269056;
            if(App.Player.networkPurchaserExcludedFromAds == true)
        {
                return false;
        }
        
            GameEcon val_7 = App.getGameEcon;
            return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_7.adsControlPopupLevel);
        }
        
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.AdsControlEnabled()) == false)
        {
                return false;
        }
        
        val_17 = null;
        if(AdsManager.isInPurchaseCooldown == true)
        {
                return false;
        }
        
        val_15 = 1152921504884269056;
        if(App.Player.networkPurchaserExcludedFromAds != false)
        {
                return false;
        }
        
        GameEcon val_14 = App.getGameEcon;
        return GameEcon.IsEnabledAndLevelNotExeeded(playerLevel:  App.Player, knobValue:  val_14.adsControlButtonLevel_max);
    }
    public static bool ShowAdsControlMenuItem()
    {
        var val_7;
        var val_8;
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.AdsControlEnabled()) == false)
        {
            goto label_4;
        }
        
        val_7 = null;
        if(AdsManager.isInPurchaseCooldown == false)
        {
            goto label_7;
        }
        
        label_4:
        val_8 = 0;
        goto label_8;
        label_7:
        bool val_5 = App.Player.networkPurchaserExcludedFromAds;
        val_8 = val_5 ^ 1;
        label_8:
        val_5 = val_8;
        return (bool)val_5;
    }
    public static bool get_AdsAllowedByScene()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_1A0;
    }
    private int get_AdsWatchedCount()
    {
        int val_3 = this.ads_watched_count;
        if(val_3 != 1)
        {
                return val_3;
        }
        
        if((CPlayerPrefs.HasKey(key:  "wg_ads_watched_count")) != false)
        {
                val_3 = "wg_ads_watched_count";
            int val_2 = CPlayerPrefs.GetInt(key:  val_3);
        }
        else
        {
                val_3 = 0;
        }
        
        this.ads_watched_count = val_3;
        return val_3;
    }
    private void set_AdsWatchedCount(int value)
    {
        int val_5;
        var val_6;
        var val_8;
        val_5 = value;
        this.ads_watched_count = val_5;
        if(this.requiredVideos == val_5)
        {
                this.ads_watched_count = 0;
            val_6 = null;
            if(AdsManager.isInVideoCooldown != false)
        {
                System.DateTime val_2 = this.AdsWatchedCooldownEnd;
        }
        else
        {
                System.DateTime val_3 = ServerHandler.ServerTime;
        }
        
            System.DateTime val_4 = val_3.dateData.AddHours(value:  (double)this.cooldownHours);
            this.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_4.dateData};
            val_8 = null;
            val_8 = null;
            App.trackerManager.track(eventName:  Events.ADS_DISABLED_REW);
            val_5 = this.ads_watched_count;
        }
        
        CPlayerPrefs.SetInt(key:  "wg_ads_watched_count", val:  val_5);
    }
    public static int get_AdsWatched()
    {
        return MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCount;
    }
    public static void set_AdsWatched(int value)
    {
        MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCount = value;
    }
    public System.DateTime get_AdsWatchedCooldownEnd()
    {
        null = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.ads_watched_cooldown_end}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return (System.DateTime)this.ads_watched_cooldown_end;
        }
        
        if((CPlayerPrefs.HasKey(key:  "wg_ads_watched_cooldown")) != false)
        {
                System.DateTime val_4 = SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "wg_ads_watched_cooldown"));
            this.ads_watched_cooldown_end = val_4;
            return (System.DateTime)this.ads_watched_cooldown_end;
        }
        
        System.DateTime val_5 = ServerHandler.ServerTime;
        this.ads_watched_cooldown_end = val_5;
        CPlayerPrefs.SetString(key:  "wg_ads_watched_cooldown", val:  this.ads_watched_cooldown_end.ToString());
        return (System.DateTime)this.ads_watched_cooldown_end;
    }
    public void set_AdsWatchedCooldownEnd(System.DateTime value)
    {
        this.ads_watched_cooldown_end = value;
        CPlayerPrefs.SetString(key:  "wg_ads_watched_cooldown", val:  this.ads_watched_cooldown_end.ToString());
    }
    public static void AddAdsWatchedFromVersionUpdate()
    {
        if(AdsManager.isInVideoCooldown != false)
        {
                System.DateTime val_4 = MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        }
        else
        {
                System.DateTime val_5 = ServerHandler.ServerTime;
        }
        
        System.DateTime val_7 = val_5.dateData.AddMonths(months:  AdsManager.CooldownMonths);
        MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_7.dateData};
    }
    public static void AddPurchaseCooldownFromVersionUpdate()
    {
        ulong val_14;
        Player val_1 = App.Player;
        AdsManager val_2 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        System.DateTime val_3 = val_1.last_purchase.AddMonths(months:  val_2.cooldownMonths);
        val_14 = val_3.dateData;
        System.DateTime val_4 = ServerHandler.ServerTime;
        if((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_14}, t2:  new System.DateTime() {dateData = val_4.dateData})) < 1)
        {
                return;
        }
        
        Player val_6 = App.Player;
        System.DateTime val_7 = ServerHandler.ServerTime;
        Player val_8 = App.Player;
        AdsManager val_9 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        System.DateTime val_10 = val_8.last_purchase.AddMonths(months:  val_9.cooldownMonths);
        val_14 = val_10.dateData;
        System.DateTime val_11 = ServerHandler.ServerTime;
        System.TimeSpan val_12 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_14}, d2:  new System.DateTime() {dateData = val_11.dateData});
        System.DateTime val_13 = val_7.dateData.Add(value:  new System.TimeSpan() {_ticks = val_12._ticks});
        val_6.properties.NoAdsEndTime = val_13;
    }
    public void OnVideoResponse(Notification notif)
    {
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        int val_3 = this._videosWatchedToday;
        val_3 = val_3 + 1;
        this._videosWatchedToday = val_3;
        this.SaveWatchedVideos();
    }
    public void HackResetAdsWatchedCoolDown()
    {
        var val_4 = null;
        if(AdsManager.isInVideoCooldown == false)
        {
                return;
        }
        
        System.DateTime val_2 = ServerHandler.ServerTime;
        System.DateTime val_3 = val_2.dateData.AddMinutes(value:  5);
        this.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_3.dateData};
    }
    public System.Collections.Generic.List<string> get_AdsEventsFromAPI()
    {
        return (System.Collections.Generic.List<System.String>)this.AdsEventsList;
    }
    private void AddAdsEvent(string eventName)
    {
        this.AdsEventsList.Add(item:  eventName);
    }
    public int HackAdsWatchedToday(int increment)
    {
        int val_1 = this._videosWatchedToday;
        val_1 = val_1 + increment;
        this._videosWatchedToday = val_1;
        this.SaveWatchedVideos();
        return (int)this._videosWatchedToday;
    }
    public AdsManager()
    {
        var val_5;
        this.videoConfig = new AdConfig();
        this.bannerConfig = new AdConfig();
        this.interstitialConfig = new AdConfig();
        this._applovinRefreshRate = 3;
        this._rewardedVideoCap = 0;
        this.ads_watched_count = 0;
        this.cooldownMonths = ;
        this.cooldownHours = ;
        this.requiredVideos = 25769803781;
        this.nonClickerThreshold = 6;
        this._surveyRequestLevel = 50;
        this._offerwallRequestLevel = 40;
        val_5 = null;
        val_5 = null;
        this.ads_watched_cooldown_end = System.DateTime.MinValue;
        this.AdsEventsList = new System.Collections.Generic.List<System.String>();
    }
    private static AdsManager()
    {
        AdsManager.ADS_WATCHED_COOLDOWN_PREF = 12;
    }
    private void <Awake>b__48_0(MaxSdkBase.SdkConfiguration <p0>)
    {
        this.AddAdsEvent(eventName:  "OnSdkInitializedEvent");
    }
    private void <Awake>b__48_1()
    {
        this.AddAdsEvent(eventName:  "OnVariablesUpdatedEvent");
    }
    private void <Awake>b__48_2(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnBannerAdLoadedEvent");
    }
    private void <Awake>b__48_3(string <p0>, int <p1>)
    {
        this.AddAdsEvent(eventName:  "OnBannerAdLoadFailedEvent");
    }
    private void <Awake>b__48_4(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnBannerAdClickedEvent");
    }
    private void <Awake>b__48_5(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnBannerAdExpandedEvent");
    }
    private void <Awake>b__48_6(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnBannerAdCollapsedEvent");
    }
    private void <Awake>b__48_7(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialLoadedEvent");
    }
    private void <Awake>b__48_8(string <p0>, int <p1>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialLoadFailedEvent");
    }
    private void <Awake>b__48_9(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialHiddenEvent");
    }
    private void <Awake>b__48_10(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialDisplayedEvent");
    }
    private void <Awake>b__48_11(string <p0>, int <p1>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialAdFailedToDisplayEvent");
    }
    private void <Awake>b__48_12(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnInterstitialClickedEvent");
    }
    private void <Awake>b__48_13(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdLoadedEvent");
    }
    private void <Awake>b__48_14(string <p0>, int <p1>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdLoadFailedEvent");
    }
    private void <Awake>b__48_15(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdDisplayedEvent");
    }
    private void <Awake>b__48_16(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdHiddenEvent");
    }
    private void <Awake>b__48_17(string <p0>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdClickedEvent");
    }
    private void <Awake>b__48_18(string <p0>, int <p1>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdFailedToDisplayEvent");
    }
    private void <Awake>b__48_19(string <p0>, MaxSdkBase.Reward <p1>)
    {
        this.AddAdsEvent(eventName:  "OnRewardedAdReceivedRewardEvent");
    }

}

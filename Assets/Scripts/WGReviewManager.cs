using UnityEngine;
public class WGReviewManager : MonoSingleton<WGReviewManager>
{
    // Fields
    private const string prefTime = "prefs_review_time";
    private const string prefDidNot = "prefs_did_not_review";
    public const string REVIEW_FREE_TRIAL = "reviewtrial";
    public static int ReviewPopupLevel;
    public static int ReviewFiveStarDelay;
    private int _freeNoAdsDuration;
    private int _freeTrialDuration;
    public int selectedRating;
    private static bool _declinedReview;
    private static System.DateTime _NextReviewTime;
    private const string GOOGLE_API_REVIEW_PREF = "google_api_review_pref";
    private Google.Play.Review.ReviewManager reviewManager;
    private bool initializingRManager;
    private Google.Play.Review.PlayReviewInfo _playReviewInfo;
    
    // Properties
    public int freeNoAdsDuration { get; }
    public int feeTrialDuration { get; }
    private static bool IsAvailable { get; }
    private static bool IsDelayedUntilLaterLevel { get; }
    public static bool CanShow { get; }
    private static bool TimeToShow { get; }
    private static bool DeclinedReview { get; set; }
    public static System.DateTime NextReviewTime { get; set; }
    
    // Methods
    public int get_freeNoAdsDuration()
    {
        return (int)this._freeNoAdsDuration;
    }
    public int get_feeTrialDuration()
    {
        return (int)this._freeTrialDuration;
    }
    private static bool get_IsAvailable()
    {
        var val_2;
        GameBehavior val_1 = App.getBehavior;
        val_2 = null;
        val_2 = null;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  WGReviewManager.GOOGLE_API_REVIEW_PREF);
    }
    private static bool get_IsDelayedUntilLaterLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        bool val_4 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  MonoSingleton<WGFTUXManager>.Instance.ReviewPromptLevel);
        val_4 = (~val_4) & 1;
        return (bool)val_4;
    }
    public static bool get_CanShow()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        if(WGReviewManager.IsAvailable != false)
        {
                val_4 = null;
            if(WGReviewManager.TimeToShow == false)
        {
                return WGReviewManager.DeclinedReview;
        }
        
            val_5 = 1;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    private static bool get_TimeToShow()
    {
        System.DateTime val_1 = DateTimeCheat.ServerNow;
        System.DateTime val_2 = WGReviewManager.NextReviewTime;
        return (bool)((val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_2.dateData})) > 0) ? 1 : 0;
    }
    private static bool get_DeclinedReview()
    {
        var val_3 = null;
        WGReviewManager._declinedReview = CPlayerPrefs.GetBool(key:  "prefs_did_not_review", defaultValue:  false);
        return (bool)WGReviewManager._declinedReview;
    }
    private static void set_DeclinedReview(bool value)
    {
        null = null;
        WGReviewManager._declinedReview = value;
        CPlayerPrefs.SetBool(key:  "prefs_did_not_review", value:  (WGReviewManager._declinedReview == true) ? 1 : 0);
    }
    public static System.DateTime get_NextReviewTime()
    {
        var val_7;
        System.DateTime val_8;
        var val_9;
        var val_10;
        val_7 = null;
        if(WGReviewManager.IsAvailable != false)
        {
                System.DateTime val_2 = DateTimeCheat.ServerNow;
            System.DateTime val_3 = val_2.dateData.AddDays(value:  7);
        }
        else
        {
                val_9 = null;
            val_9 = null;
            val_8 = System.DateTime.MinValue;
        }
        
        System.DateTime val_6 = SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "prefs_review_time", defaultValue:  val_8.ToString()));
        val_10 = null;
        val_10 = null;
        WGReviewManager._NextReviewTime = val_6.dateData;
        return (System.DateTime)WGReviewManager._NextReviewTime;
    }
    public static void set_NextReviewTime(System.DateTime value)
    {
        null = null;
        WGReviewManager._NextReviewTime = value.dateData;
        CPlayerPrefs.SetString(key:  "prefs_review_time", val:  WGReviewManager._NextReviewTime.ToString());
    }
    public override void InitMonoSingleton()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
    }
    private void OnDeferredReady()
    {
        System.DateTime val_1 = WGReviewManager.NextReviewTime;
        WGReviewManager.NextReviewTime = new System.DateTime() {dateData = val_1.dateData};
        if(WGReviewManager.CanShow == false)
        {
                return;
        }
        
        this.LoadAppReview();
    }
    public bool CheckAvailable()
    {
        var val_13;
        var val_14;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_3 = new object[4];
            val_13 = null;
            val_13 = null;
            val_3[0] = NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE;
            val_14 = null;
            val_3[1] = WGReviewManager.IsAvailable;
            val_3[2] = WGReviewManager.TimeToShow;
            val_3[3] = WGReviewManager.IsDelayedUntilLaterLevel;
            UnityEngine.Debug.LogFormat(format:  "WGReviewManager Network:{0} available:{1} timetoShow:{2} isDelayed:{3}", args:  val_3);
        }
        
        val_17 = 1152921504886665216;
        val_18 = null;
        val_18 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                val_17 = 1152921504973672448;
            val_19 = null;
            if(WGReviewManager.IsAvailable != false)
        {
                val_20 = null;
            if(WGReviewManager.TimeToShow != false)
        {
                val_21 = null;
            val_22 = (~WGReviewManager.IsDelayedUntilLaterLevel) & 1;
            return (bool)val_22;
        }
        
        }
        
        }
        
        val_22 = 0;
        return (bool)val_22;
    }
    public void HandleReviewSelected(int rating, bool forceTracking = False)
    {
        double val_8;
        var val_10;
        WGReviewManager.DeclinedReview = false;
        GameBehavior val_1 = App.getBehavior;
        if((rating - 1) <= 4)
        {
                var val_8 = 32496784 + ((rating - 1)) << 2;
            val_8 = val_8 + 32496784;
        }
        else
        {
                WGReviewManager.DeclinedReview = true;
            val_8 = 1;
            System.DateTime val_3 = DateTimeCheat.ServerNow;
            System.DateTime val_4 = val_3.dateData.AddDays(value:  val_8);
            WGReviewManager.NextReviewTime = new System.DateTime() {dateData = val_4.dateData};
            this.selectedRating = rating;
            val_10 = null;
            val_10 = null;
            new AggregateEventCalculator(name:  "rev_prmpt").Calculate(valueToAggregate:  new System.Decimal() {flags = System.Decimal.One, hi = System.Decimal.One, lo = System.Decimal.Powers10.__il2cppRuntimeField_20>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_20>>32&0x0}, autoFlush:  false);
            var val_6 = (rating == 5) ? 1 : 0;
            if((rating & 2147483648) == 0)
        {
                val_6 = val_6 | ((val_1.<metaGameBehavior>k__BackingField) | forceTracking);
            if((val_6 & 1) == 0)
        {
                return;
        }
        
        }
        
            this.DoAmpTracking(optionSelected:  "");
        }
    
    }
    public void DoAmpTracking(string optionSelected = "")
    {
        string val_14;
        var val_15;
        val_14 = optionSelected;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        int val_14 = this.selectedRating;
        val_14 = val_14 >> 31;
        val_14 = val_14 ^ 1;
        val_1.Add(key:  "Did Review", value:  val_14);
        val_1.Add(key:  "Rating", value:  this.selectedRating);
        AggregateEventCalculator val_2 = new AggregateEventCalculator(name:  "rev_prmpt");
        val_1.Add(key:  "Num Times Shown", value:  (AggregateEventCalculator)[1152921517521076624].aggregate);
        if((System.String.op_Inequality(a:  Player.GetLevelForTracking(), b:  "Game Name Not Set")) != false)
        {
                val_1.Add(key:  "Current Lvl", value:  Player.GetLevelForTracking());
        }
        
        if((System.String.op_Inequality(a:  Player.GetLevelNameForTracking(), b:  "Game Name Not Set")) != false)
        {
                val_1.Add(key:  "Current Lvl Name", value:  Player.GetLevelNameForTracking());
        }
        
        GameBehavior val_9 = App.getBehavior;
        if(((val_9.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_1.Add(key:  "Daily Challenge", value:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge);
        }
        
        if(this.selectedRating == 5)
        {
            goto label_21;
        }
        
        if((System.String.op_Equality(a:  val_14, b:  "")) != true)
        {
                if((this.selectedRating & 2147483648) == 0)
        {
            goto label_23;
        }
        
        }
        
        val_14 = "None";
        label_23:
        val_1.Add(key:  "Feedback", value:  val_14);
        label_21:
        val_15 = null;
        val_15 = null;
        App.trackerManager.track(eventName:  "Review Prompt", data:  val_1);
    }
    public void GrantNoAdTime()
    {
        System.DateTime val_3 = MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        System.DateTime val_4 = val_3.dateData.AddDays(value:  (double)this._freeNoAdsDuration);
        MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_4.dateData};
    }
    public void TryGrantFreeTrial()
    {
        GameBehavior val_1 = App.getBehavior;
        WGSubscriptionManager._subEntryPoint = 0;
    }
    public void LoadAppReview()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "google_api_review_pref")) == true)
        {
                return;
        }
        
        if(this.reviewManager == null)
        {
                this.reviewManager = new Google.Play.Review.ReviewManager();
        }
        
        if(this._playReviewInfo != null)
        {
                return;
        }
        
        if(this.initializingRManager != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.InitReviewManager());
    }
    public void ShowInAppReview()
    {
        TrackingComponent.CurrentIntent = 6;
        if(this._playReviewInfo != null)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "google_api_review_pref")) == false)
        {
            goto label_4;
        }
        
        }
        
        UnityEngine.Debug.Log(message:  "EV: [WAD-6116] In-App Review Popup was alredy shown, open store for review");
        AppConfigs val_2 = App.Configuration;
        twelvegigs.plugins.SharePlugin.OpenURL(url:  val_2.appConfig.Key(key:  "marketUrl"));
        return;
        label_4:
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.LaunchAppReview());
    }
    private System.Collections.IEnumerator InitReviewManager()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewManager.<InitReviewManager>d__41();
    }
    private System.Collections.IEnumerator LaunchAppReview()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGReviewManager.<LaunchAppReview>d__42();
    }
    public WGReviewManager()
    {
        this._freeNoAdsDuration = 3;
        this._freeTrialDuration = 0;
        this.selectedRating = 0;
    }
    private static WGReviewManager()
    {
        var val_1;
        var val_2;
        WGReviewManager.GOOGLE_API_REVIEW_PREF = 15;
        WGReviewManager.ReviewFiveStarDelay = 16;
        val_1 = null;
        WGReviewManager._declinedReview = false;
        val_2 = null;
        val_2 = null;
        val_1 = 1152921504973672632;
        WGReviewManager._NextReviewTime = System.DateTime.MinValue;
    }

}

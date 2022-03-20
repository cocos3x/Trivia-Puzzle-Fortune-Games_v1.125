using UnityEngine;
public class WGDailyBonusManager : MonoSingleton<WGDailyBonusManager>
{
    // Fields
    private static int DB_Version;
    private bool hasSeenThisSession;
    public DailyBonusRevealedRewardInfo revealedRewardInfo;
    private DailyBonusUIState _bonusUIState;
    public bool playingVideo;
    public bool justCollectedReward;
    public UnityEngine.GameObject bonusPopup;
    
    // Properties
    private System.DateTime GetLocalServerTime { get; }
    private System.DateTime LastCollectTime { get; set; }
    private bool isReadyToCollect { get; }
    public DailyBonusUIState bonusUIstate { get; set; }
    
    // Methods
    private System.DateTime get_GetLocalServerTime()
    {
        return DateTimeCheat.Now;
    }
    private System.DateTime get_LastCollectTime()
    {
        string val_13;
        var val_14;
        int val_15;
        var val_17;
        bool val_1 = CPlayerPrefs.HasKey(key:  "wg_last_daily_bonus");
        if(val_1 == false)
        {
            goto label_3;
        }
        
        val_13 = UnityEngine.PlayerPrefs.GetInt(key:  "db_ver", defaultValue:  1);
        val_14 = null;
        val_14 = null;
        val_15 = WGDailyBonusManager.DB_Version;
        if(val_13 >= val_15)
        {
            goto label_6;
        }
        
        val_15 = WGDailyBonusManager.DB_Version;
        UnityEngine.PlayerPrefs.SetInt(key:  "db_ver", value:  val_15);
        System.DateTime val_3 = System.DateTime.UtcNow;
        goto label_11;
        label_3:
        System.DateTime val_4 = val_1.GetLocalServerTime;
        System.DateTime val_5 = val_4.dateData.AddDays(value:  -2);
        CPlayerPrefs.SetString(key:  "wg_last_daily_bonus", val:  val_5.dateData.ToString());
        val_13 = 1152921504986398720;
        val_17 = null;
        val_17 = null;
        UnityEngine.PlayerPrefs.SetInt(key:  "db_ver", value:  WGDailyBonusManager.DB_Version);
        System.DateTime val_7 = GetLocalServerTime;
        label_11:
        System.DateTime val_8 = val_7.dateData.AddDays(value:  -2);
        return (System.DateTime)val_12.dateData;
        label_6:
        val_13 = CPlayerPrefs.GetString(key:  "wg_last_daily_bonus");
        System.DateTime val_10 = System.DateTime.UtcNow;
        System.DateTime val_11 = val_10.dateData.AddDays(value:  -2);
        System.DateTime val_12 = SLCDateTime.Parse(dateTime:  val_13, defaultValue:  new System.DateTime() {dateData = val_11.dateData});
        return (System.DateTime)val_12.dateData;
    }
    private void set_LastCollectTime(System.DateTime value)
    {
        CPlayerPrefs.SetString(key:  "wg_last_daily_bonus", val:  value.dateData.ToString());
        CPlayerPrefs.Save();
        Player val_2 = App.Player;
        val_2.last_daily_credits = value;
    }
    private bool get_isReadyToCollect()
    {
        System.DateTime val_1 = this.GetLocalServerTime;
        System.DateTime val_2 = val_1.dateData.LastCollectTime;
        GameEcon val_3 = App.getGameEcon;
        System.DateTime val_4 = val_2.dateData.AddHours(value:  (double)val_3.dailyBonusHours);
        int val_5 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_4.dateData});
        val_5 = (val_5 >> 31) ^ 1;
        return (bool)val_5;
    }
    public DailyBonusUIState get_bonusUIstate()
    {
        return (DailyBonusUIState)this._bonusUIState;
    }
    public void set_bonusUIstate(DailyBonusUIState value)
    {
        this._bonusUIState = value;
    }
    private void ShowDailyBonusPopup(bool showNext = True)
    {
        if((this.isReadyToCollect != true) && (this.hasSeenThisSession != false))
        {
                return;
        }
        
        this.revealedRewardInfo = 0;
        this.playingVideo = false;
        this.hasSeenThisSession = true;
        this.UpdateUIState();
        GameBehavior val_2 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9F0;
    }
    private void ShowInternetRequiredPopup(System.Func<bool>[] buttonCallbacks)
    {
        int val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "try_again_upper", defaultValue:  "TRY AGAIN", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "no_video_upper", defaultValue:  "NO VIDEO AVAILABLE", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "video_unavailable_explanation", defaultValue:  "No Rewarded Video Available.", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  true, buttonCallbacks:  buttonCallbacks, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void OnVideoResponse(Notification notif)
    {
        if((System.Boolean.Parse(value:  notif.data.ToString())) == false)
        {
                return;
        }
        
        this.revealedRewardInfo = 0;
        this.playingVideo = false;
        this._bonusUIState = 2;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "UpdateDailyBonusUI");
    }
    private void CloseBonusPopup()
    {
        if(this.bonusPopup == 0)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.bonusPopup, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        this.bonusPopup = 0;
    }
    public void UpdateUIState()
    {
        var val_6;
        if(this.isReadyToCollect == false)
        {
            goto label_1;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_6;
        }
        
        val_6 = 4;
        goto label_13;
        label_1:
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_12;
        }
        
        val_6 = 5;
        goto label_13;
        label_6:
        this._bonusUIState = 0;
        return;
        label_12:
        label_13:
        this._bonusUIState = (((val_3.<metaGameBehavior>k__BackingField.IsReadyToShowRewardedVideo()) & true) != 0) ? 3 : (0 + 1);
    }
    public void ResetReadyToCollectState()
    {
        this.justCollectedReward = false;
    }
    public bool IsReadyToShowRewardedVideo()
    {
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) == false)
        {
                return MonoSingletonSelfGenerating<AdsManager>.Instance.VideoEnabledAndUnlocked();
        }
        
        return false;
    }
    public void RemoveVideoObserver()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnVideoResponse");
    }
    public void AddVideoObserver()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
    }
    public void HandleCollected()
    {
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        if(this.isReadyToCollect == false)
        {
                return;
        }
        
        val_6 = null;
        val_6 = null;
        WGFreeHintPopup.dailyCollected = true;
        System.DateTime val_2 = GetLocalServerTime;
        val_2.dateData.LastCollectTime = new System.DateTime() {dateData = val_2.dateData};
        WGGenericNotificationsManager.SendDailyBonusNotification(QAHACK_Force:  false);
        val_7 = null;
        val_7 = null;
        if(App.game == 17)
        {
                GameBehavior val_3 = App.getBehavior;
            if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_8 = 5;
        }
        
            this._bonusUIState = (((val_3.<metaGameBehavior>k__BackingField.IsReadyToShowRewardedVideo()) & true) != 0) ? 3 : (0 + 1);
        }
        
        this.justCollectedReward = true;
        val_9 = null;
        val_9 = null;
        App.trackerManager.track(eventName:  Events.DAILY_BONUS);
    }
    public bool CheckAvailable()
    {
        var val_4;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((val_1.<metaGameBehavior>k__BackingField.isReadyToCollect) == false)
        {
                return (bool)(this.hasSeenThisSession == false) ? 1 : 0;
        }
        
            val_4 = 1;
            return (bool)(this.hasSeenThisSession == false) ? 1 : 0;
        }
        
        val_4 = 0;
        return (bool)(this.hasSeenThisSession == false) ? 1 : 0;
    }
    public void ForceUpdateLastCollectTime(System.DateTime time)
    {
        this.LastCollectTime = new System.DateTime() {dateData = time.dateData};
    }
    public System.DateTime GetLastCollectTime()
    {
        return this.LastCollectTime;
    }
    public int GetReward()
    {
        System.Collections.Generic.Dictionary<System.Int32, DailyBonusTier> val_23;
        int val_24;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
            goto label_16;
        }
        
        GameEcon val_2 = App.getGameEcon;
        val_23 = val_2.dailyBonusTiers;
        int val_3 = val_23.Count;
        if(val_3 == 0)
        {
            goto label_16;
        }
        
        if(val_3.isReadyToCollect != true)
        {
                if(val_5.dailyBonusVideoRewards == null)
        {
            goto label_16;
        }
        
        }
        
        var val_24 = null;
        if(App.getGameEcon.isReadyToCollect == false)
        {
            goto label_17;
        }
        
        GameEcon val_7 = App.getGameEcon;
        if(val_7.dailyBonusTiers.Count < 1)
        {
            goto label_22;
        }
        
        label_32:
        DailyBonusTier val_10 = val_7.dailyBonusTiers.Item[0 + 1];
        decimal val_12 = System.Decimal.op_Implicit(value:  System.Convert.ToInt32(value:  val_10.threshold));
        Player val_13 = App.Player;
        if((System.Decimal.op_LessThanOrEqual(d1:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, d2:  new System.Decimal() {flags = val_13._credits, hi = val_13._credits})) == false)
        {
            goto label_31;
        }
        
        val_24 = 0 + 1;
        if((0 + 2) < val_7.dailyBonusTiers.Count)
        {
            goto label_32;
        }
        
        goto label_43;
        label_16:
        GameEcon val_17 = App.getGameEcon;
        return (int)val_17.dbFtuxCr;
        label_17:
        GameEcon val_18 = App.getGameEcon;
        int val_19 = UnityEngine.Random.Range(min:  0, max:  269157872);
        if(val_24 <= val_19)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24 = val_24 + (val_19 << 2);
        return (int)val_17.dbFtuxCr;
        label_22:
        val_24 = 0;
        goto label_43;
        label_31:
        val_24 = 0;
        label_43:
        if(val_24 == 1)
        {
                val_24 = val_7.dailyBonusTiers.Count - 1;
        }
        
        DailyBonusTier val_21 = val_7.dailyBonusTiers.Item[val_24];
        System.Collections.Generic.List<System.Object> val_25 = val_21.rewards;
        int val_22 = UnityEngine.Random.Range(min:  0, max:  val_24);
        DailyBonusTier val_23 = val_7.dailyBonusTiers.Item[val_24];
        if(val_25 <= val_22)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_25 = val_25 + (val_22 << 3);
        return System.Convert.ToInt32(value:  val_23.rewards);
    }
    public void ShowVideo(bool result)
    {
        var val_11;
        if((MonoSingleton<ApplovinMaxPlugin>.Instance.IsVideoAvailable()) != false)
        {
                this.playingVideo = MonoSingleton<AdsUIController>.Instance.ShowIncentivizedVideo(tag:  4, adCapExempt:  false);
            return;
        }
        
        System.Func<System.Boolean>[] val_6 = new System.Func<System.Boolean>[1];
        val_6[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean WGDailyBonusManager::<ShowVideo>b__31_0());
        X0.ShowInternetRequiredPopup(buttonCallbacks:  val_6);
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_11 = 5;
        }
        
        this._bonusUIState = (((val_8.<metaGameBehavior>k__BackingField.IsReadyToShowRewardedVideo()) & true) != 0) ? 3 : (0 + 1);
        this.CloseBonusPopup();
    }
    public void ShowPostPopups()
    {
        UnityEngine.Object val_23;
        var val_24;
        var val_25;
        val_23 = this;
        val_24 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        if(this.justCollectedReward == false)
        {
                return;
        }
        
        Player val_2 = App.Player;
        if(val_2.total_purchased > 0f)
        {
            goto label_18;
        }
        
        GameBehavior val_3 = App.getBehavior;
        GameEcon val_4 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_3.<metaGameBehavior>k__BackingField, knobValue:  val_4.freeHintPostDailyBonus)) == false)
        {
            goto label_18;
        }
        
        val_25 = (~(MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached)) & 1;
        goto label_22;
        label_18:
        val_25 = 0;
        label_22:
        GameBehavior val_8 = App.getBehavior;
        if((((val_8.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<WGSubscriptionManager>.Instance) == 0))
        {
            goto label_32;
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == false)
        {
            goto label_63;
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  1)) == false)
        {
            goto label_40;
        }
        
        label_32:
        label_63:
        if((val_25 & 0) != 0)
        {
            goto label_41;
        }
        
        if((UnityEngine.Random.Range(min:  0, max:  2)) >= 1)
        {
            goto label_42;
        }
        
        goto label_43;
        label_41:
        if((0 & 1) == 0)
        {
            goto label_44;
        }
        
        label_43:
        this.ShowSubPopup();
        goto label_46;
        label_44:
        if(val_25 == 0)
        {
            goto label_46;
        }
        
        label_42:
        this.ShowFreeHintPopup();
        label_46:
        val_24 = 1152921517761363216;
        val_23 = MonoSingleton<WGMoreGamesManager>.Instance;
        if(val_23 == 0)
        {
                return;
        }
        
        MonoSingleton<WGMoreGamesManager>.Instance.ShowPopupDuringBonusCollectFlow();
        return;
        label_40:
        GameBehavior val_19 = App.getBehavior;
        GameEcon val_20 = App.getGameEcon;
        bool val_21 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_19.<metaGameBehavior>k__BackingField, knobValue:  val_20.subscriptionPromoPostDailyBonusLevel);
        goto label_63;
    }
    private void ShowSubPopup()
    {
        GameBehavior val_2 = App.getBehavior;
        .wgSWP = val_2.<metaGameBehavior>k__BackingField;
        mem2[0] = MonoSingleton<WGSubscriptionManager>.Instance.silverTicketUnlocked;
        WGSubscriptionManager._subEntryPoint = ((MonoSingleton<WGSubscriptionManager>.Instance.silverTicketUnlocked) != true) ? 57 : 32;
        System.Delegate val_11 = System.Delegate.Combine(a:  (WGDailyBonusManager.<>c__DisplayClass33_0)[1152921517761660240].wgSWP.onCloseAction, b:  new System.Action(object:  new WGDailyBonusManager.<>c__DisplayClass33_0(), method:  System.Void WGDailyBonusManager.<>c__DisplayClass33_0::<ShowSubPopup>b__0()));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        (WGDailyBonusManager.<>c__DisplayClass33_0)[1152921517761660240].wgSWP.onCloseAction = val_11;
        return;
        label_16:
    }
    private void ShowFreeHintPopup()
    {
        var val_4;
        var val_5;
        GameBehavior val_1 = App.getBehavior;
        val_4 = null;
        val_4 = null;
        val_5 = null;
        val_5 = null;
        var val_3 = (App.game == 17) ? 1 : 0;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
    }
    public void TryShowDailyBonus()
    {
        this.ShowDailyBonusPopup(showNext:  false);
    }
    public WGDailyBonusManager()
    {
    
    }
    private static WGDailyBonusManager()
    {
        WGDailyBonusManager.DB_Version = 2;
    }
    private bool <ShowVideo>b__31_0()
    {
        this.ShowVideo(result:  false);
        return true;
    }

}

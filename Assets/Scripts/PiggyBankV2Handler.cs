using UnityEngine;
public class PiggyBankV2Handler : WGEventHandler
{
    // Fields
    private static PiggyBankV2Handler _Instance;
    public const string PIGGY_BANK_V2_EVENT_ID = "PiggyBankV2";
    private const string piggyBankDataKey = "pbv2EventData";
    private const string pbNextReceiveKey = "pbv2NextReceive";
    private const string pbNextPiggyTierKey = "pbv2NextPiggyTier";
    private const string pbLastCollectedKey = "pbv2LastRewardCollected";
    private const string pbCurrencyGainedKey = "pbv2CurrencyGained";
    private const string pbCurrencyPendingKey = "pbv2CurrencyPending";
    private const string pbExpireTimeKey = "pbv2ExpireTime";
    private const string pbPackageTierKey = "pbv2PackageTier";
    private const string pbIsTriggeredKey = "pbv2IsTriggered";
    private const string pbLastProgressKey = "pbv2LastProgress";
    private const string eventLapse = "lapsed_duration_days";
    private const string eventLongTermNonPayer = "long_term_non_payer_days";
    private const string eventExpire = "event_duration_days";
    private const string eventpromptCooldown = "prompt_cool_seconds";
    private const string eventFeatureCooldown = "feature_cool_days";
    private int lapseDurationDays;
    private int longTermNonPayer;
    private int promptCooldownSeconds;
    private int featureCooldownDays;
    private int eventDurationDays;
    private int <GoldCurrencyGained>k__BackingField;
    private int goldCurrencyTarget;
    private int GoldCurrencyPending;
    private int packageTier;
    private decimal initialBankAmount;
    private System.DateTime piggyBankNextReceiveTime;
    private System.DateTime bundleExpireTime;
    private bool isTriggered;
    private string <PackageID>k__BackingField;
    private decimal <BankAmountMax>k__BackingField;
    private PurchaseModel purchaseModel;
    private bool <BankFull>k__BackingField;
    private int <GoldCurrencyGainedOld>k__BackingField;
    private bool <EventEnded>k__BackingField;
    private PiggyBankV2Econ econ;
    private System.DateTime promptCooldownTime;
    private TrackerPurchasePoints purchasePoint;
    public static bool hackIgnoreLastPurchase;
    private string lastPackageLogic;
    private const int minDowngradeTier = 1;
    public System.Action<bool> OnPurchaseAttemptResult;
    private bool shownApplicationLoadedAdvert;
    
    // Properties
    public static PiggyBankV2Handler Instance { get; }
    public int GoldCurrencyGained { get; set; }
    public int GoldCurrencyTarget { get; }
    public string PackageID { get; set; }
    public decimal BankAmountMax { get; set; }
    public bool BankFull { get; set; }
    public int GoldCurrencyGainedOld { get; set; }
    public bool EventEnded { get; set; }
    public string PricePurchaseString { get; }
    public decimal BankAmountCurrent { get; }
    public decimal BankAmountOld { get; }
    private static int LastProgressTimestampPref { get; set; }
    public override bool SupportsGoldenApples { get; }
    public override bool IsEventHidden { get; }
    public override bool OverrideEventButton { get; }
    
    // Methods
    public static PiggyBankV2Handler get_Instance()
    {
        return (PiggyBankV2Handler)PiggyBankV2Handler.minDowngradeTier;
    }
    public int get_GoldCurrencyGained()
    {
        return (int)this.<GoldCurrencyGained>k__BackingField;
    }
    private void set_GoldCurrencyGained(int value)
    {
        this.<GoldCurrencyGained>k__BackingField = value;
    }
    public int get_GoldCurrencyTarget()
    {
        return (int)this.goldCurrencyTarget;
    }
    public string get_PackageID()
    {
        return (string)this.<PackageID>k__BackingField;
    }
    private void set_PackageID(string value)
    {
        this.<PackageID>k__BackingField = value;
    }
    public decimal get_BankAmountMax()
    {
        return new System.Decimal() {flags = this.<BankAmountMax>k__BackingField, hi = this.<BankAmountMax>k__BackingField};
    }
    private void set_BankAmountMax(decimal value)
    {
        this.<BankAmountMax>k__BackingField = value;
        mem[1152921516593581328] = value.lo;
        mem[1152921516593581332] = value.mid;
    }
    public bool get_BankFull()
    {
        return (bool)this.<BankFull>k__BackingField;
    }
    private void set_BankFull(bool value)
    {
        this.<BankFull>k__BackingField = value;
    }
    public int get_GoldCurrencyGainedOld()
    {
        return (int)this.<GoldCurrencyGainedOld>k__BackingField;
    }
    private void set_GoldCurrencyGainedOld(int value)
    {
        this.<GoldCurrencyGainedOld>k__BackingField = value;
    }
    public bool get_EventEnded()
    {
        return (bool)this.<EventEnded>k__BackingField;
    }
    private void set_EventEnded(bool value)
    {
        this.<EventEnded>k__BackingField = value;
    }
    public string get_PricePurchaseString()
    {
        if(this.purchaseModel != null)
        {
                return this.purchaseModel.LocalPrice;
        }
        
        throw new NullReferenceException();
    }
    public decimal get_BankAmountCurrent()
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  this.<GoldCurrencyGained>k__BackingField);
        return System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this.initialBankAmount, hi = this.initialBankAmount});
    }
    public decimal get_BankAmountOld()
    {
        decimal val_1 = System.Decimal.op_Implicit(value:  this.<GoldCurrencyGainedOld>k__BackingField);
        return System.Decimal.op_Addition(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = this.initialBankAmount, hi = this.initialBankAmount});
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "pbv2LastProgress", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pbv2LastProgress", value:  value);
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override bool get_IsEventHidden()
    {
        if(this.isTriggered == false)
        {
                return true;
        }
        
        return this.HasExpired();
    }
    public override void Init(GameEventV2 eventV2)
    {
        ulong val_10;
        mem[1152921516595169808] = eventV2;
        PiggyBankV2Handler.minDowngradeTier = this;
        this.ParseEventData(eventData:  PiggyBankV2Handler.minDowngradeTier.__il2cppRuntimeField_68);
        if(this.IsEventAvailable() != false)
        {
                this.LoadData();
            System.DateTime val_2 = DateTimeCheat.UtcNow;
            this.promptCooldownTime = val_2;
            this.<GoldCurrencyGainedOld>k__BackingField = this.<GoldCurrencyGained>k__BackingField;
            if(val_2.dateData.HasExistingData() != false)
        {
                if(this.HasExpired() != true)
        {
                if(this.isTriggered == true)
        {
                return;
        }
        
        }
        
        }
        
            val_10 = mem[this.isTriggered + 40];
            val_10 = this.isTriggered + 40;
            if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = this.isTriggered + 24}, t2:  new System.DateTime() {dateData = val_10})) != true)
        {
                if(this.HasExpired() == false)
        {
            goto label_12;
        }
        
        }
        
        }
        
        this.<EventEnded>k__BackingField = true;
        return;
        label_12:
        this.ResetSaveData();
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.<BankFull>k__BackingField = false;
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.DateTime val_8 = val_7.dateData.AddDays(value:  (double)this.eventDurationDays);
        this.bundleExpireTime = val_8;
        this.isTriggered = false;
        this.SaveData();
        GameBehavior val_9 = App.getBehavior;
        if((val_9.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
    
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "piggy_bank")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail();
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "piggy_bank")) == false)
        {
                return;
        }
        
        this.OnPurchaseSuccess();
    }
    public override void OnProcessPurchase(ref PurchaseModel purchase)
    {
        var val_9;
        var val_10;
        var val_14;
        val_10 = 1152921516595599216;
        if(purchase == null)
        {
                throw new NullReferenceException();
        }
        
        if(purchase.id == null)
        {
                throw new NullReferenceException();
        }
        
        if((purchase.id.Contains(value:  "piggy_bank")) == false)
        {
                return;
        }
        
        System.Collections.IList val_2 = PackagesManager.GetPackages(packageType:  "credits");
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        val_9 = val_2.GetEnumerator();
        goto label_22;
        label_28:
        var val_12 = 0;
        val_12 = val_12 + 1;
        new PurchaseModel() = new PurchaseModel(json:  val_9.Current);
        if(new PurchaseModel() == null)
        {
                throw new NullReferenceException();
        }
        
        if(purchase == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  (PurchaseModel)[1152921516595615552].id, b:  purchase.id)) != false)
        {
                if(purchase == null)
        {
                throw new NullReferenceException();
        }
        
            sale_price = (PurchaseModel)[1152921516595615552].sale_price;
        }
        
        label_22:
        var val_13 = 0;
        val_13 = val_13 + 1;
        if(val_9.MoveNext() == true)
        {
            goto label_28;
        }
        
        val_10 = 0;
        if(X0 == false)
        {
            goto label_29;
        }
        
        var val_16 = X0;
        val_9 = X0;
        if((X0 + 294) == 0)
        {
            goto label_33;
        }
        
        var val_14 = X0 + 176;
        var val_15 = 0;
        val_14 = val_14 + 8;
        label_32:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_31;
        }
        
        val_15 = val_15 + 1;
        val_14 = val_14 + 16;
        if(val_15 < (X0 + 294))
        {
            goto label_32;
        }
        
        goto label_33;
        label_31:
        val_16 = val_16 + (((X0 + 176 + 8)) << 4);
        val_14 = val_16 + 304;
        label_33:
        val_9.Dispose();
        label_29:
        if(val_10 != 0)
        {
                throw val_10;
        }
    
    }
    public override void OnAppleAwarded(int appleAwarded)
    {
        if((this.<BankFull>k__BackingField) != false)
        {
                return;
        }
        
        if(this.isTriggered == false)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) == true)
        {
                return;
        }
        
        int val_1 = this.GoldCurrencyPending;
        val_1 = val_1 + appleAwarded;
        this.GoldCurrencyPending = val_1;
        this.SaveData();
    }
    public override void OnGameSceneBegan()
    {
        if(this.isTriggered == true)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) == true)
        {
                return;
        }
        
        if(this.HasLapsedPurchase() == false)
        {
                return;
        }
        
        this.DetermineBundle();
        this.ShowPreviewPopup();
        this.isTriggered = true;
        this.SaveData();
    }
    public override void OnMenuLoaded()
    {
        if((this.<BankFull>k__BackingField) == false)
        {
                return;
        }
        
        if(this.HasExpired() == true)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) == true)
        {
                return;
        }
        
        if(this.shownApplicationLoadedAdvert == true)
        {
                return;
        }
        
        this.purchasePoint = 51;
        this.ShowMainPopup(endOfChapter:  false, flyout:  false);
        this.shownApplicationLoadedAdvert = true;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankV2Handler::<OnLevelComplete>b__86_0()), ignoreTimeScale:  true);
    }
    public override void OnDailyChallengeLevelComplete()
    {
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankV2Handler::<OnDailyChallengeLevelComplete>b__87_0()), ignoreTimeScale:  true);
    }
    public override void OnDailyChallengeRewardGranted()
    {
        if(this.GoldCurrencyPending < 1)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  false, flyout:  false);
    }
    public override void OnBonusGameGoldCurrencyRewardGranted()
    {
        if(this.GoldCurrencyPending < 1)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  false, flyout:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        if((this.<BankFull>k__BackingField) != false)
        {
                this.purchasePoint = 51;
        }
        
        this.ShowMainPopup(endOfChapter:  false, flyout:  false);
    }
    public override bool get_OverrideEventButton()
    {
        return true;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        if((this.<BankFull>k__BackingField) != false)
        {
                this.purchasePoint = 53;
        }
        
        this.ShowMainPopup(endOfChapter:  false, flyout:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        decimal val_1 = this.BankAmountCurrent;
        GameEcon val_2 = App.getGameEcon;
        string val_3 = val_1.flags.ToString(format:  val_2.numberFormatInt);
        EventListItemContentPiggyBankV2 val_4 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentPiggyBankV2>(allowMultiple:  false);
        float val_5 = (float)this.<GoldCurrencyGained>k__BackingField;
        val_5 = val_5 / (float)this.goldCurrencyTarget;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Piggy Bank Tier", value:  this.packageTier);
        currentData.Add(key:  "Piggy Bank Max Fund", value:  this.<BankFull>k__BackingField);
    }
    public override void OnEventEnded()
    {
        this.ResetSaveData();
    }
    public override void UpdateProgress()
    {
        PiggyBankV2Handler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override int LastProgressTimestamp()
    {
        return PiggyBankV2Handler.LastProgressTimestampPref;
    }
    public override bool EventCompleted()
    {
        if((this.<EventEnded>k__BackingField) != false)
        {
                return true;
        }
        
        if((this.<BankFull>k__BackingField) == false)
        {
                return false;
        }
        
        return this.HasExpired();
    }
    public override bool IsRewardReadyToCollect()
    {
        return (bool)this.<BankFull>k__BackingField;
    }
    public override System.DateTime GetTimeEnd()
    {
        return (System.DateTime)this.bundleExpireTime;
    }
    public override string GetMainMenuButtonText()
    {
        bool val_1 = this.HasExpired();
        decimal val_3 = this.BankAmountCurrent;
        GameEcon val_4 = App.getGameEcon;
        return (string)System.String.Format(format:  "{0}\n{1} {2}", arg0:  Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false), arg1:  val_3.flags.ToString(format:  val_4.numberFormatInt), arg2:  Localization.Localize(key:  "coins_upper", defaultValue:  "COINS", useSingularKey:  false));
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false);
    }
    public override string GetCustomizedEventListItemTimerText()
    {
        System.TimeSpan val_1 = this.GetTimeRemaining();
        return (string)System.String.Format(format:  "{0}d {1}h {2}m", arg0:  val_1._ticks.Days, arg1:  val_1._ticks.Hours, arg2:  val_1._ticks.Minutes);
    }
    public System.TimeSpan GetTimeRemaining()
    {
        var val_3;
        if(this.HasExpired() != false)
        {
                val_3 = null;
            val_3 = null;
            return (System.TimeSpan)System.TimeSpan.Zero;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        return this.bundleExpireTime.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
    }
    public bool IsEventAvailable()
    {
        var val_3;
        if(this.HasExistingData() != false)
        {
                val_3 = 1;
            return (bool)val_3;
        }
        
        if(this.HasPassedFeatureCooldown() != false)
        {
                return this.HasLapsedPurchase();
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public void TryPurchase()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = this.purchasePoint;
        PurchaseModel val_2 = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  this.<PackageID>k__BackingField));
        decimal val_3 = this.BankAmountCurrent;
        val_2.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        bool val_4 = PurchaseProxy.Purchase(purchase:  val_2);
    }
    public void ResetGoldGainedOld()
    {
        this.<GoldCurrencyGainedOld>k__BackingField = this.<GoldCurrencyGained>k__BackingField;
    }
    public void AddGoldGained()
    {
        int val_1 = this.GoldCurrencyPending;
        this.GoldCurrencyPending = 0;
        val_1 = val_1 + (this.<GoldCurrencyGained>k__BackingField);
        this.<GoldCurrencyGained>k__BackingField = val_1;
        if(val_1 >= this.goldCurrencyTarget)
        {
                this.<GoldCurrencyGained>k__BackingField = this.goldCurrencyTarget;
            this.<BankFull>k__BackingField = true;
        }
        
        this.SaveData();
    }
    public void OnPurchaseSuccess()
    {
        this.TrackPurchaseMade();
        UnityEngine.PlayerPrefs.DeleteKey(key:  "pbv2NextPiggyTier");
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromDays(value:  (double)this.featureCooldownDays);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.piggyBankNextReceiveTime = val_3;
        this.<EventEnded>k__BackingField = true;
        this.ResetSaveData();
        this.OnPurchaseAttemptResult.Invoke(obj:  true);
        goto typeof(PiggyBankV2Handler).__il2cppRuntimeField_2B0;
    }
    private void TrackPurchaseMade()
    {
        var val_2 = null;
        App.trackerManager.track(eventName:  this.<PackageID>k__BackingField.Replace(oldValue:  "id_piggy_bank_", newValue:  "purchase_piggy_"));
    }
    public void OnPurchaseFail()
    {
        this.OnPurchaseAttemptResult.Invoke(obj:  false);
    }
    private bool HasExistingData()
    {
        bool val_2 = System.String.IsNullOrEmpty(value:  UnityEngine.PlayerPrefs.GetString(key:  "pbv2EventData", defaultValue:  ""));
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    private bool HasPassedFeatureCooldown()
    {
        var val_5;
        System.DateTime val_6;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbv2NextReceive", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) == false)
        {
            goto label_1;
        }
        
        val_5 = null;
        val_5 = null;
        val_6 = System.DateTime.MinValue;
        if(this != null)
        {
            goto label_4;
        }
        
        label_1:
        System.DateTime val_3 = SLCDateTime.Parse(dateTime:  val_1);
        val_6 = val_3.dateData;
        label_4:
        this.piggyBankNextReceiveTime = val_3;
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_6}, t2:  new System.DateTime() {dateData = val_4.dateData});
    }
    private bool HasExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if(((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = this.bundleExpireTime}, t2:  new System.DateTime() {dateData = val_1.dateData})) != false) && ((this.<EventEnded>k__BackingField) != true))
        {
                this.<EventEnded>k__BackingField = true;
            this.ResetSaveData();
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = this.bundleExpireTime}, t2:  new System.DateTime() {dateData = val_3.dateData});
    }
    private bool CanShowInterstitialPopup()
    {
        if(this.GoldCurrencyPending < 1)
        {
                return false;
        }
        
        return (bool)((this.<EventEnded>k__BackingField) == false) ? 1 : 0;
    }
    private bool CanShowReadyPopup()
    {
        var val_5;
        if(((this.<BankFull>k__BackingField) != false) && (this.HasExpired() != true))
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = this.promptCooldownTime})) != false)
        {
                var val_4 = ((this.<EventEnded>k__BackingField) == false) ? 1 : 0;
            return (bool)val_5;
        }
        
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    private bool HasLapsedPurchase()
    {
        Player val_1 = App.Player;
        if(val_1.num_purchase < 1)
        {
                return true;
        }
        
        if(PiggyBankV2Handler.hackIgnoreLastPurchase != false)
        {
                return true;
        }
        
        Player val_2 = App.Player;
        System.TimeSpan val_3 = System.TimeSpan.FromDays(value:  (double)this.lapseDurationDays);
        System.DateTime val_4 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_2.last_purchase}, t:  new System.TimeSpan() {_ticks = val_3._ticks});
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = val_5.dateData});
    }
    private void SetPurchaseModel()
    {
        if((System.String.IsNullOrEmpty(value:  this.<PackageID>k__BackingField)) == true)
        {
                return;
        }
        
        this.purchaseModel = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  this.<PackageID>k__BackingField));
    }
    private void OnGoldCurrencyTargetMet()
    {
        this.<BankFull>k__BackingField = true;
    }
    private void SetPromptCooldownTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromSeconds(value:  (double)this.promptCooldownSeconds);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.promptCooldownTime = val_3;
    }
    private void ShowPreviewPopup()
    {
        mem2[0] = 1;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankV2Popup>(showNext:  false).SetupMain();
    }
    private void ShowMainPopup(bool endOfChapter = False, bool flyout = False)
    {
        if(flyout == false)
        {
            goto label_1;
        }
        
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != null)
        {
            goto label_6;
        }
        
        label_1:
        label_6:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankV2Popup>(showNext:  false).SetupMain();
        this.SetPromptCooldownTime();
    }
    private void ShowInterstitialPopup(bool endOfChapter = False, bool flyout = False)
    {
        var val_5;
        this.AddGoldGained();
        if(flyout == false)
        {
            goto label_1;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_5 = val_1.<metaGameBehavior>k__BackingField;
        if(val_5 != null)
        {
            goto label_6;
        }
        
        label_1:
        WGWindowManager val_4 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankV2Popup>(showNext:  true);
        label_6:
        mem2[0] = 1;
        this.SetPromptCooldownTime();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        if((eventData.ContainsKey(key:  "lapsed_duration_days")) != false)
        {
                object val_2 = eventData.Item["lapsed_duration_days"];
            this.lapseDurationDays = null;
        }
        
        if((eventData.ContainsKey(key:  "long_term_non_payer_days")) != false)
        {
                object val_4 = eventData.Item["long_term_non_payer_days"];
            this.longTermNonPayer = null;
        }
        
        if((eventData.ContainsKey(key:  "event_duration_days")) != false)
        {
                object val_6 = eventData.Item["event_duration_days"];
            this.eventDurationDays = null;
        }
        
        if((eventData.ContainsKey(key:  "prompt_cool_seconds")) != false)
        {
                object val_8 = eventData.Item["prompt_cool_seconds"];
            this.promptCooldownSeconds = null;
        }
        
        if((eventData.ContainsKey(key:  "feature_cool_days")) == false)
        {
                return;
        }
        
        object val_10 = eventData.Item["feature_cool_days"];
        this.featureCooldownDays = null;
    }
    private void DetermineBundle()
    {
        string val_21;
        if(((UnityEngine.PlayerPrefs.GetInt(key:  "pbv2NextPiggyTier", defaultValue:  0)) & 2147483648) != 0)
        {
            goto label_1;
        }
        
        this.packageTier = UnityEngine.Mathf.Max(a:  1, b:  UnityEngine.PlayerPrefs.GetInt(key:  "pbv2NextPiggyTier"));
        val_21 = "loaded saved = {0}";
        goto label_41;
        label_1:
        this.packageTier = 0;
        Player val_4 = App.Player;
        Player val_5 = App.Player;
        float val_20 = (float)val_5.num_purchase;
        val_20 = val_4.total_purchased / val_20;
        val_20 = val_20 * 100f;
        if(val_20 >= 1499f)
        {
            goto label_9;
        }
        
        if(val_20 >= 899f)
        {
            goto label_10;
        }
        
        if(val_20 >= 399f)
        {
            goto label_11;
        }
        
        if(val_20 <= 0f)
        {
            goto label_12;
        }
        
        this.packageTier = 2;
        val_21 = "non-zero avg = {0}";
        goto label_41;
        label_9:
        this.packageTier = 5;
        val_21 = "high avg = {0}";
        goto label_41;
        label_10:
        this.packageTier = 4;
        val_21 = "mid avg = {0}";
        goto label_41;
        label_11:
        this.packageTier = 3;
        val_21 = "low avg = {0}";
        label_41:
        label_40:
        this.lastPackageLogic = System.String.Format(format:  val_21, arg0:  3);
        this.<PackageID>k__BackingField = this.econ.packageTierIDs[this.packageTier];
        this.goldCurrencyTarget = this.econ.goldCurrencyNeeded[this.packageTier];
        decimal val_7 = System.Decimal.op_Implicit(value:  this.econ.minBankFund[this.packageTier]);
        this.initialBankAmount = val_7;
        mem[1152921516601183100] = val_7.lo;
        mem[1152921516601183104] = val_7.mid;
        decimal val_8 = System.Decimal.op_Implicit(value:  this.econ.maxBankFund[this.packageTier]);
        this.<BankAmountMax>k__BackingField = val_8;
        mem[1152921516601183152] = val_8.lo;
        mem[1152921516601183156] = val_8.mid;
        UnityEngine.PlayerPrefs.SetInt(key:  "pbv2NextPiggyTier", value:  this.packageTier - 1);
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.<BankFull>k__BackingField = false;
        System.DateTime val_10 = DateTimeCheat.UtcNow;
        System.DateTime val_11 = val_10.dateData.AddDays(value:  (double)this.eventDurationDays);
        this.bundleExpireTime = val_11;
        System.DateTime val_12 = this.bundleExpireTime.AddDays(value:  (double)this.featureCooldownDays);
        this.piggyBankNextReceiveTime = val_12;
        this.isTriggered = false;
        this.SetPurchaseModel();
        this.SaveData();
        return;
        label_12:
        Player val_13 = App.Player;
        System.DateTime val_14 = DateTimeCheat.UtcNow;
        System.DateTime val_15 = val_14.dateData.AddDays(value:  (double)-this.longTermNonPayer);
        if((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_13.created_at}, t2:  new System.DateTime() {dateData = val_15.dateData})) < 1)
        {
            goto label_37;
        }
        
        this.packageTier = 1;
        System.DateTime val_17 = DateTimeCheat.UtcNow;
        System.DateTime val_18 = val_17.dateData.AddDays(value:  (double)-this.longTermNonPayer);
        string val_19 = System.String.Format(format:  "created after {1} {0}", arg0:  1, arg1:  val_18);
        goto label_40;
        label_37:
        this.packageTier = 0;
        goto label_41;
    }
    private void SaveData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "pbv2CurrencyGained", value:  this.<GoldCurrencyGained>k__BackingField);
        val_1.Add(key:  "pbv2CurrencyPending", value:  this.GoldCurrencyPending);
        val_1.Add(key:  "pbv2ExpireTime", value:  this.bundleExpireTime);
        val_1.Add(key:  "pbv2PackageTier", value:  this.packageTier);
        val_1.Add(key:  "pbv2IsTriggered", value:  this.isTriggered);
        UnityEngine.PlayerPrefs.SetString(key:  "pbv2NextReceive", value:  this.piggyBankNextReceiveTime.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "pbv2EventData", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void LoadData()
    {
        string val_20;
        if((System.String.IsNullOrEmpty(value:  UnityEngine.PlayerPrefs.GetString(key:  "pbv2EventData", defaultValue:  ""))) != false)
        {
                return;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "pbv2EventData", defaultValue:  ""));
        val_20 = "pbv2CurrencyGained";
        if((val_4.ContainsKey(key:  "pbv2CurrencyGained")) != false)
        {
                object val_6 = val_4.Item["pbv2CurrencyGained"];
            this.<GoldCurrencyGained>k__BackingField = null;
        }
        
        val_20 = "pbv2CurrencyPending";
        if((val_4.ContainsKey(key:  "pbv2CurrencyPending")) != false)
        {
                object val_8 = val_4.Item["pbv2CurrencyPending"];
            this.GoldCurrencyPending = null;
        }
        
        if((val_4.ContainsKey(key:  "pbv2ExpireTime")) != false)
        {
                val_20 = val_4.Item["pbv2ExpireTime"];
            System.DateTime val_11 = System.DateTime.UtcNow;
            if(val_20 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
            System.DateTime val_12 = SLCDateTime.Parse(dateTime:  val_20, defaultValue:  new System.DateTime() {dateData = val_11.dateData});
            this.bundleExpireTime = val_12;
        }
        
        val_20 = "pbv2PackageTier";
        if((val_4.ContainsKey(key:  "pbv2PackageTier")) != false)
        {
                object val_14 = val_4.Item["pbv2PackageTier"];
            this.packageTier = null;
        }
        
        val_20 = "pbv2IsTriggered";
        if((val_4.ContainsKey(key:  "pbv2IsTriggered")) != false)
        {
                object val_16 = val_4.Item["pbv2IsTriggered"];
            this.isTriggered = null;
        }
        
        this.<PackageID>k__BackingField = this.econ.packageTierIDs[this.packageTier];
        this.goldCurrencyTarget = this.econ.goldCurrencyNeeded[this.packageTier];
        decimal val_17 = System.Decimal.op_Implicit(value:  this.econ.minBankFund[this.packageTier]);
        this.initialBankAmount = val_17;
        mem[1152921516601879708] = val_17.lo;
        mem[1152921516601879712] = val_17.mid;
        decimal val_18 = System.Decimal.op_Implicit(value:  this.econ.maxBankFund[this.packageTier]);
        this.<BankAmountMax>k__BackingField = val_18;
        mem[1152921516601879760] = val_18.lo;
        mem[1152921516601879764] = val_18.mid;
        this.<BankFull>k__BackingField = ((this.<GoldCurrencyGained>k__BackingField) >= this.goldCurrencyTarget) ? 1 : 0;
        this.SetPurchaseModel();
        return;
        label_15:
    }
    private void ResetSaveData()
    {
        null = null;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = this.piggyBankNextReceiveTime}, t2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "pbv2NextReceive", value:  this.piggyBankNextReceiveTime.ToString());
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "pbv2EventData", value:  "");
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
        goto typeof(PiggyBankV2Handler).__il2cppRuntimeField_2B0;
    }
    public void HackReInit()
    {
        this.ResetSaveData();
        goto typeof(PiggyBankV2Handler).__il2cppRuntimeField_1F0;
    }
    public void HackResetProgress()
    {
        this.<BankFull>k__BackingField = false;
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.SaveData();
    }
    public void HackSetBankAlmostFull()
    {
        int val_1 = this.goldCurrencyTarget;
        this.<BankFull>k__BackingField = false;
        this.GoldCurrencyPending = 0;
        val_1 = val_1 - 1;
        this.<GoldCurrencyGained>k__BackingField = val_1;
        this.<GoldCurrencyGainedOld>k__BackingField = val_1;
    }
    public void HackSetBundleReady()
    {
        int val_1 = this.goldCurrencyTarget - (this.<GoldCurrencyGained>k__BackingField);
        this.AddGoldGained();
        this.<GoldCurrencyGainedOld>k__BackingField = this.<GoldCurrencyGained>k__BackingField;
    }
    public void HackResetPromptCooldown()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        this.promptCooldownTime = val_1;
    }
    public void HackSetExpire1Minute()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  1);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.bundleExpireTime = val_3;
        System.TimeSpan val_4 = System.TimeSpan.FromDays(value:  (double)this.featureCooldownDays);
        System.DateTime val_5 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_3.dateData}, t:  new System.TimeSpan() {_ticks = val_4._ticks});
        this.piggyBankNextReceiveTime = val_5;
    }
    public System.DateTime HackLongTimePurchaseDate()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = val_1.dateData.AddDays(value:  (double)-this.longTermNonPayer);
        return (System.DateTime)val_2.dateData;
    }
    public string HackLastPackageLogic()
    {
        return (string)this.lastPackageLogic;
    }
    public static void HackResetFeatureCooldown()
    {
        null = null;
        UnityEngine.PlayerPrefs.SetString(key:  "pbv2NextReceive", value:  System.DateTime.MinValue.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void HackIgnoreLastPurchaseDate()
    {
        bool val_1 = PiggyBankV2Handler.hackIgnoreLastPurchase;
        val_1 = val_1 ^ 1;
        PiggyBankV2Handler.hackIgnoreLastPurchase = val_1;
    }
    public static string HackNextAvailableDate()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbv2NextReceive", defaultValue:  "");
        return (string)((System.String.IsNullOrEmpty(value:  val_1)) != true) ? "null" : (val_1);
    }
    public PiggyBankV2Handler()
    {
        var val_2;
        this.eventDurationDays = 14;
        this.goldCurrencyTarget = 0;
        this.lapseDurationDays = ;
        this.longTermNonPayer = ;
        this.promptCooldownSeconds = 60129542264;
        this.featureCooldownDays = 14;
        val_2 = null;
        val_2 = null;
        this.bundleExpireTime = System.DateTime.MaxValue;
        this.econ = new PiggyBankV2Econ();
        this.lastPackageLogic = "undetermined";
    }
    private void <OnLevelComplete>b__86_0()
    {
        if(this.isTriggered == false)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        if(MainController.instance != 0)
        {
                bool val_4 = MainController.instance.IsChapterComplete;
        }
        
        if(this.GoldCurrencyPending >= 1)
        {
                if((this.<EventEnded>k__BackingField) == false)
        {
            goto label_12;
        }
        
        }
        
        if(this.CanShowReadyPopup() == false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowMainPopup(endOfChapter:  false, flyout:  false);
        return;
        label_12:
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  false, flyout:  false);
    }
    private void <OnDailyChallengeLevelComplete>b__87_0()
    {
        if(this.GoldCurrencyPending < 1)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  false, flyout:  false);
    }

}

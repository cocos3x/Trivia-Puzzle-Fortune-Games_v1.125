using UnityEngine;
public class PiggyBankHandler : WGEventHandler
{
    // Fields
    private static PiggyBankHandler _Instance;
    public const string PIGGY_BANK_EVENT_ID = "PiggyBank";
    private const string piggyBankDataKey = "pbEventData";
    private const string pbNextReceiveKey = "pbNextReceive";
    private const string pbLastCollectedKey = "pbLastRewardCollected";
    private const string pbCurrencyGainedKey = "pbCurrencyGained";
    private const string pbCurrencyPendingKey = "pbCurrencyPending";
    private const string pbCurrencyTargetKey = "pbCurrencyTarget";
    private const string pbExpireTimeKey = "pbExpireTime";
    private const string pbPackageIDKey = "pbPackageID";
    private const string pbPackageNameKey = "pbPackageName";
    private const string pbCoinRewardKey = "pbCoinReward";
    private const string pbGoldRewardKey = "pbGoldReward";
    private const string pbIsTriggeredKey = "pbIsTriggered";
    private const string pbLastProgressKey = "pbLastProgress";
    private const string eventEconomy = "economy";
    private const string eventSpend = "spend_cents";
    private const string eventLevels = "levels";
    private const string eventObjective = "objective_golden";
    private const string eventCriteria = "criteria";
    private const string eventCoinBalance = "coins_balance";
    private const string eventDailySpent = "coins_spent";
    private const string eventLapse = "lapse_purchase_days";
    private const string eventExpire = "bundle_expire_minutes";
    private const string eventpromptCooldown = "prompt_cool_seconds";
    private const string eventFeatureCooldown = "feature_cool_days";
    private const string eventLow = "low";
    private const string eventMid = "mid";
    private const string eventHigh = "high";
    private const string packageNonBuyer = "id_piggy_bank_nonbuyer";
    private const string packageLapse1 = "id_piggy_bank_lapse1";
    private const string packageLapse2 = "id_piggy_bank_lapse2";
    private const string packageLapse3 = "id_piggy_bank_lapse3";
    private const string iapKey = "pb_iap";
    private const string iapNonBuyer = "non";
    private const string iapLapse1 = "l1";
    private const string iapLapse2 = "l2";
    private const string iapLapse3 = "l3";
    private const string iapCoin = "c";
    private const string iapGold = "g";
    private const string iapUsualPrice = "u_p";
    private const string iapDiscount = "d_pc";
    private const string iapLow = "l";
    private const string iapMid = "m";
    private const string iapHigh = "h";
    private int playerSpendLow;
    private int playerSpendHigh;
    private int playerLevelLow;
    private int playerLevelHigh;
    private int goldCurrencyTargetLow;
    private int goldCurrencyTargetMid;
    private int goldCurrencyTargetHigh;
    private double lapseDurationDays;
    private decimal coinBalanceCriterion;
    private decimal dailyCoinSpentCriterion;
    private double bundleDurationMinutes;
    private double promptCooldownSeconds;
    private double featureCooldownDays;
    private int <GoldCurrencyGained>k__BackingField;
    private int goldCurrencyTarget;
    private int GoldCurrencyPending;
    private System.DateTime piggyBankNextReceiveTime;
    private System.DateTime bundleExpireTime;
    private bool isTriggered;
    private string <PackageName>k__BackingField;
    private string <PackageID>k__BackingField;
    private decimal <CoinReward>k__BackingField;
    private int <GoldReward>k__BackingField;
    private string PriceUsual;
    private int <Discount>k__BackingField;
    private PurchaseModel purchaseModel;
    private bool <BundleReady>k__BackingField;
    private int <GoldCurrencyGainedOld>k__BackingField;
    private bool <EventEnded>k__BackingField;
    private System.DateTime promptCooldownTime;
    private System.TimeSpan lastCoinSpentDuration;
    private TrackerPurchasePoints purchasePoint;
    private int priceUsualLocalized;
    public static bool hackIgnoreLastPurchase;
    private int unlockLevel;
    public System.Action<bool> OnPurchaseAttemptResult;
    private bool shownApplicationLoadedAdvert;
    
    // Properties
    public static PiggyBankHandler Instance { get; }
    public int GoldCurrencyGained { get; set; }
    public int GoldCurrencyTarget { get; }
    public System.DateTime BundleExpireTime { get; }
    public string PackageName { get; set; }
    public string PackageID { get; set; }
    public decimal CoinReward { get; set; }
    public int GoldReward { get; set; }
    public int Discount { get; set; }
    public bool BundleReady { get; set; }
    public int GoldCurrencyGainedOld { get; set; }
    public bool EventEnded { get; set; }
    public string PricePurchaseString { get; }
    public string PriceUsualString { get; }
    private static int LastProgressTimestampPref { get; set; }
    public override bool SupportsGoldenApples { get; }
    public override bool IsEventHidden { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static PiggyBankHandler get_Instance()
    {
        return (PiggyBankHandler)PiggyBankHandler.iapHigh;
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
    public System.DateTime get_BundleExpireTime()
    {
        return (System.DateTime)this.bundleExpireTime;
    }
    public string get_PackageName()
    {
        return (string)this.<PackageName>k__BackingField;
    }
    private void set_PackageName(string value)
    {
        this.<PackageName>k__BackingField = value;
    }
    public string get_PackageID()
    {
        return (string)this.<PackageID>k__BackingField;
    }
    private void set_PackageID(string value)
    {
        this.<PackageID>k__BackingField = value;
    }
    public decimal get_CoinReward()
    {
        return new System.Decimal() {flags = this.<CoinReward>k__BackingField, hi = this.<CoinReward>k__BackingField};
    }
    private void set_CoinReward(decimal value)
    {
        this.<CoinReward>k__BackingField = value;
        mem[1152921516554687488] = value.lo;
        mem[1152921516554687492] = value.mid;
    }
    public int get_GoldReward()
    {
        return (int)this.<GoldReward>k__BackingField;
    }
    private void set_GoldReward(int value)
    {
        this.<GoldReward>k__BackingField = value;
    }
    public int get_Discount()
    {
        return (int)this.<Discount>k__BackingField;
    }
    private void set_Discount(int value)
    {
        this.<Discount>k__BackingField = value;
    }
    public bool get_BundleReady()
    {
        return (bool)this.<BundleReady>k__BackingField;
    }
    private void set_BundleReady(bool value)
    {
        this.<BundleReady>k__BackingField = value;
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
    public string get_PriceUsualString()
    {
        return (string)this.PriceUsual;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "pbLastProgress", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "pbLastProgress", value:  value);
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override bool get_IsEventHidden()
    {
        return (bool)(this.isTriggered == false) ? 1 : 0;
    }
    public override bool get_IsEventValid()
    {
        return (bool)(App.Player >= this.unlockLevel) ? 1 : 0;
    }
    public override void Init(GameEventV2 eventV2)
    {
        ulong val_8;
        var val_10;
        mem[1152921516556748464] = eventV2;
        PiggyBankHandler.iapHigh = this;
        this.ParseEventData(eventData:  PiggyBankHandler.iapHigh.__il2cppRuntimeField_68);
        if(this.IsEventAvailable() == false)
        {
            goto label_2;
        }
        
        this.LoadData();
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        this.promptCooldownTime = val_2;
        this.<GoldCurrencyGainedOld>k__BackingField = this.<GoldCurrencyGained>k__BackingField;
        if((val_2.dateData.HasExistingData() == false) || ((this.HasExpired() == true) || (this.isTriggered == false)))
        {
            goto label_7;
        }
        
        GameBehavior val_5 = App.getBehavior;
        if((val_5.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        goto typeof(PiggyBankHandler).__il2cppRuntimeField_220;
        label_7:
        this.ResetSaveData();
        val_8 = mem[this.<GoldCurrencyGained>k__BackingField + 40];
        val_8 = this.<GoldCurrencyGained>k__BackingField + 40;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = this.<GoldCurrencyGained>k__BackingField + 24}, t2:  new System.DateTime() {dateData = val_8})) == false)
        {
            goto label_17;
        }
        
        label_2:
        this.<EventEnded>k__BackingField = true;
        return;
        label_17:
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.<BundleReady>k__BackingField = false;
        val_10 = null;
        val_10 = null;
        this.isTriggered = false;
        this.bundleExpireTime = System.DateTime.MaxValue;
        this.SaveData();
        GameBehavior val_7 = App.getBehavior;
        if((val_7.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        goto typeof(PiggyBankHandler).__il2cppRuntimeField_220;
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
    public override void OnProcessPurchase(ref PurchaseModel purchased)
    {
        var val_9;
        var val_10;
        var val_14;
        val_10 = 1152921516557186160;
        if(purchased == null)
        {
                throw new NullReferenceException();
        }
        
        if(purchased.id == null)
        {
                throw new NullReferenceException();
        }
        
        if((purchased.id.Contains(value:  "piggy_bank")) == false)
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
        
        if(purchased == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  (PurchaseModel)[1152921516557202496].id, b:  purchased.id)) != false)
        {
                if(purchased == null)
        {
                throw new NullReferenceException();
        }
        
            sale_price = (PurchaseModel)[1152921516557202496].sale_price;
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
        if((this.<BundleReady>k__BackingField) != false)
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
        
        if(this.HasPassedCoinCriteria() == false)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        this.DetermineBundle(eventData:  typeof(PiggyBankHandler).__il2cppRuntimeField_198);
        this.ShowPreviewPopup();
        this.isTriggered = true;
        this.SaveData();
    }
    public override void OnMenuLoaded()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(App.game != 17)
        {
                val_3 = null;
            val_3 = null;
            if(App.game != 19)
        {
                return;
        }
        
        }
        
        if((this.<BundleReady>k__BackingField) == false)
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
        
        if((this & 1) == 0)
        {
                return;
        }
        
        if(this.shownApplicationLoadedAdvert == true)
        {
                return;
        }
        
        this.purchasePoint = 51;
        this.ShowReadyPopup(endOfChapter:  false, flyout:  false);
        this.shownApplicationLoadedAdvert = true;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        null = null;
        if(App.game == 17)
        {
                return;
        }
        
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  1.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void PiggyBankHandler::<OnLevelComplete>b__135_0()), ignoreTimeScale:  true);
    }
    public override void OnLevelCompleteRewardAnimFinished()
    {
        if(this.isTriggered == false)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) == true)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        if(((this & 1) != 0) && (this.GoldCurrencyPending >= 1))
        {
                if((this.<EventEnded>k__BackingField) == false)
        {
            goto label_5;
        }
        
        }
        
        if(this.CanShowReadyPopup() == false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowReadyPopup(endOfChapter:  false, flyout:  true);
        return;
        label_5:
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  false, flyout:  true);
    }
    public override void OnDailyChallengeRewardGranted()
    {
        if((this & 1) == 0)
        {
                return;
        }
        
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
        if((this & 1) == 0)
        {
                return;
        }
        
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
        
        if((this.<BundleReady>k__BackingField) != false)
        {
                this.purchasePoint = 51;
            this.ShowReadyPopup(endOfChapter:  false, flyout:  false);
            return;
        }
        
        this.ShowNotReadyPopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this.<EventEnded>k__BackingField) != false)
        {
                return;
        }
        
        if((this.<BundleReady>k__BackingField) != false)
        {
                this.purchasePoint = 53;
            this.ShowReadyPopup(endOfChapter:  false, flyout:  false);
            return;
        }
        
        this.ShowNotReadyPopup();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        string val_1 = System.String.Format(format:  "{0}/{1}", arg0:  this.<GoldCurrencyGained>k__BackingField, arg1:  this.goldCurrencyTarget);
        EventListItemContentPiggyBank val_2 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentPiggyBank>(allowMultiple:  false);
        float val_3 = (float)this.<GoldCurrencyGained>k__BackingField;
        val_3 = val_3 / (float)this.goldCurrencyTarget;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "PiggyBank", value:  this.<PackageName>k__BackingField);
        currentData.Add(key:  "PiggyBank Full", value:  this.<BundleReady>k__BackingField);
    }
    public override void OnEventEnded()
    {
        this.ResetSaveData();
    }
    public override void UpdateProgress()
    {
        PiggyBankHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override int LastProgressTimestamp()
    {
        return PiggyBankHandler.LastProgressTimestampPref;
    }
    public override bool EventCompleted()
    {
        if((this.<EventEnded>k__BackingField) != false)
        {
                return true;
        }
        
        if((this.<BundleReady>k__BackingField) == false)
        {
                return false;
        }
        
        return this.HasExpired();
    }
    public override bool IsRewardReadyToCollect()
    {
        return (bool)this.<BundleReady>k__BackingField;
    }
    public override System.DateTime GetTimeEnd()
    {
        var val_1;
        System.DateTime val_2;
        var val_3;
        val_1 = this;
        if((this.<BundleReady>k__BackingField) != false)
        {
                val_2 = this.bundleExpireTime;
            return (System.DateTime)val_2;
        }
        
        val_1 = 1152921504616751104;
        val_3 = null;
        val_3 = null;
        val_2 = 1152921504616755224;
        return (System.DateTime)val_2;
    }
    public override string GetMainMenuButtonText()
    {
        object val_4;
        var val_5;
        var val_6;
        var val_7;
        object val_8;
        string val_10;
        val_5 = null;
        val_5 = null;
        if(App.game == 17)
        {
            goto label_6;
        }
        
        val_6 = null;
        val_6 = null;
        if(App.game != 19)
        {
            goto label_12;
        }
        
        label_6:
        if((this.<BundleReady>k__BackingField) != false)
        {
                val_7 = "PIGGY BANK\nREADY!";
            return (string)System.String.Format(format:  val_10 = "{0} {1}/{2}", arg0:  val_8 = Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false), arg1:  this.<GoldCurrencyGained>k__BackingField, arg2:  this.goldCurrencyTarget);
        }
        
        val_8 = Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false);
        val_4 = this.<GoldCurrencyGained>k__BackingField;
        val_10 = "{0}\n{1}/{2}";
        return (string)System.String.Format(format:  val_10, arg0:  val_8, arg1:  this.<GoldCurrencyGained>k__BackingField, arg2:  this.goldCurrencyTarget);
        label_12:
        if((this.<BundleReady>k__BackingField) != false)
        {
                return Localization.Localize(key:  "piggy_bank_ready_upper", defaultValue:  "PIGGY BANK READY!", useSingularKey:  false);
        }
        
        val_4 = this.<GoldCurrencyGained>k__BackingField;
        return (string)System.String.Format(format:  val_10, arg0:  val_8, arg1:  this.<GoldCurrencyGained>k__BackingField, arg2:  this.goldCurrencyTarget);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "piggy_bank_upper", defaultValue:  "PIGGY BANK", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.<GoldCurrencyGained>k__BackingField, arg1:  this.goldCurrencyTarget);
    }
    public bool IsEventAvailable()
    {
        var val_3;
        if((this & 1) != 0)
        {
                if(this.HasExistingData() != false)
        {
                val_3 = 1;
            return (bool)val_3;
        }
        
            if(this.HasPassedFeatureCooldown() != false)
        {
                return this.HasLapsedPurchase();
        }
        
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public void TryPurchase()
    {
        var val_6;
        string val_7;
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = this.purchasePoint;
        PurchaseModel val_2 = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  this.<PackageID>k__BackingField));
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_7 = "gems";
        }
        else
        {
                val_7 = "credits";
        }
        
        val_2.AddReward(rewardType:  val_7, amount:  new System.Decimal() {flags = this.<CoinReward>k__BackingField, hi = this.<CoinReward>k__BackingField});
        decimal val_4 = System.Decimal.op_Implicit(value:  this.<GoldReward>k__BackingField);
        val_2.AddReward(rewardType:  "golden_currency", amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        bool val_5 = PurchaseProxy.Purchase(purchase:  val_2);
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
            this.<BundleReady>k__BackingField = true;
            this.SetBundleExpirationTime();
        }
        
        this.SaveData();
    }
    public void OnPurchaseSuccess()
    {
        SLC.Social.Leagues.LeaguesManager.OnAppleAwarded(appleAwarded:  this.<GoldReward>k__BackingField);
        this.TrackPurchaseMade();
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromDays(value:  this.featureCooldownDays);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.piggyBankNextReceiveTime = val_3;
        val_3.dateData.CancelNotification();
        this.<EventEnded>k__BackingField = true;
        this.ResetSaveData();
        this.OnPurchaseAttemptResult.Invoke(obj:  true);
        goto typeof(PiggyBankHandler).__il2cppRuntimeField_2B0;
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
        bool val_2 = System.String.IsNullOrEmpty(value:  UnityEngine.PlayerPrefs.GetString(key:  "pbEventData", defaultValue:  ""));
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    private bool HasPassedFeatureCooldown()
    {
        var val_5;
        System.DateTime val_6;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbNextReceive", defaultValue:  "");
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
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = this.bundleExpireTime}, t2:  new System.DateTime() {dateData = val_1.dateData})) != false)
        {
                this.ResetSaveData();
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = this.bundleExpireTime}, t2:  new System.DateTime() {dateData = val_3.dateData});
    }
    private bool CanShowInterstitialPopup()
    {
        var val_2;
        if(((this & 1) != 0) && (this.GoldCurrencyPending >= 1))
        {
                var val_1 = ((this.<EventEnded>k__BackingField) == false) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    private bool CanShowReadyPopup()
    {
        var val_5;
        if((((this & 1) != 0) && ((this.<BundleReady>k__BackingField) != false)) && (this.HasExpired() != true))
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
        
        if(PiggyBankHandler.hackIgnoreLastPurchase != false)
        {
                return true;
        }
        
        Player val_2 = App.Player;
        System.TimeSpan val_3 = System.TimeSpan.FromDays(value:  this.lapseDurationDays);
        System.DateTime val_4 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_2.last_purchase}, t:  new System.TimeSpan() {_ticks = val_3._ticks});
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = val_5.dateData});
    }
    private bool HasPassedCoinCriteria()
    {
        ulong val_16;
        var val_17;
        val_16 = this;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        Player val_2 = App.Player;
        if(val_2.num_purchase < 1)
        {
            goto label_28;
        }
        
        Player val_3 = App.Player;
        decimal val_4 = System.Decimal.op_Implicit(value:  val_3._gems);
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, d2:  new System.Decimal() {flags = this.coinBalanceCriterion, hi = this.coinBalanceCriterion})) == true)
        {
            goto label_34;
        }
        
        Player val_6 = App.Player;
        System.DateTime val_7 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_6.properties.LastGemSpent}, t:  new System.TimeSpan() {_ticks = this.lastCoinSpentDuration});
        val_16 = val_7.dateData;
        System.DateTime val_8 = DateTimeCheat.UtcNow;
        val_17 = (~(System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_16}, t2:  new System.DateTime() {dateData = val_8.dateData}))) & 1;
        return (bool)val_17;
        label_5:
        Player val_10 = App.Player;
        if(val_10.num_purchase < 1)
        {
            goto label_28;
        }
        
        Player val_11 = App.Player;
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits, lo = X22, mid = X22}, d2:  new System.Decimal() {flags = this.coinBalanceCriterion, hi = this.coinBalanceCriterion, lo = 41971712})) == false)
        {
            goto label_34;
        }
        
        Player val_13 = App.Player;
        System.DateTime val_14 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_13.properties.LastCoinSpent}, t:  new System.TimeSpan() {_ticks = this.lastCoinSpentDuration});
        System.DateTime val_15 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_14.dateData}, t2:  new System.DateTime() {dateData = val_15.dateData});
        label_28:
        val_17 = 1;
        return (bool)val_17;
        label_34:
        val_17 = 0;
        return (bool)val_17;
    }
    private void SetPurchaseModel()
    {
        if((System.String.IsNullOrEmpty(value:  this.<PackageID>k__BackingField)) == true)
        {
                return;
        }
        
        twelvegigs.storage.JsonDictionary val_2 = PackagesManager.GetPackageById(packageId:  this.<PackageID>k__BackingField);
        if(val_2 != null)
        {
                this.purchaseModel = new PurchaseModel(json:  val_2);
            this.PriceUsual = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_2.getString(key:  "credit_package", defaultValue:  ""))).LocalPrice;
            if((this.<Discount>k__BackingField) > 0)
        {
                return;
        }
        
            float val_11 = 100f;
            float val_8 = (PurchaseModel)[1152921516561564048].sale_price - this.purchaseModel.sale_price;
            val_8 = val_8 / (PurchaseModel)[1152921516561564048].sale_price;
            val_11 = val_8 * val_11;
            this.<Discount>k__BackingField = UnityEngine.Mathf.RoundToInt(f:  val_11);
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "PiggyBankHandler.SetPurchaseModel(). PiggyPackage is null for PackageId " + this.<PackageID>k__BackingField(this.<PackageID>k__BackingField));
    }
    private void OnGoldCurrencyTargetMet()
    {
        this.<BundleReady>k__BackingField = true;
        this.SetBundleExpirationTime();
    }
    private void SetBundleExpirationTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  this.bundleDurationMinutes);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.bundleExpireTime = val_3;
        System.TimeSpan val_4 = System.TimeSpan.FromDays(value:  this.featureCooldownDays);
        System.DateTime val_5 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_3.dateData}, t:  new System.TimeSpan() {_ticks = val_4._ticks});
        this.piggyBankNextReceiveTime = val_5;
        val_5.dateData.CancelNotification();
        this.SetNotification();
    }
    private void SetPromptCooldownTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromSeconds(value:  this.promptCooldownSeconds);
        System.DateTime val_3 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        this.promptCooldownTime = val_3;
    }
    private void ShowPreviewPopup()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankPopup>(showNext:  false);
        goto typeof(WGWindowManager).__il2cppRuntimeField_170;
    }
    private void ShowNotReadyPopup()
    {
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankPopup>(showNext:  false).SetupNotReady();
    }
    private void ShowReadyPopup(bool endOfChapter = False, bool flyout = False)
    {
        MetaGameBehavior val_7;
        var val_8;
        bool val_9;
        val_7 = flyout;
        if(val_7 != false)
        {
                GameBehavior val_1 = App.getBehavior;
            val_7 = val_1.<metaGameBehavior>k__BackingField;
            val_8 = endOfChapter;
            val_9 = 0;
        }
        else
        {
                val_9 = endOfChapter;
            val_8 = 0;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankPopup>(showNext:  false).SetupReady(fromInterstitial:  false, endOfChapter:  val_9);
        this.SetPromptCooldownTime();
    }
    private void ShowInterstitialPopup(bool endOfChapter = False, bool flyout = False)
    {
        bool val_6 = flyout;
        this.AddGoldGained();
        if(val_6 == false)
        {
            goto label_1;
        }
        
        GameBehavior val_1 = App.getBehavior;
        val_6 = val_1.<metaGameBehavior>k__BackingField;
        if(val_6 != null)
        {
            goto label_6;
        }
        
        label_1:
        label_6:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<PiggyBankPopup>(showNext:  true).SetupInterstitial(endOfChapter:  endOfChapter);
        this.SetPromptCooldownTime();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_33;
        UnityEngine.Debug.LogError(message:  PrettyPrint.printJSON(obj:  eventData, types:  false, singleLineOutput:  false));
        if((eventData.ContainsKey(key:  "econ")) != false)
        {
                this.ParseV1SplitEcon(eventData:  eventData);
            return;
        }
        
        if((eventData.ContainsKey(key:  "econ")) != false)
        {
                this.ParseAlternateEcon(eventData:  eventData);
            return;
        }
        
        val_33 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_5 = eventData.Item["economy"];
        if((val_5.ContainsKey(key:  "spend_cents")) != false)
        {
                object val_7 = val_5.Item["spend_cents"];
            object val_8 = val_7.Item["low"];
            this.playerSpendLow = null;
            object val_9 = val_7.Item["high"];
            this.playerSpendHigh = null;
        }
        
        if((val_5.ContainsKey(key:  "levels")) != false)
        {
                object val_11 = val_5.Item["levels"];
            object val_12 = val_11.Item["low"];
            this.playerLevelLow = null;
            object val_13 = val_11.Item["high"];
            this.playerLevelHigh = null;
        }
        
        if((val_5.ContainsKey(key:  "objective_golden")) != false)
        {
                object val_15 = val_5.Item["objective_golden"];
            object val_16 = val_15.Item["low"];
            this.goldCurrencyTargetLow = null;
            object val_17 = val_15.Item["mid"];
            this.goldCurrencyTargetMid = null;
            object val_18 = val_15.Item["high"];
            this.goldCurrencyTargetHigh = null;
        }
        
        if((val_5.ContainsKey(key:  "criteria")) != false)
        {
                object val_20 = val_5.Item["criteria"];
            object val_21 = val_20.Item["coins_balance"];
            decimal val_22 = System.Decimal.op_Implicit(value:  19914752);
            this.coinBalanceCriterion = val_22;
            mem[1152921516562632144] = val_22.lo;
            mem[1152921516562632148] = val_22.mid;
            object val_23 = val_20.Item["coins_spent"];
            decimal val_24 = System.Decimal.op_Implicit(value:  19914752);
            this.dailyCoinSpentCriterion = val_24;
            mem[1152921516562632160] = val_24.lo;
            mem[1152921516562632164] = val_24.mid;
        }
        
        if((val_5.ContainsKey(key:  "lapse_purchase_days")) != false)
        {
                object val_26 = val_5.Item["lapse_purchase_days"];
            this.lapseDurationDays = 1.15292150460685E+18;
        }
        
        if((val_5.ContainsKey(key:  "bundle_expire_minutes")) != false)
        {
                object val_28 = val_5.Item["bundle_expire_minutes"];
            this.bundleDurationMinutes = 1.15292150460685E+18;
        }
        
        if((val_5.ContainsKey(key:  "prompt_cool_seconds")) != false)
        {
                object val_30 = val_5.Item["prompt_cool_seconds"];
            this.promptCooldownSeconds = 1.15292150460685E+18;
        }
        
        val_33 = "feature_cool_days";
        if((val_5.ContainsKey(key:  "feature_cool_days")) == false)
        {
                return;
        }
        
        object val_32 = val_5.Item["feature_cool_days"];
        this.featureCooldownDays = 1.15292150460685E+18;
    }
    private void ParseAlternateEcon(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        object val_1 = eventData.Item["econ"];
        if((val_1.ContainsKey(key:  "s_c")) != false)
        {
                object val_3 = val_1.Item["s_c"];
            if(null >= 2)
        {
                bool val_5 = System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, result: out  this.playerSpendLow);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            bool val_7 = System.Int32.TryParse(s:  41868256, result: out  this.playerSpendHigh);
        }
        
        }
        
        if((val_1.ContainsKey(key:  "lvls")) != false)
        {
                object val_9 = val_1.Item["lvls"];
            if(null >= 2)
        {
                bool val_11 = System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, result: out  this.playerLevelLow);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            bool val_13 = System.Int32.TryParse(s:  41868256, result: out  this.playerLevelHigh);
        }
        
        }
        
        if((val_1.ContainsKey(key:  "obj_g")) != false)
        {
                object val_15 = val_1.Item["obj_g"];
            if(null >= 3)
        {
                bool val_17 = System.Int32.TryParse(s:  System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg, result: out  this.goldCurrencyTargetLow);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            bool val_19 = System.Int32.TryParse(s:  41868256, result: out  this.goldCurrencyTargetMid);
            if((System.Single DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(float perc)) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            bool val_21 = System.Int32.TryParse(s:  System.Single DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(float perc).__il2cppRuntimeField_30, result: out  this.goldCurrencyTargetHigh);
        }
        
        }
        
        if((val_1.ContainsKey(key:  "cta")) != false)
        {
                object val_23 = val_1.Item["cta"];
            bool val_25 = System.Decimal.TryParse(s:  val_23.Item["c_bal"], result: out  new System.Decimal() {flags = this.coinBalanceCriterion, hi = this.coinBalanceCriterion, lo = this.coinBalanceCriterion, mid = this.coinBalanceCriterion});
            bool val_27 = System.Decimal.TryParse(s:  val_23.Item["c_spt"], result: out  new System.Decimal() {flags = this.dailyCoinSpentCriterion, hi = this.dailyCoinSpentCriterion, lo = this.dailyCoinSpentCriterion, mid = this.dailyCoinSpentCriterion});
        }
        
        if((val_1.ContainsKey(key:  "lp_d")) != false)
        {
                bool val_31 = System.Double.TryParse(s:  val_1.Item["lp_d"], result: out  this.lapseDurationDays);
        }
        
        if((val_1.ContainsKey(key:  "b_e_m")) != false)
        {
                bool val_35 = System.Double.TryParse(s:  val_1.Item["b_e_m"], result: out  this.bundleDurationMinutes);
        }
        
        if((val_1.ContainsKey(key:  "p_c_s")) != false)
        {
                bool val_39 = System.Double.TryParse(s:  val_1.Item["p_c_s"], result: out  this.promptCooldownSeconds);
        }
        
        if((val_1.ContainsKey(key:  "f_c_d")) == false)
        {
                return;
        }
        
        bool val_43 = System.Double.TryParse(s:  val_1.Item["f_c_d"], result: out  this.featureCooldownDays);
    }
    private void DetermineBundle(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_28;
        var val_29;
        string val_30;
        string val_31;
        string val_32;
        var val_33;
        string val_34;
        string val_35;
        string val_36;
        int val_37;
        var val_38;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_28 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((App.getGameEcon.GetGameplayKnobs().ContainsKey(key:  "pb_iap")) != false)
        {
                object val_7 = App.getGameEcon.GetGameplayKnobs().Item["pb_iap"];
            val_28 = 0;
        }
        
        val_29 = "non";
        this.<PackageID>k__BackingField = "id_piggy_bank_nonbuyer";
        this.<PackageName>k__BackingField = "Non-Buyer ";
        Player val_9 = App.Player;
        float val_28 = val_9.lastItemPrice;
        val_28 = val_28 * 100f;
        if(val_28 <= (float)this.playerSpendHigh)
        {
            goto label_16;
        }
        
        val_30 = "Lapsed3 ";
        val_31 = "id_piggy_bank_lapse3";
        val_32 = "l3";
        goto label_20;
        label_16:
        if(val_28 >= (float)this.playerSpendLow)
        {
            goto label_18;
        }
        
        if(val_28 <= 0f)
        {
            goto label_19;
        }
        
        val_30 = "Lapsed1 ";
        val_31 = "id_piggy_bank_lapse1";
        val_32 = "l1";
        goto label_20;
        label_18:
        val_30 = "Lapsed2 ";
        val_31 = "id_piggy_bank_lapse2";
        val_32 = "l2";
        label_20:
        this.<PackageID>k__BackingField = val_31;
        this.<PackageName>k__BackingField = val_30;
        label_19:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_10 = null;
        val_33 = val_10;
        val_10 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((ContainsKey(key:  val_32)) != false)
        {
                val_33 = Item[val_32];
        }
        
        if((val_10.ContainsKey(key:  "c")) != false)
        {
                object val_14 = val_10.Item["c"];
            decimal val_15 = System.Decimal.op_Implicit(value:  19914752);
            this.<CoinReward>k__BackingField = val_15;
            mem[1152921516563112272] = val_15.lo;
            mem[1152921516563112276] = val_15.mid;
        }
        
        val_34 = "d_pc";
        if((val_10.ContainsKey(key:  val_34)) != false)
        {
                if((System.Int32.TryParse(s:  val_10.Item["d_pc"], result: out  0)) != false)
        {
                this.<Discount>k__BackingField = 0;
        }
        
        }
        
        Player val_20 = App.Player;
        if(val_20 >= this.playerLevelHigh)
        {
            goto label_39;
        }
        
        if(val_20 >= this.playerLevelLow)
        {
            goto label_40;
        }
        
        val_35 = "l";
        val_36 = "Low";
        val_37 = this.goldCurrencyTargetLow;
        goto label_42;
        label_39:
        val_35 = "h";
        val_36 = "High";
        val_37 = this.goldCurrencyTargetHigh;
        goto label_42;
        label_40:
        val_35 = "m";
        val_36 = "Mid";
        val_37 = this.goldCurrencyTargetMid;
        label_42:
        this.goldCurrencyTarget = val_37;
        this.<PackageName>k__BackingField = this.<PackageName>k__BackingField(this.<PackageName>k__BackingField) + val_36;
        if((val_10.ContainsKey(key:  "g")) != false)
        {
                object val_23 = val_10.Item["g"];
            if((val_23.ContainsKey(key:  val_35)) != false)
        {
                object val_25 = val_23.Item[val_35];
            this.<GoldReward>k__BackingField = null;
        }
        
        }
        
        if((val_10.ContainsKey(key:  "s")) != false)
        {
                object val_27 = val_10.Item["s"];
            this.<GoldReward>k__BackingField = null;
        }
        
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.<BundleReady>k__BackingField = false;
        val_38 = null;
        val_38 = null;
        this.isTriggered = false;
        this.bundleExpireTime = System.DateTime.MaxValue;
        this.SetPurchaseModel();
        this.SaveData();
    }
    private void ParseV1SplitEcon(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        object val_1 = eventData.Item["econ"];
        int val_4 = 0;
        if((val_1.ContainsKey(key:  "ul")) != false)
        {
                if((System.Int32.TryParse(s:  val_1.Item["ul"], result: out  val_4)) != false)
        {
                this.unlockLevel = 0;
        }
        
        }
        
        if((val_1.ContainsKey(key:  "s_c")) != false)
        {
                object val_7 = val_1.Item["s_c"];
            if(null >= 2)
        {
                this.playerSpendLow = 1179403647;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.playerSpendHigh = System.Single DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(float perc);
        }
        
        }
        
        if((val_1.ContainsKey(key:  "st_ob")) != false)
        {
                if((System.Int32.TryParse(s:  val_1.Item["st_ob"], result: out  val_4)) != false)
        {
                this.goldCurrencyTarget = 0;
            this.goldCurrencyTargetLow = 0;
            this.goldCurrencyTargetMid = 0;
            this.goldCurrencyTargetHigh = 0;
        }
        
        }
        
        if((val_1.ContainsKey(key:  "cta")) != false)
        {
                object val_12 = val_1.Item["cta"];
            if(val_12 != null)
        {
                if((val_12.ContainsKey(key:  "g_bal")) != false)
        {
                bool val_15 = System.Decimal.TryParse(s:  val_12.Item["g_bal"], result: out  new System.Decimal() {flags = this.coinBalanceCriterion, hi = this.coinBalanceCriterion, lo = this.coinBalanceCriterion, mid = this.coinBalanceCriterion});
        }
        
        }
        
        }
        
        if((val_1.ContainsKey(key:  "lp_d")) != false)
        {
                if((System.Int32.TryParse(s:  val_1.Item["lp_d"], result: out  val_4)) != false)
        {
                this.lapseDurationDays = 0;
        }
        
        }
        
        if((val_1.ContainsKey(key:  "b_e_m")) != false)
        {
                if((System.Int32.TryParse(s:  val_1.Item["b_e_m"], result: out  val_4)) != false)
        {
                this.bundleDurationMinutes = 0;
        }
        
        }
        
        if((val_1.ContainsKey(key:  "p_c_s")) == false)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  val_1.Item["p_c_s"], result: out  val_4)) == false)
        {
                return;
        }
        
        this.promptCooldownSeconds = 0;
    }
    private void SetNotification()
    {
        System.TimeSpan val_1 = System.TimeSpan.FromHours(value:  1);
        System.DateTime val_2 = System.DateTime.op_Subtraction(d:  new System.DateTime() {dateData = this.bundleExpireTime}, t:  new System.TimeSpan() {_ticks = val_1._ticks});
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  18, when:  new System.DateTime() {dateData = val_2.dateData}, optMessage:  "Your Piggy Bank is bursting with Coins! Collect Now!", extraData:  0);
    }
    private void CancelNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  18);
    }
    private void SaveData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "pbCurrencyGained", value:  this.<GoldCurrencyGained>k__BackingField);
        val_1.Add(key:  "pbCurrencyPending", value:  this.GoldCurrencyPending);
        val_1.Add(key:  "pbCurrencyTarget", value:  this.goldCurrencyTarget);
        val_1.Add(key:  "pbExpireTime", value:  this.bundleExpireTime);
        val_1.Add(key:  "pbPackageID", value:  this.<PackageID>k__BackingField);
        val_1.Add(key:  "pbCoinReward", value:  this.<CoinReward>k__BackingField);
        val_1.Add(key:  "pbGoldReward", value:  this.<GoldReward>k__BackingField);
        val_1.Add(key:  "pbPackageName", value:  this.<PackageName>k__BackingField);
        val_1.Add(key:  "pbIsTriggered", value:  this.isTriggered);
        UnityEngine.PlayerPrefs.SetString(key:  "pbNextReceive", value:  this.piggyBankNextReceiveTime.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "pbEventData", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private void LoadData()
    {
        var val_27;
        string val_28;
        if((System.String.IsNullOrEmpty(value:  UnityEngine.PlayerPrefs.GetString(key:  "pbEventData", defaultValue:  ""))) != false)
        {
                return;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "pbEventData", defaultValue:  ""));
        val_27 = (System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
        val_28 = "pbCurrencyGained";
        if((val_4.ContainsKey(key:  "pbCurrencyGained")) != false)
        {
                object val_6 = val_4.Item["pbCurrencyGained"];
            this.<GoldCurrencyGained>k__BackingField = null;
        }
        
        val_28 = "pbCurrencyPending";
        if((val_4.ContainsKey(key:  "pbCurrencyPending")) != false)
        {
                object val_8 = val_4.Item["pbCurrencyPending"];
            this.GoldCurrencyPending = null;
        }
        
        val_28 = "pbCurrencyTarget";
        if((val_4.ContainsKey(key:  "pbCurrencyTarget")) != false)
        {
                object val_10 = val_4.Item["pbCurrencyTarget"];
            this.goldCurrencyTarget = null;
        }
        
        if((val_4.ContainsKey(key:  "pbExpireTime")) != false)
        {
                val_28 = val_4.Item["pbExpireTime"];
            System.DateTime val_13 = System.DateTime.UtcNow;
            if(val_28 != null)
        {
                if(null != null)
        {
            goto label_26;
        }
        
        }
        
            System.DateTime val_14 = SLCDateTime.Parse(dateTime:  val_28, defaultValue:  new System.DateTime() {dateData = val_13.dateData});
            this.bundleExpireTime = val_14;
        }
        
        val_28 = "pbPackageID";
        if((val_4.ContainsKey(key:  "pbPackageID")) != false)
        {
                object val_16 = val_4.Item["pbPackageID"];
            if(val_16 != null)
        {
                if(null != null)
        {
            goto label_35;
        }
        
        }
        
            this.<PackageID>k__BackingField = val_16;
        }
        
        if((val_4.ContainsKey(key:  "pbCoinReward")) != false)
        {
                val_28 = val_4.Item["pbCoinReward"];
            decimal val_19 = System.Decimal.op_Implicit(value:  19914752);
            this.<CoinReward>k__BackingField = val_19;
            mem[1152921516563976624] = val_19.lo;
            mem[1152921516563976628] = val_19.mid;
        }
        
        val_28 = "pbGoldReward";
        if((val_4.ContainsKey(key:  "pbGoldReward")) != false)
        {
                object val_21 = val_4.Item["pbGoldReward"];
            this.<GoldReward>k__BackingField = null;
        }
        
        val_28 = "pbPackageName";
        if((val_4.ContainsKey(key:  "pbPackageName")) != false)
        {
                object val_23 = val_4.Item["pbPackageName"];
            if(val_23 != null)
        {
                if(null != null)
        {
            goto label_35;
        }
        
        }
        
            this.<PackageName>k__BackingField = val_23;
        }
        
        val_28 = "pbIsTriggered";
        if((val_4.ContainsKey(key:  "pbIsTriggered")) != false)
        {
                object val_25 = val_4.Item["pbIsTriggered"];
            this.isTriggered = null;
        }
        
        this.<BundleReady>k__BackingField = ((this.<GoldCurrencyGained>k__BackingField) >= this.goldCurrencyTarget) ? 1 : 0;
        this.SetPurchaseModel();
        return;
        label_35:
        label_26:
    }
    private void ResetSaveData()
    {
        UnityEngine.PlayerPrefs.SetString(key:  "pbNextReceive", value:  this.piggyBankNextReceiveTime.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "pbEventData", value:  "");
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void HackReInit()
    {
        this.ResetSaveData();
        goto typeof(PiggyBankHandler).__il2cppRuntimeField_1F0;
    }
    public void HackResetProgress()
    {
        this.<BundleReady>k__BackingField = false;
        this.<GoldCurrencyGained>k__BackingField = 0;
        this.GoldCurrencyPending = 0;
        this.<GoldCurrencyGainedOld>k__BackingField = 0;
        this.SaveData();
    }
    public void HackSetBundleAlmostReady()
    {
        int val_1 = this.goldCurrencyTarget;
        this.<BundleReady>k__BackingField = false;
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
        System.TimeSpan val_4 = System.TimeSpan.FromDays(value:  this.featureCooldownDays);
        System.DateTime val_5 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_3.dateData}, t:  new System.TimeSpan() {_ticks = val_4._ticks});
        this.piggyBankNextReceiveTime = val_5;
    }
    public static void HackResetFeatureCooldown()
    {
        null = null;
        UnityEngine.PlayerPrefs.SetString(key:  "pbNextReceive", value:  System.DateTime.MinValue.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static void HackIgnoreLastPurchaseDate()
    {
        bool val_1 = PiggyBankHandler.hackIgnoreLastPurchase;
        val_1 = val_1 ^ 1;
        PiggyBankHandler.hackIgnoreLastPurchase = val_1;
    }
    public static string HackNextAvailableDate()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "pbNextReceive", defaultValue:  "");
        return (string)((System.String.IsNullOrEmpty(value:  val_1)) != true) ? "null" : (val_1);
    }
    public PiggyBankHandler()
    {
        var val_4;
        this.goldCurrencyTargetLow = 100;
        this.goldCurrencyTargetMid = 230;
        this.goldCurrencyTargetHigh = 450;
        this.lapseDurationDays = 14;
        this.playerSpendLow = ;
        this.playerSpendHigh = ;
        this.playerLevelLow = 8589934593125;
        this.playerLevelHigh = 2000;
        decimal val_1 = new System.Decimal(value:  172);
        decimal val_2;
        this.coinBalanceCriterion = val_1.flags;
        val_2 = new System.Decimal(value:  120);
        this.featureCooldownDays = 7;
        this.goldCurrencyTarget = 0;
        this.dailyCoinSpentCriterion = val_2.flags;
        this.bundleDurationMinutes = ;
        this.promptCooldownSeconds = 120;
        val_4 = null;
        val_4 = null;
        this.bundleExpireTime = System.DateTime.MaxValue;
        System.TimeSpan val_3 = System.TimeSpan.FromDays(value:  1);
        this.lastCoinSpentDuration = val_3;
        this.unlockLevel = 0;
    }
    private void <OnLevelComplete>b__135_0()
    {
        UnityEngine.Object val_6;
        var val_7;
        if(this.isTriggered == false)
        {
                return;
        }
        
        if((this.<EventEnded>k__BackingField) == true)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        val_6 = 0;
        if(MainController.instance != val_6)
        {
                val_6 = 0;
            val_7 = MainController.instance.IsChapterComplete;
        }
        else
        {
                val_7 = 0;
        }
        
        if(((this & 1) != 0) && (this.GoldCurrencyPending >= 1))
        {
                if((this.<EventEnded>k__BackingField) == false)
        {
            goto label_15;
        }
        
        }
        
        if(this.CanShowReadyPopup() == false)
        {
                return;
        }
        
        this.purchasePoint = 52;
        this.ShowReadyPopup(endOfChapter:  val_7 & 1, flyout:  false);
        return;
        label_15:
        this.purchasePoint = 52;
        this.ShowInterstitialPopup(endOfChapter:  val_7 & 1, flyout:  false);
    }

}

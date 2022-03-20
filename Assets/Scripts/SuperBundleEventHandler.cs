using UnityEngine;
public class SuperBundleEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "SuperBundle";
    private const string packageLapse1 = "id_super_bundle_lapse1";
    private const string packageLapse2 = "id_super_bundle_lapse2";
    private const string packageLapse3 = "id_super_bundle_lapse3";
    private const string iapKey = "sb_iap";
    private const string iapLapse1 = "l1";
    private const string iapLapse2 = "l2";
    private const string iapLapse3 = "l3";
    private const string iapCoin = "c";
    private const string iapGold = "g";
    private const string expirePref = "sb_expire";
    private const string nextPref = "sb_next";
    private const string bundlePref = "sb_bundleID";
    private const string seenPref = "sb_seenB";
    private static SuperBundleEventHandler _Instance;
    public System.Action<bool> OnPurchaseAttemptResult;
    private int lapseDurationDays;
    private int bundleDurationMinutes;
    private int playerSpendLow;
    private int featureCooldownDays;
    private int promptCooldownSecs;
    private decimal coinBalanceCriterion;
    private PurchaseModel purchaseModel;
    private string priceUsual;
    private float discount;
    private int coinReward;
    private int goldReward;
    private bool isShowing;
    private System.DateTime nextPrompt;
    private TrackerPurchasePoints purchasePoint;
    
    // Properties
    public static SuperBundleEventHandler Instance { get; }
    private System.DateTime expireTime { get; set; }
    private System.DateTime nextTime { get; set; }
    private string currentBundleId { get; set; }
    private bool seenCurrentBundlePopup { get; set; }
    public PurchaseModel GetPurchaseModel { get; }
    public string GetUsualPrice { get; }
    public float GetDiscountPercent { get; }
    public int GetCoinReward { get; }
    public int GetGoldReward { get; }
    public System.DateTime GetBundleExpireTime { get; }
    public override bool OverrideEventButton { get; }
    public override bool IsEventHidden { get; }
    
    // Methods
    public static SuperBundleEventHandler get_Instance()
    {
        return (SuperBundleEventHandler)SuperBundleEventHandler._Instance;
    }
    private System.DateTime get_expireTime()
    {
        null = null;
        System.DateTime val_3 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "sb_expire", defaultValue:  System.DateTime.MinValue.ToString()), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        return (System.DateTime)val_3.dateData;
    }
    private void set_expireTime(System.DateTime value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "sb_expire", value:  value.dateData.ToString());
    }
    private System.DateTime get_nextTime()
    {
        null = null;
        System.DateTime val_3 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "sb_next", defaultValue:  System.DateTime.MinValue.ToString()), defaultValue:  new System.DateTime() {dateData = System.DateTime.MinValue});
        return (System.DateTime)val_3.dateData;
    }
    private void set_nextTime(System.DateTime value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "sb_next", value:  value.dateData.ToString());
    }
    private string get_currentBundleId()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "sb_bundleID", defaultValue:  "");
    }
    private void set_currentBundleId(string value)
    {
        UnityEngine.PlayerPrefs.SetString(key:  "sb_bundleID", value:  value);
    }
    private bool get_seenCurrentBundlePopup()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "sb_seenB", defaultValue:  0)) == 1) ? 1 : 0;
    }
    private void set_seenCurrentBundlePopup(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "sb_seenB", value:  value);
    }
    public PurchaseModel get_GetPurchaseModel()
    {
        return (PurchaseModel)this.purchaseModel;
    }
    public string get_GetUsualPrice()
    {
        return (string)this.priceUsual;
    }
    public float get_GetDiscountPercent()
    {
        return (float)this.discount;
    }
    public int get_GetCoinReward()
    {
        return (int)this.coinReward;
    }
    public int get_GetGoldReward()
    {
        return (int)this.goldReward;
    }
    public System.DateTime get_GetBundleExpireTime()
    {
        System.DateTime val_1 = this.expireTime;
        int val_2 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = 504464731990392832});
        if((val_2 & 2147483648) != 0)
        {
                return val_2.expireTime;
        }
        
        return (System.DateTime)System.DateTime.__il2cppRuntimeField_cctor_finished + 48;
    }
    public void TryPurchase()
    {
        var val_6;
        int val_7;
        var val_8;
        string val_9;
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = this.purchasePoint;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_7 = this.coinReward;
            val_8 = 0;
            decimal val_2 = System.Decimal.op_Implicit(value:  val_7);
            val_9 = "gems";
        }
        else
        {
                val_7 = this.coinReward;
            val_8 = 0;
            decimal val_3 = System.Decimal.op_Implicit(value:  val_7);
            val_9 = "credits";
        }
        
        this.purchaseModel.AddReward(rewardType:  val_9, amount:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        decimal val_4 = System.Decimal.op_Implicit(value:  this.goldReward);
        this.purchaseModel.AddReward(rewardType:  "golden_currency", amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
        bool val_5 = PurchaseProxy.Purchase(purchase:  this.purchaseModel);
    }
    public bool CanShowSuperBundleOnStoreOOCFlow()
    {
        var val_2;
        this.UpdateStateLogic();
        if((this.CheckAndShowPopup(flyout:  true)) != false)
        {
                val_2 = 1;
            this.purchasePoint = 122;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516745300784] = eventV2;
        SuperBundleEventHandler._Instance = this;
        if((SuperBundleEventHandler._Instance.__il2cppRuntimeField_68.ContainsKey(key:  "economy")) != false)
        {
                object val_2 = SuperBundleEventHandler._Instance.__il2cppRuntimeField_68.Item["economy"];
            if((val_2.ContainsKey(key:  "rew")) != false)
        {
                object val_5 = val_2.Item["rew"].Item["low"];
            this.playerSpendLow = null;
        }
        
            if((val_2.ContainsKey(key:  "lapsed_purchase_days")) != false)
        {
                object val_7 = val_2.Item["lapsed_purchase_days"];
            this.lapseDurationDays = null;
        }
        
            if((val_2.ContainsKey(key:  "bundle_expire_minutes")) != false)
        {
                object val_9 = val_2.Item["bundle_expire_minutes"];
            this.bundleDurationMinutes = null;
        }
        
            if((val_2.ContainsKey(key:  "feature_cool_days")) != false)
        {
                object val_11 = val_2.Item["feature_cool_days"];
            this.featureCooldownDays = null;
        }
        
            if((val_2.ContainsKey(key:  "prompt_cool_seconds")) != false)
        {
                object val_13 = val_2.Item["prompt_cool_seconds"];
            this.promptCooldownSecs = null;
        }
        
            if((val_2.ContainsKey(key:  "coin_balance_criteria")) != false)
        {
                object val_15 = val_2.Item["coin_balance_criteria"];
            decimal val_16 = System.Decimal.op_Implicit(value:  19914752);
            this.coinBalanceCriterion = val_16;
            mem[1152921516745300836] = val_16.lo;
            mem[1152921516745300840] = val_16.mid;
        }
        
        }
        
        this.UpdateStateLogic();
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "super_bundle")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail();
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "super_bundle")) != false)
        {
                this.OnPurchaseSuccess();
            return;
        }
        
        this.UpdateStateLogic();
    }
    public override void OnProcessPurchase(ref PurchaseModel purchased)
    {
        var val_9;
        var val_10;
        var val_14;
        val_10 = 1152921516745754864;
        if(purchased == null)
        {
                throw new NullReferenceException();
        }
        
        if(purchased.id == null)
        {
                throw new NullReferenceException();
        }
        
        if((purchased.id.Contains(value:  "super_bundle")) == false)
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
        
        if((System.String.op_Equality(a:  (PurchaseModel)[1152921516745771200].id, b:  purchased.id)) != false)
        {
                if(purchased == null)
        {
                throw new NullReferenceException();
        }
        
            sale_price = (PurchaseModel)[1152921516745771200].sale_price;
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
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "super_bundle", defaultValue:  "SUPER BUNDLE", useSingularKey:  false), arg1:  this.purchaseModel.LocalPrice);
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "super_bundle", defaultValue:  "SUPER BUNDLE", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        ulong val_11;
        long val_12;
        var val_13;
        var val_14;
        System.DateTime val_1 = this.expireTime;
        int val_2 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = 504464731990392832});
        if((val_2 & 2147483648) == 0)
        {
                val_11 = mem[System.DateTime.__il2cppRuntimeField_cctor_finished + 48];
            val_11 = System.DateTime.__il2cppRuntimeField_cctor_finished + 48;
        }
        else
        {
                System.DateTime val_3 = val_2.expireTime;
            val_11 = val_3.dateData;
        }
        
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_11}, d2:  new System.DateTime() {dateData = val_4.dateData});
        val_12 = val_5._ticks;
        val_13 = null;
        val_13 = null;
        if(((System.TimeSpan.Compare(t1:  new System.TimeSpan() {_ticks = val_12}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) & 2147483648) == 0)
        {
                return (string)System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_12.Days, arg1:  val_12.Hours, arg2:  val_12.Minutes);
        }
        
        val_14 = null;
        val_14 = null;
        val_12 = System.TimeSpan.Zero;
        return (string)System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_12.Days, arg1:  val_12.Hours, arg2:  val_12.Minutes);
    }
    public override System.DateTime GetTimeEnd()
    {
        System.DateTime val_1 = this.expireTime;
        int val_2 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = 504464731990392832});
        if((val_2 & 2147483648) != 0)
        {
                return val_2.expireTime;
        }
        
        return (System.DateTime)System.DateTime.__il2cppRuntimeField_cctor_finished + 48;
    }
    public override void OnGameSceneBegan()
    {
        this.UpdateStateLogic();
        if((this.CheckAndShowPopup(flyout:  false)) == false)
        {
                return;
        }
        
        this.purchasePoint = 106;
    }
    public override void OnMenuLoaded()
    {
        this.UpdateStateLogic();
        if((this.CheckAndShowPopup(flyout:  false)) == false)
        {
                return;
        }
        
        this.purchasePoint = 105;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        this.purchasePoint = 107;
        this.ShowPopup(flyout:  false);
    }
    public override bool get_OverrideEventButton()
    {
        return true;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        this.purchasePoint = 105;
        this.ShowPopup(flyout:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentSuperBundle>(allowMultiple:  false).Setup(handler:  this);
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        if(this.purchaseModel == null)
        {
                return;
        }
        
        AppConfigs val_1 = App.Configuration;
        if((val_1.storeConfig.GetProductByInternalId(internalId:  this.purchaseModel.id)) == null)
        {
            goto label_7;
        }
        
        label_9:
        currentData.Add(key:  "SuperBundle", value:  val_2.sku);
        return;
        label_7:
        if(currentData != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
    }
    public override bool get_IsEventHidden()
    {
        return (bool)(this.isShowing == false) ? 1 : 0;
    }
    public override void OnMyEventPopupClosed()
    {
        this.UpdateStateLogic();
        this.OnMyEventPopupClosed();
        this.UpdateProgress();
    }
    public override string GetHackPanelEventData()
    {
        object val_85;
        string val_86;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        string val_85 = "TIME NOW {0}";
        val_85 = val_1.AppendLine(value:  System.String.Format(format:  val_85, arg0:  val_2.dateData.ToString())).seenCurrentBundlePopup;
        System.DateTime val_10 = val_1.AppendLine(value:  System.String.Format(format:  "Has Seen Popup This Cycle {0}", arg0:  val_85.ToString())).expireTime;
        System.Text.StringBuilder val_13 = val_1.AppendLine(value:  System.String.Format(format:  "Bundle Expire Time: {0}", arg0:  val_10.dateData.ToString()));
        System.DateTime val_17 = val_1.AppendLine(value:  System.String.Format(format:  "Event Expire Time: {0}", arg0:  ToString())).nextTime;
        System.Text.StringBuilder val_20 = val_1.AppendLine(value:  System.String.Format(format:  "Next Cycle Start: {0}", arg0:  val_17.dateData.ToString()));
        System.Text.StringBuilder val_23 = val_1.AppendLine(value:  System.String.Format(format:  "Is Showing: {0}", arg0:  this.isShowing.ToString()));
        string val_86 = "Next Popup: {0}";
        val_86 = val_1.AppendLine(value:  System.String.Format(format:  val_86, arg0:  this.nextPrompt.ToString())).BeforeExpire();
        string val_87 = "Is Before Expire: {0}";
        val_87 = val_1.AppendLine(value:  System.String.Format(format:  val_87, arg0:  val_86.ToString())).isReadyForNext();
        System.Text.StringBuilder val_34 = val_1.AppendLine(value:  System.String.Format(format:  "Is After Next Cycle: {0}", arg0:  val_87.ToString()));
        System.Text.StringBuilder val_37 = val_1.AppendLine(value:  System.String.Format(format:  "Is Hidden: {0}", arg0:  0.ToString()));
        bool val_44 = System.String.IsNullOrEmpty(value:  val_1.AppendLine(value:  System.String.Format(format:  "Popup Ready: {0}", arg0:  this.readyToShowPopup().ToString())).currentBundleId);
        if(val_44 != false)
        {
                val_85 = "not set";
        }
        else
        {
                val_85 = val_44.currentBundleId;
        }
        
        if((System.String.IsNullOrEmpty(value:  val_1.AppendLine(value:  System.String.Format(format:  "Current Package ID: {0}", arg0:  val_85)).currentBundleId)) != false)
        {
                val_86 = "not set";
        }
        else
        {
                if((val_50.storeConfig.GetProductByInternalId(internalId:  App.Configuration.currentBundleId)) == null)
        {
            goto label_17;
        }
        
            val_86 = val_52.sku;
        }
        
        label_17:
        System.Text.StringBuilder val_54 = val_1.AppendLine(value:  System.String.Format(format:  "Current Package SKU: {0}", arg0:  mem[val_52.sku]));
        System.Text.StringBuilder val_58 = val_1.AppendLine(value:  System.String.Format(format:  "Is Lapsed Or Non {0}", arg0:  this.isLapsedOrNonPurchaser()));
        System.Text.StringBuilder val_62 = val_1.AppendLine(value:  System.String.Format(format:  "Is under coin criteria {0}", arg0:  this.isUnderCoinLimit()));
        Player val_63 = App.Player;
        float val_88 = val_63.transactionsAverageAmount;
        val_88 = val_88 * 100f;
        System.Text.StringBuilder val_65 = val_1.AppendLine(value:  System.String.Format(format:  "Player Purchase Amt {0}", arg0:  val_88));
        System.Text.StringBuilder val_66 = val_1.AppendLine(value:  "KNOB DATA / ECON");
        System.Text.StringBuilder val_69 = val_1.AppendLine(value:  System.String.Format(format:  "lapse days {0}", arg0:  this.lapseDurationDays.ToString()));
        System.Text.StringBuilder val_72 = val_1.AppendLine(value:  System.String.Format(format:  "bundle mins {0}", arg0:  this.bundleDurationMinutes.ToString()));
        System.Text.StringBuilder val_75 = val_1.AppendLine(value:  System.String.Format(format:  "spend low {0}", arg0:  this.playerSpendLow.ToString()));
        System.Text.StringBuilder val_78 = val_1.AppendLine(value:  System.String.Format(format:  "cooldown days {0}", arg0:  this.featureCooldownDays.ToString()));
        System.Text.StringBuilder val_81 = val_1.AppendLine(value:  System.String.Format(format:  "prompt secs {0}", arg0:  this.promptCooldownSecs.ToString()));
        System.Text.StringBuilder val_84 = val_1.AppendLine(value:  System.String.Format(format:  "coin criteria {0}", arg0:  this.coinBalanceCriterion.ToString()));
        return (string)val_1;
    }
    private bool CheckAndShowPopup(bool flyout = False)
    {
        ulong val_6;
        var val_7;
        if(this.isShowing != false)
        {
                if((this.readyToShowPopup() == true) || (flyout == true))
        {
            goto label_3;
        }
        
        }
        
        val_7 = 0;
        return (bool)val_7;
        label_3:
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        val_6 = val_2.dateData;
        System.TimeSpan val_3 = System.TimeSpan.FromSeconds(value:  (double)this.promptCooldownSecs);
        System.DateTime val_4 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_6}, t:  new System.TimeSpan() {_ticks = val_3._ticks});
        this.nextPrompt = val_4;
        this.ShowPopup(flyout:  flyout);
        val_7 = 1;
        return (bool)val_7;
    }
    private void ShowPopup(bool flyout = False)
    {
        bool val_14 = flyout;
        bool val_1 = this.seenCurrentBundlePopup;
        if(val_1 != true)
        {
                val_1.seenCurrentBundlePopup = true;
            System.DateTime val_2 = DateTimeCheat.UtcNow;
            System.TimeSpan val_3 = System.TimeSpan.FromMinutes(value:  (double)this.bundleDurationMinutes);
            System.DateTime val_4 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_2.dateData}, t:  new System.TimeSpan() {_ticks = val_3._ticks});
            val_4.dateData.expireTime = new System.DateTime() {dateData = val_4.dateData};
        }
        
        if(val_14 != false)
        {
                GameBehavior val_5 = App.getBehavior;
            val_14 = ???;
        }
        else
        {
                WGWindowManager val_13 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SuperBundleEventPopup>(showNext:  false);
        }
    
    }
    private void UpdateStateLogic()
    {
        var val_12;
        bool val_1 = this.BeforeExpire();
        if(val_1 == true)
        {
            goto label_1;
        }
        
        bool val_2 = val_1.isReadyForNext();
        if(val_2 == false)
        {
            goto label_6;
        }
        
        label_1:
        bool val_3 = val_2.BeforeExpire();
        if((val_3 == true) || (val_3.isReadyForNext() == false))
        {
            goto label_4;
        }
        
        if(this.isLapsedOrNonPurchaser() == false)
        {
            goto label_6;
        }
        
        bool val_6 = this.isUnderCoinLimit();
        if(val_6 == false)
        {
            goto label_6;
        }
        
        val_6.seenCurrentBundlePopup = false;
        val_12 = null;
        val_12 = null;
        expireTime = new System.DateTime() {dateData = System.DateTime.MaxValue};
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        System.TimeSpan val_8 = System.TimeSpan.FromDays(value:  (double)this.featureCooldownDays);
        System.DateTime val_9 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_7.dateData}, t:  new System.TimeSpan() {_ticks = val_8._ticks});
        val_9.dateData.nextTime = new System.DateTime() {dateData = val_9.dateData};
        this.DetermineBundle();
        this.SetNotification();
        goto label_15;
        label_4:
        bool val_10 = val_3.BeforeExpire();
        if(val_10 == false)
        {
                return;
        }
        
        this.SetPurchaseModel(PackageID:  val_10.currentBundleId);
        if(this.purchaseModel == null)
        {
                this.DetermineBundle();
        }
        
        label_15:
        this.isShowing = true;
        return;
        label_6:
        this.KillBundle();
    }
    private void KillBundle()
    {
        this.isShowing = false;
        this.currentBundleId = "";
        this.CancelNotification();
    }
    private bool BeforeExpire()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = val_1.dateData.expireTime;
        return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_2.dateData})) < 1) ? 1 : 0;
    }
    private bool isReadyForNext()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.DateTime val_2 = val_1.dateData.nextTime;
        return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_2.dateData})) > 0) ? 1 : 0;
    }
    private bool readyToShowPopup()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return (bool)((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = this.nextPrompt})) > 0) ? 1 : 0;
    }
    private bool isLapsedOrNonPurchaser()
    {
        ulong val_8;
        var val_9;
        val_8 = this;
        Player val_1 = App.Player;
        if(val_1.num_purchase >= 1)
        {
                Player val_2 = App.Player;
            System.TimeSpan val_3 = System.TimeSpan.FromDays(value:  (double)this.lapseDurationDays);
            System.DateTime val_4 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_2.last_purchase}, t:  new System.TimeSpan() {_ticks = val_3._ticks});
            val_8 = val_4.dateData;
            System.DateTime val_5 = DateTimeCheat.UtcNow;
            var val_7 = ((System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_8}, t2:  new System.DateTime() {dateData = val_5.dateData})) < 1) ? 1 : 0;
            return (bool)val_9;
        }
        
        val_9 = 1;
        return (bool)val_9;
    }
    private bool isUnderCoinLimit()
    {
        var val_5;
        int val_6;
        int val_7;
        decimal val_8;
        var val_9;
        val_5 = this;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Player val_2 = App.Player;
            val_6 = val_2._gems;
            val_7 = 0;
            decimal val_3 = System.Decimal.op_Implicit(value:  val_6);
            val_8 = this.coinBalanceCriterion;
            return System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_6, hi = val_6, lo = val_7, mid = val_7}, d2:  new System.Decimal() {flags = val_8, hi = val_8, lo = -742592416, mid = 268435458});
        }
        
        Player val_4 = App.Player;
        val_6 = val_4._credits;
        val_7 = X21;
        val_8 = this.coinBalanceCriterion;
        val_9 = val_5;
        return System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_6, hi = val_6, lo = val_7, mid = val_7}, d2:  new System.Decimal() {flags = val_8, hi = val_8, lo = -742592416, mid = 268435458});
    }
    private void SetPurchaseModel(string PackageID)
    {
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  PackageID);
        if(val_1 == null)
        {
                return;
        }
        
        this.purchaseModel = new PurchaseModel(json:  val_1);
        this.priceUsual = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  ""))).LocalPrice;
        float val_9 = 100f;
        float val_7 = (PurchaseModel)[1152921516749370080].sale_price - this.purchaseModel.sale_price;
        val_7 = val_7 / (PurchaseModel)[1152921516749370080].sale_price;
        val_9 = val_7 * val_9;
        this.discount = (float)UnityEngine.Mathf.RoundToInt(f:  val_9);
        this.SetRewards(PackageID:  PackageID);
    }
    private void SetRewards(string PackageID)
    {
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        if((System.String.op_Equality(a:  PackageID, b:  "id_super_bundle_lapse3")) != false)
        {
                val_19 = "l3";
        }
        else
        {
                string val_3 = ((System.String.op_Equality(a:  PackageID, b:  "id_super_bundle_lapse2")) != true) ? "l2" : "l1";
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = null;
        val_20 = val_4;
        val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((App.getGameEcon.GetGameplayKnobs().ContainsKey(key:  "sb_iap")) != false)
        {
                object val_10 = App.getGameEcon.GetGameplayKnobs().Item["sb_iap"];
            val_21 = null;
            val_20 = 0;
        }
        else
        {
                val_21 = null;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = null;
        val_22 = val_12;
        val_12 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((ContainsKey(key:  val_3)) != false)
        {
                val_22 = Item[val_3];
        }
        
        if((val_12.ContainsKey(key:  "c")) != false)
        {
                object val_16 = val_12.Item["c"];
            this.coinReward = null;
        }
        
        if((val_12.ContainsKey(key:  "g")) == false)
        {
                return;
        }
        
        object val_18 = val_12.Item["g"];
        this.goldReward = null;
    }
    private void DetermineBundle()
    {
        var val_2;
        string val_3;
        val_2 = "id_super_bundle_lapse1";
        float val_2 = val_1.transactionsAverageAmount;
        val_2 = val_2 * 100f;
        if(val_2 >= (float)this.playerSpendLow)
        {
            goto label_4;
        }
        
        if(val_2 <= 0f)
        {
            goto label_5;
        }
        
        val_3 = "id_super_bundle_lapse2";
        goto label_6;
        label_4:
        val_3 = "id_super_bundle_lapse3";
        label_6:
        label_5:
        App.Player.currentBundleId = val_3;
        this.SetPurchaseModel(PackageID:  val_3);
    }
    private void OnPurchaseSuccess()
    {
        SLC.Social.Leagues.LeaguesManager.OnAppleAwarded(appleAwarded:  this.goldReward);
        this.TrackPurchaseMade();
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  1);
        System.DateTime val_3 = System.DateTime.op_Subtraction(d:  new System.DateTime() {dateData = val_1.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        val_3.dateData.expireTime = new System.DateTime() {dateData = val_3.dateData};
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        System.TimeSpan val_5 = System.TimeSpan.FromDays(value:  (double)this.featureCooldownDays);
        System.DateTime val_6 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_4.dateData}, t:  new System.TimeSpan() {_ticks = val_5._ticks});
        val_6.dateData.nextTime = new System.DateTime() {dateData = val_6.dateData};
        this.KillBundle();
        this.UpdateStateLogic();
        this.OnPurchaseAttemptResult.Invoke(obj:  true);
        this.UpdateProgress();
    }
    private void TrackPurchaseMade()
    {
        var val_2 = null;
        App.trackerManager.track(eventName:  this.purchaseModel.id.Replace(oldValue:  "id_super_bundle_", newValue:  "purchase_sb_"));
    }
    private void OnPurchaseFail()
    {
        this.OnPurchaseAttemptResult.Invoke(obj:  false);
    }
    private void SetNotification()
    {
        ulong val_7;
        System.DateTime val_1 = this.expireTime;
        int val_2 = System.DateTime.Compare(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = 504464731990392832});
        if((val_2 & 2147483648) == 0)
        {
                val_7 = mem[System.DateTime.__il2cppRuntimeField_cctor_finished + 48];
            val_7 = System.DateTime.__il2cppRuntimeField_cctor_finished + 48;
        }
        else
        {
                System.DateTime val_3 = val_2.expireTime;
            val_7 = val_3.dateData;
        }
        
        System.TimeSpan val_4 = System.TimeSpan.FromHours(value:  1);
        System.DateTime val_5 = System.DateTime.op_Subtraction(d:  new System.DateTime() {dateData = val_7}, t:  new System.TimeSpan() {_ticks = val_4._ticks});
        System.DateTime val_6 = val_5.dateData.ToLocalTime();
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  27, when:  new System.DateTime() {dateData = val_6.dateData}, optMessage:  "Your Super Bundle Offer is bursting with Coins! Collect Now!", extraData:  0);
    }
    private void CancelNotification()
    {
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  27);
    }
    public SuperBundleEventHandler()
    {
        var val_2;
        decimal val_1;
        this.promptCooldownSecs = 120;
        this.lapseDurationDays = ;
        this.bundleDurationMinutes = ;
        this.playerSpendLow = 30064771471;
        this.featureCooldownDays = 7;
        val_1 = new System.Decimal(value:  172);
        this.coinBalanceCriterion = val_1.flags;
        val_2 = null;
        val_2 = null;
        this.nextPrompt = System.DateTime.MinValue;
    }

}

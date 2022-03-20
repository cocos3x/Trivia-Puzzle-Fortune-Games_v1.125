using UnityEngine;
public class WGWaterfallSaleManager : MonoSingleton<WGWaterfallSaleManager>
{
    // Fields
    public const string WATERFALL_HINT_NOTIF = "OnHintUsed";
    public const string pref_waterfall_started = "waterfall_started";
    public const string pref_waterfall_last_seen = "waterfall_last_seen";
    private bool waterfallEnabled;
    private int PriceReductionInterval;
    private int LevelLock;
    private int MinutesToDisplay;
    private bool waterfallOOC;
    private bool hintUsed;
    private bool waterFallSeen;
    private int PriceReductionLevels;
    private PurchaseModel purchaseModel;
    private PurchaseModel valueModel;
    private bool canPurchase;
    private WGWaterfallSalePopup currentPopup;
    private System.Action<bool> WGStoreProxyAction;
    private bool qahack_useMinutes;
    private readonly int[] packageMapping;
    
    // Properties
    public bool CanPurchaseSale { get; set; }
    public bool QAHACK_UseMinutes { get; set; }
    public int QAHACK_Interval { get; }
    public int QAHACK_LevelReq { get; }
    public bool QAHACK_Enabled { get; }
    public int QAHACK_CurrentInterval { get; }
    public bool QAHACK_SeenThisSession { get; }
    public bool QAHACK_OOC_Enabled { get; }
    public string QAHACK_CurrentShowLogic { get; }
    private bool IsFeatureEnabled { get; }
    public bool IsSaleWaterfallEnabled { get; }
    
    // Methods
    public bool get_CanPurchaseSale()
    {
        return (bool)this.canPurchase;
    }
    public void set_CanPurchaseSale(bool value)
    {
        this.canPurchase = value;
    }
    public bool get_QAHACK_UseMinutes()
    {
        return (bool)this.qahack_useMinutes;
    }
    public void set_QAHACK_UseMinutes(bool value)
    {
        this.qahack_useMinutes = value;
    }
    public int get_QAHACK_Interval()
    {
        return (int)this.PriceReductionInterval;
    }
    public int get_QAHACK_LevelReq()
    {
        return (int)this.LevelLock;
    }
    public bool get_QAHACK_Enabled()
    {
        return (bool)this.waterfallEnabled;
    }
    public int get_QAHACK_CurrentInterval()
    {
        return this.GetSaleInterval();
    }
    public bool get_QAHACK_SeenThisSession()
    {
        return (bool)this.waterFallSeen;
    }
    public bool get_QAHACK_OOC_Enabled()
    {
        return (bool)this.waterfallOOC;
    }
    public string get_QAHACK_CurrentShowLogic()
    {
        long val_25;
        var val_26;
        int val_27;
        int val_28;
        var val_29;
        var val_30;
        string val_32;
        if(this.IsFeatureEnabled == false)
        {
            goto label_1;
        }
        
        val_26 = null;
        val_26 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
            goto label_7;
        }
        
        if(this.hintUsed == false)
        {
            goto label_8;
        }
        
        val_27 = this.PriceReductionInterval;
        if(this.qahack_useMinutes == false)
        {
            goto label_9;
        }
        
        val_28 = 0;
        val_29 = 0;
        goto label_10;
        label_1:
        val_30 = "Feature Disabled";
        return (string)val_30;
        label_7:
        val_30 = "No Network Connection";
        return (string)val_30;
        label_8:
        val_30 = "Hint not used";
        return (string)val_30;
        label_9:
        val_28 = val_27;
        val_29 = 0;
        val_27 = 0;
        label_10:
        System.TimeSpan val_2 = new System.TimeSpan(days:  val_28, hours:  0, minutes:  0, seconds:  0);
        System.DateTime val_3 = ServerHandler.ServerTime;
        Player val_4 = App.Player;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = val_4.last_purchase});
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_5._ticks}, t2:  new System.TimeSpan() {_ticks = val_2._ticks})) == false)
        {
            goto label_23;
        }
        
        Player val_7 = App.Player;
        if(val_7.total_purchased != 0f)
        {
            goto label_27;
        }
        
        label_23:
        System.DateTime val_8 = ServerHandler.ServerTime;
        System.DateTime val_13 = System.DateTime.FromBinary(dateData:  System.Int64.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "waterfall_last_seen", defaultValue:  0.ToBinary().ToString())));
        System.TimeSpan val_14 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_8.dateData}, d2:  new System.DateTime() {dateData = val_13.dateData});
        val_25 = val_14._ticks;
        if(((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_25}, t2:  new System.TimeSpan() {_ticks = val_2._ticks})) == false) || (this.waterFallSeen == false))
        {
            goto label_35;
        }
        
        System.DateTime val_20 = System.DateTime.FromBinary(dateData:  System.Int64.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "waterfall_last_seen", defaultValue:  0.ToBinary().ToString())));
        System.DateTime val_21 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_20.dateData}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        val_32 = "Already seen, next showing {0}";
        goto label_38;
        label_35:
        val_30 = "Ready To Show";
        return (string)val_30;
        label_27:
        Player val_22 = App.Player;
        System.DateTime val_23 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_22.last_purchase}, t:  new System.TimeSpan() {_ticks = val_2._ticks});
        val_32 = "Blocked by purchase until {0}";
        label_38:
        string val_24 = System.String.Format(format:  val_32, arg0:  val_23);
        return (string)val_30;
    }
    private bool get_IsFeatureEnabled()
    {
        var val_3;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) >= this.LevelLock)
        {
                return (bool)(this.waterfallEnabled == true) ? 1 : 0;
        }
        
        val_3 = 0;
        return (bool)(this.waterfallEnabled == true) ? 1 : 0;
    }
    public bool get_IsSaleWaterfallEnabled()
    {
        return this.IsFeatureEnabled;
    }
    public override void InitMonoSingleton()
    {
        var val_12;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnHintUsed");
        AppConfigs val_3 = App.Configuration;
        this.waterfallEnabled = val_3.econConfig.WGWaterfall;
        AppConfigs val_4 = App.Configuration;
        this.PriceReductionInterval = val_4.econConfig.WGWaterfallIntervalDays;
        AppConfigs val_5 = App.Configuration;
        this.MinutesToDisplay = val_5.econConfig.WaterfallDisplayMinutes;
        val_12 = null;
        val_12 = null;
        System.Delegate val_7 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGWaterfallSaleManager::PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchased)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_7;
        System.Delegate val_9 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGWaterfallSaleManager::PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_9;
        System.Delegate val_11 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGWaterfallSaleManager::PurchasesHandler_OnPurchaseFailure(PurchaseModel purchased)));
        if(val_11 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_11;
        return;
        label_20:
    }
    private void PurchasesHandler_OnPurchaseFailure(PurchaseModel purchased)
    {
        if((purchased.id.Contains(value:  "waterfall")) == false)
        {
                return;
        }
        
        this.HandlePurchaseFailure();
    }
    private void PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)
    {
        if((purchased.id.Contains(value:  "waterfall")) == false)
        {
                return;
        }
        
        decimal val_2 = purchased.Credits;
        this.HandlePurchaseSuccess(coinsToReceive:  System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}));
    }
    private void PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchased)
    {
        if((purchased.id.Contains(value:  "waterfall")) == false)
        {
                return;
        }
        
        if((System.String.IsNullOrEmpty(value:  purchased.id)) != false)
        {
                UnityEngine.Debug.LogError(message:  "WHOOPS. Purchase id is null!");
            return;
        }
        
        twelvegigs.storage.JsonDictionary val_3 = PackagesManager.GetPackageById(packageId:  purchased.id);
        twelvegigs.storage.JsonDictionary val_5 = PackagesManager.GetPackageById(packageId:  val_3.getString(key:  "credit_package", defaultValue:  ""));
        decimal val_7 = System.Decimal.op_Implicit(value:  val_5.getInt(key:  "credits", defaultValue:  0));
        purchased.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        sale_price = val_3.getFloat(key:  "sale_price", defaultValue:  0f);
        targetSalePrice = val_5.getFloat(key:  "sale_price", defaultValue:  1f);
        1152921517525896976 = purchased;
        price = val_5.getString(key:  "regular_price", defaultValue:  purchased.sale_price.ToString());
    }
    private void OnServerSync()
    {
        var val_13;
        null = null;
        System.Collections.IDictionary val_1 = getSalesLogic();
        if(val_1 == null)
        {
                return;
        }
        
        var val_2 = (((System.Collections.IDictionary.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_1) : 0;
        val_13 = 1152921510222861648;
        if((val_2.ContainsKey(key:  "wgwaterfall")) != false)
        {
                object val_4 = val_2.Item["wgwaterfall"];
            this.waterfallEnabled = null;
        }
        
        if((val_2.ContainsKey(key:  "wgwaterfall_interval")) != false)
        {
                object val_6 = val_2.Item["wgwaterfall_interval"];
            this.PriceReductionInterval = null;
        }
        
        if((val_2.ContainsKey(key:  "wgwaterfall_display")) != false)
        {
                object val_8 = val_2.Item["wgwaterfall_display"];
            this.MinutesToDisplay = null;
        }
        
        if((val_2.ContainsKey(key:  "wgwaterfall_level")) != false)
        {
                object val_10 = val_2.Item["wgwaterfall_level"];
            this.LevelLock = null;
        }
        
        if((val_2.ContainsKey(key:  "wgwaterfall_ooc")) == false)
        {
                return;
        }
        
        object val_12 = val_2.Item["wgwaterfall_ooc"];
        this.waterfallOOC = null;
    }
    private void OnHintUsed()
    {
        this.hintUsed = true;
    }
    private void GeneratePackages()
    {
        int val_1 = this.GetSaleInterval();
        twelvegigs.storage.JsonDictionary val_4 = PackagesManager.GetPackageById(packageId:  "id_waterfall_" + val_1.ToString());
        this.valueModel = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_4.getString(key:  "credit_package", defaultValue:  "")));
        this.purchaseModel = new PurchaseModel(json:  val_4);
        .ltoModifier = System.String.Format(format:  "sale_waterfall_{0}", arg0:  val_1.ToString());
    }
    private int GetSaleInterval()
    {
        var val_22;
        var val_23;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "waterfall_started")) == false)
        {
            goto label_1;
        }
        
        System.DateTime val_4 = System.DateTime.FromBinary(dateData:  System.Int64.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "waterfall_started")));
        System.DateTime val_5 = ServerHandler.ServerTime;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime() {dateData = val_4.dateData});
        if(this.qahack_useMinutes == false)
        {
            goto label_6;
        }
        
        int val_8 = val_6._ticks.Minutes;
        goto label_7;
        label_1:
        val_22 = 0;
        goto label_8;
        label_6:
        label_7:
        val_22 = System.Math.Min(val1:  val_6._ticks.Days / ((this.PriceReductionInterval > 1) ? this.PriceReductionInterval : (0 + 1)), val2:  this.PriceReductionLevels - 1);
        label_8:
        Player val_13 = App.Player;
        if(val_13.lastPurchasePrice >= 49.99f)
        {
            goto label_14;
        }
        
        Player val_14 = App.Player;
        if(val_14.lastPurchasePrice >= 19.99f)
        {
            goto label_18;
        }
        
        Player val_15 = App.Player;
        if(val_15.lastPurchasePrice >= 9.99f)
        {
            goto label_22;
        }
        
        Player val_16 = App.Player;
        val_23 = 3;
        if(val_16.num_purchase != 0)
        {
            goto label_29;
        }
        
        var val_18 = (WGStarterPackController.HasSeenExpiredStarterPack != true) ? (val_23 + 1) : (val_23);
        goto label_29;
        label_14:
        val_23 = 0;
        goto label_29;
        label_18:
        val_23 = 1;
        goto label_29;
        label_22:
        val_23 = 2;
        label_29:
        return (int)this.packageMapping[System.Math.Min(val1:  val_23 + val_22, val2:  this.PriceReductionLevels - 1)];
    }
    public void HandlePurchaseSuccess(int coinsToReceive)
    {
        WGWaterfallSalePopup val_5;
        UnityEngine.PlayerPrefs.DeleteKey(key:  "waterfall_started");
        WGWaterfallSaleManager val_1 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        val_1.canPurchase = true;
        val_5 = this.currentPopup;
        if(val_5 == 0)
        {
                return;
        }
        
        if(this.WGStoreProxyAction != null)
        {
                val_5 = this.currentPopup.GetComponent<SLCWindow>();
            val_3.Action_OnClose = new System.Action(object:  this, method:  System.Void WGWaterfallSaleManager::<HandlePurchaseSuccess>b__50_0());
        }
        
        this.currentPopup.AnimateCoins(coinsPurchased:  coinsToReceive);
    }
    public void HandlePurchaseFailure()
    {
        var val_21;
        int val_22;
        var val_23;
        .<>4__this = this;
        WGWaterfallSaleManager val_2 = MonoSingleton<WGWaterfallSaleManager>.Instance;
        val_2.canPurchase = true;
        bool val_5 = UnityEngine.Object.op_Inequality(x:  this.currentPopup.gameObject.GetComponent<WGFlyoutWindow>(), y:  0);
        .wasFlyout = val_5;
        if(val_5 == false)
        {
            goto label_13;
        }
        
        WGFlyoutWindow val_8 = this.currentPopup.gameObject.GetComponent<WGFlyoutWindow>();
        mem2[0] = 0;
        if(((WGWaterfallSaleManager.<>c__DisplayClass51_0)[1152921517526977248].wasFlyout) == false)
        {
            goto label_13;
        }
        
        WGFlyoutManager val_9 = MonoSingleton<WGFlyoutManager>.Instance;
        val_21 = 1152921517526870000;
        goto label_17;
        label_13:
        val_21 = 1152921515849370336;
        label_17:
        bool[] val_14 = new bool[2];
        val_14[0] = true;
        string[] val_15 = new string[2];
        val_22 = val_15.Length;
        val_15[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_22 = val_15.Length;
        val_15[1] = "NO";
        System.Func<System.Boolean>[] val_17 = new System.Func<System.Boolean>[2];
        val_17[0] = new System.Func<System.Boolean>(object:  new WGWaterfallSaleManager.<>c__DisplayClass51_0(), method:  System.Boolean WGWaterfallSaleManager.<>c__DisplayClass51_0::<HandlePurchaseFailure>b__0());
        val_23 = null;
        val_23 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  true).SetupMessage(titleTxt:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false), shownButtons:  val_14, buttonTexts:  val_15, showClose:  false, buttonCallbacks:  val_17, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
        if(this.currentPopup == 0)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.currentPopup.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public bool CanDisplayWaterfallSale(bool oocFlow = False)
    {
        long val_18;
        var val_19;
        int val_20;
        int val_21;
        var val_22;
        System.DateTime val_23;
        var val_24;
        if(this.IsFeatureEnabled == false)
        {
            goto label_39;
        }
        
        val_18 = 1152921504886665216;
        val_19 = null;
        val_19 = null;
        if(((NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null) || (this.hintUsed == false)) || (WGStarterPackController.IsInStarterPackDelay == true))
        {
            goto label_39;
        }
        
        if((FOMOPackEventHandler.<Instance>k__BackingField) != null)
        {
                if((FOMOPackEventHandler.<Instance>k__BackingField.AvailableShow) == true)
        {
            goto label_39;
        }
        
        }
        
        val_20 = this.PriceReductionInterval;
        if(this.qahack_useMinutes != false)
        {
                val_21 = 0;
            val_22 = 0;
        }
        else
        {
                System.TimeSpan val_4;
            val_21 = val_20;
            val_22 = 0;
            val_20 = 0;
        }
        
        val_4 = new System.TimeSpan(days:  val_21, hours:  0, minutes:  0, seconds:  0);
        val_18 = val_4._ticks;
        System.DateTime val_5 = ServerHandler.ServerTime;
        Player val_6 = App.Player;
        val_23 = val_6.last_purchase;
        System.TimeSpan val_7 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime() {dateData = val_23});
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_7._ticks}, t2:  new System.TimeSpan() {_ticks = val_18})) == false)
        {
            goto label_24;
        }
        
        Player val_9 = App.Player;
        if(val_9.total_purchased != 0f)
        {
            goto label_39;
        }
        
        label_24:
        System.DateTime val_10 = ServerHandler.ServerTime;
        val_23 = System.Int64.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "waterfall_last_seen", defaultValue:  0.ToBinary().ToString()));
        System.DateTime val_15 = System.DateTime.FromBinary(dateData:  val_23);
        System.TimeSpan val_16 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_10.dateData}, d2:  new System.DateTime() {dateData = val_15.dateData});
        if(((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_16._ticks}, t2:  new System.TimeSpan() {_ticks = val_18})) != false) && (this.waterFallSeen != false))
        {
                if(oocFlow == false)
        {
            goto label_39;
        }
        
        }
        
        if(oocFlow != false)
        {
                if(this.waterfallOOC == false)
        {
            goto label_39;
        }
        
        }
        
        val_24 = 1;
        return (bool)val_24;
        label_39:
        val_24 = 0;
        return (bool)val_24;
    }
    public void ShowPopup(bool oocFlow = False, System.Action<bool> storeCloseCallback)
    {
        System.Delegate val_23;
        WGWaterfallSalePopup val_24;
        var val_25;
        var val_26;
        var val_27;
        System.DateTime val_1 = ServerHandler.ServerTime;
        UnityEngine.PlayerPrefs.SetString(key:  "waterfall_last_seen", value:  val_1.dateData.ToBinary().ToString());
        this.waterFallSeen = true;
        val_23 = "waterfall_started";
        if((UnityEngine.PlayerPrefs.HasKey(key:  "waterfall_started")) == false)
        {
            goto label_3;
        }
        
        System.DateTime val_7 = System.DateTime.FromBinary(dateData:  System.Int64.Parse(s:  UnityEngine.PlayerPrefs.GetString(key:  "waterfall_started")));
        Player val_8 = App.Player;
        if(((val_7.dateData.CompareTo(value:  new System.DateTime() {dateData = val_8.last_purchase})) & 2147483648) == 0)
        {
            goto label_9;
        }
        
        label_3:
        System.DateTime val_10 = ServerHandler.ServerTime;
        UnityEngine.PlayerPrefs.SetString(key:  "waterfall_started", value:  val_10.dateData.ToBinary().ToString());
        label_9:
        bool val_13 = PrefsSerializationManager.SavePlayerPrefs();
        this.GeneratePackages();
        if(oocFlow != false)
        {
                GameBehavior val_14 = App.getBehavior;
            val_24 = val_14.<metaGameBehavior>k__BackingField;
        }
        else
        {
                GameBehavior val_16 = App.getBehavior;
            val_24 = val_16.<metaGameBehavior>k__BackingField;
        }
        
        this.currentPopup = val_24;
        this.WGStoreProxyAction = storeCloseCallback;
        if(storeCloseCallback != null)
        {
                SLCWindow val_18 = val_24.GetComponent<SLCWindow>();
            System.Action val_19 = null;
            val_23 = val_19;
            val_19 = new System.Action(object:  this, method:  System.Void WGWaterfallSaleManager::<ShowPopup>b__53_0());
            System.Delegate val_20 = System.Delegate.Combine(a:  val_18.Action_OnClose, b:  val_19);
            if(val_20 != null)
        {
                if(null != null)
        {
            goto label_28;
        }
        
        }
        
            val_18.Action_OnClose = val_20;
        }
        
        if(oocFlow != false)
        {
                val_26 = null;
            val_26 = null;
            val_27 = 97;
        }
        else
        {
                val_25 = 1152921504891564032;
            val_26 = null;
            val_26 = null;
        }
        
        PurchaseProxy.currentPurchasePoint = (SceneDictator.IsInGameScene() != true) ? (4 + 1) : 4;
        this.canPurchase = true;
        return;
        label_28:
    }
    public int GetSecondsRemainingForOffer()
    {
        return (int)this.MinutesToDisplay * 60;
    }
    public void BuyWaterfallSpecial()
    {
        if(this.canPurchase == false)
        {
                return;
        }
        
        this.canPurchase = false;
        bool val_1 = PurchaseProxy.Purchase(purchase:  this.purchaseModel);
    }
    public string GetValue()
    {
        if(this.valueModel != null)
        {
                return this.valueModel.LocalPrice;
        }
        
        throw new NullReferenceException();
    }
    public string GetCoins()
    {
        decimal val_1 = this.valueModel.Credits;
        GameEcon val_2 = App.getGameEcon;
        return (string)val_1.flags.ToString(format:  val_2.numberFormatInt);
    }
    public string GetPrice()
    {
        if(this.purchaseModel != null)
        {
                return this.purchaseModel.LocalPrice;
        }
        
        throw new NullReferenceException();
    }
    public WGWaterfallSaleManager()
    {
        this.MinutesToDisplay = 10;
        this.PriceReductionLevels = 8;
        this.canPurchase = true;
        this.PriceReductionInterval = 5;
        this.LevelLock = 10;
        this.packageMapping = new int[8] {7, 6, 5, 0, 1, 2, 3, 4};
    }
    private void <HandlePurchaseSuccess>b__50_0()
    {
        this.WGStoreProxyAction.Invoke(obj:  true);
        this.WGStoreProxyAction = 0;
    }
    private void <ShowPopup>b__53_0()
    {
        this.WGStoreProxyAction.Invoke(obj:  false);
        this.WGStoreProxyAction = 0;
    }

}

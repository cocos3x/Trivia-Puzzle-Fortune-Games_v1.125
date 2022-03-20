using UnityEngine;
public class WGStarterPackController : MonoSingleton<WGStarterPackController>
{
    // Fields
    private const string lastShownKey = "starterPackLastShownAt";
    public const string sawPromptedPopup = "starterPackPrompted";
    private TrackerPurchasePoints _ap;
    private bool setListener;
    public System.Action<bool, System.Decimal> purchaseResult;
    private WGStarterPackStoreItem _prefab_starter_pack_store_item;
    private WGStarterPackStoreItem storeItemInstance;
    
    // Properties
    public static bool featureRelavent { get; }
    public static bool HasSeenExpiredStarterPack { get; }
    public static bool IsInStarterPackDelay { get; }
    public static bool StarterPackActive { get; }
    private static System.DateTime starterPackShownAt { get; }
    public static bool starterPackTimerStarted { get; }
    public static System.DateTime starterPackEndedAt { get; }
    public System.TimeSpan timeRemaining { get; }
    public TrackerPurchasePoints setAccessPoint { set; }
    public TrackerPurchasePoints getAccessPoint { get; }
    private WGStarterPackStoreItem Prefab_starter_pack_store_item { get; }
    
    // Methods
    public static bool get_featureRelavent()
    {
        Player val_1 = App.Player;
        if(val_1.num_purchase < 1)
        {
            goto label_4;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        label_59:
        UnityEngine.Debug.Log(message:  "Not Showing Starter pack because this user is flagged as a purchaser");
        return false;
        label_4:
        GameEcon val_4 = App.getGameEcon;
        if(val_4.starterPackEnabled == false)
        {
            goto label_14;
        }
        
        GameEcon val_6 = App.getGameEcon;
        if(App.Player >= val_6.starterPackLevel)
        {
            goto label_19;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        goto label_59;
        label_14:
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        goto label_59;
        label_19:
        if(WGStarterPackController.starterPackTimerStarted == true)
        {
            goto label_39;
        }
        
        GameEcon val_13 = App.getGameEcon;
        if(App.Player <= val_13.starterPackLevel)
        {
            goto label_39;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        goto label_59;
        label_39:
        if(WGStarterPackController.starterPackTimerStarted == false)
        {
            goto label_52;
        }
        
        System.DateTime val_17 = WGStarterPackController.starterPackShownAt;
        System.DateTime val_18 = DateTimeCheat.UtcNow;
        System.TimeSpan val_19 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_17.dateData}, d2:  new System.DateTime() {dateData = val_18.dateData});
        if(val_19._ticks.TotalMinutes >= 0)
        {
            goto label_52;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        goto label_59;
        label_52:
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        UnityEngine.Debug.Log(message:  "Starter Pack feature relevent, should be showing popup at proper level");
        return false;
    }
    public static bool get_HasSeenExpiredStarterPack()
    {
        ulong val_7;
        var val_8;
        if(WGStarterPackController.starterPackTimerStarted != false)
        {
                System.DateTime val_2 = WGStarterPackController.starterPackShownAt;
            val_7 = val_2.dateData;
            System.DateTime val_3 = DateTimeCheat.UtcNow;
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7}, d2:  new System.DateTime() {dateData = val_3.dateData});
            var val_6 = (val_4._ticks.TotalMinutes < 0) ? 1 : 0;
            return (bool)val_8;
        }
        
        val_8 = 0;
        return (bool)val_8;
    }
    public static bool get_IsInStarterPackDelay()
    {
        ulong val_9;
        var val_10;
        if(WGStarterPackController.starterPackTimerStarted != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            val_9 = val_2.dateData;
            System.DateTime val_3 = WGStarterPackController.starterPackEndedAt;
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_9}, d2:  new System.DateTime() {dateData = val_3.dateData});
            GameEcon val_6 = App.getGameEcon;
            double val_7 = val_6.starterPackWaterfalDelay.TotalMinutes;
            var val_8 = (val_4._ticks.TotalMinutes < 0) ? 1 : 0;
            return (bool)val_10;
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    public static bool get_StarterPackActive()
    {
        System.DateTime val_1 = WGStarterPackController.starterPackShownAt;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = val_2.dateData})) == false)
        {
                return false;
        }
        
        System.DateTime val_4 = WGStarterPackController.starterPackEndedAt;
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = val_5.dateData});
    }
    private static System.DateTime get_starterPackShownAt()
    {
        if((CPlayerPrefs.HasKey(key:  "starterPackLastShownAt")) == false)
        {
                return DateTimeCheat.UtcNow;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "starterPackLastShownAt"), defaultValue:  new System.DateTime() {dateData = val_3.dateData});
    }
    public static bool get_starterPackTimerStarted()
    {
        return CPlayerPrefs.HasKey(key:  "starterPackLastShownAt");
    }
    public static System.DateTime get_starterPackEndedAt()
    {
        if((CPlayerPrefs.HasKey(key:  "starterPackLastShownAt")) != false)
        {
                System.DateTime val_2 = WGStarterPackController.starterPackShownAt;
            GameEcon val_3 = App.getGameEcon;
            System.DateTime val_4 = val_2.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3.starterPackTimeSpan});
            return (System.DateTime)val_5.dateData;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return (System.DateTime)val_5.dateData;
    }
    public System.TimeSpan get_timeRemaining()
    {
        if((CPlayerPrefs.HasKey(key:  "starterPackLastShownAt")) != false)
        {
                System.DateTime val_2 = WGStarterPackController.starterPackShownAt;
            System.DateTime val_3 = DateTimeCheat.UtcNow;
            return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
        }
        
        GameEcon val_4 = App.getGameEcon;
        return (System.TimeSpan)val_4.starterPackTimeSpan;
    }
    public void set_setAccessPoint(TrackerPurchasePoints value)
    {
        this._ap = value;
    }
    public TrackerPurchasePoints get_getAccessPoint()
    {
        return (TrackerPurchasePoints)this._ap;
    }
    private WGStarterPackStoreItem get_Prefab_starter_pack_store_item()
    {
        WGStarterPackStoreItem val_3;
        if(this._prefab_starter_pack_store_item == 0)
        {
                this._prefab_starter_pack_store_item = PrefabLoader.LoadPrefab<WGStarterPackStoreItem>(featureName:  "Store");
            return val_3;
        }
        
        val_3 = this._prefab_starter_pack_store_item;
        return val_3;
    }
    public static void SetTimeShown()
    {
        if((CPlayerPrefs.HasKey(key:  "starterPackLastShownAt")) == true)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        GameEcon val_3 = App.getGameEcon;
        System.DateTime val_4 = val_2.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3.starterPackTimeSpan});
        1152921504874684416 = val_4.dateData.ToString();
        CPlayerPrefs.SetString(key:  "starterPackLastShownAt", val:  1152921504874684416);
        CPlayerPrefs.Save();
    }
    public void TryMakePurchase()
    {
        PurchaseModel val_4;
        var val_5;
        if(WGStarterPackController.featureRelavent != false)
        {
                val_4 = WGStarterPackController.GetStarterPack();
        }
        else
        {
                val_4 = 0;
        }
        
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = this._ap;
        bool val_3 = PurchaseProxy.Purchase(purchase:  val_4);
    }
    public void OnPurchaseSuccess(PurchaseModel purchase)
    {
        if(this.purchaseResult == null)
        {
                return;
        }
        
        decimal val_1 = purchase.Credits;
        this.purchaseResult.Invoke(arg1:  true, arg2:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
    }
    public void OnPurchaseFail()
    {
        var val_1;
        if(this.purchaseResult == null)
        {
                return;
        }
        
        val_1 = null;
        val_1 = null;
        this.purchaseResult.Invoke(arg1:  false, arg2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
    }
    public bool TryShowPopup()
    {
        var val_11;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  "Trying to show starter pack");
        }
        
        val_11 = 0;
        if((CPlayerPrefs.GetInt(key:  "starterPackPrompted", defaultValue:  0)) > 0)
        {
                return (bool)val_11;
        }
        
        if(WGStarterPackController.featureRelavent != false)
        {
                GameEcon val_6 = App.getGameEcon;
            if(App.Player == val_6.starterPackLevel)
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  "Starter pack should be showing");
        }
        
            WGWindowManager val_10 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStarterPackPopup>(showNext:  false);
            val_11 = 1;
            this._ap = 46;
            return (bool)val_11;
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    public override void InitMonoSingleton()
    {
        var val_15;
        var val_16;
        GameEcon val_2 = App.getGameEcon;
        if((App.Player == val_2.starterPackLevel) && (WGStarterPackController.starterPackTimerStarted != true))
        {
                GameBehavior val_4 = App.getBehavior;
            if((val_4.<metaGameBehavior>k__BackingField) == 2)
        {
                WGStarterPackController.SetTimeShown();
        }
        
        }
        
        this.InitMonoSingleton();
        val_15 = null;
        val_15 = null;
        System.Delegate val_6 = System.Delegate.Combine(a:  GameStoreUI.OnCreatePackItems, b:  new System.Action(object:  this, method:  System.Void WGStarterPackController::Store_OnCreatePackItems()));
        if(val_6 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        GameStoreUI.OnCreatePackItems = val_6;
        System.Delegate val_8 = System.Delegate.Combine(a:  GameStoreUI.OnRefreshDisplay, b:  new System.Action(object:  this, method:  System.Void WGStarterPackController::Store_OnRefreshDisplay()));
        if(val_8 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_8;
        val_16 = null;
        val_16 = null;
        System.Delegate val_10 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGStarterPackController::PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_10 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_10;
        System.Delegate val_12 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStarterPackController::PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)));
        if(val_12 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_12;
        System.Delegate val_14 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGStarterPackController::PurchasesHandler_OnPurchaseFailure(PurchaseModel purchase)));
        if(val_14 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_14;
    }
    private void Store_OnRefreshDisplay()
    {
        var val_30;
        UnityEngine.Object val_31;
        UnityEngine.Object val_32;
        WGStarterPackStoreItem val_33;
        val_30 = this;
        if(WGStarterPackController.featureRelavent != true)
        {
                val_31 = this.storeItemInstance;
            if(val_31 != 0)
        {
                GameStoreCategory val_5 = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
            val_32 = this.storeItemInstance.gameObject;
            UnityEngine.Object.Destroy(obj:  val_32);
            this.storeItemInstance = 0;
            if(val_5.XfmPackageContents.childCount > 0)
        {
                return;
        }
        
            UnityEngine.Object.Destroy(obj:  val_5.gameObject);
            return;
        }
        
        }
        
        if(WGStarterPackController.featureRelavent == false)
        {
                return;
        }
        
        if(WGStarterPackController.GetStarterPack() == null)
        {
                return;
        }
        
        val_33 = this.storeItemInstance;
        if(val_33 == 0)
        {
                val_33 = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
            WGStarterPackStoreItem val_18 = UnityEngine.Object.Instantiate<WGStarterPackStoreItem>(original:  this.Prefab_starter_pack_store_item, parent:  val_33.XfmPackageContents);
            this.storeItemInstance = val_18;
            val_18.transform.SetSiblingIndex(index:  val_33.GetFirstAvailableSiblingIndex());
        }
        
        this.storeItemInstance.gameObject.SetActive(value:  true);
        GameStoreUI val_22 = MonoSingleton<GameStoreUI>.Instance;
        val_30 = ???;
        val_32 = ???;
        goto typeof(WGStarterPackStoreItem).__il2cppRuntimeField_1A0;
    }
    private void Store_OnCreatePackItems()
    {
        if(WGStarterPackController.featureRelavent == false)
        {
                return;
        }
        
        if(WGStarterPackController.GetStarterPack() == null)
        {
                return;
        }
        
        GameStoreCategory val_5 = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
        WGStarterPackStoreItem val_8 = UnityEngine.Object.Instantiate<WGStarterPackStoreItem>(original:  this.Prefab_starter_pack_store_item, parent:  val_5.XfmPackageContents);
        this.storeItemInstance = val_8;
        val_8.transform.SetSiblingIndex(index:  val_5.GetFirstAvailableSiblingIndex());
        GameStoreUI val_11 = MonoSingleton<GameStoreUI>.Instance;
        this = ???;
        goto typeof(WGStarterPackStoreItem).__il2cppRuntimeField_1A0;
    }
    private PurchaseModel Store_DetermineStarterPack()
    {
        if(WGStarterPackController.featureRelavent == false)
        {
                return 0;
        }
        
        return WGStarterPackController.GetStarterPack();
    }
    public static PurchaseModel GetStarterPack()
    {
        var val_8;
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  "id_starter_pack");
        PurchaseModel val_2 = new PurchaseModel(json:  val_1);
        twelvegigs.storage.JsonDictionary val_4 = PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  ""));
        val_8 = null;
        val_8 = null;
        decimal val_5 = val_4.getDecimal(key:  "credits", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        val_2.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        .sale_price = val_1.getFloat(key:  "sale_price", defaultValue:  0f);
        .targetSalePrice = val_4.getFloat(key:  "sale_price", defaultValue:  1f);
        return val_2;
    }
    private void PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    private void PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)
    {
        if((purchased.id.Contains(value:  "starter_pack")) == false)
        {
                return;
        }
        
        this.OnPurchaseSuccess(purchase:  purchased);
    }
    private void PurchasesHandler_OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "starter_pack")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail();
    }
    public WGStarterPackController()
    {
    
    }

}

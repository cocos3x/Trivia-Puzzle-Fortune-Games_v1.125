using UnityEngine;
public class WGFOMOPackController : MonoSingleton<WGFOMOPackController>
{
    // Fields
    private const string lastShownKey = "FOMOPackLastShownAt";
    private TrackerPurchasePoints _ap;
    public System.Action<bool, System.Decimal> purchaseResult;
    private PurchaseModel purchaseModel;
    private PurchaseModel valueModel;
    
    // Properties
    public static bool featureRelavent { get; }
    private static System.DateTime FOMOPackShownAt { get; }
    public static bool FOMOPackTimerStarted { get; }
    public static System.DateTime FOMOPackEndedAt { get; }
    public System.TimeSpan timeRemaining { get; }
    public TrackerPurchasePoints setAccessPoint { set; }
    public TrackerPurchasePoints getAccessPoint { get; }
    public int showedLevel { get; set; }
    
    // Methods
    public static bool get_featureRelavent()
    {
        decimal val_24;
        object val_25;
        Player val_1 = App.Player;
        if(val_1.num_purchase >= 1)
        {
                if(WGFOMOPackController.FOMOPackTimerStarted == false)
        {
            goto label_5;
        }
        
        }
        
        val_24 = App.Player;
        GameEcon val_4 = App.getGameEcon;
        if(val_24 >= val_4.FOMOPackUnlockedLevel)
        {
            goto label_10;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        val_25 = "Not Showing FOMO pack because the user is too low level";
        goto label_50;
        label_10:
        Player val_7 = App.Player;
        val_24 = val_7._credits;
        GameEcon val_9 = App.getGameEcon + 1060;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_24, hi = val_24, lo = 1152921504884269056}, d2:  new System.Decimal() {flags = val_8.FOMOMaxBalance.flags, hi = val_8.FOMOMaxBalance.flags, lo = 366026752, mid = 268435456})) == false)
        {
            goto label_24;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        val_25 = "Not Showing FOMO pack because the user is not too low credits";
        goto label_50;
        label_5:
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        val_25 = "Not Showing FOMO pack because this user is flagged as a purchaser";
        label_50:
        UnityEngine.Debug.Log(message:  val_25);
        return false;
        label_24:
        if(WGFOMOPackController.FOMOPackTimerStarted == false)
        {
            goto label_43;
        }
        
        System.DateTime val_16 = WGFOMOPackController.FOMOPackEndedAt;
        System.DateTime val_17 = DateTimeCheat.UtcNow;
        System.TimeSpan val_18 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_16.dateData}, d2:  new System.DateTime() {dateData = val_17.dateData});
        if(val_18._ticks.TotalMinutes >= 0)
        {
            goto label_43;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        goto label_50;
        label_43:
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return false;
        }
        
        UnityEngine.Debug.Log(message:  "FOMO Pack feature relevent, should be showing popup at proper level");
        return false;
    }
    private static System.DateTime get_FOMOPackShownAt()
    {
        if((CPlayerPrefs.HasKey(key:  "FOMOPackLastShownAt")) == false)
        {
                return DateTimeCheat.UtcNow;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        return SLCDateTime.Parse(dateTime:  CPlayerPrefs.GetString(key:  "FOMOPackLastShownAt"), defaultValue:  new System.DateTime() {dateData = val_3.dateData});
    }
    public static bool get_FOMOPackTimerStarted()
    {
        return CPlayerPrefs.HasKey(key:  "FOMOPackLastShownAt");
    }
    public static System.DateTime get_FOMOPackEndedAt()
    {
        if((CPlayerPrefs.HasKey(key:  "FOMOPackLastShownAt")) != false)
        {
                System.DateTime val_2 = WGFOMOPackController.FOMOPackShownAt;
            GameEcon val_3 = App.getGameEcon;
            System.DateTime val_4 = val_2.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3.FOMOPackTimeSpan});
            return (System.DateTime)val_5.dateData;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return (System.DateTime)val_5.dateData;
    }
    public System.TimeSpan get_timeRemaining()
    {
        if((CPlayerPrefs.HasKey(key:  "FOMOPackLastShownAt")) != false)
        {
                System.DateTime val_2 = WGFOMOPackController.FOMOPackShownAt;
            System.DateTime val_3 = DateTimeCheat.UtcNow;
            return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
        }
        
        GameEcon val_4 = App.getGameEcon;
        return (System.TimeSpan)val_4.FOMOPackTimeSpan;
    }
    public void set_setAccessPoint(TrackerPurchasePoints value)
    {
        this._ap = value;
    }
    public TrackerPurchasePoints get_getAccessPoint()
    {
        return (TrackerPurchasePoints)this._ap;
    }
    public int get_showedLevel()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "FOMO_ShowedLevel", defaultValue:  0);
    }
    public void set_showedLevel(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "FOMO_ShowedLevel", value:  value);
    }
    public static void SetTimeShown()
    {
        if((CPlayerPrefs.HasKey(key:  "FOMOPackLastShownAt")) == true)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        GameEcon val_3 = App.getGameEcon;
        System.DateTime val_4 = val_2.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3.FOMOPackTimeSpan});
        1152921504874684416 = val_4.dateData.ToString();
        CPlayerPrefs.SetString(key:  "FOMOPackLastShownAt", val:  1152921504874684416);
        CPlayerPrefs.Save();
    }
    public void TryMakePurchase()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = this._ap;
        bool val_1 = PurchaseProxy.Purchase(purchase:  this.purchaseModel);
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
        object val_9;
        var val_10;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_9 = "Trying to show FOFO pack";
            UnityEngine.Debug.Log(message:  val_9);
        }
        
        if(WGFOMOPackController.featureRelavent != false)
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.Log(message:  "FOMO pack should be showing");
        }
        
            this.GeneratePackages();
            WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFOMOSalePopup>(showNext:  false);
            this._ap = 128;
            Player val_8 = App.Player;
            val_8.showedLevel = val_8;
            val_10 = 1;
            return (bool)val_10;
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    public override void InitMonoSingleton()
    {
        var val_11;
        GameEcon val_2 = App.getGameEcon;
        if((App.Player == val_2.FOMOPackUnlockedLevel) && (WGFOMOPackController.FOMOPackTimerStarted != true))
        {
                GameBehavior val_4 = App.getBehavior;
            if((val_4.<metaGameBehavior>k__BackingField) == 2)
        {
                WGFOMOPackController.SetTimeShown();
        }
        
        }
        
        this.InitMonoSingleton();
        val_11 = null;
        val_11 = null;
        System.Delegate val_6 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void WGFOMOPackController::PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_6;
        System.Delegate val_8 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGFOMOPackController::PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_8;
        System.Delegate val_10 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void WGFOMOPackController::PurchasesHandler_OnPurchaseFailure(PurchaseModel purchase)));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_10;
        return;
        label_19:
    }
    private void GeneratePackages()
    {
        var val_11;
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  "id_fomo_pack");
        this.purchaseModel = new PurchaseModel(json:  val_1);
        twelvegigs.storage.JsonDictionary val_4 = PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  ""));
        val_11 = null;
        val_11 = null;
        decimal val_5 = val_4.getDecimal(key:  "credits", defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.purchaseModel.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
        this.purchaseModel.sale_price = val_1.getFloat(key:  "sale_price", defaultValue:  0f);
        this.purchaseModel.targetSalePrice = val_4.getFloat(key:  "sale_price", defaultValue:  1f);
        this.valueModel = new PurchaseModel(json:  PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  "")));
    }
    private void PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    private void PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)
    {
        if((purchased.id.Contains(value:  "fomo_pack")) == false)
        {
                return;
        }
        
        this.OnPurchaseSuccess(purchase:  purchased);
    }
    private void PurchasesHandler_OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "fomo_pack")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail();
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
    public WGFOMOPackController()
    {
    
    }

}

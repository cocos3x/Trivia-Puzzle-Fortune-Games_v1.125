using UnityEngine;
public class FOMOPackEventHandler : WGEventHandler
{
    // Fields
    public const string FOMO_PACK_EVENT_ID = "FOMO pack";
    public const string EVENT_TRACKING_ID = "FOMO pack";
    private static FOMOPackEventHandler <Instance>k__BackingField;
    private FOMOPackProgress progressData;
    private TrackerPurchasePoints <AccessPoint>k__BackingField;
    public System.Action<bool, System.Decimal> purchaseResult;
    private PurchaseModel purchaseModel;
    protected bool isEventInitialized;
    
    // Properties
    public static bool IsEventActive { get; }
    public static FOMOPackEventHandler Instance { get; set; }
    public FOMOPackProgress ProgressData { get; }
    private int PlayerLevel { get; }
    public TrackerPurchasePoints AccessPoint { get; set; }
    public override bool IsEventHidden { get; }
    public override int UnlockLevel { get; }
    public System.DateTime PackShownAt { get; }
    public bool PackTimerStarted { get; }
    public System.DateTime PackEndedAt { get; }
    public System.TimeSpan timeRemaining { get; }
    public int ShowedLevel { get; set; }
    public string GetAmount { get; }
    public string GetPrice { get; }
    public bool AvailableShow { get; }
    public bool CanLevelShow { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((FOMOPackEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)FOMOPackEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(FOMOPackEventHandler).__il2cppRuntimeField_4A0;
    }
    public static FOMOPackEventHandler get_Instance()
    {
        return (FOMOPackEventHandler)FOMOPackEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(FOMOPackEventHandler value)
    {
        FOMOPackEventHandler.<Instance>k__BackingField = value;
    }
    public FOMOPackProgress get_ProgressData()
    {
        return (FOMOPackProgress)this.progressData;
    }
    private int get_PlayerLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_360;
    }
    public TrackerPurchasePoints get_AccessPoint()
    {
        return (TrackerPurchasePoints)this.<AccessPoint>k__BackingField;
    }
    public void set_AccessPoint(TrackerPurchasePoints value)
    {
        this.<AccessPoint>k__BackingField = value;
    }
    public override bool get_IsEventHidden()
    {
        return true;
    }
    public override int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.FOMOPackUnlockedLevel;
    }
    public System.DateTime get_PackShownAt()
    {
        if((System.String.IsNullOrEmpty(value:  this.progressData.LastShownAt)) != false)
        {
                return DateTimeCheat.UtcNow;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        return SLCDateTime.Parse(dateTime:  this.progressData.LastShownAt, defaultValue:  new System.DateTime() {dateData = val_2.dateData});
    }
    public bool get_PackTimerStarted()
    {
        bool val_1 = System.String.IsNullOrEmpty(value:  this.progressData.LastShownAt);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public System.DateTime get_PackEndedAt()
    {
        if(this.PackTimerStarted != false)
        {
                System.DateTime val_2 = this.PackShownAt;
            GameEcon val_3 = App.getGameEcon;
            System.DateTime val_4 = val_2.dateData.Add(value:  new System.TimeSpan() {_ticks = val_3.FOMOPackTimeSpan});
            return (System.DateTime)val_5.dateData;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return (System.DateTime)val_5.dateData;
    }
    public System.TimeSpan get_timeRemaining()
    {
        if(this.PackTimerStarted != false)
        {
                System.DateTime val_2 = this.PackEndedAt;
            System.DateTime val_3 = DateTimeCheat.UtcNow;
            return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
        }
        
        GameEcon val_4 = App.getGameEcon;
        return (System.TimeSpan)val_4.FOMOPackTimeSpan;
    }
    public int get_ShowedLevel()
    {
        if(this.progressData != null)
        {
                return (int)this.progressData.ShowedLevel;
        }
        
        throw new NullReferenceException();
    }
    public void set_ShowedLevel(int value)
    {
        this.progressData.ShowedLevel = value;
        goto typeof(FOMOPackProgress).__il2cppRuntimeField_180;
    }
    public string get_GetAmount()
    {
        GameBehavior val_1 = App.getBehavior;
        decimal val_2 = this.purchaseModel.GetReward(rewardType:  val_1.<metaGameBehavior>k__BackingField);
        GameEcon val_3 = App.getGameEcon;
        return (string)val_2.flags.ToString(format:  val_3.numberFormatInt);
    }
    public string get_GetPrice()
    {
        if(this.purchaseModel != null)
        {
                return this.purchaseModel.LocalPrice;
        }
        
        throw new NullReferenceException();
    }
    public bool get_AvailableShow()
    {
        var val_1;
        if((this & 1) != 0)
        {
                val_1 = 1152921516237848545;
            return (bool)val_1 & 1;
        }
        
        val_1 = 0;
        return (bool)val_1 & 1;
    }
    public bool get_CanLevelShow()
    {
        GameEcon val_2 = App.getGameEcon;
        return (bool)((App.Player - this.progressData.ShowedLevel) >= val_2.FOMOLevelInterval) ? 1 : 0;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516238101232] = eventV2;
        FOMOPackEventHandler.<Instance>k__BackingField = this;
        this.SetupEvent();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "FOMO pack")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override bool get_IsEventValid()
    {
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -1253390880)) == false)
        {
                return false;
        }
        
        GameBehavior val_3 = App.getBehavior;
        GameEcon val_5 = App.getGameEcon + 1060;
        return System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_3.<metaGameBehavior>k__BackingField, hi = val_3.<metaGameBehavior>k__BackingField, lo = typeof(MetaGameBehavior).__il2cppRuntimeField_388, mid = typeof(MetaGameBehavior).__il2cppRuntimeField_388}, d2:  new System.Decimal() {flags = val_4.FOMOMaxBalance.flags, hi = val_4.FOMOMaxBalance.flags, lo = 366026752, mid = 268435456});
    }
    public override bool EventCompleted()
    {
        var val_8;
        if(this.PackTimerStarted != false)
        {
                System.TimeSpan val_2 = this.timeRemaining;
            if((val_2._ticks.Seconds >> 31) != 0)
        {
                val_8 = 1;
            return (bool)val_8 & 1;
        }
        
        }
        
        Player val_5 = App.Player;
        if(val_5.num_purchase >= 1)
        {
                val_8 = this.PackTimerStarted ^ 1;
            return (bool)val_8 & 1;
        }
        
        val_8 = 0;
        return (bool)val_8 & 1;
    }
    public override string GetHackPanelEventData()
    {
        bool val_32;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_3 = val_1.AppendLine(value:  System.String.Format(format:  "unlock level {0}", arg0:  this));
        GameBehavior val_4 = App.getBehavior;
        System.Text.StringBuilder val_6 = val_1.AppendLine(value:  System.String.Format(format:  "player currency {0}", arg0:  val_4.<metaGameBehavior>k__BackingField));
        GameEcon val_8 = App.getGameEcon + 1060;
        System.Text.StringBuilder val_10 = val_1.AppendLine(value:  System.String.Format(format:  "max currency {0}", arg0:  val_7.FOMOMaxBalance.flags));
        System.Text.StringBuilder val_12 = val_1.AppendLine(value:  System.String.Format(format:  "therefore valid? {0}\n\n", arg0:  0));
        System.Text.StringBuilder val_16 = val_1.AppendLine(value:  System.String.Format(format:  "timer started? {0}", arg0:  this.PackTimerStarted));
        System.TimeSpan val_17 = this.timeRemaining;
        System.Text.StringBuilder val_20 = val_1.AppendLine(value:  System.String.Format(format:  "remaining seconds {0}", arg0:  val_17._ticks.Seconds));
        Player val_21 = App.Player;
        System.Text.StringBuilder val_23 = val_1.AppendLine(value:  System.String.Format(format:  "player purhcases {0}", arg0:  val_21.num_purchase));
        System.Text.StringBuilder val_25 = val_1.AppendLine(value:  System.String.Format(format:  "therefore completed? {0}\n\n", arg0:  0));
        if((MonoSingleton<WGStarterPackController>.Instance) != 0)
        {
                val_32 = WGStarterPackController.StarterPackActive;
        }
        else
        {
                val_32 = false;
        }
        
        System.Text.StringBuilder val_30 = val_1.AppendLine(value:  System.String.Format(format:  "blocked by starterpack? {0}\n\n", arg0:  val_32));
        return (string)val_1;
    }
    public void SetupSomeStuffFromFeature(string whateverFeatureInfo = "")
    {
    
    }
    private void SetupEvent()
    {
        var val_9;
        if(this.isEventInitialized != true)
        {
                val_9 = null;
            val_9 = null;
            System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void FOMOPackEventHandler::PurchasesHandler_OnProcessPurchase(ref PurchaseModel purchase)));
            if(val_2 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_2;
            System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void FOMOPackEventHandler::PurchasesHandler_OnPurchaseCompleted(PurchaseModel purchased)));
            if(val_4 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            PurchasesHandler.OnPurchaseCompleted = val_4;
            System.Delegate val_6 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void FOMOPackEventHandler::PurchasesHandler_OnPurchaseFailure(PurchaseModel purchase)));
            if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
            PurchasesHandler.OnPurchaseFailure = val_6;
        }
        
        if((this & 1) != 0)
        {
                if(this.IsCurrentEventInCycle() != true)
        {
                this.progressData = new FOMOPackProgress();
        }
        
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        this.progressData.eventId = typeof(FOMOPackEventHandler).__il2cppRuntimeField_38;
        this.isEventInitialized = true;
        return;
        label_10:
    }
    public void SetTimeShown()
    {
        if(this.PackTimerStarted == true)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        this.progressData.LastShownAt = val_2.dateData.ToString();
    }
    public void TryMakePurchase()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = this.<AccessPoint>k__BackingField;
        bool val_1 = PurchaseProxy.Purchase(purchase:  this.purchaseModel);
    }
    public void OnPurchaseSuccess(PurchaseModel purchase)
    {
        if(this.purchaseResult == null)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        decimal val_2 = purchase.GetReward(rewardType:  val_1.<metaGameBehavior>k__BackingField);
        this.purchaseResult.Invoke(arg1:  true, arg2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
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
    public void SetShowedLevel()
    {
        this.ShowedLevel = App.Player;
    }
    public bool TryShowPopup(bool isOOC = False)
    {
        if((this & 1) == 0)
        {
                return false;
        }
        
        if((this & 1) != 0)
        {
                return false;
        }
        
        if((MonoSingleton<WGStarterPackController>.Instance) != 0)
        {
                if(WGStarterPackController.StarterPackActive == true)
        {
                return false;
        }
        
        }
        
        this.GeneratePackages();
        GameBehavior val_4 = App.getBehavior;
        val_4.<metaGameBehavior>k__BackingField.Setup(outOfCurrency:  isOOC);
        this.<AccessPoint>k__BackingField = 128;
        return false;
    }
    private void GeneratePackages()
    {
        var val_10;
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageById(packageId:  "id_fomo_pack");
        this.purchaseModel = new PurchaseModel(json:  val_1);
        twelvegigs.storage.JsonDictionary val_4 = PackagesManager.GetPackageById(packageId:  val_1.getString(key:  "credit_package", defaultValue:  ""));
        GameBehavior val_5 = App.getBehavior;
        GameBehavior val_6 = App.getBehavior;
        val_10 = null;
        val_10 = null;
        decimal val_7 = val_4.getDecimal(key:  val_6.<metaGameBehavior>k__BackingField, defaultValue:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.purchaseModel.AddReward(rewardType:  val_5.<metaGameBehavior>k__BackingField, amount:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
        this.purchaseModel.sale_price = val_1.getFloat(key:  "sale_price", defaultValue:  0f);
        this.purchaseModel.targetSalePrice = val_4.getFloat(key:  "sale_price", defaultValue:  1f);
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
    private bool IsCurrentEventInCycle()
    {
        return (bool)(this.progressData.eventId == (X9 + 56)) ? 1 : 0;
    }
    public FOMOPackEventHandler()
    {
        this.progressData = new FOMOPackProgress();
    }

}

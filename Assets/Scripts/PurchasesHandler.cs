using UnityEngine;
public class PurchasesHandler : DefaultHandler<PurchasesHandler>
{
    // Fields
    public static PostProcessPurchaseDelegate OnProcessPurchase;
    public static System.Action<PurchaseModel> OnPurchaseCompleted;
    public static System.Action<PurchaseModel> OnPurchaseFailure;
    private const string ON_RESTORE_TRANSACTIONS_SUCCESS = "OnRestoreTransactionsSuccess";
    private static bool initialized;
    
    // Methods
    private void OnPurchaseComplete(NativePurchase purchaseInfo)
    {
        object val_25;
        string val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        int val_32;
        PurchaseModel val_33;
        var val_34;
        string val_35;
        var val_36;
        var val_37;
        var val_38;
        System.Action<PurchaseModel> val_39;
        val_25 = purchaseInfo;
        SLCDebug.Log(logMessage:  System.String.Format(format:  "PurchasesHandler.OnPurchaseComplete :: {0}", arg0:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_25, formatting:  1)), colorHash:  "#5452EA", isError:  false);
        AppConfigs val_3 = App.Configuration;
        val_26 = val_3.storeConfig.GetId(sku:  purchaseInfo.sku);
        val_27 = null;
        val_27 = null;
        if(null == 0)
        {
            goto label_14;
        }
        
        label_129:
        if((PurchasesHandler.DeterminePackageType(packageId:  val_26)) == false)
        {
                return;
        }
        
        if(null == 0)
        {
                SLCDebug.Log(logMessage:  "PurchasesHandler.OnPurchaseComplete :: taking care of malformed purchase", colorHash:  "#FF0000", isError:  false);
            PurchaseModel val_6 = new PurchaseModel();
            .<Sku>k__BackingField = purchaseInfo.sku;
            .id = val_26;
            val_6.AddInstruction(instruction:  0);
            val_28 = null;
            val_28 = null;
            PurchaseProxy.currentPurchasePoint = 0;
            val_26 = val_6;
            if((PackagesManager.IsNonConsumable(purchase:  val_6)) != true)
        {
                this.PurchasedCredits(currentPurchase: ref  val_6);
        }
        
            UnityEngine.Debug.LogError(message:  "PurchasesHandler: currentPurchase was null and was not recovered, attempting reconstruction");
        }
        
        val_29 = null;
        val_29 = null;
        if((App.inAppPurchasesManager.IsCashedIn(token:  purchaseInfo.token)) == false)
        {
            goto label_38;
        }
        
        val_30 = null;
        val_30 = null;
        if((App.inAppPurchasesManager.IsTracked(token:  purchaseInfo.token)) == true)
        {
                return;
        }
        
        DefaultHandler<TrackingHandler>.Instance.ProcessPurchase(currentPurchase:  val_6, purchaseInfo:  val_25);
        return;
        label_14:
        val_31 = null;
        val_31 = null;
        if(App.inAppPurchasesManager.DeserializeCurrentPurchaseFromPrefs() == null)
        {
            goto label_56;
        }
        
        if((System.String.op_Inequality(a:  val_11.id, b:  val_26)) == false)
        {
            goto label_57;
        }
        
        string[] val_13 = new string[5];
        val_32 = val_13.Length;
        val_13[0] = "PurchasesHandler.OnPurchaseComplete :: currentPurchase.InternalId (";
        if((val_11 + 24) != 0)
        {
                val_32 = val_13.Length;
        }
        
        val_13[1] = val_11 + 24;
        val_32 = val_13.Length;
        val_13[2] = ") != packagePurchased (";
        if(val_26 != null)
        {
                val_32 = val_13.Length;
        }
        
        val_13[3] = val_26;
        val_32 = val_13.Length;
        val_13[4] = ")";
        SLCDebug.Log(logMessage:  +val_13, colorHash:  "#E77155", isError:  false);
        PurchaseModel val_17 = 0;
        goto label_129;
        label_38:
        val_33 = val_17;
        Player val_15 = App.Player;
        mem[496] = val_15.total_purchased;
        Player val_16 = App.Player;
        mem[500] = val_16._credits;
        val_34 = null;
        val_34 = null;
        val_35 = PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS;
        if(val_35 != null)
        {
                val_35 = PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS;
            val_35.Invoke(purchase: ref  val_17);
            val_33 = val_17;
        }
        
        this.RewardPlayerPurchase(purchase:  val_33);
        this.RegisterPurchase(purchase: ref  val_17);
        DefaultHandler<TrackingHandler>.Instance.ProcessPurchase(currentPurchase:  val_17, purchaseInfo:  val_25);
        this.Player.SaveState();
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
        val_36 = null;
        val_36 = null;
        App.inAppPurchasesManager.ClearPurchaseFromPrefs();
        val_37 = null;
        val_37 = null;
        App.inAppPurchasesManager.AddCashedIn(token:  purchaseInfo.token);
        AdsManager.HandlePurchase();
        val_26 = 1152921513404137360;
        val_25 = MonoSingleton<AdsUIController>.Instance;
        if(val_25 != 0)
        {
                MonoSingleton<AdsUIController>.Instance.HandlePurchase();
        }
        
        val_38 = null;
        val_38 = null;
        val_39 = PurchasesHandler.OnPurchaseCompleted;
        if(val_39 == null)
        {
                return;
        }
        
        val_39 = PurchasesHandler.OnPurchaseCompleted;
        val_39.Invoke(obj:  val_17);
        return;
        label_56:
        SLCDebug.Log(logMessage:  "PurchasesHandler.OnPurchasecoplete :: attempt to recover unresolved purchase "("PurchasesHandler.OnPurchasecoplete :: attempt to recover unresolved purchase ") + val_26 + " failed - couldn\'t deserialize the last saved purchase."(" failed - couldn\'t deserialize the last saved purchase."), colorHash:  "#FFFF00", isError:  false);
        goto label_129;
        label_57:
        SLCDebug.Log(logMessage:  "PurchasesHandler.OnPurchaseComplete :: recoveryPurchase = true but doing nothing with this info", colorHash:  "#AEF90E", isError:  false);
        goto label_129;
    }
    private void OnPurchaseFailed(NativePurchase purchase)
    {
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        System.Action<PurchaseModel> val_11;
        val_7 = purchase;
        val_8 = this;
        val_9 = null;
        val_9 = null;
        if(val_7 == null)
        {
                return;
        }
        
        if(null == 0)
        {
                return;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = System.String.Format(format:  "Failed purchase: {0} Original Error Message: {1}", arg0:  purchase.errorCode.ToString(), arg1:  purchase.errorString);
        D.LogClientError(developer:  "NA", filter:  "default", context:  this.gameObject, strings:  val_2);
        val_8 = DefaultHandler<TrackingHandler>.Instance;
        val_8.TrackPurchaseFailed(model:  App.inAppPurchasesManager.currentPurchase, errorCode:  purchase.errorCode.ToString(), errorRaw:  purchase.errorString, errorString:  purchase.token);
        val_7 = 1152921504890499072;
        val_10 = null;
        val_10 = null;
        val_11 = PurchasesHandler.OnPurchaseFailure;
        if(val_11 == null)
        {
                return;
        }
        
        val_11 = PurchasesHandler.OnPurchaseFailure;
        val_11.Invoke(obj:  App.inAppPurchasesManager.currentPurchase);
    }
    public static bool DeterminePackageType(string packageId)
    {
        var val_3;
        if((packageId.Contains(value:  "golden_ticket")) != false)
        {
                val_3 = 0;
            return (bool)val_3;
        }
        
        val_3 = (~(packageId.Contains(value:  "silver_ticket"))) & 1;
        return (bool)val_3;
    }
    private void RegisterPurchase(ref PurchaseModel purchase)
    {
        bool val_30;
        Player val_1 = this.Player;
        Player val_2 = this.Player;
        if(val_2.lastPurchasePrice < 0)
        {
                Player val_3 = this.Player;
            val_3.max_item_purchased = purchase.id;
        }
        
        Player val_4 = this.Player;
        val_4.last_item_purchased = purchase.id;
        Player val_5 = this.Player;
        val_5.lastItemPrice = purchase.sale_price;
        Player val_6 = this.Player;
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        val_6.last_purchase = val_7;
        Player val_8 = this.Player;
        float val_29 = val_8.total_purchased;
        val_29 = val_29 + purchase.sale_price;
        val_8.total_purchased = val_29;
        Player val_9 = this.Player;
        float val_30 = purchase.sale_price;
        int val_31 = val_9.totalRevenue;
        val_30 = val_30 * 100f;
        val_30 = (val_30 == Infinityf) ? (-(double)val_30) : ((double)val_30);
        val_31 = val_31 + (int)val_30;
        val_9.totalRevenue = val_31;
        Player val_10 = this.Player;
        Player val_11 = this.Player;
        if(val_10.transactionsAverageAmount == 0f)
        {
                val_11.transactionsAverageAmount = purchase.sale_price;
        }
        else
        {
                Player val_12 = this.Player;
            Player val_13 = this.Player;
            Player val_14 = this.Player;
            int val_33 = val_14.num_purchase;
            float val_32 = (float)val_13.num_purchase;
            val_32 = val_12.transactionsAverageAmount * val_32;
            val_32 = val_32 + purchase.sale_price;
            val_33 = val_33 + 1;
            val_32 = val_32 / (float)val_33;
            val_11.transactionsAverageAmount = val_32;
        }
        
        Player val_15 = this.Player;
        int val_34 = val_15.num_purchase;
        val_34 = val_34 + 1;
        val_15.num_purchase = val_34;
        Player val_16 = this.Player;
        Player val_17 = this.Player;
        val_16.lastPurchasePrice = System.Math.Max(val1:  val_17.lastPurchasePrice, val2:  purchase.sale_price);
        Player val_20 = this.Player;
        if((System.String.IsNullOrEmpty(value:  val_1.max_item_purchased)) == false)
        {
            goto label_35;
        }
        
        val_30 = 1;
        goto label_36;
        label_35:
        if((System.String.op_Inequality(a:  val_1.max_item_purchased, b:  val_20.max_item_purchased)) == false)
        {
            goto label_37;
        }
        
        Player val_22 = this.Player;
        val_30 = false;
        label_36:
        val_22.samePurchases = val_30;
        label_37:
        GameEcon val_23 = App.getGameEcon;
        if(val_23.extraReqPostPurchaseLvl != 1)
        {
                GameBehavior val_24 = App.getBehavior;
            GameEcon val_25 = App.getGameEcon;
            if((val_24.<metaGameBehavior>k__BackingField) >= val_25.extraReqPostPurchaseLvl)
        {
                Player val_26 = this.Player;
            val_26.properties.LevelsPlayedPostPurchase = 0;
        }
        
        }
        
        GameBehavior val_27 = App.getBehavior;
        if(((val_27.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        this.Player.RemovedAds = true;
    }
    private void PurchasedCredits(ref PurchaseModel currentPurchase)
    {
        twelvegigs.storage.JsonDictionary val_1 = this.GetPackage(id:  currentPurchase.id);
        decimal val_2 = this.GetTotalAmountByPackage(packageDictionary:  val_1, packageType:  "credits");
        currentPurchase.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
        sale_price = val_1.getFloat(key:  "sale_price", defaultValue:  1f);
        price = val_1.getString(key:  "regular_price", defaultValue:  currentPurchase.sale_price.ToString());
    }
    protected override void AwakeLogic()
    {
        this.AwakeLogic();
        this.Initialize();
    }
    private void Initialize()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        val_3 = null;
        if(PurchasesHandler.initialized == true)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        App.inAppPurchasesManager.addPurchaseListener(successCallback:  new System.Action<NativePurchase>(object:  this, method:  System.Void PurchasesHandler::OnPurchaseComplete(NativePurchase purchaseInfo)), errorCallback:  new System.Action<NativePurchase>(object:  this, method:  System.Void PurchasesHandler::OnPurchaseFailed(NativePurchase purchase)));
        val_5 = null;
        val_5 = null;
        PurchasesHandler.initialized = true;
    }
    public PurchasesHandler()
    {
    
    }
    private static PurchasesHandler()
    {
    
    }

}

using UnityEngine;
public class GooglePurchasesBridge : PurchasesBridge, PluginObserver
{
    // Fields
    private const int PURCHASE_DAYS_LIMIT = 4;
    private bool initialized;
    private string key;
    private string[] currentSKUs;
    private System.Collections.Generic.Queue<SLC.Billing.GooglePurchase> pendingPurchases;
    private static bool trustUser;
    private NativePurchase cachedPurchase;
    
    // Properties
    public static bool TrustUser { get; set; }
    
    // Methods
    public PluginObserverManager.ObserverType getType()
    {
        return 3;
    }
    public string pluginName()
    {
        return "Google Play Store";
    }
    public string errorMessage()
    {
        var val_2;
        if(this.initialized != false)
        {
                var val_1 = ((this.initialized + 24) == 0) ? "Failed to query the inventory, service not working." : "Bridge working correctly.";
            return (string)val_2;
        }
        
        val_2 = "Not initialized!";
        return (string)val_2;
    }
    public bool isWorking()
    {
        if(X8 != 0)
        {
                return (bool)X8 + 24;
        }
        
        throw new NullReferenceException();
    }
    public bool isInitialized()
    {
        return (bool)this.initialized;
    }
    public static bool get_TrustUser()
    {
        null = null;
        return (bool)GooglePurchasesBridge.trustUser;
    }
    public static void set_TrustUser(bool value)
    {
        null = null;
        GooglePurchasesBridge.trustUser = value;
    }
    public GooglePurchasesBridge(InAppPurchasesManager manager)
    {
        var val_14;
        this.pendingPurchases = new System.Collections.Generic.Queue<SLC.Billing.GooglePurchase>();
        MonoSingletonSelfGenerating<PluginObserverManager>.Instance.AddObserver(observer:  this);
        SLC.Billing.GoogleIAPManager.add_billingSupportedEvent(value:  new System.Action(object:  this, method:  System.Void GooglePurchasesBridge::billingSupportedEvent()));
        SLC.Billing.GoogleIAPManager.add_queryInventoryFailedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void GooglePurchasesBridge::queryInventoryFailedEvent(string error)));
        SLC.Billing.GoogleIAPManager.add_purchaseSucceededEvent(value:  new System.Action<SLC.Billing.GooglePurchase>(object:  this, method:  System.Void GooglePurchasesBridge::purchaseSucceededEvent(SLC.Billing.GooglePurchase purchase)));
        SLC.Billing.GoogleIAPManager.add_purchaseFailedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void GooglePurchasesBridge::purchaseFailedEvent(string error)));
        SLC.Billing.GoogleIAPManager.add_consumePurchaseSucceededEvent(value:  new System.Action<System.String, System.String>(object:  this, method:  System.Void GooglePurchasesBridge::consumePurchaseSucceededEvent(string responseCode, string purchaseToken)));
        SLC.Billing.GoogleIAPManager.add_consumePurchaseFailedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void GooglePurchasesBridge::consumePurchaseFailedEvent(string error)));
        SLC.Billing.GoogleIAPManager.add_acknowledgePurchaseSucceededEvent(value:  new System.Action<System.String, System.String>(object:  this, method:  System.Void GooglePurchasesBridge::acknowledgePurchaseSucceededEvent(string responseCode, string purchaseToken)));
        SLC.Billing.GoogleIAPManager.add_AcknowledgePurchaseFailedEvent(value:  new System.Action<System.String>(object:  this, method:  System.Void GooglePurchasesBridge::acknowledgePurchaseFailedEvent(string responseCode)));
        SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField = CompanyDevices.Instance.CompanyDevice();
        val_14 = null;
        val_14 = null;
        GooglePurchasesBridge.trustUser = true;
    }
    public override void init(string key)
    {
        if(this.initialized == true)
        {
                return;
        }
        
        this.key = key;
        if(key == null)
        {
                return;
        }
        
        SLC.Billing.GoogleIAP.init(publicKey:  key);
        this.initialized = true;
    }
    public override void queryInventory(string[] productSkus, string[] subSkus)
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.AddRange(collection:  productSkus);
        val_1.AddRange(collection:  subSkus);
        this.currentSKUs = val_1.ToArray();
        SLC.Billing.GoogleIAP.queryInventory(products:  productSkus, subscriptions:  subSkus);
    }
    public override void queryHistory()
    {
        SLC.Billing.GoogleIAP.queryHistory();
    }
    public override void Purchase(string sku)
    {
        SLC.Billing.GoogleIAP.purchaseProduct(sku:  sku);
    }
    public override void Subscribe(string sku)
    {
        SLC.Billing.GoogleIAP.subscribe(sku:  sku);
    }
    public override void Consume(NativePurchase purchase)
    {
        if(purchase.isConsumable != false)
        {
                SLC.Billing.GoogleIAP.consumeProduct(purchaseToken:  purchase.token);
            return;
        }
        
        SLC.Billing.GoogleIAP.AcknowledgeProduct(purchaseToken:  purchase.token);
    }
    private void queryInventoryFailedEvent(string error)
    {
        UnityEngine.Debug.Log(message:  "GooglePurchasesBridge.queryInventoryFailedEvent(). Error: "("GooglePurchasesBridge.queryInventoryFailedEvent(). Error: ") + error);
    }
    private void purchaseSucceededEvent(SLC.Billing.GooglePurchase purchase)
    {
        SLC.Billing.GooglePurchase val_9;
        NativePurchase val_10;
        NativePurchase val_11;
        var val_12;
        var val_13;
        val_9 = purchase;
        val_10 = this;
        if((purchase.<purchaseState>k__BackingField) == 0)
        {
                return;
        }
        
        if(this.cachedPurchase != null)
        {
                this.pendingPurchases.Enqueue(item:  val_9);
            return;
        }
        
        val_11 = val_10;
        val_12 = val_10;
        this.cachedPurchase = val_10;
        if((this.IsAValidPurchaseDate(purchase:  val_9, nativePurchase:  this)) == false)
        {
            goto label_16;
        }
        
        val_13 = null;
        val_13 = null;
        if(GooglePurchasesBridge.trustUser == false)
        {
            goto label_11;
        }
        
        label_14:
        val_11 = this.cachedPurchase;
        this.NotifyManagers(success:  true, purchase:  val_11);
        goto label_12;
        label_11:
        if(GooglePurchasesBridge.trustUser == false)
        {
            goto label_14;
        }
        
        label_12:
        if(((purchase.<isAcknowledged>k__BackingField) == true) || ((purchase.<purchaseState>k__BackingField) != 1))
        {
            goto label_16;
        }
        
        val_10 = ???;
        val_9 = ???;
        val_12 = ???;
        goto typeof(GooglePurchasesBridge).__il2cppRuntimeField_1D0;
        label_16:
        mem2[0] = 0;
        val_10.consumePendings();
    }
    private bool IsAValidPurchaseDate(SLC.Billing.GooglePurchase purchase, NativePurchase nativePurchase)
    {
        long val_6;
        var val_7;
        val_6 = purchase.<purchaseTime>k__BackingField;
        decimal val_1 = System.Decimal.op_Implicit(value:  val_6);
        System.DateTime val_2 = twelvegigs.storage.JsonDictionary.ConvertToUTCMilliseconds(timestamp:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid});
        if(nativePurchase.isConsumable != false)
        {
                val_6 = val_2.dateData;
            System.DateTime val_3 = ServerHandler.ServerTime;
            System.DateTime val_4 = val_3.dateData.AddDays(value:  -4);
            if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_4.dateData}, t2:  new System.DateTime() {dateData = val_6})) != false)
        {
                val_7 = 0;
            return (bool)val_7;
        }
        
        }
        
        val_7 = 1;
        return (bool)val_7;
    }
    private void purchaseFailedEvent(string error)
    {
        var val_5;
        notify(success:  false, purchaseInfo:  new NativePurchase(errorCode:  NativePurchase.setNavitePurchaseErrorCode(error:  error), errorString:  error));
        notifySubscription(success:  false, purchaseInfo:  new NativePurchase(errorCode:  NativePurchase.setNavitePurchaseErrorCode(error:  error), errorString:  error));
        val_5 = null;
        val_5 = null;
        GooglePurchasesBridge.trustUser = false;
        this.consumePendings();
    }
    private void consumePurchaseSucceededEvent(string responseCode, string purchaseToken)
    {
        null = null;
        if(GooglePurchasesBridge.trustUser != true)
        {
                if((System.String.op_Equality(a:  this.cachedPurchase.token, b:  purchaseToken)) != false)
        {
                this.NotifyManagers(success:  true, purchase:  this.cachedPurchase);
        }
        
        }
        
        this.cachedPurchase = 0;
        this.consumePendings();
    }
    private void acknowledgePurchaseSucceededEvent(string responseCode, string purchaseToken)
    {
        this.cachedPurchase = 0;
        this.consumePendings();
    }
    private void acknowledgePurchaseFailedEvent(string responseCode)
    {
        this.cachedPurchase = 0;
        this.consumePendings();
    }
    private void NotifyManagers(bool success, NativePurchase purchase)
    {
        if(purchase.isSubscription != false)
        {
                this.notifySubscription(success:  success, purchaseInfo:  purchase);
            return;
        }
        
        this.notify(success:  success, purchaseInfo:  purchase);
    }
    private bool AlreadyCashedIn(SLC.Billing.GooglePurchase purchaseToConsume)
    {
        null = null;
        if(GooglePurchasesBridge.trustUser == false)
        {
                return false;
        }
        
        if(this.cachedPurchase == null)
        {
                return false;
        }
        
        return System.String.op_Equality(a:  this.cachedPurchase.originalJson, b:  purchaseToConsume.<originalJson>k__BackingField);
    }
    private void consumePurchaseFailedEvent(string error)
    {
        this.cachedPurchase = 0;
        this.consumePendings();
    }
    private void consumePendings()
    {
        if(this.pendingPurchases == null)
        {
                return;
        }
        
        if(true < 1)
        {
                return;
        }
        
        this.purchaseSucceededEvent(purchase:  this.pendingPurchases.Dequeue());
    }
    protected override NativePurchase BuildPurchase(object parameters)
    {
        var val_11;
        var val_12;
        val_11 = parameters;
        if((System.Type.op_Equality(left:  val_11.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
        {
                val_12 = 0;
        }
        
        new SLC.Billing.GooglePurchase() = new SLC.Billing.GooglePurchase(dict:  (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? MiniJSON.Json.Deserialize(json:  (null == null) ? (val_11) : 0) : 0);
        .<originalJson>k__BackingField = (null == null) ? (val_11) : 0;
        val_11 = new SLC.Billing.GooglePurchase();
        .purchaseId = (NativePurchase)[1152921515718061632].sku;
        .packageName = (SLC.Billing.GooglePurchase)[1152921515718053440].<packageName>k__BackingField;
        .signature = (SLC.Billing.GooglePurchase)[1152921515718053440].<signature>k__BackingField;
        .token = (SLC.Billing.GooglePurchase)[1152921515718053440].<purchaseToken>k__BackingField;
        .originalJson = (SLC.Billing.GooglePurchase)[1152921515718053440].<originalJson>k__BackingField;
        .isPending = (((SLC.Billing.GooglePurchase)[1152921515718053440].<purchaseState>k__BackingField) != 1) ? 1 : 0;
        return (NativePurchase)new NativePurchase(sku:  (SLC.Billing.GooglePurchase)[1152921515718053440].<sku>k__BackingField);
    }
    private void billingSupportedEvent()
    {
        var val_1;
        UnityEngine.Debug.Log(message:  "GooglePurchasesBridge BillingSupported ");
        SLC.Billing.GoogleIAP.queryHistory();
        0.Initialized = true;
        val_1 = null;
        val_1 = null;
        App.inAppPurchasesManager.Initialized = true;
    }
    private void billingNotSupportedEvent(string error)
    {
    
    }
    public override void setPurchasePackages(string[] purchasePackages)
    {
        if(this.currentSKUs != null)
        {
                return;
        }
        
        this.currentSKUs = purchasePackages;
    }
    public override void setLogging(bool isLogging)
    {
        mem[1152921515718662136] = isLogging;
    }
    private static GooglePurchasesBridge()
    {
    
    }

}

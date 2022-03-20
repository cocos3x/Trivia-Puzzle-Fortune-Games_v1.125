using UnityEngine;
public class InAppPurchasesManager
{
    // Fields
    private const string PURCHASE_PREF_KEY = "iap_unresolved";
    private const string ANDROID_PROCESSED_TOKENS = "iap_android_tokens";
    private const int MAX_SAVED_TOKENS = 30;
    private static InAppPurchasesManager instance;
    private PurchasesBridge purchasesBridge;
    private bool initialized;
    private bool inPurchase;
    private bool logging;
    private System.Collections.Generic.List<System.Action<NativePurchase>> successCallbacks;
    private System.Collections.Generic.List<System.Action<NativePurchase>> subscriptionsSuccessCallbacks;
    private System.Collections.Generic.List<System.Action<NativePurchase>> errorCallbacks;
    private System.Collections.Generic.List<System.Action<NativePurchase>> subscriptionsErrorCallbacks;
    private static bool <inPurchaseIntent>k__BackingField;
    private System.Collections.Generic.HashSet<string> cashedIn;
    private System.Collections.Generic.HashSet<string> tracked;
    private PurchaseModel currentPurchase;
    private System.Collections.Generic.List<string> validTrackPoints;
    
    // Properties
    public static bool inPurchaseIntent { get; set; }
    public bool Logging { get; set; }
    public bool Initialized { get; set; }
    public PurchaseModel CurrentPurchase { get; }
    public static InAppPurchasesManager Instance { get; }
    
    // Methods
    public static bool get_inPurchaseIntent()
    {
        return (bool)InAppPurchasesManager.<inPurchaseIntent>k__BackingField;
    }
    private static void set_inPurchaseIntent(bool value)
    {
        InAppPurchasesManager.<inPurchaseIntent>k__BackingField = value;
    }
    public bool get_Logging()
    {
        return (bool)this.logging;
    }
    public void set_Logging(bool value)
    {
        this.logging = value;
        if(this.purchasesBridge != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public bool get_Initialized()
    {
        return (bool)this.initialized;
    }
    public void set_Initialized(bool value)
    {
        if(this.initialized != false)
        {
                return;
        }
        
        this.initialized = value;
    }
    public PurchaseModel DeserializeCurrentPurchaseFromPrefs()
    {
        var val_5;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "iap_unresolved", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) != true)
        {
                if((JsonSerializable<PurchaseModel>.Deserialize(serialized:  val_1)) != null)
        {
                return (PurchaseModel)val_5;
        }
        
        }
        
        UnityEngine.Debug.LogWarning(message:  "InAppPurchasesManager: failed to deserialize \'"("InAppPurchasesManager: failed to deserialize \'") + val_1 + "\'");
        val_5 = 0;
        return (PurchaseModel)val_5;
    }
    public void ClearPurchaseFromPrefs()
    {
        this.currentPurchase = 0;
        UnityEngine.PlayerPrefs.SetString(key:  "iap_unresolved", value:  "");
    }
    public PurchaseModel get_CurrentPurchase()
    {
        return (PurchaseModel)this.currentPurchase;
    }
    public void AddCashedIn(string token)
    {
        if((this.cashedIn.Contains(item:  token)) != true)
        {
                bool val_2 = this.cashedIn.Add(item:  token);
        }
        
        this.SaveCashedInAndTracked();
    }
    public bool IsCashedIn(string token)
    {
        return this.cashedIn.Contains(item:  token);
    }
    public void AddTracked(string token)
    {
        if((this.tracked.Contains(item:  token)) != true)
        {
                bool val_2 = this.tracked.Add(item:  token);
        }
        
        this.SaveCashedInAndTracked();
    }
    public bool IsTracked(string token)
    {
        return this.tracked.Contains(item:  token);
    }
    private void SaveCashedInAndTracked()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>(collection:  this.cashedIn);
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>(collection:  this.tracked);
        if(1152921510196879024 >= 31)
        {
                val_2.RemoveRange(index:  0, count:  44217914);
        }
        
        if(1152921510196879024 >= 31)
        {
                val_3.RemoveRange(index:  0, count:  44217914);
        }
        
        val_1.Add(key:  "cashedIn", value:  val_2);
        val_1.Add(key:  "tracked", value:  val_3);
        UnityEngine.PlayerPrefs.SetString(key:  "iap_android_tokens", value:  MiniJSON.Json.Serialize(obj:  val_1));
    }
    private void LoadCashedInAndTrecked()
    {
        string val_7;
        var val_8;
        string val_17;
        string val_18;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "iap_android_tokens")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "iap_android_tokens", defaultValue:  "{}"));
        object val_4 = val_3.Item["cashedIn"];
        List.Enumerator<T> val_6 = GetEnumerator();
        label_13:
        val_17 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_10;
        }
        
        val_18 = val_7;
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_18;
        if(this.cashedIn == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_10 = this.cashedIn.Add(item:  val_17);
        goto label_13;
        label_10:
        val_8.Dispose();
        List.Enumerator<T> val_12 = val_3.Item["tracked"].GetEnumerator();
        label_20:
        val_17 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_17;
        }
        
        val_18 = val_7;
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_18;
        if(this.tracked == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_14 = this.tracked.Add(item:  val_17);
        goto label_20;
        label_17:
        val_8.Dispose();
    }
    private InAppPurchasesManager()
    {
        this.cashedIn = new System.Collections.Generic.HashSet<System.String>();
        this.tracked = new System.Collections.Generic.HashSet<System.String>();
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        val_3.Add(item:  "PurchaseProxy");
        this.validTrackPoints = val_3;
        this.successCallbacks = new System.Collections.Generic.List<System.Action<NativePurchase>>();
        this.errorCallbacks = new System.Collections.Generic.List<System.Action<NativePurchase>>();
        this.subscriptionsSuccessCallbacks = new System.Collections.Generic.List<System.Action<NativePurchase>>();
        this.subscriptionsErrorCallbacks = new System.Collections.Generic.List<System.Action<NativePurchase>>();
        this.purchasesBridge = new GooglePurchasesBridge(manager:  this);
    }
    public void RemovePurchaseListeners(System.Action<NativePurchase> successCallback, System.Action<NativePurchase> errorCallback)
    {
        if((this.successCallbacks.Contains(item:  successCallback)) != false)
        {
                bool val_2 = this.successCallbacks.Remove(item:  successCallback);
        }
        
        if((this.errorCallbacks.Contains(item:  errorCallback)) != false)
        {
                bool val_4 = this.errorCallbacks.Remove(item:  errorCallback);
        }
        
        if((this.subscriptionsSuccessCallbacks.Contains(item:  successCallback)) != false)
        {
                bool val_6 = this.subscriptionsSuccessCallbacks.Remove(item:  successCallback);
        }
        
        if((this.subscriptionsErrorCallbacks.Contains(item:  errorCallback)) == false)
        {
                return;
        }
        
        bool val_8 = this.errorCallbacks.Remove(item:  errorCallback);
    }
    public void RestorePreviousPurchases()
    {
        UnityEngine.Debug.LogError(message:  "InAppUrchasesManager: RestorePreviousPurchases");
        goto typeof(PurchasesBridge).__il2cppRuntimeField_1C0;
    }
    public void SetPurchaseables(string[] packs)
    {
        if(this.purchasesBridge == null)
        {
                return;
        }
        
        goto typeof(PurchasesBridge).__il2cppRuntimeField_200;
    }
    public static InAppPurchasesManager get_Instance()
    {
        InAppPurchasesManager val_2;
        InAppPurchasesManager val_3 = InAppPurchasesManager.instance;
        if(val_3 != null)
        {
                return val_3;
        }
        
        InAppPurchasesManager val_1 = null;
        val_2 = val_1;
        val_1 = new InAppPurchasesManager();
        InAppPurchasesManager.instance = val_2;
        val_3 = InAppPurchasesManager.instance;
        return val_3;
    }
    public void Init(string key)
    {
        if(this.initialized != false)
        {
                return;
        }
        
        SLC.Billing.GoogleIAPManager.add_queryInventorySucceededEvent(value:  new System.Action<System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo>>(object:  this, method:  System.Void InAppPurchasesManager::HandleGooglequeryInventorySucceededEvent(System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo> skus)));
    }
    private void HandleGooglequeryInventorySucceededEvent(System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo> skus)
    {
        var val_4;
        var val_5;
        string val_11;
        string val_12;
        AppConfigs val_1 = App.Configuration;
        System.Collections.Generic.Dictionary<System.String, System.String> val_2 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        List.Enumerator<T> val_3 = skus.GetEnumerator();
        label_12:
        val_11 = public System.Boolean List.Enumerator<SLC.Billing.GoogleSkuInfo>::MoveNext();
        if(val_5.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_11 = "#FFFFFF";
        val_12 = "sku: "("sku: ") + val_4 + 48(val_4 + 48) + " - "(" - ") + val_4 + 24(val_4 + 24);
        SLCDebug.Log(logMessage:  val_12, colorHash:  val_11, isError:  false);
        if(val_1.storeConfig == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.IsNullOrEmpty(value:  val_1.storeConfig.GetId(sku:  val_4 + 48))) == true)
        {
            goto label_12;
        }
        
        val_11 = val_1.storeConfig.GetId(sku:  val_4 + 48);
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(key:  val_11, value:  val_4 + 24);
        goto label_12;
        label_5:
        val_5.Dispose();
        PackagesManager.UpdateCreditsFromStore(items:  val_2);
    }
    public void QueryHistory()
    {
        if(this.purchasesBridge != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void QueryInventory(string[] prodSkus, string[] subSkus)
    {
        if(this.purchasesBridge != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public bool Purchase(PurchaseModel purchase)
    {
        System.Object[] val_10;
        PurchaseModel val_11;
        var val_12;
        var val_13;
        val_10 = this;
        SLCDebug.Log(logMessage:  System.String.Format(format:  "InAppPurchasesManger.Purchase :: {0}", arg0:  purchase.ToShortString()), colorHash:  "#96CF13", isError:  false);
        var val_11 = 0;
        var val_10 = 0;
        do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = val_10 | (UnityEngine.StackTraceUtility.ExtractStackTrace().Contains(value:  ((UnityEngine.StackTraceUtility.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 32));
            val_11 = val_11 + 1;
        }
        while(this.validTrackPoints != null);
        
        if((val_10 & 1) == 0)
        {
            goto label_12;
        }
        
        InAppPurchasesManager.<inPurchaseIntent>k__BackingField = true;
        if(this.initialized == false)
        {
            goto label_14;
        }
        
        PurchaseModel val_6 = null;
        val_11 = val_6;
        val_6 = new PurchaseModel(purchaseToClone:  purchase);
        this.currentPurchase = val_11;
        UnityEngine.PlayerPrefs.SetString(key:  "iap_unresolved", value:  val_6.Serialize(format:  1));
        bool val_8 = PrefsSerializationManager.SavePlayerPrefs();
        if(purchase.isSubscription == false)
        {
            goto label_19;
        }
        
        goto label_20;
        label_12:
        val_12 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_12 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_12 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_12 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184];
        val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184;
        D.LogClientError(developer:  "A purchase attempt was made via App.Purchases.Purchase() without going through PurchaseProxy.Purchase(). Please use the PurchaseProxy purchase methods instead.", filter:  "default", context:  0, strings:  val_10);
        goto label_29;
        label_14:
        this.notify(success:  false, purchaseInfo:  new NativePurchase(errorCode:  8, errorString:  0));
        UnityEngine.Debug.LogError(message:  "InAppPurchasesManager not initialized, purchase failed.");
        label_29:
        val_13 = 0;
        return (bool)val_13;
        label_19:
        label_20:
        val_13 = 1;
        return (bool)val_13;
    }
    public void addPurchaseListener(System.Action<NativePurchase> successCallback, System.Action<NativePurchase> errorCallback)
    {
        if((this.successCallbacks.Contains(item:  successCallback)) != true)
        {
                this.successCallbacks.Add(item:  successCallback);
        }
        
        if((this.errorCallbacks.Contains(item:  errorCallback)) != false)
        {
                return;
        }
        
        this.errorCallbacks.Add(item:  errorCallback);
    }
    public void addSubscriptionListener(System.Action<NativePurchase> subscriptionSuccessCallback, System.Action<NativePurchase> errorCallback)
    {
        if((this.subscriptionsSuccessCallbacks.Contains(item:  subscriptionSuccessCallback)) != true)
        {
                this.subscriptionsSuccessCallbacks.Add(item:  subscriptionSuccessCallback);
        }
        
        if((this.subscriptionsErrorCallbacks.Contains(item:  errorCallback)) != false)
        {
                return;
        }
        
        this.subscriptionsErrorCallbacks.Add(item:  errorCallback);
    }
    public void notify(bool success, NativePurchase purchaseInfo)
    {
        var val_3;
        var val_4;
        NativePurchase val_6;
        var val_7;
        val_6 = purchaseInfo;
        var val_1 = (success != true) ? 32 : 48;
        List.Enumerator<T> val_2 = 1152921504889593856.GetEnumerator();
        label_4:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3.Invoke(obj:  val_6);
        goto label_4;
        label_2:
        val_6 = 0;
        val_4.Dispose();
        if(val_6 != 0)
        {
                throw val_6;
        }
        
        label_18:
        InAppPurchasesManager.<inPurchaseIntent>k__BackingField = false;
        return;
        label_19:
        val_7 = val_6;
        if(0 != 1)
        {
            goto label_14;
        }
        
        if((null & 1) == 0)
        {
            goto label_15;
        }
        
        UnityEngine.Debug.LogException(exception:  1152921504889700352);
        goto label_18;
        label_15:
        mem[8] = null;
        goto label_19;
        label_14:
    }
    public void notifySubscription(bool success, NativePurchase purchaseInfo)
    {
        var val_3;
        var val_4;
        NativePurchase val_6;
        var val_7;
        val_6 = purchaseInfo;
        var val_1 = (success != true) ? 40 : 56;
        List.Enumerator<T> val_2 = 1152921504889593856.GetEnumerator();
        label_4:
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3.Invoke(obj:  val_6);
        goto label_4;
        label_2:
        val_6 = 0;
        val_4.Dispose();
        if(val_6 != 0)
        {
                throw val_6;
        }
        
        label_18:
        InAppPurchasesManager.<inPurchaseIntent>k__BackingField = false;
        return;
        label_19:
        val_7 = val_6;
        if(0 != 1)
        {
            goto label_14;
        }
        
        if((null & 1) == 0)
        {
            goto label_15;
        }
        
        UnityEngine.Debug.LogException(exception:  1152921504889700352);
        goto label_18;
        label_15:
        mem[8] = null;
        goto label_19;
        label_14:
    }
    private void Log(string message)
    {
        if(this.logging == false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  message);
    }

}

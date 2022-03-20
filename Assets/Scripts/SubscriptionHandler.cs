using UnityEngine;
public class SubscriptionHandler : DefaultHandler<SubscriptionHandler>
{
    // Fields
    private const string CURRENT_SUBSCRIPTIONS_KEY = "current_subscriptions";
    private PurchaseModel currentPurchase;
    private NativePurchase currentNativePurchase;
    private SubscriptionModel currentGoldenSub;
    private SubscriptionModel currentSilverSub;
    private System.DateTime lastUpdated;
    private bool subscriptionUpdated;
    private bool econUpdated;
    private bool pendingSubscription;
    private FrameSkipper frameSkipper;
    public System.Action<System.Collections.Generic.Dictionary<string, object>> onSubscriptionCollectAttempt;
    public System.Action<bool> onSubscriptionPurchaseComplete;
    public System.Action<bool> onSubscriptionTrialClaimComplete;
    private int _dailyCoinAmount;
    private int _dailyCoinAmountSilver;
    private int _dailyGemAmount;
    private int _silverTicketUnlockLevel;
    private float _pointMultiplier;
    private int _freeTrialDaysGolden;
    private int _freeTrialDaysSilver;
    private static System.DateTime lastServerCall;
    private static int secondsUntilNextRequest;
    private static bool initialized;
    
    // Properties
    private System.Collections.Generic.List<SubscriptionModel> eitherSubscription { get; }
    public int getDailyCoinAmount { get; }
    public int getDailyCoinAmountSilver { get; }
    public int getDailyGemAmount { get; }
    public int getSilverTicketUnlockLevel { get; }
    public float getPointMultiplier { get; }
    public bool freeTrialEnabledGolden { get; }
    public bool freeTrialEnabledSilver { get; }
    public int freeTrialDaysGolden { get; }
    public int freeTrialDaysSilver { get; }
    
    // Methods
    private System.Collections.Generic.List<SubscriptionModel> get_eitherSubscription()
    {
        System.Collections.Generic.List<SubscriptionModel> val_1 = new System.Collections.Generic.List<SubscriptionModel>();
        if(this.currentGoldenSub != null)
        {
                val_1.Add(item:  this.currentGoldenSub);
        }
        
        if(this.currentSilverSub == null)
        {
                return val_1;
        }
        
        val_1.Add(item:  this.currentSilverSub);
        return val_1;
    }
    public int get_getDailyCoinAmount()
    {
        return (int)this._dailyCoinAmount;
    }
    public int get_getDailyCoinAmountSilver()
    {
        return (int)this._dailyCoinAmountSilver;
    }
    public int get_getDailyGemAmount()
    {
        return (int)this._dailyGemAmount;
    }
    public int get_getSilverTicketUnlockLevel()
    {
        return (int)this._silverTicketUnlockLevel;
    }
    public float get_getPointMultiplier()
    {
        return (float)this._pointMultiplier;
    }
    public bool get_freeTrialEnabledGolden()
    {
        return (bool)(this._freeTrialDaysGolden > 0) ? 1 : 0;
    }
    public bool get_freeTrialEnabledSilver()
    {
        return (bool)(this._freeTrialDaysSilver > 0) ? 1 : 0;
    }
    public int get_freeTrialDaysGolden()
    {
        return (int)this._freeTrialDaysGolden;
    }
    public int get_freeTrialDaysSilver()
    {
        return (int)this._freeTrialDaysSilver;
    }
    private SubscriptionModel GetSubByPackage(SubscriptionHandler.SubScriptionType subPackage)
    {
        SubscriptionModel val_1;
        if(subPackage != 1)
        {
                if(subPackage != 0)
        {
                return 0;
        }
        
            val_1 = this.currentGoldenSub;
            return (SubscriptionModel)mem[this.currentSilverSub];
        }
        
        val_1 = this.currentSilverSub;
        return (SubscriptionModel)mem[this.currentSilverSub];
    }
    public bool IsActive(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        SubscriptionModel val_1;
        if(subPackage != 1)
        {
                if(subPackage != 0)
        {
                return false;
        }
        
            val_1 = this.currentGoldenSub;
        }
        else
        {
                val_1 = this.currentSilverSub;
        }
        
        if(mem[this.currentSilverSub] == 0)
        {
                return false;
        }
        
        return mem[this.currentSilverSub].IsActive;
    }
    public bool CanCollect(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        SubscriptionModel val_1;
        if(subPackage != 1)
        {
                if(subPackage != 0)
        {
                return false;
        }
        
            val_1 = this.currentGoldenSub;
        }
        else
        {
                val_1 = this.currentSilverSub;
        }
        
        if(mem[this.currentSilverSub] == 0)
        {
                return false;
        }
        
        return mem[this.currentSilverSub].CanCollect;
    }
    public SubscriptionModel getCurrentModel(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        SubscriptionModel val_1;
        if(subPackage != 1)
        {
                if(subPackage != 0)
        {
                return 0;
        }
        
            val_1 = this.currentGoldenSub;
            return (SubscriptionModel)mem[this.currentSilverSub];
        }
        
        val_1 = this.currentSilverSub;
        return (SubscriptionModel)mem[this.currentSilverSub];
    }
    public void ProcessPurchase(NativePurchase subscriptionNativePurchase)
    {
        int val_19;
        string val_20;
        string val_21;
        var val_22;
        var val_23;
        SubscriptionHandler.<>c__DisplayClass45_0 val_1 = new SubscriptionHandler.<>c__DisplayClass45_0();
        .subscriptionNativePurchase = subscriptionNativePurchase;
        object[] val_2 = new object[2];
        val_19 = val_2.Length;
        val_2[0] = (SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase.token;
        if(((SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase.purchaseId) != null)
        {
                val_19 = val_2.Length;
        }
        
        val_2[1] = (SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase.purchaseId;
        UnityEngine.Debug.LogFormat(format:  "SubscriptionHandler ProcessPurchase: {0} {1}", args:  val_2);
        if((this.eitherSubscription.Exists(match:  new System.Predicate<SubscriptionModel>(object:  val_1, method:  System.Boolean SubscriptionHandler.<>c__DisplayClass45_0::<ProcessPurchase>b__0(SubscriptionModel x)))) != false)
        {
                System.DateTime val_9 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_8.<expire_at>k__BackingField, hi = val_8.<expire_at>k__BackingField, lo = -1743649728, mid = 268435458});
            val_20 = val_9.dateData.ToString();
            UnityEngine.Debug.Log(message:  "ProcessPurchase: currentSubscription"("ProcessPurchase: currentSubscription") + val_20 + " IsActive:"(" IsActive:") + System.Linq.Enumerable.FirstOrDefault<SubscriptionModel>(source:  this.eitherSubscription, predicate:  new System.Func<SubscriptionModel, System.Boolean>(object:  val_1, method:  System.Boolean SubscriptionHandler.<>c__DisplayClass45_0::<ProcessPurchase>b__1(SubscriptionModel x))).IsActive.ToString()(System.Linq.Enumerable.FirstOrDefault<SubscriptionModel>(source:  this.eitherSubscription, predicate:  new System.Func<SubscriptionModel, System.Boolean>(object:  val_1, method:  System.Boolean SubscriptionHandler.<>c__DisplayClass45_0::<ProcessPurchase>b__1(SubscriptionModel x))).IsActive.ToString()));
            if(this.onSubscriptionPurchaseComplete == null)
        {
                return;
        }
        
            this.onSubscriptionPurchaseComplete.Invoke(obj:  false);
            return;
        }
        
        val_20 = 1152921504884269056;
        AppConfigs val_15 = App.Configuration;
        if((val_15.storeConfig.GetProductBySku(sku:  (SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase.sku)) != null)
        {
                val_21 = val_16.internalId;
        }
        else
        {
                val_21 = 0;
        }
        
        val_22 = null;
        val_22 = null;
        this.currentPurchase = App.inAppPurchasesManager.currentPurchase;
        if(null != 0)
        {
                typeof(PurchaseModel).__il2cppRuntimeField_18 = val_21;
            Player val_17 = App.Player;
            this.currentPurchase.PrePurchaseUserInfo.total_purchase = val_17.total_purchased;
            bool val_18 = this.currentPurchase.id.Equals(value:  "id_silver_ticket_subscription");
            val_23 = null;
            val_23 = null;
            App.inAppPurchasesManager.ClearPurchaseFromPrefs();
        }
        
        this.currentNativePurchase = (SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase;
        this.ValidatePurchasedSubscription(nativePurchase:  (SubscriptionHandler.<>c__DisplayClass45_0)[1152921515748062256].subscriptionNativePurchase);
    }
    public void PurchaseFailed(NativePurchase nativePurchase)
    {
        if(this.onSubscriptionPurchaseComplete == null)
        {
                return;
        }
        
        this.onSubscriptionPurchaseComplete.Invoke(obj:  false);
    }
    public void ValidatePurchasedSubscription(NativePurchase nativePurchase)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12;
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_13;
        var val_14;
        var val_15;
        val_12 = nativePurchase;
        .<>4__this = this;
        val_13 = 1152921504884269056;
        val_14 = null;
        val_14 = null;
        if(App.networkManager.Reachable() == false)
        {
            goto label_8;
        }
        
        Player val_3 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_3.id)) == false)
        {
            goto label_12;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "On purchase failed but no player ID");
        }
        
        if(this.onSubscriptionPurchaseComplete != null)
        {
                this.onSubscriptionPurchaseComplete.Invoke(obj:  false);
        }
        
        this.pendingSubscription = true;
        return;
        label_8:
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "On purchase failed but no api reachable");
        }
        
        if(this.onSubscriptionPurchaseComplete == null)
        {
                return;
        }
        
        this.onSubscriptionPurchaseComplete.Invoke(obj:  false);
        return;
        label_12:
        System.Collections.Generic.Dictionary<System.String, System.Object> val_9 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        .data = val_9;
        Player val_10 = App.Player;
        val_9.Add(key:  "user_id", value:  val_10.id);
        val_9.Add(key:  "package", value:  nativePurchase.sku);
        val_12.AddStoreSpecificDataForValidation(postParams: ref  .data);
        val_15 = null;
        val_15 = null;
        val_12 = (SubscriptionHandler.<>c__DisplayClass47_0)[1152921515748480224].data;
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_11 = null;
        val_13 = val_11;
        val_11 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  new SubscriptionHandler.<>c__DisplayClass47_0(), method:  System.Void SubscriptionHandler.<>c__DisplayClass47_0::<ValidatePurchasedSubscription>b__0(string apicall, System.Collections.Generic.Dictionary<string, object> response));
        App.networkManager.DoPost(path:  "/api/subscriptions", postBody:  val_12, onCompleteFunction:  val_11, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    public void UpdateOnSceneChanged()
    {
        var val_7;
        var val_8;
        System.Predicate<SubscriptionModel> val_10;
        val_7 = null;
        val_7 = null;
        if(SubscriptionHandler.initialized == false)
        {
                return;
        }
        
        val_8 = null;
        val_8 = null;
        val_10 = SubscriptionHandler.<>c.<>9__48_0;
        if(val_10 == null)
        {
                System.Predicate<SubscriptionModel> val_2 = null;
            val_10 = val_2;
            val_2 = new System.Predicate<SubscriptionModel>(object:  SubscriptionHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean SubscriptionHandler.<>c::<UpdateOnSceneChanged>b__48_0(SubscriptionModel x));
            SubscriptionHandler.<>c.<>9__48_0 = val_10;
        }
        
        if((this.eitherSubscription.Exists(match:  val_2)) == false)
        {
                return;
        }
        
        Player val_4 = App.Player;
        if(val_4.properties.numSubscriptionsPurchased == 0)
        {
                Player val_5 = App.Player;
            if(val_5.properties.numSubscriptionsPurchased_Silver == 0)
        {
                return;
        }
        
        }
        
        System.DateTime val_6 = ServerHandler.ServerTime;
        this.lastUpdated = val_6;
        this.GetSubscription();
    }
    private System.Collections.IEnumerator RetryValidation(System.Collections.Generic.Dictionary<string, object> purchaseData)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .purchaseData = purchaseData;
        return (System.Collections.IEnumerator)new SubscriptionHandler.<RetryValidation>d__49();
    }
    private string SubscriptionsPostPath()
    {
        return "/api/subscriptions";
    }
    private void OnPurchaseValidated(System.Collections.Generic.Dictionary<string, object> purchaseData, System.Collections.Generic.Dictionary<string, object> response)
    {
        TrackerManager val_44;
        var val_45;
        var val_46;
        var val_47;
        var val_48;
        var val_49;
        var val_50;
        int val_51;
        var val_52;
        var val_53;
        var val_54;
        var val_55;
        var val_56;
        System.DateTime val_1 = ServerHandler.ServerTime;
        this.lastUpdated = val_1;
        if(response == null)
        {
            goto label_4;
        }
        
        val_45 = "validated";
        if((response.ContainsKey(key:  "validated")) == false)
        {
            goto label_4;
        }
        
        this.pendingSubscription = false;
        this.subscriptionUpdated = true;
        twelvegigs.storage.JsonDictionary val_3 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  response);
        if((val_3.getBool(key:  "validated")) == false)
        {
            goto label_6;
        }
        
        SubscriptionModel val_5 = new SubscriptionModel();
        val_5.ParseJsonDic(jsonDic:  val_3.getJsonDictionary(key:  "subscription"));
        val_45 = 1152921504884269056;
        AppConfigs val_7 = App.Configuration;
        if(((SubscriptionModel)[1152921515749298576].<packageName>k__BackingField.Equals(value:  val_7.storeConfig.id_golden_ticket_subscription.sku)) == false)
        {
            goto label_14;
        }
        
        if(this.currentGoldenSub == null)
        {
            goto label_15;
        }
        
        this.currentGoldenSub.ParseJsonDic(jsonDic:  val_3.getJsonDictionary(key:  "subscription"));
        goto label_16;
        label_4:
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "On purchase failed but not validated");
        }
        
        if(this.onSubscriptionPurchaseComplete != null)
        {
                this.onSubscriptionPurchaseComplete.Invoke(obj:  false);
        }
        
        UnityEngine.Coroutine val_13 = this.StartCoroutine(routine:  this.RetryValidation(purchaseData:  purchaseData));
        return;
        label_6:
        val_46 = null;
        val_46 = null;
        GooglePurchasesBridge.trustUser = false;
        UnityEngine.Debug.LogError(message:  "Hack intent! Subscription validation failed.");
        val_44 = 1152921504885014528;
        val_47 = null;
        val_47 = null;
        PluginObserverManager.isPurchaseValidationWorking = false;
        Player val_14 = App.Player;
        val_14.properties.<PurchaseHackUser>k__BackingField = true;
        App.Player.SaveState();
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  "On purchase failed but hacker flag");
        }
        
        if(this.onSubscriptionPurchaseComplete == null)
        {
                return;
        }
        
        val_48 = 1152921510229859200;
        val_49 = 0;
        goto label_46;
        label_14:
        AppConfigs val_18 = App.Configuration;
        if(((SubscriptionModel)[1152921515749298576].<packageName>k__BackingField.Equals(value:  val_18.storeConfig.id_silver_ticket_subscription.sku)) == false)
        {
            goto label_53;
        }
        
        if(this.currentSilverSub == null)
        {
            goto label_54;
        }
        
        this.currentSilverSub.ParseJsonDic(jsonDic:  val_3.getJsonDictionary(key:  "subscription"));
        goto label_55;
        label_15:
        this.currentGoldenSub = val_5;
        label_16:
        Player val_21 = App.Player;
        val_21.properties.has_Active_Subscription = true;
        if(((SubscriptionModel)[1152921515749298576].<trial>k__BackingField) != false)
        {
                Player val_22 = App.Player;
            int val_44 = val_22.properties.numTrialSubs;
            val_44 = val_44 + 1;
            val_22.properties.numTrialSubs = val_44;
        }
        else
        {
                Player val_23 = App.Player;
            int val_45 = val_23.properties.numSubscriptionsPurchased;
            val_45 = val_45 + 1;
            val_23.properties.numSubscriptionsPurchased = val_45;
        }
        
        val_50 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        System.DateTime val_26 = MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        val_51 = this._freeTrialDaysGolden;
        goto label_73;
        label_54:
        this.currentSilverSub = val_5;
        label_55:
        Player val_27 = App.Player;
        val_27.properties.has_Active_Subscription_Silver = true;
        if(((SubscriptionModel)[1152921515749298576].<trial>k__BackingField) != false)
        {
                Player val_28 = App.Player;
            int val_46 = val_28.properties.numTrialSubs_Silver;
            val_46 = val_46 + 1;
            val_28.properties.numTrialSubs_Silver = val_46;
        }
        else
        {
                Player val_29 = App.Player;
            int val_47 = val_29.properties.numSubscriptionsPurchased_Silver;
            val_47 = val_47 + 1;
            val_29.properties.numSubscriptionsPurchased_Silver = val_47;
        }
        
        val_50 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        System.DateTime val_32 = MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd;
        val_51 = this._freeTrialDaysSilver;
        label_73:
        System.DateTime val_33 = val_32.dateData.AddDays(value:  (double)val_51);
        val_50.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_33.dateData};
        label_53:
        val_44 = this;
        PurchaseModel val_41 = this.currentPurchase;
        if(val_41 != null)
        {
                if(((SubscriptionModel)[1152921515749298576].<trial>k__BackingField) == false)
        {
            goto label_93;
        }
        
        }
        
        val_52 = null;
        val_52 = null;
        if((App.game != 17) || (((SubscriptionModel)[1152921515749298576].<trial>k__BackingField) == false))
        {
            goto label_116;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_34 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_53 = null;
        val_53 = null;
        val_34.Add(key:  "Entry Point", value:  PurchaseProxy.currentPurchasePoint.ToString());
        val_54 = null;
        val_54 = null;
        val_44 = App.trackerManager;
        val_44.track(eventName:  Events.SUBSCRIPTION_TRIAL_START, data:  val_34);
        goto label_116;
        label_93:
        val_55 = null;
        val_55 = null;
        App.trackerManager.track(eventName:  Events.SUBSCRIPTION_PURCHASE);
        val_56 = null;
        val_56 = null;
        App.trackerManager.track(eventName:  this.currentPurchase.sale_price.ToString().Replace(oldValue:  ".", newValue:  ""));
        SLCDebug.Log(logMessage:  "Tracking Subscription event(s): "("Tracking Subscription event(s): ") + Events.SUBSCRIPTION_PURCHASE + " " + this.currentPurchase.sale_price.ToString().Replace(oldValue:  ".", newValue:  "")(this.currentPurchase.sale_price.ToString().Replace(oldValue:  ".", newValue:  "")), colorHash:  "#FFFFFF", isError:  false);
        this.RegisterPurchase(purchase: ref  val_41);
        DefaultHandler<TrackingHandler>.Instance.TrackSubscriptionPurchase(model:  this.currentPurchase, native:  this.currentNativePurchase);
        label_116:
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  19);
        App.Player.RemovedAds = true;
        this.SaveSubscription();
        if(this.onSubscriptionPurchaseComplete == null)
        {
                return;
        }
        
        val_48 = 1152921510229859200;
        val_49 = 1;
        label_46:
        this.onSubscriptionPurchaseComplete.Invoke(obj:  true);
    }
    private void SaveSubscription()
    {
        if(this.currentGoldenSub != null)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "current_subscriptions_gt", value:  this.currentGoldenSub.Serialize(format:  0));
        }
        else
        {
                UnityEngine.PlayerPrefs.DeleteKey(key:  "current_subscriptions_gt");
        }
        
        if(this.currentSilverSub != null)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "current_subscriptions_st", value:  this.currentSilverSub.Serialize(format:  0));
            return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "current_subscriptionsst");
    }
    private void LoadCurrentSubscription()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "current_subscriptions_gt")) != false)
        {
                this.currentGoldenSub = JsonSerializable<SubscriptionModel>.Deserialize(serialized:  UnityEngine.PlayerPrefs.GetString(key:  "current_subscriptions_gt"));
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "current_subscriptions_st")) == false)
        {
                return;
        }
        
        this.currentSilverSub = JsonSerializable<SubscriptionModel>.Deserialize(serialized:  UnityEngine.PlayerPrefs.GetString(key:  "current_subscriptions_st"));
    }
    private void UpdateNextSubscription()
    {
        System.Predicate<T> val_17;
        System.Collections.Generic.List<SubscriptionModel> val_1 = this.eitherSubscription;
        if(true == 0)
        {
                return;
        }
        
        System.Predicate<SubscriptionModel> val_3 = null;
        val_17 = val_3;
        val_3 = new System.Predicate<SubscriptionModel>(object:  this, method:  System.Boolean SubscriptionHandler::<UpdateNextSubscription>b__54_0(SubscriptionModel x));
        if((this.eitherSubscription.Exists(match:  val_3)) == false)
        {
                return;
        }
        
        if(this.subscriptionUpdated == false)
        {
                return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                object[] val_10 = new object[3];
            val_10[0] = this.lastUpdated;
            System.DateTime val_11 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = val_9.<expire_at>k__BackingField, hi = val_9.<expire_at>k__BackingField, lo = 19914752, mid = 268435456});
            val_10[1] = val_11.dateData.ToString();
            val_17 = System.Linq.Enumerable.First<SubscriptionModel>(source:  this.eitherSubscription, predicate:  new System.Func<SubscriptionModel, System.Boolean>(object:  this, method:  System.Boolean SubscriptionHandler::<UpdateNextSubscription>b__54_1(SubscriptionModel x))).IsActive;
            val_10[2] = val_17;
            UnityEngine.Debug.LogFormat(format:  "UpdateNextSubscription {0} {1} {2}", args:  val_10);
        }
        
        this.subscriptionUpdated = false;
        System.DateTime val_15 = ServerHandler.ServerTime;
        this.lastUpdated = val_15;
        this.GetSubscription();
        InAppPurchasesManager.Instance.QueryHistory();
    }
    private void OnServerResponded()
    {
        null = null;
        if(TrackingComponent.lastIntent == 2)
        {
                return;
        }
        
        if((this.pendingSubscription != false) && (this.currentNativePurchase != null))
        {
                this.ValidatePurchasedSubscription(nativePurchase:  this.currentNativePurchase);
        }
        
        if((this.subscriptionUpdated != false) && (this.econUpdated != false))
        {
                return;
        }
        
        this.GetSubscription();
    }
    private void GetSubscription()
    {
        twelvegigs.net.JsonApiRequester val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        val_12 = 1152921504884269056;
        val_13 = null;
        val_13 = null;
        if(App.networkManager.Reachable() == false)
        {
                return;
        }
        
        Player val_2 = App.Player;
        if((System.String.IsNullOrEmpty(value:  val_2.id)) == true)
        {
                return;
        }
        
        System.DateTime val_4 = System.DateTime.UtcNow;
        val_14 = null;
        val_14 = null;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = SubscriptionHandler.lastServerCall});
        if(val_5._ticks.TotalSeconds < 0)
        {
                return;
        }
        
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        val_15 = null;
        val_15 = null;
        SubscriptionHandler.lastServerCall = val_7.dateData;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_8 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_8.Add(key:  "platform", value:  "android");
        val_16 = null;
        val_16 = null;
        val_12 = App.networkManager;
        Player val_9 = App.Player;
        val_12.DoGet(path:  "/api/subscriptions/"("/api/subscriptions/") + val_9.id, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SubscriptionHandler::OnGetSubscription(string method, System.Collections.Generic.Dictionary<string, object> response)), destroy:  false, immediate:  false, getParams:  val_8, timeout:  20);
    }
    private void OnGetSubscription(string method, System.Collections.Generic.Dictionary<string, object> response)
    {
        System.Collections.IDictionary val_30;
        var val_31;
        val_30 = response;
        System.DateTime val_1 = ServerHandler.ServerTime;
        this.lastUpdated = val_1;
        if(val_30 == null)
        {
                return;
        }
        
        if((val_30.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        twelvegigs.storage.JsonDictionary val_3 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  val_30);
        if((val_3.getBool(key:  "success")) == false)
        {
                return;
        }
        
        if((val_3.Contains(key:  "golden")) != false)
        {
                twelvegigs.storage.JsonDictionary val_6 = val_3.getJsonDictionary(key:  "golden");
            val_30 = val_6;
            this._dailyCoinAmount = val_6.getInt(key:  "coins", defaultValue:  this._dailyCoinAmount);
            if((val_30.Contains(key:  "gems")) != false)
        {
                this._dailyGemAmount = val_30.getInt(key:  "gems", defaultValue:  this._dailyGemAmount);
        }
        
            this._pointMultiplier = System.Single.Parse(s:  val_30.getString(key:  "points", defaultValue:  ""), provider:  System.Globalization.CultureInfo.InvariantCulture);
            if((val_30.Contains(key:  "trial")) != false)
        {
                this.UpdateTrialData(trialData:  val_30.getJsonDictionary(key:  "trial"), subPack:  0);
        }
        
            this.econUpdated = true;
        }
        
        if((val_3.Contains(key:  "silver")) != false)
        {
                twelvegigs.storage.JsonDictionary val_16 = val_3.getJsonDictionary(key:  "silver");
            val_30 = val_16;
            this._dailyCoinAmountSilver = val_16.getInt(key:  "coins", defaultValue:  this._dailyCoinAmountSilver);
            if((val_30.Contains(key:  "gems")) != false)
        {
                this._dailyGemAmount = val_30.getInt(key:  "gems", defaultValue:  this._dailyGemAmount);
        }
        
            this._silverTicketUnlockLevel = val_30.getInt(key:  "unlock_level", defaultValue:  this._silverTicketUnlockLevel);
            if((val_30.Contains(key:  "trial")) != false)
        {
                this.UpdateTrialData(trialData:  val_30.getJsonDictionary(key:  "trial"), subPack:  1);
        }
        
            this.econUpdated = true;
        }
        
        val_31 = 0;
        if((val_3.Contains(key:  "subscriptions")) == false)
        {
                return;
        }
        
        val_30 = (twelvegigs.storage.JsonDictionary)[1152921515750494048].dataSource;
        var val_31 = 0;
        val_31 = val_31 + 1;
        val_31 = 0;
        if(val_30.Item["subscriptions"] == null)
        {
                return;
        }
        
        twelvegigs.storage.JsonDictionary val_26 = val_3.getJsonDictionary(key:  "subscriptions");
        if((val_26.Contains(key:  "golden")) != false)
        {
                this.UpdateSubData(gtData:  val_26.getJsonDictionary(key:  "golden"), subPackage:  0);
        }
        
        if((val_26.Contains(key:  "silver")) == false)
        {
                return;
        }
        
        this.UpdateSubData(gtData:  val_26.getJsonDictionary(key:  "silver"), subPackage:  1);
    }
    private void UpdateSubData(twelvegigs.storage.JsonDictionary gtData, SubscriptionHandler.SubScriptionType subPackage)
    {
        if(subPackage == 1)
        {
            goto label_1;
        }
        
        if(subPackage != 0)
        {
            goto label_2;
        }
        
        if((gtData.Contains(key:  "non_trial_count")) != false)
        {
                Player val_2 = App.Player;
            val_2.properties.numSubscriptionsPurchased = gtData.getInt(key:  "non_trial_count", defaultValue:  0);
        }
        
        if((gtData.Contains(key:  "trial_count")) == false)
        {
            goto label_26;
        }
        
        Player val_5 = App.Player;
        val_5.properties.numTrialSubs = gtData.getInt(key:  "trial_count", defaultValue:  0);
        goto label_26;
        label_1:
        if((gtData.Contains(key:  "non_trial_count")) != false)
        {
                Player val_8 = App.Player;
            val_8.properties.numSubscriptionsPurchased_Silver = gtData.getInt(key:  "non_trial_count", defaultValue:  0);
        }
        
        if((gtData.Contains(key:  "trial_count")) == false)
        {
            goto label_26;
        }
        
        Player val_11 = App.Player;
        val_11.properties.numTrialSubs_Silver = gtData.getInt(key:  "trial_count", defaultValue:  0);
        goto label_26;
        label_2:
        label_26:
        if((gtData.Contains(key:  "active")) == false)
        {
                return;
        }
        
        this.UpdateSubscriptionModel(sub:  gtData.getJsonDictionary(key:  "active"));
    }
    private void UpdateSubscriptionModel(twelvegigs.storage.JsonDictionary sub)
    {
        SubscriptionModel val_1 = new SubscriptionModel();
        val_1.ParseJsonDic(jsonDic:  sub);
        AppConfigs val_2 = App.Configuration;
        if(((SubscriptionModel)[1152921515750919056].<packageName>k__BackingField.Equals(value:  val_2.storeConfig.id_golden_ticket_subscription.sku)) == false)
        {
            goto label_8;
        }
        
        if(this.currentGoldenSub != null)
        {
            goto label_9;
        }
        
        this.currentGoldenSub = val_1;
        goto label_19;
        label_8:
        AppConfigs val_4 = App.Configuration;
        if(((SubscriptionModel)[1152921515750919056].<packageName>k__BackingField.Equals(value:  val_4.storeConfig.id_silver_ticket_subscription.sku)) == false)
        {
            goto label_19;
        }
        
        if(this.currentSilverSub == null)
        {
            goto label_18;
        }
        
        label_9:
        this.currentSilverSub.ParseJsonDic(jsonDic:  sub);
        label_19:
        this.subscriptionUpdated = true;
        this.SaveSubscription();
        return;
        label_18:
        this.currentSilverSub = val_1;
        goto label_19;
    }
    private void UpdateTrialData(twelvegigs.storage.JsonDictionary trialData, SubscriptionHandler.SubScriptionType subPack)
    {
        twelvegigs.storage.JsonDictionary val_6 = trialData;
        if((val_6.Contains(key:  "android")) == false)
        {
                return;
        }
        
        twelvegigs.storage.JsonDictionary val_2 = val_6.getJsonDictionary(key:  "android");
        val_6 = val_2;
        if((val_2.Contains(key:  "days")) == false)
        {
                return;
        }
        
        if(subPack != 1)
        {
                if(subPack != 0)
        {
                return;
        }
        
            this._freeTrialDaysGolden = val_6.getInt(key:  "days", defaultValue:  3);
            return;
        }
        
        this._freeTrialDaysSilver = val_6.getInt(key:  "days", defaultValue:  3);
    }
    public void CollectSubscription(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        twelvegigs.net.JsonApiRequester val_6;
        SubscriptionModel val_7;
        SubscriptionModel val_8;
        SubscriptionModel val_9;
        var val_10;
        val_6 = subPackage;
        if(val_6 != 1)
        {
                if(val_6 != 0)
        {
                return;
        }
        
            val_7 = this.currentGoldenSub;
        }
        else
        {
                val_7 = this.currentSilverSub;
        }
        
        if(mem[this.currentSilverSub] == 0)
        {
                return;
        }
        
        if(mem[this.currentSilverSub].CanCollect == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "collect", value:  true);
        if(val_6 != 1)
        {
                val_8 = this.currentGoldenSub;
        }
        else
        {
                val_8 = this.currentSilverSub;
        }
        
        val_2.Add(key:  "package_name", value:  mem[this.currentSilverSub] + 24);
        if(val_6 != 1)
        {
                val_9 = this.currentGoldenSub;
        }
        else
        {
                val_9 = this.currentSilverSub;
        }
        
        val_2.Add(key:  "package", value:  mem[this.currentSilverSub] + 24);
        val_10 = null;
        val_10 = null;
        val_6 = App.networkManager;
        Player val_3 = App.Player;
        val_6.DoPut(path:  "/api/subscriptions/"("/api/subscriptions/") + val_3.id, postBody:  val_2, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  public System.Void SubscriptionHandler::OnCollectSubscription(string method, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    public void OnCollectSubscription(string method, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_9;
        var val_10;
        System.DateTime val_1 = ServerHandler.ServerTime;
        this.lastUpdated = val_1;
        if((response != null) && ((response.ContainsKey(key:  "success")) != false))
        {
                twelvegigs.storage.JsonDictionary val_3 = null;
            val_9 = val_3;
            val_3 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  response);
            if((val_3.getBool(key:  "success")) != false)
        {
                SubscriptionModel val_5 = new SubscriptionModel();
            val_10 = 0;
            if((val_3.Contains(key:  "subscription")) != false)
        {
                var val_10 = 0;
            val_10 = val_10 + 1;
            val_10 = 0;
            if((twelvegigs.storage.JsonDictionary)[1152921515751431376].dataSource.Item["subscription"] != null)
        {
                this.UpdateSubscriptionModel(sub:  val_3.getJsonDictionary(key:  "subscription"));
        }
        
        }
        
        }
        
        }
        
        if(this.onSubscriptionCollectAttempt == null)
        {
                return;
        }
        
        this.onSubscriptionCollectAttempt.Invoke(obj:  response);
    }
    private void RegisterPurchase(ref PurchaseModel purchase)
    {
        bool val_25;
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
        System.DateTime val_7 = ServerHandler.ServerTime;
        val_6.last_purchase = val_7;
        Player val_8 = this.Player;
        float val_24 = val_8.total_purchased;
        val_24 = val_24 + purchase.sale_price;
        val_8.total_purchased = val_24;
        Player val_9 = this.Player;
        float val_25 = purchase.sale_price;
        int val_26 = val_9.totalRevenue;
        val_25 = val_25 * 100f;
        val_25 = (val_25 == Infinityf) ? (-(double)val_25) : ((double)val_25);
        val_26 = val_26 + (int)val_25;
        val_9.totalRevenue = val_26;
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
            int val_28 = val_14.num_purchase;
            float val_27 = (float)val_13.num_purchase;
            val_27 = val_12.transactionsAverageAmount * val_27;
            val_27 = val_27 + purchase.sale_price;
            val_28 = val_28 + 1;
            val_27 = val_27 / (float)val_28;
            val_11.transactionsAverageAmount = val_27;
        }
        
        Player val_15 = this.Player;
        int val_29 = val_15.num_purchase;
        val_29 = val_29 + 1;
        val_15.num_purchase = val_29;
        Player val_16 = this.Player;
        Player val_17 = this.Player;
        val_16.lastPurchasePrice = System.Math.Max(val1:  val_17.lastPurchasePrice, val2:  purchase.sale_price);
        Player val_20 = this.Player;
        if((System.String.IsNullOrEmpty(value:  val_1.max_item_purchased)) == false)
        {
            goto label_35;
        }
        
        val_25 = 1;
        goto label_36;
        label_35:
        if((System.String.op_Inequality(a:  val_1.max_item_purchased, b:  val_20.max_item_purchased)) == false)
        {
            goto label_37;
        }
        
        Player val_22 = this.Player;
        val_25 = false;
        label_36:
        val_22.samePurchases = val_25;
        label_37:
        Player val_23 = this.Player;
        val_23.properties.LevelsPlayedPostPurchase = 0;
    }
    protected override void AwakeLogic()
    {
        this.AwakeLogic();
        this.Initialize();
    }
    private void Initialize()
    {
        object val_13;
        var val_14;
        var val_15;
        FrameSkipper val_16;
        SubscriptionModel val_17;
        SubscriptionModel val_18;
        var val_19;
        val_13 = this;
        val_14 = null;
        val_14 = null;
        if(SubscriptionHandler.initialized == true)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        App.inAppPurchasesManager.addSubscriptionListener(subscriptionSuccessCallback:  new System.Action<NativePurchase>(object:  this, method:  public System.Void SubscriptionHandler::ProcessPurchase(NativePurchase subscriptionNativePurchase)), errorCallback:  new System.Action<NativePurchase>(object:  this, method:  public System.Void SubscriptionHandler::PurchaseFailed(NativePurchase nativePurchase)));
        this.LoadCurrentSubscription();
        if(this.frameSkipper != 0)
        {
            goto label_12;
        }
        
        FrameSkipper val_5 = this.gameObject.AddComponent<FrameSkipper>();
        val_16 = val_5;
        this.frameSkipper = val_5;
        if(val_16 != null)
        {
            goto label_14;
        }
        
        label_12:
        val_16 = this.frameSkipper;
        label_14:
        System.Delegate val_7 = System.Delegate.Combine(a:  this.frameSkipper.updateLogic, b:  new System.Action(object:  this, method:  System.Void SubscriptionHandler::UpdateNextSubscription()));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_18;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_7;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerResponded");
        Player val_9 = App.Player;
        val_17 = this.currentGoldenSub;
        if(val_17 != null)
        {
                val_17 = val_17.IsActive;
        }
        
        val_9.properties.has_Active_Subscription = val_17;
        Player val_11 = App.Player;
        val_18 = this.currentSilverSub;
        val_13 = val_11.properties;
        if(val_18 != null)
        {
                val_18 = val_18.IsActive;
        }
        
        val_11.properties.has_Active_Subscription_Silver = val_18;
        val_19 = null;
        val_19 = null;
        SubscriptionHandler.initialized = true;
        return;
        label_18:
    }
    public SubscriptionHandler()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        this.lastUpdated = val_1;
        this._pointMultiplier = 2f;
        this._freeTrialDaysGolden = 3;
        this._freeTrialDaysSilver = 0;
        this._dailyCoinAmount = ;
        this._dailyCoinAmountSilver = ;
        this._dailyGemAmount = 1610612736120;
        this._silverTicketUnlockLevel = 375;
    }
    private static SubscriptionHandler()
    {
        null = null;
        SubscriptionHandler.lastServerCall = System.DateTime.MinValue;
        SubscriptionHandler.secondsUntilNextRequest = 30;
        SubscriptionHandler.initialized = false;
    }
    private bool <UpdateNextSubscription>b__54_0(SubscriptionModel x)
    {
        System.DateTime val_5;
        var val_6;
        val_5 = this;
        if(x.IsActive != false)
        {
                val_6 = 0;
        }
        else
        {
                val_5 = this.lastUpdated;
            System.DateTime val_2 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = x.<expire_at>k__BackingField, hi = x.<expire_at>k__BackingField, lo = x, mid = x});
            bool val_3 = System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_5}, t2:  new System.DateTime() {dateData = val_2.dateData});
            val_6 = val_3 ^ 1;
        }
        
        val_3 = val_6;
        return (bool)val_3;
    }
    private bool <UpdateNextSubscription>b__54_1(SubscriptionModel x)
    {
        System.DateTime val_5;
        var val_6;
        val_5 = this;
        if(x.IsActive != false)
        {
                val_6 = 0;
        }
        else
        {
                val_5 = this.lastUpdated;
            System.DateTime val_2 = twelvegigs.storage.JsonDictionary.ConvertToUTC(timestamp:  new System.Decimal() {flags = x.<expire_at>k__BackingField, hi = x.<expire_at>k__BackingField, lo = x, mid = x});
            bool val_3 = System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_5}, t2:  new System.DateTime() {dateData = val_2.dateData});
            val_6 = val_3 ^ 1;
        }
        
        val_3 = val_6;
        return (bool)val_3;
    }

}

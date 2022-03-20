using UnityEngine;
public class WGSubscriptionManager : MonoSingleton<WGSubscriptionManager>
{
    // Fields
    private const string golden_ticket_purchased = "gt_purchased";
    private const string silver_ticket_purchased = "st_purchased";
    private static TrackerPurchasePoints _subEntryPoint;
    public System.Action<bool> purchaseResult;
    public System.Action<bool, WGSubscriptionManager.collectResultStatus> onCollectAttemptResult;
    
    // Properties
    public static bool HasSubscribedGoldenTicket { get; set; }
    public static bool HasSubscribedSilverTicket { get; set; }
    public static TrackerPurchasePoints subEntryPoint { get; set; }
    public static bool WillGetFreeTrial_Golden { get; }
    public static bool WillGetFreeTrial_Silver { get; }
    public static bool WillGetFreeTrial { get; }
    public string pointMultiplier { get; }
    public string pointXMoreMultiplier { get; }
    public bool silverTicketUnlocked { get; }
    
    // Methods
    public static bool get_HasSubscribedGoldenTicket()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "gt_purchased", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public static void set_HasSubscribedGoldenTicket(bool value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "gt_purchased", value:  value);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static bool get_HasSubscribedSilverTicket()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "st_purchased", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public static void set_HasSubscribedSilverTicket(bool value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "st_purchased", value:  value);
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static TrackerPurchasePoints get_subEntryPoint()
    {
        return (TrackerPurchasePoints)WGSubscriptionManager._subEntryPoint;
    }
    public static void set_subEntryPoint(TrackerPurchasePoints value)
    {
        WGSubscriptionManager._subEntryPoint = value;
    }
    public static int GetAdditionalPoints(int basePoints)
    {
        if((MonoSingleton<WGSubscriptionManager>.Instance) == 0)
        {
                return 0;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return 0;
        }
        
        if((DefaultHandler<SubscriptionHandler>.Instance) == 0)
        {
                return 0;
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == false)
        {
                return 0;
        }
        
        SubscriptionHandler val_8 = DefaultHandler<SubscriptionHandler>.Instance;
        float val_10 = (float)basePoints;
        val_10 = val_8._pointMultiplier * val_10;
        int val_9 = UnityEngine.Mathf.RoundToInt(f:  val_10);
        val_9 = val_9 - basePoints;
        return 0;
    }
    public static float GetPointMultiplier()
    {
        UnityEngine.Object val_9;
        float val_10;
        val_9 = MonoSingleton<WGSubscriptionManager>.Instance;
        val_10 = 0f;
        if(val_9 == 0)
        {
                return val_10;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return val_10;
        }
        
        val_9 = DefaultHandler<SubscriptionHandler>.Instance;
        if(val_9 == 0)
        {
                return val_10;
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance.hasSubscription(subPackage:  0)) == false)
        {
                return val_10;
        }
        
        SubscriptionHandler val_8 = DefaultHandler<SubscriptionHandler>.Instance;
        val_10 = val_8._pointMultiplier;
        return val_10;
    }
    public static bool get_WillGetFreeTrial_Golden()
    {
        Player val_1 = App.Player;
        if(val_1.properties.has_Active_Subscription == true)
        {
                return false;
        }
        
        Player val_2 = App.Player;
        if(val_2.properties.numSubscriptionsPurchased != 0)
        {
                return false;
        }
        
        Player val_3 = App.Player;
        if(val_3.properties.numTrialSubs != 0)
        {
                return false;
        }
        
        1152921504884269056 = DefaultHandler<SubscriptionHandler>.Instance;
        if(1152921504884269056 == 0)
        {
                return false;
        }
        
        return DefaultHandler<SubscriptionHandler>.Instance.freeTrialEnabledGolden;
    }
    public static bool get_WillGetFreeTrial_Silver()
    {
        Player val_1 = App.Player;
        if(val_1.properties.has_Active_Subscription_Silver == true)
        {
                return false;
        }
        
        Player val_2 = App.Player;
        if(val_2.properties.numSubscriptionsPurchased_Silver != 0)
        {
                return false;
        }
        
        Player val_3 = App.Player;
        if(val_3.properties.numTrialSubs_Silver != 0)
        {
                return false;
        }
        
        1152921504884269056 = DefaultHandler<SubscriptionHandler>.Instance;
        if(1152921504884269056 == 0)
        {
                return false;
        }
        
        return DefaultHandler<SubscriptionHandler>.Instance.freeTrialEnabledSilver;
    }
    public static bool get_WillGetFreeTrial()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        if(WGSubscriptionManager.WillGetFreeTrial_Golden == false)
        {
                return false;
        }
        
        return WGSubscriptionManager.WillGetFreeTrial_Silver;
    }
    public bool hasSubscription(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        return DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  subPackage);
    }
    public bool canCollectSubscription(SubscriptionHandler.SubScriptionType subPackage = 0)
    {
        return DefaultHandler<SubscriptionHandler>.Instance.CanCollect(subPackage:  subPackage);
    }
    public bool hasAnySubscription()
    {
        bool val_1 = this.hasSubscription(subPackage:  0);
        if(val_1 == false)
        {
                return val_1.hasSubscription(subPackage:  1);
        }
        
        return true;
    }
    public int promoDailyCoinsAmount(SubscriptionHandler.SubScriptionType subPackage)
    {
        int val_7;
        if((DefaultHandler<SubscriptionHandler>.Instance) != 0)
        {
            goto label_5;
        }
        
        label_17:
        val_7 = 0;
        return val_7;
        label_5:
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                SubscriptionHandler val_4 = DefaultHandler<SubscriptionHandler>.Instance;
            val_7 = val_4._dailyGemAmount;
            return val_7;
        }
        
        if(subPackage == 1)
        {
            goto label_16;
        }
        
        if(subPackage != 0)
        {
            goto label_17;
        }
        
        SubscriptionHandler val_5 = DefaultHandler<SubscriptionHandler>.Instance;
        val_7 = val_5._dailyCoinAmount;
        return val_7;
        label_16:
        SubscriptionHandler val_6 = DefaultHandler<SubscriptionHandler>.Instance;
        val_7 = val_6._dailyCoinAmountSilver;
        return val_7;
    }
    public string get_pointMultiplier()
    {
        SubscriptionHandler val_1 = DefaultHandler<SubscriptionHandler>.Instance;
        return (string)val_1._pointMultiplier.ToString();
    }
    public string get_pointXMoreMultiplier()
    {
        SubscriptionHandler val_1 = DefaultHandler<SubscriptionHandler>.Instance;
        float val_4 = val_1._pointMultiplier;
        val_4 = val_4 + (-1f);
        val_4 = val_4 * 100f;
        GameEcon val_2 = App.getGameEcon;
        return (string)val_4.ToString(format:  val_2.numberFormatInt);
    }
    public bool get_silverTicketUnlocked()
    {
        var val_6 = 1;
        if((this.hasSubscription(subPackage:  1)) == true)
        {
                return (bool)val_6 & 1;
        }
        
        GameBehavior val_2 = App.getBehavior;
        SubscriptionHandler val_3 = DefaultHandler<SubscriptionHandler>.Instance;
        bool val_4 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_2.<metaGameBehavior>k__BackingField, knobValue:  val_3._silverTicketUnlockLevel);
        if(val_4 != false)
        {
                val_6 = (val_4.hasSubscription(subPackage:  0)) ^ 1;
            return (bool)val_6 & 1;
        }
        
        val_6 = 0;
        return (bool)val_6 & 1;
    }
    public int freeTrialDaysCount(SubscriptionHandler.SubScriptionType subPackage)
    {
        int val_5;
        if((DefaultHandler<SubscriptionHandler>.Instance) == 0)
        {
            goto label_7;
        }
        
        if(subPackage == 1)
        {
            goto label_6;
        }
        
        if(subPackage == 0)
        {
                SubscriptionHandler val_3 = DefaultHandler<SubscriptionHandler>.Instance;
            val_5 = val_3._freeTrialDaysGolden;
            return (int)val_5;
        }
        
        label_7:
        val_5 = 0;
        return (int)val_5;
        label_6:
        SubscriptionHandler val_4 = DefaultHandler<SubscriptionHandler>.Instance;
        return (int)val_5;
    }
    public override void InitMonoSingleton()
    {
        var val_12;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        SubscriptionHandler val_2 = DefaultHandler<SubscriptionHandler>.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.onSubscriptionCollectAttempt, b:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSubscriptionManager::HandleCollectionResponse(System.Collections.Generic.Dictionary<string, object> response)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        val_2.onSubscriptionCollectAttempt = val_4;
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGSubscriptionManager::OnSceneChanged(SceneType type)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        val_5.OnSceneLoaded = val_7;
        if((val_7.hasSubscription(subPackage:  0)) != false)
        {
                if(WGSubscriptionManager.HasSubscribedGoldenTicket != true)
        {
                val_12 = 1;
            WGSubscriptionManager.HasSubscribedGoldenTicket = true;
        }
        
        }
        
        if((this.hasSubscription(subPackage:  1)) == false)
        {
                return;
        }
        
        if(WGSubscriptionManager.HasSubscribedSilverTicket != false)
        {
                return;
        }
        
        WGSubscriptionManager.HasSubscribedSilverTicket = true;
        return;
        label_15:
    }
    public static float GetInitialPriceForPackage(SubscriptionHandler.SubScriptionType subPack)
    {
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageBySubscriptionID(packageType:  "special", instruction:  subPack);
        if((val_1.Contains(key:  "initial")) == false)
        {
                return 0f;
        }
        
        return val_1.getFloat(key:  "initial", defaultValue:  0f);
    }
    public string GetInitialCostForPackage(SubscriptionHandler.SubScriptionType subPack)
    {
        return (string)WGSubscriptionManager.GetInitialPriceForPackage(subPack:  subPack).ToString(format:  "$0.00");
    }
    public string GetPromoCostForPackage(SubscriptionHandler.SubScriptionType subPack)
    {
        twelvegigs.storage.JsonDictionary val_1 = PackagesManager.GetPackageBySubscriptionID(packageType:  "special", instruction:  subPack);
        return (string)val_1.getString(key:  "regular_price", defaultValue:  val_1.getFloat(key:  "sale_price", defaultValue:  0f).ToString(format:  "$0.00"));
    }
    public void TryPurchase(SubscriptionHandler.SubScriptionType subPackage)
    {
        SubScriptionType val_25;
        var val_26;
        var val_27;
        string val_28;
        SubScriptionType val_29;
        float val_30;
        var val_32;
        System.Action val_34;
        val_25 = subPackage;
        SubscriptionHandler val_1 = DefaultHandler<SubscriptionHandler>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.onSubscriptionPurchaseComplete, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionManager::OnSubscriptionPurchaseAttempt(bool result)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.onSubscriptionPurchaseComplete = val_3;
        val_26 = null;
        val_26 = null;
        PurchaseProxy.currentPurchasePoint = WGSubscriptionManager._subEntryPoint;
        val_27 = 1152921504891084800;
        PurchaseModel val_5 = new PurchaseModel(json:  PackagesManager.GetPackageBySubscriptionID(packageType:  "special", instruction:  val_25));
        bool val_7 = (val_25 == 0) ? 1 : 0;
        val_7 = val_7 & WGSubscriptionManager.HasSubscribedGoldenTicket ^ 1;
        val_5.AddTrackingInfo(infoKey:  "1st GT Subscription", infoValue:  val_7);
        bool val_10 = (val_25 == 1) ? 1 : 0;
        val_28 = "1st ST Subscription";
        val_10 = val_10 & WGSubscriptionManager.HasSubscribedSilverTicket ^ 1;
        val_29 = val_5;
        val_5.AddTrackingInfo(infoKey:  val_28, infoValue:  val_10);
        if(val_25 == 0)
        {
                if(WGSubscriptionManager.HasSubscribedGoldenTicket != false)
        {
                val_30 = 0f;
            float val_14 = PackagesManager.GetPackageBySubscriptionID(packageType:  "special", instruction:  0).getFloat(key:  "sale_price", defaultValue:  val_30);
        }
        else
        {
                val_29 = 0;
        }
        
            .sale_price = WGSubscriptionManager.GetInitialPriceForPackage(subPack:  val_29);
        }
        
        if(val_25 == 1)
        {
                if(WGSubscriptionManager.HasSubscribedSilverTicket != false)
        {
                val_30 = 0f;
            float val_18 = PackagesManager.GetPackageBySubscriptionID(packageType:  "special", instruction:  1).getFloat(key:  "sale_price", defaultValue:  val_30);
        }
        
            .sale_price = WGSubscriptionManager.GetInitialPriceForPackage(subPack:  1);
        }
        
        if((PurchaseProxy.Purchase(purchase:  val_5)) == false)
        {
            goto label_29;
        }
        
        if(val_25 == 0)
        {
            goto label_30;
        }
        
        if(val_25 != 1)
        {
                return;
        }
        
        WGSubscriptionManager.HasSubscribedSilverTicket = true;
        return;
        label_29:
        val_25 = MonoSingletonSelfGenerating<WGStoreController>.Instance;
        val_28 = Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false);
        val_32 = null;
        val_32 = null;
        val_34 = WGSubscriptionManager.<>c.<>9__38_0;
        if(val_34 == null)
        {
                System.Action val_24 = null;
            val_34 = val_24;
            val_24 = new System.Action(object:  WGSubscriptionManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGSubscriptionManager.<>c::<TryPurchase>b__38_0());
            WGSubscriptionManager.<>c.<>9__38_0 = val_34;
        }
        
        val_25.HandlePurchaseFailed(title:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), message:  val_28, onCloseMessageAction:  val_24);
        return;
        label_30:
        WGSubscriptionManager.HasSubscribedGoldenTicket = true;
        return;
        label_5:
    }
    public void UITryCollect(SubscriptionHandler.SubScriptionType subPackage)
    {
        if((this.canCollectSubscription(subPackage:  subPackage)) != false)
        {
                DefaultHandler<SubscriptionHandler>.Instance.CollectSubscription(subPackage:  subPackage);
            return;
        }
        
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        this.onCollectAttemptResult.Invoke(arg1:  false, arg2:  3);
    }
    private void HandleCollectionResponse(System.Collections.Generic.Dictionary<string, object> response)
    {
        System.Collections.IDictionary val_12;
        var val_13;
        var val_15;
        collectResultStatus val_16;
        val_12 = response;
        if(val_12 == null)
        {
            goto label_1;
        }
        
        if((val_12.ContainsKey(key:  "success")) == false)
        {
            goto label_4;
        }
        
        twelvegigs.storage.JsonDictionary val_2 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  val_12);
        if((val_2.getBool(key:  "success")) == false)
        {
            goto label_4;
        }
        
        val_13 = 0;
        if((val_2.Contains(key:  "subscription")) == false)
        {
            goto label_29;
        }
        
        val_12 = (twelvegigs.storage.JsonDictionary)[1152921516455311408].dataSource;
        var val_13 = 0;
        val_13 = val_13 + 1;
        val_13 = 0;
        goto label_10;
        label_4:
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        val_15 = 1152921516455060448;
        val_16 = 2;
        goto label_14;
        label_1:
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        val_15 = 1152921516455060448;
        val_16 = 1;
        goto label_14;
        label_10:
        if(val_12.Item["subscription"] != null)
        {
                string val_8 = val_2.getJsonDictionary(key:  "subscription").getString(key:  "package_name", defaultValue:  "");
            val_12 = 1152921504884269056;
            AppConfigs val_9 = App.Configuration;
            if((val_8.Equals(value:  val_9.storeConfig.id_golden_ticket_subscription.sku)) != false)
        {
                this.CollectSub_Gold();
            return;
        }
        
            AppConfigs val_11 = App.Configuration;
            if((val_8.Equals(value:  val_11.storeConfig.id_silver_ticket_subscription.sku)) != false)
        {
                this.CollectSub_Silver();
            return;
        }
        
        }
        
        label_29:
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        val_15 = 1152921516455060448;
        val_16 = 4;
        label_14:
        this.onCollectAttemptResult.Invoke(arg1:  false, arg2:  val_16);
    }
    private void CollectSub_Gold()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Player val_2 = App.Player;
            val_2.AddGems(amount:  val_2.promoDailyCoinsAmount(subPackage:  0), source:  "Golden Ticket Daily Gems", subsource:  0);
            Player val_4 = App.Player;
            val_4.TrackNonCoinReward(source:  "Golden Ticket Subscription Daily Gems", subSource:  0, rewardType:  "Gems", rewardAmount:  val_4.promoDailyCoinsAmount(subPackage:  0).ToString(), additionalParams:  0);
        }
        else
        {
                Player val_7 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_7.promoDailyCoinsAmount(subPackage:  0));
            val_7.AddCredits(amount:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, source:  "Golden Ticket Daily Coins", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        this.onCollectAttemptResult.Invoke(arg1:  true, arg2:  0);
    }
    private void CollectSub_Silver()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Player val_2 = App.Player;
            val_2.AddGems(amount:  val_2.promoDailyCoinsAmount(subPackage:  1), source:  "Golden Ticket Daily Gems", subsource:  0);
            Player val_4 = App.Player;
            val_4.TrackNonCoinReward(source:  "Silver Ticket Subscription Daily Gems", subSource:  0, rewardType:  "Gems", rewardAmount:  val_4.promoDailyCoinsAmount(subPackage:  0).ToString(), additionalParams:  0);
        }
        else
        {
                Player val_7 = App.Player;
            decimal val_9 = System.Decimal.op_Implicit(value:  val_7.promoDailyCoinsAmount(subPackage:  1));
            val_7.AddCredits(amount:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, source:  "Silver Ticket Daily Coins", subSource:  0, externalParams:  0, doTrack:  true);
        }
        
        if(this.onCollectAttemptResult == null)
        {
                return;
        }
        
        this.onCollectAttemptResult.Invoke(arg1:  true, arg2:  0);
    }
    private void OnSubscriptionPurchaseAttempt(bool result)
    {
        SubscriptionHandler val_1 = DefaultHandler<SubscriptionHandler>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.onSubscriptionPurchaseComplete, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGSubscriptionManager::OnSubscriptionPurchaseAttempt(bool result)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.onSubscriptionPurchaseComplete = val_3;
        if(this.purchaseResult == null)
        {
                return;
        }
        
        this.purchaseResult.Invoke(obj:  result);
        return;
        label_5:
    }
    private void OnSceneChanged(SceneType type)
    {
        DefaultHandler<SubscriptionHandler>.Instance.UpdateOnSceneChanged();
    }
    public System.DateTime getNextCollectTime(SubscriptionHandler.SubScriptionType subPackage)
    {
        if((DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  subPackage)) != false)
        {
                System.DateTime val_5 = DefaultHandler<SubscriptionHandler>.Instance.getCurrentModel(subPackage:  subPackage).collectedTime;
            System.DateTime val_6 = val_5.dateData.AddDays(value:  1);
            return (System.DateTime)val_7.dateData;
        }
        
        UnityEngine.Debug.LogError(message:  "trying to get the time of a subscription when none is active..");
        System.DateTime val_7 = DateTimeCheat.UtcNow;
        return (System.DateTime)val_7.dateData;
    }
    public System.DateTime getSubscriptionStartTime(SubscriptionHandler.SubScriptionType subPackage)
    {
        if((DefaultHandler<SubscriptionHandler>.Instance.IsActive(subPackage:  subPackage)) != false)
        {
                return DefaultHandler<SubscriptionHandler>.Instance.getCurrentModel(subPackage:  subPackage).startTime;
        }
        
        UnityEngine.Debug.LogError(message:  "trying to get the time of a subscription when none is active..");
        return DateTimeCheat.UtcNow;
    }
    private void OnDestroy()
    {
        SubscriptionHandler val_1 = DefaultHandler<SubscriptionHandler>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.onSubscriptionCollectAttempt, value:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WGSubscriptionManager::HandleCollectionResponse(System.Collections.Generic.Dictionary<string, object> response)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_1.onSubscriptionCollectAttempt = val_3;
        SceneDictator val_4 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_6 = System.Delegate.Remove(source:  val_4.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void WGSubscriptionManager::OnSceneChanged(SceneType type)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_4.OnSceneLoaded = val_6;
        return;
        label_10:
    }
    public WGSubscriptionManager()
    {
    
    }

}

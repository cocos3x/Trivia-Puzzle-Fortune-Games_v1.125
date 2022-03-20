using UnityEngine;
public class FeaturedOfferManager : MonoSingleton<FeaturedOfferManager>
{
    // Fields
    private const string pref_last_offer_purchase = "fo_l_p";
    public static int MinimumPurchases;
    public static int PostPurchaseDelayDays;
    public static int PurchasePercent;
    public static int BonusCoinsPercent;
    private FeaturedOfferStoreItem _prefab_featured_store_item;
    private FeaturedOfferStoreItem storeItemInstance;
    private string debugLog;
    private System.DateTime _LastOfferPurchaseTime;
    
    // Properties
    public static int PostPurchaseDelayHours { get; }
    public static float PurchasePercentage { get; }
    public static decimal BonusCoinPercentage { get; }
    private FeaturedOfferStoreItem Prefab_featured_store_item { get; }
    public System.DateTime LastOfferPurchaseTime { get; set; }
    
    // Methods
    public static int get_PostPurchaseDelayHours()
    {
        null = null;
        int val_2 = FeaturedOfferManager.PostPurchaseDelayDays;
        val_2 = val_2 + (val_2 << 1);
        return (int)val_2 << 3;
    }
    public static float get_PurchasePercentage()
    {
        null = null;
        float val_1 = (float)FeaturedOfferManager.PurchasePercent;
        val_1 = val_1 / 100f;
        return (float)val_1;
    }
    public static decimal get_BonusCoinPercentage()
    {
        null = null;
        decimal val_1 = System.Decimal.op_Implicit(value:  FeaturedOfferManager.BonusCoinsPercent);
        decimal val_2 = new System.Decimal(value:  100);
        decimal val_3 = System.Decimal.op_Division(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.flags, lo = val_2.lo, mid = val_2.lo});
        return new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid};
    }
    private FeaturedOfferStoreItem get_Prefab_featured_store_item()
    {
        FeaturedOfferStoreItem val_3;
        if(this._prefab_featured_store_item == 0)
        {
                this._prefab_featured_store_item = PrefabLoader.LoadPrefab<FeaturedOfferStoreItem>(featureName:  "Store");
            return val_3;
        }
        
        val_3 = this._prefab_featured_store_item;
        return val_3;
    }
    public System.DateTime get_LastOfferPurchaseTime()
    {
        var val_6;
        var val_7;
        val_6 = null;
        val_6 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this._LastOfferPurchaseTime}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) == false)
        {
                return (System.DateTime)this._LastOfferPurchaseTime;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "fo_l_p")) == false)
        {
                return (System.DateTime)this._LastOfferPurchaseTime;
        }
        
        val_7 = null;
        val_7 = null;
        System.DateTime val_5 = SLCDateTime.Parse(dateTime:  UnityEngine.PlayerPrefs.GetString(key:  "fo_l_p", defaultValue:  System.DateTime.MinValue.ToString()));
        this._LastOfferPurchaseTime = val_5;
        return (System.DateTime)this._LastOfferPurchaseTime;
    }
    public void set_LastOfferPurchaseTime(System.DateTime value)
    {
        this._LastOfferPurchaseTime = value;
        UnityEngine.PlayerPrefs.SetString(key:  "fo_l_p", value:  this._LastOfferPurchaseTime.ToString());
    }
    public override void InitMonoSingleton()
    {
        var val_9;
        var val_10;
        this.InitMonoSingleton();
        val_9 = null;
        val_9 = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  GameStoreUI.OnCreatePackItems, b:  new System.Action(object:  this, method:  System.Void FeaturedOfferManager::OnCreatePackItems()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        GameStoreUI.OnCreatePackItems = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  GameStoreUI.OnRefreshDisplay, b:  new System.Action(object:  this, method:  System.Void FeaturedOfferManager::OnRefreshDisplay()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        GameStoreUI.OnRefreshDisplay = val_4;
        val_10 = null;
        val_10 = null;
        System.Delegate val_6 = System.Delegate.Combine(a:  PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS, b:  new PostProcessPurchaseDelegate(object:  this, method:  System.Void FeaturedOfferManager::OnProcessPurchase(ref PurchaseModel purchase)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        PurchasesHandler.ON_RESTORE_TRANSACTIONS_SUCCESS = val_6;
        System.Delegate val_8 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void FeaturedOfferManager::OnPurchaseCompleted(PurchaseModel purchased)));
        if(val_8 != null)
        {
                if(null != null)
        {
            goto label_12;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_8;
        this.LogDebug(text:  "initialized.", color:  "#FFFFFF");
        return;
        label_12:
    }
    public string GetDebugLog()
    {
        return (string)this.debugLog;
    }
    private void OnRefreshDisplay()
    {
        var val_24;
        if(this.DetermineFeaturedOfferPack() == null)
        {
                return;
        }
        
        if(this.storeItemInstance == 0)
        {
                GameStoreCategory val_5 = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
            FeaturedOfferStoreItem val_8 = UnityEngine.Object.Instantiate<FeaturedOfferStoreItem>(original:  this.Prefab_featured_store_item, parent:  val_5.XfmPackageContents);
            this.storeItemInstance = val_8;
            val_8.transform.SetSiblingIndex(index:  val_5.GetFirstAvailableSiblingIndex());
        }
        
        this.storeItemInstance.gameObject.SetActive(value:  true);
        int val_13 = MonoSingleton<GameStoreUI>.Instance.GetStoreItemIndex(packId:  val_1.id);
        int val_15 = MonoSingleton<GameStoreUI>.Instance.CoinPackItemsCount;
        GameStoreUI val_16 = MonoSingleton<GameStoreUI>.Instance;
        val_24 = ???;
        goto typeof(FeaturedOfferStoreItem).__il2cppRuntimeField_1A0;
    }
    private void OnCreatePackItems()
    {
        var val_19;
        if(this.DetermineFeaturedOfferPack() == null)
        {
                return;
        }
        
        GameStoreCategory val_4 = MonoSingleton<GameStoreUI>.Instance.GetOrCreateCategory(categoryTitle:  Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false), showTitle:  true, siblingIndex:  0);
        FeaturedOfferStoreItem val_7 = UnityEngine.Object.Instantiate<FeaturedOfferStoreItem>(original:  this.Prefab_featured_store_item, parent:  val_4.XfmPackageContents);
        this.storeItemInstance = val_7;
        val_7.transform.SetSiblingIndex(index:  val_4.GetFirstAvailableSiblingIndex());
        GameStoreUI val_10 = MonoSingleton<GameStoreUI>.Instance;
        val_19 = ???;
        goto typeof(FeaturedOfferStoreItem).__il2cppRuntimeField_1A0;
    }
    private PurchaseModel DetermineFeaturedOfferPack()
    {
        var val_34;
        var val_35;
        var val_36;
        System.Predicate<PurchaseModel> val_38;
        var val_40;
        var val_41;
        string val_43;
        var val_44;
        Player val_1 = App.Player;
        val_34 = null;
        val_34 = null;
        if(val_1.num_purchase < FeaturedOfferManager.MinimumPurchases)
        {
                return 0;
        }
        
        Player val_2 = App.Player;
        if(val_2.lastItemPrice <= 0f)
        {
                return 0;
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        System.DateTime val_4 = this.LastOfferPurchaseTime;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = val_4.dateData});
        val_35 = null;
        int val_7 = FeaturedOfferManager.PostPurchaseDelayHours;
        if(val_5._ticks.TotalHours < 0)
        {
                return 0;
        }
        
        Player val_8 = App.Player;
        Player val_9 = App.Player;
        float val_11 = (val_8.transactionsAverageAmount ?? val_9.lastItemPrice) / val_9.lastItemPrice;
        this.LogDebug(text:  "Determining Featured Offer Pack...", color:  "#A4DE51");
        object[] val_12 = new object[4];
        val_12[0] = val_11;
        val_12[1] = val_8.transactionsAverageAmount;
        val_12[2] = val_9.lastItemPrice;
        val_12[3] = val_9.lastItemPrice;
        this.LogDebug(text:  System.String.Format(format:  "percentDifference {0} = Abs(averagePrice {1} - lastPurchasePrice {2}) / lastPurchasePrice {3} ...", args:  val_12), color:  "#97CE71");
        val_36 = null;
        val_36 = null;
        val_38 = FeaturedOfferManager.<>c.<>9__24_0;
        if(val_38 == null)
        {
                System.Predicate<PurchaseModel> val_16 = null;
            val_38 = val_16;
            val_16 = new System.Predicate<PurchaseModel>(object:  FeaturedOfferManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FeaturedOfferManager.<>c::<DetermineFeaturedOfferPack>b__24_0(PurchaseModel p));
            FeaturedOfferManager.<>c.<>9__24_0 = val_38;
        }
        
        float val_18 = FeaturedOfferManager.PurchasePercentage;
        if(val_11 >= 0)
        {
            goto label_48;
        }
        
        this.LogDebug(text:  System.String.Format(format:  "percentDifference {0} is less than PurchasePercentage {1}...", arg0:  val_11, arg1:  FeaturedOfferManager.PurchasePercentage), color:  "#50D697");
        this.LogDebug(text:  System.String.Format(format:  "finding next pack higher than lastPurchasePrice {0}...", arg0:  val_9.lastItemPrice), color:  "#50D697");
        if("finding next pack higher than lastPurchasePrice {0}..." < 1)
        {
            goto label_77;
        }
        
        var val_34 = 0;
        if("finding next pack higher than lastPurchasePrice {0}..." <= val_34)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_40 = mem[("finding next pack higher than lastPurchasePrice {0}...".__il2cppRuntimeField_20 + 0) + 32];
        val_40 = ("finding next pack higher than lastPurchasePrice {0}...".__il2cppRuntimeField_20 + 0) + 32;
        if((UnityEngine.Mathf.Approximately(a:  ("finding next pack higher than lastPurchasePrice {0}...".__il2cppRuntimeField_20 + 0) + 32 + 112, b:  val_9.lastItemPrice)) == false)
        {
            goto label_60;
        }
        
        val_34 = val_34 + 1;
        label_77:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_41 = mem[(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished - 1)) << 3) + 32];
        val_41 = (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished - 1)) << 3) + 32;
        val_41.AddTrackingInfo(infoKey:  "Feature Offer Determined", infoValue:  "Next Higher");
        val_43 = "Determined to show {0} pack!";
        goto label_64;
        label_48:
        this.LogDebug(text:  System.String.Format(format:  "percentDifference {0} is greater than or equal to PurchasePercentage {1}...", arg0:  val_11, arg1:  FeaturedOfferManager.PurchasePercentage), color:  "#7AEDD7");
        float val_27 = UnityEngine.Mathf.Max(a:  val_8.transactionsAverageAmount, b:  val_9.lastItemPrice);
        PurchaseModel val_28 = this.GetPackageNearestToPrice(priceToCompare:  val_27, availablePacks:  MonoSingletonSelfGenerating<WGStoreController>.Instance.RetrievePurchasePacks().FindAll(match:  val_16));
        val_41 = val_28;
        val_28.AddTrackingInfo(infoKey:  "Feature Offer Determined", infoValue:  "Current Highest");
        this.LogDebug(text:  System.String.Format(format:  "Higher value between avg {0} and last {1} = {2}. Finding nearest pack to the high value...", arg0:  val_8.transactionsAverageAmount, arg1:  val_9.lastItemPrice, arg2:  val_27), color:  "#7AEDD7");
        val_43 = "Determined to show {0}!";
        label_64:
        this.LogDebug(text:  System.String.Format(format:  val_43, arg0:  val_28.sale_price), color:  "#52EBF7");
        decimal val_31 = val_41.Credits;
        val_44 = null;
        decimal val_32 = FeaturedOfferManager.BonusCoinPercentage;
        decimal val_33 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_31.flags, hi = val_31.hi, lo = val_31.lo, mid = val_31.mid}, d2:  new System.Decimal() {flags = val_32.flags, hi = val_32.hi, lo = val_32.lo, mid = val_32.mid});
        val_41.AddReward(rewardType:  "credits", amount:  new System.Decimal() {flags = val_33.flags, hi = val_33.hi, lo = val_33.lo, mid = val_33.mid});
        val_41.AddInstruction(instruction:  1);
        return 0;
        label_60:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        goto label_77;
    }
    private void OnProcessPurchase(ref PurchaseModel purchase)
    {
    
    }
    private void OnPurchaseCompleted(PurchaseModel purchased)
    {
        if((purchased.ContainsInstruction(instruction:  1)) == false)
        {
                return;
        }
        
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        this.LastOfferPurchaseTime = new System.DateTime() {dateData = val_2.dateData};
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private PurchaseModel GetPackageNearestToPrice(float priceToCompare, System.Collections.Generic.List<PurchaseModel> availablePacks)
    {
        var val_3;
        bool val_3 = true;
        if(val_3 < 1)
        {
            goto label_2;
        }
        
        if(val_3 <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 8;
        priceToCompare = priceToCompare ?? ((true + 8) + 32 + 112);
        if(priceToCompare >= 0)
        {
            goto label_7;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_3 = 0 + 1;
        var val_1 = 0 + 2;
        float val_2 = priceToCompare - ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 8) + 32 + 112);
        goto label_12;
        label_2:
        val_3 = 0;
        goto label_12;
        label_7:
        val_3 = 0;
        label_12:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        return (PurchaseModel)(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32;
    }
    private void LogDebug(string text, string color = "#FFFFFF")
    {
        this.debugLog = this.debugLog + System.String.Format(format:  "{0}s: <color={1}>{2}</color>\n", arg0:  UnityEngine.Time.time.ToString(format:  "0000.00"), arg1:  color, arg2:  text)(System.String.Format(format:  "{0}s: <color={1}>{2}</color>\n", arg0:  UnityEngine.Time.time.ToString(format:  "0000.00"), arg1:  color, arg2:  text));
    }
    public FeaturedOfferManager()
    {
        var val_1;
        this.debugLog = "<b>~Featured Offer Log Begin~</b>\n";
        val_1 = null;
        val_1 = null;
        this._LastOfferPurchaseTime = System.DateTime.MinValue;
    }
    private static FeaturedOfferManager()
    {
        FeaturedOfferManager.MinimumPurchases = 2;
        FeaturedOfferManager.PostPurchaseDelayDays = 3;
        FeaturedOfferManager.PurchasePercent = 20;
        FeaturedOfferManager.BonusCoinsPercent = 10;
    }

}

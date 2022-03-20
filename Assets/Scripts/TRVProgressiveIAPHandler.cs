using UnityEngine;
public class TRVProgressiveIAPHandler : WGEventHandler
{
    // Fields
    private static TRVProgressiveIAPHandler _Instance;
    public const string EVENT_ID = "ProgressiveIapSale";
    public const string EVENT_TRACKING_ID = "TRVProgressiveIAP";
    public const string BONUS_MULTIPLIER = "BonusMulti";
    private string packagePrefix;
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    public static TrackerPurchasePoints purchasePoint;
    protected int[] levelRq;
    protected int playerProgress;
    protected bool purchased;
    private PurchaseModel currentModel;
    private int lastCheckedPurcahseModel;
    public System.Action<bool> OnPurchaseAttemptResult;
    
    // Properties
    public static TRVProgressiveIAPHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public int[] getLevelReq { get; }
    public int getPlayerProgress { get; }
    protected static int LastProgressTimestampPref { get; set; }
    public override bool IsEventHidden { get; }
    
    // Methods
    public static TRVProgressiveIAPHandler get_Instance()
    {
        return (TRVProgressiveIAPHandler)TRVProgressiveIAPHandler.BONUS_MULTIPLIER;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public int[] get_getLevelReq()
    {
        return (System.Int32[])this.levelRq;
    }
    public int get_getPlayerProgress()
    {
        return (int)this.playerProgress;
    }
    protected static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "youBet_prog_ts", defaultValue:  0);
    }
    protected static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "youBet_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517175296176] = eventV2;
        bool val_1 = this.ParseEventData(eventData:  eventV2.eventData);
        TRVProgressiveIAPHandler.BONUS_MULTIPLIER = this;
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
            return;
        }
        
        this.LoadPersistantData();
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "ProgressiveIapSale")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "ProgressiveIapSale"));
        if(val_3 == null)
        {
                return true;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        return true;
    }
    private void GenerateNewData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "id", value:  System.Void System.Runtime.Serialization.Formatters.Binary.SizedArray::IncreaseCapacity(int index));
        val_1.Add(key:  "playerProgress", value:  0);
        val_1.Add(key:  "purchased", value:  null);
        CPlayerPrefs.SetString(key:  "ProgressiveIapSale", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    protected virtual void GenerateExtraNewData(ref System.Collections.Generic.Dictionary<string, object> eventDataToSave)
    {
    
    }
    private void LoadPersistantData()
    {
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "ProgressiveIapSale"));
        if(val_2 != null)
        {
                this.myEventData = val_2;
            if((val_2.ContainsKey(key:  "playerProgress")) != false)
        {
                bool val_6 = System.Int32.TryParse(s:  this.myEventData.Item["playerProgress"], result: out  this.playerProgress);
        }
        
            if((this.myEventData.ContainsKey(key:  "purchased")) != false)
        {
                bool val_10 = System.Boolean.TryParse(value:  this.myEventData.Item["purchased"], result: out  this.purchased);
        }
        
            this = ???;
        }
        else
        {
                mem2[0] = 0;
            throw new NullReferenceException();
        }
    
    }
    protected virtual void LoadExtraPersistentData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
    
    }
    protected void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "playerProgress", newValue:  this.playerProgress);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "purchased", newValue:  this.purchased);
        CPlayerPrefs.SetString(key:  "ProgressiveIapSale", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    protected virtual void SaveExtraData(ref System.Collections.Generic.Dictionary<string, object> myEventData)
    {
    
    }
    private bool ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_9;
        var val_10;
        if(eventData == null)
        {
            goto label_16;
        }
        
        val_10 = eventData;
        if(val_10.Count == 0)
        {
            goto label_20;
        }
        
        val_9 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
            goto label_16;
        }
        
        val_9 = eventData.Item["economy"];
        if((val_9.ContainsKey(key:  "req_lvls")) == false)
        {
            goto label_20;
        }
        
        object val_5 = val_9.Item["req_lvls"];
        if(val_5 == null)
        {
            goto label_20;
        }
        
        val_9 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_5) : 0;
        label_16:
        val_10 = 0;
        label_20:
        val_10 = val_10 & 1;
        return (bool)val_10;
    }
    protected virtual bool ParseExtraDataKnobs(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        return true;
    }
    public override void OnPurchaseFailure(PurchaseModel purchase)
    {
        if((purchase.id.Contains(value:  "progressive_sale")) == false)
        {
                return;
        }
        
        this.OnPurchaseFail();
    }
    public override void OnPurchaseCompleted(PurchaseModel purchase)
    {
        this.SaveData();
        if((purchase.id.Contains(value:  "progressive_sale")) == false)
        {
                return;
        }
        
        this.OnPurchaseSuccess();
    }
    public override bool EventCompleted()
    {
        return (bool)this.purchased;
    }
    public override bool get_IsEventHidden()
    {
        bool val_2;
        if((this.GetCurrentPurchaseModel(tierOverride:  0)) != null)
        {
                val_2 = this.purchased;
            return (bool)val_2;
        }
        
        val_2 = 1;
        return (bool)val_2;
    }
    public override void OnCategoryComplete()
    {
        int val_2 = this.playerProgress;
        val_2 = val_2 + 1;
        this.playerProgress = val_2;
        this.SaveData();
        PurchaseModel val_1 = this.GetCurrentPurchaseModel(tierOverride:  0);
    }
    public override void OnLevelCompleteRewardAnimFinished()
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.playerProgress > (System.Linq.Enumerable.Sum(source:  this.levelRq)))
        {
                return;
        }
        
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        if(val_2.currentGame.successfullyCompletedQuiz == false)
        {
                return;
        }
        
        if(this.playerProgress == 0)
        {
                return;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_4.<metaGameBehavior>k__BackingField.Init();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "get_more_sale_upper", defaultValue:  "\"GET MORE\" SALE", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        float val_9 = 100f;
        val_9 = (this.GetCurrentJsonDictionary(tier:  0).getFloat(key:  "BonusMulti", defaultValue:  0f)) * val_9;
        return (string)System.String.Format(format:  "{0}{1}{2}", arg0:  Localization.Localize(key:  "get_more_sale_upper", defaultValue:  "\"GET MORE\" SALE", useSingularKey:  false), arg1:  System.Environment.NewLine, arg2:  System.String.Format(format:  Localization.Localize(key:  "#_pct_free_upper_exc", defaultValue:  "{0}% FREE!", useSingularKey:  false), arg0:  UnityEngine.Mathf.FloorToInt(f:  val_9)));
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVProgressiveIAPPopup MetaGameBehavior::ShowUGUIMonolith<TRVProgressiveIAPPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void OnGameButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVProgressiveIAPPopup MetaGameBehavior::ShowUGUIMonolith<TRVProgressiveIAPPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void UpdateProgress()
    {
        TRVProgressiveIAPHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentProgressiveIAP val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentProgressiveIAP>(allowMultiple:  false);
    }
    public override string GetMainMenuButtonText()
    {
        goto typeof(TRVProgressiveIAPHandler).__il2cppRuntimeField_340;
    }
    public override string EventContentItemButtonText()
    {
        return Localization.Localize(key:  "view_sale_upper", defaultValue:  "VIEW SALE", useSingularKey:  false);
    }
    public bool SupportsGems()
    {
        return this.GetCurrentJsonDictionary(tier:  1).Contains(key:  "gems");
    }
    public twelvegigs.storage.JsonDictionary GetCurrentJsonDictionary(int tier = -1)
    {
        TRVProgressiveIAPHandler val_4;
        var val_5;
        val_4 = this;
        if((tier & 2147483648) != 0)
        {
            goto label_1;
        }
        
        if(tier == 0)
        {
            goto label_2;
        }
        
        label_7:
        val_4 = System.String.Format(format:  "{0}{1}", arg0:  this.packagePrefix, arg1:  val_4);
        twelvegigs.storage.JsonDictionary val_2 = PackagesManager.GetPackageById(packageId:  val_4);
        return (twelvegigs.storage.JsonDictionary)val_5;
        label_1:
        if((this.GetCurrentTier(calculatedProgress:  this.playerProgress)) != 0)
        {
            goto label_7;
        }
        
        label_2:
        val_5 = 0;
        return (twelvegigs.storage.JsonDictionary)val_5;
    }
    public PurchaseModel GetCurrentPurchaseModel(int tierOverride = -1)
    {
        PurchaseModel val_3;
        if(this.lastCheckedPurcahseModel == this.playerProgress)
        {
                val_3 = this.currentModel;
            return (PurchaseModel)val_3;
        }
        
        twelvegigs.storage.JsonDictionary val_1 = this.GetCurrentJsonDictionary(tier:  0);
        if(val_1 != null)
        {
                PurchaseModel val_2 = null;
            val_3 = val_2;
            val_2 = new PurchaseModel(json:  val_1);
            this.currentModel = val_3;
            this.lastCheckedPurcahseModel = this.playerProgress;
            return (PurchaseModel)val_3;
        }
        
        val_3 = 0;
        return (PurchaseModel)val_3;
    }
    public int GetCurrentTierProgress(int calculatedProgress)
    {
        var val_4;
        if((this.GetCurrentTier(calculatedProgress:  calculatedProgress)) != 0)
        {
                if((this.levelRq.Length << 32) >= 1)
        {
                var val_4 = 0;
            do
        {
            val_4 = val_4 + 1;
            val_4 = calculatedProgress - ((0 > calculatedProgress) ? 0 : (null));
        }
        while(val_4 < (long)this.levelRq.Length);
        
            return (int)val_4;
        }
        
        }
        
        val_4 = calculatedProgress;
        return (int)val_4;
    }
    public int GetCurrentTierRequirement(int calculatedProgress)
    {
        return (int)this.levelRq[System.Math.Min(val1:  this.GetCurrentTier(calculatedProgress:  calculatedProgress), val2:  this.levelRq.Length - 1)];
    }
    public int GetCurrentTier(int calculatedProgress)
    {
        var val_3;
        if((this.levelRq.Length << 32) >= 1)
        {
                var val_3 = 0;
            do
        {
            val_3 = val_3 + 1;
            var val_2 = (0 > calculatedProgress) ? 0 : (val_3);
        }
        while(val_3 < (long)this.levelRq.Length);
        
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public void TryPurchase()
    {
        null = null;
        PurchaseProxy.currentPurchasePoint = TRVProgressiveIAPHandler.purchasePoint;
        bool val_2 = PurchaseProxy.Purchase(purchase:  this.GetCurrentPurchaseModel(tierOverride:  0));
    }
    public void OnPurchaseSuccess()
    {
        this.OnPurchaseAttemptResult.Invoke(obj:  true);
        this.purchased = true;
        this.SaveData();
    }
    private void TrackPurchaseMade()
    {
    
    }
    public void OnPurchaseFail()
    {
        this.OnPurchaseAttemptResult.Invoke(obj:  false);
    }
    public virtual void ShowSalePopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVProgressiveIAPPopup MetaGameBehavior::ShowUGUIFlyOut<TRVProgressiveIAPPopup>().__il2cppRuntimeField_48) << 4) + 312];
    }
    protected virtual int GetCurrentTierIAPIndex(int tier)
    {
        return (int)tier;
    }
    public TRVProgressiveIAPHandler()
    {
        this.lastCheckedPurcahseModel = 0;
        this.packagePrefix = "progressive_sale_";
    }

}

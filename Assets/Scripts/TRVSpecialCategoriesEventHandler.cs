using UnityEngine;
public class TRVSpecialCategoriesEventHandler : WGEventHandler
{
    // Fields
    private static TRVSpecialCategoriesEventHandler _Instance;
    public const string SPECIAL_CATEGORIES_EVENT_ID = "SpecialCategories";
    public const string EVENT_TRACKING_ID = "Special Categories";
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private System.Collections.Generic.Dictionary<int, int> tierRewards;
    private System.Collections.Generic.Dictionary<int, int> quizLength;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<object>> quizDifficulties;
    private string eventCatergory;
    private int quizProgress;
    private int lastCollectedReward;
    
    // Properties
    public static TRVSpecialCategoriesEventHandler Instance { get; }
    public override int getPriorityWeight { get; }
    public GameEventV2 getEvent { get; }
    public string getEventCategory { get; }
    public int getQuizProgress { get; }
    public System.Collections.Generic.Dictionary<int, int> getTierRewards { get; }
    private static int LastProgressTimestampPref { get; set; }
    public override bool IsEventHidden { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static TRVSpecialCategoriesEventHandler get_Instance()
    {
        return (TRVSpecialCategoriesEventHandler)TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID;
    }
    public override int get_getPriorityWeight()
    {
        return 1;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public string get_getEventCategory()
    {
        return (string)this.eventCatergory;
    }
    public int get_getQuizProgress()
    {
        return (int)this.quizProgress;
    }
    public System.Collections.Generic.Dictionary<int, int> get_getTierRewards()
    {
        return (System.Collections.Generic.Dictionary<System.Int32, System.Int32>)this.tierRewards;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "specCat_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "specCat_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517378688736] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        TRVSpecialCategoriesEventHandler.EVENT_TRACKING_ID = this;
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
            return;
        }
        
        this.LoadPersistantData();
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "SpecialCategories")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "SpecialCategories"));
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
        val_1.Add(key:  "prog", value:  0);
        val_1.Add(key:  "rew", value:  null);
        val_1.Add(key:  "lcr", value:  0);
        CPlayerPrefs.SetString(key:  "SpecialCategories", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
        TRVDataParser val_3 = MonoSingleton<TRVDataParser>.Instance;
        val_3.<playerPersistance>k__BackingField.ResetSubCat(subcat:  this.eventCatergory);
    }
    private void LoadPersistantData()
    {
        var val_6;
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "SpecialCategories"));
        val_6 = 0;
        this.myEventData = ;
        object val_4 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "prog", defaultValue:  0);
        this.quizProgress = null;
        object val_5 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "lcr", defaultValue:  0);
        this.lastCollectedReward = null;
    }
    private void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "prog", newValue:  this.quizProgress);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lcr", newValue:  this.lastCollectedReward);
        CPlayerPrefs.SetString(key:  "SpecialCategories", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        string val_20;
        var val_21;
        var val_52;
        string val_53;
        string val_54;
        var val_55;
        var val_56;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        val_52 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = eventData.Item["economy"];
        if(val_3 == null)
        {
                return;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        return;
        label_40:
        if(val_21.MoveNext() == false)
        {
            goto label_32;
        }
        
        int val_23 = 0;
        if((System.Int32.TryParse(s:  val_20, result: out  val_23)) == false)
        {
            goto label_35;
        }
        
        val_53 = val_20;
        object val_25 = Item[val_53];
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_25, result: out  val_23)) == false)
        {
            goto label_35;
        }
        
        val_54 = this.tierRewards;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        val_54.Add(key:  0, value:  0);
        goto label_40;
        label_35:
        UnityEngine.Debug.LogError(message:  "Error parsing special categories knob data");
        goto label_40;
        label_32:
        val_21.Dispose();
        if((ContainsKey(key:  "quiz_len")) == false)
        {
                return;
        }
        
        this.quizLength = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        val_53 = "quiz_len";
        object val_29 = Item[val_53];
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Object>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_30 = val_29.Keys;
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_31 = val_30.GetEnumerator();
        label_54:
        if(val_21.MoveNext() == false)
        {
            goto label_46;
        }
        
        int val_33 = 0;
        if((System.Int32.TryParse(s:  val_20, result: out  val_33)) == false)
        {
            goto label_49;
        }
        
        val_53 = val_20;
        object val_35 = val_29.Item[val_53];
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Int32.TryParse(s:  val_35, result: out  val_33)) == false)
        {
            goto label_49;
        }
        
        val_54 = this.quizLength;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        val_54.Add(key:  0, value:  0);
        goto label_54;
        label_49:
        UnityEngine.Debug.LogError(message:  "Error parsing special categories knob data");
        goto label_54;
        label_46:
        val_21.Dispose();
        if((ContainsKey(key:  "diff")) == false)
        {
                return;
        }
        
        object val_38 = Item["diff"];
        val_55 = 0;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Object>> val_40 = null;
        val_53 = public System.Void System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Object>>::.ctor();
        val_40 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Object>>();
        this.quizDifficulties = val_40;
        val_53 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Object>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_41 = Keys;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_42 = val_41.GetEnumerator();
        label_72:
        if(val_21.MoveNext() == false)
        {
            goto label_61;
        }
        
        object val_44 = Item[val_20];
        val_56 = 0;
        if(((System.Int32.TryParse(s:  val_20, result: out  0)) ^ 1) == true)
        {
            goto label_67;
        }
        
        this.quizDifficulties.Add(key:  0, value:  null);
        goto label_72;
        label_67:
        UnityEngine.Debug.LogError(message:  "error parsing special categories knobs data");
        goto label_72;
        label_61:
        val_21.Dispose();
        if((eventData.ContainsKey(key:  "category")) != false)
        {
                val_53 = "category";
            object val_50 = eventData.Item[val_53];
            if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
            this.eventCatergory = val_50;
            return;
        }
        
        this.eventCatergory = "Queen";
        UnityEngine.Debug.LogError(message:  "NO CATEGORY DEFINED FOR SPECIAL CATEGORIES EVENT! ABORT ABORT!");
    }
    public int GetQuizLength()
    {
        int val_3;
        var val_4;
        var val_9;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.quizLength.Keys.GetEnumerator();
        val_9 = 3;
        goto label_3;
        label_5:
        if(this.quizLength == null)
        {
                throw new NullReferenceException();
        }
        
        label_3:
        if(val_4.MoveNext() == true)
        {
            goto label_5;
        }
        
        val_4.Dispose();
        return (int)UnityEngine.Mathf.Max(a:  3, b:  (this.quizProgress < this.quizLength.Item[val_3]) ? (val_9) : (val_3));
    }
    public string GetEventPrimaryCategory()
    {
        return "SpecialCategory";
    }
    public TRVCategorySelectionInfo GetEventSubCategory()
    {
        .categoryName = this.eventCatergory;
        return (TRVCategorySelectionInfo)new TRVCategorySelectionInfo();
    }
    public int GetQuestionDifficulty(int quizProgress)
    {
        var val_4;
        var val_5;
        var val_12;
        int val_13;
        var val_14;
        var val_15;
        val_12 = this;
        int val_1 = this.GetQuizLength();
        if(this.quizDifficulties == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Object>>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_2 = this.quizDifficulties.Keys;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = val_2.GetEnumerator();
        val_14 = 0;
        goto label_4;
        label_6:
        if(val_4 == val_1)
        {
                val_14 = this.quizDifficulties.Item[val_1];
        }
        
        label_4:
        if(val_5.MoveNext() == true)
        {
            goto label_6;
        }
        
        var val_11 = 1152921517380171344;
        val_13 = public System.Void Dictionary.KeyCollection.Enumerator<System.Int32, System.Collections.Generic.List<System.Object>>::Dispose();
        val_5.Dispose();
        if(val_14 == null)
        {
                if(this.quizDifficulties == null)
        {
                throw new NullReferenceException();
        }
        
            val_13 = System.Linq.Enumerable.Max(source:  this.quizDifficulties.Keys);
            System.Collections.Generic.List<System.Object> val_10 = this.quizDifficulties.Item[val_13];
            val_14 = val_10;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_11 > quizProgress)
        {
                if(val_11 <= quizProgress)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_11 = val_11 + (quizProgress << 3);
            val_12 = mem[(1152921517380171344 + (quizProgress) << 3) + 32];
            val_12 = (1152921517380171344 + (quizProgress) << 3) + 32;
            if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_13 = null;
            val_15 = mem[(1152921517380171344 + (quizProgress) << 3) + 32];
            val_15 = val_12;
            return (int)val_15;
        }
        
        UnityEngine.Debug.LogError(message:  "Requesting a special categories quiz out of difficulty array bounds, defaulting to diff 0");
        val_15 = 0;
        return (int)val_15;
    }
    public override TRVQuizProgress GetCustomQuizLevel(TRVSubCategoryData data)
    {
        return (TRVQuizProgress)new TRVSpecialCategoriesQuiz(quizCategoryData:  data, isPromo:  false);
    }
    public int getCurrentReward()
    {
        if((this.tierRewards.ContainsKey(key:  this.quizProgress)) == false)
        {
                return 0;
        }
        
        return this.tierRewards.Item[this.quizProgress];
    }
    public void CollectReward()
    {
        var val_4;
        object val_5;
        object val_12;
        int val_1 = this.getCurrentReward();
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.tierRewards.Keys.GetEnumerator();
        val_12 = 1;
        goto label_3;
        label_5:
        if(val_4 == this.quizProgress)
        {
            goto label_4;
        }
        
        val_12 = 2;
        label_3:
        if(val_5.MoveNext() == true)
        {
            goto label_5;
        }
        
        label_4:
        val_5.Dispose();
        val_5 = val_12;
        App.Player.AddGems(amount:  val_1, source:  System.String.Format(format:  "Special Category Tier {0}", arg0:  val_5), subsource:  0);
        App.Player.TrackNonCoinReward(source:  System.String.Format(format:  "Special Category Tier {0}", arg0:  val_12), subSource:  0, rewardType:  "Gems", rewardAmount:  val_1.ToString(), additionalParams:  0);
        this.lastCollectedReward = this.quizProgress;
        this.SaveData();
    }
    public override bool IsRewardReadyToCollect()
    {
        var val_3;
        if((this.tierRewards.ContainsKey(key:  this.quizProgress)) != false)
        {
                var val_2 = (this.lastCollectedReward != this.quizProgress) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public override bool EventCompleted()
    {
        int val_5;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_6;
        val_5 = this;
        if(this.quizProgress != 0)
        {
                val_6 = this.tierRewards;
            if(val_6 == null)
        {
                return (bool)val_6;
        }
        
            if(val_6.Count == 0)
        {
                return (bool)val_6;
        }
        
            val_5 = this.quizProgress;
            var val_4 = (val_5 >= (System.Linq.Enumerable.Max(source:  this.tierRewards.Keys))) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public override bool get_IsEventHidden()
    {
        goto typeof(TRVSpecialCategoriesEventHandler).__il2cppRuntimeField_4F0;
    }
    public override bool get_IsEventValid()
    {
        if((this & 1) != 0)
        {
                return false;
        }
        
        GameBehavior val_1 = App.getBehavior;
        return System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public override string GetEventDisplayName()
    {
        return System.String.Format(format:  "SPECIAL CATEGORY: {0}", arg0:  this.eventCatergory.ToUpper());
    }
    public override string GetGameButtonText()
    {
        return "SPECIAL CATEGORIES";
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "SPECIAL CATEGORY\n{0}", arg0:  this.eventCatergory.ToUpper());
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVSpecialCategoriesPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVSpecialCategoriesPopup>(showNext:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentSpecialCategories>(allowMultiple:  false).Init(category:  this.eventCatergory);
    }
    public override void OnCategoryComplete()
    {
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if(val_1.currentGame == null)
        {
                return;
        }
    
    }
    public override void AppendGemSpentTracking(ref System.Collections.Generic.Dictionary<string, object> refData)
    {
        if((MonoSingleton<TRVMainController>.Instance) == 0)
        {
                return;
        }
        
        TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
        if(val_3.currentGame == null)
        {
                return;
        }
        
        TRVMainController val_4 = MonoSingleton<TRVMainController>.Instance;
        1152921517382247728 = refData;
        Add(key:  "Special Categories", value:  null);
    }
    public override void UpdateProgress()
    {
        TRVSpecialCategoriesEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public TRVSpecialCategoriesEventHandler()
    {
        this.eventCatergory = "";
    }

}

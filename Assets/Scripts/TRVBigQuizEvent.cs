using UnityEngine;
public class TRVBigQuizEvent : WGEventHandler
{
    // Fields
    private static TRVBigQuizEvent _Instance;
    public const string BIG_HINT_ID = "BigQuiz";
    public const string EVENT_TRACKING_ID = "Big Quiz Event";
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private int _startLevel;
    private int _levelsNeeded;
    private int _reward;
    private bool rewarded;
    
    // Properties
    public static TRVBigQuizEvent Instance { get; }
    public GameEventV2 getEvent { get; }
    public int eventProgress { get; }
    public int startLevel { get; }
    public int levelsNeeded { get; }
    public int reward { get; }
    private static int LastProgressTimestampPref { get; set; }
    public override bool IsEventHidden { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static TRVBigQuizEvent get_Instance()
    {
        return (TRVBigQuizEvent)TRVBigQuizEvent.EVENT_TRACKING_ID;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public int get_eventProgress()
    {
        Player val_1 = App.Player;
        val_1 = val_1 - this._startLevel;
        return (int)val_1;
    }
    public int get_startLevel()
    {
        return (int)this._startLevel;
    }
    public int get_levelsNeeded()
    {
        return (int)this._levelsNeeded;
    }
    public int get_reward()
    {
        return (int)this._reward;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "bigQuiz_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "bigQuiz_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517370727440] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        TRVBigQuizEvent.EVENT_TRACKING_ID = this;
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
            return;
        }
        
        this.LoadPersistantData();
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "BigQuiz")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "BigQuiz"));
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
        val_1.Add(key:  "prog", value:  App.Player);
        val_1.Add(key:  "rew", value:  null);
        CPlayerPrefs.SetString(key:  "BigQuiz", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    private void LoadPersistantData()
    {
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "BigQuiz"));
        if(val_2 != null)
        {
                this.myEventData = val_2;
            if((val_2.ContainsKey(key:  "prog")) == false)
        {
                return;
        }
        
            bool val_6 = System.Int32.TryParse(s:  this.myEventData.Item["prog"], result: out  this._startLevel);
            return;
        }
        
        this.myEventData = 0;
        throw new NullReferenceException();
    }
    private void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "prog", newValue:  this._startLevel);
        CPlayerPrefs.SetString(key:  "BigQuiz", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    public override void OnGameSceneBegan()
    {
        var val_12;
        ulong val_13;
        val_12 = null;
        val_12 = null;
        if((System.DateTime.TryParse(s:  CPlayerPrefs.GetString(key:  "BGLS", defaultValue:  System.DateTime.MinValue.ToString()), result: out  new System.DateTime())) != false)
        {
                System.DateTime val_4 = 0.Date;
            val_13 = val_4.dateData;
            System.DateTime val_5 = DateTimeCheat.UtcNow;
            System.DateTime val_6 = val_5.dateData.Date;
            if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_13}, d2:  new System.DateTime() {dateData = val_6.dateData})) == true)
        {
                return;
        }
        
        }
        
        WGWindowManager val_9 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVBigQuizEventPopup>(showNext:  false);
        System.DateTime val_10 = DateTimeCheat.UtcNow;
        val_13 = val_10.dateData.ToString();
        CPlayerPrefs.SetString(key:  "BGLS", val:  val_13);
        CPlayerPrefs.Save();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        var val_7;
        var val_8;
        var val_9;
        val_7 = this;
        val_8 = 1152921504884269056;
        val_9 = null;
        val_9 = null;
        if(levelsProgressed < 1)
        {
                return;
        }
        
        if(App.game != 19)
        {
                return;
        }
        
        val_7 = ???;
        val_8 = ???;
        goto typeof(TRVBigQuizEvent).__il2cppRuntimeField_3B0;
    }
    public override void OnCategoryComplete()
    {
        if((this & 1) == 0)
        {
                return;
        }
        
        if(this.rewarded != false)
        {
                return;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVBigQuizEventPopup>(showNext:  false);
    }
    public override bool EventCompleted()
    {
        return (bool)this.rewarded;
    }
    public override bool get_IsEventHidden()
    {
        return (bool)this.rewarded;
    }
    public override bool get_IsEventValid()
    {
        var val_8;
        GameBehavior val_1 = App.getBehavior;
        if((System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) == true)
        {
            goto label_5;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if((System.String.op_Equality(a:  val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "es")) == false)
        {
            goto label_10;
        }
        
        label_5:
        var val_7 = (this.rewarded == false) ? 1 : 0;
        return (bool)val_8;
        label_10:
        val_8 = 0;
        return (bool)val_8;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "big_quiz_upper", defaultValue:  "THE BIG QUIZ", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "big_quiz_upper", defaultValue:  "THE BIG QUIZ", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return (string)System.String.Format(format:  "{0}\n{1}/{2}", arg0:  Localization.Localize(key:  "big_quiz_upper", defaultValue:  "THE BIG QUIZ", useSingularKey:  false), arg1:  UnityEngine.Mathf.Min(a:  this._levelsNeeded, b:  this.eventProgress), arg2:  this._levelsNeeded);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVBigQuizEventPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVBigQuizEventPopup>(showNext:  false);
    }
    public override void UpdateProgress()
    {
        TRVBigQuizEvent.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentBigQuiz val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentBigQuiz>(allowMultiple:  false);
        if(this.eventProgress == 0)
        {
            goto label_2;
        }
        
        label_4:
        val_1.Setup(handler:  this);
        val_1.SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  this.eventProgress.ToString(), arg1:  this._levelsNeeded), sliderValue:  (float)this.eventProgress / (float)this._levelsNeeded);
        return;
        label_2:
        if(val_1 != null)
        {
            goto label_4;
        }
        
        throw new NullReferenceException();
    }
    public override bool IsRewardReadyToCollect()
    {
        int val_3 = this._startLevel;
        val_3 = this._levelsNeeded + val_3;
        return (bool)(App.Player >= val_3) ? 1 : 0;
    }
    public void OnCollect()
    {
        App.Player.AddGems(amount:  this._reward, source:  "BigQuizEvent", subsource:  0);
        App.Player.TrackNonCoinReward(source:  "The Big Quiz Event", subSource:  0, rewardType:  "Gems", rewardAmount:  this._reward.ToString(), additionalParams:  0);
        this.rewarded = true;
        this.SaveData();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "rewarded", value:  true);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_4);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_18;
        int val_19;
        int val_20;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = eventData;
        if(val_18 == null)
        {
                return;
        }
        
        if(val_18.Count == 0)
        {
                return;
        }
        
        val_18 = "economy";
        if((val_18.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = val_18.Item["economy"];
        if((val_3.ContainsKey(key:  "g_rew")) == false)
        {
            goto label_7;
        }
        
        val_19 = this._reward;
        if((System.Int32.TryParse(s:  val_3.Item["g_rew"], result: out  val_19)) == false)
        {
            goto label_9;
        }
        
        goto label_10;
        label_7:
        val_19 = this._reward;
        label_9:
        mem2[0] = 100;
        label_10:
        if((val_3.ContainsKey(key:  "lvls")) == false)
        {
            goto label_11;
        }
        
        val_20 = this._levelsNeeded;
        if((System.Int32.TryParse(s:  val_3.Item["lvls"], result: out  val_20)) == false)
        {
            goto label_13;
        }
        
        goto label_14;
        label_11:
        val_20 = this._levelsNeeded;
        label_13:
        mem2[0] = 100;
        label_14:
        val_18 = "progress";
        if((val_18.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        object val_13 = val_18.Item["progress"];
        if(val_13 == null)
        {
                return;
        }
        
        val_18 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_13) : 0;
        val_18 = "rewarded";
        if((val_18.ContainsKey(key:  "rewarded")) == false)
        {
                return;
        }
        
        bool val_17 = System.Boolean.TryParse(value:  val_18.Item["rewarded"], result: out  this.rewarded);
    }
    public TRVBigQuizEvent()
    {
        this._startLevel = 2147483647;
    }

}

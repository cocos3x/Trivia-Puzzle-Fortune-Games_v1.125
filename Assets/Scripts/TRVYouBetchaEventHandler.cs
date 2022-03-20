using UnityEngine;
public class TRVYouBetchaEventHandler : WGEventHandler
{
    // Fields
    private static TRVYouBetchaEventHandler _Instance;
    public const string YOU_BETCHA_ID = "YouBetcha";
    public const string EVENT_TRACKING_ID = "You Betcha Event";
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private bool hasPromptedEvent;
    private bool <hasActiveBet>k__BackingField;
    private int <betAmount>k__BackingField;
    private float <rewardMulti>k__BackingField;
    private int <consecPopupDismissal>k__BackingField;
    private int <lastLevelBetAt>k__BackingField;
    public int lastLevelAwardedAt;
    
    // Properties
    public static TRVYouBetchaEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public bool hasActiveBet { get; set; }
    public int betAmount { get; set; }
    public float rewardMulti { get; set; }
    public int consecPopupDismissal { get; set; }
    public int betReward { get; }
    public int lastLevelBetAt { get; set; }
    public bool shouldShowPopup { get; }
    private static int LastProgressTimestampPref { get; set; }
    
    // Methods
    public static TRVYouBetchaEventHandler get_Instance()
    {
        return (TRVYouBetchaEventHandler)TRVYouBetchaEventHandler.EVENT_TRACKING_ID;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public bool get_hasActiveBet()
    {
        return (bool)this.<hasActiveBet>k__BackingField;
    }
    private void set_hasActiveBet(bool value)
    {
        this.<hasActiveBet>k__BackingField = value;
    }
    public int get_betAmount()
    {
        return (int)this.<betAmount>k__BackingField;
    }
    private void set_betAmount(int value)
    {
        this.<betAmount>k__BackingField = value;
    }
    public float get_rewardMulti()
    {
        return (float)this.<rewardMulti>k__BackingField;
    }
    private void set_rewardMulti(float value)
    {
        this.<rewardMulti>k__BackingField = value;
    }
    public int get_consecPopupDismissal()
    {
        return (int)this.<consecPopupDismissal>k__BackingField;
    }
    private void set_consecPopupDismissal(int value)
    {
        this.<consecPopupDismissal>k__BackingField = value;
    }
    public int get_betReward()
    {
        float val_3 = 1.2f;
        val_3 = ((float)this.<betAmount>k__BackingField) * val_3;
        float val_4 = this.<rewardMulti>k__BackingField;
        float val_5 = (float)this.<betAmount>k__BackingField;
        val_4 = val_4 + 1f;
        val_5 = val_4 * val_5;
        return UnityEngine.Mathf.Max(a:  UnityEngine.Mathf.FloorToInt(f:  val_3), b:  UnityEngine.Mathf.FloorToInt(f:  val_5));
    }
    public int get_lastLevelBetAt()
    {
        return (int)this.<lastLevelBetAt>k__BackingField;
    }
    private void set_lastLevelBetAt(int value)
    {
        this.<lastLevelBetAt>k__BackingField = value;
    }
    public bool get_shouldShowPopup()
    {
        int val_3 = this.<lastLevelBetAt>k__BackingField;
        val_3 = App.Player - val_3;
        return (bool)(val_3 < (this.<consecPopupDismissal>k__BackingField)) ? 1 : 0;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "youBet_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "youBet_prog_ts", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517365490576] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        TRVYouBetchaEventHandler.EVENT_TRACKING_ID = this;
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
            return;
        }
        
        this.LoadPersistantData();
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "YouBetcha")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "YouBetcha"));
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
        val_1.Add(key:  "prompted", value:  null);
        val_1.Add(key:  "llba", value:  App.Player);
        CPlayerPrefs.SetString(key:  "YouBetcha", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    private void LoadPersistantData()
    {
        var val_7;
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "YouBetcha"));
        val_7 = 0;
        this.myEventData = ;
        object val_4 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "prompted", defaultValue:  null);
        this.hasPromptedEvent = null;
        object val_6 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "llba", defaultValue:  App.Player);
        this.<lastLevelBetAt>k__BackingField = null;
    }
    private void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "prompted", newValue:  this.hasPromptedEvent);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "llba", newValue:  this.<lastLevelBetAt>k__BackingField);
        CPlayerPrefs.SetString(key:  "YouBetcha", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_17;
        if(eventData == null)
        {
                return;
        }
        
        if(eventData.Count == 0)
        {
                return;
        }
        
        val_17 = "economy";
        if((eventData.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = eventData.Item["economy"];
        int val_6 = 100;
        if((val_3.ContainsKey(key:  "bet")) != false)
        {
                if((System.Int32.TryParse(s:  val_3.Item["bet"], result: out  val_6)) != false)
        {
                this.<betAmount>k__BackingField = 100;
        }
        
        }
        
        this.<betAmount>k__BackingField = UnityEngine.Mathf.Max(a:  this.<betAmount>k__BackingField, b:  50);
        if((val_3.ContainsKey(key:  "mult")) != false)
        {
                if((System.Single.TryParse(s:  val_3.Item["mult"], result: out  float val_11 = -2.160174E+34f)) != false)
        {
                this.<rewardMulti>k__BackingField = 0.5f;
        }
        
        }
        
        this.<rewardMulti>k__BackingField = UnityEngine.Mathf.Max(a:  this.<rewardMulti>k__BackingField, b:  0.2f);
        val_17 = "cpu_dis";
        if((val_3.ContainsKey(key:  "cpu_dis")) == false)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  val_3.Item["cpu_dis"], result: out  val_6)) == false)
        {
                return;
        }
        
        this.<consecPopupDismissal>k__BackingField = 100;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "you_betcha_upper", defaultValue:  "YOU BETCHA!", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "you_betcha_upper", defaultValue:  "YOU BETCHA!", useSingularKey:  false);
    }
    public override void OnCategorySelected(TRVCategorySelectionInfo category)
    {
        this.<hasActiveBet>k__BackingField = false;
    }
    public override void OnGameSceneBegan()
    {
        if(this.hasPromptedEvent != false)
        {
                return;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVYouBetchaPopup>(showNext:  false);
        this.hasPromptedEvent = true;
        this.SaveData();
    }
    public override void OnLevelComplete(int levelsProgressed)
    {
        if(levelsProgressed == 0)
        {
                this.<hasActiveBet>k__BackingField = false;
        }
        
        this.OnLevelComplete(levelsProgressed:  levelsProgressed);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVYouBetchaPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<TRVYouBetchaPopup>(showNext:  false);
    }
    public override void UpdateProgress()
    {
        TRVYouBetchaEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentYouBetcha val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentYouBetcha>(allowMultiple:  false);
        goto typeof(EventListItemContentYouBetcha).__il2cppRuntimeField_170;
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "you_betcha_upper", defaultValue:  "YOU BETCHA!", useSingularKey:  false);
    }
    public override WGWindow showPreQuestionWindow(TRVQuizProgress progress)
    {
        MetaGameBehavior val_6;
        var val_7;
        val_6 = progress;
        if(this.shouldShowPopup != false)
        {
                System.Collections.Generic.List<TRVQuestionHistory> val_2 = val_6.countedAnswerData;
            int val_6 = progress.correctAnswerRequirement;
            val_6 = val_6 - 1;
            if(W9 == val_6)
        {
                GameBehavior val_3 = App.getBehavior;
            val_6 = val_3.<metaGameBehavior>k__BackingField;
            WGWindow val_5 = val_6.GetComponent<WGWindow>();
            return (WGWindow)val_7;
        }
        
        }
        
        val_7 = 0;
        return (WGWindow)val_7;
    }
    public bool TryPlaceBet()
    {
        decimal val_7;
        var val_8;
        Player val_1 = App.Player;
        val_7 = val_1._credits;
        decimal val_2 = System.Decimal.op_Implicit(value:  this.<betAmount>k__BackingField);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_7, hi = val_7, lo = 41975808}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid})) != false)
        {
                val_8 = 0;
            return (bool)val_8;
        }
        
        decimal val_5 = System.Decimal.op_Implicit(value:  -(this.<betAmount>k__BackingField));
        val_7 = true;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, source:  "you_betcha", subSource:  0, externalParams:  0, doTrack:  true);
        this.<hasActiveBet>k__BackingField = val_7;
        this.<lastLevelBetAt>k__BackingField = App.Player;
        this.SaveData();
        val_8 = 1;
        return (bool)val_8;
    }
    public bool TryRewardBet()
    {
        var val_6;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if((val_1.currentGame.quizLevel != this.lastLevelAwardedAt) && ((this.<hasActiveBet>k__BackingField) != false))
        {
                this.<hasActiveBet>k__BackingField = false;
            decimal val_4 = System.Decimal.op_Implicit(value:  this.betReward);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  "you_betcha", subSource:  0, externalParams:  0, doTrack:  true);
            TRVMainController val_5 = MonoSingleton<TRVMainController>.Instance;
            val_6 = 1;
            this.lastLevelAwardedAt = val_5.currentGame.quizLevel;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public void ResetEventProgress()
    {
        this.<lastLevelBetAt>k__BackingField = App.Player;
        this.SaveData();
    }
    public TRVYouBetchaEventHandler()
    {
    
    }

}

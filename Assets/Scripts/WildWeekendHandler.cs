using UnityEngine;
public class WildWeekendHandler : WGEventHandler
{
    // Fields
    public static WildWeekendHandler Instance;
    public const string WILD_WEEKEND_EVENT_ID = "WildWordWeekend";
    public const string WILD_WEEKEND_EVENT_TRACKING_ID = "Wild Weekend Complete";
    private const int econ_default_levels = 50;
    private const int econ_default_award = 200;
    
    // Properties
    public static int TotalLevelQuantity { get; }
    private static int SavedLevelQuantity { get; set; }
    private int SavedAwardAmount { get; set; }
    private bool SavedHasSeenFirstTime { get; set; }
    private static int LastProgressTimestampPref { get; set; }
    public virtual bool IsAvailable { get; }
    
    // Methods
    public static int get_TotalLevelQuantity()
    {
        return WildWeekendHandler.SavedLevelQuantity;
    }
    private static int get_SavedLevelQuantity()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "wild_lvlQty", defaultValue:  0);
    }
    private static void set_SavedLevelQuantity(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wild_lvlQty", value:  value);
    }
    private int get_SavedAwardAmount()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "wild_award", defaultValue:  0);
    }
    private void set_SavedAwardAmount(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wild_award", value:  value);
    }
    private bool get_SavedHasSeenFirstTime()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "wild_seen", defaultValue:  0)) == 1) ? 1 : 0;
    }
    private void set_SavedHasSeenFirstTime(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "wild_seen", value:  value);
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "wild_lst_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "wild_lst_prog_ts", value:  value);
    }
    public virtual bool get_IsAvailable()
    {
        var val_6;
        if(true != 0)
        {
                if((this.HasCollected() != true) && (true != 0))
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            var val_5 = (41.ToOADate() > val_3.dateData.ToOADate()) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public void GainLevelComplete(int levelsToGain = 1)
    {
        if((this & 1) == 0)
        {
                return;
        }
        
        Player val_1 = App.Player;
        Player val_2 = App.Player;
        val_1.properties.WWWEventProgress = System.Math.Max(val1:  val_2.properties.WWWEventProgress + levelsToGain, val2:  0);
        Player val_5 = App.Player;
        val_5.properties.Save(writePrefs:  true);
    }
    public bool CheckComplete()
    {
        var val_4;
        if((this & 1) != 0)
        {
                var val_3 = (this.GetLevelsComplete() >= WildWeekendHandler.SavedLevelQuantity) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    public int GetLevelsComplete()
    {
        Player val_1 = App.Player;
        return (int)val_1.properties.WWWEventProgress;
    }
    public void SetHasSeenFirstTime()
    {
        bool val_1 = this.SavedHasSeenFirstTime;
        if(val_1 != false)
        {
                return;
        }
        
        val_1.SavedHasSeenFirstTime = true;
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void SetSavedCollected(bool collected)
    {
        Player val_1 = App.Player;
        collected = collected;
        val_1.properties.WWWEventCollected = collected;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
    }
    public bool HasCollected()
    {
        Player val_1 = App.Player;
        return val_1.properties.WWWEventCollected;
    }
    public int GetLevelsTotal()
    {
        return WildWeekendHandler.SavedLevelQuantity;
    }
    public System.DateTime GetEndDate()
    {
        if(X8 != 0)
        {
                return (System.DateTime)X8 + 40;
        }
        
        throw new NullReferenceException();
    }
    public GameEventRewardType getRewardType()
    {
        var val_14;
        var val_15;
        val_14 = 147633.Item["economy"];
        if((val_14.ContainsKey(key:  "rew_v2")) != false)
        {
                val_14 = val_14.Item["rew_v2"];
            int val_6 = 0;
            if((val_14.ContainsKey(key:  "coins")) != false)
        {
                if(val_6 >= 1)
        {
                if((System.Int32.TryParse(s:  val_14.Item["coins"], result: out  val_6)) == true)
        {
            goto label_22;
        }
        
        }
        
        }
        
            if((val_14.ContainsKey(key:  "bonus_spin")) != false)
        {
                if((val_6 >= 1) && ((System.Int32.TryParse(s:  val_14.Item["bonus_spin"], result: out  val_6)) != false))
        {
                val_15 = 4;
            return (GameEventRewardType)val_15;
        }
        
        }
        
            if((val_14.ContainsKey(key:  "bonus_wheel")) != false)
        {
                if((val_6 >= 1) && ((System.Int32.TryParse(s:  val_14.Item["bonus_wheel"], result: out  val_6)) != false))
        {
                val_15 = 3;
            return (GameEventRewardType)val_15;
        }
        
        }
        
        }
        
        label_22:
        val_15 = 1;
        return (GameEventRewardType)val_15;
    }
    public int getRewardValue()
    {
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        val_10 = this;
        val_11 = 0;
        if(this.getRewardType() != 1)
        {
                return (int)val_11;
        }
        
        val_12 = 1152921504685600768;
        val_10 = 37794084.Item["economy"];
        val_13 = val_10;
        if((val_13.ContainsKey(key:  "rew_v2")) != false)
        {
                val_10 = val_10.Item["rew_v2"];
            val_12 = "coins";
            val_13 = val_10;
            if((val_13.ContainsKey(key:  "coins")) != false)
        {
                int val_7 = 0;
            bool val_8 = System.Int32.TryParse(s:  val_10.Item["coins"], result: out  val_7);
            val_11 = val_7;
            if(val_11 >= 1)
        {
                if(val_8 == true)
        {
                return (int)val_11;
        }
        
        }
        
        }
        
        }
        
        val_11 = val_8.SavedAwardAmount;
        return (int)val_11;
    }
    private void InitWildWeekend(string json, bool clearProgress)
    {
        var val_20;
        var val_21;
        string val_20 = json;
        object val_3 = MiniJSON.Json.Deserialize(json:  ((System.String.IsNullOrEmpty(value:  val_20)) != true) ? "{}" : (val_20));
        if(clearProgress == false)
        {
            goto label_3;
        }
        
        label_17:
        Player val_4 = App.Player;
        val_4.properties.WWWServerTimestamp = App.__il2cppRuntimeField_cctor_finished + 16;
        Player val_5 = App.Player;
        val_5.properties.WWWEventProgress = 0;
        Player val_6 = App.Player;
        val_6.properties.WWWEventCollected = false;
        Player val_7 = App.Player;
        val_7.properties.Save(writePrefs:  true);
        val_7.properties.SavedHasSeenFirstTime = false;
        WildWeekendHandler.LastProgressTimestampPref = 0;
        if(0 != 0)
        {
            goto label_15;
        }
        
        val_20 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        if(clearProgress == true)
        {
            goto label_17;
        }
        
        label_3:
        label_15:
        object val_8 = val_3.Item["economy"];
        if(((val_8.ContainsKey(key:  "levels")) == false) || ((System.String.IsNullOrEmpty(value:  val_8.Item["levels"])) == true))
        {
            goto label_29;
        }
        
        object val_12 = val_8.Item["levels"];
        if(null < 1)
        {
            goto label_29;
        }
        
        object val_13 = val_8.Item["levels"];
        goto label_32;
        label_29:
        val_20 = 50;
        label_32:
        WildWeekendHandler.SavedLevelQuantity = 50;
        bool val_14 = val_8.ContainsKey(key:  "award");
        if((val_14 == false) || ((System.String.IsNullOrEmpty(value:  val_8.Item["award"])) == true))
        {
            goto label_38;
        }
        
        object val_17 = val_8.Item["award"];
        if(null < 1)
        {
            goto label_38;
        }
        
        object val_18 = val_8.Item["award"];
        if(this != null)
        {
            goto label_41;
        }
        
        label_38:
        val_21 = 200;
        label_41:
        val_14.SavedAwardAmount = 200;
        bool val_19 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public bool ShowNewWeekendInLobby()
    {
        var val_3;
        if((SceneDictator.GetActiveSceneType() == 1) && ((this & 1) != 0))
        {
                val_3 = (~this.SavedHasSeenFirstTime) & 1;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    protected void SetupAndShowPopup()
    {
        var val_14;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41963520 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_14 = val_3.<metaGameBehavior>k__BackingField;
        }
        
        int val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WildWeekendPopup>(showNext:  false).GetLevelsComplete();
        GameEventRewardType val_10 = this.getRewardType();
        System.Action val_11 = new System.Action(object:  this, method:  typeof(WildWeekendHandler).__il2cppRuntimeField_448);
        System.Action val_12 = new System.Action(object:  this, method:  typeof(WildWeekendHandler).__il2cppRuntimeField_458);
        bool val_13 = WildWeekendHandler.SavedLevelQuantity.HasCollected();
    }
    private void RefreshWeekendInfo(GameEventV2 eventV2)
    {
        mem[1152921516379683008] = eventV2;
        if(eventV2 == null)
        {
                return;
        }
        
        if((System.String.op_Inequality(a:  eventV2.type, b:  "WildWordWeekend")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update WildWeekendHandler with non-matching event type: "("Attempting to update WildWeekendHandler with non-matching event type: ") + eventV2.ToString());
            return;
        }
        
        WildWeekendHandler.econ_default_award = this;
        Player val_4 = App.Player;
        this.InitWildWeekend(json:  App.__il2cppRuntimeField_12F + 96, clearProgress:  (WildWeekendHandler.econ_default_award.__il2cppRuntimeField_10 != val_4.properties.WWWServerTimestamp) ? 1 : 0);
    }
    public override void Init(GameEventV2 eventV2)
    {
        this.RefreshWeekendInfo(eventV2:  eventV2);
    }
    public override void OnGameSceneBegan()
    {
        if(this.SavedHasSeenFirstTime == true)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        this.SetupAndShowPopup();
    }
    public override void OnMenuLoaded()
    {
    
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        null = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 16;
        this.SetupAndShowPopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_4 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (17 + 1) : 17;
        this.SetupAndShowPopup();
    }
    public override void OnEventEnded()
    {
        this.OnEventEnded();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.RefreshWeekendInfo(eventV2:  eventV2);
    }
    public override string GetMainMenuButtonText()
    {
        object val_9;
        var val_10;
        val_9 = this;
        bool val_1 = this.CheckComplete();
        if(val_1 != false)
        {
                string val_2 = Localization.Localize(key:  "reward_upper", defaultValue:  "REWARD", useSingularKey:  false);
            return (string)val_10;
        }
        
        int val_3 = val_1.GetLevelsComplete();
        if(val_3 != 0)
        {
                val_9 = val_3.GetLevelsComplete().ToString();
            string val_8 = System.String.Format(format:  "{0}/{1}", arg0:  val_9, arg1:  WildWeekendHandler.SavedLevelQuantity.ToString());
            return (string)val_10;
        }
        
        val_10 = "WILD WORDS";
        return (string)val_10;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "wild_word_event_upper", defaultValue:  "WILD WORD EVENT", useSingularKey:  false);
    }
    public override void HackAddLevels(int levelsHacked)
    {
        this.GainLevelComplete(levelsToGain:  levelsHacked);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.GainLevelComplete(levelsToGain:  levelsProgressed);
    }
    public override void HandleCollectAction()
    {
        this.SetSavedCollected(collected:  true);
    }
    public override void HandleAdvertisedSeen()
    {
        this.SetHasSeenFirstTime();
    }
    public override string GetGameButtonText()
    {
        Player val_1 = App.Player;
        return (string)val_1.properties.WWWEventProgress + "/"("/") + WildWeekendHandler.SavedLevelQuantity;
    }
    public override bool IsChallengeCompleted()
    {
        return this.HasCollected();
    }
    public override bool IsEventEndedOffline()
    {
        System.DateTime val_1 = System.Convert.ToDateTime(value:  new System.DateTime() {dateData = 504464731990392832});
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        int val_3 = val_1.dateData.CompareTo(value:  new System.DateTime() {dateData = val_2.dateData});
        val_3 = val_3 >> 31;
        return (bool)val_3;
    }
    public override int LastProgressTimestamp()
    {
        return WildWeekendHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        WildWeekendHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        return this.CheckComplete();
    }
    public override bool EventCompleted()
    {
        return this.HasCollected();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        string val_5 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  this.GetLevelsComplete().ToString(), arg1:  WildWeekendHandler.SavedLevelQuantity.ToString());
        float val_9 = (float)val_5.GetLevelsComplete();
        val_9 = val_9 / (float)WildWeekendHandler.SavedLevelQuantity;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentWWW>(allowMultiple:  false).SetupSlider(sliderText:  val_5, sliderValue:  val_9);
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_1;
        if(layoutType == 1)
        {
                val_1 = 0;
            return true;
        }
        
        val_1 = 1152921516382320449;
        return true;
    }
    public string GetEventRemainingTime()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = UnityEngine.Mathf.Max(a:  val_2._ticks.Days, b:  0);
        val_3[1] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
        val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
        val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Seconds, b:  0);
        return (string)System.String.Format(format:  "{0:0}:{1:00}:{2:00}:{3:00}", args:  val_3);
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventButton = eventButton;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WildWeekendHandler.<DoLevelCompleteEventProgressAnimation>d__58();
    }
    public WildWeekendHandler()
    {
    
    }

}

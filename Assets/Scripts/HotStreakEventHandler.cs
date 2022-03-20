using UnityEngine;
public class HotStreakEventHandler : WGEventHandler
{
    // Fields
    private static HotStreakEventHandler _instance;
    public const string HOT_STREAK_ID = "HotStreak";
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private int lastLevelShowAt;
    private int lastLevelCollectedAt;
    private int currentStreak;
    private bool inStreak;
    private int currentStreakGoal;
    private int levelsLapsedSinceLastShown;
    private GameplayMode lastModeShowAt;
    private string lastModeSecondaryId;
    private int levelInterval;
    private int knobStreakGoal;
    private int streakKnobLess;
    private int streakKnobMore;
    private int streakMinValue;
    private int streakMaxValue;
    private int reward;
    
    // Properties
    public static HotStreakEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public int getCurrentStreakGoal { get; }
    private static int LastProgressTimestampPref { get; set; }
    public override bool IsEventHidden { get; }
    
    // Methods
    public static HotStreakEventHandler get_Instance()
    {
        return (HotStreakEventHandler)HotStreakEventHandler.HOT_STREAK_ID;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public int get_getCurrentStreakGoal()
    {
        return (int)this.knobStreakGoal;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "hs_last_prog", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "hs_last_prog", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        HotStreakEventHandler val_8 = this;
        mem[1152921516485578176] = eventV2;
        HotStreakEventHandler.HOT_STREAK_ID = val_8;
        if(eventV2.eventData != null)
        {
                this.ParseEventData(eventData:  eventV2.eventData);
        }
        
        if((this.CheckNeedsNewData(eventData:  eventV2.eventData)) != false)
        {
                this.GenerateNewData();
        }
        else
        {
                this.LoadPersistantData();
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_8 = ???;
        goto typeof(HotStreakEventHandler).__il2cppRuntimeField_210;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_31;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_31 = eventData;
        if(val_31 == null)
        {
                return;
        }
        
        if(val_31.Count == 0)
        {
                return;
        }
        
        val_31 = 1152921510222861648;
        if((val_31.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = val_31.Item["economy"];
        if(val_3 == null)
        {
                return;
        }
        
        val_31 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "hotStreakData")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "hotStreakData"));
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
        val_1.Add(key:  "lastLevel", value:  998);
        val_1.Add(key:  "levelsLapsed", value:  9999);
        val_1.Add(key:  "lastCollect", value:  998);
        val_1.Add(key:  "eventPrompted", value:  null);
        CPlayerPrefs.SetString(key:  "hotStreakData", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    private void LoadPersistantData()
    {
        var val_11;
        var val_12;
        string val_13;
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "hotStreakData"));
        val_11 = 0;
        this.myEventData = ;
        val_12 = 1152921504619999232;
        object val_4 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "lastLevel", defaultValue:  0);
        this.lastLevelShowAt = null;
        object val_5 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "lastCollect", defaultValue:  0);
        this.lastLevelCollectedAt = null;
        object val_6 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "levelsLapsed", defaultValue:  0);
        this.levelsLapsedSinceLastShown = null;
        object val_7 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "lastMode", defaultValue:  1);
        this.lastModeShowAt = null;
        if((this.myEventData.ContainsKey(key:  "lastModeSecondary")) == false)
        {
            goto label_15;
        }
        
        val_12 = 1152921510214912464;
        if(this.myEventData.Item["lastModeSecondary"] == null)
        {
            goto label_20;
        }
        
        object val_10 = this.myEventData.Item["lastModeSecondary"];
        goto label_20;
        label_15:
        val_13 = 0;
        label_20:
        this.lastModeSecondaryId = val_13;
    }
    private void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastLevel", newValue:  this.lastLevelShowAt);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastCollect", newValue:  this.lastLevelCollectedAt);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "levelsLapsed", newValue:  this.levelsLapsedSinceLastShown);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastMode", newValue:  this.lastModeShowAt);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastModeSecondary", newValue:  this.lastModeSecondaryId);
        CPlayerPrefs.SetString(key:  "hotStreakData", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    public bool CanEngageWithEvent()
    {
        bool val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
        return false;
    }
    public bool IsCurrentModeEqualsModeWithExistingStreak()
    {
        var val_7;
        if(PlayingLevel.CurrentGameplayMode != this.lastModeShowAt)
        {
            goto label_3;
        }
        
        if(PlayingLevel.CurrentGameplayMode != 4)
        {
            goto label_6;
        }
        
        val_7 = 0;
        if((System.Int32.TryParse(s:  this.lastModeSecondaryId, result: out  0)) == false)
        {
                return (bool)val_7;
        }
        
        CategoryPacksManager val_5 = MonoSingleton<CategoryPacksManager>.Instance;
        var val_6 = ((val_5.<CurrentCategoryPackInfo>k__BackingField.packId) == 0) ? 1 : 0;
        return (bool)val_7;
        label_3:
        val_7 = 0;
        return (bool)val_7;
        label_6:
        val_7 = 1;
        return (bool)val_7;
    }
    public override void OnGameSceneInit()
    {
        var val_27;
        int val_28;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_29;
        val_27 = this;
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        if(WordRegion.instance == 0)
        {
            goto label_10;
        }
        
        WordRegion val_4 = WordRegion.instance;
        if(((this.myEventData.ContainsKey(key:  "lastReq")) == false) || (this.myEventData.Item["lastReq"] == null))
        {
            goto label_14;
        }
        
        val_28 = this.currentStreakGoal;
        if((System.Int32.TryParse(s:  this.myEventData.Item["lastReq"], result: out  val_28)) == true)
        {
            goto label_17;
        }
        
        label_14:
        Player val_10 = App.Player;
        int val_13 = UnityEngine.Random.Range(min:  this.streakKnobLess + val_10.properties.LifetimeLargestStreak, max:  this.streakKnobMore + val_10.properties.LifetimeLargestStreak);
        this.currentStreakGoal = val_13;
        val_28 = this.currentStreakGoal;
        int val_14 = UnityEngine.Mathf.Clamp(value:  val_13, min:  this.streakMinValue, max:  this.streakMaxValue);
        this.currentStreakGoal = val_14;
        val_29 = this.myEventData;
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  val_29, key:  "lastReq", newValue:  val_14);
        label_17:
        WordRegion val_15 = WordRegion.instance;
        this.currentStreak = 0;
        this.inStreak = false;
        return;
        label_10:
        UnityEngine.Debug.LogError(message:  "Hot Streak Game Init Error");
    }
    public override void OnValidWordSubmitted(string word)
    {
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        if((this.currentStreak < this.currentStreakGoal) && (this.inStreak != false))
        {
                if(this.lastLevelCollectedAt != PlayingLevel.GetCurrentPlayerLevelNumber())
        {
                int val_6 = this.currentStreak;
            val_6 = val_6 + 1;
            this.currentStreak = val_6;
        }
        
        }
        
        this.inStreak = true;
        if(this.lastLevelCollectedAt == PlayingLevel.GetCurrentPlayerLevelNumber())
        {
                return;
        }
        
        if(this.currentStreak < this.currentStreakGoal)
        {
                return;
        }
        
        WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HotStreakPopup>(showNext:  false);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        if((this.IsCurrentModeEqualsModeWithExistingStreak() != false) && (PlayingLevel.GetCurrentPlayerLevelNumber() == this.lastLevelShowAt))
        {
                if((this.myEventData.ContainsKey(key:  "lastReq")) != false)
        {
                bool val_4 = this.myEventData.Remove(key:  "lastReq");
        }
        
        }
        
        int val_5 = this.levelsLapsedSinceLastShown;
        val_5 = val_5 + levelsProgressed;
        this.levelsLapsedSinceLastShown = val_5;
        this.SaveData();
    }
    public override void OnInvalidWordSubmitted()
    {
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        this.inStreak = false;
        if(this.currentStreak < this.currentStreakGoal)
        {
                this.currentStreak = 0;
        }
    
    }
    public override void BreakStreak()
    {
        goto typeof(HotStreakEventHandler).__il2cppRuntimeField_600;
    }
    public override bool IsRewardReadyToCollect()
    {
        var val_6;
        if(this.CanEngageWithEvent() != false)
        {
                if((PlayingLevel.GetCurrentPlayerLevelNumber() != this.lastLevelCollectedAt) && (this.currentStreakGoal != 0))
        {
                val_6 = ((this.currentStreak >= this.currentStreakGoal) ? 1 : 0) & ((this.currentStreak != 0) ? 1 : 0);
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "hot_streaks_upper", defaultValue:  "HOT STREAKS", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        int val_3;
        if(this.CanEngageWithEvent() != false)
        {
                string val_2 = System.String.Format(format:  "{0}/{1}", arg0:  this.currentStreak, arg1:  this.currentStreakGoal);
            return (string)val_3;
        }
        
        val_3 = System.String.alignConst;
        return (string)val_3;
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "hot_streaks_upper", defaultValue:  "HOT STREAKS", useSingularKey:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HotStreakPopup>(showNext:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HotStreakPopup>(showNext:  false);
    }
    public override int LastProgressTimestamp()
    {
        return HotStreakEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        HotStreakEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        string val_6;
        float val_7;
        if(this.CanEngageWithEvent() != false)
        {
                val_6 = System.String.Format(format:  "STREAKS {0}/{1}", arg0:  this.currentStreak, arg1:  this.currentStreakGoal);
        }
        else
        {
                val_6 = "-/-";
        }
        
        val_7 = 0f;
        if(this.CanEngageWithEvent() != false)
        {
                val_7 = (float)this.currentStreak / (float)this.currentStreakGoal;
        }
        
        loader.LoadStrictlyTypeNamedPrefab<EventListContentItemHotStreak>(allowMultiple:  false).SetupSlider(sliderText:  val_6, sliderValue:  val_7);
    }
    public override string GetHackPanelEventData()
    {
        int val_24;
        int val_25;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        object[] val_2 = new object[7];
        val_2[0] = "last level shown at ";
        val_24 = val_2.Length;
        val_2[1] = this.lastLevelShowAt;
        val_24 = val_2.Length;
        val_2[2] = " inside mode ";
        mem2[0] = this.lastModeShowAt;
        val_25 = val_2.Length;
        val_2[3] = this.lastModeShowAt.ToString();
        val_25 = val_2.Length;
        val_2[4] = " (secondary id: ";
        if(this.lastModeSecondaryId != null)
        {
                val_25 = val_2.Length;
        }
        
        val_2[5] = this.lastModeSecondaryId;
        val_25 = val_2.Length;
        val_2[6] = ")";
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  +val_2);
        System.Text.StringBuilder val_10 = val_1.AppendLine(value:  "hot streak level? "("hot streak level? ") + this.CanEngageWithEvent().ToString());
        if(this.CanEngageWithEvent() != true)
        {
                System.Text.StringBuilder val_13 = val_1.AppendLine(value:  "current streak goal : "("current streak goal : ") + this.currentStreakGoal);
            System.Text.StringBuilder val_15 = val_1.AppendLine(value:  "levels since last level shown " + this.levelsLapsedSinceLastShown);
        }
        
        System.Text.StringBuilder val_17 = val_1.AppendLine(value:  "last level collected at " + this.lastLevelCollectedAt);
        Player val_18 = App.Player;
        System.Text.StringBuilder val_20 = val_1.AppendLine(value:  "current lifetime largest streak " + val_18.properties.LifetimeLargestStreak);
        System.Text.StringBuilder val_21 = val_1.AppendLine(value:  "JSON KNOB DATA");
        System.Text.StringBuilder val_23 = val_1.AppendLine(value:  PrettyPrint.printJSON(obj:  public System.Boolean System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>::ContainsKey(System.Int32 key), types:  false, singleLineOutput:  false));
        return (string)val_1;
    }
    public override bool get_IsEventHidden()
    {
        if(X8 != 0)
        {
                return (bool)X8 + 82;
        }
        
        throw new NullReferenceException();
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        if(this.IsCurrentModeEqualsModeWithExistingStreak() == false)
        {
                return;
        }
        
        if(this.lastLevelShowAt != PlayingLevel.GetCurrentPlayerLevelNumber())
        {
                return;
        }
        
        1152921516489382432 = currentData;
        1152921516489382432.Add(key:  "Hot Streaks Level Completed", value:  (this.currentStreak >= this.currentStreakGoal) ? 1 : 0);
    }
    public int GetCoinReward()
    {
        return (int)this.reward;
    }
    public void CollectReward()
    {
        this.lastLevelCollectedAt = PlayingLevel.GetCurrentPlayerLevelNumber();
        decimal val_2 = System.Decimal.op_Implicit(value:  this.reward);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "hot streak event", externalParams:  0, animated:  false);
        this.SaveData();
    }
    public HotStreakEventHandler()
    {
        this.lastLevelShowAt = 9999;
        this.streakMinValue = 3;
        this.streakMaxValue = 18;
        this.levelsLapsedSinceLastShown = 9999;
        this.lastModeShowAt = 1;
        this.levelInterval = ;
        this.knobStreakGoal = ;
        this.streakKnobLess = 12884901886;
        this.streakKnobMore = 2;
        this.reward = 50;
    }

}

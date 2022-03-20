using UnityEngine;
public class SuperStreakEventHandler : WGEventHandler
{
    // Fields
    private static SuperStreakEventHandler _superStreakEventHandler;
    public const string SUPER_STREAK_ID = "SuperStreak";
    private const string SUPER_STREAK_TRACKING_ID = "Super Streak Weekend";
    private System.Collections.Generic.Dictionary<string, object> myEventData;
    private const string EVENT_DATAKEY_LEVELS_LAPSED = "levelsLapsed";
    private const int DEFAULT_LEVELS_LAPSED = -999;
    private const string EVENT_DATAKEY_LAST_GAME_MODE = "modeShown";
    private const string EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE = "modeSecondaryShown";
    private int currentStreak;
    private int currentTier;
    private int currentTierLevelReq;
    private bool inStreak;
    private int levelsCompletedThisTier;
    private int levelInterval;
    private int knobStreakGoal;
    private int currentStreakGoal;
    private int curPriorityOffset;
    private int priorityOffset;
    private bool hasSeenBreakFtux;
    private bool shouldSeeFtux;
    private System.Collections.Generic.List<object> tierData;
    
    // Properties
    public static SuperStreakEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    private int levelsLapsedSinceLastShown { get; set; }
    private GameplayMode lastShownGameMode { get; set; }
    private string lastShownSecondaryGameMode { get; set; }
    private int lastLevelShowAt { get; set; }
    public int getCurrentTierReq { get; }
    public int getCurrentStreakGoal { get; }
    private static int LastProgressTimestampPref { get; set; }
    
    // Methods
    public static SuperStreakEventHandler get_Instance()
    {
        return (SuperStreakEventHandler)SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    private int get_levelsLapsedSinceLastShown()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "levelsLapsed", defaultValue:  998);
        return (int)null;
    }
    private void set_levelsLapsedSinceLastShown(int value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "levelsLapsed", newValue:  value);
    }
    private GameplayMode get_lastShownGameMode()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "modeShown", defaultValue:  1);
        return (GameplayMode)null;
    }
    private void set_lastShownGameMode(GameplayMode value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "modeShown", newValue:  value);
    }
    private string get_lastShownSecondaryGameMode()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "modeSecondaryShown", defaultValue:  0);
        if(val_1 == null)
        {
                return (string)val_1;
        }
        
        this = ???;
        goto typeof(System.Object).__il2cppRuntimeField_160;
    }
    private void set_lastShownSecondaryGameMode(string value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "modeSecondaryShown", newValue:  value);
    }
    private int get_lastLevelShowAt()
    {
        object val_1 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "lastLevel", defaultValue:  0);
        return (int)null;
    }
    private void set_lastLevelShowAt(int value)
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastLevel", newValue:  value);
    }
    public int get_getCurrentTierReq()
    {
        return (int)this.currentTierLevelReq;
    }
    public int get_getCurrentStreakGoal()
    {
        return (int)this.knobStreakGoal;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ss_last_prog", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ss_last_prog", value:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        SuperStreakEventHandler val_8 = this;
        mem[1152921516755474432] = eventV2;
        SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE = val_8;
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
        
        this.CalculateCurrentTierReq();
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_8 = ???;
        goto typeof(SuperStreakEventHandler).__il2cppRuntimeField_210;
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_25;
        var val_26;
        var val_42;
        var val_43;
        string val_44;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_40 = eventData;
        if(val_40 == null)
        {
                return;
        }
        
        val_42 = 1152921510222861648;
        if((val_40.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = val_40.Item["economy"];
        if(val_2 == null)
        {
                return;
        }
        
        val_40 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_2) : 0;
        return;
        label_51:
        val_44 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_26.MoveNext() == false)
        {
            goto label_35;
        }
        
        val_43 = val_25;
        if(val_43 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_44 = null;
        if(((val_43.Count == 0) || ((val_43.ContainsKey(key:  "lvl")) == false)) || ((val_43.ContainsKey(key:  "rwd")) == false))
        {
            goto label_48;
        }
        
        object val_31 = val_43.Item["rwd"];
        if((val_31 == null) || (val_31.Count == 0))
        {
            goto label_48;
        }
        
        if((val_31.ContainsKey(key:  "bonus_wheel")) != true)
        {
                if((val_31.ContainsKey(key:  "bonus_spin")) != true)
        {
                if((val_31.ContainsKey(key:  "coins")) == false)
        {
            goto label_48;
        }
        
        }
        
        }
        
        if((val_31.ContainsKey(key:  "coins")) == false)
        {
            goto label_51;
        }
        
        int val_38 = 0;
        bool val_39 = System.Int32.TryParse(s:  val_31.Item["coins"], result: out  val_38);
        if(val_38 != 0)
        {
            goto label_51;
        }
        
        label_48:
        val_26.Dispose();
        UnityEngine.Debug.LogError(message:  "Super Streak Knobs are set to invalid values, defaulting to econ values");
        return;
        label_35:
        val_26.Dispose();
        this.tierData = ;
    }
    private bool CheckNeedsNewData(GameEventV2 eventData)
    {
        if((CPlayerPrefs.HasKey(key:  "superStreakData")) == false)
        {
                return true;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "superStreakData"));
        if(val_3 == null)
        {
                return true;
        }
        
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        return true;
    }
    private void GenerateNewData()
    {
        this.currentStreak = 0;
        this.inStreak = false;
        this.currentStreakGoal = 0;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "id", value:  System.Void System.Runtime.Serialization.Formatters.Binary.SizedArray::IncreaseCapacity(int index));
        val_1.Add(key:  "lastLevel", value:  998);
        val_1.Add(key:  "levelsLapsed", value:  this.levelInterval);
        val_1.Add(key:  "curTier", value:  0);
        val_1.Add(key:  "levelsCompleted", value:  0);
        val_1.Add(key:  "eventPrompted", value:  null);
        val_1.Add(key:  "lastStreak", value:  0);
        val_1.Add(key:  "seenBreakFtux", value:  null);
        CPlayerPrefs.SetString(key:  "superStreakData", val:  MiniJSON.Json.Serialize(obj:  val_1));
        CPlayerPrefs.Save();
        this.LoadPersistantData();
    }
    private void LoadPersistantData()
    {
        bool val_17;
        var val_18;
        GameplayMode val_20;
        val_17 = this;
        object val_2 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "superStreakData"));
        val_18 = 0;
        this.myEventData = ;
        object val_4 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  null, key:  "levelsLapsed", defaultValue:  0);
        this.levelsLapsedSinceLastShown = 19914752;
        if((this.myEventData.ContainsKey(key:  "modeShown")) != false)
        {
                object val_6 = this.myEventData.Item["modeShown"];
        }
        
        int val_8 = 1;
        if((System.Int32.TryParse(s:  1.ToString(), result: out  val_8)) != false)
        {
                val_20 = val_8;
        }
        else
        {
                val_20 = 1;
        }
        
        this.lastShownGameMode = val_20;
        object val_10 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "lastLevel", defaultValue:  0);
        this.lastLevelShowAt = 19914752;
        object val_11 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "curTier", defaultValue:  0);
        this.currentTier = null;
        object val_12 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "levelsCompleted", defaultValue:  0);
        this.levelsCompletedThisTier = null;
        if((this.myEventData.ContainsKey(key:  "seenBreakFtux")) == false)
        {
                return;
        }
        
        val_17 = this.hasSeenBreakFtux;
        bool val_16 = System.Boolean.TryParse(value:  this.myEventData.Item["seenBreakFtux"], result: out  val_17);
    }
    private void SaveData()
    {
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "levelsLapsed", newValue:  this.levelsLapsedSinceLastShown);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "modeShown", newValue:  this.lastShownGameMode);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "modeSecondaryShown", newValue:  this.lastShownSecondaryGameMode);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastLevel", newValue:  this.lastLevelShowAt);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "curTier", newValue:  this.currentTier);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "levelsCompleted", newValue:  this.levelsCompletedThisTier);
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "seenBreakFtux", newValue:  this.hasSeenBreakFtux);
        CPlayerPrefs.SetString(key:  "superStreakData", val:  MiniJSON.Json.Serialize(obj:  this.myEventData));
        CPlayerPrefs.Save();
    }
    public bool CanEngageWithEvent()
    {
        var val_6;
        var val_7;
        val_6 = this;
        if(this.currentTier >= this.tierData)
        {
            goto label_2;
        }
        
        if(this.levelsLapsedSinceLastShown >= this.levelInterval)
        {
            goto label_3;
        }
        
        if(this.IsCurrentModeEqualsModeWithStreak() == false)
        {
            goto label_7;
        }
        
        val_6 = this.lastLevelShowAt;
        if(val_6 != PlayingLevel.GetCurrentPlayerLevelNumber())
        {
            goto label_7;
        }
        
        label_3:
        val_7 = 1;
        return (bool)val_7;
        label_7:
        GameBehavior val_5 = App.getBehavior;
        label_2:
        val_7 = 0;
        return (bool)val_7;
    }
    private bool WasPlayingEvent()
    {
        var val_5;
        var val_6;
        val_5 = this;
        if(this.IsCurrentModeEqualsModeWithStreak() != false)
        {
                val_5 = this.lastLevelShowAt;
            if((val_5 + 1) == PlayingLevel.GetCurrentPlayerLevelNumber())
        {
                val_6 = 1;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public bool IsCurrentModeEqualsModeWithStreak()
    {
        var val_9;
        if(PlayingLevel.CurrentGameplayMode != this.lastShownGameMode)
        {
            goto label_3;
        }
        
        if(PlayingLevel.CurrentGameplayMode != 4)
        {
            goto label_6;
        }
        
        val_9 = 0;
        if((System.Int32.TryParse(s:  this.lastShownSecondaryGameMode, result: out  0)) == false)
        {
                return (bool)val_9;
        }
        
        CategoryPacksManager val_7 = MonoSingleton<CategoryPacksManager>.Instance;
        var val_8 = ((val_7.<CurrentCategoryPackInfo>k__BackingField.packId) == 0) ? 1 : 0;
        return (bool)val_9;
        label_3:
        val_9 = 0;
        return (bool)val_9;
        label_6:
        val_9 = 1;
        return (bool)val_9;
    }
    private void CalculateCurrentTierReq()
    {
        bool val_5 = true;
        if(this.currentTier >= val_5)
        {
                return;
        }
        
        if(val_5 <= this.currentTier)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + ((this.currentTier) << 3);
        if(((true + (this.currentTier) << 3) + 32.ContainsKey(key:  "lvl")) == false)
        {
                return;
        }
        
        bool val_4 = System.Int32.TryParse(s:  (true + (this.currentTier) << 3) + 32.Item["lvl"], result: out  this.currentTierLevelReq);
    }
    private void UpdateProgressWithOffset(int offset = 0)
    {
        this.curPriorityOffset = offset;
        goto typeof(SuperStreakEventHandler).__il2cppRuntimeField_2B0;
    }
    public override void OnGameSceneInit()
    {
        var val_29;
        var val_30;
        string val_31;
        val_29 = this;
        if(this.CanEngageWithEvent() == false)
        {
            goto label_1;
        }
        
        val_30 = 1152921504879157248;
        if(WordRegion.instance == 0)
        {
            goto label_10;
        }
        
        WordRegion val_4 = WordRegion.instance;
        WordRegion val_5 = WordRegion.instance;
        this.currentStreakGoal = System.Math.Min(val1:  this.knobStreakGoal, val2:  (WordRegion.__il2cppRuntimeField_cctor_finished + 24 - 1)>>0&0xFFFFFFFF);
        this.currentStreak = this.GetStreak();
        this.inStreak = false;
        this.curPriorityOffset = this.priorityOffset;
        this.lastLevelShowAt = PlayingLevel.GetCurrentPlayerLevelNumber();
        this.levelsLapsedSinceLastShown = 0;
        this.lastShownGameMode = PlayingLevel.CurrentGameplayMode;
        val_31 = 0;
        if(this.lastShownGameMode == 4)
        {
                CategoryPacksManager val_12 = MonoSingleton<CategoryPacksManager>.Instance;
            val_31 = val_12.<CurrentCategoryPackInfo>k__BackingField.packId.ToString();
        }
        
        this.lastShownSecondaryGameMode = val_31;
        object val_14 = EnumerableExtentions.GetOrDefault<System.String, System.Object>(dic:  this.myEventData, key:  "eventPrompted", defaultValue:  null);
        if(null == null)
        {
                WGWindowManager val_16 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SuperStreakPopup>(showNext:  false);
            EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "eventPrompted", newValue:  true);
        }
        
        this.SaveData();
        MonoSingleton<WGFlyoutManager>.Instance.ShowUGUIMonolith<WGMessageFlyout>(showNext:  false).SetupMessage(message:  System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "ssw_level_start", defaultValue:  "Super Streak Level!", useSingularKey:  false), arg1:  Localization.Localize(key:  "ssw_level_start_2", defaultValue:  "Use HINTS to help keep your streak alive!", useSingularKey:  false)), displaySeconds:  3f, startAction:  0);
        return;
        label_1:
        this.curPriorityOffset = -this.priorityOffset;
        val_29 = ???;
        val_30 = ???;
        goto typeof(SuperStreakEventHandler).__il2cppRuntimeField_2B0;
        label_10:
        UnityEngine.Debug.LogError(message:  "Super Streak Game Init Error");
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        levelsProgressed = this.levelsLapsedSinceLastShown + levelsProgressed;
        this.levelsLapsedSinceLastShown = levelsProgressed;
        if(this.WasPlayingEvent() == false)
        {
                return;
        }
        
        if(this.currentStreak < this.currentStreakGoal)
        {
            goto label_2;
        }
        
        int val_8 = this.levelsCompletedThisTier;
        val_8 = val_8 + 1;
        this.levelsCompletedThisTier = val_8;
        if(val_8 >= this.currentTierLevelReq)
        {
            goto label_3;
        }
        
        MonoSingleton<WGFlyoutManager>.Instance.ShowUGUIMonolith<WGMessageFlyout>(showNext:  false).SetupMessage(message:  Localization.Localize(key:  "super_streak_completed_exc", defaultValue:  "Super Streak Level Complete!", useSingularKey:  false), displaySeconds:  3f, startAction:  0);
        label_2:
        this.SaveData();
        return;
        label_3:
        WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SuperStreakPopup>(showNext:  false);
    }
    public override void OnValidWordSubmitted(string word)
    {
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        int val_2 = this.currentStreak;
        if((val_2 < this.currentStreakGoal) && (this.inStreak != false))
        {
                val_2 = val_2 + 1;
            this.currentStreak = val_2;
        }
        
        this.curPriorityOffset = 0;
        this.inStreak = true;
        this.UpdateStreakData();
    }
    public override void OnInvalidWordSubmitted()
    {
        UnityEngine.GameObject val_8;
        if(this.CanEngageWithEvent() == false)
        {
                return;
        }
        
        this.inStreak = false;
        if(((this.currentStreak >= 1) && (this.shouldSeeFtux != false)) && (this.hasSeenBreakFtux != true))
        {
                WGEventButton_Game val_4 = UnityEngine.Object.FindObjectOfType<WGEventButton_Game>();
            val_8 = val_4;
            if(val_4 != 0)
        {
                val_8 = val_4.event_button.gameObject;
            MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0).ShowToolTip(objToToolTip:  val_8, text:  Localization.Localize(key:  "streak_break_ftux_tooltip", defaultValue:  "The streak count will reset when you break the word streak!", useSingularKey:  false), topToolTip:  true, displayDuration:  2f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
            this.hasSeenBreakFtux = true;
        }
        
        }
        
        if(this.currentStreak < this.currentStreakGoal)
        {
                this.currentStreak = 0;
        }
        
        this.curPriorityOffset = 0;
        this.UpdateStreakData();
    }
    public override bool IsRewardReadyToCollect()
    {
        return (bool)(this.levelsCompletedThisTier >= this.currentTierLevelReq) ? 1 : 0;
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "super_streak_upper", defaultValue:  "SUPER STREAK", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        System.Object[] val_6;
        int val_7;
        if(this.CanEngageWithEvent() != false)
        {
                object[] val_2 = new object[4];
            val_6 = val_2;
            val_6[0] = Localization.Localize(key:  "streak_upper", defaultValue:  "STREAK", useSingularKey:  false);
            val_6[1] = System.Environment.NewLine;
            val_6[2] = this.currentStreak;
            val_6[3] = this.currentStreakGoal;
            string val_5 = System.String.Format(format:  "{0} {1}{2}/{3}", args:  val_2);
            return (string)val_7;
        }
        
        val_7 = System.String.alignConst;
        return (string)val_7;
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "super_streak_upper", defaultValue:  "SUPER STREAK", useSingularKey:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SuperStreakPopup>(showNext:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<SuperStreakPopup>(showNext:  false);
    }
    public override bool EventCompleted()
    {
        return (bool)(this.currentTier >= this.tierData) ? 1 : 0;
    }
    public override int LastProgressTimestamp()
    {
        return SuperStreakEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        int val_1 = ServerHandler.UnixServerTime;
        val_1 = this.curPriorityOffset + val_1;
        SuperStreakEventHandler.LastProgressTimestampPref = val_1;
        this.UpdateProgress();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_5 = (float)this.levelsCompletedThisTier;
        val_5 = val_5 / (float)this.currentTierLevelReq;
        loader.LoadStrictlyTypeNamedPrefab<SuperStreakEventItem>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  this.levelsCompletedThisTier.ToString(), arg1:  this.currentTierLevelReq.ToString()), sliderValue:  val_5);
    }
    public override string GetHackPanelEventData()
    {
        int val_23;
        int val_24;
        int val_25;
        int val_26;
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        object[] val_2 = new object[7];
        val_2[0] = "last level shown at ";
        val_23 = val_2.Length;
        val_2[1] = this.lastLevelShowAt;
        val_23 = val_2.Length;
        val_2[2] = " inside mode ";
        val_24 = val_2.Length;
        val_2[3] = this.lastShownGameMode.ToString();
        val_24 = val_2.Length;
        val_2[4] = " (secondary id: ";
        val_25 = val_2.Length;
        val_2[5] = this.lastShownSecondaryGameMode;
        val_25 = val_2.Length;
        val_2[6] = ")";
        System.Text.StringBuilder val_8 = val_1.AppendLine(value:  +val_2);
        System.Text.StringBuilder val_11 = val_1.AppendLine(value:  "levels completed this tier " + this.levelsCompletedThisTier.ToString());
        System.Text.StringBuilder val_13 = val_1.AppendLine(value:  "level req for this tier " + this.currentTierLevelReq);
        int val_23 = this.currentTier;
        val_23 = val_23 + 1;
        System.Text.StringBuilder val_15 = val_1.AppendLine(value:  "current tier " + val_23);
        object[] val_16 = new object[4];
        val_16[0] = "current streak ";
        val_26 = val_16.Length;
        val_16[1] = this.currentStreak;
        val_26 = val_16.Length;
        val_16[2] = " current goal ";
        val_16[3] = this.currentStreakGoal;
        System.Text.StringBuilder val_18 = val_1.AppendLine(value:  +val_16);
        System.Text.StringBuilder val_19 = val_1.AppendLine(value:  val_16.Length + 96);
        System.Text.StringBuilder val_20 = val_1.AppendLine(value:  "JSON KNOB DATA");
        System.Text.StringBuilder val_22 = val_1.AppendLine(value:  PrettyPrint.printJSON(obj:  public System.Boolean System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Vector2Int>::ContainsKey(System.Int32 key), types:  false, singleLineOutput:  false));
        return (string)val_1;
    }
    public override void BreakStreak()
    {
        goto typeof(SuperStreakEventHandler).__il2cppRuntimeField_600;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        bool val_3;
        if(this.CanEngageWithEvent() != false)
        {
                var val_2 = (this.currentStreak >= this.currentStreakGoal) ? 1 : 0;
        }
        else
        {
                val_3 = false;
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  currentData, key:  "Super Streak Level Completed", newValue:  val_3);
    }
    public GameEventRewardType GetRewardType()
    {
        int val_9;
        bool val_9 = true;
        val_9 = this.currentTier;
        if(val_9 > val_9)
        {
                return 0;
        }
        
        if(val_9 <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + ((this.currentTier) << 3);
        if(((true + (this.currentTier) << 3) + 32) == 0)
        {
                return 0;
        }
        
        var val_1 = ((((true + (this.currentTier) << 3) + 32 + 200 + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? ((true + (this.currentTier) << 3) + 32) : 0;
        return 0;
    }
    public int GetCoinRewardForTier()
    {
        int val_9;
        var val_10;
        val_9 = this;
        bool val_9 = true;
        val_10 = 0;
        if(this.GetRewardType() != 1)
        {
                return (int)val_10;
        }
        
        val_9 = this.currentTier;
        if(val_9 <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + ((this.currentTier) << 3);
        if(((true + (this.currentTier) << 3) + 32) != 0)
        {
                var val_2 = ((((true + (this.currentTier) << 3) + 32 + 200 + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? ((true + (this.currentTier) << 3) + 32) : 0;
        }
        
        val_10 = 0;
        return (int)val_10;
    }
    public void CollectReward()
    {
        if(this.TryCollect() != false)
        {
                int val_5 = this.currentTier;
            this.levelsCompletedThisTier = 0;
            val_5 = val_5 + 1;
            this.currentTier = val_5;
            this.CalculateCurrentTierReq();
            this.SaveData();
            return;
        }
        
        this = "error while trying to collect super streak reward of type " + this.GetRewardType().ToString();
        UnityEngine.Debug.LogError(message:  this);
    }
    private bool TryCollect()
    {
        int val_8;
        var val_9;
        val_8 = this;
        if(this.levelsCompletedThisTier >= this.currentTierLevelReq)
        {
            goto label_1;
        }
        
        label_5:
        val_9 = 0;
        return (bool)val_9;
        label_1:
        GameEventRewardType val_1 = this.GetRewardType();
        if(val_1 == 4)
        {
            goto label_3;
        }
        
        if(val_1 == 3)
        {
            goto label_4;
        }
        
        if(val_1 != 1)
        {
            goto label_5;
        }
        
        val_9 = val_8;
        int val_2 = this.GetCoinRewardForTier();
        if(val_2 == 0)
        {
                return (bool)val_9;
        }
        
        val_8 = val_2;
        decimal val_3 = System.Decimal.op_Implicit(value:  val_8);
        CurrencyController.CreditBalance(value:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, source:  "Super Streak Weekend", externalParams:  0, animated:  false);
        goto label_15;
        label_4:
        GameBehavior val_4 = App.getBehavior;
        val_8 = val_4.<metaGameBehavior>k__BackingField;
        mem2[0] = "Super Streak Weekend";
        goto label_15;
        label_3:
        GameBehavior val_6 = App.getBehavior;
        val_8 = val_6.<metaGameBehavior>k__BackingField;
        mem2[0] = "Super Streak Weekend";
        label_15:
        val_9 = 1;
        return (bool)val_9;
    }
    private void UpdateStreakData()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1;
        var val_3;
        val_1 = this;
        if(this.currentStreak != 0)
        {
                if(this.currentStreak < this.currentStreakGoal)
        {
                return;
        }
        
            val_1 = this.myEventData;
            val_3 = null;
        }
        else
        {
                val_1 = this.myEventData;
            val_3 = null;
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  val_1, key:  "lastStreak", newValue:  0);
    }
    private int GetStreak()
    {
        var val_7;
        if(this.lastLevelShowAt != PlayingLevel.GetCurrentPlayerLevelNumber())
        {
            goto label_3;
        }
        
        if((this.myEventData.ContainsKey(key:  "lastStreak")) == false)
        {
            goto label_5;
        }
        
        int val_5 = 0;
        bool val_6 = System.Int32.TryParse(s:  this.myEventData.Item["lastStreak"], result: out  val_5);
        val_7 = val_5;
        return (int)val_7;
        label_3:
        EnumerableExtentions.SetOrAdd<System.String, System.Object>(dic:  this.myEventData, key:  "lastStreak", newValue:  0);
        label_5:
        val_7 = 0;
        return (int)val_7;
    }
    public SuperStreakEventHandler()
    {
        this.currentTierLevelReq = 3;
        this.levelInterval = 5;
        this.knobStreakGoal = 0;
        this.priorityOffset = 600;
        this.shouldSeeFtux = true;
        System.Collections.Generic.List<System.Object> val_1 = new System.Collections.Generic.List<System.Object>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "lvl", value:  2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "coins", value:  25);
        val_2.Add(key:  "rwd", value:  val_3);
        val_1.Add(item:  val_2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "lvl", value:  3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "coins", value:  75);
        val_4.Add(key:  "rwd", value:  val_5);
        val_1.Add(item:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_6.Add(key:  "lvl", value:  5);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7.Add(key:  "coins", value:  150);
        val_6.Add(key:  "rwd", value:  val_7);
        val_1.Add(item:  val_6);
        this.tierData = val_1;
    }

}

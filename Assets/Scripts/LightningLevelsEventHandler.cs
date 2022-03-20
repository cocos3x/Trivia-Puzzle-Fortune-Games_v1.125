using UnityEngine;
public class LightningLevelsEventHandler : WGEventHandler
{
    // Fields
    public const string LIGHTNING_LEVELS_EVENT_ID = "LightningLevels";
    private static LightningLevelsEventHandler <Instance>k__BackingField;
    private int <CacheOverallEventProgress>k__BackingField;
    public LightningLevelsEcon Econ;
    protected LightningLevelsEventPrgress eventProgress;
    protected LightningLevelsLevelProgress levelProgress;
    private SceneType previousScene;
    private bool isLevelClearSuccessful;
    
    // Properties
    public static LightningLevelsEventHandler Instance { get; set; }
    public override int PointsCollected { get; }
    public override int PointsRequired { get; }
    public int CacheOverallEventProgress { get; set; }
    protected virtual LightingEventProgress EventProgress { get; }
    protected virtual LightningLevelProgress LevelProgress { get; }
    
    // Methods
    public static LightningLevelsEventHandler get_Instance()
    {
        return (LightningLevelsEventHandler)LightningLevelsEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(LightningLevelsEventHandler value)
    {
        LightningLevelsEventHandler.<Instance>k__BackingField = value;
    }
    public override int get_PointsCollected()
    {
        if(this.eventProgress != null)
        {
                return (int)this;
        }
        
        throw new NullReferenceException();
    }
    public override int get_PointsRequired()
    {
        if(this.Econ != null)
        {
                return (int)this.Econ.RequiredLevels;
        }
        
        throw new NullReferenceException();
    }
    public int get_CacheOverallEventProgress()
    {
        return (int)this.<CacheOverallEventProgress>k__BackingField;
    }
    protected void set_CacheOverallEventProgress(int value)
    {
        this.<CacheOverallEventProgress>k__BackingField = value;
    }
    protected virtual LightingEventProgress get_EventProgress()
    {
        return (LightingEventProgress)this.eventProgress;
    }
    protected virtual LightningLevelProgress get_LevelProgress()
    {
        return (LightningLevelProgress)this.levelProgress;
    }
    public override void Init(GameEventV2 eventV2)
    {
        LightningLevelsEventHandler.<Instance>k__BackingField = this;
        mem[1152921516492807952] = eventV2;
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void LightningLevelsEventHandler::OnSceneLoaded(SceneType sType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        this.<CacheOverallEventProgress>k__BackingField = this.eventProgress;
        return;
        label_6:
    }
    private void OnSceneLoaded(SceneType sType)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        this.previousScene = sType;
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_4;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_4;
        }
        
        label_10:
        val_4 = 0;
        return (bool)val_4;
        label_4:
        if(context == 5)
        {
                var val_3 = (this.isLevelClearSuccessful == true) ? 1 : 0;
            return (bool)val_4;
        }
        
        if((this & 1) != 0)
        {
                val_4 = 1;
            return (bool)val_4;
        }
        
        if(this.levelProgress < 1)
        {
            goto label_10;
        }
        
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_870;
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        if(S0 >= 0)
        {
            goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_880;
        }
    
    }
    public override void OnEventEnded()
    {
        LightningLevelsEventHandler.<Instance>k__BackingField = 0;
        goto typeof(LightningLevelsEventPrgress).__il2cppRuntimeField_190;
    }
    public override void OnGameSceneInit()
    {
        int val_8;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        if(S0 >= 1f)
        {
                return;
        }
        
        if((this.levelProgress < 1) || ((this & 1) == 0))
        {
            goto label_10;
        }
        
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_8C0;
        label_10:
        if((this & 1) == 0)
        {
                return;
        }
        
        mem2[0] = (CategoryPacksManager.IsPlaying != true) ? 4 : (0 + 1);
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_18;
        }
        
        CategoryPacksManager val_7 = MonoSingleton<CategoryPacksManager>.Instance;
        val_8 = val_7.<CurrentCategoryPackInfo>k__BackingField.packId;
        if(this.levelProgress != null)
        {
            goto label_23;
        }
        
        return;
        label_18:
        val_8 = 0;
        label_23:
        mem2[0] = val_8;
        mem2[0] = 1;
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_8C0;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        int val_6 = this.eventProgress.CurrentInterval;
        val_6 = val_6 + 1;
        this.eventProgress.CurrentInterval = val_6;
        if((this & 1) != 0)
        {
                mem2[0] = (typeof(LightningLevelsEventHandler).__il2cppRuntimeField_8A0 + 1);
            this.isLevelClearSuccessful = true;
            mem2[0] = 0;
            mem2[0] = 0;
        }
        
        if(this.InExpireInterval() == true)
        {
                return;
        }
        
        if(this.eventProgress.CurrentInterval != this.eventProgress.DefinedInterval)
        {
                return;
        }
        
        mem2[0] = 0;
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_860;
    }
    protected virtual void ExecuteLevelCompleteSuccessAction()
    {
        if(S0 >= 1f)
        {
            goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_880;
        }
    
    }
    public override bool EventCompleted()
    {
        if(this.eventProgress != null)
        {
                return (bool)this;
        }
        
        throw new NullReferenceException();
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_4F0;
    }
    public override void MarkEventRewarded()
    {
        UnityEngine.Object val_9;
        if(this.Econ.RewardType == 4)
        {
            goto label_2;
        }
        
        if(this.Econ.RewardType != 3)
        {
            goto label_20;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.GetWindow<BonusGameWheelPopup>();
        val_9 = 0;
        if(val_2 == val_9)
        {
            goto label_20;
        }
        
        val_9 = 0;
        if(val_2.enabled == false)
        {
            goto label_20;
        }
        
        mem2[0] = 0;
        goto label_20;
        label_2:
        WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.GetWindow<BonusGameSlotMachinePopup>();
        val_9 = 0;
        if(val_6 != val_9)
        {
                val_9 = 0;
            if(val_6.enabled != false)
        {
                val_6.waitingForGeneration = 0;
        }
        
        }
        
        label_20:
        mem2[0] = 1;
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_2B0;
    }
    public override int LastProgressTimestamp()
    {
        if(this.eventProgress != null)
        {
                return (int)this;
        }
        
        throw new NullReferenceException();
    }
    public override void UpdateProgress()
    {
        mem2[0] = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        var val_2;
        if(S0 >= 1f)
        {
                return (bool)(this.eventProgress == 0) ? 1 : 0;
        }
        
        val_2 = 0;
        return (bool)(this.eventProgress == 0) ? 1 : 0;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_1;
        var val_2;
        val_1 = this;
        if((val_1 & 1) != 0)
        {
                return;
        }
        
        val_1 = 1152921504887996416;
        val_2 = null;
        val_2 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 73;
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_1;
        var val_2;
        val_1 = this;
        if((val_1 & 1) != 0)
        {
                return;
        }
        
        val_1 = 1152921504887996416;
        val_2 = null;
        val_2 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 74;
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "<size={0}>{1}\n{2}</size>", arg0:  "25", arg1:  this, arg2:  this);
    }
    public override string GetGameButtonText()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_810;
    }
    public override string GetEventDisplayName()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_920;
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentLightningLevels val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentLightningLevels>(allowMultiple:  false);
        goto typeof(EventListItemContentLightningLevels).__il2cppRuntimeField_180;
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Lightning Level", value:  0);
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventProgressUI = eventProgressUI;
        .<>4__this = this;
        .eventButton = eventButton;
        return (System.Collections.IEnumerator)new LightningLevelsEventHandler.<DoLevelCompleteEventProgressAnimation>d__43();
    }
    public bool IsLightningStrikenLevel()
    {
        if(this.levelProgress == null)
        {
                return false;
        }
        
        return (bool)(this.levelProgress != 0) ? 1 : 0;
    }
    public virtual string GetLightningEventProgress(bool spaced = False)
    {
        return (string)System.String.Format(format:  "{0}{1}{2}", arg0:  this.eventProgress, arg1:  (spaced != true) ? " / " : "/", arg2:  this.Econ.RequiredLevels);
    }
    public virtual float GetEventProgressValue()
    {
        float val_1 = (float)S0;
        val_1 = val_1 / (float)this.Econ.RequiredLevels;
        return (float)val_1;
    }
    public virtual System.TimeSpan GetLightningElapsed()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this}, d2:  new System.DateTime() {dateData = val_1.dateData});
    }
    public virtual void PauseTimer()
    {
        double val_1 = this.TotalSeconds;
        val_1 = (val_1 == Infinity) ? (-val_1) : (val_1);
        int val_2 = (int)val_1;
        val_2 = val_2 + 1;
        mem2[0] = val_2;
    }
    public virtual void ResumeTimer()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = val_1.dateData.AddSeconds(value:  (double)this.levelProgress);
        mem2[0] = val_2.dateData;
    }
    public virtual void ResetTimer()
    {
        mem2[0] = 0;
        goto typeof(LightningLevelsLevelProgress).__il2cppRuntimeField_180;
    }
    public virtual bool IsPlayingLightningLevel()
    {
        var val_7;
        CategoryPackInfo val_8;
        val_7 = this;
        if(this.levelProgress == null)
        {
                return (bool)((val_7 == (val_3.<CurrentCategoryPackInfo>k__BackingField.packId)) ? 1 : 0) & 1;
        }
        
        if(this.levelProgress == 1)
        {
                val_8 = CategoryPacksManager.IsPlaying ^ 1;
            return (bool)((val_7 == (val_3.<CurrentCategoryPackInfo>k__BackingField.packId)) ? 1 : 0) & 1;
        }
        
        CategoryPacksManager val_2 = MonoSingleton<CategoryPacksManager>.Instance;
        val_8 = val_2.<CurrentCategoryPackInfo>k__BackingField;
        if(val_8 == null)
        {
                return (bool)((val_7 == (val_3.<CurrentCategoryPackInfo>k__BackingField.packId)) ? 1 : 0) & 1;
        }
        
        CategoryPacksManager val_3 = MonoSingleton<CategoryPacksManager>.Instance;
        return (bool)((val_7 == (val_3.<CurrentCategoryPackInfo>k__BackingField.packId)) ? 1 : 0) & 1;
    }
    public virtual void ShowLightningPopup()
    {
        var val_12;
        var val_13;
        var val_14;
        val_12 = 1152921504893161472;
        val_13 = 1152921513412338272;
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(41975808 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_12 = ???;
            val_14 = ???;
            val_13 = ???;
        }
        else
        {
                WGWindowManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ShowUGUIMonolith<WGLightningLevelsPopup>(showNext:  false);
        }
    
    }
    public virtual void ShowLightningProgressInGamePopup()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetUp(handler:  this, onCLoseCallback:  0);
    }
    public bool IsLightningPeriod()
    {
        goto typeof(LightningLevelsEventHandler).__il2cppRuntimeField_8A0;
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
    public void ShowInternetRequiredPopup()
    {
        int val_8;
        var val_9;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_8 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_8 = val_6.Length;
        val_6[1] = "NULL";
        val_9 = null;
        val_9 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public bool HasValidQueuedWindows()
    {
        var val_7;
        if((MonoSingleton<WGWindowManager>.Instance.HasQueuedWindows()) != false)
        {
                val_7 = (MonoSingleton<WGWindowManager>.Instance.GetWindow<WGChallengeFlyout>().isActiveAndEnabled) ^ 1;
            return (bool)val_7 & 1;
        }
        
        val_7 = 0;
        return (bool)val_7 & 1;
    }
    public bool InExpireInterval()
    {
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 504464731990392832})) != false)
        {
                System.DateTime val_2 = DateTimeCheat.UtcNow;
            return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_2.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28});
        }
        
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = typeof(DateTimeCheat).__il2cppRuntimeField_28})) == false)
        {
                return false;
        }
        
        System.DateTime val_5 = DateTimeCheat.UtcNow;
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_5.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48});
    }
    protected virtual bool IsLightningValidAndSuccess()
    {
        var val_3;
        if(this.InExpireInterval() != true)
        {
                if(this.TotalSeconds >= 0f)
        {
            goto label_1;
        }
        
        }
        
        val_3 = 0;
        return false;
        label_1:
        val_3 = this;
        return false;
    }
    protected virtual void StartTimer()
    {
        WordRegion val_1 = WordRegion.instance;
        mem2[0] = (WordRegion.__il2cppRuntimeField_cctor_finished + 24 * this.Econ.SecondsPerWord);
        System.DateTime val_3 = DateTimeCheat.Now;
        System.DateTime val_5 = val_3.dateData.AddSeconds(value:  (double)((WordRegion.__il2cppRuntimeField_cctor_finished + 24 * this.Econ.SecondsPerWord) + 1));
        mem2[0] = val_5.dateData;
    }
    protected virtual void ShowLightningUI()
    {
        LightningLevelsUIController val_1 = MonoSingleton<LightningLevelsUIController>.Instance;
        if(null == null)
        {
                return;
        }
        
        mem2[0] = 0;
        this = ???;
        goto typeof(LightningLevelsEventPrgress).__il2cppRuntimeField_180;
    }
    protected virtual bool IsReady()
    {
        var val_2;
        if(this.eventProgress.CurrentInterval == 1)
        {
            goto label_1;
        }
        
        if(this.eventProgress.CurrentInterval != this.eventProgress.DefinedInterval)
        {
            goto label_2;
        }
        
        var val_1 = (this.levelProgress == 0) ? 1 : 0;
        return (bool)val_2;
        label_1:
        val_2 = 1;
        return (bool)val_2;
        label_2:
        val_2 = 0;
        return (bool)val_2;
    }
    protected virtual void ResetInterval()
    {
        this.eventProgress.CurrentInterval = 0;
        int val_3 = this.Econ.IntervalMax;
        val_3 = (UnityEngine.Random.Range(min:  this.Econ.IntervalMin, max:  val_3 + 1)) + 1;
        this.eventProgress.DefinedInterval = val_3;
        goto typeof(LightningLevelsEventPrgress).__il2cppRuntimeField_180;
    }
    protected virtual void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        string val_9;
        if((System.String.op_Inequality(a:  0, b:  "LightningLevels")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + public EventQueueEntry System.Collections.Generic.List<EventQueueEntry>::get_Item(int index)(public EventQueueEntry System.Collections.Generic.List<EventQueueEntry>::get_Item(int index)));
            return;
        }
        
        if((this & 1) != 0)
        {
                mem2[0] = LightningLevelsEventHandler.__il2cppRuntimeField_name;
        }
        else
        {
                val_9 = "rewarded";
            if((data.ContainsKey(key:  val_9)) != false)
        {
                val_9 = 0;
            bool val_5 = System.Boolean.Parse(value:  data.Item["rewarded"]);
            var val_6 = (System.Boolean.__il2cppRuntimeField_cctor_finished == 0) ? 1 : 0;
            val_6 = val_5 | val_6;
            mem2[0] = val_5;
        }
        
        }
        
        this.Econ = this.levelProgress.ParseEventEcon(data:  data);
        goto typeof(LightningLevelsEventPrgress).__il2cppRuntimeField_180;
    }
    protected virtual bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress != (X9 + 16)) ? 1 : 0;
    }
    protected virtual void ResetEventProgress()
    {
        LightningLevelsLevelProgress val_1 = null;
        mem[1152921516498771856] = 1;
        mem[1152921516498771868] = 0;
        val_1 = new LightningLevelsLevelProgress();
        this.levelProgress = val_1;
        mem[1152921516498775952] = 1;
        mem[1152921516498775956] = 0;
        mem[1152921516498775960] = 0;
        mem[1152921516498775964] = ;
        this.eventProgress = new LightningLevelsEventPrgress();
    }
    protected virtual string GetLightningEventNameLoc()
    {
        return Localization.Localize(key:  "lightning_levels_upper", defaultValue:  "LIGHTNING LEVELS", useSingularKey:  false);
    }
    protected virtual void UpdateRewardStatus()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "rewarded", value:  true);
        this.UpdateToServer(data:  val_1);
    }
    protected void UpdateToServer(System.Collections.Generic.Dictionary<string, object> data)
    {
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  data);
    }
    private LightningLevelsEcon ParseEventEcon(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_9;
        string val_10;
        var val_37;
        var val_38;
        string val_39;
        var val_40;
        var val_41;
        var val_42;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_36 = data;
        LightningLevelsEcon val_1 = null;
        .Reward = ;
        .RewardType = ;
        .IntervalMax = 7;
        .SecondsPerWord = 15;
        val_1 = new LightningLevelsEcon();
        if(val_36 == null)
        {
                return val_1;
        }
        
        val_37 = "economy";
        if((val_36.ContainsKey(key:  "economy")) == false)
        {
                return val_1;
        }
        
        object val_3 = val_36.Item["economy"];
        if(val_3 == null)
        {
                return val_1;
        }
        
        val_36 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        if((val_36.ContainsKey(key:  "rew")) == false)
        {
            goto label_7;
        }
        
        object val_5 = val_36.Item["rew"];
        Dictionary.Enumerator<TKey, TValue> val_7 = GetEnumerator();
        label_21:
        val_38 = public System.Boolean Dictionary.Enumerator<System.String, System.Object>::MoveNext();
        if(val_9.MoveNext() == false)
        {
            goto label_13;
        }
        
        val_40 = val_10;
        val_39 = val_10;
        int val_12 = 0;
        if(val_39 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_12 < 1) || (((System.Int32.TryParse(s:  val_39, result: out  val_12)) ^ 1) == true))
        {
            goto label_21;
        }
        
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = 0;
        string val_15 = val_40.Trim();
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        string val_16 = val_15.ToLower();
        if((System.String.Compare(strA:  val_16, strB:  "coins")) == 0)
        {
            goto label_19;
        }
        
        if((System.String.Compare(strA:  val_16, strB:  "bonus_wheel")) == 0)
        {
            goto label_20;
        }
        
        if((System.String.Compare(strA:  val_16, strB:  "bonus_spin")) != 0)
        {
            goto label_21;
        }
        
        val_41 = 4;
        goto label_24;
        label_13:
        val_42 = 0;
        val_41 = 0;
        goto label_23;
        label_19:
        val_41 = 1;
        goto label_24;
        label_20:
        val_41 = 3;
        label_24:
        val_42 = val_12;
        label_23:
        val_9.Dispose();
        .Reward = (val_41 == 0) ? 200 : (val_42);
        .RewardType = (val_41 != 0) ? (val_41) : (0 + 1);
        label_7:
        if((val_36.ContainsKey(key:  "req_lvl")) != false)
        {
                .RequiredLevels = System.Int32.Parse(s:  val_36.Item["req_lvl"]);
        }
        
        if((val_36.ContainsKey(key:  "interval")) != false)
        {
                object val_26 = val_36.Item["interval"];
            if((val_26.ContainsKey(key:  "min")) != false)
        {
                .IntervalMin = System.Int32.Parse(s:  val_26.Item["min"]);
        }
        
            if((val_26.ContainsKey(key:  "max")) != false)
        {
                .IntervalMax = System.Int32.Parse(s:  val_26.Item["max"]);
        }
        
        }
        
        val_37 = "sec_per_wd";
        if((val_36.ContainsKey(key:  "sec_per_wd")) == false)
        {
                return val_1;
        }
        
        .SecondsPerWord = System.Int32.Parse(s:  val_36.Item["sec_per_wd"]);
        return val_1;
    }
    public LightningLevelsEventHandler()
    {
        mem[1152921516499473684] = 0;
        mem[1152921516499473688] = 0;
        mem[1152921516499473680] = 1;
        mem[1152921516499473692] = ;
        this.eventProgress = new LightningLevelsEventPrgress();
        LightningLevelsLevelProgress val_2 = null;
        mem[1152921516499477776] = 1;
        mem[1152921516499477788] = 0;
        val_2 = new LightningLevelsLevelProgress();
        this.levelProgress = val_2;
    }

}

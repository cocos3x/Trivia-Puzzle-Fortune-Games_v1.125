using UnityEngine;
public class RaidMadnessEventHandler : WGEventHandler
{
    // Fields
    public const string RAID_MADNESS_EVENT_ID = "RaidMadness";
    public const string EVENT_TRACKING_ID = "Raid Madness";
    private RaidMadnessEcon econ;
    private RaidMadnessProgress progressData;
    protected bool suppressRewardCollectionPopup;
    protected bool isEventInitialized;
    private static RaidMadnessEventHandler <Instance>k__BackingField;
    private int <ProgressDisplayPoints>k__BackingField;
    private int <EventButtonDisplayPoints>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public RaidMadnessEcon Econ { get; }
    public RaidMadnessProgress ProgressData { get; }
    public static RaidMadnessEventHandler Instance { get; set; }
    public int PlayerTier { get; set; }
    public int ProgressLevel { get; set; }
    public int PlayerLevel { get; }
    public override int UnlockLevel { get; }
    public System.DateTime TimeExpire { get; }
    public override bool IsPointCollection { get; }
    public override int PointsCollected { get; set; }
    public override int PointsRequired { get; }
    public int PointsCollectedForCurrentLevel { get; set; }
    public int ProgressDisplayPoints { get; set; }
    public int EventButtonDisplayPoints { get; set; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)RaidMadnessEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(RaidMadnessEventHandler).__il2cppRuntimeField_4A0;
    }
    public RaidMadnessEcon get_Econ()
    {
        return (RaidMadnessEcon)this.econ;
    }
    public RaidMadnessProgress get_ProgressData()
    {
        return (RaidMadnessProgress)this.progressData;
    }
    public static RaidMadnessEventHandler get_Instance()
    {
        return (RaidMadnessEventHandler)RaidMadnessEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(RaidMadnessEventHandler value)
    {
        RaidMadnessEventHandler.<Instance>k__BackingField = value;
    }
    public int get_PlayerTier()
    {
        if(this.progressData != null)
        {
                return (int)this.progressData.playerTierAtEventStart;
        }
        
        throw new NullReferenceException();
    }
    protected void set_PlayerTier(int value)
    {
        if(this.progressData != null)
        {
                this.progressData.playerTierAtEventStart = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public int get_ProgressLevel()
    {
        if(this.progressData != null)
        {
                return (int)this.progressData.rewardProgressLevel;
        }
        
        throw new NullReferenceException();
    }
    protected void set_ProgressLevel(int value)
    {
        if(this.progressData != null)
        {
                this.progressData.rewardProgressLevel = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public int get_PlayerLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_360;
    }
    public override int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return UnityEngine.Mathf.Max(a:  val_1.events_unlockLevel, b:  this.econ.unlockPlayerLevel);
    }
    public System.DateTime get_TimeExpire()
    {
        if(X8 != 0)
        {
                return (System.DateTime)X8 + 48;
        }
        
        throw new NullReferenceException();
    }
    public override bool get_IsPointCollection()
    {
        return true;
    }
    public override int get_PointsCollected()
    {
        if(this.progressData != null)
        {
                return (int)this.progressData.pointsCollected;
        }
        
        throw new NullReferenceException();
    }
    public override void set_PointsCollected(int value)
    {
        this.progressData.pointsCollected = value;
        goto typeof(RaidMadnessProgress).__il2cppRuntimeField_180;
    }
    public override int get_PointsRequired()
    {
        return (int)this;
    }
    public int get_PointsCollectedForCurrentLevel()
    {
        if(this.progressData.pointsCollectedDuringGameLevel != null)
        {
                return EnumerableExtentions.GetOrDefault<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, defaultValue:  0);
        }
        
        this.progressData.pointsCollectedDuringGameLevel = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
        this.progressData = this.progressData;
        return EnumerableExtentions.GetOrDefault<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, defaultValue:  0);
    }
    protected void set_PointsCollectedForCurrentLevel(int value)
    {
        System.Collections.Generic.Dictionary<GameplayMode, System.Int32> val_3;
        if(this.progressData.pointsCollectedDuringGameLevel == null)
        {
                System.Collections.Generic.Dictionary<GameplayMode, System.Int32> val_1 = null;
            val_3 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
            this.progressData.pointsCollectedDuringGameLevel = val_3;
            this.progressData = this.progressData;
        }
        
        EnumerableExtentions.SetOrAdd<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, newValue:  value);
    }
    public int get_ProgressDisplayPoints()
    {
        return (int)this.<ProgressDisplayPoints>k__BackingField;
    }
    protected void set_ProgressDisplayPoints(int value)
    {
        this.<ProgressDisplayPoints>k__BackingField = value;
    }
    public int get_EventButtonDisplayPoints()
    {
        return (int)this.<EventButtonDisplayPoints>k__BackingField;
    }
    protected void set_EventButtonDisplayPoints(int value)
    {
        this.<EventButtonDisplayPoints>k__BackingField = value;
    }
    public override bool ActivelyPlayingGameMode()
    {
        var val_5;
        if(this.IsCurrentEventInCycle() != false)
        {
                if(this.IsEventExpired() == false)
        {
            goto label_1;
        }
        
        }
        
        val_5 = 0;
        goto label_2;
        label_1:
        bool val_3 = this.HasCollectedAllRewards();
        val_5 = val_3 ^ 1;
        label_2:
        val_3 = val_5;
        return (bool)val_3;
    }
    public override void PreInit(GameEventV2 eventV2)
    {
        this.econ = new RaidMadnessEcon(eventDataDict:  eventV2.eventData);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516663362192] = eventV2;
        RaidMadnessEventHandler.<Instance>k__BackingField = this;
        MonoSingleton<GoalsManager>.Instance.AddRaidCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  typeof(RaidMadnessEventHandler).__il2cppRuntimeField_7E8));
        this.SetupEvent();
        this.<EventButtonDisplayPoints>k__BackingField = this;
    }
    public override void Dispose()
    {
        MonoSingleton<GoalsManager>.Instance.RemoveRaidCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  typeof(RaidMadnessEventHandler).__il2cppRuntimeField_7E8));
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "RaidMadness")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "raid_madness_upper", defaultValue:  "RAID MADNESS", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        if(this.progressData.totalPointsCollected < 1)
        {
                return System.String.Format(format:  "{0}!", arg0:  Localization.Localize(key:  "raid_upper", defaultValue:  "RAID", useSingularKey:  false));
        }
        
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.<EventButtonDisplayPoints>k__BackingField, arg1:  this);
    }
    public override string GetGameButtonText()
    {
        if(this.HasCollectedAllRewards() == false)
        {
                return (string)this.<ProgressDisplayPoints>k__BackingField.ToString();
        }
        
        string val_2 = Localization.Localize(key:  "complete_upper", defaultValue:  "COMPLETE", useSingularKey:  false);
        return (string)this.<ProgressDisplayPoints>k__BackingField.ToString();
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        return (bool)(layoutType == 1) ? 1 : 0;
    }
    public bool HasCollectedAllRewards()
    {
        int val_5;
        var val_6;
        val_5 = this;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -827475504)) != false)
        {
                val_5 = this.progressData.rewardProgressLevel;
            var val_4 = (val_5 >= (this.econ.GetTotalCollectableRewards(playerTier:  this.progressData.playerTierAtEventStart))) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public override bool EventCompleted()
    {
        if(this.IsEventExpired() == false)
        {
                return this.HasCollectedAllRewards();
        }
        
        return true;
    }
    public override bool IsChallengeCompleted()
    {
        return this.HasCollectedAllRewards();
    }
    public override bool get_IsEventValid()
    {
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -827131312);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_8;
        string val_9;
        if(this.HasCollectedAllRewards() != false)
        {
                val_8 = 1f;
        }
        else
        {
                val_8 = (1.152922E+18f) / (1.152922E+18f);
        }
        
        if(this.HasCollectedAllRewards() == false)
        {
            goto label_3;
        }
        
        val_9 = "COMPLETED!";
        if(loader != null)
        {
            goto label_4;
        }
        
        label_3:
        val_9 = System.String.Format(format:  "{0}/{1}", arg0:  this, arg1:  this);
        label_4:
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentRaidMadness>(allowMultiple:  false).SetupSlider(sliderText:  val_9, sliderValue:  val_8, eventCompleted:  this.HasCollectedAllRewards(), rewardData:  this);
    }
    public override void OnEventEnded()
    {
        this.progressData = new RaidMadnessProgress();
    }
    public override void OnMenuLoaded()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 5)
        {
                return;
        }
        
        this.ShowPopup(firstTime:  true);
    }
    public override void OnGameSceneInit()
    {
        this.<ProgressDisplayPoints>k__BackingField = this.PointsCollectedForCurrentLevel;
    }
    public override void OnGameSceneBegan()
    {
        this.ShowPopup(firstTime:  true);
    }
    public override void OnNewForestShown()
    {
        this.ShowPopup(firstTime:  true);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.ShowPopup(firstTime:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        this.ShowPopup(firstTime:  false);
    }
    public void UpdateProgressToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "player_tier", value:  this.progressData.playerTierAtEventStart);
        val_1.Add(key:  "rewards_collected", value:  this.progressData.rewardProgressLevel);
        val_1.Add(key:  "points_collected", value:  this);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.suppressRewardCollectionPopup = true;
        this.ApplyPointsEarnedInLevel();
        this.econ.rewardData = RaidMadnessEconDataHelper.ParseCSV();
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventProgressUI = eventProgressUI;
        .eventButton = eventButton;
        .<>4__this = this;
        .popup = popup;
        return (System.Collections.IEnumerator)new RaidMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__70();
    }
    private System.Collections.IEnumerator DoRewardSequence(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .popup = popup;
        .eventButton = eventButton;
        .eventProgressUI = eventProgressUI;
        return (System.Collections.IEnumerator)new RaidMadnessEventHandler.<DoRewardSequence>d__71();
    }
    public override RESEventRewardData GetCurrentReward()
    {
        if(this.progressData.currentRewardData != null)
        {
                return (RESEventRewardData)this.progressData.currentRewardData;
        }
        
        this.progressData.currentRewardData = this.econ.GetEventReward(playerTier:  this.progressData.playerTierAtEventStart, rewardProgressLevel:  this.progressData.rewardProgressLevel);
        this.progressData = this.progressData;
        return (RESEventRewardData)this.progressData.currentRewardData;
    }
    public RESEventRewardData GetFinalPrize()
    {
        return this.econ.GetFinalPrize(playerTier:  this.progressData.playerTierAtEventStart);
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        currentData.Add(key:  "Raid Madness Points", value:  this.PointsCollectedForCurrentLevel);
    }
    private void OnPointGainComplete()
    {
        if(this.IsRewardReadyToCollect() != true)
        {
                WordRegion.instance.RemoveLevelCompleteBlocker(blocker:  3);
        }
        
        this.<ProgressDisplayPoints>k__BackingField = this.PointsCollectedForCurrentLevel;
        this.UpdateProgress();
    }
    public override void OnMysteryChestCollected()
    {
        if(this.PointsCollectedForCurrentLevel <= (this.<ProgressDisplayPoints>k__BackingField))
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_3.<metaGameBehavior>k__BackingField.Setup(type:  1, points:  this.PointsCollectedForCurrentLevel - (this.<ProgressDisplayPoints>k__BackingField), initialPoints:  this.<ProgressDisplayPoints>k__BackingField, _onComplete:  new System.Action(object:  this, method:  System.Void RaidMadnessEventHandler::OnPointGainComplete()));
        WordRegion.instance.AddLevelCompleteBlocker(blocker:  3);
    }
    protected virtual void OnRaidCompleted(bool isRaidPerfect)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.HasCollectedAllRewards() == true)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        if(this.econ.pointsGainPerRaid < 1)
        {
                return;
        }
        
        this.PointsCollectedForCurrentLevel = this.econ.pointsGainPerRaid + this.PointsCollectedForCurrentLevel;
    }
    protected void ApplyPointsEarnedInLevel()
    {
        this.progressData.totalPointsCollected = this.PointsCollectedForCurrentLevel + this.progressData.totalPointsCollected;
        int val_4 = this.PointsCollectedForCurrentLevel + this;
        this.PointsCollectedForCurrentLevel = 0;
        this.UpdateProgressToServer();
    }
    protected virtual UnityEngine.GameObject ShowRewardCollection()
    {
        var val_8;
        if(this.suppressRewardCollectionPopup != false)
        {
                return 0;
        }
        
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        if(static_value_02807000 != 0)
        {
                GameBehavior val_3 = App.getBehavior;
            val_8 = val_3.<metaGameBehavior>k__BackingField;
        }
        else
        {
                WGWindowManager val_6 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WFOEventRewardPopup>(showNext:  false);
        }
        
        val_6.InitReward(title:  this, reward:  this, source:  "Raid Madness Reward", onCollectClicked:  new System.Action(object:  this, method:  typeof(RaidMadnessEventHandler).__il2cppRuntimeField_808), onClose:  0);
        return val_6.gameObject;
    }
    protected virtual void OnCurrentRewardCollected()
    {
        int val_1 = UnityEngine.Mathf.Max(a:  0, b:  0);
        int val_3 = this.progressData.rewardProgressLevel;
        val_3 = val_3 + 1;
        this.progressData.rewardProgressLevel = val_3;
        this.progressData.currentRewardData = this.econ.GetEventReward(playerTier:  this.progressData.playerTierAtEventStart, rewardProgressLevel:  this.progressData.rewardProgressLevel);
        this.<EventButtonDisplayPoints>k__BackingField = this;
        this.UpdateProgressToServer();
    }
    private bool IsEventExpired()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 48})) == false)
        {
                return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = System.DateTime.__il2cppRuntimeField_cctor_finished + 40});
        }
        
        return true;
    }
    private bool IsCurrentEventInCycle()
    {
        return (bool)(this.progressData.eventId == (X9 + 56)) ? 1 : 0;
    }
    private void ParsePlayerProgressFromServer(System.Collections.Generic.Dictionary<string, object> eventDataDict)
    {
        var val_15;
        if(eventDataDict == null)
        {
                return;
        }
        
        val_15 = "progress";
        if((eventDataDict.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        val_15 = 1152921510214912464;
        object val_2 = eventDataDict.Item["progress"];
        if((val_2.ContainsKey(key:  "player_tier")) != false)
        {
                if((System.Int32.TryParse(s:  val_2.Item["player_tier"], result: out  0)) != false)
        {
                this.progressData.playerTierAtEventStart = 0;
        }
        
        }
        
        if((val_2.ContainsKey(key:  "rewards_collected")) != false)
        {
                if((System.Int32.TryParse(s:  val_2.Item["rewards_collected"], result: out  0)) != false)
        {
                this.progressData.rewardProgressLevel = 0;
        }
        
        }
        
        if((val_2.ContainsKey(key:  "points_collected")) == false)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  val_2.Item["points_collected"], result: out  0)) == false)
        {
                return;
        }
    
    }
    private void SetupEvent()
    {
        string val_9;
        var val_10;
        if((true != 0) && (147633 != 0))
        {
                val_9 = "economy";
            if((147633.ContainsKey(key:  val_9)) != false)
        {
                val_9 = "economy";
            if(Item[val_9] != null)
        {
                RaidMadnessEcon val_3 = null;
            val_9 = System.Void System.ComponentModel.AsyncOperation::VerifyDelegateNotNull(System.Threading.SendOrPostCallback d);
            val_3 = new RaidMadnessEcon(eventDataDict:  val_9);
            this.econ = val_3;
        }
        
        }
        
        }
        
        if(this.IsEventExpired() != true)
        {
                if(this.IsCurrentEventInCycle() == true)
        {
            goto label_18;
        }
        
        }
        
        this.progressData = new RaidMadnessProgress();
        val_10 = null;
        val_10 = null;
        if(App.game == 20)
        {
                this.progressData.playerTierAtEventStart = RestaurantRivals.CommonEventEconDataHelper.GetPlayerTier();
        }
        
        label_18:
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        this.ParsePlayerProgressFromServer(eventDataDict:  App.game + 104);
        this.progressData.eventId = App.game + 56;
        this.isEventInitialized = true;
    }
    private void ShowPopup(bool firstTime = False)
    {
        if(firstTime != false)
        {
                if(this.progressData.hasSeenPopup == true)
        {
                return;
        }
        
        }
        
        int val_1 = this.PlayerLevel;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1, knobValue:  -823612016)) == false)
        {
                return;
        }
        
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance;
        if(val_1 != 0)
        {
                GameBehavior val_5 = App.getBehavior;
        }
        else
        {
                GameBehavior val_7 = App.getBehavior;
        }
        
        this.progressData.hasSeenPopup = true;
    }
    public void ResetEventProgress()
    {
        RaidMadnessProgress val_3;
        var val_4;
        val_3 = this;
        this.progressData = new RaidMadnessProgress();
        val_4 = null;
        val_4 = null;
        if(App.game != 20)
        {
                return;
        }
        
        val_3 = this.progressData;
        this.progressData.playerTierAtEventStart = RestaurantRivals.CommonEventEconDataHelper.GetPlayerTier();
    }
    private string GetPlatformId()
    {
        return "a";
    }
    public override string GetHackPanelEventData()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_8 = val_1.AppendLine(value:  "<color=#ffef00>Econ knob data:</color>");
        System.Text.StringBuilder val_11 = val_1.AppendLine(value:  System.String.Format(format:  "Player unlock level: {0}", arg0:  this.econ.unlockPlayerLevel.ToString()));
        System.Text.StringBuilder val_13 = val_1.AppendLine(value:  System.String.Format(format:  "Avg Pt Per Spin (PPS):\n      T1: {0} | T2: {1} | T3: {2}", arg0:  System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  (this.progressData.playerTierAtEventStart == 1) ? "ff9200" : "ffffff", arg1:  this.econ.avgPointPerSpinTier1), arg1:  System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  (this.progressData.playerTierAtEventStart == 2) ? "ff9200" : "ffffff", arg1:  this.econ.avgPointPerSpinTier2), arg2:  System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  (this.progressData.playerTierAtEventStart == 3) ? "ff9200" : "ffffff", arg1:  this.econ.avgPointPerSpinTier3)));
        System.Text.StringBuilder val_14 = val_1.AppendLine(value:  "<color=#ffef00>Player Stats</color>");
        System.Text.StringBuilder val_16 = val_1.AppendLine(value:  System.String.Format(format:  "Player Tier: {0}", arg0:  this.progressData.playerTierAtEventStart));
        System.Text.StringBuilder val_18 = val_1.AppendLine(value:  System.String.Format(format:  "Points Collected: {0}", arg0:  this.progressData.pointsCollected));
        System.Text.StringBuilder val_20 = val_1.AppendLine(value:  System.String.Format(format:  "Rewards Collected: {0}", arg0:  this.progressData.rewardProgressLevel));
        float val_27 = (float)this.progressData.totalPointsCollected;
        val_27 = val_27 / (float)this.progressData.totalSpinResourceSpent;
        System.Text.StringBuilder val_22 = val_1.AppendLine(value:  System.String.Format(format:  "Current Avg PPS: {0}", arg0:  val_27));
        System.Text.StringBuilder val_24 = val_1.AppendLine(value:  System.String.Format(format:  "Total Point Collected: {0}", arg0:  this.progressData.totalPointsCollected));
        System.Text.StringBuilder val_26 = val_1.AppendLine(value:  System.String.Format(format:  "Total Spin Bets: {0}", arg0:  this.progressData.totalSpinResourceSpent));
        return (string)val_1;
    }
    public RaidMadnessEventHandler()
    {
        this.econ = new RaidMadnessEcon(eventDataDict:  0);
        this.progressData = new RaidMadnessProgress();
    }

}

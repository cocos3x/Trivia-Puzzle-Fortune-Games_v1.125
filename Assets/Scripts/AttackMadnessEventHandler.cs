using UnityEngine;
public class AttackMadnessEventHandler : WGEventHandler
{
    // Fields
    public const string ATTACK_MADNESS_EVENT_ID = "AttackMadness";
    public const string EVENT_TRACKING_ID = "Attack Madness";
    private AttackMadnessEcon econ;
    private AttackMadnessProgress progressData;
    protected bool suppressRewardCollectionPopup;
    protected bool isEventInitialized;
    private static AttackMadnessEventHandler <Instance>k__BackingField;
    private bool <NeedToShowProgress>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public AttackMadnessEcon Econ { get; }
    public AttackMadnessProgress ProgressData { get; }
    public static AttackMadnessEventHandler Instance { get; set; }
    public int PlayerTier { get; set; }
    public int ProgressLevel { get; set; }
    public int PlayerLevel { get; }
    public override int UnlockLevel { get; }
    public System.DateTime TimeExpire { get; }
    public override bool IsPointCollection { get; }
    public override int PointsCollected { get; set; }
    public int PointsCollectedInLevel { get; }
    public override int PointsRequired { get; }
    public bool NeedToShowProgress { get; set; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)AttackMadnessEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(AttackMadnessEventHandler).__il2cppRuntimeField_4A0;
    }
    public AttackMadnessEcon get_Econ()
    {
        return (AttackMadnessEcon)this.econ;
    }
    public AttackMadnessProgress get_ProgressData()
    {
        return (AttackMadnessProgress)this.progressData;
    }
    public static AttackMadnessEventHandler get_Instance()
    {
        return (AttackMadnessEventHandler)AttackMadnessEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(AttackMadnessEventHandler value)
    {
        AttackMadnessEventHandler.<Instance>k__BackingField = value;
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
        goto typeof(AttackMadnessProgress).__il2cppRuntimeField_180;
    }
    public int get_PointsCollectedInLevel()
    {
        return EnumerableExtentions.GetOrDefault<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, defaultValue:  0);
    }
    public override int get_PointsRequired()
    {
        return (int)this;
    }
    public bool get_NeedToShowProgress()
    {
        return (bool)this.<NeedToShowProgress>k__BackingField;
    }
    public void set_NeedToShowProgress(bool value)
    {
        this.<NeedToShowProgress>k__BackingField = value;
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
        this.econ = new AttackMadnessEcon(eventDataDict:  eventV2.eventData);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516061524288] = eventV2;
        AttackMadnessEventHandler.<Instance>k__BackingField = this;
        MonoSingleton<GoalsManager>.Instance.AddAttackCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  typeof(AttackMadnessEventHandler).__il2cppRuntimeField_7F8));
        this.SetupEvent();
    }
    public override void Dispose()
    {
        MonoSingleton<GoalsManager>.Instance.RemoveAttackCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  typeof(AttackMadnessEventHandler).__il2cppRuntimeField_7F8));
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "AttackMadness")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "attack_madness_upper", defaultValue:  "ATTACK MADNESS", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        if(this.progressData.totalPointsCollected < 1)
        {
                return System.String.Format(format:  "{0}!", arg0:  Localization.Localize(key:  "attack_upper", defaultValue:  "ATTACK", useSingularKey:  false));
        }
        
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this, arg1:  this);
    }
    public override string GetGameButtonText()
    {
        if(this.HasCollectedAllRewards() == false)
        {
                return (string)this.PointsCollectedInLevel.ToString();
        }
        
        string val_2 = Localization.Localize(key:  "complete_upper", defaultValue:  "COMPLETE", useSingularKey:  false);
        return (string)this.PointsCollectedInLevel.ToString();
    }
    public bool HasCollectedAllRewards()
    {
        var val_5;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -1429392096)) == false)
        {
            goto label_3;
        }
        
        if(this.progressData.rewardProgressLevel >= (this.econ.GetTotalCollectableRewards(playerTier:  this.progressData.playerTierAtEventStart)))
        {
            goto label_6;
        }
        
        var val_4 = (this.progressData.playerTierAtEventStart > this.econ.rewardData.rewardListTier.Length) ? 1 : 0;
        return (bool)val_5;
        label_3:
        val_5 = 0;
        return (bool)val_5;
        label_6:
        val_5 = 1;
        return (bool)val_5;
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
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -1428998752);
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
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentAttackMadness>(allowMultiple:  false).SetupSlider(sliderText:  val_9, sliderValue:  val_8, eventCompleted:  this.HasCollectedAllRewards(), rewardData:  this);
    }
    public override void OnEventEnded()
    {
        this.progressData = new AttackMadnessProgress();
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
    public override void OnSpinBetUpdate()
    {
    
    }
    public override void OnSpinStarted()
    {
    
    }
    public override void OnSpinEnded()
    {
    
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
    public decimal GetGrandPrizeSpinAmount()
    {
        return this.econ.GetGrandPrizeSpinAmount(playerTier:  this.progressData.playerTierAtEventStart);
    }
    public RESEventRewardData GetFinalPrize()
    {
        return this.econ.GetFinalPrize(playerTier:  this.progressData.playerTierAtEventStart);
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        if(this.progressData.pointsCollectedDuringGameLevel == null)
        {
                return;
        }
        
        1152921516064693984 = currentData;
        1152921516064693984.Add(key:  "Attack Madness Points", value:  this.PointsCollectedInLevel);
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .eventButton = eventButton;
        .eventProgressUI = eventProgressUI;
        .popup = popup;
        return (System.Collections.IEnumerator)new AttackMadnessEventHandler.<DoLevelCompleteEventProgressAnimation>d__69();
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_2;
        if((this & 1) == 0)
        {
            goto label_0;
        }
        
        label_5:
        val_2 = 0;
        return (bool)val_2;
        label_0:
        if(layoutType != 1)
        {
            goto label_4;
        }
        
        if(context == 3)
        {
            goto label_5;
        }
        
        if(context == 5)
        {
                if(this.PointsCollectedInLevel < 1)
        {
            goto label_5;
        }
        
        }
        
        label_4:
        val_2 = 1;
        return (bool)val_2;
    }
    public override void OnMysteryChestCollected()
    {
        if(this.PointsCollectedInLevel < 1)
        {
                return;
        }
        
        this.ShowNewSymbolAnimation();
    }
    private System.Collections.IEnumerator PlayNextRewardSequence(WGEventButtonV2 eventButton)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .eventButton = eventButton;
        return (System.Collections.IEnumerator)new AttackMadnessEventHandler.<PlayNextRewardSequence>d__72();
    }
    private System.Collections.IEnumerator PlayPointCollectionSequence(int startValue, int points, WGEventButtonV2_AttackMadness attackMadnessButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .attackMadnessButton = attackMadnessButton;
        .<>4__this = this;
        .startValue = startValue;
        .points = points;
        .eventProgressUI = eventProgressUI;
        .popup = popup;
        return (System.Collections.IEnumerator)new AttackMadnessEventHandler.<PlayPointCollectionSequence>d__73();
    }
    private System.Collections.IEnumerator RewardSequence(WGEventButtonV2_AttackMadness attackMadnessButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .popup = popup;
        .<>4__this = this;
        .attackMadnessButton = attackMadnessButton;
        return (System.Collections.IEnumerator)new AttackMadnessEventHandler.<RewardSequence>d__74();
    }
    protected virtual void ShowRewardCollection(System.Action onCollectionClose)
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.InitReward(title:  "ATTACK MADNESS", reward:  this, source:  "Attack Madness Reward", onCollectClicked:  new System.Action(object:  this, method:  System.Void AttackMadnessEventHandler::<ShowRewardCollection>b__75_0()), onClose:  onCollectionClose);
        this.<NeedToShowProgress>k__BackingField = true;
    }
    public void ShowNewSymbolAnimation()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.Setup(type:  0, points:  this.PointsCollectedInLevel, initialPoints:  0, _onComplete:  0);
    }
    protected virtual void OnAttackCompleted(bool isSuccess)
    {
        AttackMadnessProgress val_8;
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
        
        if(this.econ.pointsGainPerAttack < 1)
        {
                return;
        }
        
        val_8 = this.progressData;
        if(this.progressData.pointsCollectedDuringGameLevel == null)
        {
                this.progressData.pointsCollectedDuringGameLevel = new System.Collections.Generic.Dictionary<GameplayMode, System.Int32>();
            val_8 = this.progressData;
        }
        
        EnumerableExtentions.SetOrAdd<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, newValue:  (EnumerableExtentions.GetOrDefault<GameplayMode, System.Int32>(dic:  this.progressData.pointsCollectedDuringGameLevel, key:  PlayingLevel.CurrentGameplayMode, defaultValue:  0)) + this.econ.pointsGainPerAttack);
        int val_8 = this.progressData.totalPointsCollected;
        val_8 = val_8 + this.econ.pointsGainPerAttack;
        this.progressData.totalPointsCollected = val_8;
        AttackMadnessEventHandler val_7 = this + this.econ.pointsGainPerAttack;
        this.UpdateProgressToServer();
    }
    protected virtual void UpdatePointsFlow(int ptsToAdd, int ptsMaxLimit, bool onlyAnimateProgressBar)
    {
        System.Action val_7;
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetHandler(handler:  this);
        val_1.<metaGameBehavior>k__BackingField.SetProgressBarValue(pointsCollected:  this - ptsToAdd, pointsRequired:  ptsMaxLimit, animated:  false);
        val_7 = 0;
        if(ptsToAdd >= ptsMaxLimit)
        {
                this.suppressRewardCollectionPopup = true;
            System.Action val_4 = null;
            val_7 = val_4;
            val_4 = new System.Action(object:  this, method:  System.Void AttackMadnessEventHandler::<UpdatePointsFlow>b__78_0());
        }
        
        val_1.<metaGameBehavior>k__BackingField.ShowPointGainAnimation(fromQty:  this - ptsToAdd, toQty:  -1425661696, maxQty:  ptsMaxLimit, onAnimationComplete:  val_4, onlyAnimateProgressBar:  onlyAnimateProgressBar, showBackground:  true, showBrownFlyout:  false);
    }
    protected virtual void OnCurrentRewardCollected()
    {
        int val_5 = this.progressData.rewardProgressLevel;
        val_5 = val_5 + 1;
        this.progressData.rewardProgressLevel = val_5;
        var val_3 = (this.HasCollectedAllRewards() != true) ? 0 : UnityEngine.Mathf.Max(a:  0, b:  0);
        this.progressData.currentRewardData = this.econ.GetEventReward(playerTier:  this.progressData.playerTierAtEventStart, rewardProgressLevel:  this.progressData.rewardProgressLevel);
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
        string val_7;
        if((true != 0) && (147633 != 0))
        {
                val_7 = "economy";
            if((147633.ContainsKey(key:  val_7)) != false)
        {
                val_7 = "economy";
            if(Item[val_7] != null)
        {
                AttackMadnessEcon val_3 = null;
            val_7 = System.Void System.ComponentModel.AsyncOperation::VerifyDelegateNotNull(System.Threading.SendOrPostCallback d);
            val_3 = new AttackMadnessEcon(eventDataDict:  val_7);
            this.econ = val_3;
        }
        
        }
        
        }
        
        if(this.IsEventExpired() != true)
        {
                if(this.IsCurrentEventInCycle() == true)
        {
            goto label_11;
        }
        
        }
        
        this.ResetEventProgress();
        label_11:
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        this.ParsePlayerProgressFromServer(eventDataDict:  AttackMadnessProgress.__il2cppRuntimeField_typeDefinition);
        this.progressData.eventId = typeof(AttackMadnessProgress).__il2cppRuntimeField_38;
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
        
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  this.PlayerLevel, knobValue:  -1424819616)) == false)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        this.progressData.hasSeenPopup = true;
    }
    public void ResetEventProgress()
    {
        this.progressData = new AttackMadnessProgress();
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
    public AttackMadnessEventHandler()
    {
        this.econ = new AttackMadnessEcon(eventDataDict:  0);
        this.progressData = new AttackMadnessProgress();
    }
    private void <ShowRewardCollection>b__75_0()
    {
        goto typeof(AttackMadnessEventHandler).__il2cppRuntimeField_810;
    }
    private void <UpdatePointsFlow>b__78_0()
    {
        this.suppressRewardCollectionPopup = false;
        goto typeof(AttackMadnessEventHandler).__il2cppRuntimeField_7E0;
    }

}

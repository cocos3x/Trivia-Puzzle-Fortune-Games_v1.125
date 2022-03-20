using UnityEngine;
public class IslandParadiseEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "IslandParadiseSymbol";
    public const string PURCHASE_ID_BASE = "id_keyPack";
    public const string KEY_TO_RICHES_EVENT_REWARD = "Key to Riches Event RESEventRewardData";
    public System.Action OnKeyBalanceChanged;
    private static IslandParadiseEventHandler _Instance;
    private IslandParadiseEventHandler.IslandParadiseProgress progressData;
    private bool isEventInitialized;
    private UnityEngine.GameObject eventButtonGO;
    private int <ProgressLabelPoints>k__BackingField;
    private int <PointsEarnedInLevel>k__BackingField;
    private bool <NeedToShowProgress>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public static IslandParadiseEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public UnityEngine.GameObject EventButtonGO { get; }
    public override int PointsCollected { get; set; }
    public override int PointsRequired { get; }
    public int ProgressLevel { get; set; }
    public int ProgressLabelPoints { get; set; }
    public int PointsEarnedInLevel { get; set; }
    public bool NeedToShowProgress { get; set; }
    public int ForestLevel { get; }
    public int UnlockForestLevel { get; }
    public override int UnlockLevel { get; }
    public virtual System.DateTime TimeExpire { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return (bool)IslandParadiseEventHandler._Instance;
        }
        
        goto typeof(IslandParadiseEventHandler).__il2cppRuntimeField_4A0;
    }
    public static IslandParadiseEventHandler get_Instance()
    {
        return (IslandParadiseEventHandler)IslandParadiseEventHandler._Instance;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public UnityEngine.GameObject get_EventButtonGO()
    {
        return (UnityEngine.GameObject)this.eventButtonGO;
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
        goto typeof(IslandParadiseEventHandler.IslandParadiseProgress).__il2cppRuntimeField_180;
    }
    public override int get_PointsRequired()
    {
        var val_1;
        if(this != null)
        {
                return (int)val_1;
        }
        
        val_1 = 1;
        return (int)val_1;
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
        this.progressData.rewardProgressLevel = value;
        goto typeof(IslandParadiseEventHandler.IslandParadiseProgress).__il2cppRuntimeField_180;
    }
    public int get_ProgressLabelPoints()
    {
        return (int)this.<ProgressLabelPoints>k__BackingField;
    }
    public void set_ProgressLabelPoints(int value)
    {
        this.<ProgressLabelPoints>k__BackingField = value;
    }
    public int get_PointsEarnedInLevel()
    {
        return (int)this.<PointsEarnedInLevel>k__BackingField;
    }
    public void set_PointsEarnedInLevel(int value)
    {
        this.<PointsEarnedInLevel>k__BackingField = value;
    }
    public bool get_NeedToShowProgress()
    {
        return (bool)this.<NeedToShowProgress>k__BackingField;
    }
    public void set_NeedToShowProgress(bool value)
    {
        this.<NeedToShowProgress>k__BackingField = value;
    }
    public int get_ForestLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_360;
    }
    public int get_UnlockForestLevel()
    {
        null = null;
        return (int)IslandParadiseEventHandler.Econ.unlockForestLevel;
    }
    public override int get_UnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.events_unlockLevel;
    }
    public virtual System.DateTime get_TimeExpire()
    {
        if(X8 != 0)
        {
                return (System.DateTime)X8 + 48;
        }
        
        throw new NullReferenceException();
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516269971824] = eventV2;
        IslandParadiseEventHandler._Instance = this;
        this.SetupEvent();
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_1;
        if((this & 1) == 0)
        {
            goto label_0;
        }
        
        label_5:
        val_1 = 0;
        return (bool)val_1;
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
                if((this.<ProgressLabelPoints>k__BackingField) == 0)
        {
            goto label_5;
        }
        
        }
        
        label_4:
        val_1 = 1;
        return (bool)val_1;
    }
    public override bool ActivelyPlayingGameMode()
    {
        var val_10;
        var val_11;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                val_10 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
        }
        else
        {
                val_10 = 0;
        }
        
        if(this.EventUnlocked() != false)
        {
                if(this.IsCurrentEventInCycle() != false)
        {
                val_11 = ((val_10 == 0) ? 1 : 0) & 1152921516270224481;
            return (bool)val_11;
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    public bool EventUnlocked()
    {
        var val_4 = null;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  this.ForestLevel, knobValue:  IslandParadiseEventHandler.Econ.unlockForestLevel)) == false)
        {
                return false;
        }
        
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -1221400096);
    }
    public override bool EventCompleted()
    {
        if(this.EventUnlocked() == false)
        {
                return true;
        }
        
        if(this.IsEventExpired() == false)
        {
                return this.HasCollectedAllRewards();
        }
        
        return true;
    }
    public bool HasCollectedAllRewards()
    {
        int val_3;
        var val_4;
        var val_5;
        val_3 = this;
        if(this.EventUnlocked() != false)
        {
                val_3 = this.progressData.rewardProgressLevel;
            val_4 = null;
            val_4 = null;
            var val_2 = (val_3 >= (IslandParadiseEventHandler.Econ.rewards + 24)) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    public override bool get_IsEventValid()
    {
        return this.EventUnlocked();
    }
    public override RESEventRewardData GetCurrentReward()
    {
        int val_8;
        object val_9;
        RewardTier val_10;
        val_8 = 1152921504917442560;
        RESEventRewardData val_1 = IslandParadiseEventHandler.Econ.GetCurrentRewardData(progress:  this.progressData.rewardProgressLevel);
        if(val_1 == null)
        {
                return val_1;
        }
        
        if(val_1.rewardType != 3)
        {
                return val_1;
        }
        
        if((val_1.metaData != null) && ((val_1.metaData.ContainsKey(key:  "tier")) != false))
        {
                object val_3 = val_1.metaData.Item["tier"];
        }
        else
        {
                val_9 = "IslandParadiseEventHandler: The current reward data doesn\'t have a definition for acorn tier. Reward progress level : "("IslandParadiseEventHandler: The current reward data doesn\'t have a definition for acorn tier. Reward progress level : ") + this.progressData.rewardProgressLevel;
            UnityEngine.Debug.LogWarning(message:  val_9);
            val_10 = 0;
        }
        
        val_8 = val_9.ForestLevel;
        decimal val_7 = System.Decimal.op_Implicit(value:  IslandParadiseEventHandler.Econ.GetAcornTierReward(level:  val_8, tier:  val_10));
        val_1.rewardQty = val_7;
        mem2[0] = val_7.lo;
        mem[4] = val_7.mid;
        return val_1;
    }
    public override bool IsRewardReadyToCollect()
    {
        if(this == null)
        {
                return (bool)(this >= null) ? 1 : 0;
        }
        
        return (bool)(this >= null) ? 1 : 0;
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
        this.<ProgressLabelPoints>k__BackingField = 0;
        this.<PointsEarnedInLevel>k__BackingField = 0;
    }
    public override void OnGameSceneBegan()
    {
        this.ShowPopup(firstTime:  true);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.ApplyPointsEarnedInLevel();
    }
    public override void OnNewForestShown()
    {
        this.ShowPopup(firstTime:  true);
    }
    public override void OnMysteryChestCollected()
    {
        if((this.<PointsEarnedInLevel>k__BackingField) < 1)
        {
                return;
        }
        
        this.ShowNewSymbolAnimation();
    }
    public override string GetEventDisplayName()
    {
        return "ISLAND PARADISE";
    }
    public override string GetMainMenuButtonText()
    {
        if(this.progressData.rewardProgressLevel == 0)
        {
                if(this == null)
        {
                return (string)System.String.Format(format:  "{0}/{1}", arg0:  this, arg1:  this);
        }
        
        }
        
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this, arg1:  this);
    }
    public override string GetGameButtonText()
    {
        return (string)this.<ProgressLabelPoints>k__BackingField.ToString();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_5 = 1.152922E+18f;
        val_5 = val_5 / (1.152922E+18f);
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentIslandParadise>(allowMultiple:  false).SetupSlider(hasCollectedAllRewards:  this.HasCollectedAllRewards(), sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  this, arg1:  this), sliderValue:  val_5, currentReward:  this);
    }
    public int GetTotalCollectableRewards()
    {
        var val_1;
        System.Collections.Generic.List<RESEventRewardData> val_2;
        var val_3;
        val_1 = null;
        val_1 = null;
        val_2 = IslandParadiseEventHandler.Econ.rewards;
        if(val_2 != null)
        {
                val_2 = IslandParadiseEventHandler.Econ.rewards;
            val_3 = mem[IslandParadiseEventHandler.Econ.rewards + 24];
            val_3 = IslandParadiseEventHandler.Econ.rewards + 24;
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    public void RewardPointsFromSymbols(int symbolAmount)
    {
        int val_2 = this.<PointsEarnedInLevel>k__BackingField;
        val_2 = val_2 + (this.GetPointsFromSymbols(symbolAmount:  symbolAmount));
        this.<PointsEarnedInLevel>k__BackingField = val_2;
        this.UpdateProgressToServer();
    }
    public void ApplyPointsEarnedInLevel()
    {
        int val_1 = (this.<PointsEarnedInLevel>k__BackingField) + this;
        this.UpdateProgressToServer();
    }
    public int GetPointsFromSymbols(int symbolAmount)
    {
        var val_1;
        var val_2;
        int val_3;
        var val_4;
        var val_5;
        val_1 = symbolAmount;
        if(val_1 == 3)
        {
            goto label_1;
        }
        
        if(val_1 == 2)
        {
            goto label_2;
        }
        
        if(val_1 != 1)
        {
            goto label_3;
        }
        
        val_1 = 1152921504917442560;
        val_2 = null;
        val_2 = null;
        val_3 = IslandParadiseEventHandler.Econ.points1Symbol;
        return (int)val_3;
        label_1:
        val_1 = 1152921504917442560;
        val_4 = null;
        val_4 = null;
        val_3 = IslandParadiseEventHandler.Econ.points3Symbol;
        return (int)val_3;
        label_2:
        val_1 = 1152921504917442560;
        val_5 = null;
        val_5 = null;
        val_3 = IslandParadiseEventHandler.Econ.points2Symbol;
        return (int)val_3;
        label_3:
        val_3 = 0;
        return (int)val_3;
    }
    public void ProcessRewardCollected()
    {
        if((this & 1) == 0)
        {
                return;
        }
        
        this.ProgressLevel = this.progressData.rewardProgressLevel + 1;
        this.UpdateProgressToServer();
    }
    public void UpdateProgressToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "rewards_collected", value:  this.progressData.rewardProgressLevel);
        val_1.Add(key:  "points_collected", value:  this);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    public void ShowNewSymbolAnimation()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.Setup(type:  2, points:  this.<PointsEarnedInLevel>k__BackingField, initialPoints:  this.<ProgressLabelPoints>k__BackingField, _onComplete:  new System.Action(object:  this, method:  public System.Void IslandParadiseEventHandler::OnPointGainComplete()));
    }
    public void OnPointGainComplete()
    {
        int val_1 = this.<ProgressLabelPoints>k__BackingField;
        val_1 = (this.<PointsEarnedInLevel>k__BackingField) + val_1;
        this.<ProgressLabelPoints>k__BackingField = val_1;
    }
    public void ShowPopup(bool firstTime = False)
    {
        var val_8;
        if(firstTime != false)
        {
                if(this.progressData.hasSeenPopup == true)
        {
                return;
        }
        
        }
        
        if(this.EventUnlocked() == false)
        {
                return;
        }
        
        val_8 = 1152921504893161472;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance;
        if(firstTime != 0)
        {
                GameBehavior val_4 = App.getBehavior;
        }
        else
        {
                WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<IslandParadiseProgressPopup>(showNext:  false);
        }
        
        this.progressData.hasSeenPopup = true;
    }
    public void ShowRewardCollection()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.InitReward(title:  "ISLAND PARADISE", reward:  this, source:  "Island Paradise Reward", onCollectClicked:  new System.Action(object:  this, method:  System.Void IslandParadiseEventHandler::<ShowRewardCollection>b__78_0()), onClose:  new System.Action(object:  this, method:  System.Void IslandParadiseEventHandler::<ShowRewardCollection>b__78_1()));
        this.<NeedToShowProgress>k__BackingField = true;
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventButton = eventButton;
        .<>4__this = this;
        .eventProgressUI = eventProgressUI;
        .popup = popup;
        return (System.Collections.IEnumerator)new IslandParadiseEventHandler.<DoLevelCompleteEventProgressAnimation>d__79();
    }
    private System.Collections.IEnumerator PlayPointCollectionSequence(int startValue, int points, WGEventButtonV2_IslandParadise islandParadiseButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .islandParadiseButton = islandParadiseButton;
        .<>4__this = this;
        .startValue = startValue;
        .points = points;
        .eventProgressUI = eventProgressUI;
        .popup = popup;
        return (System.Collections.IEnumerator)new IslandParadiseEventHandler.<PlayPointCollectionSequence>d__80();
    }
    private System.Collections.IEnumerator RewardSequence(WGEventButtonV2_IslandParadise islandParadiseButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .islandParadiseButton = islandParadiseButton;
        .popup = popup;
        return (System.Collections.IEnumerator)new IslandParadiseEventHandler.<RewardSequence>d__81();
    }
    private void SetupEvent()
    {
        if(this.IsEventExpired() != true)
        {
                if(this.IsCurrentEventInCycle() == true)
        {
            goto label_4;
        }
        
        }
        
        this.progressData = new IslandParadiseEventHandler.IslandParadiseProgress();
        this.UpdateProgressToServer();
        label_4:
        bool val_4 = this.IsEventExpired();
        if(val_4 == true)
        {
                return;
        }
        
        val_4.ParseEventEcon(eventData:  TMPro.TMP_WordInfo System.Array::InternalArray__IReadOnlyList_get_Item<TMPro.TMP_WordInfo>(int index));
        this.ParsePlayerProgressFromServer(eventData:  TMPro.TMP_WordInfo System.Array::InternalArray__IReadOnlyList_get_Item<TMPro.TMP_WordInfo>(int index));
        this.progressData.eventId = " has a button for the WGUnlockableUIElement to work with";
        if((this.HasCollectedAllRewards() != true) && (this >= this))
        {
                this.ShowPopup(firstTime:  false);
        }
        
        this.isEventInitialized = true;
    }
    private void ParseEventEcon(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        val_13 = eventData;
        if(val_13 == null)
        {
                return;
        }
        
        if((val_13.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_14 = 1152921504685600768;
        val_13 = val_13.Item["economy"];
        if((val_13.ContainsKey(key:  "unlock_lvl")) != false)
        {
                val_15 = val_13.Item["unlock_lvl"];
            val_16 = null;
            val_16 = null;
            IslandParadiseEventHandler.Econ.unlockForestLevel = null;
        }
        
        if((val_13.ContainsKey(key:  "pc")) == false)
        {
                return;
        }
        
        val_13 = val_13.Item["pc"];
        if((val_13.ContainsKey(key:  "1s")) != false)
        {
                val_15 = val_13.Item["1s"];
            val_17 = null;
            val_17 = null;
            IslandParadiseEventHandler.Econ.points1Symbol = null;
        }
        
        if((val_13.ContainsKey(key:  "2s")) != false)
        {
                val_15 = val_13.Item["2s"];
            val_18 = null;
            val_18 = null;
            IslandParadiseEventHandler.Econ.points2Symbol = null;
        }
        
        if((val_13.ContainsKey(key:  "3s")) == false)
        {
                return;
        }
        
        val_13 = val_13.Item["3s"];
        val_19 = null;
        val_19 = null;
        IslandParadiseEventHandler.Econ.points3Symbol = null;
    }
    private void ParsePlayerProgressFromServer(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_11;
        if(eventData == null)
        {
                return;
        }
        
        val_11 = "progress";
        if((eventData.ContainsKey(key:  "progress")) == false)
        {
                return;
        }
        
        val_11 = 1152921510214912464;
        object val_2 = eventData.Item["progress"];
        if((val_2.ContainsKey(key:  "rewards_collected")) != false)
        {
                if((System.Int32.TryParse(s:  val_2.Item["rewards_collected"], result: out  0)) != false)
        {
                this.ProgressLevel = 0;
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
    public void HackProgressLevel(int progress)
    {
        this.ProgressLevel = UnityEngine.Mathf.Max(a:  0, b:  progress);
        this.UpdateProgressToServer();
    }
    public void HackPointsCollected(int points)
    {
        int val_1 = UnityEngine.Mathf.Max(a:  0, b:  points);
        this.UpdateProgressToServer();
    }
    public void ResetEventProgress()
    {
        this.ProgressLevel = 0;
        this.UpdateProgressToServer();
    }
    public IslandParadiseEventHandler()
    {
        this.progressData = new IslandParadiseEventHandler.IslandParadiseProgress();
    }
    private void <ShowRewardCollection>b__78_0()
    {
        this.ProcessRewardCollected();
    }
    private void <ShowRewardCollection>b__78_1()
    {
        this.ShowPopup(firstTime:  false);
    }

}

using UnityEngine;
public class HotNSpicyEventHandler : WGEventHandler
{
    // Fields
    public const string HOTNSPICY_EVENT_ID = "HotNSpicy";
    public const string EVENT_TRACKING_ID = "Hot N Spicy";
    private HotNSpicyEcon econ;
    private HotNSpicyProgress progressData;
    private bool suppressRewardCollectionPopup;
    private bool isInitialized;
    private static HotNSpicyEventHandler <Instance>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public HotNSpicyEcon Econ { get; }
    public HotNSpicyProgress ProgressData { get; }
    public static HotNSpicyEventHandler Instance { get; set; }
    public int PlayerTier { get; set; }
    public int ProgressLevel { get; set; }
    public override int UnlockLevel { get; }
    public System.DateTime TimeExpire { get; }
    public override bool IsPointCollection { get; }
    public override int PointsCollected { get; set; }
    public override int PointsRequired { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((HotNSpicyEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)HotNSpicyEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(HotNSpicyEventHandler).__il2cppRuntimeField_4A0;
    }
    public HotNSpicyEcon get_Econ()
    {
        return (HotNSpicyEcon)this.econ;
    }
    public HotNSpicyProgress get_ProgressData()
    {
        return (HotNSpicyProgress)this.progressData;
    }
    public static HotNSpicyEventHandler get_Instance()
    {
        return (HotNSpicyEventHandler)HotNSpicyEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(HotNSpicyEventHandler value)
    {
        HotNSpicyEventHandler.<Instance>k__BackingField = value;
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
        goto typeof(HotNSpicyProgress).__il2cppRuntimeField_180;
    }
    public override int get_PointsRequired()
    {
        return (int)this;
    }
    public override bool ActivelyPlayingGameMode()
    {
        var val_3;
        if(this.IsCurrentEventInCycle() != false)
        {
                if(this.IsEventExpired() == false)
        {
            goto label_1;
        }
        
        }
        
        val_3 = 0;
        return true;
        label_1:
        val_3 = 1152921516478073505;
        return true;
    }
    public override void PreInit(GameEventV2 eventV2)
    {
        this.econ = new HotNSpicyEcon(eventDataDict:  eventV2.eventData);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516478353840] = eventV2;
        HotNSpicyEventHandler.<Instance>k__BackingField = this;
        MonoSingleton<GoalsManager>.Instance.AddAttackCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  System.Void HotNSpicyEventHandler::OnAttackCompleted(bool isSuccess)));
        MonoSingleton<GoalsManager>.Instance.AddRaidCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  System.Void HotNSpicyEventHandler::OnRaidCompleted(bool isRaidPerfect)));
        MonoSingleton<GoalsManager>.Instance.AddEventIconCollectedListener(listener:  new System.Action<System.Int32>(object:  this, method:  System.Void HotNSpicyEventHandler::OnEventIconCollected(int amtCollected)));
        this.SetupEvent();
    }
    public override void Dispose()
    {
        MonoSingleton<GoalsManager>.Instance.RemoveAttackCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  System.Void HotNSpicyEventHandler::OnAttackCompleted(bool isSuccess)));
        MonoSingleton<GoalsManager>.Instance.RemoveRaidCompletedListener(listener:  new System.Action<System.Boolean>(object:  this, method:  System.Void HotNSpicyEventHandler::OnRaidCompleted(bool isRaidPerfect)));
        MonoSingleton<GoalsManager>.Instance.RemoveEventIconCollectedListener(listener:  new System.Action<System.Int32>(object:  this, method:  System.Void HotNSpicyEventHandler::OnEventIconCollected(int amtCollected)));
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "HotNSpicy")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "hot_n_spicy_upper", defaultValue:  "Hot \'n Spicy", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "hot_n_spicy_upper", defaultValue:  "HOT \'N SPICY", useSingularKey:  false);
    }
    public bool HasCollectedAllRewards()
    {
        int val_5;
        var val_6;
        val_5 = this;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -1012728240)) != false)
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
        int val_5;
        var val_6;
        val_5 = this;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -1012591664)) != false)
        {
                val_5 = this.progressData.rewardProgressLevel;
            var val_4 = (val_5 >= (this.econ.GetTotalCollectableRewards(playerTier:  this.progressData.playerTierAtEventStart))) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 1;
        return (bool)val_6;
    }
    public override bool IsChallengeCompleted()
    {
        return this.HasCollectedAllRewards();
    }
    public override bool get_IsEventValid()
    {
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -1012351280);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
    
    }
    public override void OnEventEnded()
    {
        HotNSpicyProgress val_1 = null;
        .playerTierAtEventStart = 0;
        val_1 = new HotNSpicyProgress();
        this.progressData = val_1;
    }
    public override void OnMenuLoaded()
    {
    
    }
    public override void OnGameSceneBegan()
    {
    
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public HotNSpicyPopup MetaGameBehavior::ShowUGUIMonolith<HotNSpicyPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public override void OnGameButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public HotNSpicyPopup MetaGameBehavior::ShowUGUIMonolith<HotNSpicyPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
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
        this.econ.rewardData = HotNSpicyEconDataHelper.ParseCSV();
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
    public override void OnAllReelsStopped()
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
    private void ShowRewardCollection()
    {
    
    }
    private void OnAttackCompleted(bool isSuccess)
    {
        if((this & 1) != 0)
        {
                return;
        }
    
    }
    private void OnRaidCompleted(bool isRaidPerfect)
    {
        if((this & 1) != 0)
        {
                return;
        }
    
    }
    private void OnEventIconCollected(int amtCollected)
    {
        goto typeof(HotNSpicyEventHandler).__il2cppRuntimeField_4F0;
    }
    private void OnCurrentRewardCollected()
    {
        int val_6 = this.progressData.rewardProgressLevel;
        val_6 = val_6 + 1;
        this.progressData.rewardProgressLevel = val_6;
        var val_3 = (this.HasCollectedAllRewards() != true) ? 0 : UnityEngine.Mathf.Max(a:  0, b:  0);
        this.progressData.currentRewardData = this.econ.GetEventReward(playerTier:  this.progressData.playerTierAtEventStart, rewardProgressLevel:  this.progressData.rewardProgressLevel);
        this.UpdateProgressToServer();
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.HasCollectedAllRewards() == false)
        {
            goto typeof(HotNSpicyEventHandler).__il2cppRuntimeField_760;
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
                HotNSpicyEcon val_3 = null;
            val_9 = System.Void System.ComponentModel.AsyncOperation::VerifyDelegateNotNull(System.Threading.SendOrPostCallback d);
            val_3 = new HotNSpicyEcon(eventDataDict:  val_9);
            this.econ = val_3;
        }
        
        }
        
        }
        
        if(this.IsEventExpired() != true)
        {
                if(this.IsCurrentEventInCycle() == true)
        {
            goto label_10;
        }
        
        }
        
        HotNSpicyProgress val_6 = null;
        .playerTierAtEventStart = 0;
        val_6 = new HotNSpicyProgress();
        this.progressData = val_6;
        label_10:
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        this.ParsePlayerProgressFromServer(eventDataDict:  37794084);
        if(this.progressData.playerTierAtEventStart <= 0)
        {
                val_10 = null;
            val_10 = null;
            if(App.game == 20)
        {
                this.progressData.playerTierAtEventStart = RestaurantRivals.CommonEventEconDataHelper.GetPlayerTier();
        }
        
        }
        
        this.progressData.eventId = App.game + 56;
        this.isInitialized = true;
    }
    private void ShowPopup(bool firstTime = False)
    {
        var val_5;
        if(firstTime != false)
        {
                if(this.progressData.hasSeenPopup == true)
        {
                return;
        }
        
        }
        
        val_5 = this;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -1009124272)) == false)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        this.progressData.hasSeenPopup = true;
    }
    public void ResetEventProgress()
    {
        HotNSpicyProgress val_1 = null;
        .playerTierAtEventStart = 0;
        val_1 = new HotNSpicyProgress();
        this.progressData = val_1;
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
    public HotNSpicyEventHandler()
    {
        this.econ = new HotNSpicyEcon(eventDataDict:  0);
        HotNSpicyProgress val_2 = null;
        .playerTierAtEventStart = 0;
        val_2 = new HotNSpicyProgress();
        this.progressData = val_2;
    }

}

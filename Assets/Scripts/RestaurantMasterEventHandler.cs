using UnityEngine;
public class RestaurantMasterEventHandler : WGEventHandler
{
    // Fields
    public const string RESTAURANT_MASTER_EVENT_ID = "RestaurantMaster";
    public const string EVENT_TRACKING_ID = "Restaurant Master";
    private RestaurantMasterEcon econ;
    private RestaurantMasterProgress progressData;
    private static RestaurantMasterEventHandler <Instance>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public RestaurantMasterEcon Econ { get; }
    public RestaurantMasterProgress ProgressData { get; }
    public static RestaurantMasterEventHandler Instance { get; set; }
    public override int UnlockLevel { get; }
    public System.DateTime TimeExpire { get; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((RestaurantMasterEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)RestaurantMasterEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(RestaurantMasterEventHandler).__il2cppRuntimeField_4A0;
    }
    public RestaurantMasterEcon get_Econ()
    {
        return (RestaurantMasterEcon)this.econ;
    }
    public RestaurantMasterProgress get_ProgressData()
    {
        return (RestaurantMasterProgress)this.progressData;
    }
    public static RestaurantMasterEventHandler get_Instance()
    {
        return (RestaurantMasterEventHandler)RestaurantMasterEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(RestaurantMasterEventHandler value)
    {
        RestaurantMasterEventHandler.<Instance>k__BackingField = value;
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
        val_3 = 1152921516677196929;
        return true;
    }
    public override void PreInit(GameEventV2 eventV2)
    {
        this.econ = new RestaurantMasterEcon(eventDataDict:  eventV2.eventData);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516677449616] = eventV2;
        RestaurantMasterEventHandler.<Instance>k__BackingField = this;
        this.SetupEvent();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "RestaurantMaster")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "restaurant_master_upper", defaultValue:  "RESTAURANT MASTER", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "restaurant_master_upper", defaultValue:  "RESTAURANT MASTER", useSingularKey:  false);
    }
    public override bool EventCompleted()
    {
        bool val_2 = GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  this.econ.unlockPlayerLevel);
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    public override bool get_IsEventValid()
    {
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  -813698064);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
    
    }
    public override void OnEventEnded()
    {
        this.progressData = new RestaurantMasterProgress();
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
        val_1.<metaGameBehavior>k__BackingField.SetupView();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupView();
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        this.ShowRewardCollection();
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
    public decimal GetCoinReward(bool showNextLevel = True)
    {
        int val_9;
        var val_10;
        var val_11;
        System.Predicate<RESEventRewardData> val_13;
        decimal val_14;
        var val_15;
        var val_16;
        if(showNextLevel != false)
        {
                val_9 = App.Player + 1;
        }
        else
        {
                val_9 = App.Player;
        }
        
        System.Collections.Generic.List<RESEventRewardData> val_3 = this.econ.GetRewardsList(playerLevel:  val_9);
        if(val_3 != null)
        {
                val_10 = val_3;
            val_11 = null;
            val_11 = null;
            val_13 = RestaurantMasterEventHandler.<>c.<>9__38_0;
            if(val_13 == null)
        {
                System.Predicate<RESEventRewardData> val_4 = null;
            val_13 = val_4;
            val_4 = new System.Predicate<RESEventRewardData>(object:  RestaurantMasterEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean RestaurantMasterEventHandler.<>c::<GetCoinReward>b__38_0(RESEventRewardData node));
            RestaurantMasterEventHandler.<>c.<>9__38_0 = val_13;
        }
        
            RESEventRewardData val_5 = val_10.Find(match:  val_4);
            if(val_5 != null)
        {
                val_14 = val_5.rewardQty;
            val_15 = val_5 + 32;
            return new System.Decimal() {flags = val_14, hi = val_14, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
        }
        
        }
        
        val_10 = 1152921504617017344;
        val_16 = null;
        val_16 = null;
        val_14 = 1152921504617021448;
        val_15 = 1152921504617021456;
        return new System.Decimal() {flags = val_14, hi = val_14, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
    }
    public int GetSpinReward(bool showNextLevel = True)
    {
        int val_8;
        int val_9;
        var val_10;
        System.Predicate<RESEventRewardData> val_12;
        val_8 = this;
        if(showNextLevel != false)
        {
                val_9 = App.Player + 1;
        }
        else
        {
                val_9 = App.Player;
        }
        
        System.Collections.Generic.List<RESEventRewardData> val_3 = this.econ.GetRewardsList(playerLevel:  val_9);
        if(val_3 == null)
        {
                return 0;
        }
        
        val_8 = val_3;
        val_10 = null;
        val_10 = null;
        val_12 = RestaurantMasterEventHandler.<>c.<>9__39_0;
        if(val_12 == null)
        {
                System.Predicate<RESEventRewardData> val_4 = null;
            val_12 = val_4;
            val_4 = new System.Predicate<RESEventRewardData>(object:  RestaurantMasterEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean RestaurantMasterEventHandler.<>c::<GetSpinReward>b__39_0(RESEventRewardData node));
            RestaurantMasterEventHandler.<>c.<>9__39_0 = val_12;
        }
        
        if((val_8.Find(match:  val_4)) == null)
        {
                return 0;
        }
        
        return System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_5.rewardQty, hi = val_5.rewardQty, lo = val_8, mid = val_8});
    }
    private void ShowRewardCollection()
    {
        null = null;
        if(App.game != 20)
        {
                return;
        }
        
        ShowRewardCollection_RRV();
    }
    private void ShowRewardCollection_RRV()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupCollect();
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
                RestaurantMasterEcon val_3 = null;
            val_7 = System.Void System.ComponentModel.AsyncOperation::VerifyDelegateNotNull(System.Threading.SendOrPostCallback d);
            val_3 = new RestaurantMasterEcon(eventDataDict:  val_7);
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
        
        this.ResetEventProgress();
        label_10:
        if(this.IsEventExpired() != false)
        {
                return;
        }
        
        this.progressData.eventId = typeof(RestaurantMasterProgress).__il2cppRuntimeField_38;
        goto typeof(RestaurantMasterProgress).__il2cppRuntimeField_180;
    }
    public void ResetEventProgress()
    {
        this.progressData = new RestaurantMasterProgress();
    }
    private string GetPlatformId()
    {
        return "a";
    }
    public override string GetHackPanelEventData()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_2 = val_1.AppendLine(value:  "<color=#ffef00>Econ knob data:</color>");
        System.Text.StringBuilder val_5 = val_1.AppendLine(value:  System.String.Format(format:  "Player unlock level: {0}", arg0:  this.econ.unlockPlayerLevel.ToString()));
        System.Text.StringBuilder val_6 = val_1.AppendLine(value:  "<color=#ffef00>Player Stats</color>");
        System.Text.StringBuilder val_9 = val_1.AppendLine(value:  System.String.Format(format:  "Player Level: {0}", arg0:  App.Player));
        return (string)val_1;
    }
    public RestaurantMasterEventHandler()
    {
        this.econ = new RestaurantMasterEcon(eventDataDict:  0);
        this.progressData = new RestaurantMasterProgress();
    }

}

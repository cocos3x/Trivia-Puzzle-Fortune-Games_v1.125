using UnityEngine;
public class ForestMasterEventHandler : WGEventHandler
{
    // Fields
    public const string FOREST_MASTER_EVENT_ID = "ForestMaster";
    public const string EVENT_TRACKING_ID = "Forest Master";
    private ForestMasterEcon econ;
    private ForestMasterProgress progressData;
    private bool isEventInitialized;
    private static ForestMasterEventHandler <Instance>k__BackingField;
    private bool <IsRewardAvailable>k__BackingField;
    
    // Properties
    public static bool IsEventActive { get; }
    public ForestMasterEcon Econ { get; }
    public ForestMasterProgress ProgressData { get; }
    public static ForestMasterEventHandler Instance { get; set; }
    public int PlayerLevel { get; }
    public override int UnlockLevel { get; }
    public System.DateTime TimeExpire { get; }
    public bool IsRewardAvailable { get; set; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static bool get_IsEventActive()
    {
        if((ForestMasterEventHandler.<Instance>k__BackingField) == null)
        {
                return (bool)ForestMasterEventHandler.<Instance>k__BackingField;
        }
        
        goto typeof(ForestMasterEventHandler).__il2cppRuntimeField_4A0;
    }
    public ForestMasterEcon get_Econ()
    {
        return (ForestMasterEcon)this.econ;
    }
    public ForestMasterProgress get_ProgressData()
    {
        return (ForestMasterProgress)this.progressData;
    }
    public static ForestMasterEventHandler get_Instance()
    {
        return (ForestMasterEventHandler)ForestMasterEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(ForestMasterEventHandler value)
    {
        ForestMasterEventHandler.<Instance>k__BackingField = value;
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
    public bool get_IsRewardAvailable()
    {
        return (bool)this.<IsRewardAvailable>k__BackingField;
    }
    private void set_IsRewardAvailable(bool value)
    {
        this.<IsRewardAvailable>k__BackingField = value;
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
        val_3 = 1152921516215336769;
        return true;
    }
    public override void PreInit(GameEventV2 eventV2)
    {
        this.econ = new ForestMasterEcon(eventDataDict:  eventV2.eventData);
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516215589456] = eventV2;
        ForestMasterEventHandler.<Instance>k__BackingField = this;
        this.SetupEvent();
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((System.String.op_Inequality(a:  eventV2.type, b:  "ForestMaster")) != false)
        {
                return;
        }
        
        this.SetupEvent();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "forest_master_upper", defaultValue:  "FOREST MASTER", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        float val_5 = ((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestGrowth) / ((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentMaxGrowth);
        if(val_5 <= 0f)
        {
                return Localization.Localize(key:  "forest_master_upper", defaultValue:  "FOREST MASTER", useSingularKey:  false);
        }
        
        float val_8 = 100f;
        val_8 = val_5 * val_8;
        return (string)System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.RoundToInt(f:  val_8));
    }
    public override string GetGameButtonText()
    {
        float val_8 = 100f;
        val_8 = (((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestGrowth) / ((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentMaxGrowth)) * val_8;
        return (string)System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.RoundToInt(f:  val_8));
    }
    public override bool EventCompleted()
    {
        bool val_1 = this.IsEventExpired();
        if(val_1 != false)
        {
                return true;
        }
        
        if(this.econ.unlockPlayerLevel == 1)
        {
                return true;
        }
        
        if(val_1.PlayerLevel < this.econ.unlockPlayerLevel)
        {
                return true;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if(this.PlayerLevel < (val_4.<metaGameBehavior>k__BackingField))
        {
                return true;
        }
        
        var val_5 = ((this.<IsRewardAvailable>k__BackingField) == false) ? 1 : 0;
        return true;
    }
    public override bool get_IsEventValid()
    {
        return (bool)((this.PlayerLevel >= this) ? 1 : 0) & ((this != 1) ? 1 : 0);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        float val_9 = 100f;
        val_9 = (((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestGrowth) / ((float)MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentMaxGrowth)) * val_9;
        string val_7 = System.String.Format(format:  "{0}%", arg0:  UnityEngine.Mathf.RoundToInt(f:  val_9));
        EventListItemContentForestMaster val_8 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentForestMaster>(allowMultiple:  false);
    }
    public override void OnEventEnded()
    {
        this.progressData = new ForestMasterProgress();
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
    public override void OnForestComplete(int levelsProgressed = 1)
    {
        this.<IsRewardAvailable>k__BackingField = true;
        goto typeof(ForestMasterEventHandler).__il2cppRuntimeField_2B0;
    }
    public override void OnForestUpdated()
    {
        goto typeof(ForestMasterEventHandler).__il2cppRuntimeField_2B0;
    }
    public override System.Collections.IEnumerator DoLevelCompleteEventProgressAnimation(WGEventButtonV2 eventButton, WGEventButtonV2 eventProgressUI, WGLevelClearPopup popup)
    {
        .<>1__state = 0;
        .eventButton = eventButton;
        return (System.Collections.IEnumerator)new ForestMasterEventHandler.<DoLevelCompleteEventProgressAnimation>d__43();
    }
    public decimal GetCoinReward(bool showCurrentLevel = True)
    {
        int val_11;
        var val_12;
        var val_13;
        System.Predicate<RESEventRewardData> val_15;
        decimal val_16;
        var val_17;
        var val_18;
        if(showCurrentLevel != false)
        {
                val_11 = MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestLevel;
        }
        else
        {
                val_11 = (MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestLevel) - 1;
        }
        
        System.Collections.Generic.List<RESEventRewardData> val_5 = this.econ.GetRewardsList(playerLevel:  val_11);
        if(val_5 != null)
        {
                val_12 = val_5;
            val_13 = null;
            val_13 = null;
            val_15 = ForestMasterEventHandler.<>c.<>9__44_0;
            if(val_15 == null)
        {
                System.Predicate<RESEventRewardData> val_6 = null;
            val_15 = val_6;
            val_6 = new System.Predicate<RESEventRewardData>(object:  ForestMasterEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean ForestMasterEventHandler.<>c::<GetCoinReward>b__44_0(RESEventRewardData node));
            ForestMasterEventHandler.<>c.<>9__44_0 = val_15;
        }
        
            RESEventRewardData val_7 = val_12.Find(match:  val_6);
            if(val_7 != null)
        {
                val_16 = val_7.rewardQty;
            val_17 = val_7 + 32;
            return new System.Decimal() {flags = val_16, hi = val_16, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
        }
        
        }
        
        val_12 = 1152921504617017344;
        val_18 = null;
        val_18 = null;
        val_16 = 1152921504617021448;
        val_17 = 1152921504617021456;
        return new System.Decimal() {flags = val_16, hi = val_16, lo = mem[1152921504617021456], mid = mem[1152921504617021456]};
    }
    public int GetAcornReward(bool showCurrentLevel = True)
    {
        int val_10;
        var val_11;
        System.Predicate<RESEventRewardData> val_13;
        var val_14;
        decimal val_15;
        var val_16;
        if(showCurrentLevel != false)
        {
                val_10 = MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestLevel;
        }
        else
        {
                val_10 = (MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestLevel) - 1;
        }
        
        System.Collections.Generic.List<RESEventRewardData> val_5 = this.econ.GetRewardsList(playerLevel:  val_10);
        if(val_5 == null)
        {
                return (int)val_5;
        }
        
        val_11 = null;
        val_11 = null;
        val_13 = ForestMasterEventHandler.<>c.<>9__45_0;
        if(val_13 == null)
        {
                System.Predicate<RESEventRewardData> val_6 = null;
            val_13 = val_6;
            val_6 = new System.Predicate<RESEventRewardData>(object:  ForestMasterEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean ForestMasterEventHandler.<>c::<GetAcornReward>b__45_0(RESEventRewardData node));
            ForestMasterEventHandler.<>c.<>9__45_0 = val_13;
        }
        
        RESEventRewardData val_7 = val_5.Find(match:  val_6);
        if(val_7 != null)
        {
                val_14 = null;
            val_15 = val_7.rewardQty;
            val_16 = val_7 + 32;
            return System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_15, hi = val_15, lo = mem[1152921504617021456], mid = mem[1152921504617021456]});
        }
        
        val_14 = null;
        val_14 = null;
        val_15 = 1152921504617021448;
        val_16 = 1152921504617021456;
        return System.Decimal.ToInt32(d:  new System.Decimal() {flags = val_15, hi = val_15, lo = mem[1152921504617021456], mid = mem[1152921504617021456]});
    }
    public void ShowRewardCollection()
    {
        this.<IsRewardAvailable>k__BackingField = false;
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public ForestMasterRewardPopup MetaGameBehavior::ShowUGUIMonolith<ForestMasterRewardPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
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
                ForestMasterEcon val_3 = null;
            val_7 = System.Void System.ComponentModel.AsyncOperation::VerifyDelegateNotNull(System.Threading.SendOrPostCallback d);
            val_3 = new ForestMasterEcon(eventDataDict:  val_7);
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
        
        this.progressData.eventId = typeof(ForestMasterProgress).__il2cppRuntimeField_38;
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
        if(this == 1)
        {
                return;
        }
        
        if(val_1 < this)
        {
                return;
        }
        
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance;
        if(val_1 != 0)
        {
                GameBehavior val_4 = App.getBehavior;
        }
        else
        {
                GameBehavior val_6 = App.getBehavior;
        }
        
        this.progressData.hasSeenPopup = true;
    }
    public void ResetEventProgress()
    {
        this.progressData = new ForestMasterProgress();
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
        System.Text.StringBuilder val_9 = val_1.AppendLine(value:  System.String.Format(format:  "Player Level: {0}", arg0:  val_1.AppendLine(value:  "<color=#ffef00>Player Stats</color>").PlayerLevel));
        return (string)val_1;
    }
    public ForestMasterEventHandler()
    {
        this.econ = new ForestMasterEcon(eventDataDict:  0);
        this.progressData = new ForestMasterProgress();
    }

}

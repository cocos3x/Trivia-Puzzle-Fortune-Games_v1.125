using UnityEngine;
public class TRVStarChampionshipEventHandler : WGEventHandler
{
    // Fields
    public const string STAR_CHAMPIONSHIP_EVENT_ID = "StarChampionship";
    public const string EVENT_TRACKING_ID = "Star Championship Event";
    private const string STAR_CHAMPIONSHIP_EVENT_NAME = "STAR CHAMPIONSHIP";
    private static TRVStarChampionshipEventHandler <Instance>k__BackingField;
    private StarChampionshipEventProgress eventProgress;
    private System.Action onLevelCompleteRewardAnimFinished;
    
    // Properties
    public static TRVStarChampionshipEventHandler Instance { get; set; }
    public override bool SupportsGoldenApples { get; }
    public GameEventV2 getGameEvent { get; }
    private System.Collections.Generic.List<StarChampionshipTier> EventEcon { get; set; }
    
    // Methods
    public static TRVStarChampionshipEventHandler get_Instance()
    {
        return (TRVStarChampionshipEventHandler)TRVStarChampionshipEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(TRVStarChampionshipEventHandler value)
    {
        TRVStarChampionshipEventHandler.<Instance>k__BackingField = value;
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public GameEventV2 get_getGameEvent()
    {
        return (GameEventV2)this;
    }
    private System.Collections.Generic.List<StarChampionshipTier> get_EventEcon()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (System.Collections.Generic.List<StarChampionshipTier>)val_1.StarChampionshipEventEcon;
    }
    private void set_EventEcon(System.Collections.Generic.List<StarChampionshipTier> value)
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        val_1.StarChampionshipEventEcon = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517388085488] = eventV2;
        TRVStarChampionshipEventHandler.<Instance>k__BackingField = this;
        this.RefreshEventData(data:  eventV2.eventData);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(eventV2 != null)
        {
                this.RefreshEventData(data:  eventV2.eventData);
            return;
        }
        
        throw new NullReferenceException();
    }
    public override void OnEventEnded()
    {
        TRVStarChampionshipEventHandler.<Instance>k__BackingField = 0;
        goto typeof(StarChampionshipEventProgress).__il2cppRuntimeField_190;
    }
    public override void OnGameSceneBegan()
    {
        if((this & 1) != 0)
        {
                return;
        }
    
    }
    public override bool EventCompleted()
    {
        if(this.eventProgress.Rewarded != false)
        {
                return true;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(TRVStarChampionshipEventHandler).__il2cppRuntimeField_4F0;
    }
    public override void OnAppleAwarded(int earnedAmount)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        StarChampionshipTier val_1 = this.GetCurrentTier();
        int val_4 = this.eventProgress.Stars;
        val_4 = val_4 + earnedAmount;
        this.eventProgress.Stars = val_4;
        StarChampionshipTier val_2 = this.GetCurrentTier();
        if(val_2.tierIndex == val_1.tierIndex)
        {
                return;
        }
        
        this.onLevelCompleteRewardAnimFinished = new System.Action(object:  this, method:  System.Void TRVStarChampionshipEventHandler::ShowStarChampionshipRewardPopup());
    }
    public override void MarkEventRewarded()
    {
        this.eventProgress.Rewarded = true;
        this.UpdateRewardStatus();
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
    public override void OnLevelCompleteRewardAnimFinished()
    {
        if(this.onLevelCompleteRewardAnimFinished == null)
        {
                return;
        }
        
        this.onLevelCompleteRewardAnimFinished.Invoke();
        this.onLevelCompleteRewardAnimFinished = 0;
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                this = ???;
        }
        else
        {
                this.ShowStarChampionshipProgressPopup();
        }
    
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_6;
        var val_7;
        val_6 = connected;
        val_7 = this;
        if((this & 1) != 0)
        {
                val_6 = ???;
            val_7 = ???;
        }
        else
        {
                var val_3 = val_6 & 1;
        }
    
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "<size={0}>{1} {2}</size>", arg0:  "30", arg1:  Localization.Localize(key:  "star_championship_upper", defaultValue:  "STAR CHAMPIONSHIP", useSingularKey:  false), arg2:  this.GetEventProgressText());
    }
    public override string GetGameButtonText()
    {
        return System.String.Format(format:  "<size={0}>{1} {2}</size>", arg0:  "30", arg1:  Localization.Localize(key:  "star_championship_upper", defaultValue:  "STAR CHAMPIONSHIP", useSingularKey:  false), arg2:  this.GetEventProgressText());
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "star_championship_upper", defaultValue:  "STAR CHAMPIONSHIP", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        mem[1152921517390104428] = this.GetProgressBarValue(definedDivisions:  loader);
        StarChampionshipTier val_3 = this.GetCurrentTier();
        int val_5 = val_3.tierIndex;
        val_5 = val_5 - 1;
        mem[1152921517390104424] = val_5;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentStarChampionship>(allowMultiple:  false).UpdateProgressBar(uiParam:  new TRVStarChampionshipProgressUIParam());
    }
    public override UnityEngine.Sprite GetEventIcon()
    {
        return MonoSingleton<TRVUtils>.Instance.GetEventIcon(eventHandler:  this);
    }
    public string GetEventProgressText()
    {
        StarChampionshipTier val_1 = this.GetNextTier();
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.eventProgress.Stars, arg1:  val_1.goal);
    }
    private void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        if((System.String.op_Inequality(a:  0, b:  "StarChampionship")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + null);
            return;
        }
        
        if(this.IsEventNewCycle() != false)
        {
                this.ResetEventProgress();
        }
        
        this.ParseEcon(data:  data);
        this.ParseServerProgress(data:  data);
        goto typeof(StarChampionshipEventProgress).__il2cppRuntimeField_180;
    }
    private void ParseEcon(System.Collections.Generic.Dictionary<string, object> data)
    {
        System.Collections.Generic.List<StarChampionshipTier> val_17;
        var val_18;
        StarChampionshipTier val_19;
        if(data == null)
        {
                return;
        }
        
        val_18 = "economy";
        if((data.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        System.Collections.Generic.List<StarChampionshipTier> val_2 = null;
        val_17 = val_2;
        val_2 = new System.Collections.Generic.List<StarChampionshipTier>();
        StarChampionshipTier val_3 = null;
        val_19 = val_3;
        val_3 = new StarChampionshipTier(tierIndex:  0, goal:  0, reward:  0, isTopTier:  false);
        val_2.Add(item:  val_3);
        object val_4 = data.Item["economy"];
        if(val_4 == null)
        {
                return;
        }
        
        var val_5 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_4) : 0;
    }
    private void ParseServerProgress(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_9;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_9 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((data.ContainsKey(key:  "progress")) != false)
        {
                val_9 = data.Item["progress"];
        }
        
        if((val_1.ContainsKey(key:  "rewarded")) == false)
        {
                return;
        }
        
        bool val_6 = System.Boolean.Parse(value:  val_1.Item["rewarded"]);
        var val_7 = (this.eventProgress.Rewarded == false) ? 1 : 0;
        val_7 = val_6 | val_7;
        if(val_7 != false)
        {
                this.eventProgress.Rewarded = val_6;
            return;
        }
        
        this.UpdateRewardStatus();
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress != (X9 + 16)) ? 1 : 0;
    }
    private void ResetEventProgress()
    {
        this.eventProgress = new StarChampionshipEventProgress();
        mem[1152921517391093296] = null;
    }
    private void UpdateRewardStatus()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "rewarded", value:  true);
        this.UpdateToServer(data:  val_1);
    }
    private void UpdateToServer(System.Collections.Generic.Dictionary<string, object> data)
    {
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  data);
    }
    private StarChampionshipTier GetCurrentTier()
    {
        var val_5;
        var val_6;
        val_5 = this;
        label_7:
        var val_2 = W21 - 1;
        if(<0)
        {
            goto label_2;
        }
        
        StarChampionshipEventProgress val_5 = this.eventProgress;
        System.Collections.Generic.List<StarChampionshipTier> val_3 = this.EventEcon.EventEcon;
        if(val_5 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + (val_2 << 3);
        var val_6 = (this.eventProgress + ((W21 - 1)) << 3).Rewarded + 20;
        if(this.eventProgress.Stars < val_6)
        {
            goto label_7;
        }
        
        val_5 = this.EventEcon;
        if(val_6 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (((long)(int)((W21 - 1))) << 3);
        val_6 = mem[((this.eventProgress + ((W21 - 1)) << 3).Rewarded + 20 + ((long)(int)((W21 - 1))) << 3) + 32];
        val_6 = ((this.eventProgress + ((W21 - 1)) << 3).Rewarded + 20 + ((long)(int)((W21 - 1))) << 3) + 32;
        return (StarChampionshipTier)val_6;
        label_2:
        val_6 = 0;
        return (StarChampionshipTier)val_6;
    }
    private StarChampionshipTier GetNextTier()
    {
        var val_8;
        var val_9;
        val_8 = this;
        StarChampionshipTier val_2 = this.GetCurrentTier();
        .currentTier = val_2;
        if(val_2.isTopTier == true)
        {
                return (StarChampionshipTier)val_9;
        }
        
        System.Collections.Generic.List<StarChampionshipTier> val_3 = val_2.EventEcon;
        val_8 = val_3;
        var val_8 = 1152921517391579488;
        int val_7 = (val_3.EventEcon.FindIndex(match:  new System.Predicate<StarChampionshipTier>(object:  new TRVStarChampionshipEventHandler.<>c__DisplayClass43_0(), method:  System.Boolean TRVStarChampionshipEventHandler.<>c__DisplayClass43_0::<GetNextTier>b__0(StarChampionshipTier x)))) + 1;
        if(val_8 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (val_7 << 3);
        val_9 = mem[(1152921517391579488 + ((val_6 + 1)) << 3) + 32];
        val_9 = (1152921517391579488 + ((val_6 + 1)) << 3) + 32;
        return (StarChampionshipTier)val_9;
    }
    private void ShowStarChampionshipProgressPopup()
    {
        mem[1152921517391811612] = this.GetProgressBarValue(definedDivisions:  null);
        StarChampionshipTier val_3 = this.GetCurrentTier();
        int val_10 = val_3.tierIndex;
        val_10 = val_10 - 1;
        mem[1152921517391811608] = val_10;
        mem[1152921517391811616] = Localization.Localize(key:  "star_championship_popup_ln1", defaultValue:  "Earn #currency by completing levels to earn big rewards!", useSingularKey:  false);
        StarChampionshipTier val_6 = this.GetNextTier();
        int val_11 = this.eventProgress.Stars;
        val_11 = val_6.goal - val_11;
        .descriptionBottom = System.String.Format(format:  Localization.Localize(key:  "star_championship_popup_ln2", defaultValue:  "{0} #currency needed to earn the next reward", useSingularKey:  false), arg0:  val_11);
        GameBehavior val_8 = App.getBehavior;
        val_8.<metaGameBehavior>k__BackingField.ShowProgressPopup(param:  new TRVStarChampionshipProgressUIParam());
    }
    private void ShowStarChampionshipRewardPopup()
    {
        mem[1152921517392006844] = this.GetProgressBarValue(definedDivisions:  null);
        StarChampionshipTier val_3 = this.GetCurrentTier();
        int val_11 = val_3.tierIndex;
        val_11 = val_11 - 1;
        mem[1152921517392006840] = val_11;
        mem[1152921517392006848] = System.String.Format(format:  Localization.Localize(key:  "star_championship_reward", defaultValue:  "Congratulations! You\'ve earned {0} #currency!", useSingularKey:  false), arg0:  val_3.goal)(System.String.Format(format:  Localization.Localize(key:  "star_championship_reward", defaultValue:  "Congratulations! You\'ve earned {0} #currency!", useSingularKey:  false), arg0:  val_3.goal)) + "\n" + Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false)(Localization.Localize(key:  "collect_your_reward_exc", defaultValue:  "Collect your reward!", useSingularKey:  false));
        StarChampionshipTier val_8 = this.GetCurrentTier();
        .reward = val_8.reward;
        .delay = 0f;
        GameBehavior val_9 = App.getBehavior;
        val_9.<metaGameBehavior>k__BackingField.ShowRewardPopup(param:  new TRVStarChampionshipRewardUIParam());
        if(val_3.isTopTier == false)
        {
                return;
        }
    
    }
    private float GetProgressBarValue(float[] definedDivisions)
    {
        StarChampionshipTier val_7 = this.GetCurrentTier();
        if(val_1.tierIndex == val_2.tierIndex)
        {
                System.Collections.Generic.List<StarChampionshipTier> val_3 = this.GetNextTier().EventEcon;
            int val_7 = val_1.tierIndex;
            int val_4 = val_7 - 1;
            if(val_2.tierIndex <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_7 = val_7 + (val_4 << 3);
            val_7 = mem[(val_1.tierIndex + ((val_1.tierIndex - 1)) << 3) + 32];
            val_7 = (val_1.tierIndex + ((val_1.tierIndex - 1)) << 3) + 32;
        }
        
        int val_10 = this.eventProgress.Stars;
        float val_8 = definedDivisions[((val_1.tierIndex + ((val_1.tierIndex - 1)) << 3) + 32 + 16) << 2];
        float val_9 = definedDivisions[(val_2.tierIndex) << 2];
        val_10 = val_10 - ((val_1.tierIndex + ((val_1.tierIndex - 1)) << 3) + 32 + 20);
        float val_11 = (float)val_10;
        val_11 = val_11 / ((float)val_2.goal - ((val_1.tierIndex + ((val_1.tierIndex - 1)) << 3) + 32 + 20));
        val_9 = val_9 - val_8;
        val_11 = val_8 + (val_11 * val_9);
        return UnityEngine.Mathf.Min(a:  1f, b:  val_11);
    }
    public TRVStarChampionshipEventHandler()
    {
        this.eventProgress = new StarChampionshipEventProgress();
    }

}

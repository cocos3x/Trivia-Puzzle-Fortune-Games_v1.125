using UnityEngine;
public class TriviaMastersEventHandler : WGEventHandler
{
    // Fields
    private const string TRIVIA_MASTERS_NAME = "TRIVIA MASTERS";
    public const string TRIVIA_MASTERS_EVENT_ID = "TriviaMasters";
    public const string EVENT_TRACKING_ID = "Trivia Masters Event";
    private static TriviaMastersEventHandler <Instance>k__BackingField;
    private TriviaMastersEventProgress eventProgress;
    
    // Properties
    public static TriviaMastersEventHandler Instance { get; set; }
    private TriviaMastersEcon EventEcon { get; set; }
    
    // Methods
    public static TriviaMastersEventHandler get_Instance()
    {
        return (TriviaMastersEventHandler)TriviaMastersEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(TriviaMastersEventHandler value)
    {
        TriviaMastersEventHandler.<Instance>k__BackingField = value;
    }
    private TriviaMastersEcon get_EventEcon()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (TriviaMastersEcon)val_1.TriviaMastersEventEcon;
    }
    private void set_EventEcon(TriviaMastersEcon value)
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        val_1.TriviaMastersEventEcon = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517411591904] = eventV2;
        TriviaMastersEventHandler.<Instance>k__BackingField = this;
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
        TriviaMastersEventHandler.<Instance>k__BackingField = 0;
        goto typeof(TriviaMastersEventProgress).__il2cppRuntimeField_190;
    }
    public override void OnGameSceneBegan()
    {
        if((this & 1) != 0)
        {
                return;
        }
    
    }
    public override void OnCategoryComplete()
    {
        if(this.eventProgress.IsPlayingTMQuiz == false)
        {
                return;
        }
        
        this.eventProgress.IsPlayingTMQuiz = false;
        this.EarnToken();
        if(this.GetEventProgressValue() < 1f)
        {
                return;
        }
        
        this.ShowTriviaMastersRewardPopup();
    }
    public override bool EventCompleted()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(TriviaMastersEventHandler).__il2cppRuntimeField_4F0;
    }
    public override void OnCategorySelected(TRVCategorySelectionInfo category)
    {
        var val_15;
        TriviaMastersEventProgress val_16;
        string val_17;
        TriviaMastersEventProgress val_18;
        val_15 = this;
        val_16 = this.eventProgress;
        val_17 = this.eventProgress.SelectedCategory;
        this.eventProgress.IsPlayingTMQuiz = System.String.op_Equality(a:  category.categoryName, b:  val_17);
        val_18 = this.eventProgress;
        if(this.eventProgress.IsPlayingTMQuiz != true)
        {
                if(this.eventProgress.NextTMLevel != App.Player)
        {
                return;
        }
        
            val_18 = this.eventProgress;
        }
        
        this.eventProgress.SelectedCategory = "";
        Player val_4 = App.Player;
        TriviaMastersEcon val_6 = val_4.EventEcon.EventEcon;
        int val_15 = val_6.maxInterval;
        val_15 = (UnityEngine.Random.Range(min:  val_5.minInterval, max:  val_15 + 1)) + val_4;
        this.eventProgress.NextTMLevel = val_15;
        val_15 = ???;
        val_16 = ???;
        goto typeof(TriviaMastersEventProgress).__il2cppRuntimeField_180;
    }
    public override System.Collections.Generic.List<TRVCategorySelectionInfo> GetEventsRegisteredCategories(System.Collections.Generic.List<TRVCategorySelectionInfo> categories)
    {
        System.Predicate<T> val_7;
        if(this.IsEligible() == false)
        {
                return (System.Collections.Generic.List<TRVCategorySelectionInfo>)categories;
        }
        
        var val_7 = 1152921504858656768;
        RandomSet val_2 = new RandomSet();
        val_2.addIntRange(lowest:  0, highest:  44364199);
        int val_3 = val_2.roll(unweighted:  false);
        if(val_7 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + (val_3 << 3);
        this.eventProgress.SelectedCategory = (1152921504858656768 + (val_3) << 3) + 32 + 16;
        System.Predicate<TRVCategorySelectionInfo> val_4 = null;
        val_7 = val_4;
        val_4 = new System.Predicate<TRVCategorySelectionInfo>(object:  this, method:  System.Boolean TriviaMastersEventHandler::<GetEventsRegisteredCategories>b__19_0(TRVCategorySelectionInfo x));
        TRVCategorySelectionInfo val_5 = categories.Find(match:  val_4);
        if(val_5 == null)
        {
                return (System.Collections.Generic.List<TRVCategorySelectionInfo>)categories;
        }
        
        val_7 = val_5;
        if((val_5.associatedEvents.Contains(item:  this)) == true)
        {
                return (System.Collections.Generic.List<TRVCategorySelectionInfo>)categories;
        }
        
        val_5.associatedEvents.Add(item:  this);
        return (System.Collections.Generic.List<TRVCategorySelectionInfo>)categories;
    }
    public override void UpdateProgress()
    {
        mem2[0] = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.ShowTriviaMastersPopup();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.ShowTriviaMastersPopup();
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "trivia_masters_upper", defaultValue:  "TRIVIA MASTERS", useSingularKey:  false), arg1:  this.GetEventProgressText());
    }
    public override string GetGameButtonText()
    {
        return System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "trivia_masters_upper", defaultValue:  "TRIVIA MASTERS", useSingularKey:  false), arg1:  this.GetEventProgressText());
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "trivia_masters_upper", defaultValue:  "TRIVIA MASTERS", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentTriviaMasters>(allowMultiple:  false).SetupSlider(sliderText:  this.GetEventProgressText(), sliderValue:  this.GetEventProgressValue());
    }
    public override UnityEngine.Sprite GetEventIcon()
    {
        return MonoSingleton<TRVUtils>.Instance.GetEventIcon(eventHandler:  this);
    }
    public void CollectReward()
    {
        TriviaMastersEcon val_1 = this.EventEcon;
        if(val_1.reward.rewardType != 0)
        {
                if(val_1.reward.rewardType != 1)
        {
                return;
        }
        
            Player val_2 = App.Player;
            TriviaMastersEcon val_3 = val_2.EventEcon;
            val_2.AddGems(amount:  val_3.reward.rewardAmount, source:  "Trivia Masters", subsource:  0);
            Player val_4 = App.Player;
            TriviaMastersEcon val_5 = val_4.EventEcon;
            val_4.TrackNonCoinReward(source:  "Trivia Masters", subSource:  0, rewardType:  "Gems", rewardAmount:  val_5.reward.rewardAmount.ToString(), additionalParams:  0);
            return;
        }
        
        Player val_7 = App.Player;
        TriviaMastersEcon val_8 = val_7.EventEcon;
        decimal val_9 = System.Decimal.op_Implicit(value:  val_8.reward.rewardAmount);
        val_7.AddCredits(amount:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, source:  "Trivia Masters", subSource:  0, externalParams:  0, doTrack:  true);
    }
    private void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        if((System.String.op_Inequality(a:  0, b:  "TriviaMasters")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + null);
            return;
        }
        
        if(this.IsEventNewCycle() != false)
        {
                this.ResetEventProgress();
        }
        
        this.ParseEcon(data:  data);
        goto typeof(TriviaMastersEventProgress).__il2cppRuntimeField_180;
    }
    private void ParseEcon(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_24;
        string val_25;
        if(data == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = data.Item["economy"];
        val_24 = 0;
        if((ContainsKey(key:  "tk_req")) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  Item["tk_req"], result: out  (TriviaMastersEcon)[1152921517414236720].requirement);
        }
        
        if((ContainsKey(key:  "rew")) == false)
        {
            goto label_18;
        }
        
        object val_10 = Item["rew"];
        val_25 = "g";
        if((val_10.ContainsKey(key:  "g")) == false)
        {
            goto label_14;
        }
        
        (TriviaMastersEcon)[1152921517414236720].reward.rewardType = 1;
        goto label_17;
        label_14:
        val_25 = "c";
        if((val_10.ContainsKey(key:  "c")) == false)
        {
            goto label_18;
        }
        
        (TriviaMastersEcon)[1152921517414236720].reward.rewardType = 0;
        label_17:
        bool val_15 = System.Int32.TryParse(s:  val_10.Item[val_25], result: out  (TriviaMastersEcon)[1152921517414236720].reward.rewardAmount);
        label_18:
        if((ContainsKey(key:  "min_int")) != false)
        {
                bool val_19 = System.Int32.TryParse(s:  Item["min_int"], result: out  (TriviaMastersEcon)[1152921517414236720].minInterval);
        }
        
        System.Int32.TryParse(s:  Item["max_int"], result: out  (TriviaMastersEcon)[1152921517414236720].maxInterval).EventEcon = new TriviaMastersEcon();
    }
    private bool IsEligible()
    {
        var val_4;
        if(App.Player == this.eventProgress.NextTMLevel)
        {
                var val_3 = (this.GetEventProgressValue() < 0) ? 1 : 0;
            return (bool)val_4;
        }
        
        val_4 = 0;
        return (bool)val_4;
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress != (X9 + 16)) ? 1 : 0;
    }
    private void ResetEventProgress()
    {
        this.eventProgress = new TriviaMastersEventProgress();
        mem[1152921517414638416] = "Argument not of type SocketPermission";
    }
    private void EarnToken()
    {
        int val_1 = this.eventProgress.Tokens;
        val_1 = val_1 + 1;
        this.eventProgress.Tokens = val_1;
        goto typeof(TriviaMastersEventProgress).__il2cppRuntimeField_180;
    }
    private float GetEventProgressValue()
    {
        TriviaMastersEcon val_1 = this.EventEcon;
        float val_2 = (float)val_1.requirement;
        val_2 = (float)this.eventProgress.Tokens / val_2;
        return (float)val_2;
    }
    private string GetEventProgressText()
    {
        TriviaMastersEcon val_1 = this.eventProgress.Tokens.EventEcon;
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.eventProgress.Tokens, arg1:  val_1.requirement);
    }
    private void ShowTriviaMastersRewardPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        TriviaMastersEcon val_4 = val_1.<metaGameBehavior>k__BackingField.EventEcon.EventEcon;
        val_1.<metaGameBehavior>k__BackingField.SetupUI(tokens:  val_3.requirement, reward:  val_4.reward);
        this.ResetEventProgress();
        mem2[0] = 1;
        this.ShowTriviaMastersPopup();
        goto typeof(TriviaMastersEventHandler).__il2cppRuntimeField_2B0;
    }
    private void ShowTriviaMastersPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetupUI(progressText:  this.GetEventProgressText(), progressValue:  this.GetEventProgressValue());
    }
    public TriviaMastersEventHandler()
    {
        this.eventProgress = new TriviaMastersEventProgress();
    }
    private bool <GetEventsRegisteredCategories>b__19_0(TRVCategorySelectionInfo x)
    {
        return System.String.op_Equality(a:  x.categoryName, b:  this.eventProgress.SelectedCategory);
    }

}

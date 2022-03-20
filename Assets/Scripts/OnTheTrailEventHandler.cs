using UnityEngine;
public class OnTheTrailEventHandler : WGEventHandler
{
    // Fields
    public const string ON_THE_TRAIL_EVENT_ID = "OnTheTrail";
    public OnTheTrailEventEcon Econ;
    private OnTheTrailEventProgress eventProgress;
    private static OnTheTrailEventHandler <Instance>k__BackingField;
    
    // Properties
    public static OnTheTrailEventHandler Instance { get; set; }
    private System.Collections.Generic.List<bool> DaysRewarded { get; }
    private OnTheTrailDayProgress SavedDayProgress { get; }
    private OnTheTrailDayProgress WagonBrokenDayProgress { get; set; }
    
    // Methods
    public static OnTheTrailEventHandler get_Instance()
    {
        return (OnTheTrailEventHandler)OnTheTrailEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(OnTheTrailEventHandler value)
    {
        OnTheTrailEventHandler.<Instance>k__BackingField = value;
    }
    private System.Collections.Generic.List<bool> get_DaysRewarded()
    {
        if(this.eventProgress != null)
        {
                return (System.Collections.Generic.List<System.Boolean>)this.eventProgress.DaysRewarded;
        }
        
        throw new NullReferenceException();
    }
    private OnTheTrailDayProgress get_SavedDayProgress()
    {
        if(this.eventProgress != null)
        {
                return (OnTheTrailDayProgress)this.eventProgress.SavedDayProgress;
        }
        
        throw new NullReferenceException();
    }
    private OnTheTrailDayProgress get_WagonBrokenDayProgress()
    {
        if(this.eventProgress != null)
        {
                return (OnTheTrailDayProgress)this.eventProgress.WagonBrokenDayProgress;
        }
        
        throw new NullReferenceException();
    }
    private void set_WagonBrokenDayProgress(OnTheTrailDayProgress value)
    {
        if(this.eventProgress != null)
        {
                this.eventProgress.WagonBrokenDayProgress = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public override void Init(GameEventV2 eventV2)
    {
        OnTheTrailEventHandler.<Instance>k__BackingField = this;
        mem[1152921516542644032] = eventV2;
        if((this & 1) != 0)
        {
                return;
        }
        
        this.RefreshEventData(data:  eventV2.eventData);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.RefreshEventData(data:  eventV2.eventData);
    }
    public override void OnGameSceneInit()
    {
        OnTheTrailEvent.PopupUIParameters_Basic val_8;
        System.Collections.Generic.List<System.Int32> val_9;
        if((this & 1) != 0)
        {
                return;
        }
        
        if(this.eventProgress.IsFtuxSeen != false)
        {
                return;
        }
        
        if(this.eventProgress.IsWagonBroken != false)
        {
                OnTheTrailEvent.PopupUIParameters_BrokenWagon val_1 = null;
            val_8 = val_1;
            val_1 = new OnTheTrailEvent.PopupUIParameters_BrokenWagon();
            int val_2 = this.GetCurrentDay();
            mem[1152921516543027008] = val_2;
            System.TimeSpan val_3 = this.GetTimeLeftUntilEndOfDay(day:  val_2);
            mem[1152921516543027016] = val_3._ticks;
            mem[1152921516543027024] = this.eventProgress.DaysRewarded;
            mem[1152921516543027032] = this.Econ.Rewards;
            mem[1152921516543027040] = this.eventProgress.WagonBrokenDayProgress.CompletedLevels;
            OnTheTrailEventEcon val_8 = this.Econ;
            val_9 = this.Econ.Goals;
            if(val_8 <= this.eventProgress.WagonBrokenDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + ((this.eventProgress.WagonBrokenDayProgress.DayIndex) << 2);
            mem[1152921516543027044] = (this.Econ + (this.eventProgress.WagonBrokenDayProgress.DayIndex) << 2).FixPrice;
            .WagonFixPrice = this.Econ.FixPrice;
        }
        else
        {
                OnTheTrailEvent.PopupUIParameters_DayInProgress val_4 = null;
            val_8 = val_4;
            val_4 = new OnTheTrailEvent.PopupUIParameters_DayInProgress();
            int val_5 = this.GetCurrentDay();
            mem[1152921516543076160] = val_5;
            System.TimeSpan val_6 = this.GetTimeLeftUntilEndOfDay(day:  val_5);
            mem[1152921516543076168] = val_6._ticks;
            mem[1152921516543076176] = this.eventProgress.DaysRewarded;
            mem[1152921516543076184] = this.Econ.Rewards;
            mem[1152921516543076192] = this.eventProgress.SavedDayProgress.CompletedLevels;
            OnTheTrailEventEcon val_9 = this.Econ;
            val_9 = this.Econ.Goals;
            OnTheTrailEventEcon val_7 = val_9 - 1;
            if(this.eventProgress.IsFtuxSeen <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_9 = val_9 + (val_7 << 2);
            mem[1152921516543076196] = (this.Econ + ((this.Econ - 1)) << 2).FixPrice;
        }
        
        this.ShowOnTheTrailPopup(param:  val_4);
        this.eventProgress.IsFtuxSeen = true;
        goto typeof(OnTheTrailEventProgress).__il2cppRuntimeField_180;
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        UnityEngine.Object val_16;
        OnTheTrailEventProgress val_17;
        OnTheTrailEvent.PopupUIParameters_Basic val_18;
        var val_19;
        OnTheTrailEventProgress val_20;
        val_16 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_16 != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        }
        
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        val_17 = this.eventProgress;
        if(this.eventProgress.IsWagonBroken == true)
        {
                return;
        }
        
        val_16 = this.eventProgress.DaysRewarded;
        if(this.eventProgress.IsWagonBroken > this.eventProgress.SavedDayProgress.DayIndex)
        {
                if(this.eventProgress.IsWagonBroken <= this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_17 = val_17 + this.eventProgress.SavedDayProgress.DayIndex;
            if(((this.eventProgress + this.eventProgress.SavedDayProgress.DayIndex).SavedDayProgress) != null)
        {
                return;
        }
        
            val_17 = this.eventProgress;
        }
        
        System.TimeSpan val_7 = this.GetTimeLeftUntilEndOfDay(day:  this.eventProgress.SavedDayProgress.DayIndex + 1);
        val_18 = 0;
        double val_8 = val_7._ticks.TotalSeconds;
        val_8 = (val_8 == Infinity) ? (-val_8) : (val_8);
        if(((int)val_8 & 2147483648) != 0)
        {
            goto label_21;
        }
        
        int val_15 = this.eventProgress.SavedDayProgress.CompletedLevels;
        val_15 = val_15 + levelsProgressed;
        this.eventProgress.SavedDayProgress.CompletedLevels = val_15;
        if((this & 1) == 0)
        {
                return;
        }
        
        OnTheTrailEvent.PopupUIParameters_RewardAvailable val_9 = new OnTheTrailEvent.PopupUIParameters_RewardAvailable();
        int val_10 = this.GetCurrentDay();
        mem[1152921516543388864] = val_10;
        System.TimeSpan val_11 = this.GetTimeLeftUntilEndOfDay(day:  val_10);
        mem[1152921516543388872] = val_11._ticks;
        mem[1152921516543388880] = this.eventProgress.DaysRewarded;
        mem[1152921516543388888] = this.Econ.Rewards;
        mem[1152921516543388896] = this.eventProgress.SavedDayProgress.CompletedLevels;
        OnTheTrailEventEcon val_17 = this.Econ;
        val_16 = val_10 - 1;
        if(val_17 <= val_16)
        {
            goto label_32;
        }
        
        val_19 = val_16;
        if(val_17 > val_16)
        {
            goto label_43;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_19 = val_16;
        goto label_43;
        label_21:
        val_20 = this.eventProgress;
        int val_16 = this.eventProgress.SavedDayProgress.DayIndex;
        val_16 = this.GetCurrentDay() - val_16;
        if(val_16 >= 2)
        {
                this.eventProgress.IsWagonBroken = true;
            val_20 = this.eventProgress;
        }
        
        val_16 = this.eventProgress.SavedDayProgress.DayIndex + val_16;
        this.eventProgress.SavedDayProgress.DayIndex = val_16;
        this.eventProgress.SavedDayProgress.CompletedLevels = (this.eventProgress.IsWagonBroken == false) ? levelsProgressed : 0;
        return;
        label_32:
        val_19 = val_17 - 1;
        if(val_17 == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        label_43:
        val_17 = val_17 + (val_19 << 2);
        mem[1152921516543388900] = (this.Econ + ((this.Econ - 1)) << 2).FixPrice;
        OnTheTrailEventEcon val_18 = this.Econ;
        if(val_18 <= val_16)
        {
            goto label_46;
        }
        
        if(val_18 > val_16)
        {
            goto label_49;
        }
        
        label_50:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        label_49:
        val_18 = val_9;
        val_18 = val_18 + (val_16 << 2);
        .CurrentReward = (this.Econ + ((val_10 - 1)) << 2).FixPrice;
        this.ShowOnTheTrailPopup(param:  val_9);
        return;
        label_46:
        OnTheTrailEventEcon val_14 = val_18 - 1;
        if(val_18 != null)
        {
            goto label_49;
        }
        
        goto label_50;
    }
    public override void OnEventEnded()
    {
        if(this.eventProgress != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public override bool EventCompleted()
    {
        OnTheTrailEventProgress val_4;
        var val_5;
        val_4 = this.eventProgress;
        int val_2 = this.GetEventDurationInDays() - 1;
        if(this.eventProgress.SavedDayProgress.DayIndex != val_2)
        {
                return (bool)(this.eventProgress.IsEventCompleted == true) ? 1 : 0;
        }
        
        if(val_4 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + (val_2 << );
        if((((this.eventProgress + ((val_1 - 1)) << ).SavedDayProgress) & 1) != 0)
        {
                val_5 = 1;
            return (bool)(this.eventProgress.IsEventCompleted == true) ? 1 : 0;
        }
        
        val_4 = this.eventProgress;
        return (bool)(this.eventProgress.IsEventCompleted == true) ? 1 : 0;
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(OnTheTrailEventHandler).__il2cppRuntimeField_4F0;
    }
    public override int LastProgressTimestamp()
    {
        if(this.eventProgress != null)
        {
                return (int)this.eventProgress.LastProgressTimestamp;
        }
        
        throw new NullReferenceException();
    }
    public override void UpdateProgress()
    {
        this.eventProgress.LastProgressTimestamp = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        System.Collections.Generic.List<System.Boolean> val_2;
        var val_3;
        val_2 = this;
        OnTheTrailDayProgress val_2 = this.eventProgress.SavedDayProgress;
        if(this.Econ <= (long)this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (((long)(int)(this.eventProgress.SavedDayProgress.DayIndex)) << 2);
        if(this.eventProgress.SavedDayProgress.CompletedLevels == val_2)
        {
                OnTheTrailDayProgress val_3 = this.eventProgress.SavedDayProgress;
            val_2 = this.eventProgress.DaysRewarded;
            if(val_3 <= this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = val_3 + this.eventProgress.SavedDayProgress.DayIndex;
            var val_1 = (val_3 == 0) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "{0} {1}", arg0:  this.GetEventNameLoc(), arg1:  this.GetTodaysProgressText());
    }
    public override string GetGameButtonText()
    {
        return this.GetTodaysProgressText();
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "on_the_trail_upper", defaultValue:  "ON THE TRAIL", useSingularKey:  false);
    }
    public override string GetCustomizedEventListItemTimerText()
    {
        int val_1 = this.GetCurrentDay();
        System.TimeSpan val_2 = this.GetTimeLeftUntilEndOfDay(day:  val_1);
        object[] val_3 = new object[4];
        val_3[0] = Localization.Localize(key:  "day_upper", defaultValue:  "DAY", useSingularKey:  false);
        val_3[1] = val_1;
        val_3[2] = UnityEngine.Mathf.Max(a:  val_2._ticks.Hours, b:  0);
        val_3[3] = UnityEngine.Mathf.Max(a:  val_2._ticks.Minutes, b:  0);
        return (string)System.String.Format(format:  "{0} {1}: {2}h {3}m", args:  val_3);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        var val_7;
        var val_8;
        val_7 = this;
        if(this.IsEventExpired() != true)
        {
                if((val_7 & 1) == 0)
        {
            goto label_2;
        }
        
        }
        
        val_7 = ???;
        goto typeof(OnTheTrailEventHandler).__il2cppRuntimeField_2B0;
        label_2:
        val_8 = null;
        val_8 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 75;
        val_7.OnEventButtonPressed();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        var val_11;
        var val_12;
        val_11 = this;
        if(this.IsEventExpired() != true)
        {
                if((val_11 & 1) == 0)
        {
            goto label_2;
        }
        
        }
        
        val_11 = ???;
        goto typeof(OnTheTrailEventHandler).__il2cppRuntimeField_2B0;
        label_2:
        val_12 = null;
        val_12 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true) ? (76 + 1) : 76;
        val_11.OnEventButtonPressed();
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        string val_7;
        OnTheTrailEventProgress val_8;
        int val_9;
        OnTheTrailEventProgress val_10;
        var val_11;
        OnTheTrailEventEcon val_14;
        OnTheTrailDayProgress val_15;
        OnTheTrailEventProgress val_16;
        if(this.IsEventExpired() == true)
        {
                return;
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        this.RefreshLatestProgress(day:  this.GetCurrentDay());
        val_8 = this.eventProgress;
        if(this.eventProgress.IsWagonBroken == false)
        {
            goto label_4;
        }
        
        OnTheTrailDayProgress val_7 = this.eventProgress.WagonBrokenDayProgress;
        val_9 = this.eventProgress.WagonBrokenDayProgress.CompletedLevels;
        if(this.Econ <= (long)this.eventProgress.WagonBrokenDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = this.eventProgress;
        }
        
        val_11 = 1152921504619999232;
        val_7 = val_7 + (((long)(int)(this.eventProgress.WagonBrokenDayProgress.DayIndex)) << 2);
        val_14 = this.Econ;
        val_15 = this.eventProgress.WagonBrokenDayProgress;
        if(val_15 != null)
        {
            goto label_13;
        }
        
        label_4:
        OnTheTrailDayProgress val_8 = this.eventProgress.SavedDayProgress;
        val_9 = this.eventProgress.SavedDayProgress.CompletedLevels;
        if(this.Econ <= (long)this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_16 = this.eventProgress;
        }
        
        val_11 = 1152921504619999232;
        val_8 = val_8 + (((long)(int)(this.eventProgress.SavedDayProgress.DayIndex)) << 2);
        val_14 = this.Econ;
        val_15 = this.eventProgress.SavedDayProgress;
        label_13:
        float val_9 = (float)S8;
        if(val_14 <= this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = (float)val_9 / val_9;
        val_14 = val_14 + ((this.eventProgress.SavedDayProgress.DayIndex) << 2);
        val_7 = System.String.Format(format:  "{0}\n{1}", arg0:  System.String.Format(format:  "{0}/{1}", arg0:  this.eventProgress.SavedDayProgress.CompletedLevels, arg1:  (this.Econ + (this.eventProgress.SavedDayProgress.DayIndex) << 2).FixPrice), arg1:  Localization.Localize(key:  "levels_upper", defaultValue:  "LEVELS", useSingularKey:  false));
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentOnTheTrail>(allowMultiple:  false).Setup(progress:  val_9, progressText:  val_7, isWagonBroken:  this.eventProgress.IsWagonBroken);
    }
    public System.Collections.Generic.KeyValuePair<int, System.TimeSpan> GetDayTimeInfo()
    {
        int val_1 = this.GetCurrentDay();
        System.TimeSpan val_2 = this.GetTimeLeftUntilEndOfDay(day:  val_1);
        System.Collections.Generic.KeyValuePair<System.Int32, System.TimeSpan> val_3 = new System.Collections.Generic.KeyValuePair<System.Int32, System.TimeSpan>(key:  val_1, value:  new System.TimeSpan() {_ticks = val_2._ticks});
        return (System.Collections.Generic.KeyValuePair<System.Int32, System.TimeSpan>)val_3.Value._ticks;
    }
    private void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        string val_16;
        bool val_17;
        int val_18;
        int val_19;
        if((System.String.op_Inequality(a:  0, b:  "OnTheTrail")) != false)
        {
                return;
        }
        
        if(data == null)
        {
            goto label_3;
        }
        
        if((data.ContainsKey(key:  "rewarded")) != false)
        {
                if((System.Boolean.Parse(value:  data.Item["rewarded"])) != false)
        {
                this.eventProgress.IsEventCompleted = true;
            return;
        }
        
        }
        
        this.Econ = new OnTheTrailEventEcon();
        val_16 = "economy";
        if((data.ContainsKey(key:  val_16)) == false)
        {
            goto label_15;
        }
        
        val_16 = 0;
        goto label_14;
        label_3:
        this.Econ = new OnTheTrailEventEcon();
        goto label_15;
        label_14:
        this.Econ = data.Item["economy"].ParseEventEcon(econData:  null);
        label_15:
        if(this.IsEventNewCycle() != false)
        {
                this.ResetEventProgress();
        }
        
        int val_11 = this.GetCurrentDay();
        val_17 = this.eventProgress.IsInitialized;
        int val_12 = val_11 - 1;
        int val_13 = val_12 - this.eventProgress.SavedDayProgress.DayIndex;
        if(val_13 <= 0)
        {
            goto label_20;
        }
        
        if(val_17 == false)
        {
            goto label_24;
        }
        
        int val_14 = val_11 - 2;
        if(val_17 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_17 = val_17 + (val_14 << );
        val_17 = ((this.eventProgress.IsInitialized + ((val_11 - 2)) << ) + 32) ^ 1;
        goto label_24;
        label_20:
        if(val_17 == true)
        {
            goto typeof(OnTheTrailEventProgress).__il2cppRuntimeField_180;
        }
        
        label_24:
        this.eventProgress.IsWagonBroken = val_17;
        if(this.eventProgress.IsWagonBroken != false)
        {
                if(val_13 < 2)
        {
                val_18 = this.eventProgress.SavedDayProgress.DayIndex;
            val_19 = this.eventProgress.SavedDayProgress.CompletedLevels;
        }
        else
        {
                val_19 = 0;
            val_18 = val_11 - 2;
        }
        
            this.eventProgress.WagonBrokenDayProgress.DayIndex = val_18;
            this.eventProgress.WagonBrokenDayProgress.CompletedLevels = val_19;
        }
        
        this.eventProgress.SavedDayProgress.DayIndex = val_12;
        this.eventProgress.SavedDayProgress.CompletedLevels = 0;
        this.eventProgress.IsInitialized = true;
        goto typeof(OnTheTrailEventProgress).__il2cppRuntimeField_180;
    }
    private OnTheTrailEventEcon ParseEventEcon(System.Collections.Generic.Dictionary<string, object> econData)
    {
        int val_7;
        var val_8;
        var val_19;
        int val_20;
        var val_21;
        if(econData == null)
        {
                return (OnTheTrailEventEcon)new OnTheTrailEventEcon();
        }
        
        if((econData.ContainsKey(key:  "goal_levels")) == false)
        {
            goto label_35;
        }
        
        .Goals = new System.Collections.Generic.List<System.Int32>();
        object val_4 = econData.Item["goal_levels"];
        List.Enumerator<T> val_6 = GetEnumerator();
        label_13:
        val_19 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_9;
        }
        
        if((OnTheTrailEventEcon)[1152921516545863856].Goals == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = val_7;
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = null;
        (OnTheTrailEventEcon)[1152921516545863856].Goals.Add(item:  val_20);
        goto label_13;
        label_9:
        val_8.Dispose();
        label_35:
        val_21 = "golden_rew";
        if((econData.ContainsKey(key:  "golden_rew")) == false)
        {
            goto label_32;
        }
        
        .Rewards = new System.Collections.Generic.List<System.Int32>();
        List.Enumerator<T> val_13 = econData.Item["golden_rew"].GetEnumerator();
        val_21 = 1152921510211410768;
        label_23:
        val_19 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_19;
        }
        
        if((OnTheTrailEventEcon)[1152921516545863856].Rewards == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = val_7;
        if(val_20 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = null;
        (OnTheTrailEventEcon)[1152921516545863856].Rewards.Add(item:  val_20);
        goto label_23;
        label_19:
        val_8.Dispose();
        label_32:
        if((econData.ContainsKey(key:  "fix_price")) == false)
        {
                return (OnTheTrailEventEcon)new OnTheTrailEventEcon();
        }
        
        .FixPrice = System.Int32.Parse(s:  econData.Item["fix_price"]);
        return (OnTheTrailEventEcon)new OnTheTrailEventEcon();
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress.Timestamp != (X9 + 16)) ? 1 : 0;
    }
    private void ResetEventProgress()
    {
        this.eventProgress = new OnTheTrailEventProgress();
        .Timestamp = public System.Void System.Collections.Generic.List<GiftRewardRevealInfo>::.ctor();
        int val_2 = this.GetEventDurationInDays();
        this.eventProgress.DaysRewarded = new System.Collections.Generic.List<System.Boolean>(collection:  new bool[0]);
    }
    private void UpdateRewardStatusToServer()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "rewarded", value:  true);
        MonoSingleton<GameEventsManager>.Instance.PutUpdate(eventID:  -1940626368, data:  val_1);
    }
    private bool IsEventExpired()
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
    private int GetCurrentDay()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 32});
        return (int)UnityEngine.Mathf.CeilToInt(f:  (float)val_2._ticks.TotalDays);
    }
    private System.TimeSpan GetTimeLeftUntilEndOfDay(int day)
    {
        System.DateTime val_3 = true + 32.AddSeconds(value:  (double)this.Econ.SecondsPerDay * day);
        System.DateTime val_4 = DateTimeCheat.UtcNow;
        return System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = val_4.dateData});
    }
    private int GetEventDurationInDays()
    {
        System.TimeSpan val_1 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = 163547}, d2:  new System.DateTime() {dateData = 16140901064495857664});
        return (int)UnityEngine.Mathf.CeilToInt(f:  (float)val_1._ticks.TotalDays);
    }
    private string GetTodaysProgressText()
    {
        OnTheTrailEventEcon val_2 = this.Econ;
        if(val_2 <= this.eventProgress.SavedDayProgress.DayIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + ((this.eventProgress.SavedDayProgress.DayIndex) << 2);
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  this.eventProgress.SavedDayProgress.CompletedLevels, arg1:  (this.Econ + (this.eventProgress.SavedDayProgress.DayIndex) << 2).FixPrice);
    }
    private string GetEventNameLoc()
    {
        return Localization.Localize(key:  "on_the_trail_upper", defaultValue:  "ON THE TRAIL", useSingularKey:  false);
    }
    private void ShowOnTheTrailPopup(OnTheTrailEvent.PopupUIParameters_Basic param)
    {
        if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WGOnTheTrailPopup>().isActiveAndEnabled) != false)
        {
                if((MonoSingleton<WGWindowManager>.Instance.GetWindow<WGOnTheTrailPopup>()) != null)
        {
            goto label_9;
        }
        
        }
        
        label_9:
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGOnTheTrailPopup>(showNext:  true).Setup(param:  param);
    }
    private void RefreshLatestProgress(int day)
    {
        int val_3;
        int val_4;
        int val_3 = this.eventProgress.SavedDayProgress.DayIndex;
        int val_1 = day - 1;
        int val_2 = val_1 - val_3;
        if(val_2 < 1)
        {
                return;
        }
        
        val_3 = day - 2;
        if(val_3 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + (val_3 << );
        bool val_4 = (this.eventProgress.SavedDayProgress.DayIndex + ((day - 2)) << ) + 32;
        val_4 = val_4 ^ 1;
        this.eventProgress.IsWagonBroken = val_4;
        if(this.eventProgress.IsWagonBroken != false)
        {
                if(val_2 < 2)
        {
                val_3 = this.eventProgress.SavedDayProgress.DayIndex;
            val_4 = this.eventProgress.SavedDayProgress.CompletedLevels;
        }
        else
        {
                val_4 = 0;
        }
        
            this.eventProgress.WagonBrokenDayProgress.DayIndex = val_3;
            this.eventProgress.WagonBrokenDayProgress.CompletedLevels = val_4;
        }
        
        this.eventProgress.SavedDayProgress.DayIndex = val_1;
        this.eventProgress.SavedDayProgress.CompletedLevels = 0;
        goto typeof(OnTheTrailEventProgress).__il2cppRuntimeField_180;
    }
    public void FixWagon()
    {
        decimal val_2 = System.Decimal.op_Implicit(value:  -this.Econ.FixPrice);
        App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Wagon Fix", subSource:  0, externalParams:  0, doTrack:  true);
        this.eventProgress.IsWagonBroken = false;
        goto typeof(OnTheTrailEventProgress).__il2cppRuntimeField_180;
    }
    public void CollectReward(int rewardAmount)
    {
        GoldenApplesManager val_1 = MonoSingleton<GoldenApplesManager>.Instance;
        int val_5 = this.eventProgress.SavedDayProgress.DayIndex;
        val_5 = val_5 + 1;
        string val_2 = System.String.Format(format:  "On The Trail Day {0}", arg0:  val_5);
        this.eventProgress.DaysRewarded.set_Item(index:  this.eventProgress.SavedDayProgress.DayIndex, value:  true);
        if(this.eventProgress.SavedDayProgress.DayIndex != (this.GetEventDurationInDays() - 1))
        {
                return;
        }
        
        this.eventProgress.IsEventCompleted = true;
        this.UpdateRewardStatusToServer();
    }
    public void OnEventButtonPressed()
    {
        System.Collections.Generic.List<System.Int32> val_7;
        long val_8;
        OnTheTrailEvent.PopupUIParameters_Basic val_9;
        var val_10;
        val_7 = this;
        int val_1 = this.GetCurrentDay();
        System.TimeSpan val_2 = this.GetTimeLeftUntilEndOfDay(day:  val_1);
        val_8 = val_2._ticks;
        this.RefreshLatestProgress(day:  val_1);
        OnTheTrailEventProgress val_8 = this.eventProgress;
        if(this.eventProgress.IsWagonBroken == false)
        {
            goto label_2;
        }
        
        OnTheTrailEvent.PopupUIParameters_BrokenWagon val_3 = null;
        val_9 = val_3;
        val_3 = new OnTheTrailEvent.PopupUIParameters_BrokenWagon();
        mem[1152921516548027024] = val_1;
        mem[1152921516548027032] = val_8;
        mem[1152921516548027040] = this.eventProgress.DaysRewarded;
        mem[1152921516548027048] = this.Econ.Rewards;
        mem[1152921516548027056] = this.eventProgress.WagonBrokenDayProgress.CompletedLevels;
        OnTheTrailEventEcon val_7 = this.Econ;
        val_8 = this.eventProgress.WagonBrokenDayProgress.DayIndex;
        if(val_7 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + ((this.eventProgress.WagonBrokenDayProgress.DayIndex) << 2);
        mem[1152921516548027060] = (this.Econ + (this.eventProgress.WagonBrokenDayProgress.DayIndex) << 2).FixPrice;
        .WagonFixPrice = this.Econ.FixPrice;
        goto label_14;
        label_2:
        int val_4 = val_1 - 1;
        if(val_8 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_8 = val_8 + (val_4 << );
        if(((this.eventProgress + ((val_1 - 1)) << ).SavedDayProgress) == null)
        {
            goto label_17;
        }
        
        val_10 = 1152921505020264448;
        goto label_18;
        label_17:
        OnTheTrailDayProgress val_9 = this.eventProgress.SavedDayProgress;
        if(this.Econ <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + (((long)(int)((val_1 - 1))) << 2);
        if(this.eventProgress.SavedDayProgress.CompletedLevels != val_9)
        {
            goto label_24;
        }
        
        OnTheTrailEvent.PopupUIParameters_RewardAvailable val_5 = null;
        val_9 = val_5;
        val_5 = new OnTheTrailEvent.PopupUIParameters_RewardAvailable();
        mem[1152921516548100752] = val_1;
        mem[1152921516548100760] = val_8;
        mem[1152921516548100768] = this.eventProgress.DaysRewarded;
        mem[1152921516548100776] = this.Econ.Rewards;
        OnTheTrailEventEcon val_10 = this.Econ;
        if(val_10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((long)(int)((val_1 - 1))) << 2);
        .CurrentReward = (this.Econ + ((long)(int)((val_1 - 1))) << 2).FixPrice;
        goto label_31;
        label_24:
        val_10 = 1152921505020211200;
        label_18:
        OnTheTrailEvent.PopupUIParameters_DayInProgress val_6 = null;
        val_9 = val_6;
        val_6 = new OnTheTrailEvent.PopupUIParameters_DayInProgress();
        mem[1152921516548129424] = val_1;
        mem[1152921516548129432] = val_8;
        mem[1152921516548129440] = this.eventProgress.DaysRewarded;
        mem[1152921516548129448] = this.Econ.Rewards;
        label_31:
        mem[1152921516548129456] = this.eventProgress.SavedDayProgress.CompletedLevels;
        OnTheTrailEventEcon val_11 = this.Econ;
        val_7 = this.Econ.Goals;
        if(val_11 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_11 = val_11 + (((long)(int)((val_1 - 1))) << 2);
        mem[1152921516548129460] = (this.Econ + ((long)(int)((val_1 - 1))) << 2).FixPrice;
        label_14:
        this.ShowOnTheTrailPopup(param:  val_6);
    }
    public OnTheTrailEventHandler()
    {
        this.Econ = new OnTheTrailEventEcon();
        this.eventProgress = new OnTheTrailEventProgress();
    }

}

using UnityEngine;
public class ForestFrenzyEventHandler : WGEventHandler
{
    // Fields
    public const string EVENT_ID = "ForestFrenzy";
    private const string ECONOMY = "economy";
    private int track_ShovelsEarnedThisLevel;
    private static ForestFrenzyEventHandler <Instance>k__BackingField;
    
    // Properties
    private static int LastProgressTimestampPref { get; set; }
    public static ForestFrenzyEventHandler Instance { get; set; }
    public override bool SupportsGoldenApples { get; }
    
    // Methods
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "ffrzy_lst_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "ffrzy_lst_prog_ts", value:  value);
    }
    public static ForestFrenzyEventHandler get_Instance()
    {
        return (ForestFrenzyEventHandler)ForestFrenzyEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(ForestFrenzyEventHandler value)
    {
        ForestFrenzyEventHandler.<Instance>k__BackingField = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921516244337104] = eventV2;
        ForestFrenzyEventHandler.<Instance>k__BackingField = this;
        ForestFrenzyEventProgress.Init(gameEventV2:  eventV2);
        eventV2.ParseEventData(data:  eventV2.eventData);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        this.ParseEventData(data:  eventV2.eventData);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnForestFrenzyEventDataUpdate");
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        MonoSingleton<ForestFrenzyManager>.Instance.ShowForestScene();
    }
    public override void OnGameButtonPressed(bool connected)
    {
        MonoSingleton<ForestFrenzyManager>.Instance.ShowForestScene();
    }
    public override void OnAppleAwarded(int appleAwarded)
    {
        UnityEngine.Object val_15;
        var val_16 = this;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        val_15 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_15 != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        }
        
        if((val_16 & 1) != 0)
        {
                return;
        }
        
        val_15 = MonoSingleton<ForestFrenzyManager>.Instance;
        int val_7 = UnityEngine.Mathf.Max(a:  0, b:  appleAwarded);
        val_7.AddCurrency(amount:  val_7);
        int val_15 = this.track_ShovelsEarnedThisLevel;
        val_15 = val_15 + appleAwarded;
        this.track_ShovelsEarnedThisLevel = val_15;
        if(appleAwarded < 1)
        {
                return;
        }
        
        val_16 = ???;
        val_15 = ???;
        goto typeof(ForestFrenzyEventHandler).__il2cppRuntimeField_2B0;
    }
    public override bool get_SupportsGoldenApples()
    {
        return true;
    }
    public override string GetMainMenuButtonText()
    {
        object val_5;
        WordForest.WFOForestData val_4 = MonoSingleton<ForestFrenzyManager>.Instance.CurrentForestData;
        return (string)System.String.Format(format:  "{0}\n{1} / {2}", arg0:  this, arg1:  MonoSingleton<ForestFrenzyManager>.Instance.CurrentForestGrowth, arg2:  val_5);
    }
    public override string GetGameButtonText()
    {
        return "N/A";
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "forest_frenzy_upper", defaultValue:  "FOREST FRENZY", useSingularKey:  false);
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        object val_5;
        int val_2 = MonoSingleton<ForestFrenzyManager>.Instance.CurrentForestGrowth;
        WordForest.WFOForestData val_4 = MonoSingleton<ForestFrenzyManager>.Instance.CurrentForestData;
        float val_8 = (float)val_2;
        val_8 = val_8 / (float)val_5;
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentForestFrenzy>(allowMultiple:  false).SetupSlider(sliderText:  System.String.Format(format:  "{0}/{1}", arg0:  val_2, arg1:  val_5), sliderValue:  val_8);
    }
    public override void OnLevelComplete(int levelsProgressed = 1)
    {
        UnityEngine.Object val_8;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        val_8 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_8 != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        this.OnLevelComplete(levelsProgressed:  levelsProgressed);
        bool val_7 = MonoSingleton<ForestFrenzyManager>.Instance.TryShowForestBeforeLevelComplete();
    }
    public override void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> currentData)
    {
        UnityEngine.Object val_6;
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        val_6 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_6 != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        }
        
        if((this & 1) != 0)
        {
                return;
        }
        
        currentData.Add(key:  "Shovels Earned", value:  this.track_ShovelsEarnedThisLevel);
        this.track_ShovelsEarnedThisLevel = 0;
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        bool val_1 = CategoryPacksManager.IsPlaying;
        val_1 = (~(val_1 | dailyChallengeState)) & 1;
        return (bool)val_1;
    }
    public override bool EventCompleted()
    {
        null = null;
        return (bool)ForestFrenzyEventProgress.hasRewarded;
    }
    public override int LastProgressTimestamp()
    {
        return ForestFrenzyEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        ForestFrenzyEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_15;
        int val_16;
        var val_17;
        var val_18;
        var val_19;
        val_15 = data;
        if(val_15 == null)
        {
                return;
        }
        
        if((val_15.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = val_15.Item["economy"];
        if(val_2 == null)
        {
                return;
        }
        
        val_15 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_2) : 0;
        if((val_15.ContainsKey(key:  "loc_rew")) != false)
        {
                decimal val_6 = System.Decimal.Parse(s:  val_15.Item["loc_rew"], provider:  System.Globalization.CultureInfo.InvariantCulture);
            val_16 = val_6.lo;
            val_17 = null;
            val_17 = null;
            ForestFrenzyEcon.ForestCompleteReward = val_6.flags;
            ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_10 = val_6.hi;
            ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_14 = val_16;
            ForestFrenzyEcon.UnlockLevel.__il2cppRuntimeField_18 = val_6.mid;
        }
        
        if((val_15.ContainsKey(key:  "lvls_to_play")) != false)
        {
                val_16 = 1152921504916004864;
            val_18 = null;
            val_18 = null;
            bool val_10 = System.Int32.TryParse(s:  val_15.Item["lvls_to_play"], result: out  1152921504916008964);
        }
        
        if((val_15.ContainsKey(key:  "cd")) == false)
        {
                return;
        }
        
        val_19 = null;
        val_19 = null;
        bool val_14 = System.Int32.TryParse(s:  val_15.Item["cd"], result: out  1152921504916008968);
    }
    public ForestFrenzyEventHandler()
    {
    
    }

}

using UnityEngine;
public class HintManiaEventHandler : WGEventHandler
{
    // Fields
    private static HintManiaEventHandler _Instance;
    public const string HINT_MANIA_ID = "HintMania";
    private GameEventRewardType _currentRewardType;
    private int _hintRewardOdds;
    private System.Collections.Generic.Dictionary<string, object> rewardProbabilities;
    private System.Collections.Generic.Dictionary<string, object> rewardValues;
    
    // Properties
    public static HintManiaEventHandler Instance { get; }
    public GameEventV2 getEvent { get; }
    public GameEventRewardType currentRewardType { get; }
    public int hintRewardOdds { get; }
    private static int LastProgressTimestampPref { get; set; }
    private int LastEventPopupShown { get; set; }
    public override bool IsEventHidden { get; }
    
    // Methods
    public static HintManiaEventHandler get_Instance()
    {
        return (HintManiaEventHandler)HintManiaEventHandler.HINT_MANIA_ID;
    }
    public GameEventV2 get_getEvent()
    {
        return (GameEventV2)this;
    }
    public GameEventRewardType get_currentRewardType()
    {
        return (GameEventRewardType)this._currentRewardType;
    }
    public int get_hintRewardOdds()
    {
        return (int)this._hintRewardOdds;
    }
    private static int get_LastProgressTimestampPref()
    {
        return UnityEngine.PlayerPrefs.GetInt(key:  "hint_mania_prog_ts", defaultValue:  0);
    }
    private static void set_LastProgressTimestampPref(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key:  "hint_mania_prog_ts", value:  value);
    }
    private int get_LastEventPopupShown()
    {
        return CPlayerPrefs.GetInt(key:  "hint_mania_last_shown", defaultValue:  0);
    }
    private void set_LastEventPopupShown(int value)
    {
        CPlayerPrefs.SetInt(key:  "hint_mania_last_shown", val:  value);
    }
    public override void Init(GameEventV2 eventV2)
    {
        HintManiaEventHandler val_7 = this;
        mem[1152921516464230016] = eventV2;
        this.ParseEventData(eventData:  eventV2.eventData);
        HintManiaEventHandler.HINT_MANIA_ID = val_7;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_7 = ???;
        goto typeof(HintManiaEventHandler).__il2cppRuntimeField_220;
    }
    public override void OnGameSceneBegan()
    {
        if(this.LastEventPopupShown == 469778432)
        {
                return;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HintManiaEventPopup>(showNext:  false).LastEventPopupShown = 931764992;
        CPlayerPrefs.Save();
    }
    public override void OnGameSceneInit()
    {
    
    }
    public override void OnDailyChallengeInit()
    {
    
    }
    public override string GetEventDisplayName()
    {
        return Localization.Localize(key:  "hint_mania_upper", defaultValue:  "HINT MANIA", useSingularKey:  false);
    }
    public override string GetGameButtonText()
    {
        return Localization.Localize(key:  "hint_mania_upper", defaultValue:  "HINT MANIA", useSingularKey:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return Localization.Localize(key:  "hint_mania_upper", defaultValue:  "HINT MANIA", useSingularKey:  false);
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HintManiaEventPopup>(showNext:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<HintManiaEventPopup>(showNext:  false);
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return true;
    }
    public override bool EventCompleted()
    {
        bool val_1 = this.IsEventValid;
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public override bool get_IsEventHidden()
    {
        bool val_1 = this.IsEventValid;
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    public override void OnAnyHintUsed(bool free)
    {
        if(free != false)
        {
                return;
        }
        
        this.RollForReward();
    }
    public override int LastProgressTimestamp()
    {
        return HintManiaEventHandler.LastProgressTimestampPref;
    }
    public override void UpdateProgress()
    {
        HintManiaEventHandler.LastProgressTimestampPref = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override bool IsRewardReadyToCollect()
    {
        return (bool)(this._currentRewardType != 0) ? 1 : 0;
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        EventListItemContentHintMania val_1 = loader.LoadStrictlyTypeNamedPrefab<EventListItemContentHintMania>(allowMultiple:  false);
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "hm_events", defaultValue:  "Every Hint has a {0}% chance of granting a reward!", useSingularKey:  false), arg0:  this._hintRewardOdds);
    }
    private void ParseEventData(System.Collections.Generic.Dictionary<string, object> eventData)
    {
        var val_50;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_50 = eventData;
        if(val_50 == null)
        {
                return;
        }
        
        if(val_50.Count == 0)
        {
                return;
        }
        
        val_50 = "economy";
        if((val_50.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_3 = val_50.Item["economy"];
        if(val_3 == null)
        {
                return;
        }
        
        val_50 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
    }
    private void CheckDisplayRewardAvailable()
    {
    
    }
    private void RollForReward()
    {
        UnityEngine.Object val_25 = this;
        if((UnityEngine.Random.Range(min:  0, max:  100)) > this._hintRewardOdds)
        {
                return;
        }
        
        RandomSet val_2 = new RandomSet();
        if((this.rewardProbabilities.ContainsKey(key:  "coins")) != false)
        {
                val_2.add(item:  1, weight:  (float)System.Int32.Parse(s:  this.rewardProbabilities.Item["coins"]));
        }
        
        if((this.rewardProbabilities.ContainsKey(key:  "golden")) != false)
        {
                val_2.add(item:  2, weight:  (float)System.Int32.Parse(s:  this.rewardProbabilities.Item["golden"]));
        }
        
        if((this.rewardProbabilities.ContainsKey(key:  "bonus_spin")) != false)
        {
                val_2.add(item:  4, weight:  (float)System.Int32.Parse(s:  this.rewardProbabilities.Item["bonus_spin"]));
        }
        
        if((this.rewardProbabilities.ContainsKey(key:  "bonus_wheel")) != false)
        {
                val_2.add(item:  3, weight:  (float)System.Int32.Parse(s:  this.rewardProbabilities.Item["bonus_wheel"]));
        }
        
        this._currentRewardType = val_2.roll(unweighted:  false);
        val_25 = MonoSingleton<HintFeatureManager>.Instance;
        if(val_25 == 0)
        {
                return;
        }
        
        HintFeatureManager val_18 = MonoSingleton<HintFeatureManager>.Instance;
        val_25 = val_18.<wgHbutton>k__BackingField;
        if(val_25 == 0)
        {
                return;
        }
        
        HintFeatureManager val_20 = MonoSingleton<HintFeatureManager>.Instance;
        val_25 = val_20.<wgHbutton>k__BackingField.GetComponent<HintManiaGameplayButton>();
        if(val_25 == 0)
        {
                return;
        }
        
        HintFeatureManager val_23 = MonoSingleton<HintFeatureManager>.Instance;
        val_23.<wgHbutton>k__BackingField.GetComponent<HintManiaGameplayButton>().CheckShowButton();
    }
    public void CollectReward()
    {
        UnityEngine.Object val_19;
        if(this._currentRewardType <= 4)
        {
                var val_19 = 32498248 + (this._currentRewardType) << 2;
            val_19 = val_19 + 32498248;
        }
        else
        {
                this._currentRewardType = 0;
            this.SaveCurrentReward();
            val_19 = MonoSingleton<HintFeatureManager>.Instance;
            if(val_19 == 0)
        {
                return;
        }
        
            HintFeatureManager val_12 = MonoSingleton<HintFeatureManager>.Instance;
            val_19 = val_12.<wgHbutton>k__BackingField;
            if(val_19 == 0)
        {
                return;
        }
        
            HintFeatureManager val_14 = MonoSingleton<HintFeatureManager>.Instance;
            val_19 = val_14.<wgHbutton>k__BackingField.GetComponent<HintManiaGameplayButton>();
            if(val_19 == 0)
        {
                return;
        }
        
            HintFeatureManager val_17 = MonoSingleton<HintFeatureManager>.Instance;
            val_17.<wgHbutton>k__BackingField.GetComponent<HintManiaGameplayButton>().CheckShowButton();
        }
    
    }
    public int GetRewardValue(GameEventRewardType rewardType)
    {
        var val_6;
        int val_2 = 0;
        if(rewardType != 2)
        {
                val_6 = 0;
            if(rewardType != 1)
        {
                return 250;
        }
        
            bool val_3 = System.Int32.TryParse(s:  this.rewardValues.Item["coins"], result: out  val_2);
            val_6 = val_2;
            if(val_6 != 0)
        {
                return 250;
        }
        
            val_6 = 50;
            return 250;
        }
        
        bool val_5 = System.Int32.TryParse(s:  this.rewardValues.Item["golden"], result: out  val_2);
        val_6 = val_2;
        if(val_6 != 0)
        {
                return 250;
        }
        
        val_6 = 250;
        return 250;
    }
    private void SaveCurrentReward()
    {
        CPlayerPrefs.SetInt(key:  "hintManiaReward", val:  this._currentRewardType);
        CPlayerPrefs.Save();
    }
    public HintManiaEventHandler()
    {
        this._hintRewardOdds = 4;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "coins", value:  35);
        val_1.Add(key:  "golden", value:  35);
        val_1.Add(key:  "bonus_wheel", value:  15);
        val_1.Add(key:  "bonus_spin", value:  15);
        this.rewardProbabilities = val_1;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "coins", value:  50);
        val_2.Add(key:  "golden", value:  250);
        val_2.Add(key:  "bonus_wheel", value:  1);
        val_2.Add(key:  "bonus_spin", value:  1);
        this.rewardValues = val_2;
    }

}

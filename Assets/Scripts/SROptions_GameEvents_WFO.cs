using UnityEngine;
public class SROptions_GameEvents_WFO : SuperLuckySROptionsParent<SROptions_GameEvents_WFO>, INotifyPropertyChanged
{
    // Fields
    private WGEventHandler activeEvent;
    private System.TimeSpan eventSpan;
    private float calcTime;
    private string lastCachedInfo;
    
    // Properties
    public string CurrentEventType { get; }
    public string CurrentSingleEvent { get; }
    public string Level { get; }
    public string AtkMadnessCurrentRewData { get; }
    public string AtkMadnessRewardsCollected { get; }
    public string AtkMadnessPtsCollected { get; }
    public string RaidMadnessCurrentRewData { get; }
    public string RaidMadnessRewardsCollected { get; }
    public string RaidMadnessPtsCollected { get; }
    public string IslandParadiseSymbolsRewardsCollected { get; }
    public string IslandParadiseSymbolsPtsCollected { get; }
    private string EventExpireCountdown { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public string get_CurrentEventType()
    {
        WGEventHandler val_2 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  0);
        if(val_2 == null)
        {
                return "none";
        }
        
        return val_2.EventType;
    }
    public string get_CurrentSingleEvent()
    {
        return MonoSingleton<WordGameEventsController>.Instance.QAHACK_CurrentSingleEventTypeKey;
    }
    public void ToggleHackedSingleEvent()
    {
        MonoSingleton<WordGameEventsController>.Instance.QAHACK_ToggleSingleEvent();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "CurrentSingleEvent");
    }
    public void CurrentEventInfoHud()
    {
        var val_4;
        System.Func<System.String> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = SROptions_GameEvents_WFO.<>c.<>9__7_0;
        if(val_6 == null)
        {
                System.Func<System.String> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<System.String>(object:  SROptions_GameEvents_WFO.<>c.__il2cppRuntimeField_static_fields, method:  System.String SROptions_GameEvents_WFO.<>c::<CurrentEventInfoHud>b__7_0());
            SROptions_GameEvents_WFO.<>c.<>9__7_0 = val_6;
        }
        
        SLCHUDWindow.SetupHUD(name:  "Current Events HUD", callbackfunc:  val_1);
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_Level()
    {
        return MonoSingleton<WordGameEventsController>.Instance.DebugGetLevel();
    }
    public void PlayerLevelUp1()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  1);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelUp10()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  5);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelUp100()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  100);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown1()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  0);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown10()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  -5);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public void PlayerLevelDown100()
    {
        MonoSingleton<WordGameEventsController>.Instance.HackAddLevels(levelsHacked:  99);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "Level");
    }
    public string get_AtkMadnessCurrentRewData()
    {
        var val_3;
        var val_4;
        if(((AttackMadnessEventHandler.<Instance>k__BackingField) != null) && ((AttackMadnessEventHandler.<Instance>k__BackingField) != null))
        {
                val_3 = AttackMadnessEventHandler.<Instance>k__BackingField;
            AttackMadnessEventHandler.<Instance>k__BackingField.__unknownFiledOffset_10 = AttackMadnessEventHandler.<Instance>k__BackingField + 24;
            string val_2 = System.String.Format(format:  "<color=#ffef00>{0} {1} - Pts Req: {2}</color>", arg0:  AttackMadnessEventHandler.<Instance>k__BackingField + 24, arg1:  AttackMadnessEventHandler.<Instance>k__BackingField + 24.ToString(), arg2:  AttackMadnessEventHandler.<Instance>k__BackingField + 20);
            return (string)val_4;
        }
        
        val_4 = "-";
        return (string)val_4;
    }
    public string get_AtkMadnessRewardsCollected()
    {
        var val_4;
        if((AttackMadnessEventHandler.<Instance>k__BackingField) != null)
        {
                string val_3 = "<color=#00ff00>"("<color=#00ff00>") + AttackMadnessEventHandler.<Instance>k__BackingField.ProgressLevel.ToString()(AttackMadnessEventHandler.<Instance>k__BackingField.ProgressLevel.ToString()) + "</color>"("</color>");
            return (string)val_4;
        }
        
        val_4 = "0";
        return (string)val_4;
    }
    private void ModifyAttackMadnessEventLevel(int val, bool isAbsoluteValue = False)
    {
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(isAbsoluteValue != false)
        {
                typeof(AttackMadnessProgress).__il2cppRuntimeField_1C = val;
        }
        else
        {
                typeof(AttackMadnessProgress).__il2cppRuntimeField_1C = UnityEngine.Mathf.Max(a:  0, b:  (val + val)>>0&0xFFFFFFFF);
        }
        
        typeof(AttackMadnessProgress).__il2cppRuntimeField_28 = 0;
        AttackMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessCurrentRewData");
    }
    public void AttackMadnessRewardsCollectUp1()
    {
        this.ModifyAttackMadnessEventLevel(val:  1, isAbsoluteValue:  false);
    }
    public void AttackMadnessRewardsCollectUp10()
    {
        this.ModifyAttackMadnessEventLevel(val:  10, isAbsoluteValue:  false);
    }
    public void AttackMadnessRewardsCollectDown1()
    {
        this.ModifyAttackMadnessEventLevel(val:  0, isAbsoluteValue:  false);
    }
    public void AttackMadnessRewardsCollectDown10()
    {
        this.ModifyAttackMadnessEventLevel(val:  9, isAbsoluteValue:  false);
    }
    public string get_AtkMadnessPtsCollected()
    {
        var val_3;
        if((AttackMadnessEventHandler.<Instance>k__BackingField) != null)
        {
                string val_2 = "<color=#00ff00>"("<color=#00ff00>") + AttackMadnessEventHandler.<Instance>k__BackingField.ToString()(AttackMadnessEventHandler.<Instance>k__BackingField.ToString()) + "</color>"("</color>");
            return (string)val_3;
        }
        
        val_3 = "0";
        return (string)val_3;
    }
    private void ModifyAttackMadnessPointsCollected(int val, bool isAbsoluteValue = False)
    {
        bool val_3 = isAbsoluteValue;
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(val_3 != false)
        {
            
        }
        else
        {
                val_3 = AttackMadnessEventHandler.<Instance>k__BackingField;
            int val_2 = UnityEngine.Mathf.Max(a:  0, b:  val_3 + val);
        }
        
        AttackMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessCurrentRewData");
    }
    public void AtkMadnessPtsCollectUp1()
    {
        this.ModifyAttackMadnessPointsCollected(val:  1, isAbsoluteValue:  false);
    }
    public void AtkMadnessPtsCollectUp10()
    {
        this.ModifyAttackMadnessPointsCollected(val:  10, isAbsoluteValue:  false);
    }
    public void AtkMadnessPtsCollectUp100()
    {
        this.ModifyAttackMadnessPointsCollected(val:  100, isAbsoluteValue:  false);
    }
    public void AtkMadnessPtsCollectDown1()
    {
        this.ModifyAttackMadnessPointsCollected(val:  0, isAbsoluteValue:  false);
    }
    public void AtkMadnessPtsCollectDown10()
    {
        this.ModifyAttackMadnessPointsCollected(val:  9, isAbsoluteValue:  false);
    }
    public void AtkMadnessPtsCollectDown100()
    {
        this.ModifyAttackMadnessPointsCollected(val:  99, isAbsoluteValue:  false);
    }
    public void SkipToAlmostCurrentRewardPtsReq()
    {
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        AttackMadnessEventHandler.<Instance>k__BackingField.ModifyAttackMadnessPointsCollected(val:  (AttackMadnessEventHandler.<Instance>k__BackingField + 20) - 1, isAbsoluteValue:  true);
    }
    public void SkipToAlmostFinalRewardPtsReq()
    {
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        RESEventRewardData val_1 = AttackMadnessEventHandler.<Instance>k__BackingField.GetFinalPrize();
        int val_5 = AttackMadnessEventHandler.<Instance>k__BackingField.PlayerTier;
        int val_3 = GetTotalCollectableRewards(playerTier:  val_5);
        val_5 = val_3 - 1;
        val_3.ModifyAttackMadnessEventLevel(val:  val_5, isAbsoluteValue:  true);
        val_3.ModifyAttackMadnessPointsCollected(val:  val_1.pointsReq - 1, isAbsoluteValue:  true);
    }
    public void ResetAtkMadness()
    {
        if((AttackMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        AttackMadnessEventHandler.<Instance>k__BackingField.ResetEventProgress();
        AttackMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "AtkMadnessCurrentRewData");
    }
    public string get_RaidMadnessCurrentRewData()
    {
        var val_3;
        var val_4;
        if(((RaidMadnessEventHandler.<Instance>k__BackingField) != null) && ((RaidMadnessEventHandler.<Instance>k__BackingField) != null))
        {
                val_3 = RaidMadnessEventHandler.<Instance>k__BackingField;
            RaidMadnessEventHandler.<Instance>k__BackingField.__unknownFiledOffset_10 = RaidMadnessEventHandler.<Instance>k__BackingField + 24;
            string val_2 = System.String.Format(format:  "<color=#ffef00>{0} {1} - Pts Req: {2}</color>", arg0:  RaidMadnessEventHandler.<Instance>k__BackingField + 24, arg1:  RaidMadnessEventHandler.<Instance>k__BackingField + 24.ToString(), arg2:  RaidMadnessEventHandler.<Instance>k__BackingField + 20);
            return (string)val_4;
        }
        
        val_4 = "-";
        return (string)val_4;
    }
    public string get_RaidMadnessRewardsCollected()
    {
        var val_4;
        if((RaidMadnessEventHandler.<Instance>k__BackingField) != null)
        {
                string val_3 = "<color=#00ff00>"("<color=#00ff00>") + RaidMadnessEventHandler.<Instance>k__BackingField.ProgressLevel.ToString()(RaidMadnessEventHandler.<Instance>k__BackingField.ProgressLevel.ToString()) + "</color>"("</color>");
            return (string)val_4;
        }
        
        val_4 = "0";
        return (string)val_4;
    }
    private void ModifyRaidMadnessEventLevel(int val, bool isAbsoluteValue = False)
    {
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(isAbsoluteValue != false)
        {
                typeof(RaidMadnessProgress).__il2cppRuntimeField_1C = val;
        }
        else
        {
                typeof(RaidMadnessProgress).__il2cppRuntimeField_1C = UnityEngine.Mathf.Max(a:  0, b:  (val + val)>>0&0xFFFFFFFF);
        }
        
        typeof(RaidMadnessProgress).__il2cppRuntimeField_28 = 0;
        RaidMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessCurrentRewData");
    }
    public void RaidMadnessRewardsCollectUp1()
    {
        this.ModifyRaidMadnessEventLevel(val:  1, isAbsoluteValue:  false);
    }
    public void RaidMadnessRewardsCollectUp10()
    {
        this.ModifyRaidMadnessEventLevel(val:  10, isAbsoluteValue:  false);
    }
    public void RaidMadnessRewardsCollectDown1()
    {
        this.ModifyRaidMadnessEventLevel(val:  0, isAbsoluteValue:  false);
    }
    public void RaidMadnessRewardsCollectDown10()
    {
        this.ModifyRaidMadnessEventLevel(val:  9, isAbsoluteValue:  false);
    }
    public string get_RaidMadnessPtsCollected()
    {
        var val_3;
        if((RaidMadnessEventHandler.<Instance>k__BackingField) != null)
        {
                string val_2 = "<color=#00ff00>"("<color=#00ff00>") + RaidMadnessEventHandler.<Instance>k__BackingField.ToString()(RaidMadnessEventHandler.<Instance>k__BackingField.ToString()) + "</color>"("</color>");
            return (string)val_3;
        }
        
        val_3 = "0";
        return (string)val_3;
    }
    private void ModifyRaidMadnessPointsCollected(int val, bool isAbsoluteValue = False)
    {
        bool val_3 = isAbsoluteValue;
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        if(val_3 != false)
        {
            
        }
        else
        {
                val_3 = RaidMadnessEventHandler.<Instance>k__BackingField;
            int val_2 = UnityEngine.Mathf.Max(a:  0, b:  val_3 + val);
        }
        
        RaidMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessCurrentRewData");
    }
    public void RaidMadnessPtsCollectUp1()
    {
        this.ModifyRaidMadnessPointsCollected(val:  1, isAbsoluteValue:  false);
    }
    public void RaidMadnessPtsCollectUp10()
    {
        this.ModifyRaidMadnessPointsCollected(val:  10, isAbsoluteValue:  false);
    }
    public void RaidMadnessPtsCollectUp100()
    {
        this.ModifyRaidMadnessPointsCollected(val:  100, isAbsoluteValue:  false);
    }
    public void RaidMadnessPtsCollectDown1()
    {
        this.ModifyRaidMadnessPointsCollected(val:  0, isAbsoluteValue:  false);
    }
    public void RaidMadnessPtsCollectDown10()
    {
        this.ModifyRaidMadnessPointsCollected(val:  9, isAbsoluteValue:  false);
    }
    public void RaidMadnessPtsCollectDown100()
    {
        this.ModifyRaidMadnessPointsCollected(val:  99, isAbsoluteValue:  false);
    }
    public void RaidSkipToAlmostCurrentRewardPtsReq()
    {
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        RaidMadnessEventHandler.<Instance>k__BackingField.ModifyRaidMadnessPointsCollected(val:  (RaidMadnessEventHandler.<Instance>k__BackingField + 20) - 1, isAbsoluteValue:  true);
    }
    public void RaidSkipToAlmostFinalRewardPtsReq()
    {
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        RESEventRewardData val_1 = RaidMadnessEventHandler.<Instance>k__BackingField.GetFinalPrize();
        int val_5 = RaidMadnessEventHandler.<Instance>k__BackingField.PlayerTier;
        int val_3 = GetTotalCollectableRewards(playerTier:  val_5);
        val_5 = val_3 - 1;
        val_3.ModifyRaidMadnessEventLevel(val:  val_5, isAbsoluteValue:  true);
        val_3.ModifyRaidMadnessPointsCollected(val:  val_1.pointsReq - 1, isAbsoluteValue:  true);
    }
    public void ResetRaidMadness()
    {
        if((RaidMadnessEventHandler.<Instance>k__BackingField) == null)
        {
                return;
        }
        
        RaidMadnessEventHandler.<Instance>k__BackingField.ResetEventProgress();
        RaidMadnessEventHandler.<Instance>k__BackingField.UpdateProgressToServer();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessPtsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "RaidMadnessCurrentRewData");
    }
    public string get_IslandParadiseSymbolsRewardsCollected()
    {
        var val_3;
        if(IslandParadiseEventHandler._Instance != null)
        {
                string val_2 = IslandParadiseEventHandler._Instance.ProgressLevel.ToString();
            return (string)val_3;
        }
        
        val_3 = "0";
        return (string)val_3;
    }
    public void IslandParadiseSymbolsRewardsCollectUp1()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackProgressLevel(progress:  IslandParadiseEventHandler._Instance.ProgressLevel + 1);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsRewardsCollected");
    }
    public void IslandParadiseSymbolsRewardsCollectUp10()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackProgressLevel(progress:  IslandParadiseEventHandler._Instance.ProgressLevel + 10);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsRewardsCollected");
    }
    public void IslandParadiseSymbolsRewardsCollectDown1()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackProgressLevel(progress:  IslandParadiseEventHandler._Instance.ProgressLevel - 1);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsRewardsCollected");
    }
    public void IslandParadiseSymbolsRewardsCollectDown10()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackProgressLevel(progress:  IslandParadiseEventHandler._Instance.ProgressLevel - 10);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsRewardsCollected");
    }
    public string get_IslandParadiseSymbolsPtsCollected()
    {
        var val_2;
        if(IslandParadiseEventHandler._Instance != null)
        {
                string val_1 = IslandParadiseEventHandler._Instance.ToString();
            return (string)val_2;
        }
        
        val_2 = "0";
        return (string)val_2;
    }
    public void IslandParadiseSymbolsPtsCollectUp1()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  typeof(IslandParadiseEventHandler).__il2cppRuntimeField_748>>0&0xFFFFFFFF);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void IslandParadiseSymbolsPtsCollectUp10()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  typeof(IslandParadiseEventHandler).__il2cppRuntimeField_748>>0&0xFFFFFFFF);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void IslandParadiseSymbolsPtsCollectUp100()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  typeof(IslandParadiseEventHandler).__il2cppRuntimeField_748>>0&0xFFFFFFFF);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void IslandParadiseSymbolsPtsCollectDown1()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  IslandParadiseEventHandler._Instance - 1);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void IslandParadiseSymbolsPtsCollectDown10()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  IslandParadiseEventHandler._Instance - 10);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void IslandParadiseSymbolsPtsCollectDown100()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.HackPointsCollected(points:  IslandParadiseEventHandler._Instance - 100);
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void ResetIslandParadiseSymbols()
    {
        if(IslandParadiseEventHandler._Instance == null)
        {
                return;
        }
        
        IslandParadiseEventHandler._Instance.ResetEventProgress();
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsRewardsCollected");
        SROptions_GameEvents_WFO.NotifyPropertyChanged(propertyName:  "IslandParadiseSymbolsPtsCollected");
    }
    public void SetWordHuntWords()
    {
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                return;
        }
        
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.SetRequiredWordsAsCurrentExtraWords();
    }
    public void CollectWordHuntWord()
    {
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                return;
        }
        
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.HackCollectSmallestWord();
    }
    private string get_EventExpireCountdown()
    {
        object val_15;
        var val_16;
        val_15 = this;
        WGEventHandler val_2 = MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlersByIndex(index:  0);
        this.activeEvent = val_2;
        if(val_2 != null)
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2}, d2:  new System.DateTime() {dateData = val_3.dateData});
            this.eventSpan = val_4;
            object[] val_5 = new object[4];
            val_5[0] = this.eventSpan.Days.ToString();
            val_5[1] = this.eventSpan.Hours.ToString();
            val_5[2] = this.eventSpan.Minutes.ToString();
            val_15 = this.eventSpan.Seconds.ToString();
            val_5[3] = val_15;
            string val_14 = System.String.Format(format:  "{00}d:{01}h:{02}m:{03}s", args:  val_5);
            return (string)val_16;
        }
        
        val_16 = "n/a";
        return (string)val_16;
    }
    public string GetCurrentEventInfo()
    {
        object val_10;
        string val_11;
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.calcTime + val_1;
        this.calcTime = val_1;
        if(val_1 < 0)
        {
                if((System.String.IsNullOrEmpty(value:  this.lastCachedInfo)) == false)
        {
            goto label_2;
        }
        
        }
        
        this.lastCachedInfo = "";
        System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_6 = val_3.Append(value:  System.String.Format(format:  "<color=#20FD3B>Expire Countdown: {0}</color>\n", arg0:  this.EventExpireCountdown));
        if(this.activeEvent != null)
        {
                val_10 = this.activeEvent.EventType;
        }
        else
        {
                val_10 = "null";
        }
        
        System.Text.StringBuilder val_9 = val_3.Append(value:  System.String.Format(format:  "Event Info: {0}", arg0:  val_10));
        val_11 = val_3;
        this.lastCachedInfo = val_11;
        this.calcTime = 0f;
        return val_11;
        label_2:
        val_11 = this.lastCachedInfo;
        return val_11;
    }
    public SROptions_GameEvents_WFO()
    {
        this.lastCachedInfo = "";
    }

}

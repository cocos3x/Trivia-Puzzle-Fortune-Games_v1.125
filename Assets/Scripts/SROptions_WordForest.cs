using UnityEngine;
public class SROptions_WordForest : SuperLuckySROptionsParent<SROptions_WordForest>, INotifyPropertyChanged
{
    // Properties
    public string ChestHackStatus { get; }
    public bool PlayChallengeWords { get; set; }
    public int ChestForceIslandParadise { get; set; }
    public bool EnableChestFtux { get; set; }
    public int ForestLevel { get; set; }
    public bool Show { get; set; }
    public string ShowRaidPoolIds { get; }
    public string ShowAttackPoolIds { get; }
    
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
    public void CopyErrors()
    {
        var val_6;
        string val_7;
        val_6 = null;
        val_7 = "";
        val_6 = null;
        System.Collections.Generic.IEnumerator<T> val_1 = UnityLoggerListener._allConsoleEntries.GetEnumerator();
        label_14:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        string val_6 = val_7 + val_1.Current;
        goto label_14;
        label_9:
        val_7 = 0;
        if(val_1 != null)
        {
                var val_10 = 0;
            val_10 = val_10 + 1;
            val_1.Dispose();
        }
        
        if(val_7 != 0)
        {
                throw val_7;
        }
        
        ClipboardHelper.clipBoard = val_7;
    }
    public void ShareErrors()
    {
        var val_6;
        string val_7;
        val_6 = null;
        val_7 = "";
        val_6 = null;
        System.Collections.Generic.IEnumerator<T> val_1 = UnityLoggerListener._allConsoleEntries.GetEnumerator();
        label_14:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_9 = 0;
        val_9 = val_9 + 1;
        string val_6 = val_7 + val_1.Current;
        goto label_14;
        label_9:
        val_7 = 0;
        if(val_1 != null)
        {
                var val_10 = 0;
            val_10 = val_10 + 1;
            val_1.Dispose();
        }
        
        if(val_7 != 0)
        {
                throw val_7;
        }
        
        ClipboardHelper.clipBoard = val_7;
        twelvegigs.plugins.SharePlugin.Share(text:  val_7, url:  "", subject:  "Latest Error Logs", emailBody:  val_7, imgPath:  0);
    }
    public void General()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_General>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void PlayerCheats()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Player>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DateTime()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DateTime>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Store()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Store>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void Ads()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Ads>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void GameOfTheDayMenu()
    {
        var val_8;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                var val_7 = 0;
            val_7 = val_7 + 1;
        }
        else
        {
                DebugMessageDisplay.DisplayMessage(msgTxt:  "Does not support game of the day.", displayTime:  3f);
            return;
        }
        
        val_8 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_GameOfTheDay>.Instance);
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void GenericUIs()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_UIs>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void DailyChallenge()
    {
        var val_8;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                var val_7 = 0;
            val_7 = val_7 + 1;
        }
        else
        {
                DebugMessageDisplay.DisplayMessage(msgTxt:  "Daily Challenge Not Yet Supported", displayTime:  3f);
            return;
        }
        
        val_8 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DailyChallenge>.Instance);
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowEventHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_GameEvents_WFO>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void RestartLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_1B0;
    }
    public void GrantExtraWord()
    {
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion val_3 = WordRegion.instance;
        goto typeof(WordRegion).__il2cppRuntimeField_260;
    }
    public void CompleteLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_190;
    }
    public void ExtraReqWordsHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Extra Required Words HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetWordsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void CompleteChapter()
    {
        UnityEngine.Object val_8 = WordRegion.instance;
        if(val_8 == 0)
        {
                return;
        }
        
        val_8 = MainController.instance;
        if(val_8 == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_1A0;
    }
    public void LevelsSkipped()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Levels Skipped", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetLevelsSkippedInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void DisplayLevelInfo()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetGameLevelInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_ChestHackStatus()
    {
        return MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.Hack_ChestRewardHackStatus();
    }
    public void MysteryChestUnlockInstantly()
    {
        MonoSingleton<WordForest.WFOMysteryChestUI>.Instance.Hack_CollectMysteryChest();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public bool get_PlayChallengeWords()
    {
        WGChallengeWordsManager val_1 = MonoSingleton<WGChallengeWordsManager>.Instance;
        return (bool)val_1.<QAHACK_forceThisLevel>k__BackingField;
    }
    public void set_PlayChallengeWords(bool value)
    {
        WGChallengeWordsManager val_1 = MonoSingleton<WGChallengeWordsManager>.Instance;
        val_1.<QAHACK_forceThisLevel>k__BackingField = value;
    }
    public void ChestForceRewardClear()
    {
        MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.Hack_ClearForcedReward();
        SROptions_WordForest.NotifyPropertyChanged(propertyName:  "ChestHackStatus");
    }
    public void ChestForceRewardRaid()
    {
        MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.Hack_ForceRewardRaid();
        SROptions_WordForest.NotifyPropertyChanged(propertyName:  "ChestHackStatus");
    }
    public void ChestForceRewardAttack()
    {
        MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.Hack_ForceRewardAttack();
        SROptions_WordForest.NotifyPropertyChanged(propertyName:  "ChestHackStatus");
    }
    public int get_ChestForceIslandParadise()
    {
        WordForest.WFOMysteryChestManager val_1 = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance;
        return (int)val_1.hack_islandParadiseSymbolCount;
    }
    public void set_ChestForceIslandParadise(int value)
    {
        MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.Hack_ForceIslandParadiseSymbolCount(value:  value);
        SROptions_WordForest.NotifyPropertyChanged(propertyName:  "ChestHackStatus");
    }
    public bool get_EnableChestFtux()
    {
        var val_8;
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        if((MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  9)) != false)
        {
                WordForest.WFOPlayer val_3 = WordForest.WFOPlayer.Instance;
            if((MonoExtensions.IsBitSet(value:  val_3.tutorialCompleted, bit:  10)) != false)
        {
                WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
            val_8 = (MonoExtensions.IsBitSet(value:  val_5.tutorialCompleted, bit:  8)) ^ 1;
            return (bool)val_8 & 1;
        }
        
        }
        
        val_8 = 1;
        return (bool)val_8 & 1;
    }
    public void set_EnableChestFtux(bool value)
    {
        var val_17;
        int val_18;
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
        if(value == false)
        {
            goto label_1;
        }
        
        val_1.tutorialCompleted = MonoExtensions.UnsetBit(value:  val_2.tutorialCompleted, bit:  9);
        WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
        WordForest.WFOPlayer val_5 = WordForest.WFOPlayer.Instance;
        val_4.tutorialCompleted = MonoExtensions.UnsetBit(value:  val_5.tutorialCompleted, bit:  10);
        val_17 = WordForest.WFOPlayer.Instance;
        WordForest.WFOPlayer val_8 = WordForest.WFOPlayer.Instance;
        val_18 = val_8.tutorialCompleted;
        int val_9 = MonoExtensions.UnsetBit(value:  val_18, bit:  8);
        if(val_17 != null)
        {
            goto label_6;
        }
        
        label_1:
        val_1.tutorialCompleted = MonoExtensions.SetBit(value:  val_2.tutorialCompleted, bit:  9);
        WordForest.WFOPlayer val_11 = WordForest.WFOPlayer.Instance;
        WordForest.WFOPlayer val_12 = WordForest.WFOPlayer.Instance;
        val_11.tutorialCompleted = MonoExtensions.SetBit(value:  val_12.tutorialCompleted, bit:  10);
        val_17 = WordForest.WFOPlayer.Instance;
        WordForest.WFOPlayer val_15 = WordForest.WFOPlayer.Instance;
        val_18 = val_15.tutorialCompleted;
        label_6:
        val_14.tutorialCompleted = MonoExtensions.SetBit(value:  val_18, bit:  8);
    }
    public void ResetShields()
    {
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        val_1.shields = 0;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnShieldBalanceUpdated");
    }
    public int get_ForestLevel()
    {
        return MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentForestLevel;
    }
    public void set_ForestLevel(int value)
    {
        MonoSingleton<WordForest.WFOForestManager>.Instance.Hack_SetForestLevel(level:  value);
    }
    public bool get_Show()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "isDebugBannerShown", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public void set_Show(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "isDebugBannerShown", value:  value);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ToggleDebugBanner");
    }
    public string get_ShowRaidPoolIds()
    {
        WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        return val_1.dataController.QA_RaidPoolIds;
    }
    public string get_ShowAttackPoolIds()
    {
        WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        return val_1.dataController.QA_AttackPoolIds;
    }
    public void ShowMyselfHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Myself HUD", callbackfunc:  new System.Func<System.String>(object:  this, method:  System.String SROptions_WordForest::GetRaidAttackHud()));
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    private string GetRaidAttackHud()
    {
        int val_64;
        int val_65;
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        WordForest.RaidAttackManager val_2 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
        System.Text.StringBuilder val_5 = val_3.AppendLine(value:  "Server Forest Id: "("Server Forest Id: ") + val_1.forestServerId);
        System.Text.StringBuilder val_7 = val_3.AppendLine(value:  "Forest Profile Name: "("Forest Profile Name: ") + val_2.dataController.<QA_myself>k__BackingField.name(val_2.dataController.<QA_myself>k__BackingField.name));
        System.Text.StringBuilder val_10 = val_3.AppendLine(value:  "Acorns: "("Acorns: ") + val_1.acorns);
        System.Text.StringBuilder val_12 = val_3.AppendLine(value:  "Raids Sent: "("Raids Sent: ") + val_2.dataController.<QA_myself>k__BackingField.raidsSent(val_2.dataController.<QA_myself>k__BackingField.raidsSent));
        System.Text.StringBuilder val_14 = val_3.AppendLine(value:  "Raids Received: "("Raids Received: ") + val_2.dataController.<QA_myself>k__BackingField.raidsReceived(val_2.dataController.<QA_myself>k__BackingField.raidsReceived));
        System.Text.StringBuilder val_16 = val_3.AppendLine(value:  "Attacks Sent: "("Attacks Sent: ") + val_2.dataController.<QA_myself>k__BackingField.attacksSent(val_2.dataController.<QA_myself>k__BackingField.attacksSent));
        System.Text.StringBuilder val_18 = val_3.AppendLine(value:  "Attacks Received: "("Attacks Received: ") + val_2.dataController.<QA_myself>k__BackingField.attacksReceived(val_2.dataController.<QA_myself>k__BackingField.attacksReceived));
        System.Text.StringBuilder val_19 = val_3.AppendLine();
        WordForest.RaidAttackManager val_20 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        System.Text.StringBuilder val_22 = val_3.AppendLine(value:  "Acorns Lost Offline: "("Acorns Lost Offline: ") + val_20.serverController.<acornsLostBetweenSessions>k__BackingField(val_20.serverController.<acornsLostBetweenSessions>k__BackingField));
        WordForest.RaidAttackManager val_23 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        System.Text.StringBuilder val_25 = val_3.AppendLine(value:  "Shields Lost Offline: "("Shields Lost Offline: ") + val_23.serverController.<shieldsLostBetweenSessions>k__BackingField(val_23.serverController.<shieldsLostBetweenSessions>k__BackingField));
        System.Text.StringBuilder val_26 = val_3.AppendLine();
        UnityEngine.Vector2Int val_27 = WordForest.WFOGameEconHelper.GetRaidEligibleAcornsMinMax(forestLevel:  val_1.currentForestID);
        int val_28 = val_27.m_X.x;
        System.Text.StringBuilder val_29 = val_3.AppendLine(value:  "<b>Can be Raided?</b>");
        System.Text.StringBuilder val_33 = val_3.AppendLine(value:  "Has raided others: "("Has raided others: ") + ((val_2.dataController.<QA_myself>k__BackingField.raidsSent) > 0) ? 1 : 0.ToString()(((val_2.dataController.<QA_myself>k__BackingField.raidsSent) > 0) ? 1 : 0.ToString()));
        object[] val_34 = new object[5];
        val_34[0] = "Min acorns attained: ";
        val_64 = val_34.Length;
        val_34[1] = (val_1.acorns > val_28) ? 1 : 0.ToString();
        val_64 = val_34.Length;
        val_34[2] = " (Required: ";
        val_65 = val_34.Length;
        val_34[3] = val_28;
        val_65 = val_34.Length;
        val_34[4] = ")";
        System.Text.StringBuilder val_39 = val_3.AppendLine(value:  +val_34);
        WordForest.WFOPlayer val_40 = WordForest.WFOPlayer.Instance;
        System.Text.StringBuilder val_45 = val_3.AppendLine(value:  "Has completed raid ftux: "("Has completed raid ftux: ") + MonoExtensions.IsBitSet(value:  val_40.tutorialCompleted, bit:  9).ToString()(MonoExtensions.IsBitSet(value:  val_40.tutorialCompleted, bit:  9).ToString()));
        System.Text.StringBuilder val_46 = val_3.AppendLine();
        System.Text.StringBuilder val_47 = val_3.AppendLine(value:  "<b>Can be Attacked?</b>");
        System.Text.StringBuilder val_51 = val_3.AppendLine(value:  "Has attacked others: "("Has attacked others: ") + ((val_2.dataController.<QA_myself>k__BackingField.attacksSent) > 0) ? 1 : 0.ToString()(((val_2.dataController.<QA_myself>k__BackingField.attacksSent) > 0) ? 1 : 0.ToString()));
        WordForest.WFOPlayer val_52 = WordForest.WFOPlayer.Instance;
        System.Text.StringBuilder val_57 = val_3.AppendLine(value:  "Has completed attack ftux: "("Has completed attack ftux: ") + MonoExtensions.IsBitSet(value:  val_52.tutorialCompleted, bit:  10).ToString()(MonoExtensions.IsBitSet(value:  val_52.tutorialCompleted, bit:  10).ToString()));
        WordForest.WFOPlayer val_58 = WordForest.WFOPlayer.Instance;
        System.Text.StringBuilder val_63 = val_3.AppendLine(value:  "Has completed blocked ftux: "("Has completed blocked ftux: ") + MonoExtensions.IsBitSet(value:  val_58.tutorialCompleted, bit:  11).ToString()(MonoExtensions.IsBitSet(value:  val_58.tutorialCompleted, bit:  11).ToString()));
        return (string)val_3;
    }
    public void ShowServerLogTraceHUD()
    {
        WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        SLCHUDWindow.SetupHUD(name:  "Log HUD", callbackfunc:  new System.Func<System.String>(object:  val_1.serverController, method:  public System.String WordForest.RaidAttackServerController::GetServerLogs()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_WordForest()
    {
    
    }

}

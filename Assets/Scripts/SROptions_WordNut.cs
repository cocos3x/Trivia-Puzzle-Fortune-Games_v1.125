using UnityEngine;
public class SROptions_WordNut : SuperLuckySROptionsParent<SROptions_WordNut>, INotifyPropertyChanged
{
    // Properties
    public bool ToggleTapToRevealSpace { get; set; }
    public bool Show { get; set; }
    
    // Methods
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
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_GameEvents>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowFriendInviter()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_FriendInviter>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
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
    public void CompleteChapter()
    {
        if(MainController.instance == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        GameBehavior val_5 = App.getBehavior;
        goto typeof(HackBehavior).__il2cppRuntimeField_1A0;
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
    public void DisplayLevelTracking()
    {
        var val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Tracking", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetGameLevelTrackingInfo()));
        var val_6 = 0;
        val_6 = val_6 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ExtraReqWordsHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Extra Required Words HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetWordsInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void PrizeBalloon()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_PrizeBalloon>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void InfinityModeInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Infinity Mode HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetInfinityModeInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public bool get_ToggleTapToRevealSpace()
    {
        null = null;
        return (bool)WordRegion.hackTapToReveal;
    }
    public void set_ToggleTapToRevealSpace(bool value)
    {
        null = null;
        WordRegion.hackTapToReveal = value;
    }
    public void None()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 0;
    }
    public void Attack()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 1;
    }
    public void AttackSuccess()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 2;
    }
    public void AttackFailed()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 3;
    }
    public void Raid()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 4;
    }
    public void Shield()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 5;
    }
    public void Spins()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 6;
    }
    public void Bag3()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 7;
    }
    public void Bag2()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 8;
    }
    public void Bag1()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 9;
    }
    public void Coin3()
    {
        null = null;
        SpinKingSlotMachine.hackSpinType = 10;
    }
    public void LeaguesHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Leagues>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ToggleAlphabetHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Alphabet>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void SkipDailyChallengeTutorial()
    {
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<DailyChallengeTutorialManager>.Instance.QAHACK_SKIPTUTORIAL();
    }
    public void ShowWordIQ()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_WordIQ>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowTheLibraryHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_TheLibrary>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowWADPetsHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_WADPets>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowTournamentsHacks()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_Tournaments>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void ShowLeaderBoardData()
    {
        var val_8;
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<WGLeaderboardManager>.Instance)) == false)
        {
                return;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<WGLeaderboardManager>.Instance, method:  public System.String WGLeaderboardManager::QAHack_GetLeaderboardDataHUD()));
        var val_8 = 0;
        val_8 = val_8 + 1;
        SRDebug.Instance.HideDebugPanel();
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
    public SROptions_WordNut()
    {
    
    }

}

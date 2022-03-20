using UnityEngine;
public class SROptions_BestBlocks : SuperLuckySROptionsParent<SROptions_BestBlocks>, INotifyPropertyChanged
{
    // Properties
    public bool EasyMode { get; set; }
    public string LifeTimer { get; }
    public int Lives { get; set; }
    public bool Show { get; set; }
    
    // Methods
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
    public void DailyBonus()
    {
        var val_7;
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_7 = public System.Void SRDebugger.Services.IDebugService::AddOptionContainer(object container);
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SROptions_DailyBonus>.Instance);
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_7 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
    }
    public void CompleteLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void CompleteChapter()
    {
        GameBehavior val_1 = App.getBehavior;
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void RestartLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void FailLevel()
    {
        object val_10;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
            goto label_5;
        }
        
        if(((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CurrentGameMode) != 2) || (BestBlocksPlayer.Instance.IsFTUXGameLevels() == false))
        {
            goto label_11;
        }
        
        val_10 = "Hack usable only after completing FTUX levels.";
        goto label_14;
        label_5:
        val_10 = "Option works only in-game.";
        label_14:
        UnityEngine.Debug.Log(message:  val_10);
        return;
        label_11:
        WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<BBLGameOverScreen>(showNext:  false);
        var val_10 = 0;
        val_10 = val_10 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void GoNextLevelQuick()
    {
        MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.HackQuickGoNextLevel();
    }
    public bool get_EasyMode()
    {
        return BlockPuzzleMagic.BestBlocksGameEcon.Instance.IsEasyMode();
    }
    public void set_EasyMode(bool value)
    {
        int val_3;
        if(value == false)
        {
            goto label_6;
        }
        
        BlockPuzzleMagic.BestBlocksGameEcon val_2 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        val_3 = val_2.failedAttemptsBeforeEasyMode;
        if(App.Player != null)
        {
            goto label_13;
        }
        
        label_6:
        val_3 = 0;
        label_13:
        mem2[0] = val_3;
    }
    public string get_LifeTimer()
    {
        var val_9;
        BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
        System.TimeSpan val_2 = System.TimeSpan.FromMinutes(value:  (double)val_1.lifeRechargeTimeMins);
        System.DateTime val_3 = DateTimeCheat.UtcNow;
        BestBlocksPlayer val_4 = BestBlocksPlayer.Instance;
        System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_3.dateData}, d2:  new System.DateTime() {dateData = val_4.lastLifeTopupTime});
        System.TimeSpan val_6 = System.TimeSpan.op_Subtraction(t1:  new System.TimeSpan() {_ticks = val_2._ticks}, t2:  new System.TimeSpan() {_ticks = val_5._ticks});
        if(val_6._ticks.TotalSeconds > 0f)
        {
                string val_8 = GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_6._ticks}, formatted:  true);
            return (string)val_9;
        }
        
        val_9 = "MAX";
        return (string)val_9;
    }
    public int get_Lives()
    {
        BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
        return (int)val_1.livesBalance;
    }
    public void set_Lives(int value)
    {
        BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
        val_1.livesBalance = value;
    }
    public void RefreshAllShapes()
    {
        MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.RegenerateNewShapes();
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
    public void ResetFtuxPowerups()
    {
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  4, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  5, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  6, completed:  false);
    }
    public void ResetFtuxGameplay()
    {
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  1, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  2, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  3, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  13, completed:  false);
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  14, completed:  false);
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
    public SROptions_BestBlocks()
    {
    
    }

}

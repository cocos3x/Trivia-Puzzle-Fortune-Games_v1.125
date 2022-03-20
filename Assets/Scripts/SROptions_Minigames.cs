using UnityEngine;
public class SROptions_Minigames : SuperLuckySROptionsParent<SROptions_Minigames>, INotifyPropertyChanged
{
    // Properties
    public string CheckPoint { get; }
    public string Rank { get; }
    public bool FreeContinues { get; set; }
    public string WordQuizShowAnswer { get; }
    
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
    public void CompleteLevel()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete();
        }
        
        if((MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
    }
    public void FailLevel()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                bool val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
        }
        
        if((MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
    }
    public void RestartLevel()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleGameRestart();
        }
        
        if((MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
    }
    public string get_CheckPoint()
    {
        var val_5;
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            string val_4 = val_3.currentPlayerLevel.ToString();
            return (string)val_5;
        }
        
        val_5 = "0";
        return (string)val_5;
    }
    public void PlayerLevelUp1()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.QAHACK_IncrementCheckpoint();
        }
        
        SROptions_Minigames.NotifyPropertyChanged(propertyName:  "CheckPoint");
    }
    public void PlayerLevelDown1()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.QAHACK_DecrementCheckpoint();
        }
        
        SROptions_Minigames.NotifyPropertyChanged(propertyName:  "CheckPoint");
    }
    public string get_Rank()
    {
        string val_5;
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                SLC.Minigames.MinigameLevelRank val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank;
            val_5 = val_4.rankName;
            return (string)val_5;
        }
        
        val_5 = "0";
        return (string)val_5;
    }
    public void PlayerRankUp1()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.QAHACK_IncrementRank();
        }
        
        SROptions_Minigames.NotifyPropertyChanged(propertyName:  "Rank");
    }
    public void PlayerRankDown1()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                MonoSingleton<SLC.Minigames.MinigameManager>.Instance.QAHACK_DecrementRank();
        }
        
        SROptions_Minigames.NotifyPropertyChanged(propertyName:  "Rank");
    }
    public bool get_FreeContinues()
    {
        var val_5;
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            var val_4 = (val_3.QAHACK_freeContinues == true) ? 1 : 0;
            return (bool)val_5;
        }
        
        val_5 = 0;
        return (bool)val_5;
    }
    public void set_FreeContinues(bool value)
    {
        SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        bool val_3 = val_2.QAHACK_freeContinues;
        val_3 = val_3 ^ 1;
        val_1.QAHACK_freeContinues = val_3;
        SROptions_Minigames.NotifyPropertyChanged(propertyName:  "FreeContinues");
    }
    public void Pause15Seconds()
    {
        if((MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance.PauseHack();
    }
    public void StopTimer()
    {
        if((MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance.StopTimerHack();
    }
    public void ResumeTimer()
    {
        if((MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.Whack.WhackUIController>.Instance.ResumeTimerHack();
    }
    public void EmojiMatchSlowDownTimer()
    {
        if((MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.PauseHack();
    }
    public void EmojiMatchStopTimer()
    {
        if((MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.StopTimerHack();
    }
    public void EmojiMatchResumeTimer()
    {
        if((MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<SLC.Minigames.EmojiMatch.EmojiMatchController>.Instance.ResumeTimerHack();
    }
    public void WordQuizShowCurrentLevelPool()
    {
        var val_8;
        if((MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance) == 0)
        {
                return;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Pool + Used Levels", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance, method:  public System.String SLC.Minigames.WordQuiz.WordQuizManager::ReturnWordPool()));
        var val_8 = 0;
        val_8 = val_8 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_WordQuizShowAnswer()
    {
        if((MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance) == 0)
        {
                return "";
        }
        
        return MonoSingleton<SLC.Minigames.WordQuiz.WordQuizManager>.Instance.ReturnCurrentAnswer();
    }
    public void WordArrowsDisplayLevelInfo()
    {
        var val_8;
        if((MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance) == 0)
        {
                return;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SLC.Minigames.TwistyArrow.TwistyGameManager>.Instance, method:  public System.String SLC.Minigames.TwistyArrow.TwistyGameManager::CurrentLevelInfo()));
        var val_8 = 0;
        val_8 = val_8 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void Just2EmojisDisplayLevelInfo()
    {
        var val_8;
        if((MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance) == 0)
        {
                return;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Info", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance, method:  public System.String SLC.Minigames.Just2Emojis.Just2EmojisManager::CurrentLevelInfo()));
        var val_8 = 0;
        val_8 = val_8 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void Just2EmojisDisplayLevelPool()
    {
        var val_8;
        if((MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance) == 0)
        {
                return;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        SLCHUDWindow.SetupHUD(name:  System.String.Format(format:  "Current Level Pool + Used Levels", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184), callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SLC.Minigames.Just2Emojis.Just2EmojisManager>.Instance, method:  public System.String SLC.Minigames.Just2Emojis.Just2EmojisManager::ReturnWordPool()));
        var val_8 = 0;
        val_8 = val_8 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public SROptions_Minigames()
    {
    
    }

}

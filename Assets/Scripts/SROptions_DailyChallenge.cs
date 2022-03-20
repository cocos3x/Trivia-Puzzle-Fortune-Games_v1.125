using UnityEngine;
public class SROptions_DailyChallenge : SuperLuckySROptionsParent<SROptions_DailyChallenge>, INotifyPropertyChanged
{
    // Fields
    private int days;
    private int lastPlayedDays;
    
    // Properties
    public string SetStars { get; set; }
    public int Days { get; set; }
    public bool OverrideServerTime { get; set; }
    public string LastPlayedDate { get; }
    public int DaysSincePlayed { get; set; }
    
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
    public void set_SetStars(string value)
    {
        Player val_1 = App.Player;
        int val_2 = val_1.dcStars;
        if((System.Int32.TryParse(s:  value, result: out  val_2)) != false)
        {
                Player val_4 = App.Player;
            val_4.dcStars = val_2;
            App.Player.SaveState();
        }
        
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
    }
    public string get_SetStars()
    {
        Player val_1 = App.Player;
        return val_1.dcStars.ToString();
    }
    public void Add100Stars()
    {
        Player val_1 = App.Player;
        int val_2 = val_1.dcStars;
        val_2 = val_2 + 100;
        val_1.dcStars = val_2;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
    }
    public void Add10Stars()
    {
        Player val_1 = App.Player;
        int val_2 = val_1.dcStars;
        val_2 = val_2 + 10;
        val_1.dcStars = val_2;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
    }
    public void ResetStars()
    {
        Player val_1 = App.Player;
        val_1.dcStars = 0;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
    }
    public void Minus10Stars()
    {
        Player val_2 = App.Player;
        if(val_2.dcStars < 0)
        {
            goto label_4;
        }
        
        Player val_3 = App.Player;
        int val_4 = val_3.dcStars;
        val_4 = val_4 - 10;
        label_9:
        val_1.dcStars = val_4;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
        return;
        label_4:
        if(App.Player != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
    }
    public void Minute100Stars()
    {
        Player val_2 = App.Player;
        if(val_2.dcStars < 0)
        {
            goto label_4;
        }
        
        Player val_3 = App.Player;
        int val_4 = val_3.dcStars;
        val_4 = val_4 - 100;
        label_9:
        val_1.dcStars = val_4;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Stars");
        return;
        label_4:
        if(App.Player != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
    }
    public void GrantSunMoonWord()
    {
        WordRegion.instance.Hack_GrantSunMoonWord();
    }
    public void CheckLevelInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Daily Challenge Info HUD", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetDailyChallengeLevelInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void CheckTilesInfoHUD()
    {
        SLCHUDWindow.SetupHUD(name:  "Daily Challenge Tiles Info", callbackfunc:  new System.Func<System.String>(object:  MonoSingleton<SRDebugger_Instantiator>.Instance, method:  public System.String SRDebugger_Instantiator::GetDailyChallengeTileInfo()));
        var val_5 = 0;
        val_5 = val_5 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public int get_Days()
    {
        return (int)this.days;
    }
    public void set_Days(int value)
    {
        this.days = value;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "Days");
    }
    public void CompleteWithFullStars()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_FillStars(days:  this.days);
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void ResetMonthTile()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_ResetMonthTileOnServer();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void HackMonthTileCollection()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_MonthTileCollection();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void HackThisMonthStars()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_CompleteMonthStars();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public void HackThisWeekStars()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_CompleteWeekStars();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public bool get_OverrideServerTime()
    {
        var val_5;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                val_5 = 0;
            return (bool)((val_3.<HackDateTime>k__BackingField) == true) ? 1 : 0;
        }
        
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        return (bool)((val_3.<HackDateTime>k__BackingField) == true) ? 1 : 0;
    }
    public void set_OverrideServerTime(bool value)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return;
        }
        
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_3.<HackDateTime>k__BackingField = value;
    }
    public void ResetDailyChallenge()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_ResetDailyChallenge();
        var val_4 = 0;
        val_4 = val_4 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public string get_LastPlayedDate()
    {
        System.DateTime val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.LastPlayedDailyChallenge;
        return (string)val_2.dateData.ToString();
    }
    public int get_DaysSincePlayed()
    {
        return (int)this.lastPlayedDays;
    }
    public void set_DaysSincePlayed(int value)
    {
        this.lastPlayedDays = value;
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "DaysSincePlayed");
    }
    public void SetLastPlayedTime()
    {
        System.DateTime val_2 = DateTimeCheat.Now;
        System.DateTime val_3 = val_2.dateData.AddDays(value:  (double)this.lastPlayedDays);
        MonoSingleton<WGDailyChallengeManager>.Instance.LastPlayedDailyChallenge = new System.DateTime() {dateData = val_3.dateData};
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "LastPlayedDate");
    }
    public void ResetLastPlayTime()
    {
        MonoSingleton<WGDailyChallengeManager>.Instance.Hack_ResetLastPlayedTime();
        SROptions_DailyChallenge.NotifyPropertyChanged(propertyName:  "LastPlayedDate");
    }
    public SROptions_DailyChallenge()
    {
        this.days = 7;
        this.lastPlayedDays = -30;
    }

}

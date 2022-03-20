using UnityEngine;
public class DailyChallengeTutorialManager : MonoSingleton<DailyChallengeTutorialManager>
{
    // Fields
    private bool _TutorialActive;
    private bool _GameplayTutorialActive;
    private int _GameplayTutorialStep;
    
    // Properties
    public bool TutorialActive { get; }
    public bool GameplayTutorialActive { get; }
    public int GameplayTutorialStep { get; set; }
    private DailyChallengeTutorialGameplayHelper GetGameplayHelper { get; }
    private DailyChallengeTutorialCalendarHelper GetCalendarHelper { get; }
    private bool PlayerShouldSeeTutorial { get; }
    private bool HasAnyDailyChallengeProgress { get; }
    private bool HasPlayedDailyChallenge30Days { get; }
    private bool HasSeenTutorial { get; }
    
    // Methods
    public bool get_TutorialActive()
    {
        return (bool)this._TutorialActive;
    }
    public bool get_GameplayTutorialActive()
    {
        return (bool)this._GameplayTutorialActive;
    }
    public int get_GameplayTutorialStep()
    {
        return (int)this._GameplayTutorialStep;
    }
    public void set_GameplayTutorialStep(int value)
    {
        this._GameplayTutorialStep = value;
    }
    private DailyChallengeTutorialGameplayHelper get_GetGameplayHelper()
    {
        return MonoSingleton<DailyChallengeTutorialGameplayHelper>.Instance;
    }
    private DailyChallengeTutorialCalendarHelper get_GetCalendarHelper()
    {
        return MonoSingleton<DailyChallengeTutorialCalendarHelper>.Instance;
    }
    private bool get_PlayerShouldSeeTutorial()
    {
        return false;
    }
    private bool get_HasAnyDailyChallengeProgress()
    {
        Player val_1 = App.Player;
        if(val_1.dcStars > 0)
        {
                return true;
        }
        
        Player val_2 = App.Player;
        if(val_2.properties.LifetimeDCHints > 0)
        {
                return true;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.GetLifetimeMonthlyZootiles()) == null)
        {
                return true;
        }
        
        System.Collections.Generic.List<ZooTile> val_6 = MonoSingleton<WGDailyChallengeManager>.Instance.GetLifetimeMonthlyZootiles();
        return true;
    }
    private bool get_HasPlayedDailyChallenge30Days()
    {
        ulong val_12;
        var val_13;
        System.DateTime val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.LastPlayedDailyChallenge;
        val_12 = val_2.dateData;
        val_13 = null;
        val_13 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = val_12}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                WGDailyChallengeManager val_4 = MonoSingleton<WGDailyChallengeManager>.Instance;
            var val_5 = (val_4.monthHistory.stars > 0) ? 1 : 0;
            return (bool)(val_9._ticks.TotalDays <= 30) ? 1 : 0;
        }
        
        System.DateTime val_6 = DateTimeCheat.Now;
        val_12 = val_6.dateData;
        System.DateTime val_8 = MonoSingleton<WGDailyChallengeManager>.Instance.LastPlayedDailyChallenge;
        System.TimeSpan val_9 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_12}, d2:  new System.DateTime() {dateData = val_8.dateData});
        return (bool)(val_9._ticks.TotalDays <= 30) ? 1 : 0;
    }
    private bool get_HasSeenTutorial()
    {
        Player val_1 = App.Player;
        return (bool)(val_1.properties.DailyChallengeTutorialStatus > 0) ? 1 : 0;
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
    }
    public void TryShowLobbyTutorial()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_2D0;
    }
    public void ShowGameplayTutorial()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                return;
        }
        
        DailyChallengeTutorialGameplayHelper val_3 = val_2.<metaGameBehavior>k__BackingField.GetGameplayHelper;
        bool val_4 = UnityEngine.Object.op_Equality(x:  val_3, y:  0);
        if(val_4 != false)
        {
                UnityEngine.Debug.LogError(message:  "Could not find DailyChallengeTutorialGameplayHelper in game scene!");
            return;
        }
        
        UnityEngine.Coroutine val_6 = val_3.StartCoroutine(routine:  val_4.wait_ShowFTUX());
    }
    public GameLevel GetGameLevel()
    {
        GameLevel val_1 = new GameLevel();
        .extraWords = "";
        .word = "H|I|N|T";
        .actualWordCount = 6;
        .answers = "HI|IN|IT|HIT|TIN|HINT";
        val_1.levelName = "dctutorial";
        return val_1;
    }
    public DailyChallengeGameLevel GetDailyChallengeGameLevel()
    {
        DailyChallengeGameLevel val_1 = new DailyChallengeGameLevel();
        .gameLevel = val_1.GetGameLevel();
        return val_1;
    }
    public int GetSunMoonWordIndex()
    {
        if(this._GameplayTutorialStep >= 2)
        {
                return (int)(this._GameplayTutorialStep == 2) ? 4 : (!0);
        }
        
        return 1;
    }
    public System.Collections.Generic.List<bool> GetAllowedLettersForPan(int level, int lettersSize, System.Collections.Generic.List<string> lettersArray, System.Collections.Generic.List<int> indexes)
    {
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        int val_13 = lettersSize;
        val_10 = this;
        val_11 = 1152921504687730688;
        System.Collections.Generic.List<System.Boolean> val_1 = null;
        val_12 = val_1;
        val_1 = new System.Collections.Generic.List<System.Boolean>();
        val_1.Add(item:  false);
        val_1.Add(item:  false);
        val_1.Add(item:  false);
        val_1.Add(item:  false);
        GameBehavior val_2 = App.getBehavior;
        string val_3 = val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        int val_10 = this._GameplayTutorialStep;
        if(val_10 <= 1)
        {
            goto label_6;
        }
        
        if(val_10 != 2)
        {
            goto label_7;
        }
        
        if(val_10 < 1)
        {
                return (System.Collections.Generic.List<System.Boolean>)val_12;
        }
        
        val_10 = "T";
        val_11 = "I";
        var val_11 = 0;
        label_23:
        if(val_10 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 0;
        val_13 = mem[(this._GameplayTutorialStep + 0) + 32];
        val_13 = (this._GameplayTutorialStep + 0) + 32;
        if(val_10 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((this._GameplayTutorialStep + 0) + 32) << 3);
        if((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 32.Equals(value:  "T")) == true)
        {
            goto label_18;
        }
        
        val_13 = 0;
        if(val_10 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 0;
        if(val_10 <= ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3);
        if((((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 32.Equals(value:  "I")) == true)
        {
            goto label_18;
        }
        
        if(val_10 <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 0;
        val_13 = mem[(((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 0) + 32];
        val_13 = (((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 0) + 32;
        if(val_10 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 0) + 32) << 3);
        if((((((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 0) + + 32.Equals(value:  "N")) == false)
        {
            goto label_22;
        }
        
        label_18:
        val_1.set_Item(index:  0, value:  true);
        label_22:
        val_11 = val_11 + 1;
        if(val_11 < val_10)
        {
            goto label_23;
        }
        
        return (System.Collections.Generic.List<System.Boolean>)val_12;
        label_6:
        if(val_10 < 1)
        {
                return (System.Collections.Generic.List<System.Boolean>)val_12;
        }
        
        val_10 = "I";
        val_11 = "N";
        var val_12 = 0;
        label_36:
        if(val_10 <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 0;
        if(val_10 <= ((this._GameplayTutorialStep + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((this._GameplayTutorialStep + 0) + 32) << 3);
        if((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 32.Equals(value:  "I")) == true)
        {
            goto label_31;
        }
        
        if(val_10 <= val_12)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + 0;
        if(val_10 <= ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3);
        if((((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + ((((this._GameplayTutorialStep + 0) + ((this._GameplayTutorialStep + 0) + 32) << 3) + 0) + 32) << 3) + 32.Equals(value:  "N")) == false)
        {
            goto label_35;
        }
        
        label_31:
        val_1.set_Item(index:  0, value:  true);
        label_35:
        val_12 = val_12 + 1;
        if(val_12 < val_10)
        {
            goto label_36;
        }
        
        return (System.Collections.Generic.List<System.Boolean>)val_12;
        label_7:
        System.Collections.Generic.List<System.Boolean> val_9 = null;
        val_12 = val_9;
        val_9 = new System.Collections.Generic.List<System.Boolean>();
        if(val_13 < 1)
        {
                return (System.Collections.Generic.List<System.Boolean>)val_12;
        }
        
        do
        {
            val_9.Add(item:  true);
            val_13 = val_13 - 1;
        }
        while(val_13 != 1);
        
        return (System.Collections.Generic.List<System.Boolean>)val_12;
    }
    public void QAHACK_SKIPTUTORIAL()
    {
        if((MonoSingleton<DailyChallengeTutorialLobbyHelper>.Instance) != 0)
        {
                MonoSingleton<DailyChallengeTutorialLobbyHelper>.Instance.QAHACK_CANCEL();
        }
        
        this.HandleGameplayTutorialAborted();
    }
    public void HandleLobbyTutorialClicked()
    {
        this._TutorialActive = true;
        this._GameplayTutorialActive = true;
        MonoSingleton<WGDailyChallengeManager>.Instance.Play();
        Player val_2 = App.Player;
        val_2.properties.DailyChallengeTutorialStatus = 2;
        Player val_3 = App.Player;
        val_3.properties.Save(writePrefs:  true);
    }
    public void CheckHomeClick()
    {
        if(this._TutorialActive == false)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return;
        }
        
        this.HandleGameplayTutorialAborted();
    }
    public void HandleGameplayTutorialComplete()
    {
        this._GameplayTutorialActive = false;
    }
    public void HandlePreviousChallengesPrompted()
    {
        this._TutorialActive = false;
        Player val_1 = App.Player;
        val_1.properties.DailyChallengeTutorialStatus = 1;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
    }
    public void HandleGameplayTutorialAborted()
    {
        this._TutorialActive = false;
        this._GameplayTutorialActive = false;
        Player val_1 = App.Player;
        val_1.properties.DailyChallengeTutorialStatus = 2;
        Player val_2 = App.Player;
        val_2.properties.Save(writePrefs:  true);
    }
    public DailyChallengeTutorialManager()
    {
    
    }

}

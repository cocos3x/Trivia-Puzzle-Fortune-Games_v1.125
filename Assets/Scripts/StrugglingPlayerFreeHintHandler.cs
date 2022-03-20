using UnityEngine;
public class StrugglingPlayerFreeHintHandler : HintFeatureHandler
{
    // Fields
    private const float DEFAULT_AVG_COMPLETION_TIME = 60;
    private bool initd;
    private int freeHintsRemaining;
    private bool freeHintAvailableNow;
    private float currentCompletionTime;
    private UnityEngine.Coroutine waitingRoutine;
    private int wordsInThisLevel;
    private float timeWaited;
    
    // Properties
    public override bool freeHintEligable { get; }
    public override bool hasFreeHintsRemaining { get; }
    private float TimeToWaitBetweenHints { get; }
    
    // Methods
    public override bool get_freeHintEligable()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return false;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return false;
        }
        
        1152921504893161472 = 1152921504884269056;
        GameEcon val_6 = App.getGameEcon;
        if(App.Player >= val_6.spHintStartLevel)
        {
                GameEcon val_8 = App.getGameEcon;
            if(App.Player <= val_8.spHintEndLevel)
        {
                return false;
        }
        
        }
        
        return false;
    }
    public override void Init()
    {
        if(this.initd != false)
        {
                return;
        }
        
        this.initd = true;
    }
    private void OnDisable()
    {
        if(this.waitingRoutine == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.waitingRoutine);
    }
    public override void OnLevelStarted()
    {
        var val_14;
        string val_15;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if((this & 1) == 0)
        {
                return;
        }
        
        val_14 = 1152921504879157248;
        if(WordRegion.instance != 0)
        {
                WordRegion val_5 = WordRegion.instance;
            this.wordsInThisLevel = WordRegion.__il2cppRuntimeField_cctor_finished + 24;
        }
        
        GameLevel val_6 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false);
        this.currentCompletionTime = val_6.avgCompletionTime;
        if(val_6.avgCompletionTime < 0)
        {
                return;
        }
        
        if(val_6.avgCompletionTime == 0f)
        {
                this.currentCompletionTime = 60f;
        }
        
        this.freeHintAvailableNow = false;
        val_14 = "lastSrLevel";
        if((CPlayerPrefs.GetInt(key:  "lastSrLevel", defaultValue:  0)) == App.Player)
        {
                val_15 = "srHntRm";
            this.freeHintsRemaining = CPlayerPrefs.GetInt(key:  val_15, defaultValue:  0);
        }
        else
        {
                GameEcon val_10 = App.getGameEcon;
            this.freeHintsRemaining = val_10.spHintsPerLevel;
            CPlayerPrefs.SetInt(key:  "srHntRm", val:  val_10.spHintsPerLevel);
            CPlayerPrefs.SetInt(key:  "lastSrLevel", val:  App.Player);
            val_15 = this.freeHintsRemaining;
        }
        
        if(val_15 < 1)
        {
                return;
        }
        
        if(this.waitingRoutine != null)
        {
                this.StopCoroutine(routine:  this.waitingRoutine);
        }
        
        this.waitingRoutine = this.StartCoroutine(routine:  this.WaitThenDisplayPopup());
    }
    public override void OnLevelComplete()
    {
        if(this.waitingRoutine == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.waitingRoutine);
    }
    public override void OnSceneChanged()
    {
        if(this.waitingRoutine == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.waitingRoutine);
    }
    public override bool get_hasFreeHintsRemaining()
    {
        var val_2;
        if(((this & 1) != 0) && (this.freeHintsRemaining >= 1))
        {
                var val_1 = (this.freeHintAvailableNow == true) ? 1 : 0;
            return (bool)val_2;
        }
        
        val_2 = 0;
        return (bool)val_2;
    }
    public override void OnHintUsed(bool freeHint)
    {
        if((this & 1) == 0)
        {
                return;
        }
        
        GameLevel val_1 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false);
        if(val_1.avgCompletionTime < 0)
        {
                return;
        }
        
        if(freeHint == true)
        {
                return;
        }
        
        this.timeWaited = 0f;
    }
    public override void OnMyFreeHintUsed()
    {
        var val_8;
        MainController.instance.StruggleHintsUsed = val_1.struggleHintsUsed + 1;
        Player val_3 = App.Player;
        int val_8 = val_3.properties.LifetimeStruggleHints;
        val_8 = val_8 + 1;
        val_3.properties.LifetimeStruggleHints = val_8;
        int val_9 = this.freeHintsRemaining;
        this.freeHintAvailableNow = false;
        val_9 = val_9 - 1;
        this.freeHintsRemaining = val_9;
        MonoSingleton<HintFeatureManager>.Instance.UpdateFreeHintEligable();
        HintFeatureManager val_5 = MonoSingleton<HintFeatureManager>.Instance;
        val_5.<wgHbutton>k__BackingField.CheckFreeHinting();
        if(this.freeHintsRemaining >= 1)
        {
                if(this.waitingRoutine != null)
        {
                this.StopCoroutine(routine:  this.waitingRoutine);
        }
        
            this.waitingRoutine = this.StartCoroutine(routine:  this.WaitThenDisplayPopup());
        }
        
        val_8 = null;
        val_8 = null;
        App.trackerManager.track(eventName:  Events.STRUGGLE_HINT_USED);
    }
    private System.Collections.IEnumerator WaitThenDisplayPopup()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new StrugglingPlayerFreeHintHandler.<WaitThenDisplayPopup>d__19();
    }
    private float get_TimeToWaitBetweenHints()
    {
        if(this.wordsInThisLevel == 0)
        {
                return 99999f;
        }
        
        GameEcon val_1 = App.getGameEcon;
        float val_2 = val_1.spHintConstant;
        val_2 = val_2 * this.currentCompletionTime;
        val_2 = val_2 * (float)this.wordsInThisLevel;
        return 99999f;
    }
    public StrugglingPlayerFreeHintHandler()
    {
    
    }

}

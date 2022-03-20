using UnityEngine;
public class WGChallengeWordsManager : MonoSingleton<WGChallengeWordsManager>
{
    // Fields
    private const string HAS_SHOW_CHALLEHGE_FTU_KEY = "Has_Show_Challenge_FTUX_Key";
    public WGChallengeWordsManager.ChallengeWordsProgress progress;
    private bool <hasShowChallengeFTUX>k__BackingField;
    private bool <QAHACK_forceThisLevel>k__BackingField;
    public string QAHACK_lastLoadedLevelChallengeword;
    private bool <IsChallengeLevel>k__BackingField;
    
    // Properties
    public bool hasShowChallengeFTUX { get; set; }
    public bool QAHACK_forceThisLevel { get; set; }
    public int QAHACK_getProgressLevel { get; }
    public static bool IsFeatureUnlocked { get; }
    public bool IsPlaying { get; }
    public bool IsChallengeLevel { get; set; }
    
    // Methods
    public bool get_hasShowChallengeFTUX()
    {
        return (bool)this.<hasShowChallengeFTUX>k__BackingField;
    }
    private void set_hasShowChallengeFTUX(bool value)
    {
        this.<hasShowChallengeFTUX>k__BackingField = value;
    }
    public bool get_QAHACK_forceThisLevel()
    {
        return (bool)this.<QAHACK_forceThisLevel>k__BackingField;
    }
    public void set_QAHACK_forceThisLevel(bool value)
    {
        this.<QAHACK_forceThisLevel>k__BackingField = value;
    }
    public int get_QAHACK_getProgressLevel()
    {
        if(this.progress.inited == true)
        {
                return (int)this.progress._level;
        }
        
        this.progress.InitProgress();
        return (int)this.progress._level;
    }
    public static bool get_IsFeatureUnlocked()
    {
        GameEcon val_2 = App.getGameEcon;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_2._challengeWordsunlockLevel);
    }
    public bool get_IsPlaying()
    {
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        if(this.progress._level != App.Player)
        {
                if((this.<QAHACK_forceThisLevel>k__BackingField) == false)
        {
                return (bool)(this.progress._wordIndex != 1) ? 1 : 0;
        }
        
        }
        
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        return (bool)(this.progress._wordIndex != 1) ? 1 : 0;
    }
    public bool get_IsChallengeLevel()
    {
        return (bool)this.<IsChallengeLevel>k__BackingField;
    }
    private void set_IsChallengeLevel(bool value)
    {
        this.<IsChallengeLevel>k__BackingField = value;
    }
    public override void InitMonoSingleton()
    {
        this.<IsChallengeLevel>k__BackingField = false;
        this.<hasShowChallengeFTUX>k__BackingField = ((UnityEngine.PlayerPrefs.GetInt(key:  "Has_Show_Challenge_FTUX_Key", defaultValue:  0)) != 0) ? 1 : 0;
        this.CheckProgressLevel();
    }
    public void OnLevelLoaded(GameLevel gameLevel)
    {
        this.CheckIfChallengeLevel();
        if((this.<IsChallengeLevel>k__BackingField) == false)
        {
                return;
        }
        
        this.SetProgressWordIndex(challengeWord:  gameLevel.challengeWord);
    }
    public void ProgressLevelToNext()
    {
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        int val_1 = this.progress._level;
        val_1 = val_1 + 1;
        this.progress._level = val_1;
        this.progress.SaveProgress();
        this.progress._wordIndex = 0;
        this.progress.SaveProgress();
    }
    public void CompleteChallenge()
    {
        GameEcon val_2 = App.getGameEcon;
        int val_3 = val_2._challengeWordsLevelCooldown;
        val_3 = val_3 + App.Player;
        this.progress._level = val_3;
        this.progress.SaveProgress();
        this.progress._wordIndex = 0;
        this.progress.SaveProgress();
    }
    public void FinishFTUX()
    {
        this.<hasShowChallengeFTUX>k__BackingField = true;
        UnityEngine.PlayerPrefs.SetInt(key:  "Has_Show_Challenge_FTUX_Key", value:  1);
    }
    public void OnLevelComplete()
    {
        this.<IsChallengeLevel>k__BackingField = false;
    }
    private void CheckProgressLevel()
    {
        if(WGChallengeWordsManager.IsFeatureUnlocked == false)
        {
                return;
        }
        
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        if(App.Player <= this.progress._level)
        {
                return;
        }
        
        this.progress._level = App.Player;
        this.progress.SaveProgress();
        this.progress._wordIndex = 0;
        this.progress.SaveProgress();
    }
    private void CheckIfChallengeLevel()
    {
        this.CheckProgressLevel();
        this.<IsChallengeLevel>k__BackingField = false;
        if((this.<QAHACK_forceThisLevel>k__BackingField) == false)
        {
            goto label_1;
        }
        
        label_11:
        this.<IsChallengeLevel>k__BackingField = true;
        return;
        label_1:
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        if(this.progress._level != App.Player)
        {
                return;
        }
        
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        if((this.progress._wordIndex != 1) || ((this.<hasShowChallengeFTUX>k__BackingField) == false))
        {
            goto label_11;
        }
        
        int val_2 = UnityEngine.Random.Range(min:  0, max:  100);
        GameEcon val_3 = App.getGameEcon;
        this.<IsChallengeLevel>k__BackingField = (val_2 <= val_3._challengeWordsWordChance) ? 1 : 0;
        if(val_2 <= val_3._challengeWordsWordChance)
        {
                return;
        }
        
        this.ProgressLevelToNext();
    }
    private void SetProgressWordIndex(string challengeWord)
    {
        string val_4 = challengeWord;
        this.progress._wordIndex = 0;
        this.progress.SaveProgress();
        WordRegion val_1 = WordRegion.instance;
        if(mem[41963544] >= 1)
        {
                int val_5 = 0;
            do
        {
            if(mem[41963544] <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_4 = mem[41963536];
            val_4 = val_4 + 0;
            if((System.String.op_Equality(a:  (mem[41963536] + 0) + 32 + 24, b:  val_4 = challengeWord)) != false)
        {
                this.progress._wordIndex = val_5;
            this.progress.SaveProgress();
        }
        
            val_5 = val_5 + 1;
        }
        while(val_5 < mem[41963544]);
        
        }
        
        if(this.progress.inited != true)
        {
                this.progress.InitProgress();
        }
        
        if(this.progress._wordIndex == 1)
        {
                this.<IsChallengeLevel>k__BackingField = false;
            val_4 = System.String.Format(format:  "level does not contain: {0}", arg0:  val_4);
        }
        
        this.QAHACK_lastLoadedLevelChallengeword = val_4;
    }
    public void Hack_OnLevelChanged()
    {
        if(this.progress != null)
        {
                this.progress._level = 0;
            this.progress.SaveProgress();
            return;
        }
        
        throw new NullReferenceException();
    }
    public WGChallengeWordsManager()
    {
        WGChallengeWordsManager.ChallengeWordsProgress val_1 = null;
        ._wordIndex = 0;
        val_1 = new WGChallengeWordsManager.ChallengeWordsProgress();
        this.progress = val_1;
        this.QAHACK_lastLoadedLevelChallengeword = "";
    }

}

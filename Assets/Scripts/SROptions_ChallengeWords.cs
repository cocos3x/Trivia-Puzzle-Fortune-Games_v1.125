using UnityEngine;
public class SROptions_ChallengeWords : SuperLuckySROptionsParent<SROptions_ChallengeWords>, INotifyPropertyChanged
{
    // Properties
    public bool PlayChallengeWords { get; set; }
    public bool IsChallengeLevel { get; }
    public bool IsPlaying { get; }
    public int NextChallengeLevel { get; }
    public string LastChallengeWord { get; }
    public int Cooldown { get; }
    public int Chance { get; }
    
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
    public bool get_IsChallengeLevel()
    {
        WGChallengeWordsManager val_1 = MonoSingleton<WGChallengeWordsManager>.Instance;
        return (bool)val_1.<IsChallengeLevel>k__BackingField;
    }
    public bool get_IsPlaying()
    {
        return MonoSingleton<WGChallengeWordsManager>.Instance.IsPlaying;
    }
    public int get_NextChallengeLevel()
    {
        return MonoSingleton<WGChallengeWordsManager>.Instance.QAHACK_getProgressLevel;
    }
    public string get_LastChallengeWord()
    {
        WGChallengeWordsManager val_1 = MonoSingleton<WGChallengeWordsManager>.Instance;
        return (string)val_1.QAHACK_lastLoadedLevelChallengeword;
    }
    public int get_Cooldown()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1._challengeWordsLevelCooldown;
    }
    public int get_Chance()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1._challengeWordsWordChance;
    }
    public SROptions_ChallengeWords()
    {
    
    }

}

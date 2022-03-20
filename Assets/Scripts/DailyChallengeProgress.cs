using UnityEngine;
public class DailyChallengeProgress : Progression
{
    // Fields
    public double oa_date;
    public DailyChallengeGameLevel currentLevel;
    public DailyChallengeSimplifiedLevel morningChallenge;
    public DailyChallengeSimplifiedLevel eveningChallenge;
    
    // Methods
    public DailyChallengeProgress()
    {
        this.currentLevel = new DailyChallengeGameLevel();
        mem[1152921517466622628] = 1;
        this.morningChallenge = new DailyChallengeSimplifiedLevel();
        mem[1152921517466626724] = 0;
        this.eveningChallenge = new DailyChallengeSimplifiedLevel();
        this.currentLevel = new DailyChallengeGameLevel();
    }
    public override void Load()
    {
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_170;
    }
    public override void Save()
    {
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_190;
    }

}

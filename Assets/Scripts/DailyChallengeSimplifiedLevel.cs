using UnityEngine;
public class DailyChallengeSimplifiedLevel : DailyChallengeBasicLevel
{
    // Fields
    private const string pref_morning_finished = "DailyChallengeMorningFinished";
    private const string pref_evening_finished = "DailyChallengeEveningFinished";
    private const string pref_morning_stars = "DailyChallengemMorningStars";
    private const string pref_evening_stars = "DailyChallengeEveningStars";
    public bool done;
    
    // Methods
    public DailyChallengeSimplifiedLevel(bool isMorning)
    {
        val_1 = new Progression();
        mem[1152921517467834532] = isMorning;
        this.done = false;
    }
    public override void Load()
    {
        string val_1 = (true == 0) ? "DailyChallengeEveningStars" : "DailyChallengemMorningStars";
        mem[1152921517467947040] = UnityEngine.PlayerPrefs.GetInt(key:  val_1, defaultValue:  0);
        this.done = ((UnityEngine.PlayerPrefs.GetInt(key:  (val_1 == 0) ? "DailyChallengeEveningFinished" : "DailyChallengeMorningFinished", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public override void Save()
    {
        string val_1 = (true == 0) ? "DailyChallengeEveningStars" : "DailyChallengemMorningStars";
        UnityEngine.PlayerPrefs.SetInt(key:  val_1, value:  0);
        UnityEngine.PlayerPrefs.SetInt(key:  (val_1 == 0) ? "DailyChallengeEveningFinished" : "DailyChallengeMorningFinished", value:  this.done);
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        this.DeleteKey(key:  "DailyChallengeMorningFinished");
        this.DeleteKey(key:  "DailyChallengeEveningFinished");
        this.DeleteKey(key:  "DailyChallengemMorningStars");
        this.DeleteKey(key:  "DailyChallengeEveningStars");
    }

}

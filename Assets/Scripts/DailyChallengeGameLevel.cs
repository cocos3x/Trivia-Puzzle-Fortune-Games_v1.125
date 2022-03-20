using UnityEngine;
public class DailyChallengeGameLevel : Progression
{
    // Fields
    private const string pref_max_wd_strk = "dc_max_wd_strk";
    private const string pref_league_pts = "dc_lg_pts_erd";
    private const string pref_current_stars = "DailyChallengeCurrentStars";
    private const string pref_current_points = "DailyChallengeCurrentPoints";
    private const string pref_retry_level = "DailyChallengeRetried";
    private const string pref_ptr_gone = "DailyChallenge_PointerGG";
    private const string pref_ptr_word_index = "DailyChallenge_PointerWordIndex";
    private const string pref_ptr_letter_index = "DailyChallenge_PointerLetterIndex";
    private const string pref_current_word = "DailyChallengeCurrentWord";
    private const string pref_has_started = "DailyChallengeInProgress";
    private const string pref_progress_def_index = "DailyChallengeProgressDefinitionsIndex";
    private const string pref_regular_hints_used = "DailyChallengeHintsUsed";
    private const string pref_picker_hints_used = "DailyChallengePickerHintsUsed";
    private const string pref_time_spent = "DailyChallengeTimeSpent";
    private const string pref_session_stars_starting = "DailyChallengeSessionStarsStarting";
    private const string pref_stars_saved = "DailyChallengeStarsSavedByPet";
    private const string pref_current_tier = "dc_current_tier";
    public bool persistent;
    public GameLevel gameLevel;
    public System.Collections.Generic.List<string> found;
    public int stars;
    public int points;
    public string currentSunMoonWord;
    public int progressDefinitionsIndex;
    public bool isRetryLevel;
    public bool hasStartedPreviously;
    public bool pointerGone;
    public int pointerWordIndex;
    public int pointerLetterIndex;
    public int largestWordStreak;
    public int leaguePointsEarned;
    public int regularHintsUsed;
    public int pickerHintsUsed;
    public int timeSpent;
    public int sessionStarsStarting;
    public bool challengeResumed;
    public int challengeStartTime;
    public int timerBeginCheatSeconds;
    public int sessionLoseFocusStartTime;
    public int sessionLoseFocusTime;
    public int starsSaved;
    public StarTier tier;
    
    // Methods
    public DailyChallengeGameLevel()
    {
        this.found = new System.Collections.Generic.List<System.String>();
        this.persistent = true;
        this.gameLevel = new GameLevel();
        this.stars = 0;
        this.points = 0;
        this.pointerGone = false;
        this.isRetryLevel = false;
        this.hasStartedPreviously = false;
        this.progressDefinitionsIndex = 0;
        this.challengeResumed = false;
        this.regularHintsUsed = 0;
        this.pickerHintsUsed = 0;
        this.timeSpent = 0;
        this.sessionStarsStarting = 0;
        this.largestWordStreak = 0;
        this.leaguePointsEarned = 0;
        this.starsSaved = 0;
        this.sessionLoseFocusStartTime = 0;
        this.sessionLoseFocusTime = 0;
        this.challengeStartTime = 0;
        this.timerBeginCheatSeconds = 0;
        this.pointerWordIndex = -1;
        this.pointerLetterIndex = -1;
        this.tier = new StarTier();
    }
    public void ResetPointer()
    {
        this.pointerGone = false;
        this.pointerWordIndex = -1;
        this.pointerLetterIndex = -1;
        goto typeof(DailyChallengeGameLevel).__il2cppRuntimeField_180;
    }
    public override void Load()
    {
        if(this.persistent == false)
        {
                return;
        }
        
        this.stars = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeCurrentStars", defaultValue:  0);
        this.points = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeCurrentPoints", defaultValue:  0);
        this.progressDefinitionsIndex = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeProgressDefinitionsIndex", defaultValue:  0);
        this.isRetryLevel = ((UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeRetried", defaultValue:  0)) == 1) ? 1 : 0;
        this.hasStartedPreviously = ((UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeInProgress", defaultValue:  0)) == 1) ? 1 : 0;
        this.pointerGone = ((UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallenge_PointerGG", defaultValue:  0)) == 1) ? 1 : 0;
        this.pointerWordIndex = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallenge_PointerWordIndex", defaultValue:  0);
        this.pointerLetterIndex = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallenge_PointerLetterIndex", defaultValue:  0);
        this.largestWordStreak = UnityEngine.PlayerPrefs.GetInt(key:  "dc_max_wd_strk", defaultValue:  0);
        this.leaguePointsEarned = UnityEngine.PlayerPrefs.GetInt(key:  "dc_lg_pts_erd", defaultValue:  0);
        this.regularHintsUsed = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeHintsUsed", defaultValue:  0);
        this.pickerHintsUsed = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengePickerHintsUsed", defaultValue:  0);
        this.timeSpent = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeTimeSpent", defaultValue:  0);
        this.sessionStarsStarting = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeSessionStarsStarting", defaultValue:  0);
        this.starsSaved = UnityEngine.PlayerPrefs.GetInt(key:  "DailyChallengeStarsSavedByPet", defaultValue:  0);
    }
    public override void Save()
    {
        if(this.persistent == false)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeCurrentStars", value:  this.stars);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeCurrentPoints", value:  this.points);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeProgressDefinitionsIndex", value:  this.progressDefinitionsIndex);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeRetried", value:  this.isRetryLevel);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeInProgress", value:  this.hasStartedPreviously);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallenge_PointerGG", value:  this.pointerGone);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallenge_PointerWordIndex", value:  this.pointerWordIndex);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallenge_PointerLetterIndex", value:  this.pointerLetterIndex);
        UnityEngine.PlayerPrefs.SetInt(key:  "dc_max_wd_strk", value:  this.largestWordStreak);
        UnityEngine.PlayerPrefs.SetInt(key:  "dc_lg_pts_erd", value:  this.leaguePointsEarned);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeHintsUsed", value:  this.regularHintsUsed);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengePickerHintsUsed", value:  this.pickerHintsUsed);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeTimeSpent", value:  this.timeSpent);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeSessionStarsStarting", value:  this.sessionStarsStarting);
        UnityEngine.PlayerPrefs.SetInt(key:  "DailyChallengeStarsSavedByPet", value:  this.starsSaved);
        if((System.String.IsNullOrEmpty(value:  this.gameLevel.word)) != true)
        {
                this = this.gameLevel;
            PlayingLevel.SetLevel(currentMode:  2, level:  this, parameters:  0, skipSaving:  false);
        }
        
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        if(this.persistent == false)
        {
                return;
        }
        
        this.DeleteKey(key:  "DailyChallengeCurrentStars");
        this.DeleteKey(key:  "DailyChallengeCurrentPoints");
        this.DeleteKey(key:  "DailyChallengeProgressDefinitionsIndex");
        this.DeleteKey(key:  "DailyChallengeRetried");
        this.DeleteKey(key:  "DailyChallengeInProgress");
        this.DeleteKey(key:  "dc_max_wd_strk");
        this.DeleteKey(key:  "dc_lg_pts_erd");
        this.DeleteKey(key:  "DailyChallengeHintsUsed");
        this.DeleteKey(key:  "DailyChallengePickerHintsUsed");
        this.DeleteKey(key:  "DailyChallengeTimeSpent");
        this.DeleteKey(key:  "DailyChallengeSessionStarsStarting");
        this.DeleteKey(key:  "DailyChallenge_PointerGG");
        this.DeleteKey(key:  "DailyChallenge_PointerWordIndex");
        this.DeleteKey(key:  "DailyChallenge_PointerLetterIndex");
        this.DeleteKey(key:  "DailyChallengeStarsSavedByPet");
    }

}

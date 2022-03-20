using UnityEngine;
public class WordIQManagerGameplay : MonoSingleton<WordIQManagerGameplay>
{
    // Fields
    private const string pref_iq_input = "iq_input";
    private const string pref_iq_streak = "iq_streak";
    private const string pref_iq_highest_streak = "iq_highest_streak";
    private const string pref_iq_input_words = "iq_input_words";
    private const string pref_iq_has_seen_new = "iq_has_seen_new";
    private int _TotalInput;
    private int _CurrentStreak;
    private int _HighestConsecutiveValidInput;
    private System.Collections.Generic.List<string> _ValidWordsInput;
    private int _LevelFirstSawNew;
    private IQGains lastLevelGains;
    
    // Methods
    public override void InitMonoSingleton()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WordIQManagerGameplay::OnSceneLoaded(SceneType sceneType)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public void AddValidInput(string validWord, bool isExtra)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        int val_7 = this._TotalInput;
        val_7 = val_7 + 1;
        this._TotalInput = val_7;
        this._ValidWordsInput.Add(item:  validWord);
        int val_8 = this._CurrentStreak;
        val_8 = val_8 + 1;
        this._CurrentStreak = val_8;
        if((MonoSingleton<WordIQManager>.Instance.IsNewWord(word:  validWord)) != false)
        {
                MonoSingleton<WordIQManagerUI>.Instance.NewWordFound(word:  validWord, isExtra:  isExtra);
        }
        
        this.SaveGameState();
    }
    public void AddInvalidInput()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        int val_3 = this._TotalInput;
        val_3 = val_3 + 1;
        this._TotalInput = val_3;
        if(this._CurrentStreak > this._HighestConsecutiveValidInput)
        {
                this._HighestConsecutiveValidInput = this._CurrentStreak;
        }
        
        this._CurrentStreak = 0;
        this.SaveGameState();
    }
    public void ResetLevelProgress()
    {
        this._TotalInput = 0;
        this._CurrentStreak = 0;
        this._HighestConsecutiveValidInput = 0;
        this._ValidWordsInput.Clear();
        this.SaveGameState();
    }
    public void HandleLevelComplete(GameLevel level)
    {
        var val_21;
        var val_22;
        System.Predicate<System.String> val_24;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        char[] val_4 = new char[1];
        val_4[0] = 124;
        IQGains val_8 = MonoSingleton<WordIQManager>.Instance.CalculateCompletedLevelPoints(allValidWords:  this._ValidWordsInput, requiredWords:  new System.Collections.Generic.List<System.String>(collection:  level.answers.Split(separator:  val_4)), numLetters:  level.word.m_stringLength, totalInput:  this._TotalInput, highestConsecutiveValidInput:  UnityEngine.Mathf.Max(a:  this._CurrentStreak, b:  this._HighestConsecutiveValidInput));
        this.lastLevelGains = val_8;
        string val_10 = "IQ POINTS GAINED: "("IQ POINTS GAINED: ") + val_8.Total;
        val_10.DebugLog(logString:  val_10);
        WordIQManager val_11 = MonoSingleton<WordIQManager>.Instance;
        float val_13 = this.lastLevelGains.Total;
        val_13 = val_11.PlayerIQ + val_13;
        val_11.PlayerIQ = val_13;
        System.Collections.Generic.List<System.String> val_14 = new System.Collections.Generic.List<System.String>(collection:  this._ValidWordsInput);
        val_22 = null;
        val_22 = null;
        val_24 = WordIQManagerGameplay.<>c.<>9__15_0;
        if(val_24 == null)
        {
                System.Predicate<System.String> val_15 = null;
            val_24 = val_15;
            val_15 = new System.Predicate<System.String>(object:  WordIQManagerGameplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordIQManagerGameplay.<>c::<HandleLevelComplete>b__15_0(string p));
            WordIQManagerGameplay.<>c.<>9__15_0 = val_24;
        }
        
        int val_16 = val_14.RemoveAll(match:  val_15);
        val_21 = MonoSingleton<WordIQManagerUI>.Instance;
        val_21.HandleLevelCompleted(iqPointsTotal:  MonoSingleton<WordIQManager>.Instance.PlayerIQ, iqPointsGainedLastLevel:  this.lastLevelGains, newWordsFoundLastLevel:  val_14);
        MonoSingleton<WordIQManager>.Instance.HandleLevelCompleted(allValidWords:  this._ValidWordsInput);
        this.ResetLevelProgress();
    }
    public void AppendLevelCompleteData(ref System.Collections.Generic.Dictionary<string, object> curData)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(this.lastLevelGains == null)
        {
                return;
        }
        
        val_3 = curData;
        val_3.Add(key:  "IQ Points Level Clear Earned", value:  this.lastLevelGains.levelClearPoints);
        1152921516852626192 = curData;
        1152921516852626192.Add(key:  "IQ Points NEWWORDS Earned", value:  this.lastLevelGains.newWordsFoundPoints);
    }
    public void HandleNewLevel(GameLevel level)
    {
        var val_13;
        System.Predicate<System.String> val_15;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        char[] val_3 = new char[1];
        val_3[0] = 124;
        System.Collections.Generic.List<System.String> val_5 = new System.Collections.Generic.List<System.String>(collection:  level.answers.Split(separator:  val_3));
        val_13 = null;
        val_13 = null;
        val_15 = WordIQManagerGameplay.<>c.<>9__17_0;
        if(val_15 == null)
        {
                System.Predicate<System.String> val_7 = null;
            val_15 = val_7;
            val_7 = new System.Predicate<System.String>(object:  WordIQManagerGameplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordIQManagerGameplay.<>c::<HandleNewLevel>b__17_0(string p));
            WordIQManagerGameplay.<>c.<>9__17_0 = val_15;
        }
        
        int val_8 = new System.Collections.Generic.List<System.String>(collection:  val_5).RemoveAll(match:  val_7);
        System.Collections.Generic.List<System.String> val_9 = new System.Collections.Generic.List<System.String>(collection:  val_5);
        char[] val_10 = new char[1];
        val_10[0] = 124;
        val_9.AddRange(collection:  level.extraWords.Split(separator:  val_10));
        this.LoadGameState(allLevelWords:  val_9);
        MonoSingleton<WordIQManagerUI>.Instance.PrepNewLevel();
    }
    public string DebugGameplayLogic()
    {
        object[] val_1 = new object[5];
        val_1[0] = this._TotalInput;
        val_1[1] = this._CurrentStreak;
        val_1[2] = this._HighestConsecutiveValidInput;
        val_1[3] = PrettyPrint.printJSON(obj:  this._ValidWordsInput, types:  false, singleLineOutput:  false);
        val_1[4] = this._LevelFirstSawNew;
        return (string)System.String.Format(format:  "Total Input:{0}\nCurrent Streak:{1}\nHighest Streak:{2}\nValid Input Words:\n{3}\nLevel First Saw New:{4}", args:  val_1);
    }
    private void OnSceneLoaded(SceneType sceneType)
    {
        var val_11;
        if(sceneType != 2)
        {
                return;
        }
        
        val_11 = 1152921504879157248;
        if(WordRegion.instance == 0)
        {
                return;
        }
        
        WordRegion.instance.addOnValidWordSubmittedAction(callback:  new System.Action<System.String, System.Boolean>(object:  this, method:  public System.Void WordIQManagerGameplay::AddValidInput(string validWord, bool isExtra)));
        WordRegion.instance.addOnInvalidWordSubmittedAction(callback:  new System.Action(object:  this, method:  public System.Void WordIQManagerGameplay::AddInvalidInput()));
        WordRegion.instance.addOnLevelLoadedAction(callback:  new System.Action<GameLevel>(object:  this, method:  public System.Void WordIQManagerGameplay::HandleNewLevel(GameLevel level)));
        WordRegion.instance.addOnLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  public System.Void WordIQManagerGameplay::HandleLevelComplete(GameLevel level)));
    }
    private void SaveGameState()
    {
        this.WriteDataToPrefs();
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
        string val_3 = "SAVED: "("SAVED: ") + this.DebugGameplayLogic();
        val_3.DebugLog(logString:  val_3);
    }
    private string GetPrefPrefix()
    {
        return (string)(CategoryPacksManager.IsPlaying != true) ? "cat_" : "";
    }
    private void WriteDataToPrefs()
    {
        string val_1 = this.GetPrefPrefix();
        UnityEngine.PlayerPrefs.SetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_input"), value:  this._TotalInput);
        UnityEngine.PlayerPrefs.SetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_streak"), value:  this._CurrentStreak);
        UnityEngine.PlayerPrefs.SetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_highest_streak"), value:  this._HighestConsecutiveValidInput);
        UnityEngine.PlayerPrefs.SetString(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_input_words"), value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this._ValidWordsInput));
        UnityEngine.PlayerPrefs.SetInt(key:  "iq_has_seen_new", value:  this._LevelFirstSawNew);
    }
    private void LoadGameState(System.Collections.Generic.List<string> allLevelWords)
    {
        var val_18;
        string val_1 = this.GetPrefPrefix();
        this._TotalInput = UnityEngine.PlayerPrefs.GetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_input"), defaultValue:  0);
        this._CurrentStreak = UnityEngine.PlayerPrefs.GetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_streak"), defaultValue:  0);
        this._HighestConsecutiveValidInput = UnityEngine.PlayerPrefs.GetInt(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_highest_streak"), defaultValue:  0);
        this._ValidWordsInput = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.String>>(value:  UnityEngine.PlayerPrefs.GetString(key:  System.String.Format(format:  "{0}{1}", arg0:  val_1, arg1:  "iq_input_words"), defaultValue:  "[]"));
        string val_12 = "LOADED: "("LOADED: ") + this.DebugGameplayLogic();
        val_12.DebugLog(logString:  val_12);
        this._LevelFirstSawNew = UnityEngine.PlayerPrefs.GetInt(key:  "iq_has_seen_new", defaultValue:  0);
        val_18 = 0;
        label_8:
        if(val_18 >= "iq_has_seen_new")
        {
                return;
        }
        
        if(val_18 >= 44418264)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((allLevelWords.Contains(item:  null)) == false)
        {
            goto label_7;
        }
        
        val_18 = val_18 + 1;
        if(this._ValidWordsInput != null)
        {
            goto label_8;
        }
        
        throw new NullReferenceException();
        label_7:
        string val_17 = "Loaded answers don\'t match current GameLevel. GameLevel answers: \n"("Loaded answers don\'t match current GameLevel. GameLevel answers: \n") + PrettyPrint.printJSON(obj:  allLevelWords, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  allLevelWords, types:  false, singleLineOutput:  false)) + "\n vs Loaded answers: \n"("\n vs Loaded answers: \n") + PrettyPrint.printJSON(obj:  this._ValidWordsInput, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  this._ValidWordsInput, types:  false, singleLineOutput:  false));
        val_17.DebugLog(logString:  val_17);
        this.ResetLevelProgress();
    }
    private void DebugLog(string logString)
    {
        WordIQManager.DebugLog(logString:  logString);
    }
    public WordIQManagerGameplay()
    {
        this._ValidWordsInput = new System.Collections.Generic.List<System.String>();
        this._LevelFirstSawNew = 0;
    }

}

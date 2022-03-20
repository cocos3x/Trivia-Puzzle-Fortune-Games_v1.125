using UnityEngine;
public class WordIQManager : MonoSingleton<WordIQManager>
{
    // Fields
    public const bool display_feature_complexities = False;
    private const string pref_word_history = "wiq_hist";
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> _WordHistory;
    private const string KEY_IS_FTUX_SEEN = "word_iq_is_ftux_seen";
    private System.Collections.Generic.List<string> cachedWordsToSend;
    private System.Collections.Generic.List<string> wordsBeingSent;
    private bool sendingWords;
    private string debug_populatedHistoryFromLevel;
    private string debug_actualWordHistory;
    private static string _debugLogHistory;
    protected System.Collections.Generic.Dictionary<int, float> CompensatedIQScoreBelow2502;
    
    // Properties
    public float PlayerIQ { get; set; }
    public int PlayerMilestone { get; }
    public bool IsFtuxSeen { get; set; }
    public static float BaseIQ { get; }
    private string pref_played_words_key { get; }
    private int MaxPredefinedLevels { get; }
    private float MaxNEWWORDIQCompensation { get; }
    private float LevelClearIQCompensation_a { get; }
    private float LevelClearIQCompensation_b { get; }
    private float BaseNewWordPoint { get; }
    private float LetterPoint { get; }
    private float NEWWORDMultiplier { get; }
    private float BaseClearPoints_min { get; }
    private float BaseClearPoints_max { get; }
    private float HighestComplexity { get; }
    private float MaxAdditionalClearPoints { get; }
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> WordHistory { get; set; }
    protected float[] Milestones { get; }
    
    // Methods
    public float get_PlayerIQ()
    {
        Player val_1 = App.Player;
        return (float)val_1.properties.PlayerIQ;
    }
    public void set_PlayerIQ(float value)
    {
        Player val_1 = App.Player;
        val_1.properties.PlayerIQ = value;
    }
    public int get_PlayerMilestone()
    {
        return this.GetMilestone(iqPoints:  this.PlayerIQ);
    }
    public bool get_IsFtuxSeen()
    {
        return (bool)((UnityEngine.PlayerPrefs.GetInt(key:  "word_iq_is_ftux_seen", defaultValue:  0)) == 1) ? 1 : 0;
    }
    public void set_IsFtuxSeen(bool value)
    {
        value = value;
        UnityEngine.PlayerPrefs.SetInt(key:  "word_iq_is_ftux_seen", value:  value);
        bool val_1 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public static float get_BaseIQ()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_BaseIQ;
    }
    private string get_pref_played_words_key()
    {
        return "wadwut_pw_vars";
    }
    private int get_MaxPredefinedLevels()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return MonoSingletonSelfGenerating<WADChapterManager>.Instance.MaxPredefinedLevels;
        }
        
        return MonoSingletonSelfGenerating<WordLevelGen>.Instance.DefinedLevelCount;
    }
    private float get_MaxNEWWORDIQCompensation()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_MaxNEWWORDIQCompensation;
    }
    private float get_LevelClearIQCompensation_a()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_LevelClearIQCompensation_a;
    }
    private float get_LevelClearIQCompensation_b()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_LevelClearIQCompensation_b;
    }
    private float get_BaseNewWordPoint()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_BaseNewWordPoint;
    }
    private float get_LetterPoint()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_LetterPoint;
    }
    private float get_NEWWORDMultiplier()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_NEWWORDMultiplier;
    }
    private float get_BaseClearPoints_min()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_BaseClearPoints_min;
    }
    private float get_BaseClearPoints_max()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_BaseClearPoints_max;
    }
    private float get_HighestComplexity()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_HighestComplexity;
    }
    private float get_MaxAdditionalClearPoints()
    {
        GameEcon val_1 = App.getGameEcon;
        return (float)val_1.WIQ_MaxAdditionalClearPoints;
    }
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> get_WordHistory()
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_5 = this._WordHistory;
        if(val_5 != null)
        {
                return val_5;
        }
        
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wiq_hist")) != false)
        {
                val_5 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "wiq_hist", defaultValue:  "{}"));
        }
        else
        {
                System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_4 = null;
            val_5 = val_4;
            val_4 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
        }
        
        this._WordHistory = val_5;
        return val_5;
    }
    private void set_WordHistory(System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> value)
    {
        this._WordHistory = value;
    }
    public override void InitMonoSingleton()
    {
        System.Action val_11;
        this.InitMonoSingleton();
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_5;
        }
        
        WordLevelGen val_2 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
        if(val_2.initialized == false)
        {
            goto label_9;
        }
        
        label_13:
        this.ManagePlayerData();
        return;
        label_5:
        WADataParser val_3 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(val_3.initialized == true)
        {
            goto label_13;
        }
        
        label_9:
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                WordLevelGen val_5 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            val_11 = val_5.OnWordLevelGenInit;
            System.Delegate val_7 = System.Delegate.Combine(a:  val_11, b:  new System.Action(object:  this, method:  System.Void WordIQManager::OnLevelsInitialized()));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_5.OnWordLevelGenInit = val_7;
            return;
        }
        
        WADataParser val_8 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        val_11 = val_8.OnWADataParseInit;
        System.Delegate val_10 = System.Delegate.Combine(a:  val_11, b:  new System.Action(object:  this, method:  System.Void WordIQManager::OnLevelsInitialized()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
        val_8.OnWADataParseInit = val_10;
        return;
        label_29:
    }
    public IQGains CalculateCompletedLevelPoints(System.Collections.Generic.List<string> allValidWords, System.Collections.Generic.List<string> requiredWords, int numLetters, int totalInput, int highestConsecutiveValidInput)
    {
        object val_62;
        float val_63;
        float val_64;
        float val_66;
        val_62 = this;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>(collection:  allValidWords);
        int val_3 = val_1.RemoveAll(match:  new System.Predicate<System.String>(object:  this, method:  System.Boolean WordIQManager::<CalculateCompletedLevelPoints>b__43_0(string p)));
        if(1152921516845216832 >= 1)
        {
                do
        {
            if(1152921516845216832 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            float val_6 = this.NEWWORDMultiplier;
            float val_62 = (float)public System.Void System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.RewardedVideoAdContainer>::.ctor().__il2cppRuntimeField_10;
            val_62 = this.LetterPoint * val_62;
            val_62 = val_3.BaseNewWordPoint + val_62;
            val_6 = val_6 * val_62;
            val_63 = 0f + val_6;
            val_62 = 0 + 1;
        }
        while(val_62 < (public System.Void System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.RewardedVideoAdContainer>::.ctor()));
        
        }
        else
        {
                val_63 = 0f;
        }
        
        val_64 = val_3.BaseClearPoints_min;
        float val_9 = UnityEngine.Random.Range(min:  val_64, max:  val_3.BaseClearPoints_max);
        if(1152921516845216832 >= 1)
        {
                do
        {
            if(1152921516845216832 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_62 = 0 + 1;
            val_64 = (float)public System.Void System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.RewardedVideoAdContainer>::.ctor().__il2cppRuntimeField_10;
            val_66 = 0f + val_64;
        }
        while(val_62 < (public System.Void System.Collections.Generic.Dictionary<System.Int32, AudienceNetwork.RewardedVideoAdContainer>::.ctor()));
        
        }
        else
        {
                val_66 = 0f;
        }
        
        float val_10 = val_66 / (4.442441E+07f);
        float val_63 = (float)numLetters;
        float val_65 = 7f;
        float val_64 = 18f;
        val_63 = val_63 / val_65;
        val_64 = (4.442441E+07f) / val_64;
        val_63 = val_64 * val_63;
        val_65 = val_10 / val_65;
        val_63 = val_65 * val_63;
        float val_12 = UnityEngine.Mathf.Min(a:  val_63, b:  this.HighestComplexity);
        float val_66 = val_12;
        float val_13 = this.HighestComplexity;
        val_66 = val_66 / val_13;
        float val_67 = (float)totalInput;
        float val_68 = val_13;
        val_67 = val_68 / val_67;
        val_68 = (float)highestConsecutiveValidInput / val_68;
        val_68 = val_67 + val_68;
        float val_69 = 0.5f;
        float val_14 = val_68 * val_69;
        float val_15 = this.MaxAdditionalClearPoints;
        val_69 = val_66 * val_14;
        val_15 = val_15 * val_69;
        val_15 = val_9 + val_15;
        val_15 = val_63 + val_15;
        object[] val_16 = new object[35];
        val_16[0] = val_15.ToString();
        val_16[1] = val_63.ToString();
        val_16[2] = val_15.ToString();
        val_16[3] = Newtonsoft.Json.JsonConvert.SerializeObject(value:  val_1);
        val_16[4] = val_63.ToString();
        val_16[5] = X0.BaseNewWordPoint.ToString();
        val_16[6] = X0.LetterPoint.ToString();
        val_16[7] = X0.NEWWORDMultiplier.ToString();
        val_16[8] = val_15.ToString();
        val_16[9] = val_9.ToString();
        val_16[10] = val_15.ToString();
        val_16[11] = val_9.ToString();
        val_16[12] = X0.BaseClearPoints_min.ToString();
        val_16[13] = X0.BaseClearPoints_max.ToString();
        val_16[14] = val_15.ToString();
        val_16[15] = val_66.ToString();
        val_16[16] = val_14.ToString();
        val_16[17] = X0.MaxAdditionalClearPoints.ToString();
        val_16[18] = val_66.ToString();
        val_16[19] = val_12.ToString();
        val_16[20] = X0.HighestComplexity.ToString();
        val_16[21] = val_12.ToString();
        val_16[22] = numLetters.ToString();
        val_16[23] = val_16.Length.ToString();
        val_16[24] = val_10.ToString();
        val_16[25] = X0.HighestComplexity.ToString();
        val_16[26] = val_14.ToString();
        val_16[27] = val_67.ToString();
        val_16[28] = val_68.ToString();
        val_16[29] = val_67.ToString();
        val_16[30] = val_68.ToString();
        val_16[31] = totalInput.ToString();
        val_16[32] = val_68.ToString();
        val_16[33] = highestConsecutiveValidInput.ToString();
        val_16[34] = val_16.Length.ToString();
        WordIQManager.DebugLog(logString:  System.String.Format(format:  "Total IQ points gained for level {0} = Total NEWWORDPoints {1} + LevelClearPoints {2}\n    Total NEWWORDPoints:\n        New Words:{3}\n        IQ Points earned, per NEWWORD completed in Level {4} = (BaseNewWordPoint {5} + Word Length * LetterPoint {6}) * NEWWORDMultiplier {7}\n    LevelClearPoints {8} = BaseClearPoints {9} + AdditionalClearPoints {10}\n        BaseClearPoints {11} = Random between BaseClearPoints_min {12} and BaseClearPoints_max {13}\n        AdditionalClearPoints {14} = Complexity Multiplier {15} * Accuracy Multiplier {16} * MaxAdditionalClearPoints {17}\n            Complexity Multiplier {18} = (Complexity {19} / HighestComplexity {20})\n                Complexity {21} = (Number of Letters {22} / 7) * (Number of Answer Words {23} / 18) * (Average Letters of Answers {24} / 7)\n                    If Complexity is > HighestComplexity, set it to HighestComplexity {25}\n            Accuracy Multiplier {26} = (InputAccuracy {27} + ConsecAccuracy {28}) / 2\n                InputAccuracy {29} = (ValidInput {30} / TotalInput {31})\n                ConsecAccuracy {32} = (HighestConsecutiveValidInput {33} / TotalValidWords {34})", args:  val_16));
        return (IQGains)new IQGains(levelClearPts:  val_15, newWordPts:  val_63);
    }
    public void HandleLevelCompleted(System.Collections.Generic.List<string> allValidWords)
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>(collection:  allValidWords);
        int val_3 = val_1.RemoveAll(match:  new System.Predicate<System.String>(object:  this, method:  System.Boolean WordIQManager::<HandleLevelCompleted>b__44_0(string p)));
        if(1152921516845216832 < 1)
        {
                return;
        }
        
        this.AddWordsToHistory(words:  val_1);
    }
    public bool IsNewWord(string word)
    {
        var val_7;
        if((this.WordHistory.ContainsKey(key:  word.m_stringLength)) != false)
        {
                val_7 = (this.WordHistory.Item[word.m_stringLength].Contains(item:  word)) ^ 1;
            return (bool)val_7 & 1;
        }
        
        val_7 = 1;
        return (bool)val_7 & 1;
    }
    public int GetMilestone(float iqPoints)
    {
        var val_4;
        int val_5;
        val_4 = 0;
        label_5:
        System.Single[] val_2 = this.Milestones.Milestones;
        val_5 = val_2.Length;
        if(val_4 >= (val_1.Length << ))
        {
                return (int)val_5 - 1;
        }
        
        if(val_2[0] > iqPoints)
        {
            goto label_4;
        }
        
        val_4 = val_4 + 1;
        if(val_2.Milestones != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_4:
        val_5 = val_4;
        return (int)val_5 - 1;
    }
    public float GetMilestoneAmount(int milestoneIndex)
    {
        return (float)this.Milestones[milestoneIndex << 2];
    }
    public void Hack_AddIQ(float points)
    {
        float val_1 = this.PlayerIQ;
        val_1 = val_1 + points;
        this.PlayerIQ = val_1;
        string val_2 = points.ToString();
        WordIQManager.DebugLog(logString:  System.String.Format(format:  "<color=#FF084A>Hack added IQ points: {0} resulting in current IQ: {1}</color>", arg0:  val_2, arg1:  val_2.PlayerIQ.ToString()));
    }
    public void Hack_SetIQ(float points)
    {
        this.PlayerIQ = points;
        WordIQManager.DebugLog(logString:  System.String.Format(format:  "<color=#E98CCB>Hack set current IQ: {0}</color>", arg0:  this.PlayerIQ.ToString()));
    }
    public int GetTotalFoundWordsCount()
    {
        var val_4;
        Dictionary.Enumerator<TKey, TValue> val_2 = this.WordHistory.GetEnumerator();
        val_4 = 0;
        goto label_2;
        label_4:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_4 = 9733424;
        label_2:
        if(0.MoveNext() == true)
        {
            goto label_4;
        }
        
        0.Dispose();
        return (int)val_4;
    }
    public System.Collections.Generic.List<string> GetFoundWords(int numLetters)
    {
        var val_7;
        if((this.WordHistory.ContainsKey(key:  numLetters)) != false)
        {
                System.Collections.Generic.List<System.String> val_5 = null;
            val_7 = val_5;
            val_5 = new System.Collections.Generic.List<System.String>(collection:  this.WordHistory.Item[numLetters]);
            return (System.Collections.Generic.List<System.String>)val_7;
        }
        
        System.Collections.Generic.List<System.String> val_6 = null;
        val_7 = val_6;
        val_6 = new System.Collections.Generic.List<System.String>();
        return (System.Collections.Generic.List<System.String>)val_7;
    }
    public int GetTotalPossibleFoundWordsCount()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return MonoSingletonSelfGenerating<WADataParser>.Instance.GetAllPossibleWordsCount();
        }
        
        return MonoSingletonSelfGenerating<WordLevelGen>.Instance.GetAllPossibleWordsCount();
    }
    public int GetPossibleWordsCount(int numLetters)
    {
        var val_6;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                int val_3 = MonoSingletonSelfGenerating<WordLevelGen>.Instance.GetPossibleWordsCount(numLetters:  numLetters);
        }
        
        if((MonoSingletonSelfGenerating<WADataParser>.Instance.GetPossibleWordsCount(numLetters:  numLetters)) < 11)
        {
                return (int)val_6;
        }
        
        val_6 = 0;
        return (int)val_6;
    }
    public string DebugLogic()
    {
        null = null;
        return (string)WordIQManager._debugLogHistory;
    }
    private void OnLevelsInitialized()
    {
        this.ManagePlayerData();
    }
    private void ManagePlayerData()
    {
        Player val_1 = App.Player;
        if(val_1 <= 1)
        {
                null.PlayerIQ = WordIQManager.BaseIQ;
        }
        
        int val_4 = this.WordHistory.Count;
        if(val_1 < 2)
        {
                return;
        }
        
        if(val_4 > 0)
        {
                return;
        }
        
        if(val_4.PlayerIQ > WordIQManager.BaseIQ)
        {
                return;
        }
        
        this.PopulateWordHistoryFromLevel(playerLevel:  App.Player);
        this.PlayerIQ = this.CalculateCompensatedIQ(playerLevel:  val_1);
    }
    private void SendWordHistoryToServer()
    {
        var val_6;
        System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>> val_8;
        val_6 = null;
        val_6 = null;
        val_8 = WordIQManager.<>c.<>9__57_0;
        if(val_8 == null)
        {
                System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>> val_3 = null;
            val_8 = val_3;
            val_3 = new System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>>(object:  WordIQManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.IEnumerable<System.String> WordIQManager.<>c::<SendWordHistoryToServer>b__57_0(System.Collections.Generic.List<string> x));
            WordIQManager.<>c.<>9__57_0 = val_8;
        }
        
        this.SendWordsToServer(newWords:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.SelectMany<System.Collections.Generic.List<System.String>, System.String>(source:  this.WordHistory.Values, selector:  val_3)));
    }
    private void SendWordsToServer(System.Collections.Generic.List<string> newWords)
    {
        var val_5;
        this.MergeLists(existingList: ref  this.cachedWordsToSend, wordsToAdd:  newWords);
        if(this.sendingWords != false)
        {
                return;
        }
        
        this.MergeLists(existingList: ref  this.wordsBeingSent, wordsToAdd:  this.cachedWordsToSend);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "words", value:  this.wordsBeingSent.SyncRoot);
        val_5 = null;
        val_5 = null;
        App.networkManager.DoPut(path:  "/api/word/word_iq/", postBody:  val_3, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WordIQManager::<SendWordsToServer>b__61_0(string apicall, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    private void SyncWordHistoryWithServer()
    {
        var val_4;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        Player val_2 = App.Player;
        val_1.Add(key:  "user_id", value:  val_2.id);
        val_4 = null;
        val_4 = null;
        App.networkManager.DoPut(path:  "/api/word/word_iq/", postBody:  val_1, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void WordIQManager::<SyncWordHistoryWithServer>b__62_0(string apicall, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false);
    }
    private void MergeLists(ref System.Collections.Generic.List<string> existingList, System.Collections.Generic.List<string> wordsToAdd)
    {
        System.Collections.Generic.List<System.String> val_2;
        if(true < 1)
        {
                return;
        }
        
        var val_4 = 4;
        do
        {
            val_2 = existingList;
            var val_1 = val_4 - 4;
            if(val_1 >= true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((val_2.Contains(item:  0)) != true)
        {
                val_2 = existingList;
            if(val_1 >= true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_2.Add(item:  0);
        }
        
            val_4 = val_4 + 1;
        }
        while((val_4 - 3) < true);
    
    }
    private void RemoveWordsFromList(ref System.Collections.Generic.List<string> existingList, System.Collections.Generic.List<string> wordsToRemove)
    {
        System.Collections.Generic.List<System.String> val_3;
        if(true < 1)
        {
                return;
        }
        
        var val_5 = 4;
        do
        {
            val_3 = existingList;
            var val_1 = val_5 - 4;
            if(val_1 >= true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((val_3.Contains(item:  0)) != false)
        {
                val_3 = existingList;
            if(val_1 >= true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            bool val_3 = val_3.Remove(item:  0);
        }
        
            val_5 = val_5 + 1;
        }
        while((val_5 - 3) < true);
    
    }
    private void PopulateWordHistoryFromLevel(int playerLevel)
    {
        var val_20;
        System.Func<System.String, System.Int32> val_22;
        var val_23;
        System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32> val_25;
        System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>> val_27;
        int val_28;
        int val_29;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        int val_3 = UnityEngine.Mathf.Min(a:  playerLevel, b:  val_1.MaxPredefinedLevels);
        if(val_3 >= 2)
        {
                var val_20 = 1;
            do
        {
            GameLevel val_5 = MonoSingletonSelfGenerating<WADChapterManager>.Instance.GetGameLevel(playerLevel:  1, language:  "en", bucket:  "A");
            char[] val_6 = new char[1];
            val_6[0] = 124;
            val_1.AddRange(collection:  new System.Collections.Generic.List<System.String>(collection:  val_5.answers.Split(separator:  val_6)));
            val_20 = val_20 + 1;
        }
        while(val_20 < val_3);
        
        }
        
        val_20 = null;
        val_20 = null;
        val_22 = WordIQManager.<>c.<>9__65_0;
        if(val_22 == null)
        {
                System.Func<System.String, System.Int32> val_10 = null;
            val_22 = val_10;
            val_10 = new System.Func<System.String, System.Int32>(object:  WordIQManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordIQManager.<>c::<PopulateWordHistoryFromLevel>b__65_0(string x));
            WordIQManager.<>c.<>9__65_0 = val_22;
        }
        
        val_23 = null;
        val_23 = null;
        val_25 = WordIQManager.<>c.<>9__65_1;
        if(val_25 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32> val_12 = null;
            val_25 = val_12;
            val_12 = new System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32>(object:  WordIQManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordIQManager.<>c::<PopulateWordHistoryFromLevel>b__65_1(System.Linq.IGrouping<int, string> x));
            val_23 = null;
            WordIQManager.<>c.<>9__65_1 = val_25;
        }
        
        val_23 = null;
        val_27 = WordIQManager.<>c.<>9__65_2;
        if(val_27 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>> val_13 = null;
            val_27 = val_13;
            val_13 = new System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>>(object:  WordIQManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.List<System.String> WordIQManager.<>c::<PopulateWordHistoryFromLevel>b__65_2(System.Linq.IGrouping<int, string> x));
            WordIQManager.<>c.<>9__65_2 = val_27;
        }
        
        mem[1152921516848507960] = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.Int32, System.String>, System.Int32, System.Collections.Generic.List<System.String>>(source:  System.Linq.Enumerable.GroupBy<System.String, System.Int32>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  val_1), keySelector:  val_10), keySelector:  val_12, elementSelector:  val_13);
        object[] val_15 = new object[6];
        val_15[0] = "Bucket ";
        Player val_16 = App.Player;
        val_28 = val_15.Length;
        val_15[1] = val_16.playerBucket;
        val_28 = val_15.Length;
        val_15[2] = " Level ";
        val_29 = val_15.Length;
        val_15[3] = playerLevel;
        val_29 = val_15.Length;
        val_15[4] = " ";
        val_15[5] = Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.WordHistory);
        mem[1152921516848507992] = +val_15;
    }
    private float CalculateCompensatedIQ(int playerLevel)
    {
        if(playerLevel >= 2)
        {
                if(this.MaxPredefinedLevels >= playerLevel)
        {
            goto label_2;
        }
        
        }
        
        float val_5 = null.LevelClearIQCompensation_b;
        float val_25 = (float)playerLevel - 1;
        float val_7 = WordIQManager.BaseIQ + null.MaxNEWWORDIQCompensation;
        val_25 = null.LevelClearIQCompensation_a * val_25;
        val_7 = val_7 + val_25;
        val_5 = val_5 + val_7;
        object[] val_8 = new object[6];
        this = val_8;
        this[0] = WordIQManager.BaseIQ.ToString();
        this[1] = X0.MaxNEWWORDIQCompensation.ToString();
        this[2] = X0.LevelClearIQCompensation_a.ToString();
        this[3] = playerLevel.ToString();
        this[4] = X0.LevelClearIQCompensation_b.ToString();
        this[5] = val_5.ToString();
        WordIQManager.DebugLog(logString:  System.String.Format(format:  "Determined compensated IQ score BaseIQ {0} + MaxNEWWORDIQCompensation {1} + LevelClearIQCompensation_a {2} * (playerLevel {3} - 1) + LevelClearIQCompensation_b {4} = {5}", args:  val_8));
        return (float)this.CompensatedIQScoreBelow2502.Item[playerLevel];
        label_2:
        WordIQManager.DebugLog(logString:  System.String.Format(format:  "Determined compensated IQ score from level {0}: {1} [first 2500 levels]", arg0:  playerLevel.ToString(), arg1:  this.CompensatedIQScoreBelow2502.Item[playerLevel].ToString()));
        return (float)this.CompensatedIQScoreBelow2502.Item[playerLevel];
    }
    private void AddWordsToHistory(System.Collections.Generic.List<string> words)
    {
        bool val_1 = true;
        if(val_1 >= 1)
        {
                var val_2 = 0;
            do
        {
            if(val_2 >= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_1 = val_1 + 0;
            this.AddWordToHistory(word:  (true + 0) + 32);
            val_2 = val_2 + 1;
        }
        while(val_2 < val_1);
        
        }
        
        this.SaveWordHistory();
    }
    private void AddWordToHistory(string word)
    {
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_3 = this.WordHistory;
        if((this.WordHistory.ContainsKey(key:  word.m_stringLength)) == false)
        {
            goto label_3;
        }
        
        if((val_3.Item[word.m_stringLength].Contains(item:  word)) == false)
        {
            goto label_6;
        }
        
        return;
        label_3:
        System.Collections.Generic.List<System.String> val_6 = new System.Collections.Generic.List<System.String>();
        val_6.Add(item:  word);
        val_3.Add(key:  word.m_stringLength, value:  val_6);
        return;
        label_6:
        this.WordHistory.Item[word.m_stringLength].Add(item:  word);
    }
    private void SaveWordHistory()
    {
        var val_9;
        int val_10;
        val_9 = 4;
        object[] val_1 = new object[4];
        val_1[0] = "Level ";
        val_10 = val_1.Length;
        val_1[1] = App.Player;
        val_10 = val_1.Length;
        val_1[2] = " ";
        val_1[3] = Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.WordHistory, formatting:  1);
        this.debug_actualWordHistory = +val_1;
        UnityEngine.PlayerPrefs.SetString(key:  "wiq_hist", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.WordHistory));
        bool val_8 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public string Debug_PopulatedHistoryFromLevel()
    {
        return (string)this.debug_populatedHistoryFromLevel;
    }
    public string Debug_ActualWordHistory()
    {
        return (string)this.debug_actualWordHistory;
    }
    public static void DebugLog(string logString)
    {
        var val_4;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        WordIQManager._debugLogHistory = WordIQManager._debugLogHistory + logString + "\n";
    }
    protected float[] get_Milestones()
    {
        GameEcon val_1 = App.getGameEcon;
        return (System.Single[])val_1.WIQ_Milestones;
    }
    public WordIQManager()
    {
        this.cachedWordsToSend = new System.Collections.Generic.List<System.String>();
        this.wordsBeingSent = new System.Collections.Generic.List<System.String>();
        this.debug_populatedHistoryFromLevel = "";
        this.debug_actualWordHistory = "";
        System.Collections.Generic.Dictionary<System.Int32, System.Single> val_3 = new System.Collections.Generic.Dictionary<System.Int32, System.Single>();
        val_3.Add(key:  2, value:  100.0414f);
        val_3.Add(key:  3, value:  100.0829f);
        val_3.Add(key:  4, value:  100.1299f);
    }
    private static WordIQManager()
    {
        WordIQManager._debugLogHistory = "";
    }
    private bool <CalculateCompletedLevelPoints>b__43_0(string p)
    {
        bool val_1 = this.IsNewWord(word:  p);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    private bool <HandleLevelCompleted>b__44_0(string p)
    {
        bool val_1 = this.IsNewWord(word:  p);
        val_1 = (~val_1) & 1;
        return (bool)val_1;
    }
    private void <SendWordsToServer>b__61_0(string apicall, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_5;
        System.Collections.Generic.List<System.String> val_6;
        System.Collections.Generic.List<System.String> val_7;
        if((response == null) || ((response.ContainsKey(key:  "success")) == false))
        {
            goto label_2;
        }
        
        val_5 = this;
        val_6 = this.wordsBeingSent;
        val_7 = 1152921516850502512;
        if(null == null)
        {
            goto label_5;
        }
        
        response.Item["success"].RemoveWordsFromList(existingList: ref  val_7, wordsToRemove:  val_6);
        goto label_6;
        label_2:
        val_5 = this;
        val_6 = this.wordsBeingSent;
        val_7 = 1152921516850502512;
        label_5:
        this.MergeLists(existingList: ref  val_7, wordsToAdd:  val_6);
        label_6:
        val_6.Clear();
        this.sendingWords = false;
    }
    private void <SyncWordHistoryWithServer>b__62_0(string apicall, System.Collections.Generic.Dictionary<string, object> response)
    {
        var val_11;
        var val_12;
        var val_13;
        System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>> val_15;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = response;
        if(val_11 == null)
        {
                return;
        }
        
        val_11 = "word_history";
        if((val_11.ContainsKey(key:  "word_history")) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  val_11.Item["word_history"]);
        val_12 = 0;
        this.AddWordsToHistory(words:  null);
        val_13 = null;
        val_13 = null;
        val_15 = WordIQManager.<>c.<>9__62_1;
        if(val_15 == null)
        {
                System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>> val_6 = null;
            val_15 = val_6;
            val_6 = new System.Func<System.Collections.Generic.List<System.String>, System.Collections.Generic.IEnumerable<System.String>>(object:  WordIQManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.IEnumerable<System.String> WordIQManager.<>c::<SyncWordHistoryWithServer>b__62_1(System.Collections.Generic.List<string> x));
            WordIQManager.<>c.<>9__62_1 = val_15;
        }
        
        val_11 = 1152921510375394352;
        if(1152921516823878448 < 1)
        {
                return;
        }
        
        this.SendWordsToServer(newWords:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Except<System.String>(first:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.SelectMany<System.Collections.Generic.List<System.String>, System.String>(source:  this.WordHistory.Values, selector:  val_6)), second:  null)));
    }

}

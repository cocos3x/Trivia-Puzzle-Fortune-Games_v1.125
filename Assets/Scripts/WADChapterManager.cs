using UnityEngine;
public class WADChapterManager : MonoSingletonSelfGenerating<WADChapterManager>
{
    // Fields
    public const int LEVEL_SKIP_LEVEL_LIMIT = 300;
    private const string PP_INVALID_LEVELS = "skipped_levels";
    private const string PP_SKIP_CURRENT_LEVEL_INFO = "skip_current_level_info";
    public System.Action OnLevelCompleted;
    protected string levelWord;
    private System.DateTime levelStartStamp;
    private bool levelCompletedInLessThanAverage;
    private int levelCompletionInMillis;
    private string debugFetchFromLevelSkipStatus;
    private System.Collections.Generic.List<SkippedLevel> levelsToSkip;
    private System.Collections.Generic.Dictionary<string, object> currentSkipLevelStatus;
    private const string pref_pl_vars_key = "wadwut_pl_vars";
    public const string pref_played_words_key = "wadwut_pw_vars";
    public const string pref_chapter_levels_curve_v = "pp_chapter_level_curve_v";
    private const int LevelCurveVersion = 3;
    private System.Collections.Generic.List<int> plv_chapterWordLengths;
    private System.Collections.Generic.List<string> plv_playedWords;
    
    // Properties
    public int MaxPredefinedLevels { get; }
    public static bool ChapterComplete { get; }
    public System.Collections.Generic.List<SkippedLevel> DebugLevelsToSkip { get; }
    public System.Collections.Generic.Dictionary<string, object> DebugCurrentLevelSkipStatus { get; }
    public string DebugFetchFromLevelSkipStatus { get; set; }
    public bool LevelCompletedInLessThanAverage { get; }
    private string CurrentLaguage { get; }
    private int BeginDynamicLevels { get; }
    private System.Collections.Generic.List<SkippedLevel> LevelsToSkip { get; set; }
    private System.Collections.Generic.Dictionary<string, object> CurrentLevelSkipStatus { get; set; }
    
    // Methods
    public int get_MaxPredefinedLevels()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                return (int)MonoSingletonSelfGenerating<WADataParser>.Instance.CurrentLevelCurveGameLevels;
        }
        
        return MonoSingletonSelfGenerating<WordLevelGen>.Instance.DefinedLevelCount;
    }
    public static bool get_ChapterComplete()
    {
        return ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player);
    }
    public System.Collections.Generic.List<SkippedLevel> get_DebugLevelsToSkip()
    {
        return this.LevelsToSkip;
    }
    public System.Collections.Generic.Dictionary<string, object> get_DebugCurrentLevelSkipStatus()
    {
        return this.CurrentLevelSkipStatus;
    }
    public string get_DebugFetchFromLevelSkipStatus()
    {
        return (string)this.debugFetchFromLevelSkipStatus;
    }
    public void set_DebugFetchFromLevelSkipStatus(string value)
    {
        this.debugFetchFromLevelSkipStatus = value;
    }
    public bool get_LevelCompletedInLessThanAverage()
    {
        return (bool)this.levelCompletedInLessThanAverage;
    }
    private string get_CurrentLaguage()
    {
        GameBehavior val_1 = App.getBehavior;
        return val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
    }
    private int get_BeginDynamicLevels()
    {
        return System.Math.Max(val1:  3, val2:  this.MaxPredefinedLevels);
    }
    private System.Collections.Generic.List<SkippedLevel> get_LevelsToSkip()
    {
        string val_5;
        var val_6;
        System.Collections.Generic.List<SkippedLevel> val_12;
        var val_13;
        val_12 = this.levelsToSkip;
        if(val_12 != null)
        {
                return val_12;
        }
        
        this.levelsToSkip = new System.Collections.Generic.List<SkippedLevel>();
        List.Enumerator<T> val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "skipped_levels", defaultValue:  "[]")).GetEnumerator();
        label_13:
        if(val_6.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_5 != 0)
        {
                val_13 = null;
            if(val_5 != val_13)
        {
                throw new NullReferenceException();
        }
        
        }
        
        SkippedLevel val_8 = new SkippedLevel();
        val_13 = 0;
        object val_9 = MiniJSON.Json.Deserialize(json:  val_5);
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = 0;
        val_8.Decode(encoded:  null);
        if(this.levelsToSkip == null)
        {
                throw new NullReferenceException();
        }
        
        this.levelsToSkip.Add(item:  val_8);
        goto label_13;
        label_5:
        val_6.Dispose();
        val_12 = this.levelsToSkip;
        return val_12;
    }
    private void set_LevelsToSkip(System.Collections.Generic.List<SkippedLevel> value)
    {
        this.levelsToSkip = value;
        UnityEngine.PlayerPrefs.SetString(key:  "skipped_levels", value:  MiniJSON.Json.Serialize(obj:  value));
    }
    private System.Collections.Generic.Dictionary<string, object> get_CurrentLevelSkipStatus()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = this.currentSkipLevelStatus;
        if(val_4 != null)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>);
        }
        
        if((MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "skip_current_level_info", defaultValue:  "{}"))) != null)
        {
                val_4 = 0;
        }
        
        this.currentSkipLevelStatus = ;
        return (System.Collections.Generic.Dictionary<System.String, System.Object>);
    }
    private void set_CurrentLevelSkipStatus(System.Collections.Generic.Dictionary<string, object> value)
    {
        this.currentSkipLevelStatus = value;
        UnityEngine.PlayerPrefs.SetString(key:  "skip_current_level_info", value:  MiniJSON.Json.Serialize(obj:  value));
    }
    public static int GetCurrentChapter()
    {
        return WADChapterManager.GetChapter(level:  App.Player);
    }
    public static int GetChapter(int level)
    {
        return ChapterBookLogic.GetCurrentCumulativeChapter(playerLevel:  level);
    }
    public static int GetChapterWithinBook(int level)
    {
        return ChapterBookLogic.GetCurrentChapter(playerLevel:  level);
    }
    public static int GetNumLevelsInCurrentChapter()
    {
        return ChapterBookLogic.GetLevelsPerChapter(playerLevel:  App.Player);
    }
    public static int GetCurrentLevelWithinChapter(int level = -1)
    {
        return ChapterBookLogic.GetLevelWithinChapter(playerLevel:  App.Player);
    }
    public static int GetCurrentChapterFirstLevel()
    {
        return ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  App.Player);
    }
    public static int GetCurrentChapterLastLevel()
    {
        return ChapterBookLogic.GetLastLevelOfChapter(playerLevel:  App.Player);
    }
    public bool FinishedContent(int toCompare)
    {
        return (bool)(this.MaxPredefinedLevels < toCompare) ? 1 : 0;
    }
    public GameLevel GetGameLevelForPlayerLevelFromChapter(int playerLevel = -1, bool checkLevelSkip = False)
    {
        var val_125;
        GameplayBehavior val_128;
        var val_130;
        bool val_131;
        var val_132;
        var val_133;
        string val_134;
        int val_135;
        var val_136;
        System.Predicate<GameLevel> val_138;
        var val_139;
        System.Func<GameLevel, System.Single> val_141;
        int val_143;
        int val_144;
        var val_145;
        int val_146;
        var val_147;
        var val_149;
        GameLevel val_151;
        val_125 = playerLevel;
        int val_1 = WADChapterManager.GetCurrentChapter();
        int val_2 = WADChapterManager.GetCurrentLevelWithinChapter(level:  val_1);
        var val_121 = val_2;
        if((val_125 & 2147483648) != 0)
        {
                Player val_3 = App.Player;
            if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
            val_125 = val_3;
        }
        
        int val_4 = val_3.BeginDynamicLevels;
        if(val_125 <= val_4)
        {
            goto label_5;
        }
        
        var val_122 = 1152921504985280512;
        DynamicLevelBuildParams val_5 = new DynamicLevelBuildParams();
        if(this.plv_chapterWordLengths == null)
        {
                throw new NullReferenceException();
        }
        
        val_121 = val_121 - 1;
        if(val_122 <= val_121)
        {
                val_128 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_122 = val_122 + (val_121 << 2);
        mem[1152921518053609600] = 0;
        .levelWordLength = (1152921504985280512 + ((val_2 - 1)) << 2) + 32;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_6.<gameplayBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_128 & 1) == 0)
        {
            goto label_13;
        }
        
        WordLevelGen val_7 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        GameLevel val_8 = val_7.BuildDynamicLevel(wordLength:  (DynamicLevelBuildParams)[1152921518053609584].levelWordLength, wordCount:  3, maxWordCount:  0, dailyChallenge:  false);
        goto label_17;
        label_5:
        int val_9 = val_4.MaxPredefinedLevels;
        if(val_125 <= val_9)
        {
            goto label_18;
        }
        
        val_130 = 0;
        goto label_19;
        label_18:
        string val_10 = val_9.CurrentLaguage;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_11 = val_10.Equals(value:  "en");
        System.Text.StringBuilder val_12 = new System.Text.StringBuilder();
        val_131 = 0;
        if(val_11 != false)
        {
                if((val_125 - 6) <= 293)
        {
                if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
            val_131 = val_16.levelSkipEnabled;
        }
        
        }
        
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_17 = val_11;
        System.Text.StringBuilder val_18 = val_12.AppendFormat(format:  "Are we outside of FTUX? {0}\n", arg0:  (val_125 > 5) ? 1 : 0);
        System.Text.StringBuilder val_19 = val_12.AppendFormat(format:  "Player Level ({0}) is less than {1}? {2}\n", arg0:  val_3, arg1:  300, arg2:  (val_125 < 300) ? 1 : 0);
        System.Text.StringBuilder val_20 = val_12.AppendFormat(format:  "Is it in English? {0}\n", arg0:  val_17);
        val_132 = 1152921504884269056;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_23 = val_12.AppendFormat(format:  "lws knob enabled for bucket {0}? {1}\n", arg0:  val_21.playerBucket, arg1:  val_22.levelSkipEnabled);
        System.Text.StringBuilder val_24 = val_12.AppendFormat(format:  "Did we fetch from Level Skip? {0}\n", arg0:  val_131);
        this.debugFetchFromLevelSkipStatus = val_12;
        if(val_131 == false)
        {
            goto label_31;
        }
        
        var val_25 = (this.levelCompletedInLessThanAverage == true) ? 1 : 0;
        goto label_32;
        label_13:
        WADataParser val_26 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        label_17:
        val_130 = val_26.BuildDynamicLevel(param:  val_5);
        if(val_130 == null)
        {
                throw new NullReferenceException();
        }
        
        label_190:
        val_134 = val_3.ToString();
        goto label_37;
        label_31:
        val_133 = 0;
        label_32:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_29.<gameplayBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        val_133 = val_133 & checkLevelSkip;
        GameplayBehavior val_30 = val_128 ^ 1;
        if((val_133 & val_30) != true)
        {
            goto label_68;
        }
        
        WADataParser val_33 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<GameLevel> val_35 = val_33.GetFeatureLevelCurve(bucket:  "E");
        System.Collections.Generic.Dictionary<System.String, System.Object> val_36 = this.CurrentLevelSkipStatus;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_36.ContainsKey(key:  "index")) == false)
        {
            goto label_51;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_38 = this.CurrentLevelSkipStatus;
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_39 = val_38.Item["index"];
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_135 = (System.Int32.Parse(s:  val_39, style:  511)) + 1;
        if(val_35 != null)
        {
            goto label_54;
        }
        
        throw new NullReferenceException();
        label_51:
        val_135 = val_3 - 1;
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        label_54:
        System.Collections.Generic.List<TSource> val_45 = System.Linq.Enumerable.ToList<GameLevel>(source:  System.Linq.Enumerable.Where<GameLevel>(source:  val_35.GetRange(index:  val_135, count:  val_3 - val_135), predicate:  new System.Func<GameLevel, System.Boolean>(object:  this, method:  System.Boolean WADChapterManager::<GetGameLevelForPlayerLevelFromChapter>b__42_0(GameLevel lvl))));
        val_136 = null;
        val_136 = null;
        val_138 = WADChapterManager.<>c.<>9__42_1;
        if(val_138 == null)
        {
                System.Predicate<GameLevel> val_46 = null;
            val_138 = val_46;
            val_46 = new System.Predicate<GameLevel>(object:  WADChapterManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WADChapterManager.<>c::<GetGameLevelForPlayerLevelFromChapter>b__42_1(GameLevel lvl));
            WADChapterManager.<>c.<>9__42_1 = val_138;
        }
        
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_139 = null;
        val_139 = null;
        val_141 = WADChapterManager.<>c.<>9__42_2;
        if(val_141 == null)
        {
                System.Func<GameLevel, System.Single> val_48 = null;
            val_141 = val_48;
            val_48 = new System.Func<GameLevel, System.Single>(object:  WADChapterManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Single WADChapterManager.<>c::<GetGameLevelForPlayerLevelFromChapter>b__42_2(GameLevel lvl));
            WADChapterManager.<>c.<>9__42_2 = val_141;
        }
        
        if((MoreLinq.MinBy<GameLevel, System.Single>(source:  val_45.FindAll(match:  val_46), selector:  val_48)) != null)
        {
                System.Collections.Generic.List<SkippedLevel> val_50 = this.LevelsToSkip;
            SkippedLevel val_51 = null;
            float val_123 = 1000f;
            val_123 = val_49.avgCompletionTime * val_123;
            val_123 = (val_123 == Infinityf) ? (-(double)val_123) : ((double)val_123);
            val_51 = new SkippedLevel(word:  val_49.word, index:  val_49.levelIndex, avgCompletionTime:  (int)val_123, skipTriggerCompletionTime:  this.levelCompletionInMillis);
            if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
            val_50.Insert(index:  0, item:  val_51);
            this.LevelsToSkip = this.LevelsToSkip;
            if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
            int val_124 = val_53.levelsRemoved;
            val_124 = val_124 + 1;
            val_53.levelsRemoved = val_124;
        }
        
        label_68:
        if((((val_131 == true) ? 1 : 0) & val_30) == null)
        {
            goto label_73;
        }
        
        WADChapterManager.<>c__DisplayClass42_1 val_55 = new WADChapterManager.<>c__DisplayClass42_1();
        WADataParser val_56 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        .levelSkipLevels = val_56.GetFeatureLevelCurve(bucket:  "E");
        System.Collections.Generic.Dictionary<System.String, System.Object> val_59 = this.CurrentLevelSkipStatus;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_60 = val_59.ContainsKey(key:  "index");
        if(val_60 == false)
        {
            goto label_83;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_61 = this.CurrentLevelSkipStatus;
        if(val_61 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_62 = val_61.Item["index"];
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_63 = System.Int32.Parse(s:  val_62, style:  511);
        goto label_86;
        label_73:
        val_143 = val_1;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_64.<gameplayBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_128 & 1) == 0)
        {
            goto label_91;
        }
        
        WordLevelGen val_65 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
        if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
        val_144 = val_3 - 1;
        val_145 = val_65.GetDefinedLevel(index:  val_144);
        goto label_101;
        label_91:
        WADataParser val_67 = MonoSingletonSelfGenerating<WADataParser>.Instance;
        if(val_67 == null)
        {
                throw new NullReferenceException();
        }
        
        val_144 = 0;
        if(val_67.CurrentLevelCurveGameLevels == null)
        {
                throw new NullReferenceException();
        }
        
        Player val_125 = val_3;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_125 = val_125 + ((val_125 - 1) << 3);
        val_145 = mem[(val_3 + ((val_3 - 1)) << 3) + 32];
        val_145 = (val_3 + ((val_3 - 1)) << 3) + 32;
        goto label_101;
        label_83:
        val_146 = val_3 - 1;
        label_86:
        .levelSkipStartIndex = val_146;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_70 = this.CurrentLevelSkipStatus;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_60 & (val_70.ContainsKey(key:  "status"))) == false)
        {
            goto label_109;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_73 = this.CurrentLevelSkipStatus;
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        object val_74 = val_73.Item["status"];
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_74.Equals(value:  "completed")) == false)
        {
            goto label_109;
        }
        
        label_110:
        int val_126 = (WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex;
        val_126 = val_126 + 1;
        .levelSkipStartIndex = val_126;
        if(((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipLevels) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_126 >= ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipLevels))
        {
            goto label_109;
        }
        
        var val_127 = null;
        val_128 = this.LevelsToSkip;
        if((System.Linq.Enumerable.Any<SkippedLevel>(source:  val_128, predicate:  new System.Func<SkippedLevel, System.Boolean>(object:  val_55, method:  System.Boolean WADChapterManager.<>c__DisplayClass42_1::<GetGameLevelForPlayerLevelFromChapter>b__4(SkippedLevel skippedLevel)))) == true)
        {
            goto label_110;
        }
        
        label_109:
        if(((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipLevels) == null)
        {
                throw new NullReferenceException();
        }
        
        val_143 = val_1;
        val_132 = 1152921504884269056;
        if(val_127 <= ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_127 = val_127 + (((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3);
        val_145 = mem[(null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32];
        val_145 = (null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_79 = this.CurrentLevelSkipStatus;
        if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
        val_79.set_Item(key:  "index", value:  (WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_80 = this.CurrentLevelSkipStatus;
        if(val_80 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80.set_Item(key:  "status", value:  "started");
        val_144 = this.CurrentLevelSkipStatus;
        this.CurrentLevelSkipStatus = val_144;
        label_101:
        if(val_17 == false)
        {
            goto label_119;
        }
        
        Player val_82 = App.Player;
        if(val_82 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_82 <= WGFTUXManager.FTUX_LEVEL_LIMIT)
        {
            goto label_119;
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_84.<gameplayBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_128 & 1) == 0)
        {
            goto label_124;
        }
        
        label_119:
        if(val_145 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_134 = val_2.ToString();
        val_130 = val_145;
        label_37:
        val_130.levelName = val_134;
        label_19:
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_86.<metaGameBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_128 & 1) != 0)
        {
                DifficultySettingManager val_87 = MonoSingleton<DifficultySettingManager>.Instance;
            if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_87.IsPlayingChallengingLevels != false)
        {
                if(val_130 != 0)
        {
                if(((null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32 + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
            var val_128 = (null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32 + 64 + 16;
            val_128 = ((val_128 + 1) < 0) ? (val_128 + 2) : (val_128 + 1);
            val_147 = val_128 >> 1;
        }
        else
        {
                val_147 = 0;
        }
        
            if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
            val_128 = val_91.<gameplayBehavior>k__BackingField;
            if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
            if((val_128 & 1) != 0)
        {
                WordLevelGen val_92 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            if(val_92 == null)
        {
                throw new NullReferenceException();
        }
        
            GameLevel val_93 = val_92.BuildChallengingLevelForNormalProgression(levelWordLength:  0);
        }
        else
        {
                WADataParser val_94 = MonoSingletonSelfGenerating<WADataParser>.Instance;
            if(val_94 == null)
        {
                throw new NullReferenceException();
        }
        
            GameLevel val_95 = val_94.BuildChallengingLevelForNormalProgression(retries:  0);
        }
        
            if(val_130 == 0)
        {
                GameLevel val_96 = null;
            val_149 = val_96;
            val_96 = new GameLevel();
        }
        
        }
        
        }
        
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                if(((val_95 == 0) ? (val_149) : (val_95)) == 0)
        {
                GameLevel val_100 = null;
            val_151 = val_100;
            val_100 = new GameLevel();
        }
        
            WordGameEventsController val_101 = MonoSingleton<WordGameEventsController>.Instance;
            if(val_101 == null)
        {
                throw new NullReferenceException();
        }
        
            GameLevel val_102 = val_101.checkEventForGameLevel(refLevel:  val_100);
            var val_103 = (val_102 == 0) ? (val_151) : (val_102);
        }
        
        if(val_103 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_128 = mem[val_102 == null ? val_151 : val_102 + 64];
        val_128 = val_102 == null ? val_151 : val_102 + 64;
        if(val_128 == 0)
        {
                throw new NullReferenceException();
        }
        
        char[] val_105 = new char[1];
        if(val_105 == null)
        {
                throw new NullReferenceException();
        }
        
        val_105[0] = 124;
        if((val_102 == null ? val_151 : val_102 + 72) == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_107 = new System.Collections.Generic.List<System.String>(collection:  val_102 == null ? val_151 : val_102 + 72.Split(separator:  val_105));
        char[] val_108 = new char[1];
        if(val_108 == null)
        {
                throw new NullReferenceException();
        }
        
        val_108[0] = 124;
        if((val_102 == null ? val_151 : val_102 + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_107 == null)
        {
                throw new NullReferenceException();
        }
        
        val_107.AddRange(collection:  new System.Collections.Generic.List<System.String>(collection:  val_102 == null ? val_151 : val_102 + 80.Split(separator:  val_108)));
        List.Enumerator<T> val_111 = val_107.GetEnumerator();
        label_174:
        if(0.MoveNext() == false)
        {
            goto label_169;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_128.Replace(oldValue:  "|", newValue:  "")) == null)
        {
                throw new NullReferenceException();
        }
        
        if(11993091 != val_104.m_stringLength)
        {
            goto label_174;
        }
        
        this.plv_playedWords.Add(item:  0);
        goto label_174;
        label_169:
        0.Dispose();
        return (GameLevel)val_103;
        label_124:
        BuildLevelBasedOnWordParams val_113 = new BuildLevelBasedOnWordParams();
        if(val_145 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_113 == null)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921518054076596] = (val_143 > 10) ? 1 : 0;
        .levelWord = (null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32 + 64;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_128 = val_115.<gameplayBehavior>k__BackingField;
        if(val_128 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_128 & 1) != 0)
        {
                WordLevelGen val_116 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            if(val_116 == null)
        {
                throw new NullReferenceException();
        }
        
            GameLevel val_117 = val_116.BuildLevelBasedOnWord(daWord:  (BuildLevelBasedOnWordParams)[1152921518054076560].levelWord, maxWordCount:  0, keepWord:  0);
        }
        else
        {
                WADataParser val_118 = MonoSingletonSelfGenerating<WADataParser>.Instance;
            if(val_118 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if((val_118.BuildLevelBasedOnWord(param:  val_113)) == null)
        {
                throw new NullReferenceException();
        }
        
        val_119.avgCompletionTime = (null + ((WADChapterManager.<>c__DisplayClass42_1)[1152921518053806192].levelSkipStartIndex) << 3) + 32 + 232;
        string val_120 = val_2.ToString();
        goto label_190;
    }
    public GameLevel GetGameLevel(int playerLevel)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return MonoSingletonSelfGenerating<WordLevelGen>.Instance.GetDefinedLevel(index:  playerLevel - 1);
        }
        
        var val_6 = 1152921515417468368;
        System.Collections.Generic.List<GameLevel> val_5 = MonoSingletonSelfGenerating<WADataParser>.Instance.CurrentLevelCurveGameLevels;
        if(val_6 <= playerLevel)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (playerLevel << 3);
        return (GameLevel)(1152921515417468368 + (playerLevel) << 3) + 32;
    }
    public GameLevel GetGameLevel(int playerLevel, string language, string bucket)
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                return MonoSingletonSelfGenerating<WordLevelGen>.Instance.GetDefinedLevel(index:  playerLevel - 1);
        }
        
        var val_6 = 1152921515417468368;
        LevelCurve val_5 = MonoSingletonSelfGenerating<WADataParser>.Instance.GetLevelCurve(lang:  language, bucket:  bucket);
        if(val_6 <= playerLevel)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + (playerLevel << 3);
        return (GameLevel)(1152921515417468368 + (playerLevel) << 3) + 32;
    }
    public void LevelWasCompleted()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) >= (val_1.<metaGameBehavior>k__BackingField.MaxPredefinedLevels))
        {
                this.PrepPlayerVarsForNewChapter();
        }
        
        this.SaveData();
        if(this.OnLevelCompleted == null)
        {
                return;
        }
        
        this.OnLevelCompleted.Invoke();
    }
    public void SaveData()
    {
        this.StorePlayerVars();
        App.Player.SaveState();
        CPlayerPrefs.Save();
    }
    public void TrackLevelSkipLevelStart(string levelWord)
    {
        this.levelWord = levelWord;
        System.DateTime val_1 = System.DateTime.Now;
        this.levelStartStamp = val_1;
        this.levelCompletedInLessThanAverage = false;
    }
    public void TrackLevelSkipLevelComplete(float averageLevelWordCompletionTime)
    {
        System.DateTime val_1 = System.DateTime.Now;
        float val_8 = 1000f;
        val_8 = averageLevelWordCompletionTime * val_8;
        val_8 = (val_8 == Infinityf) ? (-(double)val_8) : ((double)val_8);
        System.TimeSpan val_2 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = this.levelStartStamp});
        double val_3 = val_2._ticks.TotalMilliseconds;
        val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
        this.levelCompletionInMillis = (int)val_3;
        bool val_5 = ((int)val_3 < (int)val_8) ? 1 : 0;
        val_5 = val_5 & (((int)val_8 > 0) ? 1 : 0);
        this.levelCompletedInLessThanAverage = val_5;
        this.CurrentLevelSkipStatus.set_Item(key:  "status", value:  "completed");
        this.CurrentLevelSkipStatus = this.CurrentLevelSkipStatus;
    }
    private string GetCurveForBucket(string bucket)
    {
        return "E";
    }
    private void LoadPlayerVars()
    {
        string val_17;
        var val_18;
        var val_21;
        var val_22;
        string val_23;
        var val_24;
        val_21 = 1152921504874684416;
        if(((CPlayerPrefs.HasKey(key:  "wadwut_pl_vars")) == false) || ((UnityEngine.PlayerPrefs.GetInt(key:  "pp_chapter_level_curve_v", defaultValue:  1)) != 3))
        {
            goto label_4;
        }
        
        string val_3 = CPlayerPrefs.GetString(key:  "wadwut_pl_vars", defaultValue:  "");
        if((val_3 == null) || ((System.String.op_Inequality(a:  val_3, b:  "")) == false))
        {
            goto label_9;
        }
        
        this.DeserializePlayerVars(data:  val_3);
        goto label_9;
        label_4:
        System.Collections.Generic.List<System.Int32> val_5 = new System.Collections.Generic.List<System.Int32>();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  6);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        val_5.Add(item:  7);
        this.plv_chapterWordLengths = val_5;
        val_22 = 1152921504884269056;
        label_18:
        Player val_6 = App.Player;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(W26 >= (ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_6)))
        {
            goto label_16;
        }
        
        if(this.plv_chapterWordLengths == null)
        {
                throw new NullReferenceException();
        }
        
        this.plv_chapterWordLengths.Add(item:  System.Linq.Enumerable.LastOrDefault<System.Int32>(source:  this.plv_chapterWordLengths));
        if(this.plv_chapterWordLengths != null)
        {
            goto label_18;
        }
        
        throw new NullReferenceException();
        label_16:
        UnityEngine.PlayerPrefs.SetInt(key:  "pp_chapter_level_curve_v", value:  3);
        bool val_9 = PrefsSerializationManager.SavePlayerPrefs();
        label_9:
        if((CPlayerPrefs.HasKey(key:  "wadwut_pw_vars")) == false)
        {
            goto label_23;
        }
        
        val_23 = CPlayerPrefs.GetString(key:  "wadwut_pw_vars", defaultValue:  "");
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
        object val_13 = MiniJSON.Json.Deserialize(json:  val_23);
        goto label_30;
        label_23:
        label_49:
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
        return;
        label_30:
        List.Enumerator<T> val_16 = GetEnumerator();
        val_21 = 1152921510211410768;
        val_22 = 1152921509851232320;
        label_35:
        if(val_18.MoveNext() == false)
        {
            goto label_32;
        }
        
        if(val_17 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_23 = this.plv_playedWords;
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23.Add(item:  val_17);
        goto label_35;
        label_32:
        val_23 = 0;
        val_18.Dispose();
        if(val_23 != 0)
        {
                throw val_23;
        }
        
        return;
        label_50:
        val_24 = val_23;
        if(0 != 1)
        {
            goto label_47;
        }
        
        if((null & 1) == 0)
        {
            goto label_48;
        }
        
        goto label_49;
        label_48:
        mem[8] = null;
        goto label_50;
        label_47:
    }
    private void StorePlayerVars()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) >= (val_1.<metaGameBehavior>k__BackingField.MaxPredefinedLevels))
        {
                CPlayerPrefs.SetString(key:  "wadwut_pl_vars", val:  this.SerializePlayerVars());
        }
        
        CPlayerPrefs.SetString(key:  "wadwut_pw_vars", val:  MiniJSON.Json.Serialize(obj:  this.plv_playedWords));
    }
    private string SerializePlayerVars()
    {
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        var val_5 = 0;
        do
        {
            if(val_5 != 0)
        {
                System.Text.StringBuilder val_2 = val_1.Append(value:  "|");
        }
        
            if(val_5 >= 1152921504630968320)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            System.Text.StringBuilder val_4 = val_1.Append(value:  System.Boolean System.Array::InternalArray__ICollection_Contains<TMPro.TMP_WordInfo>(TMPro.TMP_WordInfo item).ToString());
            val_5 = val_5 + 1;
        }
        while(val_5 < 19);
        
        return (string)val_1;
    }
    private void DeserializePlayerVars(string data)
    {
        char[] val_1 = new char[1];
        val_1[0] = 124;
        var val_4 = 0;
        do
        {
            this.plv_chapterWordLengths.set_Item(index:  0, value:  System.Int32.Parse(s:  null));
            val_4 = val_4 + 1;
        }
        while(val_4 < 19);
    
    }
    private void PrepPlayerVarsForNewChapter()
    {
        PluginExtension.Shuffle<System.Int32>(list:  this.plv_chapterWordLengths, seed:  new System.Nullable<System.Int32>() {HasValue = false});
    }
    public void Debug_PrintPlayerVars()
    {
        UnityEngine.Debug.LogError(message:  "word lengths array: "("word lengths array: ") + PrettyPrint.printJSON(obj:  this.plv_chapterWordLengths, types:  false, singleLineOutput:  true)(PrettyPrint.printJSON(obj:  this.plv_chapterWordLengths, types:  false, singleLineOutput:  true)));
    }
    public WADChapterManager()
    {
        this.levelWord = System.String.alignConst;
        this.debugFetchFromLevelSkipStatus = System.String.alignConst;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  6);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        val_1.Add(item:  7);
        this.plv_chapterWordLengths = val_1;
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
    }
    private bool <GetGameLevelForPlayerLevelFromChapter>b__42_0(GameLevel lvl)
    {
        .lvl = lvl;
        bool val_4 = System.Linq.Enumerable.Any<SkippedLevel>(source:  this.LevelsToSkip, predicate:  new System.Func<SkippedLevel, System.Boolean>(object:  new WADChapterManager.<>c__DisplayClass42_0(), method:  System.Boolean WADChapterManager.<>c__DisplayClass42_0::<GetGameLevelForPlayerLevelFromChapter>b__3(SkippedLevel skipped)));
        val_4 = (~val_4) & 1;
        return (bool)val_4;
    }

}

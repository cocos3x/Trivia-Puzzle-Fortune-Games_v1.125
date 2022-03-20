using UnityEngine;
public class WADataParser : MonoSingletonSelfGenerating<WADataParser>
{
    // Fields
    private CrosswordCreator.Crossword.CrosswordGenerator this_generator;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> CommonWordsByLength;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> UncommonWordsByLength;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> RareWordsByLength;
    public static string debug_lastReqResult;
    public static string debug_lastReqDetermination;
    public static string debug_uncommonInAnswers;
    public static string debug_uncommonInRequiredExtra;
    public static System.Collections.Generic.List<string> debug_extraRequiredWords;
    private System.Collections.Generic.List<string> usedWordThisSession;
    private System.Collections.Generic.List<int> usedSpanishLevels;
    private int maxTries;
    private int minSpanishLevel;
    private static bool _QAHACK_NoExtraRequired;
    private int maxPredefinedLevels;
    private int builtInChapters;
    private const int levelsPerChapter = 20;
    private const string PP_Saved = "PP_SavedDataOnce";
    private string[] buckets;
    private string[] featureBuckets;
    private static string Debug_RanOutWhenTranslating;
    private static string Debug_FinishedContent;
    private static string QAhackedWord;
    private bool initialized;
    private bool initializing;
    private int version;
    private bool hasSynched;
    private const string PP_HasSynched = "PP_123j86_Sync";
    public const int LEVEL_GEN_VERSION = 1;
    public System.Action OnWADataParseInit;
    private const string pref_pl_vars_key = "wadwut_pl_vars";
    public const string pref_played_words_key = "wadwut_pw_vars";
    public const string pref_level_gen_version = "wadwut_lg_version";
    private System.Collections.Generic.List<int> plv_chapterWordLengths;
    private System.Collections.Generic.List<string> plv_playedWords;
    private const int CurrentLevelGenVersion = 3;
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> _AllKnownWords;
    private int allPossibleWords;
    private System.Collections.Generic.List<WADataParser.LevelCurve> knownLevelCurves;
    private System.Collections.Generic.List<WADataParser.LevelCurve> featureLevelCurves;
    
    // Properties
    public System.Collections.Generic.List<GameLevel> CurrentLevelCurveGameLevels { get; set; }
    public static bool QAHACK_NoExtraRequired { get; set; }
    public int MaxPredefinedLevels { get; set; }
    public string PathToGameResources { get; }
    public static string QAHACK_RanOutReason { get; }
    public static string QAHACK_FinishedReason { get; }
    public static string QAHACK_SetDesiredLevelGenWord { get; set; }
    public bool HasInitialized { get; }
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> AllKnownWords { get; }
    
    // Methods
    public System.Collections.Generic.List<bool> GetAllowedLetters(int level, int lettersSize, System.Collections.Generic.List<string> lettersArray, System.Collections.Generic.List<int> indexes)
    {
        int val_39 = lettersSize;
        if((MonoSingleton<DailyChallengeTutorialManager>.Instance) != 0)
        {
                DailyChallengeTutorialManager val_3 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
            if(val_3._GameplayTutorialActive != false)
        {
                return MonoSingleton<DailyChallengeTutorialManager>.Instance.GetAllowedLettersForPan(level:  level, lettersSize:  val_39, lettersArray:  lettersArray, indexes:  indexes);
        }
        
        }
        
        System.Collections.Generic.List<System.Boolean> val_5 = new System.Collections.Generic.List<System.Boolean>();
        val_5.Add(item:  false);
        val_5.Add(item:  false);
        val_5.Add(item:  false);
        if(((MonoSingleton<WordGameEventsController>.Instance.ActivelyPlayingEventGameMode()) != true) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true))
        {
                if(WGFTUXManager.CanShow != false)
        {
                System.Collections.Generic.List<System.String> val_12 = WordRegion.instance.GetCompletedWords();
        }
        
        }
        
        System.Collections.Generic.List<System.Boolean> val_13 = new System.Collections.Generic.List<System.Boolean>();
        if(val_39 < 1)
        {
                return val_13;
        }
        
        do
        {
            val_13.Add(item:  true);
            val_39 = val_39 - 1;
        }
        while(val_39 != 1);
        
        return val_13;
        label_49:
        if("es" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44270704 <= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223372036799429488].Equals(value:  "U")) == true)
        {
            goto label_44;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_40 = -9223372036799429520;
        if(val_40 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_40 = val_40 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "N")) == false)
        {
            goto label_48;
        }
        
        label_44:
        val_5.set_Item(index:  0, value:  true);
        label_48:
         =  + 1;
        if( < val_40)
        {
            goto label_49;
        }
        
        return val_13;
        label_65:
        if("en" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44520928 <= (DG.Tweening.Plugins.Core.PathCore.ControlPoint System.Array::InternalArray__get_Item<DG.Tweening.Plugins.Core.PathCore.ControlPoint>(int index)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223371931869543936].Equals(value:  "B")) == true)
        {
            goto label_60;
        }
        
        if((-9223371931869543968) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_42 = -9223371931869543968;
        if(val_42 <= (mem[-9223371931869543936]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_42 = val_42 + ((mem[-9223371931869543936]) << 3);
        if(((-9223371931869543968 + (mem[-9223371931869543936]) << 3) + 32.Equals(value:  "E")) == false)
        {
            goto label_64;
        }
        
        label_60:
        val_5.set_Item(index:  0, value:  true);
        label_64:
         =  + 1;
        if( < val_42)
        {
            goto label_65;
        }
        
        return val_13;
        label_78:
        if("es" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44270704 <= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223372036799429488].Equals(value:  "L")) == true)
        {
            goto label_73;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_44 = -9223372036799429520;
        if(val_44 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_44 = val_44 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "O")) == false)
        {
            goto label_77;
        }
        
        label_73:
        val_5.set_Item(index:  0, value:  true);
        label_77:
         =  + 1;
        if( < val_44)
        {
            goto label_78;
        }
        
        return val_13;
        label_94:
        if("fr" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44261944 <= (public static System.Int32 System.Linq.Enumerable::Count<WGEventHandler>(System.Collections.Generic.IEnumerable<TSource> source)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223371942553186472].Equals(value:  "O")) == true)
        {
            goto label_89;
        }
        
        if((-9223371942553186504) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_46 = -9223371942553186504;
        if(val_46 <= (mem[-9223371942553186472]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_46 = val_46 + ((mem[-9223371942553186472]) << 3);
        if(((-9223371942553186504 + (mem[-9223371942553186472]) << 3) + 32.Equals(value:  "U")) == false)
        {
            goto label_93;
        }
        
        label_89:
        val_5.set_Item(index:  0, value:  true);
        label_93:
         =  + 1;
        if( < val_46)
        {
            goto label_94;
        }
        
        return val_13;
        label_123:
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if( <= (App.game + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + ((App.game + 32) << 3);
        if(((App.game + (App.game + 32) << 3) + 32.Equals(value:  "A")) == true)
        {
            goto label_118;
        }
        
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if( <= ((App.game + (App.game + 32) << 3) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + (((App.game + (App.game + 32) << 3) + 32) << 3);
        if((((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + 32.Equals(value:  "T")) == true)
        {
            goto label_118;
        }
        
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if( <= (((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + ((((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + 32) << 3);
        if(((((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + (((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + 32) << 3) + 32.Equals(value:  "C")) == false)
        {
            goto label_122;
        }
        
        label_118:
        val_5.set_Item(index:  0, value:  true);
        label_122:
         =  + 1;
        if( < )
        {
            goto label_123;
        }
        
        return val_13;
        label_139:
        if("de" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44511928 <= ("UncommonW: <color=#9DA832>{0}</color>\n"))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223371937025811880].Equals(value:  "A")) == true)
        {
            goto label_134;
        }
        
        if((-9223371937025811912) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_50 = -9223371937025811912;
        if(val_50 <= (mem[-9223371937025811880]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_50 = val_50 + ((mem[-9223371937025811880]) << 3);
        if(((-9223371937025811912 + (mem[-9223371937025811880]) << 3) + 32.Equals(value:  "B")) == false)
        {
            goto label_138;
        }
        
        label_134:
        val_5.set_Item(index:  0, value:  true);
        label_138:
         =  + 1;
        if( < val_50)
        {
            goto label_139;
        }
        
        return val_13;
        label_152:
        if("fr" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44261944 <= (public static System.Int32 System.Linq.Enumerable::Count<WGEventHandler>(System.Collections.Generic.IEnumerable<TSource> source)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223371942553186472].Equals(value:  "S")) == true)
        {
            goto label_147;
        }
        
        if((-9223371942553186504) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_52 = -9223371942553186504;
        if(val_52 <= (mem[-9223371942553186472]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_52 = val_52 + ((mem[-9223371942553186472]) << 3);
        if(((-9223371942553186504 + (mem[-9223371942553186472]) << 3) + 32.Equals(value:  "I")) == false)
        {
            goto label_151;
        }
        
        label_147:
        val_5.set_Item(index:  0, value:  true);
        label_151:
         =  + 1;
        if( < val_52)
        {
            goto label_152;
        }
        
        return val_13;
        label_165:
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if( <= (App.game + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + ((App.game + 32) << 3);
        if(((App.game + (App.game + 32) << 3) + 32.Equals(value:  "M")) == true)
        {
            goto label_160;
        }
        
        if( <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if( <= ((App.game + (App.game + 32) << 3) + 32))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
         =  + (((App.game + (App.game + 32) << 3) + 32) << 3);
        if((((App.game + (App.game + 32) << 3) + ((App.game + (App.game + 32) << 3) + 32) << 3) + 32.Equals(value:  "Y")) == false)
        {
            goto label_164;
        }
        
        label_160:
        val_5.set_Item(index:  0, value:  true);
        label_164:
         =  + 1;
        if( < )
        {
            goto label_165;
        }
        
        return val_13;
        label_178:
        if("de" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44511928 <= ("UncommonW: <color=#9DA832>{0}</color>\n"))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223371937025811880].Equals(value:  "A")) == true)
        {
            goto label_173;
        }
        
        if((-9223371937025811912) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_55 = -9223371937025811912;
        if(val_55 <= (mem[-9223371937025811880]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_55 = val_55 + ((mem[-9223371937025811880]) << 3);
        if(((-9223371937025811912 + (mem[-9223371937025811880]) << 3) + 32.Equals(value:  "N")) == false)
        {
            goto label_177;
        }
        
        label_173:
        val_5.set_Item(index:  0, value:  true);
        label_177:
         =  + 1;
        if( < val_55)
        {
            goto label_178;
        }
        
        return val_13;
    }
    public System.Collections.Generic.List<int> GetIndexesForTutorialLevel(int level, int lettersSize, System.Collections.Generic.List<string> lettersArray)
    {
        var val_26;
        var val_27;
        var val_28;
        string val_29;
        string val_30;
        var val_31;
        var val_32;
        val_26 = lettersSize;
        System.Collections.Generic.List<System.Int32> val_1 = null;
        val_27 = val_1;
        val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  0);
        val_1.Add(item:  1);
        val_1.Add(item:  2);
        GameBehavior val_2 = App.getBehavior;
        string val_3 = val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        if((System.String.op_Equality(a:  val_3, b:  "es")) == false)
        {
            goto label_6;
        }
        
        if(level <= 1)
        {
            goto label_7;
        }
        
        if(level != 2)
        {
            goto label_39;
        }
        
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "N"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "U"));
        val_29 = "A";
        goto label_49;
        label_6:
        if((System.String.op_Equality(a:  val_3, b:  "en")) == false)
        {
            goto label_11;
        }
        
        if(level <= 1)
        {
            goto label_12;
        }
        
        if(level != 2)
        {
            goto label_39;
        }
        
        val_30 = "E";
        goto label_15;
        label_7:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "O"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "L"));
        val_29 = "S";
        goto label_49;
        label_11:
        if((System.String.op_Equality(a:  val_3, b:  "de")) == false)
        {
            goto label_18;
        }
        
        if(level <= 1)
        {
            goto label_19;
        }
        
        if(level != 2)
        {
            goto label_39;
        }
        
        val_30 = "A";
        label_15:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  val_30));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "B"));
        val_29 = "D";
        goto label_49;
        label_12:
        val_31 = null;
        val_31 = null;
        if(App.game == 18)
        {
            goto label_28;
        }
        
        val_32 = null;
        val_32 = null;
        if(App.game != 1)
        {
            goto label_34;
        }
        
        label_28:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "A"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "T"));
        val_29 = "C";
        goto label_49;
        label_18:
        if((System.String.op_Equality(a:  val_3, b:  "fr")) == false)
        {
            goto label_39;
        }
        
        if(level <= 1)
        {
            goto label_38;
        }
        
        if(level != 2)
        {
            goto label_39;
        }
        
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "O"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "U"));
        val_29 = "P";
        goto label_49;
        label_39:
        System.Collections.Generic.List<System.Int32> val_18 = null;
        val_27 = val_18;
        val_18 = new System.Collections.Generic.List<System.Int32>();
        if(val_26 < 1)
        {
                return (System.Collections.Generic.List<System.Int32>)val_27;
        }
        
        var val_26 = 0;
        do
        {
            val_18.Add(item:  0);
            val_26 = val_26 + 1;
        }
        while(val_26 != val_26);
        
        return (System.Collections.Generic.List<System.Int32>)val_27;
        label_19:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "A"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "N"));
        val_29 = "F";
        goto label_49;
        label_34:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "Y"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "M"));
        val_29 = "G";
        goto label_49;
        label_38:
        val_26 = 1152921517724626848;
        val_28 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "I"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "S"));
        val_29 = "R";
        label_49:
        val_1.set_Item(index:  2, value:  lettersArray.IndexOf(item:  val_29));
        return (System.Collections.Generic.List<System.Int32>)val_27;
    }
    public System.Collections.Generic.List<GameLevel> get_CurrentLevelCurveGameLevels()
    {
        GameBehavior val_1 = App.getBehavior;
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        return this.GetLevels(language:  val_2, bucket:  val_2.GetPlayerBucket());
    }
    public void set_CurrentLevelCurveGameLevels(System.Collections.Generic.List<GameLevel> value)
    {
        string val_6;
        GameBehavior val_1 = App.getBehavior;
        val_6 = "A";
        if(App.Player != 0)
        {
                Player val_5 = App.Player;
            val_6 = val_5.playerBucket;
        }
        
        this.SetLevels(language:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), bucket:  val_6, levels:  value);
    }
    public System.Collections.Generic.List<GameLevel> GetFeatureLevelCurve(string bucket)
    {
        System.Collections.Generic.List<GameLevel> val_6;
        GameBehavior val_1 = App.getBehavior;
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        if((this.GetFeatureLevelCurve(lang:  val_2, bucket:  bucket)) != null)
        {
                val_6 = val_3.Levels;
            return (System.Collections.Generic.List<GameLevel>)val_6;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Could not find feature level curve for language {0} bucket {1}", arg0:  val_2, arg1:  bucket));
        System.Collections.Generic.List<GameLevel> val_5 = null;
        val_6 = val_5;
        val_5 = new System.Collections.Generic.List<GameLevel>();
        return (System.Collections.Generic.List<GameLevel>)val_6;
    }
    private System.Collections.Generic.List<GameLevel> GetLevels(string language, string bucket)
    {
        object val_5;
        System.Collections.Generic.List<GameLevel> val_6;
        val_5 = bucket;
        goto label_0;
        label_6:
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Could not find chapter data for language {0} bucket {1}", arg0:  language, arg1:  val_5));
        if(((System.String.op_Inequality(a:  language, b:  "en")) == false) || ((System.String.op_Inequality(a:  val_5, b:  "A")) == false))
        {
            goto label_4;
        }
        
        val_5 = "A";
        label_0:
        if((this.GetLevelCurve(lang:  language, bucket:  val_5)) == null)
        {
            goto label_6;
        }
        
        val_6 = val_4.Levels;
        return (System.Collections.Generic.List<GameLevel>)val_6;
        label_4:
        val_6 = 0;
        return (System.Collections.Generic.List<GameLevel>)val_6;
    }
    private void SetLevels(string language, string bucket, System.Collections.Generic.List<GameLevel> levels)
    {
        WADataParser.LevelCurve val_1 = new WADataParser.LevelCurve(language:  language, bucket:  bucket, flattenedLevels:  levels);
        val_1.AddOrUpdateToLevelCurveList(curve:  val_1, levelCurves:  this.knownLevelCurves);
    }
    public bool IsWordUncommon(string wordToCheck)
    {
        var val_5;
        Dictionary.Enumerator<TKey, TValue> val_2 = this.UncommonWordsByLength.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0.Contains(item:  wordToCheck.Replace(oldValue:  "|", newValue:  ""))) == false)
        {
            goto label_5;
        }
        
        val_5 = 1;
        goto label_6;
        label_3:
        val_5 = 0;
        label_6:
        0.Dispose();
        return (bool)val_5;
    }
    public GameLevel BuildLevel(GameLevel inputLevel)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "l", value:  inputLevel.word);
        val_1.Add(key:  "r", value:  inputLevel.answers);
        val_1.Add(key:  "e", value:  inputLevel.extraWords);
        val_1.Add(key:  "n", value:  inputLevel.lvlName);
        val_1.Add(key:  "m", value:  inputLevel.coords);
        val_1.Add(key:  "g", value:  inputLevel.gridSize);
        return val_1.ParseLevel(thisLevel:  val_1);
    }
    public GameLevel ParseLevel(System.Collections.Generic.Dictionary<string, object> thisLevel)
    {
        var val_30;
        float val_31;
        System.Collections.Generic.IEnumerable<T> val_32;
        GameLevel val_1 = new GameLevel();
        .word = thisLevel.Item["l"];
        .answers = thisLevel.Item["r"];
        .extraWords = thisLevel.Item["e"];
        val_1.levelName = thisLevel.Item["n"];
        if((System.String.IsNullOrEmpty(value:  (GameLevel)[1152921517726085440].lvlName)) != false)
        {
                val_1.levelName = (GameLevel)[1152921517726085440].word.Replace(oldValue:  "|", newValue:  "");
        }
        
        val_30 = 1152921510222861648;
        if((((thisLevel.ContainsKey(key:  "m")) != false) && (thisLevel.Item["m"] != null)) && (thisLevel.Item["g"] != null))
        {
                if((System.String.IsNullOrEmpty(value:  thisLevel.Item["m"])) != true)
        {
                .coords = thisLevel.Item["m"];
            .gridSize = thisLevel.Item["g"];
        }
        
        }
        
        if((thisLevel.ContainsKey(key:  "d")) != false)
        {
                if((System.String.IsNullOrEmpty(value:  thisLevel.Item["d"])) != true)
        {
                .extraWords = (GameLevel)[1152921517726085440].extraWords + "|"("|") + thisLevel.Item["d"];
        }
        
        }
        
        if((thisLevel.ContainsKey(key:  "c_t")) == false)
        {
            goto label_20;
        }
        
        val_31 = (GameLevel)[1152921517726085440].avgCompletionTime;
        if((System.Single.TryParse(s:  thisLevel.Item["c_t"], result: out  val_31)) == false)
        {
            goto label_22;
        }
        
        goto label_23;
        label_20:
        val_31 = (GameLevel)[1152921517726085440].avgCompletionTime;
        label_22:
        mem2[0] = -1082130432;
        label_23:
        .availExtraReq = "";
        char[] val_24 = new char[1];
        val_24[0] = 124;
        val_32 = (GameLevel)[1152921517726085440].extraWords.Split(separator:  val_24);
        System.Collections.Generic.List<System.String> val_26 = new System.Collections.Generic.List<System.String>(collection:  val_32);
        if(1152921515438511520 >= 1)
        {
                val_32 = public System.String SRDebugger_Instantiator::GetLPNsLog();
            .availExtraReq = val_32;
            if(1152921515438511520 >= 2)
        {
                val_30 = "|";
            do
        {
            if(1 >= 1152921515438511520)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            string val_27 = val_32 + "|"("|") + "pooledStream";
            .availExtraReq = val_27;
            val_32 = val_27;
            var val_29 = 5 + 1;
        }
        while((5 - 3) < 1152921515438511520);
        
        }
        
        }
        
        GameBehavior val_30 = App.getBehavior;
        .language = val_30.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        return val_1;
    }
    public void GenerateNewGrid(GameLevel gameLevel, int triesBeforeEasier = 100)
    {
        string val_7;
        int val_8;
        int val_41;
        GameLevel val_42;
        System.Collections.Generic.Dictionary<System.String, CrosswordCreator.Crossword.WordTuple> val_43;
        System.Char[] val_44;
        object val_45;
        System.Collections.Generic.IEnumerable<T> val_46;
        System.Collections.Generic.List<T> val_47;
        string val_48;
        var val_49;
        string val_50;
        val_42 = gameLevel;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = 1152921505060011504;
        val_44 = 1;
        char[] val_1 = new char[1];
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_1;
        val_44[0] = 124;
        if(gameLevel.answers == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<System.String> val_3 = null;
        val_45 = 1152921515438511520;
        val_3 = new System.Collections.Generic.List<System.String>(collection:  gameLevel.answers.Split(separator:  val_1));
        System.Collections.Generic.List<System.String> val_4 = null;
        val_41 = 1152921509851217984;
        val_4 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.String> val_5 = null;
        val_44 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_46 = val_5;
        val_5 = new System.Collections.Generic.List<System.String>();
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_6 = val_3.GetEnumerator();
        label_12:
        if(val_8.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_48 = "*";
        if((val_7.StartsWith(value:  val_48)) == false)
        {
            goto label_8;
        }
        
        val_47 = val_4;
        if(val_47 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_4.Add(item:  val_7);
        goto label_12;
        label_8:
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_5.Add(item:  val_7);
        goto label_12;
        label_6:
        val_8.Dispose();
        System.Collections.Generic.List<System.String> val_11 = null;
        val_44 = val_46;
        val_49 = val_11;
        val_11 = new System.Collections.Generic.List<System.String>(collection:  val_5);
        val_41 = triesBeforeEasier - 1;
        label_24:
        var val_39 = val_41;
        label_16:
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_46;
        this.this_generator.Generate(words:  val_5, maxWidth:  12, maxHeight:  12);
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = 0;
        val_39 = val_39 - 1;
        if()
        {
                if(this.this_generator.usedAllWords == false)
        {
            goto label_16;
        }
        
        }
        
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = 0;
        if(this.this_generator.usedAllWords != true)
        {
                if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            val_42.WordRemoval(maxCount:  44183631, removePercent:  0, removePlurals:  false, rareWords:  0);
            val_44 = 1;
            char[] val_14 = new char[1];
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = val_14;
            val_44[0] = 124;
            if(gameLevel.answers == null)
        {
                throw new NullReferenceException();
        }
        
            System.Collections.Generic.List<System.String> val_16 = null;
            val_46 = val_16;
            val_16 = new System.Collections.Generic.List<System.String>(collection:  gameLevel.answers.Split(separator:  val_14));
            System.Collections.Generic.List<System.String> val_17 = null;
            val_44 = val_46;
            val_49 = val_17;
            val_17 = new System.Collections.Generic.List<System.String>(collection:  val_16);
        }
        
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator.usedAllWords == false)
        {
            goto label_24;
        }
        
        System.Text.StringBuilder val_19 = null;
        val_44 = 0;
        val_46 = val_19;
        val_19 = new System.Text.StringBuilder();
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        val_8 = this.this_generator._board.xWindow;
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = 1152921504619999232;
        val_41 = 4;
        label_45:
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board.WordTuples == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = public System.Int32 System.Collections.Generic.Dictionary<System.String, CrosswordCreator.Crossword.WordTuple>::get_Count();
        var val_20 = val_41 - 4;
        if(val_20 >= (this.this_generator._board.WordTuples.Count << ))
        {
            goto label_30;
        }
        
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43 = this.this_generator._board.WordTuples;
        if(val_20 >= X9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = this.this_generator._board.xWindow;
        val_43 = val_43.Item[val_44];
        if(val_41 != 4)
        {
                if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = "|";
            System.Text.StringBuilder val_23 = val_19.Append(value:  val_44);
        }
        
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_22.dir == 0)
        {
                if(val_20 >= val_22.dir)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((val_22.dir + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            int val_24 = System.Math.Max(val1:  0, val2:  val_22.dir + 32 + 16);
        }
        
        val_8 = val_22.y;
        val_45 = val_22.x;
        val_44 = val_8;
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = System.String.Format(format:  "{0},{1},{2}", arg0:  val_8, arg1:  val_22.x, arg2:  val_22.dir);
        System.Text.StringBuilder val_26 = val_19.Append(value:  val_44);
        val_41 = val_41 + 1;
        if(this.this_generator != null)
        {
            goto label_45;
        }
        
        throw new NullReferenceException();
        label_30:
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = val_46;
        val_50 = 1152921513250978752;
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = this.this_generator._board.yWindow.ToString() + "|"("|") + this.this_generator._board.xWindow.ToString();
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(mem[1152921517726658520] < 1)
        {
                return;
        }
        
        if(this.this_generator == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.this_generator._board == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = this.this_generator._board.xWindow + 1;
        List.Enumerator<T> val_30 = val_4.GetEnumerator();
        label_57:
        if(val_8.MoveNext() == false)
        {
            goto label_58;
        }
        
        if((val_7.StartsWith(value:  "*")) == false)
        {
            goto label_57;
        }
        
        val_50 = mem[gameLevel + 120];
        val_50 = gameLevel + 120;
        val_8 = val_41;
        val_41 = val_42;
        mem2[0] = val_50 + System.String.Format(format:  "|{0},{1},{2}", arg0:  "0", arg1:  val_8, arg2:  "1")(System.String.Format(format:  "|{0},{1},{2}", arg0:  "0", arg1:  val_8, arg2:  "1"));
        var val_40 = val_7 + 16;
        val_40 = val_40 - 1;
        label_58:
        val_8.Dispose();
        mem2[0] = val_40.ToString() + "|"("|") + this.this_generator._board.xWindow + 2.ToString()(this.this_generator._board.xWindow + 2.ToString());
    }
    public GameLevel GetDynamicDailyChallengeLevel(DynamicLevelBuildParams param)
    {
        return this.BuildDynamicLevel(param:  param);
    }
    public GameLevel BuildDynamicLevel(DynamicLevelBuildParams param)
    {
        string val_16;
        var val_17;
        var val_55;
        var val_56;
        var val_57;
        var val_58;
        var val_59;
        string val_60;
        var val_61;
        var val_63;
        var val_64;
        var val_65;
        var val_66;
        var val_67;
        var val_68;
        string val_69;
        GameLevel val_1 = new GameLevel();
        .answers = "";
        System.Collections.Generic.List<System.Boolean> val_2 = new System.Collections.Generic.List<System.Boolean>();
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_55 = null;
            val_55 = null;
            if((System.String.op_Inequality(a:  WADataParser.QAhackedWord, b:  System.String.alignConst)) != false)
        {
                val_56 = null;
            val_56 = null;
            if(WADataParser.QAhackedWord.m_stringLength >= 5)
        {
                val_57 = null;
            val_57 = null;
            if(WADataParser.QAhackedWord.m_stringLength <= 9)
        {
                val_58 = null;
            val_58 = null;
            param.levelWordLength = WADataParser.QAhackedWord.m_stringLength;
            val_58 = null;
            val_58 = null;
            if((this.plv_playedWords.Contains(item:  WADataParser.QAhackedWord.ToUpper())) != false)
        {
                val_59 = null;
            val_59 = null;
            bool val_10 = this.plv_playedWords.Remove(item:  WADataParser.QAhackedWord.ToUpper());
        }
        
        }
        
        }
        
        }
        
        }
        
        label_113:
        val_60 = (GameLevel)[1152921517727279840].answers;
        char[] val_11 = new char[1];
        val_11[0] = 124;
        System.String[] val_12 = val_60.Split(separator:  val_11);
        if(val_12.Length >= 6)
        {
                return (GameLevel)val_61;
        }
        
        System.Collections.Generic.List<System.String> val_14 = null;
        val_61 = val_14;
        val_14 = new System.Collections.Generic.List<System.String>(collection:  this.CommonWordsByLength.Item[param.levelWordLength]);
        List.Enumerator<T> val_15 = this.plv_playedWords.GetEnumerator();
        label_56:
        if(val_17.MoveNext() == false)
        {
            goto label_54;
        }
        
        if(val_61 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_19 = val_14.Remove(item:  val_16);
        goto label_56;
        label_54:
        val_63 = 0 + 1;
        mem2[0] = 253;
        val_17.Dispose();
        if(val_63 != 1)
        {
                var val_20 = ((1152921517727231568 + ((0 + 1)) << 2) == 253) ? 1 : 0;
            val_20 = ((val_63 >= 0) ? 1 : 0) & val_20;
            val_63 = val_63 - val_20;
        }
        
        if(val_20 != 0)
        {
            goto label_67;
        }
        
        System.Collections.Generic.List<System.String> val_23 = null;
        val_61 = val_23;
        val_23 = new System.Collections.Generic.List<System.String>(collection:  this.UncommonWordsByLength.Item[param.levelWordLength]);
        List.Enumerator<T> val_24 = this.plv_playedWords.GetEnumerator();
        label_64:
        if(val_17.MoveNext() == false)
        {
            goto label_62;
        }
        
        if(val_61 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_26 = val_23.Remove(item:  val_16);
        goto label_64;
        label_62:
        val_64 = val_63 + 1;
        mem2[0] = 345;
        val_17.Dispose();
        if(val_64 != 1)
        {
                var val_27 = ((1152921517727231568 + ((((0 + 1) - (val_63 >= 0x0 ? 1 : 0 & 1152921517727231568 + ((0 + 1)) << 2 == 0xFD ? 1 : 0)) + 1)) << 2) == 345) ? 1 : 0;
            val_27 = ((val_64 >= 0) ? 1 : 0) & val_27;
            val_64 = val_64 - val_27;
        }
        
        if(val_27 != 0)
        {
            goto label_67;
        }
        
        List.Enumerator<T> val_30 = this.CommonWordsByLength.Item[param.levelWordLength].GetEnumerator();
        label_72:
        if(val_17.MoveNext() == false)
        {
            goto label_70;
        }
        
        if(this.plv_playedWords == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_32 = this.plv_playedWords.Remove(item:  val_16);
        goto label_72;
        label_70:
        val_64 = val_64 + 1;
        mem2[0] = 430;
        val_17.Dispose();
        if(val_64 != 1)
        {
                var val_33 = ((1152921517727231568 + ((((((0 + 1) - (val_63 >= 0x0 ? 1 : 0 & 1152921517727231568 + ((0 + 1)) << 2 == 0xFD ? 1 : 0)) + 1) - (val_64 >= 0x0 ? 1 : 0 & 1152921517727231568 + ((((0 + 1) - (val_63 >= 0x0 ? 1 : 0 & 11529215177272) << 2) == 430) ? 1 : 0;
            val_33 = ((val_64 >= 0) ? 1 : 0) & val_33;
            val_65 = val_64 - val_33;
        }
        else
        {
                val_65 = 0;
        }
        
        List.Enumerator<T> val_36 = this.UncommonWordsByLength.Item[param.levelWordLength].GetEnumerator();
        label_79:
        if(val_17.MoveNext() == false)
        {
            goto label_77;
        }
        
        if(this.plv_playedWords == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_38 = this.plv_playedWords.Remove(item:  val_16);
        goto label_79;
        label_77:
        val_65 = val_65 + 1;
        mem2[0] = 504;
        val_17.Dispose();
        if(val_65 != 1)
        {
                var val_39 = ((1152921517727231568 + ((val_65 + 1)) << 2) == 504) ? 1 : 0;
            val_39 = ((val_65 >= 0) ? 1 : 0) & val_39;
            var val_41 = val_65 - val_39;
        }
        
        System.Collections.Generic.List<System.String> val_42 = this.CommonWordsByLength.Item[param.levelWordLength];
        System.Collections.Generic.List<System.String> val_43 = null;
        val_61 = val_43;
        val_43 = new System.Collections.Generic.List<System.String>(collection:  val_42);
        label_67:
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_92;
        }
        
        val_66 = null;
        val_66 = null;
        if((System.String.op_Inequality(a:  WADataParser.QAhackedWord, b:  System.String.alignConst)) == false)
        {
            goto label_92;
        }
        
        val_67 = null;
        val_67 = null;
        if((val_43.Contains(item:  WADataParser.QAhackedWord.ToUpper())) == false)
        {
            goto label_100;
        }
        
        val_68 = null;
        val_68 = null;
        val_69 = WADataParser.QAhackedWord.ToUpper();
        goto label_107;
        label_92:
        label_100:
        int val_51 = RandomSet.singleInRange(lowest:  0, highest:  val_42 - 1);
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_69 = mem[(RandomSet.__il2cppRuntimeField_cctor_finished + (val_51) << 3) + 32];
        val_69 = (RandomSet.__il2cppRuntimeField_cctor_finished + (val_51) << 3) + 32;
        label_107:
        .levelWord = val_69;
        mem[1152921517727439636] = 1;
        mem[1152921517727439616] = 1;
        mem[1152921517727439620] = 1;
        mem[1152921517727439624] = 1;
        mem[1152921517727439638] = 1;
        mem[1152921517727439628] = 1;
        if((this.BuildLevelBasedOnWord(param:  new BuildLevelBasedOnWordParams())) != null)
        {
            goto label_113;
        }
        
        throw new NullReferenceException();
    }
    public GameLevel BuildLevelBasedOnWord(BuildLevelBasedOnWordParams param)
    {
        GameLevel val_87;
        string val_88;
        System.Collections.Generic.List<System.String> val_89;
        int val_91;
        var val_92;
        int val_93;
        string val_94;
        string val_95;
        int val_96;
        int val_97;
        var val_98;
        param.levelWord = param.levelWord.Replace(oldValue:  "|", newValue:  "");
        GameLevel val_2 = null;
        val_87 = val_2;
        val_2 = new GameLevel();
        string val_4 = param.levelWord.Chars[0].ToString();
        .word = val_4;
        val_88 = param.levelWord;
        var val_95 = 1;
        label_7:
        if(val_95 >= param.levelWord.m_stringLength)
        {
            goto label_6;
        }
        
        .word = val_4 + "|"("|") + val_88.Chars[1].ToString();
        val_88 = param.levelWord;
        val_95 = val_95 + 1;
        if(val_88 != null)
        {
            goto label_7;
        }
        
        throw new NullReferenceException();
        label_6:
        var val_8 = (param.levelWord.m_stringLength > 4) ? (2 + 1) : 2;
        System.Collections.Generic.List<TSource> val_18 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  this.GetAvailableWordsFromList(word:  val_88, listToUse:  this.CommonWordsByLength, startingLength:  (1152921504878411776 == 1) ? (val_8) : (1152921504878411776), endingLength:  param.levelWord.m_stringLength)));
        val_89 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  this.GetAvailableWordsFromList(word:  param.levelWord, listToUse:  this.UncommonWordsByLength, startingLength:  (1152921504878411776 == 1) ? 3 : (1152921504878411776), endingLength:  param.levelWord.m_stringLength)));
        System.Collections.Generic.List<TSource> val_22 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  this.GetAvailableWordsFromList(word:  param.levelWord, listToUse:  this.RareWordsByLength, startingLength:  (1152921504878411776 == 1) ? 3 : (1152921504878411776), endingLength:  System.Math.Min(val1:  param.levelWord.m_stringLength, val2:  (val_8 == 1) ? 6 : (val_8)))));
        .availExtraReq = "";
        .answers = "";
        .extraWords = "";
        .extraRequiredWords = "";
        if("" >= 1)
        {
                .answers = null;
            do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((System.String.IsNullOrEmpty(value:  "".__il2cppRuntimeField_20 + 40)) != true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            .answers = (GameLevel)[1152921517728319328].answers + "|"("|") + "".__il2cppRuntimeField_20 + 40("".__il2cppRuntimeField_20 + 40);
        }
        
            var val_26 = 5 + 1;
        }
        while((5 - 3) < ("|"));
        
        }
        
        if(("|") >= 1)
        {
                if(param.includeUncommonAsRequiredWords != false)
        {
                var val_96 = 4;
            do
        {
            if(0 >= ("|"))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.String.IsNullOrEmpty(value:  public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key())) != true)
        {
                if(0 >= ("|"))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((GameLevel)[1152921517728319328].answers.Contains(value:  public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key())) != true)
        {
                if(0 >= ("|"))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(("|") <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .answers = (GameLevel)[1152921517728319328].answers + "|"("|") + public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()(public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key());
        }
        
        }
        
            val_96 = val_96 + 1;
        }
        while((val_96 - 3) < ("|"));
        
            if(("|") == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        }
        
            .extraWords = public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key();
            if((public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()) >= 2)
        {
                do
        {
            if(1 >= (public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.String.IsNullOrEmpty(value:  public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key().__il2cppRuntimeField_28)) != true)
        {
                if(1 >= (public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((GameLevel)[1152921517728319328].extraWords.Contains(value:  public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key().__il2cppRuntimeField_28)) != true)
        {
                if(1 >= (public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .extraWords = (GameLevel)[1152921517728319328].extraWords + "|"("|") + public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key().__il2cppRuntimeField_28(public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key().__il2cppRuntimeField_28);
        }
        
        }
        
            var val_35 = 5 + 1;
        }
        while((5 - 3) < (public System.Char System.Collections.Generic.KeyValuePair<System.Char, FPHKeyButton>::get_Key()));
        
        }
        
        }
        
        val_2.levelName = param.levelWord;
        if(as. 
           
           
          
        
        
        
         != 0)
        {
                if(((GameLevel)[1152921517728319328].extraWords & 2147483648) != 0)
        {
                GameEcon val_36 = App.getGameEcon;
            val_91 = val_36.remLevelWordMax;
        }
        
            if(param.includeUncommonAsRequiredWords != false)
        {
                GameEcon val_37 = App.getGameEcon;
            val_2.WordRemovalWithUncommonWords(maxCount:  val_91, removePercent:  val_37.remWordRemovalPercentage, removePlurals:  true, rareWords:  val_22, uncommonWords:  val_89);
        }
        else
        {
                GameEcon val_38 = App.getGameEcon;
            val_2.WordRemoval(maxCount:  val_91, removePercent:  val_38.remWordRemovalPercentage, removePlurals:  true, rareWords:  val_22);
        }
        
        }
        
        char[] val_39 = new char[1];
        val_39[0] = 124;
        System.String[] val_40 = (GameLevel)[1152921517728319328].extraWords.Split(separator:  val_39);
        char[] val_41 = new char[1];
        val_41[0] = 124;
        .availExtraReq = "";
        val_92 = null;
        val_92 = null;
        var val_43 = (App.game == 4) ? (val_18) : (val_89);
        if((App.game == 0x4 ? val_18 : val_20 + 24) >= 1)
        {
                var val_97 = 4;
            do
        {
            if(0 >= (App.game == 0x4 ? val_18 : val_20 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.Linq.Enumerable.Contains<System.String>(source:  (GameLevel)[1152921517728319328].answers.Split(separator:  val_41), value:  App.game == 0x4 ? val_18 : val_20 + 16 + 32)) != true)
        {
                if(0 >= (App.game == 0x4 ? val_18 : val_20 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .availExtraReq = (GameLevel)[1152921517728319328].availExtraReq + App.game == 0x4 ? val_18 : val_20 + 16 + 32(App.game == 0x4 ? val_18 : val_20 + 16 + 32) + "|"("|");
        }
        
            val_97 = val_97 + 1;
        }
        while((val_97 - 3) < (App.game == 0x4 ? val_18 : val_20 + 24));
        
        }
        
        char[] val_47 = new char[1];
        val_47[0] = 124;
        char[] val_50 = new char[1];
        val_50[0] = 124;
        System.Collections.Generic.List<TSource> val_52 = System.Linq.Enumerable.ToList<System.String>(source:  (GameLevel)[1152921517728319328].extraWords.Split(separator:  val_50));
        char[] val_53 = new char[1];
        val_53[0] = 124;
        System.Collections.Generic.List<TSource> val_55 = System.Linq.Enumerable.ToList<System.String>(source:  (GameLevel)[1152921517728319328].availExtraReq.Split(separator:  val_53));
        if(124 != 0)
        {
                this.CalculateExtraRequiredWords(resultLevel:  val_2, answersList:  System.Linq.Enumerable.ToList<System.String>(source:  (GameLevel)[1152921517728319328].answers.Split(separator:  val_47)), inWUT:  (App.game == 4) ? 1 : 0, requiredExtraWords:  param.requiredExtraWords);
        }
        
        if(((GameLevel)[1152921517728319328].answers.EndsWith(value:  "|")) != false)
        {
                .answers = (GameLevel)[1152921517728319328].answers.Substring(startIndex:  0, length:  (GameLevel)[1152921517728319328].answers.m_stringLength - 1);
        }
        
        if(((GameLevel)[1152921517728319328].extraWords.EndsWith(value:  "|")) != false)
        {
                .extraWords = (GameLevel)[1152921517728319328].extraWords.Substring(startIndex:  0, length:  (GameLevel)[1152921517728319328].extraWords.m_stringLength - 1);
        }
        
        if(((GameLevel)[1152921517728319328].availExtraReq.EndsWith(value:  "|")) != false)
        {
                .availExtraReq = (GameLevel)[1152921517728319328].availExtraReq.Substring(startIndex:  0, length:  (GameLevel)[1152921517728319328].availExtraReq.m_stringLength - 1);
        }
        
        if(App.game != 4)
        {
            goto label_98;
        }
        
        this.GenerateNewGrid(gameLevel:  val_2, triesBeforeEasier:  100);
        char[] val_66 = new char[1];
        val_66[0] = 124;
        System.String[] val_67 = (GameLevel)[1152921517728319328].answers.Split(separator:  val_66);
        char[] val_68 = new char[1];
        val_68[0] = 124;
        System.String[] val_69 = (GameLevel)[1152921517728319328].coords.Split(separator:  val_68);
        val_93 = val_69.Length;
        if(val_67.Length != val_93)
        {
            goto label_100;
        }
        
        if((GameLevel)[1152921517728319328].extraWordsNeeded >= 1)
        {
                if(((GameLevel)[1152921517728319328].answers.Contains(value:  "|*")) == false)
        {
            goto label_100;
        }
        
        }
        
        label_98:
        if((val_22 + 24) < 1)
        {
            goto label_136;
        }
        
        if((val_22 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_94 = mem[val_22 + 16 + 32];
        val_94 = val_22 + 16 + 32;
        if((System.String.op_Equality(a:  (GameLevel)[1152921517728319328].extraWords, b:  "")) == false)
        {
            goto label_104;
        }
        
        val_95 = val_94;
        val_94 = "|";
        goto label_105;
        label_100:
        object[] val_72 = new object[8];
        val_72[0] = "RabanosPicantes: Built unsolvable level: ";
        val_96 = val_72.Length;
        val_72[1] = val_67.Length;
        val_96 = val_72.Length;
        val_72[2] = ", coords: ";
        val_97 = val_72.Length;
        val_72[3] = val_93;
        val_97 = val_72.Length;
        val_72[4] = ", word: ";
        val_89 = (GameLevel)[1152921517728319328].lvlName;
        if(val_89 != null)
        {
                val_97 = val_72.Length;
        }
        
        val_72[5] = val_89;
        val_98 = ", words:";
        val_97 = val_72.Length;
        val_72[6] = ", words:";
        if((GameLevel)[1152921517728319328].answers != null)
        {
                val_97 = val_72.Length;
        }
        
        val_72[7] = (GameLevel)[1152921517728319328].answers;
        UnityEngine.Debug.LogError(message:  +val_72);
        val_87 = 0;
        if(param.ignoreRetries == true)
        {
                return val_87;
        }
        
        val_87 = this.BuildLevelOfWordLength(desiredLength:  param.levelWord.m_stringLength);
        return val_87;
        label_104:
        val_95 = "|";
        label_105:
        .extraWords = (GameLevel)[1152921517728319328].extraWords + val_95 + val_94;
        if((val_22 + 24) >= 2)
        {
                do
        {
            if(1 >= (val_22 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((System.String.IsNullOrEmpty(value:  val_22 + 16 + 40)) != true)
        {
                if(1 >= (val_22 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((GameLevel)[1152921517728319328].extraWords.Contains(value:  val_22 + 16 + 40)) != true)
        {
                if(1 >= (val_22 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .extraWords = (GameLevel)[1152921517728319328].extraWords + "|"("|") + val_22 + 16 + 40(val_22 + 16 + 40);
        }
        
        }
        
            var val_80 = 5 + 1;
        }
        while((5 - 3) < (val_22 + 24));
        
        }
        
        label_136:
        char[] val_81 = new char[1];
        val_81[0] = 124;
        System.String[] val_82 = (GameLevel)[1152921517728319328].answers.Split(separator:  val_81);
        .actualWordCount = val_82.Length;
        GameBehavior val_83 = App.getBehavior;
        .language = val_83.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        .isChallengingLevel = App.__il2cppRuntimeField_cctor_finished;
        System.Collections.Generic.List<System.String> val_85 = new System.Collections.Generic.List<System.String>();
        char[] val_86 = new char[1];
        val_86[0] = 124;
        val_93 = 1152921515438561712;
        val_85.AddRange(collection:  System.Linq.Enumerable.ToList<System.String>(source:  (GameLevel)[1152921517728319328].answers.Split(separator:  val_86)));
        char[] val_89 = new char[1];
        char val_98 = 124;
        val_89[0] = val_98;
        System.Collections.Generic.List<TSource> val_91 = System.Linq.Enumerable.ToList<System.String>(source:  (GameLevel)[1152921517728319328].availExtraReq.Split(separator:  val_89));
        val_85.AddRange(collection:  val_91);
        int val_92 = UnityEngine.Random.Range(min:  0, max:  val_91);
        val_98 = val_92;
        if(val_98 <= val_92)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_98 = val_98 + (val_98 << 3);
        .challengeWord = (124 + (val_92) << 3) + 32;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return val_87;
        }
        
        .commonW = val_18;
        .uncommonW = val_89;
        .rareW = val_22;
        return val_87;
    }
    private void CalculateExtraRequiredWords(GameLevel resultLevel, System.Collections.Generic.List<string> answersList, bool inWUT, int requiredExtraWords)
    {
        string val_22;
        var val_23;
        var val_67;
        var val_68;
        string val_69;
        MetaGameBehavior val_70;
        var val_71;
        var val_72;
        var val_74;
        var val_76;
        var val_77;
        var val_78;
        val_67 = answersList;
        if(inWUT != false)
        {
                int val_1 = this.CalculateRequiredExtraWordsWUT();
        }
        
        int val_3 = System.Math.Max(val1:  this.CalculateRequiredExtraWordsWAD(), val2:  requiredExtraWords);
        if(val_3 < 1)
        {
                return;
        }
        
        val_69 = 1152921504884269056;
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_4.properties.LevelsPlayedPostPurchase < val_5.extraReqPostPurchaseMin)
        {
            goto label_11;
        }
        
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_6.properties == null)
        {
                throw new NullReferenceException();
        }
        
        if(App.getGameEcon == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_6.properties.LevelsPlayedPostPurchase <= val_7.extraReqPostPurchaseMax)
        {
            goto label_17;
        }
        
        label_11:
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.<ExtraRequiredWordsPostPurchase>k__BackingField = false;
        goto label_21;
        label_17:
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.<ExtraRequiredWordsPostPurchase>k__BackingField = true;
        val_71 = null;
        val_71 = null;
        WADataParser.debug_lastReqDetermination = WADataParser.debug_lastReqDetermination + " : post purchase extra"(" : post purchase extra");
        WADataParser.CurrentLevelGenVersion = val_3 + 1.ToString();
        label_21:
        val_72 = null;
        val_72 = null;
        if(WADataParser._QAHACK_NoExtraRequired != false)
        {
                WADataParser.debug_lastReqDetermination = "qa hack no extra";
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_70 = val_13.<metaGameBehavior>k__BackingField;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_70 & 1) == 0)
        {
                val_70 = null;
            val_70 = null;
            WADataParser.debug_lastReqDetermination = "extra required words not supported";
        }
        
        if(resultLevel == null)
        {
                throw new NullReferenceException();
        }
        
        resultLevel.extraWordsNeeded = 0;
        char[] val_14 = new char[1];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14[0] = 124;
        if(resultLevel.availExtraReq == null)
        {
                throw new NullReferenceException();
        }
        
        System.String[] val_15 = resultLevel.availExtraReq.Split(separator:  val_14);
        System.Collections.Generic.List<System.String> val_16 = null;
        val_69 = 1152921509851217984;
        val_16 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.String> val_17 = new System.Collections.Generic.List<System.String>();
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        if(0 >= val_15.Length)
        {
            goto label_47;
        }
        
        val_74 = inWUT;
        if(0 < 1)
        {
            goto label_48;
        }
        
        val_69 = 0;
        label_57:
        var val_65 = 99;
        label_54:
        val_70 = 0;
        int val_18 = UnityEngine.Random.Range(min:  0, max:  val_15.Length);
        if(val_16 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_64 = val_15[val_18];
        if((val_16.Contains(item:  val_64)) != true)
        {
                if((System.String.IsNullOrEmpty(value:  val_64)) == false)
        {
            goto label_52;
        }
        
        }
        
        val_65 = val_65 - 1;
        if(val_18 < val_15.Length)
        {
            goto label_60;
        }
        
        if(val_69 < 0)
        {
            goto label_54;
        }
        
        goto label_60;
        label_52:
        val_16.Add(item:  val_64);
        if(val_65 < 1)
        {
            goto label_60;
        }
        
        val_69 = val_69 + 1;
        if(val_69 < 0)
        {
            goto label_57;
        }
        
        goto label_60;
        label_47:
        val_70 = val_16;
        if(val_70 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_74 = inWUT;
        val_16.AddRange(collection:  val_15);
        goto label_60;
        label_48:
        if(val_16 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_60:
        List.Enumerator<T> val_21 = val_16.GetEnumerator();
        val_69 = "n/a";
        goto label_68;
        label_69:
        if(val_67 == null)
        {
                throw new NullReferenceException();
        }
        
        if((((val_67.Contains(item:  val_22)) != true) && ((val_67.Contains(item:  "*"("*") + val_22)) != true)) && ((System.String.op_Equality(a:  val_22.ToLower(), b:  "n/a")) != true))
        {
                if((System.String.IsNullOrEmpty(value:  val_22)) != true)
        {
                resultLevel.extraRequiredWords = resultLevel.extraRequiredWords + System.String.Format(format:  "{0}|", arg0:  val_22)(System.String.Format(format:  "{0}|", arg0:  val_22));
            resultLevel.answers = resultLevel.answers + System.String.Format(format:  "{0}{1}", arg0:  "|*", arg1:  val_22)(System.String.Format(format:  "{0}{1}", arg0:  "|*", arg1:  val_22));
        }
        
        }
        
        label_68:
        if(val_23.MoveNext() == true)
        {
            goto label_69;
        }
        
        val_23.Dispose();
        val_70 = resultLevel.answers;
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_70.Contains(value:  "|*")) == true) || (val_74 == true))
        {
            goto label_120;
        }
        
        val_69 = resultLevel.answers;
        char[] val_36 = new char[1];
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36[0] = 124;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_66 = 1152921510375394352;
        System.Collections.Generic.List<TSource> val_38 = System.Linq.Enumerable.ToList<System.String>(source:  val_69.Split(separator:  val_36));
        if(val_38 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_39 = UnityEngine.Random.Range(min:  0, max:  1473580080);
        if(val_66 <= val_39)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_66 = val_66 + (val_39 << 3);
        val_38.set_Item(index:  val_39, value:  "*"("*") + (1152921510375394352 + (val_39) << 3) + 32((1152921510375394352 + (val_39) << 3) + 32));
        resultLevel.answers = "";
        List.Enumerator<T> val_41 = val_38.GetEnumerator();
        goto label_78;
        label_79:
        resultLevel.answers = resultLevel.answers + System.String.Format(format:  "{0}{1}", arg0:  val_22, arg1:  "|")(System.String.Format(format:  "{0}{1}", arg0:  val_22, arg1:  "|"));
        label_78:
        if(val_23.MoveNext() == true)
        {
            goto label_79;
        }
        
        val_23.Dispose();
        label_120:
        System.Collections.Generic.List<System.String> val_45 = null;
        val_69 = val_45;
        val_45 = new System.Collections.Generic.List<System.String>();
        char[] val_46 = new char[1];
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_46[0] = 124;
        if(resultLevel.extraWords == null)
        {
                throw new NullReferenceException();
        }
        
        System.String[] val_47 = resultLevel.extraWords.Split(separator:  val_46);
        if(val_47 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_67 = val_47.Length;
        val_70 = val_16;
        if(val_67 >= 1)
        {
                var val_68 = 0;
            val_67 = val_67 & 4294967295;
            do
        {
            if((val_16.Contains(item:  1152921505059157200)) != true)
        {
                if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
            val_45.Add(item:  1152921505059157200);
        }
        
            val_70 = val_16;
            val_68 = val_68 + 1;
        }
        while(val_68 < (val_47.Length << ));
        
        }
        
        resultLevel.extraWords = "";
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_49 = val_45.GetEnumerator();
        val_67 = "|";
        goto label_90;
        label_91:
        resultLevel.extraWords = resultLevel.extraWords + val_22 + "|"("|");
        label_90:
        if(val_23.MoveNext() == true)
        {
            goto label_91;
        }
        
        val_23.Dispose();
        if(0 != 1)
        {
                var val_52 = (842 == 842) ? 1 : 0;
            val_52 = ((0 >= 0) ? 1 : 0) & val_52;
            val_76 = 0 - val_52;
        }
        else
        {
                val_76 = 0;
        }
        
        List.Enumerator<T> val_54 = val_16.GetEnumerator();
        label_97:
        val_77 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_23.MoveNext() == false)
        {
            goto label_94;
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_17.Contains(item:  val_22)) == false)
        {
            goto label_97;
        }
        
        bool val_57 = val_17.Remove(item:  val_22);
        goto label_97;
        label_94:
        val_68 = 1;
        val_23.Dispose();
        if(val_68 != 1)
        {
                var val_58 = (905 == 905) ? 1 : 0;
            val_58 = ((val_68 >= 0) ? 1 : 0) & val_58;
            val_58 = val_68 - val_58;
            val_58 = val_58 + 1;
            val_78 = (long)val_58;
        }
        else
        {
                val_78 = 0;
        }
        
        val_70 = resultLevel.extraWords;
        if((System.String.IsNullOrEmpty(value:  val_70)) != false)
        {
                resultLevel.extraWords = "";
        }
        
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_61 = val_17.GetEnumerator();
        goto label_102;
        label_103:
        resultLevel.extraWords = resultLevel.extraWords + val_22 + "|"("|");
        label_102:
        if(val_23.MoveNext() == true)
        {
            goto label_103;
        }
        
        val_23.Dispose();
    }
    protected int CalculateRequiredExtraWordsWAD()
    {
        string val_22;
        var val_23;
        int val_24;
        var val_25;
        int val_26;
        int val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_22 = 1152921504985387008;
            val_23 = null;
            val_23 = null;
            val_24 = 0;
            WADataParser.debug_lastReqDetermination = "playing challenge";
            return (int)val_24;
        }
        
        int val_3 = Prefs.currentLevel;
        GameEcon val_5 = App.getGameEcon;
        if(Prefs.currentChapter < val_5.extraReqBeginningChapter)
        {
                GameEcon val_8 = App.getGameEcon;
            val_22 = "chapter (" + Prefs.currentChapter.ToString() + ") <= "(") <= ") + val_8.extraReqBeginningChapter.ToString();
            val_25 = null;
            val_25 = null;
            val_24 = 0;
            WADataParser.debug_lastReqDetermination = val_22;
            return (int)val_24;
        }
        
        val_22 = MainController.instance;
        if(val_22 == 0)
        {
                val_24 = 0;
            return (int)val_24;
        }
        
        val_22 = MainController.instance;
        string[] val_14 = new string[5];
        val_14[0] = "chosen lvls:";
        val_26 = val_14.Length;
        val_14[1] = MiniJSON.Json.Serialize(obj:  val_22);
        val_26 = val_14.Length;
        val_14[2] = " vs current: ";
        val_27 = val_14.Length;
        val_14[3] = val_3.ToString();
        val_27 = val_14.Length;
        val_14[4] = "\n";
        val_28 = null;
        val_28 = null;
        WADataParser.debug_lastReqDetermination = +val_14;
        val_29 = null;
        if((val_22.Contains(item:  val_3)) != false)
        {
                val_30 = null;
            WADataParser.debug_lastReqDetermination = WADataParser.debug_lastReqDetermination + "lvl was chosen!"("lvl was chosen!");
            GameEcon val_20 = App.getGameEcon;
            val_24 = val_20.extraReqQuantityPerLevel;
            return (int)val_24;
        }
        
        val_31 = null;
        val_24 = 0;
        WADataParser.debug_lastReqDetermination = WADataParser.debug_lastReqDetermination + "lvl not chosen";
        return (int)val_24;
    }
    protected int CalculateRequiredExtraWordsWUT()
    {
        string val_22;
        var val_23;
        var val_24;
        var val_25;
        int val_26;
        int val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_22 = 1152921504985387008;
            val_23 = null;
            val_23 = null;
            val_24 = 0;
            WADataParser.debug_lastReqDetermination = "playing challenge";
            return (int)val_24;
        }
        
        GameEcon val_4 = App.getGameEcon;
        if(Prefs.currentChapter < val_4.extraReqBeginningChapter)
        {
                GameEcon val_7 = App.getGameEcon;
            val_22 = "chapter (" + Prefs.currentChapter.ToString() + ") <= "(") <= ") + val_7.extraReqBeginningChapter.ToString();
            val_25 = null;
            val_25 = null;
            val_24 = 0;
            WADataParser.debug_lastReqDetermination = val_22;
            return (int)val_24;
        }
        
        val_22 = MainController.instance;
        if(val_22 == 0)
        {
                val_24 = 0;
            return (int)val_24;
        }
        
        val_22 = MainController.instance;
        string[] val_13 = new string[5];
        val_13[0] = "chosen lvls:";
        val_26 = val_13.Length;
        val_13[1] = MiniJSON.Json.Serialize(obj:  val_22);
        val_26 = val_13.Length;
        val_13[2] = " vs current: ";
        val_27 = val_13.Length;
        val_13[3] = Prefs.currentLevel.ToString();
        val_27 = val_13.Length;
        val_13[4] = "\n";
        val_28 = null;
        val_28 = null;
        WADataParser.debug_lastReqDetermination = +val_13;
        val_29 = null;
        if((val_22.Contains(item:  Prefs.currentLevel)) != false)
        {
                val_30 = null;
            WADataParser.debug_lastReqDetermination = WADataParser.debug_lastReqDetermination + "lvl was chosen!"("lvl was chosen!");
            val_24 = 1;
            return (int)val_24;
        }
        
        val_31 = null;
        val_24 = 0;
        WADataParser.debug_lastReqDetermination = WADataParser.debug_lastReqDetermination + "lvl not chosen";
        return (int)val_24;
    }
    public GameLevel BuildChallengingLevelForNormalProgression(int retries = 0)
    {
        do
        {
            do
        {
            int val_1 = UnityEngine.Random.Range(min:  3, max:  8);
            System.Collections.Generic.List<System.String> val_4 = this.UncommonWordsByLength.Item[val_1];
            var val_8 = 1152921515438561712;
            new System.Collections.Generic.List<System.String>(collection:  this.CommonWordsByLength.Item[val_1]).AddRange(collection:  val_4);
            int val_5 = UnityEngine.Random.Range(min:  0, max:  val_4);
            if(val_8 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_8 = val_8 + (val_5 << 3);
            .levelWord = (1152921515438561712 + (val_5) << 3) + 32;
            mem[1152921517730362356] = 257;
            .includeUncommonAsRequiredWords = true;
            mem[1152921517730362358] = true;
            .requiredExtraWords = true;
            GameLevel val_7 = this.BuildLevelBasedOnWord(param:  new BuildLevelBasedOnWordParams());
        }
        while(val_7 == null);
        
            int val_9 = retries;
            if(val_9 > 9)
        {
                return val_7;
        }
        
            val_9 = val_9 + 1;
        }
        while(val_7.actualWordCount < 5);
        
        return val_7;
    }
    public GameLevel BuildLevelOfWordLength(int desiredLength)
    {
        var val_9;
        var val_10;
        val_9 = 0;
        label_12:
        if((this.CommonWordsByLength.ContainsKey(key:  desiredLength)) == false)
        {
            goto label_9;
        }
        
        System.Collections.Generic.List<System.String> val_3 = this.CommonWordsByLength.Item[desiredLength];
        int val_4 = UnityEngine.Random.Range(min:  1, max:  desiredLength);
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_9 = this.CommonWordsByLength;
        System.Collections.Generic.List<System.String> val_5 = val_9.Item[desiredLength];
        if(val_9 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_9 = val_9 + (val_4 << 3);
        if((this.usedWordThisSession.Contains(item:  val_4)) == true)
        {
            goto label_9;
        }
        
        .levelWord = val_4;
        mem[1152921517730531700] = true;
        mem[1152921517730531680] = 18;
        .includeUncommonAsRequiredWords = true;
        .ignoreRetries = true;
        GameLevel val_7 = this.BuildLevelBasedOnWord(param:  new BuildLevelBasedOnWordParams());
        if(val_7 != null)
        {
            goto label_11;
        }
        
        label_9:
        val_9 = val_9 + 1;
        if(val_9 < 99)
        {
            goto label_12;
        }
        
        val_10 = 0;
        goto label_14;
        label_11:
        val_10 = val_7;
        label_14:
        if((this.usedWordThisSession.Contains(item:  (BuildLevelBasedOnWordParams)[1152921517730531664].levelWord)) == true)
        {
                return (GameLevel)val_10;
        }
        
        this.usedWordThisSession.Add(item:  (BuildLevelBasedOnWordParams)[1152921517730531664].levelWord);
        return (GameLevel)val_10;
    }
    public GameLevel BuildLevelContainingWordOfLength(BuildLevelBasedOnWordParams parametros)
    {
        return this.BuildLevelContainingWordOfLength(word:  parametros.levelWord, desiredLength:  parametros.levelWord.m_stringLength, desiredAnswers:  0, runWordRemoval:  false, lengthFlexibility:  0);
    }
    public GameLevel BuildLevelContainingWordOfLength(string word, int desiredLength, int desiredAnswers, bool runWordRemoval, int lengthFlexibility = 0)
    {
        string val_7;
        var val_8;
        var val_20;
        int val_21;
        string val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        val_21 = desiredLength;
        BuildLevelBasedOnWordParams val_1 = new BuildLevelBasedOnWordParams();
        if((lengthFlexibility & 2147483648) != 0)
        {
            goto label_1;
        }
        
        val_20 = 1152921504874737664;
        val_22 = 0;
        val_23 = 0;
        label_28:
        if((this.CommonWordsByLength.ContainsKey(key:  val_21)) == false)
        {
            goto label_3;
        }
        
        System.Collections.Generic.List<System.String> val_4 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.String> val_5 = this.FindLargerWordContainingWord(smallWord:  word, desiredLevelLength:  val_21);
        if(val_5 == null)
        {
            goto label_4;
        }
        
        if((public System.Void System.Collections.Generic.List<System.String>::.ctor()) == 0)
        {
            goto label_5;
        }
        
        List.Enumerator<T> val_6 = val_5.GetEnumerator();
        label_17:
        if(val_8.MoveNext() == false)
        {
            goto label_6;
        }
        
        BuildLevelBasedOnWordParams val_10 = new BuildLevelBasedOnWordParams();
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        .levelWord = val_7;
        mem[1152921517730890868] = runWordRemoval;
        mem[1152921517730890848] = desiredAnswers;
        GameLevel val_11 = this.BuildLevelBasedOnWord(param:  val_10);
        if(val_22 == 0)
        {
            goto label_17;
        }
        
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if((CUtils.BuildListFromString<System.String>(values:  val_11.answers, split:  '|')) == null)
        {
                throw new NullReferenceException();
        }
        
        if((CUtils.BuildListFromString<System.String>(values:  0, split:  '|')) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_14 = (val_11.answers > CUtils.__il2cppRuntimeField_cctor_finished) ? (val_11) : (val_22);
        if((CUtils.BuildListFromString<System.String>(values:  val_11.answers > CUtils.__il2cppRuntimeField_cctor_finished ? val_11 : val_22 + 72, split:  '|')) == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_18;
        label_3:
        val_25 = val_22;
        goto label_19;
        label_4:
        val_25 = val_22;
        goto label_23;
        label_6:
        val_24 = val_22;
        label_18:
        val_8.Dispose();
        val_25 = val_24;
        val_26 = 1;
        if(1 == 1)
        {
            goto label_22;
        }
        
        var val_16 = (222 == 222) ? 1 : 0;
        val_16 = ((val_26 >= 0) ? 1 : 0) & val_16;
        val_26 = val_26 - val_16;
        goto label_22;
        label_5:
        val_26 = 0;
        val_25 = val_22;
        label_22:
        if(val_25 != 0)
        {
                val_22 = 0;
            System.Collections.Generic.List<T> val_18 = CUtils.BuildListFromString<System.String>(values:  val_22, split:  '|');
        }
        
        label_23:
        val_21 = val_21 + 1;
        val_22 = val_25;
        label_19:
        val_23 = val_23 + 1;
        if(val_23 <= lengthFlexibility)
        {
            goto label_28;
        }
        
        return (GameLevel)val_25;
        label_1:
        val_25 = 0;
        return (GameLevel)val_25;
    }
    public System.Collections.Generic.List<string> FindLargerWordContainingWord(string smallWord, int desiredLevelLength)
    {
        string val_6;
        var val_7;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_21;
        int val_22;
        if(smallWord == null)
        {
                throw new NullReferenceException();
        }
        
        if(smallWord.m_stringLength >= desiredLevelLength)
        {
                return 0;
        }
        
        val_21 = this.CommonWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_21.ContainsKey(key:  desiredLevelLength)) == false)
        {
                return 0;
        }
        
        System.Collections.Generic.List<System.Boolean> val_2 = null;
        val_22 = public System.Void System.Collections.Generic.List<System.Boolean>::.ctor();
        val_2 = new System.Collections.Generic.List<System.Boolean>();
        if(smallWord.m_stringLength >= 1)
        {
                if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            var val_20 = 0;
            do
        {
            val_2.Add(item:  false);
            val_20 = val_20 + 1;
        }
        while(val_20 < smallWord.m_stringLength);
        
        }
        
        System.Collections.Generic.List<System.String> val_3 = null;
        val_22 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_3 = new System.Collections.Generic.List<System.String>();
        val_21 = this.CommonWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = desiredLevelLength;
        System.Collections.Generic.List<System.String> val_4 = val_21.Item[val_22];
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_4.GetEnumerator();
        label_13:
        bool val_8 = val_7.MoveNext();
        if(val_8 == false)
        {
            goto label_10;
        }
        
        val_22 = val_6;
        if((val_8.CanSpell(letters:  val_22, word:  smallWord, letterused:  null)) == false)
        {
            goto label_13;
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  val_6);
        goto label_13;
        label_10:
        val_22 = public System.Void List.Enumerator<System.String>::Dispose();
        val_7.Dispose();
        val_21 = this.UncommonWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = desiredLevelLength;
        if((val_21.ContainsKey(key:  val_22)) == false)
        {
            goto label_42;
        }
        
        val_21 = this.UncommonWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = desiredLevelLength;
        System.Collections.Generic.List<System.String> val_11 = val_21.Item[val_22];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_12 = val_11.GetEnumerator();
        label_21:
        bool val_13 = val_7.MoveNext();
        if(val_13 == false)
        {
            goto label_18;
        }
        
        val_22 = val_6;
        if((val_13.CanSpell(letters:  val_22, word:  smallWord, letterused:  null)) == false)
        {
            goto label_21;
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  val_6);
        goto label_21;
        label_18:
        val_22 = public System.Void List.Enumerator<System.String>::Dispose();
        val_7.Dispose();
        label_42:
        val_21 = this.RareWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = desiredLevelLength;
        if((val_21.ContainsKey(key:  val_22)) == false)
        {
                return 0;
        }
        
        val_21 = this.RareWordsByLength;
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22 = desiredLevelLength;
        System.Collections.Generic.List<System.String> val_16 = val_21.Item[val_22];
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_17 = val_16.GetEnumerator();
        label_29:
        bool val_18 = val_7.MoveNext();
        if(val_18 == false)
        {
            goto label_26;
        }
        
        if((val_18.CanSpell(letters:  val_6, word:  smallWord, letterused:  null)) == false)
        {
            goto label_29;
        }
        
        val_3.Add(item:  val_6);
        goto label_29;
        label_26:
        val_7.Dispose();
        return 0;
    }
    public System.Collections.Generic.List<string> GetAvailableWordsFromList(string word, System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> listToUse, int startingLength, int endingLength)
    {
        string val_7;
        var val_8;
        var val_13;
        int val_14 = startingLength;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        if(val_1.m_stringLength >= 1)
        {
                do
        {
            new System.Collections.Generic.List<System.Boolean>().Add(item:  false);
            val_13 = 0 + 1;
        }
        while(val_13 < val_1.m_stringLength);
        
        }
        
        if(val_14 > endingLength)
        {
                return val_2;
        }
        
        val_13 = 1152921513250978752;
        var val_12 = 0;
        label_16:
        if((listToUse.ContainsKey(key:  val_14)) == false)
        {
            goto label_15;
        }
        
        List.Enumerator<T> val_6 = listToUse.Item[val_14].GetEnumerator();
        label_14:
        bool val_9 = val_8.MoveNext();
        if(val_9 == false)
        {
            goto label_10;
        }
        
        if((val_9.CanSpell(letters:  word.Replace(oldValue:  "|", newValue:  ""), word:  val_7, letterused:  0)) == false)
        {
            goto label_14;
        }
        
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_2.Contains(item:  val_7)) == true)
        {
            goto label_14;
        }
        
        val_2.Add(item:  val_7);
        goto label_14;
        label_10:
        val_12 = val_12 + 1;
        val_8.Dispose();
        if(val_12 != 1)
        {
                var val_13 = 0;
            val_13 = val_13 ^ (val_12 >> 31);
            val_12 = val_12 + val_13;
        }
        
        label_15:
        val_14 = val_14 + 1;
        if(val_14 <= endingLength)
        {
            goto label_16;
        }
        
        return val_2;
    }
    private bool CanSpell(string letters, string word, System.Collections.Generic.List<bool> letterused)
    {
        var val_5;
        var val_6;
        System.Collections.Generic.List<System.Boolean> val_1 = new System.Collections.Generic.List<System.Boolean>();
        if(letters.m_stringLength >= 1)
        {
                val_5 = 1152921516198038128;
            var val_5 = 0;
            do
        {
            val_1.Add(item:  false);
            val_5 = val_5 + 1;
        }
        while(val_5 < letters.m_stringLength);
        
        }
        
        if(word.m_stringLength < 1)
        {
            goto label_6;
        }
        
        var val_7 = 0;
        label_14:
        int val_6 = letters.m_stringLength;
        if(val_6 < 1)
        {
            goto label_13;
        }
        
        val_5 = 0;
        do
        {
            if(val_5 >= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_6 = val_6 + val_5;
            if(((letters.m_stringLength + val_5) + 32) == 0)
        {
                if((letters.Chars[0] & 65535) == word.Chars[0])
        {
            goto label_11;
        }
        
        }
        
            val_5 = val_5 + 1;
        }
        while(val_5 < letters.m_stringLength);
        
        goto label_13;
        label_11:
        val_6 = 1;
        val_1.set_Item(index:  0, value:  true);
        val_7 = val_7 + 1;
        if(val_7 < word.m_stringLength)
        {
            goto label_14;
        }
        
        return (bool)val_6;
        label_13:
        val_6 = 0;
        return (bool)val_6;
        label_6:
        val_6 = 1;
        return (bool)val_6;
    }
    public void SaveWorldData(System.Collections.Generic.List<object> data)
    {
    
    }
    private LevelDefinition TranslateLevel(int playerLevel = -1)
    {
        int val_18;
        var val_19;
        System.Collections.Generic.List<System.Int32> val_20;
        val_18 = playerLevel;
        if(val_18 <= 0)
        {
                GameBehavior val_1 = App.getBehavior;
            val_18 = val_1.<metaGameBehavior>k__BackingField;
        }
        
        LevelDefinition val_2 = null;
        val_19 = val_2;
        val_2 = new LevelDefinition();
        .Level = val_18;
        GameBehavior val_3 = App.getBehavior;
        if(val_18 > this.MaxPredefinedLevels)
        {
                if((val_3.<metaGameBehavior>k__BackingField.GetCurrentLanguage().Equals(value:  "en")) == false)
        {
            goto label_13;
        }
        
        }
        
        if(val_18 <= this.MaxPredefinedLevels)
        {
            goto label_14;
        }
        
        var val_18 = ~this.MaxPredefinedLevels;
        int val_19 = this.builtInChapters;
        val_18 = val_18 + val_18;
        MetaGameBehavior val_9 = val_18 >> 63;
        val_18 = val_18 >> 35;
        val_18 = val_18 + val_9;
        val_19 = val_19 + val_18;
        val_19 = val_19 + 1;
        .Chapter = val_19;
        int val_20 = ~this.MaxPredefinedLevels;
        val_20 = val_18 + val_20;
        val_9 = val_18 >> 63;
        val_18 = val_18 >> 35;
        val_18 = val_18 + val_9;
        val_20 = val_20 - (val_18 * 20);
        val_20 = val_20 + 1;
        .ChapterLevel = val_20;
        return (LevelDefinition)val_19;
        label_13:
        int val_12 = UnityEngine.Random.Range(min:  this.minSpanishLevel, max:  this.MaxPredefinedLevels);
        var val_21 = 0;
        label_19:
        if(((this.usedSpanishLevels.Contains(item:  val_12)) == false) || (val_21 >= this.maxTries))
        {
            goto label_18;
        }
        
        int val_15 = UnityEngine.Random.Range(min:  this.minSpanishLevel, max:  this.MaxPredefinedLevels);
        val_21 = val_21 + 1;
        if(this.usedSpanishLevels != null)
        {
            goto label_19;
        }
        
        label_18:
        if(val_21 >= this.maxTries)
        {
            goto label_21;
        }
        
        val_20 = this.usedSpanishLevels;
        if(val_20 != null)
        {
            goto label_22;
        }
        
        label_21:
        System.Collections.Generic.List<System.Int32> val_16 = null;
        val_20 = val_16;
        val_16 = new System.Collections.Generic.List<System.Int32>();
        this.usedSpanishLevels = val_20;
        label_22:
        val_16.Add(item:  val_12);
        label_14:
        LevelDefinition val_17 = null;
        val_19 = val_17;
        val_17 = new LevelDefinition();
        return (LevelDefinition)val_19;
    }
    public static bool get_QAHACK_NoExtraRequired()
    {
        null = null;
        return (bool)WADataParser._QAHACK_NoExtraRequired;
    }
    public static void set_QAHACK_NoExtraRequired(bool value)
    {
        null = null;
        WADataParser._QAHACK_NoExtraRequired = value;
    }
    public int get_MaxPredefinedLevels()
    {
        int val_4;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage().Equals(value:  "en")) != false)
        {
                val_4 = this.maxPredefinedLevels;
            return 1000;
        }
        
        val_4 = 1000;
        return 1000;
    }
    public void set_MaxPredefinedLevels(int value)
    {
        this.maxPredefinedLevels = value;
    }
    public string get_PathToGameResources()
    {
        return "game/"("game/") + WordApp.GamePathName + "/"("/");
    }
    private void LoadDataIntoMemoryFromResources()
    {
        string val_3;
        var val_4;
        object val_10;
        LevelCurve val_11;
        System.String[] val_12;
        var val_13;
        GameBehavior val_1 = App.getBehavior;
        List.Enumerator<T> val_2 = val_1.<metaGameBehavior>k__BackingField.GetEnumerator();
        goto label_14;
        label_21:
        val_10 = "LoadDataIntoMemoryFromResources lang: "("LoadDataIntoMemoryFromResources lang: ") + val_3;
        val_11 = 0;
        UnityEngine.Debug.Log(message:  val_10);
        val_12 = this.buckets;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_10 = this.buckets.Length;
        if(val_10 >= 1)
        {
                var val_11 = 0;
            val_10 = val_10 & 4294967295;
            do
        {
            if(val_11 >= val_10)
        {
                throw new IndexOutOfRangeException();
        }
        
            LevelCurve val_6 = this.LoadBucketDataIntoMemoryFromResources(lang:  val_3, bucket:  null);
            val_11 = val_6;
            val_6.AddOrUpdateToLevelCurveList(curve:  val_11, levelCurves:  this.knownLevelCurves);
            val_11 = val_11 + 1;
        }
        while(val_11 < (this.buckets.Length << ));
        
        }
        
        if(this.featureBuckets == null)
        {
                throw new NullReferenceException();
        }
        
        int val_12 = this.featureBuckets.Length;
        if(val_12 >= 1)
        {
                val_12 = val_12 & 4294967295;
            do
        {
            LevelCurve val_7 = this.LoadBucketDataIntoMemoryFromResources(lang:  val_3, bucket:  1152921505252485504);
            if(val_7 != null)
        {
                val_7.AddOrUpdateToLevelCurveList(curve:  val_7, levelCurves:  this.featureLevelCurves);
        }
        else
        {
                val_12 = "Level Curve failed to load for feature bucket " + 1152921505252485504;
            UnityEngine.Debug.LogError(message:  val_12);
        }
        
            val_13 = 0 + 1;
        }
        while(val_13 < (this.featureBuckets.Length << ));
        
        }
        
        label_14:
        if(val_4.MoveNext() == true)
        {
            goto label_21;
        }
        
        val_4.Dispose();
    }
    private void LoadDataIntoMemoryFromResourcesRegularCurve(string lang, string bucket)
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[2];
        val_4 = val_1.Length;
        val_1[0] = lang;
        if(bucket != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[1] = bucket;
        UnityEngine.Debug.LogErrorFormat(format:  "Level Curve LoadDataIntoMemoryFromResources lang: {0} bucket {1}", args:  val_1);
        LevelCurve val_2 = this.LoadBucketDataIntoMemoryFromResources(lang:  lang, bucket:  bucket);
        if(val_2 != null)
        {
                val_2.AddOrUpdateToLevelCurveList(curve:  val_2, levelCurves:  this.knownLevelCurves);
            return;
        }
        
        object[] val_3 = new object[2];
        val_5 = val_3.Length;
        val_3[0] = lang;
        if(bucket != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = bucket;
        UnityEngine.Debug.LogErrorFormat(format:  "Level Curve failed to load for feature bucket lang: {0} bucket: {1}", args:  val_3);
    }
    private void LoadDataIntoMemoryFromResourcesFeatureCurve(string lang, string featureBucket)
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[2];
        val_4 = val_1.Length;
        val_1[0] = lang;
        if(featureBucket != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[1] = featureBucket;
        UnityEngine.Debug.LogErrorFormat(format:  "Feature Curve LoadDataIntoMemoryFromResources lang: {0} bucket {1}", args:  val_1);
        LevelCurve val_2 = this.LoadBucketDataIntoMemoryFromResources(lang:  lang, bucket:  featureBucket);
        if(val_2 != null)
        {
                val_2.AddOrUpdateToLevelCurveList(curve:  val_2, levelCurves:  this.featureLevelCurves);
            return;
        }
        
        object[] val_3 = new object[2];
        val_5 = val_3.Length;
        val_3[0] = lang;
        if(featureBucket != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = featureBucket;
        UnityEngine.Debug.LogErrorFormat(format:  "Feature Curve failed to load for feature bucket lang: {0} bucket: {1}", args:  val_3);
    }
    private WADataParser.LevelCurve LoadBucketDataIntoMemoryFromResources(string lang, string bucket)
    {
        UnityEngine.Object val_13;
        var val_14;
        var val_15;
        string val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.Dictionary<System.String, System.Object>>().PathToGameResources;
        val_13 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  val_2 + "Levels/"("Levels/") + val_2.GetLevelCurveSubPath(lang:  lang, bucket:  bucket)(val_2.GetLevelCurveSubPath(lang:  lang, bucket:  bucket))(val_2 + "Levels/"("Levels/") + val_2.GetLevelCurveSubPath(lang:  lang, bucket:  bucket)(val_2.GetLevelCurveSubPath(lang:  lang, bucket:  bucket))) + "/Flattened_Levels"("/Flattened_Levels"));
        val_14 = 0;
        if(val_13 == 0)
        {
                return (LevelCurve)val_14;
        }
        
        val_15 = 0;
        val_13 = MiniJSON.Json.Deserialize(json:  val_13.text).ParseFlatLevels(flatLevelsDef:  null);
        WADataParser.LevelCurve val_12 = null;
        val_14 = val_12;
        val_12 = new WADataParser.LevelCurve(language:  lang, bucket:  bucket, flattenedLevels:  val_13);
        return (LevelCurve)val_14;
    }
    private void LoadLengthsInMemoryFromResources()
    {
        var val_13;
        var val_14;
        var val_51;
        object val_52;
        var val_53;
        System.Collections.Generic.List<System.String> val_54;
        var val_55;
        var val_56;
        var val_57;
        System.Collections.Generic.Dictionary<TKey, TValue> val_58;
        val_51 = 1152921504884269056;
        val_52 = "";
        val_53 = null;
        val_53 = null;
        if(App.game == 1)
        {
                val_52 = System.String.Format(format:  "WordGroups/{0}/", arg0:  GetPlayerBucket());
        }
        
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_3 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
        mem[1152921517733508320] = val_3;
        if(val_6.Length < 1)
        {
            goto label_8;
        }
        
        val_51 = 1152921509851232320;
        label_23:
        T val_50 = UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  System.String.Format(format:  "{0}{1}{2}", arg0:  val_3.PathToGameResources, arg1:  val_52, arg2:  "CommonWords"))[0];
        object val_9 = MiniJSON.Json.Deserialize(json:  val_50.text);
        System.Collections.Generic.List<System.String> val_10 = null;
        val_54 = val_10;
        val_10 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_12 = GetEnumerator();
        label_20:
        if(val_14.MoveNext() == false)
        {
            goto label_16;
        }
        
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_13 != null)
        {
            goto label_31;
        }
        
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.Add(item:  val_13.ToUpper());
        goto label_20;
        label_16:
        val_55 = 0 + 1;
        mem2[0] = 168;
        val_14.Dispose();
        label_33:
        if(val_55 != 1)
        {
                var val_17 = ((1152921517733496096 + ((0 + 1)) << 2) == 168) ? 1 : 0;
            val_17 = ((val_55 >= 0) ? 1 : 0) & val_17;
            val_55 = val_55 - val_17;
        }
        
        val_3.Add(key:  System.Int32.Parse(s:  val_50.name), value:  val_10);
        val_56 = 0 + 1;
        if(val_56 < val_6.Length)
        {
            goto label_23;
        }
        
        goto label_24;
        label_31:
        if(null != 1)
        {
            goto label_87;
        }
        
        val_57 = mem[val_13];
        val_57 = val_13;
        val_14.Dispose();
        if(val_57 == 0)
        {
            goto label_33;
        }
        
        throw val_57 = val_13;
        label_8:
        val_55 = 0;
        label_24:
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_20 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
        mem[1152921517733508328] = val_20;
        if(val_23.Length < 1)
        {
            goto label_52;
        }
        
        val_51 = 1152921509851232320;
        label_51:
        T val_51 = UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  System.String.Format(format:  "{0}{1}{2}", arg0:  val_20.PathToGameResources, arg1:  val_52, arg2:  "UncommonWords"))[0];
        object val_26 = MiniJSON.Json.Deserialize(json:  val_51.text);
        System.Collections.Generic.List<System.String> val_27 = null;
        val_54 = val_27;
        val_27 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_29 = GetEnumerator();
        label_48:
        if(val_14.MoveNext() == false)
        {
            goto label_44;
        }
        
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_13 != null)
        {
            goto label_59;
        }
        
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        val_27.Add(item:  val_13.ToUpper());
        goto label_48;
        label_44:
        val_55 = val_55 + 1;
        mem2[0] = 335;
        val_14.Dispose();
        label_61:
        if(val_55 != 1)
        {
                var val_32 = ((1152921517733496096 + ((val_55 + 1)) << 2) == 335) ? 1 : 0;
            val_32 = ((val_55 >= 0) ? 1 : 0) & val_32;
            val_55 = val_55 - val_32;
        }
        
        val_20.Add(key:  System.Int32.Parse(s:  val_51.name), value:  val_27);
        val_56 = 0 + 1;
        if(val_56 < val_23.Length)
        {
            goto label_51;
        }
        
        goto label_52;
        label_59:
        if(null != 1)
        {
            goto label_87;
        }
        
        val_57 = mem[val_13];
        val_14.Dispose();
        if(val_57 == 0)
        {
            goto label_61;
        }
        
        throw val_57;
        label_52:
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_35 = null;
        val_58 = val_35;
        val_35 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>();
        mem[1152921517733508336] = val_58;
        if(val_38.Length < 1)
        {
                return;
        }
        
        val_56 = 1152921510211410768;
        val_51 = 1152921504622235648;
        var val_53 = 0;
        label_78:
        T val_52 = UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  System.String.Format(format:  "{0}{1}{2}", arg0:  val_35.PathToGameResources, arg1:  val_52, arg2:  "RareWords"))[val_53];
        val_58 = val_52.name;
        object val_41 = MiniJSON.Json.Deserialize(json:  val_52.text);
        System.Collections.Generic.List<System.String> val_42 = new System.Collections.Generic.List<System.String>();
        List.Enumerator<T> val_44 = GetEnumerator();
        label_75:
        if(val_14.MoveNext() == false)
        {
            goto label_71;
        }
        
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_13 != null)
        {
            goto label_86;
        }
        
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.Add(item:  val_13.ToUpper());
        goto label_75;
        label_71:
        val_55 = val_55 + 1;
        mem2[0] = 503;
        val_14.Dispose();
        label_88:
        if(val_55 != 1)
        {
                var val_47 = ((1152921517733496096 + ((val_55 + 1)) << 2) == 503) ? 1 : 0;
            val_47 = ((val_55 >= 0) ? 1 : 0) & val_47;
            val_55 = val_55 - val_47;
        }
        
        val_54 = mem[1152921517733508336];
        val_35.Add(key:  System.Int32.Parse(s:  val_58), value:  val_42);
        val_53 = val_53 + 1;
        if(val_53 < val_38.Length)
        {
            goto label_78;
        }
        
        return;
        label_86:
        if(null != 1)
        {
            goto label_87;
        }
        
        val_54 = mem[val_13];
        val_54 = val_13;
        val_14.Dispose();
        if(val_54 == 0)
        {
            goto label_88;
        }
        
        throw val_54;
        label_87:
    }
    public void SaveLevelsFromChaptersDict(System.Collections.Generic.List<object> fromLoadedData, string language)
    {
        var val_7;
        int val_8;
        string val_15;
        this.Initialize();
        if(((System.String.IsNullOrEmpty(value:  language)) != true) && ((System.String.op_Equality(a:  language, b:  "en_us")) != true))
        {
                if((System.String.op_Equality(a:  language, b:  "en")) != true)
        {
                string val_5 = UnityEngine.Application.persistentDataPath + "/"("/") + language;
        }
        
        }
        
        List.Enumerator<T> val_6 = fromLoadedData.GetEnumerator();
        label_12:
        val_15 = public System.Boolean List.Enumerator<System.Object>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15 = "o";
        object val_10 = val_7.Item[val_15];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_15 = "n";
        object val_13 = val_7.Item[val_15];
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(key:  "name", value:  val_13);
        val_8 = System.Int32.Parse(s:  val_10, style:  511);
        val_12.Add(key:  "index", value:  val_8);
        val_12.Add(key:  "levels", value:  val_7.Item["l"]);
        goto label_12;
        label_5:
        val_8.Dispose();
    }
    public static string get_QAHACK_RanOutReason()
    {
        null = null;
        return (string)WADataParser.Debug_RanOutWhenTranslating;
    }
    public static string get_QAHACK_FinishedReason()
    {
        null = null;
        return (string)WADataParser.Debug_FinishedContent;
    }
    public static string get_QAHACK_SetDesiredLevelGenWord()
    {
        null = null;
        return (string)WADataParser.QAhackedWord;
    }
    public static void set_QAHACK_SetDesiredLevelGenWord(string value)
    {
        null = null;
        WADataParser.QAhackedWord = value;
    }
    public void CallEmptyMethod()
    {
    
    }
    public bool get_HasInitialized()
    {
        return (bool)this.initialized;
    }
    private void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnDeferredReady");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnWordData");
        this.Initialize();
    }
    private void OnWordData()
    {
    
    }
    public void ReInitialize()
    {
        if(this.initialized == false)
        {
                return;
        }
        
        if(this.initializing != false)
        {
                return;
        }
        
        this.initialized = false;
        this.Initialize();
    }
    private void Initialize()
    {
        var val_4;
        if(this.initialized == true)
        {
                return;
        }
        
        if(this.initializing != false)
        {
                return;
        }
        
        this.initializing = true;
        GameBehavior val_1 = App.getBehavior;
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        this.LoadDataIntoMemoryFromResourcesRegularCurve(lang:  val_2, bucket:  "A");
        Player val_3 = App.Player;
        this.LoadDataIntoMemoryFromResourcesFeatureCurve(lang:  val_2, featureBucket:  val_3.playerBucket);
        this.LoadLengthsInMemoryFromResources();
        this.LoadPlayerVars();
        this.initialized = true;
        this.initializing = false;
        val_4 = null;
        val_4 = null;
        WordApp.CurrentlyLoadedLevelGenVersion = true;
        if(this.OnWADataParseInit == null)
        {
                return;
        }
        
        this.OnWADataParseInit.Invoke();
    }
    public void Unload()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void LoadPlayerVars()
    {
        string val_15;
        var val_16;
        var val_19;
        string val_20;
        var val_21;
        val_19 = 1152921504874684416;
        if(((CPlayerPrefs.HasKey(key:  "wadwut_pl_vars")) == false) || ((UnityEngine.PlayerPrefs.GetInt(key:  "wadwut_lg_version", defaultValue:  1)) != 3))
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
        label_12:
        if(1152921510062986752 >= 20)
        {
            goto label_11;
        }
        
        val_5.Add(item:  System.Linq.Enumerable.LastOrDefault<System.Int32>(source:  val_5));
        if(this.plv_chapterWordLengths != null)
        {
            goto label_12;
        }
        
        throw new NullReferenceException();
        label_11:
        UnityEngine.PlayerPrefs.SetInt(key:  "wadwut_lg_version", value:  3);
        bool val_7 = PrefsSerializationManager.SavePlayerPrefs();
        label_9:
        if((CPlayerPrefs.HasKey(key:  "wadwut_pw_vars")) == false)
        {
            goto label_17;
        }
        
        val_20 = CPlayerPrefs.GetString(key:  "wadwut_pw_vars", defaultValue:  "");
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
        object val_11 = MiniJSON.Json.Deserialize(json:  val_20);
        goto label_24;
        label_17:
        label_43:
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
        return;
        label_24:
        List.Enumerator<T> val_14 = GetEnumerator();
        val_19 = 1152921510211410768;
        label_29:
        if(val_16.MoveNext() == false)
        {
            goto label_26;
        }
        
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_20 = this.plv_playedWords;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20.Add(item:  val_15);
        goto label_29;
        label_26:
        val_20 = 0;
        val_16.Dispose();
        if(val_20 != 0)
        {
                throw val_20;
        }
        
        return;
        label_44:
        val_21 = val_20;
        if(0 != 1)
        {
            goto label_41;
        }
        
        if((null & 1) == 0)
        {
            goto label_42;
        }
        
        goto label_43;
        label_42:
        mem[8] = null;
        goto label_44;
        label_41:
    }
    private void StorePlayerVars()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) >= this.MaxPredefinedLevels)
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
    private string GetLevelCurveSubPath(string lang, string bucket)
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        object val_10;
        val_4 = null;
        val_4 = null;
        if(App.game != 1)
        {
                val_5 = null;
            val_5 = null;
            if(App.game != 10)
        {
                val_6 = null;
            val_6 = null;
            if(App.game != 7)
        {
                val_7 = null;
            val_7 = null;
            if(App.game != 4)
        {
                val_8 = null;
            val_8 = null;
            if(App.game != 18)
        {
                val_9 = null;
            val_9 = null;
            if(App.game != 9)
        {
                return (string)lang;
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        if((System.String.op_Inequality(a:  lang, b:  "en")) != false)
        {
                return System.String.Format(format:  "{0}/{1}", arg0:  "android", arg1:  lang);
        }
        
        if((System.String.op_Equality(a:  bucket, b:  "A")) != false)
        {
                val_10 = "";
            return System.String.Format(format:  "{0}/{1}{2}", arg0:  "android", arg1:  lang, arg2:  val_10 = System.String.Format(format:  "_{0}", arg0:  bucket));
        }
        
        return System.String.Format(format:  "{0}/{1}{2}", arg0:  "android", arg1:  lang, arg2:  val_10);
    }
    private string GetPlayerBucket()
    {
        Player val_1 = App.Player;
        return (string)val_1.playerBucket;
    }
    private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<string>> get_AllKnownWords()
    {
        int val_18;
        var val_19;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>> val_26;
        var val_27;
        var val_28;
        System.Func<System.String, System.Int32> val_30;
        var val_31;
        System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32> val_33;
        System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>> val_35;
        int val_36;
        if(this._AllKnownWords != null)
        {
                return (System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>)this._AllKnownWords;
        }
        
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        if(this.MaxPredefinedLevels >= 2)
        {
                do
        {
            if(this.CurrentLevelCurveGameLevels == null)
        {
                throw new NullReferenceException();
        }
        
            if(1152921509851217984 <= (5 - 4))
        {
                val_26 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            char[] val_5 = new char[1];
            if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
            val_5[0] = 124;
            if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_1.AddRange(collection:  new System.Collections.Generic.List<System.String>(collection:  "uriPrefix".__il2cppRuntimeField_48.Split(separator:  val_5)));
            val_27 = 5 + 1;
        }
        while((val_27 - 4) < this.MaxPredefinedLevels);
        
        }
        
        val_28 = null;
        val_28 = null;
        val_30 = WADataParser.<>c.<>9__102_0;
        if(val_30 == null)
        {
                System.Func<System.String, System.Int32> val_11 = null;
            val_30 = val_11;
            val_11 = new System.Func<System.String, System.Int32>(object:  WADataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADataParser.<>c::<get_AllKnownWords>b__102_0(string x));
            WADataParser.<>c.<>9__102_0 = val_30;
        }
        
        val_31 = null;
        val_31 = null;
        val_33 = WADataParser.<>c.<>9__102_1;
        if(val_33 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32> val_13 = null;
            val_33 = val_13;
            val_13 = new System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Int32>(object:  WADataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADataParser.<>c::<get_AllKnownWords>b__102_1(System.Linq.IGrouping<int, string> x));
            val_31 = null;
            WADataParser.<>c.<>9__102_1 = val_33;
        }
        
        val_31 = null;
        val_35 = WADataParser.<>c.<>9__102_2;
        if(val_35 == null)
        {
                System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>> val_14 = null;
            val_35 = val_14;
            val_14 = new System.Func<System.Linq.IGrouping<System.Int32, System.String>, System.Collections.Generic.List<System.String>>(object:  WADataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Collections.Generic.List<System.String> WADataParser.<>c::<get_AllKnownWords>b__102_2(System.Linq.IGrouping<int, string> x));
            WADataParser.<>c.<>9__102_2 = val_35;
        }
        
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = this.CommonWordsByLength;
        this._AllKnownWords = System.Linq.Enumerable.ToDictionary<System.Linq.IGrouping<System.Int32, System.String>, System.Int32, System.Collections.Generic.List<System.String>>(source:  System.Linq.Enumerable.GroupBy<System.String, System.Int32>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  val_1), keySelector:  val_11), keySelector:  val_13, elementSelector:  val_14);
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_16 = val_26.GetEnumerator();
        label_36:
        if(val_19.MoveNext() == false)
        {
            goto label_28;
        }
        
        val_26 = this._AllKnownWords;
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_18;
        if((val_26.ContainsKey(key:  val_36)) == false)
        {
            goto label_30;
        }
        
        if(this._AllKnownWords == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_18;
        System.Collections.Generic.List<System.String> val_22 = this._AllKnownWords.Item[val_36];
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36 = val_18;
        val_22.AddRange(collection:  val_36);
        if(this._AllKnownWords == null)
        {
                throw new NullReferenceException();
        }
        
        this._AllKnownWords.set_Item(key:  val_18, value:  System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Distinct<System.String>(source:  this._AllKnownWords.Item[val_18])));
        goto label_36;
        label_30:
        this._AllKnownWords.Add(key:  val_18, value:  new System.Collections.Generic.List<System.String>(collection:  val_18));
        goto label_36;
        label_28:
        val_19.Dispose();
        return (System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.String>>)this._AllKnownWords;
    }
    public int GetAllPossibleWordsCount()
    {
        int val_4 = this.allPossibleWords;
        if(val_4 > 0)
        {
                return val_4;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_2 = this.AllKnownWords.GetEnumerator();
        val_4 = 0;
        goto label_3;
        label_5:
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_4 = 9733424;
        label_3:
        if(0.MoveNext() == true)
        {
            goto label_5;
        }
        
        0.Dispose();
        this.allPossibleWords = val_4;
        return val_4;
    }
    public int GetPossibleWordsCount(int numLetters)
    {
        return (int)this.AllKnownWords.Item[numLetters];
    }
    private System.Collections.Generic.List<GameLevel> FlattenLevels(System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<string, object>> chaptersToUse)
    {
        var val_5;
        var val_6;
        var val_17;
        var val_20;
        var val_21;
        var val_22;
        var val_25;
        System.Func<GameLevel, System.Int32> val_27;
        val_17 = chaptersToUse;
        System.Collections.Generic.List<GameLevel> val_1 = new System.Collections.Generic.List<GameLevel>();
        System.Collections.Generic.Dictionary<System.Int32, GameLevel> val_2 = new System.Collections.Generic.Dictionary<System.Int32, GameLevel>();
        Dictionary.ValueCollection.Enumerator<TKey, TValue> val_4 = val_17.Values.GetEnumerator();
        label_19:
        val_20 = public System.Boolean Dictionary.ValueCollection.Enumerator<System.Int32, System.Collections.Generic.Dictionary<System.String, System.Object>>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_3;
        }
        
        val_21 = val_5;
        if(val_21 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_21.Item["levels"] == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_10 = GetEnumerator();
        label_15:
        bool val_11 = val_6.MoveNext();
        if(val_11 == false)
        {
            goto label_10;
        }
        
        val_22 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_11.ParseLevel(thisLevel:  null));
        goto label_15;
        label_10:
        val_17 = 0;
        var val_14 = 0 + 1;
        mem2[0] = 111;
        val_6.Dispose();
        if(val_17 != 0)
        {
            goto label_16;
        }
        
        if((val_14 == 1) || ((1152921517737199776 + ((0 + 1)) << 2) != 111))
        {
            goto label_19;
        }
        
        var val_20 = 0;
        val_20 = val_20 ^ (val_14 >> 31);
        var val_15 = val_14 + val_20;
        goto label_19;
        label_3:
        var val_16 = 0 + 1;
        mem2[0] = 136;
        val_6.Dispose();
        val_25 = null;
        val_25 = null;
        val_27 = WADataParser.<>c.<>9__106_0;
        if(val_27 != null)
        {
                return (System.Collections.Generic.List<GameLevel>)System.Linq.Enumerable.ToList<GameLevel>(source:  System.Linq.Enumerable.OrderBy<GameLevel, System.Int32>(source:  val_1, keySelector:  System.Func<GameLevel, System.Int32> val_17 = null));
        }
        
        val_27 = val_17;
        val_17 = new System.Func<GameLevel, System.Int32>(object:  WADataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADataParser.<>c::<FlattenLevels>b__106_0(GameLevel x));
        WADataParser.<>c.<>9__106_0 = val_27;
        return (System.Collections.Generic.List<GameLevel>)System.Linq.Enumerable.ToList<GameLevel>(source:  System.Linq.Enumerable.OrderBy<GameLevel, System.Int32>(source:  val_1, keySelector:  val_17));
        label_16:
        val_21 = val_17;
        val_20 = 0;
        throw val_21;
    }
    private System.Collections.Generic.List<GameLevel> ParseFlatLevels(System.Collections.Generic.Dictionary<string, object> flatLevelsDef)
    {
        var val_5;
        var val_12;
        var val_13;
        var val_14;
        System.Func<GameLevel, System.Int32> val_16;
        System.Collections.Generic.List<GameLevel> val_1 = new System.Collections.Generic.List<GameLevel>();
        List.Enumerator<T> val_3 = flatLevelsDef.Item["levels"].GetEnumerator();
        val_12 = 1152921504685600768;
        label_10:
        bool val_6 = val_5.MoveNext();
        if(val_6 == false)
        {
            goto label_5;
        }
        
        val_13 = 0;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_6.ParseLevel(thisLevel:  null));
        goto label_10;
        label_5:
        val_5.Dispose();
        val_14 = null;
        val_14 = null;
        val_16 = WADataParser.<>c.<>9__107_0;
        if(val_16 != null)
        {
                return (System.Collections.Generic.List<GameLevel>)System.Linq.Enumerable.ToList<GameLevel>(source:  System.Linq.Enumerable.OrderBy<GameLevel, System.Int32>(source:  val_1, keySelector:  System.Func<GameLevel, System.Int32> val_9 = null));
        }
        
        val_16 = val_9;
        val_9 = new System.Func<GameLevel, System.Int32>(object:  WADataParser.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WADataParser.<>c::<ParseFlatLevels>b__107_0(GameLevel x));
        WADataParser.<>c.<>9__107_0 = val_16;
        return (System.Collections.Generic.List<GameLevel>)System.Linq.Enumerable.ToList<GameLevel>(source:  System.Linq.Enumerable.OrderBy<GameLevel, System.Int32>(source:  val_1, keySelector:  val_9));
    }
    private void AddOrUpdateKnownLevelCurve(WADataParser.LevelCurve curve)
    {
        this.AddOrUpdateToLevelCurveList(curve:  curve, levelCurves:  this.knownLevelCurves);
    }
    private void AddOrUpdateFeatureLevelCurve(WADataParser.LevelCurve curve)
    {
        this.AddOrUpdateToLevelCurveList(curve:  curve, levelCurves:  this.featureLevelCurves);
    }
    private void AddOrUpdateToLevelCurveList(WADataParser.LevelCurve curve, System.Collections.Generic.List<WADataParser.LevelCurve> levelCurves)
    {
        var val_3;
        bool val_3 = true;
        if(curve == null)
        {
                return;
        }
        
        if(val_3 < 1)
        {
            goto label_11;
        }
        
        label_10:
        if(val_3 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_3 = val_3 + 0;
        var val_4 = (true + 0) + 32;
        if((System.String.op_Equality(a:  (true + 0) + 32 + 24, b:  curve.Language)) == false)
        {
            goto label_6;
        }
        
        if(val_4 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + 0;
        if((System.String.op_Equality(a:  ((true + 0) + 32 + 0) + 32 + 16, b:  curve.Bucket)) == true)
        {
            goto label_9;
        }
        
        label_6:
        val_3 = 0 + 1;
        if(val_3 < (((true + 0) + 32 + 0) + 32))
        {
            goto label_10;
        }
        
        label_11:
        levelCurves.Add(item:  curve);
        return;
        label_9:
        if((0 & 2147483648) != 0)
        {
            goto label_11;
        }
        
        levelCurves.set_Item(index:  0, value:  curve);
    }
    public WADataParser.LevelCurve GetLevelCurve(string lang, string bucket)
    {
        if((this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.knownLevelCurves)) != null)
        {
                return this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.knownLevelCurves);
        }
        
        this.LoadDataIntoMemoryFromResourcesRegularCurve(lang:  lang, bucket:  bucket);
        return this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.knownLevelCurves);
    }
    public WADataParser.LevelCurve GetFeatureLevelCurve(string lang, string bucket)
    {
        if((this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.featureLevelCurves)) != null)
        {
                return this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.featureLevelCurves);
        }
        
        this.LoadDataIntoMemoryFromResourcesFeatureCurve(lang:  lang, featureBucket:  bucket);
        return this.GetLevelCurveFromList(lang:  lang, bucket:  bucket, levelCurves:  this.featureLevelCurves);
    }
    private WADataParser.LevelCurve GetLevelCurveFromList(string lang, string bucket, System.Collections.Generic.List<WADataParser.LevelCurve> levelCurves)
    {
        .lang = lang;
        .bucket = bucket;
        return System.Linq.Enumerable.FirstOrDefault<LevelCurve>(source:  levelCurves, predicate:  new System.Func<LevelCurve, System.Boolean>(object:  new WADataParser.<>c__DisplayClass116_0(), method:  System.Boolean WADataParser.<>c__DisplayClass116_0::<GetLevelCurveFromList>b__0(WADataParser.LevelCurve p)));
    }
    public WADataParser()
    {
        int val_10;
        int val_11;
        this.this_generator = new CrosswordCreator.Crossword.CrosswordGenerator();
        this.usedWordThisSession = new System.Collections.Generic.List<System.String>();
        this.usedSpanishLevels = new System.Collections.Generic.List<System.Int32>();
        this.maxTries = ;
        this.minSpanishLevel = ;
        this.maxPredefinedLevels = 442381632488;
        this.builtInChapters = 103;
        string[] val_4 = new string[2];
        val_10 = val_4.Length;
        val_4[0] = "A";
        val_10 = val_4.Length;
        val_4[1] = "B";
        this.buckets = val_4;
        string[] val_5 = new string[2];
        val_11 = val_5.Length;
        val_5[0] = "D";
        val_11 = val_5.Length;
        val_5[1] = "E";
        this.featureBuckets = val_5;
        System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  6);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        val_6.Add(item:  7);
        this.plv_chapterWordLengths = val_6;
        this.plv_playedWords = new System.Collections.Generic.List<System.String>();
        this.knownLevelCurves = new System.Collections.Generic.List<LevelCurve>();
        this.featureLevelCurves = new System.Collections.Generic.List<LevelCurve>();
    }
    private static WADataParser()
    {
        WADataParser.CurrentLevelGenVersion = "n/a";
        WADataParser.CurrentLevelGenVersion.__il2cppRuntimeField_3 = 268435458;
        WADataParser.debug_lastReqDetermination = "n/a";
        WADataParser.debug_uncommonInAnswers = "n/a";
        WADataParser.debug_uncommonInRequiredExtra = "n/a";
        WADataParser._QAHACK_NoExtraRequired = false;
        WADataParser.Debug_RanOutWhenTranslating = "False. Has not parsed any level data yet.";
        WADataParser.Debug_FinishedContent = "False. Has not checked for finished content yet.";
        WADataParser.QAhackedWord = System.String.alignConst;
    }

}

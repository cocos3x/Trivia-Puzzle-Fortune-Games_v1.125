using UnityEngine;
public class WordLevelGen : MonoSingletonSelfGenerating<WordLevelGen>
{
    // Fields
    private System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<string>>> RequiredDictionary;
    private const int NEVER_UNLOCK = 10000000;
    private System.Collections.Generic.List<int> DictionaryUnlockLevels;
    private System.Collections.Generic.List<string> DictionaryLoadPaths;
    private System.Collections.Generic.List<System.Collections.Generic.List<string>> CurrentRequiredDictionary;
    private const string CRD_PREFKEY = "wlg_crd";
    private System.Collections.Generic.List<int> UnlocksAdded;
    private const string UNLOCKS_ADDED_PREFKEY = "wlg_ula";
    private System.Collections.Generic.List<string> DefinedWords;
    private System.Collections.Generic.List<GameLevel> DefinedLevels;
    private bool initialized;
    private bool initializing;
    private bool knobsLoaded;
    public const int MIN_WORD_LENGTH = 3;
    public const int MAX_WORD_LENGTH = 7;
    public const int LEVEL_WORD_MINIMUM = 3;
    public static int LEVEL_WORD_MAXIMUM_KNOB;
    public System.Collections.Generic.List<int> LevelWordMaximums;
    public const int CHAPTERS_PER_BOOK = 4;
    public const int LEVEL_GEN_VERSION = 2;
    public static int[] chapter_lengths;
    public System.Action OnWordLevelGenInit;
    private int allPossibleWords;
    
    // Properties
    public bool HasInitialized { get; }
    public int DefinedLevelCount { get; }
    public string PathToGameResources { get; }
    
    // Methods
    public bool get_HasInitialized()
    {
        return (bool)this.initialized;
    }
    public int CurrentLevelWordMaximum()
    {
        null = null;
        return (int)WordLevelGen.LEVEL_GEN_VERSION;
    }
    public static int GetCurrentChapter(int playerLevel = -1)
    {
        int val_1 = WordLevelGen.GetCurrentCumulativeChapter(playerLevel:  playerLevel);
        int val_2 = val_1 - 1;
        var val_4 = (val_2 < 0) ? (val_1 + 2) : (val_2);
        val_4 = val_4 & 4294967292;
        val_2 = val_2 - val_4;
        val_1 = val_2 + 1;
        return (int)val_1;
    }
    public static int GetCurrentCumulativeChapter(int playerLevel = -1)
    {
        var val_5;
        var val_6;
        val_5 = playerLevel;
        if(val_5 <= 0)
        {
                Player val_1 = App.Player;
            val_5 = val_1;
            if(val_1 < 1)
        {
                return (int)val_5;
        }
        
        }
        
        var val_5 = 0;
        do
        {
            val_6 = null;
            val_6 = null;
            System.Int32[] val_4 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            val_5 = val_5 + 1;
            val_5 = val_5 - ((WordLevelGen.chapter_lengths + (val_3) << 2) + 32);
        }
        while(val_5 > 0);
        
        return (int)val_5;
    }
    public static int GetFirstLevelOfChapter(int playerLevel = -1)
    {
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        val_9 = playerLevel;
        if(val_9 <= 0)
        {
                Player val_1 = App.Player;
            val_9 = val_1;
            if(val_1 < 1)
        {
                return (int)val_9;
        }
        
        }
        
        var val_9 = 0;
        val_10 = val_9;
        label_19:
        val_11 = null;
        val_11 = null;
        System.Int32[] val_4 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
        if(((WordLevelGen.chapter_lengths + (val_3) << 2) + 32) >= val_10)
        {
            goto label_12;
        }
        
        val_12 = null;
        val_12 = null;
        System.Int32[] val_7 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
        val_9 = val_9 + 1;
        val_10 = val_10 - ((WordLevelGen.chapter_lengths + (val_6) << 2) + 32);
        if(val_10 > 0)
        {
            goto label_19;
        }
        
        return (int)val_9;
        label_12:
        val_9 = (val_9 + 1) - val_10;
        return (int)val_9;
    }
    public static int GetLastLevelOfChapter(int playerLevel = -1)
    {
        var val_10;
        System.Int32[] val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        var val_16;
        val_10 = playerLevel;
        if(val_10 <= 0)
        {
                Player val_1 = App.Player;
            val_10 = val_1;
            if(val_1 < 1)
        {
                return (int)val_10;
        }
        
        }
        
        val_11 = 1152921504997474304;
        var val_11 = 0;
        val_12 = val_10;
        label_19:
        val_13 = null;
        val_13 = null;
        int val_10 = System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1);
        val_14 = null;
        val_10 = WordLevelGen.chapter_lengths + (val_10 << 2);
        if(((WordLevelGen.chapter_lengths + (val_3) << 2) + 32) >= val_12)
        {
            goto label_12;
        }
        
        val_15 = null;
        System.Int32[] val_6 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
        val_11 = val_11 + 1;
        val_12 = val_12 - ((WordLevelGen.chapter_lengths + (val_5) << 2) + 32);
        if(val_12 > 0)
        {
            goto label_19;
        }
        
        return (int)val_10;
        label_12:
        val_16 = null;
        val_11 = WordLevelGen.chapter_lengths;
        System.Int32[] val_9 = val_11 + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
        var val_12 = ~val_12;
        val_12 = val_10 + val_12;
        val_10 = val_12 + ((WordLevelGen.chapter_lengths + (val_8) << 2) + 32);
        return (int)val_10;
    }
    public static int GetLevelWithinChapter(int playerLevel = -1)
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        val_8 = playerLevel;
        if(val_8 <= 0)
        {
                Player val_1 = App.Player;
            val_8 = val_1;
            val_9 = val_1;
            if(val_1 < 1)
        {
                return (int)val_9;
        }
        
        }
        
        val_10 = 0;
        val_9 = val_8;
        do
        {
            val_11 = null;
            val_11 = null;
            System.Int32[] val_4 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            if(((WordLevelGen.chapter_lengths + (val_3) << 2) + 32) >= val_9)
        {
                return (int)val_9;
        }
        
            val_12 = null;
            val_12 = null;
            System.Int32[] val_7 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            val_10 = val_10 + 1;
            val_9 = val_9 - ((WordLevelGen.chapter_lengths + (val_6) << 2) + 32);
        }
        while(val_9 > 0);
        
        val_9 = val_8;
        return (int)val_9;
    }
    public static int GetLevelsPerChapter(int playerLevel = -1)
    {
        null = null;
        int val_3 = (System.Math.Min(val1:  WordLevelGen.GetCurrentCumulativeChapter(playerLevel:  playerLevel), val2:  WordLevelGen.chapter_lengths.Length)) - 1;
        val_3 = WordLevelGen.chapter_lengths + (val_3 << 2);
        return (int)(WordLevelGen.chapter_lengths + ((val_2 - 1)) << 2) + 32;
    }
    public static int GetLevelsForChapter(int chapter)
    {
        null = null;
        System.Int32[] val_5 = WordLevelGen.chapter_lengths + ((System.Math.Max(val1:  System.Math.Min(val1:  chapter - 1, val2:  WordLevelGen.chapter_lengths.Length - 1), val2:  0)) << 2);
        return (int)(WordLevelGen.chapter_lengths + (val_4) << 2) + 32;
    }
    public static int GetLevelsThroughChapter(int chapter)
    {
        var val_2;
        if(chapter >= 1)
        {
                var val_2 = 1;
            do
        {
            val_2 = val_2 + 1;
            val_2 = (WordLevelGen.GetLevelsForChapter(chapter:  1)) + 0;
        }
        while(val_2 <= chapter);
        
            return (int)val_2;
        }
        
        val_2 = 0;
        return (int)val_2;
    }
    public static int GetFirstLevelOfBook(int playerLevel = -1)
    {
        var val_5;
        var val_6;
        val_5 = playerLevel;
        if(val_5 <= 0)
        {
                Player val_1 = App.Player;
            val_5 = val_1;
            if(val_1 < 1)
        {
                return (int)val_7;
        }
        
        }
        
        var val_8 = 0;
        var val_7 = 1;
        do
        {
            do
        {
            val_6 = null;
            val_6 = null;
            System.Int32[] val_5 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  val_8 + 0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            val_7 = ((WordLevelGen.chapter_lengths + (val_4) << 2) + 32) + val_7;
        }
        while(0 < 3);
        
            val_8 = val_8 + (0 + 1);
        }
        while(val_7 <= val_5);
        
        return (int)val_7;
    }
    public static int GetFirstLevelOfSecondBook()
    {
        var val_4;
        var val_6 = 1;
        var val_5 = 0;
        do
        {
            val_4 = null;
            val_4 = null;
            System.Int32[] val_4 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  val_5 + 1, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            val_5 = val_5 + 1;
            val_6 = ((WordLevelGen.chapter_lengths + (val_3) << 2) + 32) + val_6;
        }
        while(val_5 < 3);
        
        return (int)val_6;
    }
    public static int GetCurrentBook(int playerLevel = -1)
    {
        var val_5;
        var val_6;
        val_5 = playerLevel;
        if(val_5 <= 0)
        {
                Player val_1 = App.Player;
            val_5 = val_1;
            if(val_1 < 1)
        {
                return (int)val_7;
        }
        
        }
        
        var val_7 = 0;
        var val_9 = 0;
        var val_8 = 1;
        do
        {
            val_7 = val_7 + 1;
            do
        {
            val_6 = null;
            val_6 = null;
            System.Int32[] val_5 = WordLevelGen.chapter_lengths + ((System.Math.Min(val1:  val_9 + 0, val2:  WordLevelGen.chapter_lengths.Length - 1)) << 2);
            val_8 = ((WordLevelGen.chapter_lengths + (val_4) << 2) + 32) + val_8;
        }
        while(0 < 3);
        
            val_9 = val_9 + (0 + 1);
        }
        while(val_8 <= val_5);
        
        return (int)val_7;
    }
    public GameLevel GetDefinedLevel(int index)
    {
        System.Collections.Generic.List<GameLevel> val_4;
        bool val_4 = true;
        val_4 = this.DefinedLevels;
        if(val_4 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + (index << 3);
        var val_5 = (true + (index) << 3) + 32;
        if(val_5 == 0)
        {
                if(val_5 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + (((long)(int)(index)) << 3);
            var val_6 = 1152921518022982176;
            this.DefinedLevels.set_Item(index:  index, value:  this.BuildLevelBasedOnWord(daWord:  ((true + (index) << 3) + 32 + ((long)(int)(index)) << 3) + 32, maxWordCount:  0, keepWord:  0));
            if(val_6 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_6 = val_6 + (((long)(int)(index)) << 3);
            val_4 = mem[(1152921518022982176 + ((long)(int)(index)) << 3) + 32];
            val_4 = (1152921518022982176 + ((long)(int)(index)) << 3) + 32;
            int val_2 = index + 1;
            val_4.levelName = val_2.ToString();
        }
        
        if(val_2 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_2 = val_2 + (((long)(int)(index)) << 3);
        return (GameLevel)((index + 1) + ((long)(int)(index)) << 3) + 32;
    }
    public int get_DefinedLevelCount()
    {
        return 38254;
    }
    private void Start()
    {
        this.Initialize();
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
        var val_1;
        if(this.initialized == true)
        {
                return;
        }
        
        if(this.initializing != false)
        {
                return;
        }
        
        this.initializing = true;
        this.ReadFromKnobs();
        this.LoadLengthsInMemoryFromResources();
        this.LoadDefinedLevelsIntoMemoryFromResources(lang:  "en");
        this.LoadCurrentDictionary();
        this.initialized = true;
        this.initializing = false;
        val_1 = null;
        val_1 = null;
        WordApp.CurrentlyLoadedLevelGenVersion = 2;
        if(this.OnWordLevelGenInit == null)
        {
                return;
        }
        
        this.OnWordLevelGenInit.Invoke();
    }
    public void Unload()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void ReadFromKnobs()
    {
        int val_22;
        System.Collections.IDictionary val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        val_22 = this;
        if(this.knobsLoaded == true)
        {
                return;
        }
        
        this.knobsLoaded = true;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_23 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_24 = null;
        val_24 = null;
        if(getWordGameplayKnobs() != null)
        {
                val_23 = val_2.dataSource;
        }
        
        val_25 = "rwd";
        if((val_1.ContainsKey(key:  "rwd")) != false)
        {
                val_25 = 1152921510214912464;
            object val_4 = val_1.Item["rwd"];
            int val_7 = 0;
            if((val_4.ContainsKey(key:  "e1_lu")) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  val_4.Item["e1_lu"], result: out  val_7);
            val_26 = val_7;
            if((val_26 & 2147483648) != 0)
        {
                val_26 = 9961472;
            val_26 = 152;
        }
        
            this.DictionaryUnlockLevels.set_Item(index:  1, value:  10000000);
        }
        
            if((val_4.ContainsKey(key:  "e2_lu")) != false)
        {
                bool val_12 = System.Int32.TryParse(s:  val_4.Item["e2_lu"], result: out  int val_11 = 10000000);
            val_27 = 10000000;
            if((val_27 & 2147483648) != 0)
        {
                val_27 = 9961472;
            val_27 = 152;
        }
        
            this.DictionaryUnlockLevels.set_Item(index:  2, value:  10000000);
        }
        
            if((val_4.ContainsKey(key:  "e3_lu")) != false)
        {
                bool val_16 = System.Int32.TryParse(s:  val_4.Item["e3_lu"], result: out  int val_15 = 10000000);
            val_28 = 10000000;
            if((val_28 & 2147483648) != 0)
        {
                val_28 = 9961472;
            val_28 = 152;
        }
        
            this.DictionaryUnlockLevels.set_Item(index:  3, value:  10000000);
        }
        
            if((val_4.ContainsKey(key:  "e4_lu")) != false)
        {
                bool val_20 = System.Int32.TryParse(s:  val_4.Item["e4_lu"], result: out  int val_19 = 10000000);
            val_29 = 10000000;
            if((val_29 & 2147483648) != 0)
        {
                val_29 = 9961472;
            val_29 = 152;
        }
        
            this.DictionaryUnlockLevels.set_Item(index:  4, value:  10000000);
        }
        
        }
        
        GameEcon val_21 = App.getGameEcon;
        val_22 = val_21.remLevelWordMax;
        val_30 = null;
        val_30 = null;
        WordLevelGen.LEVEL_GEN_VERSION = val_22;
    }
    public void CallEmptyMethod()
    {
    
    }
    public GameLevel BuildLevelBasedOnWord(string daWord, int maxWordCount = -1, string keepWord)
    {
        string val_23;
        var val_24;
        var val_38;
        var val_39;
        GameLevel val_40;
        System.Collections.Generic.IEnumerable<T> val_41;
        UnityEngine.Object val_42;
        System.Collections.Generic.List<T> val_43;
        var val_44;
        string val_45;
        var val_46;
        val_38 = this;
        if(maxWordCount <= 2)
        {
                val_39 = null;
            val_39 = null;
        }
        
        GameLevel val_1 = null;
        val_40 = val_1;
        val_1 = new GameLevel();
        val_41 = 1152921515418583504;
        val_42 = MonoSingleton<DifficultySettingManager>.Instance;
        if(val_42 == 0)
        {
            goto label_9;
        }
        
        DifficultySettingManager val_4 = MonoSingleton<DifficultySettingManager>.Instance;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_6 = val_4.IsPlayingChallengingLevels;
        if(daWord != null)
        {
            goto label_13;
        }
        
        throw new NullReferenceException();
        label_9:
        if(daWord == null)
        {
                throw new NullReferenceException();
        }
        
        label_13:
        string val_8 = daWord.Chars[0].ToString();
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        .word = val_8;
        if(daWord.m_stringLength >= 2)
        {
                var val_41 = 1;
            do
        {
            .word = val_8 + "|"("|") + daWord.Chars[1].ToString();
            val_41 = val_41 + 1;
        }
        while(val_41 < daWord.m_stringLength);
        
        }
        
        System.Collections.Generic.List<System.String> val_12 = null;
        val_41 = val_12;
        val_12 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.String> val_13 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.String> val_14 = null;
        val_40 = val_14;
        val_14 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_15 = null;
        val_42 = val_15;
        val_15 = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.Add(item:  daWord);
        if(this.RequiredDictionary == null)
        {
                throw new NullReferenceException();
        }
        
        var val_43 = 0;
        label_44:
        if(val_43 >= 1152921509851232320)
        {
            goto label_21;
        }
        
        if(val_43 >= 44467096)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<System.String> val_16 = this.GetAvailableWordsFromList(word:  daWord, listToUse:  "Art", startingLength:  3, endingLength:  daWord.m_stringLength);
        PluginExtension.Shuffle<System.String>(list:  val_16, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        if(App.Player == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.DictionaryUnlockLevels == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_42 = 0;
        if(val_42 == 0)
        {
            goto label_29;
        }
        
        if(this.DictionaryUnlockLevels == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43 >= val_42)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_42 = val_42 + 0;
        if(((0 + 0) + 32) <= 9999999)
        {
            goto label_32;
        }
        
        label_29:
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_13.AddRange(collection:  val_16);
        if(val_42 != null)
        {
            goto label_34;
        }
        
        throw new NullReferenceException();
        label_32:
        val_12.AddRange(collection:  val_16);
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.Clear();
        val_14.AddRange(collection:  val_16);
        if(this.RequiredDictionary == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43 >= 1152921515450536464)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if(((System.Collections.Generic.List<T>.__il2cppRuntimeField_name + (daWord.m_stringLength) << 3) + 32.Contains(item:  daWord)) != false)
        {
                val_14.Add(item:  daWord);
        }
        
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        label_34:
        val_15.Add(item:  val_16);
        val_43 = val_43 + 1;
        if(this.RequiredDictionary != null)
        {
            goto label_44;
        }
        
        throw new NullReferenceException();
        label_21:
        if(1152921515860184720 <= WordLevelGen.LEVEL_GEN_VERSION)
        {
            goto label_94;
        }
        
        System.Collections.Generic.List<System.String> val_19 = new System.Collections.Generic.List<System.String>(collection:  val_12);
        val_12.Clear();
        val_12.Add(item:  daWord);
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        bool val_20 = val_19.Remove(item:  daWord);
        if(keepWord != 0)
        {
                val_12.Add(item:  keepWord);
            bool val_21 = val_19.Remove(item:  keepWord);
        }
        
        PluginExtension.Shuffle<System.String>(list:  val_19, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        List.Enumerator<T> val_22 = val_19.GetEnumerator();
        val_38 = 1152921513250978752;
        label_53:
        if(val_24.MoveNext() == false)
        {
            goto label_48;
        }
        
        if((val_43 + val_23) <= WordLevelGen.LEVEL_GEN_VERSION)
        {
            goto label_49;
        }
        
        if(val_23 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_23 >= WordLevelGen.LEVEL_GEN_VERSION) || ((val_23 + 16) <= 3))
        {
            goto label_52;
        }
        
        label_49:
        val_12.Add(item:  val_23);
        label_57:
        val_43 = val_43 - 1;
        goto label_53;
        label_52:
        val_43 = val_13;
        if(val_43 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_13.Add(item:  val_23);
        if((val_14.Contains(item:  val_23)) == false)
        {
            goto label_57;
        }
        
        bool val_28 = val_14.Remove(item:  val_23);
        goto label_57;
        label_48:
        val_24.Dispose();
        label_94:
        mem[1152921518024223456] = 1152921513251019952;
        if((public System.Void List.Enumerator<System.String>::Dispose()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_44 = val_41;
        val_45 = public System.Void System.Collections.Generic.Dictionary<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase>::Add(SRDebugger.Internal.OptionDefinition key, SRDebugger.UI.Controls.OptionsControlBase value);
        mem[1152921518024223416] = val_45;
        if(1152921513251019952 >= 2)
        {
                val_38 = "|";
            do
        {
            if(1 >= 1152921513251019952)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            string val_29 = val_45 + "|"("|") + "Monday";
            val_45 = val_29;
            var val_31 = 5 + 1;
            mem[1152921518024223416] = val_29;
        }
        while((5 - 3) < val_40);
        
        }
        
        mem[1152921518024223424] = "";
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(mem[1152921518024252040] >= 1)
        {
                val_45 = mem[mem[1152921518024252032] + 32];
            val_45 = mem[1152921518024252032] + 32;
            mem[1152921518024223424] = val_45;
            if(mem[1152921518024252040] >= 2)
        {
                val_38 = "|";
            do
        {
            if(1 >= mem[1152921518024252040])
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            string val_32 = val_45 + "|"("|") + mem[1152921518024252032] + 40(mem[1152921518024252032] + 40);
            val_45 = val_32;
            var val_34 = 5 + 1;
            mem[1152921518024223424] = val_32;
        }
        while((5 - 3) < mem[1152921518024252040]);
        
        }
        
        }
        
        val_1.levelName = daWord;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_35.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_44 = 0;
        mem[1152921518024223448] = val_35.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        mem[1152921518024223372] = val_44;
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        if(0 >= 1)
        {
                int val_37 = UnityEngine.Random.Range(min:  0, max:  0);
            val_46 = val_37;
            if(0 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_44 = val_40 + 16;
        }
        else
        {
                int val_38 = UnityEngine.Random.Range(min:  0, max:  0);
            val_46 = val_38;
            if(0 <= val_38)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        }
        
        val_44 = val_44 + (val_46 << 3);
        mem[1152921518024223568] = (0 + (val_38) << 3) + 32;
        CompanyDevices val_39 = CompanyDevices.Instance;
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_39.CompanyDevice() == false)
        {
                return val_40;
        }
        
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem[1152921518024223528] = CompanyDevices.__il2cppRuntimeField_cctor_finished + 32;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem[1152921518024223536] = CompanyDevices.__il2cppRuntimeField_cctor_finished + 32 + 40;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem[1152921518024223544] = CompanyDevices.__il2cppRuntimeField_cctor_finished + 32 + 40 + 48;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem[1152921518024223552] = CompanyDevices.__il2cppRuntimeField_cctor_finished + 32 + 40 + 48 + 56;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem[1152921518024223560] = CompanyDevices.__il2cppRuntimeField_cctor_finished + 32 + 40 + 48 + 56 + 64;
        return val_40;
    }
    public System.Collections.Generic.List<string> GetAvailableWordsFromList(string word, System.Collections.Generic.List<System.Collections.Generic.List<string>> listToUse, int startingLength, int endingLength)
    {
        string val_3;
        var val_4;
        System.Collections.Generic.List<System.String> val_1 = null;
        var val_10 = 1152921509851217984;
        val_1 = new System.Collections.Generic.List<System.String>();
        if(startingLength > endingLength)
        {
                return val_1;
        }
        
        var val_13 = (long)startingLength;
        var val_11 = 0;
        label_15:
        if(val_13 >= val_10)
        {
                return val_1;
        }
        
        if(val_10 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10 = val_10 + (((long)(int)(startingLength)) << 3);
        if(((1152921509851217984 + ((long)(int)(startingLength)) << 3) + 32) == 0)
        {
            goto label_14;
        }
        
        if(val_10 <= val_13)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = val_10 + (((long)(int)(startingLength)) << 3);
        }
        
        List.Enumerator<T> val_2 = ((1152921509851217984 + ((long)(int)(startingLength)) << 3) + ((long)(int)(startingLength)) << 3) + 32.GetEnumerator();
        label_13:
        if(val_4.MoveNext() == false)
        {
            goto label_8;
        }
        
        bool val_6 = System.String.op_Inequality(a:  word, b:  val_3);
        if((val_6 == false) || ((val_6.CanSpell(letters:  word, word:  val_3)) == false))
        {
            goto label_13;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.Contains(item:  val_3)) == true)
        {
            goto label_13;
        }
        
        val_1.Add(item:  val_3);
        goto label_13;
        label_8:
        val_11 = val_11 + 1;
        val_4.Dispose();
        if(val_11 != 1)
        {
                var val_12 = 0;
            val_12 = val_12 ^ (val_11 >> 31);
            val_11 = val_11 + val_12;
        }
        
        label_14:
        val_13 = val_13 + 1;
        if((val_13 + 1) <= endingLength)
        {
            goto label_15;
        }
        
        return val_1;
    }
    private bool CanSpell(string letters, string word)
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
    public GameLevel BuildChallengingLevelForNormalProgression(int levelWordLength = 0)
    {
        if(levelWordLength > 2)
        {
                return this.BuildDynamicLevel(wordLength:  UnityEngine.Random.Range(min:  4, max:  7), wordCount:  3, maxWordCount:  0, dailyChallenge:  false);
        }
        
        return this.BuildDynamicLevel(wordLength:  UnityEngine.Random.Range(min:  4, max:  7), wordCount:  3, maxWordCount:  0, dailyChallenge:  false);
    }
    public GameLevel GetDynamicDailyChallengeLevel(int wordLength, int wordCount = 3, int maxWordCount = -1)
    {
        return this.BuildDynamicLevel(wordLength:  wordLength, wordCount:  wordCount, maxWordCount:  maxWordCount, dailyChallenge:  true);
    }
    public GameLevel BuildDynamicLevel(int wordLength, int wordCount = 3, int maxWordCount = -1, bool dailyChallenge = False)
    {
        int val_33;
        var val_34;
        var val_35;
        UnityEngine.Object val_36;
        var val_37;
        var val_38;
        string val_39;
        var val_40;
        System.Collections.Generic.List<System.Int32> val_41;
        string val_42;
        var val_43;
        var val_44;
        var val_45;
        val_33 = wordLength;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_34 = null;
            val_34 = null;
            if((System.String.op_Inequality(a:  WADataParser.QAhackedWord, b:  System.String.alignConst)) != false)
        {
                val_35 = null;
            val_35 = null;
            val_33 = mem[WADataParser.QAhackedWord + 16];
            val_33 = WADataParser.QAhackedWord.m_stringLength;
        }
        
        }
        
        val_36 = 7;
        val_37 = System.Math.Min(val1:  System.Math.Max(val1:  val_33, val2:  3), val2:  7);
        if(dailyChallenge != true)
        {
                val_36 = 0;
            if((MonoSingleton<DifficultySettingManager>.Instance) != val_36)
        {
                val_36 = 0;
            if((MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels) != false)
        {
                if(App.Player > this.DefinedLevelCount)
        {
                val_36 = 7;
            val_37 = RandomSet.singleInRange(lowest:  6, highest:  7);
        }
        
        }
        
        }
        
        }
        
        this.AddNewUnlocks();
        val_38 = 0;
        val_39 = 0;
        label_88:
        if(val_38 == 0)
        {
            goto label_35;
        }
        
        var val_32 = 65536;
        if(65536 >= wordCount)
        {
            goto label_36;
        }
        
        label_35:
        if(65536 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_32 = val_32 + (val_37 << 3);
        val_40 = mem[(65536 + (val_12) << 3) + 32 + 24];
        val_40 = (65536 + (val_12) << 3) + 32 + 24;
        if(val_40 != 0)
        {
            goto label_40;
        }
        
        var val_33 = 0;
        label_56:
        if(val_33 >= this.DictionaryUnlockLevels)
        {
            goto label_48;
        }
        
        Player val_13 = App.Player;
        val_41 = this.DictionaryUnlockLevels;
        if(null <= val_33)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (Player.__il2cppRuntimeField_byval_arg + ((long)(int)(val_12)) << 3) + 32.AddRange(collection:  (((Player.__il2cppRuntimeField_byval_arg + ((long)(int)(val_12)) << 3) + 0) + 32 + 16 + ((long)(int)(val_12)) << 3) + 32);
        val_33 = val_33 + 1;
        if(this.DictionaryUnlockLevels != null)
        {
            goto label_56;
        }
        
        label_48:
        val_40 = mem[(65536 + (val_12) << 3) + 32 + 24];
        val_40 = (65536 + (val_12) << 3) + 32 + 24;
        label_40:
        int val_16 = RandomSet.singleInRange(lowest:  0, highest:  val_40 - 1);
        if(((65536 + (val_12) << 3) + 32 + 24) <= val_16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_34 = (65536 + (val_12) << 3) + 32 + 16;
        val_34 = val_34 + (val_16 << 3);
        val_42 = mem[((65536 + (val_12) << 3) + 32 + 16 + (val_16) << 3) + 32];
        val_42 = ((65536 + (val_12) << 3) + 32 + 16 + (val_16) << 3) + 32;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_43 = null;
            val_43 = null;
            if((System.String.op_Inequality(a:  WADataParser.QAhackedWord, b:  System.String.alignConst)) != false)
        {
                val_44 = null;
            val_44 = null;
            val_42 = WADataParser.QAhackedWord.ToUpper();
        }
        
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        var val_35 = 1152921513293150832;
        if(((WADataParser.__il2cppRuntimeField_static_fields + ((long)(int)(val_12)) << 3) + 32.Contains(item:  val_42)) != false)
        {
                if(val_35 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_35 = val_35 + (((long)(int)(val_12)) << 3);
            bool val_22 = (1152921513293150832 + ((long)(int)(val_12)) << 3) + 32.Remove(item:  val_42);
        }
        
        if(val_38 != 0)
        {
                if(val_23.actualWordCount <= 65536)
        {
            goto label_86;
        }
        
        }
        
        val_45 = 0;
        val_38 = this.BuildLevelBasedOnWord(daWord:  val_42, maxWordCount:  maxWordCount, keepWord:  0);
        goto label_87;
        label_86:
        val_45 = val_39 + 1;
        label_87:
        var val_24 = (val_45 == 50) ? 1 : 0;
        val_24 = val_24 & dailyChallenge;
        bool val_26 = val_24 ^ 1;
        val_26 = ((val_37 > 6) ? 1 : 0) | val_26;
        val_39 = (val_26 == true) ? (val_45) : 0;
        val_45 = val_24 & ((val_37 < 7) ? 1 : 0);
        val_37 = val_37 + val_45;
        if(val_39 <= 49)
        {
            goto label_88;
        }
        
        label_36:
        char[] val_28 = new char[1];
        val_28[0] = 124;
        if(val_29.Length >= 1)
        {
                var val_38 = 0;
            val_41 = (long)val_37;
            do
        {
            val_39 = 0.Split(separator:  val_28)[val_38];
            int val_36 = val_29[0x0][0].m_stringLength;
            if(val_36 == val_37)
        {
                if(val_36 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_36 = val_36 + (((long)(int)((val_12 + ((val_45 == 0x32 ? 1 : 0 & dailyChallenge) & val_37 < 7 ? 1 : 0)))) << 3);
            var val_37 = 1152921513293150832;
            if(((val_29[0x0][0].m_stringLength + ((long)(int)((val_12 + ((val_45 == 0x32 ? 1 : 0 & dailyChallenge) & val_37 < 7 ? 1 : 0)))) << 3) + 32.Contains(item:  val_39)) != false)
        {
                if(val_37 <= val_37)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_37 = val_37 + (((long)(int)((val_12 + ((val_45 == 0x32 ? 1 : 0 & dailyChallenge) & val_37 < 7 ? 1 : 0)))) << 3);
            bool val_31 = (1152921513293150832 + ((long)(int)((val_12 + ((val_45 == 0x32 ? 1 : 0 & dailyChallenge) & val_37 < 7 ? 1 : 0)))) << 3) + 32.Remove(item:  val_39);
        }
        
        }
        
            val_38 = val_38 + 1;
        }
        while(val_38 < val_29.Length);
        
        }
        
        this.SaveCurrentDictionary();
        return (GameLevel)val_38;
    }
    public GameLevel BuildLevelContainingWordOfLength(string word, int desiredLength, int desiredAnswers, int lengthFlexibility = 0)
    {
        string val_4;
        var val_5;
        var val_12;
        int val_13;
        var val_14;
        System.Collections.Generic.List<System.String> val_15;
        System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.String>>> val_16;
        val_13 = desiredLength;
        if((lengthFlexibility & 2147483648) != 0)
        {
            goto label_1;
        }
        
        val_14 = 0;
        val_12 = 0;
        label_28:
        System.Collections.Generic.List<System.String> val_1 = null;
        val_15 = val_1;
        val_1 = new System.Collections.Generic.List<System.String>();
        var val_11 = 0;
        label_14:
        if(val_11 >= this.DictionaryUnlockLevels)
        {
            goto label_13;
        }
        
        val_16 = App.Player;
        if(null <= val_11)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_16 = this.RequiredDictionary;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        this.FindLargerWordContainingWord(smallWord:  word, desiredLevelLength:  val_13, dictIndex:  0, wordsListReturn:  val_1);
        val_11 = val_11 + 1;
        if(this.DictionaryUnlockLevels != null)
        {
            goto label_14;
        }
        
        label_13:
        var val_12 = 0;
        if(this.DictionaryUnlockLevels < 1)
        {
            goto label_25;
        }
        
        List.Enumerator<T> val_3 = val_1.GetEnumerator();
        label_23:
        if(val_5.MoveNext() == false)
        {
            goto label_18;
        }
        
        val_15 = this.BuildLevelBasedOnWord(daWord:  val_4, maxWordCount:  desiredAnswers, keepWord:  word);
        if(val_14 != 0)
        {
                if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            var val_8 = (val_7.actualWordCount > 65536) ? (val_15) : (val_14);
        }
        else
        {
                if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_7.actualWordCount < desiredAnswers)
        {
            goto label_23;
        }
        
        goto label_24;
        label_18:
        val_15 = val_14;
        label_24:
        val_12 = val_12 + 1;
        mem2[0] = 188;
        val_5.Dispose();
        val_14 = val_15;
        if(val_12 != 1)
        {
                var val_9 = ((533520112 + ((0 + 1)) << 2) == 188) ? 1 : 0;
            val_9 = ((val_12 >= 0) ? 1 : 0) & val_9;
            val_12 = val_12 - val_9;
        }
        
        label_25:
        if(val_14 != 0)
        {
                if(65536 >= desiredAnswers)
        {
                return (GameLevel)val_14;
        }
        
        }
        
        val_12 = val_12 + 1;
        val_13 = val_13 + 1;
        if(val_12 <= lengthFlexibility)
        {
            goto label_28;
        }
        
        return (GameLevel)val_14;
        label_1:
        val_14 = 0;
        return (GameLevel)val_14;
    }
    public void FindLargerWordContainingWord(string smallWord, int desiredLevelLength, int dictIndex, System.Collections.Generic.List<string> wordsListReturn)
    {
        int val_4 = smallWord.m_stringLength;
        if(val_4 >= desiredLevelLength)
        {
                return;
        }
        
        if(val_4 <= dictIndex)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + (dictIndex << 3);
        if(((smallWord.m_stringLength + (dictIndex) << 3) + 32 + 24) <= desiredLevelLength)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = (smallWord.m_stringLength + (dictIndex) << 3) + 32 + 16;
        val_5 = val_5 + (desiredLevelLength << 3);
        List.Enumerator<T> val_1 = ((smallWord.m_stringLength + (dictIndex) << 3) + 32 + 16 + (desiredLevelLength) << 3) + 32.GetEnumerator();
        this = 1152921509851232320;
        label_11:
        bool val_2 = 0.MoveNext();
        if(val_2 == false)
        {
            goto label_8;
        }
        
        if((val_2.CanSpell(letters:  0, word:  smallWord)) == false)
        {
            goto label_11;
        }
        
        if(wordsListReturn == null)
        {
                throw new NullReferenceException();
        }
        
        wordsListReturn.Add(item:  0);
        goto label_11;
        label_8:
        0.Dispose();
    }
    public string get_PathToGameResources()
    {
        return "game/"("game/") + WordApp.GamePathName + "/"("/");
    }
    private string GetPlayerBucket()
    {
        Player val_1 = App.Player;
        return (string)val_1.playerBucket;
    }
    private void LoadLengthsInMemoryFromResources()
    {
        var val_15;
        var val_16;
        var val_20;
        var val_21;
        System.Collections.Generic.List<T> val_22;
        var val_23;
        System.Collections.Generic.List<System.String> val_24;
        var val_25;
        val_20 = 1152921504884269056;
        val_21 = null;
        val_21 = null;
        System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.String>>> val_3 = null;
        val_22 = val_3;
        val_3 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Collections.Generic.List<System.String>>>();
        mem[1152921518025895080] = val_22;
        var val_23 = 0;
        label_50:
        if(0 >= (mem[1152921518025895096] + 24))
        {
                return;
        }
        
        System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_4 = null;
        val_22 = val_4;
        val_4 = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
        val_3.Add(item:  val_4);
        var val_19 = 0;
        do
        {
            if(1 > 2)
        {
                val_23 = 1152921515860184720;
            val_24 = new System.Collections.Generic.List<System.String>();
        }
        else
        {
                val_23 = 1152921515860184720;
            val_24 = 0;
        }
        
            val_4.Add(item:  val_24);
            val_19 = val_19 + 1;
        }
        while(val_19 < 7);
        
        val_20 = mem[1152921518025895096];
        if(0 >= (mem[1152921518025895096] + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_20 = mem[1152921518025895096] + 16;
        val_25 = 0;
        val_20 = val_20 + 0;
        if(val_8.Length < 1)
        {
            goto label_36;
        }
        
        label_35:
        T val_21 = UnityEngine.Resources.LoadAll<UnityEngine.TextAsset>(path:  System.String.Format(format:  "{0}{1}{2}", arg0:  val_4.PathToGameResources, arg1:  System.String.Format(format:  "WordGroups/{0}/", arg0:  GetPlayerBucket()), arg2:  (mem[1152921518025895096] + 16 + 0) + 32))[0];
        object val_12 = MiniJSON.Json.Deserialize(json:  val_21.text);
        List.Enumerator<T> val_14 = GetEnumerator();
        label_33:
        if(val_16.MoveNext() == false)
        {
            goto label_26;
        }
        
        if(val_15 != 0)
        {
                var val_22 = val_15;
            if(val_22 != null)
        {
            goto label_46;
        }
        
        }
        
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_22 <= (System.Int32.Parse(s:  val_21.name)))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_22 = val_22 + (((long)(int)(val_10)) << 3);
        if(((val_15 + ((long)(int)(val_10)) << 3) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        (val_15 + ((long)(int)(val_10)) << 3) + 32.Add(item:  val_15.ToUpper());
        goto label_33;
        label_26:
        val_23 = val_23 + 1;
        val_16.Dispose();
        label_48:
        if(val_23 != 1)
        {
                var val_24 = 0;
            val_24 = val_24 ^ (val_23 >> 31);
            val_23 = val_23 + val_24;
        }
        
        val_20 = 0 + 1;
        if(val_20 < (val_8 + 24))
        {
            goto label_35;
        }
        
        goto label_36;
        label_46:
        if(null != 1)
        {
                throw ???;
        }
        
        val_16.Dispose();
        if(val_15 == 0)
        {
            goto label_48;
        }
        
        throw ???;
        label_36:
        var val_25 = 0;
        val_25 = val_25 + 1;
        if(mem[1152921518025895096] != 0)
        {
            goto label_50;
        }
        
        throw new NullReferenceException();
    }
    private void LoadDefinedLevelsIntoMemoryFromResources(string lang)
    {
        string val_12;
        var val_13;
        string val_16;
        string val_17;
        this.DefinedLevels = new System.Collections.Generic.List<GameLevel>();
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        this.DefinedWords = val_2;
        string val_3 = val_2.PathToGameResources;
        val_16 = val_3;
        UnityEngine.TextAsset val_7 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  val_16 + "Levels/"("Levels/") + val_3.GetLevelCurveSubPath(lang:  lang, bucket:  "A")(val_3.GetLevelCurveSubPath(lang:  lang, bucket:  "A"))(val_16 + "Levels/"("Levels/") + val_3.GetLevelCurveSubPath(lang:  lang, bucket:  "A")(val_3.GetLevelCurveSubPath(lang:  lang, bucket:  "A"))) + "/Defined_Levels"("/Defined_Levels"));
        if(val_7 == 0)
        {
                return;
        }
        
        List.Enumerator<T> val_11 = MiniJSON.Json.Deserialize(json:  val_7.text).GetEnumerator();
        val_17 = val_12;
        val_16 = 1152921504622235648;
        label_13:
        if(val_13.MoveNext() == false)
        {
            goto label_8;
        }
        
        if(val_17 != 0)
        {
                val_17 = null;
            if(val_17 != val_17)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.DefinedWords == null)
        {
                throw new NullReferenceException();
        }
        
        this.DefinedWords.Add(item:  val_17);
        if(this.DefinedLevels == null)
        {
                throw new NullReferenceException();
        }
        
        this.DefinedLevels.Add(item:  0);
        goto label_13;
        label_8:
        val_13.Dispose();
    }
    private string GetLevelCurveSubPath(string lang, string bucket = "A")
    {
        object val_4;
        if((System.String.op_Inequality(a:  lang, b:  "en")) != false)
        {
                return System.String.Format(format:  "{0}/{1}", arg0:  "android", arg1:  lang);
        }
        
        if((System.String.op_Equality(a:  bucket, b:  "A")) != false)
        {
                val_4 = "";
            return System.String.Format(format:  "{0}/{1}{2}", arg0:  "android", arg1:  lang, arg2:  val_4 = System.String.Format(format:  "_{0}", arg0:  bucket));
        }
        
        return System.String.Format(format:  "{0}/{1}{2}", arg0:  "android", arg1:  lang, arg2:  val_4);
    }
    private void LoadCurrentDictionary()
    {
        string val_9;
        var val_10;
        var val_25;
        var val_26;
        string val_27;
        var val_28;
        var val_29;
        System.Collections.Generic.List<System.Collections.Generic.List<System.String>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<System.String>>();
        this.CurrentRequiredDictionary = val_1;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        label_3:
        val_1.Add(item:  new System.Collections.Generic.List<System.String>());
        val_25 = 0 + 1;
        if(val_25 > 6)
        {
            goto label_2;
        }
        
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        if(this.CurrentRequiredDictionary != null)
        {
            goto label_3;
        }
        
        throw new NullReferenceException();
        label_2:
        val_26 = 1152921504874684416;
        val_27 = "wlg_crd";
        if((CPlayerPrefs.HasKey(key:  "wlg_crd")) == false)
        {
            goto label_6;
        }
        
        if((MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "wlg_crd", defaultValue:  ""))) == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_13;
        label_6:
        val_27 = 0;
        val_28 = 0;
        goto label_79;
        label_13:
        List.Enumerator<T> val_8 = GetEnumerator();
        val_25 = 1152921509851232320;
        var val_27 = 0;
        var val_26 = 0;
        label_27:
        if(val_10.MoveNext() == false)
        {
            goto label_15;
        }
        
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_12 = val_9.GetEnumerator();
        string val_25 = val_9;
        label_24:
        if(val_10.MoveNext() == false)
        {
            goto label_19;
        }
        
        if(this.CurrentRequiredDictionary == null)
        {
                throw new NullReferenceException();
        }
        
        val_27 = val_25;
        if(val_25 <= val_27)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_27 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_25 = val_25 + 0;
        if(((val_9 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        (val_9 + 0) + 32.Add(item:  val_27);
        goto label_24;
        label_19:
        val_26 = val_26 + 1;
        val_27 = 0;
        mem2[0] = 170;
        val_10.Dispose();
        if(val_27 != 0)
        {
                throw val_27;
        }
        
        if(val_26 != 1)
        {
                var val_14 = ((1152921518026468992 + ((0 + 1)) << 2) == 170) ? 1 : 0;
            val_14 = ((val_26 >= 0) ? 1 : 0) & val_14;
            val_26 = val_26 - val_14;
        }
        
        val_27 = val_27 + 1;
        goto label_27;
        label_15:
        val_28 = val_26 + 1;
        val_27 = 0;
        mem2[0] = 199;
        val_26 = 1152921504874684416;
        val_10.Dispose();
        if(val_27 != 0)
        {
                throw val_27;
        }
        
        if(val_28 != 1)
        {
                val_27 = 0;
            var val_16 = ((1152921518026468992 + ((0 + 1)) << 2) == 199) ? 1 : 0;
            val_16 = ((val_28 >= 0) ? 1 : 0) & val_16;
            val_28 = val_28 - val_16;
        }
        else
        {
                val_27 = 0;
        }
        
        label_79:
        val_29 = "wlg_ula";
        if((CPlayerPrefs.HasKey(key:  "wlg_ula")) == false)
        {
                return;
        }
        
        if(this.UnlocksAdded == null)
        {
                throw new NullReferenceException();
        }
        
        this.UnlocksAdded.Clear();
        object val_20 = MiniJSON.Json.Deserialize(json:  CPlayerPrefs.GetString(key:  "wlg_ula", defaultValue:  ""));
        List.Enumerator<T> val_22 = GetEnumerator();
        val_29 = 1152921510211410768;
        val_25 = 1152921510479955696;
        label_56:
        if(val_10.MoveNext() == false)
        {
            goto label_52;
        }
        
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(this.UnlocksAdded == null)
        {
                throw new NullReferenceException();
        }
        
        this.UnlocksAdded.Add(item:  val_9);
        goto label_56;
        label_52:
        var val_24 = val_28 + 1;
        mem2[0] = 316;
        val_10.Dispose();
        if(val_27 != 0)
        {
                throw val_27;
        }
        
        return;
        label_83:
        if(0 != 1)
        {
            goto label_85;
        }
        
        if((null & 1) != 0)
        {
                return;
        }
        
        mem[8] = "wlg_crd";
        goto label_83;
        label_85:
    }
    private void SaveCurrentDictionary()
    {
        CPlayerPrefs.SetString(key:  "wlg_crd", val:  MiniJSON.Json.Serialize(obj:  this.CurrentRequiredDictionary));
        CPlayerPrefs.SetString(key:  "wlg_ula", val:  MiniJSON.Json.Serialize(obj:  this.UnlocksAdded));
    }
    private void AddNewUnlocks()
    {
        System.Collections.Generic.List<System.Int32> val_3;
        var val_4;
        var val_6 = 0;
        do
        {
            if(val_6 >= this.DictionaryUnlockLevels)
        {
                return;
        }
        
            val_3 = this.DictionaryUnlockLevels;
            val_4 = App.Player;
            if(null <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if((this.UnlocksAdded.Contains(item:  0)) != true)
        {
                var val_5 = 7;
            do
        {
            var val_3 = val_5 - 4;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_4 = mem[Player.__il2cppRuntimeField_byval_arg + 56];
            val_4 = Player.__il2cppRuntimeField_byval_arg + 56;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = mem[(Player.__il2cppRuntimeField_byval_arg + 0) + 32];
            val_3 = (Player.__il2cppRuntimeField_byval_arg + 0) + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_4.AddRange(collection:  (Player.__il2cppRuntimeField_byval_arg + 0) + 32 + 16 + 56);
            val_5 = val_5 + 1;
        }
        while((val_5 - 5) < 7);
        
            this.UnlocksAdded.Add(item:  0);
        }
        
            val_6 = val_6 + 1;
        }
        while(this.DictionaryUnlockLevels != null);
        
        throw new NullReferenceException();
    }
    public int GetAllPossibleWordsCount()
    {
        var val_2;
        var val_3;
        WordLevelGen val_8;
        int val_9;
        val_8 = this;
        val_9 = this.allPossibleWords;
        if(val_9 > 0)
        {
                return val_9;
        }
        
        List.Enumerator<T> val_1 = this.RequiredDictionary.GetEnumerator();
        val_9 = 0;
        label_11:
        if(val_3.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_2.GetEnumerator();
        goto label_6;
        label_7:
        if(val_2 != 0)
        {
                val_9 = (val_2 + 24) + val_9;
        }
        
        label_6:
        if(val_3.MoveNext() == true)
        {
            goto label_7;
        }
        
        var val_7 = 0 + 1;
        val_8 = 0;
        mem2[0] = 92;
        val_3.Dispose();
        if(val_8 != 0)
        {
                throw val_8;
        }
        
        if((val_7 == 1) || ((1152921518026958608 + ((0 + 1)) << 2) != 92))
        {
            goto label_11;
        }
        
        var val_10 = 0;
        val_10 = val_10 ^ (val_7 >> 31);
        var val_8 = val_7 + val_10;
        goto label_11;
        label_3:
        var val_9 = 0 + 1;
        mem2[0] = 117;
        val_3.Dispose();
        this.allPossibleWords = val_9;
        return val_9;
    }
    public int GetPossibleWordsCount(int numLetters)
    {
        var val_3;
        var val_4;
        List.Enumerator<T> val_1 = this.RequiredDictionary.GetEnumerator();
        val_3 = 0;
        goto label_5;
        label_8:
        if(0 != 0)
        {
                if(9733424 <= numLetters)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_3 = 11993091;
            val_3 = val_3 + (((long)(int)(numLetters)) << 3);
            val_4 = mem[(11993091 + ((long)(int)(numLetters)) << 3) + 32];
            val_4 = (11993091 + ((long)(int)(numLetters)) << 3) + 32;
            if(val_4 != 0)
        {
                if(9733424 <= numLetters)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_4 = 11993091;
            val_4 = val_4 + (((long)(int)(numLetters)) << 3);
            val_4 = mem[(11993091 + ((long)(int)(numLetters)) << 3) + 32];
            val_4 = (11993091 + ((long)(int)(numLetters)) << 3) + 32;
            if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        }
        
            val_3 = ((11993091 + ((long)(int)(numLetters)) << 3) + 32 + 24) + val_3;
        }
        
        }
        
        label_5:
        if(0.MoveNext() == true)
        {
            goto label_8;
        }
        
        0.Dispose();
        return (int)val_3;
    }
    public System.Collections.Generic.List<bool> GetAllowedLetters(int level, int lettersSize, System.Collections.Generic.List<string> lettersArray, System.Collections.Generic.List<int> indexes)
    {
        int val_21 = lettersSize;
        System.Collections.Generic.List<System.Boolean> val_1 = new System.Collections.Generic.List<System.Boolean>();
        val_1.Add(item:  false);
        val_1.Add(item:  false);
        val_1.Add(item:  false);
        if(((MonoSingleton<WordGameEventsController>.Instance.ActivelyPlayingEventGameMode()) != true) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true))
        {
                if(WGFTUXManager.CanShow != false)
        {
                System.Collections.Generic.List<System.String> val_8 = WordRegion.instance.GetCompletedWords();
        }
        
        }
        
        System.Collections.Generic.List<System.Boolean> val_9 = new System.Collections.Generic.List<System.Boolean>();
        if(val_21 < 1)
        {
                return val_9;
        }
        
        do
        {
            val_9.Add(item:  true);
            val_21 = val_21 - 1;
        }
        while(val_21 != 1);
        
        return val_9;
        label_37:
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
            goto label_32;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_22 = -9223372036799429520;
        if(val_22 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_22 = val_22 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "N")) == false)
        {
            goto label_36;
        }
        
        label_32:
        val_1.set_Item(index:  0, value:  true);
        label_36:
         =  + 1;
        if( < val_22)
        {
            goto label_37;
        }
        
        return val_9;
        label_52:
        if("es" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44270704 <= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223372036799429488].Equals(value:  "O")) == true)
        {
            goto label_47;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_24 = -9223372036799429520;
        if(val_24 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24 = val_24 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "W")) == false)
        {
            goto label_51;
        }
        
        label_47:
        val_1.set_Item(index:  0, value:  true);
        label_51:
         =  + 1;
        if( < val_24)
        {
            goto label_52;
        }
        
        return val_9;
        label_65:
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
            goto label_60;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_26 = -9223372036799429520;
        if(val_26 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_26 = val_26 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "O")) == false)
        {
            goto label_64;
        }
        
        label_60:
        val_1.set_Item(index:  0, value:  true);
        label_64:
         =  + 1;
        if( < val_26)
        {
            goto label_65;
        }
        
        return val_9;
        label_78:
        if("es" <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(44270704 <= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[-9223372036799429488].Equals(value:  "A")) == true)
        {
            goto label_73;
        }
        
        if((-9223372036799429520) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_28 = -9223372036799429520;
        if(val_28 <= (mem[-9223372036799429488]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_28 = val_28 + ((mem[-9223372036799429488]) << 3);
        if(((-9223372036799429520 + (mem[-9223372036799429488]) << 3) + 32.Equals(value:  "C")) == false)
        {
            goto label_77;
        }
        
        label_73:
        val_1.set_Item(index:  0, value:  true);
        label_77:
         =  + 1;
        if( < val_28)
        {
            goto label_78;
        }
        
        return val_9;
    }
    public System.Collections.Generic.List<int> GetIndexesForTutorialLevel(int level, int lettersSize, System.Collections.Generic.List<string> lettersArray)
    {
        var val_14;
        var val_15;
        string val_16;
        string val_17;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  0);
        val_1.Add(item:  1);
        val_1.Add(item:  2);
        GameBehavior val_2 = App.getBehavior;
        if((System.String.op_Equality(a:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "es")) == false)
        {
            goto label_6;
        }
        
        if(level <= 1)
        {
            goto label_7;
        }
        
        if(level != 2)
        {
            goto label_12;
        }
        
        val_14 = 1152921517724626848;
        val_15 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "N"));
        val_16 = "U";
        goto label_10;
        label_6:
        if(level <= 1)
        {
            goto label_11;
        }
        
        if(level != 2)
        {
            goto label_12;
        }
        
        val_14 = 1152921517724626848;
        val_15 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "W"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "O"));
        val_17 = "N";
        goto label_16;
        label_7:
        val_14 = 1152921517724626848;
        val_15 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "O"));
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  "L"));
        val_17 = "S";
        goto label_16;
        label_11:
        val_14 = 1152921517724626848;
        val_15 = 1152921516173237664;
        val_1.set_Item(index:  0, value:  lettersArray.IndexOf(item:  "C"));
        val_16 = "T";
        label_10:
        val_1.set_Item(index:  1, value:  lettersArray.IndexOf(item:  val_16));
        val_17 = "A";
        label_16:
        val_1.set_Item(index:  2, value:  lettersArray.IndexOf(item:  val_17));
        return val_1;
        label_12:
        if(lettersSize < 1)
        {
                return val_1;
        }
        
        var val_14 = 0;
        do
        {
            new System.Collections.Generic.List<System.Int32>().Add(item:  0);
            val_14 = val_14 + 1;
        }
        while(lettersSize != val_14);
        
        return val_1;
    }
    public WordLevelGen()
    {
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_1.Add(item:  0);
        val_1.Add(item:  151);
        val_1.Add(item:  233);
        val_1.Add(item:  113);
        val_1.Add(item:  10000000);
        this.DictionaryUnlockLevels = val_1;
        System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
        val_2.Add(item:  "RWDBase");
        val_2.Add(item:  "RWDExp1");
        val_2.Add(item:  "RWDExp2");
        val_2.Add(item:  "RWDExp3");
        val_2.Add(item:  "RWDExp4");
        this.DictionaryLoadPaths = val_2;
        this.UnlocksAdded = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.List<System.Int32> val_4 = new System.Collections.Generic.List<System.Int32>();
        val_4.Add(item:  8);
        val_4.Add(item:  15);
        this.LevelWordMaximums = val_4;
    }
    private static WordLevelGen()
    {
        WordLevelGen.LEVEL_GEN_VERSION = 18;
        WordLevelGen.chapter_lengths = new int[6] {4, 4, 4, 8, 12, 16};
    }

}

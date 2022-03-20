using UnityEngine;
public static class Prefs
{
    // Properties
    public static int currentWorld { get; }
    public static int currentChapter { get; }
    public static int currentLevel { get; }
    public static int extraProgress { get; set; }
    public static int extraTarget { get; set; }
    public static int totalExtraAdded { get; set; }
    public static bool HasUsedHintPicker { get; set; }
    public static bool HasUsedHintMega { get; set; }
    public static bool HasUsedHintCheck { get; set; }
    public static GameMode currentGameMode { get; set; }
    public static int freePlayLevel { get; set; }
    
    // Methods
    public static int get_currentWorld()
    {
        return 0;
    }
    public static int get_currentChapter()
    {
        return WADChapterManager.GetCurrentChapter();
    }
    public static int get_currentLevel()
    {
        return WADChapterManager.GetCurrentLevelWithinChapter(level:  0);
    }
    public static bool IsCurrentLevel()
    {
        bool val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge;
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    public static void SetExtraWords(int world, int subWorld, int level, string[] extraWords)
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[6];
        val_1[0] = "extra_words_";
        val_4 = val_1.Length;
        val_1[1] = world;
        val_4 = val_1.Length;
        val_1[2] = "_";
        val_5 = val_1.Length;
        val_1[3] = subWorld;
        val_5 = val_1.Length;
        val_1[4] = "_";
        val_1[5] = level;
        bool val_3 = CryptoPlayerPrefsX.SetStringArray(key:  +val_1, stringArray:  extraWords);
    }
    public static string[] GetExtraWords(int world, int subWorld, int level)
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[6];
        val_1[0] = "extra_words_";
        val_4 = val_1.Length;
        val_1[1] = world;
        val_4 = val_1.Length;
        val_1[2] = "_";
        val_5 = val_1.Length;
        val_1[3] = subWorld;
        val_5 = val_1.Length;
        val_1[4] = "_";
        val_1[5] = level;
        return (System.String[])CryptoPlayerPrefsX.GetStringArray(key:  +val_1);
    }
    public static void SetExtraWordsEvents(string gameType, string[] extraWords)
    {
        bool val_2 = CryptoPlayerPrefsX.SetStringArray(key:  "extra_words_" + gameType, stringArray:  extraWords);
    }
    public static string[] GetExtraWordsEvents(string gameType)
    {
        return CryptoPlayerPrefsX.GetStringArray(key:  "extra_words_" + gameType);
    }
    public static int get_extraProgress()
    {
        return CPlayerPrefs.GetInt(key:  "extra_progress", defaultValue:  0);
    }
    public static void set_extraProgress(int value)
    {
        CPlayerPrefs.SetInt(key:  "extra_progress", val:  value);
    }
    public static int get_extraTarget()
    {
        return CPlayerPrefs.GetInt(key:  "extra_target", defaultValue:  0);
    }
    public static void set_extraTarget(int value)
    {
        CPlayerPrefs.SetInt(key:  "extra_target", val:  value);
    }
    public static int get_totalExtraAdded()
    {
        return CPlayerPrefs.GetInt(key:  "total_extra_added", defaultValue:  0);
    }
    public static void set_totalExtraAdded(int value)
    {
        CPlayerPrefs.SetInt(key:  "total_extra_added", val:  value);
    }
    public static void AddToNumHint(int world, int subWorld, int level)
    {
        int val_9;
        int val_10;
        if((MonoSingletonSelfGenerating<WGChallengeController>.Instance) != 0)
        {
                HintFeatureManager val_4 = MonoSingleton<HintFeatureManager>.Instance;
            if(val_4.freeHintOnLastCheck != true)
        {
                MonoSingletonSelfGenerating<WGChallengeController>.Instance.OnAnyHintUsed();
        }
        
        }
        
        object[] val_6 = new object[6];
        val_6[0] = "numhint_used_";
        val_9 = val_6.Length;
        val_6[1] = world;
        val_9 = val_6.Length;
        val_6[2] = "_";
        val_10 = val_6.Length;
        val_6[3] = subWorld;
        val_10 = val_6.Length;
        val_6[4] = "_";
        val_6[5] = level;
        UnityEngine.PlayerPrefs.SetInt(key:  +val_6, value:  (Prefs.GetNumHint(world:  world, subWorld:  subWorld, level:  level)) + 1);
    }
    public static int GetNumHint(int world, int subWorld, int level)
    {
        int val_4;
        int val_5;
        object[] val_1 = new object[6];
        val_1[0] = "numhint_used_";
        val_4 = val_1.Length;
        val_1[1] = world;
        val_4 = val_1.Length;
        val_1[2] = "_";
        val_5 = val_1.Length;
        val_1[3] = subWorld;
        val_5 = val_1.Length;
        val_1[4] = "_";
        val_1[5] = level;
        return (int)UnityEngine.PlayerPrefs.GetInt(key:  +val_1);
    }
    public static void UsedHint(bool free = False)
    {
        if(free != false)
        {
                Player val_1 = App.Player;
            int val_3 = val_1.properties.LifetimeFreeHints;
            val_3 = val_3 + 1;
            val_1.properties.LifetimeFreeHints = val_3;
            return;
        }
        
        Player val_2 = App.Player;
        int val_4 = val_2.properties.LifetimeHints;
        val_4 = val_4 + 1;
        val_2.properties.LifetimeHints = val_4;
    }
    public static bool HasUsedHint()
    {
        var val_4;
        Player val_1 = App.Player;
        if(val_1.properties.LifetimeHints > 0)
        {
                val_4 = 1;
            return (bool)(val_2.properties.LifetimeFreeHints > 0) ? 1 : 0;
        }
        
        Player val_2 = App.Player;
        return (bool)(val_2.properties.LifetimeFreeHints > 0) ? 1 : 0;
    }
    public static bool get_HasUsedHintPicker()
    {
        Player val_1 = App.Player;
        return (bool)(val_1.properties.LifetimeHintPickers > 0) ? 1 : 0;
    }
    public static void set_HasUsedHintPicker(bool value)
    {
        int val_3;
        Player val_1 = App.Player;
        if(value == false)
        {
            goto label_4;
        }
        
        Player val_2 = App.Player;
        val_3 = val_2.properties.LifetimeHintPickers + 1;
        if(val_1.properties != null)
        {
            goto label_9;
        }
        
        label_4:
        val_3 = 0;
        label_9:
        val_1.properties.LifetimeHintPickers = val_3;
    }
    public static bool get_HasUsedHintMega()
    {
        Player val_1 = App.Player;
        return (bool)(val_1.properties.LifetimeMegaHints > 0) ? 1 : 0;
    }
    public static void set_HasUsedHintMega(bool value)
    {
        int val_3;
        Player val_1 = App.Player;
        if(value == false)
        {
            goto label_4;
        }
        
        Player val_2 = App.Player;
        val_3 = val_2.properties.LifetimeMegaHints + 1;
        if(val_1.properties != null)
        {
            goto label_9;
        }
        
        label_4:
        val_3 = 0;
        label_9:
        val_1.properties.LifetimeMegaHints = val_3;
    }
    public static bool get_HasUsedHintCheck()
    {
        Player val_1 = App.Player;
        return (bool)(val_1.properties.LifetimeCheckHints > 0) ? 1 : 0;
    }
    public static void set_HasUsedHintCheck(bool value)
    {
        int val_3;
        Player val_1 = App.Player;
        if(value == false)
        {
            goto label_4;
        }
        
        Player val_2 = App.Player;
        val_3 = val_2.properties.LifetimeCheckHints + 1;
        if(val_1.properties != null)
        {
            goto label_9;
        }
        
        label_4:
        val_3 = 0;
        label_9:
        val_1.properties.LifetimeCheckHints = val_3;
    }
    public static GameMode get_currentGameMode()
    {
        return CPlayerPrefs.GetInt(key:  "current_game_mode", defaultValue:  0);
    }
    public static void set_currentGameMode(GameMode value)
    {
        CPlayerPrefs.SetInt(key:  "current_game_mode", val:  value);
    }
    public static int get_freePlayLevel()
    {
        return CPlayerPrefs.GetInt(key:  "free_play_level", defaultValue:  0);
    }
    public static void set_freePlayLevel(int value)
    {
        CPlayerPrefs.SetInt(key:  "free_play_level", val:  value);
    }

}

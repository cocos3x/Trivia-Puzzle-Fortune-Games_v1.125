using UnityEngine;
public class PlayingLevel
{
    // Fields
    private static System.Collections.Generic.Dictionary<GameplayMode, object> gameLevels;
    private static bool initialized;
    
    // Properties
    private static string PP_Data { get; }
    public static GameplayMode CurrentGameplayMode { get; }
    
    // Methods
    private static string get_PP_Data()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(GameplayBehavior).__il2cppRuntimeField_330;
    }
    public static GameplayMode get_CurrentGameplayMode()
    {
        UnityEngine.Object val_6;
        var val_7;
        if(CategoryPacksManager.IsPlaying != false)
        {
                val_7 = 4;
            return (GameplayMode)val_7;
        }
        
        val_6 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_6 != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_7 = 2;
            return (GameplayMode)val_7;
        }
        
        }
        
        val_7 = 1;
        return (GameplayMode)val_7;
    }
    public static void CompleteLevel(GameplayMode mode, System.Collections.Generic.Dictionary<string, object> parameters)
    {
        if((PlayingLevel.GetLevel(currentMode:  mode, parameters:  parameters)) != null)
        {
                val_1.completed = true;
        }
        
        PlayingLevel.Save();
    }
    public static GameLevel GetCurrentDailyChallengeLevel()
    {
        return PlayingLevel.GetLevel(currentMode:  2, parameters:  0);
    }
    public static GameLevel GetMissedDailyChallengeLevel()
    {
        return PlayingLevel.GetLevel(currentMode:  3, parameters:  0);
    }
    public static GameLevel GetCategoryLevel(int categoryPackId = -1)
    {
        var val_31;
        var val_32;
        string val_33;
        var val_34;
        var val_35;
        BuildLevelBasedOnWordParams val_36;
        GameLevel val_37;
        int val_38;
        var val_40;
        string val_41;
        var val_42;
        var val_43;
        bool val_44;
        var val_45;
        if((categoryPackId & 2147483648) != 0)
        {
                CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
        }
        
        val_31 = 1152921504685600768;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_32 = 1152921510196879024;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_33 = "catid";
        val_34 = 1152921515419383392;
        val_2.Add(key:  "catid", value:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId.ToString());
        val_35 = 1152921504975749120;
        val_36 = 1152921504893161472;
        val_37 = PlayingLevel.GetLevel(currentMode:  4, parameters:  val_2);
        val_38 = MonoSingleton<CategoryPacksManager>.Instance.GetPackProgress(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId);
        if(val_37 != null)
        {
                if(val_4.playerLevel == val_38)
        {
                return val_37;
        }
        
        }
        
        string val_8 = MonoSingleton<CategoryPacksManager>.Instance.GetWordFromPack(packId:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId);
        GameBehavior val_9 = App.getBehavior;
        if(((val_9.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_36 = MonoSingletonSelfGenerating<WordLevelGen>.Instance;
            GameEcon val_11 = App.getGameEcon;
            GameLevel val_12 = val_36.BuildLevelBasedOnWord(daWord:  val_8, maxWordCount:  val_11.categoryMaxRequiredWords, keepWord:  0);
        }
        else
        {
                if(((MonoSingleton<DifficultySettingManager>.Instance) != 0) && ((MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels) != false))
        {
                val_40 = val_34;
            val_41 = val_33;
            val_42 = val_32;
            val_43 = val_31;
            val_44 = 1;
        }
        else
        {
                val_40 = val_34;
            val_41 = val_33;
            val_42 = val_32;
            val_43 = val_31;
            val_44 = MonoSingletonSelfGenerating<WADataParser>.Instance.IsWordUncommon(wordToCheck:  val_8);
        }
        
            BuildLevelBasedOnWordParams val_19 = null;
            val_36 = val_19;
            val_19 = new BuildLevelBasedOnWordParams();
            .levelWord = val_8;
            mem[1152921517568137364] = 1;
            GameEcon val_20 = App.getGameEcon;
            .includeUncommonAsRequiredWords = val_44;
            mem[1152921517568137366] = 0;
            mem[1152921517568137344] = val_20.categoryMaxRequiredWords;
            val_31 = val_43;
            val_32 = val_42;
            if((MonoSingleton<DifficultySettingManager>.Instance) != 0)
        {
                val_33 = val_41;
            val_45 = MonoSingleton<DifficultySettingManager>.Instance.IsPlayingChallengingLevels;
        }
        else
        {
                val_45 = 0;
            val_33 = val_41;
        }
        
            mem[1152921517568137365] = val_45;
            val_34 = val_40;
            val_35 = 1152921504975749120;
        }
        
        val_37 = MonoSingletonSelfGenerating<WADataParser>.Instance.BuildLevelBasedOnWord(param:  val_19);
        val_26.playerLevel = val_38;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_27 = null;
        val_38 = val_27;
        val_27 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_27.Add(key:  val_33, value:  val_1.<CurrentCategoryPackInfo>k__BackingField.packId.ToString());
        PlayingLevel.SetLevel(currentMode:  4, level:  val_37, parameters:  val_27, skipSaving:  false);
        return val_37;
    }
    public static GameLevel GetLevelForPlayerLevel(int levelIndex = -1, bool checkLevelSkip = False)
    {
        var val_11;
        string val_12;
        val_11 = null;
        val_11 = null;
        if(PlayingLevel.initialized != true)
        {
                PlayingLevel.Initialize();
            val_11 = null;
        }
        
        val_11 = null;
        if((PlayingLevel.gameLevels.ContainsKey(key:  1)) != false)
        {
                val_12 = 1152921504884269056;
            if((App.Player == val_2.playerLevel) && (val_2.completed != true))
        {
                val_12 = val_2.language;
            GameBehavior val_4 = App.getBehavior;
            if((System.String.op_Equality(a:  val_12, b:  val_4.<metaGameBehavior>k__BackingField.GetCurrentLanguage())) != false)
        {
                return (GameLevel)PlayingLevel.GetLevel(currentMode:  1, parameters:  0);
        }
        
        }
        
        }
        
        val_9.playerLevel = App.Player;
        PlayingLevel.SetLevel(currentMode:  1, level:  MonoSingletonSelfGenerating<WADChapterManager>.Instance.GetGameLevelForPlayerLevelFromChapter(playerLevel:  0, checkLevelSkip:  checkLevelSkip), parameters:  0, skipSaving:  false);
        return PlayingLevel.GetLevel(currentMode:  1, parameters:  0);
    }
    public static GameLevel GetLevel(GameplayMode currentMode, System.Collections.Generic.Dictionary<string, object> parameters)
    {
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        var val_15;
        val_11 = 1152921504975749120;
        val_12 = null;
        val_12 = null;
        if(PlayingLevel.initialized != true)
        {
                PlayingLevel.Initialize();
            val_12 = null;
        }
        
        val_12 = null;
        if((PlayingLevel.gameLevels.ContainsKey(key:  currentMode)) == false)
        {
            goto label_21;
        }
        
        if(currentMode != 4)
        {
            goto label_10;
        }
        
        if((parameters == null) || ((parameters.ContainsKey(key:  "catid")) == false))
        {
            goto label_21;
        }
        
        val_13 = null;
        val_13 = null;
        object val_3 = PlayingLevel.gameLevels.Item[4];
        if(val_3 == null)
        {
                return (GameLevel)val_14;
        }
        
        val_14 = 0;
        var val_4 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Collections.Generic.Dictionary<TKey, TValue>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_3) : 0;
        val_11 = 1152921510214912464;
        if((val_4.ContainsKey(key:  parameters.Item["catid"])) == false)
        {
            goto label_21;
        }
        
        GameLevel val_8 = val_4.Item[parameters.Item["catid"]];
        return (GameLevel)val_14;
        label_10:
        val_15 = null;
        val_15 = null;
        if(PlayingLevel.gameLevels.Item[currentMode] == null)
        {
                return (GameLevel)val_14;
        }
        
        label_21:
        val_14 = 0;
        return (GameLevel)val_14;
    }
    public static void SetLevel(GameplayMode currentMode, GameLevel level, System.Collections.Generic.Dictionary<string, object> parameters, bool skipSaving = False)
    {
        object val_7;
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        System.Collections.Generic.Dictionary<T, U> val_12;
        var val_13;
        val_8 = null;
        val_8 = null;
        if(PlayingLevel.initialized != true)
        {
                PlayingLevel.Initialize();
        }
        
        if(currentMode != 4)
        {
            goto label_6;
        }
        
        if((parameters == null) || ((parameters.ContainsKey(key:  "catid")) == false))
        {
            goto label_8;
        }
        
        val_9 = null;
        val_9 = null;
        if((PlayingLevel.gameLevels.ContainsKey(key:  4)) != true)
        {
                val_10 = null;
            val_10 = null;
            System.Collections.Generic.Dictionary<System.String, GameLevel> val_3 = null;
            val_7 = val_3;
            val_3 = new System.Collections.Generic.Dictionary<System.String, GameLevel>();
            EnumerableExtentions.SetOrAdd<GameplayMode, System.Object>(dic:  PlayingLevel.gameLevels, key:  4, newValue:  val_3);
        }
        
        val_11 = null;
        val_11 = null;
        object val_4 = PlayingLevel.gameLevels.Item[4];
        if(val_4 != null)
        {
                val_12 = val_4;
        }
        
        System.Collections.Generic.Dictionary<System.String, GameLevel> val_5 = null;
        val_12 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, GameLevel>();
        EnumerableExtentions.SetOrAdd<System.String, GameLevel>(dic:  val_5, key:  parameters.Item["catid"], newValue:  level);
        if(skipSaving == true)
        {
                return;
        }
        
        goto label_26;
        label_6:
        val_13 = null;
        val_13 = null;
        EnumerableExtentions.SetOrAdd<GameplayMode, System.Object>(dic:  PlayingLevel.gameLevels, key:  currentMode, newValue:  level);
        if(skipSaving == false)
        {
            goto label_26;
        }
        
        return;
        label_8:
        UnityEngine.Debug.LogError(message:  "[PlayingLevel] No id specified when saving category level.");
        if(skipSaving == true)
        {
                return;
        }
        
        label_26:
        PlayingLevel.Save();
    }
    public static int GetCurrentPlayerLevelNumber()
    {
        return PlayingLevel.GetCurrentPlayerLevelNumber(mode:  PlayingLevel.CurrentGameplayMode);
    }
    public static int GetCurrentPlayerLevelNumber(GameplayMode mode)
    {
        var val_9;
        if(mode == 4)
        {
                val_9 = 1152921515417176704;
            CategoryPacksManager val_1 = MonoSingleton<CategoryPacksManager>.Instance;
            if((val_1.<CurrentCategoryPackInfo>k__BackingField) == null)
        {
                return 0;
        }
        
            CategoryPacksManager val_3 = MonoSingleton<CategoryPacksManager>.Instance;
            return MonoSingleton<CategoryPacksManager>.Instance.GetPackProgress(packId:  val_3.<CurrentCategoryPackInfo>k__BackingField.packId);
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_9 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_2F0;
    }
    public static void Save()
    {
        string val_3;
        var val_5;
        var val_21;
        var val_22;
        string val_24;
        val_21 = null;
        val_21 = null;
        if(PlayingLevel.initialized != true)
        {
                PlayingLevel.Initialize();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_22 = null;
        val_22 = null;
        Dictionary.Enumerator<TKey, TValue> val_2 = PlayingLevel.gameLevels.GetEnumerator();
        var val_22 = 0;
        label_29:
        if(val_5.MoveNext() == false)
        {
            goto label_9;
        }
        
        val_24 = val_3;
        if(val_3 == 4)
        {
            goto label_10;
        }
        
        if(val_24 == 0)
        {
            goto label_29;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_3.ToString(), value:  val_24.ToJSON());
        goto label_29;
        label_10:
        System.Collections.Generic.Dictionary<System.String, System.String> val_9 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        if(val_24 == 0)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_11 = GetEnumerator();
        label_24:
        if(val_5.MoveNext() == false)
        {
            goto label_22;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        EnumerableExtentions.SetOrAdd<System.String, System.String>(dic:  val_9, key:  val_3, newValue:  val_3.ToJSON());
        goto label_24;
        label_22:
        val_24 = 0;
        val_22 = val_22 + 1;
        mem2[0] = 138;
        val_5.Dispose();
        if(val_24 != 0)
        {
                throw val_24;
        }
        
        if(val_22 != 1)
        {
                var val_14 = ((1152921517569119568 + ((0 + 1)) << 2) == 138) ? 1 : 0;
            val_14 = ((val_22 >= 0) ? 1 : 0) & val_14;
            val_22 = val_22 - val_14;
        }
        
        if(4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_24 = 4.ToString();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  val_24, value:  MiniJSON.Json.Serialize(obj:  val_9));
        goto label_29;
        label_9:
        var val_18 = val_22 + 1;
        mem2[0] = 255;
        val_5.Dispose();
        UnityEngine.PlayerPrefs.SetString(key:  PlayingLevel.PP_Data, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_21 = PrefsSerializationManager.SavePlayerPrefs();
    }
    private static void Load()
    {
        string val_8;
        var val_10;
        string val_21;
        if((UnityEngine.PlayerPrefs.HasKey(key:  PlayingLevel.PP_Data)) == false)
        {
                return;
        }
        
        if((MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  PlayingLevel.PP_Data, defaultValue:  "{}"))) == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_7 = GetEnumerator();
        label_38:
        if(val_10.MoveNext() == false)
        {
            goto label_11;
        }
        
        val_21 = val_8;
        if((System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_21)) == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != 4)
        {
            goto label_18;
        }
        
        if(val_8 == 0)
        {
                throw new NullReferenceException();
        }
        
        object val_14 = MiniJSON.Json.Deserialize(json:  val_8);
        if(val_14 == null)
        {
            goto label_38;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_15 = val_14.GetEnumerator();
        label_29:
        if(val_10.MoveNext() == false)
        {
            goto label_23;
        }
        
        GameLevel val_17 = null;
        val_21 = val_17;
        val_17 = new GameLevel();
        if(val_8 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17.FromJSON(jsonString:  val_8);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_18 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.Add(key:  "catid", value:  val_8);
        PlayingLevel.SetLevel(currentMode:  4, level:  val_17, parameters:  val_18, skipSaving:  true);
        goto label_29;
        label_23:
        var val_20 = 0;
        val_21 = 0;
        val_20 = val_20 + 1;
        mem2[0] = 259;
        val_10.Dispose();
        if(val_21 != 0)
        {
                throw val_21;
        }
        
        var val_22 = val_20;
        if(val_22 == 1)
        {
            goto label_31;
        }
        
        if((77568704 + ((0 + 1)) << 2) != 259)
        {
            goto label_32;
        }
        
        var val_21 = 0;
        val_21 = val_21 ^ (val_22 >> 31);
        val_22 = val_22 + val_21;
        goto label_38;
        label_31:
        label_32:
        val_21 = 4;
        label_18:
        GameLevel val_19 = new GameLevel();
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19.FromJSON(jsonString:  val_8);
        PlayingLevel.SetLevel(currentMode:  val_21, level:  val_19, parameters:  0, skipSaving:  true);
        goto label_38;
        label_11:
        var val_23 = 0;
        val_23 = val_23 + 1;
        mem2[0] = 287;
        val_10.Dispose();
    }
    private static void Initialize()
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(PlayingLevel.initialized != false)
        {
                return;
        }
        
        val_3 = 1152921504975753224;
        PlayingLevel.initialized = true;
        PlayingLevel.gameLevels = new System.Collections.Generic.Dictionary<GameplayMode, System.Object>();
        PlayingLevel.Load();
    }
    public PlayingLevel()
    {
    
    }
    private static PlayingLevel()
    {
    
    }

}

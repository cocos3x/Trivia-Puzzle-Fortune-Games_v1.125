using UnityEngine;
public class WFOMetaGameBehavior : MetaGameBehavior
{
    // Properties
    public override System.Collections.Generic.Dictionary<string, System.Type> EventHandlerTypeLookup { get; }
    public override int PlayerStructureLevel { get; }
    public override int HighestAvailableUniqueStructureLevel { get; }
    public override int PlayerInitialGoldenCurrency { get; }
    public override int FTUXLevel { get; }
    public override int DailyChallengeVersion { get; }
    public override bool supportAdsControlV2 { get; }
    public override bool supportsEvents { get; }
    public override bool supportAdsControl { get; }
    public override bool supportsFriendInviter { get; }
    public override bool supportsExtraWordsList { get; }
    public override bool supportsChallengeFLyout { get; }
    public override bool supportsCategoryLevelPacks { get; }
    public override bool supportsFeatureMenu { get; }
    public override bool supportsNotificationLifecylce { get; }
    public override bool supportsPets { get; }
    public override bool supportsLocalization { get; }
    public override bool supportsAlphabet { get; }
    public override bool supportsWordIQ { get; }
    public override bool supportsLibrary { get; }
    public override bool supportExtraRequiredWords { get; }
    public override bool isEventsDisplayable { get; }
    public override int PickerHintTutorialLevel { get; }
    public override bool ShowV2PickerHintTutorial { get; }
    public override bool ShowV2HintTutorial { get; }
    public override int HintTutorialLevel { get; }
    public override int PickerHintUnlockLevel { get; }
    public override bool SupportsFreeHints { get; }
    public override bool SkipTutorialEligible { get; }
    public override bool ExtraWordGameplayUpdate { get; }
    
    // Methods
    public override System.Collections.Generic.Dictionary<string, System.Type> get_EventHandlerTypeLookup()
    {
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Type>();
        val_1.Add(key:  "LightningLevels", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "WildWordWeekend", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "WordHunt", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        return val_1;
    }
    public override int get_PlayerStructureLevel()
    {
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        return (int)val_1.currentForestID;
    }
    public override int get_HighestAvailableUniqueStructureLevel()
    {
        return (int)MonoSingleton<WordForest.WFOForestManager>.Instance;
    }
    public override int get_PlayerInitialGoldenCurrency()
    {
        WordForest.WFOGameEcon val_1 = App.GetGameSpecificEcon<WordForest.WFOGameEcon>();
        return (int)val_1.InitialPlayerGoldenCurrency;
    }
    public override int get_FTUXLevel()
    {
        return 1;
    }
    public override int get_DailyChallengeVersion()
    {
        return 7;
    }
    public override bool AdsAllowedByScene()
    {
        return (bool)(this == 2) ? 1 : 0;
    }
    public override void WildWeekedOnContinue()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public override string GetUrlSharePrefix()
    {
        return "https://{0}/word/invite?";
    }
    public override string GetLevelNameForTracking()
    {
        var val_14;
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
        {
                return MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return MonoSingleton<WGDailyChallengeManager>.Instance.GetLevelForTracking();
        }
        
        val_14 = 1152921504975749120;
        if(CategoryPacksManager.IsPlaying != false)
        {
                if((PlayingLevel.GetCategoryLevel(categoryPackId:  0)) != null)
        {
                return (string)val_13.word;
        }
        
        }
        
        if((PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false)) != null)
        {
                if((PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false)) != null)
        {
                return (string)val_13.word;
        }
        
        }
        
        val_14 = MonoSingletonSelfGenerating<WADChapterManager>.Instance;
        GameLevel val_13 = val_14.GetGameLevel(playerLevel:  App.Player);
        return (string)val_13.word;
    }
    public override string GetLevelForTracking()
    {
        if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
        {
            goto label_9;
        }
        
        SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
        if(val_3.GetCurrentRank == null)
        {
            goto label_9;
        }
        
        SLC.Minigames.MinigameLevelRank val_5 = val_3.GetCurrentRank;
        if((System.String.IsNullOrEmpty(value:  val_5.rankName)) == false)
        {
            goto label_11;
        }
        
        label_9:
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return (string)System.String.Format(format:  "{0}-{1}", arg0:  Prefs.currentChapter, arg1:  Prefs.currentLevel + 1);
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance) == 0)
        {
                return (string)System.String.Format(format:  "{0}-{1}", arg0:  Prefs.currentChapter, arg1:  Prefs.currentLevel + 1);
        }
        
        return MonoSingleton<WGDailyChallengeManager>.Instance.GetStageForTracking();
        label_11:
        SLC.Minigames.MinigameLevelRank val_16 = val_3.GetCurrentRank;
        SLC.Minigames.MinigameLevelRank val_17 = val_3.GetCurrentRank;
        return System.String.Format(format:  "{0}-{1}", arg0:  val_16.rankName, arg1:  val_17.rankLevel.ToString());
    }
    public override bool DailyChallengeSupported()
    {
        return true;
    }
    public override bool DailyChallengeRevamped()
    {
        return true;
    }
    public override bool StoryModeSupported()
    {
        return false;
    }
    public override void LoadScene(SceneType sceneToLoad, bool immediate = False)
    {
        bool val_2;
        SceneType val_3;
        if(sceneToLoad == 5)
        {
                if(WordForest.WFOForestManager.IsFeatureUnlocked == false)
        {
            goto label_1;
        }
        
        }
        
        val_2 = immediate;
        val_3 = sceneToLoad;
        goto label_2;
        label_1:
        val_2 = immediate;
        val_3 = 2;
        label_2:
        this.LoadScene(sceneToLoad:  val_3, immediate:  val_2);
    }
    public override void OnClickHome()
    {
        var val_4;
        var val_5;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_4 = null;
            val_4 = null;
            val_5 = 2;
        }
        else
        {
                val_4 = null;
            val_4 = null;
            val_5 = 70;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 70;
        MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        this.OnClickHome();
    }
    public override void SaveAllLevelsForCurrentGame(System.Collections.Generic.List<object> response)
    {
    
    }
    public override SceneType getActiveSceneType()
    {
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        string val_2 = val_1.m_Handle.name;
        return (SceneType)this;
    }
    public override bool overlaySceneShowing()
    {
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = null;
        val_2 = null;
        if(SceneDictator.lastOverlayedScene == 0)
        {
                return false;
        }
        
        val_3 = null;
        val_3 = null;
        if(SceneDictator.lastOverlayedScene == 1)
        {
                return false;
        }
        
        val_4 = null;
        val_4 = null;
        if(SceneDictator.lastOverlayedScene == 2)
        {
                return false;
        }
        
        val_5 = null;
        val_5 = null;
        var val_1 = (SceneDictator.lastOverlayedScene != 5) ? 1 : 0;
        return false;
    }
    public override string GetTitleFormat()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return (string)(val_1.theme.themeType == 1) ? "•{0}•" : "{0}";
    }
    public override string GetSceneNameFromSceneType(SceneType sceneType)
    {
        var val_4;
        if((sceneType - 1) <= 10)
        {
                var val_3 = 32555216 + ((sceneType - 1)) << 2;
            val_3 = val_3 + 32555216;
        }
        else
        {
                val_4 = sceneType.ToString();
            return (string);
        }
    
    }
    public override System.Collections.Generic.List<string[]> LeagueHints()
    {
        int val_8;
        int val_9;
        int val_10;
        int val_11;
        int val_12;
        int val_13;
        System.Collections.Generic.List<System.String[]> val_1 = new System.Collections.Generic.List<System.String[]>();
        string[] val_2 = new string[2];
        val_8 = val_2.Length;
        val_2[0] = "WFOleague_loading_hint_1";
        val_8 = val_2.Length;
        val_2[1] = "Earn Acorns by making word streaks";
        val_1.Add(item:  val_2);
        string[] val_3 = new string[2];
        val_9 = val_3.Length;
        val_3[0] = "WFOleague_loading_hint_2";
        val_9 = val_3.Length;
        val_3[1] = "The top 2 clubs in a group move up in the League!";
        val_1.Add(item:  val_3);
        string[] val_4 = new string[2];
        val_10 = val_4.Length;
        val_4[0] = "WFOleague_loading_hint_3";
        val_10 = val_4.Length;
        val_4[1] = "The bottom 4 clubs in a group move down in the League";
        val_1.Add(item:  val_4);
        string[] val_5 = new string[2];
        val_11 = val_5.Length;
        val_5[0] = "WFOleague_loading_hint_4";
        val_11 = val_5.Length;
        val_5[1] = "Increase club level to increase maximum members";
        val_1.Add(item:  val_5);
        string[] val_6 = new string[2];
        val_12 = val_6.Length;
        val_6[0] = "WFOleague_loading_hint_5";
        val_12 = val_6.Length;
        val_6[1] = "Join a club to earn rewards each week!";
        val_1.Add(item:  val_6);
        string[] val_7 = new string[2];
        val_13 = val_7.Length;
        val_7[0] = "WFOleague_loading_hint_6";
        val_13 = val_7.Length;
        val_7[1] = "Each season lasts for one week";
        val_1.Add(item:  val_7);
        return val_1;
    }
    public override SceneType GetSceneTypeFromSceneName(string sceneName)
    {
        var val_3;
        if((sceneName.Contains(value:  "ForestScene")) != false)
        {
                val_3 = 5;
            return 11;
        }
        
        if((sceneName.Contains(value:  "RaidAttack")) == false)
        {
                return this.GetSceneTypeFromSceneName(sceneName:  sceneName);
        }
        
        val_3 = 11;
        return 11;
    }
    public override bool ArePopupsAllowedForSceneType(SceneType type)
    {
        if(type != 2)
        {
                return (bool)((type | 4) == 5) ? 1 : 0;
        }
        
        return true;
    }
    public override void SaveLevelsFromChaptersCurrentGame(System.Collections.Generic.List<object> chapters, string language = "")
    {
    
    }
    public override bool get_supportAdsControlV2()
    {
        return true;
    }
    public override bool get_supportsEvents()
    {
        return true;
    }
    public override bool get_supportAdsControl()
    {
        return true;
    }
    public override bool get_supportsFriendInviter()
    {
        return true;
    }
    public override bool get_supportsExtraWordsList()
    {
        return true;
    }
    public override bool get_supportsChallengeFLyout()
    {
        return true;
    }
    public override string GetGoldenAppleNameForGame()
    {
        return Localization.Localize(key:  "acorns", defaultValue:  "Acorns", useSingularKey:  false);
    }
    public override string GetGoldenAppleNameForGameUpper()
    {
        return Localization.Localize(key:  "acorns_upper", defaultValue:  "ACORNS", useSingularKey:  false);
    }
    public override bool get_supportsCategoryLevelPacks()
    {
        return false;
    }
    public override bool get_supportsFeatureMenu()
    {
        return true;
    }
    public override bool get_supportsNotificationLifecylce()
    {
        return true;
    }
    public override bool get_supportsPets()
    {
        return false;
    }
    public override UnityEngine.GameObject OpenPauseMenu()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                MonoSingleton<WGWindowManager>.Instance.CloseCurrentWindow();
            GameBehavior val_3 = App.getBehavior;
            return 0;
        }
        
        GameBehavior val_4 = App.getBehavior;
        return val_4.<metaGameBehavior>k__BackingField.gameObject;
    }
    public override bool get_supportsLocalization()
    {
        return true;
    }
    public override System.Collections.Generic.List<string> GetSupportedLanguageNames()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "en");
        val_1.Add(item:  "es");
        return val_1;
    }
    public override bool get_supportsAlphabet()
    {
        return false;
    }
    public override bool get_supportsWordIQ()
    {
        return false;
    }
    public override bool get_supportsLibrary()
    {
        return false;
    }
    public override bool get_supportExtraRequiredWords()
    {
        return true;
    }
    public override bool get_isEventsDisplayable()
    {
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        GameEcon val_2 = App.getGameEcon;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.currentForestID, knobValue:  val_2.events_unlockLevel);
    }
    public override bool GemsUnlocked()
    {
        return false;
    }
    public override void AppendUserProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> userProperties)
    {
        WordForest.WFOForestManager val_1 = MonoSingleton<WordForest.WFOForestManager>.Instance;
        if(val_1 == 0)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  System.String.Format(format:  "{0}{1}", arg0:  val_1.CurrentForestLevel, arg1:  val_1.CurrentForestGrowth.ToString(format:  "D2")), result: out  0)) == false)
        {
                return;
        }
        
        1152921517075761744 = userProperties;
        1152921517075761744.Add(key:  "Current Forest Lvl", value:  0);
    }
    public override void InjectAdditionalLevelStartTrackings(ref System.Collections.Generic.Dictionary<string, object> eventData)
    {
        if((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance) == 0)
        {
                return;
        }
        
        1152921517075915568 = eventData;
        1152921517075915568.Add(key:  "Mystery Chest Shown", value:  ((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetChestCount) > 0) ? 1 : 0);
    }
    public override string GetSpecialCurrencyLocalizationKey()
    {
        return "acorns_meta";
    }
    public override int get_PickerHintTutorialLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintPickerTutorialLevelV2;
    }
    public override bool get_ShowV2PickerHintTutorial()
    {
        return true;
    }
    public override bool get_ShowV2HintTutorial()
    {
        return true;
    }
    public override int get_HintTutorialLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintTutorialLevelV2;
    }
    public override int get_PickerHintUnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintPickerUnlockLevelV2;
    }
    public override bool get_SupportsFreeHints()
    {
        return false;
    }
    public override bool get_SkipTutorialEligible()
    {
        return false;
    }
    public override void InjectGameSpecificGlobals(ref System.Collections.Generic.Dictionary<string, object> globals)
    {
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        globals.Add(key:  "Attack FTUX Complete", value:  MonoExtensions.IsBitSet(value:  val_1.tutorialCompleted, bit:  10));
        WordForest.WFOPlayer val_4 = WordForest.WFOPlayer.Instance;
        globals.Add(key:  "Raid FTUX Complete", value:  MonoExtensions.IsBitSet(value:  val_4.tutorialCompleted, bit:  9));
        WordForest.WFOPlayer val_7 = WordForest.WFOPlayer.Instance;
        globals.Add(key:  "Shield FTUX Complete", value:  MonoExtensions.IsBitSet(value:  val_7.tutorialCompleted, bit:  8));
        if((MonoSingleton<WGLeaderboardManager>.Instance) == 0)
        {
                return;
        }
        
        1152921517077009856 = globals;
        WGLeaderboardManager val_12 = MonoSingleton<WGLeaderboardManager>.Instance;
        1152921517077009856.Add(key:  "Lifetime Golden Currency", value:  val_12.playerInfo_Self.lifetimeBalance);
    }
    public override bool get_ExtraWordGameplayUpdate()
    {
        return false;
    }
    public WFOMetaGameBehavior()
    {
    
    }

}

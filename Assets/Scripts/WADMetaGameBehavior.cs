using UnityEngine;
public class WADMetaGameBehavior : MetaGameBehavior
{
    // Properties
    public override System.Collections.Generic.Dictionary<string, System.Type> EventHandlerTypeLookup { get; }
    public override bool supportsEvents { get; }
    public override float AdsDisplayValueMultiplier { get; }
    public override bool supportAdsControlV2 { get; }
    public override bool supportAdsControl { get; }
    public override bool supportsFriendInviter { get; }
    public override bool supportsExtraWordsList { get; }
    public override bool supportsChallengeFLyout { get; }
    public override bool supportsCategoryLevelPacks { get; }
    public override bool supportsFeatureMenu { get; }
    public override bool supportsNotificationLifecylce { get; }
    public override bool supportsPets { get; }
    public override bool supportsDifficultySetting { get; }
    public override bool supportsAlphabet { get; }
    public override bool supportsLocalization { get; }
    public override bool supportsRestoreProgression { get; }
    public override bool supportsDailyChallengeTutorial { get; }
    public override bool supportsTournaments { get; }
    public override bool supportsDiceRolls { get; }
    public override int FTUXLevel { get; }
    public override int PickerHintTutorialLevel { get; }
    public override bool ShowV2PickerHintTutorial { get; }
    public override bool ShowV2HintTutorial { get; }
    public override int HintTutorialLevel { get; }
    public override int PickerHintUnlockLevel { get; }
    public override bool SupportsFreeHints { get; }
    public override bool SkipTutorialEligible { get; }
    public override bool ExtraWordGameplayUpdate { get; }
    public override int WordStreakStartCount { get; }
    public override bool SupportsNonAlphabeticalOrder { get; }
    
    // Methods
    public override System.Collections.Generic.Dictionary<string, System.Type> get_EventHandlerTypeLookup()
    {
        System.Collections.Generic.Dictionary<System.String, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Type>();
        val_1.Add(key:  "WordHunt", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  "ProgressiveIapSale", value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        return val_1;
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
    public override bool StoryModeSupported()
    {
        return true;
    }
    public override void OnClickHome()
    {
        var val_5;
        var val_6;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                val_5 = null;
            val_5 = null;
            val_6 = 2;
        }
        else
        {
                val_5 = null;
            val_5 = null;
            val_6 = 70;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 70;
        MonoSingleton<DailyChallengeTutorialManager>.Instance.CheckHomeClick();
        MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        this.OnClickHome();
    }
    public override void SaveAllLevelsForCurrentGame(System.Collections.Generic.List<object> response)
    {
    
    }
    public override SceneType getActiveSceneType()
    {
        UnityEngine.SceneManagement.Scene val_1 = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        return (SceneType)this.GetSceneTypeFromSceneName(sceneName:  val_1.m_Handle.name);
    }
    public override string GetTitleFormat()
    {
        ThemesHandler val_1 = App.ThemesHandler;
        return (string)(val_1.theme.themeType == 1) ? "•{0}•" : "{0}";
    }
    public override void SaveLevelsFromChaptersCurrentGame(System.Collections.Generic.List<object> chapters, string language = "")
    {
    
    }
    public override bool get_supportsEvents()
    {
        return true;
    }
    public override float get_AdsDisplayValueMultiplier()
    {
        return 1.2f;
    }
    public override bool get_supportAdsControlV2()
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
        return Localization.Localize(key:  "golden_apples", defaultValue:  "Golden Apples", useSingularKey:  false);
    }
    public override string GetGoldenAppleNameForGameUpper()
    {
        return Localization.Localize(key:  "golden_apples_upper", defaultValue:  "GOLDEN APPLES", useSingularKey:  false);
    }
    public override bool get_supportsCategoryLevelPacks()
    {
        return true;
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
        return true;
    }
    public override bool get_supportsDifficultySetting()
    {
        return true;
    }
    public override UnityEngine.GameObject OpenPauseMenu()
    {
        GameBehavior val_1 = App.getBehavior;
        return val_1.<metaGameBehavior>k__BackingField.gameObject;
    }
    public override bool get_supportsAlphabet()
    {
        return true;
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
        val_1.Add(item:  "fr");
        val_1.Add(item:  "de");
        return val_1;
    }
    public override bool get_supportsRestoreProgression()
    {
        return true;
    }
    public override bool get_supportsDailyChallengeTutorial()
    {
        return true;
    }
    public override bool get_supportsTournaments()
    {
        return true;
    }
    public override bool get_supportsDiceRolls()
    {
        var val_2;
        if((SnakesAndLaddersEventHandler.<Instance>k__BackingField) != null)
        {
                val_2 = (SnakesAndLaddersEventHandler.<Instance>k__BackingField) ^ 1;
            return (bool)val_2 & 1;
        }
        
        val_2 = 0;
        return (bool)val_2 & 1;
    }
    public override int get_FTUXLevel()
    {
        return 1;
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
    public override string LeaguesBenefitsDescription()
    {
        return Localization.Localize(key:  "league_benefit_info1", defaultValue:  "Free Coins each day when earning first Golden Apples.", useSingularKey:  false);
    }
    public override bool get_SkipTutorialEligible()
    {
        return false;
    }
    public override bool get_ExtraWordGameplayUpdate()
    {
        return false;
    }
    public override int get_WordStreakStartCount()
    {
        return 2;
    }
    public override bool get_SupportsNonAlphabeticalOrder()
    {
        return true;
    }
    public override void InjectGameSpecificGlobals(ref System.Collections.Generic.Dictionary<string, object> globals)
    {
        if((MonoSingleton<WGLeaderboardManager>.Instance) == 0)
        {
                return;
        }
        
        WGLeaderboardManager val_3 = MonoSingleton<WGLeaderboardManager>.Instance;
        if(val_3.playerInfo_Self == null)
        {
                return;
        }
        
        1152921517066899872 = globals;
        WGLeaderboardManager val_4 = MonoSingleton<WGLeaderboardManager>.Instance;
        1152921517066899872.Add(key:  "Lifetime Golden Currency", value:  val_4.playerInfo_Self.lifetimeBalance);
    }
    public WADMetaGameBehavior()
    {
    
    }

}

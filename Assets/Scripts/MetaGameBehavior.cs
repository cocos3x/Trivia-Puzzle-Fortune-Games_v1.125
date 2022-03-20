using UnityEngine;
public class MetaGameBehavior
{
    // Properties
    public virtual System.Collections.Generic.Dictionary<string, System.Type> DefaultEventTypes { get; }
    public virtual System.Collections.Generic.Dictionary<string, System.Type> EventHandlerTypeLookup { get; }
    public virtual int PlayerLevel { get; set; }
    public virtual int PlayerLevelHighest { get; }
    public virtual float AdsDisplayValueMultiplier { get; }
    public virtual int FTUXLevel { get; }
    public virtual int DailyChallengeVersion { get; }
    public virtual int RewardedVideoGemReward { get; }
    public virtual int PlayerStructureLevel { get; }
    public virtual int HighestAvailableUniqueStructureLevel { get; }
    public virtual decimal FOMOCurrency { get; }
    public virtual string FOMOCurrencyType { get; }
    public virtual string NotifImgUrlDailyBonus { get; }
    public virtual string NotifImgUrlPostAd { get; }
    public virtual bool supportsAdaptiveRewardedVideoReward { get; }
    public virtual bool supportsMiniSettingsPopupSoundButtons { get; }
    public virtual bool supportsSales { get; }
    public virtual bool supportsSeparatePlayerLevels { get; }
    public virtual bool supportsEvents { get; }
    public virtual bool isEventsDisplayable { get; }
    public virtual bool supportsGOTDPopup { get; }
    public virtual bool supportsDailyLoginRewardPopup { get; }
    public virtual bool supportsEmailCollectPopup { get; }
    public virtual bool supportsRecommendPopup { get; }
    public virtual bool supportsFriendInviter { get; }
    public virtual bool supportsFBConnect { get; }
    public virtual bool supportsExtraWordsList { get; }
    public virtual bool supportsChallenges { get; }
    public virtual bool supportsChallengeFLyout { get; }
    public virtual bool supportsSubscriptions { get; }
    public virtual bool supportsCategoryLevelPacks { get; }
    public virtual bool supportsRecaptureNotifications { get; }
    public virtual bool supportsFeatureMenu { get; }
    public virtual bool supportsNotificationLifecylce { get; }
    public virtual bool supportsPets { get; }
    public virtual bool supportsSpins { get; }
    public virtual bool supportsDifficultySetting { get; }
    public virtual bool supportsLocalization { get; }
    public virtual bool supportsAlphabet { get; }
    public virtual bool supportsWordIQ { get; }
    public virtual bool supportsLibrary { get; }
    public virtual bool supportsFBShare { get; }
    public virtual bool supportsRestoreProgression { get; }
    public virtual bool purchasesAlwaysRemoveAds { get; }
    public virtual bool leaguesRewardsCoins { get; }
    public virtual bool playMusicInLeaugues { get; }
    public virtual bool leaguesContributeCostCoins { get; }
    public virtual bool leaguesMultiplierCostCoins { get; }
    public virtual bool supportExtraRequiredWords { get; }
    public virtual bool supportsDailyChallengeTutorial { get; }
    public virtual bool supportsTournaments { get; }
    public virtual bool supportsBonusRewards { get; }
    public virtual bool supportsDiceRolls { get; }
    public virtual bool canShowGameSceneEventUpdates { get; }
    public virtual bool supportsLeaguesUnlockingAnimation { get; }
    public virtual bool alwaysForceReviewTracking { get; }
    public virtual bool supportsPortraitCollection { get; }
    public virtual bool supportAdsControl { get; }
    public virtual bool supportAdsControlV2 { get; }
    public virtual bool isWordGame { get; }
    public virtual bool supportsLeaguesLowPointJoinLock { get; }
    public virtual bool supportsSilverTicketDisplay { get; }
    public virtual bool canShowGoldenTicketStoreItem { get; }
    public virtual bool subscriptionGrantsGems { get; }
    public virtual bool IsDailyBonusAvailable { get; }
    public virtual bool IsDailyBonusFtuxAvailable { get; }
    protected virtual bool AdoptNewCurrencySourcePropKey { get; }
    public virtual decimal PlayerInitialCoins { get; }
    public virtual int PlayerInitialGems { get; }
    public virtual int PlayerInitialGoldenCurrency { get; }
    public virtual bool PiggyBankUsesGems { get; }
    public virtual bool SuperBundleUsesGems { get; }
    public virtual bool CanShowUnPauseInterstitial { get; }
    public virtual float WindowManagerBackgroundAlpha { get; }
    public virtual int PickerHintUnlockLevel { get; }
    public virtual int PickerHintTutorialLevel { get; }
    public virtual bool ShowV2PickerHintTutorial { get; }
    public virtual bool ShowV2HintTutorial { get; }
    public virtual int HintTutorialLevel { get; }
    public virtual bool SupportsFreeHints { get; }
    public virtual bool InNormalGameMode { get; }
    public virtual bool SkipTutorialEligible { get; }
    public virtual bool ExtraWordGameplayUpdate { get; }
    public virtual int WordStreakStartCount { get; }
    public virtual bool SupportsNonAlphabeticalOrder { get; }
    public virtual string BannerPlacement { get; }
    
    // Methods
    public virtual System.Collections.Generic.Dictionary<string, System.Type> get_DefaultEventTypes()
    {
        return 0;
    }
    public virtual System.Collections.Generic.Dictionary<string, System.Type> get_EventHandlerTypeLookup()
    {
        return 0;
    }
    public virtual System.Type getDefinitions<T>()
    {
        return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
    }
    public virtual bool AdsAllowedByScene()
    {
        return false;
    }
    public virtual bool BannerAdsSkipPlayerLevelCheck()
    {
        return false;
    }
    public virtual bool levelClearShown()
    {
        return false;
    }
    public virtual void WildWeekedOnContinue()
    {
        UnityEngine.Debug.LogError(message:  "Continue wild weekend but no behavior has been declared");
    }
    public virtual void SaveLevelsFromChaptersCurrentGame(System.Collections.Generic.List<object> chapters, string language = "")
    {
        UnityEngine.Debug.LogWarning(message:  "Trying to save levels from chapter for current game but not behavior has been specified for this game");
    }
    public virtual bool UsesSingleScene()
    {
        return false;
    }
    public virtual void LoadSingleSceneGameplayScene()
    {
    
    }
    public virtual string GetUrlSharePrefix()
    {
        UnityEngine.Debug.LogError(message:  "URL share prefix has not been set, check other games behavior classes for explamples");
        return "Game Url Not Set";
    }
    public virtual string GetShareTextScreenShot()
    {
        return "I found a new word game! {0}";
    }
    public virtual string GetLevelNameForTracking()
    {
        return "Game Name Not Set";
    }
    public virtual string GetLevelForTracking()
    {
        return "Game Name Not Set";
    }
    public virtual bool DailyChallengeSupported()
    {
        return false;
    }
    public virtual bool DailyChallengeRevamped()
    {
        return false;
    }
    public virtual bool StoryModeSupported()
    {
        return false;
    }
    public virtual void OnClickHome()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                App.Quit();
            return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public virtual void SaveAllLevelsForCurrentGame(System.Collections.Generic.List<object> response)
    {
        null = null;
        UnityEngine.Debug.LogError(message:  "No behavior set for SaveAllLevelsForCurrentGame in " + App.game);
    }
    public virtual void ShowFTUXWindow()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<FTUXDemoWindow>(showNext:  false);
    }
    public virtual SceneType getActiveSceneType()
    {
        null = null;
        UnityEngine.Debug.LogError(message:  "Requesting scene type for " + App.game + " but behavior logic has not been set up, please overload this method for proper interactions");
        return 3;
    }
    public virtual SceneType getOverlayedSceneType()
    {
        null = null;
        return (SceneType)SceneDictator.lastOverlayedScene;
    }
    public virtual bool overlaySceneShowing()
    {
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_2 = null;
        val_2 = null;
        if(SceneDictator.lastOverlayedScene == 0)
        {
            goto label_6;
        }
        
        val_3 = null;
        val_3 = null;
        if(SceneDictator.lastOverlayedScene != 1)
        {
            goto label_12;
        }
        
        label_6:
        val_4 = 0;
        return (bool)(SceneDictator.lastOverlayedScene != 2) ? 1 : 0;
        label_12:
        val_5 = null;
        val_5 = null;
        return (bool)(SceneDictator.lastOverlayedScene != 2) ? 1 : 0;
    }
    public virtual string GetTitleFormat()
    {
        return "{0}";
    }
    public virtual int get_PlayerLevel()
    {
        Player val_1 = App.Player;
        goto typeof(Player).__il2cppRuntimeField_170;
    }
    public virtual void set_PlayerLevel(int value)
    {
        Player val_1 = App.Player;
        goto typeof(Player).__il2cppRuntimeField_180;
    }
    public virtual int get_PlayerLevelHighest()
    {
        Player val_1 = App.Player;
        goto typeof(Player).__il2cppRuntimeField_170;
    }
    public virtual float get_AdsDisplayValueMultiplier()
    {
        return 2f;
    }
    public virtual int get_FTUXLevel()
    {
        return 2;
    }
    public virtual int get_DailyChallengeVersion()
    {
        return 6;
    }
    public virtual int get_RewardedVideoGemReward()
    {
        UnityEngine.Debug.LogError(message:  "Please override Rewarded Video Gem Reward in metabehavior. Returning default value 0");
        return 0;
    }
    public virtual int get_PlayerStructureLevel()
    {
        Player val_1 = App.Player;
        goto typeof(Player).__il2cppRuntimeField_170;
    }
    public virtual int get_HighestAvailableUniqueStructureLevel()
    {
        return 999999;
    }
    public virtual decimal get_FOMOCurrency()
    {
        Player val_1 = App.Player;
        return new System.Decimal() {flags = val_1._credits, hi = val_1._credits};
    }
    public virtual string get_FOMOCurrencyType()
    {
        return "credits";
    }
    public virtual System.Collections.Generic.List<PurchaseModel> FilterStoreCreditPacksPerGame(System.Collections.Generic.List<PurchaseModel> unfiltered)
    {
        var val_2;
        System.Predicate<PurchaseModel> val_4;
        val_2 = null;
        val_2 = null;
        val_4 = MetaGameBehavior.<>c.<>9__47_0;
        if(val_4 != null)
        {
                return unfiltered.FindAll(match:  System.Predicate<PurchaseModel> val_1 = null);
        }
        
        val_4 = val_1;
        val_1 = new System.Predicate<PurchaseModel>(object:  MetaGameBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean MetaGameBehavior.<>c::<FilterStoreCreditPacksPerGame>b__47_0(PurchaseModel p));
        MetaGameBehavior.<>c.<>9__47_0 = val_4;
        return unfiltered.FindAll(match:  val_1);
    }
    public virtual System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> CustomGemCreditPacks()
    {
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "id", value:  "id_gems1");
        val_2.Add(key:  "gems", value:  7);
        val_2.Add(key:  "sale_price", value:  4.99f);
        val_1.Add(item:  val_2);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "id", value:  "id_gems2");
        val_3.Add(key:  "gems", value:  16);
        val_3.Add(key:  "sale_price", value:  9.99f);
        val_1.Add(item:  val_3);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "id", value:  "id_gems3");
        val_4.Add(key:  "gems", value:  34);
        val_4.Add(key:  "sale_price", value:  19.99f);
        val_1.Add(item:  val_4);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_5.Add(key:  "id", value:  "id_gems4");
        val_5.Add(key:  "gems", value:  112);
        val_5.Add(key:  "sale_price", value:  49.99f);
        val_1.Add(item:  val_5);
        return val_1;
    }
    public virtual void ReloadScene(bool fadeOut)
    {
        CUtils.ReloadScene(useScreenFader:  fadeOut);
    }
    public virtual void LoadScene(SceneType sceneToLoad, bool immediate = False)
    {
        if((MonoSingleton<GameStoreUI>.Instance) != 0)
        {
                MonoSingleton<GameStoreUI>.Instance.ForceClose();
        }
        
        if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) != 0)
        {
                SLC.Social.Leagues.LeaguesUIManager.LeaveLeaguesScene();
        }
        
        if((sceneToLoad != 3) && (immediate != true))
        {
                CUtils.FadeAndLoadScene(sceneName:  this + "_" + App.ThemesHandler.CurrentThemeName);
            return;
        }
        
        CUtils.LoadSceneImmediate(sceneName:  sceneToLoad + "_" + App.ThemesHandler.CurrentThemeName);
    }
    public bool IsLoadingScene()
    {
        return CUtils.IsLoadingScene();
    }
    public virtual string GetSceneNameFromSceneType(SceneType sceneType)
    {
        if((sceneType - 1) <= 11)
        {
                var val_3 = 32498468 + ((sceneType - 1)) << 2;
            val_3 = val_3 + 32498468;
        }
        else
        {
                string val_2 = sceneType.ToString();
            return (string);
        }
    
    }
    public virtual SceneType GetSceneTypeFromSceneName(string sceneName)
    {
        var val_12;
        if((sceneName.Contains(value:  "Store")) != false)
        {
                val_12 = 6;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Boot")) != false)
        {
                val_12 = 0;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Launch")) != false)
        {
                val_12 = 1;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Mini")) != false)
        {
                val_12 = 3;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Game")) != false)
        {
                val_12 = 2;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "League")) != false)
        {
                val_12 = 4;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Library")) != false)
        {
                val_12 = 7;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Category")) != false)
        {
                val_12 = 8;
            return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        if((sceneName.Contains(value:  "Pets")) == false)
        {
                return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
        }
        
        val_12 = 10;
        return (SceneType)((sceneName.Contains(value:  "ForestFrenzy")) != true) ? 12 : 3;
    }
    public virtual bool ArePopupsAllowedForSceneType(SceneType type)
    {
        return (bool)((type - 1) < 2) ? 1 : 0;
    }
    public virtual void PlayGame()
    {
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public virtual int GetHintsUsed()
    {
        if(MainController.instance == 0)
        {
                throw new System.NotImplementedException();
        }
        
        MainController val_3 = MainController.instance;
        goto typeof(MainController).__il2cppRuntimeField_1D0;
    }
    public virtual string get_NotifImgUrlDailyBonus()
    {
        return "https://s3-us-west-1.amazonaws.com/12gcontent/WordAddictRpnImg/DailyReward.png";
    }
    public virtual string get_NotifImgUrlPostAd()
    {
        return "https://s3-us-west-1.amazonaws.com/12gcontent/WordAddictRpnImg/PostAdClick.png";
    }
    public virtual bool get_supportsAdaptiveRewardedVideoReward()
    {
        return true;
    }
    public virtual bool get_supportsMiniSettingsPopupSoundButtons()
    {
        return true;
    }
    public virtual bool get_supportsSales()
    {
        return true;
    }
    public virtual bool get_supportsSeparatePlayerLevels()
    {
        return false;
    }
    public virtual bool get_supportsEvents()
    {
        return false;
    }
    public virtual bool get_isEventsDisplayable()
    {
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_2 = App.getGameEcon;
        return GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.<metaGameBehavior>k__BackingField, knobValue:  val_2.events_unlockLevel);
    }
    public virtual bool get_supportsGOTDPopup()
    {
        return true;
    }
    public virtual bool get_supportsDailyLoginRewardPopup()
    {
        return true;
    }
    public virtual bool get_supportsEmailCollectPopup()
    {
        return true;
    }
    public virtual bool get_supportsRecommendPopup()
    {
        return true;
    }
    public virtual bool get_supportsFriendInviter()
    {
        return false;
    }
    public virtual bool get_supportsFBConnect()
    {
        return false;
    }
    public virtual bool get_supportsExtraWordsList()
    {
        return false;
    }
    public virtual bool get_supportsChallenges()
    {
        return true;
    }
    public virtual bool get_supportsChallengeFLyout()
    {
        return false;
    }
    public virtual bool get_supportsSubscriptions()
    {
        return true;
    }
    public virtual bool get_supportsCategoryLevelPacks()
    {
        return false;
    }
    public virtual bool get_supportsRecaptureNotifications()
    {
        return true;
    }
    public virtual bool get_supportsFeatureMenu()
    {
        return false;
    }
    public virtual bool get_supportsNotificationLifecylce()
    {
        return false;
    }
    public virtual bool get_supportsPets()
    {
        return false;
    }
    public virtual bool get_supportsSpins()
    {
        return false;
    }
    public virtual bool get_supportsDifficultySetting()
    {
        return false;
    }
    public virtual bool get_supportsLocalization()
    {
        return false;
    }
    public virtual bool get_supportsAlphabet()
    {
        return false;
    }
    public virtual bool get_supportsWordIQ()
    {
        return true;
    }
    public virtual bool get_supportsLibrary()
    {
        return true;
    }
    public virtual bool get_supportsFBShare()
    {
        return true;
    }
    public virtual bool get_supportsRestoreProgression()
    {
        return false;
    }
    public virtual bool get_purchasesAlwaysRemoveAds()
    {
        return true;
    }
    public virtual bool get_leaguesRewardsCoins()
    {
        return true;
    }
    public virtual bool get_playMusicInLeaugues()
    {
        return true;
    }
    public virtual bool get_leaguesContributeCostCoins()
    {
        return true;
    }
    public virtual bool get_leaguesMultiplierCostCoins()
    {
        return true;
    }
    public virtual bool get_supportExtraRequiredWords()
    {
        return true;
    }
    public virtual bool get_supportsDailyChallengeTutorial()
    {
        return false;
    }
    public virtual bool get_supportsTournaments()
    {
        return false;
    }
    public virtual bool get_supportsBonusRewards()
    {
        return false;
    }
    public virtual bool get_supportsDiceRolls()
    {
        return false;
    }
    public virtual bool get_canShowGameSceneEventUpdates()
    {
        return true;
    }
    public virtual void AppendUserProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> userProperties)
    {
    
    }
    public virtual bool get_supportsLeaguesUnlockingAnimation()
    {
        return false;
    }
    public virtual bool get_alwaysForceReviewTracking()
    {
        return false;
    }
    public virtual bool get_supportsPortraitCollection()
    {
        return false;
    }
    public virtual bool get_supportAdsControl()
    {
        return true;
    }
    public virtual bool get_supportAdsControlV2()
    {
        return false;
    }
    public virtual bool get_isWordGame()
    {
        return false;
    }
    public virtual bool get_supportsLeaguesLowPointJoinLock()
    {
        return false;
    }
    public virtual bool get_supportsSilverTicketDisplay()
    {
        return true;
    }
    public virtual bool get_canShowGoldenTicketStoreItem()
    {
        return true;
    }
    public virtual void AppendCommonEventProperties(string eventName, ref System.Collections.Generic.Dictionary<string, object> eventProperties)
    {
    
    }
    public virtual bool AlwaysShowOOCVideoPostStore(bool OOCloop)
    {
        return true;
    }
    public virtual bool get_subscriptionGrantsGems()
    {
        return false;
    }
    public virtual bool get_IsDailyBonusAvailable()
    {
        GameEcon val_2 = App.getGameEcon;
        return (bool)(App.Player >= val_2.dbFtuxLevel) ? 1 : 0;
    }
    public virtual bool get_IsDailyBonusFtuxAvailable()
    {
        GameEcon val_2 = App.getGameEcon;
        return (bool)(App.Player == val_2.dbFtuxLevel) ? 1 : 0;
    }
    public virtual void DoStoreCloseVideoLogic(bool purchased, bool ooc)
    {
        var val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        if(purchased != false)
        {
                return;
        }
        
        if((FOMOPackEventHandler.<Instance>k__BackingField) != null)
        {
                bool val_1 = FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  true);
        }
        
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                val_14 = null;
            val_14 = null;
            MonoSingleton<AdsUIController>.Instance.TryShowPromptVideo(entryPoint:  PurchaseProxy.currentPurchasePoint, showAsFlyout:  false);
            return;
        }
        
        if((MonoSingleton<MinigamesAdsController>.Instance) == 0)
        {
                return;
        }
        
        val_15 = null;
        val_15 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
                return;
        }
        
        if((MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached) == true)
        {
                return;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_16 = null;
        val_16 = null;
        HeyZapAdTag val_11 = AdsUIController.GetTagForPurchasePoint(entryPoint:  PurchaseProxy.currentPurchasePoint);
        val_17 = null;
        val_17 = null;
        string val_12 = AdsUIController.GetFreeCoinsEventForPurchasePoint(entryPoint:  PurchaseProxy.currentPurchasePoint);
        val_18 = null;
        val_18 = null;
        CurrencyRewardType val_13 = AdsUIController.GetCurrencyRewardForPurchasePoint(entryPoint:  PurchaseProxy.currentPurchasePoint);
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_180;
    }
    protected virtual bool get_AdoptNewCurrencySourcePropKey()
    {
        null = null;
        if(App.game <= 21)
        {
                var val_1 = 1;
            val_1 = val_1 << App.game;
            if((val_1 & 2613246) == 0)
        {
                return false;
        }
        
        }
        
        if(App.game == 99)
        {
                return false;
        }
        
        return false;
    }
    public virtual void TrackCreditsSpent(decimal amount, string source, decimal previousBalance, System.Collections.Generic.Dictionary<string, object> extraParams)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_37;
        int val_38;
        string val_39;
        int val_40;
        string val_41;
        MetaGameBehavior val_42;
        var val_43;
        val_38 = previousBalance.lo;
        val_39 = source;
        val_40 = amount.lo;
        if((System.String.op_Equality(a:  val_39, b:  "Not Tracked")) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_37 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  (this != 1) ? "Sink" : "Source", value:  val_39);
        val_40 = "Coins Spent";
        val_2.Add(key:  "Coins Spent", value:  amount);
        Player val_4 = App.Player;
        val_2.Add(key:  "Current Coins", value:  val_4._credits);
        val_2.Add(key:  "Previous Balance", value:  previousBalance);
        val_2.Add(key:  "Current Lvl", value:  this);
        val_41 = "Current Lvl Name";
        val_2.Add(key:  val_41, value:  this);
        if(LightningWordsHandler.DEFAULT_REWARD_VALUE != 0)
        {
                val_41 = "Lightning Words";
            val_2.Add(key:  val_41, value:  LightningWordsHandler.DEFAULT_REWARD_VALUE.IsCoinSpentDuringLightningWord());
        }
        
        if((LightningLevelsEventHandler.<Instance>k__BackingField) != null)
        {
                val_41 = "Lightning Levels";
            val_2.Add(key:  val_41, value:  LightningLevelsEventHandler.<Instance>k__BackingField.IsLightningStrikenLevel());
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_9.<metaGameBehavior>k__BackingField;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_42 & 1) != 0)
        {
                WGDailyChallengeManager val_10 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            val_41 = "Daily Challenge";
            val_2.Add(key:  val_41, value:  val_10.PlayingChallenge);
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_13.<metaGameBehavior>k__BackingField;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_42 & 1) != 0)
        {
                val_41 = "Categories";
            val_2.Add(key:  val_41, value:  CategoryPacksManager.IsPlaying.ToString());
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_17.<metaGameBehavior>k__BackingField;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_42 & 1) != 0)
        {
                if(Alphabet2Manager.IsAvailable != false)
        {
                Alphabet2Manager val_19 = MonoSingleton<Alphabet2Manager>.Instance;
            if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
            object val_37 = ~(System.String.IsNullOrEmpty(value:  val_19.GetCurrentCollectionLetter));
            val_37 = val_37 & 1;
            val_41 = "Alphabet Tile Available ";
            val_2.Add(key:  val_41, value:  val_37);
        }
        
        }
        
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = val_22.<metaGameBehavior>k__BackingField;
        if(val_42 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_42 & 1) != 0)
        {
                val_41 = "Category Level Pack";
            if((System.String.op_Equality(a:  val_39, b:  val_41)) != false)
        {
                if((MonoSingleton<CategoryPacksManager>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
            val_2.Add(key:  "Category Level Pack Purchased", value:  val_24.<PackNewlyPurchased>k__BackingField);
        }
        
        }
        
        if(KeyToRichesEventHandler._Instance != null)
        {
                val_2.Add(key:  "Key Level", value:  KeyToRichesEventHandler._Instance.IsKeyLevel);
        }
        
        if((BingoEventHandler.<Instance>k__BackingField) != null)
        {
                val_2.Add(key:  "Bingo Ball Level", value:  BingoEventHandler.<Instance>k__BackingField.HasMovingItem);
        }
        
        if(SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY != null)
        {
                val_2.Add(key:  "Spin King Level", value:  SpinKingEventHandler.LAST_PROGRESS_STAMP_KEY.isActive);
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY != null)
        {
                val_2.Add(key:  "Word Hunt Words", value:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.IsLevelContainEventWord());
        }
        
        if(extraParams == null)
        {
            goto label_120;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_33 = extraParams.GetEnumerator();
        val_38 = 1152921510222861648;
        label_55:
        if(0.MoveNext() == false)
        {
            goto label_53;
        }
        
        if((val_2.ContainsKey(key:  0)) == true)
        {
            goto label_55;
        }
        
        val_2.Add(key:  0, value:  0);
        goto label_55;
        label_53:
        0.Dispose();
        label_120:
        val_43 = null;
        val_43 = null;
        App.trackerManager.track(eventName:  "Coins Spent", data:  val_2);
    }
    public virtual void TrackGemsSpent(int amount, string source, int previousBalance)
    {
        int val_8;
        int val_9;
        var val_10;
        var val_11;
        val_8 = previousBalance;
        val_9 = amount;
        val_10 = this;
        if((System.String.op_Equality(a:  source, b:  "Not Tracked")) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  (val_10 != 1) ? "Sink" : "Source", value:  source);
        val_9 = "Gems Spent";
        val_2.Add(key:  "Gems Spent", value:  val_9);
        Player val_4 = App.Player;
        val_2.Add(key:  "Current Gems", value:  val_4._gems);
        val_2.Add(key:  "Previous Balance", value:  val_8);
        val_10 = 1152921515418697360;
        if((MonoSingleton<WordGameEventsController>.Instance) != 0)
        {
                MonoSingleton<WordGameEventsController>.Instance.InjectGemSpentTrackingInfo(trackingData: ref  val_2);
        }
        
        val_11 = null;
        val_11 = null;
        App.trackerManager.track(eventName:  "Gems Spent", data:  val_2);
    }
    public virtual void TrackGoldenCurrencySpent(int amount, string source, System.Collections.Generic.Dictionary<string, object> additionalParams)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6;
        string val_7;
        var val_8;
        val_7 = source;
        if((System.String.op_Equality(a:  val_7, b:  "Not Tracked")) == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_6 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  "Amount Spent", value:  amount);
        val_2.Add(key:  "Source", value:  val_7);
        if(additionalParams == null)
        {
            goto label_16;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_3 = additionalParams.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if((val_2.ContainsKey(key:  0)) == true)
        {
            goto label_6;
        }
        
        val_2.Add(key:  0, value:  0);
        goto label_6;
        label_4:
        0.Dispose();
        label_16:
        val_8 = null;
        val_8 = null;
        App.trackerManager.track(eventName:  "Golden Currency Spent", data:  val_2);
    }
    public virtual T ShowUGUIMonolith<T>(bool showNext = False)
    {
        var val_40;
        var val_41;
        UnityEngine.Object val_42;
        var val_43;
        var val_44;
        UnityEngine.Object val_45;
        var val_46;
        var val_47;
        val_40 = __RuntimeMethodHiddenParam;
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_5;
        }
        
        SLC.Minigames.MinigamesWindowManager val_3 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48];
        val_43 = __RuntimeMethodHiddenParam + 48;
        goto label_76;
        label_5:
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_14;
        }
        
        SLC.Social.Leagues.LeaguesWindowManager val_6 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 8];
        val_43 = __RuntimeMethodHiddenParam + 48 + 8;
        goto label_76;
        label_14:
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<GameStoreWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_27;
        }
        
        GameStoreWindowManager val_9 = MonoSingleton<GameStoreWindowManager>.Instance;
        if(val_9.canShowWindows == false)
        {
            goto label_27;
        }
        
        GameStoreWindowManager val_10 = MonoSingleton<GameStoreWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 16];
        val_43 = __RuntimeMethodHiddenParam + 48 + 16;
        goto label_76;
        label_27:
        if((MonoSingleton<TheLibraryUI>.Instance) == 0)
        {
            goto label_45;
        }
        
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<LibraryWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_45;
        }
        
        LibraryWindowManager val_15 = MonoSingleton<LibraryWindowManager>.Instance;
        if(val_15.canShowWindows == false)
        {
            goto label_45;
        }
        
        LibraryWindowManager val_16 = MonoSingleton<LibraryWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 24];
        val_43 = __RuntimeMethodHiddenParam + 48 + 24;
        goto label_76;
        label_45:
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<CategoriesWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_54;
        }
        
        CategoriesWindowManager val_19 = MonoSingleton<CategoriesWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 32];
        val_43 = __RuntimeMethodHiddenParam + 48 + 32;
        goto label_76;
        label_54:
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<WADPetsWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_63;
        }
        
        WADPetsWindowManager val_22 = MonoSingleton<WADPetsWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 40];
        val_43 = __RuntimeMethodHiddenParam + 48 + 40;
        goto label_76;
        label_63:
        val_41 = 1152921504893161472;
        val_42 = MonoSingleton<RaidAttackWindowManager>.Instance;
        if(val_42 == 0)
        {
            goto label_72;
        }
        
        RaidAttackWindowManager val_25 = MonoSingleton<RaidAttackWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 48];
        val_43 = __RuntimeMethodHiddenParam + 48 + 48;
        goto label_76;
        label_72:
        val_44 = 1152921504893161472;
        val_45 = MonoSingleton<WGWindowManager>.Instance;
        if(val_45 == 0)
        {
            goto label_81;
        }
        
        WGWindowManager val_28 = MonoSingleton<WGWindowManager>.Instance;
        val_43 = mem[__RuntimeMethodHiddenParam + 48 + 56];
        val_43 = __RuntimeMethodHiddenParam + 48 + 56;
        label_76:
        bool val_29 = showNext;
        val_40 = ???;
        val_46 = ???;
        val_47 = ???;
        goto __RuntimeMethodHiddenParam + 48 + 56;
        label_81:
        UnityEngine.Debug.LogError(message:  "MetaGameBehavior.ShowUGUIMonolith" + System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_40 + 48 + 64})(System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_40 + 48 + 64})) + " :No Window Manager Available!"(" :No Window Manager Available!"));
        return 0;
    }
    public virtual T ShowUGUIFlyOut<T>()
    {
        var val_8;
        var val_9;
        val_8 = 1152921504893161472;
        if((MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance) != 0)
        {
                SLC.Minigames.MinigamesWindowManager val_3 = MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance;
            val_9 = mem[__RuntimeMethodHiddenParam + 48];
            val_9 = __RuntimeMethodHiddenParam + 48;
        }
        else
        {
                val_8 = 1152921504893161472;
            if((MonoSingleton<SLC.Social.Leagues.LeaguesFlyoutManager>.Instance) != 0)
        {
                SLC.Social.Leagues.LeaguesFlyoutManager val_6 = MonoSingleton<SLC.Social.Leagues.LeaguesFlyoutManager>.Instance;
            val_9 = mem[__RuntimeMethodHiddenParam + 48 + 8];
            val_9 = __RuntimeMethodHiddenParam + 48 + 8;
        }
        else
        {
                WGFlyoutManager val_7 = MonoSingleton<WGFlyoutManager>.Instance;
            val_9 = mem[__RuntimeMethodHiddenParam + 48 + 16];
            val_9 = __RuntimeMethodHiddenParam + 48 + 16;
        }
        
        }
    
    }
    public virtual string GetGoldenAppleNameForGame()
    {
        return "League Points";
    }
    public virtual string GetGoldenAppleNameForGameUpper()
    {
        return "LEAGUE POINTS";
    }
    public virtual void AddSessionEndProperties(ref System.Collections.Generic.Dictionary<string, object> eventProperties)
    {
        TheLibraryLogic.TrackSessionEnd(eventProperties: ref  System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = eventProperties);
    }
    public virtual bool GemsUnlocked()
    {
        return (bool)((ChapterBookLogic.GetCurrentCumulativeChapter(playerLevel:  0)) > 1) ? 1 : 0;
    }
    public virtual bool WADPetsUnlocked()
    {
        if((MonoSingleton<WADPetsManager>.Instance) == 0)
        {
                return false;
        }
        
        return WADPetsManager.IsFeatureUnlocked();
    }
    public virtual UnityEngine.GameObject OpenPauseMenu()
    {
        GameBehavior val_1 = App.getBehavior;
        return val_1.<metaGameBehavior>k__BackingField.gameObject;
    }
    public virtual bool SupportsGoldenMultiplierManager()
    {
        return false;
    }
    public virtual bool CanAccessLimitedTimeBundles()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return false;
        }
        
        if(Alphabet2Manager.IsAvailable == false)
        {
                return false;
        }
        
        GameBehavior val_3 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_590;
    }
    public virtual bool ShouldShowLTBPopup(int levelSincePopup, int Interval)
    {
        return (bool)(levelSincePopup >= Interval) ? 1 : 0;
    }
    public virtual bool LTB_V2()
    {
        return true;
    }
    public string GetCurrentLanguage()
    {
        string val_3 = this;
        if((val_3 & 1) == 0)
        {
                return "en";
        }
        
        val_3 = Localization.GAME_NAME;
        if(val_3 == 0)
        {
                return "en";
        }
        
        if((System.String.IsNullOrEmpty(value:  Localization.GAME_NAME + 80)) == false)
        {
                return "en";
        }
        
        return "en";
    }
    public virtual System.Collections.Generic.List<string> GetSupportedLanguageNames()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "en");
        return val_1;
    }
    public virtual UnityEngine.GameObject OnLeaguesEntryButtonClicked()
    {
        return MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGLeaguesBenefitsWindow>(showNext:  false).gameObject;
    }
    public virtual void ShowAdditionalSceneChangePopups(SceneType scene)
    {
    
    }
    public virtual string LeaguesBenefitsDescription()
    {
        GameBehavior val_1 = App.getBehavior;
        return System.String.Format(format:  "Free Coins each day when earning first {0}", arg0:  val_1.<metaGameBehavior>k__BackingField);
    }
    public virtual System.Collections.Generic.List<string[]> LeagueHints()
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
        val_2[0] = "league_loading_hint_1";
        val_8 = val_2.Length;
        val_2[1] = "Earn Golden Apples by making word streaks";
        val_1.Add(item:  val_2);
        string[] val_3 = new string[2];
        val_9 = val_3.Length;
        val_3[0] = "league_loading_hint_2";
        val_9 = val_3.Length;
        val_3[1] = "The top 2 clubs in a group move up in the League!";
        val_1.Add(item:  val_3);
        string[] val_4 = new string[2];
        val_10 = val_4.Length;
        val_4[0] = "league_loading_hint_3";
        val_10 = val_4.Length;
        val_4[1] = "The bottom 4 clubs in a group move down in the League";
        val_1.Add(item:  val_4);
        string[] val_5 = new string[2];
        val_11 = val_5.Length;
        val_5[0] = "league_loading_hint_4";
        val_11 = val_5.Length;
        val_5[1] = "Increase club level to increase maximum members";
        val_1.Add(item:  val_5);
        string[] val_6 = new string[2];
        val_12 = val_6.Length;
        val_6[0] = "league_loading_hint_5";
        val_12 = val_6.Length;
        val_6[1] = "Join a club to earn rewards each week!";
        val_1.Add(item:  val_6);
        string[] val_7 = new string[2];
        val_13 = val_7.Length;
        val_7[0] = "league_loading_hint_6";
        val_13 = val_7.Length;
        val_7[1] = "Each season lasts for one week";
        val_1.Add(item:  val_7);
        return val_1;
    }
    public virtual bool CanShowLeaguesJoinLeagueButton(SLC.Social.Leagues.Guild CurrentGuild)
    {
        int val_6;
        var val_7;
        val_6 = CurrentGuild;
        if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
        {
                val_6 = CurrentGuild.ServerId;
            SLC.Social.Leagues.Guild val_4 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            var val_5 = (val_6 != val_4.ServerId) ? 1 : 0;
            return (bool)val_7;
        }
        
        val_7 = 1;
        return (bool)val_7;
    }
    public virtual System.Collections.Generic.Dictionary<string, object> FilterSubscriptionDictionary(System.Collections.Generic.Dictionary<string, object> dic)
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)dic;
    }
    public virtual decimal get_PlayerInitialCoins()
    {
        GameEcon val_1 = App.getGameEcon;
        return new System.Decimal() {flags = val_1.InitialPlayerCoins, hi = val_1.InitialPlayerCoins};
    }
    public virtual int get_PlayerInitialGems()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.InitialPlayerGems;
    }
    public virtual int get_PlayerInitialGoldenCurrency()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.InitialPlayerGoldenCurrency;
    }
    public virtual bool get_PiggyBankUsesGems()
    {
        return false;
    }
    public virtual bool get_SuperBundleUsesGems()
    {
        return false;
    }
    public virtual bool get_CanShowUnPauseInterstitial()
    {
        return true;
    }
    public virtual void AppendPurchaseTracking(ref System.Collections.Generic.Dictionary<string, object> tracking, PurchaseModel pm)
    {
    
    }
    public virtual void SetToCreditsStatViewPos(UnityEngine.RectTransform rectTransform)
    {
    
    }
    public virtual void SetToGemsStatViewPos(UnityEngine.RectTransform rectTransform)
    {
    
    }
    public virtual void SetToGoldenStatViewPos(UnityEngine.RectTransform rectTransform)
    {
    
    }
    public virtual void SetToSpinsStatViewPos(UnityEngine.RectTransform rectTransform)
    {
    
    }
    public virtual void ShowDailyBonusPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WGDailyBonusPopup MetaGameBehavior::ShowUGUIMonolith<WGDailyBonusPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public virtual string GetDailyBonusNotificationTitle()
    {
        return "DAILY BONUS IS READY";
    }
    public virtual string GetDailyBonusNotificationMessage()
    {
        return "Your Free Coins are ready to be collected! Log in now!";
    }
    public virtual string GetSpecialCurrencyLocalizationKey()
    {
        return "golden_apples_meta";
    }
    public virtual string GetCoinStoreBannerText()
    {
        return Localization.Localize(key:  "coin_deals_upper", defaultValue:  "COIN DEALS", useSingularKey:  false);
    }
    public virtual void OnLevelAwarded()
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public virtual float get_WindowManagerBackgroundAlpha()
    {
        return 0.745f;
    }
    public virtual int get_PickerHintUnlockLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintPickerUnlockLevel;
    }
    public virtual int get_PickerHintTutorialLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintPickerTutorialLevel;
    }
    public virtual bool get_ShowV2PickerHintTutorial()
    {
        return false;
    }
    public virtual bool get_ShowV2HintTutorial()
    {
        return false;
    }
    public virtual int get_HintTutorialLevel()
    {
        GameEcon val_1 = App.getGameEcon;
        return (int)val_1.hintTutorialLevel;
    }
    public virtual bool get_SupportsFreeHints()
    {
        return true;
    }
    public virtual bool get_InNormalGameMode()
    {
        UnityEngine.Object val_8;
        var val_9;
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_3;
        }
        
        val_8 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_8 == 0)
        {
                val_9 = 1;
            return (bool)val_9 & 1;
        }
        
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_12;
        }
        
        label_3:
        val_9 = 0;
        return (bool)val_9 & 1;
        label_12:
        bool val_8 = (MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) ^ 1;
        return (bool)val_9 & 1;
    }
    public virtual bool get_SkipTutorialEligible()
    {
        return true;
    }
    public virtual void InjectGameSpecificGlobals(ref System.Collections.Generic.Dictionary<string, object> globals)
    {
    
    }
    public virtual void InjectAdditionalLevelStartTrackings(ref System.Collections.Generic.Dictionary<string, object> eventData)
    {
    
    }
    public virtual void ShowGameSpecificPopup()
    {
    
    }
    public virtual void TrackAdditionalNonCoinAwardParams(System.Collections.Generic.Dictionary<string, object> data)
    {
    
    }
    public virtual bool get_ExtraWordGameplayUpdate()
    {
        return false;
    }
    public virtual int get_WordStreakStartCount()
    {
        return 2;
    }
    public virtual bool get_SupportsNonAlphabeticalOrder()
    {
        return false;
    }
    public virtual string get_BannerPlacement()
    {
        return "BOTTOM";
    }
    public MetaGameBehavior()
    {
    
    }

}

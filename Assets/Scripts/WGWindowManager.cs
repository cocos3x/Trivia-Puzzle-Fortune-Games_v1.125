using UnityEngine;
public class WGWindowManager : SLCWindowManager<WGWindowManager>
{
    // Fields
    private UnityEngine.Coroutine waitingForGeneration;
    
    // Properties
    protected override System.Type myWindowType { get; }
    private bool surpressPopups { get; }
    
    // Methods
    protected override System.Type get_myWindowType()
    {
        return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
    }
    private bool get_surpressPopups()
    {
        return false;
    }
    public override void InitMonoSingleton()
    {
        var val_8;
        var val_9;
        this.InitMonoSingleton();
        val_8 = null;
        val_8 = null;
        SLCWindowManager<T>.color_show_available_popups.__il2cppRuntimeField_10 = this.transform.GetComponentInChildren<UnityEngine.Camera>();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnFacebookPluginUpdate");
        val_9 = null;
        val_9 = null;
        WordApp.DeferredGameUIReadyEvent.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGWindowManager::OnWordAppUIReady()));
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGWindowManager::OnScreenChanged(SceneType type)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_5.OnSceneLoaded = val_7;
        return;
        label_14:
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        this.HandleApplicationPause(paused:  pauseStatus);
    }
    private void OnApplicationFocus(bool focus)
    {
        focus = (~focus) & 1;
        this.HandleApplicationPause(paused:  focus);
    }
    private void HandleApplicationPause(bool paused)
    {
        var val_1;
        if(paused == true)
        {
                return;
        }
        
        val_1 = null;
        val_1 = null;
        if(TrackingComponent.lastIntent != 0)
        {
                return;
        }
        
        this.ShowAvailablePopups(fromMinimize:  true, entry:  "OnApplicationFocus");
    }
    private void OnWordAppUIReady()
    {
        this.ShowAvailablePopups(fromMinimize:  false, entry:  "OnWordAppUIReady");
    }
    private void OnFacebookPluginUpdate()
    {
    
    }
    private void OnScreenChanged(SceneType type)
    {
        if(this.waitingForGeneration != null)
        {
                this.StopCoroutine(routine:  this.waitingForGeneration);
            this.waitingForGeneration = 0;
        }
        
        if(WordRegion.instance != 0)
        {
                WordRegion.instance.addOnLevelLoadCompleteAction(callback:  new System.Action(object:  this, method:  System.Void WGWindowManager::onWordRegionLoaded()));
            return;
        }
        
        if(type == 2)
        {
                GameBehavior val_5 = App.getBehavior;
            if(((val_5.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                this.waitingForGeneration = this.StartCoroutine(routine:  this.WaitingForGeneration());
            return;
        }
        
        }
        
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        this.ShowAvailablePopups(fromMinimize:  false, entry:  "OnScreenChanged");
    }
    private System.Collections.IEnumerator WaitingForGeneration()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGWindowManager.<WaitingForGeneration>d__12();
    }
    private void onWordRegionLoaded()
    {
        this.ShowAvailablePopups(fromMinimize:  false, entry:  "OnScreenChanged");
    }
    public void ShowAvailablePopups(bool fromMinimize = False, string entry = "")
    {
        object val_169;
        var val_170;
        var val_171;
        var val_172;
        var val_173;
        var val_174;
        UnityEngine.Object val_175;
        var val_176;
        var val_177;
        System.Action val_179;
        var val_180;
        var val_181;
        var val_182;
        val_169 = entry;
        val_171 = null;
        val_171 = null;
        if(WordApp.deferredEventHasFired == false)
        {
                return;
        }
        
        this.AddOp(info:  System.String.Format(format:  "WindowManager: Show Available Popups ... ({0})", arg0:  val_169), hexColor:  "#99BBCC");
        val_170 = 1152921504884269056;
        Player val_2 = App.Player;
        if(val_2.properties.ShouldShowGdprConsent() != false)
        {
                WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGUserConsentPopup>(showNext:  false);
        }
        
        if((MonoSingleton<WGNotificationPromptManager>.Instance) != 0)
        {
                if((MonoSingleton<WGNotificationPromptManager>.Instance.ShouldShowNotif()) != false)
        {
                WGWindowManager val_11 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGPushNotificationPrompt>(showNext:  false);
        }
        
        }
        
        GameBehavior val_12 = App.getBehavior;
        if(((val_12.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                GameBehavior val_13 = App.getBehavior;
            GameEcon val_14 = App.getGameEcon;
            if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_13.<metaGameBehavior>k__BackingField, knobValue:  val_14.storyPopupLevel)) != false)
        {
                Player val_16 = App.Player;
            if((System.String.op_Equality(a:  val_16.properties.story_mode_vote, b:  "None")) != false)
        {
                WGWindowManager val_19 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoryModePopup>(showNext:  false);
        }
        
        }
        
        }
        
        if(((MonoSingleton<WGDailyBonusManager>.Instance) != 0) && ((MonoSingleton<WGDailyBonusManager>.Instance.CheckAvailable()) != false))
        {
                GameBehavior val_24 = App.getBehavior;
            if(((val_24.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                MonoSingleton<WGDailyBonusManager>.Instance.TryShowDailyBonus();
        }
        
        }
        
        val_172 = 1152921515677572976;
        if((MonoSingleton<TournamentsManager>.Instance) != 0)
        {
                GameBehavior val_28 = App.getBehavior;
            if(((val_28.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                bool val_30 = MonoSingleton<TournamentsManager>.Instance.ShowTournamentResults();
        }
        
        }
        
        GameBehavior val_31 = App.getBehavior;
        if(((val_31.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_172 = 1152921516187096944;
            if((MonoSingleton<DailyChallengeTutorialManager>.Instance) != 0)
        {
                if(SceneDictator.IsInGameScene() == false)
        {
            goto label_90;
        }
        
        }
        
        }
        
        GameBehavior val_35 = App.getBehavior;
        if((((val_35.<metaGameBehavior>k__BackingField) & 1) != 0) && (SceneDictator.IsInGameScene() != false))
        {
                DailyChallengeTutorialManager val_37 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
            if(val_37._TutorialActive != false)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                MonoSingleton<DailyChallengeTutorialManager>.Instance.ShowGameplayTutorial();
            return;
        }
        
        }
        
        }
        
        if((MonoSingleton<WGSubscriptionManager>.Instance) != 0)
        {
                if((MonoSingleton<WGSubscriptionManager>.Instance.canCollectSubscription(subPackage:  0)) != true)
        {
                if((MonoSingleton<WGSubscriptionManager>.Instance.canCollectSubscription(subPackage:  1)) == false)
        {
            goto label_122;
        }
        
        }
        
            WGWindowManager val_48 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGSubscriptionPopup>(showNext:  false);
        }
        
        label_122:
        val_173 = 1152921504979849216;
        if(((SceneDictator.IsInGameScene() == false) || (Alphabet2Manager.IsAvailable == false)) || ((MonoSingleton<Alphabet2Manager>.Instance.canAddGameplayTile) == false))
        {
            goto label_150;
        }
        
        if((MonoSingleton<Alphabet2Manager>.Instance.IsCollectionBoxFull()) == false)
        {
            goto label_139;
        }
        
        WGWindowManager val_56 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionBoxPopup>(showNext:  false);
        goto label_150;
        label_90:
        MonoSingleton<DailyChallengeTutorialManager>.Instance.TryShowLobbyTutorial();
        return;
        label_139:
        if((MonoSingleton<Alphabet2Manager>.Instance.ShouldShowFTUX()) != false)
        {
                WGWindowManager val_61 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionFlyout>(showNext:  false);
            mem2[0] = 0;
        }
        
        label_150:
        if((MonoSingleton<WGReviewManager>.Instance) != 0)
        {
                if((MonoSingleton<WGReviewManager>.Instance.CheckAvailable()) != false)
        {
                WGWindowManager val_67 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGReviewPopup>(showNext:  false);
        }
        
        }
        
        if(WGInviteManager.CanShowFTUX() != false)
        {
                MonoSingleton<WGInviteManager>.Instance.ShowFTUX();
        }
        else
        {
                if(WGInviteManager.RewardAvailable != false)
        {
                WGInvite val_71 = WGInviteManager.ShowInvitePopup(status:  2);
        }
        
        }
        
        if((MonoSingleton<RestoreProgressManager>.Instance) != 0)
        {
                GameBehavior val_74 = App.getBehavior;
            if(((val_74.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if(RestoreProgressManager.HasPreviousProgression != false)
        {
                WGWindowManager val_77 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGRestoreProgressionPopup>(showNext:  false);
        }
        else
        {
                if((MonoSingleton<RestoreProgressManager>.Instance.ShouldShowReminder()) != false)
        {
                MonoSingleton<RestoreProgressManager>.Instance.ShowSignInReminder();
        }
        
        }
        
        }
        
        }
        
        GameBehavior val_81 = App.getBehavior;
        if(fromMinimize != true)
        {
                GameBehavior val_82 = App.getBehavior;
            if(((val_82.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if(SceneDictator.IsInGameScene() != false)
        {
                val_174 = 0;
            MonoSingleton<WordGameEventsController>.Instance.OnGameSceneBegan();
        }
        else
        {
                val_174 = 0;
            MonoSingleton<WordGameEventsController>.Instance.OnMenuLoaded();
        }
        
        }
        
        }
        
        GameEcon val_87 = App.getGameEcon;
        if((((App.Player == val_87.starterPackLevel) && ((MonoSingleton<WGStarterPackController>.Instance) != 0)) && (SceneDictator.IsInGameScene() != false)) && (WGStarterPackController.featureRelavent != false))
        {
                val_169 = MonoSingleton<WGStarterPackController>.Instance.TryShowPopup();
        }
        else
        {
                val_169 = 0;
        }
        
        if(((((FOMOPackEventHandler.<Instance>k__BackingField) != null) && (SceneDictator.IsInGameScene() != false)) && ((FOMOPackEventHandler.<Instance>k__BackingField.AvailableShow) != false)) && ((FOMOPackEventHandler.<Instance>k__BackingField.CanLevelShow) != false))
        {
                if((FOMOPackEventHandler.<Instance>k__BackingField.TryShowPopup(isOOC:  false)) != false)
        {
                FOMOPackEventHandler.<Instance>k__BackingField.SetShowedLevel();
            val_169 = 1;
        }
        
        }
        
        if((MonoSingleton<WGWaterfallSaleManager>.Instance) != 0)
        {
                if((MonoSingleton<WGWaterfallSaleManager>.Instance.CanDisplayWaterfallSale(oocFlow:  false)) != false)
        {
                MonoSingleton<WGWaterfallSaleManager>.Instance.ShowPopup(oocFlow:  false, storeCloseCallback:  0);
            val_169 = 1;
        }
        
        }
        
        if((MonoSingleton<WGFTUXManager>.Instance) != 0)
        {
                if((MonoSingleton<WGFTUXManager>.Instance.CheckAvailable()) != false)
        {
                MonoSingleton<WGFTUXManager>.Instance.ShowAdvancedPlayerPopup();
            return;
        }
        
        }
        
        if((MonoSingleton<GameOfTheDay>.Instance) != 0)
        {
                GameBehavior val_110 = App.getBehavior;
            if(((val_110.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                if((MonoSingleton<GameOfTheDay>.Instance.isAvailableAndMustShow) != false)
        {
                WGWindowManager val_114 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<GameOfTheDayWindowUGUI>(showNext:  false);
        }
        
        }
        
        }
        
        val_175 = 0;
        if((MonoSingleton<WGEmailCollectManager>.Instance) != val_175)
        {
                val_175 = 0;
            if((MonoSingleton<WGEmailCollectManager>.Instance.CheckAvailable()) != false)
        {
                val_175 = 0;
            WGWindowManager val_120 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGEmailCollectPopup>(showNext:  false);
        }
        
        }
        
        if(fromMinimize != true)
        {
                GameBehavior val_121 = App.getBehavior;
            if(((val_121.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                if((val_121.<gameplayBehavior>k__BackingField.ShowHintTutorial()) != false)
        {
                return;
        }
        
        }
        
        }
        
        if((MonoSingleton<WGInviteManager>.Instance) != 0)
        {
                MonoSingleton<WGInviteManager>.Instance.ShowRecommendPopupWhenReady();
        }
        
        if((MonoSingleton<MysteryGiftManager>.Instance) != 0)
        {
                if(SceneDictator.IsInGameScene() != false)
        {
                MonoSingleton<MysteryGiftManager>.Instance.OnSceneChange();
        }
        
        }
        
        if((MonoSingleton<AdsUIController>.Instance) != 0)
        {
                if((MonoSingleton<AdsUIController>.Instance.CanShowFreeHintPopup()) != false)
        {
                val_176 = null;
            val_176 = null;
            WGFreeHintPopup.dailyCollected = false;
            WGWindowManager val_135 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGFreeHintPopup>(showNext:  false);
        }
        
        }
        
        if(((MonoSingleton<AdsUIController>.Instance) != 0) && ((MonoSingleton<AdsUIController>.Instance.CanShowAdsControlPopup(adWaterfallOn:  false)) != false))
        {
                WGAdsControlPopup val_142 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAdsControlPopup>(showNext:  false).InitEntryTag(tag:  1);
            val_177 = null;
            val_177 = null;
            val_179 = WGWindowManager.<>c.<>9__14_0;
            if(val_179 == null)
        {
                System.Action val_143 = null;
            val_179 = val_143;
            val_143 = new System.Action(object:  WGWindowManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGWindowManager.<>c::<ShowAvailablePopups>b__14_0());
            WGWindowManager.<>c.<>9__14_0 = val_179;
        }
        
            val_142.Action_OnClose = val_179;
        }
        else
        {
                if(((val_169 & 1) == 0) && ((MonoSingleton<LimitedTimeBundlesManager>.Instance) != 0))
        {
                if((MonoSingleton<LimitedTimeBundlesManager>.Instance.ShouldShowBundlesPopup()) != false)
        {
                WGWindowManager val_149 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<LimitedTimeBundlesPopup>(showNext:  false);
        }
        
        }
        
        }
        
        if(SceneDictator.IsInGameScene() == false)
        {
            goto label_401;
        }
        
        GameBehavior val_151 = App.getBehavior;
        if((((val_151.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingletonSelfGenerating<WGChallengeController>.Instance) == 0))
        {
            goto label_401;
        }
        
        val_173 = 1152921504893161472;
        if((MonoSingleton<DifficultySettingManager>.Instance) == 0)
        {
            goto label_395;
        }
        
        DifficultySettingManager val_156 = MonoSingleton<DifficultySettingManager>.Instance;
        if((val_156.<Setting>k__BackingField.FeatureStatus.IsFtuxLevel) == true)
        {
            goto label_401;
        }
        
        label_395:
        MonoSingletonSelfGenerating<WGChallengeController>.Instance.CheckSceneLoading();
        label_401:
        val_180 = 1152921504893161472;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance) != 0)
        {
                MonoSingleton<TRVQuestionOfTheDayManager>.Instance.CheckQOTD();
        }
        
        if((MonoSingleton<WordForest.RaidAttackManager>.Instance) != 0)
        {
                val_180 = 1152921504999550976;
            val_181 = null;
            val_181 = null;
            if(WordForest.RaidAttackManager.queueNewsPopup != true)
        {
                if(WordForest.WFONewsPopup.UnseenNewsCount < 1)
        {
            goto label_421;
        }
        
        }
        
            GameBehavior val_164 = App.getBehavior;
            val_182 = null;
            val_182 = null;
            WordForest.RaidAttackManager.queueNewsPopup = false;
        }
        
        label_421:
        GameBehavior val_166 = App.getBehavior;
        GameBehavior val_167 = App.getBehavior;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "DoneQueuingAvailablePopups");
    }
    private bool ShowHintTutorial()
    {
        string val_69;
        UnityEngine.Object val_70;
        var val_71;
        var val_72;
        System.Action val_74;
        var val_75;
        var val_76;
        var val_77;
        var val_79;
        val_69 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((((val_1.<gameplayBehavior>k__BackingField) & 1) == 0) || (WGHintButtonDemoPopup.CheckAvailable() == false))
        {
            goto label_8;
        }
        
        GameBehavior val_3 = App.getBehavior;
        if(((val_3.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_13;
        }
        
        GameBehavior val_4 = App.getBehavior;
        val_70 = val_4.<metaGameBehavior>k__BackingField;
        GameBehavior val_5 = App.getBehavior;
        if(val_70 != (val_5.<metaGameBehavior>k__BackingField))
        {
            goto label_152;
        }
        
        GameBehavior val_6 = App.getBehavior;
        val_70 = val_6.<metaGameBehavior>k__BackingField;
        val_69 = Localization.Localize(key:  "gotit_upper", defaultValue:  "GOT IT", useSingularKey:  false);
        System.Collections.Generic.List<UnityEngine.GameObject> val_10 = new System.Collections.Generic.List<UnityEngine.GameObject>();
        val_71 = 1152921513404137360;
        val_10.Add(item:  MonoSingleton<AdsUIController>.Instance.HintButtonGroup);
        label_161:
        val_10.Add(item:  MonoSingleton<AdsUIController>.Instance.ShuffleButtonGroup);
        val_70.Setup(description:  Localization.Localize(key:  "interaction_ftux_shufflehint", defaultValue:  "If you get stuck, try tapping the shuffle or hint button", useSingularKey:  false), buttonText:  val_69, featureTargets:  val_10);
        goto label_118;
        label_8:
        GameBehavior val_15 = App.getBehavior;
        if(((val_15.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_50;
        }
        
        GameBehavior val_16 = App.getBehavior;
        if(((val_16.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_50;
        }
        
        GameBehavior val_17 = App.getBehavior;
        GameEcon val_18 = App.getGameEcon;
        if(((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_17.<metaGameBehavior>k__BackingField, knobValue:  val_18.hintMEGATutorialLevel)) == false) || (Prefs.HasUsedHintMega == true))
        {
            goto label_50;
        }
        
        GameBehavior val_21 = App.getBehavior;
        if(((val_21.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_55;
        }
        
        label_50:
        GameBehavior val_22 = App.getBehavior;
        if(((val_22.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_177;
        }
        
        GameBehavior val_23 = App.getBehavior;
        if(((val_23.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_177;
        }
        
        GameBehavior val_24 = App.getBehavior;
        GameBehavior val_25 = App.getBehavior;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_24.<metaGameBehavior>k__BackingField, knobValue:  val_25.<metaGameBehavior>k__BackingField)) == false)
        {
            goto label_74;
        }
        
        GameBehavior val_27 = App.getBehavior;
        GameBehavior val_28 = App.getBehavior;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_27.<metaGameBehavior>k__BackingField, knobValue:  val_28.<metaGameBehavior>k__BackingField)) == true)
        {
            goto label_83;
        }
        
        label_74:
        if((WADPetsManager.GetUnlockedPetByAbility(ability:  1)) == false)
        {
            goto label_177;
        }
        
        label_83:
        if(Prefs.HasUsedHintPicker == true)
        {
            goto label_177;
        }
        
        GameBehavior val_32 = App.getBehavior;
        if(((val_32.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
            goto label_90;
        }
        
        label_177:
        val_71 = 1152921515418697360;
        val_70 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_70 != 0)
        {
                GameBehavior val_35 = App.getBehavior;
            if(((val_35.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                GameBehavior val_36 = App.getBehavior;
            if(((val_36.<gameplayBehavior>k__BackingField) & 1) == 0)
        {
                if((MonoSingleton<WordGameEventsController>.Instance.TryShowFtux()) == true)
        {
            goto label_118;
        }
        
        }
        
        }
        
        }
        
        val_69 = 1152921504893161472;
        val_70 = MonoSingleton<WADPetsManager>.Instance;
        if(val_70 != 0)
        {
                if((MonoSingleton<WADPetsManager>.Instance.CheckFTUX()) == true)
        {
            goto label_118;
        }
        
        }
        
        val_69 = 1152921504893161472;
        val_70 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        if((val_70 == 0) || (SceneDictator.IsInGameScene() == false))
        {
            goto label_152;
        }
        
        return MonoSingleton<WordForest.WFOManagerGameplay>.Instance.CheckAndShowForestPopup();
        label_13:
        val_70 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHintButtonDemoPopup>(showNext:  false).GetComponent<SLCWindow>();
        val_72 = null;
        val_72 = null;
        val_74 = WGWindowManager.<>c.<>9__15_0;
        if(val_74 == null)
        {
                System.Action val_50 = null;
            val_74 = val_50;
            val_50 = new System.Action(object:  WGWindowManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGWindowManager.<>c::<ShowHintTutorial>b__15_0());
            WGWindowManager.<>c.<>9__15_0 = val_74;
        }
        
        label_187:
        val_49.Action_OnClose = val_74;
        label_118:
        val_75 = 1;
        return (bool)val_75;
        label_90:
        GameBehavior val_51 = App.getBehavior;
        if(((val_51.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_145;
        }
        
        GameBehavior val_52 = App.getBehavior;
        val_70 = val_52.<metaGameBehavior>k__BackingField;
        GameBehavior val_53 = App.getBehavior;
        if(val_70 != (val_53.<metaGameBehavior>k__BackingField))
        {
            goto label_152;
        }
        
        GameBehavior val_54 = App.getBehavior;
        string val_56 = Localization.Localize(key:  "interaction_ftux_pick", defaultValue:  "PICK lets you choose which letter to reveal!", useSingularKey:  false);
        string val_57 = Localization.Localize(key:  "gotit_upper", defaultValue:  "GOT IT", useSingularKey:  false);
        System.Collections.Generic.List<UnityEngine.GameObject> val_58 = new System.Collections.Generic.List<UnityEngine.GameObject>();
        HintPickerController val_59 = MonoSingleton<HintPickerController>.Instance;
        goto label_161;
        label_152:
        val_75 = 0;
        return (bool)val_75;
        label_55:
        val_76 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHintMegaDemoPopup>(showNext:  false).GetComponent<SLCWindow>();
        val_77 = null;
        val_77 = null;
        if((WGWindowManager.<>c.<>9__15_1) != null)
        {
            goto label_184;
        }
        
        WGWindowManager.<>c.<>9__15_1 = new System.Action(object:  WGWindowManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGWindowManager.<>c::<ShowHintTutorial>b__15_1());
        if(val_76 != null)
        {
            goto label_187;
        }
        
        label_145:
        GameBehavior val_64 = App.getBehavior;
        if(((val_64.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
            goto label_177;
        }
        
        val_76 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGHintPickerDemoPopup>(showNext:  false).GetComponent<SLCWindow>();
        val_79 = null;
        val_79 = null;
        if((WGWindowManager.<>c.<>9__15_2) == null)
        {
                WGWindowManager.<>c.<>9__15_2 = new System.Action(object:  WGWindowManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGWindowManager.<>c::<ShowHintTutorial>b__15_2());
        }
        
        label_184:
        if(val_76 != null)
        {
            goto label_187;
        }
        
        throw new NullReferenceException();
    }
    protected override void WindowStateChanged(bool anyActiveOrQueuedWindows)
    {
        if((MonoSingleton<WordGameEventsController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WordGameEventsController>.Instance.OnWindowStateChanged(anyActiveWindows:  anyActiveOrQueuedWindows);
    }
    private void OnDestroy()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingletonSelfGenerating<SceneDictator>.Instance)) == false)
        {
                return;
        }
        
        SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        1152921504893267968 = val_3.OnSceneLoaded;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893267968, value:  new System.Action<SceneType>(object:  this, method:  System.Void WGWindowManager::OnScreenChanged(SceneType type)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.OnSceneLoaded = val_5;
        return;
        label_10:
    }
    public static UnityEngine.Camera GetCameraByTransform(UnityEngine.Transform obTranform)
    {
        return obTranform.GetComponentInParent<UnityEngine.Camera>();
    }
    public static UnityEngine.Vector3 GetWorldPosInSelCamera(UnityEngine.Transform selfTransform, UnityEngine.Transform targetTransform)
    {
        UnityEngine.Vector3 val_3 = targetTransform.position;
        UnityEngine.Vector3 val_4 = WGWindowManager.GetCameraByTransform(obTranform:  targetTransform).WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        return WGWindowManager.GetCameraByTransform(obTranform:  selfTransform).ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    public WGWindowManager()
    {
    
    }

}

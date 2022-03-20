using UnityEngine;
public class TRVQuestionComplete : MonoBehaviour
{
    // Fields
    public static int lastLevelShownAnim;
    private UnityEngine.UI.Button nextQuestionButton;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button gemButton;
    private UnityEngine.UI.Button freeCoinButton;
    private UnityEngine.UI.Button buyExtraLifeButton;
    private UnityEngine.UI.Button endQuizButton;
    private UnityEngine.UI.Button howToPlayButton;
    private UnityEngine.UI.Button removeAdsButton;
    private UnityEngine.UI.Button expertsButton;
    private TournamentsButton tournamentsButton;
    private UnityEngine.UI.Text playButtonText;
    private UnityEngine.UI.Text levelProgressText;
    private UnityEngine.UI.Text extraLifeCostText;
    private System.Collections.Generic.List<TRVQuizProgressIcon> progressIcons;
    private TRVExtraLifeButton extraLifeButton;
    private UnityEngine.Transform quizProgressParent;
    private UnityEngine.Transform quizLevelDisplay;
    private TRVQuizProgressIcon progressIconPrefab;
    private UnityEngine.UI.VerticalLayoutGroup parentLayoutGroup;
    private UnityEngine.ParticleSystem quizCompleteParticle;
    private SLC.Social.Leagues.LeaguesEntryButton entryButton;
    private UnityEngine.UI.Image chestImage;
    private UnityEngine.Sprite bronzeChest;
    private UnityEngine.Sprite silverChest;
    private UnityEngine.Sprite goldenChest;
    private UnityEngine.UI.Text coinRewardText;
    private UnityEngine.GameObject upgradeArrow;
    private UnityEngine.GameObject threeQuestionSpacing;
    
    // Methods
    private void OnEnable()
    {
        var val_29;
        var val_30;
        System.Action val_32;
        System.Delegate val_33;
        this.nextQuestionButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClick()));
        this.endQuizButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClick()));
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickCoinBalance()));
        this.gemButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickGemBalance()));
        if(this.tournamentsButton != 0)
        {
                System.Delegate val_7 = System.Delegate.Combine(a:  this.tournamentsButton.ExternalClickCallback, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void TRVQuestionComplete::OnTournamentsClicked(bool isConnected)));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_43;
        }
        
        }
        
            this.tournamentsButton.ExternalClickCallback = val_7;
        }
        
        this.Setup();
        MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this).alpha = 0f;
        UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.redraw());
        val_29 = null;
        twelvegigs.Autopilot.AutopilotManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
        GameEcon val_13 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_13.leaguesUnlockLevel)) != false)
        {
                this.entryButton.onLeaguesEntryAction = new System.Action(object:  this, method:  System.Void TRVQuestionComplete::<OnEnable>b__29_0());
            val_30 = null;
            val_30 = null;
            val_32 = TRVQuestionComplete.<>c.<>9__29_1;
            if(val_32 == null)
        {
                System.Action val_16 = null;
            val_32 = val_16;
            val_16 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnEnable>b__29_1());
            TRVQuestionComplete.<>c.<>9__29_1 = val_32;
        }
        
            this.entryButton.onExitLeaguesAction = val_32;
        }
        
        System.Action<System.Boolean> val_18 = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVQuestionComplete::RedrawExtraLife(bool available));
        val_33 = val_18;
        System.Delegate val_19 = System.Delegate.Combine(a:  this.extraLifeButton.ExtraLifeStateChange, b:  val_18);
        if(val_19 == null)
        {
            goto label_42;
        }
        
        val_33 = null;
        if(null != val_33)
        {
            goto label_43;
        }
        
        label_42:
        this.extraLifeButton.ExtraLifeStateChange = val_19;
        TRVEcon val_21 = App.GetGameSpecificEcon<TRVEcon>();
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  App.Player, knobValue:  val_21.expertsUnlockLevel)) != false)
        {
                this.upgradeArrow.gameObject.SetActive(value:  MonoSingleton<TRVExpertsController>.Instance.AnyExpertReadyToUpgrade());
            this.expertsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickExpertsButton()));
            return;
        }
        
        this.expertsButton.gameObject.SetActive(value:  false);
        return;
        label_43:
    }
    public void Setup()
    {
        var val_60;
        var val_61;
        UnityEngine.UI.Text val_62;
        bool val_64;
        UnityEngine.UI.Text val_65;
        string val_66;
        string val_67;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        this.SetChestSprite();
        if((val_1.currentGame.quizCompleted == false) || (val_1.currentGame.successfullyCompletedQuiz == false))
        {
            goto label_6;
        }
        
        val_60 = null;
        val_60 = null;
        if(TRVQuestionComplete.lastLevelShownAnim == App.Player)
        {
            goto label_126;
        }
        
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.sound.PlayGeneralSound(type:  0, oneshot:  true, pitch:  1f, vol:  1f);
        this.quizCompleteParticle.Play();
        val_61 = null;
        val_61 = null;
        TRVQuestionComplete.lastLevelShownAnim = App.Player;
        goto label_126;
        label_6:
        if((MonoSingleton<TRVMainController>.Instance.IsPlayingChallenge) == false)
        {
            goto label_28;
        }
        
        val_62 = this.levelProgressText;
        string val_9 = System.String.Format(format:  "{0}{1}CHALLENGE", arg0:  val_1.currentGame.quizCategory, arg1:  System.Environment.NewLine);
        if(val_62 != null)
        {
            goto label_29;
        }
        
        label_28:
        val_62 = this.levelProgressText;
        string val_12 = System.String.Format(format:  "{0}{1}{2}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "LEVEL", useSingularKey:  false), arg1:  System.Environment.NewLine, arg2:  val_1.currentGame.quizLevel);
        label_29:
        label_126:
        TRVEcon val_13 = App.GetGameSpecificEcon<TRVEcon>();
        string val_15 = val_1.currentGame.GetQuizBaseReward().ToString();
        this.PopulateQuizProgressIcons();
        this.InformQuizProgressIcons();
        this.extraLifeButton.gameObject.SetActive(value:  true);
        this.freeCoinButton.gameObject.SetActive(value:  MonoSingletonSelfGenerating<AdsManager>.Instance.VideoEnabledAndUnlocked());
        this.buyExtraLifeButton.gameObject.SetActive(value:  false);
        this.endQuizButton.gameObject.SetActive(value:  false);
        this.nextQuestionButton.gameObject.SetActive(value:  false);
        this.removeAdsButton.gameObject.SetActive(value:  false);
        if(val_1.currentGame.previousQuestions == null)
        {
            goto label_56;
        }
        
        WGAudioController val_25 = MonoSingleton<WGAudioController>.Instance;
        if(val_25.music.IsPlaying() != true)
        {
                WGAudioController val_27 = MonoSingleton<WGAudioController>.Instance;
            val_27.music.Play(type:  1, trackIndex:  0);
        }
        
        System.Collections.Generic.List<TRVQuestionHistory> val_30 = val_1.currentGame.countedAnswerData;
        val_64 = val_1.currentGame.quizCompleted;
        if(val_64 == false)
        {
            goto label_70;
        }
        
        if(val_1.currentGame.countedAnswers >= val_1.currentGame.correctAnswerRequirement)
        {
            goto label_71;
        }
        
        val_64 = val_1.currentGame.quizCompleted;
        label_70:
        if(((val_1.currentGame.correctAnswerRequirement - val_1.currentGame.countedAnswers) <= ((MonoSingleton<TRVMainController>.Instance.getQuizLength) - W27)) || (val_64 == true))
        {
            goto label_73;
        }
        
        if(val_64 != true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_64 = val_64 + ((val_64 - 1) << 3);
        if(((val_1.currentGame.quizCompleted + ((val_1.currentGame.quizCompleted - 1)) << 3) + 32.extraLifeUsed) == false)
        {
            goto label_77;
        }
        
        label_73:
        val_65 = this.playButtonText;
        val_66 = "next_question_upper";
        val_67 = "NEXT QUESTION";
        goto label_78;
        label_56:
        val_65 = this.playButtonText;
        val_66 = "start_quiz_upper";
        val_67 = "START QUIZ";
        label_78:
        string val_37 = Localization.Localize(key:  val_66, defaultValue:  val_67, useSingularKey:  false);
        label_122:
        label_118:
        this.nextQuestionButton.gameObject.SetActive(value:  true);
        this.freeCoinButton.m_OnClick.RemoveAllListeners();
        this.freeCoinButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickWatchVideo()));
        this.extraLifeButton.onClick.RemoveAllListeners();
        this.extraLifeButton.onClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickExtraLife()));
        this.howToPlayButton.m_OnClick.RemoveAllListeners();
        this.howToPlayButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickHowToPlay()));
        this.removeAdsButton.m_OnClick.RemoveAllListeners();
        this.removeAdsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVQuestionComplete::OnClickRemoveAds()));
        this.extraLifeCostText.gameObject.SetActive(value:  (~(MonoSingleton<TRVMainController>.Instance.freeLifeAvailable)) & 1);
        TRVEcon val_49 = App.GetGameSpecificEcon<TRVEcon>();
        string val_50 = val_49.extraLifeCost.ToString();
        this.SetupRemoveAdsButton();
        if(this.threeQuestionSpacing == 0)
        {
                return;
        }
        
        this.threeQuestionSpacing.SetActive(value:  (val_1.currentGame.quizLength == 3) ? 1 : 0);
        return;
        label_71:
        string val_53 = Localization.Localize(key:  "you_win!_upper", defaultValue:  "YOU WIN!", useSingularKey:  false);
        this.nextQuestionButton.gameObject.SetActive(value:  true);
        this.extraLifeButton.gameObject.SetActive(value:  false);
        UnityEngine.GameObject val_56 = this.freeCoinButton.gameObject;
        goto label_118;
        label_77:
        this.buyExtraLifeButton.gameObject.SetActive(value:  true);
        if(this.endQuizButton != null)
        {
            goto label_122;
        }
        
        string val_59 = System.String.Format(format:  "EVENT LEVEL{0}{1}", arg0:  System.Environment.NewLine, arg1:  val_1.currentGame.quizLevel);
        this.levelProgressText.fontSize = 60;
        goto label_126;
    }
    private System.Collections.IEnumerator redraw()
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVQuestionComplete.<redraw>d__31(<>1__state:  0);
    }
    private void SetupRemoveAdsButton()
    {
        GameEcon val_2 = App.getGameEcon;
        if(App.Player >= val_2.postLevelAdsControl_minLvl)
        {
                if(App.Player.RemovedAds == false)
        {
            goto label_9;
        }
        
        }
        
        this.howToPlayButton.gameObject.SetActive(value:  true);
        this.removeAdsButton.gameObject.SetActive(value:  false);
        return;
        label_9:
        this.removeAdsButton.gameObject.SetActive(value:  true);
        this.howToPlayButton.gameObject.SetActive(value:  false);
        UnityEngine.Vector3 val_13 = this.howToPlayButton.gameObject.transform.position;
        this.removeAdsButton.gameObject.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
    }
    private void OnClick()
    {
        MonoSingleton<TRVMainController>.Instance.ConcludeQuestionComplete();
        this.Close();
    }
    public void OnClickHome()
    {
        var val_4;
        System.Action val_6;
        GameBehavior val_1 = App.getBehavior;
        val_4 = null;
        val_4 = null;
        val_6 = TRVQuestionComplete.<>c.<>9__34_0;
        if(val_6 == null)
        {
                System.Action val_3 = null;
            val_6 = val_3;
            val_3 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickHome>b__34_0());
            TRVQuestionComplete.<>c.<>9__34_0 = val_6;
        }
        
        mem2[0] = val_6;
        this.Close();
    }
    private void OnClickCoinBalance()
    {
        var val_5;
        var val_6;
        System.Action val_8;
        val_5 = null;
        val_5 = null;
        PurchaseProxy.currentPurchasePoint = 87;
        GameBehavior val_1 = App.getBehavior;
        val_6 = null;
        val_6 = null;
        val_8 = TRVQuestionComplete.<>c.<>9__35_0;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickCoinBalance>b__35_0());
            TRVQuestionComplete.<>c.<>9__35_0 = val_8;
        }
        
        val_1.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_3);
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.music.FadeOutMusic();
        this.Close();
    }
    private void OnClickGemBalance()
    {
        var val_6;
        var val_7;
        System.Action val_9;
        GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = 87;
        GameBehavior val_2 = App.getBehavior;
        val_7 = null;
        val_7 = null;
        val_9 = TRVQuestionComplete.<>c.<>9__36_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickGemBalance>b__36_0());
            TRVQuestionComplete.<>c.<>9__36_0 = val_9;
        }
        
        val_2.<metaGameBehavior>k__BackingField.Init(outOfCredits:  false, onCloseAction:  val_4);
        WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
        val_5.music.FadeOutMusic();
        this.Close();
    }
    private void OnClickExpertsButton()
    {
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        WGWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = TRVQuestionComplete.<>c.<>9__37_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickExpertsButton>b__37_0());
            TRVQuestionComplete.<>c.<>9__37_0 = val_8;
        }
        
        mem2[0] = val_8;
        WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
        val_5.music.FadeOutMusic();
        this.Close();
    }
    private void OnClickRemoveAds()
    {
        var val_7;
        var val_8;
        System.Action val_10;
        val_7 = null;
        val_7 = null;
        PurchaseProxy.currentPurchasePoint = 90;
        GameBehavior val_1 = App.getBehavior;
        WGWindow val_4 = val_1.<metaGameBehavior>k__BackingField.InitEntryTag(tag:  30).GetComponent<WGWindow>();
        val_8 = null;
        val_8 = null;
        val_10 = TRVQuestionComplete.<>c.<>9__38_0;
        if(val_10 == null)
        {
                System.Action val_5 = null;
            val_10 = val_5;
            val_5 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickRemoveAds>b__38_0());
            TRVQuestionComplete.<>c.<>9__38_0 = val_10;
        }
        
        mem2[0] = val_10;
        WGAudioController val_6 = MonoSingleton<WGAudioController>.Instance;
        val_6.music.FadeOutMusic();
        this.Close();
    }
    private void OnClickExtraLife()
    {
        var val_8;
        System.Action val_10;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1.bonusRewardedLivesEnabled == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_2.<metaGameBehavior>k__BackingField.Init(rewardedPopup:  true, tag:  45);
        WGWindow val_4 = val_2.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_8 = null;
        val_8 = null;
        val_10 = TRVQuestionComplete.<>c.<>9__39_0;
        if(val_10 == null)
        {
                System.Action val_5 = null;
            val_10 = val_5;
            val_5 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickExtraLife>b__39_0());
            TRVQuestionComplete.<>c.<>9__39_0 = val_10;
        }
        
        mem2[0] = val_10;
        WGAudioController val_6 = MonoSingleton<WGAudioController>.Instance;
        val_6.music.FadeOutMusic();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickWatchVideo()
    {
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        WGWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = TRVQuestionComplete.<>c.<>9__40_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickWatchVideo>b__40_0());
            TRVQuestionComplete.<>c.<>9__40_0 = val_8;
        }
        
        mem2[0] = val_8;
        WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
        val_5.music.FadeOutMusic();
        this.Close();
    }
    private void OnClickHowToPlay()
    {
        var val_6;
        System.Action val_8;
        GameBehavior val_1 = App.getBehavior;
        WGWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = TRVQuestionComplete.<>c.<>9__41_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnClickHowToPlay>b__41_0());
            TRVQuestionComplete.<>c.<>9__41_0 = val_8;
        }
        
        mem2[0] = val_8;
        WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
        val_5.music.FadeOutMusic();
        this.Close();
    }
    private void PopulateQuizProgressIcons()
    {
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if((this.progressIcons != null) && (this.progressIcons != null))
        {
                return;
        }
        
        this.progressIcons = new System.Collections.Generic.List<TRVQuizProgressIcon>();
        if(val_1.currentGame.quizLength >= 1)
        {
                var val_5 = 0;
            do
        {
            TRVQuizProgressIcon val_3 = UnityEngine.Object.Instantiate<TRVQuizProgressIcon>(original:  this.progressIconPrefab, parent:  this.quizProgressParent);
            val_3.transform.SetSiblingIndex(index:  2);
            this.progressIcons.Add(item:  val_3);
            val_5 = val_5 + 1;
        }
        while(val_5 < val_1.currentGame.quizLength);
        
        }
        
        this.quizLevelDisplay.SetSiblingIndex(index:  2);
    }
    private void InformQuizProgressIcons()
    {
        System.Collections.Generic.List<TRVQuizProgressIcon> val_10;
        var val_11;
        var val_12;
        TRVQuestionHistory val_13;
        var val_14;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        val_10 = this.progressIcons;
        if(val_10 == null)
        {
                return;
        }
        
        if(1152921515943153616 != val_1.currentGame.quizLength)
        {
                return;
        }
        
        if(1152921515943153616 < 1)
        {
                return;
        }
        
        val_11 = 0;
        var val_11 = 4;
        label_25:
        if(0 >= 1152921515943153616)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_1.currentGame.countedAnswerData == null)
        {
            goto label_11;
        }
        
        System.Collections.Generic.List<TRVQuestionHistory> val_3 = val_1.currentGame.countedAnswerData;
        if(0 >= 1152921515943153616)
        {
            goto label_11;
        }
        
        System.Collections.Generic.List<TRVQuestionHistory> val_4 = val_1.currentGame.countedAnswerData;
        if(0 >= 1152921515943153616)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<TRVQuestionHistory> val_6 = val_1.currentGame.countedAnswerData;
        if(0 >= 1152921515943153616)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_13 = public SlotMaterialOverride Array.InternalEnumerator<SlotMaterialOverride>::get_Current();
        if(answeredCorrectly == false)
        {
            goto label_18;
        }
        
        goto label_19;
        label_11:
        var val_8 = (val_1.currentGame.quizCompleted == true) ? 1 : 0;
        val_8 = val_11 | val_8;
        if((val_8 & 1) == 0)
        {
            goto label_21;
        }
        
        var val_9 = (val_11 == 4) ? 1 : 0;
        val_13 = 0;
        label_19:
        val_14 = 0;
        goto label_23;
        label_21:
        val_14 = 1;
        val_11 = 1;
        val_13 = 0;
        val_12 = 0;
        goto label_23;
        label_18:
        val_14 = 1;
        val_11 = 1;
        label_23:
        SetupIcon(history:  val_13, firstQuestion:  (val_11 == 4) ? 1 : 0, highlightMe:  true);
        val_10 = this.progressIcons;
        val_11 = val_11 + 1;
        if((val_11 - 3) < 1152921515943153616)
        {
            goto label_25;
        }
    
    }
    private void SetChestSprite()
    {
        UnityEngine.Sprite val_2;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        if(val_1.currentGame.myChest == 2)
        {
            goto label_5;
        }
        
        if(val_1.currentGame.myChest == 1)
        {
            goto label_6;
        }
        
        if(val_1.currentGame.myChest != 0)
        {
                return;
        }
        
        val_2 = this.bronzeChest;
        goto label_11;
        label_6:
        val_2 = this.silverChest;
        goto label_11;
        label_5:
        val_2 = this.goldenChest;
        label_11:
        this.chestImage.sprite = val_2;
    }
    private void Close()
    {
        System.Delegate val_7;
        System.Action<System.Boolean> val_1 = null;
        val_7 = val_1;
        val_1 = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVQuestionComplete::RedrawExtraLife(bool available));
        System.Delegate val_2 = System.Delegate.Remove(source:  this.extraLifeButton.ExtraLifeStateChange, value:  val_1);
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        this.extraLifeButton.ExtraLifeStateChange = val_2;
        if(this.tournamentsButton != 0)
        {
                System.Action<System.Boolean> val_4 = null;
            val_7 = val_4;
            val_4 = new System.Action<System.Boolean>(object:  this, method:  System.Void TRVQuestionComplete::OnTournamentsClicked(bool isConnected));
            System.Delegate val_5 = System.Delegate.Remove(source:  this.tournamentsButton.ExternalClickCallback, value:  val_4);
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            this.tournamentsButton.ExternalClickCallback = val_5;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        return;
        label_9:
    }
    private void RedrawExtraLife(bool available)
    {
        this.Setup();
    }
    private void OnTournamentsClicked(bool isConnected)
    {
        var val_14;
        System.Action val_16;
        var val_17;
        string val_19;
        string val_20;
        if(isConnected == false)
        {
            goto label_1;
        }
        
        TournamentsManager val_1 = MonoSingleton<TournamentsManager>.Instance;
        if(val_1.currentTournamentInfo == null)
        {
            goto label_5;
        }
        
        GameBehavior val_2 = App.getBehavior;
        WGWindow val_4 = val_2.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        val_14 = null;
        val_14 = null;
        val_16 = TRVQuestionComplete.<>c.<>9__47_0;
        if(val_16 == null)
        {
                System.Action val_5 = null;
            val_16 = val_5;
            val_5 = new System.Action(object:  TRVQuestionComplete.<>c.__il2cppRuntimeField_static_fields, method:  System.Void TRVQuestionComplete.<>c::<OnTournamentsClicked>b__47_0());
            TRVQuestionComplete.<>c.<>9__47_0 = val_16;
        }
        
        mem2[0] = val_16;
        WGAudioController val_6 = MonoSingleton<WGAudioController>.Instance;
        val_6.music.FadeOutMusic();
        this.Close();
        return;
        label_1:
        val_17 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_9 = this.tournamentsButton.gameObject;
        val_19 = "tournament_connection";
        val_20 = "Internet connection required. Please check your connection and try again!";
        goto label_25;
        label_5:
        val_17 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_19 = "tournament_processing";
        val_20 = "Currently processing tournament results! Try again in a few minutes.";
        label_25:
        val_17.ShowToolTip(objToToolTip:  this.tournamentsButton.gameObject, text:  Localization.Localize(key:  val_19, defaultValue:  val_20, useSingularKey:  false), topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    public TRVQuestionComplete()
    {
    
    }
    private static TRVQuestionComplete()
    {
        TRVQuestionComplete.lastLevelShownAnim = 0;
    }
    private void <OnEnable>b__29_0()
    {
        WGAudioController val_1 = MonoSingleton<WGAudioController>.Instance;
        val_1.music.FadeOutMusic();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}

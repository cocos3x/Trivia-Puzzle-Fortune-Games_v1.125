using UnityEngine;
public class WFOLevelClearPopup : WGLevelClearPopup
{
    // Fields
    private UnityEngine.CanvasGroup topBarCanvasGroup;
    private UnityEngine.UI.Button buttonStore;
    private WordForest.WFOShieldStatView statViewShield;
    private UnityEngine.CanvasGroup secondaryBarAcornsCanvasGroup;
    private UnityEngine.UI.Text secondaryBarAcornsLabel;
    private UnityEngine.UI.Text secondaryBarAcornMultiplierLabel;
    private UnityEngine.CanvasGroup bottomRowCanvasGroup;
    private UnityEngine.CanvasGroup containerTotalAcornsEarned;
    private UnityEngine.UI.Text labelTotalAcornsEarned;
    private UnityEngine.UI.Button buttonForests;
    private UnityEngine.CanvasGroup badgeForests;
    private UnityEngine.GameObject forestTooltip;
    private UnityEngine.UI.Text buttonForestsText;
    private UnityEngine.UI.Text badgeLabelForests;
    private UnityEngine.UI.Image imageTreesLeft;
    private UnityEngine.UI.Image imageTreesRight;
    private UnityEngine.CanvasGroup progressBarRootCanvasGroup;
    private UnityEngine.CanvasGroup progressBarCanvasGroup;
    private UnityEngine.Transform progressBarRays;
    private UnityEngine.Transform progressBarGiftBox;
    private EventButtonPanel eventProgressPanel;
    private EventButtonPanel eventButtonPanel;
    protected CurrencyParticles acornFlyParticles;
    private UnityEngine.UI.Text buttonContinueText;
    private UnityEngine.UI.Button buttonCollect;
    private SLC.Social.Leagues.LeaguesEntryButton buttonLeagues;
    private UnityEngine.UI.Text levelClearText;
    private UnityEngine.Transform titleTopper;
    private UnityEngine.Transform titleFrame;
    private bool startAnimsPlayed;
    private WGEventButtonV2 evt01_Button;
    private WGEventButtonV2 evt01_ProgressUI;
    private WGEventButtonV2 evt02_Button;
    private WGEventButtonV2 evt02_ProgressUI;
    private bool isSlotOneEmpty;
    private bool isSlotTwoEmpty;
    
    // Properties
    private bool IsAcornSufficientToGrowForest { get; }
    public EventButtonPanel EventButtonPanel { get; }
    
    // Methods
    private bool get_IsAcornSufficientToGrowForest()
    {
        WordForest.WFOPlayer val_1 = WordForest.WFOPlayer.Instance;
        return (bool)(41975808 >= (MonoSingleton<WordForest.WFOForestManager>.Instance.CurrentGrowthCost)) ? 1 : 0;
    }
    public EventButtonPanel get_EventButtonPanel()
    {
        return (EventButtonPanel)this.eventButtonPanel;
    }
    protected override void Start()
    {
        UnityEngine.Events.UnityAction val_10;
        this.Start();
        if(this.buttonLeagues != 0)
        {
                System.Delegate val_3 = System.Delegate.Combine(a:  this.buttonLeagues.onLeaguesEntryAction, b:  new System.Action(object:  X21, method:  public System.Void LevelCompletePopup::HideSelfAndDontDestroy()));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            this.buttonLeagues.onLeaguesEntryAction = val_3;
            System.Action val_4 = new System.Action(object:  X21, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf());
            System.Delegate val_5 = System.Delegate.Combine(a:  this.buttonLeagues.onExitLeaguesAction, b:  val_4);
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
            this.buttonLeagues.onExitLeaguesAction = val_5;
        }
        
        if(this.buttonStore != 0)
        {
                this.buttonStore.m_OnClick.RemoveAllListeners();
            UnityEngine.Events.UnityAction val_7 = null;
            val_10 = val_7;
            val_7 = new UnityEngine.Events.UnityAction(object:  val_4, method:  public System.Void LevelCompletePopup::OpenStackingMonolith<WGStoreProxy>());
            this.buttonStore.m_OnClick.AddListener(call:  val_7);
        }
        
        if(this.statViewShield == 0)
        {
                return;
        }
        
        this.statViewShield.button.m_OnClick.RemoveAllListeners();
        this.statViewShield.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_7, method:  public System.Void LevelCompletePopup::OpenStackingMonolith<WordForest.WFORaidAttackInfoPopup>()));
        return;
        label_9:
    }
    protected override void UpdateUI()
    {
        var val_75;
        var val_76;
        string val_78;
        WFOLevelClearPopup val_79;
        var val_80;
        var val_81;
        469778432.blocksRaycasts = false;
        469778432.SetActive(value:  false);
        this.buttonForests.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WFOLevelClearPopup::OnClickForests()));
        if(this.buttonForests.m_OnClick.IsAcornSufficientToGrowForest == false)
        {
            goto label_6;
        }
        
        val_75 = WordForest.WFOForestManager.IsFeatureUnlocked;
        if(this.buttonForests != null)
        {
            goto label_7;
        }
        
        label_6:
        val_75 = 0;
        label_7:
        this.buttonForests.interactable = false;
        if(WordForest.WFOForestManager.IsFeatureUnlocked != true)
        {
                if(this.buttonForestsText != 0)
        {
                WordForest.WFOGameEcon val_6 = WordForest.WFOGameEcon.Instance;
            string val_7 = System.String.Format(format:  "Forest unlocks at level {0}", arg0:  val_6.wordForestUnlockLevel);
        }
        
        }
        
        this.badgeForests.gameObject.SetActive(value:  false);
        this.eventButtonPanel.rootCanvasGroup.alpha = 0f;
        this.eventProgressPanel.rootCanvasGroup.alpha = 1f;
        UnityEngine.GameObject val_11 = this.buttonCollect.gameObject;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_27;
        }
        
        val_11.SetActive(value:  true);
        UnityEngine.GameObject val_12 = this.buttonForests.gameObject;
        val_12.SetActive(value:  false);
        val_76 = 0;
        val_12.gameObject.SetActive(value:  false);
        goto label_32;
        label_27:
        val_11.SetActive(value:  false);
        UnityEngine.GameObject val_14 = this.buttonForests.gameObject;
        val_14.SetActive(value:  true);
        val_14.gameObject.SetActive(value:  true);
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player)) == false)
        {
            goto label_42;
        }
        
        string val_18 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        if(this.buttonContinueText != null)
        {
            goto label_43;
        }
        
        label_42:
        label_43:
        val_76 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        label_32:
        Player val_21 = App.Player;
        int val_74 = val_21;
        Player val_22 = val_21 - 1;
        string val_23 = System.String.Format(format:  "LEVEL {0} COMPLETE!", arg0:  val_22);
        val_74 = val_74 - 2;
        mem2[0] = (float)ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_74);
        this.levelClearText.current = (float)ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_74);
        ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_22).current = 0f;
        float val_75 = ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28;
        val_75 = (val_75 == Infinityf) ? (-(double)val_75) : ((double)val_75);
        string val_28 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  (int)val_75, arg1:  (int)((ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 == Infinityf ? ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 : ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 + 24) == Infinityf) ? (-((double)ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 == Infinityf ? ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 : ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 + 24)) : ((double)ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 == Infinityf ? ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 : ChapterBookLogic.__il2cppRuntimeField_cctor_finished + 28 + 24));
        val_78 = 1152921517437954544;
        WordForest.WFOManagerGameplay val_29 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        string val_30 = val_29.<lastCompletedAcornsBase>k__BackingField.ToString();
        WordForest.WFOManagerGameplay val_31 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        string val_32 = System.String.Format(format:  "x{0}", arg0:  val_31.<lastCompletedWordStreak>k__BackingField);
        this.HideOfferButtons();
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelOffer()) == false)
        {
            goto label_109;
        }
        
        bool val_36 = MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached;
        if(val_36 == true)
        {
            goto label_109;
        }
        
        if(val_36 != true)
        {
                val_79 = this;
            mem[1152921517438127408] = val_79;
        }
        
        if(val_79 == 3)
        {
            goto label_78;
        }
        
        if((val_79 != 1) || (this.secondaryBarAcornMultiplierLabel == 0))
        {
            goto label_109;
        }
        
        GameBehavior val_39 = App.getBehavior;
        bool val_41 = MonoSingleton<AdsUIController>.Instance.CanShowPostLevelRewardedVideo(playerLevel:  (val_39.<metaGameBehavior>k__BackingField) - 1);
        if(val_41 == false)
        {
            goto label_109;
        }
        
        if(val_41 == true)
        {
            goto label_91;
        }
        
        label_78:
        if(this.secondaryBarAcornMultiplierLabel == 0)
        {
            goto label_109;
        }
        
        GameBehavior val_44 = App.getBehavior;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelAdsControlOffer(playerLevel:  (val_44.<metaGameBehavior>k__BackingField) - 1)) == false)
        {
            goto label_109;
        }
        
        val_80 = null;
        val_80 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
            goto label_109;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        val_78 = Localization.Localize(key:  "x_levels_no_ads_upper", defaultValue:  "{0} LEVELS NO ADS", useSingularKey:  false);
        GameEcon val_49 = App.getGameEcon;
        string val_50 = System.String.Format(format:  val_78, arg0:  val_49.postLevelAdsControl_duration);
        label_91:
        gameObject.SetActive(value:  true);
        AdsUIController val_52 = MonoSingleton<AdsUIController>.Instance;
        val_52.SawPostLevelOffer();
        label_109:
        bool val_54 = val_52.gameObject.activeInHierarchy;
        if(val_54 == true)
        {
            goto label_124;
        }
        
        bool val_56 = val_54.gameObject.activeInHierarchy;
        if(val_56 == false)
        {
            goto label_127;
        }
        
        label_124:
        val_81 = 1;
        if(null != 0)
        {
            goto label_128;
        }
        
        label_127:
        label_128:
        SetActive(value:  val_56.gameObject.activeInHierarchy);
        if(activeInHierarchy != false)
        {
            
        }
        
        float val_63 = ((new UnityEngine.Vector2(x:  600f, y:  200f).activeInHierarchy) != true) ? 0.8f : 0.6f;
        UnityEngine.Transform val_64 = transform;
        if(null == null)
        {
                val_64.sizeDelta = new UnityEngine.Vector2() {x = val_61.x, y = val_61.y};
            if(null == null)
        {
                val_64.transform.sizeDelta = new UnityEngine.Vector2() {x = val_61.x, y = val_61.y};
            UnityEngine.Transform.__il2cppRuntimeField_initializationExceptionGCHandle.pixelsPerUnitMultiplier = val_63;
            (39798888 + (UnityEngine.UI.Image.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 + 216.pixelsPerUnitMultiplier = val_63;
            UnityEngine.Vector3 val_66 = UnityEngine.Vector3.zero;
            this.titleFrame.localScale = new UnityEngine.Vector3() {x = val_66.x, y = val_66.y, z = val_66.z};
            this.titleTopper.localScale = new UnityEngine.Vector3() {x = val_66.x, y = val_66.y, z = val_66.z};
            UnityEngine.Vector3 val_68 = UnityEngine.Vector3.zero;
            this.containerTotalAcornsEarned.transform.localScale = new UnityEngine.Vector3() {x = val_68.x, y = val_68.y, z = val_68.z};
            UnityEngine.Vector3 val_70 = UnityEngine.Vector3.zero;
            this.buttonForests.transform.localScale = new UnityEngine.Vector3() {x = val_70.x, y = val_70.y, z = val_70.z};
            UnityEngine.Vector3 val_73 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  1f);
            this.imageTreesRight.transform.localScale = new UnityEngine.Vector3() {x = val_73.x, y = val_73.y, z = val_73.z};
            this.imageTreesLeft.transform.localScale = new UnityEngine.Vector3() {x = val_73.x, y = val_73.y, z = val_73.z};
            return;
        }
        
        }
    
    }
    public override void PlayStartAnims()
    {
        if(this.startAnimsPlayed != false)
        {
                return;
        }
        
        this.startAnimsPlayed = true;
        WordForest.WFOManagerGameplay val_1 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  0.4f);
        DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.titleTopper, endValue:  1f, duration:  0.4f), ease:  27));
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.titleFrame, endValue:  1f, duration:  0.6f), ease:  27));
        DG.Tweening.Sequence val_10 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_10, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1f, duration:  0.4f), ease:  27));
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_10, atPosition:  0.1f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.buttonForests.transform, endValue:  1f, duration:  0.4f), ease:  27));
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_10, atPosition:  0.3f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScaleY(target:  this.imageTreesLeft.transform, endValue:  1f, duration:  0.25f), ease:  27));
        DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_10, atPosition:  0.3f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScaleX(target:  this.imageTreesLeft.transform, endValue:  1f, duration:  0.2f), ease:  1));
        DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_10, atPosition:  0.5f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScaleY(target:  this.imageTreesRight.transform, endValue:  1f, duration:  0.25f), ease:  27));
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_10, atPosition:  0.5f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScaleX(target:  this.imageTreesRight.transform, endValue:  1f, duration:  0.2f), ease:  1));
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  val_10);
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                this.buttonCollect.interactable = true;
            DG.Tweening.Tweener val_39 = DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.buttonCollect, endValue:  1f, duration:  0.5f), endValue:  1f, duration:  0.5f);
            return;
        }
        
        DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  0.25f);
        DG.Tweening.Sequence val_42 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_2, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOLevelClearPopup::PlayAcornsCreditAnimation()));
    }
    private void PlayAcornsCreditAnimation()
    {
        IntPtr val_50;
        WFOLevelClearPopup.<>c__DisplayClass43_0 val_1 = new WFOLevelClearPopup.<>c__DisplayClass43_0();
        .<>4__this = this;
        this.acornFlyParticles.SetOrigin(originObject:  this.secondaryBarAcornsCanvasGroup.gameObject);
        UnityEngine.Vector3 val_4 = this.containerTotalAcornsEarned.transform.position;
        WordForest.WFOManagerGameplay val_5 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        this.acornFlyParticles.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, particleCount:  val_5.<lastCompletedAcornsTotal>k__BackingField, animateStatView:  false);
        .currentTotal = 0;
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.secondaryBarAcornsCanvasGroup.transform, endValue:  0.85f, duration:  0.1f), ease:  21));
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.4f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.secondaryBarAcornsCanvasGroup.transform, endValue:  1f, duration:  0.1f), ease:  21));
        WordForest.WFOManagerGameplay val_17 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.9f, t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  val_1, method:  System.Int32 WFOLevelClearPopup.<>c__DisplayClass43_0::<PlayAcornsCreditAnimation>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  val_1, method:  System.Void WFOLevelClearPopup.<>c__DisplayClass43_0::<PlayAcornsCreditAnimation>b__1(int x)), endValue:  val_17.<lastCompletedAcornsTotal>k__BackingField, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WFOLevelClearPopup.<>c__DisplayClass43_0::<PlayAcornsCreditAnimation>b__2())));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.9f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1.15f, duration:  0.2f), ease:  21));
        DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  1.2f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1f, duration:  0.2f), ease:  21));
        int val_31 = MonoSingleton<WordForest.WFOForestManager>.Instance.AffordableGrowthStages;
        if(val_31.IsAcornSufficientToGrowForest != false)
        {
                if((val_31 >= 1) && (WordForest.WFOForestManager.IsFeatureUnlocked != false))
        {
                this.badgeForests.alpha = 0f;
            this.badgeForests.gameObject.SetActive(value:  true);
            string val_35 = val_31.ToString();
            DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  1.5f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.badgeForests, endValue:  1f, duration:  0.5f));
            UnityEngine.Vector3 val_39 = new UnityEngine.Vector3(x:  0.65f, y:  0.65f, z:  0f);
            DG.Tweening.Sequence val_41 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  1.5f, t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.badgeForests.transform, punch:  new UnityEngine.Vector3() {x = val_39.x, y = val_39.y, z = val_39.z}, duration:  1.2f, vibrato:  5, elasticity:  0.5f));
        }
        
        }
        
        DG.Tweening.Sequence val_43 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  1.5f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.secondaryBarAcornsCanvasGroup, endValue:  0f, duration:  1f));
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                DG.Tweening.Sequence val_46 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_6, interval:  2f);
            val_50 = 1152921517439269328;
        }
        else
        {
                DG.Tweening.TweenCallback val_47 = null;
            val_50 = 1152921517439274448;
        }
        
        val_47 = new DG.Tweening.TweenCallback(object:  val_1, method:  val_50);
        DG.Tweening.Sequence val_48 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_6, action:  val_47);
    }
    private System.Collections.IEnumerator PlayEventProgressAnim()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WFOLevelClearPopup.<PlayEventProgressAnim>d__44();
    }
    private void PlayChapterProgressAnim()
    {
        float val_41;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        this.progressBarRootCanvasGroup.alpha = 0f;
        this.progressBarRootCanvasGroup.SetActive(value:  true);
        val_41 = (float)ChapterBookLogic.GetLevelWithinChapter(playerLevel:  App.Player - 1);
        1152921504885919744.current = 0f;
        DG.Tweening.Sequence val_8 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_8, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.progressBarRootCanvasGroup, endValue:  1f, duration:  0.25f));
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_8, interval:  0.5f);
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_8, t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single WFOLevelClearPopup::<PlayChapterProgressAnim>b__45_0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void WFOLevelClearPopup::<PlayChapterProgressAnim>b__45_1(float x)), endValue:  val_41, duration:  1f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOLevelClearPopup::<PlayChapterProgressAnim>b__45_2())));
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player)) != false)
        {
                UnityEngine.Vector3 val_19 = UnityEngine.Vector3.zero;
            this.progressBarRays.localScale = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
            this.progressBarRays.gameObject.SetActive(value:  true);
            UnityEngine.Vector3 val_21 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -360f);
            DG.Tweening.Tweener val_24 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DORotate(target:  this.progressBarRays, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, duration:  5f, mode:  3), ease:  1), loops:  0, loopType:  0);
            val_41 = 0.15f;
            DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_8, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.progressBarCanvasGroup, endValue:  0f, duration:  val_41));
            UnityEngine.Vector2 val_27 = UnityEngine.Vector2.zero;
            if(this.progressBarGiftBox != null)
        {
                if(null != null)
        {
            goto label_26;
        }
        
        }
        
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_8, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.progressBarGiftBox, endValue:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y}, duration:  1f, snapping:  false), ease:  7));
            UnityEngine.Vector3 val_31 = UnityEngine.Vector3.one;
            DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_8, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.progressBarRays, endValue:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, duration:  0.1f), ease:  27));
            UnityEngine.Vector3 val_35 = new UnityEngine.Vector3(x:  1.2f, y:  1.2f, z:  1f);
            DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_8, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.progressBarGiftBox, endValue:  new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z}, duration:  val_41), ease:  28));
        }
        
        DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_8, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOLevelClearPopup::PlayConcludingAnimation()));
        return;
        label_26:
    }
    private void PlayConcludingAnimation()
    {
        UnityEngine.RectTransform val_36;
        WGEventButtonV2 val_37;
        34918.interactable = true;
        this.bottomRowCanvasGroup.alpha = 0f;
        this.bottomRowCanvasGroup.gameObject.SetActive(value:  true);
        val_36 = this.topBarCanvasGroup.transform;
        if(null != null)
        {
            goto label_7;
        }
        
        UnityEngine.Vector2 val_3 = val_36.anchoredPosition;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  170f);
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, b:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
        val_36.anchoredPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  0.3f, y:  0.1f, z:  0f);
        UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  0.3f, y:  0.1f, z:  0f);
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOShakeScale(target:  DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOShakeScale(target:  DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.DOTween.__il2cppRuntimeField_cctor_finished, endValue:  1f, duration:  0.1f)).transform, duration:  0.65f, strength:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, vibrato:  7, randomness:  90f, fadeOut:  true)), endValue:  1f, duration:  0.5f)).transform, duration:  0.65f, strength:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, vibrato:  7, randomness:  90f, fadeOut:  true));
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  val_36, endValue:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, duration:  0.5f, snapping:  false), ease:  6));
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.topBarCanvasGroup, endValue:  1f, duration:  0.1f));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bottomRowCanvasGroup, endValue:  1f, duration:  0.3f));
        if(this.isSlotOneEmpty == true)
        {
            goto label_14;
        }
        
        .<>4__this = this;
        if(this.evt01_Button == 0)
        {
            goto label_18;
        }
        
        val_37 = this.evt01_Button;
        if(val_37 != null)
        {
            goto label_19;
        }
        
        label_18:
        val_37 = this.evt01_ProgressUI;
        label_19:
        .handler = this.evt01_ProgressUI.eventHandler;
        DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  0.7f, callback:  new DG.Tweening.TweenCallback(object:  new WFOLevelClearPopup.<>c__DisplayClass46_0(), method:  System.Void WFOLevelClearPopup.<>c__DisplayClass46_0::<PlayConcludingAnimation>b__1()));
        label_14:
        if(this.isSlotTwoEmpty == true)
        {
            goto label_22;
        }
        
        WFOLevelClearPopup.<>c__DisplayClass46_1 val_30 = null;
        val_36 = val_30;
        val_30 = new WFOLevelClearPopup.<>c__DisplayClass46_1();
        .<>4__this = this;
        if(this.evt02_Button == 0)
        {
            goto label_26;
        }
        
        label_28:
        .handler = this.evt02_Button.eventHandler;
        DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  0.7f, callback:  new DG.Tweening.TweenCallback(object:  val_30, method:  System.Void WFOLevelClearPopup.<>c__DisplayClass46_1::<PlayConcludingAnimation>b__2()));
        label_22:
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_6, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOLevelClearPopup::<PlayConcludingAnimation>b__46_0()));
        return;
        label_26:
        if(this.evt02_ProgressUI != null)
        {
            goto label_28;
        }
        
        throw new NullReferenceException();
        label_7:
    }
    public void CloseAndGoToScene(SceneType scene)
    {
        469778432.blocksRaycasts = false;
        System.Nullable<SceneType> val_1 = new System.Nullable<SceneType>(value:  scene);
    }
    public override void OnClick_TapToContinue()
    {
        this.CloseAndGoToScene(scene:  2);
    }
    private void OnClickForests()
    {
        var val_1;
        this.CloseAndGoToScene(scene:  5);
        val_1 = null;
        val_1 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 97;
    }
    protected override WGLevelClearPopup.OfferButton GetOfferButtonToShow()
    {
        GameEcon val_1 = App.getGameEcon;
        float val_7 = val_1.postLevelAdsControl_freq;
        val_7 = val_7 * 10f;
        GameEcon val_3 = App.getGameEcon;
        float val_8 = val_3.postLevelRewardedVideo_freq;
        val_8 = val_8 * 10f;
        val_8 = (val_8 == Infinityf) ? (-(double)val_8) : ((double)val_8);
        return (OfferButton)((UnityEngine.Random.Range(min:  0, max:  (int)val_8 + ((int)(val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7)))) <= ((int)(val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7))) ? 3 : (0 + 1);
    }
    public WFOLevelClearPopup()
    {
    
    }
    private float <PlayChapterProgressAnim>b__45_0()
    {
        if(X8 != 0)
        {
                return (float)X8 + 28;
        }
        
        throw new NullReferenceException();
    }
    private void <PlayChapterProgressAnim>b__45_1(float x)
    {
        if(this != null)
        {
                this.current = x;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <PlayChapterProgressAnim>b__45_2()
    {
        float val_5 = 2.417852E+24f;
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        string val_2 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  (int)val_5, arg1:  (int)((2.417852E+24f == Infinityf ? 2.417852E+24 : 2.417852E+24 + 24) == Infinityf) ? (-((double)2.417852E+24f == Infinityf ? 2.417852E+24 : 2.417852E+24 + 24)) : ((double)2.417852E+24f == Infinityf ? 2.417852E+24 : 2.417852E+24 + 24));
        if((System.String.op_Inequality(a:  X21, b:  34922)) == false)
        {
                return;
        }
        
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.sound.PlayGameSpecificSound(id:  "Progress Update", clipIndex:  0);
    }
    private void <PlayConcludingAnimation>b__46_0()
    {
        X8 + 56.blocksRaycasts = true;
        UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  0.18f, y:  0.18f, z:  0f);
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  X8 + 56.transform, punch:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, duration:  0.9f, vibrato:  5, elasticity:  1f);
    }

}

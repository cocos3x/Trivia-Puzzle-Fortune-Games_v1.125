using UnityEngine;
public class WUTLevelClearPopup : WGLevelClearPopup
{
    // Fields
    private UnityEngine.CanvasGroup topBarCanvasGroup;
    private UnityEngine.UI.Button buttonStore;
    private UnityEngine.UI.Button homeButton;
    private UnityEngine.CanvasGroup secondaryBarAcornsCanvasGroup;
    private UnityEngine.UI.Text secondaryBarAcornsLabel;
    private UnityEngine.UI.Text secondaryBarAcornMultiplierLabel;
    private UnityEngine.CanvasGroup bottomRowCanvasGroup;
    private UnityEngine.CanvasGroup containerTotalAcornsEarned;
    private UnityEngine.UI.Text labelTotalAcornsEarned;
    private UnityEngine.CanvasGroup progressBarRootCanvasGroup;
    private UnityEngine.CanvasGroup progressBarCanvasGroup;
    private UnityEngine.Transform progressBarRays;
    private UnityEngine.Transform progressBarGiftBox;
    private EventButtonPanel eventProgressPanel;
    private EventButtonPanel eventButtonPanel;
    private UnityEngine.CanvasGroup petsNoAdsGroup;
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
    private bool giftRewardCollected;
    
    // Properties
    public EventButtonPanel EventButtonPanel { get; }
    
    // Methods
    public EventButtonPanel get_EventButtonPanel()
    {
        return (EventButtonPanel)this.eventButtonPanel;
    }
    public override void PlayStartAnims()
    {
        if(this.startAnimsPlayed != false)
        {
                return;
        }
        
        this.startAnimsPlayed = true;
        Player val_1 = App.Player;
        WordStreak val_2 = MonoSingleton<WordStreak>.Instance;
        DG.Tweening.Sequence val_3 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_3, interval:  0.4f);
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_3, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.titleTopper, endValue:  1f, duration:  0.4f), ease:  27));
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_3, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.titleFrame, endValue:  1f, duration:  0.6f), ease:  27));
        DG.Tweening.Sequence val_11 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_11, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1f, duration:  0.4f), ease:  27));
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_3, t:  val_11);
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                this.buttonCollect.interactable = true;
            DG.Tweening.Tweener val_20 = DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.buttonCollect, endValue:  1f, duration:  0.5f), endValue:  1f, duration:  0.5f);
            return;
        }
        
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_3, interval:  0.25f);
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_3, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTLevelClearPopup::PlayAcornsCreditAnimation()));
    }
    public void CloseAndGoToScene(SceneType scene)
    {
        469778432.blocksRaycasts = false;
        System.Nullable<SceneType> val_1 = new System.Nullable<SceneType>(value:  scene);
    }
    public override void OnClick_TapToContinue()
    {
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player)) != false)
        {
                if(this.giftRewardCollected == false)
        {
            goto label_7;
        }
        
        }
        
        this.CloseAndGoToScene(scene:  2);
        return;
        label_7:
        WGFlyoutManager val_3 = MonoSingleton<WGFlyoutManager>.Instance;
        val_3.SetDarkenedBackgroundAlpha(alpha:  0f);
        WGGiftRewardPopup val_4 = val_3.OpenStackingMonolithGetWindow<WGGiftRewardPopup>();
        SLCWindow val_5 = val_4.GetComponent<SLCWindow>();
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.Action_OnClose, b:  new System.Action(object:  this, method:  typeof(WUTLevelClearPopup).__il2cppRuntimeField_1B8));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        val_5.Action_OnClose = val_7;
        val_4.Setup(rewardSource:  3);
        this.giftRewardCollected = true;
        return;
        label_16:
    }
    public override void ResetLevelClearAfterGiftReward()
    {
        string val_2 = System.String.Format(format:  "LEVEL {0}", arg0:  App.Player);
        UnityEngine.UI.Text.__il2cppRuntimeField_actualSize.RemoveAllListeners();
        UnityEngine.UI.Text.__il2cppRuntimeField_actualSize.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WUTLevelClearPopup).__il2cppRuntimeField_198));
        Player val_4 = App.Player;
        Player val_5 = val_4 - 1;
        this.progressBarCanvasGroup.alpha = 1f;
        mem2[0] = (float)ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_5);
        X22.current = (float)ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_5);
        ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_4).current = 0f;
        string val_13 = System.String.Format(format:  "{0}/{1} "("{0}/{1} ") + Localization.Localize(key:  "levels_upper", defaultValue:  "LEVELS", useSingularKey:  false)(Localization.Localize(key:  "levels_upper", defaultValue:  "LEVELS", useSingularKey:  false)), arg0:  (int)(("{0}/{1} ".__il2cppRuntimeField_1C) == Infinityf) ? (-((double)"{0}/{1} ".__il2cppRuntimeField_1C)) : ((double)"{0}/{1} ".__il2cppRuntimeField_1C), arg1:  (int)(("{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24) == Infinityf) ? (-((double)"{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24)) : ((double)"{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24));
        this.progressBarGiftBox.GetComponent<UnityEngine.UI.Button>().interactable = false;
        UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  370f, y:  0f);
        if(null == null)
        {
                this.progressBarGiftBox.anchoredPosition = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            this.progressBarRays.gameObject.SetActive(value:  false);
            return;
        }
    
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
        
        if(this.homeButton == 0)
        {
                return;
        }
        
        this.homeButton.m_OnClick.RemoveAllListeners();
        this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_7, method:  public System.Void LevelCompletePopup::OpenStackingMonolith<WGFeatureMenu>()));
        return;
        label_9:
    }
    protected override void UpdateUI()
    {
        var val_65;
        string val_67;
        WUTLevelClearPopup val_68;
        var val_69;
        var val_70;
        469778432.blocksRaycasts = false;
        469778432.SetActive(value:  false);
        this.eventButtonPanel.rootCanvasGroup.alpha = 0f;
        this.eventProgressPanel.rootCanvasGroup.alpha = 1f;
        UnityEngine.GameObject val_3 = this.buttonCollect.gameObject;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_13;
        }
        
        val_3.SetActive(value:  true);
        val_65 = 0;
        val_3.gameObject.SetActive(value:  false);
        goto label_16;
        label_13:
        val_3.SetActive(value:  false);
        val_3.gameObject.SetActive(value:  true);
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player)) == false)
        {
            goto label_24;
        }
        
        string val_8 = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        if(this.buttonContinueText != null)
        {
            goto label_25;
        }
        
        label_24:
        label_25:
        val_65 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  App.Player);
        label_16:
        Player val_12 = App.Player;
        int val_65 = val_12;
        Player val_13 = val_12 - 1;
        string val_15 = System.String.Format(format:  Localization.Localize(key:  "level_#_complete_exc", defaultValue:  "LEVEL {0} COMPLETE!", useSingularKey:  false), arg0:  val_13);
        val_65 = val_65 - 2;
        mem2[0] = (float)ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_65);
        this.levelClearText.current = (float)ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_65);
        ChapterBookLogic.GetLevelWithinChapter(playerLevel:  val_13).current = 0f;
        string val_23 = System.String.Format(format:  "{0}/{1} "("{0}/{1} ") + Localization.Localize(key:  "levels_upper", defaultValue:  "LEVELS", useSingularKey:  false)(Localization.Localize(key:  "levels_upper", defaultValue:  "LEVELS", useSingularKey:  false)), arg0:  (int)(("{0}/{1} ".__il2cppRuntimeField_1C) == Infinityf) ? (-((double)"{0}/{1} ".__il2cppRuntimeField_1C)) : ((double)"{0}/{1} ".__il2cppRuntimeField_1C), arg1:  (int)(("{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24) == Infinityf) ? (-((double)"{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24)) : ((double)"{0}/{1} ".__il2cppRuntimeField_1C == Infinityf ? "{0}/{1} ".__il2cppRuntimeField_1C : "{0}/{1} ".__il2cppRuntimeField_1C + 24));
        val_67 = 1152921515420703792;
        WordStreak val_24 = MonoSingleton<WordStreak>.Instance;
        string val_25 = val_24.currentLevel.goldenApplesStreaks.ToString();
        Player val_26 = App.Player;
        WordStreak val_27 = MonoSingleton<WordStreak>.Instance;
        int val_66 = val_27.currentLevel.goldenApplesStreaks;
        val_66 = val_26._stars - val_66;
        string val_28 = val_66.ToString();
        this.HideOfferButtons();
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelOffer()) == false)
        {
            goto label_96;
        }
        
        bool val_32 = MonoSingletonSelfGenerating<AdsManager>.Instance.rewardVideoCapReached;
        if(val_32 == true)
        {
            goto label_96;
        }
        
        if(val_32 != true)
        {
                val_68 = this;
            mem[1152921518042382448] = val_68;
        }
        
        if(val_68 == 3)
        {
            goto label_65;
        }
        
        if((val_68 != 1) || (this.labelTotalAcornsEarned == 0))
        {
            goto label_96;
        }
        
        GameBehavior val_35 = App.getBehavior;
        bool val_37 = MonoSingleton<AdsUIController>.Instance.CanShowPostLevelRewardedVideo(playerLevel:  (val_35.<metaGameBehavior>k__BackingField) - 1);
        if(val_37 == false)
        {
            goto label_96;
        }
        
        if(val_37 == true)
        {
            goto label_78;
        }
        
        label_65:
        if(this.labelTotalAcornsEarned == 0)
        {
            goto label_96;
        }
        
        GameBehavior val_40 = App.getBehavior;
        if((MonoSingleton<AdsUIController>.Instance.CanShowPostLevelAdsControlOffer(playerLevel:  (val_40.<metaGameBehavior>k__BackingField) - 1)) == false)
        {
            goto label_96;
        }
        
        val_69 = null;
        val_69 = null;
        if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE == null)
        {
            goto label_96;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnVideoResponse");
        val_67 = Localization.Localize(key:  "x_levels_no_ads_upper", defaultValue:  "{0} LEVELS NO ADS", useSingularKey:  false);
        GameEcon val_45 = App.getGameEcon;
        string val_46 = System.String.Format(format:  val_67, arg0:  val_45.postLevelAdsControl_duration);
        label_78:
        gameObject.SetActive(value:  true);
        AdsUIController val_48 = MonoSingleton<AdsUIController>.Instance;
        val_48.SawPostLevelOffer();
        label_96:
        bool val_50 = val_48.gameObject.activeInHierarchy;
        if(val_50 == true)
        {
            goto label_111;
        }
        
        bool val_52 = val_50.gameObject.activeInHierarchy;
        if(val_52 == false)
        {
            goto label_114;
        }
        
        label_111:
        val_70 = 1;
        if(null != 0)
        {
            goto label_115;
        }
        
        label_114:
        label_115:
        SetActive(value:  val_52.gameObject.activeInHierarchy);
        if(activeInHierarchy != false)
        {
            
        }
        
        float val_59 = ((new UnityEngine.Vector2(x:  600f, y:  200f).activeInHierarchy) != true) ? 0.8f : 0.6f;
        UnityEngine.Transform val_60 = transform;
        if(null == null)
        {
                val_60.sizeDelta = new UnityEngine.Vector2() {x = val_57.x, y = val_57.y};
            if(null == null)
        {
                val_60.transform.sizeDelta = new UnityEngine.Vector2() {x = val_57.x, y = val_57.y};
            UnityEngine.Transform.__il2cppRuntimeField_initializationExceptionGCHandle.pixelsPerUnitMultiplier = val_59;
            (39798888 + (UnityEngine.UI.Image.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 + 216.pixelsPerUnitMultiplier = val_59;
            UnityEngine.Vector3 val_62 = UnityEngine.Vector3.zero;
            this.titleFrame.localScale = new UnityEngine.Vector3() {x = val_62.x, y = val_62.y, z = val_62.z};
            this.titleTopper.localScale = new UnityEngine.Vector3() {x = val_62.x, y = val_62.y, z = val_62.z};
            UnityEngine.Vector3 val_64 = UnityEngine.Vector3.zero;
            this.containerTotalAcornsEarned.transform.localScale = new UnityEngine.Vector3() {x = val_64.x, y = val_64.y, z = val_64.z};
            return;
        }
        
        }
    
    }
    private void PlayAcornsCreditAnimation()
    {
        IntPtr val_39;
        WUTLevelClearPopup.<>c__DisplayClass39_0 val_1 = new WUTLevelClearPopup.<>c__DisplayClass39_0();
        .<>4__this = this;
        WordStreak val_2 = MonoSingleton<WordStreak>.Instance;
        this.acornFlyParticles.SetOrigin(originObject:  this.secondaryBarAcornsCanvasGroup.gameObject);
        UnityEngine.Vector3 val_5 = this.containerTotalAcornsEarned.transform.position;
        this.acornFlyParticles.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, particleCount:  val_2.currentLevel.goldenApplesStreaks, animateStatView:  false);
        Player val_6 = App.Player;
        int val_38 = val_6._stars;
        val_38 = val_38 - val_2.currentLevel.goldenApplesStreaks;
        .currentTotal = val_38;
        DG.Tweening.Sequence val_7 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  0f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.secondaryBarAcornsCanvasGroup.transform, endValue:  0.85f, duration:  0.1f), ease:  21));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  0.4f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.secondaryBarAcornsCanvasGroup.transform, endValue:  1f, duration:  0.1f), ease:  21));
        Player val_18 = App.Player;
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  0.9f, t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  val_1, method:  System.Int32 WUTLevelClearPopup.<>c__DisplayClass39_0::<PlayAcornsCreditAnimation>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  val_1, method:  System.Void WUTLevelClearPopup.<>c__DisplayClass39_0::<PlayAcornsCreditAnimation>b__1(int x)), endValue:  val_18._stars, duration:  0.5f), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WUTLevelClearPopup.<>c__DisplayClass39_0::<PlayAcornsCreditAnimation>b__2())));
        DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  0.9f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1.15f, duration:  0.2f), ease:  21));
        DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  1.2f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.containerTotalAcornsEarned.transform, endValue:  1f, duration:  0.2f), ease:  21));
        DG.Tweening.Sequence val_32 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_7, atPosition:  1.5f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.secondaryBarAcornsCanvasGroup, endValue:  0f, duration:  1f));
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_7, interval:  2f);
            val_39 = 1152921518042895248;
        }
        else
        {
                DG.Tweening.TweenCallback val_36 = null;
            val_39 = 1152921518042900368;
        }
        
        val_36 = new DG.Tweening.TweenCallback(object:  val_1, method:  val_39);
        DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_7, action:  val_36);
    }
    private System.Collections.IEnumerator PlayEventProgressAnim()
    {
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WUTLevelClearPopup.<PlayEventProgressAnim>d__40(<>1__state:  0);
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
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_8, t:  DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single WUTLevelClearPopup::<PlayChapterProgressAnim>b__41_0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void WUTLevelClearPopup::<PlayChapterProgressAnim>b__41_1(float x)), endValue:  val_41, duration:  1f), ease:  1), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTLevelClearPopup::<PlayChapterProgressAnim>b__41_2())));
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
        
        DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_8, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTLevelClearPopup::PlayConcludingAnimation()));
        return;
        label_26:
    }
    private void PlayConcludingAnimation()
    {
        UnityEngine.RectTransform val_38;
        WGEventButtonV2 val_39;
        36933.interactable = true;
        this.bottomRowCanvasGroup.alpha = 0f;
        this.bottomRowCanvasGroup.gameObject.SetActive(value:  true);
        val_38 = this.topBarCanvasGroup.transform;
        if(null != null)
        {
            goto label_7;
        }
        
        UnityEngine.Vector2 val_3 = val_38.anchoredPosition;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0f, y:  170f);
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, b:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
        val_38.anchoredPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
        DG.Tweening.Sequence val_6 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  val_38, endValue:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, duration:  0.5f, snapping:  false), ease:  6));
        DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.topBarCanvasGroup, endValue:  1f, duration:  0.1f));
        DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.petsNoAdsGroup, endValue:  1f, duration:  0.1f));
        UnityEngine.Vector3 val_19 = new UnityEngine.Vector3(x:  0.3f, y:  0.1f, z:  0f);
        UnityEngine.Vector3 val_25 = new UnityEngine.Vector3(x:  0.3f, y:  0.1f, z:  0f);
        DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOShakeScale(target:  DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.TweenSettingsExtensions.Join(s:  val_6, t:  DG.Tweening.ShortcutExtensions.DOShakeScale(target:  DG.Tweening.TweenSettingsExtensions.Append(s:  val_6, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  DG.Tweening.TweenSettingsExtensions.Insert(s:  val_6, atPosition:  0.7f, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.bottomRowCanvasGroup, endValue:  1f, duration:  0.3f)), endValue:  1f, duration:  0.1f)).transform, duration:  0.65f, strength:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, vibrato:  7, randomness:  90f, fadeOut:  true)), endValue:  1f, duration:  0.5f)).transform, duration:  0.65f, strength:  new UnityEngine.Vector3() {x = val_25.x, y = val_25.y, z = val_25.z}, vibrato:  7, randomness:  90f, fadeOut:  true));
        if(this.isSlotOneEmpty == true)
        {
            goto label_14;
        }
        
        .<>4__this = this;
        if(this.evt01_Button == 0)
        {
            goto label_18;
        }
        
        val_39 = this.evt01_Button;
        if(val_39 != null)
        {
            goto label_19;
        }
        
        label_18:
        val_39 = this.evt01_ProgressUI;
        label_19:
        .handler = this.evt01_ProgressUI.eventHandler;
        DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  0.7f, callback:  new DG.Tweening.TweenCallback(object:  new WUTLevelClearPopup.<>c__DisplayClass42_0(), method:  System.Void WUTLevelClearPopup.<>c__DisplayClass42_0::<PlayConcludingAnimation>b__1()));
        label_14:
        if(this.isSlotTwoEmpty == true)
        {
            goto label_22;
        }
        
        WUTLevelClearPopup.<>c__DisplayClass42_1 val_32 = null;
        val_38 = val_32;
        val_32 = new WUTLevelClearPopup.<>c__DisplayClass42_1();
        .<>4__this = this;
        if(this.evt02_Button == 0)
        {
            goto label_26;
        }
        
        label_28:
        .handler = this.evt02_Button.eventHandler;
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.InsertCallback(s:  val_6, atPosition:  0.7f, callback:  new DG.Tweening.TweenCallback(object:  val_32, method:  System.Void WUTLevelClearPopup.<>c__DisplayClass42_1::<PlayConcludingAnimation>b__2()));
        label_22:
        DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_6, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WUTLevelClearPopup::<PlayConcludingAnimation>b__42_0()));
        return;
        label_26:
        if(this.evt02_ProgressUI != null)
        {
            goto label_28;
        }
        
        throw new NullReferenceException();
        label_7:
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
    public WUTLevelClearPopup()
    {
    
    }
    private float <PlayChapterProgressAnim>b__41_0()
    {
        if(X8 != 0)
        {
                return (float)X8 + 28;
        }
        
        throw new NullReferenceException();
    }
    private void <PlayChapterProgressAnim>b__41_1(float x)
    {
        if(this != null)
        {
                this.current = x;
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <PlayChapterProgressAnim>b__41_2()
    {
        float val_5 = mem[-4289678541989019619];
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        string val_2 = System.String.Format(format:  "{0}/{1} LEVELS", arg0:  (int)val_5, arg1:  (int)((mem[-4289678541989019619] == Infinityf ? mem[-4289678541989019619] : mem[-4289678541989019619] + 24) == Infinityf) ? (-((double)mem[-4289678541989019619] == Infinityf ? mem[-4289678541989019619] : mem[-4289678541989019619] + 24)) : ((double)mem[-4289678541989019619] == Infinityf ? mem[-4289678541989019619] : mem[-4289678541989019619] + 24));
        if((System.String.op_Inequality(a:  X21, b:  36938)) == false)
        {
                return;
        }
        
        WGAudioController val_4 = MonoSingleton<WGAudioController>.Instance;
        val_4.sound.PlayGameSpecificSound(id:  "Progress Update", clipIndex:  0);
    }
    private void <PlayConcludingAnimation>b__42_0()
    {
        469778432.blocksRaycasts = true;
        if((ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player)) == false)
        {
                return;
        }
        
        this.progressBarGiftBox.GetComponent<UnityEngine.UI.Button>().interactable = true;
        UnityEngine.UI.Button val_4 = this.progressBarGiftBox.GetComponent<UnityEngine.UI.Button>();
        val_4.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WUTLevelClearPopup).__il2cppRuntimeField_198));
    }

}

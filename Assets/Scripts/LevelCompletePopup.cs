using UnityEngine;
public class LevelCompletePopup : MonoBehaviour
{
    // Fields
    protected WGLevelClearPopup levelClearPopup;
    protected WGChapterClearPopup chapterClearPopup;
    private WordIQLevelCompleteDisplayAnim iqDisplayAnim;
    private ChapterBookLevelCompleteDisplay chapterBookLevelComplete;
    protected UnityEngine.CanvasGroup rootCanvasGroup;
    private UnityEngine.CanvasGroup allUpperUI;
    private UnityEngine.CanvasGroup allLowerUI;
    private LevelCompleteGoldenApplesUI goldenApplesGroup;
    private UnityEngine.RectTransform categoryInfoDisplayContainer;
    private CategoryPackCompleteDisplay catPackCompleteDisplayPrefab;
    private GoldenCurrencyCollectAnimationInstantiator appleCollector;
    private UnityEngine.GameObject group_goldenApplesDisplay;
    private UnityEngine.UI.Text goldenApplesBonus;
    private UnityEngine.UI.Button difficultySettingButton;
    private UnityEngine.UI.Text goldenMultiplierBonusApples;
    private UnityEngine.GameObject goldenMultiplierGroup;
    private TournamentsButton tournamentsButton;
    private CategoryPackCompleteDisplay catPackCompleteDisplayInstance;
    
    // Properties
    public UnityEngine.CanvasGroup RootCanvasGroup { get; }
    public GoldenCurrencyCollectAnimationInstantiator AppleCollector { get; }
    public WGLevelClearPopup LevelClearPopup { get; }
    public UnityEngine.CanvasGroup AllUpperUI { get; }
    public UnityEngine.CanvasGroup AllLowerUI { get; }
    
    // Methods
    public UnityEngine.CanvasGroup get_RootCanvasGroup()
    {
        return (UnityEngine.CanvasGroup)this.rootCanvasGroup;
    }
    public GoldenCurrencyCollectAnimationInstantiator get_AppleCollector()
    {
        return (GoldenCurrencyCollectAnimationInstantiator)this.appleCollector;
    }
    public WGLevelClearPopup get_LevelClearPopup()
    {
        return (WGLevelClearPopup)this.levelClearPopup;
    }
    public UnityEngine.CanvasGroup get_AllUpperUI()
    {
        return (UnityEngine.CanvasGroup)this.allUpperUI;
    }
    public UnityEngine.CanvasGroup get_AllLowerUI()
    {
        return (UnityEngine.CanvasGroup)this.allLowerUI;
    }
    public virtual void OnEnable()
    {
        bool val_23 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                this.iqDisplayAnim.Setup();
        }
        
        this.Invoke(methodName:  "WaitAndPlayAnim", time:  0.1f);
        if(PlayingLevel.CurrentGameplayMode == 4)
        {
                if(this.chapterBookLevelComplete != 0)
        {
                this.chapterBookLevelComplete.gameObject.SetActive(value:  false);
        }
        
            if(this.categoryInfoDisplayContainer == 0)
        {
                return;
        }
        
            this.categoryInfoDisplayContainer.gameObject.SetActive(value:  true);
            this.catPackCompleteDisplayInstance = UnityEngine.Object.Instantiate<CategoryPackCompleteDisplay>(original:  this.catPackCompleteDisplayPrefab, parent:  this.categoryInfoDisplayContainer);
            val_7.levelCompletePopup = this;
            CategoryPacksManager val_8 = MonoSingleton<CategoryPacksManager>.Instance;
            val_23 = val_8.<IsChapterCompleted>k__BackingField;
            this.catPackCompleteDisplayInstance.Show(isChapterComplete:  (val_23 == true) ? 1 : 0, isPackComplete:  MonoSingleton<CategoryPacksManager>.Instance.IsPackNewlyCompleted);
        }
        else
        {
                if(this.chapterBookLevelComplete != 0)
        {
                this.chapterBookLevelComplete.gameObject.SetActive(value:  true);
            this.chapterBookLevelComplete.Display(currentPlayerLevel:  App.Player, secondsBeforeDisplay:  0.1f);
        }
        
            if(this.categoryInfoDisplayContainer != 0)
        {
                this.categoryInfoDisplayContainer.gameObject.SetActive(value:  false);
        }
        
        }
        
        if(GoldenMultiplierManager.IsAvaialable != false)
        {
                this.SetupGoldenMultiplierUI();
        }
        else
        {
                if(this.goldenApplesGroup != 0)
        {
                this.goldenApplesGroup.SetupDifficultySettingUI();
            this.goldenApplesGroup.SetupPetsUI();
        }
        else
        {
                this.SetupDifficultySettingUI();
        }
        
        }
        
        if(this.tournamentsButton == 0)
        {
                return;
        }
        
        System.Action<System.Boolean> val_21 = null;
        val_23 = val_21;
        val_21 = new System.Action<System.Boolean>(object:  this, method:  System.Void LevelCompletePopup::OnTournamentsClicked(bool isConnected));
        System.Delegate val_22 = System.Delegate.Combine(a:  this.tournamentsButton.ExternalClickCallback, b:  val_21);
        if(val_22 != null)
        {
                if(null != null)
        {
            goto label_55;
        }
        
        }
        
        this.tournamentsButton.ExternalClickCallback = val_22;
        return;
        label_55:
    }
    public virtual void ShowWithEffects()
    {
        bool val_16;
        bool val_17;
        if(PlayingLevel.CurrentGameplayMode == 4)
        {
                CategoryPacksManager val_2 = MonoSingleton<CategoryPacksManager>.Instance;
            var val_3 = ((val_2.<IsChapterCompleted>k__BackingField) == true) ? 1 : 0;
            val_17 = (((val_2.<IsChapterCompleted>k__BackingField) == true) ? 1 : 0) & ((MonoSingleton<CategoryPacksManager>.Instance.IsPackNewlyCompleted) ^ 1);
        }
        else
        {
                val_16 = ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player);
            val_17 = (ChapterBookLogic.ShowBookComplete(playerLevel:  App.Player)) ^ 1;
        }
        
        this.chapterClearPopup.Setup(shouldBeShowing:  val_16, showRewards:  val_17);
        this.levelClearPopup.Setup(shouldBeShowing:  (~val_16) & 1);
    }
    public virtual void HandleWindowClose(bool chapterClear)
    {
        var val_24;
        var val_25;
        var val_26;
        UnityEngine.Object val_27;
        val_24 = 1152921504765632512;
        if(this.tournamentsButton != 0)
        {
                System.Delegate val_3 = System.Delegate.Remove(source:  this.tournamentsButton.ExternalClickCallback, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void LevelCompletePopup::OnTournamentsClicked(bool isConnected)));
            if(val_3 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
            this.tournamentsButton.ExternalClickCallback = val_3;
        }
        
        val_25 = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_13;
        }
        
        val_25 = 0;
        if((MonoSingleton<CategoryPacksManager>.Instance.IsPackCompleted(packId:  0)) == false)
        {
            goto label_13;
        }
        
        MainController.instance.OnCategoryPackCompletedClosed();
        goto label_22;
        label_13:
        if(chapterClear != false)
        {
                MainController.instance.OnChapterClearClosed();
        }
        else
        {
                MainController val_10 = MainController.instance;
        }
        
        label_22:
        val_26 = 1152921515418583504;
        val_27 = MonoSingleton<DifficultySettingManager>.Instance;
        if(val_27 == 0)
        {
                return;
        }
        
        DifficultySettingManager val_13 = MonoSingleton<DifficultySettingManager>.Instance;
        if(val_13.DifficultyChangedOnLevelComplete == false)
        {
                return;
        }
        
        GameBehavior val_14 = App.getBehavior;
        val_27 = ???;
        val_26 = ???;
        val_24 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
        label_6:
    }
    public void HideLowerUI(float fadeOutDuration = 0.5, float delay = 0)
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.allLowerUI, endValue:  0f, duration:  fadeOutDuration), delay:  delay);
    }
    public void HideUpperUI(float fadeOutDuration = 0.5, float delay = 0)
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.allUpperUI, endValue:  0f, duration:  fadeOutDuration), delay:  delay);
    }
    public void ShowLowerUI(float fadeInDuration = 0.5, float delay = 0)
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.allLowerUI, endValue:  1f, duration:  fadeInDuration), delay:  delay);
    }
    public void ShowUpperUI(float fadeInDuration = 0.5, float delay = 0)
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.allUpperUI, endValue:  1f, duration:  fadeInDuration), delay:  delay);
    }
    public virtual void WaitAndPlayAnim()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                this.iqDisplayAnim.Play();
        }
        
        this.chapterClearPopup.PlayStartAnims();
        goto typeof(WGLevelClearPopup).__il2cppRuntimeField_1A0;
    }
    public void OpenStackingMonolith<T>()
    {
        System.Delegate val_7;
        this.HideSelfAndDontDestroy();
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        SLCWindow val_2 = val_1.GetComponent<SLCWindow>();
        System.Action val_3 = null;
        val_7 = val_3;
        val_3 = new System.Action(object:  this, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf());
        if((System.Delegate.Combine(a:  val_2.Action_OnClose, b:  val_3)) == null)
        {
            goto label_7;
        }
        
        val_7 = null;
        if(X0 == false)
        {
            goto label_8;
        }
        
        label_7:
        val_2.Action_OnClose = null;
        if((UnityEngine.Object.op_Implicit(exists:  val_1.GetComponent<WGFeatureMenu>())) == false)
        {
                return;
        }
        
        val_5.levelCompletePopup = this;
        return;
        label_8:
    }
    public T OpenStackingMonolithGetWindow<T>()
    {
        UnityEngine.Debug.LogError(message:  "RESTORING LEVEL COMPLETE");
        this.HideSelfAndDontDestroy();
        WGWindowManager val_1 = MonoSingleton<WGWindowManager>.Instance;
        SLCWindow val_2 = val_1.GetComponent<SLCWindow>();
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.Action_OnClose, b:  new System.Action(object:  this, method:  public System.Void LevelCompletePopup::RestoreHiddenSelf()));
        if(val_4 == null)
        {
            goto label_9;
        }
        
        this = val_4;
        if(X0 == false)
        {
            goto label_10;
        }
        
        label_9:
        val_2.Action_OnClose = null;
        return (object)val_1;
        label_10:
    }
    public void HideSelfAndDontDestroy()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
    }
    public void RestoreHiddenSelf()
    {
        var val_3;
        System.Action val_5;
        val_3 = null;
        val_3 = null;
        val_5 = LevelCompletePopup.<>c.<>9__39_0;
        if(val_5 == null)
        {
                System.Action val_2 = null;
            val_5 = val_2;
            val_2 = new System.Action(object:  LevelCompletePopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void LevelCompletePopup.<>c::<RestoreHiddenSelf>b__39_0());
            LevelCompletePopup.<>c.<>9__39_0 = val_5;
        }
        
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  MonoSingleton<WGWindowManager>.Instance, callback:  val_2, count:  1);
    }
    private void OnClick_DifficultySettingButton()
    {
        WGFlyoutManager val_2 = MonoSingleton<WGFlyoutManager>.Instance.ShowUGUIMonolith<WGDifficultySettingPopup>(showNext:  false);
    }
    private void SetupDifficultySettingUI()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        if((MonoSingleton<DifficultySettingManager>.Instance) == 0)
        {
                return;
        }
        
        if((MonoSingleton<DifficultySettingManagerGameplay>.Instance) == 0)
        {
                return;
        }
        
        DifficultySettingManagerGameplay val_6 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
        if(val_6.ShouldShowGoldenApplesBonus == false)
        {
                return;
        }
        
        DifficultySettingManagerGameplay val_7 = MonoSingleton<DifficultySettingManagerGameplay>.Instance;
        string val_8 = val_7.GoldenApplesAward.ToString();
        if((UnityEngine.Object.op_Implicit(exists:  this.appleCollector)) != false)
        {
                mem2[0] = 1;
        }
        
        this.group_goldenApplesDisplay.SetActive(value:  true);
        this.difficultySettingButton.gameObject.SetActive(value:  true);
        this.difficultySettingButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LevelCompletePopup::OnClick_DifficultySettingButton()));
    }
    private void SetupGoldenMultiplierUI()
    {
        mem2[0] = 0;
        this.group_goldenApplesDisplay.SetActive(value:  true);
        GoldenMultiplierManager val_1 = MonoSingleton<GoldenMultiplierManager>.Instance;
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.PlayGoldenCurrencyGet(amount:  val_1.currentLevelCompleteBonus));
    }
    private System.Collections.IEnumerator PlayGoldenCurrencyGet(int amount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .amount = amount;
        return (System.Collections.IEnumerator)new LevelCompletePopup.<PlayGoldenCurrencyGet>d__43();
    }
    private void OnTournamentsClicked(bool isConnected)
    {
        MetaGameBehavior val_10;
        string val_12;
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
        val_10 = val_2.<metaGameBehavior>k__BackingField;
        mem2[0] = 0;
        return;
        label_1:
        val_10 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        UnityEngine.GameObject val_6 = this.tournamentsButton.gameObject;
        val_12 = "Internet connection required. Please check your connection and try again!";
        goto label_17;
        label_5:
        val_10 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        val_12 = "Currently processing tournament results! Try again in a few minutes.";
        label_17:
        val_10.ShowToolTip(objToToolTip:  this.tournamentsButton.gameObject, text:  val_12, topToolTip:  true, displayDuration:  3.5f, width:  700f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
    }
    public LevelCompletePopup()
    {
    
    }

}

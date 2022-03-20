using UnityEngine;
public class FPHGameplayUIController : MonoSingleton<FPHGameplayUIController>
{
    // Fields
    private UnityEngine.CanvasGroup topBarCanvasGroup;
    private UnityEngine.CanvasGroup topBarButtonsGroup;
    private FPHKeyboard keyBoard;
    private UnityEngine.GameObject banner;
    private UnityEngine.UI.Text bannerText;
    private FPHAnswerDisplay answerDisplay;
    private UnityEngine.CanvasGroup solveRowCanvasGroup;
    private FPHTokenDisplay tokenDisplay;
    private FPHIncorrectGuessDisplay incorrectGuessDisplay;
    private FPHLevelFailDisplay levelFailDisplay;
    private UnityEngine.UI.Button howToPlayButton;
    private UnityEngine.UI.Button leaguesButton;
    private UnityEngine.UI.Button eventsButton;
    private UnityEngine.UI.Button removeAdsButton;
    private UnityEngine.UI.Button freeGemsButton;
    private UnityEngine.UI.Button buttonSolve;
    private UnityEngine.UI.Button buttonExitSolve;
    private FPHPowerupButton buttonPowerupHint;
    private UnityEngine.UI.Image ootSolveButtonHighlight;
    private UnityEngine.UI.Text tutorialText;
    private UnityEngine.GameObject solveButtonTutorial;
    private FPHEcon econ;
    private DG.Tweening.Tween solveButtonHighlightTween;
    
    // Properties
    public FPHAnswerDisplay AnswerDisplay { get; }
    
    // Methods
    public FPHAnswerDisplay get_AnswerDisplay()
    {
        return (FPHAnswerDisplay)this.answerDisplay;
    }
    private void Start()
    {
        UnityEngine.Events.UnityAction val_15;
        var val_16;
        UnityEngine.Events.UnityAction val_18;
        this.econ = App.GetGameSpecificEcon<FPHEcon>();
        FPHGameplayController val_2 = FPHGameplayController.Instance;
        System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnSolveModeToggled, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHGameplayUIController::OnSolveModeToggled(bool isOn)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_2.OnSolveModeToggled = val_4;
        FPHGameplayController val_5 = FPHGameplayController.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnAnswerSubmitted, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHGameplayUIController::OnAnswerSubmitted(bool isCorrect)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_5.OnAnswerSubmitted = val_7;
        System.Delegate val_10 = System.Delegate.Combine(a:  val_8.OnOutOfTokens, b:  new System.Action(object:  this, method:  System.Void FPHGameplayUIController::OnOutOfTokens()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_13;
        }
        
        }
        
        val_8.OnOutOfTokens = val_10;
        WGWindowManager val_11 = MonoSingleton<WGWindowManager>.Instance;
        FPHGameplayController.Instance.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHGameplayUIController::ToggleTopUI()));
        UnityEngine.Events.UnityAction val_13 = null;
        val_15 = val_13;
        val_13 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHGameplayUIController::OnButtonSolveClicked());
        this.buttonSolve.m_OnClick.AddListener(call:  val_13);
        val_16 = null;
        val_16 = null;
        val_18 = FPHGameplayUIController.<>c.<>9__25_0;
        if(val_18 == null)
        {
                UnityEngine.Events.UnityAction val_14 = null;
            val_18 = val_14;
            val_14 = new UnityEngine.Events.UnityAction(object:  FPHGameplayUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FPHGameplayUIController.<>c::<Start>b__25_0());
            FPHGameplayUIController.<>c.<>9__25_0 = val_18;
        }
        
        this.buttonExitSolve.m_OnClick.AddListener(call:  val_14);
        return;
        label_13:
    }
    public void StartGameplay(FPHGameplayState newState)
    {
        this.econ = App.GetGameSpecificEcon<FPHEcon>();
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.music.Play(type:  1, trackIndex:  0);
        if((FPHGameplayController.Instance & 1) != 0)
        {
                this.ShowTutorial(newState:  newState);
            return;
        }
        
        this.tutorialText.gameObject.SetActive(value:  false);
        this.keyBoard.UpdateKeyboard(state:  newState);
        this.answerDisplay.Setup(state:  newState);
        this.tokenDisplay.Setup(initial:  newState.<tokensRemaining>k__BackingField);
        this.ToggleTopUI();
        goto typeof(FPHPowerupButton).__il2cppRuntimeField_1A0;
    }
    public void UpdateGameplayState(FPHGameplayState updatedState)
    {
        this.keyBoard.UpdateKeyboard(state:  updatedState);
        this.answerDisplay.UpdateState(state:  updatedState);
        this.tokenDisplay.UpdateState(state:  updatedState);
    }
    public void UpdateTutorialText(string text)
    {
        this.tutorialText.gameObject.SetActive(value:  true);
    }
    public void ShowSolveButtonTutorial()
    {
        this.tutorialText.gameObject.SetActive(value:  false);
        this.freeGemsButton.gameObject.SetActive(value:  false);
        this.buttonPowerupHint.gameObject.SetActive(value:  false);
        this.solveRowCanvasGroup.interactable = true;
        this.solveRowCanvasGroup.alpha = 1f;
        this.solveButtonTutorial.SetActive(value:  true);
    }
    private void ShowTutorial(FPHGameplayState newState)
    {
        string val_1 = Localization.Localize(key:  "how_to_play_upper", defaultValue:  "HOW TO PLAY", useSingularKey:  false);
        this.banner.SetActive(value:  false);
        this.keyBoard.UpdateKeyboard(state:  newState);
        this.answerDisplay.Setup(state:  newState);
        this.tokenDisplay.Setup(initial:  newState.<tokensRemaining>k__BackingField);
        this.solveRowCanvasGroup.alpha = 0f;
        this.solveRowCanvasGroup.interactable = false;
        if((FPHGameplayController.Instance & 1) != 0)
        {
                this.topBarCanvasGroup.alpha = 0f;
            this.topBarButtonsGroup.alpha = 0f;
            this.topBarCanvasGroup.interactable = false;
            this.topBarButtonsGroup.interactable = false;
            return;
        }
        
        if((FPHGameplayController.Instance & 1) == 0)
        {
                return;
        }
        
        this.topBarButtonsGroup.interactable = false;
        this.topBarButtonsGroup.alpha = 0f;
        this.bannerText = Localization.Localize(key:  "FPH_FTUX2_ln2", defaultValue:  "Consonants cost {0}. Vowels cost {1}.", useSingularKey:  false);
        this.UpdateTutorialText(text:  System.String.Format(format:  "{0}\n{1}", arg0:  System.String.Format(format:  Localization.Localize(key:  "FPH_FTUX2_ln1", defaultValue:  "Begin each level with {0} Tokens.", useSingularKey:  false), arg0:  this.econ.defaultTokens), arg1:  System.String.Format(format:  this.bannerText, arg0:  this.econ.consonantCost, arg1:  this.econ.vowelCost)));
    }
    private void ToggleTopUI()
    {
        var val_14;
        this.eventsButton.gameObject.SetActive(value:  WordGameEventsController.EventsEnabled);
        UnityEngine.GameObject val_4 = this.removeAdsButton.gameObject;
        if(App.Player.RemovedAds == true)
        {
            goto label_9;
        }
        
        GameBehavior val_7 = App.getBehavior;
        if((val_7.<metaGameBehavior>k__BackingField) >= 2)
        {
            goto label_14;
        }
        
        label_9:
        val_14 = 0;
        if(val_4 != null)
        {
            goto label_15;
        }
        
        label_14:
        val_14 = 0;
        label_15:
        val_4.SetActive(value:  AdsManager.ShowAdsControlButtons(fromSettings:  false));
        GameBehavior val_11 = App.getBehavior;
        FPHEcon val_12 = App.GetGameSpecificEcon<FPHEcon>();
        int val_14 = val_12.powerupHintUnlockLevel;
        val_14 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_11.<metaGameBehavior>k__BackingField, knobValue:  val_14);
        this.buttonPowerupHint.gameObject.SetActive(value:  val_14);
    }
    private void OnButtonSolveClicked()
    {
        var val_7;
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        val_7 = null;
        if((val_1.<IsSolveModeOn>k__BackingField) != false)
        {
                FPHGameplayController val_2 = FPHGameplayController.Instance;
        }
        else
        {
                FPHGameplayController.Instance.SolveModeEnter(resetAnyUnconfirmedSlots:  false);
        }
    
    }
    private void OnAnswerSubmitted(bool isCorrect)
    {
        .isCorrect = isCorrect;
        this.topBarCanvasGroup.blocksRaycasts = false;
        if(((FPHGameplayUIController.<>c__DisplayClass33_0)[1152921515955183024].isCorrect) != false)
        {
                WGAudioController val_3 = MonoSingleton<WGAudioController>.Instance;
            val_3.sound.PlayGameSpecificSound(id:  "CorrectAnswer", clipIndex:  0);
            this.answerDisplay.DoLevelCompleteAnimation();
            DG.Tweening.Tween val_5 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.55f, callback:  new DG.Tweening.TweenCallback(object:  new FPHGameplayUIController.<>c__DisplayClass33_0(), method:  System.Void FPHGameplayUIController.<>c__DisplayClass33_0::<OnAnswerSubmitted>b__0()), ignoreTimeScale:  true);
            return;
        }
        
        FPHGameplayController val_6 = FPHGameplayController.Instance;
        goto typeof(FPHGameplayController).__il2cppRuntimeField_1D0;
    }
    public void OnIncorrectAnswerSubmitted()
    {
        this.solveRowCanvasGroup.interactable = false;
        this.topBarCanvasGroup.interactable = false;
        this.answerDisplay.DoLevelFailAnimation();
        this.incorrectGuessDisplay.Show();
    }
    private void OnOutOfTokens()
    {
        if((FPHGameplayController.Instance & 1) != 0)
        {
                this.ShowSolveButtonTutorial();
            return;
        }
        
        this.tokenDisplay.ShowOutOfTokens();
        if(this.solveButtonHighlightTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.solveButtonHighlightTween, complete:  false);
        }
        
        UnityEngine.Color val_2 = this.ootSolveButtonHighlight.color;
        this.ootSolveButtonHighlight.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = 0f};
        this.ootSolveButtonHighlight.gameObject.SetActive(value:  true);
        DG.Tweening.Sequence val_4 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  val_4, loops:  0, loopType:  0);
        DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.ootSolveButtonHighlight, endValue:  0.35f, duration:  0.85f));
        DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.ootSolveButtonHighlight, endValue:  0f, duration:  0.85f));
        this.solveButtonHighlightTween = val_4;
    }
    public void AbortLevel()
    {
        var val_12;
        System.Func<System.Boolean> val_14;
        var val_15;
        var val_16;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        val_5[1] = true;
        string[] val_6 = new string[2];
        val_6[0] = Localization.Localize(key:  "yes_upper", defaultValue:  "YES", useSingularKey:  false);
        val_6[1] = Localization.Localize(key:  "no_upper", defaultValue:  "NO", useSingularKey:  false);
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_9[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean FPHGameplayUIController::<AbortLevel>b__36_0());
        val_12 = null;
        val_12 = null;
        val_14 = FPHGameplayUIController.<>c.<>9__36_1;
        if(val_14 != null)
        {
            goto label_21;
        }
        
        val_15 = 1152921504614514688;
        System.Func<System.Boolean> val_11 = null;
        val_14 = val_11;
        val_11 = new System.Func<System.Boolean>(object:  FPHGameplayUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean FPHGameplayUIController.<>c::<AbortLevel>b__36_1());
        FPHGameplayUIController.<>c.<>9__36_1 = val_14;
        if(val_14 == null)
        {
            goto label_25;
        }
        
        label_21:
        label_25:
        val_9[1] = val_14;
        val_16 = null;
        val_16 = null;
        val_1.<metaGameBehavior>k__BackingField.SetupMessage(titleTxt:  Localization.Localize(key:  "are_you_sure", defaultValue:  "Are You Sure?", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "fph_quit_popup_body", defaultValue:  "Are you sure you want to abandon your progress?", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public void ShowLevelFail(string failReason)
    {
        GoldenApplesManager val_1 = MonoSingleton<GoldenApplesManager>.Instance;
        FPHGameplayController val_2 = FPHGameplayController.Instance;
        FPHGameplayController.Instance.TrackLevelComplete(isSuccess:  false, failReason:  failReason);
        FPHGameplayController val_4 = FPHGameplayController.Instance;
        this.levelFailDisplay.Show();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnStarsUpdated");
    }
    public void GuessAgain()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        int val_3 = val_1.currentGame.retryAttempts;
        val_3 = val_3 + 1;
        val_1.currentGame.retryAttempts = val_3;
        this.topBarCanvasGroup.blocksRaycasts = true;
        this.incorrectGuessDisplay.Hide();
        this.solveRowCanvasGroup.interactable = true;
        this.topBarCanvasGroup.interactable = true;
        FPHGameplayController.Instance.ResetAnyUnconfirmedLetters();
    }
    private void OnSolveModeToggled(bool isOn)
    {
        UnityEngine.Transform[] val_16;
        if(isOn != false)
        {
                this.buttonExitSolve.gameObject.SetActive(value:  true);
            MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
            MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
            UnityEngine.Color val_5 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.75f);
            System.Nullable<UnityEngine.Color> val_6 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
            MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
            UnityEngine.Transform[] val_8 = new UnityEngine.Transform[4];
            val_16 = val_8;
            val_16[0] = this.answerDisplay.transform;
            val_16[1] = this.keyBoard.transform;
            val_16[2] = this.buttonSolve.transform;
            this = this.buttonExitSolve.transform;
            val_16[3] = this;
            MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_8);
            return;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0f);
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        this.buttonExitSolve.gameObject.SetActive(value:  false);
    }
    public FPHGameplayUIController()
    {
    
    }
    private bool <AbortLevel>b__36_0()
    {
        this.ShowLevelFail(failReason:  "Quit");
        return true;
    }

}

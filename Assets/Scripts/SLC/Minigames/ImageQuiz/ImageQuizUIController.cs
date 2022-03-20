using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizUIController : MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizUIController>
    {
        // Fields
        private UnityEngine.CanvasGroup gameplayUIGroup;
        private SLC.Minigames.ImageQuiz.ImageQuizClueDisplay clueImageDisplay;
        private SLC.Minigames.ImageQuiz.ImageQuizDisplayWord wordInputDisplay;
        private SLC.Minigames.ImageQuiz.ImageQuizLetterButtonGrid letterButtonGrid;
        private UnityEngine.UI.Button hintButton;
        private UnityEngine.UI.Text hintCostLabel;
        private SLC.Minigames.MinigamesCheckpointSlider checkpointSlider;
        private SLC.Minigames.ImageQuiz.ImageQuizLoadingIndicator loadingIndicator;
        private UnityEngine.GameObject pauseOverlay;
        private UnityEngine.UI.Button pauseMenuButtonQuit;
        private UnityEngine.UI.Button pauseMenuButtonResume;
        private UnityEngine.GameObject ftuxMessageBlurb;
        private SLC.Minigames.ImageQuiz.ImageQuizFTUXPointer ftuxPointerPrefab;
        private SLC.Minigames.ImageQuiz.ImageQuizFTUXPointer ftuxPointer;
        private bool <IsGameInputAllowed>k__BackingField;
        private int previousFTUXStep;
        private DG.Tweening.Tween ftuxPointerShowTween;
        
        // Properties
        public SLC.Minigames.ImageQuiz.ImageQuizDisplayWord WordInputDisplay { get; }
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButtonGrid LetterButtonGrid { get; }
        public bool IsGameInputAllowed { get; set; }
        
        // Methods
        public SLC.Minigames.ImageQuiz.ImageQuizDisplayWord get_WordInputDisplay()
        {
            return (SLC.Minigames.ImageQuiz.ImageQuizDisplayWord)this.wordInputDisplay;
        }
        public SLC.Minigames.ImageQuiz.ImageQuizLetterButtonGrid get_LetterButtonGrid()
        {
            return (SLC.Minigames.ImageQuiz.ImageQuizLetterButtonGrid)this.letterButtonGrid;
        }
        public bool get_IsGameInputAllowed()
        {
            return (bool)this.<IsGameInputAllowed>k__BackingField;
        }
        private void set_IsGameInputAllowed(bool value)
        {
            this.<IsGameInputAllowed>k__BackingField = value;
        }
        public override void InitMonoSingleton()
        {
            SLC.Minigames.ImageQuiz.ImageQuizDataManager val_1 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnDataBegin, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameDataLoadBegin()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_1.OnDataBegin = val_3;
            SLC.Minigames.ImageQuiz.ImageQuizDataManager val_4 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnDataLoaded, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameDataLoadComplete(bool isSuccess)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_4.OnDataLoaded = val_6;
            twelvegigs.Autopilot.AutopilotManager val_7 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_7.<aButtons>k__BackingField, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameBegin()));
            if(val_9 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_7.<aButtons>k__BackingField = val_9;
            twelvegigs.Autopilot.AutopilotManager val_10 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            System.Delegate val_12 = System.Delegate.Combine(a:  val_10.instructions, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnLevelComplete()));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_10.instructions = val_12;
            twelvegigs.Autopilot.AutopilotManager val_13 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            System.Delegate val_15 = System.Delegate.Combine(a:  val_13.initialized, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameEnd()));
            if(val_15 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_13.initialized = val_15;
            SLC.Minigames.MinigameManager val_16 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_18 = System.Delegate.Combine(a:  val_16.OnCheckpointRankUpContinue, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::DisplayLevel()));
            if(val_18 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_16.OnCheckpointRankUpContinue = val_18;
            SLC.Minigames.MinigameManager val_19 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_21 = System.Delegate.Combine(a:  val_19.OnContinueMinigame, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameContinue()));
            if(val_21 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_19.OnContinueMinigame = val_21;
            SLC.Minigames.MinigameManager val_22 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_24 = System.Delegate.Combine(a:  val_22.OnPauseClicked, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnPauseClicked()));
            if(val_24 != null)
            {
                    if(null != null)
            {
                goto label_30;
            }
            
            }
            
            val_22.OnPauseClicked = val_24;
            SLC.Minigames.MinigameManager val_25 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_25.TogglePopupWindow = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::TogglePopup(bool windowShowing));
            this.hintButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnHintButtonClicked()));
            this.pauseMenuButtonResume.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnResumeClicked()));
            this.pauseMenuButtonQuit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnQuitClicked()));
            return;
            label_30:
        }
        private void OnDestroy()
        {
            var val_34;
            System.Action<System.Boolean> val_35;
            val_34 = 1152921504765632512;
            if((MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance) != 0)
            {
                    SLC.Minigames.ImageQuiz.ImageQuizDataManager val_3 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
                System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnDataBegin, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameDataLoadBegin()));
                if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
                val_3.OnDataBegin = val_5;
                SLC.Minigames.ImageQuiz.ImageQuizDataManager val_6 = MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance;
                System.Delegate val_8 = System.Delegate.Remove(source:  val_6.OnDataLoaded, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameDataLoadComplete(bool isSuccess)));
                if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
                val_6.OnDataLoaded = val_8;
            }
            
            if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance) != 0)
            {
                    twelvegigs.Autopilot.AutopilotManager val_11 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
                System.Delegate val_13 = System.Delegate.Remove(source:  val_11.<aButtons>k__BackingField, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameBegin()));
                if(val_13 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
                val_11.<aButtons>k__BackingField = val_13;
                twelvegigs.Autopilot.AutopilotManager val_14 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
                System.Delegate val_16 = System.Delegate.Remove(source:  val_14.instructions, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnLevelComplete()));
                if(val_16 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
                val_14.instructions = val_16;
                twelvegigs.Autopilot.AutopilotManager val_17 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
                System.Delegate val_19 = System.Delegate.Remove(source:  val_17.initialized, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameEnd()));
                if(val_19 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
                val_17.initialized = val_19;
            }
            
            val_35 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) == 0)
            {
                    return;
            }
            
            SLC.Minigames.MinigameManager val_22 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_24 = System.Delegate.Remove(source:  val_22.OnCheckpointRankUpContinue, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::DisplayLevel()));
            if(val_24 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
            val_22.OnCheckpointRankUpContinue = val_24;
            SLC.Minigames.MinigameManager val_25 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_27 = System.Delegate.Remove(source:  val_25.OnContinueMinigame, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnMinigameContinue()));
            if(val_27 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
            val_25.OnContinueMinigame = val_27;
            SLC.Minigames.MinigameManager val_28 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Delegate val_30 = System.Delegate.Remove(source:  val_28.OnPauseClicked, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::OnPauseClicked()));
            if(val_30 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
            val_28.OnPauseClicked = val_30;
            SLC.Minigames.MinigameManager val_31 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_35 = val_31.TogglePopupWindow;
            val_34 = 1152921504614248448;
            System.Delegate val_33 = System.Delegate.Remove(source:  val_35, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::TogglePopup(bool windowShowing)));
            if(val_33 != null)
            {
                    if(null != null)
            {
                goto label_48;
            }
            
            }
            
            val_31.TogglePopupWindow = val_33;
            return;
            label_48:
        }
        private void Start()
        {
            decimal val_1 = SLC.Minigames.ImageQuiz.ImageQuizEcon.HintCost;
            GameEcon val_2 = App.getGameEcon;
            string val_3 = val_1.flags.ToString(format:  val_2.numberFormatInt);
            this.checkpointSlider.UpdateUI();
        }
        private void OnMinigameDataLoadBegin()
        {
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if((public static SLC.Minigames.ImageQuiz.ImageQuizMinigameManager MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizMinigameManager>::get_Instance()) != 0)
            {
                    return;
            }
            
            this.pauseOverlay.SetActive(value:  false);
            this.loadingIndicator.Show(isVisible:  true);
            this.gameplayUIGroup.alpha = 0f;
        }
        private void OnMinigameDataLoadComplete(bool isSuccess)
        {
            this.loadingIndicator.Show(isVisible:  false);
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            bool val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.HasLevelData();
            if(val_3 != false)
            {
                    return;
            }
            
            val_3.ShowLoadErrorMessage();
        }
        private void ShowLoadErrorMessage()
        {
            int val_8;
            var val_9;
            System.Func<System.Boolean> val_11;
            if((MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance) == 0)
            {
                    return;
            }
            
            bool[] val_4 = new bool[2];
            val_4[0] = true;
            string[] val_5 = new string[2];
            val_8 = val_5.Length;
            val_5[0] = "HOME";
            val_8 = val_5.Length;
            val_5[1] = "NULL";
            System.Func<System.Boolean>[] val_6 = new System.Func<System.Boolean>[2];
            val_9 = null;
            val_9 = null;
            val_11 = ImageQuizUIController.<>c.<>9__27_0;
            if(val_11 == null)
            {
                    System.Func<System.Boolean> val_7 = null;
                val_11 = val_7;
                val_7 = new System.Func<System.Boolean>(object:  ImageQuizUIController.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean ImageQuizUIController.<>c::<ShowLoadErrorMessage>b__27_0());
                ImageQuizUIController.<>c.<>9__27_0 = val_11;
            }
            
            val_6[0] = val_11;
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowMessage(titleTxt:  "ERROR", messageTxt:  "Failed to load new level.", shownButtons:  val_4, buttonTexts:  val_5, showClose:  false, buttonCallbacks:  val_6);
        }
        private void OnMinigameBegin()
        {
            this.DisplayLevel();
        }
        private void OnMinigameContinue()
        {
            MonoSingleton<SLC.Minigames.ImageQuiz.ImageQuizDataManager>.Instance.ConsumeCurrentLevel();
            this.pauseOverlay.SetActive(value:  false);
            this.pauseOverlay.PlayMinigame();
        }
        private void OnLevelComplete()
        {
            this.<IsGameInputAllowed>k__BackingField = false;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnLevelCompleteCoroutine());
        }
        private System.Collections.IEnumerator OnLevelCompleteCoroutine()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageQuizUIController.<OnLevelCompleteCoroutine>d__31();
        }
        private void OnMinigameEnd()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnMinigameEndCoroutine());
        }
        private System.Collections.IEnumerator OnMinigameEndCoroutine()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ImageQuizUIController.<OnMinigameEndCoroutine>d__33();
        }
        private void OnHintButtonClicked()
        {
            var val_14;
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if(1152921517483448192 != 1)
            {
                    return;
            }
            
            if((this.<IsGameInputAllowed>k__BackingField) == false)
            {
                    return;
            }
            
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            Player val_3 = App.Player;
            decimal val_4 = SLC.Minigames.ImageQuiz.ImageQuizEcon.HintCost;
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid})) != false)
            {
                    Player val_6 = App.Player;
                int val_14 = val_6.properties.MGHintsCount;
                val_14 = val_14 + 1;
                val_6.properties.MGHintsCount = val_14;
                decimal val_7 = SLC.Minigames.ImageQuiz.ImageQuizEcon.HintCost;
                bool val_11 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, source:  System.String.Format(format:  "MG {0} HINT", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), externalParams:  0, animated:  false);
                this.wordInputDisplay.GiveLetterHint();
                return;
            }
            
            val_14 = null;
            val_14 = null;
            PurchaseProxy.currentPurchasePoint = 24;
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  0);
        }
        private void OnPauseClicked()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.pauseOverlay.SetActive(value:  true);
        }
        private void OnResumeClicked()
        {
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            this.pauseOverlay.SetActive(value:  false);
        }
        private void OnQuitClicked()
        {
            this.gameplayUIGroup.alpha = 0f;
            this.pauseOverlay.SetActive(value:  false);
            MonoSingleton<MinigameAudioController>.Instance.PlayButtonSound(clipIndex:  0, volumeScale:  1f);
            MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance.ShowGameOver();
        }
        private void TogglePopup(bool windowShowing)
        {
            if(this.gameplayUIGroup != null)
            {
                    this.gameplayUIGroup.alpha = (windowShowing != true) ? 0f : 1f;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void PlayMinigame()
        {
            if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.HasLevelData()) != false)
            {
                    MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.BeginGame();
                return;
            }
            
            UnityEngine.Debug.LogError(message:  "Quiz minigame data not ready yet. Aborting play.");
        }
        private void DisplayLevel()
        {
            this.clueImageDisplay.ToggleResultOverlay(isVisible:  false, isCorrect:  true);
            this.wordInputDisplay.Initialize(_numberOfLetters:  val_2.word.m_stringLength);
            this.letterButtonGrid.Initialize(letters:  MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCurrentQuizLevel().LetterPool);
            this.clueImageDisplay.UpdateClueDisplay();
            this.checkpointSlider.UpdateUI();
            this.gameplayUIGroup.alpha = 1f;
            this.<IsGameInputAllowed>k__BackingField = true;
            twelvegigs.Autopilot.AutopilotManager val_5 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            this.hintButton.gameObject.SetActive(value:  ((val_5.<AllowPurchases>k__BackingField) > false) ? 1 : 0);
            twelvegigs.Autopilot.AutopilotManager val_7 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            if((val_7.<AllowPurchases>k__BackingField) > false)
            {
                    return;
            }
            
            this.StartFTUX();
        }
        private void StartFTUX()
        {
            if(this.ftuxPointer != 0)
            {
                goto label_3;
            }
            
            SLC.Minigames.ImageQuiz.ImageQuizFTUXPointer val_3 = UnityEngine.Object.Instantiate<SLC.Minigames.ImageQuiz.ImageQuizFTUXPointer>(original:  this.ftuxPointerPrefab, parent:  this.gameplayUIGroup.transform);
            this.ftuxPointer = val_3;
            if(val_3 != null)
            {
                goto label_7;
            }
            
            label_3:
            label_7:
            this.ftuxPointer.gameObject.SetActive(value:  false);
            System.Delegate val_6 = System.Delegate.Combine(a:  this.wordInputDisplay.OnInputProcessed, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::ShowFTUXStep()));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            this.wordInputDisplay.OnInputProcessed = val_6;
            this.previousFTUXStep = 0;
            DG.Tweening.Tween val_8 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::ShowFTUXStep()), ignoreTimeScale:  true);
            return;
            label_13:
        }
        public void EndFTUX()
        {
            System.Delegate val_2 = System.Delegate.Remove(source:  this.wordInputDisplay.OnInputProcessed, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizUIController::ShowFTUXStep()));
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_3;
            }
            
            }
            
            this.wordInputDisplay.OnInputProcessed = val_2;
            this.ftuxMessageBlurb.gameObject.SetActive(value:  false);
            this.ftuxPointer.gameObject.SetActive(value:  false);
            if(this.ftuxPointer.pointerSeq == null)
            {
                    return;
            }
            
            DG.Tweening.TweenExtensions.Kill(t:  this.ftuxPointer.pointerSeq, complete:  false);
            return;
            label_3:
        }
        private void ShowFTUXStep()
        {
            if(this.ftuxPointerShowTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.ftuxPointerShowTween, complete:  false);
            }
            
            this.ftuxMessageBlurb.gameObject.SetActive(value:  true);
            if(this.previousFTUXStep == this.wordInputDisplay.caretPosition)
            {
                    this.EndFTUX();
                return;
            }
            
            this.FtuxHighlightAction(letterIndex:  this.wordInputDisplay.caretPosition);
            this.previousFTUXStep = this.wordInputDisplay.caretPosition;
        }
        private void FtuxHighlightAction(int letterIndex)
        {
            int val_13;
            SLC.Minigames.ImageQuiz.ImageQuizUIController val_14;
            val_13 = letterIndex;
            val_14 = this;
            .<>4__this = val_14;
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCurrentQuizLevel();
            SLC.Minigames.ImageQuiz.ImageQuizLetterButton val_6 = this.letterButtonGrid.GetButton(letter:  val_3.word.Chars[val_13].ToString(), getOnlyUnusedButtons:  true);
            .buttonToHighlight = val_6;
            val_6.SetHighlight(state:  1);
            (ImageQuizUIController.<>c__DisplayClass46_0)[1152921519961950352].buttonToHighlight.button.interactable = true;
            if(this.letterButtonGrid.letterButtons.Length >= 1)
            {
                    var val_14 = 0;
                do
            {
                if(this.letterButtonGrid.letterButtons[val_14].GetInstanceID() != ((ImageQuizUIController.<>c__DisplayClass46_0)[1152921519961950352].buttonToHighlight.GetInstanceID()))
            {
                    this.letterButtonGrid.letterButtons[0x0] + 32 + 24.interactable = false;
            }
            
                val_14 = val_14 + 1;
            }
            while(val_14 < this.letterButtonGrid.letterButtons.Length);
            
            }
            
            this.wordInputDisplay.<AllowErase>k__BackingField = false;
            UnityEngine.GameObject val_9 = this.ftuxPointer.gameObject;
            if(val_13 != 0)
            {
                    val_9.SetActive(value:  false);
                DG.Tweening.TweenCallback val_10 = null;
                val_13 = val_10;
                val_10 = new DG.Tweening.TweenCallback(object:  new ImageQuizUIController.<>c__DisplayClass46_0(), method:  System.Void ImageQuizUIController.<>c__DisplayClass46_0::<FtuxHighlightAction>b__0());
                this.ftuxPointerShowTween = DG.Tweening.DOVirtual.DelayedCall(delay:  3f, callback:  val_10, ignoreTimeScale:  true);
                return;
            }
            
            val_9.SetActive(value:  true);
            val_14 = this.ftuxPointer;
            val_14.PointAt(targetObj:  (ImageQuizUIController.<>c__DisplayClass46_0)[1152921519961950352].buttonToHighlight.gameObject, flipPointerX:  false, flipPointerY:  false);
        }
        public ImageQuizUIController()
        {
            this.previousFTUXStep = 0;
        }
    
    }

}

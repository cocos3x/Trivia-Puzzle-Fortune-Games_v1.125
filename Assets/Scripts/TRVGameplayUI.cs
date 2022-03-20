using UnityEngine;
public class TRVGameplayUI : MonoSingleton<TRVGameplayUI>
{
    // Fields
    private System.Collections.Generic.List<TRVQuestionButton> questionButtons;
    private TRVTimerDisplay timer;
    private TRVCountdownOverlay countDown;
    private UnityEngine.CanvasGroup gameplayCanvasGroup;
    private UnityEngine.UI.Text questionText;
    private UnityEngine.GameObject questionImageGroup;
    private UnityEngine.UI.Text questionImageText;
    private UnityEngine.UI.Image questionImage;
    private UnityEngine.UI.Text categoryNameText;
    private TRVHintButton hintButton;
    private TRVRerollQuestionButton rerollButton;
    private TRVAskExpertButton expertButton;
    private UnityEngine.UI.HorizontalLayoutGroup feedbackGroup;
    private TRVAnswerFeedbackDisplay answerFeedback;
    private TRVCategoryRankDisplay rankDisplay;
    private TRVFlyout myFlyout;
    private CurrencyStatViewInstantiator streakStatView;
    private TRVStreakParticle streakParticle;
    private int countdownTime;
    private int quizTime;
    private TRVQuizProgress currentLevelData;
    
    // Properties
    public TRVTimerDisplay getTimer { get; }
    public System.Collections.Generic.List<TRVPowerupButton> getPowerupButtons { get; }
    
    // Methods
    public TRVTimerDisplay get_getTimer()
    {
        return (TRVTimerDisplay)this.timer;
    }
    public System.Collections.Generic.List<TRVPowerupButton> get_getPowerupButtons()
    {
        System.Collections.Generic.List<TRVPowerupButton> val_1 = new System.Collections.Generic.List<TRVPowerupButton>();
        val_1.Add(item:  this.hintButton);
        val_1.Add(item:  this.rerollButton);
        val_1.Add(item:  this.expertButton);
        return val_1;
    }
    private void Start()
    {
        if(this.gameplayCanvasGroup != null)
        {
                this.gameplayCanvasGroup.alpha = 0f;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void StartGameplay(TRVQuizProgress incData)
    {
        QuestionData val_11;
        UnityEngine.UI.Text val_12;
        string val_13;
        System.Collections.Generic.List<System.String> val_1 = 28387;
        val_1 = new System.Collections.Generic.List<System.String>();
        this.currentLevelData = incData;
        bool val_2 = UnityEngine.Object.op_Inequality(x:  incData.currentQuestionData.imageSp, y:  0);
        if(val_2 == false)
        {
            goto label_5;
        }
        
        this.questionImage.sprite = incData.currentQuestionData.imageSp;
        val_11 = incData.currentQuestionData;
        val_12 = this.questionImageText;
        if(val_12 != null)
        {
            goto label_9;
        }
        
        label_5:
        val_11 = incData.currentQuestionData;
        val_12 = this.questionText;
        label_9:
        this.questionImageGroup.SetActive(value:  val_2);
        this.questionText.gameObject.SetActive(value:  (~val_2) & 1);
        val_1.AddRange(collection:  incData.currentQuestionData.<incorrectAnswers>k__BackingField);
        val_1.Add(item:  incData.currentQuestionData.<answer>k__BackingField);
        PluginExtension.Shuffle<System.String>(list:  val_1, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        this.answerFeedback.Hide();
        this.rankDisplay.Hide();
        val_13 = incData.quizCategory;
        if((val_13.Contains(value:  "FTUX")) != false)
        {
                val_13 = val_13.Replace(oldValue:  "FTUX", newValue:  "");
        }
        
        var val_12 = 4;
        label_34:
        var val_8 = val_12 - 4;
        if(val_8 >= incData.currentGameplayState.activeButtons)
        {
            goto label_26;
        }
        
        if(incData.currentGameplayState.activeButtons <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(0 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.questionButtons.SetupButton(answerToDisplay:  mem[4398046511137]);
        if(1 <= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        mem[4398046511137].SetButtonState(state:  false, immediate:  true);
        val_12 = val_12 + 1;
        if(incData.currentGameplayState != null)
        {
            goto label_34;
        }
        
        label_26:
        this.timer.enabled = false;
        MonoSingleton<TRVScreenBlocker>.Instance.SetActive(active:  true);
        UnityEngine.Coroutine val_11 = this.StartCoroutine(routine:  this.StartGame(incData:  1));
    }
    private System.Collections.IEnumerator StartGame(TRVQuizProgress incData)
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVGameplayUI.<StartGame>d__27();
    }
    private System.Collections.IEnumerator checkLevelFlyout()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVGameplayUI.<checkLevelFlyout>d__28();
    }
    public void UpdateGameState(TRVQuizProgress incData)
    {
        .incData = incData;
        var val_30 = 1;
        label_37:
        string val_26 = 0;
        bool val_3 = System.String.IsNullOrEmpty(value:  incData.currentGameplayState.selectedAnswer);
        if((((this.questionButtons > 0) ? 1 : 0) & 1) == 0)
        {
            goto label_5;
        }
        
        var val_4 = val_30 - 1;
        if(incData.currentGameplayState <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(val_3 != false)
        {
                TRVGameplayState val_25 = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState;
            if((X9 + (val_4 << 3)) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_25 = val_25 + (((long)(int)((1 - 1))) << 3);
            val_26 = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.activeButtons.Contains(item:  val_26);
            (X9 + ((1 - 1)) << 3) + 32.SetButtonState(state:  val_26, immediate:  false);
        }
        else
        {
                QuestionData val_28 = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData;
            (X9 + ((1 - 1)) << 3) + 32.SetAnswerSelectedState(correctAnswer:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData.<answer>k__BackingField, selectedAnswer:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.selectedAnswer);
        }
        
        TRVGameplayState val_27 = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState;
        if(val_28 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_27 = val_27 + (((long)(int)((1 - 1))) << 3);
        if(((TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.expertHintedAnswers.ContainsKey(key:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData.<answer>k__BackingField)) != false)
        {
                if((((TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState + ((long)(int)((1 - 1))) << 3).selectedAnswer) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            TRVGameplayState val_29 = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState;
            val_28 = val_28 + (((long)(int)((1 - 1))) << 3);
            if(W10 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_29 = val_29 + (((long)(int)((1 - 1))) << 3);
            ((TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData + ((long)(int)((1 - 1))) << 3).<difficulty>k__BackingField.DisplayExpert(exp:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.expertHintedAnswers.Item[(TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData.<answer>k__BackingField]);
        }
        
        var val_9 = (val_30 < this.questionButtons) ? 1 : 0;
        val_30 = val_30 + 1;
        if(((TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData) != null)
        {
            goto label_37;
        }
        
        label_5:
        if(val_3 != false)
        {
                this.timer.UpdateTime(incStartTime:  new System.DateTime() {dateData = (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.quizStartTime}, secondsToCompleteQuiz:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.quizDuration);
            return;
        }
        
        this.FadeOutPowerups();
        bool val_10 = System.String.op_Equality(a:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentGameplayState.selectedAnswer, b:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.currentQuestionData.<answer>k__BackingField);
        if((val_10 == false) || ((TRVCategoryRankController.CanRankUpCategory(subCategory:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.quizCategory)) == false))
        {
            goto label_48;
        }
        
        this.rankDisplay.DisplayCategoryRank(categorySp:  MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.quizCategory), startProgress:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.categoryRankProgress.lastRankProgress, endProgress:  (TRVGameplayUI.<>c__DisplayClass29_0)[1152921517262902464].incData.categoryRankProgress.currentRankProgress);
        TRVQuestionButton val_15 = System.Linq.Enumerable.FirstOrDefault<TRVQuestionButton>(source:  this.questionButtons, predicate:  new System.Func<TRVQuestionButton, System.Boolean>(object:  new TRVGameplayUI.<>c__DisplayClass29_0(), method:  System.Boolean TRVGameplayUI.<>c__DisplayClass29_0::<UpdateGameState>b__0(TRVQuestionButton x)));
        if(val_15 == 0)
        {
            goto label_68;
        }
        
        UnityEngine.Transform val_17 = this.streakParticle.transform;
        UnityEngine.Vector3 val_19 = val_15.transform.position;
        val_17.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        UnityEngine.Vector3 val_22 = val_17.AppleIcon.transform.position;
        this.streakParticle.PlayParticles(destinationPosition:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z}, particleCount:  1, animateStatView:  true);
        goto label_68;
        label_48:
        this.rankDisplay.Hide();
        label_68:
        this.answerFeedback.DisplayResult(correct:  val_10);
        MonoSingleton<TRVScreenBlocker>.Instance.SetActive(active:  true);
        this.StopTimer();
    }
    public void HideQuestionButtons()
    {
        List.Enumerator<T> val_1 = this.questionButtons.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.SetButtonState(state:  false, immediate:  false);
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void HideTimer()
    {
        if(this.timer != null)
        {
                this.timer.Setup();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void StopTimer()
    {
        this.timer.OnTick = 0;
        this.timer.StopTimer();
    }
    public void ContinueTimer(float duration)
    {
        if(this.timer == 0)
        {
                return;
        }
        
        if(this.currentLevelData == null)
        {
                return;
        }
        
        System.Delegate val_3 = System.Delegate.Combine(a:  this.timer.OnTick, b:  new System.Action<System.Int32>(object:  this.hintButton, method:  typeof(TRVHintButton).__il2cppRuntimeField_218));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        this.timer.OnTick = val_3;
        System.Delegate val_5 = System.Delegate.Combine(a:  this.timer.OnTick, b:  new System.Action<System.Int32>(object:  this.rerollButton, method:  public System.Void TRVPowerupButton::PlayReminderAnim(int remainingTime)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        this.timer.OnTick = val_5;
        System.Delegate val_7 = System.Delegate.Combine(a:  this.timer.OnTick, b:  new System.Action<System.Int32>(object:  this.expertButton, method:  typeof(TRVAskExpertButton).__il2cppRuntimeField_218));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_16;
        }
        
        }
        
        this.timer.OnTick = val_7;
        System.DateTime val_8 = DateTimeCheat.UtcNow;
        this.currentLevelData.currentGameplayState.quizStartTime = val_8;
        System.DateTime val_9 = DateTimeCheat.UtcNow;
        this.timer.UpdateTime(incStartTime:  new System.DateTime() {dateData = val_9.dateData}, secondsToCompleteQuiz:  duration);
        return;
        label_16:
    }
    public void SetGameplayAlpha(bool visible)
    {
        if(this.gameplayCanvasGroup != null)
        {
                this.gameplayCanvasGroup.alpha = (visible != true) ? 1f : 0f;
            return;
        }
        
        throw new NullReferenceException();
    }
    public void FadeOutPowerups()
    {
        if(this.hintButton.gameObject.activeInHierarchy != false)
        {
                this.hintButton.FadeOut();
        }
        
        if(this.rerollButton.gameObject.activeInHierarchy != false)
        {
                this.rerollButton.FadeOut();
        }
        
        if(this.expertButton.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        this.expertButton.FadeOut();
    }
    public TRVGameplayUI()
    {
        this.countdownTime = 3;
        this.quizTime = 7;
    }

}

using UnityEngine;
private sealed class TRVMainController.<displayAnswerResult>d__66 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public bool correct;
    public TRVMainController <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVMainController.<displayAnswerResult>d__66(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        TRVMainController val_39;
        var val_40;
        var val_41;
        int val_42;
        var val_43;
        val_39 = this.<>4__this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_97;
        }
        
        this.<>1__state = 0;
        MonoSingleton<TRVScreenBlocker>.Instance.SetActive(active:  true);
        val_40 = 1152921504893161472;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != true)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnLevelComplete(levelsProgressed:  this.correct);
        }
        
        if((this.<>4__this.currentGame.countedAnswers) < (this.<>4__this.currentGame.quizLength))
        {
                if(((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) == false) || ((this.<>4__this.currentGame.countedAnswers) != 2))
        {
            goto label_28;
        }
        
        }
        
        val_39.ProcessQuizComplete(success:  true);
        if(this.correct != false)
        {
                if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != true)
        {
                MonoSingleton<WordGameEventsController>.Instance.OnCategoryComplete();
            MonoSingleton<TRVSpecialCategoriesManager>.Instance.OnQuizComplete(quiz:  this.<>4__this.currentGame);
        }
        
        }
        
        label_28:
        val_41 = null;
        val_41 = null;
        UnityEngine.WaitForSeconds val_14 = null;
        val_39 = val_14;
        val_14 = new UnityEngine.WaitForSeconds(seconds:  (TRVMainController.QAHACK_HURRY == false) ? 1.5f : 0.1f);
        val_42 = 1;
        this.<>2__current = val_39;
        this.<>1__state = val_42;
        return (bool)val_42;
        label_1:
        this.<>1__state = 0;
        val_40 = 1152921504893161472;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) == false)
        {
            goto label_41;
        }
        
        GameBehavior val_17 = App.getBehavior;
        val_17.<metaGameBehavior>k__BackingField.Init(reward:  MonoSingleton<TRVQuestionOfTheDayManager>.Instance.GetReward(isBonus:  ((this.<>4__this.currentGame.quizProgressIndex) > 0) ? 1 : 0), isBonus:  ((this.<>4__this.currentGame.quizProgressIndex) > 0) ? 1 : 0);
        goto label_97;
        label_2:
        this.<>1__state = 0;
        MonoSingleton<TRVGameplayUI>.Instance.SetGameplayAlpha(visible:  false);
        MonoSingleton<TRVScreenBlocker>.Instance.SetActive(active:  false);
        if(this.correct == false)
        {
            goto label_60;
        }
        
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_42 = 1;
        return (bool)val_42;
        label_41:
        GameBehavior val_25 = App.getBehavior;
        MonoSingleton<TRVSpecialCategoriesManager>.Instance.OnQuestionComplete(quiz:  this.<>4__this.currentGame);
        goto label_97;
        label_60:
        val_40 = 1152921515677607024;
        TRVDataParser val_28 = MonoSingleton<TRVDataParser>.Instance;
        TRVSubCategoryProgress val_29 = val_28.<playerPersistance>k__BackingField.GetSubCatProgress(subCategory:  this.<>4__this.currentGame.quizCategory);
        int val_39 = val_29.incorrectQuestions;
        val_39 = val_39 + 1;
        val_29.incorrectQuestions = val_39;
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) == false)
        {
            goto label_81;
        }
        
        GameBehavior val_32 = App.getBehavior;
        val_39 = val_32.<metaGameBehavior>k__BackingField;
        val_43 = 1152921517307655648;
        goto label_86;
        label_81:
        TRVDataParser val_33 = MonoSingleton<TRVDataParser>.Instance;
        if((val_33.<playerPersistance>k__BackingField.freeLifeAvailable) == false)
        {
            goto label_91;
        }
        
        val_39.OnExtraLifeClicked();
        GameBehavior val_35 = App.getBehavior;
        val_39 = val_35.<metaGameBehavior>k__BackingField;
        val_39.Init(rewardedPopup:  false, tag:  46);
        goto label_97;
        label_91:
        GameBehavior val_37 = App.getBehavior;
        val_39 = val_37.<metaGameBehavior>k__BackingField;
        val_43 = 1152921517294475856;
        label_86:
        label_97:
        val_42 = 0;
        return (bool)val_42;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}

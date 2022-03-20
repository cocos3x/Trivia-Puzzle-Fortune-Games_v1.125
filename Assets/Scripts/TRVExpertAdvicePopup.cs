using UnityEngine;
public class TRVExpertAdvicePopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image expertImage;
    private UnityEngine.UI.Text expertAdvice;
    private UnityEngine.UI.Button continueButton;
    public System.Action onCloseAction;
    private UnityEngine.UI.Text timerText;
    
    // Methods
    public void Init(TRVExpert exp, TRVExpertOutcomes outcome, bool wasFree)
    {
        string val_18;
        var val_19;
        var val_22;
        var val_23;
        var val_26;
        string val_27;
        string val_28;
        System.Collections.Generic.Dictionary<System.String, TRVExpert> val_29;
        val_22 = wasFree;
        this.expertImage.sprite = exp.mySprite;
        val_23 = 1152921504893161472;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        UnityEngine.Events.UnityAction val_2 = null;
        var val_23 = 1152921517141650896;
        val_2 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertAdvicePopup::OnContinuePress());
        this.continueButton.m_OnClick.AddListener(call:  val_2);
        System.Collections.Generic.List<System.String> val_3 = new System.Collections.Generic.List<System.String>();
        if(outcome == 2)
        {
            goto label_9;
        }
        
        if(outcome == 1)
        {
            goto label_10;
        }
        
        if(outcome != 0)
        {
            goto label_17;
        }
        
        val_3.AddRange(collection:  val_1.currentGame.currentQuestionData.<incorrectAnswers>k__BackingField);
        var val_22 = 1152921509851232320;
        val_3.Add(item:  val_1.currentGame.currentQuestionData.<answer>k__BackingField);
        int val_4 = UnityEngine.Random.Range(min:  0, max:  val_1.currentGame.currentQuestionData.<answer>k__BackingField);
        if(val_22 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_22 = val_22 + (val_4 << 3);
        bool val_5 = val_3.Remove(item:  (1152921509851232320 + (val_4) << 3) + 32);
        string val_7 = System.String.Format(format:  Localization.Localize(key:  "experts_answer_3", defaultValue:  "All I can say is that it is definitely not {0}", useSingularKey:  false), arg0:  (1152921509851232320 + (val_4) << 3) + 32);
        goto label_17;
        label_10:
        System.Collections.Generic.List<System.String> val_8 = new System.Collections.Generic.List<System.String>();
        val_8.Add(item:  val_1.currentGame.currentQuestionData.<answer>k__BackingField);
        int val_9 = UnityEngine.Random.Range(min:  0, max:  val_1.currentGame.currentQuestionData.<answer>k__BackingField);
        if(val_23 <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_23 = val_23 + (val_9 << 3);
        val_8.Add(item:  (1152921517141650896 + (val_9) << 3) + 32);
        PluginExtension.Shuffle<System.String>(list:  val_8, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        if("experts_answer_2" == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if("experts_answer_2" <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        string val_11 = System.String.Format(format:  Localization.Localize(key:  "experts_answer_2", defaultValue:  "I believe it is either {0} or {1}", useSingularKey:  false), arg0:  "Late bound operations cannot be performed on fields with types for which Type.ContainsGenericParameters is true.", arg1:  null);
        val_22 = val_22;
        if(null == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_23 = 1152921504893161472;
        val_3.Add(item:  UnityEngine.UI.Text.__il2cppRuntimeField_byval_arg);
        if(null <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_26 = public System.Void System.Collections.Generic.List<System.String>::Add(System.String item);
        goto label_28;
        label_9:
        string val_13 = System.String.Format(format:  Localization.Localize(key:  "experts_answer_1", defaultValue:  "I am confident the answer is {0}", useSingularKey:  false), arg0:  val_1.currentGame.currentQuestionData.<answer>k__BackingField);
        val_27 = val_1.currentGame.currentQuestionData.<answer>k__BackingField;
        val_26 = public System.Void System.Collections.Generic.List<System.String>::Add(System.String item);
        label_28:
        val_3.Add(item:  val_27);
        label_17:
        TRVGameplayUI val_14 = MonoSingleton<TRVGameplayUI>.Instance;
        string val_15 = val_14.timer.TimeRemainingText();
        TRVMainController val_16 = MonoSingleton<TRVMainController>.Instance;
        List.Enumerator<T> val_17 = val_3.GetEnumerator();
        label_49:
        val_28 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(val_19.MoveNext() == false)
        {
            goto label_42;
        }
        
        if(val_16.currentGame.currentGameplayState == null)
        {
                throw new NullReferenceException();
        }
        
        val_29 = val_16.currentGame.currentGameplayState.expertHintedAnswers;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_28 = val_18;
        val_29 = val_16.currentGame.currentGameplayState.expertHintedAnswers;
        if((val_29.ContainsKey(key:  val_28)) == false)
        {
            goto label_45;
        }
        
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.set_Item(key:  val_18, value:  exp);
        goto label_49;
        label_45:
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.Add(key:  val_18, value:  exp);
        goto label_49;
        label_42:
        val_19.Dispose();
        if(val_22 == false)
        {
                return;
        }
        
        val_16.currentGame.currentGameplayState.freeExpertAnswer = true;
    }
    private void FixedUpdate()
    {
        TRVGameplayUI val_1 = MonoSingleton<TRVGameplayUI>.Instance;
        string val_2 = val_1.timer.TimeRemainingText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnContinuePress()
    {
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        MonoSingleton<TRVGameplayUI>.Instance.UpdateGameState(incData:  val_2.currentGame);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(this.onCloseAction == null)
        {
                return;
        }
        
        this.onCloseAction.Invoke();
    }
    public TRVExpertAdvicePopup()
    {
    
    }

}

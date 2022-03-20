using UnityEngine;
private sealed class TRVLossAversionPopup.<Start>d__17 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLossAversionPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLossAversionPopup.<Start>d__17(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_12;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.SetChestSprite();
        this.<>4__this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this.<>4__this, method:  System.Void TRVLossAversionPopup::OnClickContinue()));
        this.<>4__this.exitQuizButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this.<>4__this, method:  System.Void TRVLossAversionPopup::OnClickNoThanks()));
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        string val_4 = val_3.extraLifeCost.ToString();
        val_12 = 1;
        this.<>4__this.mainGroup.SetActive(value:  true);
        this.<>4__this.streakBrokenGroup.SetActive(value:  false);
        this.<>2__current = 0;
        this.<>1__state = val_12;
        return (bool)val_12;
        label_1:
        this.<>1__state = 0;
        bool val_5 = UnityEngine.Object.op_Inequality(x:  this, y:  0);
        if((val_5 != false) && (val_5 != false))
        {
                val_5.SetTextCrossout();
        }
        
        if(null == 0)
        {
            goto label_25;
        }
        
        if((typeof(TRVStreakStatView).__il2cppRuntimeField_38.GetComponent<WGConnectionlessPopupButton>()) != 0)
        {
                UnityEngine.Object.Destroy(obj:  typeof(TRVStreakStatView).__il2cppRuntimeField_38.GetComponent<WGConnectionlessPopupButton>());
        }
        
        typeof(TRVStreakStatView).__il2cppRuntimeField_38 + 248.RemoveAllListeners();
        typeof(TRVStreakStatView).__il2cppRuntimeField_38 + 248.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this.<>4__this, method:  System.Void TRVLossAversionPopup::OnGemStoreButtonClicked()));
        typeof(TRVStreakStatView).__il2cppRuntimeField_38.gameObject.SetActive(value:  true);
        label_2:
        val_12 = 0;
        return (bool)val_12;
        label_25:
        mem2[0] = new System.Action(object:  this.<>4__this, method:  System.Void TRVLossAversionPopup::<Start>b__17_0());
        return (bool)val_12;
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

using UnityEngine;
private sealed class TRVGameplayUI.<StartGame>d__27 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVGameplayUI <>4__this;
    private int <button>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVGameplayUI.<StartGame>d__27(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_22;
        object val_23;
        int val_24;
        int val_26;
        var val_31;
        var val_32;
        var val_33;
        val_22 = 0;
        if((this.<>1__state) > 4)
        {
                return (bool)val_22;
        }
        
        var val_21 = 32556256;
        val_21 = (32556256 + (this.<>1__state) << 2) + val_21;
        goto (32556256 + (this.<>1__state) << 2 + 32556256);
        label_38:
        if(null <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_22 = X23 + 16;
        val_22 = val_22 + (-1816731264);
        (X23 + 16 + -1816731264) + 32.SetButtonState(state:  true, immediate:  false);
        WGAudioController val_14 = MonoSingleton<WGAudioController>.Instance;
        val_14.sound.PlayGameSpecificSound(id:  "Show Answer Option", clipIndex:  0);
        val_26 = mem[X26 + 32];
        val_26 = ;
        if(val_26 < 1152921516163670335)
        {
            goto label_35;
        }
        
        val_31 = val_26 + 1;
        mem2[0] = val_31;
        if(val_31 < (X23 + 24))
        {
            goto label_38;
        }
        
        MonoSingleton<TRVScreenBlocker>.Instance.SetActive(active:  false);
        TRVMainController val_16 = MonoSingleton<TRVMainController>.Instance;
        val_16.StartQuiz();
        val_16.UpdateButton();
        val_16.UpdateButton();
        val_16.UpdateButton();
        val_32 = null;
        val_32 = null;
        UnityEngine.WaitForSeconds val_18 = null;
        val_23 = val_18;
        val_18 = new UnityEngine.WaitForSeconds(seconds:  (TRVMainController.QAHACK_HURRY == false) ? 0.5f : 0.1f);
        val_24 = 4;
        goto label_51;
        label_35:
        val_33 = null;
        val_33 = null;
        UnityEngine.WaitForSeconds val_20 = null;
        val_23 = val_20;
        val_20 = new UnityEngine.WaitForSeconds(seconds:  (TRVMainController.QAHACK_HURRY == false) ? 0.25f : 0.1f);
        val_24 = 3;
        label_51:
        val_22 = 1;
        this.<>2__current = val_23;
        this.<>1__state = val_24;
        return (bool)val_22;
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

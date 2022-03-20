using UnityEngine;
private sealed class TRVPowerupButton.<CheckOOCAfterDelay>d__35 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVPowerupButton <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVPowerupButton.<CheckOOCAfterDelay>d__35(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        TRVPowerupButton val_7;
        int val_8;
        val_7 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_8 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
        this.<>1__state = val_8;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        val_7 = this.<>4__this;
        WGWindowManager val_3 = MonoSingleton<WGWindowManager>.Instance.GetWindow<WGFreeHintPopup>();
        if(val_3 != 0)
        {
                if(val_3.isActiveAndEnabled != false)
        {
                val_8 = 0;
            mem2[0] = new System.Action(object:  val_7, method:  System.Void TRVPowerupButton::<CheckOOCAfterDelay>b__35_0());
            return (bool)val_8;
        }
        
        }
        
        val_7.ContinueGame();
        label_2:
        val_8 = 0;
        return (bool)val_8;
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

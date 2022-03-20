using UnityEngine;
private sealed class FPHLevelCompletePopup.<animateReveal>d__58 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public FPHPickerGameButton selected;
    public FPHLevelCompletePopup <>4__this;
    private System.Collections.Generic.List.Enumerator<FPHPickerGameButton> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public FPHLevelCompletePopup.<animateReveal>d__58(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 3)
        {
                return;
        }
        
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        int val_72;
        if((this.<>1__state) <= 12)
        {
                var val_65 = 32562528 + (this.<>1__state) << 2;
            val_65 = val_65 + 32562528;
        }
        else
        {
                val_72 = 0;
            return (bool);
        }
    
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        this.<>7__wrap1.Dispose();
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

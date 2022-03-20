using UnityEngine;
private sealed class TRVLevelComplete.<animateReveal>d__86 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVPickerGameButton selected;
    public TRVLevelComplete <>4__this;
    public bool rerollAvailable;
    private System.Collections.Generic.Dictionary.KeyCollection.Enumerator<TRVPickerGameButton, int> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<animateReveal>d__86(int <>1__state)
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
        int val_17;
        if((this.<>1__state) <= 3)
        {
                var val_15 = 32497780 + (this.<>1__state) << 2;
            val_15 = val_15 + 32497780;
        }
        else
        {
                val_17 = 0;
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

using UnityEngine;
private sealed class WGEventProgressFlyInAwayPopup.<PlayFallAnimation>d__23 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventProgressFlyInAwayPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventProgressFlyInAwayPopup.<PlayFallAnimation>d__23(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_15;
        if((this.<>1__state) <= 3)
        {
                var val_14 = 32497656 + (this.<>1__state) << 2;
            val_14 = val_14 + 32497656;
        }
        else
        {
                val_15 = 0;
            return (bool)val_15;
        }
    
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

using UnityEngine;
private sealed class TRVLevelComplete.<PlayStreakAnimation>d__81 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLevelComplete <>4__this;
    private TRVLevelComplete.<>c__DisplayClass81_0 <>8__1;
    private UnityEngine.CanvasGroup <cg>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<PlayStreakAnimation>d__81(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        TRVLevelComplete val_39;
        int val_40;
        if((this.<>1__state) <= 5)
        {
                var val_39 = 32497728 + (this.<>1__state) << 2;
            val_39 = this.<>4__this;
            val_39 = val_39 + 32497728;
        }
        else
        {
                val_40 = 0;
            return (bool)val_40;
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

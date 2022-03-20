using UnityEngine;
private sealed class TRVLossAversionPopup.<animateStreakBreaking>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLossAversionPopup <>4__this;
    public int preStreak;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLossAversionPopup.<animateStreakBreaking>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_21;
        if((this.<>1__state) <= 6)
        {
                var val_21 = 32497796 + (this.<>1__state) << 2;
            val_21 = val_21 + 32497796;
        }
        else
        {
                val_21 = 0;
            return (bool)val_21;
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

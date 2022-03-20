using UnityEngine;
private sealed class TRVProgressiveIAPProgressPopup.<AnimateBarFill>d__16 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVProgressiveIAPProgressPopup <>4__this;
    public float targetFillAmount;
    public bool openPurchasePopup;
    public int req;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVProgressiveIAPProgressPopup.<AnimateBarFill>d__16(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_28;
        if((this.<>1__state) <= 7)
        {
                var val_28 = 32557624 + (this.<>1__state) << 2;
            val_28 = val_28 + 32557624;
        }
        else
        {
                val_28 = 0;
            return (bool);
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

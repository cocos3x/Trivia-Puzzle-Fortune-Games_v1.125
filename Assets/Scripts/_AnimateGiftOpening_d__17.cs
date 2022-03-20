using UnityEngine;
private sealed class TRVProgressiveIAPProgressPopup.<AnimateGiftOpening>d__17 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVProgressiveIAPProgressPopup <>4__this;
    private TRVProgressiveIAPProgressPopup.<>c__DisplayClass17_0 <>8__1;
    private int <bonusAmount>5__2;
    private int <prevBonus>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVProgressiveIAPProgressPopup.<AnimateGiftOpening>d__17(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_35;
        if((this.<>1__state) <= 5)
        {
                var val_35 = 32557656 + (this.<>1__state) << 2;
            val_35 = val_35 + 32557656;
        }
        else
        {
                val_35 = 0;
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

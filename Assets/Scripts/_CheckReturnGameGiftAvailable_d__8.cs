using UnityEngine;
private sealed class ReturnGameGiftManager.<CheckReturnGameGiftAvailable>d__8 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ReturnGameGiftManager.<CheckReturnGameGiftAvailable>d__8(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_16;
        int val_17;
        val_16 = this;
        if((this.<>1__state) <= 3)
        {
                var val_16 = 32562372 + (this.<>1__state) << 2;
            val_16 = val_16 + 32562372;
        }
        else
        {
                val_17 = 0;
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

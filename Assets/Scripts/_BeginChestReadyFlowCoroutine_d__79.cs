using UnityEngine;
private sealed class WFOMysteryChestDisplay.<BeginChestReadyFlowCoroutine>d__79 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordForest.WFOMysteryChestDisplay <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOMysteryChestDisplay.<BeginChestReadyFlowCoroutine>d__79(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_38;
        if((this.<>1__state) <= 3)
        {
                var val_37 = 32561404 + (this.<>1__state) << 2;
            val_37 = val_37 + 32561404;
        }
        else
        {
                val_38 = 0;
            return (bool)val_38;
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

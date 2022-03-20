using UnityEngine;
private sealed class TRVGameplayUI.<checkLevelFlyout>d__28 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVGameplayUI <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVGameplayUI.<checkLevelFlyout>d__28(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_9 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool);
        }
        
        var val_9 = 32556276;
        val_9 = (32556276 + (this.<>1__state) << 2) + val_9;
        goto (32556276 + (this.<>1__state) << 2 + 32556276);
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

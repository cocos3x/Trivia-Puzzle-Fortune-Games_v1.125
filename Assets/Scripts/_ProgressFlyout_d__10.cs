using UnityEngine;
private sealed class WGMessageFlyout.<ProgressFlyout>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGMessageFlyout <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGMessageFlyout.<ProgressFlyout>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_9;
        if((this.<>1__state) <= 3)
        {
                var val_9 = 32496664 + (this.<>1__state) << 2;
            val_9 = val_9 + 32496664;
        }
        else
        {
                val_9 = 0;
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

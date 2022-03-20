using UnityEngine;
private sealed class MysteryGiftFlyoutMessage.<AnimateMessage>d__5 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public MysteryGiftFlyoutMessage <>4__this;
    private UnityEngine.RectTransform <rt>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public MysteryGiftFlyoutMessage.<AnimateMessage>d__5(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_10 = 0;
        if((this.<>1__state) > 3)
        {
                return (bool);
        }
        
        var val_10 = 32558284;
        val_10 = (32558284 + (this.<>1__state) << 2) + val_10;
        goto (32558284 + (this.<>1__state) << 2 + 32558284);
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

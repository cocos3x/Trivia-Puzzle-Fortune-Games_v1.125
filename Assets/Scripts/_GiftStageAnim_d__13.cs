using UnityEngine;
private sealed class WADMysteryGiftPopup.<GiftStageAnim>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WADMysteryGiftPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WADMysteryGiftPopup.<GiftStageAnim>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_29 = 0;
        if((this.<>1__state) > 7)
        {
                return (bool);
        }
        
        var val_29 = 32498396;
        val_29 = (32498396 + (this.<>1__state) << 2) + val_29;
        goto (32498396 + (this.<>1__state) << 2 + 32498396);
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

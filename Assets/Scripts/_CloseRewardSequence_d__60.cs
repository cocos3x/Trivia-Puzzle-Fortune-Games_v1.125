using UnityEngine;
private sealed class KeyToRichesPopup.<CloseRewardSequence>d__60 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public KeyToRichesPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public KeyToRichesPopup.<CloseRewardSequence>d__60(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_5;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this.delayBeforeReveal);
        this.<>1__state = val_5;
        return (bool)val_5;
        label_1:
        this.<>1__state = 0;
        SLCWindow.CloseWindow(window:  this.<>4__this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_3:
        val_5 = 0;
        return (bool)val_5;
        label_2:
        this.<>1__state = 0;
        var val_6 = 0;
        do
        {
            if((this.<>4__this.openedChests.Contains(item:  0)) != true)
        {
                this.<>4__this.chests[val_6].RevealReward();
        }
        
            val_6 = val_6 + 1;
        }
        while(val_6 < 8);
        
        KeyToRichesEventHandler._Instance.OnRewardComplete();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this.delayAfterReveal);
        this.<>1__state = 2;
        val_5 = 1;
        return (bool)val_5;
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

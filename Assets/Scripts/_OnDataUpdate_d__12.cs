using UnityEngine;
private sealed class WGLeaguesLoadingPopup.<OnDataUpdate>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGLeaguesLoadingPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGLeaguesLoadingPopup.<OnDataUpdate>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_9;
        var val_10;
        var val_11;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        val_9 = 0;
        if((this.<>1__state) != 0)
        {
                return (bool)val_9;
        }
        
        this.<>1__state = 0;
        if(((this.<>4__this.enabled) == false) || ((this.<>4__this.gameObject.activeInHierarchy) == false))
        {
            goto label_9;
        }
        
        val_10 = 1152921504897474560;
        val_11 = null;
        val_11 = null;
        if(WGLeaguesLoadingPopup.loadingLeagues == false)
        {
            goto label_9;
        }
        
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this.<>4__this, name:  0.ToString());
        val_10 = NotificationCenter.DefaultCenter;
        val_10.RemoveObserver(observer:  this.<>4__this, name:  9.ToString());
        this.<>2__current = this.<>4__this.WaitLoadLeagues();
        val_9 = 1;
        this.<>1__state = val_9;
        return (bool)val_9;
        label_1:
        val_9 = 0;
        this.<>1__state = 0;
        return (bool)val_9;
        label_9:
        val_9 = 0;
        return (bool)val_9;
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

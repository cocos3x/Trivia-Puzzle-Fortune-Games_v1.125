using UnityEngine;
private sealed class TRVLevelComplete.<WaitForCoinAnimation>d__92 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLevelComplete <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<WaitForCoinAnimation>d__92(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_6;
        int val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_9;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_6 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  1.25f);
        val_7 = 1;
        this.<>2__current = val_6;
        this.<>1__state = val_7;
        return (bool)val_7;
        label_1:
        val_6 = this.<>4__this;
        this.<>1__state = 0;
        UUI_EventsController.EnableInputs();
        0.TryShowFomoOnComplete();
        bool val_3 = MonoSingleton<AdsUIController>.Instance.ShowInterstitial(context:  2);
        SLCWindow.CloseWindow(window:  val_6.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if((this.<>4__this.playNextLevelAction) != null)
        {
                this.<>4__this.playNextLevelAction.Invoke();
        }
        else
        {
                MonoSingleton<TRVMainController>.Instance.Init(currentlySelectedCategores:  0, fromReroll:  false);
        }
        
        label_9:
        val_7 = 0;
        return (bool)val_7;
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

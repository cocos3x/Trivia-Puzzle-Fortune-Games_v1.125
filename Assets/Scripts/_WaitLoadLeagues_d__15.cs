using UnityEngine;
private sealed class WGLeaguesLoadingPopup.<WaitLoadLeagues>d__15 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGLeaguesLoadingPopup <>4__this;
    private UnityEngine.AsyncOperation <asyncLoad>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGLeaguesLoadingPopup.<WaitLoadLeagues>d__15(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_12;
        UnityEngine.AsyncOperation val_13;
        var val_14;
        int val_15;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_22;
        }
        
        this.<>1__state = 0;
        GameBehavior val_1 = App.getBehavior;
        if((System.String.IsNullOrEmpty(value:  App.ThemesHandler.CurrentThemeName)) == false)
        {
            goto label_8;
        }
        
        val_12 = "";
        goto label_9;
        label_1:
        val_13 = this.<asyncLoad>5__2;
        this.<>1__state = 0;
        if(val_13 != null)
        {
            goto label_10;
        }
        
        label_8:
        val_12 = "_" + App.ThemesHandler.CurrentThemeName;
        label_9:
        UnityEngine.AsyncOperation val_9 = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName:  val_1.<metaGameBehavior>k__BackingField(val_1.<metaGameBehavior>k__BackingField) + val_12, mode:  1);
        this.<asyncLoad>5__2 = val_9;
        label_10:
        if(val_9.isDone == false)
        {
            goto label_18;
        }
        
        val_14 = null;
        val_14 = null;
        WGLeaguesLoadingPopup.loadingLeagues = false;
        if((this.<>4__this.isFlyout) != false)
        {
                SLCWindow.CloseWindow(window:  this.<>4__this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
        label_22:
        val_15 = 0;
        return (bool)val_15;
        label_18:
        val_15 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_15;
        return (bool)val_15;
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

using UnityEngine;
private sealed class DeeplinkDelegate.<DelayedShowScene>d__14 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DeeplinkDelegate.<DelayedShowScene>d__14(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_26;
        UnityEngine.Object val_27;
        string val_28;
        string val_29;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        val_26 = 0;
        if((this.<>1__state) != 0)
        {
                return (bool)val_26;
        }
        
        this.<>1__state = 0;
        GameBehavior val_1 = App.getBehavior;
        val_27 = App.ThemesHandler;
        if(val_27 != 0)
        {
                if((System.String.IsNullOrEmpty(value:  App.ThemesHandler.CurrentThemeName)) == false)
        {
            goto label_13;
        }
        
        }
        
        val_28 = "";
        goto label_14;
        label_1:
        this.<>1__state = 0;
        MonoSingleton<Bootstrapper>.Instance.HandleDeeplinkMainGame();
        val_26 = 0;
        return (bool)val_26;
        label_13:
        val_28 = "_" + App.ThemesHandler.CurrentThemeName;
        label_14:
        UnityEngine.SceneManagement.Scene val_12 = UnityEngine.SceneManagement.SceneManager.GetSceneByName(name:  val_1.<metaGameBehavior>k__BackingField(val_1.<metaGameBehavior>k__BackingField) + val_28);
        if(val_12.m_Handle.isLoaded == false)
        {
            goto label_24;
        }
        
        GameBehavior val_14 = App.getBehavior;
        val_27 = App.ThemesHandler;
        if(val_27 != 0)
        {
                if((System.String.IsNullOrEmpty(value:  App.ThemesHandler.CurrentThemeName)) == false)
        {
            goto label_35;
        }
        
        }
        
        val_29 = "";
        goto label_36;
        label_35:
        val_29 = "_" + App.ThemesHandler.CurrentThemeName;
        label_36:
        UnityEngine.AsyncOperation val_24 = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName:  val_14.<metaGameBehavior>k__BackingField(val_14.<metaGameBehavior>k__BackingField) + val_29);
        label_24:
        val_26 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  3f);
        this.<>1__state = val_26;
        return (bool)val_26;
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

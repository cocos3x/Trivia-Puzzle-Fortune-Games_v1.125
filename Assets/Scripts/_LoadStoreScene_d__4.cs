using UnityEngine;
private sealed class GameStoreManager.<LoadStoreScene>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public GameStoreManager <>4__this;
    public System.Action<bool, bool> storeCloseCallback;
    private UnityEngine.AsyncOperation <asyncLoad>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GameStoreManager.<LoadStoreScene>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.AsyncOperation val_4;
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        GameBehavior val_1 = App.getBehavior;
        UnityEngine.AsyncOperation val_2 = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName:  val_1.<metaGameBehavior>k__BackingField, mode:  1);
        this.<asyncLoad>5__2 = val_2;
        if(val_2 != null)
        {
            goto label_9;
        }
        
        label_1:
        val_4 = this.<asyncLoad>5__2;
        this.<>1__state = 0;
        label_9:
        if(val_4.isDone != false)
        {
                if((this.<>4__this.currentStoreCloseCallback) != null)
        {
                this.<>4__this.currentStoreCloseCallback.Invoke(arg1:  false, arg2:  false);
        }
        
            val_5 = 0;
            this.<>4__this.currentStoreCloseCallback = this.storeCloseCallback;
            return (bool)val_5;
        }
        
        val_5 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_5;
        return (bool)val_5;
        label_2:
        val_5 = 0;
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

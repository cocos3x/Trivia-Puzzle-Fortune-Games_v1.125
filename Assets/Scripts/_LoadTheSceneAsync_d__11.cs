using UnityEngine;
private sealed class ScreenFader.<LoadTheSceneAsync>d__11 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ScreenFader <>4__this;
    public string sceneName;
    private UnityEngine.AsyncOperation <asyncLoad>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ScreenFader.<LoadTheSceneAsync>d__11(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.AsyncOperation val_3;
        int val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.isLoadingScene = true;
        UnityEngine.AsyncOperation val_1 = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName:  this.sceneName, mode:  0);
        this.<asyncLoad>5__2 = val_1;
        if(val_1 != null)
        {
            goto label_6;
        }
        
        label_1:
        val_3 = this.<asyncLoad>5__2;
        this.<>1__state = 0;
        label_6:
        if(val_3.isDone == false)
        {
            goto label_9;
        }
        
        label_2:
        val_4 = 0;
        return (bool)val_4;
        label_9:
        val_4 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_4;
        return (bool)val_4;
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

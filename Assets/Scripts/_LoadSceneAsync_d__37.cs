using UnityEngine;
private sealed class Bootstrapper.<LoadSceneAsync>d__37 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Bootstrapper <>4__this;
    public string sceneName;
    public string lastScene;
    public bool killManagers;
    public bool redirectToGameplay;
    private UnityEngine.AsyncOperation <asyncLoad>5__2;
    private UnityEngine.AsyncOperation <asyncUnload>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Bootstrapper.<LoadSceneAsync>d__37(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_28;
        if((this.<>1__state) <= 5)
        {
                var val_23 = 32497548 + (this.<>1__state) << 2;
            val_23 = val_23 + 32497548;
        }
        else
        {
                val_28 = 0;
            return (bool)val_28;
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

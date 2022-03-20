using UnityEngine;
private sealed class MonoExtensions.<DelayedCallEndOfFrameCoroutine>d__2 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int count;
    public System.Action callback;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public MonoExtensions.<DelayedCallEndOfFrameCoroutine>d__2(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        int val_3;
        val_2 = this.<>1__state;
        if(val_2 == 1)
        {
            goto label_1;
        }
        
        if(val_2 != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<i>5__2 = 0;
        goto label_3;
        label_1:
        this.<>1__state = 0;
        val_2 = (this.<i>5__2) + 1;
        this.<i>5__2 = val_2;
        label_3:
        if(val_2 < this.count)
        {
                val_3 = 1;
            this.<>2__current = new UnityEngine.WaitForEndOfFrame();
            this.<>1__state = val_3;
            return (bool)val_3;
        }
        
        this.callback.Invoke();
        label_2:
        val_3 = 0;
        return (bool)val_3;
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

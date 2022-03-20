using UnityEngine;
private sealed class AsyncExecution.<MultiAction>d__5<T> : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int framesToWait;
    public System.Action<T> collectionAction;
    public T actionArgument;
    private int <i>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AsyncExecution.<MultiAction>d__5<T>(int <>1__state)
    {
        mem[1152921515777642768] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_2;
        var val_3;
        if(W8 == 1)
        {
            goto label_0;
        }
        
        if(W8 != 0)
        {
            goto label_1;
        }
        
        mem[1152921515777866768] = 0;
        mem[1152921515777866808] = 0;
        goto label_2;
        label_0:
        mem[1152921515777866768] = 0;
        val_2 = W8 + 1;
        mem[1152921515777866808] = val_2;
        label_2:
        if(val_2 < 0)
        {
                val_3 = 1;
            mem[1152921515777866776] = 0;
            mem[1152921515777866768] = val_3;
            return (bool)val_3;
        }
        
        label_1:
        val_3 = 0;
        return (bool)val_3;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this;
    }

}

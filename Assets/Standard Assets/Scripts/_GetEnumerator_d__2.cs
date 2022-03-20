using UnityEngine;
private sealed class BetterList.<GetEnumerator>d__2<T> : IEnumerator<T>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private T <>2__current;
    public BetterList<T> <>4__this;
    private int <i>5__2;
    
    // Properties
    private T System.Collections.Generic.IEnumerator<T>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BetterList.<GetEnumerator>d__2<T>(int <>1__state)
    {
        mem[1152921510453424400] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_2;
        var val_3;
        if(W9 == 1)
        {
            goto label_0;
        }
        
        if(W9 != 0)
        {
            goto label_6;
        }
        
        mem[1152921510453648400] = 0;
        if((X8 + 16) == 0)
        {
            goto label_6;
        }
        
        val_2 = 0;
        mem[1152921510453648424] = 0;
        goto label_4;
        label_0:
        mem[1152921510453648400] = 0;
        val_2 = W9 + 1;
        mem[1152921510453648424] = val_2;
        label_4:
        if(val_2 < (X8 + 24))
        {
                var val_1 = X8 + 16;
            val_1 = val_1 + (val_2 << 3);
            val_3 = 1;
            mem[1152921510453648400] = val_3;
            mem[1152921510453648408] = (X8 + 16 + ((W9 + 1)) << 3) + 32;
            return (bool)val_3;
        }
        
        label_6:
        val_3 = 0;
        return (bool)val_3;
    }
    private T System.Collections.Generic.IEnumerator<T>.get_Current()
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

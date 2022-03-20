using UnityEngine;
private sealed class CircularBuffer.<GetEnumerator>d__17<T> : IEnumerator<T>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private T <>2__current;
    public SRDebugger.CircularBuffer<T> <>4__this;
    private System.ArraySegment<T>[] <>7__wrap1;
    private int <>7__wrap2;
    private System.ArraySegment<T> <segment>5__4;
    private int <i>5__5;
    
    // Properties
    private T System.Collections.Generic.IEnumerator<T>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public CircularBuffer.<GetEnumerator>d__17<T>(int <>1__state)
    {
        mem[1152921519495047984] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        if(W8 == 1)
        {
            goto label_0;
        }
        
        if(W8 != 0)
        {
            goto label_1;
        }
        
        mem[1152921519495276096] = 0;
        val_5 = __RuntimeMethodHiddenParam + 24 + 192;
        mem2[0] = X22;
        mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        val_6 = this;
        mem2[0] = X22;
        mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        mem[1152921519495276144] = val_5;
        val_7 = 0;
        mem[1152921519495276152] = 0;
        if(val_5 != 0)
        {
            goto label_7;
        }
        
        label_0:
        mem[1152921519495276096] = 0;
        val_9 = W8 + 1;
        val_10 = 1152921519495276160;
        mem[1152921519495276176] = val_9;
        goto label_9;
        label_1:
        val_11 = 0;
        return (bool)val_11;
        label_14:
        var val_1 = X20 + (((long)(int)(W8)) << 4);
        val_10 = this;
        val_9 = 0;
        mem[1152921519495276160] = (X20 + ((long)(int)(W8)) << 4) + 32;
        mem[1152921519495276168] = (X20 + ((long)(int)(W8)) << 4) + 32 + 8;
        mem[1152921519495276176] = 0;
        val_8 = ((X20 + ((long)(int)(W8)) << 4) + 32 + 8) >> 32;
        label_9:
        if(val_9 < val_8)
        {
            goto label_12;
        }
        
        mem[1152921519495276160] = 0;
        mem[1152921519495276168] = 0;
        val_6 = this;
        val_7 = 1;
        mem[1152921519495276152] = val_7;
        label_7:
        if(val_7 < (X20 + 24))
        {
            goto label_14;
        }
        
        val_11 = 0;
        mem[1152921519495276144] = 0;
        return (bool)val_11;
        label_12:
        val_9 = val_8 + val_9;
        var val_2 = 1152921519495276160 + (((long)(int)((((X20 + ((long)(int)(W8)) << 4) + 32 + 8 >> 32) + val_9))) << 5);
        val_11 = 1;
        mem[1152921519495276096] = val_11;
        mem[1152921519495276104] = (1152921519495276160 + ((long)(int)((((X20 + ((long)(int)(W8)) << 4) + 32 + 8 >> 32) + val_9))) << 5) + 32;
        mem[1152921519495276120] = (1152921519495276160 + ((long)(int)((((X20 + ((long)(int)(W8)) << 4) + 32 + 8 >> 32) + val_9))) << 5) + 32 + 16;
        return (bool)val_11;
    }
    private T System.Collections.Generic.IEnumerator<T>.get_Current()
    {
        SRDebugger.Services.ProfilerFrame val_0;
        return val_0;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object);
    }

}

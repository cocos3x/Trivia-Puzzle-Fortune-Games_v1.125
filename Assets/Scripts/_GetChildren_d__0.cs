using UnityEngine;
private sealed class SRFTransformExtensions.<GetChildren>d__0 : IEnumerable<UnityEngine.Transform>, IEnumerable, IEnumerator<UnityEngine.Transform>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private UnityEngine.Transform <>2__current;
    private int <>l__initialThreadId;
    private UnityEngine.Transform t;
    public UnityEngine.Transform <>3__t;
    private int <i>5__2;
    
    // Properties
    private UnityEngine.Transform System.Collections.Generic.IEnumerator<UnityEngine.Transform>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SRFTransformExtensions.<GetChildren>d__0(int <>1__state)
    {
        this.<>1__state = <>1__state;
        this.<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_4;
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_0;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_4;
        }
        
        val_4 = 0;
        this.<>1__state = 0;
        this.<i>5__2 = 0;
        goto label_2;
        label_0:
        this.<>1__state = 0;
        val_4 = (this.<i>5__2) + 1;
        this.<i>5__2 = val_4;
        label_2:
        if(val_4 < this.t.childCount)
        {
                this.<>2__current = this.t.GetChild(index:  this.<i>5__2);
            val_5 = 1;
            this.<>1__state = val_5;
            return (bool)val_5;
        }
        
        label_4:
        val_5 = 0;
        return (bool)val_5;
    }
    private UnityEngine.Transform System.Collections.Generic.IEnumerator<UnityEngine.Transform>.get_Current()
    {
        return (UnityEngine.Transform)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }
    private System.Collections.Generic.IEnumerator<UnityEngine.Transform> System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator()
    {
        var val_4;
        if(((this.<>1__state) == 2) && ((this.<>l__initialThreadId) == System.Environment.CurrentManagedThreadId))
        {
                this.<>1__state = 0;
            val_4 = this;
        }
        else
        {
                SRFTransformExtensions.<GetChildren>d__0 val_2 = null;
            val_4 = val_2;
            val_2 = new SRFTransformExtensions.<GetChildren>d__0();
            .<>1__state = 0;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        }
        
        .t = this.<>3__t;
        return (System.Collections.Generic.IEnumerator<UnityEngine.Transform>)val_4;
    }
    private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator();
    }

}

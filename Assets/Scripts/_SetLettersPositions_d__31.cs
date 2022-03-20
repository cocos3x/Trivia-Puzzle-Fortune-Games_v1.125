using UnityEngine;
private sealed class Pan.<SetLettersPositions>d__31 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Pan <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Pan.<SetLettersPositions>d__31(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_4;
        int val_5;
        val_4 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_6;
        }
        
        this.<>1__state = 0;
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_5;
        return (bool)val_5;
        label_1:
        this.<>1__state = 0;
        val_4 = 0;
        label_14:
        if(val_4 >= (this.<>4__this.tileStrings))
        {
            goto label_6;
        }
        
        if((this.<>4__this.tileStrings) <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.Collections.Generic.List<System.Int32> val_4 = this.<>4__this.indexes;
        int val_3 = val_4.IndexOf(item:  0);
        if(val_4 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + ((long)val_3 * 12);
        System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg.transform.localPosition = new UnityEngine.Vector3() {x = ((long)(int)(val_3) * 12) + this.<>4__this.indexes + 32, y = ((long)(int)(val_3) * 12) + this.<>4__this.indexes + 32 + 4, z = ((long)(int)(val_3) * 12) + this.<>4__this.indexes + 40};
        val_4 = val_4 + 1;
        if((this.<>4__this.tileStrings) != null)
        {
            goto label_14;
        }
        
        throw new NullReferenceException();
        label_6:
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

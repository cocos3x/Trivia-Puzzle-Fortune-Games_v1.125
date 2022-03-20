using UnityEngine;
private sealed class JSONNode.<get_DeepChilds>d__19 : IEnumerable<com.adjust.sdk.JSONNode>, IEnumerable, IEnumerator<com.adjust.sdk.JSONNode>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private com.adjust.sdk.JSONNode <>2__current;
    private int <>l__initialThreadId;
    public com.adjust.sdk.JSONNode <>4__this;
    private System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode> <>7__wrap1;
    private System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode> <>7__wrap2;
    
    // Properties
    private com.adjust.sdk.JSONNode System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public JSONNode.<get_DeepChilds>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
        this.<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
    }
    private void System.IDisposable.Dispose()
    {
        if(((this.<>1__state) & 4294967294) != 4)
        {
            goto label_0;
        }
        
        if(((this.<>1__state) == 4) || ((this.<>1__state) == 1))
        {
            goto label_2;
        }
        
        goto label_3;
        label_0:
        if((this.<>1__state) != 1)
        {
                return;
        }
        
        label_2:
        this.<>m__Finally2();
        label_3:
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        com.adjust.sdk.JSONNode val_8;
        var val_9;
        System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode> val_10;
        var val_11;
        int val_13;
        var val_15;
        var val_18;
        if((this.<>1__state) == 0)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 1)
        {
            goto label_57;
        }
        
        val_9 = this;
        val_10 = this.<>7__wrap2;
        goto label_3;
        label_1:
        val_8 = this.<>4__this;
        this.<>1__state = 0;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_12 = 0;
        val_12 = val_12 + 1;
        System.Collections.Generic.IEnumerator<T> val_2 = val_8.GetEnumerator();
        this.<>7__wrap1 = val_2;
        this.<>1__state = -3;
        goto label_38;
        label_57:
        val_13 = 0;
        return (bool)val_13;
        label_38:
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_13 = 0;
        val_13 = val_13 + 1;
        val_11 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        val_8 = val_2;
        if(val_8.MoveNext() == false)
        {
            goto label_20;
        }
        
        if((this.<>7__wrap1) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_16 = mem[val_2];
        if((mem[val_2] + 294) == 0)
        {
            goto label_25;
        }
        
        var val_14 = mem[val_2] + 176;
        var val_15 = 0;
        val_14 = val_14 + 8;
        label_24:
        if(((mem[val_2] + 176 + 8) + -8) == null)
        {
            goto label_23;
        }
        
        val_15 = val_15 + 1;
        val_14 = val_14 + 16;
        if(val_15 < (mem[val_2] + 294))
        {
            goto label_24;
        }
        
        goto label_25;
        label_23:
        val_16 = val_16 + (((mem[val_2] + 176 + 8)) << 4);
        val_15 = val_16 + 304;
        label_25:
        val_11 = public T System.Collections.Generic.IEnumerator<T>::get_Current();
        val_8 = this.<>7__wrap1;
        T val_5 = val_8.Current;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode> val_6 = val_5.DeepChilds;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_11 = public System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>::GetEnumerator();
        val_8 = val_6;
        System.Collections.Generic.IEnumerator<T> val_8 = val_8.GetEnumerator();
        val_9 = this;
        val_10 = val_8;
        this.<>7__wrap2 = val_8;
        label_3:
        this.<>1__state = -4;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_18 = 0;
        val_18 = val_18 + 1;
        if(val_10.MoveNext() == true)
        {
            goto label_37;
        }
        
        this.<>m__Finally2();
        this.<>7__wrap2 = 0;
        goto label_38;
        label_20:
        this.<>m__Finally1();
        val_13 = 0;
        this.<>7__wrap1 = 0;
        return (bool)val_13;
        label_37:
        var val_21 = 1179403647;
        if(mem[282584257676965] == 0)
        {
            goto label_44;
        }
        
        var val_19 = mem[282584257676847];
        var val_20 = 0;
        val_19 = val_19 + 8;
        label_43:
        if(((mem[282584257676847] + 8) + -8) == null)
        {
            goto label_42;
        }
        
        val_20 = val_20 + 1;
        val_19 = val_19 + 16;
        if(val_20 < mem[282584257676965])
        {
            goto label_43;
        }
        
        goto label_44;
        label_42:
        val_21 = val_21 + (((mem[282584257676847] + 8)) << 4);
        val_18 = val_21 + 304;
        label_44:
        this.<>2__current = this.<>7__wrap2.Current;
        val_13 = 1;
        this.<>1__state = val_13;
        return (bool)val_13;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        if((this.<>7__wrap1) == null)
        {
                return;
        }
        
        var val_2 = 0;
        val_2 = val_2 + 1;
        this.<>7__wrap1.Dispose();
    }
    private void <>m__Finally2()
    {
        this.<>1__state = -3;
        if((this.<>7__wrap2) == null)
        {
                return;
        }
        
        var val_2 = 0;
        val_2 = val_2 + 1;
        this.<>7__wrap2.Dispose();
    }
    private com.adjust.sdk.JSONNode System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode>.get_Current()
    {
        return (com.adjust.sdk.JSONNode)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }
    private System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode> System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator()
    {
        if((this.<>1__state) == 2)
        {
                if((this.<>l__initialThreadId) == System.Environment.CurrentManagedThreadId)
        {
                this.<>1__state = 0;
            return (System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode>)this;
        }
        
        }
        
        .<>1__state = 0;
        .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        this = new JSONNode.<get_DeepChilds>d__19();
        .<>4__this = this.<>4__this;
        return (System.Collections.Generic.IEnumerator<com.adjust.sdk.JSONNode>)this;
    }
    private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>.GetEnumerator();
    }

}

using UnityEngine;
private sealed class AsyncExecution.<MultiAsync>d__4<T> : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public System.Collections.Generic.IEnumerable<T> collection;
    public int batchSize;
    public AsyncExecution <>4__this;
    public System.Action<T> collectionAction;
    private int <maxLoadBatches>5__2;
    private int <i>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public AsyncExecution.<MultiAsync>d__4<T>(int <>1__state)
    {
        mem[1152921515776953232] = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_17;
        int val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        var val_33;
        var val_34;
        var val_35;
        val_17 = __RuntimeMethodHiddenParam;
        if(true == 1)
        {
            goto label_1;
        }
        
        if(true != 0)
        {
            goto label_57;
        }
        
        mem[1152921515777181392] = 0;
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = mem[__RuntimeMethodHiddenParam + 24 + 192];
        val_19 = __RuntimeMethodHiddenParam + 24 + 192;
        var val_11 = X22;
        if((X22 + 294) == 0)
        {
            goto label_8;
        }
        
        var val_9 = X22 + 176;
        var val_10 = 0;
        val_9 = val_9 + 8;
        label_7:
        if(((X22 + 176 + 8) + -8) == val_19)
        {
            goto label_6;
        }
        
        val_10 = val_10 + 1;
        val_9 = val_9 + 16;
        if(val_10 < (X22 + 294))
        {
            goto label_7;
        }
        
        goto label_8;
        label_1:
        mem[1152921515777181392] = 0;
        val_21 = 1152921515777181440;
        val_22 = true + 1;
        mem[1152921515777181444] = val_22;
        goto label_9;
        label_6:
        val_11 = val_11 + (((X22 + 176 + 8)) << 4);
        val_20 = val_11 + 304;
        label_8:
        val_18 = X22;
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_23 = 0;
        goto label_11;
        label_21:
        var val_14 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_16;
        }
        
        var val_12 = X22 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_15:
        if(((X22 + 176 + 8) + -8) == (__RuntimeMethodHiddenParam + 24 + 192 + 8))
        {
            goto label_14;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X22 + 294))
        {
            goto label_15;
        }
        
        goto label_16;
        label_14:
        val_14 = val_14 + (((X22 + 176 + 8)) << 4);
        val_24 = val_14 + 304;
        label_16:
        val_23 = 1;
        label_11:
        var val_17 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_20;
        }
        
        var val_15 = X22 + 176;
        var val_16 = 0;
        val_15 = val_15 + 8;
        label_19:
        if(((X22 + 176 + 8) + -8) == null)
        {
            goto label_18;
        }
        
        val_16 = val_16 + 1;
        val_15 = val_15 + 16;
        if(val_16 < (X22 + 294))
        {
            goto label_19;
        }
        
        goto label_20;
        label_18:
        val_17 = val_17 + (((X22 + 176 + 8)) << 4);
        val_25 = val_17 + 304;
        label_20:
        if(val_18.MoveNext() == true)
        {
            goto label_21;
        }
        
        val_19 = 0;
        if(val_18 == 0)
        {
            goto label_70;
        }
        
        var val_20 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_26;
        }
        
        var val_18 = X22 + 176;
        var val_19 = 0;
        val_18 = val_18 + 8;
        label_25:
        if(((X22 + 176 + 8) + -8) == null)
        {
            goto label_24;
        }
        
        val_19 = val_19 + 1;
        val_18 = val_18 + 16;
        if(val_19 < (X22 + 294))
        {
            goto label_25;
        }
        
        goto label_26;
        label_24:
        val_20 = val_20 + (((X22 + 176 + 8)) << 4);
        val_26 = val_20 + 304;
        label_26:
        val_18.Dispose();
        label_70:
        if(val_19 != 0)
        {
                throw val_31 = 0;
        }
        
        if(0 != 1)
        {
                var val_2 = (85 == 85) ? 1 : 0;
            val_2 = ((0 >= 0) ? 1 : 0) & val_2;
            val_2 = 0 - val_2;
            val_2 = val_2 + 1;
            val_27 = (long)val_2;
        }
        else
        {
                val_27 = 0;
        }
        
        int val_4 = System.Math.Max(val1:  val_18, val2:  1);
        mem[1152921515777181416] = val_4;
        val_4 = val_23 / val_4;
        val_28 = 1;
        mem[1152921515777181440] = System.Math.Max(val1:  val_4, val2:  1);
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_23 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_34;
        }
        
        var val_21 = X22 + 176;
        var val_22 = 0;
        val_21 = val_21 + 8;
        label_36:
        if(((X22 + 176 + 8) + -8) == (__RuntimeMethodHiddenParam + 24 + 192))
        {
            goto label_35;
        }
        
        val_22 = val_22 + 1;
        val_21 = val_21 + 16;
        if(val_22 < (X22 + 294))
        {
            goto label_36;
        }
        
        label_34:
        val_28 = __RuntimeMethodHiddenParam + 24 + 192;
        goto label_37;
        label_35:
        val_23 = val_23 + (((X22 + 176 + 8)) << 4);
        val_29 = val_23 + 304;
        label_37:
        val_18 = val_18;
        val_30 = 0;
        goto label_39;
        label_50:
        var val_26 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_44;
        }
        
        var val_24 = X22 + 176;
        var val_25 = 0;
        val_24 = val_24 + 8;
        label_43:
        if(((X22 + 176 + 8) + -8) == (__RuntimeMethodHiddenParam + 24 + 192 + 8))
        {
            goto label_42;
        }
        
        val_25 = val_25 + 1;
        val_24 = val_24 + 16;
        if(val_25 < (X22 + 294))
        {
            goto label_43;
        }
        
        goto label_44;
        label_42:
        val_26 = val_26 + (((X22 + 176 + 8)) << 4);
        val_32 = val_26 + 304;
        label_44:
        if(==0)
        {
                throw new NullReferenceException();
        }
        
        var val_27 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        UnityEngine.Coroutine val_6 = StartCoroutine(routine:  41988096);
        val_30 = 1;
        val_27 = val_30 / val_27;
        val_31 = val_27 - ((val_27 / val_24) * val_24);
        label_39:
        var val_30 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_49;
        }
        
        var val_28 = X22 + 176;
        var val_29 = 0;
        val_28 = val_28 + 8;
        label_48:
        if(((X22 + 176 + 8) + -8) == null)
        {
            goto label_47;
        }
        
        val_29 = val_29 + 1;
        val_28 = val_28 + 16;
        if(val_29 < (X22 + 294))
        {
            goto label_48;
        }
        
        goto label_49;
        label_47:
        val_30 = val_30 + (((X22 + 176 + 8)) << 4);
        val_33 = val_30 + 304;
        label_49:
        if(val_18.MoveNext() == true)
        {
            goto label_50;
        }
        
        val_17 = 0;
        if(val_18 == 0)
        {
            goto label_67;
        }
        
        var val_33 = val_18;
        if((X22 + 294) == 0)
        {
            goto label_55;
        }
        
        var val_31 = X22 + 176;
        var val_32 = 0;
        val_31 = val_31 + 8;
        label_54:
        if(((X22 + 176 + 8) + -8) == null)
        {
            goto label_53;
        }
        
        val_32 = val_32 + 1;
        val_31 = val_31 + 16;
        if(val_32 < (X22 + 294))
        {
            goto label_54;
        }
        
        goto label_55;
        label_53:
        val_33 = val_33 + (((X22 + 176 + 8)) << 4);
        val_34 = val_33 + 304;
        label_55:
        val_18.Dispose();
        label_67:
        if(val_17 != 0)
        {
                throw val_17;
        }
        
        val_22 = 0;
        val_21 = 1152921515777181440;
        mem[1152921515777181444] = 0;
        label_9:
        if(val_22 < null)
        {
                val_35 = 1;
            mem[1152921515777181400] = 0;
            mem[1152921515777181392] = val_35;
            return (bool)val_35;
        }
        
        label_57:
        val_35 = 0;
        return (bool)val_35;
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

using UnityEngine;
private sealed class LineWord.<IEShowAnswer>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float waitBeforePlaying;
    public LineWord <>4__this;
    private System.Collections.Generic.List.Enumerator<Cell> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LineWord.<IEShowAnswer>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 3)
        {
                return;
        }
        
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        var val_3;
        List.Enumerator<Cell> val_4;
        System.Collections.Generic.List<Cell> val_11;
        int val_12;
        List.Enumerator<Cell> val_13;
        var val_14;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        if(this.waitBeforePlaying <= 0f)
        {
            goto label_4;
        }
        
        val_12 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.waitBeforePlaying);
        this.<>1__state = val_12;
        return (bool)val_12;
        label_2:
        this.<>1__state = 0;
        label_4:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = this.<>4__this.cells;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = val_11.GetEnumerator();
        val_13 = this.<>7__wrap1;
        mem[1152921515448784800] = val_3;
        this.<>7__wrap1 = val_4;
        this.<>1__state = -3;
        goto label_8;
        label_1:
        val_13 = this.<>7__wrap1;
        this.<>1__state = -3;
        label_8:
        val_14 = public System.Boolean List.Enumerator<Cell>::MoveNext();
        val_11 = val_13;
        if(val_11.MoveNext() != false)
        {
                if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_11 = mem[this.<>7__wrap1 + 32];
            mem2[0] = 1;
            if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_14 = 0;
            if(val_11.activeSelf != true)
        {
                val_11 = TextPreview.instance;
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_13.Animate(from:  val_11.transform, fromParent:  MonoUtils.instance.textFlyTransform);
        }
        
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
            this.<>1__state = 2;
            val_12 = 1;
            return (bool)val_12;
        }
        
        this.<>m__Finally1();
        val_12 = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        return (bool)val_12;
        label_3:
        val_12 = 0;
        return (bool)val_12;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        this.<>7__wrap1.Dispose();
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

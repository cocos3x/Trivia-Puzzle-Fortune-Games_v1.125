using UnityEngine;
public class BetterList<T>
{
    // Fields
    public T[] buffer;
    public int size;
    
    // Properties
    public T Item { get; set; }
    
    // Methods
    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        mem2[0] = this;
        return (System.Collections.Generic.IEnumerator<T>)__RuntimeMethodHiddenParam + 24 + 192;
    }
    public T get_Item(int i)
    {
        var val_1 = X8 + (i << 3);
        return (object)(X8 + (i) << 3) + 32;
    }
    public void set_Item(int i, T value)
    {
        var val_1 = X8 + (i << 3);
        mem2[0] = value;
    }
    private void AllocateMore()
    {
        System.Array val_3;
        var val_4;
        if(!=0)
        {
                val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            val_4 = UnityEngine.Mathf.Max(a:  mem[41988120] << 1, b:  32);
        }
        else
        {
                val_4 = 32;
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        }
        
        if((val_3 != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 302) >= 1))
        {
                val_3.CopyTo(array:  val_3, index:  0);
        }
        
        mem[1152921510451914896] = val_3;
    }
    private void Trim()
    {
        if(W20 >= 1)
        {
                if(W20 >= (X8 + 24))
        {
                return;
        }
        
            if((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 302) >= 1)
        {
                var val_3 = 4;
            do
        {
            var val_1 = val_3 - 4;
            mem2[0] = X9 + 32;
            val_3 = val_3 + 1;
        }
        while((val_3 - 3) < (X9 + 32));
        
        }
        
            mem[1152921510452035344] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            return;
        }
        
        mem[1152921510452035344] = 0;
    }
    public void Clear()
    {
        mem[1152921510452151448] = 0;
    }
    public void Release()
    {
        mem[1152921510452263448] = 0;
        mem[1152921510452263440] = 0;
    }
    public void Add(T item)
    {
        if(X8 != 0)
        {
                if(W9 != (X8 + 24))
        {
            goto label_1;
        }
        
        }
        
        var val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 24;
        mem[1152921510452379544] = W9 + 1;
        if(val_3 != 0)
        {
            goto label_2;
        }
        
        throw new NullReferenceException();
        label_1:
        mem[1152921510452379544] = W9 + 1;
        label_2:
        val_3 = val_3 + ((W9) << 3);
        mem2[0] = item;
    }
    public void Insert(int index, T item)
    {
        var val_4;
        if(X9 == 0)
        {
            goto label_0;
        }
        
        val_4 = this;
        var val_4 = X9 + 24;
        if(W10 != val_4)
        {
            goto label_1;
        }
        
        label_0:
        val_4 = this;
        label_1:
        if(W10 > index)
        {
                var val_5 = (long)(long)(int)(W10);
            var val_1 = (val_4 == 0) ? 1 : 0;
            do
        {
            var val_2 = W10 - 1;
            val_4 = val_4 + (((long)(int)(W10)) << 3);
            val_5 = val_5 - 1;
            mem2[0] = (X9 + 24 + ((long)(int)(W10)) << 3) + 24;
            var val_3 = (val_4 == 0) ? 1 : 0;
        }
        while(val_5 > (long)index);
        
            val_4 = val_4 + (((long)(int)(index)) << 3);
            mem2[0] = item;
            val_4 = val_4 + 1;
            mem[1152921510452499736] = val_4;
        }
    
    }
    public bool Contains(T item)
    {
        if((X8 == 0) || (W9 < 1))
        {
                return false;
        }
        
        var val_2 = 0;
        do
        {
            var val_1 = X8 + 0;
            if((((X8 + 0) + 32) & 1) != 0)
        {
                return false;
        }
        
            val_2 = val_2 + 1;
            if(val_2 >= ((X8 + 0) + 32))
        {
                return false;
        }
        
        }
        while(((X8 + 0) + 32) != 0);
        
        throw new NullReferenceException();
    }
    public bool Remove(T item)
    {
        if(X8 == 0)
        {
                return false;
        }
        
        var val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 48;
        if(val_2 < 1)
        {
                return false;
        }
        
        var val_3 = 0;
        label_6:
        var val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 48;
        val_2 = val_2 + 0;
        var val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 48 + 432;
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 48) & 1) != 0)
        {
            goto label_5;
        }
        
        val_3 = val_3 + 1;
        if(val_3 < val_5)
        {
            goto label_6;
        }
        
        return false;
        label_5:
        val_4 = val_4 - 1;
        mem[1152921510452740120] = val_4;
        val_5 = val_5 + 0;
        mem2[0] = 0;
        if(val_5 <= val_3)
        {
                return false;
        }
        
        do
        {
            val_5 = val_5 + 0;
            mem2[0] = ((__RuntimeMethodHiddenParam + 24 + 192 + 48 + 432 + 0) + 0) + 40;
        }
        while((val_3 + 1) < val_5);
        
        return false;
    }
    public void RemoveAt(int index)
    {
        if(X8 == 0)
        {
                return;
        }
        
        if(W9 <= index)
        {
                return;
        }
        
        mem[1152921510452856216] = W9 - 1;
        var val_4 = X8 + 24;
        mem2[0] = 0;
        if((X8 + (index << 3)) <= index)
        {
                return;
        }
        
        var val_5 = (long)index;
        do
        {
            var val_3 = val_5 + 1;
            val_4 = val_4 + (((long)(int)(index)) << 3);
            val_5 = val_5 + 1;
            mem2[0] = (X8 + 24 + ((long)(int)(index)) << 3) + 40;
        }
        while(val_5 < val_4);
    
    }
    public T Pop()
    {
        if(X8 == 0)
        {
                return 0;
        }
        
        if(W9 == 0)
        {
                return 0;
        }
        
        var val_1 = W9 - 1;
        mem[1152921510452968216] = val_1;
        if(val_1 < (X8 + 24))
        {
                var val_2 = X8 + (val_1 << 3);
            mem2[0] = 0;
            return (object)(X8 + ((W9 - 1)) << 3) + 32;
        }
        
        throw new IndexOutOfRangeException();
    }
    public T[] ToArray()
    {
        return (T[])this;
    }
    public void Sort(System.Comparison<T> comparer)
    {
        var val_1;
        var val_5 = 1;
        label_12:
        val_1 = 0;
        if(val_5 >= W9)
        {
            goto label_0;
        }
        
        var val_1 = val_5 - 1;
        var val_2 = 0 + (((long)(int)((1 - 1))) << 3);
        if(comparer >= 1)
        {
                var val_3 = val_2 + 8;
            val_2 = val_2 + (((long)(int)((1 - 1))) << 3);
            var val_4 = ((0 + ((long)(int)((1 - 1))) << 3) + ((long)(int)((1 - 1))) << 3) + 32;
            mem2[0] = val_4;
            val_4 = val_4 + (((long)(int)((1 - 1))) << 3);
            val_1 = 1;
            mem2[0] = ((0 + ((long)(int)((1 - 1))) << 3) + 8) + 32;
        }
        
        val_5 = val_5 + 1;
        goto label_12;
        label_0:
        if((val_1 & 1) != 0)
        {
            goto label_12;
        }
    
    }
    public BetterList<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }

}

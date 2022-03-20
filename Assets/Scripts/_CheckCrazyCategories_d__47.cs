using UnityEngine;
private sealed class TRVCategorySelection.<CheckCrazyCategories>d__47 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVCategorySelection <>4__this;
    private System.Collections.Generic.List.Enumerator<TRVCategoryButton> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVCategorySelection.<CheckCrazyCategories>d__47(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 1)
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
        var val_5;
        List.Enumerator<TRVCategoryButton> val_6;
        UnityEngine.UI.Image val_15;
        int val_16;
        string val_17;
        List.Enumerator<TRVCategoryButton> val_18;
        if((this.<>1__state) != 1)
        {
                if((this.<>1__state) == 0)
        {
                this.<>1__state = 0;
            if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID != null)
        {
                if((System.String.IsNullOrEmpty(value:  TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32)) == false)
        {
            goto label_5;
        }
        
        }
        
        }
        
            val_16 = 0;
            return (bool)val_16;
        }
        
        this.<>1__state = -3;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = this.<>4__this.crazyCategoryImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = 0;
        UnityEngine.RectTransform val_2 = val_15.rectTransform;
        val_15 = 0;
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.anchoredPosition = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
        val_18 = this.<>7__wrap1;
        goto label_12;
        label_5:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_4 = this.<>4__this.catButtons.GetEnumerator();
        val_18 = this.<>7__wrap1;
        mem[1152921517232794584] = val_5;
        this.<>7__wrap1 = val_6;
        this.<>1__state = -3;
        label_12:
        label_23:
        val_17 = public System.Boolean List.Enumerator<TRVCategoryButton>::MoveNext();
        val_15 = val_18;
        if(val_15.MoveNext() == false)
        {
            goto label_15;
        }
        
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
            goto label_23;
        }
        
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15 = mem[X22 + 128];
        val_15 = X22 + 128;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_17 = 0;
        if(TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = mem[TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32];
        val_15 = TRVCrazyCategoriesEventHandler.EVENT_TRACKING_ID + 32;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_15.ToLower();
        val_15 = val_15.ToLower();
        if((System.String.op_Equality(a:  val_15, b:  val_17)) == false)
        {
            goto label_23;
        }
        
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = this.<>4__this.crazyCategoryImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_11 = val_15.transform;
        val_17 = X22.transform;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.SetParent(p:  val_17);
        val_15 = this.<>4__this.crazyCategoryImage;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = 0;
        UnityEngine.GameObject val_13 = val_15.gameObject;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16 = 1;
        val_13.SetActive(value:  true);
        this.<>2__current = 0;
        this.<>1__state = val_16;
        return (bool)val_16;
        label_15:
        this.<>m__Finally1();
        val_16 = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        return (bool)val_16;
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

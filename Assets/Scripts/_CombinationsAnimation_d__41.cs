using UnityEngine;
private sealed class BingoEventPopup.<CombinationsAnimation>d__41 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public BingoEventPopup <>4__this;
    private System.Collections.Generic.List.Enumerator<System.Collections.Generic.List<UnityEngine.Vector2Int>> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BingoEventPopup.<CombinationsAnimation>d__41(int <>1__state)
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
        List.Enumerator<System.Collections.Generic.List<UnityEngine.Vector2Int>> val_4;
        BingoCell val_16;
        int val_17;
        List.Enumerator<System.Collections.Generic.List<UnityEngine.Vector2Int>> val_18;
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
            goto label_12;
        }
        
        this.<>1__state = 0;
        val_17 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_17;
        return (bool)val_17;
        label_2:
        this.<>1__state = 0;
        goto label_17;
        label_1:
        val_18 = this.<>7__wrap1;
        this.<>1__state = -3;
        goto label_6;
        label_17:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.eventHandler) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.eventHandler.<combinations>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_2 = this.<>4__this.eventHandler.<combinations>k__BackingField.GetEnumerator();
        val_18 = this.<>7__wrap1;
        mem[1152921516094087128] = val_3;
        this.<>7__wrap1 = val_4;
        this.<>1__state = -3;
        label_6:
        if(val_18.MoveNext() == true)
        {
            goto label_16;
        }
        
        this.<>m__Finally1();
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        goto label_17;
        label_16:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.bingoCells) == null)
        {
                throw new NullReferenceException();
        }
        
        var val_16 = 0;
        label_25:
        if(val_16 >= (this.<>4__this.bingoCells.Length))
        {
            goto label_20;
        }
        
        if(val_16 >= (this.<>4__this.bingoCells.Length))
        {
                throw new IndexOutOfRangeException();
        }
        
        if((this.<>4__this.bingoCells[val_16]) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.bingoCells[0x0][0].highlightBG) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_6 = this.<>4__this.bingoCells[0x0][0].highlightBG.gameObject;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.SetActive(value:  false);
        val_16 = val_16 + 1;
        if((this.<>4__this.bingoCells) != null)
        {
            goto label_25;
        }
        
        throw new NullReferenceException();
        label_20:
        List.Enumerator<T> val_7 = val_18.GetEnumerator();
        label_33:
        if(val_4.MoveNext() == false)
        {
            goto label_27;
        }
        
        var val_17 = val_3;
        val_16 = val_17.y;
        if((this.<>4__this.bingoCells) == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_16 + (val_16 << 2);
        val_17 = val_17.x + val_17;
        val_16 = this.<>4__this.bingoCells[val_17];
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.bingoCells[(val_10 + (val_9 + (val_9) << 2))][0].highlightBG) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_11 = this.<>4__this.bingoCells[(val_10 + (val_9 + (val_9) << 2))][0].highlightBG.gameObject;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.SetActive(value:  true);
        PluginExtension.SetColorAlpha(graphic:  this.<>4__this.bingoCells[(val_10 + (val_9 + (val_9) << 2))][0].highlightBG, a:  0f);
        DG.Tweening.Tweener val_13 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.bingoCells[(val_10 + (val_9 + (val_9) << 2))][0].highlightBG, endValue:  1f, duration:  0.5f), ease:  4);
        goto label_33;
        label_27:
        val_16 = 0;
        val_4.Dispose();
        if(val_16 != 0)
        {
                throw null;
        }
        
        val_17 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  3f);
        this.<>1__state = 2;
        return (bool)val_17;
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

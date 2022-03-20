using UnityEngine;
private sealed class SnakeBlockController.<Continue>d__41 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.SnackBlock.SnakeBlockController <>4__this;
    private System.Collections.Generic.List.Enumerator<UnityEngine.GameObject> <>7__wrap1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SnakeBlockController.<Continue>d__41(int <>1__state)
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
        var val_3;
        List.Enumerator<UnityEngine.GameObject> val_4;
        SLC.Minigames.SnackBlock.SnakeBlockController val_18;
        DG.Tweening.Tweener val_19;
        List.Enumerator<UnityEngine.GameObject> val_20;
        int val_21;
        val_18 = this.<>4__this;
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
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.resetting = true;
        val_18.enabled = true;
        this.<>4__this.removeTailProgress = val_18.liveDeductionInterval;
        if((this.<>4__this.startingLifes) >= 1)
        {
                do
        {
            val_18.AddTail();
            val_19 = 0 + 1;
        }
        while(val_19 < (this.<>4__this.startingLifes));
        
        }
        
        this.<>4__this.speed = 0f;
        List.Enumerator<T> val_2 = this.<>4__this.myTails.GetEnumerator();
        val_20 = this.<>7__wrap1;
        mem[1152921519901079192] = val_3;
        this.<>7__wrap1 = val_4;
        this.<>1__state = -3;
        goto label_8;
        label_2:
        val_20 = this.<>7__wrap1;
        this.<>1__state = -3;
        label_8:
        if(val_20.MoveNext() == false)
        {
            goto label_9;
        }
        
        SnakeBlockController.<>c__DisplayClass41_0 val_6 = null;
        val_18 = val_6;
        val_6 = new SnakeBlockController.<>c__DisplayClass41_0();
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        .tail = val_6;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = DG.Tweening.ShortcutExtensions43.DOFade(target:  val_6.GetComponent<UnityEngine.SpriteRenderer>(), endValue:  0f, duration:  0.9f);
        DG.Tweening.Tweener val_11 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_19, action:  new DG.Tweening.TweenCallback(object:  val_6, method:  System.Void SnakeBlockController.<>c__DisplayClass41_0::<Continue>b__0())), loops:  3);
        val_21 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        this.<>1__state = val_21;
        return (bool)val_21;
        label_1:
        this.<>1__state = 0;
        SLC.Minigames.SnackBlock.SnakeBlockManager val_13 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        float val_14 = val_13.getSpeedForLevel;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_21 = 0;
        this.<>4__this.speed = val_14;
        this.<>4__this.cachedSpeed = val_14;
        this.<>4__this.resetting = false;
        return (bool)val_21;
        label_9:
        this.<>m__Finally1();
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  3f);
        this.<>1__state = 2;
        val_21 = 1;
        return (bool)val_21;
        label_3:
        val_21 = 0;
        return (bool)val_21;
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

using UnityEngine;
private sealed class BingoEventPopup.<CollectBallsAnimation>d__40 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public BingoEventPopup <>4__this;
    private BingoEventPopup.<>c__DisplayClass40_0 <>8__1;
    private BingoEventPopup.<>c__DisplayClass40_2 <>8__2;
    private float <ballWidth>5__2;
    private int <i>5__3;
    private UnityEngine.GameObject <goBall>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BingoEventPopup.<CollectBallsAnimation>d__40(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_49;
        System.Collections.Generic.List<UnityEngine.GameObject> val_50;
        int val_53;
        var val_56;
        if((this.<>1__state) > 7)
        {
            goto label_48;
        }
        
        var val_49 = 32560456 + (this.<>1__state) << 2;
        val_49 = val_49 + 32560456;
        goto (32560456 + (this.<>1__state) << 2 + 32560456);
        label_65:
        if( >= (this.<>8__1.goBalls))
        {
            goto label_54;
        }
        
        .CS$<>8__locals1 = this.<>8__1;
        if((this.<>8__1) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        .prevBall = BingoEventPopup.<>c__DisplayClass40_0.__il2cppRuntimeField_byval_arg;
        float val_52 = this.<ballWidth>5__2;
        var val_26 =  + 1;
        val_52 = val_52 * 1.15f;
        val_52 = val_52 * (float)val_26;
        DG.Tweening.Tweener val_27 = DG.Tweening.ShortcutExtensions.DOLocalMoveX(target:  BingoEventPopup.<>c__DisplayClass40_0.__il2cppRuntimeField_byval_arg.transform, endValue:  val_52, duration:  0.5f, snapping:  false);
        if(val_26 >= 4)
        {
                DG.Tweening.Tweener val_29 = DG.Tweening.ShortcutExtensions.DOScale(target:  (BingoEventPopup.<>c__DisplayClass40_1)[1152921516093101984].prevBall.transform, endValue:  null, duration:  0.5f);
            DG.Tweening.TweenCallback val_30 = new DG.Tweening.TweenCallback(object:  new BingoEventPopup.<>c__DisplayClass40_1(), method:  System.Void BingoEventPopup.<>c__DisplayClass40_1::<CollectBallsAnimation>b__0());
            System.Delegate val_31 = System.Delegate.Combine(a:  null, b:  val_30);
            if(val_31 != null)
        {
                if(null != null)
        {
            goto label_82;
        }
        
        }
        
            mem2[0] = val_31;
        }
        
         =  + 1;
        if((this.<>8__1) != null)
        {
            goto label_65;
        }
        
        this.<>1__state = 0;
        if(0 == 0)
        {
            goto label_68;
        }
        
        val_30.ShowBingoCompleted();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1.5f);
        val_53 = 7;
        goto label_95;
        label_83:
        if( >= (this.<>8__1.goBalls))
        {
            goto label_72;
        }
        
        BingoEventPopup.<>c__DisplayClass40_3 val_33 = null;
        val_50 = val_33;
        val_33 = new BingoEventPopup.<>c__DisplayClass40_3();
        if((this.<>8__1) <= )
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        .ballGO = BingoEventPopup.<>c__DisplayClass40_0.__il2cppRuntimeField_byval_arg;
        System.Collections.Generic.List<UnityEngine.GameObject> val_53 = this.<>8__1.goBalls;
        val_53 =  + val_53;
        float val_54 = (float)val_53;
        val_54 = val_54 * ;
        DG.Tweening.Tweener val_36 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  BingoEventPopup.<>c__DisplayClass40_0.__il2cppRuntimeField_byval_arg.transform, endValue:  null, duration:  0.5f), delay:  val_54);
        System.Delegate val_38 = System.Delegate.Combine(a:  null, b:  new DG.Tweening.TweenCallback(object:  val_33, method:  System.Void BingoEventPopup.<>c__DisplayClass40_3::<CollectBallsAnimation>b__2()));
        if(val_38 != null)
        {
                if(null != null)
        {
            goto label_82;
        }
        
        }
        
        mem2[0] = val_38;
         =  + 1;
        val_56 =  - 1;
        if((this.<>8__1) != null)
        {
            goto label_83;
        }
        
        throw new NullReferenceException();
        label_54:
        val_53 = 2;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        goto label_95;
        label_72:
        Clear();
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.8f);
        val_53 = 6;
        label_95:
        this.<>1__state = val_53;
        val_49 = 1;
        return (bool)val_49;
        label_68:
        val_30.UpdateUI(state:  2);
        label_48:
        val_49 = 0;
        return (bool)val_49;
        label_82:
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

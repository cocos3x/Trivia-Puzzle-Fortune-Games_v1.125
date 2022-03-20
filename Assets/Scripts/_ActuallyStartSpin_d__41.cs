using UnityEngine;
private sealed class Scroller.<ActuallyStartSpin>d__41 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Scroller <>4__this;
    public DG.Tweening.TweenCallback callback;
    public int scrollCount;
    private Scroller.<>c__DisplayClass41_0 <>8__1;
    public float duration;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Scroller.<ActuallyStartSpin>d__41(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        Scroller.<>c__DisplayClass41_0 val_27;
        int val_28;
        float val_29;
        float val_30;
        var val_31;
        DG.Tweening.TweenCallback val_33;
        val_27 = this;
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
        this.<>8__1 = new Scroller.<>c__DisplayClass41_0();
        .<>4__this = this.<>4__this;
        this.<>8__1.callback = this.callback;
        val_28 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = val_28;
        return (bool)val_28;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.layoutGroup.enabled = false;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        this.<>1__state = 2;
        val_28 = 1;
        return (bool)val_28;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.movedDistance = 0f;
        this.<>4__this.moveNeed = 0f;
        this.<>4__this.<isScrolling>k__BackingField = true;
        DG.Tweening.Sequence val_4 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_4, autoKillOnCompletion:  false);
        val_29 = 0f;
        val_30 = 0f;
        if((this.<>4__this.isWindStart) == false)
        {
            goto label_17;
        }
        
        if((this.<>4__this.windStart) == 0f)
        {
            goto label_14;
        }
        
        val_30 = 0f;
        DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void Scroller.<>c__DisplayClass41_0::<ActuallyStartSpin>b__0(float value)), startValue:  0f, endValue:  -((this.<>4__this.windStart) * (this.<>4__this.<itemSpace>k__BackingField)), duration:  this.<>4__this.windStartTime), ease:  this.<>4__this.moveNeed));
        if((this.<>4__this.isWindStart) == false)
        {
            goto label_17;
        }
        
        label_14:
        val_30 = this.<>4__this.windStart;
        label_17:
        if((this.<>4__this.isWindEnd) != false)
        {
                val_29 = this.<>4__this.windEnd;
        }
        
        float val_11 = (this.<>4__this.<itemSpace>k__BackingField) * (float)this.scrollCount;
        float val_13 = val_29 * (this.<>4__this.<itemSpace>k__BackingField);
        val_13 = val_11 + val_13;
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void Scroller.<>c__DisplayClass41_0::<ActuallyStartSpin>b__1(float value)), startValue:  -(val_30 * (this.<>4__this.<itemSpace>k__BackingField)), endValue:  val_13, duration:  this.duration), ease:  this.<>4__this.moveNeed));
        val_31 = null;
        val_31 = null;
        val_33 = Scroller.<>c.<>9__41_2;
        if(val_33 == null)
        {
                DG.Tweening.TweenCallback val_18 = null;
            val_33 = val_18;
            val_18 = new DG.Tweening.TweenCallback(object:  Scroller.<>c.__il2cppRuntimeField_static_fields, method:  System.Void Scroller.<>c::<ActuallyStartSpin>b__41_2());
            Scroller.<>c.<>9__41_2 = val_33;
        }
        
        DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_4, callback:  val_18);
        if(((this.<>4__this.isWindEnd) != false) && ((this.<>4__this.windEnd) != 0f))
        {
                val_29 = this.<>4__this.<itemSpace>k__BackingField;
            float val_21 = (this.<>4__this.windEnd) * val_29;
            val_21 = val_11 + val_21;
            DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void Scroller.<>c__DisplayClass41_0::<ActuallyStartSpin>b__3(float value)), startValue:  val_21, endValue:  val_11, duration:  this.<>4__this.windEndTime), ease:  this.<>4__this.moveNeed));
        }
        
        val_27 = this.<>8__1;
        DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_4, action:  new DG.Tweening.TweenCallback(object:  val_27, method:  System.Void Scroller.<>c__DisplayClass41_0::<ActuallyStartSpin>b__4()));
        DG.Tweening.TweenExtensions.PlayForward(t:  val_4);
        label_3:
        val_28 = 0;
        return (bool)val_28;
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

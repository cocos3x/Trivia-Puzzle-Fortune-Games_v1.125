using UnityEngine;
private sealed class WADPetProfile.<ShowLevelupAnim>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WADPetProfile <>4__this;
    private WADPetProfile.<>c__DisplayClass21_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WADPetProfile.<ShowLevelupAnim>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WADPetProfile val_11;
        int val_12;
        val_11 = this.<>4__this;
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
        this.<>8__1 = new WADPetProfile.<>c__DisplayClass21_0();
        .cg = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.levelupAnim);
        this.<>8__1.cg.alpha = 0f;
        val_12 = 1;
        this.<>4__this.levelupAnim.SetActive(value:  true);
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_5 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this.<>8__1, method:  System.Single WADPetProfile.<>c__DisplayClass21_0::<ShowLevelupAnim>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void WADPetProfile.<>c__DisplayClass21_0::<ShowLevelupAnim>b__1(float x)), endValue:  1f, duration:  0.3f);
        UnityEngine.WaitForSeconds val_6 = null;
        val_11 = val_6;
        val_6 = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>2__current = val_11;
        this.<>1__state = val_12;
        return (bool)val_12;
        label_2:
        this.<>1__state = 0;
        DG.Tweening.Core.DOSetter<System.Single> val_8 = null;
        val_11 = val_8;
        val_8 = new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void WADPetProfile.<>c__DisplayClass21_0::<ShowLevelupAnim>b__3(float x));
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_9 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this.<>8__1, method:  System.Single WADPetProfile.<>c__DisplayClass21_0::<ShowLevelupAnim>b__2()), setter:  val_8, endValue:  0f, duration:  0.3f);
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = 2;
        val_12 = 1;
        return (bool)val_12;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.levelupAnim.SetActive(value:  false);
        label_3:
        val_12 = 0;
        return (bool)val_12;
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

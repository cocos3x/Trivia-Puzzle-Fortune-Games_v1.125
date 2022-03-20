using UnityEngine;
private sealed class PortraitCollectionCollectionItem.<ExpandCollectionClosed>d__20 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public PortraitCollectionCollectionItem <>4__this;
    private PortraitCollectionCollectionItem.<>c__DisplayClass20_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public PortraitCollectionCollectionItem.<ExpandCollectionClosed>d__20(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        PortraitCollectionCollectionItem.<>c__DisplayClass20_0 val_19;
        int val_20;
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
        PortraitCollectionCollectionItem.<>c__DisplayClass20_0 val_1 = null;
        val_19 = val_1;
        val_1 = new PortraitCollectionCollectionItem.<>c__DisplayClass20_0();
        this.<>8__1 = val_19;
        .<>4__this = this.<>4__this;
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.<>4__this.allPortraitsSection), endValue:  0f, duration:  0.2f);
        val_20 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
        this.<>1__state = val_20;
        return (bool)val_20;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.allPortraitsSection.gameObject.SetActive(value:  false);
        UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -90f);
        DG.Tweening.Tweener val_8 = DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this.<>4__this.expandImage.transform, endValue:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.3f, mode:  0);
        this.<>8__1.rectT = this.<>4__this.gameObject.GetComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector2 val_12 = this.<>8__1.rectT.sizeDelta;
        this.<>8__1.rectSize = val_12;
        mem2[0] = val_12.y;
        this.<>8__1.prog = 1f;
        DG.Tweening.Tweener val_13 = DG.Tweening.ShortcutExtensions46.DOFade(target:  MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.collectionPortraitSection), endValue:  1f, duration:  0.3f);
        val_19 = DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this.<>8__1, method:  System.Single PortraitCollectionCollectionItem.<>c__DisplayClass20_0::<ExpandCollectionClosed>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void PortraitCollectionCollectionItem.<>c__DisplayClass20_0::<ExpandCollectionClosed>b__1(float x)), endValue:  0f, duration:  0.4f);
        DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions> val_18 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  val_19, action:  new DG.Tweening.TweenCallback(object:  this.<>8__1, method:  System.Void PortraitCollectionCollectionItem.<>c__DisplayClass20_0::<ExpandCollectionClosed>b__2()));
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_20 = 1;
        return (bool)val_20;
        label_1:
        val_20 = 0;
        this.<>1__state = 0;
        return (bool)val_20;
        label_3:
        val_20 = 0;
        return (bool)val_20;
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

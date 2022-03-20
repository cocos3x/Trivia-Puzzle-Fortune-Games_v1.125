using UnityEngine;
private sealed class WFOEventPointsGainAnimator.<ShowPointGainAnimationCoroutine>d__37 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WFOEventPointsGainAnimator <>4__this;
    public int toQty;
    public int fromQty;
    public int maxQty;
    public System.Action onAnimationComplete;
    private int <iterAmt>5__2;
    private int <i>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOEventPointsGainAnimator.<ShowPointGainAnimationCoroutine>d__37(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_50;
        int val_51;
        int val_52;
        int val_53;
        int val_54;
        int val_55;
        int val_56;
        int val_57;
        var val_58;
        DG.Tweening.TweenCallback val_60;
        var val_61;
        System.Action val_63;
        var val_64;
        if((this.<>1__state) > 3)
        {
            goto label_1;
        }
        
        var val_49 = 32562328 + (this.<>1__state) << 2;
        val_49 = val_49 + 32562328;
        goto (32562328 + (this.<>1__state) << 2 + 32562328);
        label_59:
        WFOEventPointsGainAnimator.<>c__DisplayClass37_0 val_8 = null;
        val_52 = val_8;
        val_8 = new WFOEventPointsGainAnimator.<>c__DisplayClass37_0();
        .<>4__this = ;
        UnityEngine.GameObject val_10 = new UnityEngine.GameObject(name:  "PointIconParent_" +);
        .iconParentObj = val_10;
        val_10.transform.SetParent(p:  0);
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, d:  null);
        (WFOEventPointsGainAnimator.<>c__DisplayClass37_0)[1152921517433646816].iconParentObj.transform.localScale = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        UnityEngine.Vector3 val_16 = UnityEngine.Vector3.zero;
        (WFOEventPointsGainAnimator.<>c__DisplayClass37_0)[1152921517433646816].iconParentObj.transform.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
        UnityEngine.RectTransform val_17 = (WFOEventPointsGainAnimator.<>c__DisplayClass37_0)[1152921517433646816].iconParentObj.AddComponent<UnityEngine.RectTransform>();
        UnityEngine.Vector2 val_18 = UnityEngine.Vector2.zero;
        val_17.anchoredPosition = new UnityEngine.Vector2() {x = val_18.x, y = val_18.y};
        UnityEngine.Vector2 val_19 = UnityEngine.Vector2.zero;
        val_17.sizeDelta = new UnityEngine.Vector2() {x = val_19.x, y = val_19.y};
        UnityEngine.UI.Image val_21 = UnityEngine.Object.Instantiate<UnityEngine.UI.Image>(original:  val_17, parent:  (WFOEventPointsGainAnimator.<>c__DisplayClass37_0)[1152921517433646816].iconParentObj.transform);
        val_21.sprite = GetFlySprite();
        UnityEngine.Vector3 val_24 = UnityEngine.Vector3.zero;
        val_21.transform.localPosition = new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z};
        UnityEngine.Vector3 val_26 = UnityEngine.Vector3.one;
        val_21.transform.localScale = new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z};
        val_21.gameObject.SetActive(value:  true);
        UnityEngine.Vector2 val_30 = rectTransform.sizeDelta;
        val_21.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_30.x, y = val_30.y};
        val_21.preserveAspect = true;
        DG.Tweening.Sequence val_31 = DG.Tweening.DOTween.Sequence();
        val_58 = null;
        val_58 = null;
        val_60 = WFOEventPointsGainAnimator.<>c.<>9__37_0;
        if(val_60 == null)
        {
                DG.Tweening.TweenCallback val_32 = null;
            val_60 = val_32;
            val_32 = new DG.Tweening.TweenCallback(object:  WFOEventPointsGainAnimator.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOEventPointsGainAnimator.<>c::<ShowPointGainAnimationCoroutine>b__37_0());
            WFOEventPointsGainAnimator.<>c.<>9__37_0 = val_60;
        }
        
        DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_31, callback:  val_32);
        UnityEngine.Vector3 val_34 = UnityEngine.Vector3.one;
        DG.Tweening.Sequence val_36 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_31, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_32, endValue:  new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z}, duration:  1f));
        DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_31, t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_31, interval:  0.5f), endValue:  0f, duration:  0.5f), delay:  0.1f));
        val_61 = null;
        val_61 = null;
        val_63 = WFOEventPointsGainAnimator.<>c.<>9__37_1;
        if(val_63 == null)
        {
                val_64 = this;
            System.Action val_43 = null;
            val_63 = val_43;
            val_43 = new System.Action(object:  WFOEventPointsGainAnimator.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOEventPointsGainAnimator.<>c::<ShowPointGainAnimationCoroutine>b__37_1());
            val_55 = ;
            WFOEventPointsGainAnimator.<>c.<>9__37_1 = val_63;
        }
        
        MoveSymbol(sq:  val_31, trans:  (WFOEventPointsGainAnimator.<>c__DisplayClass37_0)[1152921517433646816].iconParentObj.transform, dest:  transform, onComplete:  val_43);
        val_50 = 1152921504797261824;
        DG.Tweening.Sequence val_45 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_31, callback:  new DG.Tweening.TweenCallback(object:  val_8, method:  System.Void WFOEventPointsGainAnimator.<>c__DisplayClass37_0::<ShowPointGainAnimationCoroutine>b__2()));
        val_56 = ;
        var val_50 = val_56;
        val_50 = val_50 - 1;
        if( != val_50)
        {
            goto label_58;
        }
        
        DG.Tweening.TweenCallback val_46 = null;
        val_52 = val_46;
        val_46 = new DG.Tweening.TweenCallback(object:  null, method:  System.Void WFOEventPointsGainAnimator::<ShowPointGainAnimationCoroutine>b__37_3());
        DG.Tweening.Sequence val_47 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_31, callback:  val_46);
        ShowProgressBarAnimation(fromQty:  -57958688, toQty:  this.toQty, maxQty:  this.maxQty, parentSeq:  val_31, onAnimationComplete:  this.onAnimationComplete);
        val_54 = val_55 + 1;
        mem2[0] = val_54;
        val_53 = mem[this.<iterAmt>5__2];
        val_53 = val_56;
        if(val_54 < val_53)
        {
            goto label_59;
        }
        
        label_1:
        val_51 = 0;
        return (bool)val_51;
        label_58:
        val_57 = 3;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
        this.<>1__state = val_57;
        val_51 = 1;
        return (bool)val_51;
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

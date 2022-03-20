using UnityEngine;
private sealed class WFOWordChestDisplay.<DoNewChestAnimationSequence>d__60 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WordForest.WFOWordChestDisplay <>4__this;
    public bool isFtux;
    private WordForest.WFOWordChestDisplay.<>c__DisplayClass60_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WFOWordChestDisplay.<DoNewChestAnimationSequence>d__60(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WFOWordChestDisplay.<>c__DisplayClass60_0 val_27;
        UnityEngine.CanvasGroup val_28;
        int val_29;
        val_27 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new WFOWordChestDisplay.<>c__DisplayClass60_0();
        .<>4__this = this.<>4__this;
        this.<>8__1.showFtux = this.isFtux;
        this.<>4__this.isAnimationActive = true;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.65f);
        System.Nullable<UnityEngine.Color> val_4 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
        UnityEngine.Transform[] val_6 = new UnityEngine.Transform[1];
        val_6[0] = this.<>4__this.gameObject.transform;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_6);
        this.<>4__this.UpdateChestLabels(skipAnimation:  false);
        val_28 = this.<>4__this.parentCanvasGroup;
        this.<>4__this.chestLabelsCanvasGroup.alpha = 0f;
        val_28.alpha = 0f;
        this.<>4__this.parentCanvasGroup.blocksRaycasts = false;
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  0f, y:  200f);
        this.<>4__this.chestRootTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        val_29 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        this.<>1__state = val_29;
        return (bool)val_29;
        label_1:
        this.<>1__state = 0;
        val_28 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector2 val_12 = UnityEngine.Vector2.zero;
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_28, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.<>4__this.chestRootTransform, endValue:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y}, duration:  0.125f, snapping:  false), ease:  30));
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_28, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.parentCanvasGroup, endValue:  1f, duration:  0.025f), ease:  1));
        DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_28, interval:  0.1f);
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_28, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.chestLabelsCanvasGroup, endValue:  1f, duration:  0.25f), ease:  1));
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_28, interval:  0.25f);
        val_27 = this.<>8__1;
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_28, action:  new DG.Tweening.TweenCallback(object:  val_27, method:  System.Void WFOWordChestDisplay.<>c__DisplayClass60_0::<DoNewChestAnimationSequence>b__0()));
        label_2:
        val_29 = 0;
        return (bool)val_29;
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

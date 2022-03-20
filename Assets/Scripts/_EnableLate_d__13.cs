using UnityEngine;
private sealed class WindowTransitionTween.<EnableLate>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WindowTransitionTween <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WindowTransitionTween.<EnableLate>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        WindowTransitionTween val_16;
        int val_17;
        DG.Tweening.TweenCallback val_18;
        val_16 = this.<>4__this;
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
            goto label_13;
        }
        
        val_17 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_17;
        return (bool)val_17;
        label_2:
        this.<>1__state = 0;
        val_16.SetInitialPosition();
        if((this.<>4__this.enterDirection) == 99)
        {
            goto label_6;
        }
        
        if((this.<>4__this.enterDirection) != 4)
        {
            goto label_7;
        }
        
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, d:  0.95f);
        this.<>4__this.rectTransform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
        DG.Tweening.TweenCallback val_6 = null;
        val_18 = val_6;
        val_6 = new DG.Tweening.TweenCallback(object:  val_16, method:  System.Void WindowTransitionTween::SetInteractable());
        DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.rectTransform, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  this.<>4__this.tweenDuration), ease:  this.<>4__this.easeType), action:  val_6);
        DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<>4__this.windowCanvasGroup, endValue:  1f, duration:  this.<>4__this.tweenDuration), ease:  this.<>4__this.easeType);
        goto label_13;
        label_1:
        this.<>1__state = 0;
        val_16.SetInteractable();
        goto label_13;
        label_6:
        UnityEngine.WaitForSeconds val_10 = null;
        val_16 = val_10;
        val_10 = new UnityEngine.WaitForSeconds(seconds:  0.25f);
        this.<>2__current = val_16;
        this.<>1__state = 2;
        val_17 = 1;
        return (bool)val_17;
        label_7:
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.zero;
        DG.Tweening.TweenCallback val_14 = null;
        val_18 = val_14;
        val_14 = new DG.Tweening.TweenCallback(object:  val_16, method:  System.Void WindowTransitionTween::SetInteractable());
        DG.Tweening.Tweener val_15 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.<>4__this.rectTransform, endValue:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y}, duration:  this.<>4__this.tweenDuration, snapping:  false), ease:  this.<>4__this.easeType), action:  val_14);
        label_13:
        val_17 = 0;
        return (bool)val_17;
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

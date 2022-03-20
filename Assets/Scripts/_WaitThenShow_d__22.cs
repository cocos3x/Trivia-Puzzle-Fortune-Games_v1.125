using UnityEngine;
private sealed class WGHintButton.<WaitThenShow>d__22 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGHintButton <>4__this;
    private UnityEngine.CanvasGroup <cg>5__2;
    private float <secondsPassed>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGHintButton.<WaitThenShow>d__22(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        DG.Tweening.Tweener val_19;
        int val_20;
        var val_21;
        UnityEngine.UI.Image val_22;
        float val_25;
        val_19 = this;
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
        
        val_20 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_20;
        return (bool)val_20;
        label_2:
        this.<>1__state = 0;
        this.<>4__this.popUp.SetActive(value:  true);
        UnityEngine.CanvasGroup val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.popUp);
        this.<cg>5__2 = val_1;
        val_1.alpha = 0f;
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<cg>5__2, endValue:  1f, duration:  0.1f);
        val_21 = val_19;
        this.<secondsPassed>5__3 = 0f;
        val_22 = this.<>4__this.hintImage;
        if(val_22 == 0)
        {
            goto label_16;
        }
        
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        val_22 = DG.Tweening.ShortcutExtensions.DOLocalJump(target:  this.<>4__this.hintImage.transform, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, jumpPower:  50f, numJumps:  2, duration:  1f, snapping:  true);
        DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_22, action:  new DG.Tweening.TweenCallback(object:  this.<>4__this, method:  System.Void WGHintButton::<WaitThenShow>b__22_0()));
        goto label_16;
        label_1:
        val_21 = val_19;
        this.<>1__state = 0;
        float val_9 = UnityEngine.Time.deltaTime;
        val_9 = (this.<secondsPassed>5__3) + val_9;
        this.<secondsPassed>5__3 = val_9;
        if(UnityEngine.Input.touchCount <= 0)
        {
                if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
            goto label_16;
        }
        
        }
        
        val_25 = this.<secondsPassed>5__3;
        if(val_25 <= 0.05f)
        {
            goto label_17;
        }
        
        goto label_18;
        label_16:
        val_25 = this.<secondsPassed>5__3;
        label_17:
        if(val_25 < 0)
        {
            goto label_19;
        }
        
        label_18:
        if((this.<>4__this.hintImage) != 0)
        {
                UnityEngine.Vector2 val_14 = UnityEngine.Vector2.zero;
            UnityEngine.Vector3 val_15 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y});
            this.<>4__this.hintImage.transform.localPosition = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        }
        
        val_19 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<cg>5__2, endValue:  0f, duration:  0.1f);
        DG.Tweening.TweenCallback val_17 = null;
        val_22 = val_17;
        val_17 = new DG.Tweening.TweenCallback(object:  this.<>4__this, method:  System.Void WGHintButton::<WaitThenShow>b__22_1());
        DG.Tweening.Tweener val_18 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_19, action:  val_17);
        label_3:
        val_20 = 0;
        return (bool)val_20;
        label_19:
        this.<>2__current = 0;
        this.<>1__state = 2;
        val_20 = 1;
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

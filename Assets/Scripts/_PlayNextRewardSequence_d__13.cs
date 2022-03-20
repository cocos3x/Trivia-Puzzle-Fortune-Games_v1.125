using UnityEngine;
private sealed class NextRewardPopup.<PlayNextRewardSequence>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public NextRewardPopup <>4__this;
    public WGEventButtonV2 eventButton;
    private DG.Tweening.Sequence <seq>5__2;
    private UnityEngine.WaitForSeconds <wait>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public NextRewardPopup.<PlayNextRewardSequence>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_46;
        if(((this.<>1__state) - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.<seq>5__2)) == false)
        {
            goto label_2;
        }
        
        this.<>1__state = 2;
        val_46 = 1;
        this.<>2__current = this.<wait>5__3;
        return (bool)val_46;
        label_1:
        if((this.<>1__state) != 0)
        {
            goto label_4;
        }
        
        this.<>1__state = 0;
        this.<>4__this.UpdateReward();
        this.<>4__this.rewardGroup.transform.localPosition = new UnityEngine.Vector3() {x = this.<>4__this.initialPos};
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
        this.<>4__this.titleTransform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
        this.<>4__this.rewardGroup.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.one;
        this.<>4__this.glow.transform.localScale = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
        DG.Tweening.Sequence val_9 = DG.Tweening.DOTween.Sequence();
        this.<seq>5__2 = val_9;
        DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.titleTransform, endValue:  1f, duration:  0.4f), ease:  6));
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.<seq>5__2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.rewardGroup.transform, endValue:  1f, duration:  0.7f), ease:  27));
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.<seq>5__2, interval:  0.3f);
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.<seq>5__2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.glow.transform, endValue:  0f, duration:  1.2f), ease:  3));
        UnityEngine.Vector3 val_23 = this.eventButton.transform.position;
        UnityEngine.Vector3 val_26 = MonoSingleton<WGFlyoutManager>.Instance.transform.position;
        UnityEngine.Vector3 val_27 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z}, b:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z});
        UnityEngine.Vector3 val_30 = MonoSingleton<WGWindowManager>.Instance.transform.position;
        UnityEngine.Vector3 val_31 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z}, b:  new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z});
        DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.<seq>5__2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.<>4__this.rewardGroup.transform, endValue:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, duration:  0.45f, snapping:  false), ease:  6));
        DG.Tweening.Sequence val_39 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.<seq>5__2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.rewardGroup.transform, endValue:  0f, duration:  0.45f), ease:  9));
        DG.Tweening.Sequence val_42 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.<seq>5__2, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.titleTransform, endValue:  0f, duration:  0.5f), ease:  9));
        this.<wait>5__3 = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        val_46 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_46;
        return (bool)val_46;
        label_2:
        SLCWindow.CloseWindow(window:  this.<>4__this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_4:
        val_46 = 0;
        return (bool)val_46;
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

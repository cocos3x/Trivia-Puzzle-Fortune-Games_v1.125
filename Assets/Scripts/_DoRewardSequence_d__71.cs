using UnityEngine;
private sealed class RaidMadnessEventHandler.<DoRewardSequence>d__71 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2 eventProgressUI;
    public WGLevelClearPopup popup;
    public WGEventButtonV2 eventButton;
    private UnityEngine.UI.Image <icon>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public RaidMadnessEventHandler.<DoRewardSequence>d__71(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        UnityEngine.Object val_26;
        int val_27;
        val_26 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.UI.Image val_2 = UnityEngine.Object.Instantiate<UnityEngine.UI.Image>(original:  this.eventProgressUI.icon, parent:  this.popup.transform);
        this.<icon>5__2 = val_2;
        UnityEngine.Vector3 val_5 = this.eventButton.transform.position;
        val_2.transform.position = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        this.<icon>5__2.rectTransform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        UnityEngine.Vector3 val_10 = this.popup.transform.localPosition;
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Multiply(d:  160f, a:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, b:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
        UnityEngine.Vector3 val_14 = this.popup.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        DG.Tweening.Tweener val_17 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<icon>5__2.transform, endValue:  8f, duration:  0.65f), ease:  27);
        DG.Tweening.Tweener val_20 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  this.<icon>5__2.transform, endValue:  val_14.x, duration:  0.65f, snapping:  false), ease:  3);
        DG.Tweening.Tweener val_23 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  this.<icon>5__2.transform, endValue:  val_14.y, duration:  0.65f, snapping:  false), ease:  3);
        val_27 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1.25f);
        this.<>1__state = val_27;
        return (bool)val_27;
        label_1:
        this.<>1__state = 0;
        val_26 = this.<icon>5__2.gameObject;
        UnityEngine.Object.Destroy(obj:  val_26);
        label_2:
        val_27 = 0;
        return (bool)val_27;
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

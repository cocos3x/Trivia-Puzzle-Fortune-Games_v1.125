using UnityEngine;
private sealed class HintMeterGameplayUI.<AnimateFills>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public HintMeterGameplayUI <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public HintMeterGameplayUI.<AnimateFills>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_17;
        UnityEngine.Transform val_18;
        int val_19;
        val_17 = this.<>1__state;
        if((val_17 - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this.gameObject.activeInHierarchy) == false)
        {
            goto label_18;
        }
        
        DG.Tweening.Tweener val_5 = DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.<>4__this.transform, duration:  0.1f, strength:  2f, vibrato:  10, randomness:  90f, snapping:  false, fadeOut:  true);
        DG.Tweening.Tweener val_7 = DG.Tweening.ShortcutExtensions.DOShakeScale(target:  this.<>4__this.transform, duration:  0.1f, strength:  0.02f, vibrato:  10, randomness:  90f, fadeOut:  true);
        var val_20 = 4;
        label_17:
        val_18 = val_20 - 4;
        if(val_18 >= (this.<>4__this.fillImages.Length))
        {
            goto label_6;
        }
        
        DG.Tweening.Tweener val_9 = DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.<>4__this.fillImages[0].transform, duration:  0.1f, strength:  1f, vibrato:  10, randomness:  90f, snapping:  false, fadeOut:  true);
        DG.Tweening.Tweener val_11 = DG.Tweening.ShortcutExtensions.DOShakeScale(target:  this.<>4__this.fillImages[0].transform, duration:  0.1f, strength:  0.05f, vibrato:  10, randomness:  90f, fadeOut:  true);
        val_18 = this.<>4__this.fillImages[0].transform;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.forward;
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, d:  5f);
        DG.Tweening.Tweener val_15 = DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  val_18, duration:  0.1f, strength:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, vibrato:  10, randomness:  90f, fadeOut:  true);
        val_17 = this.<>4__this.fillImages;
        val_20 = val_20 + 1;
        if(val_17 != null)
        {
            goto label_17;
        }
        
        throw new NullReferenceException();
        label_1:
        if(val_17 == null)
        {
                val_19 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_19;
            return (bool)val_19;
        }
        
        label_18:
        val_19 = 0;
        return (bool)val_19;
        label_6:
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        this.<>1__state = 2;
        val_19 = 1;
        return (bool)val_19;
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

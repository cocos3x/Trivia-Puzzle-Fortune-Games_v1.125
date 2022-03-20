using UnityEngine;
private sealed class BBLLevelClearPopup.<ClearSequence>d__22 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public BBLLevelClearPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BBLLevelClearPopup.<ClearSequence>d__22(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_10;
        int val_11;
        val_10 = 0;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
                return (bool)val_10;
        }
        
        this.<>1__state = 0;
        var val_14 = 0;
        label_19:
        if(val_14 >= (this.<>4__this.levelStars.Length))
        {
            goto label_5;
        }
        
        if((this.<>4__this.levelStars[0].gameObject.activeSelf) != false)
        {
                UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
            this.<>4__this.levelStars[0].rectTransform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
            float val_13 = 0f;
            val_13 = val_13 * 0.1f;
            val_13 = val_13 + 0.2f;
            DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<>4__this.levelStars[0].rectTransform, endValue:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, duration:  0.15f), ease:  27), delay:  val_13);
        }
        
        val_14 = val_14 + 1;
        if((this.<>4__this.levelStars) != null)
        {
            goto label_19;
        }
        
        throw new NullReferenceException();
        label_1:
        val_11 = 0;
        goto label_20;
        label_5:
        val_11 = 1;
        val_10 = 1;
        this.<>2__current = 0;
        label_20:
        this.<>1__state = val_11;
        return (bool)val_10;
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

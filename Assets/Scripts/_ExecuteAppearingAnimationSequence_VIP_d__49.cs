using UnityEngine;
private sealed class WGChapterClearPopup.<ExecuteAppearingAnimationSequence_VIP>d__49 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGChapterClearPopup <>4__this;
    private UnityEngine.CanvasGroup <cg>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGChapterClearPopup.<ExecuteAppearingAnimationSequence_VIP>d__49(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_7;
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
        if((this.<>4__this) != null)
        {
            goto label_4;
        }
        
        label_2:
        this.<>1__state = 0;
        if((this.<>4__this.animDone) == false)
        {
            goto label_7;
        }
        
        if((this.<cg>5__2.gameObject.name.Contains(value:  "Vip")) == false)
        {
            goto label_11;
        }
        
        val_7 = 1;
        this.<>4__this.vipImgAnim.enabled = true;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = 2;
        return (bool)val_7;
        label_1:
        this.<>1__state = 0;
        label_11:
        int val_7 = this.<>4__this.order;
        val_7 = val_7 + 1;
        this.<>4__this.order = val_7;
        if(val_7 != (this.<>4__this.appearingOrder.Length))
        {
            goto label_16;
        }
        
        label_3:
        val_7 = 0;
        return (bool)val_7;
        label_16:
        this.<>4__this.animDone = false;
        label_7:
        this.<cg>5__2 = 0;
        label_4:
        UnityEngine.CanvasGroup val_5 = this.<>4__this.appearingOrder[this.<>4__this.order].GetComponent<UnityEngine.CanvasGroup>();
        this.<cg>5__2 = val_5;
        val_7 = 1;
        this.<>2__current = this.<>4__this.ExecuteAppearingAnimation(cg:  val_5);
        this.<>1__state = val_7;
        return (bool)val_7;
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

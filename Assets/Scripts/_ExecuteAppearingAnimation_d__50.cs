using UnityEngine;
private sealed class WGChapterClearPopup.<ExecuteAppearingAnimation>d__50 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.CanvasGroup cg;
    public WGChapterClearPopup <>4__this;
    private float <f>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGChapterClearPopup.<ExecuteAppearingAnimation>d__50(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_4;
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        val_4 = 0f;
        this.<f>5__2 = 0f;
        this.<>1__state = 0;
        goto label_4;
        label_1:
        this.<>1__state = 0;
        val_4 = (this.<f>5__2) + UnityEngine.Time.deltaTime;
        this.<f>5__2 = val_4;
        if(val_4 > 0.5f)
        {
                val_5 = 0;
            this.<>4__this.animDone = true;
            return (bool)val_5;
        }
        
        label_4:
        this.cg.alpha = UnityEngine.Mathf.Lerp(a:  0f, b:  1f, t:  val_4 * 5f);
        val_5 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_5;
        return (bool)val_5;
        label_2:
        val_5 = 0;
        return (bool)val_5;
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

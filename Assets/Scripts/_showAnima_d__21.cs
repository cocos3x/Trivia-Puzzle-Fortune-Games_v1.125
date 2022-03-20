using UnityEngine;
private sealed class WGExtraWordsPopup.<showAnima>d__21 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.CanvasGroup cg;
    public WGExtraWordsPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGExtraWordsPopup.<showAnima>d__21(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_8;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_10;
        }
        
        this.<>1__state = 0;
        this.cg.alpha = UnityEngine.Mathf.Lerp(a:  this.cg.alpha, b:  1f, t:  0.2f);
        val_8 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  UnityEngine.Time.deltaTime);
        this.<>1__state = val_8;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        if(System.Math.Abs(this.cg.alpha) < 0)
        {
                UnityEngine.Coroutine val_7 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.showAnima(cg:  this.cg));
        }
        
        label_10:
        val_8 = 0;
        return (bool)val_8;
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

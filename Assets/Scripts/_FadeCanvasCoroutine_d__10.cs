using UnityEngine;
private sealed class DebugMessageDisplay.<FadeCanvasCoroutine>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public float duration;
    public DebugMessageDisplay <>4__this;
    public float from;
    public float to;
    private float <t>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public DebugMessageDisplay.<FadeCanvasCoroutine>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_4;
        float val_5;
        int val_6;
        float val_7;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        val_4 = 0f;
        this.<t>5__2 = 0f;
        this.<>1__state = 0;
        goto label_4;
        label_1:
        val_5 = this.<t>5__2;
        this.<>1__state = 0;
        if(val_5 < 0)
        {
            goto label_4;
        }
        
        this.<>4__this.canvasGroup.alpha = this.to;
        if(this.to < 0)
        {
                this.<>4__this.canvasGroup.gameObject.SetActive(value:  false);
        }
        
        label_7:
        val_6 = 0;
        return (bool)val_6;
        label_4:
        float val_2 = UnityEngine.Time.deltaTime;
        val_2 = val_2 / this.duration;
        val_7 = val_4 + val_2;
        this.<t>5__2 = val_7;
        this.<>4__this.canvasGroup.alpha = UnityEngine.Mathf.Lerp(a:  this.from, b:  this.to, t:  val_7);
        val_6 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_6;
        return (bool)val_6;
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

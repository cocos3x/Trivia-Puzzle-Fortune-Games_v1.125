using UnityEngine;
private sealed class ExtraWordsAnimationControl.<Fadeout>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public ExtraWordsAnimationControl <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ExtraWordsAnimationControl.<Fadeout>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_13;
        if((this.<>1__state) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = 0;
        UnityEngine.Color val_1 = this.<>4__this.skAnima.color;
        if(val_1.a > 0.01f)
        {
            goto label_4;
        }
        
        this.<>4__this.transform.parent.gameObject.SetActive(value:  false);
        label_1:
        val_13 = 0;
        return (bool)val_13;
        label_4:
        UnityEngine.Color val_5 = this.<>4__this.skAnima.color;
        UnityEngine.Color val_6 = this.<>4__this.skAnima.color;
        UnityEngine.Color val_7 = this.<>4__this.skAnima.color;
        UnityEngine.Color val_8 = this.<>4__this.skAnima.color;
        UnityEngine.Color val_10 = new UnityEngine.Color(r:  val_5.r, g:  val_6.g, b:  val_7.b, a:  UnityEngine.Mathf.Lerp(a:  val_8.a, b:  0f, t:  0.2f));
        this.<>4__this.skAnima.color = new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a};
        val_13 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  UnityEngine.Time.deltaTime);
        this.<>1__state = val_13;
        return (bool)val_13;
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

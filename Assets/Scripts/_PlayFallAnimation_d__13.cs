using UnityEngine;
private sealed class WGLevelChallengeProgressPopup.<PlayFallAnimation>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGLevelChallengeProgressPopup <>4__this;
    private float <time>5__2;
    private UnityEngine.RectTransform <myTransform>5__3;
    private UnityEngine.Vector2 <startPos>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGLevelChallengeProgressPopup.<PlayFallAnimation>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        float val_11;
        float val_12;
        int val_13;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        val_11 = this;
        this.<time>5__2 = 0f;
        this.<>1__state = 0;
        UnityEngine.RectTransform val_2 = this.<>4__this.gameObject.GetComponent<UnityEngine.RectTransform>();
        this.<myTransform>5__3 = val_2;
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.up;
        UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, d:  500f);
        val_2.anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
        UnityEngine.Vector2 val_5 = this.<myTransform>5__3.anchoredPosition;
        this.<startPos>5__4 = val_5;
        mem[1152921517904980316] = val_5.y;
        this.<>4__this.windowGroup.SetActive(value:  true);
        goto label_10;
        label_1:
        val_11 = this.<time>5__2;
        this.<>1__state = 0;
        label_10:
        val_12 = mem[this.<time>5__2];
        val_12 = val_11;
        if(val_12 < 0)
        {
            goto label_11;
        }
        
        label_2:
        val_13 = 0;
        return (bool)val_13;
        label_11:
        float val_6 = UnityEngine.Time.deltaTime;
        val_6 = val_12 + val_6;
        this.<time>5__2 = val_6;
        UnityEngine.Vector2 val_7 = UnityEngine.Vector2.zero;
        UnityEngine.Vector2 val_9 = UnityEngine.Vector2.Lerp(a:  new UnityEngine.Vector2() {x = this.<startPos>5__4, y = val_12}, b:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y}, t:  val_11 * 8f);
        this.<myTransform>5__3.anchoredPosition = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        val_13 = 1;
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
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

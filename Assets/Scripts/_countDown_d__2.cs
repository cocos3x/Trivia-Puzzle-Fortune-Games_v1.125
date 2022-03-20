using UnityEngine;
private sealed class TRVCountdownOverlay.<countDown>d__2 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVCountdownOverlay <>4__this;
    public int time;
    private UnityEngine.CanvasGroup <cg>5__2;
    private float <floatedTime>5__3;
    private float <animDuration>5__4;
    private float <animProgress>5__5;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVCountdownOverlay.<countDown>d__2(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_8;
        float val_9;
        float val_10;
        float val_11;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 1)
        {
                val_8 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_8;
        }
        
            this.<>1__state = 0;
            UnityEngine.CanvasGroup val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.<>4__this.gameObject);
            this.<cg>5__2 = val_2;
            val_2.alpha = 1f;
            val_9 = this.<floatedTime>5__3;
            val_10 = (float)this.time;
            this.<floatedTime>5__3 = val_10;
        }
        else
        {
                val_9 = this;
            val_10 = this.<floatedTime>5__3;
            this.<>1__state = 0;
        }
        
        if(val_10 > 0f)
        {
            goto label_7;
        }
        
        val_11 = 0.3f;
        this.<animDuration>5__4 = ;
        goto label_9;
        label_1:
        val_11 = this.<animProgress>5__5;
        this.<>1__state = 0;
        if(val_11 <= 0f)
        {
                this.<>4__this.gameObject.SetActive(value:  false);
            val_8 = 0;
            return (bool)val_8;
        }
        
        label_9:
        val_11 = val_11 / (this.<animDuration>5__4);
        this.<cg>5__2.alpha = val_11;
        float val_4 = UnityEngine.Time.deltaTime;
        val_4 = (this.<animProgress>5__5) - val_4;
        this.<>2__current = 0;
        this.<animProgress>5__5 = val_4;
        this.<>1__state = 2;
        val_8 = 1;
        return (bool)val_8;
        label_7:
        val_10 = val_10 - UnityEngine.Time.deltaTime;
        this.<floatedTime>5__3 = val_10;
        if(val_10 > 0.15f)
        {
                string val_7 = UnityEngine.Mathf.CeilToInt(f:  val_10).ToString();
        }
        
        float val_8 = (float)this.time;
        val_8 = (this.<floatedTime>5__3) / val_8;
        this.<>4__this.timeRemainingBar.fillAmount = val_8;
        val_8 = 1;
        this.<>2__current = 0;
        this.<>1__state = val_8;
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

using UnityEngine;
private sealed class TimerText.<UpdateClockText>d__11 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TimerText <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TimerText.<UpdateClockText>d__11(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        int val_3;
        int val_4;
        if((this.<>1__state) == 0)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 1)
        {
            goto label_8;
        }
        
        this.<>1__state = 0;
        val_2 = this.<>4__this.timeValue;
        if((this.<>4__this.countUp) == false)
        {
            goto label_4;
        }
        
        val_3 = val_2 + 1;
        goto label_5;
        label_1:
        val_2 = 0;
        this.<>1__state = val_2;
        if((this.<>4__this) != null)
        {
            goto label_11;
        }
        
        throw new NullReferenceException();
        label_4:
        if(val_2 == 0)
        {
            goto label_7;
        }
        
        val_3 = val_2 - 1;
        label_5:
        this.<>4__this.timeValue = val_3;
        label_11:
        if((this.<>4__this.isRunning) != false)
        {
                val_4 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
            this.<>1__state = val_4;
            return (bool)val_4;
        }
        
        label_8:
        val_4 = 0;
        return (bool)val_4;
        label_7:
        if((this.<>4__this.onCountDownComplete) != null)
        {
                this.<>4__this.onCountDownComplete.Invoke();
        }
        
        this.<>4__this.StopAllCoroutines();
        this.<>4__this.isRunning = false;
        goto label_11;
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

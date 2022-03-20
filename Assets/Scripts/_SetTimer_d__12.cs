using UnityEngine;
private sealed class WGGoldenGalaInfoPopup.<SetTimer>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGGoldenGalaInfoPopup <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGGoldenGalaInfoPopup.<SetTimer>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_10;
        var val_11;
        int val_12;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        System.TimeSpan val_1 = GoldenGalaHandler.dailyChallengeApple.GetTimeRemaining;
        val_10 = null;
        val_10 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_1._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_11 = null;
            val_11 = null;
        }
        
        string val_6 = System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  System.TimeSpan.Zero.Hours, arg1:  System.TimeSpan.Zero.Minutes, arg2:  System.TimeSpan.Zero.Seconds);
        val_12 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_12;
        return (bool)val_12;
        label_1:
        this.<>1__state = 0;
        UnityEngine.Coroutine val_9 = this.<>4__this.StartCoroutine(routine:  this.<>4__this.SetTimer());
        label_2:
        val_12 = 0;
        return (bool)val_12;
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

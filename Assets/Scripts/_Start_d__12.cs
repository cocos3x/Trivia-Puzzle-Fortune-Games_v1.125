using UnityEngine;
private sealed class NetworkThreadingHandler.<Start>d__12 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public NetworkThreadingHandler <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public NetworkThreadingHandler.<Start>d__12(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_7;
        int val_8;
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
        val_7 = null;
        val_7 = null;
        if(NetworkThreadingHandler.HackThrottle == false)
        {
            goto label_6;
        }
        
        this.<>4__this.delayRequest = UnityEngine.Random.Range(min:  3, max:  4);
        this.<>4__this.delayResponse = UnityEngine.Random.Range(min:  3, max:  4);
        goto label_8;
        label_2:
        this.<>1__state = 0;
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.ExecuteRequest());
        this.<>1__state = 2;
        val_8 = 1;
        return (bool)val_8;
        label_1:
        this.<>1__state = 0;
        this.<>4__this.CleanupRequest();
        label_3:
        val_8 = 0;
        return (bool)val_8;
        label_6:
        label_8:
        this.<>2__current = this.<>4__this.StartCoroutine(routine:  this.<>4__this.SitIdle());
        val_8 = 1;
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

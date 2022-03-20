using UnityEngine;
private sealed class WGDailyChallengeManager.<RequestValidIdDelayed>d__94 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGDailyChallengeManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGDailyChallengeManager.<RequestValidIdDelayed>d__94(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_4;
        int val_5;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>4__this.isRunningDelayedRequest = true;
        goto label_4;
        label_1:
        this.<>1__state = 0;
        label_4:
        Player val_1 = App.Player;
        if((System.String.op_Equality(a:  val_1.id, b:  " ")) != true)
        {
                val_4 = null;
            val_4 = null;
            if(NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE != null)
        {
                this.<>4__this.RequestChallengeData(firstTimeNewIdRequest:  true);
            val_5 = 0;
            this.<>4__this.isRunningDelayedRequest = false;
            return (bool)val_5;
        }
        
        }
        
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  10f);
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

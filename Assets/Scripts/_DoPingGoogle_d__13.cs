using UnityEngine;
private sealed class NetworkConnectivityPinger.<DoPingGoogle>d__13 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public NetworkConnectivityPinger <>4__this;
    private UnityEngine.WWW <ping>5__2;
    private float <timePassed>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public NetworkConnectivityPinger.<DoPingGoogle>d__13(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        NetworkConnectivityPinger val_31;
        int val_32;
        UnityEngine.WWW val_33;
        float val_34;
        int val_35;
        int val_36;
        int val_37;
        int val_38;
        int val_39;
        var val_40;
        var val_41;
        val_31 = this.<>4__this;
        if((this.<>1__state) != 1)
        {
                val_32 = 0;
            if((this.<>1__state) != 0)
        {
                return (bool)val_32;
        }
        
            this.<>1__state = 0;
            this.<>4__this.alreadyPinging = true;
            UnityEngine.WWW val_1 = new UnityEngine.WWW(url:  "https://www.google.com");
            val_33 = this;
            this.<ping>5__2 = val_1;
            string val_3 = "Pinging " + val_1.url;
            this.<timePassed>5__3 = 0f;
        }
        else
        {
                val_33 = this.<ping>5__2;
            this.<>1__state = 0;
        }
        
        val_34 = this.<timePassed>5__3;
        if((mem[this.<ping>5__2].isDone) != false)
        {
                if(val_31 != null)
        {
            goto label_8;
        }
        
        }
        
        if(val_34 < 0)
        {
            goto label_11;
        }
        
        label_8:
        var val_5 = (val_34 >= (this.<>4__this.time_out)) ? 1 : 0;
        string[] val_6 = new string[6];
        val_6[0] = "PING: ";
        float val_7 = mem[this.<ping>5__2].progress;
        val_7 = val_7 * 100f;
        val_35 = val_6.Length;
        val_6[1] = val_7.ToString();
        val_35 = val_6.Length;
        val_6[2] = "% ";
        val_36 = val_6.Length;
        val_6[3] = val_34.ToString();
        val_36 = val_6.Length;
        val_6[4] = "s timeOut: ";
        val_6[5] = val_5.ToString();
        string val_11 = +val_6;
        if(val_5 != 0)
        {
            goto label_64;
        }
        
        if((System.String.IsNullOrEmpty(value:  mem[this.<ping>5__2].error)) == false)
        {
            goto label_34;
        }
        
        string[] val_14 = new string[8];
        val_14[0] = "Ping Response\ntext: ";
        val_37 = val_14.Length;
        val_14[1] = mem[this.<ping>5__2].text;
        val_37 = val_14.Length;
        val_14[2] = "\nsize: ";
        val_38 = val_14.Length;
        val_14[3] = mem[this.<ping>5__2].size.ToString();
        val_38 = val_14.Length;
        val_14[4] = "\nbytesDownloaded: ";
        val_39 = val_14.Length;
        val_14[5] = mem[this.<ping>5__2].bytesDownloaded.ToString();
        val_39 = val_14.Length;
        val_14[6] = "\nerror: ";
        val_14[7] = mem[this.<ping>5__2].error;
        string val_21 = +val_14;
        goto label_64;
        label_11:
        float val_22 = UnityEngine.Time.deltaTime;
        val_22 = val_34 + val_22;
        this.<timePassed>5__3 = val_22;
        UnityEngine.WaitForEndOfFrame val_23 = null;
        val_31 = val_23;
        val_23 = new UnityEngine.WaitForEndOfFrame();
        val_32 = 1;
        this.<>2__current = val_31;
        this.<>1__state = val_32;
        return (bool)val_32;
        label_34:
        string val_25 = "Ping Error:\n"("Ping Error:\n") + mem[this.<ping>5__2].error(mem[this.<ping>5__2].error);
        label_64:
        val_34 = 0;
        if(((mem[this.<ping>5__2].isDone) != false) && (val_5 == 0))
        {
                val_34 = System.String.IsNullOrEmpty(value:  mem[this.<ping>5__2].error);
        }
        
        val_40 = null;
        val_40 = null;
        NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE = val_34;
        this.<>4__this.alreadyPinging = false;
        mem[this.<ping>5__2].Dispose();
        NotificationCenter.DefaultCenter.PostNotification(aSender:  val_31, aName:  "OnNetworkConnectivityResponse");
        val_31 = this.<>4__this.OnPingDone;
        if(val_31 != null)
        {
                val_41 = null;
            val_41 = null;
            val_31.Invoke(obj:  NetworkConnectivityPinger.NOTIF_NETWORK_CONNECT_RESPONSE);
        }
        
        val_32 = 0;
        return (bool)val_32;
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

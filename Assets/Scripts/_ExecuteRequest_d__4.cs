using UnityEngine;
private sealed class RemoteResourcesLoadingRequestHandler.<ExecuteRequest>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public RemoteResourcesLoadingRequestHandler <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public RemoteResourcesLoadingRequestHandler.<ExecuteRequest>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_8;
        int val_9;
        var val_10;
        var val_11;
        System.Byte[] val_12;
        val_8 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_17;
        }
        
        this.<>1__state = 0;
        this.<>4__this.req.timeout = 30;
        this.<>2__current = this.<>4__this.req.SendWebRequest();
        val_9 = 1;
        this.<>1__state = val_9;
        return (bool)val_9;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this.req.isNetworkError) != true)
        {
                if((this.<>4__this.req.isHttpError) == false)
        {
            goto label_11;
        }
        
        }
        
        val_8 = "Download Error: "("Download Error: ") + this.<>4__this.req.error(this.<>4__this.req.error);
        UnityEngine.Debug.LogWarning(message:  val_8);
        val_9 = this.<>4__this.callback;
        if(val_9 == null)
        {
                return (bool)val_9;
        }
        
        val_10 = 1152921517617985248;
        val_11 = 0;
        val_12 = 0;
        goto label_16;
        label_11:
        val_8 = this.<>4__this.callback;
        if(val_8 == null)
        {
            goto label_17;
        }
        
        val_10 = 1152921517617985248;
        val_12 = this.<>4__this.req.downloadHandler.data;
        val_11 = 1;
        label_16:
        val_8.Invoke(arg1:  true, arg2:  val_12);
        label_17:
        val_9 = 0;
        return (bool)val_9;
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

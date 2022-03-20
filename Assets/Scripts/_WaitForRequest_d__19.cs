using UnityEngine;
private sealed class ApiRequester.<WaitForRequest>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public UnityEngine.WWW urlToCall;
    public ApiRequester <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ApiRequester.<WaitForRequest>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        ApiRequester val_7;
        int val_8;
        var val_9;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_9;
        }
        
        val_8 = 1;
        this.<>1__state = val_8;
        this.<>2__current = this.urlToCall;
        return (bool)val_8;
        label_1:
        val_7 = this.<>4__this;
        this.<>1__state = 0;
        string val_1 = this.urlToCall.error;
        if(val_1 == null)
        {
            goto label_5;
        }
        
        val_7 = "WWW Error: "("WWW Error: ") + this.urlToCall.error;
        UnityEngine.Debug.Log(message:  val_7);
        goto label_9;
        label_5:
        if((this.<>4__this.logging) != false)
        {
                val_1.logResponse(urlToCall:  this.urlToCall);
        }
        
        object val_5 = MiniJSON.Json.Deserialize(json:  this.urlToCall.text);
        val_9 = 0;
        this.<>4__this.onRequestResponse.Invoke(method:  this.<>4__this.currentRequest.method, response:  null);
        this.<>4__this.currentRequest = 0;
        if((this.<>4__this.requests) < 1)
        {
            goto label_19;
        }
        
        val_7.execute(request:  this.<>4__this.requests);
        label_9:
        val_8 = 0;
        return (bool)val_8;
        label_19:
        this.<>4__this.executing = false;
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

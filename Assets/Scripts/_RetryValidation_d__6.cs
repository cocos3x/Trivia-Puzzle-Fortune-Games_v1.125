using UnityEngine;
private sealed class TrackingHandler.<RetryValidation>d__6 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TrackingHandler <>4__this;
    public System.Collections.Generic.Dictionary<string, object> eventData;
    private TrackingHandler.<>c__DisplayClass6_0 <>8__1;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TrackingHandler.<RetryValidation>d__6(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4;
        int val_5;
        var val_6;
        val_4 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new TrackingHandler.<>c__DisplayClass6_0();
        .<>4__this = this.<>4__this;
        this.<>8__1.eventData = this.eventData;
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  5f);
        this.<>1__state = val_5;
        return (bool)val_5;
        label_1:
        this.<>1__state = 0;
        val_6 = null;
        val_6 = null;
        val_4 = this.<>8__1.eventData;
        App.networkManager.DoPost(path:  "/api/purchases", postBody:  val_4, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this.<>8__1, method:  System.Void TrackingHandler.<>c__DisplayClass6_0::<RetryValidation>b__0(string apicall, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
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

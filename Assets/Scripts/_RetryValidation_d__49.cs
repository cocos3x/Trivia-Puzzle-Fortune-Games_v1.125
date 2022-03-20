using UnityEngine;
private sealed class SubscriptionHandler.<RetryValidation>d__49 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SubscriptionHandler <>4__this;
    public System.Collections.Generic.Dictionary<string, object> purchaseData;
    private SubscriptionHandler.<>c__DisplayClass49_0 <>8__1;
    private string <subscriptonsPath>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public SubscriptionHandler.<RetryValidation>d__49(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        string val_4;
        SubscriptionHandler val_5;
        int val_6;
        var val_7;
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
        val_5 = this.<>4__this;
        this.<>8__1 = new SubscriptionHandler.<>c__DisplayClass49_0();
        .<>4__this = this.<>4__this;
        this.<>8__1.purchaseData = this.purchaseData;
        this.<subscriptonsPath>5__2 = "/api/subscriptions";
        val_6 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  3f);
        this.<>1__state = val_6;
        return (bool)val_6;
        label_1:
        this.<>1__state = 0;
        val_7 = null;
        val_7 = null;
        val_4 = this.<subscriptonsPath>5__2;
        val_5 = App.networkManager;
        val_5.DoPost(path:  val_4, postBody:  this.<>8__1.purchaseData, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this.<>8__1, method:  System.Void SubscriptionHandler.<>c__DisplayClass49_0::<RetryValidation>b__0(string apicall, System.Collections.Generic.Dictionary<string, object> response)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
        label_2:
        val_6 = 0;
        return (bool)val_6;
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

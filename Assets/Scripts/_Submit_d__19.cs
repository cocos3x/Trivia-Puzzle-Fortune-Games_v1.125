using UnityEngine;
private sealed class BugReportApi.<Submit>d__19 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SRDebugger.Internal.BugReportApi <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public BugReportApi.<Submit>d__19(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        SRDebugger.Internal.BugReportApi val_17;
        var val_18;
        var val_19;
        int val_20;
        var val_21;
        val_17 = this.<>4__this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this._isBusy) == true)
        {
            goto label_4;
        }
        
        this.<>4__this._isBusy = true;
        this.<>4__this.<IsComplete>k__BackingField = false;
        this.<>4__this.<WasSuccessful>k__BackingField = false;
        this.<>4__this._www = 0;
        this.<>4__this.<ErrorMessage>k__BackingField = "";
        string val_1 = SRDebugger.Internal.BugReportApi.BuildJsonRequest(report:  this.<>4__this._bugReport);
        System.Text.Encoding val_2 = System.Text.Encoding.UTF8;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_3 = null;
        val_19 = public System.Void System.Collections.Generic.Dictionary<System.String, System.String>::.ctor();
        val_3 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.set_Item(key:  "Content-Type", value:  "application/json");
        val_3.set_Item(key:  "Accept", value:  "application/json");
        val_3.set_Item(key:  "Method", value:  "POST");
        val_3.set_Item(key:  "X-ApiKey", value:  this.<>4__this._apiKey);
        UnityEngine.WWW val_4 = new UnityEngine.WWW(url:  "http://srdebugger.stompyrobot.uk/report/submit", postData:  val_2, headers:  val_3);
        this.<>4__this._www = val_4;
        if(val_4 == null)
        {
            goto label_36;
        }
        
        val_20 = 1;
        this.<>2__current = val_4;
        this.<>1__state = val_20;
        return (bool)val_20;
        label_1:
        this.<>1__state = 0;
        if((System.String.IsNullOrEmpty(value:  this.<>4__this._www.error)) == false)
        {
            goto label_12;
        }
        
        if((this.<>4__this._www.responseHeaders.ContainsKey(key:  "X-STATUS")) == false)
        {
            goto label_14;
        }
        
        string val_10 = this.<>4__this._www.responseHeaders.Item["X-STATUS"];
        if((val_10.Contains(value:  "200")) == false)
        {
            goto label_18;
        }
        
        val_21 = 1;
        goto label_19;
        label_12:
        label_22:
        this.<>4__this.<ErrorMessage>k__BackingField = this.<>4__this._www.error;
        goto label_36;
        label_14:
        this.<>4__this.<ErrorMessage>k__BackingField = "Completion State Unknown";
        label_36:
        val_21 = 0;
        label_19:
        val_17.SetCompletionState(wasSuccessful:  false);
        label_2:
        val_20 = 0;
        return (bool)val_20;
        label_18:
        string val_14 = SRDebugger.Internal.SRDebugApiUtil.ParseErrorResponse(response:  this.<>4__this._www.text, fallback:  val_10);
        goto label_22;
        label_4:
        System.InvalidOperationException val_15 = null;
        val_17 = val_15;
        val_15 = new System.InvalidOperationException(message:  "BugReportApi is already sending a bug report");
        val_18 = val_17;
        val_19 = System.Boolean BugReportApi.<Submit>d__19::MoveNext();
        throw val_18;
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

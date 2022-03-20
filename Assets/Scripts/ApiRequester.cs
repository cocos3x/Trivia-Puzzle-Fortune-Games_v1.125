using UnityEngine;
public class ApiRequester : MonoBehaviour
{
    // Fields
    private string <serverUrl>k__BackingField;
    public bool logging;
    private ApiRequester.RequestHandler onRequestResponse;
    private bool executing;
    private System.Collections.Queue requests;
    private Request currentRequest;
    
    // Properties
    public string serverUrl { get; set; }
    
    // Methods
    public string get_serverUrl()
    {
        return (string)this.<serverUrl>k__BackingField;
    }
    public void set_serverUrl(string value)
    {
        this.<serverUrl>k__BackingField = value;
    }
    public void add_onRequestResponse(ApiRequester.RequestHandler value)
    {
        do
        {
            if((System.Delegate.Combine(a:  this.onRequestResponse, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.onRequestResponse != 1152921515621800504);
        
        return;
        label_2:
    }
    public void remove_onRequestResponse(ApiRequester.RequestHandler value)
    {
        do
        {
            if((System.Delegate.Remove(source:  this.onRequestResponse, value:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.onRequestResponse != 1152921515621937080);
        
        return;
        label_2:
    }
    public ApiRequester()
    {
        this.executing = false;
        this.requests = new System.Collections.Queue();
    }
    public void doGet(string url)
    {
        var val_8;
        Request val_9;
        val_8 = this;
        Request val_1 = null;
        val_9 = val_1;
        val_1 = new Request(url:  this.<serverUrl>k__BackingField, method:  url, parameters:  0);
        if(this.logging != false)
        {
                val_1.logRequest(url:  url, post:  0);
        }
        
        if(this.executing != false)
        {
                val_8 = ???;
            val_9 = ???;
        }
        else
        {
                val_8.execute(request:  val_9);
        }
    
    }
    public bool reachable()
    {
        return (bool)(UnityEngine.Application.internetReachability != 0) ? 1 : 0;
    }
    public void doPost(string url, System.Collections.Generic.Dictionary<string, string> post)
    {
        string val_9;
        var val_10;
        Request val_11;
        val_9 = url;
        val_10 = this;
        Request val_1 = null;
        val_11 = val_1;
        val_1 = new Request(url:  this.<serverUrl>k__BackingField, method:  val_9, parameters:  post);
        if(this.logging != false)
        {
                val_1.logRequest(url:  val_9, post:  post);
        }
        
        if(this.executing != false)
        {
                val_10 = ???;
            val_11 = ???;
            val_9 = ???;
        }
        else
        {
                val_10.execute(request:  val_11);
        }
    
    }
    private void logRequest(string url, System.Collections.Generic.Dictionary<string, string> post)
    {
        var val_6;
        System.Collections.Generic.Dictionary<System.String, System.String> val_7 = post;
        if(val_7 == null)
        {
            goto label_1;
        }
        
        val_6 = 1152921504758390784;
        UnityEngine.Debug.Log(message:  "POST REQUEST " + url + " contains: "(" contains: "));
        Dictionary.Enumerator<TKey, TValue> val_2 = val_7.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        UnityEngine.Debug.LogWarning(message:  "key : "("key : ") + 0 + ", value : "(", value : ") + 0);
        goto label_7;
        label_4:
        0.Dispose();
        return;
        label_1:
        val_7 = "GET REQUEST " + url;
        UnityEngine.Debug.Log(message:  val_7);
    }
    private void execute(Request request)
    {
        UnityEngine.WWWForm val_10;
        UnityEngine.WWW val_11;
        this.executing = true;
        if(request.parameters == null)
        {
            goto label_2;
        }
        
        UnityEngine.WWWForm val_1 = null;
        val_10 = val_1;
        val_1 = new UnityEngine.WWWForm();
        Dictionary.Enumerator<TKey, TValue> val_2 = request.parameters.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.AddField(fieldName:  0, value:  0);
        goto label_6;
        label_4:
        0.Dispose();
        UnityEngine.WWW val_5 = null;
        val_11 = val_5;
        val_5 = new UnityEngine.WWW(url:  request.getFullUrl(), form:  val_1);
        goto label_7;
        label_2:
        val_10 = request.getFullUrl();
        UnityEngine.WWW val_7 = null;
        val_11 = val_7;
        val_7 = new UnityEngine.WWW(url:  val_10);
        label_7:
        this.currentRequest = request;
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this.WaitForRequest(urlToCall:  val_7));
    }
    private void logResponse(UnityEngine.WWW urlToCall)
    {
        UnityEngine.Debug.Log(message:  "RESPONSE: URL "("RESPONSE: URL ") + urlToCall.url + " received data: "(" received data: ") + urlToCall.text);
    }
    private System.Collections.IEnumerator WaitForRequest(UnityEngine.WWW urlToCall)
    {
        .<>1__state = 0;
        .urlToCall = urlToCall;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new ApiRequester.<WaitForRequest>d__19();
    }

}

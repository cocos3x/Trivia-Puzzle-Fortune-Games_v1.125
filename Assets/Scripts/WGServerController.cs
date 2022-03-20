using UnityEngine;
public class WGServerController : MonoSingleton<WGServerController>
{
    // Fields
    protected System.Action<System.Collections.Generic.Dictionary<string, object>> dataFilter;
    private const string WG_SERVER_UPDATE = "OnWGServerUpateNotification";
    protected const string api_ns = "/api/word";
    protected const string worlds_index = "/worlds/";
    protected const string chapters_index = "/chapters/";
    protected const string progress_index = "/progress/";
    protected const string defintion_index = "/definitions/";
    
    // Methods
    public void GetWordDefinition(string word, System.Action<System.Collections.Generic.Dictionary<string, object>> callback, System.Action<System.Collections.Generic.Dictionary<string, object>> onFailure)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        string val_2 = "/api/word/definitions/"("/api/word/definitions/") + word;
        goto typeof(WGServerController).__il2cppRuntimeField_1B0;
    }
    protected virtual bool PreProcessFilter(string apiCall, System.Collections.Generic.Dictionary<string, object> response, System.Action<System.Collections.Generic.Dictionary<string, object>> failure)
    {
        var val_5;
        if(response == null)
        {
            goto label_5;
        }
        
        if((response.ContainsKey(key:  "success")) == false)
        {
            goto label_2;
        }
        
        object val_2 = response.Item["success"];
        if(null == null)
        {
            goto label_5;
        }
        
        label_2:
        if(this.dataFilter != null)
        {
                this.dataFilter.Invoke(obj:  response);
        }
        
        if((response.ContainsKey(key:  "data_flush")) == false)
        {
            goto label_7;
        }
        
        object val_4 = response.Item["data_flush"];
        if(null != null)
        {
            goto label_12;
        }
        
        label_7:
        val_5 = 1;
        return (bool)val_5;
        label_5:
        if(failure != null)
        {
                failure.Invoke(obj:  response);
        }
        
        label_12:
        val_5 = 0;
        return (bool)val_5;
    }
    public virtual void RegisterDataFilter(System.Action<System.Collections.Generic.Dictionary<string, object>> callback)
    {
        this.dataFilter = callback;
    }
    protected virtual void DoRequest(WGServerController.RequestType verb, string uri, System.Collections.Generic.Dictionary<string, object> requestParameters, System.Action<System.Collections.Generic.Dictionary<string, object>> onCompleteCallback, bool doPostUpdate = True, System.Action<System.Collections.Generic.Dictionary<string, object>> failureCallback)
    {
        WGServerController.<>c__DisplayClass5_0 val_1 = new WGServerController.<>c__DisplayClass5_0();
        .<>4__this = this;
        .failureCallback = failureCallback;
        .onCompleteCallback = onCompleteCallback;
        .doPostUpdate = doPostUpdate;
        if(verb > 3)
        {
                return;
        }
        
        var val_37 = 32560056 + (verb) << 2;
        val_37 = val_37 + 32560056;
        goto (32560056 + (verb) << 2 + 32560056);
    }
    private void TryPostUpdate(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnWGServerUpateNotification");
    }
    public WGServerController()
    {
    
    }

}

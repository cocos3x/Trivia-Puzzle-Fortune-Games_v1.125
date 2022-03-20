using UnityEngine;
public class ServerRequestTracker : MonoSingleton<ServerRequestTracker>
{
    // Fields
    private const string RequestEventsKey = "request_events_key";
    private const int EventsPerRequests = 5;
    private twelvegigs.net.JsonApiRequester apiRequester;
    private bool trackerEnabled;
    private string deviceId;
    private System.Collections.Generic.List<RequestEvent> requestEvents;
    private string railsGameName;
    private string loggerUrl;
    
    // Properties
    public static bool IsLoaded { get; }
    public string RailsGameName { get; }
    public string LoggerUrl { get; }
    
    // Methods
    public static bool get_IsLoaded()
    {
        return UnityEngine.Object.op_Inequality(x:  MonoSingleton<ServerRequestTracker>.Instance, y:  0);
    }
    private void Start()
    {
    
    }
    public void OnServerResponded()
    {
        var val_7;
        var val_8;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnServerResponded");
        val_7 = null;
        val_7 = null;
        if((getGameplayKnobs().Contains(key:  "http_tracker")) == false)
        {
                return;
        }
        
        val_8 = null;
        val_8 = null;
        this.trackerEnabled = getGameplayKnobs().getBool(key:  "http_tracker");
    }
    public void TrackResponse(twelvegigs.net.JsonRequestStats stats, System.Collections.Generic.Dictionary<string, object> response)
    {
        System.Uri val_9;
        var val_10;
        val_9 = 1152921517644834544;
        int val_1 = System.Convert.ToInt32(value:  stats.duration);
        if((System.String.op_Equality(a:  stats.method, b:  "GET")) != true)
        {
                if((System.String.op_Equality(a:  stats.method, b:  "DELETE")) == false)
        {
            goto label_4;
        }
        
        }
        
        System.Uri val_4 = null;
        val_9 = val_4;
        val_4 = new System.Uri(uriString:  stats.url);
        string val_6 = val_4.GetLeftPart(part:  2).ParseGetParams(uri:  val_4);
        if(response != null)
        {
            goto label_6;
        }
        
        goto label_9;
        label_4:
        if(response == null)
        {
            goto label_9;
        }
        
        label_6:
        val_9 = "success";
        if((response.ContainsKey(key:  "success")) == false)
        {
            goto label_9;
        }
        
        object val_8 = response.Item["success"];
        goto label_12;
        label_9:
        val_10 = 0;
        label_12:
        this.AddEvent(te:  new RequestEvent() {method = stats.method, url = stats.method, jsonParams = stats.jsonParams, duration_ms = 153102032, responseCode = 268435459, success = false});
        this.LogDynamicError(response:  response);
    }
    private void LogDynamicError(System.Collections.Generic.Dictionary<string, object> response)
    {
        if(response == null)
        {
                return;
        }
        
        if((response.ContainsKey(key:  "error_message")) == false)
        {
                return;
        }
        
        object val_3 = response.Item["error_message"];
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "UpdateDynamicLog", aData:  new System.Collections.Hashtable());
    }
    private string ParseGetParams(System.Uri uri)
    {
        string val_1 = uri.Query;
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return "{}";
        }
        
        if(val_1.m_stringLength != 1)
        {
                return MiniJSON.Json.Serialize(obj:  twelvegigs.net.JsonApiRequester.GetHashFromQuery(query:  val_1.Substring(startIndex:  1)));
        }
        
        return "{}";
    }
    private void AddEvent(RequestEvent te)
    {
        if(this.trackerEnabled == false)
        {
                return;
        }
        
        this.requestEvents.Add(item:  new RequestEvent() {method = te.method, url = te.method, jsonParams = te.jsonParams, duration_ms = 153561968, responseCode = 268435459, success = te.success});
        this.Flush();
    }
    private bool ShouldFlush()
    {
        return (bool)(this.requestEvents > 5) ? 1 : 0;
    }
    private void Flush()
    {
        if(this.ShouldFlush() == false)
        {
                return;
        }
        
        int val_2 = System.Math.Min(val1:  41975808, val2:  5);
        this.requestEvents.RemoveRange(index:  0, count:  val_2);
        this.Track(events:  this.requestEvents.GetRange(index:  0, count:  val_2).ToArray());
    }
    private void Track(RequestEvent[] events)
    {
        int val_5;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_6;
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
        val_5 = events.Length;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_6 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_5 >= 1)
        {
                var val_5 = 0;
            do
        {
            val_2.Add(key:  "method", value:  null);
            val_2.Add(key:  "url", value:  null);
            val_2.Add(key:  "params", value:  null);
            val_2.Add(key:  "duration_ms", value:  null);
            val_2.Add(key:  "response_code", value:  null);
            val_2.Add(key:  "success", value:  null);
            val_2.Add(key:  "device_id", value:  this.deviceId);
            val_1.Add(item:  val_2);
            val_5 = events.Length;
            val_5 = val_5 + 1;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = null;
            val_6 = val_3;
            val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        while(val_5 < val_5);
        
        }
        
        val_3.Add(key:  "game", value:  this.RailsGameName);
        val_3.Add(key:  "events", value:  val_1);
        this.apiRequester.DoPost(path:  System.String.alignConst, postBody:  val_3, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
    }
    private void responseComplete(string url, System.Collections.Generic.Dictionary<string, object> obj)
    {
        if(obj == null)
        {
                return;
        }
        
        if((obj.ContainsKey(key:  "error_message")) == false)
        {
                return;
        }
        
        object[] val_2 = new object[2];
        val_2[0] = url;
        val_2[1] = PrettyPrint.printJSON(obj:  obj, types:  false, singleLineOutput:  false);
        UnityEngine.Debug.LogErrorFormat(format:  "url: {0}\nresp:{1}", args:  val_2);
    }
    private void SaveData()
    {
        if(true >= 1)
        {
                UnityEngine.PlayerPrefs.SetString(key:  "request_events_key", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.requestEvents));
            return;
        }
        
        UnityEngine.PlayerPrefs.DeleteKey(key:  "request_events_key");
    }
    private void LoadData()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "request_events_key")) == false)
        {
                return;
        }
        
        this.requestEvents = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<RequestEvent>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "request_events_key"));
    }
    private string GetRequestTrackerUrl()
    {
        return this.LoggerUrl;
    }
    public string get_RailsGameName()
    {
        string val_3;
        bool val_1 = System.String.IsNullOrEmpty(value:  this.railsGameName);
        if(val_1 != false)
        {
                this.railsGameName = val_1.GetGameRailsName();
            return val_3;
        }
        
        val_3 = this.railsGameName;
        return val_3;
    }
    private string GetGameRailsName()
    {
        AppConfigs val_1 = App.Configuration;
        return val_1.appConfig.ProductionServerURL.Replace(oldValue:  "-", newValue:  "_").Replace(oldValue:  "https://", newValue:  "").Replace(oldValue:  "_api.12gigs.com", newValue:  "");
    }
    public string get_LoggerUrl()
    {
        string val_3;
        bool val_1 = System.String.IsNullOrEmpty(value:  this.loggerUrl);
        if(val_1 != false)
        {
                this.loggerUrl = val_1.ServerRequestLoggerUrl();
            return val_3;
        }
        
        val_3 = this.loggerUrl;
        return val_3;
    }
    private string ServerRequestLoggerUrl()
    {
        AppConfigs val_1 = App.Configuration;
        return val_1.appConfig.ProductionServerURL.Replace(oldValue:  "-api.12gigs.com", newValue:  "-http-logger.12gigs.com");
    }
    public ServerRequestTracker()
    {
        this.trackerEnabled = true;
        this.requestEvents = new System.Collections.Generic.List<RequestEvent>();
    }
    private void <Start>b__8_0()
    {
        if(this.apiRequester != null)
        {
                this.apiRequester.Dequeue();
            return;
        }
        
        throw new NullReferenceException();
    }

}

using UnityEngine;

namespace twelvegigs.net
{
    public class JsonRequest
    {
        // Fields
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
        private bool requestFailed;
        private string err;
        public bool completed;
        public bool logging;
        protected string url;
        protected string userAgent;
        protected string xUserAgent;
        protected string contentType;
        private System.Net.CookieContainer cookieJar;
        private bool throwExceptionOnRequestFailure;
        protected string uri;
        protected string requestType;
        protected object postParameters;
        protected System.Action<string, System.Collections.Generic.Dictionary<string, object>> onComplete;
        protected System.Collections.Generic.Dictionary<string, object> onCompleteResponse;
        protected System.DateTime start;
        protected double duration;
        protected string formattedJson;
        protected System.Action onExecute;
        protected int timeout;
        protected bool _destroy;
        public NetworkThreadingHandler threadHandler;
        public System.Action<twelvegigs.net.JsonRequestStats, System.Collections.Generic.Dictionary<string, object>> responseTracker;
        public string responseString;
        public System.Net.HttpStatusCode responseStatusCode;
        
        // Properties
        public string UserAgent { get; set; }
        public string XuserAgent { get; set; }
        public string ContentType { get; set; }
        public System.Net.CookieContainer CookieJar { set; }
        public bool ThrowExceptionOnRequestFailure { get; set; }
        public string URI { get; }
        public bool destroy { get; }
        
        // Methods
        public string get_UserAgent()
        {
            return (string)this.userAgent;
        }
        public void set_UserAgent(string value)
        {
            this.userAgent = value;
        }
        public string get_XuserAgent()
        {
            return (string)this.xUserAgent;
        }
        public void set_XuserAgent(string value)
        {
            this.xUserAgent = value;
        }
        public string get_ContentType()
        {
            return (string)this.contentType;
        }
        public void set_ContentType(string value)
        {
            this.contentType = value;
        }
        public void set_CookieJar(System.Net.CookieContainer value)
        {
            this.cookieJar = value;
        }
        public bool get_ThrowExceptionOnRequestFailure()
        {
            return (bool)this.throwExceptionOnRequestFailure;
        }
        public void set_ThrowExceptionOnRequestFailure(bool value)
        {
            this.throwExceptionOnRequestFailure = value;
        }
        public string get_URI()
        {
            return (string)this.uri;
        }
        public bool get_destroy()
        {
            return (bool)this._destroy;
        }
        public JsonRequest()
        {
            this.throwExceptionOnRequestFailure = true;
            this.timeout = 20;
        }
        public JsonRequest(string url, string uri, string requestType, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onComplete, object parameters, bool log, int timeout = 20, bool destroy = False)
        {
            this.throwExceptionOnRequestFailure = true;
            this.timeout = 20;
            val_1 = new System.Object();
            this.uri = val_1;
            this.url = url + val_1;
            this.requestType = requestType;
            System.Delegate val_3 = System.Delegate.Combine(a:  this.onComplete, b:  onComplete);
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            this.postParameters = parameters;
            this.onComplete = val_3;
            this.logging = false;
            this.timeout = timeout * 1000;
            this.onExecute = new System.Action(object:  this, method:  typeof(twelvegigs.net.JsonRequest).__il2cppRuntimeField_188);
            this._destroy = destroy;
            return;
            label_2:
        }
        public virtual void execute()
        {
            System.DateTime val_1 = System.DateTime.UtcNow;
            this.start = val_1;
            this.onExecute.Invoke();
        }
        protected virtual void webRequestExecute()
        {
            string val_11;
            var val_12;
            System.Net.WebRequest val_1 = System.Net.WebRequest.Create(requestUriString:  this.url);
            if(this.userAgent != null)
            {
                    val_11 = 0;
                val_1.UserAgent = this.userAgent;
            }
            
            if(this.xUserAgent != null)
            {
                    val_11 = this.xUserAgent;
            }
            
            val_1.ReadWriteTimeout = this.timeout;
            if((System.String.op_Equality(a:  this.requestType, b:  "GET")) != true)
            {
                    if((System.String.op_Equality(a:  this.requestType, b:  "DELETE")) == false)
            {
                goto label_17;
            }
            
            }
            
            System.AsyncCallback val_4 = null;
            val_12 = val_4;
            val_4 = new System.AsyncCallback(object:  this, method:  System.Void twelvegigs.net.JsonRequest::finishedRequest(System.IAsyncResult result));
            goto label_18;
            label_17:
            if((System.String.op_Equality(a:  this.requestType, b:  "POST")) != true)
            {
                    bool val_6 = System.String.op_Equality(a:  this.requestType, b:  "PUT");
            }
            
            System.AsyncCallback val_7 = null;
            val_12 = val_7;
            val_7 = new System.AsyncCallback(object:  this, method:  System.Void twelvegigs.net.JsonRequest::startedPostRequest(System.IAsyncResult result));
            label_18:
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Threading.RegisteredWaitHandle val_11 = System.Threading.ThreadPool.RegisterWaitForSingleObject(waitObject:  val_1.AsyncWaitHandle, callBack:  new System.Threading.WaitOrTimerCallback(object:  this, method:  System.Void twelvegigs.net.JsonRequest::TimeoutCallback(object state, bool timedOut)), state:  val_1, millisecondsTimeOutInterval:  this.timeout, executeOnlyOnce:  true);
        }
        private void TimeoutCallback(object state, bool timedOut)
        {
            if(timedOut == false)
            {
                    return;
            }
            
            if(state == null)
            {
                    return;
            }
            
            var val_1 = (((System.Object.__il2cppRuntimeField_typeHierarchy + (System.Net.HttpWebRequest.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? state : 0;
        }
        protected void bridgeExecute()
        {
            UnityBridge.Send(url:  this.url, requestType:  this.requestType, data:  this.postParameters, threadHandler:  this.threadHandler);
        }
        public virtual void fireCallback()
        {
            if(this.onComplete != null)
            {
                    this.onComplete.Invoke(arg1:  this.url, arg2:  this.onCompleteResponse);
            }
            
            this.onComplete = 0;
            this.TrackRequest();
        }
        private void TrackRequest()
        {
            if(this.responseTracker == null)
            {
                    return;
            }
            
            this.responseTracker.Invoke(arg1:  new twelvegigs.net.JsonRequestStats() {method = this.requestType, url = this.url, duration = this.duration, responseCode = this.responseStatusCode, jsonParams = this.formattedJson}, arg2:  this.onCompleteResponse);
            this.responseTracker = 0;
        }
        private void finishedRequest(System.IAsyncResult result)
        {
            var val_8;
            System.IO.Stream val_10;
            if(result == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_10 = public System.Object System.IAsyncResult::get_AsyncState();
            val_8 = result;
            if(val_8.AsyncState == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = 0;
            val_10 = result;
            System.IO.StreamReader val_5 = null;
            val_10 = ;
            val_5 = new System.IO.StreamReader(stream:  val_10, encoding:  System.Text.Encoding.UTF8);
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            this.responseString = val_5;
            this.responseStatusCode = ;
            System.Threading.ThreadStart val_6 = new System.Threading.ThreadStart(object:  this, method:  public System.Void twelvegigs.net.JsonRequest::finalize());
            System.Threading.Thread val_7 = null;
            val_10 = val_6;
            val_7 = new System.Threading.Thread(start:  val_6);
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7.Start();
            val_7.Join();
        }
        private void startedPostRequest(System.IAsyncResult result)
        {
            var val_9;
            System.IO.Stream val_11;
            if(result == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            object val_2 = result.AsyncState;
            if(val_2 != null)
            {
                    val_11 = null;
            }
            
            val_11 = 0;
            this.formattedJson = MiniJSON.Json.Serialize(obj:  this.postParameters);
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.IO.StreamWriter val_4 = null;
            val_11 = val_2;
            val_4 = new System.IO.StreamWriter(stream:  val_11);
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = val_2;
            val_11 = new System.AsyncCallback(object:  this, method:  System.Void twelvegigs.net.JsonRequest::finishedPostRequest(System.IAsyncResult result));
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Threading.RegisteredWaitHandle val_9 = System.Threading.ThreadPool.RegisterWaitForSingleObject(waitObject:  val_9.AsyncWaitHandle, callBack:  new System.Threading.WaitOrTimerCallback(object:  this, method:  System.Void twelvegigs.net.JsonRequest::TimeoutCallback(object state, bool timedOut)), state:  val_2, millisecondsTimeOutInterval:  this.timeout, executeOnlyOnce:  true);
        }
        private void finishedPostRequest(System.IAsyncResult result)
        {
            var val_8;
            System.IO.Stream val_10;
            if(result == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_10 = public System.Object System.IAsyncResult::get_AsyncState();
            val_8 = result;
            if(val_8.AsyncState == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = 0;
            val_10 = result;
            System.IO.StreamReader val_5 = null;
            val_10 = ;
            val_5 = new System.IO.StreamReader(stream:  val_10, encoding:  System.Text.Encoding.UTF8);
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            this.responseString = val_5;
            this.responseStatusCode = ;
            System.Threading.ThreadStart val_6 = new System.Threading.ThreadStart(object:  this, method:  public System.Void twelvegigs.net.JsonRequest::finalize());
            System.Threading.Thread val_7 = null;
            val_10 = val_6;
            val_7 = new System.Threading.Thread(start:  val_6);
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7.Start();
            val_7.Join();
        }
        private void finalizeWithError(System.Net.WebException webEx)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "success", value:  null);
            System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
            val_2.Add(item:  "WebException");
            val_1.Add(key:  "errors", value:  val_2);
            val_1.Add(key:  "error_status", value:  webEx.m_Status);
            val_1.Add(key:  "error_message", value:  webEx.Message);
            this.responseString = MiniJSON.Json.Serialize(obj:  val_1);
            this.requestFailed = true;
            System.Threading.Thread val_6 = new System.Threading.Thread(start:  new System.Threading.ThreadStart(object:  this, method:  public System.Void twelvegigs.net.JsonRequest::finalize()));
            val_6.Start();
            val_6.Join();
        }
        public void finalize()
        {
            var val_6;
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = this.start});
            this.duration = val_2._ticks.TotalMilliseconds;
            object val_4 = MiniJSON.Json.Deserialize(json:  this.responseString);
            val_6 = 0;
            this.onCompleteResponse = ;
            this.completed = true;
        }
        public virtual void Cleanup()
        {
            this.onExecute = 0;
            this.threadHandler = 0;
            this.onComplete = 0;
            this.onCompleteResponse = 0;
        }
        private void LogClientError(string error)
        {
            var val_1;
            if(this.throwExceptionOnRequestFailure == false)
            {
                    return;
            }
            
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            D.LogClientError(developer:  error, filter:  "default", context:  0, strings:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
    
    }

}

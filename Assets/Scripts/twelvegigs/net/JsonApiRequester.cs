using UnityEngine;

namespace twelvegigs.net
{
    public class JsonApiRequester
    {
        // Fields
        private System.Collections.Generic.Queue<twelvegigs.net.JsonRequest> queue;
        private bool executing;
        private string ServerURL;
        private string adminServerURL;
        private string <UserAgent>k__BackingField;
        private string <XuserAgent>k__BackingField;
        private string <ContentType>k__BackingField;
        public System.Action dequeueHandler;
        private System.Net.CookieContainer cookieJar;
        private bool logging;
        private bool throwExceptions;
        public System.Action<twelvegigs.net.JsonRequestStats, System.Collections.Generic.Dictionary<string, object>> responseTracker;
        
        // Properties
        public string UserAgent { get; set; }
        public string XuserAgent { get; set; }
        public string ContentType { get; set; }
        
        // Methods
        public string get_UserAgent()
        {
            return (string)this.<UserAgent>k__BackingField;
        }
        public void set_UserAgent(string value)
        {
            this.<UserAgent>k__BackingField = value;
        }
        public string get_XuserAgent()
        {
            return (string)this.<XuserAgent>k__BackingField;
        }
        public void set_XuserAgent(string value)
        {
            this.<XuserAgent>k__BackingField = value;
        }
        public string get_ContentType()
        {
            return (string)this.<ContentType>k__BackingField;
        }
        public void set_ContentType(string value)
        {
            this.<ContentType>k__BackingField = value;
        }
        public JsonApiRequester(string ServerURL, System.Action dequeueHandler, bool logStuff, string adminServerURL, bool throwExceptionsOnRequestFailures = True)
        {
            val_1 = new System.Object();
            this.ServerURL = ServerURL;
            this.adminServerURL = val_1;
            this.dequeueHandler = dequeueHandler;
            this.logging = logStuff;
            this.throwExceptions = throwExceptionsOnRequestFailures;
            this.cookieJar = new System.Net.CookieContainer();
            System.Delegate val_7 = System.Delegate.Combine(a:  System.Net.ServicePointManager.ServerCertificateValidationCallback, b:  new System.Net.Security.RemoteCertificateValidationCallback(object:  0, method:  public static System.Boolean twelvegigs.net.JsonApiRequester::ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)));
            if(val_7 != null)
            {
                    if(null != null)
            {
                goto label_4;
            }
            
            }
            
            System.Net.ServicePointManager.ServerCertificateValidationCallback = val_7;
            this.queue = new System.Collections.Generic.Queue<twelvegigs.net.JsonRequest>();
            return;
            label_4:
        }
        public bool Reachable()
        {
            System.Net.IPHostEntry val_1 = System.Net.Dns.GetHostEntry(hostNameOrAddress:  "www.google.com");
            return true;
        }
        public void DoGet(string path, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, bool destroy = False, bool immediate = False, System.Collections.Generic.Dictionary<string, object> getParams, int timeout = 20)
        {
            string val_6 = path;
            if(getParams != null)
            {
                    val_6 = System.String.Format(format:  "{0}?{1}", arg0:  val_6 = path, arg1:  System.Uri.EscapeUriString(stringToEscape:  this.ToGetParams(parameters:  getParams))).Replace(oldValue:  "%20", newValue:  "+");
            }
            
            this.DoRequest(path:  val_6, methodType:  "GET", onCompleteCallback:  onCompleteFunction, postBody:  0, timeout:  timeout, destroy:  destroy, immediate:  false, serverType:  0);
        }
        public void DoPost(string path, object postBody, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, int timeout = 20, bool destroy = False, bool immediate = False, twelvegigs.net.ServerType serverType = 0)
        {
            this.DoRequest(path:  path, methodType:  "POST", onCompleteCallback:  onCompleteFunction, postBody:  postBody, timeout:  timeout, destroy:  destroy, immediate:  false, serverType:  serverType);
        }
        public void DoPut(string path, object postBody, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, int timeout = 20, bool destroy = False, bool immediate = False)
        {
            this.DoRequest(path:  path, methodType:  "PUT", onCompleteCallback:  onCompleteFunction, postBody:  postBody, timeout:  timeout, destroy:  destroy, immediate:  false, serverType:  0);
        }
        public void DoDelete(string path, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, int timeout = 20, bool destroy = False, bool immediate = False, System.Collections.Generic.Dictionary<string, object> deleteParams)
        {
            string val_6 = path;
            if(deleteParams != null)
            {
                    val_6 = System.String.Format(format:  "{0}?{1}", arg0:  val_6 = path, arg1:  System.Uri.EscapeUriString(stringToEscape:  this.ToGetParams(parameters:  deleteParams))).Replace(oldValue:  "%20", newValue:  "+");
            }
            
            this.DoRequest(path:  val_6, methodType:  "DELETE", onCompleteCallback:  onCompleteFunction, postBody:  0, timeout:  timeout, destroy:  destroy, immediate:  false, serverType:  0);
        }
        private void DoRequest(string path, string methodType, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteCallback, object postBody, int timeout, bool destroy, bool immediate, twelvegigs.net.ServerType serverType = 0)
        {
            string val_7;
            if((UnityEngine.Object.op_Implicit(exists:  DefaultHandler<ServerHandler>.Instance)) != false)
            {
                    ServerHandler val_3 = DefaultHandler<ServerHandler>.Instance;
                if(val_3._allowServerConnect == false)
            {
                    return;
            }
            
            }
            
            if(serverType != 1)
            {
                goto label_10;
            }
            
            val_7 = this.adminServerURL;
            if(val_7 != null)
            {
                goto label_11;
            }
            
            UnityEngine.Debug.LogWarning(message:  "Trying to make an admin API call but admin URL is null");
            return;
            label_10:
            val_7 = this.ServerURL;
            label_11:
            .contentType = this.<ContentType>k__BackingField;
            .userAgent = this.<UserAgent>k__BackingField;
            .xUserAgent = this.<XuserAgent>k__BackingField;
            .cookieJar = this.cookieJar;
            .throwExceptionOnRequestFailure = this.throwExceptions;
            if(this.responseTracker != null)
            {
                    System.Delegate val_6 = System.Delegate.Combine(a:  (twelvegigs.net.JsonRequest)[1152921520050417488].responseTracker, b:  this.responseTracker);
                if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_17;
            }
            
            }
            
                .responseTracker = val_6;
            }
            
            this.launchNetThreadingHandler(request:  new twelvegigs.net.JsonRequest(url:  val_7, uri:  path, requestType:  methodType, onComplete:  onCompleteCallback, parameters:  postBody, log:  false, timeout:  timeout, destroy:  destroy));
            return;
            label_17:
        }
        public void Dequeue()
        {
            if(true >= 1)
            {
                    this.launchNetThreadingHandler(request:  this.queue.Dequeue());
                return;
            }
            
            this.executing = false;
        }
        private void EnqueueRequest(twelvegigs.net.JsonRequest newRequest)
        {
            this.queue.Enqueue(item:  newRequest);
        }
        private void launchNetThreadingHandler(twelvegigs.net.JsonRequest request)
        {
            this.executing = true;
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject();
            val_1.name = request.uri;
            val_2.Request = request;
            val_2.dequeueLogic = this.dequeueHandler;
            request.threadHandler = val_1.AddComponent<NetworkThreadingHandler>();
        }
        private string ToGetParams(System.Collections.Generic.Dictionary<string, object> parameters)
        {
            var val_4;
            System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Object>, System.String> val_6;
            if(parameters == null)
            {
                    return (string)System.String.alignConst;
            }
            
            val_4 = null;
            val_4 = null;
            val_6 = JsonApiRequester.<>c.<>9__31_0;
            if(val_6 != null)
            {
                    return System.String.Join(separator:  "&", value:  System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.Object>, System.String>(source:  parameters, selector:  System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Object>, System.String> val_1 = null)));
            }
            
            val_6 = val_1;
            val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.Object>, System.String>(object:  JsonApiRequester.<>c.__il2cppRuntimeField_static_fields, method:  System.String JsonApiRequester.<>c::<ToGetParams>b__31_0(System.Collections.Generic.KeyValuePair<string, object> kvp));
            JsonApiRequester.<>c.<>9__31_0 = val_6;
            return System.String.Join(separator:  "&", value:  System.Linq.Enumerable.ToArray<System.String>(source:  System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<System.String, System.Object>, System.String>(source:  parameters, selector:  val_1)));
        }
        public static System.Collections.Generic.Dictionary<string, string> GetHashFromQuery(string query)
        {
            System.Char[] val_12;
            string val_13;
            System.Collections.Generic.Dictionary<System.String, System.String> val_1 = null;
            val_12 = public System.Void System.Collections.Generic.Dictionary<System.String, System.String>::.ctor();
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            val_13 = "&";
            val_12 = ToCharArray();
            if(query == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_3.Length < 1)
            {
                    return val_1;
            }
            
            var val_13 = 0;
            do
            {
                string val_12 = query.Split(separator:  val_12)[val_13];
                if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
                int val_4 = val_12.IndexOf(value:  "=");
                string val_5 = val_12.Substring(startIndex:  0, length:  val_4);
                val_13 = val_5;
                val_12 = 0;
                if((System.String.IsNullOrEmpty(value:  val_13)) != true)
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((val_1.ContainsKey(key:  val_5)) != true)
            {
                    val_1.Add(key:  val_5, value:  val_12.Substring(startIndex:  val_4 + 1));
            }
            
            }
            
                val_13 = val_13 + 1;
            }
            while(val_13 < val_3.Length);
            
            return val_1;
        }
        public static bool ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            var val_10;
            var val_11;
            var val_12;
            val_10 = sslPolicyErrors;
            if(certificate == null)
            {
                goto label_15;
            }
            
            if(val_10 == 0)
            {
                goto label_5;
            }
            
            System.Security.Cryptography.X509Certificates.X509ChainStatus[] val_1 = chain.ChainStatus;
            var val_11 = 0;
            val_11 = 32;
            label_16:
            if((val_11 + 1) >= val_1.Length)
            {
                goto label_5;
            }
            
            val_11 = val_11 + 1;
            if(chain.ChainStatus[0] == 64)
            {
                goto label_8;
            }
            
            chain.ChainPolicy.RevocationFlag = 1;
            chain.ChainPolicy.RevocationMode = 1;
            val_10 = chain.ChainPolicy;
            System.TimeSpan val_7 = new System.TimeSpan(hours:  0, minutes:  1, seconds:  0);
            val_6.timeout = val_7._ticks;
            chain.ChainPolicy.VerificationFlags = 4095;
            if((chain.Build(certificate:  certificate)) == false)
            {
                goto label_15;
            }
            
            label_8:
            val_11 = val_11 + 16;
            if(chain.ChainStatus != null)
            {
                goto label_16;
            }
            
            throw new NullReferenceException();
            label_15:
            val_12 = 0;
            return (bool)val_12;
            label_5:
            val_12 = 1;
            return (bool)val_12;
        }
    
    }

}

using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public class SweepstakesSDK
    {
        // Fields
        private const string UserAgentFormat = "{0}/{1} TinySparkSDK/{2} {3}/{4}";
        private const string xUserAgentFormat = "TinySparkSDK/{0} ({1}; {2})";
        private const string apiFormat = "/v{0}/{1}";
        private const string apiVersion = "1";
        private const int keyLength = 32;
        private twelvegigs.net.JsonApiRequester apiRequester;
        private twelvegigs.sweepstakes.Security security;
        private string apiKey;
        private string apiSecret;
        private string serverUrl;
        private string appVersion;
        private int campaignId;
        private bool enabled;
        private string UserAgent;
        private string xUserAgent;
        private string deviceId;
        private string openUdid;
        private string idfa;
        private System.Collections.Generic.Dictionary<string, object> deviceIdentifiers;
        private string session;
        private string deviceHash;
        private System.Collections.Generic.Dictionary<string, object> user;
        private System.Collections.Generic.Dictionary<string, object> iaps;
        private System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution> distribution;
        private System.Collections.Generic.Dictionary<string, object> application;
        private string applicationName;
        private System.Collections.Generic.Dictionary<string, object> assets;
        private double balance;
        private double lastBalance;
        private int entries;
        private int lastEntries;
        
        // Properties
        private bool Disabled { get; }
        public System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution> Distribution { get; }
        public double Balance { get; }
        public double LastBalance { get; }
        public int Entries { get; }
        public int LastEntries { get; }
        public bool Initialized { get; }
        
        // Methods
        private bool get_Disabled()
        {
            return (bool)(this.enabled == false) ? 1 : 0;
        }
        public System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution> get_Distribution()
        {
            return (System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution>)this.distribution;
        }
        public double get_Balance()
        {
            return (double)this.balance;
        }
        public double get_LastBalance()
        {
            return (double)this.lastBalance;
        }
        public int get_Entries()
        {
            return (int)this.entries;
        }
        public int get_LastEntries()
        {
            return (int)this.lastEntries;
        }
        public bool get_Initialized()
        {
            bool val_1 = System.String.IsNullOrEmpty(value:  this.session);
            val_1 = (~val_1) & 1;
            return (bool)val_1;
        }
        public SweepstakesSDK(string serverUrl, string applicationVersion, string apiKey, string apiSecret, int campaignId)
        {
            string val_7;
            string val_8;
            this.apiKey = System.String.alignConst;
            this.apiSecret = System.String.alignConst;
            this.serverUrl = System.String.alignConst;
            this.appVersion = System.String.alignConst;
            this.enabled = true;
            this.UserAgent = System.String.alignConst;
            this.xUserAgent = System.String.alignConst;
            this.deviceId = System.String.alignConst;
            this.openUdid = System.String.alignConst;
            this.idfa = System.String.alignConst;
            val_1 = new System.Object();
            this.serverUrl = serverUrl;
            this.appVersion = val_1;
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.campaignId = campaignId;
            this.security = new twelvegigs.sweepstakes.Security();
            this.SaveDeviceIdentifiers();
            val_7 = this.apiKey;
            if(this.apiKey.m_stringLength != 32)
            {
                goto label_2;
            }
            
            val_7 = this.apiSecret;
            if(this.apiSecret.m_stringLength != 32)
            {
                goto label_4;
            }
            
            this.apiRequester = new twelvegigs.net.JsonApiRequester(ServerURL:  this.serverUrl, dequeueHandler:  new System.Action(object:  this, method:  System.Void twelvegigs.sweepstakes.SweepstakesSDK::<.ctor>b__45_0()), logStuff:  false, adminServerURL:  0, throwExceptionsOnRequestFailures:  true);
            .<ContentType>k__BackingField = "application/json";
            this.apiRequester.<UserAgent>k__BackingField = this.UserAgent;
            this.apiRequester.<XuserAgent>k__BackingField = this.xUserAgent;
            return;
            label_2:
            val_8 = "Invalid apiKey: \'{0}\'";
            throw new System.Exception(message:  System.String.Format(format:  val_8 = "Invalid apiSecret: \'{0}\'", arg0:  val_7));
            label_4:
            throw new System.Exception(message:  System.String.Format(format:  val_8, arg0:  val_7));
        }
        private string Url(string endpoint)
        {
            return System.String.Format(format:  "/v{0}/{1}", arg0:  "1", arg1:  endpoint);
        }
        public void Initialize(System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_3.Add(key:  "key", value:  this.apiKey);
            val_2.Add(key:  "api", value:  val_3);
            val_2.Add(key:  "campaign", value:  this.campaignId);
            val_2.Add(key:  "identifiers", value:  this.deviceIdentifiers);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "initialize", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  false);
        }
        public void Terminate(System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            this.DoPost(endpoint:  "terminate", postData:  new System.Collections.Generic.Dictionary<System.String, System.Object>(), onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Ping(System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            this.DoPost(endpoint:  "ping", postData:  new System.Collections.Generic.Dictionary<System.String, System.Object>(), onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Perform(string name, System.Collections.Generic.List<object> parameters, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "name", value:  name);
            val_2.Add(key:  "parameters", value:  parameters);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "perform", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Redeem(int count, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "count", value:  count);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "redeem", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Log(System.Collections.Generic.List<string> logs, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "logs", value:  logs);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "log", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void LogAnalytics(System.Collections.Generic.List<AnalyticsEvent> events, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            object val_7;
            var val_8;
            System.Collections.Generic.List<System.Object> val_1 = new System.Collections.Generic.List<System.Object>();
            List.Enumerator<T> val_2 = events.GetEnumerator();
            label_5:
            val_7 = public System.Boolean List.Enumerator<AnalyticsEvent>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_8 = 0;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = val_8.ToDictionary();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_7);
            goto label_5;
            label_2:
            0.Dispose();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_6 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_6.Add(key:  "events", value:  val_1);
            val_5.Add(key:  "payload", value:  val_6);
            this.DoPost(endpoint:  "analytics", postData:  val_5, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Payout(string email, string firstName, string lastName, string addressOne, string city, string state, string zip, uint phone, string birthdate, string payMethod, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, string addressTwo = "")
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "email", value:  email);
            val_2.Add(key:  "first_name", value:  firstName);
            val_2.Add(key:  "last_name", value:  lastName);
            val_2.Add(key:  "address_one", value:  addressOne);
            val_2.Add(key:  "address_two", value:  addressTwo);
            val_2.Add(key:  "city", value:  city);
            val_2.Add(key:  "state", value:  state);
            val_2.Add(key:  "zip", value:  zip);
            val_2.Add(key:  "phone", value:  phone);
            val_2.Add(key:  "birthdate", value:  birthdate);
            val_2.Add(key:  "method", value:  payMethod);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "payout", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Amoe(string email, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "email", value:  email);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "amoe", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        public void Coupon(string code, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "code", value:  code);
            val_1.Add(key:  "payload", value:  val_2);
            this.DoPost(endpoint:  "coupon", postData:  val_1, onCompleteFunction:  onCompleteFunction, checkInitialization:  true);
        }
        private void DoPost(string endpoint, System.Collections.Generic.Dictionary<string, object> postData, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction, bool checkInitialization = True)
        {
            twelvegigs.net.JsonApiRequester val_7;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_8;
            string val_9;
            val_7 = checkInitialization;
            val_8 = postData;
            val_9 = endpoint;
            SweepstakesSDK.<>c__DisplayClass57_0 val_1 = new SweepstakesSDK.<>c__DisplayClass57_0();
            .<>4__this = this;
            .onCompleteFunction = onCompleteFunction;
            if(val_7 != false)
            {
                    if((System.String.IsNullOrEmpty(value:  this.session)) != false)
            {
                    UnityEngine.Debug.LogError(message:  "[WARNING] Trying to make an API call while Sweepstakes is not initialized!");
                if(((SweepstakesSDK.<>c__DisplayClass57_0)[1152921520025603440].onCompleteFunction) == null)
            {
                    return;
            }
            
                (SweepstakesSDK.<>c__DisplayClass57_0)[1152921520025603440].onCompleteFunction.Invoke(arg1:  val_9, arg2:  new System.Collections.Generic.Dictionary<System.String, System.Object>());
                return;
            }
            
            }
            
            val_7 = this.apiRequester;
            val_9 = val_1.Url(endpoint:  val_9);
            val_8 = this.SignRequest(payload:  val_8);
            val_7.DoPost(path:  val_9, postBody:  val_8, onCompleteFunction:  new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  val_1, method:  System.Void SweepstakesSDK.<>c__DisplayClass57_0::<DoPost>b__0(string method, System.Collections.Generic.Dictionary<string, object> data)), timeout:  20, destroy:  false, immediate:  false, serverType:  0);
        }
        private void OnSweepstakesResponse(string method, System.Collections.Generic.Dictionary<string, object> data, System.Action<string, System.Collections.Generic.Dictionary<string, object>> onCompleteFunction)
        {
            var val_10;
            twelvegigs.sweepstakes.Response val_1 = new twelvegigs.sweepstakes.Response(rawResponse:  data);
            this.enabled = (twelvegigs.sweepstakes.Response)[1152921520025797664].enabled;
            if((twelvegigs.sweepstakes.Response)[1152921520025797664].enabled == false)
            {
                goto label_2;
            }
            
            if((System.String.op_Equality(a:  (twelvegigs.sweepstakes.Response)[1152921520025797664].endpoint, b:  "initialize")) == false)
            {
                goto label_3;
            }
            
            this.OnInitialize(response:  val_1);
            goto label_11;
            label_2:
            UnityEngine.Debug.LogError(message:  "Sweepstakes is disabled");
            return;
            label_3:
            if((System.String.op_Equality(a:  (twelvegigs.sweepstakes.Response)[1152921520025797664].endpoint, b:  "terminate")) != false)
            {
                    this.OnTerminate(response:  val_1);
            }
            else
            {
                    if((System.String.op_Equality(a:  (twelvegigs.sweepstakes.Response)[1152921520025797664].endpoint, b:  "perform")) != false)
            {
                    this.OnPerform(response:  val_1);
            }
            else
            {
                    object[] val_5 = new object[1];
                val_5[0] = (twelvegigs.sweepstakes.Response)[1152921520025797664].endpoint;
                UnityEngine.Debug.LogWarningFormat(format:  "API Endpoint {0} has no special handling logic", args:  val_5);
            }
            
            }
            
            label_11:
            if((W9 & 255) == 0)
            {
                    this.balance = (twelvegigs.sweepstakes.Response)[1152921520025797664].balance.Value;
            }
            
            if(((twelvegigs.sweepstakes.Response)[1152921520025797664].entries & 0) == 0)
            {
                    val_10 = 1152921515416246272;
                this.entries = (twelvegigs.sweepstakes.Response)[1152921520025797664].entries.Value;
            }
            
            if((val_10 & 255) == 0)
            {
                    this.lastBalance = (twelvegigs.sweepstakes.Response)[1152921520025797664].lastBalance.Value;
            }
            
            if(((twelvegigs.sweepstakes.Response)[1152921520025797664].lastEntries & 0) == 0)
            {
                    this.lastEntries = (twelvegigs.sweepstakes.Response)[1152921520025797664].lastEntries.Value;
            }
            
            if(onCompleteFunction == null)
            {
                    return;
            }
            
            onCompleteFunction.Invoke(arg1:  (twelvegigs.sweepstakes.Response)[1152921520025797664].endpoint, arg2:  (twelvegigs.sweepstakes.Response)[1152921520025797664].payload);
        }
        private void OnInitialize(twelvegigs.sweepstakes.Response response)
        {
            var val_21;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_26;
            string val_27;
            var val_28;
            var val_29;
            var val_30;
            var val_31;
            var val_32;
            if(response == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.IsNullOrEmpty(value:  response.session)) != true)
            {
                    this.session = response.session;
            }
            
            val_27 = 0;
            if((System.String.IsNullOrEmpty(value:  response.deviceHash)) != true)
            {
                    this.deviceHash = response.deviceHash;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_28 = 1152921510222861648;
            val_27 = "iaps";
            if((val_26.ContainsKey(key:  val_27)) != false)
            {
                    val_26 = response.payload;
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_27 = "iaps";
                object val_4 = val_26.Item[val_27];
                val_29 = 0;
                this.iaps = ;
            }
            
            if(response.error == true)
            {
                    return;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27 = "user";
            if((val_26.ContainsKey(key:  val_27)) != false)
            {
                    val_26 = response.payload;
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_27 = "user";
                object val_7 = val_26.Item[val_27];
                val_30 = 0;
                this.user = ;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27 = "application";
            if((val_26.ContainsKey(key:  val_27)) == false)
            {
                goto label_23;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27 = "application";
            object val_10 = val_26.Item[val_27];
            if(val_10 == null)
            {
                goto label_22;
            }
            
            this.application = val_10;
            val_31 = "name";
            val_27 = "name";
            if((val_10.ContainsKey(key:  val_27)) != false)
            {
                    val_26 = this.application;
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_27 = "name";
                object val_12 = val_26.Item[val_27];
                if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
                this.applicationName = val_12;
            }
            
            label_23:
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27 = "assets";
            if((val_26.ContainsKey(key:  val_27)) != false)
            {
                    val_26 = response.payload;
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_27 = "assets";
                object val_14 = val_26.Item[val_27];
                val_32 = 0;
                this.assets = ;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27 = "prizes";
            if((val_26.ContainsKey(key:  val_27)) == false)
            {
                    return;
            }
            
            val_26 = response.payload;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_17 = val_26.Item["prizes"];
            System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution> val_18 = null;
            val_27 = public System.Void System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution>::.ctor();
            val_18 = new System.Collections.Generic.List<twelvegigs.sweepstakes.Distribution>();
            this.distribution = val_18;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_19 = val_17.GetEnumerator();
            val_28 = 1152921510211410768;
            val_31 = 1152921504685600768;
            label_43:
            if(val_21.MoveNext() == false)
            {
                goto label_38;
            }
            
            val_27 = 0;
            new twelvegigs.sweepstakes.Distribution() = new twelvegigs.sweepstakes.Distribution(distribution:  null);
            val_26 = this.distribution;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_26.Add(item:  new twelvegigs.sweepstakes.Distribution());
            goto label_43;
            label_38:
            val_21.Dispose();
            return;
            label_22:
            this.application = 0;
            throw new NullReferenceException();
        }
        private void OnTerminate(twelvegigs.sweepstakes.Response response)
        {
            if((response.payload.ContainsKey(key:  "destroyed")) == false)
            {
                    return;
            }
            
            if((response.payload.Item["destroyed"].Equals(value:  this.session)) != true)
            {
                    UnityEngine.Debug.LogWarning(message:  "Sweepstakes Session Mismatch!");
            }
            
            this.session = 0;
        }
        private void OnPerform(twelvegigs.sweepstakes.Response response)
        {
            if((response.payload.ContainsKey(key:  "success")) == false)
            {
                    return;
            }
            
            object val_2 = response.payload.Item["success"];
            object[] val_3 = new object[1];
            this = null.ToString() + " " + this.entries;
            val_3[0] = this;
            UnityEngine.Debug.LogErrorFormat(format:  "Perform success? {0}", args:  val_3);
        }
        private void SaveDeviceIdentifiers()
        {
            object val_20;
            int val_21;
            string val_1 = DeviceIdPlugin.GetDeviceId();
            this.deviceId = val_1;
            this.openUdid = twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_1));
            this.deviceId = this.deviceId.Replace(oldValue:  "an-", newValue:  "");
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            string[] val_6 = new string[1];
            val_6[0] = DeviceIdPlugin.GetGoogleAdId();
            val_5.Add(key:  "android-id", value:  val_6);
            string[] val_8 = new string[1];
            val_8[0] = DeviceIdPlugin.GetDeviceId().Replace(oldValue:  "an-", newValue:  "");
            val_5.Add(key:  "android-serial", value:  val_8);
            string[] val_11 = new string[1];
            val_11[0] = this.openUdid;
            val_5.Add(key:  "openudid", value:  val_11);
            this.deviceIdentifiers = val_5;
            UnityEngine.RuntimePlatform val_12 = UnityEngine.Application.platform;
            if((val_12 - 7) < 2)
            {
                goto label_19;
            }
            
            if(val_12 == 11)
            {
                goto label_20;
            }
            
            if(val_12 != 0)
            {
                goto label_21;
            }
            
            label_19:
            val_20 = "iOS";
            goto label_22;
            label_21:
            object[] val_14 = new object[1];
            val_14[0] = UnityEngine.Application.platform;
            UnityEngine.Debug.LogWarningFormat(format:  "WARNING: Setting Android User-Agent for platform {0}", args:  val_14);
            label_20:
            val_20 = "Android";
            label_22:
            object[] val_16 = new object[5];
            val_16[0] = "Unity";
            val_21 = val_16.Length;
            val_16[1] = UnityEngine.Application.version;
            if(this.appVersion != null)
            {
                    val_21 = val_16.Length;
            }
            
            val_16[2] = this.appVersion;
            val_21 = val_16.Length;
            val_16[3] = val_20;
            val_21 = val_16.Length;
            val_16[4] = "0.0";
            this.UserAgent = System.String.Format(format:  "{0}/{1} TinySparkSDK/{2} {3}/{4}", args:  val_16);
            this.xUserAgent = System.String.Format(format:  "TinySparkSDK/{0} ({1}; {2})", arg0:  this.appVersion, arg1:  val_20, arg2:  "0.0");
        }
        private System.Collections.Generic.Dictionary<string, object> SignRequest(System.Collections.Generic.Dictionary<string, object> payload)
        {
            int val_16;
            int val_17;
            var val_18;
            string val_1 = 27554.RequestId();
            int val_2 = UnityEngine.Random.Range(min:  1, max:  99999999);
            int val_3 = val_2.UnixTimestamp();
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_4.Add(key:  "id", value:  val_1);
            System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_5.Add(key:  "type", value:  this.xUserAgent);
            val_4.Add(key:  "device", value:  val_5);
            val_4.Add(key:  "seed", value:  val_2);
            val_4.Add(key:  "time", value:  val_3);
            string[] val_6 = new string[6];
            val_16 = val_6.Length;
            val_6[0] = this.apiKey;
            if(this.apiSecret != null)
            {
                    val_16 = val_6.Length;
            }
            
            val_6[1] = this.apiSecret;
            val_17 = val_6.Length;
            val_6[2] = this.campaignId.ToString();
            if(val_1 != null)
            {
                    val_17 = val_6.Length;
            }
            
            val_6[3] = val_1;
            val_6[4] = val_3.ToString();
            val_6[5] = val_2.ToString();
            val_18 = 0;
            val_4.Add(key:  "signature", value:  payload.Item["payload"].Sign(signParams:  val_6, payload:  null));
            if((System.String.IsNullOrEmpty(value:  this.session)) != true)
            {
                    val_4.set_Item(key:  "session", value:  this.session);
            }
            
            if((System.String.IsNullOrEmpty(value:  this.deviceHash)) != true)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_15 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
                val_15.Add(key:  "hash", value:  this.deviceHash);
                val_4.set_Item(key:  "device", value:  val_15);
            }
            
            payload.Add(key:  "request", value:  val_4);
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)payload;
        }
        private void <.ctor>b__45_0()
        {
            if(this.apiRequester != null)
            {
                    this.apiRequester.Dequeue();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}

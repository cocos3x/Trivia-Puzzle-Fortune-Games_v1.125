using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public class Response
    {
        // Fields
        private string deviceHash;
        private bool enabled;
        private bool error;
        private int time;
        private string id;
        private string endpoint;
        private int seed;
        private bool suspect;
        private string method;
        private string session;
        private System.Nullable<double> balance;
        private System.Nullable<double> lastBalance;
        private System.Nullable<int> entries;
        private System.Nullable<int> lastEntries;
        private bool secure;
        private string signature;
        private System.Collections.Generic.Dictionary<string, object> payload;
        private System.Collections.Generic.Dictionary<string, object> response;
        
        // Properties
        public string DeviceHash { get; }
        public bool Enabled { get; }
        public bool Error { get; }
        public string Endpoint { get; }
        public string Session { get; }
        public System.Nullable<double> Balance { get; }
        public System.Nullable<double> LastBalance { get; }
        public System.Nullable<int> Entries { get; }
        public System.Nullable<int> LastEntries { get; }
        public System.Collections.Generic.Dictionary<string, object> Payload { get; }
        public System.Collections.Generic.Dictionary<string, object> Security { get; }
        
        // Methods
        public string get_DeviceHash()
        {
            return (string)this.deviceHash;
        }
        public bool get_Enabled()
        {
            return (bool)this.enabled;
        }
        public bool get_Error()
        {
            return (bool)this.error;
        }
        public string get_Endpoint()
        {
            return (string)this.endpoint;
        }
        public string get_Session()
        {
            return (string)this.session;
        }
        public System.Nullable<double> get_Balance()
        {
            return (System.Nullable<System.Double>)this.balance;
        }
        public System.Nullable<double> get_LastBalance()
        {
            return (System.Nullable<System.Double>)this.lastBalance;
        }
        public System.Nullable<int> get_Entries()
        {
            return (System.Nullable<System.Int32>)this.entries;
        }
        public System.Nullable<int> get_LastEntries()
        {
            return (System.Nullable<System.Int32>)this.lastEntries;
        }
        public System.Collections.Generic.Dictionary<string, object> get_Payload()
        {
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.payload;
        }
        public System.Collections.Generic.Dictionary<string, object> get_Security()
        {
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.response;
        }
        public Response(System.Collections.Generic.Dictionary<string, object> rawResponse)
        {
            bool val_42;
            var val_43;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_44;
            var val_45;
            val_42 = true;
            this.error = val_42;
            if(rawResponse == null)
            {
                    return;
            }
            
            this.enabled = val_42;
            if((rawResponse.ContainsKey(key:  "payload")) != false)
            {
                    object val_2 = rawResponse.Item["payload"];
                val_43 = 0;
            }
            else
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = null;
                val_43 = val_3;
                val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            }
            
            this.payload = ;
            if((rawResponse.ContainsKey(key:  "response")) == false)
            {
                goto label_7;
            }
            
            object val_6 = rawResponse.Item["response"];
            if(val_6 == null)
            {
                goto label_10;
            }
            
            val_44 = val_6;
            val_45 = this;
            this.response = val_44;
            goto label_11;
            label_7:
            System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = null;
            val_44 = val_7;
            val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_45 = this;
            this.response = val_44;
            label_11:
            if((val_7.ContainsKey(key:  "error")) != false)
            {
                    object val_9 = val_7.Item["error"];
                this.error = null;
            }
            
            if((val_7.ContainsKey(key:  "endpoint")) != false)
            {
                    this.endpoint = val_7.Item["endpoint"];
            }
            
            if((val_7.ContainsKey(key:  "disable")) != false)
            {
                    object val_13 = val_7.Item["disable"];
                this.enabled = 1152921504626761729;
            }
            
            val_42 = "balance";
            if((val_7.ContainsKey(key:  "balance")) != false)
            {
                    System.Nullable<System.Double> val_18 = new System.Nullable<System.Double>(value:  System.Math.Round(value:  System.Convert.ToDouble(value:  val_7.Item["balance"]), digits:  2));
                this.balance = val_18.HasValue;
            }
            
            if((val_7.ContainsKey(key:  "entries")) != false)
            {
                    System.Nullable<System.Int32> val_22 = new System.Nullable<System.Int32>(value:  System.Convert.ToInt32(value:  val_7.Item["entries"]));
                this.entries = val_22.HasValue;
            }
            
            if((val_7.ContainsKey(key:  "last")) != false)
            {
                    object val_24 = val_7.Item["last"];
                if((val_24.ContainsKey(key:  "balance")) != false)
            {
                    val_42 = val_24.Item["balance"];
                System.Nullable<System.Double> val_29 = new System.Nullable<System.Double>(value:  System.Math.Round(value:  System.Convert.ToDouble(value:  val_42), digits:  2));
                this.lastBalance = val_29.HasValue;
            }
            
                if((val_24.ContainsKey(key:  "entries")) != false)
            {
                    System.Nullable<System.Int32> val_33 = new System.Nullable<System.Int32>(value:  System.Convert.ToInt32(value:  val_24.Item["entries"]));
                this.lastEntries = val_33.HasValue;
            }
            
            }
            
            if((System.String.op_Equality(a:  this.endpoint, b:  "initialize")) == false)
            {
                    return;
            }
            
            if((val_7.ContainsKey(key:  "session")) != false)
            {
                    this.session = val_7.Item["session"];
            }
            
            if((this.payload.ContainsKey(key:  "device")) == false)
            {
                    return;
            }
            
            val_42 = 1152921510214912464;
            object val_38 = this.payload.Item["device"];
            val_45 = "hash";
            if((val_38.ContainsKey(key:  "hash")) == false)
            {
                    return;
            }
            
            this.deviceHash = val_38.Item["hash"];
            return;
            label_10:
            this.response = 0;
            throw new NullReferenceException();
        }
    
    }

}

using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustEventFailure
    {
        // Fields
        private string <Adid>k__BackingField;
        private string <Message>k__BackingField;
        private string <Timestamp>k__BackingField;
        private string <EventToken>k__BackingField;
        private string <CallbackId>k__BackingField;
        private bool <WillRetry>k__BackingField;
        private System.Collections.Generic.Dictionary<string, object> <JsonResponse>k__BackingField;
        
        // Properties
        public string Adid { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public string EventToken { get; set; }
        public string CallbackId { get; set; }
        public bool WillRetry { get; set; }
        public System.Collections.Generic.Dictionary<string, object> JsonResponse { get; set; }
        
        // Methods
        public string get_Adid()
        {
            return (string)this.<Adid>k__BackingField;
        }
        public void set_Adid(string value)
        {
            this.<Adid>k__BackingField = value;
        }
        public string get_Message()
        {
            return (string)this.<Message>k__BackingField;
        }
        public void set_Message(string value)
        {
            this.<Message>k__BackingField = value;
        }
        public string get_Timestamp()
        {
            return (string)this.<Timestamp>k__BackingField;
        }
        public void set_Timestamp(string value)
        {
            this.<Timestamp>k__BackingField = value;
        }
        public string get_EventToken()
        {
            return (string)this.<EventToken>k__BackingField;
        }
        public void set_EventToken(string value)
        {
            this.<EventToken>k__BackingField = value;
        }
        public string get_CallbackId()
        {
            return (string)this.<CallbackId>k__BackingField;
        }
        public void set_CallbackId(string value)
        {
            this.<CallbackId>k__BackingField = value;
        }
        public bool get_WillRetry()
        {
            return (bool)this.<WillRetry>k__BackingField;
        }
        public void set_WillRetry(bool value)
        {
            this.<WillRetry>k__BackingField = value;
        }
        public System.Collections.Generic.Dictionary<string, object> get_JsonResponse()
        {
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.<JsonResponse>k__BackingField;
        }
        public void set_JsonResponse(System.Collections.Generic.Dictionary<string, object> value)
        {
            this.<JsonResponse>k__BackingField = value;
        }
        public AdjustEventFailure()
        {
        
        }
        public AdjustEventFailure(System.Collections.Generic.Dictionary<string, string> eventFailureDataMap)
        {
            string val_14;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_15;
            var val_16;
            var val_17;
            val_15 = this;
            if(eventFailureDataMap == null)
            {
                    return;
            }
            
            val_16 = null;
            val_16 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            this.<EventToken>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyEventToken);
            this.<CallbackId>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
            val_14 = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
            if((System.Boolean.TryParse(value:  val_14, result: out  false)) != false)
            {
                    this.<WillRetry>k__BackingField = false;
            }
            
            val_17 = null;
            val_17 = null;
            com.adjust.sdk.JSONNode val_10 = com.adjust.sdk.JSONNode.Parse(aJSON:  com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyJsonResponse));
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_10, b:  0)) == true)
            {
                    return;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_10, b:  0)) == true)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_13 = null;
            val_14 = val_13;
            val_13 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this.<JsonResponse>k__BackingField = val_14;
            val_15 = this.<JsonResponse>k__BackingField;
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_10, output:  val_15);
        }
        public AdjustEventFailure(string jsonString)
        {
            string val_14;
            var val_15;
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            val_15 = null;
            val_15 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            this.<EventToken>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyEventToken);
            this.<CallbackId>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
            val_14 = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
            this.<WillRetry>k__BackingField = System.Convert.ToBoolean(value:  val_14);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) != false)
            {
                    return;
            }
            
            this.<JsonResponse>k__BackingField = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_1, output:  this.<JsonResponse>k__BackingField);
        }
        public void BuildJsonResponseFromString(string jsonResponseString)
        {
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonResponseString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) != false)
            {
                    return;
            }
            
            this.<JsonResponse>k__BackingField = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_1, output:  this.<JsonResponse>k__BackingField);
        }
        public string GetJsonResponse()
        {
            return com.adjust.sdk.AdjustUtils.GetJsonResponseCompact(dictionary:  this.<JsonResponse>k__BackingField);
        }
    
    }

}

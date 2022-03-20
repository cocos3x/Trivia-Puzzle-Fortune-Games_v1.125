using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustSessionFailure
    {
        // Fields
        private string <Adid>k__BackingField;
        private string <Message>k__BackingField;
        private string <Timestamp>k__BackingField;
        private bool <WillRetry>k__BackingField;
        private System.Collections.Generic.Dictionary<string, object> <JsonResponse>k__BackingField;
        
        // Properties
        public string Adid { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
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
        public AdjustSessionFailure()
        {
        
        }
        public AdjustSessionFailure(System.Collections.Generic.Dictionary<string, string> sessionFailureDataMap)
        {
            string val_12;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_13;
            var val_14;
            var val_15;
            val_13 = this;
            if(sessionFailureDataMap == null)
            {
                    return;
            }
            
            val_14 = null;
            val_14 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            val_12 = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
            if((System.Boolean.TryParse(value:  val_12, result: out  false)) != false)
            {
                    this.<WillRetry>k__BackingField = false;
            }
            
            val_15 = null;
            val_15 = null;
            com.adjust.sdk.JSONNode val_8 = com.adjust.sdk.JSONNode.Parse(aJSON:  com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionFailureDataMap, key:  com.adjust.sdk.AdjustUtils.KeyJsonResponse));
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_8, b:  0)) == true)
            {
                    return;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_8, b:  0)) == true)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = null;
            val_12 = val_11;
            val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            this.<JsonResponse>k__BackingField = val_12;
            val_13 = this.<JsonResponse>k__BackingField;
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_8, output:  val_13);
        }
        public AdjustSessionFailure(string jsonString)
        {
            string val_12;
            var val_13;
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            val_13 = null;
            val_13 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            val_12 = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyWillRetry);
            this.<WillRetry>k__BackingField = System.Convert.ToBoolean(value:  val_12);
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

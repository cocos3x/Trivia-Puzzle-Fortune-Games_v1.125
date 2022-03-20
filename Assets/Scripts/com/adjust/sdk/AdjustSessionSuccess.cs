using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustSessionSuccess
    {
        // Fields
        private string <Adid>k__BackingField;
        private string <Message>k__BackingField;
        private string <Timestamp>k__BackingField;
        private System.Collections.Generic.Dictionary<string, object> <JsonResponse>k__BackingField;
        
        // Properties
        public string Adid { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
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
        public System.Collections.Generic.Dictionary<string, object> get_JsonResponse()
        {
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.<JsonResponse>k__BackingField;
        }
        public void set_JsonResponse(System.Collections.Generic.Dictionary<string, object> value)
        {
            this.<JsonResponse>k__BackingField = value;
        }
        public AdjustSessionSuccess()
        {
        
        }
        public AdjustSessionSuccess(System.Collections.Generic.Dictionary<string, string> sessionSuccessDataMap)
        {
            var val_9;
            if(sessionSuccessDataMap == null)
            {
                    return;
            }
            
            val_9 = null;
            val_9 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            com.adjust.sdk.JSONNode val_5 = com.adjust.sdk.JSONNode.Parse(aJSON:  com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  sessionSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyJsonResponse));
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_5, b:  0)) == true)
            {
                    return;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_5, b:  0)) != false)
            {
                    return;
            }
            
            this.<JsonResponse>k__BackingField = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_5, output:  this.<JsonResponse>k__BackingField);
        }
        public AdjustSessionSuccess(string jsonString)
        {
            var val_9;
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            val_9 = null;
            val_9 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
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

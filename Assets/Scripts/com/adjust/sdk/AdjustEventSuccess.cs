using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustEventSuccess
    {
        // Fields
        private string <Adid>k__BackingField;
        private string <Message>k__BackingField;
        private string <Timestamp>k__BackingField;
        private string <EventToken>k__BackingField;
        private string <CallbackId>k__BackingField;
        private System.Collections.Generic.Dictionary<string, object> <JsonResponse>k__BackingField;
        
        // Properties
        public string Adid { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public string EventToken { get; set; }
        public string CallbackId { get; set; }
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
        public System.Collections.Generic.Dictionary<string, object> get_JsonResponse()
        {
            return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.<JsonResponse>k__BackingField;
        }
        public void set_JsonResponse(System.Collections.Generic.Dictionary<string, object> value)
        {
            this.<JsonResponse>k__BackingField = value;
        }
        public AdjustEventSuccess()
        {
        
        }
        public AdjustEventSuccess(System.Collections.Generic.Dictionary<string, string> eventSuccessDataMap)
        {
            var val_11;
            if(eventSuccessDataMap == null)
            {
                    return;
            }
            
            val_11 = null;
            val_11 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            this.<EventToken>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyEventToken);
            this.<CallbackId>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
            com.adjust.sdk.JSONNode val_7 = com.adjust.sdk.JSONNode.Parse(aJSON:  com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  eventSuccessDataMap, key:  com.adjust.sdk.AdjustUtils.KeyJsonResponse));
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_7, b:  0)) == true)
            {
                    return;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_7, b:  0)) != false)
            {
                    return;
            }
            
            this.<JsonResponse>k__BackingField = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            com.adjust.sdk.AdjustUtils.WriteJsonResponseDictionary(jsonObject:  val_7, output:  this.<JsonResponse>k__BackingField);
        }
        public AdjustEventSuccess(string jsonString)
        {
            var val_11;
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            val_11 = null;
            val_11 = null;
            this.<Adid>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<Message>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyMessage);
            this.<Timestamp>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTimestamp);
            this.<EventToken>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyEventToken);
            this.<CallbackId>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCallbackId);
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

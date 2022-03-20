using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustAttribution
    {
        // Fields
        private string <adid>k__BackingField;
        private string <network>k__BackingField;
        private string <adgroup>k__BackingField;
        private string <campaign>k__BackingField;
        private string <creative>k__BackingField;
        private string <clickLabel>k__BackingField;
        private string <trackerName>k__BackingField;
        private string <trackerToken>k__BackingField;
        private string <costType>k__BackingField;
        private System.Nullable<double> <costAmount>k__BackingField;
        private string <costCurrency>k__BackingField;
        
        // Properties
        public string adid { get; set; }
        public string network { get; set; }
        public string adgroup { get; set; }
        public string campaign { get; set; }
        public string creative { get; set; }
        public string clickLabel { get; set; }
        public string trackerName { get; set; }
        public string trackerToken { get; set; }
        public string costType { get; set; }
        public System.Nullable<double> costAmount { get; set; }
        public string costCurrency { get; set; }
        
        // Methods
        public string get_adid()
        {
            return (string)this.<adid>k__BackingField;
        }
        public void set_adid(string value)
        {
            this.<adid>k__BackingField = value;
        }
        public string get_network()
        {
            return (string)this.<network>k__BackingField;
        }
        public void set_network(string value)
        {
            this.<network>k__BackingField = value;
        }
        public string get_adgroup()
        {
            return (string)this.<adgroup>k__BackingField;
        }
        public void set_adgroup(string value)
        {
            this.<adgroup>k__BackingField = value;
        }
        public string get_campaign()
        {
            return (string)this.<campaign>k__BackingField;
        }
        public void set_campaign(string value)
        {
            this.<campaign>k__BackingField = value;
        }
        public string get_creative()
        {
            return (string)this.<creative>k__BackingField;
        }
        public void set_creative(string value)
        {
            this.<creative>k__BackingField = value;
        }
        public string get_clickLabel()
        {
            return (string)this.<clickLabel>k__BackingField;
        }
        public void set_clickLabel(string value)
        {
            this.<clickLabel>k__BackingField = value;
        }
        public string get_trackerName()
        {
            return (string)this.<trackerName>k__BackingField;
        }
        public void set_trackerName(string value)
        {
            this.<trackerName>k__BackingField = value;
        }
        public string get_trackerToken()
        {
            return (string)this.<trackerToken>k__BackingField;
        }
        public void set_trackerToken(string value)
        {
            this.<trackerToken>k__BackingField = value;
        }
        public string get_costType()
        {
            return (string)this.<costType>k__BackingField;
        }
        public void set_costType(string value)
        {
            this.<costType>k__BackingField = value;
        }
        public System.Nullable<double> get_costAmount()
        {
            return (System.Nullable<System.Double>)this.<costAmount>k__BackingField;
        }
        public void set_costAmount(System.Nullable<double> value)
        {
            this.<costAmount>k__BackingField = value.HasValue;
            mem[1152921520303448544] = ???;
        }
        public string get_costCurrency()
        {
            return (string)this.<costCurrency>k__BackingField;
        }
        public void set_costCurrency(string value)
        {
            this.<costCurrency>k__BackingField = value;
        }
        public AdjustAttribution()
        {
        
        }
        public AdjustAttribution(string jsonString)
        {
            string val_18;
            var val_19;
            var val_20;
            var val_21;
            com.adjust.sdk.JSONNode val_1 = com.adjust.sdk.JSONNode.Parse(aJSON:  jsonString);
            if((com.adjust.sdk.JSONNode.op_Equality(a:  val_1, b:  0)) == true)
            {
                    return;
            }
            
            val_19 = null;
            val_19 = null;
            this.<trackerName>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTrackerName);
            this.<trackerToken>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyTrackerToken);
            this.<network>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyNetwork);
            this.<campaign>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCampaign);
            this.<adgroup>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdgroup);
            this.<creative>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCreative);
            this.<clickLabel>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyClickLabel);
            this.<adid>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<costType>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCostType);
            val_20 = null;
            val_20 = null;
            val_18 = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCostAmount);
            System.Nullable<System.Double> val_15 = new System.Nullable<System.Double>(value:  System.Double.Parse(s:  val_18, provider:  System.Globalization.CultureInfo.InvariantCulture));
            this.<costAmount>k__BackingField = val_15.HasValue;
            val_21 = null;
            val_21 = null;
            this.<costCurrency>k__BackingField = com.adjust.sdk.AdjustUtils.GetJsonString(node:  val_1, key:  com.adjust.sdk.AdjustUtils.KeyCostCurrency);
        }
        public AdjustAttribution(System.Collections.Generic.Dictionary<string, string> dicAttributionData)
        {
            string val_16;
            var val_17;
            var val_18;
            var val_19;
            if(dicAttributionData == null)
            {
                    return;
            }
            
            val_17 = null;
            val_17 = null;
            this.<trackerName>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyTrackerName);
            this.<trackerToken>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyTrackerToken);
            this.<network>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyNetwork);
            this.<campaign>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyCampaign);
            this.<adgroup>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyAdgroup);
            this.<creative>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyCreative);
            this.<clickLabel>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyClickLabel);
            this.<adid>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyAdid);
            this.<costType>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyCostType);
            val_18 = null;
            val_18 = null;
            val_16 = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyCostAmount);
            System.Nullable<System.Double> val_13 = new System.Nullable<System.Double>(value:  System.Double.Parse(s:  val_16, provider:  System.Globalization.CultureInfo.InvariantCulture));
            this.<costAmount>k__BackingField = val_13.HasValue;
            val_19 = null;
            val_19 = null;
            this.<costCurrency>k__BackingField = com.adjust.sdk.AdjustUtils.TryGetValue(dictionary:  dicAttributionData, key:  com.adjust.sdk.AdjustUtils.KeyCostCurrency);
        }
    
    }

}

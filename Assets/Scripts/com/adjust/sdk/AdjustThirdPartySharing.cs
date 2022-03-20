using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustThirdPartySharing
    {
        // Fields
        internal System.Nullable<bool> isEnabled;
        internal System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> granularOptions;
        
        // Methods
        public AdjustThirdPartySharing(System.Nullable<bool> isEnabled)
        {
            this.isEnabled = isEnabled.HasValue;
            this.granularOptions = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        }
        public void addGranularOption(string partnerName, string key, string value)
        {
            System.Collections.Generic.List<System.String> val_4;
            if(partnerName == null)
            {
                    return;
            }
            
            if(key == null)
            {
                    return;
            }
            
            if(value == null)
            {
                    return;
            }
            
            if((this.granularOptions.ContainsKey(key:  partnerName)) == false)
            {
                goto label_5;
            }
            
            val_4 = this.granularOptions.Item[partnerName];
            if(val_4 != null)
            {
                goto label_7;
            }
            
            return;
            label_5:
            System.Collections.Generic.List<System.String> val_3 = null;
            val_4 = val_3;
            val_3 = new System.Collections.Generic.List<System.String>();
            this.granularOptions.Add(key:  partnerName, value:  val_3);
            label_7:
            val_3.Add(item:  key);
            val_3.Add(item:  value);
        }
    
    }

}

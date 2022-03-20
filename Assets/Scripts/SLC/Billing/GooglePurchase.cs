using UnityEngine;

namespace SLC.Billing
{
    public class GooglePurchase
    {
        // Fields
        private string <packageName>k__BackingField;
        private string <orderId>k__BackingField;
        private string <sku>k__BackingField;
        private string <developerPayload>k__BackingField;
        private string <type>k__BackingField;
        private long <purchaseTime>k__BackingField;
        private SLC.Billing.GooglePurchase.GooglePurchaseState <purchaseState>k__BackingField;
        private int <state>k__BackingField;
        private bool <isAcknowledged>k__BackingField;
        private string <purchaseToken>k__BackingField;
        private string <signature>k__BackingField;
        private string <originalJson>k__BackingField;
        
        // Properties
        public string packageName { get; set; }
        public string orderId { get; set; }
        public string sku { get; set; }
        public string developerPayload { get; set; }
        public string type { get; set; }
        public long purchaseTime { get; set; }
        public SLC.Billing.GooglePurchase.GooglePurchaseState purchaseState { get; set; }
        public int state { get; set; }
        public bool isAcknowledged { get; set; }
        public string purchaseToken { get; set; }
        public string signature { get; set; }
        public string originalJson { get; set; }
        
        // Methods
        public string get_packageName()
        {
            return (string)this.<packageName>k__BackingField;
        }
        private void set_packageName(string value)
        {
            this.<packageName>k__BackingField = value;
        }
        public string get_orderId()
        {
            return (string)this.<orderId>k__BackingField;
        }
        private void set_orderId(string value)
        {
            this.<orderId>k__BackingField = value;
        }
        public string get_sku()
        {
            return (string)this.<sku>k__BackingField;
        }
        private void set_sku(string value)
        {
            this.<sku>k__BackingField = value;
        }
        public string get_developerPayload()
        {
            return (string)this.<developerPayload>k__BackingField;
        }
        private void set_developerPayload(string value)
        {
            this.<developerPayload>k__BackingField = value;
        }
        public string get_type()
        {
            return (string)this.<type>k__BackingField;
        }
        private void set_type(string value)
        {
            this.<type>k__BackingField = value;
        }
        public long get_purchaseTime()
        {
            return (long)this.<purchaseTime>k__BackingField;
        }
        private void set_purchaseTime(long value)
        {
            this.<purchaseTime>k__BackingField = value;
        }
        public SLC.Billing.GooglePurchase.GooglePurchaseState get_purchaseState()
        {
            return (GooglePurchaseState)this.<purchaseState>k__BackingField;
        }
        private void set_purchaseState(SLC.Billing.GooglePurchase.GooglePurchaseState value)
        {
            this.<purchaseState>k__BackingField = value;
        }
        public int get_state()
        {
            return (int)this.<state>k__BackingField;
        }
        private void set_state(int value)
        {
            this.<state>k__BackingField = value;
        }
        public bool get_isAcknowledged()
        {
            return (bool)this.<isAcknowledged>k__BackingField;
        }
        private void set_isAcknowledged(bool value)
        {
            this.<isAcknowledged>k__BackingField = value;
        }
        public string get_purchaseToken()
        {
            return (string)this.<purchaseToken>k__BackingField;
        }
        private void set_purchaseToken(string value)
        {
            this.<purchaseToken>k__BackingField = value;
        }
        public string get_signature()
        {
            return (string)this.<signature>k__BackingField;
        }
        private void set_signature(string value)
        {
            this.<signature>k__BackingField = value;
        }
        public string get_originalJson()
        {
            return (string)this.<originalJson>k__BackingField;
        }
        public void set_originalJson(string value)
        {
            this.<originalJson>k__BackingField = value;
        }
        public static System.Collections.Generic.List<SLC.Billing.GooglePurchase> fromList(System.Collections.Generic.List<object> items)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3;
            var val_4;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_7;
            System.Collections.Generic.List<SLC.Billing.GooglePurchase> val_1 = new System.Collections.Generic.List<SLC.Billing.GooglePurchase>();
            List.Enumerator<T> val_2 = items.GetEnumerator();
            label_7:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_3 != 0)
            {
                    val_7 = null;
            }
            
            SLC.Billing.GooglePurchase val_6 = null;
            val_7 = val_3;
            val_6 = new SLC.Billing.GooglePurchase(dict:  val_7);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_6);
            goto label_7;
            label_2:
            val_4.Dispose();
            return val_1;
        }
        public GooglePurchase(System.Collections.Generic.Dictionary<string, object> dict)
        {
            string val_28;
            if((dict.ContainsKey(key:  "packageName")) != false)
            {
                    this.<packageName>k__BackingField = dict.Item["packageName"];
            }
            
            if((dict.ContainsKey(key:  "orderId")) != false)
            {
                    this.<orderId>k__BackingField = dict.Item["orderId"];
            }
            
            if((dict.ContainsKey(key:  "sku")) != false)
            {
                    this.<sku>k__BackingField = dict.Item["sku"];
            }
            
            if((dict.ContainsKey(key:  "developerPayload")) != false)
            {
                    this.<developerPayload>k__BackingField = dict.Item["developerPayload"];
            }
            
            if((dict.ContainsKey(key:  "type")) != false)
            {
                    object val_10 = dict.Item["type"];
                if(val_10 != null)
            {
                    var val_11 = (null == null) ? (val_10) : 0;
            }
            else
            {
                    val_28 = 0;
            }
            
                this.<type>k__BackingField = val_28;
            }
            
            if((dict.ContainsKey(key:  "purchaseTime")) != false)
            {
                    this.<purchaseTime>k__BackingField = System.Int64.Parse(s:  dict.Item["purchaseTime"]);
            }
            
            if((dict.ContainsKey(key:  "purchaseState")) != false)
            {
                    int val_17 = System.Int32.Parse(s:  dict.Item["purchaseState"]);
                this.<purchaseState>k__BackingField = val_17;
                this.<state>k__BackingField = val_17;
            }
            
            if((dict.ContainsKey(key:  "isAcknowledged")) != false)
            {
                    this.<isAcknowledged>k__BackingField = System.Boolean.Parse(value:  dict.Item["isAcknowledged"]);
            }
            
            if((dict.ContainsKey(key:  "purchaseToken")) != false)
            {
                    this.<purchaseToken>k__BackingField = dict.Item["purchaseToken"];
            }
            
            if((dict.ContainsKey(key:  "signature")) != false)
            {
                    this.<signature>k__BackingField = dict.Item["signature"];
            }
            
            if((dict.ContainsKey(key:  "originalJson")) == false)
            {
                    return;
            }
            
            this.<originalJson>k__BackingField = dict.Item["originalJson"];
        }
        public override string ToString()
        {
            int val_3;
            int val_4;
            object[] val_1 = new object[9];
            val_3 = val_1.Length;
            val_1[0] = this.<packageName>k__BackingField;
            if((this.<orderId>k__BackingField) != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[1] = this.<orderId>k__BackingField;
            if((this.<sku>k__BackingField) != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[2] = this.<sku>k__BackingField;
            if((this.<developerPayload>k__BackingField) != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[3] = this.<developerPayload>k__BackingField;
            if((this.<purchaseToken>k__BackingField) != null)
            {
                    val_3 = val_1.Length;
            }
            
            val_1[4] = this.<purchaseToken>k__BackingField;
            val_4 = val_1.Length;
            val_1[5] = this.<purchaseState>k__BackingField;
            if((this.<signature>k__BackingField) != null)
            {
                    val_4 = val_1.Length;
            }
            
            val_1[6] = this.<signature>k__BackingField;
            if((this.<type>k__BackingField) != null)
            {
                    val_4 = val_1.Length;
            }
            
            val_1[7] = this.<type>k__BackingField;
            if((this.<originalJson>k__BackingField) != null)
            {
                    val_4 = val_1.Length;
            }
            
            val_1[8] = this.<originalJson>k__BackingField;
            return (string)System.String.Format(format:  "<GooglePurchase> packageName: {0}, orderId: {1}, sku: {2}, developerPayload: {3}, purchaseToken: {4}, purchaseState: {5}, signature: {6}, type: {7}, json: {8}", args:  val_1);
        }
    
    }

}

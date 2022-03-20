using UnityEngine;

namespace SLC.Billing
{
    public class GoogleSkuInfo
    {
        // Fields
        private string <title>k__BackingField;
        private string <price>k__BackingField;
        private string <type>k__BackingField;
        private string <description>k__BackingField;
        private string <sku>k__BackingField;
        private string <priceCurrencyCode>k__BackingField;
        private long <priceAmountMicros>k__BackingField;
        
        // Properties
        public string title { get; set; }
        public string price { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public string priceCurrencyCode { get; set; }
        public long priceAmountMicros { get; set; }
        
        // Methods
        public string get_title()
        {
            return (string)this.<title>k__BackingField;
        }
        private void set_title(string value)
        {
            this.<title>k__BackingField = value;
        }
        public string get_price()
        {
            return (string)this.<price>k__BackingField;
        }
        private void set_price(string value)
        {
            this.<price>k__BackingField = value;
        }
        public string get_type()
        {
            return (string)this.<type>k__BackingField;
        }
        private void set_type(string value)
        {
            this.<type>k__BackingField = value;
        }
        public string get_description()
        {
            return (string)this.<description>k__BackingField;
        }
        private void set_description(string value)
        {
            this.<description>k__BackingField = value;
        }
        public string get_sku()
        {
            return (string)this.<sku>k__BackingField;
        }
        private void set_sku(string value)
        {
            this.<sku>k__BackingField = value;
        }
        public string get_priceCurrencyCode()
        {
            return (string)this.<priceCurrencyCode>k__BackingField;
        }
        private void set_priceCurrencyCode(string value)
        {
            this.<priceCurrencyCode>k__BackingField = value;
        }
        public long get_priceAmountMicros()
        {
            return (long)this.<priceAmountMicros>k__BackingField;
        }
        private void set_priceAmountMicros(long value)
        {
            this.<priceAmountMicros>k__BackingField = value;
        }
        public static System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo> fromList(System.Collections.Generic.List<object> items)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_3;
            var val_4;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_7;
            System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo> val_1 = new System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo>();
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
            
            SLC.Billing.GoogleSkuInfo val_6 = null;
            val_7 = val_3;
            val_6 = new SLC.Billing.GoogleSkuInfo(dict:  val_7);
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
        public GoogleSkuInfo(System.Collections.Generic.Dictionary<string, object> dict)
        {
            string val_23;
            string val_24;
            string val_25;
            string val_26;
            string val_27;
            string val_28;
            if((dict.ContainsKey(key:  "title")) != false)
            {
                    object val_2 = dict.Item["title"];
                if(val_2 != null)
            {
                    var val_3 = (null == null) ? (val_2) : 0;
            }
            else
            {
                    val_23 = 0;
            }
            
                this.<title>k__BackingField = val_23;
            }
            
            if((dict.ContainsKey(key:  "price")) != false)
            {
                    object val_5 = dict.Item["price"];
                if(val_5 != null)
            {
                    var val_6 = (null == null) ? (val_5) : 0;
            }
            else
            {
                    val_24 = 0;
            }
            
                this.<price>k__BackingField = val_24;
            }
            
            if((dict.ContainsKey(key:  "type")) != false)
            {
                    object val_8 = dict.Item["type"];
                if(val_8 != null)
            {
                    var val_9 = (null == null) ? (val_8) : 0;
            }
            else
            {
                    val_25 = 0;
            }
            
                this.<type>k__BackingField = val_25;
            }
            
            if((dict.ContainsKey(key:  "description")) != false)
            {
                    object val_11 = dict.Item["description"];
                if(val_11 != null)
            {
                    var val_12 = (null == null) ? (val_11) : 0;
            }
            else
            {
                    val_26 = 0;
            }
            
                this.<description>k__BackingField = val_26;
            }
            
            if((dict.ContainsKey(key:  "sku")) != false)
            {
                    object val_14 = dict.Item["sku"];
                if(val_14 != null)
            {
                    var val_15 = (null == null) ? (val_14) : 0;
            }
            else
            {
                    val_27 = 0;
            }
            
                this.<sku>k__BackingField = val_27;
            }
            
            if((dict.ContainsKey(key:  "price_currency_code")) != false)
            {
                    object val_17 = dict.Item["price_currency_code"];
                if(val_17 != null)
            {
                    var val_18 = (null == null) ? (val_17) : 0;
            }
            else
            {
                    val_28 = 0;
            }
            
                this.<priceCurrencyCode>k__BackingField = val_28;
            }
            
            if((dict.ContainsKey(key:  "price_amount_micros")) == false)
            {
                    return;
            }
            
            this.<priceAmountMicros>k__BackingField = System.Int64.Parse(s:  (null == null) ? dict.Item["price_amount_micros"] : 0);
        }
        public override string ToString()
        {
            int val_2;
            object[] val_1 = new object[6];
            val_2 = val_1.Length;
            val_1[0] = this.<title>k__BackingField;
            if((this.<price>k__BackingField) != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[1] = this.<price>k__BackingField;
            if((this.<type>k__BackingField) != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[2] = this.<type>k__BackingField;
            if((this.<description>k__BackingField) != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[3] = this.<description>k__BackingField;
            if((this.<sku>k__BackingField) != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[4] = this.<sku>k__BackingField;
            if((this.<priceCurrencyCode>k__BackingField) != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[5] = this.<priceCurrencyCode>k__BackingField;
            return System.String.Format(format:  "<GoogleSkuInfo> title: {0}, price: {1}, type: {2}, description: {3}, sku: {4}, priceCurrencyCode: {5}", args:  val_1);
        }
    
    }

}

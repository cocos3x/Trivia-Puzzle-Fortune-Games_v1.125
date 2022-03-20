using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustAppStoreSubscription
    {
        // Fields
        internal string price;
        internal string currency;
        internal string transactionId;
        internal string receipt;
        internal string billingStore;
        internal string transactionDate;
        internal string salesRegion;
        internal System.Collections.Generic.List<string> partnerList;
        internal System.Collections.Generic.List<string> callbackList;
        
        // Methods
        public AdjustAppStoreSubscription(string price, string currency, string transactionId, string receipt)
        {
            val_1 = new System.Object();
            this.price = price;
            this.currency = val_1;
            this.transactionId = transactionId;
            this.receipt = receipt;
        }
        public void setTransactionDate(string transactionDate)
        {
            this.transactionDate = transactionDate;
        }
        public void setSalesRegion(string salesRegion)
        {
            this.salesRegion = salesRegion;
        }
        public void addCallbackParameter(string key, string value)
        {
            System.Collections.Generic.List<System.String> val_2 = this.callbackList;
            if(val_2 == null)
            {
                    System.Collections.Generic.List<System.String> val_1 = null;
                val_2 = val_1;
                val_1 = new System.Collections.Generic.List<System.String>();
                this.callbackList = val_2;
            }
            
            val_1.Add(item:  key);
            this.callbackList.Add(item:  value);
        }
        public void addPartnerParameter(string key, string value)
        {
            System.Collections.Generic.List<System.String> val_2 = this.partnerList;
            if(val_2 == null)
            {
                    System.Collections.Generic.List<System.String> val_1 = null;
                val_2 = val_1;
                val_1 = new System.Collections.Generic.List<System.String>();
                this.partnerList = val_2;
            }
            
            val_1.Add(item:  key);
            this.partnerList.Add(item:  value);
        }
    
    }

}

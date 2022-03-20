using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustEvent
    {
        // Fields
        internal string currency;
        internal string eventToken;
        internal string callbackId;
        internal string transactionId;
        internal System.Nullable<double> revenue;
        internal System.Collections.Generic.List<string> partnerList;
        internal System.Collections.Generic.List<string> callbackList;
        internal string receipt;
        internal bool isReceiptSet;
        
        // Methods
        public AdjustEvent(string eventToken)
        {
            this.eventToken = eventToken;
            this.isReceiptSet = false;
        }
        public void setRevenue(double amount, string currency)
        {
            System.Nullable<System.Double> val_1 = new System.Nullable<System.Double>(value:  amount);
            this.currency = currency;
            this.revenue = val_1.HasValue;
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
        public void setTransactionId(string transactionId)
        {
            this.transactionId = transactionId;
        }
        public void setCallbackId(string callbackId)
        {
            this.callbackId = callbackId;
        }
        public void setReceipt(string receipt, string transactionId)
        {
            this.receipt = receipt;
            this.transactionId = transactionId;
            this.isReceiptSet = true;
        }
    
    }

}

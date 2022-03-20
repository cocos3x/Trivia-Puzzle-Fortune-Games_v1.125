using UnityEngine;

namespace SLC.Billing
{
    public class GoogleIAPManager : MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>
    {
        // Fields
        private static System.Action billingSupportedEvent;
        private static System.Action<string> billingNotSupportedEvent;
        private static System.Action<System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo>> queryInventorySucceededEvent;
        private static System.Action<string> queryInventoryFailedEvent;
        private static System.Action<SLC.Billing.GooglePurchase> purchaseSucceededEvent;
        private static System.Action<string> purchaseFailedEvent;
        private static System.Action<string, string> consumePurchaseSucceededEvent;
        private static System.Action<string, string> acknowledgePurchaseSucceededEvent;
        private static System.Action<string> consumePurchaseFailedEvent;
        private static System.Action<string> AcknowledgePurchaseFailedEvent;
        private static bool <logEnabled>k__BackingField;
        
        // Properties
        public static bool logEnabled { get; set; }
        
        // Methods
        public static void add_billingSupportedEvent(System.Action value)
        {
            if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.billingSupportedEvent, b:  value)) == null)
            {
                    return;
            }
            
            if(null == null)
            {
                    return;
            }
        
        }
        public static void remove_billingSupportedEvent(System.Action value)
        {
            if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.billingSupportedEvent, value:  value)) == null)
            {
                    return;
            }
            
            if(null == null)
            {
                    return;
            }
        
        }
        public static void add_billingNotSupportedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.billingNotSupportedEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.billingNotSupportedEvent != 1152921505038053384);
            
            return;
            label_2:
        }
        public static void remove_billingNotSupportedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.billingNotSupportedEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.billingNotSupportedEvent != 1152921505038053384);
            
            return;
            label_2:
        }
        public static void add_queryInventorySucceededEvent(System.Action<System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo>> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent != 1152921505038053392);
            
            return;
            label_2:
        }
        public static void remove_queryInventorySucceededEvent(System.Action<System.Collections.Generic.List<SLC.Billing.GoogleSkuInfo>> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent != 1152921505038053392);
            
            return;
            label_2:
        }
        public static void add_queryInventoryFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.queryInventoryFailedEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.queryInventoryFailedEvent != 1152921505038053400);
            
            return;
            label_2:
        }
        public static void remove_queryInventoryFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.queryInventoryFailedEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.queryInventoryFailedEvent != 1152921505038053400);
            
            return;
            label_2:
        }
        public static void add_purchaseSucceededEvent(System.Action<SLC.Billing.GooglePurchase> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.purchaseSucceededEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.purchaseSucceededEvent != 1152921505038053408);
            
            return;
            label_2:
        }
        public static void remove_purchaseSucceededEvent(System.Action<SLC.Billing.GooglePurchase> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.purchaseSucceededEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.purchaseSucceededEvent != 1152921505038053408);
            
            return;
            label_2:
        }
        public static void add_purchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.purchaseFailedEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.purchaseFailedEvent != 1152921505038053416);
            
            return;
            label_2:
        }
        public static void remove_purchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.purchaseFailedEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.purchaseFailedEvent != 1152921505038053416);
            
            return;
            label_2:
        }
        public static void add_consumePurchaseSucceededEvent(System.Action<string, string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent != 1152921505038053424);
            
            return;
            label_2:
        }
        public static void remove_consumePurchaseSucceededEvent(System.Action<string, string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent != 1152921505038053424);
            
            return;
            label_2:
        }
        public static void add_acknowledgePurchaseSucceededEvent(System.Action<string, string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent != 1152921505038053432);
            
            return;
            label_2:
        }
        public static void remove_acknowledgePurchaseSucceededEvent(System.Action<string, string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent != 1152921505038053432);
            
            return;
            label_2:
        }
        public static void add_consumePurchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent != 1152921505038053440);
            
            return;
            label_2:
        }
        public static void remove_consumePurchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent != 1152921505038053440);
            
            return;
            label_2:
        }
        public static void add_AcknowledgePurchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent != 1152921505038053448);
            
            return;
            label_2:
        }
        public static void remove_AcknowledgePurchaseFailedEvent(System.Action<string> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent != 1152921505038053448);
            
            return;
            label_2:
        }
        public static bool get_logEnabled()
        {
            return (bool)SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField;
        }
        public static void set_logEnabled(bool value)
        {
            SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField = value;
        }
        public void BillingSupported(string empty)
        {
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) != false)
            {
                    UnityEngine.Debug.Log(message:  "GoogleIAPManager BillingSupported ");
            }
            
            SLC.Billing.GoogleIAPManager.__il2cppRuntimeField_static_fields.Invoke();
        }
        public void QueryInventorySucceeded(string json)
        {
            var val_5;
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) != false)
            {
                    UnityEngine.Debug.Log(message:  "GoogleIAPManager QueryInventorySucceeded ");
            }
            
            if(SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent == null)
            {
                    return;
            }
            
            if((MiniJSON.Json.Deserialize(json:  json)) != null)
            {
                    val_5 = 0;
            }
            
            SLC.Billing.GoogleIAPManager.queryInventorySucceededEvent.Invoke(obj:  SLC.Billing.GoogleSkuInfo.fromList(items:  null));
        }
        public void queryInventoryFailed(string error)
        {
            SLC.Billing.GoogleIAPManager.queryInventoryFailedEvent.Invoke(obj:  error);
        }
        public void PurchaseSucceeded(string json)
        {
            var val_6;
            var val_10;
            var val_11;
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            val_10 = 0;
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) != false)
            {
                    UnityEngine.Debug.Log(message:  "GoogleIAPManager PurchaseSucceeded " + PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  false)(PrettyPrint.printJSON(obj:  null, types:  false, singleLineOutput:  false)));
            }
            
            List.Enumerator<T> val_4 = GetEnumerator();
            label_16:
            if(val_6.MoveNext() == false)
            {
                goto label_11;
            }
            
            val_11 = 0;
            new SLC.Billing.GooglePurchase() = new SLC.Billing.GooglePurchase(dict:  null);
            if(SLC.Billing.GoogleIAPManager.purchaseSucceededEvent == null)
            {
                    throw new NullReferenceException();
            }
            
            SLC.Billing.GoogleIAPManager.purchaseSucceededEvent.Invoke(obj:  new SLC.Billing.GooglePurchase());
            goto label_16;
            label_11:
            val_6.Dispose();
        }
        public void PurchaseFailed(string json)
        {
            var val_7;
            string val_8;
            string val_9;
            if(SLC.Billing.GoogleIAPManager.purchaseFailedEvent == null)
            {
                    return;
            }
            
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            val_7 = 0;
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) == false)
            {
                goto label_6;
            }
            
            if((ContainsKey(key:  "message")) == false)
            {
                goto label_8;
            }
            
            val_8 = Item["message"];
            goto label_10;
            label_6:
            label_8:
            val_8 = "";
            label_10:
            UnityEngine.Debug.LogError(message:  "GoogleIAPManager PurchaseFailed " + val_8);
            if((ContainsKey(key:  "errorCode")) != false)
            {
                    val_9 = Item["errorCode"];
            }
            else
            {
                    val_9 = "";
            }
            
            SLC.Billing.GoogleIAPManager.purchaseFailedEvent.Invoke(obj:  val_9);
        }
        public void ConsumePurchaseSucceeded(string json)
        {
            object val_5;
            if(SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent == null)
            {
                    return;
            }
            
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            object val_2 = val_1.Item["responseCode"];
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) != false)
            {
                    val_5 = "GoogleIAPManager ConsumePurchaseSucceeded " + val_2;
                UnityEngine.Debug.Log(message:  val_5);
            }
            
            SLC.Billing.GoogleIAPManager.consumePurchaseSucceededEvent.Invoke(arg1:  val_2, arg2:  val_1.Item["purchaseToken"]);
        }
        public void AcknowledgePurchaseSucceeded(string json)
        {
            object val_5;
            if(SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent == null)
            {
                    return;
            }
            
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            object val_2 = val_1.Item["responseCode"];
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) != false)
            {
                    val_5 = "GoogleIAPManager AcknowledgePurchaseSucceeded " + val_2;
                UnityEngine.Debug.Log(message:  val_5);
            }
            
            SLC.Billing.GoogleIAPManager.acknowledgePurchaseSucceededEvent.Invoke(arg1:  val_2, arg2:  val_1.Item["purchaseToken"]);
        }
        public void ConsumePurchaseFailed(string json)
        {
            var val_7;
            string val_8;
            string val_9;
            if(SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent == null)
            {
                    return;
            }
            
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            val_7 = 0;
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) == false)
            {
                goto label_6;
            }
            
            if((ContainsKey(key:  "message")) == false)
            {
                goto label_8;
            }
            
            val_8 = Item["message"];
            goto label_10;
            label_6:
            label_8:
            val_8 = "";
            label_10:
            UnityEngine.Debug.Log(message:  "GoogleIAPManager PurchaseFailed " + val_8);
            if((ContainsKey(key:  "errorCode")) != false)
            {
                    val_9 = Item["errorCode"];
            }
            else
            {
                    val_9 = "";
            }
            
            SLC.Billing.GoogleIAPManager.consumePurchaseFailedEvent.Invoke(obj:  val_9);
        }
        public void AcknowledgePurchaseFailed(string json)
        {
            var val_7;
            string val_8;
            string val_9;
            if(SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent == null)
            {
                    return;
            }
            
            object val_1 = MiniJSON.Json.Deserialize(json:  json);
            val_7 = 0;
            if((SLC.Billing.GoogleIAPManager.<logEnabled>k__BackingField) == false)
            {
                goto label_6;
            }
            
            if((ContainsKey(key:  "message")) == false)
            {
                goto label_8;
            }
            
            val_8 = Item["message"];
            goto label_10;
            label_6:
            label_8:
            val_8 = "";
            label_10:
            UnityEngine.Debug.Log(message:  "GoogleIAPManager PurchaseFailed " + val_8);
            if((ContainsKey(key:  "errorCode")) != false)
            {
                    val_9 = Item["errorCode"];
            }
            else
            {
                    val_9 = "";
            }
            
            SLC.Billing.GoogleIAPManager.AcknowledgePurchaseFailedEvent.Invoke(obj:  val_9);
        }
        public GoogleIAPManager()
        {
        
        }
    
    }

}

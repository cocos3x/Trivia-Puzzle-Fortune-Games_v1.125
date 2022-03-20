using UnityEngine;

namespace SLC.Billing
{
    public class GoogleIAP
    {
        // Fields
        private static UnityEngine.AndroidJavaObject _plugin;
        
        // Methods
        private static GoogleIAP()
        {
            var val_5;
            var val_6;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            UnityEngine.AndroidJavaClass val_2 = null;
            val_5 = val_2;
            val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.billing.BillingPlugin");
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            SLC.Billing.GoogleIAP._plugin = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            var val_5 = 0;
            val_5 = val_5 + 1;
            val_2.Dispose();
            if(0 != 0)
            {
                    throw 0;
            }
        
        }
        public static void init(string publicKey)
        {
            var val_10;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            if((MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance) == 0)
            {
                    return;
            }
            
            UnityEngine.Debug.Log(message:  "GoogleIAP gameObject:"("GoogleIAP gameObject:") + MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name(MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name));
            val_10 = null;
            val_10 = null;
            object[] val_7 = new object[2];
            val_7[0] = publicKey;
            val_7[1] = MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "init", args:  val_7);
        }
        public static void purchaseProduct(string sku)
        {
            var val_8;
            int val_9;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            if((MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance) == 0)
            {
                    UnityEngine.Debug.LogError(message:  "GoogleIAP: GoogleIAPManager.Instance event callback listener is null");
                return;
            }
            
            UnityEngine.Debug.Log(message:  "GoogleIAP purchaseProduct:"("GoogleIAP purchaseProduct:") + sku);
            val_8 = null;
            val_8 = null;
            object[] val_5 = new object[2];
            val_9 = val_5.Length;
            val_5[0] = MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name;
            if(sku != null)
            {
                    val_9 = val_5.Length;
            }
            
            val_5[1] = sku;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "purchaseProduct", args:  val_5);
        }
        public static void subscribe(string sku)
        {
            var val_8;
            int val_9;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            if((MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance) == 0)
            {
                    UnityEngine.Debug.LogError(message:  "GoogleIAP: GoogleIAPManager.Instance event callback listener is null");
                return;
            }
            
            UnityEngine.Debug.Log(message:  "GoogleIAP Subscribe:"("GoogleIAP Subscribe:") + sku);
            val_8 = null;
            val_8 = null;
            object[] val_5 = new object[2];
            val_9 = val_5.Length;
            val_5[0] = MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name;
            if(sku != null)
            {
                    val_9 = val_5.Length;
            }
            
            val_5[1] = sku;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "subscribe", args:  val_5);
        }
        public static void consumeProduct(string purchaseToken)
        {
            var val_7;
            int val_8;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            if((MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance) == 0)
            {
                    UnityEngine.Debug.LogError(message:  "GoogleIAP: GoogleIAPManager.Instance event callback listener is null");
                return;
            }
            
            val_7 = null;
            val_7 = null;
            object[] val_4 = new object[2];
            val_8 = val_4.Length;
            val_4[0] = MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name;
            if(purchaseToken != null)
            {
                    val_8 = val_4.Length;
            }
            
            val_4[1] = purchaseToken;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "consumeProduct", args:  val_4);
        }
        public static void AcknowledgeProduct(string purchaseToken)
        {
            var val_7;
            int val_8;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            if((MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance) == 0)
            {
                    UnityEngine.Debug.LogError(message:  "GoogleIAP: GoogleIAPManager.Instance event callback listener is null");
                return;
            }
            
            val_7 = null;
            val_7 = null;
            object[] val_4 = new object[2];
            val_8 = val_4.Length;
            val_4[0] = MonoSingletonSelfGenerating<SLC.Billing.GoogleIAPManager>.Instance.name;
            if(purchaseToken != null)
            {
                    val_8 = val_4.Length;
            }
            
            val_4[1] = purchaseToken;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "acknowledgeProduct", args:  val_4);
        }
        public static void queryInventory(string[] products, string[] subscriptions)
        {
            var val_3;
            int val_4;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            val_3 = null;
            val_3 = null;
            object[] val_2 = new object[2];
            val_4 = val_2.Length;
            val_2[0] = products;
            if(subscriptions != null)
            {
                    val_4 = val_2.Length;
            }
            
            val_2[1] = subscriptions;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "queryInventory", args:  val_2);
        }
        public static void queryHistory()
        {
            var val_2;
            var val_3;
            if(UnityEngine.Application.platform != 11)
            {
                    return;
            }
            
            val_2 = null;
            val_2 = null;
            val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            SLC.Billing.GoogleIAP._plugin.Call(methodName:  "queryHistory", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public GoogleIAP()
        {
        
        }
    
    }

}

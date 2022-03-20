using UnityEngine;
public class AmplitudePlugin : Tracker, PluginObserver
{
    // Fields
    private static bool initialized;
    private System.Collections.Generic.Dictionary<string, object> loadedData;
    
    // Methods
    public PluginObserverManager.ObserverType getType()
    {
        return 0;
    }
    public string pluginName()
    {
        return "Amplitude";
    }
    public string errorMessage()
    {
        var val_3;
        string val_4;
        var val_5;
        val_3 = null;
        val_3 = null;
        if(AmplitudePlugin.initialized != false)
        {
                val_4 = "Plugin initialized. " + (W9 == 0) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. "((W9 == 0) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. ");
            val_5 = null;
            val_5 = null;
            if(PluginObserverManager.isPurchaseValidationWorking == true)
        {
                return (string)val_4;
        }
        
            return val_4 + "Purchase validation not working. ";
        }
        
        val_4 = "Not initialized!";
        return (string)val_4;
    }
    public bool isWorking()
    {
        return (bool)this;
    }
    public bool isInitialized()
    {
        null = null;
        return (bool)AmplitudePlugin.initialized;
    }
    public static bool TrackingEnabled(string eventName)
    {
        var val_11;
        string val_12;
        var val_13;
        val_11 = "amplitude";
        if((UnityEngine.PlayerPrefs.HasKey(key:  "amplitude")) == false)
        {
            goto label_17;
        }
        
        val_11 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "amplitude"));
        val_12 = val_11.Item["enabled"];
        if((System.Boolean.Parse(value:  val_12)) == false)
        {
            goto label_8;
        }
        
        string val_7 = eventName.Replace(oldValue:  " ", newValue:  "_").ToLower();
        object[] val_8 = new object[1];
        val_12 = val_8;
        val_12[0] = val_7;
        UnityEngine.Debug.LogWarningFormat(format:  "check tracking on: {0}", args:  val_8);
        if((val_11.ContainsKey(key:  val_7)) != false)
        {
                return System.Boolean.Parse(value:  val_11.Item[val_7]);
        }
        
        label_17:
        val_13 = 1;
        return (bool)val_13;
        label_8:
        val_13 = 0;
        return (bool)val_13;
    }
    public AmplitudePlugin()
    {
        MonoSingletonSelfGenerating<PluginObserverManager>.Instance.AddObserver(observer:  this);
    }
    public AmplitudePlugin(string apiKey, string deviceId)
    {
        var val_4;
        MonoSingletonSelfGenerating<PluginObserverManager>.Instance.AddObserver(observer:  this);
        Amplitude val_2 = Amplitude.Instance;
        val_2.logging = true;
        Amplitude.Instance.init(apiKey:  apiKey, userId:  deviceId);
        val_4 = null;
        val_4 = null;
        AmplitudePlugin.initialized = true;
    }
    public override void increment(string eventName, string eventValue)
    {
    
    }
    public override void peopleIncrement(string eventName, string eventValue)
    {
    
    }
    public override void superProperty(string propertyName, string propertyValue)
    {
        this.Log(message:  "Amplitude superProperty " + propertyName);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_2.Add(key:  propertyName, value:  propertyValue);
        Amplitude.Instance.setUserProperties(properties:  val_2);
    }
    public override void peopleProperty(string propertyName, string propertyValue)
    {
        goto typeof(AmplitudePlugin).__il2cppRuntimeField_1D0;
    }
    public override void trackEvent(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        System.Collections.Generic.Dictionary<TKey, TValue> val_9;
        var val_10;
        val_9 = data;
        if((AmplitudePlugin.TrackingEnabled(eventName:  eventName)) == false)
        {
                return;
        }
        
        if(val_9 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
            val_9 = val_2;
            val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            UnityEngine.Debug.LogError(message:  "trying to track event of " + eventName + " with no tracking data");
        }
        
        Player val_4 = App.Player;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_10 = null;
        AmplitudePluginHelper.InjectRegularGlobals(eventName:  null, globals:  val_5);
        AmplitudePluginHelper.InjectFeatureGlobals(eventName:  eventName, globals:  val_5);
        AmplitudePluginHelper.InjectMetaData(eventName:  eventName, data:  val_2);
        AmplitudePluginHelper.InjectMetaBehaviorProperties(eventName:  eventName, globals: ref  val_5, data: ref  val_2);
        Amplitude.Instance.setUserProperties(properties:  val_5);
        Amplitude.Instance.logEvent(evt:  eventName, properties:  val_2);
        mem[1152921515674657592] = 1;
        this.Log(message:  "Amplitude > Amplitude tracker | EventName: "("Amplitude > Amplitude tracker | EventName: ") + eventName);
    }
    public override void trackEvent(string eventName, string propertyName, string propertyValue)
    {
        int val_4;
        string[] val_1 = new string[7];
        val_4 = val_1.Length;
        val_1[0] = "Amplitude trackEvent ";
        if(eventName != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[1] = eventName;
        val_4 = val_1.Length;
        val_1[2] = " {";
        if(propertyName != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[3] = propertyName;
        val_4 = val_1.Length;
        val_1[4] = ": ";
        if(propertyValue != null)
        {
                val_4 = val_1.Length;
        }
        
        val_1[5] = propertyValue;
        val_4 = val_1.Length;
        val_1[6] = "}";
        this.Log(message:  +val_1);
        new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  propertyName, value:  propertyValue);
        goto typeof(AmplitudePlugin).__il2cppRuntimeField_180;
    }
    public override void identify(string userId)
    {
        this.Log(message:  "Amplitude identify " + userId);
        Amplitude.Instance.setUserId(userId:  userId);
    }
    public override void trackCharge(string amount, System.Collections.Generic.Dictionary<string, object> options)
    {
        var val_14;
        System.Collections.Generic.Dictionary<TKey, TValue> val_15;
        string val_16;
        val_14 = options;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
        val_16 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::.ctor();
        val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_14.Item["Purchase_Info"] != null)
        {
                val_16 = "Purchase_Info";
            if(val_14.Item[val_16] == null)
        {
                throw new NullReferenceException();
        }
        
            AddStoreSpecificDataForValidation(postParams: ref  val_1);
        }
        
        val_16 = 0;
        val_15 = val_1;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = "signature";
        if(val_1.Item[val_16] == null)
        {
                return;
        }
        
        val_15 = val_1;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = "signature";
        object val_7 = val_1.Item[val_16];
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_16 = 0;
        if((System.String.IsNullOrEmpty(value:  val_7)) == true)
        {
                return;
        }
        
        val_14 = Amplitude.Instance;
        val_15 = val_1;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = "product_id";
        object val_10 = val_1.Item[val_16];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_1;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = "originalJson";
        object val_11 = val_1.Item[val_16];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_1;
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = "signature";
        object val_12 = val_1.Item[val_16];
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.logRevenue(productId:  val_10, quantity:  1, price:  System.Convert.ToDouble(value:  amount), receipt:  val_11, receiptSignature:  val_12);
        this.Log(message:  "Amplitude > Amplitude tracker | Revenue with amount = "("Amplitude > Amplitude tracker | Revenue with amount = ") + amount);
    }
    private void TrackWebglCharge(string amount, string webProductId)
    {
    
    }
    private static AmplitudePlugin()
    {
    
    }

}

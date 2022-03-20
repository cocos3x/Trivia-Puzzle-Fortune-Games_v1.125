using UnityEngine;
public class AdjustTracking : Tracker, PluginObserver
{
    // Fields
    private bool initialized;
    private System.Collections.Generic.Dictionary<string, string> eventTokens;
    
    // Methods
    public PluginObserverManager.ObserverType getType()
    {
        return 0;
    }
    public string pluginName()
    {
        return "Adjust";
    }
    public string errorMessage()
    {
        string val_3;
        var val_4;
        if(this.initialized != false)
        {
                val_3 = "Plugin initialized. " + (W9 == 0) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. "((W9 == 0) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. ");
            val_4 = null;
            val_4 = null;
            if(PluginObserverManager.isPurchaseValidationWorking == true)
        {
                return (string)val_3;
        }
        
            return val_3 + "Purchase validation not working. ";
        }
        
        val_3 = "Not initialized!";
        return (string)val_3;
    }
    public bool isWorking()
    {
        return (bool)this;
    }
    public bool isInitialized()
    {
        return (bool)this.initialized;
    }
    public AdjustTracking(string appToken)
    {
        if(this.initialized == true)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<PluginObserverManager>.Instance.AddObserver(observer:  this);
        com.adjust.sdk.Adjust.start(adjustConfig:  AdjustPlugin.BuildAdjustConfig(appToken:  appToken));
        UnityEngine.GameObject val_3 = new UnityEngine.GameObject(name:  "Adjust");
        com.adjust.sdk.Adjust val_4 = val_3.AddComponent<com.adjust.sdk.Adjust>();
        UnityEngine.Object.DontDestroyOnLoad(target:  val_3);
        this.eventTokens = new System.Collections.Generic.Dictionary<System.String, System.String>();
        this.initialized = true;
    }
    public void AddEventToken(string eventName, string eventToken)
    {
        var val_6;
        var val_7;
        if((this.eventTokens.ContainsKey(key:  eventName)) != false)
        {
                UnityEngine.Debug.LogError(message:  System.String.Format(format:  "{0}\'s token was already added before!", arg0:  eventName));
            return;
        }
        
        if((System.String.op_Equality(a:  eventToken, b:  "token")) != false)
        {
                UnityEngine.Debug.LogWarning(message:  "Token for " + eventName + " is the default one. Not Adding.");
            return;
        }
        
        val_6 = null;
        val_6 = null;
        if((System.String.op_Equality(a:  eventName, b:  Events.REVENUE_IAP)) != false)
        {
                val_7 = null;
            val_7 = null;
            AdjustPlugin.type = eventToken;
        }
        
        this.eventTokens.Add(key:  eventName, value:  eventToken);
    }
    public override void trackEvent(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        UnityEngine.Debug.Log(message:  "tracking with Adjust " + eventName);
    }
    public override void trackEvent(string eventName, string propertyName, string propertyValue)
    {
        string val_17;
        string val_18;
        System.Collections.Generic.Dictionary<System.String, System.String> val_19;
        val_17 = propertyValue;
        string val_2 = eventName.ToLower().Replace(oldValue:  " ", newValue:  "_");
        val_18 = val_2;
        if((System.String.op_Equality(a:  val_2, b:  "current_level")) == false)
        {
            goto label_3;
        }
        
        val_19 = this;
        val_18 = "level_up_" + val_17;
        if((this.eventTokens.ContainsKey(key:  "level_up")) == false)
        {
            goto label_5;
        }
        
        string val_6 = this.eventTokens.Item["level_up"];
        val_17 = val_6.getParams(addPropertyName:  "level", addPropertyValue:  val_17);
        com.adjust.sdk.AdjustEvent val_8 = new com.adjust.sdk.AdjustEvent(eventToken:  val_6);
        com.adjust.sdk.Adjust.trackEvent(adjustEvent:  AdjustPlugin.BuildEvent(eventToken:  val_6, eventParams:  val_17));
        goto label_10;
        label_3:
        val_19 = this.eventTokens;
        goto label_10;
        label_5:
        UnityEngine.Debug.LogError(message:  "level_up has no token (or is default \'token\') for Adjust, not tracking.");
        label_10:
        if((this.eventTokens.ContainsKey(key:  val_18)) != false)
        {
                string val_11 = this.eventTokens.Item[val_18];
            val_17 = val_11;
            com.adjust.sdk.Adjust.trackEvent(adjustEvent:  AdjustPlugin.BuildEvent(eventToken:  val_17, eventParams:  val_11.getParams(addPropertyName:  "", addPropertyValue:  "")));
            this.Log(message:  "Adjust > Adjust tracker | EventName: "("Adjust > Adjust tracker | EventName: ") + val_18);
            mem[1152921515644753112] = 1;
            return;
        }
        
        if(((val_18.IndexOf(value:  "level_up")) & 2147483648) == 0)
        {
                return;
        }
        
        UnityEngine.Debug.LogError(message:  System.String.Format(format:  "{0} has no token for Adjust, not tracking.", arg0:  val_18));
    }
    public override void trackCharge(string amount, System.Collections.Generic.Dictionary<string, object> options)
    {
        this.Log(message:  "Adjust > Adjust tracker | Revenue with amount = "("Adjust > Adjust tracker | Revenue with amount = ") + amount);
        com.adjust.sdk.Adjust.trackEvent(adjustEvent:  AdjustPlugin.BuildTrackChargeEvent(amount:  System.Convert.ToDouble(value:  amount), transactionId:  0));
        mem[1152921515644947208] = 1;
    }
    private System.Collections.Generic.Dictionary<string, string> getParams(string addPropertyName = "", string addPropertyValue = "")
    {
        string val_11;
        char[] val_2 = new char[1];
        val_2[0] = 32;
        System.String[] val_3 = DeviceProperties.DeviceModel.Split(separator:  val_2);
        if(val_3.Length != 0)
        {
                char[] val_5 = new char[1];
            val_5[0] = 32;
        }
        else
        {
                val_11 = "mobile";
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_8 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_8.Add(key:  "brand", value:  val_11);
        val_8.Add(key:  "model", value:  UnityEngine.WWW.EscapeURL(s:  DeviceProperties.DeviceModel));
        if((System.String.IsNullOrEmpty(value:  addPropertyName)) == true)
        {
                return val_8;
        }
        
        val_8.Add(key:  addPropertyName, value:  addPropertyValue);
        return val_8;
    }
    public override void increment(string eventName, string eventValue)
    {
    
    }
    public override void peopleIncrement(string eventName, string eventValue)
    {
    
    }
    public override void peopleProperty(string propertyName, string propertyValue)
    {
    
    }
    public override void superProperty(string propertyName, string propertyValue)
    {
    
    }
    public override void identify(string id)
    {
    
    }

}

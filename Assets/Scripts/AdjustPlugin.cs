using UnityEngine;
public class AdjustPlugin
{
    // Fields
    private const string CURRENCY = "USD";
    private static string REVENUE_TOKEN;
    private const AdjustPlugin.AmountTrackingType type = 0;
    private static string <clickLabelInstall>k__BackingField;
    private static string <Attribution_network>k__BackingField;
    private static string <Attribution_adgroup>k__BackingField;
    private static string <Attribution_campaign>k__BackingField;
    private static string <Attribution_trackerName>k__BackingField;
    private static string <Attribution_trackerToken>k__BackingField;
    private static string <Attribution_latestMessage>k__BackingField;
    public static bool consumedAdjustInstall;
    
    // Properties
    private static double DeductionFactor { get; }
    public static string clickLabelInstall { get; set; }
    public static string Attribution_network { get; set; }
    public static string Attribution_adgroup { get; set; }
    public static string Attribution_campaign { get; set; }
    public static string Attribution_trackerName { get; set; }
    public static string Attribution_trackerToken { get; set; }
    public static string Attribution_latestMessage { get; set; }
    
    // Methods
    public static com.adjust.sdk.AdjustConfig BuildAdjustConfig(string appToken)
    {
        var val_9;
        System.Action<System.String> val_11;
        UnityEngine.Debug.Log(message:  "2jhtw34 Token is " + appToken);
        com.adjust.sdk.AdjustConfig val_5 = new com.adjust.sdk.AdjustConfig(appToken:  appToken, environment:  (~CompanyDevices.Instance.CompanyDevice()) & 1);
        val_5.setLogLevel(logLevel:  1);
        .logDelegate = new System.Action<System.String>(object:  0, method:  public static System.Void AdjustPlugin::logDelegate(string message));
        .launchDeferredDeeplink = true;
        val_9 = null;
        val_9 = null;
        val_11 = AdjustPlugin.<>c.<>9__4_0;
        if(val_11 == null)
        {
                System.Action<System.String> val_7 = null;
            val_11 = val_7;
            val_7 = new System.Action<System.String>(object:  AdjustPlugin.<>c.__il2cppRuntimeField_static_fields, method:  System.Void AdjustPlugin.<>c::<BuildAdjustConfig>b__4_0(string url));
            AdjustPlugin.<>c.<>9__4_0 = val_11;
        }
        
        val_5.setDeferredDeeplinkDelegate(deferredDeeplinkDelegate:  val_7, sceneName:  "Adjust");
        val_5.setAttributionChangedDelegate(attributionChangedDelegate:  new System.Action<com.adjust.sdk.AdjustAttribution>(object:  0, method:  public static System.Void AdjustPlugin::attributionChangedDelegate(com.adjust.sdk.AdjustAttribution attribution)), sceneName:  "Adjust");
        return val_5;
    }
    public static void AddRevenueEventToken(string token)
    {
        null = null;
        AdjustPlugin.type = token;
    }
    public static com.adjust.sdk.AdjustEvent BuildEvent(string eventToken, System.Collections.Generic.Dictionary<string, string> eventParams)
    {
        com.adjust.sdk.AdjustEvent val_1 = new com.adjust.sdk.AdjustEvent(eventToken:  eventToken);
        if(eventParams == null)
        {
                return val_1;
        }
        
        if(eventParams.Count < 1)
        {
                return val_1;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_4 = eventParams.Keys.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_4;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.addPartnerParameter(key:  0, value:  eventParams.Item[0]);
        goto label_6;
        label_4:
        0.Dispose();
        return val_1;
    }
    public static com.adjust.sdk.AdjustEvent BuildTrackChargeEvent(double amount, string transactionId)
    {
        null = null;
        com.adjust.sdk.AdjustEvent val_1 = new com.adjust.sdk.AdjustEvent(eventToken:  AdjustPlugin.type);
        if(transactionId != null)
        {
                .transactionId = transactionId;
        }
        
        val_1.setRevenue(amount:  amount, currency:  "USD");
        return val_1;
    }
    private static double get_DeductionFactor()
    {
        return 1;
    }
    public static void logDelegate(string message)
    {
        null = null;
        AdjustPlugin.<Attribution_latestMessage>k__BackingField = message;
    }
    public static string get_clickLabelInstall()
    {
        null = null;
        return (string)AdjustPlugin.<clickLabelInstall>k__BackingField;
    }
    public static void set_clickLabelInstall(string value)
    {
        null = null;
        AdjustPlugin.<clickLabelInstall>k__BackingField = value;
    }
    public static void attributionChangedDelegate(com.adjust.sdk.AdjustAttribution attribution)
    {
        var val_1;
        var val_2;
        string val_3;
        var val_4;
        val_1 = null;
        val_2 = null;
        val_2 = null;
        AdjustPlugin.<Attribution_network>k__BackingField = attribution.<network>k__BackingField;
        val_2 = null;
        val_2 = null;
        AdjustPlugin.<Attribution_adgroup>k__BackingField = attribution.<adgroup>k__BackingField;
        val_2 = null;
        val_2 = null;
        AdjustPlugin.<Attribution_campaign>k__BackingField = attribution.<campaign>k__BackingField;
        val_2 = null;
        val_2 = null;
        AdjustPlugin.<Attribution_trackerName>k__BackingField = attribution.<trackerName>k__BackingField;
        val_3 = attribution.<trackerToken>k__BackingField;
        val_2 = null;
        val_2 = null;
        AdjustPlugin.<Attribution_trackerToken>k__BackingField = val_3;
        if((attribution.<clickLabel>k__BackingField) == null)
        {
                return;
        }
        
        val_4 = null;
        val_4 = null;
        AdjustPlugin.<clickLabelInstall>k__BackingField = attribution.<clickLabel>k__BackingField;
    }
    public static string get_Attribution_network()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_network>k__BackingField;
    }
    public static void set_Attribution_network(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_network>k__BackingField = value;
    }
    public static string get_Attribution_adgroup()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_adgroup>k__BackingField;
    }
    private static void set_Attribution_adgroup(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_adgroup>k__BackingField = value;
    }
    public static string get_Attribution_campaign()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_campaign>k__BackingField;
    }
    private static void set_Attribution_campaign(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_campaign>k__BackingField = value;
    }
    public static string get_Attribution_trackerName()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_trackerName>k__BackingField;
    }
    private static void set_Attribution_trackerName(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_trackerName>k__BackingField = value;
    }
    public static string get_Attribution_trackerToken()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_trackerToken>k__BackingField;
    }
    private static void set_Attribution_trackerToken(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_trackerToken>k__BackingField = value;
    }
    public static string get_Attribution_latestMessage()
    {
        null = null;
        return (string)AdjustPlugin.<Attribution_latestMessage>k__BackingField;
    }
    private static void set_Attribution_latestMessage(string value)
    {
        null = null;
        AdjustPlugin.<Attribution_latestMessage>k__BackingField = value;
    }
    public AdjustPlugin()
    {
    
    }
    private static AdjustPlugin()
    {
    
    }

}

using UnityEngine;
public class HelpshiftPlugin : MonoSingletonSelfGenerating<HelpshiftPlugin>
{
    // Fields
    private static HelpshiftPlugin instance;
    private Helpshift.HelpshiftSdk help;
    private bool initialized;
    private string gameObjectName;
    private System.Collections.Generic.Dictionary<string, object> configMap;
    private System.Collections.Generic.Dictionary<string, object> metadata;
    private HelpshiftPlugin.CurrencyDelegate currencyCalculator;
    private bool fromFeedbackButton;
    
    // Properties
    private float iOSVersion { get; }
    
    // Methods
    private float get_iOSVersion()
    {
        return 0f;
    }
    public void Init(string gameObject, string apiKey, string domain, string appId, HelpshiftPlugin.CurrencyDelegate currencies)
    {
        var val_21;
        CurrencyDelegate val_22;
        string val_23;
        UnityEngine.Object val_24;
        val_22 = currencies;
        val_23 = domain;
        val_24 = this;
        if(this.initialized == true)
        {
                return;
        }
        
        this.help = Helpshift.HelpshiftSdk.getInstance();
        this.gameObjectName = gameObject;
        this.currencyCalculator = val_22;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.metadata = val_2;
        val_21 = 1152921504884269056;
        Player val_3 = App.Player;
        val_2.Add(key:  "supportId", value:  val_3.support);
        Player val_4 = App.Player;
        this.metadata.Add(key:  "deviceId", value:  val_4.uuid);
        this.metadata.Add(key:  "gameVersion", value:  DeviceIdPlugin.GetClientVersion());
        this.metadata.Add(key:  "osVersion", value:  "android");
        this.metadata.Add(key:  "deviceType", value:  UnityEngine.SystemInfo.deviceModel);
        this.metadata.Add(key:  "currencies", value:  this.currencyCalculator.Invoke());
        GameBehavior val_8 = App.getBehavior;
        this.metadata.Add(key:  "level", value:  val_8.<metaGameBehavior>k__BackingField.ToString());
        Player val_10 = App.Player;
        this.metadata.Add(key:  "isHacker", value:  val_10.isHacker);
        Player val_11 = App.Player;
        if(val_11.isHacker != false)
        {
                Player val_12 = App.Player;
            this.metadata.Add(key:  "hackerTag", value:  val_12.hackerType);
        }
        
        this.metadata.Add(key:  "hs-tags", value:  this.metadata.GetTags());
        System.Collections.Generic.Dictionary<System.String, System.Object> val_14 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.configMap = val_14;
        val_14.Add(key:  "unityGameObject", value:  this.gameObjectName);
        val_22 = "yes";
        this.configMap.Add(key:  "enableInAppNotification", value:  "yes");
        this.configMap.Add(key:  "hideNameAndEmail", value:  "yes");
        this.configMap.install(apiKey:  apiKey, domainName:  val_23, appId:  appId, config:  this.configMap);
        this.configMap.updateMetaData(metaData:  this.metadata);
        Player val_15 = App.Player;
        val_23 = val_15.uuid;
        .identifier = val_23;
        .email = "";
        Helpshift.HelpshiftUser val_17 = new HelpshiftUser.Builder().build();
        val_17.login(helpshiftUser:  val_17);
        val_17.requestUnreadMessagesCount(isAsync:  true);
        this.initialized = true;
        this.gameObject.transform.SetParent(p:  0);
        val_24 = this.gameObject;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_24);
    }
    public void ShowSupport(string prefillText = "")
    {
        if(this.initialized == false)
        {
                return;
        }
        
        TrackingComponent.CurrentIntent = 1;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "showSearchOnNewConversation", value:  "YES");
        if((System.String.IsNullOrEmpty(value:  prefillText)) != true)
        {
                val_1.Add(key:  "conversationPrefillText", value:  prefillText);
        }
        
        val_1.showConversation(configMap:  val_1);
    }
    public void ShowFAQs()
    {
        TrackingComponent.CurrentIntent = 1;
        if(this.initialized == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.showFAQs(configMap:  val_1);
    }
    public void UpdateMetadata()
    {
        GameBehavior val_1 = App.getBehavior;
        this.metadata.set_Item(key:  "level", value:  val_1.<metaGameBehavior>k__BackingField.ToString());
        this.metadata.set_Item(key:  "currencies", value:  this.currencyCalculator.Invoke());
        this.metadata.set_Item(key:  "tags", value:  this.metadata.GetTags());
        this.metadata.updateMetaData(metaData:  this.metadata);
    }
    public bool UpdateDeviceToken()
    {
        var val_3;
        if(this.help == null)
        {
            goto label_0;
        }
        
        string val_1 = DeviceProperties.notificationToken;
        bool val_2 = System.String.IsNullOrEmpty(value:  val_1);
        if(val_2 == false)
        {
            goto label_1;
        }
        
        label_0:
        val_3 = 0;
        return (bool)val_3;
        label_1:
        val_2.registerDeviceToken(deviceToken:  val_1);
        val_3 = 1;
        return (bool)val_3;
    }
    public void handleRemoteNotification(string issueId)
    {
    
    }
    private static string formatDeviceToken(byte[] token)
    {
        string val_10;
        var val_11;
        val_10 = "";
        int val_10 = val_4.Length;
        if(val_10 < 1)
        {
                return (string)"<"("<") + val_10.Trim() + ">"(">");
        }
        
        var val_11 = 0;
        val_10 = val_10 & 4294967295;
        val_11 = 1;
        do
        {
            val_10 = val_10 + null.ToString();
            if(val_11 == 8)
        {
                val_10 = val_10 + " ";
            val_11 = 0;
        }
        
            val_11 = val_11 + 1;
            val_11 = val_11 + 1;
        }
        while(val_11 < (val_4.Length << ));
        
        return (string)"<"("<") + val_10.Trim() + ">"(">");
    }
    private string[] GetTags()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        Player val_2 = App.Player;
        if(val_2.total_purchased > 0f)
        {
                val_1.Add(item:  "purchaser");
        }
        
        if((UnityEngine.PlayerPrefs.GetInt(key:  "reward_watcher", defaultValue:  0)) >= 1)
        {
                val_1.Add(item:  "watcher");
        }
        
        if((UnityEngine.PlayerPrefs.GetInt(key:  "unity_crashed", defaultValue:  0)) < 1)
        {
                return val_1.ToArray();
        }
        
        val_1.Add(item:  "unity_crashed");
        return val_1.ToArray();
    }
    public void getNotifsCount()
    {
        if(this.help != null)
        {
                this.help.requestUnreadMessagesCount(isAsync:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    public HelpshiftPlugin()
    {
    
    }

}

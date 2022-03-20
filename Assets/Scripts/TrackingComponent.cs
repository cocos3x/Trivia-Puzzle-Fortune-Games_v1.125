using UnityEngine;
public class TrackingComponent : AppComponent
{
    // Fields
    private static bool hasFinishedInitializing;
    public static System.Action finishedInitializingCallback;
    private string _gameObjectName;
    protected AmplitudePlugin amplitude;
    protected AdjustTracking adjustTracking;
    protected FirebasePlugin firebase;
    private static System.DateTime started;
    private static TrackingComponent.AppPauseIntent currentIntent;
    private static TrackingComponent.AppPauseIntent lastIntent;
    
    // Properties
    public static bool wasInit { get; }
    public override bool RunInMainThread { get; }
    protected virtual string EconomyVersion { get; }
    protected virtual int GamesToShowAds { get; }
    public AdjustTracking Adjust { get; }
    public AmplitudePlugin Amplitude { get; }
    public static TrackingComponent.AppPauseIntent CurrentIntent { get; set; }
    public static TrackingComponent.AppPauseIntent LastIntent { get; }
    
    // Methods
    public static bool get_wasInit()
    {
        null = null;
        return (bool)TrackingComponent.hasFinishedInitializing;
    }
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public TrackingComponent(string gameName, string gameObjectName)
    {
        this._gameObjectName = gameObjectName;
        mem[1152921515592409456] = "TrackingComponent";
    }
    protected virtual string get_EconomyVersion()
    {
        return DeviceIdPlugin.GetClientVersion();
    }
    protected virtual void postTrackerLogic()
    {
    
    }
    protected virtual int get_GamesToShowAds()
    {
        return 10;
    }
    protected virtual bool GameSpecificAdLogic()
    {
        return true;
    }
    public AdjustTracking get_Adjust()
    {
        return (AdjustTracking)this.adjustTracking;
    }
    public AmplitudePlugin get_Amplitude()
    {
        return (AmplitudePlugin)this.amplitude;
    }
    public override void initializeOnMainThread()
    {
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        var val_46;
        var val_47;
        var val_48;
        var val_49;
        if(UnityEngine.Application.platform == 11)
        {
                int val_2 = UnityEngine.AndroidJNI.AttachCurrentThread();
        }
        
        this.initializeTrackers();
        this.initializeGeneralEvents();
        this.addTrackers();
        val_33 = null;
        val_33 = null;
        App.trackerManager.identify(id:  DeviceIdPlugin.GetDeviceId());
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_4.Add(key:  "Count", value:  "1");
        val_34 = null;
        val_34 = null;
        App.trackerManager.track(eventName:  Events.APP_LAUNCHED, data:  val_4);
        val_35 = null;
        val_35 = null;
        Player val_5 = App.Player;
        App.trackerManager.superProperty(propertyName:  Events.BUCKET, propertyValue:  val_5.playerBucket);
        val_36 = null;
        val_36 = null;
        Player val_6 = App.Player;
        App.trackerManager.peopleProperty(propertyName:  Events.BUCKET, propertyValue:  val_6.playerBucket);
        val_37 = null;
        val_37 = null;
        App.trackerManager.superProperty(propertyName:  Events.PROCESSOR_TYPE, propertyValue:  UnityEngine.SystemInfo.processorType);
        val_38 = null;
        val_38 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.PROCESSOR_TYPE, propertyValue:  UnityEngine.SystemInfo.processorType);
        val_39 = null;
        val_39 = null;
        App.trackerManager.superProperty(propertyName:  Events.PROCESSOR_COUNT, propertyValue:  UnityEngine.SystemInfo.processorCount.ToString());
        val_40 = null;
        val_40 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.PROCESSOR_COUNT, propertyValue:  UnityEngine.SystemInfo.processorCount.ToString());
        val_41 = null;
        val_41 = null;
        App.trackerManager.superProperty(propertyName:  Events.SYSTEM_MEMORY_SIZE, propertyValue:  UnityEngine.SystemInfo.systemMemorySize.ToString());
        val_42 = null;
        val_42 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.SYSTEM_MEMORY_SIZE, propertyValue:  UnityEngine.SystemInfo.systemMemorySize.ToString());
        val_43 = null;
        val_43 = null;
        App.trackerManager.superProperty(propertyName:  Events.GRAPHICS_MEMORY_SIZE, propertyValue:  UnityEngine.SystemInfo.graphicsMemorySize.ToString());
        val_44 = null;
        val_44 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.GRAPHICS_MEMORY_SIZE, propertyValue:  UnityEngine.SystemInfo.graphicsMemorySize.ToString());
        val_45 = null;
        val_45 = null;
        App.trackerManager.superProperty(propertyName:  Events.GRAPHICS_DEVICE_NAME, propertyValue:  UnityEngine.SystemInfo.graphicsDeviceName);
        val_46 = null;
        val_46 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.GRAPHICS_DEVICE_NAME, propertyValue:  UnityEngine.SystemInfo.graphicsDeviceName);
        val_47 = null;
        val_47 = null;
        App.trackerManager.superProperty(propertyName:  Events.GRAPHICS_DEVICE_VENDOR, propertyValue:  UnityEngine.SystemInfo.graphicsDeviceVendor);
        val_48 = null;
        val_48 = null;
        App.trackerManager.peopleProperty(propertyName:  Events.GRAPHICS_DEVICE_VENDOR, propertyValue:  UnityEngine.SystemInfo.graphicsDeviceVendor);
        AppConfigs val_26 = App.Configuration;
        AppConfigs val_28 = App.Configuration;
        AppConfigs val_30 = App.Configuration;
        MonoSingletonSelfGenerating<HelpshiftPlugin>.Instance.Init(gameObject:  Events.GRAPHICS_DEVICE_VENDOR, apiKey:  val_26.appConfig.Key(key:  "helpshiftApiKey"), domain:  val_28.appConfig.Key(key:  "helpshiftDomainName"), appId:  val_30.appConfig.Key(key:  "helpshiftAppId"), currencies:  new HelpshiftPlugin.CurrencyDelegate(object:  this, method:  typeof(TrackingComponent).__il2cppRuntimeField_228));
        val_49 = null;
        val_49 = null;
        TrackingComponent.hasFinishedInitializing = true;
        if(TrackingComponent.finishedInitializingCallback == null)
        {
                return;
        }
        
        TrackingComponent.finishedInitializingCallback.Invoke();
        TrackingComponent.finishedInitializingCallback = 0;
    }
    public virtual string getPlayerVirtualCurrencies()
    {
        return "";
    }
    private void initializeTrackers()
    {
        AppConfigs val_1 = App.Configuration;
        this.amplitude = new AmplitudePlugin(apiKey:  val_1.appConfig.amplitudeApiKey, deviceId:  DeviceIdPlugin.GetDeviceId());
        AppConfigs val_4 = App.Configuration;
        this.adjustTracking = new AdjustTracking(appToken:  val_4.appConfig.Key(key:  "adjustAppToken"));
        this.firebase = new FirebasePlugin();
    }
    private void addTrackers()
    {
        var val_1;
        var val_2;
        var val_3;
        val_1 = null;
        val_1 = null;
        App.trackerManager.addTracker(t:  this.amplitude);
        val_2 = null;
        val_2 = null;
        App.trackerManager.addTracker(t:  this.adjustTracking);
        val_3 = null;
        val_3 = null;
        App.trackerManager.addTracker(t:  this.firebase);
    }
    private void initializeGeneralEvents()
    {
        AdjustTracking val_34;
        string val_35;
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.DAILY_BONUS;
        this.adjustTracking.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_16;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_20;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_25;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_30;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_35;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_40;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.HINT_USED_50;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.DAILY_CHALLENGE_BUY_GUESS;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.STRUGGLE_HINT_USED;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.SUBSCRIPTION_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.STARTERPACK_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REVENUE_IAP;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.FIRST_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REPEAT_PURCHASER;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_099;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_199;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_299;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_399;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_499;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_599;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_799;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_999;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_1199;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_1499;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_1699;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_1999;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_4999;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_9999;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_19999;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TOTAL_PURCHASE_THRESHOLD_50;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TOTAL_PURCHASE_THRESHOLD_100;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TOTAL_PURCHASE_THRESHOLD_500;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TOTAL_PURCHASE_THRESHOLD_1000;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_GEMS;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.BUNDLE_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.SOUND_ON;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.SOUND_OFF;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_FOOD;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PURCHASE_2499;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PIGGY_NONBUYER;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PIGGY_LAPSE1;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PIGGY_LAPSE2;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PIGGY_LAPSE3;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D1_SUB_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D3_SUB_PURCHASE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_SEEN_NON_REWARDED;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.FB_LOGIN;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_SEEN_ALL;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_SEEN_REW_VID;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_SEEN_INT;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_SEEN_BANNER;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_05;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_10;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_15;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_20;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_25;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_50;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_100;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_250;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.REW_VID_500;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_05;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_10;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_15;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_20;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_30;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_50;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.AD_CLICK_100;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.ADS_DISABLED_REW;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D1_AD_CLICKED_10;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D3_AD_CLICKED_10;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D1_REW_VID_05;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D3_REW_VID_05;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D1;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D2;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D3;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D6;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D7;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D30;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D2_CONSECUTIVE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D3_CONSECUTIVE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D6_CONSECUTIVE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.RETENTION_D7_CONSECUTIVE;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.PUR_RET_0101;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34.AddEvent(eventName:  Events.PUR_RET_1007, propertyName:  0);
        val_35 = "_2";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_3";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_4";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_5";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_6";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_7";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_8";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_9";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_10";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_20";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_30";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_40";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_50";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_60";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_70";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_80";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_90";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_100";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_200";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_300";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_400";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_500";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_600";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_700";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_800";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_900";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_1000";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_1250";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_1500";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        this.adjustTracking.AddEvent(eventName:  Events.LEVEL_REACHED + val_35, propertyName:  0);
        val_35 = "_2000";
        if(this.adjustTracking == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.LEVEL_REACHED + val_35;
        this.adjustTracking.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D1_LEVEL_100;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.D3_LEVEL_100;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.IQ_MILESTONE_1;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.IQ_MILESTONE_2;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.IQ_MILESTONE_3;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = this.adjustTracking;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.IQ_MILESTONE_4;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        if(App.Configuration == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = val_31.adjustConfig;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = this.adjustTracking;
        val_34.LinkTokens(tracker:  val_35);
        val_34 = this.amplitude;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.LOGIN;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Start Session";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "End Session";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TRANSACTION;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.TRANSACTION_FAILED;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Free Coins";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.OUT_OF_CREDITS;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.LEVEL_UP;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Level Complete";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Level End";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Deeplink Parsed";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Review Prompt";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Vip Points Collected";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Level Start";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Coins Spent";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Ad Display";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Ad Clicked";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Daily Challenges";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Speed Challenge End";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "Speed Challenge Start";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "GOTD Shown";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "GOTD Clicked";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = "NonCoin Award";
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.FOOD_SPENT;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = Events.CARDS_SPENT;
        val_34.AddEvent(eventName:  val_35, propertyName:  0);
        val_34 = val_34;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34.AddEvent(eventName:  "Leagues Join Reward", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Join Club", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Leave Club", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Daily Rollover", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Season Rollover", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Season Reward", propertyName:  0);
        val_34.AddEvent(eventName:  "Leagues Contribution", propertyName:  0);
        val_34.AddEvent(eventName:  "Mini Game Session", propertyName:  0);
        val_34.AddEvent(eventName:  "Golden Currency Spent", propertyName:  0);
        val_34.AddEvent(eventName:  "Gems Spent", propertyName:  0);
        val_34.AddEvent(eventName:  "TRV Level Start", propertyName:  0);
        val_34.AddEvent(eventName:  "TRV Level Complete", propertyName:  0);
        val_34.AddEvent(eventName:  "Challenge Friend", propertyName:  0);
        val_34.AddEvent(eventName:  "Challenge Friend End", propertyName:  0);
        val_34.AddEvent(eventName:  Events.SUBSCRIPTION_TRIAL_START, propertyName:  0);
        val_34.AddEvent(eventName:  "Initial Forest Entry", propertyName:  0);
        val_34.AddEvent(eventName:  "Attack Complete", propertyName:  0);
        val_34.AddEvent(eventName:  "Attacked", propertyName:  0);
        val_34.AddEvent(eventName:  "Raid Complete", propertyName:  0);
        val_34.AddEvent(eventName:  "Raided", propertyName:  0);
        val_34.AddEvent(eventName:  "Slot Game Session Complete", propertyName:  0);
        val_34.AddEvent(eventName:  "Tournament Rollover", propertyName:  0);
        val_34.AddEvent(eventName:  "Interstitial Shown", propertyName:  0);
        val_34.AddEvent(eventName:  Events.AD_REVENUE, propertyName:  0);
        List.Enumerator<T> val_32 = val_34.GetEnumerator();
        label_182:
        val_35 = public System.Boolean List.Enumerator<System.String>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_180;
        }
        
        val_34 = this.firebase;
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34.AddEvent(eventName:  0, propertyName:  0);
        goto label_182;
        label_180:
        0.Dispose();
    }
    protected virtual void initializeSpecificEvents()
    {
    
    }
    public override void onInitialServerUpdate()
    {
        var val_8;
        var val_9;
        var val_10;
        string val_11;
        var val_12;
        var val_13;
        Player val_1 = App.Player;
        if(val_1.isNew != false)
        {
                new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "Auth Method", value:  "Unity");
            new System.Collections.Generic.Dictionary<System.String, System.Object>().Add(key:  "Count", value:  "1");
            val_8 = null;
            val_8 = null;
            val_9 = null;
            val_9 = null;
            GameBehavior val_4 = App.getBehavior;
            App.trackerManager.superProperty(propertyName:  Events.CURRENT_LEVEL, propertyValue:  val_4.<metaGameBehavior>k__BackingField.ToString());
            val_10 = null;
            val_10 = null;
            val_11 = Events.CURRENT_LEVEL;
            GameBehavior val_6 = App.getBehavior;
            App.trackerManager.peopleProperty(propertyName:  val_11, propertyValue:  val_6.<metaGameBehavior>k__BackingField.ToString());
            val_12 = null;
            val_12 = null;
            App.trackerManager.flush();
            return;
        }
        
        val_13 = null;
        val_13 = null;
        App.trackerManager.clearCache();
    }
    public override void onServerUpdate()
    {
        null = null;
        App.trackerManager.flush();
    }
    public override void onApplicationPause(bool pauseStatus)
    {
        pauseStatus = pauseStatus;
        this.onApplicationPause(pauseStatus:  pauseStatus);
        if(pauseStatus == false)
        {
                return;
        }
        
        TrackingComponent.TrackSession(sessionEnded:  true, quitButton:  false);
    }
    public static void TrackSession(bool sessionEnded, bool quitButton = False)
    {
        ulong val_11;
        System.Collections.Generic.Dictionary<TKey, TValue> val_12;
        var val_13;
        string val_15;
        var val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        val_11 = sessionEnded;
        val_13 = null;
        val_13 = null;
        if(App.isQuitting == true)
        {
                return;
        }
        
        string val_1 = (val_11 != true) ? "End Session" : "Start Session";
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
        val_12 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((System.String.op_Equality(a:  val_1, b:  "End Session")) == false)
        {
            goto label_7;
        }
        
        if(quitButton == false)
        {
            goto label_8;
        }
        
        val_15 = "Quit Button";
        goto label_10;
        label_7:
        System.DateTime val_4 = System.DateTime.UtcNow;
        val_11 = val_4.dateData;
        val_16 = null;
        val_16 = null;
        TrackingComponent.started = val_11;
        return;
        label_8:
        val_15 = "Minimize App";
        label_10:
        val_2.Add(key:  val_15, value:  true);
        System.DateTime val_5 = System.DateTime.UtcNow;
        val_17 = null;
        val_17 = null;
        System.TimeSpan val_6 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_5.dateData}, d2:  new System.DateTime() {dateData = TrackingComponent.started});
        val_2.Add(key:  "Session Duration", value:  val_6._ticks.TotalSeconds.ToString(format:  "##,##0"));
        TrackingComponent.currentIntent = ;
        val_2.Add(key:  "Intent", value:  TrackingComponent.currentIntent.ToString());
        GameBehavior val_10 = App.getBehavior;
        val_18 = null;
        val_18 = null;
        App.trackerManager.track(eventName:  val_1, data:  val_2);
        TrackingComponent.lastIntent = TrackingComponent.currentIntent;
        TrackingComponent.currentIntent = 0;
        val_11 = 1152921504884695040;
        val_19 = null;
        val_19 = null;
        val_12 = true;
        DeeplinkComponent.OnDeeplinkShowScene.Consumed = true;
        val_20 = null;
        val_20 = null;
        DeeplinkComponent.OnDeeplinkShowScene.Flush();
    }
    public static void TrackLogin(string fromDeeplink = "", string notificationType = "")
    {
        string val_20;
        var val_21;
        var val_22;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        val_20 = notificationType;
        val_21 = "";
        if((System.String.IsNullOrEmpty(value:  val_20)) == false)
        {
            goto label_38;
        }
        
        if((System.String.IsNullOrEmpty(value:  fromDeeplink)) == false)
        {
            goto label_2;
        }
        
        if((System.String.IsNullOrEmpty(value:  DeeplinkPlugin.GetMoreGamesReferal())) == false)
        {
            goto label_3;
        }
        
        val_20 = val_21;
        goto label_38;
        label_2:
        val_20 = fromDeeplink;
        label_38:
        val_22 = null;
        val_22 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_5 = null;
        val_23 = val_5;
        val_5 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.DateTime val_6 = System.DateTime.Now;
        val_5.Add(key:  "local_time", value:  val_6.dateData.ToString());
        val_5.Add(key:  "login_trigger", value:  3.ToString());
        val_5.Add(key:  "login_trigger_value", value:  val_20);
        val_24 = null;
        val_24 = null;
        val_5.Add(key:  "Time Started", value:  ToString());
        App.trackerManager.track(eventName:  "Start Session", data:  val_5);
        if(16843334 == 2)
        {
                val_25 = null;
            val_25 = null;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_11 = null;
            val_23 = val_11;
            val_11 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_11.Add(key:  "Count", value:  1);
            App.trackerManager.track(eventName:  "Notification Opened " + val_20, data:  val_11);
        }
        
        val_26 = null;
        val_26 = null;
        DeeplinkComponent.OnDeeplinkShowScene.Flush();
        System.DateTime val_12 = System.DateTime.UtcNow;
        val_27 = null;
        val_27 = null;
        TrackingComponent.started = val_12.dateData;
        return;
        label_3:
        string val_13 = DeeplinkPlugin.GetMoreGamesReferal();
        if((val_13.Contains(value:  "networkbonus")) != false)
        {
                string val_20 = "networkbonus";
            val_20 = (val_13.IndexOf(value:  val_20)) + 12;
            val_21 = val_13.Substring(startIndex:  val_20);
        }
        
        if((val_13.Contains(value:  "gameoftheweek")) == false)
        {
            goto label_38;
        }
        
        string val_21 = "gameoftheweek";
        val_21 = (val_13.LastIndexOf(value:  val_21)) + 13;
        string val_19 = val_13.Substring(startIndex:  val_21);
        goto label_38;
    }
    public static TrackingComponent.AppPauseIntent get_CurrentIntent()
    {
        null = null;
        return (AppPauseIntent)TrackingComponent.currentIntent;
    }
    public static void set_CurrentIntent(TrackingComponent.AppPauseIntent value)
    {
        null = null;
        TrackingComponent.lastIntent = value;
        TrackingComponent.currentIntent = value;
    }
    public static TrackingComponent.AppPauseIntent get_LastIntent()
    {
        null = null;
        return (AppPauseIntent)TrackingComponent.lastIntent;
    }
    private static TrackingComponent()
    {
        TrackingComponent.hasFinishedInitializing = false;
        TrackingComponent.finishedInitializingCallback = 0;
        System.DateTime val_1 = System.DateTime.UtcNow;
        TrackingComponent.started = val_1.dateData;
        TrackingComponent.currentIntent = 0;
        TrackingComponent.lastIntent = 0;
    }

}

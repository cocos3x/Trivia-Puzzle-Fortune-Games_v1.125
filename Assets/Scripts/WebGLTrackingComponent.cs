using UnityEngine;
public class WebGLTrackingComponent : AppComponent
{
    // Fields
    private string _gameObjectName;
    protected AmplitudePlugin amplitude;
    protected WebGLFacebookTracker facebook;
    private static System.DateTime started;
    
    // Properties
    public override bool RunInMainThread { get; }
    
    // Methods
    public override bool get_RunInMainThread()
    {
        return true;
    }
    public WebGLTrackingComponent(string gameName, string gameObjectName)
    {
        this._gameObjectName = gameObjectName;
        mem[1152921515598946144] = "TrackingComponent";
    }
    public override void initializeOnMainThread()
    {
        var val_1;
        this.initializeTrackers();
        this.initializeGeneralEvents();
        this.addTrackers();
        val_1 = null;
        val_1 = null;
        App.trackerManager.track(eventName:  Events.APP_LAUNCHED);
        WebGLTrackingComponent.TrackSession(sessionEnded:  false, forceShutdown:  false);
        this.TrackLogin(fromPause:  false, hasReward:  false);
    }
    private void initializeTrackers()
    {
        this.amplitude = new AmplitudePlugin();
        .initialized = true;
        this.facebook = new WebGLFacebookTracker();
    }
    private void addTrackers()
    {
        var val_1;
        var val_2;
        val_1 = null;
        val_1 = null;
        App.trackerManager.addTracker(t:  this.amplitude);
        val_2 = null;
        val_2 = null;
        App.trackerManager.addTracker(t:  this.facebook);
    }
    private void initializeGeneralEvents()
    {
        this.amplitude.AddEvent(eventName:  Events.LOGIN, propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Start Session", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "End Session", propertyName:  0);
        this.amplitude.AddEvent(eventName:  Events.TRANSACTION, propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Free Coins", propertyName:  0);
        this.amplitude.AddEvent(eventName:  Events.OUT_OF_CREDITS, propertyName:  0);
        this.amplitude.AddEvent(eventName:  Events.LEVEL_UP, propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Level Start", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Coins Spent", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Level Complete", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Level End", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Deeplink Parsed", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Lucky Day", propertyName:  0);
        this.amplitude.AddEvent(eventName:  "Daily Challenges", propertyName:  0);
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
        var val_2;
        pauseStatus = pauseStatus;
        this.onApplicationPause(pauseStatus:  pauseStatus);
        if(pauseStatus != false)
        {
                WebGLTrackingComponent.TrackSession(sessionEnded:  pauseStatus, forceShutdown:  false);
            return;
        }
        
        this.TrackLogin(fromPause:  false, hasReward:  false);
        val_2 = null;
        val_2 = null;
        App.trackerManager.flush();
    }
    public static void TrackSession(bool sessionEnded, bool forceShutdown = False)
    {
        var val_9;
        string val_10;
        var val_11;
        var val_12;
        var val_13;
        val_9 = "End Session";
        val_10 = mem[sessionEnded != true ? val_9 : "Start Session"];
        val_10 = (sessionEnded != true) ? (val_9) : "Start Session";
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((System.String.op_Equality(a:  val_10, b:  "End Session")) != false)
        {
                val_2.Add(key:  "Minimize App", value:  true);
            System.DateTime val_4 = System.DateTime.UtcNow;
            val_11 = null;
            val_11 = null;
            System.TimeSpan val_5 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_4.dateData}, d2:  new System.DateTime() {dateData = WebGLTrackingComponent.started});
            val_2.Add(key:  "Session Duration", value:  val_5._ticks.TotalSeconds.ToString(format:  "##,##0"));
            val_9 = 1152921504884269056;
            val_12 = null;
            val_12 = null;
            App.trackerManager.track(eventName:  val_10, data:  val_2);
            return;
        }
        
        System.DateTime val_8 = System.DateTime.UtcNow;
        val_10 = val_8.dateData;
        val_13 = null;
        val_13 = null;
        WebGLTrackingComponent.started = val_10;
    }
    protected void TrackLogin(bool fromPause = False, bool hasReward = False)
    {
        var val_8;
        var val_9;
        var val_10;
        var val_1 = (hasReward != true) ? 3 : (0 + 1);
        val_8 = null;
        val_8 = null;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        System.DateTime val_3 = System.DateTime.Now;
        val_2.Add(key:  "local_time", value:  val_3.dateData.ToString());
        val_2.Add(key:  "login_trigger", value:  val_1.ToString());
        if(val_1 == 3)
        {
                val_9 = "Currency_Reward";
        }
        
        val_2.Add(key:  "login_trigger_value", value:  System.String.__il2cppRuntimeField_static_fields);
        val_10 = null;
        val_10 = null;
        val_2.Add(key:  "Time Started", value:  ToString());
        val_2.Add(key:  "login_referal", value:  System.String.alignConst);
        App.trackerManager.track(eventName:  "Start Session", data:  val_2);
        System.DateTime val_7 = System.DateTime.UtcNow;
        WebGLTrackingComponent.started = val_7.dateData;
    }
    protected WebGLTrackingComponent.AppLaunchTriggers ChooseTrigger(bool hasReward = False)
    {
        return (AppLaunchTriggers)(hasReward != true) ? 3 : (0 + 1);
    }
    protected string ChooseTriggerValue(WebGLTrackingComponent.AppLaunchTriggers trigger = 1)
    {
        var val_1;
        if(trigger != 3)
        {
                return (string)System.String.__il2cppRuntimeField_static_fields;
        }
        
        val_1 = "Currency_Reward";
        return (string)System.String.__il2cppRuntimeField_static_fields;
    }
    protected string ChooseReferal()
    {
        return (string)System.String.alignConst;
    }
    private static WebGLTrackingComponent()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        WebGLTrackingComponent.started = val_1.dateData;
    }

}

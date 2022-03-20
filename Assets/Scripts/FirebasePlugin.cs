using UnityEngine;
public class FirebasePlugin : Tracker, PluginObserver
{
    // Fields
    private bool initialized;
    private Firebase.FirebaseApp app;
    
    // Methods
    private void InitializeFirebaseAndStart()
    {
        if(this.initialized != false)
        {
                return;
        }
        
        System.Threading.Tasks.Task val_3 = Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction:  new System.Action<System.Threading.Tasks.Task<Firebase.DependencyStatus>>(object:  this, method:  System.Void FirebasePlugin::<InitializeFirebaseAndStart>b__2_0(System.Threading.Tasks.Task<Firebase.DependencyStatus> task)));
    }
    public PluginObserverManager.ObserverType getType()
    {
        return 0;
    }
    public string pluginName()
    {
        return "Firebase";
    }
    public bool isWorking()
    {
        return (bool)this;
    }
    public bool isInitialized()
    {
        return (bool)this.initialized;
    }
    public string errorMessage()
    {
        if(this.initialized == false)
        {
                return "Not initialized!";
        }
        
        return "Plugin initialized. " + (this.initialized == false) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. "((this.initialized == false) ? "Event Tracking is not being used. " : "Event Tracking is working correctly. ");
    }
    public FirebasePlugin()
    {
        if(this.initialized != false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<PluginObserverManager>.Instance.AddObserver(observer:  this);
        this.InitializeFirebaseAndStart();
    }
    public override void trackEvent(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        goto typeof(FirebasePlugin).__il2cppRuntimeField_190;
    }
    public override void trackEvent(string eventName, string propertyName, string propertyValue)
    {
        if(this.initialized == false)
        {
                return;
        }
        
        Firebase.Analytics.FirebaseAnalytics.LogEvent(name:  eventName.ToLower().Replace(oldValue:  " ", newValue:  "_"));
    }
    public override void identify(string id)
    {
    
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
    public override void trackCharge(string quantity, System.Collections.Generic.Dictionary<string, object> data)
    {
    
    }
    private void <InitializeFirebaseAndStart>b__2_0(System.Threading.Tasks.Task<Firebase.DependencyStatus> task)
    {
        Firebase.DependencyStatus val_1 = task.Result;
        if(val_1 != 0)
        {
                UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Could not resolve all Firebase dependencies: {0}", arg0:  val_1));
            return;
        }
        
        this.app = Firebase.FirebaseApp.DefaultInstance;
        this.initialized = true;
        UnityEngine.Debug.Log(message:  "FirebasePlugin : Plugin is initialized");
    }

}

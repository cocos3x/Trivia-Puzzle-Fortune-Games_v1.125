using UnityEngine;
public class ErrorReporter : MonoSingleton<ErrorReporter>
{
    // Fields
    private int totalMaximumErrors;
    public bool enableMockErrors;
    private System.Collections.Generic.Dictionary<string, object> errorJsonObject;
    private int currentError;
    private int frameSkipper;
    private int currentFrame;
    private int timesSent;
    private int maxSent;
    private int hasResumed;
    private bool sending;
    private static string lastError;
    private static string lastStackTrace;
    public static bool IgnoreMaxSent;
    private string color;
    
    // Properties
    public static string LastError { get; }
    public static string LastStackTrace { get; }
    
    // Methods
    public static string get_LastError()
    {
        null = null;
        return (string)ErrorReporter.lastError;
    }
    public static string get_LastStackTrace()
    {
        null = null;
        return (string)ErrorReporter.lastStackTrace;
    }
    private void OnEnable()
    {
        UnityEngine.Application.add_logMessageReceived(value:  new Application.LogCallback(object:  this, method:  System.Void ErrorReporter::HandleLog(string logString, string stackTrace, UnityEngine.LogType logType)));
        this.FlushErrorDefinition();
    }
    private void OnDisable()
    {
        if((MonoSingleton<ErrorReporter>.Instance) != this)
        {
                return;
        }
        
        UnityEngine.Application.remove_logMessageReceived(value:  new Application.LogCallback(object:  this, method:  System.Void ErrorReporter::HandleLog(string logString, string stackTrace, UnityEngine.LogType logType)));
    }
    private void Update()
    {
        int val_8 = this.currentFrame;
        val_8 = val_8 + 1;
        this.currentFrame = val_8;
        if(this.enableMockErrors == false)
        {
            goto label_8;
        }
        
        var val_9 = 0;
        val_9 = val_9 + val_8;
        val_9 = (val_9 >> 7) + (val_9 >> 31);
        val_8 = val_8 - (val_9 * 180);
        if((val_8 != 0) || (((UnityEngine.Random.Range(min:  1, max:  5)) - 1) > 3))
        {
            goto label_8;
        }
        
        var val_10 = 32561264 + ((val_2 - 1)) << 2;
        val_10 = val_10 + 32561264;
        goto (32561264 + ((val_2 - 1)) << 2 + 32561264);
        label_8:
        if(this.currentFrame < 201)
        {
                return;
        }
        
        this.currentFrame = 0;
    }
    private void HandleLog(string logString, string stackTrace, UnityEngine.LogType logType)
    {
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_18;
        string val_19;
        var val_20;
        var val_21;
        var val_22;
        val_19 = logString;
        if((logType | 4) != 4)
        {
                return;
        }
        
        if((this.OldError(logString:  val_19, stackTrace:  stackTrace)) == true)
        {
                return;
        }
        
        val_20 = null;
        val_20 = null;
        if(ErrorReporter.IgnoreMaxSent != true)
        {
                if(this.timesSent >= this.maxSent)
        {
                return;
        }
        
        }
        
        int val_18 = this.currentError;
        val_18 = val_18 + 1;
        this.currentError = val_18;
        if(val_18 > this.totalMaximumErrors)
        {
                this.enabled = false;
            return;
        }
        
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Handheld.Vibrate();
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  "unity_crashed", value:  1);
        System.Collections.Generic.Dictionary<System.String, System.String> val_5 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        val_19 = DeviceIdPlugin.GetClientVersion() + "_[Engine 1.1]" + val_19;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_19 = "[DEV]" + val_19;
        }
        
        val_5.Add(key:  "exception", value:  val_19);
        val_5.Add(key:  "stack", value:  stackTrace);
        val_5.Add(key:  "scene", value:  UnityEngine.Application.loadedLevelName + "");
        val_5.Add(key:  "game_state", value:  "");
        val_5.Add(key:  "time", value:  UnityEngine.Time.timeSinceLevelLoad.ToString());
        val_5.Add(key:  "resumed", value:  this.hasResumed.ToString());
        val_21 = null;
        val_21 = null;
        ErrorReporter.lastError = val_19;
        ErrorReporter.lastStackTrace = stackTrace;
        this.errorJsonObject.Item["errorLog"].Add(item:  val_5);
        val_22 = null;
        val_22 = null;
        System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_17 = null;
        val_18 = val_17;
        val_17 = new System.Action<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void ErrorReporter::onCompleteFunction(string request, System.Collections.Generic.Dictionary<string, object> returnData));
        App.networkManager.DoPost(path:  "/api/errors", postBody:  this.errorJsonObject, onCompleteFunction:  val_17, timeout:  20, destroy:  true, immediate:  false, serverType:  0);
        int val_19 = this.timesSent;
        this.currentError = 0;
        val_19 = val_19 + 1;
        this.currentFrame = 0;
        this.timesSent = val_19;
        SLCDebug.Log(logMessage:  val_19, colorHash:  "#FF0000", isError:  true);
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        this.hasResumed = 1;
    }
    private bool OldError(string logString, string stackTrace)
    {
        var val_5;
        var val_6;
        var val_12;
        var val_14;
        val_12 = stackTrace;
        char[] val_1 = new char[1];
        val_1[0] = '
        ';
        List.Enumerator<T> val_4 = this.errorJsonObject.Item["errorLog"].GetEnumerator();
        label_15:
        if(val_6.MoveNext() == false)
        {
            goto label_10;
        }
        
        val_12 = val_5;
        if(val_12 == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_8 = val_12.Item["exception"];
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_8.IndexOf(value:  logString)) & 2147483648) != 0)
        {
            goto label_15;
        }
        
        string val_10 = val_12.Item["stack"];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_10.IndexOf(value:  val_12.Split(separator:  val_1)[0])) & 2147483648) != 0)
        {
            goto label_15;
        }
        
        val_14 = 1;
        goto label_16;
        label_10:
        val_14 = 0;
        label_16:
        val_6.Dispose();
        return (bool)val_14;
    }
    private void onCompleteFunction(string request, System.Collections.Generic.Dictionary<string, object> returnData)
    {
        this.FlushErrorDefinition();
        this.sending = false;
    }
    private bool ReachedMaximumErrors()
    {
        var val_6;
        if(this.errorJsonObject != null)
        {
                if((this.errorJsonObject.ContainsKey(key:  "errorLog")) != false)
        {
                var val_5 = (this.errorJsonObject.Item["errorLog"].Keys.Count == this.totalMaximumErrors) ? 1 : 0;
            return (bool)val_6;
        }
        
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    private void FlushErrorDefinition()
    {
        var val_13;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        this.errorJsonObject = val_1;
        val_1.Add(key:  "errorLog", value:  new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.String>>());
        this.errorJsonObject.Add(key:  "deviceId", value:  DeviceIdPlugin.GetDeviceId());
        this.errorJsonObject.Add(key:  "clientVersion", value:  DeviceIdPlugin.GetClientVersion());
        this.errorJsonObject.Add(key:  "macAddress", value:  DeviceIdPlugin.GetMacAddress());
        this.errorJsonObject.Add(key:  "platform", value:  "android");
        this.errorJsonObject.Add(key:  "version", value:  "free");
        GameBehavior val_6 = App.getBehavior;
        if((val_6.<metaGameBehavior>k__BackingField.GetCurrentLanguage()) != null)
        {
                GameBehavior val_8 = App.getBehavior;
            this.errorJsonObject.Add(key:  "language", value:  val_8.<metaGameBehavior>k__BackingField.GetCurrentLanguage());
        }
        
        val_13 = null;
        val_13 = null;
        if(App.storageManager != null)
        {
                if(App.Player != 0)
        {
                Player val_12 = App.Player;
            this.errorJsonObject.Add(key:  "user_id", value:  val_12.id);
        }
        
        }
        
        this.currentError = 0;
    }
    private string GetPlatform()
    {
        return "android";
    }
    private string GetVersion()
    {
        return "free";
    }
    public ErrorReporter()
    {
        this.totalMaximumErrors = 7;
        this.frameSkipper = 60;
        this.maxSent = 5;
        this.color = "[#ffffff]";
    }
    private static ErrorReporter()
    {
        ErrorReporter.lastError = "";
        ErrorReporter.lastStackTrace = "";
        ErrorReporter.IgnoreMaxSent = false;
    }

}

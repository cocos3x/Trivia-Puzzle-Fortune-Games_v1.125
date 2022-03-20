using UnityEngine;
public class Amplitude
{
    // Fields
    private static readonly string UnityLibraryName;
    private static readonly string UnityLibraryVersion;
    private static System.Collections.Generic.Dictionary<string, Amplitude> instances;
    private static readonly object instanceLock;
    private static readonly string androidPluginName;
    private UnityEngine.AndroidJavaClass pluginClass;
    public bool logging;
    private string instanceName;
    
    // Properties
    public static Amplitude Instance { get; }
    
    // Methods
    public static Amplitude getInstance()
    {
        return Amplitude.getInstance(instanceName:  0);
    }
    public static Amplitude getInstance(string instanceName)
    {
        var val_8;
        var val_9;
        var val_10;
        System.Collections.Generic.Dictionary<TKey, TValue> val_11;
        var val_12;
        val_8 = null;
        string val_2 = ((System.String.IsNullOrEmpty(value:  instanceName)) != true) ? "$default_instance" : instanceName;
        val_8 = null;
        bool val_3 = false;
        System.Threading.Monitor.Enter(obj:  Amplitude.instanceLock, lockTaken: ref  val_3);
        val_10 = null;
        val_10 = null;
        if(Amplitude.instances == null)
        {
                System.Collections.Generic.Dictionary<System.String, Amplitude> val_4 = null;
            val_9 = public System.Void System.Collections.Generic.Dictionary<System.String, Amplitude>::.ctor();
            val_4 = new System.Collections.Generic.Dictionary<System.String, Amplitude>();
            val_10 = null;
            val_10 = null;
            Amplitude.instances = val_4;
        }
        
        val_10 = null;
        val_11 = Amplitude.instances;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_4.TryGetValue(key:  val_2, value: out  0)) != true)
        {
                Amplitude val_7 = new Amplitude(instanceName:  instanceName);
            val_12 = null;
            val_12 = null;
            val_4.Add(key:  val_2, value:  val_7);
        }
        
        if(val_3 != 0)
        {
                System.Threading.Monitor.Exit(obj:  Amplitude.instanceLock);
        }
        
        if(0 == 0)
        {
                return val_7;
        }
        
        val_11 = 0;
        val_9 = 0;
        throw val_11;
    }
    public static Amplitude get_Instance()
    {
        return Amplitude.getInstance();
    }
    public Amplitude(string instanceName)
    {
        var val_3;
        var val_4;
        this.instanceName = instanceName;
        if(UnityEngine.Application.platform == 11)
        {
                UnityEngine.Debug.Log(message:  "construct instance");
            val_3 = null;
            val_3 = null;
            this.pluginClass = new UnityEngine.AndroidJavaClass(className:  Amplitude.androidPluginName);
        }
        
        val_4 = null;
        val_4 = null;
        this.setLibraryName(libraryName:  Amplitude.UnityLibraryName);
        this.setLibraryVersion(libraryVersion:  Amplitude.UnityLibraryVersion);
    }
    protected void Log(string message)
    {
        if(this.logging == false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  message);
    }
    protected void Log<T>(string message, string property, System.Collections.Generic.IEnumerable<T> array)
    {
        var val_5;
        int val_6;
        var val_7;
        val_5 = 4;
        object[] val_1 = new object[4];
        val_6 = val_1.Length;
        val_1[0] = message;
        if(property != null)
        {
                val_6 = val_1.Length;
        }
        
        val_1[1] = property;
        if(array != null)
        {
                val_6 = val_1.Length;
        }
        
        val_1[2] = array;
        val_7 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
        val_1[3] = System.String.Join(separator:  ", ", value:  array.Split(separator:  public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 184));
        this.Log(message:  System.String.Format(format:  "{0} {1}, {2}: [{3}]", args:  val_1));
    }
    public void init(string apiKey)
    {
        var val_11;
        object val_12;
        var val_13;
        var val_14;
        object val_15;
        var val_16;
        int val_17;
        int val_18;
        val_12 = apiKey;
        val_13 = this;
        this.Log(message:  System.String.Format(format:  "C# init {0}", arg0:  val_12));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        UnityEngine.AndroidJavaClass val_3 = null;
        val_11 = val_3;
        val_3 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer");
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.AndroidJavaObject val_4 = val_3.GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
        val_14 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_14 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_14 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_14 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_15 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_15 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_4.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplication", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        object[] val_6 = new object[3];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.instanceName != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_6.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[0] = this.instanceName;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_17 = val_6.Length;
        if(val_17 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[1] = val_4;
        if(val_12 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_17 = val_6.Length;
        }
        
        if(val_17 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[2] = val_12;
        if(this.pluginClass == null)
        {
                throw new NullReferenceException();
        }
        
        this.pluginClass.CallStatic(methodName:  "init", args:  val_6);
        val_12 = this.pluginClass;
        object[] val_7 = new object[2];
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.instanceName != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_18 = val_7.Length;
        if(val_18 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[0] = this.instanceName;
        if(val_15 != null)
        {
                val_18 = val_7.Length;
        }
        
        val_7[1] = val_15;
        val_12.CallStatic(methodName:  "enableForegroundTracking", args:  val_7);
        val_13 = 0;
        if(val_15 != null)
        {
                var val_11 = 0;
            val_11 = val_11 + 1;
            val_15.Dispose();
        }
        
        if(val_13 == 0)
        {
                val_15 = 0;
            if(val_4 != null)
        {
                var val_12 = 0;
            val_12 = val_12 + 1;
            val_4.Dispose();
        }
        
            if(val_15 != 0)
        {
                throw X21;
        }
        
            if(val_11 != null)
        {
                var val_13 = 0;
            val_13 = val_13 + 1;
            val_3.Dispose();
        }
        
            if(0 != 0)
        {
                throw X20;
        }
        
            return;
        }
        
        val_16 = val_13;
        throw val_16;
    }
    public void init(string apiKey, string userId)
    {
        var val_11;
        object val_12;
        var val_13;
        var val_14;
        object val_15;
        var val_16;
        int val_17;
        int val_18;
        val_12 = userId;
        val_13 = this;
        this.Log(message:  System.String.Format(format:  "C# init {0} with userId {1}", arg0:  apiKey, arg1:  val_12));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        UnityEngine.AndroidJavaClass val_3 = null;
        val_11 = val_3;
        val_3 = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer");
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.AndroidJavaObject val_4 = val_3.GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
        val_14 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_14 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_14 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_14 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_15 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_15 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = val_4.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplication", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        object[] val_6 = new object[4];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.instanceName != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_6.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[0] = this.instanceName;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_17 = val_6.Length;
        if(val_17 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[1] = val_4;
        if(apiKey != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_17 = val_6.Length;
        }
        
        if(val_17 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[2] = apiKey;
        if(val_12 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_17 = val_6.Length;
        }
        
        if(val_17 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[3] = val_12;
        if(this.pluginClass == null)
        {
                throw new NullReferenceException();
        }
        
        this.pluginClass.CallStatic(methodName:  "init", args:  val_6);
        val_12 = this.pluginClass;
        object[] val_7 = new object[2];
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.instanceName != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_18 = val_7.Length;
        if(val_18 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[0] = this.instanceName;
        if(val_15 != null)
        {
                val_18 = val_7.Length;
        }
        
        val_7[1] = val_15;
        val_12.CallStatic(methodName:  "enableForegroundTracking", args:  val_7);
        val_13 = 0;
        if(val_15 != null)
        {
                var val_11 = 0;
            val_11 = val_11 + 1;
            val_15.Dispose();
        }
        
        if(val_13 == 0)
        {
                val_15 = 0;
            if(val_4 != null)
        {
                var val_12 = 0;
            val_12 = val_12 + 1;
            val_4.Dispose();
        }
        
            if(val_15 != 0)
        {
                throw X21;
        }
        
            if(val_11 != null)
        {
                var val_13 = 0;
            val_13 = val_13 + 1;
            val_3.Dispose();
        }
        
            if(0 != 0)
        {
                throw X20;
        }
        
            return;
        }
        
        val_16 = val_13;
        throw val_16;
    }
    public void setTrackingOptions(System.Collections.Generic.IDictionary<string, bool> trackingOptions)
    {
        object val_5;
        int val_6;
        val_5 = trackingOptions;
        if(val_5 == null)
        {
                return;
        }
        
        val_5 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_5);
        this.Log(message:  System.String.Format(format:  "C# setting tracking options {0}", arg0:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[2];
        val_6 = val_4.Length;
        val_4[0] = this.instanceName;
        if(val_5 != null)
        {
                val_6 = val_4.Length;
        }
        
        val_4[1] = val_5;
        this.pluginClass.CallStatic(methodName:  "setTrackingOptions", args:  val_4);
    }
    public void logEvent(string evt)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# sendEvent {0}", arg0:  evt));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(evt != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = evt;
        this.pluginClass.CallStatic(methodName:  "logEvent", args:  val_3);
    }
    public void logEvent(string evt, System.Collections.Generic.IDictionary<string, object> properties)
    {
        object val_6;
        int val_7;
        val_6 = properties;
        if(val_6 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        this.Log(message:  System.String.Format(format:  "C# sendEvent {0} with properties {1}", arg0:  evt, arg1:  val_2));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_5 = new object[3];
        val_7 = val_5.Length;
        val_5[0] = this.instanceName;
        if(evt != null)
        {
                val_7 = val_5.Length;
        }
        
        val_5[1] = evt;
        if(val_2 != null)
        {
                val_7 = val_5.Length;
        }
        
        val_5[2] = val_2;
        this.pluginClass.CallStatic(methodName:  "logEvent", args:  val_5);
    }
    public void logEvent(string evt, System.Collections.Generic.IDictionary<string, object> properties, bool outOfSession)
    {
        UnityEngine.AndroidJavaClass val_7;
        object val_8;
        object val_9;
        string val_10;
        int val_11;
        val_8 = properties;
        val_9 = evt;
        val_10 = this;
        bool val_1 = outOfSession;
        if(val_8 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = null;
            val_8 = val_2;
            val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        string val_3 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_2);
        this.Log(message:  System.String.Format(format:  "C# sendEvent {0} with properties {1} and outOfSession {2}", arg0:  val_9, arg1:  val_3, arg2:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_7 = this.pluginClass;
        object[] val_6 = new object[4];
        val_10 = this.instanceName;
        val_11 = val_6.Length;
        val_6[0] = val_10;
        if(val_9 != null)
        {
                val_11 = val_6.Length;
        }
        
        val_6[1] = val_9;
        if(val_3 != null)
        {
                val_11 = val_6.Length;
        }
        
        val_6[2] = val_3;
        val_9 = val_1;
        val_6[3] = val_9;
        val_7.CallStatic(methodName:  "logEvent", args:  val_6);
    }
    public void setOffline(bool offline)
    {
        UnityEngine.AndroidJavaClass val_5;
        bool val_1 = offline;
        this.Log(message:  System.String.Format(format:  "C# setOffline {0}", arg0:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_5 = this.pluginClass;
        object[] val_4 = new object[2];
        val_4[0] = this.instanceName;
        val_4[1] = val_1;
        val_5.CallStatic(methodName:  "setOffline", args:  val_4);
    }
    public void setUserId(string userId)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setUserId {0}", arg0:  userId));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(userId != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = userId;
        this.pluginClass.CallStatic(methodName:  "setUserId", args:  val_3);
    }
    public void setUserProperties(System.Collections.Generic.IDictionary<string, object> properties)
    {
        object val_6;
        int val_7;
        val_6 = properties;
        if(val_6 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        this.Log(message:  System.String.Format(format:  "C# setUserProperties {0}", arg0:  val_2));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_5 = new object[2];
        val_7 = val_5.Length;
        val_5[0] = this.instanceName;
        if(val_2 != null)
        {
                val_7 = val_5.Length;
        }
        
        val_5[1] = val_2;
        this.pluginClass.CallStatic(methodName:  "setUserProperties", args:  val_5);
    }
    public void setOptOut(bool enabled)
    {
        UnityEngine.AndroidJavaClass val_5;
        bool val_1 = enabled;
        this.Log(message:  System.String.Format(format:  "C# setOptOut {0}", arg0:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_5 = this.pluginClass;
        object[] val_4 = new object[2];
        val_4[0] = this.instanceName;
        val_4[1] = val_1;
        val_5.CallStatic(methodName:  "setOptOut", args:  val_4);
    }
    public void setMinTimeBetweenSessionsMillis(long minTimeBetweenSessionsMillis)
    {
        long val_4 = minTimeBetweenSessionsMillis;
        this.Log(message:  System.String.Format(format:  "C# minTimeBetweenSessionsMillis {0}", arg0:  val_4 = minTimeBetweenSessionsMillis));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_3[0] = this.instanceName;
        val_4 = val_4;
        val_3[1] = val_4;
        this.pluginClass.CallStatic(methodName:  "setMinTimeBetweenSessionsMillis", args:  val_3);
    }
    public void setDeviceId(string deviceId)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setDeviceId {0}", arg0:  deviceId));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(deviceId != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = deviceId;
        this.pluginClass.CallStatic(methodName:  "setDeviceId", args:  val_3);
    }
    public void enableCoppaControl()
    {
        this.Log(message:  "C# enableCoppaControl");
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "enableCoppaControl", args:  val_2);
    }
    public void disableCoppaControl()
    {
        var val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.Log(message:  System.String.Format(format:  "C# disableCoppaControl", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[1];
        val_3[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "disableCoppaControl", args:  val_3);
    }
    public void setServerUrl(string serverUrl)
    {
        var val_4;
        int val_5;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.Log(message:  System.String.Format(format:  "C# setServerUrl", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(serverUrl != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = serverUrl;
        this.pluginClass.CallStatic(methodName:  "setServerUrl", args:  val_3);
    }
    public void setGlobalUserProperties(System.Collections.Generic.IDictionary<string, object> properties)
    {
        this.setUserProperties(properties:  properties);
    }
    public void logRevenue(double amount)
    {
        UnityEngine.AndroidJavaClass val_4;
        this.Log(message:  System.String.Format(format:  "C# logRevenue {0}", arg0:  amount));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[2];
        val_3[0] = this.instanceName;
        this = amount;
        val_3[1] = this;
        val_4.CallStatic(methodName:  "logRevenue", args:  val_3);
    }
    public void logRevenue(string productId, int quantity, double price)
    {
        string val_4;
        object val_5;
        int val_6;
        val_4 = this;
        val_5 = quantity;
        this.Log(message:  System.String.Format(format:  "C# logRevenue {0}, {1}, {2}", arg0:  productId, arg1:  quantity, arg2:  price));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_5 = this.pluginClass;
        object[] val_3 = new object[4];
        val_4 = this.instanceName;
        val_6 = val_3.Length;
        val_3[0] = val_4;
        if(productId != null)
        {
                val_6 = val_3.Length;
        }
        
        val_3[1] = productId;
        val_3[2] = quantity;
        val_3[3] = price;
        val_5.CallStatic(methodName:  "logRevenue", args:  val_3);
    }
    public void logRevenue(string productId, int quantity, double price, string receipt, string receiptSignature)
    {
        int val_4;
        string val_5;
        object val_6;
        int val_7;
        int val_8;
        val_4 = quantity;
        val_5 = this;
        val_6 = val_4;
        this.Log(message:  System.String.Format(format:  "C# logRevenue {0}, {1}, {2} (with receipt)", arg0:  productId, arg1:  val_4, arg2:  price));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_6 = this.pluginClass;
        object[] val_3 = new object[6];
        val_5 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_5;
        if(productId != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = productId;
        val_3[2] = val_4;
        val_4 = price;
        val_8 = val_3.Length;
        val_3[3] = val_4;
        if(receipt != null)
        {
                val_8 = val_3.Length;
        }
        
        val_3[4] = receipt;
        if(receiptSignature != null)
        {
                val_8 = val_3.Length;
        }
        
        val_3[5] = receiptSignature;
        val_6.CallStatic(methodName:  "logRevenue", args:  val_3);
    }
    public void logRevenue(string productId, int quantity, double price, string receipt, string receiptSignature, string revenueType, System.Collections.Generic.IDictionary<string, object> eventProperties)
    {
        object val_7;
        int val_8;
        string val_9;
        string val_10;
        object val_11;
        int val_12;
        int val_13;
        int val_14;
        val_7 = eventProperties;
        val_8 = quantity;
        val_9 = this;
        if(val_7 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_7 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        object[] val_3 = new object[5];
        val_3[0] = productId;
        val_3[1] = val_8;
        val_10 = 1152921504617336832;
        val_11 = price;
        val_12 = val_3.Length;
        val_3[2] = val_11;
        if(revenueType != null)
        {
                val_12 = val_3.Length;
        }
        
        val_3[3] = revenueType;
        if(val_2 != null)
        {
                val_12 = val_3.Length;
        }
        
        val_3[4] = val_2;
        this.Log(message:  System.String.Format(format:  "C# logRevenue {0}, {1}, {2}, {3}, {4} (with receipt)", args:  val_3));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_6 = new object[8];
        val_9 = this.instanceName;
        val_11 = val_6;
        val_13 = val_6.Length;
        val_11[0] = val_9;
        if(productId != null)
        {
                val_13 = val_6.Length;
        }
        
        val_11[1] = productId;
        val_11[2] = val_8;
        val_8 = price;
        val_14 = val_6.Length;
        val_11[3] = val_8;
        if(receipt != null)
        {
                val_14 = val_6.Length;
        }
        
        val_10 = receiptSignature;
        val_11[4] = receipt;
        if(val_10 != 0)
        {
                val_14 = val_6.Length;
        }
        
        val_11[5] = val_10;
        if(revenueType != null)
        {
                val_14 = val_6.Length;
        }
        
        val_11[6] = revenueType;
        if(val_2 != null)
        {
                val_14 = val_6.Length;
        }
        
        val_11[7] = val_2;
        this.pluginClass.CallStatic(methodName:  "logRevenue", args:  val_6);
    }
    public string getDeviceId()
    {
        UnityEngine.AndroidJavaClass val_4;
        var val_5 = 0;
        if(UnityEngine.Application.platform != 11)
        {
                return (string)val_4.CallStatic<System.String>(methodName:  "getDeviceId", args:  object[] val_2 = new object[1]);
        }
        
        val_4 = this.pluginClass;
        val_2[0] = this.instanceName;
        return (string)val_4.CallStatic<System.String>(methodName:  "getDeviceId", args:  val_2);
    }
    public void regenerateDeviceId()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "regenerateDeviceId", args:  val_2);
    }
    public void useAdvertisingIdForDeviceId()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "useAdvertisingIdForDeviceId", args:  val_2);
    }
    public void trackSessionEvents(bool enabled)
    {
        UnityEngine.AndroidJavaClass val_5;
        bool val_1 = enabled;
        this.Log(message:  System.String.Format(format:  "C# trackSessionEvents {0}", arg0:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_5 = this.pluginClass;
        object[] val_4 = new object[2];
        val_4[0] = this.instanceName;
        val_4[1] = val_1;
        val_5.CallStatic(methodName:  "trackSessionEvents", args:  val_4);
    }
    public long getSessionId()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return 0;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = this.instanceName;
        return this.pluginClass.CallStatic<System.Int64>(methodName:  "getSessionId", args:  val_2);
    }
    public void uploadEvents()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[1];
        val_2[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "uploadEvents", args:  val_2);
    }
    public void clearUserProperties()
    {
        var val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.Log(message:  System.String.Format(format:  "C# clearUserProperties", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[1];
        val_3[0] = this.instanceName;
        this.pluginClass.CallStatic(methodName:  "clearUserProperties", args:  val_3);
    }
    public void unsetUserProperty(string property)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# unsetUserProperty {0}", arg0:  property));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(property != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = property;
        this.pluginClass.CallStatic(methodName:  "unsetUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, bool value)
    {
        object val_5;
        int val_6;
        val_5 = property;
        bool val_1 = value;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  val_5, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_6 = val_4.Length;
        val_4[0] = this.instanceName;
        if(val_5 != null)
        {
                val_6 = val_4.Length;
        }
        
        val_4[1] = val_5;
        val_5 = val_1;
        val_4[2] = val_5;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_4);
    }
    public void setOnceUserProperty(string property, double value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, float value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, int value)
    {
        UnityEngine.AndroidJavaClass val_4;
        int val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "setOnceUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, long value)
    {
        UnityEngine.AndroidJavaClass val_4;
        long val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "setOnceUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, string value)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  property, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(property != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = property;
        if(value != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[2] = value;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_3);
    }
    public void setOnceUserProperty(string property, System.Collections.Generic.IDictionary<string, object> values)
    {
        int val_5;
        if(values == null)
        {
                return;
        }
        
        string val_1 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  values);
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  property, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_5 = val_4.Length;
        val_4[0] = this.instanceName;
        if(property != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[1] = property;
        if(val_1 != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[2] = val_1;
        this.pluginClass.CallStatic(methodName:  "setOnceUserPropertyDict", args:  val_4);
    }
    public void setOnceUserProperty<T>(string property, System.Collections.Generic.IList<T> values)
    {
        int val_6;
        if(values == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "list", value:  values);
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        this.Log(message:  System.String.Format(format:  "C# setOnceUserProperty {0}, {1}", arg0:  property, arg1:  val_2));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_5 = new object[3];
        val_6 = val_5.Length;
        val_5[0] = this.instanceName;
        if(property != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[1] = property;
        if(val_2 != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[2] = val_2;
        this.pluginClass.CallStatic(methodName:  "setOnceUserPropertyList", args:  val_5);
    }
    public void setOnceUserProperty(string property, bool[] array)
    {
        int val_3;
        this.Log<System.Boolean>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setOnceUserProperty(string property, double[] array)
    {
        int val_3;
        this.Log<System.Double>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setOnceUserProperty(string property, float[] array)
    {
        int val_3;
        this.Log<System.Single>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setOnceUserProperty(string property, int[] array)
    {
        int val_3;
        this.Log<System.Int32>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setOnceUserProperty(string property, long[] array)
    {
        int val_3;
        this.Log<System.Int64>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setOnceUserProperty(string property, string[] array)
    {
        int val_3;
        this.Log<System.String>(message:  "C# setOnceUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setOnceUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, bool value)
    {
        object val_5;
        int val_6;
        val_5 = property;
        bool val_1 = value;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  val_5, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_6 = val_4.Length;
        val_4[0] = this.instanceName;
        if(val_5 != null)
        {
                val_6 = val_4.Length;
        }
        
        val_4[1] = val_5;
        val_5 = val_1;
        val_4[2] = val_5;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_4);
    }
    public void setUserProperty(string property, double value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_3);
    }
    public void setUserProperty(string property, float value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_3);
    }
    public void setUserProperty(string property, int value)
    {
        UnityEngine.AndroidJavaClass val_4;
        int val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "setUserProperty", args:  val_3);
    }
    public void setUserProperty(string property, long value)
    {
        UnityEngine.AndroidJavaClass val_4;
        long val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "setUserProperty", args:  val_3);
    }
    public void setUserProperty(string property, string value)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  property, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(property != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = property;
        if(value != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[2] = value;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_3);
    }
    public void setUserProperty(string property, System.Collections.Generic.IDictionary<string, object> values)
    {
        int val_5;
        if(values == null)
        {
                return;
        }
        
        string val_1 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  values);
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  property, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_5 = val_4.Length;
        val_4[0] = this.instanceName;
        if(property != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[1] = property;
        if(val_1 != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[2] = val_1;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_4);
    }
    public void setUserProperty<T>(string property, System.Collections.Generic.IList<T> values)
    {
        int val_6;
        if(values == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "list", value:  values);
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        this.Log(message:  System.String.Format(format:  "C# setUserProperty {0}, {1}", arg0:  property, arg1:  val_2));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_5 = new object[3];
        val_6 = val_5.Length;
        val_5[0] = this.instanceName;
        if(property != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[1] = property;
        if(val_2 != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[2] = val_2;
        this.pluginClass.CallStatic(methodName:  "setUserPropertyList", args:  val_5);
    }
    public void setUserProperty(string property, bool[] array)
    {
        int val_3;
        this.Log<System.Boolean>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, double[] array)
    {
        int val_3;
        this.Log<System.Double>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, float[] array)
    {
        int val_3;
        this.Log<System.Single>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, int[] array)
    {
        int val_3;
        this.Log<System.Int32>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, long[] array)
    {
        int val_3;
        this.Log<System.Int64>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void setUserProperty(string property, string[] array)
    {
        int val_3;
        this.Log<System.String>(message:  "C# setUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "setUserProperty", args:  val_2);
    }
    public void addUserProperty(string property, double value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "addUserProperty", args:  val_3);
    }
    public void addUserProperty(string property, float value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "addUserProperty", args:  val_3);
    }
    public void addUserProperty(string property, int value)
    {
        UnityEngine.AndroidJavaClass val_4;
        int val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "addUserProperty", args:  val_3);
    }
    public void addUserProperty(string property, long value)
    {
        UnityEngine.AndroidJavaClass val_4;
        long val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "addUserProperty", args:  val_3);
    }
    public void addUserProperty(string property, string value)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  property, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(property != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = property;
        if(value != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[2] = value;
        this.pluginClass.CallStatic(methodName:  "addUserProperty", args:  val_3);
    }
    public void addUserProperty(string property, System.Collections.Generic.IDictionary<string, object> values)
    {
        int val_5;
        if(values == null)
        {
                return;
        }
        
        string val_1 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  values);
        this.Log(message:  System.String.Format(format:  "C# addUserProperty {0}, {1}", arg0:  property, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_5 = val_4.Length;
        val_4[0] = this.instanceName;
        if(property != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[1] = property;
        if(val_1 != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[2] = val_1;
        this.pluginClass.CallStatic(methodName:  "addUserPropertyDict", args:  val_4);
    }
    public void appendUserProperty(string property, bool value)
    {
        object val_5;
        int val_6;
        val_5 = property;
        bool val_1 = value;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  val_5, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_6 = val_4.Length;
        val_4[0] = this.instanceName;
        if(val_5 != null)
        {
                val_6 = val_4.Length;
        }
        
        val_4[1] = val_5;
        val_5 = val_1;
        val_4[2] = val_5;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_4);
    }
    public void appendUserProperty(string property, double value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_3);
    }
    public void appendUserProperty(string property, float value)
    {
        object val_4;
        int val_5;
        val_4 = property;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  val_4, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_5 = val_3.Length;
        val_3[0] = this.instanceName;
        if(val_4 != null)
        {
                val_5 = val_3.Length;
        }
        
        val_3[1] = val_4;
        val_4 = value;
        val_3[2] = val_4;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_3);
    }
    public void appendUserProperty(string property, int value)
    {
        UnityEngine.AndroidJavaClass val_4;
        int val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "appendUserProperty", args:  val_3);
    }
    public void appendUserProperty(string property, long value)
    {
        UnityEngine.AndroidJavaClass val_4;
        long val_5;
        string val_6;
        int val_7;
        val_5 = value;
        val_6 = this;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  property, arg1:  val_5));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_4 = this.pluginClass;
        object[] val_3 = new object[3];
        val_6 = this.instanceName;
        val_7 = val_3.Length;
        val_3[0] = val_6;
        if(property != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = property;
        val_5 = val_5;
        val_3[2] = val_5;
        val_4.CallStatic(methodName:  "appendUserProperty", args:  val_3);
    }
    public void appendUserProperty(string property, string value)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  property, arg1:  value));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(property != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = property;
        if(value != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[2] = value;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_3);
    }
    public void appendUserProperty(string property, System.Collections.Generic.IDictionary<string, object> values)
    {
        int val_5;
        if(values == null)
        {
                return;
        }
        
        string val_1 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  values);
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  property, arg1:  val_1));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_4 = new object[3];
        val_5 = val_4.Length;
        val_4[0] = this.instanceName;
        if(property != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[1] = property;
        if(val_1 != null)
        {
                val_5 = val_4.Length;
        }
        
        val_4[2] = val_1;
        this.pluginClass.CallStatic(methodName:  "appendUserPropertyDict", args:  val_4);
    }
    public void appendUserProperty<T>(string property, System.Collections.Generic.IList<T> values)
    {
        int val_6;
        if(values == null)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "list", value:  values);
        string val_2 = AmplitudeNS.MiniJSON.Json.Serialize(obj:  val_1);
        this.Log(message:  System.String.Format(format:  "C# appendUserProperty {0}, {1}", arg0:  property, arg1:  val_2));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_5 = new object[3];
        val_6 = val_5.Length;
        val_5[0] = this.instanceName;
        if(property != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[1] = property;
        if(val_2 != null)
        {
                val_6 = val_5.Length;
        }
        
        val_5[2] = val_2;
        this.pluginClass.CallStatic(methodName:  "appendUserPropertyList", args:  val_5);
    }
    public void appendUserProperty(string property, bool[] array)
    {
        int val_3;
        this.Log<System.Boolean>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    public void appendUserProperty(string property, double[] array)
    {
        int val_3;
        this.Log<System.Double>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    public void appendUserProperty(string property, float[] array)
    {
        int val_3;
        this.Log<System.Single>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    public void appendUserProperty(string property, int[] array)
    {
        int val_3;
        this.Log<System.Int32>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    public void appendUserProperty(string property, long[] array)
    {
        int val_3;
        this.Log<System.Int64>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    public void appendUserProperty(string property, string[] array)
    {
        int val_3;
        this.Log<System.String>(message:  "C# appendUserProperty", property:  property, array:  array);
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_2 = new object[3];
        val_3 = val_2.Length;
        val_2[0] = this.instanceName;
        if(property != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[1] = property;
        if(array != null)
        {
                val_3 = val_2.Length;
        }
        
        val_2[2] = array;
        this.pluginClass.CallStatic(methodName:  "appendUserProperty", args:  val_2);
    }
    private void setLibraryName(string libraryName)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setLibraryName {0}", arg0:  libraryName));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(libraryName != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = libraryName;
        this.pluginClass.CallStatic(methodName:  "setLibraryName", args:  val_3);
    }
    private void setLibraryVersion(string libraryVersion)
    {
        int val_4;
        this.Log(message:  System.String.Format(format:  "C# setLibraryVersion {0}", arg0:  libraryVersion));
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = this.instanceName;
        if(libraryVersion != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = libraryVersion;
        this.pluginClass.CallStatic(methodName:  "setLibraryVersion", args:  val_3);
    }
    public void startSession()
    {
    
    }
    public void endSession()
    {
    
    }
    private static Amplitude()
    {
        Amplitude.UnityLibraryName = "amplitude-unity";
        Amplitude.UnityLibraryVersion = "1.6.0";
        Amplitude.instanceLock = new System.Object();
        Amplitude.androidPluginName = "com.amplitude.unity.plugins.AmplitudePlugin";
    }

}

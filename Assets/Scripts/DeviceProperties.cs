using UnityEngine;
public static class DeviceProperties
{
    // Properties
    public static string LocaleFromDevice { get; }
    public static string FreeMemory { get; }
    public static string MaxMemory { get; }
    public static string LoadingTime { get; }
    public static bool isJailbroken { get; }
    public static string notificationToken { get; }
    public static bool timeTraveler { get; }
    public static string MacAddress { get; }
    public static string DeviceModel { get; }
    public static string SimpleOSVersion { get; }
    public static string SimpleDeviceModel { get; }
    public static string OSVersion { get; }
    public static string LanguageCode { get; }
    public static string Platform { get; }
    public static string Idfa { get; }
    
    // Methods
    public static string get_LocaleFromDevice()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = "en-US";
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        UnityEngine.AndroidJavaObject val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceProperties").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_2 == null)
        {
                return (string)val_4;
        }
        
        val_6 = public static T[] System.Array::Empty<System.Object>();
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = val_2.Call<System.String>(methodName:  "getLocaleFromDevice", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        return (string)val_4;
    }
    public static string get_FreeMemory()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = "";
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        UnityEngine.AndroidJavaObject val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceProperties").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_2 == null)
        {
                return (string)val_4;
        }
        
        val_6 = public static T[] System.Array::Empty<System.Object>();
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = val_2.Call<System.String>(methodName:  "getFreeMemory", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        return (string)val_4;
    }
    public static string get_MaxMemory()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        val_4 = "";
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
        UnityEngine.AndroidJavaObject val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceProperties").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_2 == null)
        {
                return (string)val_4;
        }
        
        val_6 = public static T[] System.Array::Empty<System.Object>();
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = val_2.Call<System.String>(methodName:  "getMaxMemory", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        return (string)val_4;
    }
    public static string get_LoadingTime()
    {
        return "0";
    }
    public static bool get_isJailbroken()
    {
        var val_3;
        var val_4;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        UnityEngine.AndroidJavaObject val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceProperties").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_2 == null)
        {
                return (bool)val_2;
        }
        
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        return val_2.Call<System.Boolean>(methodName:  "isDeviceRooted", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public static string get_notificationToken()
    {
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        int val_8;
        UnityEngine.AndroidJavaClass val_1 = null;
        val_4 = val_1;
        val_1 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.gcm.RemoteNotificationPlugin");
        val_5 = 1152921509994688304;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        UnityEngine.AndroidJavaObject val_2 = val_1.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_2 != null)
        {
                val_5 = public static T[] System.Array::Empty<System.Object>();
            val_4 = val_2;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_3 = val_4.Call<System.String>(methodName:  "getRegistrationToken", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_8;
        }
        
        val_8 = System.String.alignConst;
        return (string)val_8;
    }
    public static bool get_timeTraveler()
    {
        var val_9;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_9 = 0;
            return (bool)(val_6._ticks.TotalHours > 12) ? 1 : 0;
        }
        
        System.DateTime val_3 = System.DateTime.UtcNow;
        System.DateTime val_4 = ServerHandler.ServerTime;
        System.TimeSpan val_5 = val_3.dateData.Subtract(value:  new System.DateTime() {dateData = val_4.dateData});
        System.TimeSpan val_6 = val_5._ticks.Duration();
        return (bool)(val_6._ticks.TotalHours > 12) ? 1 : 0;
    }
    public static string get_MacAddress()
    {
        return DeviceIdPlugin.GetMacAddress();
    }
    public static string get_DeviceModel()
    {
        return UnityEngine.SystemInfo.deviceModel;
    }
    public static string get_SimpleOSVersion()
    {
        if((System.String.op_Equality(a:  "android", b:  "android")) != true)
        {
                if((System.String.op_Equality(a:  "android", b:  "editor")) == false)
        {
            goto label_3;
        }
        
        }
        
        char[] val_4 = new char[1];
        val_4[0] = 32;
        return (string)UnityEngine.SystemInfo.operatingSystem.Split(separator:  val_4)[2];
        label_3:
        if((System.String.op_Equality(a:  "android", b:  "ios")) == false)
        {
                return (string)UnityEngine.SystemInfo.operatingSystem.Split(separator:  val_4)[2];
        }
        
        char[] val_8 = new char[1];
        val_8[0] = 32;
        if(val_9.Length == 0)
        {
                return (string)UnityEngine.SystemInfo.operatingSystem.Split(separator:  val_4)[2];
        }
        
        char[] val_11 = new char[1];
        val_11[0] = '.';
        string val_15 = UnityEngine.SystemInfo.operatingSystem.Split(separator:  val_8)[((-4294967296) + ((val_9.Length) << 32)) >> 29].Split(separator:  val_11)[0];
        return (string)UnityEngine.SystemInfo.operatingSystem.Split(separator:  val_4)[2];
    }
    public static string get_SimpleDeviceModel()
    {
        if((System.String.op_Equality(a:  "android", b:  "android")) != true)
        {
                if((System.String.op_Equality(a:  "android", b:  "editor")) == false)
        {
            goto label_3;
        }
        
        }
        
        char[] val_4 = new char[1];
        val_4[0] = 32;
        return (string)UnityEngine.SystemInfo.deviceModel.Split(separator:  val_4)[((-4294967296) + ((val_5.Length) << 32)) >> 29];
        label_3:
        if((System.String.op_Equality(a:  "android", b:  "ios")) == false)
        {
                return (string)UnityEngine.SystemInfo.deviceModel.Split(separator:  val_4)[((-4294967296) + ((val_5.Length) << 32)) >> 29];
        }
        
        if((UnityEngine.SystemInfo.deviceModel.Contains(value:  "iPad")) == false)
        {
                return (string)UnityEngine.SystemInfo.deviceModel.Split(separator:  val_4)[((-4294967296) + ((val_5.Length) << 32)) >> 29];
        }
        
        return (string)UnityEngine.SystemInfo.deviceModel.Split(separator:  val_4)[((-4294967296) + ((val_5.Length) << 32)) >> 29];
    }
    public static string get_OSVersion()
    {
        return UnityEngine.SystemInfo.operatingSystem;
    }
    public static string get_LanguageCode()
    {
        return UnityEngine.PlayerPrefs.GetString(key:  "Language");
    }
    public static string get_Platform()
    {
        return "android";
    }
    public static string get_Idfa()
    {
        return DeviceIdPlugin.GetIdfa();
    }

}

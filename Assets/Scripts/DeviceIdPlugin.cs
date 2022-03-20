using UnityEngine;
public class DeviceIdPlugin
{
    // Fields
    public static string UNIDENTIFIABLE_ANDROID_DEVICE;
    private static string UNIDENTIFIABLE_IOS_MAC;
    public static string DEFAULT_DEVICE_ID;
    public static string DEFAULT_IOS_DEVICE_ID;
    private static UnityEngine.AndroidJavaObject plugin;
    private static System.Random random;
    private static string cachedCountry;
    private static string cachedCountryFromLocale;
    private static bool _cachedEmulator;
    private static bool _isEmulator;
    
    // Methods
    public static string GetDeviceId()
    {
        string val_12;
        var val_13;
        string val_14;
        var val_15;
        var val_16;
        var val_17;
        var val_18;
        if(UnityEngine.Application.platform == 8)
        {
                val_12 = 1152921504888582144;
            val_13 = null;
            val_13 = null;
            val_14 = DeviceIdPlugin.DEFAULT_IOS_DEVICE_ID;
            return val_14;
        }
        
        if(UnityEngine.Application.platform == 11)
        {
                UnityEngine.AndroidJavaClass val_3 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin");
            val_15 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_15 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_15 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_15 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
            val_16 = null;
            val_16 = null;
            DeviceIdPlugin.plugin = val_3.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_17 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_17 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_5 = DeviceIdPlugin.plugin.Call<System.String>(methodName:  "getDeviceId", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_12 = val_5;
            if((System.String.op_Equality(a:  val_5, b:  "9774d56d682e549c")) != true)
        {
                if((System.String.IsNullOrEmpty(value:  val_12)) == false)
        {
            goto label_23;
        }
        
        }
        
            string val_9 = "uia-"("uia-") + DeviceIdPlugin.GenerateIDForUnidentifiableAndroid(size:  12)(DeviceIdPlugin.GenerateIDForUnidentifiableAndroid(size:  12));
            return val_14;
        }
        
        val_12 = 1152921504888582144;
        val_18 = null;
        val_18 = null;
        val_14 = DeviceIdPlugin.DEFAULT_DEVICE_ID;
        return val_14;
        label_23:
        string val_10 = "an-"("an-") + val_12;
        return val_14;
    }
    public static string GenerateIDForUnidentifiableAndroid(int size = 12)
    {
        char val_8;
        var val_9;
        if((UnityEngine.PlayerPrefs.HasKey(key:  "player_cached_uia")) != false)
        {
                return UnityEngine.PlayerPrefs.GetString(key:  "player_cached_uia");
        }
        
        System.Text.StringBuilder val_2 = null;
        val_8 = 0;
        val_2 = new System.Text.StringBuilder();
        if(size >= 1)
        {
                var val_8 = 0;
            do
        {
            val_9 = null;
            val_9 = null;
            double val_3 = V0.16B * 26;
            val_3 = val_3 + 65;
            val_8 = System.Convert.ToChar(value:  System.Convert.ToInt32(value:  V0.16B));
            System.Text.StringBuilder val_6 = val_2.Append(value:  val_8);
            val_8 = val_8 + 1;
        }
        while(val_8 < size);
        
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "player_cached_uia", value:  val_2);
        bool val_7 = PrefsSerializationManager.SavePlayerPrefs();
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    public static string GetGoogleAdId()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        if(UnityEngine.Application.platform == 11)
        {
                UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.AdIdPlugin");
            if(val_2 != null)
        {
                val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = null;
            val_7 = null;
            DeviceIdPlugin.plugin = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_7 = null;
        }
        
            val_7 = null;
            val_5 = DeviceIdPlugin.plugin;
            if(val_5 != null)
        {
                val_5 = DeviceIdPlugin.plugin;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getGoogleAdId", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_9;
        }
        
        }
        
        val_9 = "NA";
        return (string)val_9;
    }
    public static bool identifiableDevice()
    {
        if(UnityEngine.Application.platform != 11)
        {
                return true;
        }
        
        return System.String.op_Inequality(a:  UnityEngine.SystemInfo.deviceUniqueIdentifier, b:  "9774d56d682e549c");
    }
    public static string GetAndroidVersion()
    {
        var val_4;
        var val_5;
        var val_6;
        UnityEngine.AndroidJavaObject val_7;
        var val_8;
        var val_9;
        val_4 = 1152921509994688304;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = null;
        val_6 = null;
        DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_7 = DeviceIdPlugin.plugin;
        if(val_7 != null)
        {
                val_7 = DeviceIdPlugin.plugin;
            val_4 = public static T[] System.Array::Empty<System.Object>();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_3 = val_7.Call<System.String>(methodName:  "getAndroidVersion", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_9;
        }
        
        val_9 = "1";
        return (string)val_9;
    }
    public static string GetClientVersion()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_11;
        if(UnityEngine.Application.platform != 11)
        {
            goto label_1;
        }
        
        val_6 = 1152921509994688304;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = null;
        val_8 = null;
        DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeviceIdPlugin.plugin;
        if(val_5 == null)
        {
            goto label_11;
        }
        
        val_5 = DeviceIdPlugin.plugin;
        val_6 = public static T[] System.Array::Empty<System.Object>();
        val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        string val_4 = val_5.Call<System.String>(methodName:  "getVersionCode", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        return (string)val_11;
        label_1:
        val_11 = "0.0";
        return (string)val_11;
        label_11:
        val_11 = "1.0";
        return (string)val_11;
    }
    public static string GetIdfa()
    {
        return (string)(UnityEngine.Application.platform == 8) ? "dummyIosId" : "";
    }
    public static string GetMacAddress()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        if(UnityEngine.Application.platform == 11)
        {
                val_6 = 1152921509994688304;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = null;
            val_8 = null;
            DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_5 = DeviceIdPlugin.plugin;
            if(val_5 != null)
        {
                val_5 = DeviceIdPlugin.plugin;
            val_6 = public static T[] System.Array::Empty<System.Object>();
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getMacAddress", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_10;
        }
        
        }
        
        val_10 = "";
        return (string)val_10;
    }
    public static string GetCountry()
    {
        UnityEngine.AndroidJavaObject val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_9;
        val_5 = null;
        val_5 = null;
        if(DeviceIdPlugin.cachedCountry != null)
        {
                return (string)DeviceIdPlugin.cachedCountry;
        }
        
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = null;
        val_7 = null;
        DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_4 = DeviceIdPlugin.plugin;
        if(val_4 != null)
        {
                val_4 = DeviceIdPlugin.plugin;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = null;
            DeviceIdPlugin.cachedCountry = val_4.Call<System.String>(methodName:  "getCountry", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_4 = System.String.alignConst;
            val_7 = null;
            DeviceIdPlugin.cachedCountry = val_4;
        }
        
        val_5 = val_7;
        return (string)DeviceIdPlugin.cachedCountry;
    }
    public static string GetCountryFromLocale()
    {
        UnityEngine.AndroidJavaObject val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_9;
        val_5 = null;
        val_5 = null;
        if(DeviceIdPlugin.cachedCountryFromLocale != null)
        {
                return (string)DeviceIdPlugin.cachedCountryFromLocale;
        }
        
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = null;
        val_7 = null;
        DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_4 = DeviceIdPlugin.plugin;
        if(val_4 != null)
        {
                val_4 = DeviceIdPlugin.plugin;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_9 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_9 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = null;
            DeviceIdPlugin.cachedCountryFromLocale = val_4.Call<System.String>(methodName:  "getCountryFromLocale", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_4 = System.String.alignConst;
            val_7 = null;
            DeviceIdPlugin.cachedCountryFromLocale = val_4;
        }
        
        val_5 = val_7;
        return (string)DeviceIdPlugin.cachedCountryFromLocale;
    }
    public static int GetTimeZone()
    {
        float val_5;
        float val_8;
        double val_9;
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = DateTimeCheat.UtcNow;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        double val_4 = val_3._ticks.TotalHours;
        if(val_4 >= 0f)
        {
            goto label_7;
        }
        
        if(val_4 != (-0.5))
        {
            goto label_8;
        }
        
        val_8 = val_5;
        val_9 = -1;
        goto label_9;
        label_7:
        if(val_4 != 0.5)
        {
            goto label_10;
        }
        
        val_8 = val_5;
        val_9 = 1;
        label_9:
        val_9 = val_8 + val_9;
        val_8 = (((long)val_8 & 1) != 0) ? (val_8) : (val_9);
        goto label_12;
        label_8:
        double val_6 = val_4 + (-0.5);
        goto label_12;
        label_10:
        double val_7 = val_4 + 0.5;
        label_12:
        val_7 = (val_7 == Infinity) ? (-val_7) : (val_7);
        return (int)(int)val_7;
    }
    public static string GetBusinessToken()
    {
        return (string)System.String.alignConst;
    }
    public static bool IsEmulator()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_10;
        bool val_11;
        val_6 = null;
        val_6 = null;
        val_7 = val_6;
        if(DeviceIdPlugin._cachedEmulator != false)
        {
                val_7 = 1152921504888582328;
            return (bool)DeviceIdPlugin._isEmulator;
        }
        
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = null;
        val_7 = null;
        DeviceIdPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeviceIdPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeviceIdPlugin.plugin;
        if(val_5 != null)
        {
                val_5 = DeviceIdPlugin.plugin;
            val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_10 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_10 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_7 = null;
            val_11 = val_5.Call<System.Boolean>(methodName:  "isEmulator", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_7 = null;
            val_11 = false;
        }
        
        DeviceIdPlugin._isEmulator = val_11;
        val_7 = null;
        DeviceIdPlugin._cachedEmulator = true;
        return (bool)DeviceIdPlugin._isEmulator;
    }
    public DeviceIdPlugin()
    {
    
    }
    private static DeviceIdPlugin()
    {
        DeviceIdPlugin.UNIDENTIFIABLE_ANDROID_DEVICE = "unidentifiableAndroid";
        DeviceIdPlugin.UNIDENTIFIABLE_IOS_MAC = "020000000000";
        DeviceIdPlugin.DEFAULT_DEVICE_ID = "dummyId";
        DeviceIdPlugin.DEFAULT_IOS_DEVICE_ID = "dummyIosId";
        System.DateTime val_1 = System.DateTime.Now;
        DeviceIdPlugin.random = new System.Random(Seed:  val_1.dateData.Ticks);
        DeviceIdPlugin.cachedCountry = 0;
        DeviceIdPlugin.cachedCountryFromLocale = 0;
        DeviceIdPlugin._cachedEmulator = false;
        DeviceIdPlugin._isEmulator = false;
    }

}

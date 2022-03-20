using UnityEngine;
public class DeeplinkPlugin
{
    // Fields
    private static UnityEngine.AndroidJavaObject plugin;
    
    // Methods
    public static DeeplinkAction GetAction()
    {
        return (DeeplinkAction)new DeeplinkAction(maybeJson:  DeeplinkPlugin.GetAndroidAction());
    }
    public static void NotifyActionConsumed(string identifier)
    {
        object[] val_1 = new object[1];
        val_1[0] = identifier;
        UnityEngine.Debug.LogWarningFormat(format:  "DeeplinkPlugin. Notify action [{0}] as consumed", args:  val_1);
        DeeplinkPlugin.AndroidNotifyConsumed(identifier:  identifier);
    }
    public static System.Collections.Generic.Dictionary<string, string> GetActionParameters()
    {
        return DeeplinkPlugin.GetAndroidActionParameters();
    }
    private static string GetIosAction()
    {
        UnityEngine.RuntimePlatform val_1 = UnityEngine.Application.platform;
        return "";
    }
    public static string GetNotificationData()
    {
        return DeeplinkPlugin.GetAndroidNotificationData();
    }
    public static void SendDeferredLinkToAdjust()
    {
        DeeplinkPlugin.CaptureDeeplinkWithAdjust();
    }
    public static string GetSwipedNotification()
    {
        return DeeplinkPlugin.GetAndroidSwipedNotification();
    }
    public static string GetMoreGamesReferal()
    {
        return DeeplinkPlugin.GetAndroidMoreGamesReferal();
    }
    public static void RateApp()
    {
    
    }
    private static System.Collections.Generic.Dictionary<string, string> GetIosActionParameters()
    {
        UnityEngine.RuntimePlatform val_2 = UnityEngine.Application.platform;
        return (System.Collections.Generic.Dictionary<System.String, System.String>)new System.Collections.Generic.Dictionary<System.String, System.String>();
    }
    private static void CaptureDeeplinkWithAdjust()
    {
        var val_3;
        var val_4;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(DeeplinkPlugin.plugin == null)
        {
                return;
        }
        
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin.Call(methodName:  "sendDeferredLinkToAdjust", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    private static string GetIOsNotificationData()
    {
        UnityEngine.RuntimePlatform val_1 = UnityEngine.Application.platform;
        return (string)System.String.alignConst;
    }
    private static string GetAndroidAction()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_10;
        if(UnityEngine.Application.platform != 11)
        {
                return (string)val_10;
        }
        
        val_6 = 1152921509994688304;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeeplinkPlugin.plugin;
        if(val_5 != null)
        {
                val_6 = public static T[] System.Array::Empty<System.Object>();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getAction", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_10;
        }
        
        val_10 = "";
        return (string)val_10;
    }
    private static void AndroidNotifyConsumed(string identifier)
    {
        var val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_4 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_4 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(DeeplinkPlugin.plugin == null)
        {
                return;
        }
        
        object[] val_3 = new object[1];
        val_3[0] = identifier;
        DeeplinkPlugin.plugin.Call(methodName:  "notifyConsumed", args:  val_3);
    }
    private static string GetAndroidNotificationData()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_10;
        if(UnityEngine.Application.platform != 11)
        {
                return (string)val_10;
        }
        
        val_6 = 1152921509994688304;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeeplinkPlugin.plugin;
        if(val_5 != null)
        {
                val_6 = public static T[] System.Array::Empty<System.Object>();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getNotificationData", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_10;
        }
        
        val_10 = "";
        return (string)val_10;
    }
    private static string GetAndroidSwipedNotification()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_10;
        if(UnityEngine.Application.platform != 11)
        {
                return (string)val_10;
        }
        
        val_6 = 1152921509994688304;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeeplinkPlugin.plugin;
        if(val_5 != null)
        {
                val_6 = public static T[] System.Array::Empty<System.Object>();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getSwipedNotification", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_10;
        }
        
        val_10 = "";
        return (string)val_10;
    }
    private static string GetAndroidMoreGamesReferal()
    {
        UnityEngine.AndroidJavaObject val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_10;
        if(UnityEngine.Application.platform != 11)
        {
                return (string)val_10;
        }
        
        val_6 = 1152921509994688304;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_5 = DeeplinkPlugin.plugin;
        if(val_5 != null)
        {
                val_6 = public static T[] System.Array::Empty<System.Object>();
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_8 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_8 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            string val_4 = val_5.Call<System.String>(methodName:  "getReferal", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return (string)val_10;
        }
        
        val_10 = "";
        return (string)val_10;
    }
    private static string GetIOSSwipedNotification()
    {
        UnityEngine.RuntimePlatform val_1 = UnityEngine.Application.platform;
        return (string)System.String.alignConst;
    }
    private static System.Collections.Generic.Dictionary<string, string> GetAndroidActionParameters()
    {
        string val_11;
        var val_12;
        var val_13;
        var val_14;
        if(UnityEngine.Application.platform == 11)
        {
                val_11 = 1152921509994688304;
            val_12 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_12 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_12 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_12 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            DeeplinkPlugin.plugin = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.DeeplinkPlugin").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(DeeplinkPlugin.plugin != null)
        {
                val_11 = public static T[] System.Array::Empty<System.Object>();
            val_13 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_13 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_13 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_13 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            char[] val_5 = new char[1];
            val_5[0] = ',';
            System.Collections.Generic.Dictionary<System.String, System.String> val_7 = null;
            val_14 = val_7;
            val_7 = new System.Collections.Generic.Dictionary<System.String, System.String>();
            if(val_6.Length < 1)
        {
                return (System.Collections.Generic.Dictionary<System.String, System.String>)val_14;
        }
        
            var val_13 = 0;
            do
        {
            val_11 = DeeplinkPlugin.plugin.Call<System.String>(methodName:  "getActionParameters", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Split(separator:  val_5)[val_13];
            char[] val_8 = new char[1];
            val_8[0] = ':';
            System.String[] val_9 = val_11.Split(separator:  val_8);
            if(val_9.Length == 2)
        {
                val_7.Add(key:  val_9[0], value:  val_9[1]);
        }
        
            val_13 = val_13 + 1;
        }
        while(val_13 < val_6.Length);
        
            return (System.Collections.Generic.Dictionary<System.String, System.String>)val_14;
        }
        
        }
        
        System.Collections.Generic.Dictionary<System.String, System.String> val_10 = null;
        val_14 = val_10;
        val_10 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        return (System.Collections.Generic.Dictionary<System.String, System.String>)val_14;
    }
    public DeeplinkPlugin()
    {
    
    }

}

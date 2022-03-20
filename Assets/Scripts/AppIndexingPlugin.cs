using UnityEngine;
public class AppIndexingPlugin : MonoBehaviour
{
    // Fields
    private static UnityEngine.AndroidJavaObject mPlugin;
    
    // Properties
    private static UnityEngine.AndroidJavaObject plugin { get; }
    
    // Methods
    public static void LogStartSession()
    {
        AppConfigs val_1 = App.Configuration;
        AppConfigs val_3 = App.Configuration;
        AppConfigs val_4 = App.Configuration;
        AppConfigs val_6 = App.Configuration;
        AppIndexingPlugin.AndroidIndexAndLogAction(name:  "Play " + val_1.appConfig.gameName, url:  System.String.Format(format:  "https://{0}.{1}", arg0:  val_3.appConfig.deeplinkScheme, arg1:  val_4.appConfig.domainName), description:  val_6.gameConfig.appIndexDescription);
    }
    public static void IndexAndLogAction(string name, string url, string description)
    {
        AppIndexingPlugin.AndroidIndexAndLogAction(name:  name, url:  url, description:  description);
    }
    public static void LogAction(string name, string url)
    {
        AppIndexingPlugin.AndroidLogAction(name:  name, url:  url);
    }
    private static void AndroidIndexAndLogAction(string name, string url, string description)
    {
        int val_4;
        if(AppIndexingPlugin.plugin == null)
        {
                return;
        }
        
        object[] val_3 = new object[3];
        val_4 = val_3.Length;
        val_3[0] = name;
        if(url != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = url;
        if(description != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[2] = description;
        AppIndexingPlugin.plugin.Call(methodName:  "IndexAndLogAction", args:  val_3);
    }
    private static void AndroidLogAction(string name, string url)
    {
        int val_4;
        if(AppIndexingPlugin.plugin == null)
        {
                return;
        }
        
        object[] val_3 = new object[2];
        val_4 = val_3.Length;
        val_3[0] = name;
        if(url != null)
        {
                val_4 = val_3.Length;
        }
        
        val_3[1] = url;
        AppIndexingPlugin.plugin.Call(methodName:  "LogEndAction", args:  val_3);
    }
    private static UnityEngine.AndroidJavaObject get_plugin()
    {
        var val_3;
        UnityEngine.AndroidJavaObject val_4;
        var val_5;
        val_4 = AppIndexingPlugin.mPlugin;
        if(val_4 != null)
        {
                return val_4;
        }
        
        UnityEngine.AndroidJavaClass val_1 = null;
        val_3 = val_1;
        val_1 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.AppIndexingPlugin");
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        AppIndexingPlugin.mPlugin = val_1.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_4 = AppIndexingPlugin.mPlugin;
        return val_4;
    }
    public AppIndexingPlugin()
    {
    
    }

}

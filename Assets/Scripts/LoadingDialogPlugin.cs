using UnityEngine;
public class LoadingDialogPlugin
{
    // Fields
    private static UnityEngine.AndroidJavaObject mPlugin;
    
    // Properties
    private static UnityEngine.AndroidJavaObject plugin { get; }
    
    // Methods
    private static UnityEngine.AndroidJavaObject get_plugin()
    {
        var val_3;
        UnityEngine.AndroidJavaObject val_4;
        var val_5;
        val_4 = LoadingDialogPlugin.mPlugin;
        if(val_4 != null)
        {
                return val_4;
        }
        
        UnityEngine.AndroidJavaClass val_1 = null;
        val_3 = val_1;
        val_1 = new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.plugins.LoadingDialogPlugin");
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        LoadingDialogPlugin.mPlugin = val_1.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        val_4 = LoadingDialogPlugin.mPlugin;
        return val_4;
    }
    public static void RemoveView()
    {
        var val_3;
        if(UnityEngine.Application.platform != 11)
        {
                return;
        }
        
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_3 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_3 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        LoadingDialogPlugin.plugin.Call(methodName:  "RemoveView", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public LoadingDialogPlugin()
    {
    
    }

}

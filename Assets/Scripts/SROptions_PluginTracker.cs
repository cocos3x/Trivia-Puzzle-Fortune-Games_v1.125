using UnityEngine;
public class SROptions_PluginTracker : SuperLuckySROptionsParent<SROptions_PluginTracker>, INotifyPropertyChanged
{
    // Methods
    public void Back()
    {
        var val_8;
        var val_11;
        var val_8 = 0;
        val_8 = val_8 + 1;
        val_8 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_9 = 0;
        val_9 = val_9 + 1;
        val_8 = 13;
        val_11 = public System.Void SRDebugger.Services.IDebugService::RemoveOptionContainer(object container);
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        var val_10 = 0;
        val_10 = val_10 + 1;
        val_11 = 12;
        SRDebug.Instance.AddOptionContainer(container:  SuperLuckySROptionsParent<SuperLuckySROptionsMain>.Instance);
    }
    public void LogGitlog()
    {
        var val_6;
        var val_7;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_6 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_6 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_7 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_7 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        UnityEngine.Debug.Log(message:  "Github Log\n\n" + new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.helpers.ActivityHelper").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<System.String>(methodName:  "getGitHubLog", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Replace(oldValue:  "\n", newValue:  "\n\n")(new UnityEngine.AndroidJavaClass(className:  "com.twelvegigs.helpers.ActivityHelper").CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "instance", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<System.String>(methodName:  "getGitHubLog", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Replace(oldValue:  "\n", newValue:  "\n\n")));
    }
    public SROptions_PluginTracker()
    {
    
    }

}

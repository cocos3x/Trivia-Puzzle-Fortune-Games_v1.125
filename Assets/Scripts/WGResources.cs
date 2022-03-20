using UnityEngine;
public static class WGResources
{
    // Fields
    private static string cachedGameResourcesPath;
    
    // Properties
    public static string gameResourcesPath { get; }
    public static string genericResourcesPath { get; }
    
    // Methods
    public static T Load<T>(string fileName, string extension = ".prefab", bool errorLog = True)
    {
        string val_8;
        UnityEngine.Object val_9;
        val_8 = WGResources.gameResourcesPath + fileName;
        UnityEngine.Object val_4 = UnityEngine.Resources.Load(path:  val_8, systemTypeInstance:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
        if(X0 == false)
        {
            goto label_7;
        }
        
        val_9 = X0;
        if(X0 == true)
        {
            goto label_8;
        }
        
        label_7:
        val_9 = 0;
        label_8:
        if((UnityEngine.Object.op_Implicit(exists:  val_9)) == true)
        {
                return (GameSpecificUI)val_9;
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_9)) == true)
        {
                return (GameSpecificUI)val_9;
        }
        
        val_8 = "WordGameResources: Could not load "("WordGameResources: Could not load ") + val_8;
        UnityEngine.Debug.LogWarning(message:  val_8);
        return (GameSpecificUI)val_9;
    }
    public static T[] LoadAll<T>(string path, string extension = ".prefab")
    {
        string val_2 = WGResources.gameResourcesPath + path;
        goto __RuntimeMethodHiddenParam + 48;
    }
    public static string get_gameResourcesPath()
    {
        AppConfigs val_1 = App.Configuration;
        return "game/"("game/") + val_1.appConfig.gamePathName + "/"("/");
    }
    public static void ClearCachedGameResourcesPath()
    {
        null = null;
        WGResources.cachedGameResourcesPath = 0;
    }
    public static string get_genericResourcesPath()
    {
        return "game/WordGame/Generic/";
    }
    private static WGResources()
    {
    
    }

}

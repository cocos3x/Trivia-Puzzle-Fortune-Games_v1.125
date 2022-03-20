using UnityEngine;
[Serializable]
public class HelpshiftConfig : ScriptableObject
{
    // Fields
    private static HelpshiftConfig instance;
    private const string helpshiftConfigAssetName = "HelpshiftConfig";
    private const string helpshiftConfigPath = "Helpshift/Resources";
    public const string pluginVersion = "5.5.1";
    
    // Properties
    public static HelpshiftConfig Instance { get; }
    
    // Methods
    public static HelpshiftConfig get_Instance()
    {
        var val_5;
        UnityEngine.Object val_1 = UnityEngine.Resources.Load(path:  "HelpshiftConfig");
        val_5 = 0;
        HelpshiftConfig.pluginVersion = ;
        if(HelpshiftConfig.pluginVersion != 0)
        {
                return (HelpshiftConfig)HelpshiftConfig.pluginVersion;
        }
        
        HelpshiftConfig.pluginVersion = UnityEngine.ScriptableObject.CreateInstance<HelpshiftConfig>();
        return (HelpshiftConfig)HelpshiftConfig.pluginVersion;
    }
    public HelpshiftConfig()
    {
    
    }

}

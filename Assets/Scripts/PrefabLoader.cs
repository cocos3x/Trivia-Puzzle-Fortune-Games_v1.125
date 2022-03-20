using UnityEngine;
public class PrefabLoader : MonoBehaviour
{
    // Fields
    private static bool themed;
    private static Themes themeType;
    private static string gc_type_to_string;
    
    // Methods
    public static T LoadPrefab<T>(string featureName)
    {
        object val_26;
        var val_27;
        var val_28;
        string val_31;
        var val_32;
        UnityEngine.Object val_33;
        var val_34;
        var val_35;
        object val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_41;
        var val_42;
        var val_43;
        var val_44;
        var val_45;
        var val_46;
        val_26 = __RuntimeMethodHiddenParam;
        PrefabLoader.CheckTheme();
        PrefabLoader.gc_type_to_string = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
        if((PrefabLoader.gc_type_to_string.Contains(value:  ".")) != false)
        {
                val_27 = null;
            val_27 = null;
            PrefabLoader.gc_type_to_string = PrefabLoader.gc_type_to_string.Remove(startIndex:  0, count:  (PrefabLoader.gc_type_to_string.LastIndexOf(value:  ".")) + 1);
        }
        
        string val_6 = "Prefabs/"("Prefabs/") + featureName;
        val_28 = null;
        string val_7 = (val_6 == null) ? "" : (val_6);
        val_28 = null;
        if(PrefabLoader.themed != false)
        {
                string val_9 = val_7 + "/"("/") + null.ToString() + "/"("/");
        }
        
        val_31 = val_7 + "/"("/");
        val_32 = null;
        val_32 = null;
        val_33 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_31 + PrefabLoader.gc_type_to_string, extension:  ".prefab", errorLog:  true);
        if(val_33 == 0)
        {
                val_34 = null;
            if(UnityEngine.Application.isEditor != false)
        {
                val_35 = null;
            val_36 = "PrefabLoader.LoadPrefab() No prefab found for type " + val_31 + PrefabLoader.gc_type_to_string;
            val_37 = 0;
            UnityEngine.Debug.LogError(message:  val_36);
        }
        else
        {
                val_38 = null;
            val_36 = "PrefabLoader.LoadPrefab() No prefab found for type " + val_31 + PrefabLoader.gc_type_to_string;
            val_37 = 0;
            UnityEngine.Debug.LogWarning(message:  val_36);
        }
        
            val_39 = null;
            val_39 = null;
            if((PrefabLoader.themed != false) && (PrefabLoader.themeType != 1))
        {
                val_31 = featureName + "/"("/") + null.ToString() + "/"("/");
            val_41 = null;
            if(UnityEngine.Application.isEditor != false)
        {
                val_42 = null;
            UnityEngine.Debug.LogError(message:  "PrefabLoader.LoadPrefab() Attempting to load backup prefab from " + val_31 + PrefabLoader.gc_type_to_string);
        }
        else
        {
                val_43 = null;
            UnityEngine.Debug.LogWarning(message:  "PrefabLoader.LoadPrefab() Attempting to load backup prfab from " + val_31 + PrefabLoader.gc_type_to_string);
        }
        
            val_44 = null;
            val_44 = null;
            val_33 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_31 + PrefabLoader.gc_type_to_string, extension:  ".prefab", errorLog:  true);
        }
        
            if(val_33 == 0)
        {
                val_45 = null;
            val_45 = null;
            val_26 = "PrefabLoader.LoadPrefab() No prefab found for type " + val_31 + PrefabLoader.gc_type_to_string;
            UnityEngine.Debug.LogError(message:  val_26);
            val_46 = 0;
            return (AlphabetBoxItem)val_46;
        }
        
        }
        
        val_46 = val_33;
        return (AlphabetBoxItem)val_46;
    }
    public static UnityEngine.GameObject LoadPrefab(string featureName, string prefabName)
    {
        string val_20;
        var val_21;
        string val_23;
        string val_25;
        UnityEngine.Object val_26;
        var val_27;
        val_20 = prefabName;
        PrefabLoader.CheckTheme();
        string val_1 = "Prefabs/"("Prefabs/") + featureName;
        val_21 = null;
        string val_2 = (val_1 == null) ? "" : (val_1);
        val_21 = null;
        if(PrefabLoader.themed != false)
        {
                val_23 = PrefabLoader.themeType.ToString();
            PrefabLoader.themeType = ;
            string val_4 = val_2 + "/"("/") + val_23 + "/"("/");
        }
        else
        {
                string val_5 = val_2 + "/"("/");
        }
        
        val_25 = val_5;
        val_26 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_5 + val_20, extension:  ".prefab", errorLog:  true);
        if(val_26 != 0)
        {
                return (UnityEngine.GameObject)val_26;
        }
        
        val_23 = "PrefabLoader.LoadPrefab() No prefab found for type " + val_25 + val_20;
        if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Debug.LogError(message:  val_23);
        }
        else
        {
                UnityEngine.Debug.LogWarning(message:  val_23);
        }
        
        val_27 = null;
        val_27 = null;
        if((PrefabLoader.themed != false) && (PrefabLoader.themeType != 1))
        {
                val_25 = featureName + "/"("/") + 1.ToString() + "/"("/");
            if(UnityEngine.Application.isEditor != false)
        {
                UnityEngine.Debug.LogError(message:  "PrefabLoader.LoadPrefab() Attempting to load backup prefab from " + val_25 + val_20);
        }
        else
        {
                UnityEngine.Debug.LogWarning(message:  "PrefabLoader.LoadPrefab() Attempting to load backup prfab from " + val_25 + val_20);
        }
        
            val_26 = WGResources.Load<UnityEngine.GameObject>(fileName:  val_25 + val_20, extension:  ".prefab", errorLog:  true);
        }
        
        if(val_26 != 0)
        {
                return (UnityEngine.GameObject)val_26;
        }
        
        val_20 = "PrefabLoader.LoadPrefab() No prefab found for type " + val_25 + val_20;
        UnityEngine.Debug.LogError(message:  val_20);
        val_26 = 0;
        return (UnityEngine.GameObject)val_26;
    }
    private static void CheckTheme()
    {
        var val_5;
        var val_6;
        bool val_8;
        var val_9;
        if(App.ThemesHandler == 0)
        {
            goto label_10;
        }
        
        AppConfigs val_3 = App.Configuration;
        if(val_3.gameConfig.themesEnabled == false)
        {
            goto label_10;
        }
        
        ThemesHandler val_4 = App.ThemesHandler;
        val_5 = 1152921504881180672;
        val_6 = null;
        val_6 = null;
        PrefabLoader.themeType = val_4.theme.themeType;
        if(PrefabLoader.themeType == 0)
        {
            goto label_25;
        }
        
        val_8 = 1;
        goto label_20;
        label_10:
        val_5 = 1152921504881180672;
        val_9 = null;
        val_9 = null;
        label_25:
        val_8 = false;
        label_20:
        PrefabLoader.themed = val_8;
    }
    public PrefabLoader()
    {
    
    }
    private static PrefabLoader()
    {
    
    }

}

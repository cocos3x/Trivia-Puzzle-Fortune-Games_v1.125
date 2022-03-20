using UnityEngine;
public class MonoSingletonInstantiateFromResources<T> : MonoBehaviour
{
    // Fields
    private static T _Instance;
    
    // Properties
    public static T Instance { get; }
    
    // Methods
    public static T get_Instance()
    {
        var val_3;
        var val_4;
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        var val_10;
        val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_3 & 1) == 0)
        {
                val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(0 == (__RuntimeMethodHiddenParam + 24 + 192 + 184))
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 302;
            val_5 = __RuntimeMethodHiddenParam + 24;
            if((val_4 & 1) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24];
            val_5 = __RuntimeMethodHiddenParam + 24;
            val_4 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
            val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_6 & 1) == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
            if(0 == (__RuntimeMethodHiddenParam + 24 + 192 + 184))
        {
                val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_7 & 1) == 0)
        {
                val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            val_8 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_8 = __RuntimeMethodHiddenParam + 24 + 302;
            val_9 = __RuntimeMethodHiddenParam + 24;
            if((val_8 & 1) == 0)
        {
                val_9 = mem[__RuntimeMethodHiddenParam + 24];
            val_9 = __RuntimeMethodHiddenParam + 24;
            val_8 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_8 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        }
        
        }
        
        val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_10 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_10 & 1) == 0)
        {
                val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_10 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        
        return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
    }
    private static void CreateSingleton()
    {
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        UnityEngine.Object val_23;
        var val_24;
        var val_25;
        string val_26;
        string val_27;
        string val_28;
        string val_29;
        var val_30;
        var val_31;
        var val_32;
        val_17 = 1152921504623353856;
        System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 32});
        val_18 = 1152921504893267968;
        val_19 = 1152921515792008688;
        MonoSingletonSelfGenerating<LoadTimer>.Instance.StartTimer(title:  "CreateSingleton<"("CreateSingleton<") + val_1 + ">"(">"), stopOnLevelWasLoaded:  true);
        val_20 = 1152921504947261440;
        val_21 = mem[__RuntimeMethodHiddenParam + 24 + 302];
        val_21 = __RuntimeMethodHiddenParam + 24 + 302;
        val_22 = __RuntimeMethodHiddenParam + 24;
        if((val_21 & 1) == 0)
        {
                val_22 = mem[__RuntimeMethodHiddenParam + 24];
            val_22 = __RuntimeMethodHiddenParam + 24;
            val_21 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_21 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        val_23 = val_1;
        if((UnityEngine.Object.op_Implicit(exists:  val_23)) != true)
        {
                AppConfigs val_5 = App.Configuration;
            val_24 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_24 = __RuntimeMethodHiddenParam + 24 + 302;
            val_25 = __RuntimeMethodHiddenParam + 24;
            if((val_24 & 1) == 0)
        {
                val_25 = mem[__RuntimeMethodHiddenParam + 24];
            val_25 = __RuntimeMethodHiddenParam + 24;
            val_24 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_24 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
            val_20 = ".prefab";
            val_18 = val_18;
            val_19 = val_19;
            val_17 = 1152921504623353856;
            val_23 = val_1 + "_" + val_5.appConfig.gamePathName;
        }
        
        val_26 = val_1;
        if((UnityEngine.Object.op_Implicit(exists:  val_23)) == true)
        {
            goto label_35;
        }
        
        val_26 = "Prefabs/"("Prefabs/") + val_1;
        UnityEngine.Object val_10 = UnityEngine.Resources.Load(path:  val_26, systemTypeInstance:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 32}));
        val_20 = X0;
        if(val_20 == false)
        {
            goto label_34;
        }
        
        val_23 = X0;
        if(X0 == true)
        {
            goto label_35;
        }
        
        label_34:
        val_23 = 0;
        label_35:
        if(val_23 != 0)
        {
            goto label_38;
        }
        
        val_27 = "Could not find ";
        val_28 = " in resources.";
        val_29 = val_26;
        goto label_39;
        label_38:
        val_30 = mem[__RuntimeMethodHiddenParam + 24 + 302];
        val_30 = __RuntimeMethodHiddenParam + 24 + 302;
        val_31 = __RuntimeMethodHiddenParam + 24;
        if((val_30 & 1) == 0)
        {
                val_31 = mem[__RuntimeMethodHiddenParam + 24];
            val_31 = __RuntimeMethodHiddenParam + 24;
            val_30 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_30 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        val_26 = val_23;
        if(val_23 != 0)
        {
            goto label_44;
        }
        
        val_27 = "MonoSingletonInstantiateFromResources<";
        val_28 = "> could not be created!";
        val_29 = val_1;
        label_39:
        UnityEngine.Debug.LogError(message:  val_27 + val_29 + val_28);
        return;
        label_44:
        val_26.name = val_1 + " Singleton (self-instantiated)"(" Singleton (self-instantiated)");
        val_32 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_32 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_32 & 1) == 0)
        {
                val_32 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_32 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        mem2[0] = val_26;
        MonoSingletonSelfGenerating<LoadTimer>.Instance.StopTimer(stopSpecifiedTimer:  "CreateSingleton<"("CreateSingleton<") + val_1 + ">"(">"));
    }
    public MonoSingletonInstantiateFromResources<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private static MonoSingletonInstantiateFromResources<T>()
    {
    
    }

}

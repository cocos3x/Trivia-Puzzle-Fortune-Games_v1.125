using UnityEngine;
public class MonoSingletonSelfGenerating<T> : MonoBehaviour
{
    // Fields
    protected static T _Instance;
    
    // Properties
    public static T Instance { get; }
    public static bool InstanceExists { get; }
    
    // Methods
    public static T get_Instance()
    {
        var val_20;
        var val_21;
        var val_22;
        string val_23;
        var val_24;
        int val_25;
        int val_26;
        object val_27;
        int val_28;
        int val_29;
        var val_30;
        int val_31;
        int val_32;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        var val_39;
        var val_40;
        var val_41;
        val_20 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_20 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_20 & 1) == 0)
        {
                val_20 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_20 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
        {
            goto label_139;
        }
        
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
        
        val_24 = (__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24) & 4294967295;
        if((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24) >= 2)
        {
                object val_20 = 0;
            UnityEngine.Object val_2 = (__RuntimeMethodHiddenParam + 24 + 192 + 16) + 32;
            do
        {
            if(val_2 == 0)
        {
                object[] val_4 = new object[4];
            val_25 = val_4.Length;
            val_4[0] = System.String.alignConst;
            val_25 = val_4.Length;
            val_4[1] = "\n instances[";
            val_26 = val_4.Length;
            val_4[2] = val_20;
            val_26 = val_4.Length;
            val_4[3] = "] is null";
            val_27 = +val_4;
        }
        else
        {
                object[] val_6 = new object[5];
            val_28 = val_6.Length;
            val_6[0] = System.String.alignConst;
            val_28 = val_6.Length;
            val_6[1] = "\n instances[";
            val_29 = val_6.Length;
            val_6[2] = val_20;
            val_29 = val_6.Length;
            val_6[3] = "] = ";
            val_6[4] = val_2.name;
            val_27 = +val_6;
            val_30 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_30 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_30 & 1) == 0)
        {
                val_30 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_30 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = val_2;
        }
        
            val_20 = val_20 + 1;
            val_2 = val_2 + 8;
        }
        while(val_20 < ((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24) << ));
        
            object[] val_9 = new object[5];
            val_31 = val_9.Length;
            val_9[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24});
            val_31 = val_9.Length;
            val_9[1] = " found: ";
            val_32 = val_9.Length;
            val_9[2] = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 24;
            val_32 = val_9.Length;
            val_9[3] = " (more details below)";
            if(val_27 != null)
        {
                val_32 = val_9.Length;
        }
        
            val_9[4] = val_27;
            val_23 = +val_9;
            val_33 = public static T[] System.Array::Empty<System.Object>();
            val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            D.LogClientError(developer:  val_23, filter:  "default", context:  0, strings:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_24 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 16 + 24];
            val_24 = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 24;
        }
        
        if(val_24 == 1)
        {
                if((__RuntimeMethodHiddenParam + 24 + 192 + 16 + 32) == 0)
        {
                val_23 = public static T[] System.Array::Empty<System.Object>();
            val_35 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_35 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_35 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_35 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            D.LogClientError(developer:  "instances[0] is null", filter:  "default", context:  0, strings:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        else
        {
                val_23 = mem[__RuntimeMethodHiddenParam + 24];
            val_23 = __RuntimeMethodHiddenParam + 24;
            val_36 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_36 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_36 & 1) == 0)
        {
                val_36 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_36 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16 + 32;
        }
        
        }
        
        val_37 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_37 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_37 & 1) == 0)
        {
                val_37 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_37 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0) || (UnityEngine.Application.isPlaying == false))
        {
            goto label_139;
        }
        
        val_38 = null;
        val_38 = null;
        if(App.isQuitting == true)
        {
            goto label_139;
        }
        
        val_39 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_39 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_39 & 1) == 0)
        {
                val_39 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_39 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        val_33 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 184];
        val_33 = __RuntimeMethodHiddenParam + 24 + 192 + 184;
        val_23 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8];
        val_23 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        if((new UnityEngine.GameObject(name:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24})(System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24})) + "_(self-generated)"("_(self-generated)")).AddComponent(componentType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 24 + 192 + 24}))) != null)
        {
                if(X0 == true)
        {
            goto label_159;
        }
        
        }
        
        val_40 = 0;
        label_159:
        mem2[0] = val_40;
        label_139:
        val_41 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_41 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_41 & 1) == 0)
        {
                val_41 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_41 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (AdsManager)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        
        return (AdsManager)__RuntimeMethodHiddenParam + 24 + 192 + 184;
    }
    public static bool get_InstanceExists()
    {
        var val_3;
        var val_4;
        val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_3 & 1) == 0)
        {
                val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_3 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
        {
                return false;
        }
        
        val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_4 & 1) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((val_4 & 512) == 0)
        {
                return UnityEngine.Object.op_Inequality(x:  __RuntimeMethodHiddenParam + 24 + 192 + 184.gameObject, y:  0);
        }
        
        return UnityEngine.Object.op_Inequality(x:  __RuntimeMethodHiddenParam + 24 + 192 + 184.gameObject, y:  0);
    }
    public MonoSingletonSelfGenerating<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private static MonoSingletonSelfGenerating<T>()
    {
    
    }

}

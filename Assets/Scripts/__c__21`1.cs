using UnityEngine;
[Serializable]
private sealed class PrefabsFromFolder.<>c__21<T>
{
    // Fields
    public static readonly PrefabsFromFolder.<>c__21<T> <>9;
    public static System.Func<UnityEngine.Transform, bool> <>9__21_0;
    
    // Methods
    private static PrefabsFromFolder.<>c__21<T>()
    {
        var val_1;
        var val_2;
        val_1 = mem[__RuntimeMethodHiddenParam + 24 + 302];
        val_1 = __RuntimeMethodHiddenParam + 24 + 302;
        val_2 = __RuntimeMethodHiddenParam + 24;
        if((val_1 & 1) == 0)
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 24];
            val_2 = __RuntimeMethodHiddenParam + 24;
            val_1 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
        mem2[0] = __RuntimeMethodHiddenParam + 24 + 192;
    }
    public PrefabsFromFolder.<>c__21<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    internal bool <LoadStrictlyTypeNamedPrefab>b__21_0(UnityEngine.Transform x)
    {
        return UnityEngine.Object.op_Inequality(x:  x, y:  0);
    }

}

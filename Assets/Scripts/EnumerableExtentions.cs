using UnityEngine;
public static class EnumerableExtentions
{
    // Methods
    public static U GetOrDefault<T, U>(System.Collections.Generic.Dictionary<T, U> dic, T key, U defaultValue)
    {
        var val_2 = mem[__RuntimeMethodHiddenParam + 48];
        val_2 = __RuntimeMethodHiddenParam + 48;
        if((dic & 1) == 0)
        {
                bool val_1 = defaultValue;
            val_2 = mem[__RuntimeMethodHiddenParam + 48];
            val_2 = __RuntimeMethodHiddenParam + 48;
        }
    
    }
    public static void SetOrAdd<T, U>(System.Collections.Generic.Dictionary<T, U> dic, T key, U newValue)
    {
        var val_2;
        if((dic & 1) != 0)
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 48 + 8];
            val_2 = __RuntimeMethodHiddenParam + 48 + 8;
        }
        else
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 48 + 16];
            val_2 = __RuntimeMethodHiddenParam + 48 + 16;
        }
        
        bool val_1 = newValue;
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }

}

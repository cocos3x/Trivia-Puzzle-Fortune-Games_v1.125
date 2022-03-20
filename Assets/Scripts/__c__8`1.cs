using UnityEngine;
[Serializable]
private sealed class WADPetsScreenUI.<>c__8<T>
{
    // Fields
    public static readonly WADPetsScreenUI.<>c__8<T> <>9;
    public static System.Action <>9__8_0;
    
    // Methods
    private static WADPetsScreenUI.<>c__8<T>()
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
    public WADPetsScreenUI.<>c__8<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    internal void <ShowScreen>b__8_0()
    {
        var val_3;
        var val_4;
        UnityEngine.GameObject val_13;
        UnityEngine.Object val_14;
        var val_15;
        val_13 = __RuntimeMethodHiddenParam;
        WADPetsScreenUI val_1 = MonoSingleton<WADPetsScreenUI>.Instance;
        Stack.Enumerator<T> val_2 = val_1.screenStack.GetEnumerator();
        label_9:
        if(val_4.MoveNext() == false)
        {
            goto label_5;
        }
        
        UnityEngine.GameObject val_6 = val_4.Current;
        val_14 = val_6;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  val_14)) == false)
        {
            goto label_9;
        }
        
        val_14.SetActive(value:  true);
        val_15 = 136;
        goto label_10;
        label_5:
        val_15 = 78;
        label_10:
        val_14 = 0;
        val_3 = val_4;
        val_4 = null;
        var val_12 = 0;
        val_12 = val_12 + 1;
        val_4.Dispose();
        if(val_14 != 0)
        {
                throw val_14;
        }
        
        if(0 != 1)
        {
                if(78 == 136)
        {
                return;
        }
        
        }
        
        WADPetsScreenUI val_8 = MonoSingleton<WADPetsScreenUI>.Instance;
        UnityEngine.GameObject val_9 = val_8.prefabsFolder.gameObject;
        val_13 = val_9;
        if(val_9.activeSelf != true)
        {
                val_13.SetActive(value:  true);
        }
        
        WADPetsScreenUI val_11 = MonoSingleton<WADPetsScreenUI>.Instance;
        val_11.screenStack.Push(item:  val_13);
    }

}

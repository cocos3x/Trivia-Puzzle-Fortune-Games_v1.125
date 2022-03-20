using UnityEngine;
[Serializable]
private sealed class CategoryPacksMenuUI.<>c__10<T>
{
    // Fields
    public static readonly CategoryPacksMenuUI.<>c__10<T> <>9;
    public static System.Action <>9__10_0;
    
    // Methods
    private static CategoryPacksMenuUI.<>c__10<T>()
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
    public CategoryPacksMenuUI.<>c__10<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    internal void <ShowScreen>b__10_0()
    {
        CategoryPacksMenuUI val_1 = MonoSingleton<CategoryPacksMenuUI>.Instance;
        UnityEngine.GameObject val_2 = val_1.prefabsFolder.gameObject;
        if(val_2.activeSelf != true)
        {
                val_2.SetActive(value:  true);
        }
        
        CategoryPacksMenuUI val_4 = MonoSingleton<CategoryPacksMenuUI>.Instance;
        val_4.screenStack.Push(item:  val_2);
    }

}

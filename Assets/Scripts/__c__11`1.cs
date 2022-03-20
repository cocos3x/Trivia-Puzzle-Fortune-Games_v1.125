using UnityEngine;
[Serializable]
private sealed class RaidAttackScreenUI.<>c__11<T>
{
    // Fields
    public static readonly RaidAttackScreenUI.<>c__11<T> <>9;
    public static System.Action <>9__11_1;
    
    // Methods
    private static RaidAttackScreenUI.<>c__11<T>()
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
    public RaidAttackScreenUI.<>c__11<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    internal void <ShowScreen>b__11_1()
    {
        MainController val_1 = MainController.instance;
        val_1.mainCamera.enabled = false;
        RaidAttackScreenUI val_2 = MonoSingleton<RaidAttackScreenUI>.Instance;
        UnityEngine.GameObject val_3 = val_2.prefabsFolder.gameObject;
        if(val_3.activeSelf != true)
        {
                val_3.SetActive(value:  true);
        }
        
        RaidAttackScreenUI val_5 = MonoSingleton<RaidAttackScreenUI>.Instance;
        val_5.screenStack.Push(item:  val_3);
        RaidAttackScreenUI val_6 = MonoSingleton<RaidAttackScreenUI>.Instance;
        val_6.screenTransition.WithdrawCurtains(delay:  1f, onComplete:  0);
    }

}

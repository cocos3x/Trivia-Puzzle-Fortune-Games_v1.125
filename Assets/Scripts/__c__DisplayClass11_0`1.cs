using UnityEngine;
private sealed class RaidAttackScreenUI.<>c__DisplayClass11_0<T>
{
    // Fields
    public WordForest.RaidAttackActionType sceneType;
    
    // Methods
    public RaidAttackScreenUI.<>c__DisplayClass11_0<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    internal void <ShowScreen>b__0()
    {
        var val_3;
        var val_4;
        System.Action val_5;
        var val_6;
        val_3 = __RuntimeMethodHiddenParam;
        RaidAttackScreenUI val_1 = MonoSingleton<RaidAttackScreenUI>.Instance;
        val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_4 & 1) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8];
        val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 184 + 8;
        if(val_5 == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_6 & 1) == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_6 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            System.Action val_2 = null;
            val_5 = val_2;
            val_2 = new System.Action(object:  __RuntimeMethodHiddenParam + 24 + 192 + 184, method:  __RuntimeMethodHiddenParam + 24 + 192 + 8);
            val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192];
            val_3 = __RuntimeMethodHiddenParam + 24 + 192;
            mem2[0] = val_5;
        }
        
        val_1.screenTransition.ExtendCurtains(sceneType:  this, onComplete:  val_2);
    }

}

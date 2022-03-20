using UnityEngine;
public abstract class WGGiftRewardManager<T>
{
    // Fields
    private static T _instance;
    
    // Properties
    public static T Instance { get; }
    
    // Methods
    public static T get_Instance()
    {
        var val_1;
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_1 & 1) == 0)
        {
                val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 302;
            val_3 = __RuntimeMethodHiddenParam + 24;
            if((val_2 & 1) == 0)
        {
                val_3 = mem[__RuntimeMethodHiddenParam + 24];
            val_3 = __RuntimeMethodHiddenParam + 24;
            val_2 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
            val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_4 & 1) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        }
        
        val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_5 & 1) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) != 0)
        {
                return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        
        return (object)__RuntimeMethodHiddenParam + 24 + 192 + 184;
    }
    public virtual void GenerateRewards()
    {
    
    }
    public virtual void CollectRewards()
    {
    
    }
    protected WGGiftRewardManager<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private static WGGiftRewardManager<T>()
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
        
        mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
    }

}

using UnityEngine;
public class MonoSingleton<T> : MonoSingleton
{
    // Fields
    protected static T _Instance;
    protected static bool searchedFailed;
    
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
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_4 & 1) == 0)
        {
                val_4 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_4 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184 + 8) == 0)
        {
                val_5 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 302;
            val_6 = __RuntimeMethodHiddenParam + 24;
            if((val_5 & 1) == 0)
        {
                val_6 = mem[__RuntimeMethodHiddenParam + 24];
            val_6 = __RuntimeMethodHiddenParam + 24;
            val_5 = mem[__RuntimeMethodHiddenParam + 24 + 302];
            val_5 = __RuntimeMethodHiddenParam + 24 + 302;
        }
        
            val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_7 & 1) == 0)
        {
                val_7 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_7 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = __RuntimeMethodHiddenParam + 24 + 192 + 16;
        }
        
        }
        
        val_8 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_8 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_8 & 1) == 0)
        {
                val_8 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_8 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) == 0)
        {
                val_9 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_9 & 1) == 0)
        {
                val_9 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            mem2[0] = 1;
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
                return (AdsUIController)__RuntimeMethodHiddenParam + 24 + 192 + 184;
        }
        
        return (AdsUIController)__RuntimeMethodHiddenParam + 24 + 192 + 184;
    }
    public virtual void Awake()
    {
        var val_8;
        var val_9;
        var val_10;
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        val_8 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_8 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_8 & 1) == 0)
        {
                val_8 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_8 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != 0)
        {
                val_9 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_9 & 1) == 0)
        {
                val_9 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            if((__RuntimeMethodHiddenParam + 24 + 192 + 184) != this)
        {
                val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_10 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
            if((val_10 & 1) == 0)
        {
                val_10 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_10 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
            UnityEngine.Debug.LogWarning(message:  this.gameObject.name + " - Another instance of this MonoSingleton already exists ("(" - Another instance of this MonoSingleton already exists (") + __RuntimeMethodHiddenParam + 24 + 192 + 184.name(__RuntimeMethodHiddenParam + 24 + 192 + 184.name) + ")", context:  __RuntimeMethodHiddenParam + 24 + 192 + 184);
            UnityEngine.Object.Destroy(obj:  this.gameObject);
            return;
        }
        
        }
        
        val_11 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
        val_11 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        if((val_11 & 1) == 0)
        {
                val_11 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 302];
            val_11 = __RuntimeMethodHiddenParam + 24 + 192 + 302;
        }
        
        val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192];
        val_12 = __RuntimeMethodHiddenParam + 24 + 192;
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
        {
                val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192];
            val_12 = __RuntimeMethodHiddenParam + 24 + 192;
        }
        
        val_13 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        if(X0 == false)
        {
            goto label_41;
        }
        
        val_13 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        if(X0 == true)
        {
            goto label_42;
        }
        
        val_13 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        label_41:
        val_14 = 0;
        label_42:
        mem2[0] = val_14;
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 302) & 1) == 0)
        {
            
        }
    
    }
    public override void InitMonoSingleton()
    {
    
    }
    public MonoSingleton<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }
    private static MonoSingleton<T>()
    {
    
    }

}

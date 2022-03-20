using UnityEngine;
public abstract class JsonSerializable<T>
{
    // Methods
    public string Serialize(Newtonsoft.Json.Formatting format = 1)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this, formatting:  format);
    }
    public static T Deserialize(string serialized)
    {
        var val_1;
        var val_2;
        var val_3;
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
        
        val_3 = mem[__RuntimeMethodHiddenParam + 24 + 192];
        val_3 = __RuntimeMethodHiddenParam + 24 + 192;
        if((val_1 & 1) == 0)
        {
                val_3 = val_3;
        }
    
    }
    protected JsonSerializable<T>()
    {
        if(this != null)
        {
                return;
        }
        
        throw new NullReferenceException();
    }

}

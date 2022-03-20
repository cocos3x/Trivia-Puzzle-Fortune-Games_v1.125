using UnityEngine;
[Serializable]
public class ConsumableAmountPair : SerializableKeyValuePair<string, System.Decimal>
{
    // Fields
    public int Scale;
    
    // Methods
    public ConsumableAmountPair(string key, decimal value, int scale = 1)
    {
        this.Scale = 1;
        mem[1152921515764457728] = key;
        mem[1152921515764457736] = value.flags;
        mem[1152921515764457740] = value.hi;
        mem[1152921515764457744] = value.lo;
        mem[1152921515764457748] = value.mid;
        this.Scale = scale;
    }

}

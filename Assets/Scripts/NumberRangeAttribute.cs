using UnityEngine;
public sealed class SROptions.NumberRangeAttribute : Attribute
{
    // Fields
    public readonly double Max;
    public readonly double Min;
    
    // Methods
    public SROptions.NumberRangeAttribute(double min, double max)
    {
        this.Max = max;
        this.Min = min;
    }

}

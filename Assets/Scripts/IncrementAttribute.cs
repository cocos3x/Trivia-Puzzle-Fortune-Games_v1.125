using UnityEngine;
public sealed class SROptions.IncrementAttribute : Attribute
{
    // Fields
    public readonly double Increment;
    
    // Methods
    public SROptions.IncrementAttribute(double increment)
    {
        this.Increment = increment;
    }

}

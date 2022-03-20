using UnityEngine;
public class ForestFrenzyWindowManager : SLCWindowManager<ForestFrenzyWindowManager>
{
    // Properties
    protected override System.Type myWindowType { get; }
    
    // Methods
    protected override System.Type get_myWindowType()
    {
        return System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
    }
    public ForestFrenzyWindowManager()
    {
    
    }

}

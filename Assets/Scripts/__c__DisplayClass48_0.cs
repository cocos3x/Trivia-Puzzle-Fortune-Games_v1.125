using UnityEngine;
private sealed class WFOForestManager.<>c__DisplayClass48_0
{
    // Fields
    public int forestId;
    
    // Methods
    public WFOForestManager.<>c__DisplayClass48_0()
    {
    
    }
    internal bool <GetForestLayout>b__0(WordForest.WFOForestContent n)
    {
        if(n != null)
        {
                return (bool)(n.forestId == this.forestId) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }

}

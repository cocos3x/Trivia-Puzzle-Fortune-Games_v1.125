using UnityEngine;
private sealed class WFOForestManager.<>c__DisplayClass44_0
{
    // Fields
    public int damagedTreeIdToFix;
    
    // Methods
    public WFOForestManager.<>c__DisplayClass44_0()
    {
    
    }
    internal bool <AddGrowth>b__0(WordForest.MapItem n)
    {
        var val_3;
        if(n.id == this.damagedTreeIdToFix)
        {
                if((System.String.op_Equality(a:  n.type, b:  "tree")) != false)
        {
                var val_2 = (n.status == 2) ? 1 : 0;
            return (bool)val_3;
        }
        
        }
        
        val_3 = 0;
        return (bool)val_3;
    }

}

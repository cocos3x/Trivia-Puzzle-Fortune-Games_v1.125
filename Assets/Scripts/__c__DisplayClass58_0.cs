using UnityEngine;
private sealed class LimitedTimeBundlesManager.<>c__DisplayClass58_0
{
    // Fields
    public PurchaseModel purchased;
    
    // Methods
    public LimitedTimeBundlesManager.<>c__DisplayClass58_0()
    {
    
    }
    internal bool <OnPurchaseCompleted>b__0(System.Collections.Generic.Dictionary<string, object> p)
    {
        return System.String.op_Equality(a:  p.Item["id"], b:  this.purchased.id);
    }

}

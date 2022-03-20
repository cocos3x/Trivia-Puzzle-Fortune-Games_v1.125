using UnityEngine;
private sealed class LimitedTimeBundlesManager.<>c__DisplayClass59_0
{
    // Fields
    public string bundleID;
    
    // Methods
    public LimitedTimeBundlesManager.<>c__DisplayClass59_0()
    {
    
    }
    internal bool <RollLetters>b__0(System.Collections.Generic.Dictionary<string, object> p)
    {
        return System.String.op_Equality(a:  p.Item["id"], b:  this.bundleID);
    }

}

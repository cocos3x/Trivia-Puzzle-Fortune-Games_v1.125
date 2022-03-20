using UnityEngine;
private sealed class WUTWordHuntEvent.<>c__DisplayClass2_0
{
    // Fields
    public string eventWord;
    
    // Methods
    public WUTWordHuntEvent.<>c__DisplayClass2_0()
    {
    
    }
    internal bool <OnGameSceneInit>b__0(object x)
    {
        return System.String.op_Equality(a:  x.ToLowerInvariant(), b:  this.eventWord.ToLowerInvariant());
    }

}

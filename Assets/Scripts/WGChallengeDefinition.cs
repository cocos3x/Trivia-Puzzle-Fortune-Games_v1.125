using UnityEngine;
public class WGChallengeDefinition : ScriptableObject
{
    // Fields
    private System.Collections.Generic.List<WGChallengeDefinition.PerChallengeInfo> info;
    
    // Methods
    public WGChallengeDefinition.PerChallengeInfo getInfoForType(ChallengeType cType)
    {
        .cType = cType;
        return System.Linq.Enumerable.First<PerChallengeInfo>(source:  this.info, predicate:  new System.Func<PerChallengeInfo, System.Boolean>(object:  new WGChallengeDefinition.<>c__DisplayClass1_0(), method:  System.Boolean WGChallengeDefinition.<>c__DisplayClass1_0::<getInfoForType>b__0(WGChallengeDefinition.PerChallengeInfo x)));
    }
    public WGChallengeDefinition()
    {
        this.info = new System.Collections.Generic.List<PerChallengeInfo>();
    }

}

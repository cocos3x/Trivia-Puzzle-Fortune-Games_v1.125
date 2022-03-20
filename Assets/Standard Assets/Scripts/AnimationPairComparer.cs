using UnityEngine;
private class AnimationStateData.AnimationPairComparer : IEqualityComparer<Spine.AnimationStateData.AnimationPair>
{
    // Fields
    internal static readonly Spine.AnimationStateData.AnimationPairComparer Instance;
    
    // Methods
    private bool System.Collections.Generic.IEqualityComparer<Spine.AnimationStateData.AnimationPair>.Equals(Spine.AnimationStateData.AnimationPair x, Spine.AnimationStateData.AnimationPair y)
    {
        return (bool)((x.a1 == y.a1) ? 1 : 0) & ((x.a2 == y.a2) ? 1 : 0);
    }
    private int System.Collections.Generic.IEqualityComparer<Spine.AnimationStateData.AnimationPair>.GetHashCode(Spine.AnimationStateData.AnimationPair obj)
    {
        Spine.Animation val_2 = obj.a2;
        val_2 = val_2 ^ (obj.a1 + (obj.a1 << 5));
        return (int)val_2;
    }
    public AnimationStateData.AnimationPairComparer()
    {
    
    }
    private static AnimationStateData.AnimationPairComparer()
    {
        AnimationStateData.AnimationPairComparer.Instance = new AnimationStateData.AnimationPairComparer();
    }

}

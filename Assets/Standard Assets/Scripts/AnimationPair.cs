using UnityEngine;
private struct AnimationStateData.AnimationPair
{
    // Fields
    public readonly Spine.Animation a1;
    public readonly Spine.Animation a2;
    
    // Methods
    public AnimationStateData.AnimationPair(Spine.Animation a1, Spine.Animation a2)
    {
        this = a1;
        this.a2 = a2;
    }
    public override string ToString()
    {
        return AnimationStateData.AnimationPair.__il2cppRuntimeField_byval_arg + "->"("->") + this.a2.name;
    }

}

using UnityEngine;
private class Skin.AttachmentKeyTupleComparer : IEqualityComparer<Spine.Skin.AttachmentKeyTuple>
{
    // Fields
    internal static readonly Spine.Skin.AttachmentKeyTupleComparer Instance;
    
    // Methods
    private bool System.Collections.Generic.IEqualityComparer<Spine.Skin.AttachmentKeyTuple>.Equals(Spine.Skin.AttachmentKeyTuple o1, Spine.Skin.AttachmentKeyTuple o2)
    {
        if(o1.slotIndex != mem[o1.name])
        {
                return false;
        }
        
        if((o1.slotIndex + 16) != o1.name.m_stringLength)
        {
                return false;
        }
        
        return System.String.op_Equality(a:  o1.slotIndex + 8, b:  mem[o1.name + 8]);
    }
    private int System.Collections.Generic.IEqualityComparer<Spine.Skin.AttachmentKeyTuple>.GetHashCode(Spine.Skin.AttachmentKeyTuple o)
    {
        return (int)o.slotIndex;
    }
    public Skin.AttachmentKeyTupleComparer()
    {
    
    }
    private static Skin.AttachmentKeyTupleComparer()
    {
        Skin.AttachmentKeyTupleComparer.Instance = new Skin.AttachmentKeyTupleComparer();
    }

}

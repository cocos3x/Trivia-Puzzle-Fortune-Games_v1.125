using UnityEngine;
[Serializable]
public struct SkeletonRendererCustomMaterials.SlotMaterialOverride : IEquatable<Spine.Unity.Modules.SkeletonRendererCustomMaterials.SlotMaterialOverride>
{
    // Fields
    public bool overrideDisabled;
    public string slotName;
    public UnityEngine.Material material;
    
    // Methods
    public bool Equals(Spine.Unity.Modules.SkeletonRendererCustomMaterials.SlotMaterialOverride other)
    {
        if(((new SkeletonRendererCustomMaterials.SlotMaterialOverride() == 0) ? 1 : 0) == ((other.overrideDisabled == true) ? 1 : 0))
        {
                return false;
        }
        
        if((System.String.op_Equality(a:  this.slotName, b:  other.slotName)) == false)
        {
                return false;
        }
        
        return UnityEngine.Object.op_Equality(x:  this.material, y:  other.material);
    }

}

using UnityEngine;
[Serializable]
public struct SkeletonRendererCustomMaterials.AtlasMaterialOverride : IEquatable<Spine.Unity.Modules.SkeletonRendererCustomMaterials.AtlasMaterialOverride>
{
    // Fields
    public bool overrideDisabled;
    public UnityEngine.Material originalMaterial;
    public UnityEngine.Material replacementMaterial;
    
    // Methods
    public bool Equals(Spine.Unity.Modules.SkeletonRendererCustomMaterials.AtlasMaterialOverride other)
    {
        UnityEngine.Material val_4;
        if(((new SkeletonRendererCustomMaterials.AtlasMaterialOverride() == 0) ? 1 : 0) == ((other.overrideDisabled == true) ? 1 : 0))
        {
                return false;
        }
        
        val_4 = this.originalMaterial;
        if(val_4 != other.originalMaterial)
        {
                return false;
        }
        
        return UnityEngine.Object.op_Equality(x:  this.replacementMaterial, y:  other.replacementMaterial);
    }

}

using UnityEngine;

namespace Spine.Unity
{
    public static class SpineMesh
    {
        // Fields
        internal const UnityEngine.HideFlags MeshHideflags = 20;
        
        // Methods
        public static UnityEngine.Mesh NewMesh()
        {
            UnityEngine.Mesh val_1 = new UnityEngine.Mesh();
            val_1.MarkDynamic();
            val_1.name = "Skeleton Mesh";
            val_1.hideFlags = 20;
            return val_1;
        }
    
    }

}

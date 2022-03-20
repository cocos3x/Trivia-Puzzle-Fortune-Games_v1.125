using UnityEngine;

namespace Spine.Unity
{
    public class MeshRendererBuffers : IDisposable
    {
        // Fields
        private Spine.Unity.DoubleBuffered<Spine.Unity.MeshRendererBuffers.SmartMesh> doubleBufferedMesh;
        internal readonly Spine.ExposedList<UnityEngine.Material> submeshMaterials;
        internal UnityEngine.Material[] sharedMaterials;
        
        // Methods
        public void Initialize()
        {
            this.doubleBufferedMesh = new Spine.Unity.DoubleBuffered<SmartMesh>();
        }
        public UnityEngine.Material[] GetUpdatedShaderdMaterialsArray()
        {
            UnityEngine.Material[] val_2;
            if(true == this.sharedMaterials.Length)
            {
                    this.submeshMaterials.CopyTo(array:  this.sharedMaterials);
                val_2 = this.sharedMaterials;
                return (UnityEngine.Material[])val_1;
            }
            
            T[] val_1 = this.submeshMaterials.ToArray();
            this.sharedMaterials = val_1;
            return (UnityEngine.Material[])val_1;
        }
        public bool MaterialsChangedInLastUpdate()
        {
            var val_2;
            if(W8 != this.sharedMaterials.Length)
            {
                goto label_7;
            }
            
            if(W8 < 1)
            {
                goto label_3;
            }
            
            var val_2 = 0;
            var val_1 = X11 + 32;
            label_8:
            if(((X11 + 32) + 0) != null)
            {
                goto label_7;
            }
            
            val_2 = val_2 + 1;
            if(val_2 < W8)
            {
                goto label_8;
            }
            
            label_3:
            val_2 = 0;
            return (bool)val_2;
            label_7:
            val_2 = 1;
            return (bool)val_2;
        }
        public void UpdateSharedMaterials(Spine.ExposedList<Spine.Unity.SubmeshInstruction> instructions)
        {
            var val_3;
            Spine.ExposedList<UnityEngine.Material> val_4;
            var val_5;
            val_3 = instructions;
            val_4 = this.submeshMaterials;
            if(41938944 > (X9 + 24))
            {
                    System.Array.Resize<UnityEngine.Material>(array: ref  T[] val_1 = this.submeshMaterials + 16, newSize:  41938944);
                val_4 = this.submeshMaterials;
            }
            
            mem2[0] = 41938944;
            if(41938944 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            val_5 = 41938944;
            var val_2 = X23 + 32;
            do
            {
                mem2[0] = null;
                val_3 = val_3 + 1;
            }
            while(val_3 < val_5);
        
        }
        public Spine.Unity.MeshRendererBuffers.SmartMesh GetNextMesh()
        {
            return this.doubleBufferedMesh.GetNext();
        }
        public void Clear()
        {
            this.sharedMaterials = new UnityEngine.Material[0];
            this.submeshMaterials.Clear(clearArray:  true);
        }
        public void Dispose()
        {
            if(this.doubleBufferedMesh == null)
            {
                    return;
            }
            
            this.doubleBufferedMesh.GetNext().Dispose();
            this.doubleBufferedMesh.GetNext().Dispose();
            this.doubleBufferedMesh = 0;
        }
        public MeshRendererBuffers()
        {
            this.submeshMaterials = new Spine.ExposedList<UnityEngine.Material>();
            this.sharedMaterials = new UnityEngine.Material[0];
        }
    
    }

}

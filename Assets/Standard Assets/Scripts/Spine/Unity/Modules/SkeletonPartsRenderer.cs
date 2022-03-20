using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonPartsRenderer : MonoBehaviour
    {
        // Fields
        private Spine.Unity.MeshGenerator meshGenerator;
        private UnityEngine.MeshRenderer meshRenderer;
        private UnityEngine.MeshFilter meshFilter;
        private Spine.Unity.MeshRendererBuffers buffers;
        private Spine.Unity.SkeletonRendererInstruction currentInstructions;
        
        // Properties
        public Spine.Unity.MeshGenerator MeshGenerator { get; }
        public UnityEngine.MeshRenderer MeshRenderer { get; }
        public UnityEngine.MeshFilter MeshFilter { get; }
        
        // Methods
        public Spine.Unity.MeshGenerator get_MeshGenerator()
        {
            this.LazyIntialize();
            return (Spine.Unity.MeshGenerator)this.meshGenerator;
        }
        public UnityEngine.MeshRenderer get_MeshRenderer()
        {
            this.LazyIntialize();
            return (UnityEngine.MeshRenderer)this.meshRenderer;
        }
        public UnityEngine.MeshFilter get_MeshFilter()
        {
            this.LazyIntialize();
            return (UnityEngine.MeshFilter)this.meshFilter;
        }
        private void LazyIntialize()
        {
            if(this.buffers != null)
            {
                    return;
            }
            
            Spine.Unity.MeshRendererBuffers val_1 = new Spine.Unity.MeshRendererBuffers();
            this.buffers = val_1;
            val_1.Initialize();
            if(this.meshGenerator != null)
            {
                    return;
            }
            
            this.meshGenerator = new Spine.Unity.MeshGenerator();
            this.meshFilter = this.GetComponent<UnityEngine.MeshFilter>();
            this.meshRenderer = this.GetComponent<UnityEngine.MeshRenderer>();
            this.currentInstructions.Clear();
        }
        public void ClearMesh()
        {
            this.LazyIntialize();
            this.meshFilter.sharedMesh = 0;
        }
        public void RenderParts(Spine.ExposedList<Spine.Unity.SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
        {
            Spine.ExposedList<Spine.Unity.SubmeshInstruction> val_10;
            bool val_11;
            Spine.Unity.SkeletonRendererInstruction val_12;
            Spine.Unity.SkeletonRendererInstruction val_13;
            Spine.Unity.SkeletonRendererInstruction val_14;
            val_10 = instructions;
            this.LazyIntialize();
            SmartMesh val_1 = this.buffers.GetNextMesh();
            this.currentInstructions.SetWithSubset(instructions:  val_10, startSubmesh:  startSubmesh, endSubmesh:  endSubmesh);
            val_11 = Spine.Unity.SkeletonRendererInstruction.GeometryNotEqual(a:  this.currentInstructions, b:  val_1.instructionUsed);
            this.meshGenerator.Begin();
            val_12 = this.currentInstructions;
            if(this.currentInstructions.hasActiveClipping == false)
            {
                goto label_7;
            }
            
            val_10 = 0;
            int val_3 = startSubmesh + 32;
            label_13:
            if(val_10 >= this.currentInstructions.submeshInstructions)
            {
                goto label_9;
            }
            
            val_10 = val_10 + 1;
            val_3 = val_3 + 48;
            this.meshGenerator.AddSubmesh(instruction:  new Spine.Unity.SubmeshInstruction() {skeleton = val_3, material = (startSubmesh + 32) + 16, forceSeparate = (startSubmesh + 32) + 16, preActiveClippingSlotSource = (startSubmesh + 32) + 16, rawTriangleCount = (startSubmesh + 32) + 16 + 16, rawVertexCount = (startSubmesh + 32) + 16 + 16, rawFirstVertexIndex = (startSubmesh + 32) + 16 + 16, hasClipping = (startSubmesh + 32) + 16 + 16}, updateTriangles:  val_11);
            val_13 = this.currentInstructions;
            if(val_13 != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_7:
            this.meshGenerator.BuildMeshWithArrays(instruction:  val_13, updateTriangles:  val_11);
            val_14 = this.currentInstructions;
            label_9:
            this.buffers.UpdateSharedMaterials(instructions:  this.currentInstructions.submeshInstructions);
            if(this.meshGenerator.VertexCount <= 0)
            {
                goto label_18;
            }
            
            this.meshGenerator.FillVertexData(mesh:  val_1.mesh);
            if(val_11 == false)
            {
                goto label_20;
            }
            
            this.meshGenerator.FillTriangles(mesh:  val_1.mesh);
            goto label_22;
            label_18:
            val_1.mesh.Clear();
            goto label_26;
            label_20:
            if(this.buffers.MaterialsChangedInLastUpdate() == false)
            {
                goto label_26;
            }
            
            label_22:
            val_11 = this.meshRenderer;
            val_11.sharedMaterials = this.buffers.GetUpdatedShaderdMaterialsArray();
            label_26:
            this.meshFilter.sharedMesh = val_1.mesh;
            val_1.instructionUsed.Set(other:  this.currentInstructions);
        }
        public void SetPropertyBlock(UnityEngine.MaterialPropertyBlock block)
        {
            this.LazyIntialize();
            this.meshRenderer.SetPropertyBlock(properties:  block);
        }
        public static Spine.Unity.Modules.SkeletonPartsRenderer NewPartsRendererGameObject(UnityEngine.Transform parent, string name)
        {
            System.Type[] val_1 = new System.Type[2];
            val_1[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[1] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            UnityEngine.GameObject val_4 = new UnityEngine.GameObject(name:  name, components:  val_1);
            val_4.transform.SetParent(parent:  parent, worldPositionStays:  false);
            return val_4.AddComponent<Spine.Unity.Modules.SkeletonPartsRenderer>();
        }
        public SkeletonPartsRenderer()
        {
            this.currentInstructions = new Spine.Unity.SkeletonRendererInstruction();
        }
    
    }

}

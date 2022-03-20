using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonRenderSeparator : MonoBehaviour
    {
        // Fields
        public const int DefaultSortingOrderIncrement = 5;
        protected Spine.Unity.SkeletonRenderer skeletonRenderer;
        private UnityEngine.MeshRenderer mainMeshRenderer;
        public bool copyPropertyBlock;
        public bool copyMeshRendererFlags;
        public System.Collections.Generic.List<Spine.Unity.Modules.SkeletonPartsRenderer> partsRenderers;
        private UnityEngine.MaterialPropertyBlock copiedBlock;
        
        // Properties
        public Spine.Unity.SkeletonRenderer SkeletonRenderer { get; set; }
        
        // Methods
        public Spine.Unity.SkeletonRenderer get_SkeletonRenderer()
        {
            return (Spine.Unity.SkeletonRenderer)this.skeletonRenderer;
        }
        public void set_SkeletonRenderer(Spine.Unity.SkeletonRenderer value)
        {
            if(this.skeletonRenderer != 0)
            {
                    mem[1152921513302188800] = this;
                mem[1152921513302188808] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
                mem[1152921513302188784] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
                this.skeletonRenderer.remove_GenerateMeshOverride(value:  new SkeletonRenderer.InstructionDelegate());
            }
            
            this.skeletonRenderer = value;
            this.enabled = false;
        }
        public static Spine.Unity.Modules.SkeletonRenderSeparator AddToSkeletonRenderer(Spine.Unity.SkeletonRenderer skeletonRenderer, int sortingLayerID = 0, int extraPartsRenderers = 0, int sortingOrderIncrement = 5, int baseSortingOrder = 0, bool addMinimumPartsRenderers = True)
        {
            System.Collections.Generic.List<Spine.Unity.Modules.SkeletonPartsRenderer> val_8;
            var val_9;
            var val_10;
            val_8 = addMinimumPartsRenderers;
            val_9 = extraPartsRenderers;
            if(skeletonRenderer == 0)
            {
                    UnityEngine.Debug.Log(message:  "Tried to add SkeletonRenderSeparator to a null SkeletonRenderer reference.");
                val_10 = 0;
                return (Spine.Unity.Modules.SkeletonRenderSeparator)val_10;
            }
            
            val_3.skeletonRenderer = skeletonRenderer;
            val_10 = skeletonRenderer.gameObject.AddComponent<Spine.Unity.Modules.SkeletonRenderSeparator>();
            if(val_8 != false)
            {
                    System.Collections.Generic.List<Spine.Slot> val_8 = skeletonRenderer.separatorSlots;
                val_8 = val_9 + val_8;
                val_9 = val_8 + 1;
            }
            
            val_8 = val_3.partsRenderers;
            if(val_9 < 1)
            {
                    return (Spine.Unity.Modules.SkeletonRenderSeparator)val_10;
            }
            
            do
            {
                Spine.Unity.Modules.SkeletonPartsRenderer val_6 = Spine.Unity.Modules.SkeletonPartsRenderer.NewPartsRendererGameObject(parent:  skeletonRenderer.transform, name:  0.ToString());
                val_6.LazyIntialize();
                val_6.meshRenderer.sortingLayerID = sortingLayerID;
                val_6.meshRenderer.sortingOrder = baseSortingOrder + (0 * sortingOrderIncrement);
                val_8.Add(item:  val_6);
            }
            while(1 < val_9);
            
            return (Spine.Unity.Modules.SkeletonRenderSeparator)val_10;
        }
        private void OnEnable()
        {
            UnityEngine.Rendering.ReflectionProbeUsage val_12;
            if(this.skeletonRenderer == 0)
            {
                    return;
            }
            
            if(this.copiedBlock == null)
            {
                    this.copiedBlock = new UnityEngine.MaterialPropertyBlock();
            }
            
            this.mainMeshRenderer = this.skeletonRenderer.GetComponent<UnityEngine.MeshRenderer>();
            val_12 = 1152921504867229696;
            mem[1152921513302607584] = this;
            mem[1152921513302607592] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            mem[1152921513302607568] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            this.skeletonRenderer.remove_GenerateMeshOverride(value:  new SkeletonRenderer.InstructionDelegate());
            mem[1152921513302615776] = this;
            mem[1152921513302615784] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            mem[1152921513302615760] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            this.skeletonRenderer.add_GenerateMeshOverride(value:  new SkeletonRenderer.InstructionDelegate());
            if(this.copyMeshRendererFlags == false)
            {
                    return;
            }
            
            val_12 = this.mainMeshRenderer.reflectionProbeUsage;
            UnityEngine.MeshRenderer val_12 = this.mainMeshRenderer;
            var val_13 = 0;
            do
            {
                if(val_13 >= val_12)
            {
                    return;
            }
            
                val_12 = val_12 & 4294967295;
                if(val_13 >= val_12)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg != 0)
            {
                    UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg.LazyIntialize();
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.lightProbeUsage = this.mainMeshRenderer.lightProbeUsage;
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.receiveShadows = this.mainMeshRenderer.receiveShadows;
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.reflectionProbeUsage = val_12;
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.shadowCastingMode = this.mainMeshRenderer.shadowCastingMode;
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.motionVectorGenerationMode = this.mainMeshRenderer.motionVectorGenerationMode;
                UnityEngine.MeshRenderer.__il2cppRuntimeField_byval_arg + 32.probeAnchor = val_12.probeAnchor;
            }
            
                val_13 = val_13 + 1;
            }
            while(this.partsRenderers != null);
            
            throw new NullReferenceException();
        }
        private void OnDisable()
        {
            Spine.Unity.Modules.SkeletonRenderSeparator val_4 = this;
            if(this.skeletonRenderer == 0)
            {
                    return;
            }
            
            mem[1152921513302812768] = val_4;
            mem[1152921513302812776] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            mem[1152921513302812752] = System.Void Spine.Unity.Modules.SkeletonRenderSeparator::HandleRender(Spine.Unity.SkeletonRendererInstruction instruction);
            this.skeletonRenderer.remove_GenerateMeshOverride(value:  new SkeletonRenderer.InstructionDelegate());
            List.Enumerator<T> val_2 = this.partsRenderers.GetEnumerator();
            val_4 = 1152921513302746496;
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_6;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            0.ClearMesh();
            goto label_8;
            label_6:
            0.Dispose();
        }
        private void HandleRender(Spine.Unity.SkeletonRendererInstruction instruction)
        {
            Spine.Unity.SkeletonRendererInstruction val_5;
            Spine.Unity.MeshGeneratorDelegate val_6;
            var val_7;
            val_5 = instruction;
            if(W24 < 1)
            {
                    return;
            }
            
            if(this.copyPropertyBlock != false)
            {
                    this.mainMeshRenderer.GetPropertyBlock(properties:  this.copiedBlock);
            }
            
            Spine.Unity.SkeletonRenderer val_1 = this.skeletonRenderer - 1;
            if(W10 == 0)
            {
                goto label_9;
            }
            
            if((val_1 & 2147483648) != 0)
            {
                goto label_10;
            }
            
            label_24:
            val_6 = this.skeletonRenderer.OnPostProcessVertices;
            val_7 = 0;
            label_22:
            if(0 == val_1)
            {
                goto label_14;
            }
            
            var val_5 = 48;
            val_5 = X26 + (0 * val_5);
            if(((0 * 48) + X26 + 56) != 0)
            {
                goto label_14;
            }
            
            val_5 = 0 + 1;
            goto label_15;
            label_14:
            val_6.LazyIntialize();
            mem2[0] = 1;
            mem2[0] = (this.skeletonRenderer.addNormals << 24) | this.skeletonRenderer.pmaVertexColors;
            mem[1] = this.skeletonRenderer.tintBlack;
            if(this.copyPropertyBlock != false)
            {
                    val_6.SetPropertyBlock(block:  this.copiedBlock);
            }
            
            Spine.Unity.SkeletonRendererInstruction val_6 = val_5;
            val_5 = 0 + 1;
            val_6.RenderParts(instructions:  instruction + 24, startSubmesh:  0, endSubmesh:  val_5);
            val_7 = val_7 + 1;
            if(val_7 >= W24)
            {
                goto label_23;
            }
            
            if(val_6 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (val_7 << 3);
            val_6 = mem[(instruction + ((val_7 + 1)) << 3) + 32];
            val_6 = (instruction + ((val_7 + 1)) << 3) + 32;
            label_15:
            if(val_5 <= val_1)
            {
                goto label_22;
            }
            
            goto label_23;
            label_9:
            val_6 = this.skeletonRenderer.zSpacing;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if((val_1 & 2147483648) == 0)
            {
                goto label_24;
            }
            
            label_10:
            val_7 = 0;
            label_23:
            if(val_7 >= W24)
            {
                    return;
            }
            
            Spine.ExposedList<Spine.Unity.SubmeshInstruction> val_4 = instruction.submeshInstructions + 32;
            do
            {
                val_5 = this.partsRenderers;
                if(instruction.submeshInstructions <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                1152921504864034816.ClearMesh();
                val_7 = val_7 + 1;
                val_4 = val_4 + 8;
            }
            while(val_7 < W24);
        
        }
        public SkeletonRenderSeparator()
        {
            this.copyPropertyBlock = true;
            this.copyMeshRendererFlags = true;
            this.partsRenderers = new System.Collections.Generic.List<Spine.Unity.Modules.SkeletonPartsRenderer>();
        }
    
    }

}

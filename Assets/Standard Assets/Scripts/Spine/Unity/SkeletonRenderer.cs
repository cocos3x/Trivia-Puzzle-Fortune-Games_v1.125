using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonRenderer : MonoBehaviour, ISkeletonComponent
    {
        // Fields
        private Spine.Unity.SkeletonRenderer.SkeletonRendererDelegate OnRebuild;
        private Spine.Unity.MeshGeneratorDelegate OnPostProcessVertices;
        public Spine.Unity.SkeletonDataAsset skeletonDataAsset;
        public string initialSkinName;
        public bool initialFlipX;
        public bool initialFlipY;
        public string[] separatorSlotNames;
        public readonly System.Collections.Generic.List<Spine.Slot> separatorSlots;
        public float zSpacing;
        public bool useClipping;
        public bool immutableTriangles;
        public bool pmaVertexColors;
        public bool clearStateOnDisable;
        public bool tintBlack;
        public bool singleSubmesh;
        public bool addNormals;
        public bool calculateTangents;
        public bool logErrors;
        public bool disableRenderingOnOverride;
        private Spine.Unity.SkeletonRenderer.InstructionDelegate generateMeshOverride;
        private readonly System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material> customMaterialOverride;
        private readonly System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material> customSlotMaterials;
        private UnityEngine.MeshRenderer meshRenderer;
        private UnityEngine.MeshFilter meshFilter;
        public bool valid;
        public Spine.Skeleton skeleton;
        private readonly Spine.Unity.SkeletonRendererInstruction currentInstructions;
        private readonly Spine.Unity.MeshGenerator meshGenerator;
        private readonly Spine.Unity.MeshRendererBuffers rendererBuffers;
        
        // Properties
        public Spine.Unity.SkeletonDataAsset SkeletonDataAsset { get; }
        public System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material> CustomMaterialOverride { get; }
        public System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material> CustomSlotMaterials { get; }
        public Spine.Skeleton Skeleton { get; }
        
        // Methods
        public void add_OnRebuild(Spine.Unity.SkeletonRenderer.SkeletonRendererDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OnRebuild, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnRebuild != 1152921513270726376);
            
            return;
            label_2:
        }
        public void remove_OnRebuild(Spine.Unity.SkeletonRenderer.SkeletonRendererDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OnRebuild, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnRebuild != 1152921513270862952);
            
            return;
            label_2:
        }
        public void add_OnPostProcessVertices(Spine.Unity.MeshGeneratorDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OnPostProcessVertices, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnPostProcessVertices != 1152921513270999536);
            
            return;
            label_2:
        }
        public void remove_OnPostProcessVertices(Spine.Unity.MeshGeneratorDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OnPostProcessVertices, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnPostProcessVertices != 1152921513271136112);
            
            return;
            label_2:
        }
        public Spine.Unity.SkeletonDataAsset get_SkeletonDataAsset()
        {
            return (Spine.Unity.SkeletonDataAsset)this.skeletonDataAsset;
        }
        private void add_generateMeshOverride(Spine.Unity.SkeletonRenderer.InstructionDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.generateMeshOverride, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.generateMeshOverride != 1152921513271392944);
            
            return;
            label_2:
        }
        private void remove_generateMeshOverride(Spine.Unity.SkeletonRenderer.InstructionDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.generateMeshOverride, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.generateMeshOverride != 1152921513271529520);
            
            return;
            label_2:
        }
        public void add_GenerateMeshOverride(Spine.Unity.SkeletonRenderer.InstructionDelegate value)
        {
            this.add_generateMeshOverride(value:  value);
            if(this.disableRenderingOnOverride == false)
            {
                    return;
            }
            
            if(this.generateMeshOverride == null)
            {
                    return;
            }
            
            this.meshRenderer.enabled = false;
        }
        public void remove_GenerateMeshOverride(Spine.Unity.SkeletonRenderer.InstructionDelegate value)
        {
            this.remove_generateMeshOverride(value:  value);
            if(this.disableRenderingOnOverride == false)
            {
                    return;
            }
            
            if(this.generateMeshOverride != null)
            {
                    return;
            }
            
            this.meshRenderer.enabled = true;
        }
        public System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material> get_CustomMaterialOverride()
        {
            return (System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material>)this.customMaterialOverride;
        }
        public System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material> get_CustomSlotMaterials()
        {
            return (System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material>)this.customSlotMaterials;
        }
        public Spine.Skeleton get_Skeleton()
        {
            return (Spine.Skeleton)this.skeleton;
        }
        public static T NewSpineGameObject<T>(Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "New Spine GameObject");
            goto __RuntimeMethodHiddenParam + 48;
        }
        public static T AddSpineComponent<T>(UnityEngine.GameObject gameObject, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            if(skeletonDataAsset == 0)
            {
                    return (Spine.Unity.SkeletonAnimation)gameObject;
            }
            
            mem2[0] = skeletonDataAsset;
            return (Spine.Unity.SkeletonAnimation)gameObject;
        }
        public virtual void Awake()
        {
            goto typeof(Spine.Unity.SkeletonRenderer).__il2cppRuntimeField_1B0;
        }
        private void OnDisable()
        {
            if(this.clearStateOnDisable == false)
            {
                    return;
            }
            
            if(this.valid == false)
            {
                    return;
            }
            
            goto typeof(Spine.Unity.SkeletonRenderer).__il2cppRuntimeField_1A0;
        }
        private void OnDestroy()
        {
            if(this.rendererBuffers != null)
            {
                    this.rendererBuffers.Dispose();
                return;
            }
            
            throw new NullReferenceException();
        }
        protected virtual void ClearState()
        {
            this.meshFilter.sharedMesh = 0;
            this.currentInstructions.Clear();
            if(this.skeleton == null)
            {
                    return;
            }
            
            this.skeleton.SetToSetupPose();
        }
        public virtual void Initialize(bool overwrite)
        {
            var val_12;
            if((this.valid != false) && (overwrite != true))
            {
                    return;
            }
            
            if(this.meshFilter != 0)
            {
                    this.meshFilter.sharedMesh = 0;
            }
            
            val_12 = 1152921513273009168;
            UnityEngine.MeshRenderer val_2 = this.GetComponent<UnityEngine.MeshRenderer>();
            this.meshRenderer = val_2;
            if(val_2 != 0)
            {
                    this.meshRenderer.sharedMaterial = 0;
            }
            
            this.currentInstructions.Clear();
            this.rendererBuffers.Clear();
            this.meshGenerator.Begin();
            this.skeleton = 0;
            this.valid = false;
            if((UnityEngine.Object.op_Implicit(exists:  this.skeletonDataAsset)) == false)
            {
                goto label_16;
            }
            
            Spine.SkeletonData val_5 = this.skeletonDataAsset.GetSkeletonData(quiet:  false);
            if(val_5 == null)
            {
                    return;
            }
            
            this.valid = true;
            this.meshFilter = this.GetComponent<UnityEngine.MeshFilter>();
            this.meshRenderer = this.GetComponent<UnityEngine.MeshRenderer>();
            this.rendererBuffers.Initialize();
            .flipX = this.initialFlipX;
            .flipY = this.initialFlipY;
            this.skeleton = new Spine.Skeleton(data:  val_5);
            if((System.String.IsNullOrEmpty(value:  this.initialSkinName)) != true)
            {
                    if((System.String.Equals(a:  this.initialSkinName, b:  "default", comparisonType:  4)) != true)
            {
                    this.skeleton.SetSkin(skinName:  this.initialSkinName);
            }
            
            }
            
            this.separatorSlots.Clear();
            label_30:
            if(0 >= (this.separatorSlotNames.Length << ))
            {
                goto label_26;
            }
            
            this.separatorSlots.Add(item:  this.skeleton.FindSlot(slotName:  this.separatorSlotNames[0]));
            val_12 = 0 + 1;
            if(this.separatorSlotNames != null)
            {
                goto label_30;
            }
            
            throw new NullReferenceException();
            label_16:
            if(this.logErrors == false)
            {
                    return;
            }
            
            UnityEngine.Debug.LogError(message:  "Missing SkeletonData asset.", context:  this);
            return;
            label_26:
            if(this.OnRebuild == null)
            {
                    return;
            }
            
            this.OnRebuild.Invoke(skeletonRenderer:  this);
        }
        public virtual void LateUpdate()
        {
            InstructionDelegate val_15;
            bool val_16;
            if(this.valid == false)
            {
                    return;
            }
            
            val_15 = this.generateMeshOverride;
            if(val_15 == null)
            {
                    if(this.meshRenderer.enabled == false)
            {
                    return;
            }
            
            }
            
            SmartMesh val_2 = this.rendererBuffers.GetNextMesh();
            if(this.singleSubmesh == false)
            {
                goto label_7;
            }
            
            Spine.Unity.AtlasAsset val_12 = this.skeletonDataAsset.atlasAssets[0];
            Spine.Unity.MeshGenerator.GenerateSingleSubmeshInstruction(instructionOutput:  this.currentInstructions, skeleton:  this.skeleton, material:  this.skeletonDataAsset.atlasAssets[0].materials[0]);
            if(this.customMaterialOverride.Count >= 1)
            {
                    Spine.Unity.MeshGenerator.TryReplaceMaterials(workingSubmeshInstructions:  this.currentInstructions.submeshInstructions, customMaterialOverride:  this.customMaterialOverride);
            }
            
            this.meshGenerator.settings = this.useClipping;
            mem2[0] = this.pmaVertexColors;
            mem[1] = this.tintBlack;
            mem[2] = this.calculateTangents;
            mem[3] = this.addNormals;
            this.meshGenerator.Begin();
            val_15 = Spine.Unity.SkeletonRendererInstruction.GeometryNotEqual(a:  this.currentInstructions, b:  val_2.instructionUsed);
            if(this.currentInstructions.hasActiveClipping == false)
            {
                goto label_19;
            }
            
            this.meshGenerator.AddSubmesh(instruction:  new Spine.Unity.SubmeshInstruction() {skeleton = this.currentInstructions.hasActiveClipping + 32, startSlot = this.currentInstructions.hasActiveClipping + 32, endSlot = this.currentInstructions.hasActiveClipping + 32, material = this.currentInstructions.hasActiveClipping + 48, forceSeparate = this.currentInstructions.hasActiveClipping + 48, preActiveClippingSlotSource = this.currentInstructions.hasActiveClipping + 48, rawTriangleCount = this.currentInstructions.hasActiveClipping + 48 + 16, rawVertexCount = this.currentInstructions.hasActiveClipping + 48 + 16, rawFirstVertexIndex = this.currentInstructions.hasActiveClipping + 48 + 16, hasClipping = this.currentInstructions.hasActiveClipping + 48 + 16}, updateTriangles:  val_15);
            goto label_35;
            label_7:
            Spine.Unity.MeshGenerator.GenerateSkeletonRendererInstruction(instructionOutput:  this.currentInstructions, skeleton:  this.skeleton, customSlotMaterials:  this.customSlotMaterials, separatorSlots:  this.separatorSlots, generateMeshOverride:  (val_15 != 0) ? 1 : 0, immutableTriangles:  this.immutableTriangles);
            if(this.customMaterialOverride.Count >= 1)
            {
                    Spine.Unity.MeshGenerator.TryReplaceMaterials(workingSubmeshInstructions:  this.currentInstructions.submeshInstructions, customMaterialOverride:  this.customMaterialOverride);
            }
            
            if(val_15 != null)
            {
                    this.generateMeshOverride.Invoke(instruction:  this.currentInstructions);
                if(this.disableRenderingOnOverride == true)
            {
                    return;
            }
            
            }
            
            this.meshGenerator.settings = this.useClipping;
            mem2[0] = this.pmaVertexColors;
            mem[1] = this.tintBlack;
            mem[2] = this.calculateTangents;
            mem[3] = this.addNormals;
            val_15 = Spine.Unity.SkeletonRendererInstruction.GeometryNotEqual(a:  this.currentInstructions, b:  val_2.instructionUsed);
            this.meshGenerator.Begin();
            if(this.currentInstructions.hasActiveClipping == false)
            {
                goto label_34;
            }
            
            this.meshGenerator.BuildMesh(instruction:  this.currentInstructions, updateTriangles:  val_15);
            goto label_35;
            label_19:
            val_16 = val_15;
            goto label_37;
            label_34:
            val_16 = val_15;
            label_37:
            this.meshGenerator.BuildMeshWithArrays(instruction:  this.currentInstructions, updateTriangles:  val_16);
            label_35:
            if(this.OnPostProcessVertices != null)
            {
                    this.OnPostProcessVertices.Invoke(meshGenerator:  this.meshGenerator);
            }
            
            this.meshGenerator.FillVertexData(mesh:  val_2.mesh);
            this.rendererBuffers.UpdateSharedMaterials(instructions:  this.currentInstructions.submeshInstructions);
            if(val_15 == false)
            {
                goto label_41;
            }
            
            this.meshGenerator.FillTriangles(mesh:  val_2.mesh);
            goto label_43;
            label_41:
            if(this.rendererBuffers.MaterialsChangedInLastUpdate() == false)
            {
                goto label_45;
            }
            
            label_43:
            this.meshRenderer.sharedMaterials = this.rendererBuffers.GetUpdatedShaderdMaterialsArray();
            label_45:
            this.meshFilter.sharedMesh = val_2.mesh;
            val_2.instructionUsed.Set(other:  this.currentInstructions);
        }
        public SkeletonRenderer()
        {
            this.separatorSlotNames = new string[0];
            this.separatorSlots = new System.Collections.Generic.List<Spine.Slot>();
            this.useClipping = true;
            this.pmaVertexColors = true;
            this.disableRenderingOnOverride = true;
            this.customMaterialOverride = new System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material>();
            this.customSlotMaterials = new System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material>();
            this.currentInstructions = new Spine.Unity.SkeletonRendererInstruction();
            this.meshGenerator = new Spine.Unity.MeshGenerator();
            this.rendererBuffers = new Spine.Unity.MeshRendererBuffers();
        }
    
    }

}

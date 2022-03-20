using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonGraphic : MaskableGraphic, ISkeletonComponent, IAnimationStateComponent, ISkeletonAnimation
    {
        // Fields
        public Spine.Unity.SkeletonDataAsset skeletonDataAsset;
        public string initialSkinName;
        public bool initialFlipX;
        public bool initialFlipY;
        public string startingAnimation;
        public bool startingLoop;
        public float timeScale;
        public bool freeze;
        public bool unscaledTime;
        private UnityEngine.Texture <OverrideTexture>k__BackingField;
        protected Spine.Skeleton skeleton;
        protected Spine.AnimationState state;
        protected Spine.Unity.MeshGenerator meshGenerator;
        private Spine.Unity.DoubleBuffered<Spine.Unity.MeshRendererBuffers.SmartMesh> meshBuffers;
        private Spine.Unity.SkeletonRendererInstruction currentInstructions;
        private Spine.Unity.UpdateBonesDelegate UpdateLocal;
        private Spine.Unity.UpdateBonesDelegate UpdateWorld;
        private Spine.Unity.UpdateBonesDelegate UpdateComplete;
        private Spine.Unity.MeshGeneratorDelegate OnPostProcessVertices;
        
        // Properties
        public Spine.Unity.SkeletonDataAsset SkeletonDataAsset { get; }
        public UnityEngine.Texture OverrideTexture { get; set; }
        public override UnityEngine.Texture mainTexture { get; }
        public Spine.Skeleton Skeleton { get; }
        public Spine.SkeletonData SkeletonData { get; }
        public bool IsValid { get; }
        public Spine.AnimationState AnimationState { get; }
        public Spine.Unity.MeshGenerator MeshGenerator { get; }
        
        // Methods
        public Spine.Unity.SkeletonDataAsset get_SkeletonDataAsset()
        {
            return (Spine.Unity.SkeletonDataAsset)this.skeletonDataAsset;
        }
        public static Spine.Unity.SkeletonGraphic NewSkeletonGraphicGameObject(Spine.Unity.SkeletonDataAsset skeletonDataAsset, UnityEngine.Transform parent)
        {
            Spine.Unity.SkeletonGraphic val_2 = Spine.Unity.SkeletonGraphic.AddSkeletonGraphicComponent(gameObject:  new UnityEngine.GameObject(name:  "New Spine GameObject"), skeletonDataAsset:  skeletonDataAsset);
            if(parent == 0)
            {
                    return val_2;
            }
            
            val_2.transform.SetParent(parent:  parent, worldPositionStays:  false);
            return val_2;
        }
        public static Spine.Unity.SkeletonGraphic AddSkeletonGraphicComponent(UnityEngine.GameObject gameObject, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            Spine.Unity.SkeletonGraphic val_1 = gameObject.AddComponent<Spine.Unity.SkeletonGraphic>();
            if(skeletonDataAsset == 0)
            {
                    return val_1;
            }
            
            val_1.skeletonDataAsset = skeletonDataAsset;
            val_1.Initialize(overwrite:  false);
            return val_1;
        }
        public UnityEngine.Texture get_OverrideTexture()
        {
            return (UnityEngine.Texture)this.<OverrideTexture>k__BackingField;
        }
        public void set_OverrideTexture(UnityEngine.Texture value)
        {
            this.<OverrideTexture>k__BackingField = value;
        }
        public override UnityEngine.Texture get_mainTexture()
        {
            UnityEngine.Texture val_3;
            if((this.<OverrideTexture>k__BackingField) != 0)
            {
                    val_3 = this.<OverrideTexture>k__BackingField;
                return (UnityEngine.Texture)val_3;
            }
            
            val_3 = 0;
            if(this.skeletonDataAsset == 0)
            {
                    return (UnityEngine.Texture)val_3;
            }
            
            Spine.Unity.AtlasAsset val_3 = this.skeletonDataAsset.atlasAssets[0];
            return this.skeletonDataAsset.atlasAssets[0].materials[0].mainTexture;
        }
        protected override void Awake()
        {
            this.Awake();
            if(this.skeleton != null)
            {
                    return;
            }
            
            this.Initialize(overwrite:  false);
            goto typeof(Spine.Unity.SkeletonGraphic).__il2cppRuntimeField_380;
        }
        public override void Rebuild(UnityEngine.UI.CanvasUpdate update)
        {
            this.Rebuild(update:  update);
            if(update != 3)
            {
                    return;
            }
            
            if(this.canvasRenderer.cull == true)
            {
                    return;
            }
            
            this.UpdateMesh();
        }
        public virtual void Update()
        {
            if(this.freeze != false)
            {
                    return;
            }
            
            if(this.unscaledTime != false)
            {
                    float val_1 = UnityEngine.Time.unscaledDeltaTime;
            }
            else
            {
                    float val_2 = UnityEngine.Time.deltaTime;
            }
        
        }
        public virtual void Update(float deltaTime)
        {
            if(this.skeleton == null)
            {
                    return;
            }
            
            float val_1 = this.timeScale * deltaTime;
            this.skeleton.Update(delta:  val_1);
            this.state.Update(delta:  val_1);
            bool val_2 = this.state.Apply(skeleton:  this.skeleton);
            if(this.UpdateLocal != null)
            {
                    this.UpdateLocal.Invoke(animated:  this);
            }
            
            this.skeleton.UpdateWorldTransform();
            if(this.UpdateWorld != null)
            {
                    this.UpdateWorld.Invoke(animated:  this);
                this.skeleton.UpdateWorldTransform();
            }
            
            if(this.UpdateComplete == null)
            {
                    return;
            }
            
            this.UpdateComplete.Invoke(animated:  this);
        }
        public void LateUpdate()
        {
            if(this.freeze != false)
            {
                    return;
            }
            
            this.UpdateMesh();
        }
        public Spine.Skeleton get_Skeleton()
        {
            return (Spine.Skeleton)this.skeleton;
        }
        public Spine.SkeletonData get_SkeletonData()
        {
            if(this.skeleton == null)
            {
                    return 0;
            }
            
            return (Spine.SkeletonData)this.skeleton.data;
        }
        public bool get_IsValid()
        {
            return (bool)(this.skeleton != 0) ? 1 : 0;
        }
        public Spine.AnimationState get_AnimationState()
        {
            return (Spine.AnimationState)this.state;
        }
        public Spine.Unity.MeshGenerator get_MeshGenerator()
        {
            return (Spine.Unity.MeshGenerator)this.meshGenerator;
        }
        public UnityEngine.Mesh GetLastMesh()
        {
            SmartMesh val_1 = this.meshBuffers.GetCurrent();
            return (UnityEngine.Mesh)val_1.mesh;
        }
        public void add_UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.UpdateLocal, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateLocal != this.UpdateLocal);
            
            return;
            label_2:
        }
        public void remove_UpdateLocal(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.UpdateLocal, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateLocal != this.UpdateLocal);
            
            return;
            label_2:
        }
        public void add_UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.UpdateWorld, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateWorld != this.UpdateWorld);
            
            return;
            label_2:
        }
        public void remove_UpdateWorld(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.UpdateWorld, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateWorld != this.UpdateWorld);
            
            return;
            label_2:
        }
        public void add_UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.UpdateComplete, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateComplete != this.UpdateComplete);
            
            return;
            label_2:
        }
        public void remove_UpdateComplete(Spine.Unity.UpdateBonesDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.UpdateComplete, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.UpdateComplete != this.UpdateComplete);
            
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
            while(this.OnPostProcessVertices != this.OnPostProcessVertices);
            
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
            while(this.OnPostProcessVertices != this.OnPostProcessVertices);
            
            return;
            label_2:
        }
        public void Clear()
        {
            this.skeleton = 0;
            this.canvasRenderer.Clear();
        }
        public void Initialize(bool overwrite)
        {
            Spine.Unity.SkeletonDataAsset val_10;
            Spine.AnimationStateData val_11;
            if(this.skeleton != null)
            {
                    if(overwrite == false)
            {
                    return;
            }
            
            }
            
            if(this.skeletonDataAsset == 0)
            {
                    return;
            }
            
            Spine.SkeletonData val_2 = this.skeletonDataAsset.GetSkeletonData(quiet:  false);
            if(val_2 == null)
            {
                    return;
            }
            
            val_10 = this.skeletonDataAsset;
            if(this.skeletonDataAsset.atlasAssets.Length == 0)
            {
                    return;
            }
            
            Spine.Unity.AtlasAsset val_10 = this.skeletonDataAsset.atlasAssets[0];
            if(this.skeletonDataAsset.atlasAssets[0].materials.Length == 0)
            {
                    return;
            }
            
            val_11 = this.skeletonDataAsset.stateData;
            if(val_11 == null)
            {
                    Spine.SkeletonData val_3 = val_10.GetSkeletonData(quiet:  false);
                val_11 = this.skeletonDataAsset.stateData;
            }
            
            Spine.AnimationState val_4 = new Spine.AnimationState(data:  val_11);
            this.state = val_4;
            if(val_4 == null)
            {
                goto label_16;
            }
            
            Spine.Skeleton val_5 = null;
            val_10 = val_5;
            val_5 = new Spine.Skeleton(data:  val_2);
            .flipX = this.initialFlipX;
            .flipY = this.initialFlipY;
            this.skeleton = val_10;
            this.meshBuffers = new Spine.Unity.DoubleBuffered<SmartMesh>();
            if((System.String.IsNullOrEmpty(value:  this.initialSkinName)) != true)
            {
                    this.skeleton.SetSkin(skinName:  this.initialSkinName);
            }
            
            if((System.String.IsNullOrEmpty(value:  this.startingAnimation)) == false)
            {
                goto label_20;
            }
            
            return;
            label_16:
            this.Clear();
            return;
            label_20:
            Spine.TrackEntry val_9 = this.state.SetAnimation(trackIndex:  0, animationName:  this.startingAnimation, loop:  this.startingLoop);
            goto typeof(Spine.Unity.SkeletonGraphic).__il2cppRuntimeField_600;
        }
        public void UpdateMesh()
        {
            if(this.skeleton == null)
            {
                    return;
            }
            
            UnityEngine.Color val_1 = this.color;
            this.skeleton.b = val_1.b;
            this.skeleton.a = val_1.a;
            this.skeleton.r = val_1.r;
            this.skeleton.g = val_1.g;
            SmartMesh val_2 = this.meshBuffers.GetNext();
            Spine.Unity.MeshGenerator.GenerateSingleSubmeshInstruction(instructionOutput:  this.currentInstructions, skeleton:  this.skeleton, material:  this.material);
            bool val_4 = Spine.Unity.SkeletonRendererInstruction.GeometryNotEqual(a:  this.currentInstructions, b:  val_2.instructionUsed);
            this.meshGenerator.Begin();
            if(this.currentInstructions.hasActiveClipping != false)
            {
                    this.meshGenerator.AddSubmesh(instruction:  new Spine.Unity.SubmeshInstruction() {skeleton = val_1.b, material = val_1.g, forceSeparate = false, rawTriangleCount = val_1.r, hasClipping = false}, updateTriangles:  val_4);
            }
            else
            {
                    this.meshGenerator.BuildMeshWithArrays(instruction:  this.currentInstructions, updateTriangles:  val_4);
            }
            
            if(this.canvas != 0)
            {
                    this.meshGenerator.ScaleVertexData(scale:  this.canvas.referencePixelsPerUnit);
            }
            
            if(this.OnPostProcessVertices != null)
            {
                    this.OnPostProcessVertices.Invoke(meshGenerator:  this.meshGenerator);
            }
            
            this.meshGenerator.FillVertexData(mesh:  val_2.mesh);
            if(val_4 != false)
            {
                    this.meshGenerator.FillTrianglesSingle(mesh:  val_2.mesh);
            }
            
            this.canvasRenderer.SetMesh(mesh:  val_2.mesh);
            val_2.instructionUsed.Set(other:  this.currentInstructions);
        }
        public SkeletonGraphic()
        {
            this.timeScale = 1f;
            this.initialSkinName = "default";
            this.meshGenerator = new Spine.Unity.MeshGenerator();
            this.currentInstructions = new Spine.Unity.SkeletonRendererInstruction();
        }
    
    }

}

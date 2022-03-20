using UnityEngine;

namespace Spine.Unity
{
    public class BoneFollower : MonoBehaviour
    {
        // Fields
        public Spine.Unity.SkeletonRenderer skeletonRenderer;
        public string boneName;
        public bool followZPosition;
        public bool followBoneRotation;
        public bool followSkeletonFlip;
        public bool followLocalScale;
        public bool initializeOnAwake;
        public bool valid;
        public Spine.Bone bone;
        private UnityEngine.Transform skeletonTransform;
        private bool skeletonTransformIsParent;
        
        // Properties
        public Spine.Unity.SkeletonRenderer SkeletonRenderer { get; set; }
        
        // Methods
        public Spine.Unity.SkeletonRenderer get_SkeletonRenderer()
        {
            return (Spine.Unity.SkeletonRenderer)this.skeletonRenderer;
        }
        public void set_SkeletonRenderer(Spine.Unity.SkeletonRenderer value)
        {
            this.skeletonRenderer = value;
            this.Initialize();
        }
        public void Awake()
        {
            if(this.initializeOnAwake == false)
            {
                    return;
            }
            
            this.Initialize();
        }
        public void HandleRebuildRenderer(Spine.Unity.SkeletonRenderer skeletonRenderer)
        {
            this.Initialize();
        }
        public void Initialize()
        {
            this.bone = 0;
            if(this.skeletonRenderer != 0)
            {
                    this.valid = this.skeletonRenderer.valid;
                if(this.skeletonRenderer.valid == false)
            {
                    return;
            }
            
                this.skeletonTransform = this.skeletonRenderer.transform;
                this.skeletonRenderer.remove_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate(object:  this, method:  public System.Void Spine.Unity.BoneFollower::HandleRebuildRenderer(Spine.Unity.SkeletonRenderer skeletonRenderer)));
                this.skeletonRenderer.add_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate(object:  this, method:  public System.Void Spine.Unity.BoneFollower::HandleRebuildRenderer(Spine.Unity.SkeletonRenderer skeletonRenderer)));
                this.skeletonTransformIsParent = (this.skeletonTransform == this.transform.parent) ? 1 : 0;
                if((System.String.IsNullOrEmpty(value:  this.boneName)) == true)
            {
                    return;
            }
            
                this.bone = this.skeletonRenderer.skeleton.FindBone(boneName:  this.boneName);
                return;
            }
            
            this.valid = false;
        }
        private void OnDestroy()
        {
            if(this.skeletonRenderer == 0)
            {
                    return;
            }
            
            this.skeletonRenderer.remove_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate(object:  this, method:  public System.Void Spine.Unity.BoneFollower::HandleRebuildRenderer(Spine.Unity.SkeletonRenderer skeletonRenderer)));
        }
        public void LateUpdate()
        {
            float val_15;
            float val_16;
            float val_26;
            float val_30;
            float val_31;
            float val_32;
            float val_33;
            float val_34;
            float val_35;
            if(this.valid == false)
            {
                goto label_1;
            }
            
            if(this.bone == null)
            {
                goto label_2;
            }
            
            label_14:
            UnityEngine.Transform val_1 = this.transform;
            if(this.skeletonTransformIsParent == false)
            {
                goto label_3;
            }
            
            val_26 = this.bone.worldX;
            if(this.followZPosition != true)
            {
                    UnityEngine.Vector3 val_2 = val_1.localPosition;
            }
            
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  val_26, y:  this.bone.worldY, z:  val_2.z);
            val_30 = val_3.y;
            val_1.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_30, z = val_3.z};
            if(this.followBoneRotation == false)
            {
                goto label_34;
            }
            
            UnityEngine.Quaternion val_4 = Spine.Unity.SkeletonExtensions.GetQuaternion(bone:  this.bone);
            val_1.localRotation = new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w};
            goto label_34;
            label_1:
            this.Initialize();
            return;
            label_2:
            if((System.String.IsNullOrEmpty(value:  this.boneName)) == true)
            {
                    return;
            }
            
            Spine.Bone val_6 = this.skeletonRenderer.skeleton.FindBone(boneName:  this.boneName);
            this.bone = val_6;
            if(val_6 != null)
            {
                goto label_14;
            }
            
            UnityEngine.Debug.LogError(message:  "Bone not found: "("Bone not found: ") + this.boneName, context:  this);
            return;
            label_3:
            UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  this.bone.worldX, y:  this.bone.worldY, z:  0f);
            val_31 = val_8.x;
            val_32 = val_8.y;
            val_33 = val_8.z;
            UnityEngine.Vector3 val_9 = this.skeletonTransform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_31, y = val_32, z = val_33});
            val_26 = val_9.y;
            if(this.followZPosition != true)
            {
                    UnityEngine.Vector3 val_10 = val_1.position;
            }
            
            val_34 = this.bone.WorldRotationX;
            UnityEngine.Transform val_12 = val_1.parent;
            if(val_12 != 0)
            {
                    UnityEngine.Matrix4x4 val_14 = val_12.localToWorldMatrix;
                float val_26 = val_8.x;
                val_33 = val_16;
                val_26 = val_26 * val_33;
                val_32 = val_8.y * val_15;
                val_31 = val_26 - val_32;
                if(val_31 < 0)
            {
                    val_34 = -val_34;
            }
            
            }
            
            if(this.followBoneRotation != false)
            {
                    UnityEngine.Quaternion val_17 = this.skeletonTransform.rotation;
                UnityEngine.Vector3 val_18 = val_17.x.eulerAngles;
                UnityEngine.Quaternion val_19 = this.skeletonTransform.rotation;
                UnityEngine.Vector3 val_20 = val_19.x.eulerAngles;
                val_20.z = val_34 + val_20.z;
                UnityEngine.Quaternion val_21 = UnityEngine.Quaternion.Euler(x:  val_18.x, y:  val_18.y, z:  val_20.z);
                val_30 = val_26;
                val_1.SetPositionAndRotation(position:  new UnityEngine.Vector3() {x = val_9.x, y = val_30, z = val_10.z}, rotation:  new UnityEngine.Quaternion() {x = val_21.x, y = val_21.y, z = val_21.z, w = val_21.w});
            }
            else
            {
                    val_30 = val_26;
                val_1.position = new UnityEngine.Vector3() {x = val_9.x, y = val_30, z = val_10.z};
            }
            
            label_34:
            if(this.followLocalScale != false)
            {
                    val_35 = this.bone.scaleY;
            }
            else
            {
                    UnityEngine.Vector3 val_22;
                val_35 = 1f;
            }
            
            val_22 = new UnityEngine.Vector3(x:  1f, y:  val_35, z:  1f);
            float val_27 = val_22.y;
            if(this.followSkeletonFlip != false)
            {
                    var val_24 = (this.bone.skeleton.flipY == true) ? 1 : 0;
                val_24 = ((this.bone.skeleton.flipX == true) ? 1 : 0) ^ val_24;
                val_27 = val_27 * ((val_24 != 0) ? -1f : 1f);
            }
            
            val_1.localScale = new UnityEngine.Vector3() {x = val_22.x, y = val_27, z = val_22.z};
        }
        public BoneFollower()
        {
            this.followZPosition = true;
            this.followBoneRotation = true;
            this.followSkeletonFlip = true;
            this.initializeOnAwake = true;
        }
    
    }

}

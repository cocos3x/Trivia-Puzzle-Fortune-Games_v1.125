using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonUtilityBone : MonoBehaviour
    {
        // Fields
        public string boneName;
        public UnityEngine.Transform parentReference;
        public Spine.Unity.SkeletonUtilityBone.Mode mode;
        public bool position;
        public bool rotation;
        public bool scale;
        public bool zPosition;
        public float overrideAlpha;
        public Spine.Unity.SkeletonUtility skeletonUtility;
        public Spine.Bone bone;
        public bool transformLerpComplete;
        public bool valid;
        private UnityEngine.Transform cachedTransform;
        private UnityEngine.Transform skeletonTransform;
        private bool incompatibleTransformMode;
        
        // Properties
        public bool IncompatibleTransformMode { get; }
        
        // Methods
        public bool get_IncompatibleTransformMode()
        {
            return (bool)this.incompatibleTransformMode;
        }
        public void Reset()
        {
            this.bone = 0;
            this.cachedTransform = this.transform;
            if(this.skeletonUtility != 0)
            {
                    if(this.skeletonUtility.skeletonRenderer != 0)
            {
                    this.valid = this.skeletonUtility.skeletonRenderer.valid;
                if(this.skeletonUtility.skeletonRenderer.valid == false)
            {
                    return;
            }
            
                this.skeletonTransform = this.skeletonUtility.transform;
                mem[1152921513280408160] = this;
                mem[1152921513280408168] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
                mem[1152921513280408144] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
                this.skeletonUtility.remove_OnReset(value:  new SkeletonUtility.SkeletonUtilityDelegate());
                mem[1152921513280416352] = this;
                mem[1152921513280416360] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
                mem[1152921513280416336] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
                this.skeletonUtility.add_OnReset(value:  new SkeletonUtility.SkeletonUtilityDelegate());
                this.DoUpdate();
                return;
            }
            
            }
            
            this.valid = false;
        }
        private void OnEnable()
        {
            Spine.Unity.SkeletonUtility val_2 = this.transform.GetComponentInParent<Spine.Unity.SkeletonUtility>();
            this.skeletonUtility = val_2;
            if(val_2 == 0)
            {
                    return;
            }
            
            this.skeletonUtility.RegisterBone(bone:  this);
            mem[1152921513280570336] = this;
            mem[1152921513280570344] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
            mem[1152921513280570320] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
            this.skeletonUtility.add_OnReset(value:  new SkeletonUtility.SkeletonUtilityDelegate());
        }
        private void HandleOnReset()
        {
            this.Reset();
        }
        private void OnDisable()
        {
            if(this.skeletonUtility == 0)
            {
                    return;
            }
            
            mem[1152921513280823008] = this;
            mem[1152921513280823016] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
            mem[1152921513280822992] = System.Void Spine.Unity.SkeletonUtilityBone::HandleOnReset();
            this.skeletonUtility.remove_OnReset(value:  new SkeletonUtility.SkeletonUtilityDelegate());
            this.skeletonUtility.UnregisterBone(bone:  this);
        }
        public void DoUpdate()
        {
            float val_42;
            float val_43;
            float val_44;
            float val_45;
            float val_46;
            float val_47;
            float val_51;
            float val_52;
            float val_53;
            float val_54;
            float val_55;
            if(this.valid == false)
            {
                goto label_1;
            }
            
            if(this.bone == null)
            {
                goto label_4;
            }
            
            label_24:
            val_42 = 1f;
            var val_1 = (this.skeletonUtility.skeletonRenderer.skeleton.flipX == true) ? 1 : 0;
            val_1 = val_1 ^ ((this.skeletonUtility.skeletonRenderer.skeleton.flipY == true) ? 1 : 0);
            val_43 = -1f;
            if(this.mode == 1)
            {
                goto label_6;
            }
            
            if(this.mode != 0)
            {
                    return;
            }
            
            if(this.bone.appliedValid != true)
            {
                    this.bone.UpdateAppliedTransform();
            }
            
            if(this.position != false)
            {
                    UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  this.bone.ax, y:  this.bone.ay, z:  0f);
                val_45 = val_4.x;
                val_46 = val_4.y;
                this.cachedTransform.localPosition = new UnityEngine.Vector3() {x = val_45, y = val_46, z = val_4.z};
            }
            
            if(this.rotation == false)
            {
                goto label_20;
            }
            
            if((Spine.SkeletonExtensions.InheritsRotation(mode:  this.bone.data.transformMode)) == false)
            {
                goto label_15;
            }
            
            val_47 = this.bone.arotation;
            val_46 = 0f;
            UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.Euler(x:  0f, y:  val_46, z:  val_47);
            this.cachedTransform.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
            goto label_20;
            label_1:
            this.Reset();
            return;
            label_4:
            if((System.String.IsNullOrEmpty(value:  this.boneName)) == true)
            {
                    return;
            }
            
            Spine.Bone val_8 = this.skeletonUtility.skeletonRenderer.skeleton.FindBone(boneName:  this.boneName);
            this.bone = val_8;
            if(val_8 != null)
            {
                goto label_24;
            }
            
            UnityEngine.Debug.LogError(message:  "Bone not found: "("Bone not found: ") + this.boneName, context:  this);
            return;
            label_6:
            if(this.transformLerpComplete == true)
            {
                    return;
            }
            
            if(this.parentReference != 0)
            {
                goto label_31;
            }
            
            if(this.position != false)
            {
                    UnityEngine.Vector3 val_11 = this.cachedTransform.localPosition;
                val_51 = this.overrideAlpha;
                val_47 = val_11.y;
                this.bone.x = UnityEngine.Mathf.Lerp(a:  this.bone.x, b:  val_11.x, t:  val_51);
                val_52 = this.bone.y;
                val_53 = val_47;
                this.bone.y = UnityEngine.Mathf.Lerp(a:  val_52, b:  val_53, t:  this.overrideAlpha);
            }
            
            if(this.rotation != false)
            {
                    val_47 = this.bone.rotation;
                UnityEngine.Quaternion val_14 = this.cachedTransform.localRotation;
                UnityEngine.Vector3 val_15 = val_14.x.eulerAngles;
                val_51 = val_15.z;
                val_52 = val_47;
                val_53 = val_51;
                float val_16 = UnityEngine.Mathf.LerpAngle(a:  val_52, b:  val_53, t:  this.overrideAlpha);
                this.bone.rotation = val_16;
                this.bone.arotation = val_16;
            }
            
            if(this.scale == false)
            {
                goto label_51;
            }
            
            UnityEngine.Vector3 val_17 = this.cachedTransform.localScale;
            val_51 = this.overrideAlpha;
            val_47 = val_17.y;
            this.bone.scaleX = UnityEngine.Mathf.Lerp(a:  this.bone.scaleX, b:  val_17.x, t:  val_51);
            this.bone.scaleY = UnityEngine.Mathf.Lerp(a:  this.bone.scaleY, b:  val_47, t:  this.overrideAlpha);
            goto label_51;
            label_15:
            UnityEngine.Quaternion val_20 = this.skeletonTransform.rotation;
            UnityEngine.Vector3 val_21 = val_20.x.eulerAngles;
            val_47 = val_21.x;
            val_51 = val_21.z;
            float val_22 = this.bone.WorldRotationX;
            val_22 = ((val_1 != 0) ? (val_43) : (val_42)) * val_22;
            val_21.z = val_51 + val_22;
            val_46 = val_21.y;
            UnityEngine.Quaternion val_23 = UnityEngine.Quaternion.Euler(x:  val_47, y:  val_46, z:  val_21.z);
            this.cachedTransform.rotation = new UnityEngine.Quaternion() {x = val_23.x, y = val_23.y, z = val_23.z, w = val_23.w};
            label_20:
            if(this.scale == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_24 = new UnityEngine.Vector3(x:  this.bone.ascaleX, y:  this.bone.ascaleY, z:  1f);
            this.cachedTransform.localScale = new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z};
            this.incompatibleTransformMode = Spine.Unity.SkeletonUtilityBone.BoneTransformModeIncompatible(bone:  this.bone);
            return;
            label_31:
            if(this.transformLerpComplete == true)
            {
                    return;
            }
            
            if(this.position != false)
            {
                    UnityEngine.Vector3 val_27 = this.cachedTransform.position;
                UnityEngine.Vector3 val_28 = this.parentReference.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z});
                val_51 = this.overrideAlpha;
                val_47 = val_28.y;
                this.bone.x = UnityEngine.Mathf.Lerp(a:  this.bone.x, b:  val_28.x, t:  val_51);
                val_54 = this.bone.y;
                val_55 = val_47;
                this.bone.y = UnityEngine.Mathf.Lerp(a:  val_54, b:  val_55, t:  this.overrideAlpha);
            }
            
            if(this.rotation != false)
            {
                    val_47 = this.bone.rotation;
                UnityEngine.Vector3 val_31 = UnityEngine.Vector3.forward;
                UnityEngine.Vector3 val_32 = this.cachedTransform.up;
                UnityEngine.Vector3 val_33 = this.parentReference.InverseTransformDirection(direction:  new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z});
                val_44 = val_33.x;
                UnityEngine.Quaternion val_34 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, upwards:  new UnityEngine.Vector3() {x = val_44, y = val_33.y, z = val_33.z});
                UnityEngine.Vector3 val_35 = val_34.x.eulerAngles;
                val_51 = val_35.z;
                val_54 = val_47;
                val_55 = val_51;
                float val_36 = UnityEngine.Mathf.LerpAngle(a:  val_54, b:  val_55, t:  this.overrideAlpha);
                this.bone.rotation = val_36;
                this.bone.arotation = val_36;
            }
            
            if(this.scale != false)
            {
                    UnityEngine.Vector3 val_37 = this.cachedTransform.localScale;
                val_51 = this.overrideAlpha;
                val_47 = val_37.y;
                this.bone.scaleX = UnityEngine.Mathf.Lerp(a:  this.bone.scaleX, b:  val_37.x, t:  val_51);
                this.bone.scaleY = UnityEngine.Mathf.Lerp(a:  this.bone.scaleY, b:  val_47, t:  this.overrideAlpha);
            }
            
            this.incompatibleTransformMode = Spine.Unity.SkeletonUtilityBone.BoneTransformModeIncompatible(bone:  this.bone);
            label_51:
            this.transformLerpComplete = true;
        }
        public static bool BoneTransformModeIncompatible(Spine.Bone bone)
        {
            bool val_1 = Spine.SkeletonExtensions.InheritsScale(mode:  bone.data.transformMode);
            val_1 = (~val_1) & 1;
            return (bool)val_1;
        }
        public void AddBoundingBox(string skinName, string slotName, string attachmentName)
        {
            UnityEngine.PolygonCollider2D val_2 = Spine.Unity.SkeletonUtility.AddBoundingBoxGameObject(skeleton:  this.bone.skeleton, skinName:  skinName, slotName:  slotName, attachmentName:  attachmentName, parent:  this.transform, isTrigger:  true);
        }
        public SkeletonUtilityBone()
        {
            this.zPosition = true;
            this.overrideAlpha = 1f;
        }
    
    }

}

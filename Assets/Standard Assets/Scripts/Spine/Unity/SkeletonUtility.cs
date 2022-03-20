using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonUtility : MonoBehaviour
    {
        // Fields
        private Spine.Unity.SkeletonUtility.SkeletonUtilityDelegate OnReset;
        public UnityEngine.Transform boneRoot;
        public Spine.Unity.SkeletonRenderer skeletonRenderer;
        public Spine.Unity.ISkeletonAnimation skeletonAnimation;
        public System.Collections.Generic.List<Spine.Unity.SkeletonUtilityBone> utilityBones;
        public System.Collections.Generic.List<Spine.Unity.SkeletonUtilityConstraint> utilityConstraints;
        protected bool hasTransformBones;
        protected bool hasUtilityConstraints;
        protected bool needToReprocessBones;
        
        // Methods
        public static UnityEngine.PolygonCollider2D AddBoundingBoxGameObject(Spine.Skeleton skeleton, string skinName, string slotName, string attachmentName, UnityEngine.Transform parent, bool isTrigger = True)
        {
            System.Object[] val_10;
            string val_11;
            string val_12;
            System.Object[] val_13;
            int val_14;
            val_10 = parent;
            val_11 = attachmentName;
            if((System.String.IsNullOrEmpty(value:  skinName)) == false)
            {
                goto label_3;
            }
            
            if(skeleton.data.defaultSkin == null)
            {
                goto label_4;
            }
            
            label_15:
            if((skeleton.data.defaultSkin.GetAttachment(slotIndex:  skeleton.FindSlotIndex(slotName:  slotName), name:  val_11)) == null)
            {
                goto label_5;
            }
            
            object[] val_4 = new object[1];
            val_4[0] = val_11;
            val_12 = "Attachment \'{0}\' was not a Bounding Box.";
            val_13 = val_4;
            goto label_14;
            label_3:
            if((skeleton.data.FindSkin(skinName:  skinName)) != null)
            {
                goto label_15;
            }
            
            label_4:
            val_11 = "Skin " + skinName + " not found!"(" not found!");
            UnityEngine.Debug.LogError(message:  val_11);
            return 0;
            label_5:
            object[] val_7 = new object[3];
            val_10 = val_7;
            val_14 = val_7.Length;
            val_10[0] = slotName;
            if(val_11 != null)
            {
                    val_14 = val_7.Length;
            }
            
            val_10[1] = val_11;
            val_11 = skeleton.data.defaultSkin.name;
            if(val_11 != null)
            {
                    val_14 = val_7.Length;
            }
            
            val_10[2] = val_11;
            val_12 = "Attachment in slot \'{0}\' named \'{1}\' not found in skin \'{2}\'.";
            val_13 = val_10;
            label_14:
            UnityEngine.Debug.LogFormat(format:  val_12, args:  val_7);
            return 0;
        }
        public static UnityEngine.PolygonCollider2D AddBoundingBoxGameObject(string name, Spine.BoundingBoxAttachment box, Spine.Slot slot, UnityEngine.Transform parent, bool isTrigger = True)
        {
            bool val_1 = System.String.IsNullOrEmpty(value:  name = name);
            UnityEngine.GameObject val_3 = new UnityEngine.GameObject(name:  "[BoundingBox]" + name);
            UnityEngine.Transform val_4 = val_3.transform;
            val_4.parent = parent;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
            val_4.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.identity;
            val_4.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
            val_4.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            return Spine.Unity.SkeletonUtility.AddBoundingBoxAsComponent(box:  box, slot:  slot, gameObject:  val_3, isTrigger:  isTrigger);
        }
        public static UnityEngine.PolygonCollider2D AddBoundingBoxAsComponent(Spine.BoundingBoxAttachment box, Spine.Slot slot, UnityEngine.GameObject gameObject, bool isTrigger = True)
        {
            UnityEngine.PolygonCollider2D val_8;
            if(box == null)
            {
                goto label_1;
            }
            
            if(slot.bone == slot.Skeleton.RootBone)
            {
                goto label_4;
            }
            
            if((gameObject.GetComponent<UnityEngine.Rigidbody2D>()) != 0)
            {
                goto label_10;
            }
            
            UnityEngine.Rigidbody2D val_5 = gameObject.AddComponent<UnityEngine.Rigidbody2D>();
            val_5.isKinematic = true;
            val_5.gravityScale = 0f;
            goto label_10;
            label_1:
            val_8 = 0;
            return val_8;
            label_4:
            label_10:
            UnityEngine.PolygonCollider2D val_6 = gameObject.AddComponent<UnityEngine.PolygonCollider2D>();
            val_8 = val_6;
            val_6.isTrigger = isTrigger;
            Spine.Unity.SkeletonUtility.SetColliderPointsLocal(collider:  val_8, slot:  slot, box:  box);
            return val_8;
        }
        public static void SetColliderPointsLocal(UnityEngine.PolygonCollider2D collider, Spine.Slot slot, Spine.BoundingBoxAttachment box)
        {
            if(box == null)
            {
                    return;
            }
            
            if((Spine.SkeletonExtensions.IsWeighted(va:  box)) != false)
            {
                    UnityEngine.Debug.LogWarning(message:  "UnityEngine.PolygonCollider2D does not support weighted or animated points. Collider points will not be animated and may have incorrect orientation. If you want to use it as a collider, please remove weights and animations from the bounding box in Spine editor.");
            }
            
            collider.SetPath(index:  0, points:  Spine.Unity.SkeletonExtensions.GetLocalVertices(va:  box, slot:  slot, buffer:  0));
        }
        public static UnityEngine.Bounds GetBoundingBoxBounds(Spine.BoundingBoxAttachment boundingBox, float depth = 0)
        {
            UnityEngine.Bounds val_0;
            UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  X20 + 32, y:  X20 + 32 + 4, z:  0f);
            0.center = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
            if((X20 + 24) >= 3)
            {
                    var val_6 = 2;
                do
            {
                var val_3 = X20 + 32;
                UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  (X20 + 32) + 8, y:  (X20 + 32) + ((2 + 1)) << 2, z:  0f);
                0.Encapsulate(point:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
                val_6 = (val_6 + 1) + 1;
            }
            while(val_6 < (X20 + 24));
            
            }
            
            UnityEngine.Vector3 val_5 = 0.size;
            0.size = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = depth};
            val_0.m_Extents.y = 0f;
            val_0.m_Extents.z = 0f;
            val_0.m_Center.x = 0f;
            val_0.m_Center.y = 0f;
            val_0.m_Center.z = 0f;
            val_0.m_Extents.x = 0f;
            return val_0;
        }
        public void add_OnReset(Spine.Unity.SkeletonUtility.SkeletonUtilityDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OnReset, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnReset != 1152921513276275416);
            
            return;
            label_2:
        }
        public void remove_OnReset(Spine.Unity.SkeletonUtility.SkeletonUtilityDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OnReset, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OnReset != 1152921513276411992);
            
            return;
            label_2:
        }
        private void Update()
        {
            if(this.skeletonRenderer.skeleton == null)
            {
                    return;
            }
            
            if(this.boneRoot == 0)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
            this.boneRoot.localScale = new UnityEngine.Vector3() {x = (this.skeletonRenderer.skeleton.flipX == false) ? val_2.x : -1f, y = (this.skeletonRenderer.skeleton.flipY == false) ? val_2.y : -1f, z = val_2.z};
        }
        private void OnEnable()
        {
            var val_7;
            Spine.Unity.UpdateBonesDelegate val_8;
            var val_10;
            val_7 = 0;
            if(this.skeletonRenderer == 0)
            {
                    this.skeletonRenderer = this.GetComponent<Spine.Unity.SkeletonRenderer>();
            }
            
            if(this.skeletonAnimation == null)
            {
                    Spine.Unity.SkeletonAnimation val_3 = this.GetComponent<Spine.Unity.SkeletonAnimation>();
                this.skeletonAnimation = val_3;
                if(val_3 == null)
            {
                    this.skeletonAnimation = this.GetComponent<Spine.Unity.SkeletonAnimator>();
            }
            
            }
            
            val_8 = 1152921504867176448;
            mem[1152921513276796032] = this;
            mem[1152921513276796040] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            mem[1152921513276796016] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            this.skeletonRenderer.remove_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate());
            mem[1152921513276804224] = this;
            mem[1152921513276804232] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            mem[1152921513276804208] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            this.skeletonRenderer.add_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate());
            if(this.skeletonAnimation != null)
            {
                    mem[1152921513276812416] = this;
                mem[1152921513276812424] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513276812400] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
                var val_7 = 0;
                val_7 = val_7 + 1;
                val_7 = 1;
                val_10 = public System.Void Spine.Unity.ISkeletonAnimation::remove_UpdateLocal(Spine.Unity.UpdateBonesDelegate value);
                this.skeletonAnimation.remove_UpdateLocal(value:  new Spine.Unity.UpdateBonesDelegate());
                mem[1152921513276820624] = this;
                mem[1152921513276820632] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513276820608] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
                val_8 = new Spine.Unity.UpdateBonesDelegate();
                var val_8 = 0;
                val_8 = val_8 + 1;
                val_10 = 0;
                this.skeletonAnimation.add_UpdateLocal(value:  new Spine.Unity.UpdateBonesDelegate());
            }
            
            this.CollectBones();
        }
        private void Start()
        {
            this.CollectBones();
        }
        private void OnDisable()
        {
            var val_5;
            var val_7;
            mem[1152921513277087696] = this;
            mem[1152921513277087704] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            mem[1152921513277087680] = System.Void Spine.Unity.SkeletonUtility::HandleRendererReset(Spine.Unity.SkeletonRenderer r);
            this.skeletonRenderer.remove_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate());
            if(this.skeletonAnimation == null)
            {
                    return;
            }
            
            mem[1152921513277095888] = this;
            mem[1152921513277095896] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
            mem[1152921513277095872] = System.Void Spine.Unity.SkeletonUtility::UpdateLocal(Spine.Unity.ISkeletonAnimation anim);
            var val_4 = 0;
            val_4 = val_4 + 1;
            val_5 = public System.Void Spine.Unity.ISkeletonAnimation::remove_UpdateLocal(Spine.Unity.UpdateBonesDelegate value);
            this.skeletonAnimation.remove_UpdateLocal(value:  new Spine.Unity.UpdateBonesDelegate());
            mem[1152921513277104096] = this;
            mem[1152921513277104104] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
            mem[1152921513277104080] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
            var val_5 = 0;
            val_5 = val_5 + 1;
            val_5 = 3;
            val_7 = public System.Void Spine.Unity.ISkeletonAnimation::remove_UpdateWorld(Spine.Unity.UpdateBonesDelegate value);
            this.skeletonAnimation.remove_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
            mem[1152921513277112304] = this;
            mem[1152921513277112312] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
            mem[1152921513277112288] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
            var val_6 = 0;
            val_6 = val_6 + 1;
            val_7 = 5;
            this.skeletonAnimation.remove_UpdateComplete(value:  new Spine.Unity.UpdateBonesDelegate());
        }
        private void HandleRendererReset(Spine.Unity.SkeletonRenderer r)
        {
            if(this.OnReset != null)
            {
                    this.OnReset.Invoke();
            }
            
            this.CollectBones();
        }
        public void RegisterBone(Spine.Unity.SkeletonUtilityBone bone)
        {
            if((this.utilityBones.Contains(item:  bone)) == true)
            {
                    return;
            }
            
            this.utilityBones.Add(item:  bone);
            this.needToReprocessBones = true;
        }
        public void UnregisterBone(Spine.Unity.SkeletonUtilityBone bone)
        {
            bool val_1 = this.utilityBones.Remove(item:  bone);
        }
        public void RegisterConstraint(Spine.Unity.SkeletonUtilityConstraint constraint)
        {
            if((this.utilityConstraints.Contains(item:  constraint)) == true)
            {
                    return;
            }
            
            this.utilityConstraints.Add(item:  constraint);
            this.needToReprocessBones = true;
        }
        public void UnregisterConstraint(Spine.Unity.SkeletonUtilityConstraint constraint)
        {
            bool val_1 = this.utilityConstraints.Remove(item:  constraint);
        }
        public void CollectBones()
        {
            Spine.Skeleton val_13;
            var val_14;
            var val_15;
            var val_16;
            var val_17;
            bool val_18;
            var val_19;
            var val_21;
            var val_23;
            var val_25;
            val_13 = this.skeletonRenderer.skeleton;
            if(val_13 == null)
            {
                    return;
            }
            
            val_14 = 0;
            if(this.boneRoot == 0)
            {
                goto label_5;
            }
            
            System.Collections.Generic.List<System.Object> val_2 = new System.Collections.Generic.List<System.Object>();
            if(W23 >= 1)
            {
                    val_15 = 1152921510083720384;
                var val_14 = 0;
                do
            {
                val_14 = public System.Void System.Collections.Generic.List<System.Object>::Add(System.Object item);
                val_2.Add(item:  "newProxyInstance".__il2cppRuntimeField_20);
                val_14 = val_14 + 1;
            }
            while(val_14 < W23);
            
            }
            
            if(this.skeletonRenderer.skeleton.ikConstraints >= 1)
            {
                    var val_15 = 0;
                do
            {
                val_14 = public System.Void System.Collections.Generic.List<System.Object>::Add(System.Object item);
                val_2.Add(item:  "newProxyInstance".__il2cppRuntimeField_20 + 32);
                val_15 = val_15 + 1;
            }
            while(val_15 < this.skeletonRenderer.skeleton.ikConstraints);
            
            }
            
            val_13 = this.utilityBones;
            if(val_15 <= 0)
            {
                goto label_21;
            }
            
            val_15 = 1152921510165335856;
            val_17 = 0;
            val_18 = this.hasUtilityConstraints;
            val_19 = val_15;
            goto label_22;
            label_27:
            val_17 = 1;
            label_22:
            if(val_19 <= val_17)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_19 = val_19 + 8;
            if((((0 + 1) + 8) + 32 + 64) != 0)
            {
                    bool val_3 = ((((0 + 1) + 8) + 32 + 40) == 1) ? 1 : 0;
                val_3 = this.hasTransformBones | val_3;
                this.hasTransformBones = val_3;
                val_14 = public System.Boolean System.Collections.Generic.List<System.Object>::Contains(System.Object item);
                mem2[0] = ((val_18 == true) ? 1 : 0) | (val_2.Contains(item:  ((0 + 1) + 8) + 32 + 64));
            }
            
            if((val_17 + 1) < val_15)
            {
                goto label_27;
            }
            
            goto label_28;
            label_5:
            this.utilityBones.Clear();
            this.utilityConstraints.Clear();
            return;
            label_21:
            val_18 = this.hasUtilityConstraints;
            label_28:
            bool val_9 = (this.utilityConstraints > 0) ? 1 : 0;
            val_9 = this.hasUtilityConstraints | val_9;
            this.hasUtilityConstraints = val_9;
            if(this.skeletonAnimation != null)
            {
                    mem[1152921513278013872] = this;
                mem[1152921513278013880] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513278013856] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
                val_16 = 1152921504865951744;
                var val_16 = 0;
                val_16 = val_16 + 1;
                val_14 = 3;
                val_21 = public System.Void Spine.Unity.ISkeletonAnimation::remove_UpdateWorld(Spine.Unity.UpdateBonesDelegate value);
                this.skeletonAnimation.remove_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
                val_15 = 1152921513277026528;
                mem[1152921513278022080] = this;
                mem[1152921513278022088] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513278022064] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
                val_13 = new Spine.Unity.UpdateBonesDelegate();
                var val_17 = 0;
                val_17 = val_17 + 1;
                val_21 = 5;
                val_23 = public System.Void Spine.Unity.ISkeletonAnimation::remove_UpdateComplete(Spine.Unity.UpdateBonesDelegate value);
                this.skeletonAnimation.remove_UpdateComplete(value:  new Spine.Unity.UpdateBonesDelegate());
                if(this.hasTransformBones != true)
            {
                    if(val_18 == false)
            {
                goto label_49;
            }
            
            }
            
                mem[1152921513278030288] = this;
                mem[1152921513278030296] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513278030272] = System.Void Spine.Unity.SkeletonUtility::UpdateWorld(Spine.Unity.ISkeletonAnimation anim);
                val_13 = new Spine.Unity.UpdateBonesDelegate();
                var val_18 = 0;
                val_18 = val_18 + 1;
                val_23 = 2;
                val_25 = public System.Void Spine.Unity.ISkeletonAnimation::add_UpdateWorld(Spine.Unity.UpdateBonesDelegate value);
                this.skeletonAnimation.add_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
                if(val_18 != false)
            {
                    mem[1152921513278038496] = this;
                mem[1152921513278038504] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
                mem[1152921513278038480] = System.Void Spine.Unity.SkeletonUtility::UpdateComplete(Spine.Unity.ISkeletonAnimation anim);
                val_13 = new Spine.Unity.UpdateBonesDelegate();
                var val_19 = 0;
                val_19 = val_19 + 1;
                val_25 = 4;
                this.skeletonAnimation.add_UpdateComplete(value:  new Spine.Unity.UpdateBonesDelegate());
            }
            
            }
            
            label_49:
            this.needToReprocessBones = false;
        }
        private void UpdateLocal(Spine.Unity.ISkeletonAnimation anim)
        {
            var val_1;
            var val_2;
            if(this.needToReprocessBones != false)
            {
                    this.CollectBones();
            }
            
            if(this.utilityBones == null)
            {
                    return;
            }
            
            if(W21 < 1)
            {
                goto label_3;
            }
            
            val_1 = 0;
            val_2 = W21;
            goto label_4;
            label_7:
            val_1 = 1;
            label_4:
            if(val_2 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + 8;
            mem2[0] = 0;
            if((val_1 + 1) < W21)
            {
                goto label_7;
            }
            
            label_3:
            this.UpdateAllBones();
        }
        private void UpdateWorld(Spine.Unity.ISkeletonAnimation anim)
        {
            bool val_1 = true;
            this.UpdateAllBones();
            if(41934848 < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                val_2 = val_2 + 1;
                if(val_2 >= 41934848)
            {
                    return;
            }
            
            }
            while(this.utilityConstraints != null);
            
            throw new NullReferenceException();
        }
        private void UpdateComplete(Spine.Unity.ISkeletonAnimation anim)
        {
            this.UpdateAllBones();
        }
        private void UpdateAllBones()
        {
            var val_2;
            var val_3;
            if(this.boneRoot == 0)
            {
                    this.CollectBones();
            }
            
            if(this.utilityBones == null)
            {
                    return;
            }
            
            if(this.boneRoot < 1)
            {
                    return;
            }
            
            val_2 = 0;
            val_3 = this.boneRoot;
            goto label_6;
            label_9:
            val_2 = 1;
            label_6:
            if(val_3 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + 8;
            0.DoUpdate();
            if((val_2 + 1) < this.boneRoot)
            {
                goto label_9;
            }
        
        }
        public UnityEngine.Transform GetBoneRoot()
        {
            if(this.boneRoot != 0)
            {
                    return (UnityEngine.Transform)this.boneRoot;
            }
            
            UnityEngine.Transform val_3 = new UnityEngine.GameObject(name:  "SkeletonUtility-Root").transform;
            this.boneRoot = val_3;
            val_3.parent = this.transform;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
            this.boneRoot.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.identity;
            this.boneRoot.localRotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
            this.boneRoot.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            return (UnityEngine.Transform)this.boneRoot;
        }
        public UnityEngine.GameObject SpawnRoot(Spine.Unity.SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
        {
            UnityEngine.Transform val_1 = this.GetBoneRoot();
            this.CollectBones();
            return (UnityEngine.GameObject)this.SpawnBone(bone:  this.skeletonRenderer.skeleton.RootBone, parent:  this.boneRoot, mode:  mode, pos:  pos, rot:  rot, sca:  sca);
        }
        public UnityEngine.GameObject SpawnHierarchy(Spine.Unity.SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
        {
            UnityEngine.Transform val_1 = this.GetBoneRoot();
            this.CollectBones();
            return (UnityEngine.GameObject)this.SpawnBoneRecursively(bone:  this.skeletonRenderer.skeleton.RootBone, parent:  this.boneRoot, mode:  mode, pos:  pos, rot:  rot, sca:  sca);
        }
        public UnityEngine.GameObject SpawnBoneRecursively(Spine.Bone bone, UnityEngine.Transform parent, Spine.Unity.SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
        {
            var val_10;
            var val_11;
            val_10 = rot;
            val_11 = bone;
            UnityEngine.GameObject val_4 = this.SpawnBone(bone:  bone, parent:  parent, mode:  mode, pos:  pos, rot:  rot, sca:  sca);
            if(W27 < 1)
            {
                    return val_4;
            }
            
            var val_9 = 0;
            bool val_5 = pos;
            val_10 = val_10;
            bool val_6 = sca;
            do
            {
                var val_7 = X8 + 0;
                val_11 = mem[(X8 + 0) + 32];
                val_11 = (X8 + 0) + 32;
                UnityEngine.Transform val_8 = val_4.transform;
                val_9 = val_9 + 1;
            }
            while(val_9 < X27);
            
            return val_4;
        }
        public UnityEngine.GameObject SpawnBone(Spine.Bone bone, UnityEngine.Transform parent, Spine.Unity.SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
        {
            float val_13;
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  bone.data.name);
            val_1.transform.parent = parent;
            val_3.skeletonUtility = this;
            val_3.mode = mode;
            val_3.position = pos;
            val_3.rotation = rot;
            val_3.scale = sca;
            val_3.zPosition = true;
            val_1.AddComponent<Spine.Unity.SkeletonUtilityBone>().Reset();
            val_3.bone = bone;
            val_3.valid = true;
            val_3.boneName = bone.data.name;
            if(mode != 1)
            {
                    return val_1;
            }
            
            if(rot != false)
            {
                    val_13 = 0f;
                UnityEngine.Quaternion val_8 = UnityEngine.Quaternion.Euler(x:  0f, y:  val_13, z:  val_3.bone.arotation);
                val_1.transform.localRotation = new UnityEngine.Quaternion() {x = val_8.x, y = val_8.y, z = val_8.z, w = val_8.w};
            }
            
            if(pos != false)
            {
                    UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_3.bone.x, y:  val_3.bone.y, z:  0f);
                val_13 = val_10.y;
                val_1.transform.localPosition = new UnityEngine.Vector3() {x = val_10.x, y = val_13, z = val_10.z};
            }
            
            UnityEngine.Vector3 val_12 = new UnityEngine.Vector3(x:  val_3.bone.scaleX, y:  val_3.bone.scaleY, z:  0f);
            val_1.transform.localScale = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
            return val_1;
        }
        public SkeletonUtility()
        {
            this.utilityBones = new System.Collections.Generic.List<Spine.Unity.SkeletonUtilityBone>();
            this.utilityConstraints = new System.Collections.Generic.List<Spine.Unity.SkeletonUtilityConstraint>();
        }
    
    }

}

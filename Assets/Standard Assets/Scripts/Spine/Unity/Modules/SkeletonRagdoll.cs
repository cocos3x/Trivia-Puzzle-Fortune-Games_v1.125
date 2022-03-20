using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonRagdoll : MonoBehaviour
    {
        // Fields
        private static UnityEngine.Transform parentSpaceHelper;
        public string startingBoneName;
        public System.Collections.Generic.List<string> stopBoneNames;
        public bool applyOnStart;
        public bool disableIK;
        public bool disableOtherConstraints;
        public bool pinStartBone;
        public bool enableJointCollision;
        public bool useGravity;
        public float thickness;
        public float rotationLimit;
        public float rootMass;
        public float massFalloffFactor;
        public int colliderLayer;
        public float mix;
        private Spine.Unity.ISkeletonAnimation targetSkeletonComponent;
        private Spine.Skeleton skeleton;
        private System.Collections.Generic.Dictionary<Spine.Bone, UnityEngine.Transform> boneTable;
        private UnityEngine.Transform ragdollRoot;
        private UnityEngine.Rigidbody <RootRigidbody>k__BackingField;
        private Spine.Bone <StartingBone>k__BackingField;
        private UnityEngine.Vector3 rootOffset;
        private bool isActive;
        
        // Properties
        public UnityEngine.Rigidbody RootRigidbody { get; set; }
        public Spine.Bone StartingBone { get; set; }
        public UnityEngine.Vector3 RootOffset { get; }
        public bool IsActive { get; }
        public UnityEngine.Rigidbody[] RigidbodyArray { get; }
        public UnityEngine.Vector3 EstimatedSkeletonPosition { get; }
        
        // Methods
        public UnityEngine.Rigidbody get_RootRigidbody()
        {
            return (UnityEngine.Rigidbody)this.<RootRigidbody>k__BackingField;
        }
        private void set_RootRigidbody(UnityEngine.Rigidbody value)
        {
            this.<RootRigidbody>k__BackingField = value;
        }
        public Spine.Bone get_StartingBone()
        {
            return (Spine.Bone)this.<StartingBone>k__BackingField;
        }
        private void set_StartingBone(Spine.Bone value)
        {
            this.<StartingBone>k__BackingField = value;
        }
        public UnityEngine.Vector3 get_RootOffset()
        {
            return new UnityEngine.Vector3() {x = this.rootOffset};
        }
        public bool get_IsActive()
        {
            return (bool)this.isActive;
        }
        private System.Collections.IEnumerator Start()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SkeletonRagdoll.<Start>d__33();
        }
        public UnityEngine.Rigidbody[] get_RigidbodyArray()
        {
            var val_8;
            var val_9;
            var val_10;
            if(this.isActive == false)
            {
                goto label_1;
            }
            
            int val_1 = this.boneTable.Count;
            val_8 = new UnityEngine.Rigidbody[0];
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_4 = this.boneTable.Values.GetEnumerator();
            val_9 = 0;
            goto label_5;
            label_11:
            val_10 = 0;
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9 = 1;
            val_8[val_9] = val_10.GetComponent<UnityEngine.Rigidbody>();
            label_5:
            if(0.MoveNext() == true)
            {
                goto label_11;
            }
            
            0.Dispose();
            return (UnityEngine.Rigidbody[])val_8;
            label_1:
            val_8 = new UnityEngine.Rigidbody[0];
            return (UnityEngine.Rigidbody[])val_8;
        }
        public UnityEngine.Vector3 get_EstimatedSkeletonPosition()
        {
            UnityEngine.Vector3 val_1 = this.<RootRigidbody>k__BackingField.position;
            return UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, b:  new UnityEngine.Vector3() {x = this.rootOffset, y = V11.16B, z = V10.16B});
        }
        public void Apply()
        {
            var val_7;
            var val_8;
            Spine.Skeleton val_47;
            var val_48;
            float val_49;
            var val_50;
            UnityEngine.Collider val_51;
            UnityEngine.Transform val_52;
            float val_53;
            float val_54;
            float val_55;
            float val_56;
            float val_58;
            var val_60;
            var val_62;
            int val_63;
            string val_65;
            Spine.Skeleton val_66;
            val_47 = this.skeleton;
            this.isActive = true;
            this.mix = 1f;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.Bone val_1 = val_47.FindBone(boneName:  this.startingBoneName);
            this.<StartingBone>k__BackingField = val_1;
            this.RecursivelyCreateBoneProxies(b:  val_1);
            val_47 = this.boneTable;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_2 = val_47.Item[this.<StartingBone>k__BackingField];
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Rigidbody val_3 = val_2.GetComponent<UnityEngine.Rigidbody>();
            this.<RootRigidbody>k__BackingField = val_3;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_48 = 0;
            val_3.isKinematic = this.pinStartBone;
            val_47 = this.<RootRigidbody>k__BackingField;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = this.rootMass;
            val_47.mass = val_49;
            System.Collections.Generic.List<UnityEngine.Collider> val_4 = new System.Collections.Generic.List<UnityEngine.Collider>();
            val_47 = this.boneTable;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_5 = val_47.GetEnumerator();
            val_50 = 1152921513291888528;
            label_49:
            val_51 = public System.Boolean Dictionary.Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext();
            if(val_8.MoveNext() == false)
            {
                goto label_7;
            }
            
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = val_7.GetComponent<UnityEngine.Collider>();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = val_4;
            val_4.Add(item:  val_51);
            if(val_7 == (this.<StartingBone>k__BackingField))
            {
                goto label_10;
            }
            
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = this.boneTable;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = mem[val_7 + 32];
            val_51 = val_7 + 32;
            val_52 = val_47.Item[val_51];
            if(val_52 != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_10:
            UnityEngine.GameObject val_12 = null;
            val_51 = "RagdollRoot";
            val_12 = new UnityEngine.GameObject(name:  val_51);
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_13 = val_12.transform;
            this.ragdollRoot = val_13;
            val_51 = this.transform;
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13.SetParent(parent:  val_51, worldPositionStays:  false);
            val_47 = this.skeleton;
            if(val_47 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = 0;
            if(val_7 != val_47.RootBone)
            {
                    if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((val_7 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_8 = 0;
                val_51 = 0;
                UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_7 + 32 + 116, y:  val_7 + 32 + 128, z:  0f);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                val_47 = this.ragdollRoot;
                val_51 = 0;
                val_47.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
                if((val_7 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_53 = mem[val_7 + 32 + 84];
                val_53 = val_7 + 32 + 84;
                if((val_7 + 32 + 32) != 0)
            {
                    do
            {
                val_53 = val_53 + (val_7 + 32 + 32 + 84);
            }
            while((val_7 + 32 + 32 + 32) != 0);
            
            }
            
                val_54 = 0f;
                val_55 = 0f;
                val_56 = val_53;
                val_47 = 0;
                UnityEngine.Quaternion val_17 = UnityEngine.Quaternion.Euler(x:  val_54, y:  val_55, z:  val_56);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                this.ragdollRoot.localRotation = new UnityEngine.Quaternion() {x = val_17.x, y = val_17.y, z = val_17.z, w = val_17.w};
            }
            else
            {
                    if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_8 = 0;
                val_51 = 0;
                UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  val_7 + 116, y:  val_7 + 128, z:  0f);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                this.ragdollRoot.localPosition = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
                val_58 = mem[val_7 + 84];
                val_58 = val_7 + 84;
                if((val_7 + 32) != 0)
            {
                    do
            {
                val_58 = val_58 + (val_7 + 32 + 84);
            }
            while((val_7 + 32 + 32) != 0);
            
            }
            
                val_54 = 0f;
                val_55 = 0f;
                val_56 = val_58;
                UnityEngine.Quaternion val_19 = UnityEngine.Quaternion.Euler(x:  val_54, y:  val_55, z:  val_56);
                this.ragdollRoot.localRotation = new UnityEngine.Quaternion() {x = val_19.x, y = val_19.y, z = val_19.z, w = val_19.w};
            }
            
            val_52 = this.ragdollRoot;
            UnityEngine.Vector3 val_20 = val_7.position;
            val_51 = 0;
            UnityEngine.Transform val_21 = this.transform;
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = 0;
            UnityEngine.Vector3 val_22 = val_21.position;
            val_49 = val_20.x;
            val_47 = 0;
            UnityEngine.Vector3 val_23 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_49, y = val_20.y, z = val_20.z}, b:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z});
            this.rootOffset = val_23;
            mem[1152921513292091068] = val_23.y;
            mem[1152921513292091072] = val_23.z;
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_13:
            UnityEngine.Rigidbody val_24 = val_52.GetComponent<UnityEngine.Rigidbody>();
            if(val_24 == 0)
            {
                goto label_49;
            }
            
            val_51 = 0;
            UnityEngine.GameObject val_26 = val_7.gameObject;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = public UnityEngine.HingeJoint UnityEngine.GameObject::AddComponent<UnityEngine.HingeJoint>();
            UnityEngine.HingeJoint val_27 = val_26.AddComponent<UnityEngine.HingeJoint>();
            if(val_27 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27.connectedBody = val_24;
            UnityEngine.Vector3 val_28 = val_7.position;
            UnityEngine.Vector3 val_29 = val_52.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_28.x, y = val_28.y, z = val_28.z});
            val_27.connectedAnchor = new UnityEngine.Vector3() {x = val_29.x, y = val_29.y, z = val_29.z};
            UnityEngine.Vector3 val_30 = UnityEngine.Vector3.forward;
            val_27.axis = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
            UnityEngine.Rigidbody val_31 = val_27.GetComponent<UnityEngine.Rigidbody>();
            val_51 = 0;
            UnityEngine.Rigidbody val_32 = val_27.connectedBody;
            if(val_32 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = 0;
            float val_33 = val_32.mass;
            if(val_31 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_33 = val_33 * this.massFalloffFactor;
            val_31.mass = val_33;
            0.min = -this.rotationLimit;
            0.max = this.rotationLimit;
            val_27.limits = new UnityEngine.JointLimits() {m_Min = 0f, m_Max = 0f, m_Bounciness = 0f, m_BounceMinVelocity = 0f, m_ContactDistance = 0f, minBounce = 0f, maxBounce = 0f};
            val_27.useLimits = true;
            val_27.enableCollision = this.enableJointCollision;
            goto label_49;
            label_7:
            val_8.Dispose();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921513291969520 >= 1)
            {
                    var val_50 = 0;
                do
            {
                if(1152921513291969520 >= 1)
            {
                    do
            {
                if(val_50 != 0)
            {
                    if(val_50 < 1152921513291969520)
            {
                    val_60 = 1152921513291969520;
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_34 = X9 + 0;
                if(1152921513291969520 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_35 = X9 + 0;
                val_48 = 0;
                UnityEngine.Physics.IgnoreCollision(collider1:  (X9 + 0) + 32, collider2:  (X9 + 0) + 32);
            }
            
                val_62 = 0 + 1;
            }
            while(val_62 < (val_35 << ));
            
            }
            
                val_50 = val_50 + 1;
            }
            while(val_50 < (val_35 << ));
            
            }
            
            T[] val_36 = this.GetComponentsInChildren<Spine.Unity.SkeletonUtilityBone>();
            if(val_36 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_36.Length != 0)
            {
                    System.Collections.Generic.List<System.String> val_37 = new System.Collections.Generic.List<System.String>();
                val_63 = val_36.Length;
                if(val_63 >= 1)
            {
                    val_50 = 1152921509851232320;
                do
            {
                if(null == null)
            {
                    throw new NullReferenceException();
            }
            
                UnityEngine.GameObject val_38 = 1152921506204592464.gameObject;
                if(val_38 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_37 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_48 = public System.Void System.Collections.Generic.List<System.String>::Add(System.String item);
                val_37.Add(item:  val_38.name);
                val_47 = 1152921506204592464.gameObject;
                UnityEngine.Object.Destroy(obj:  val_47);
                val_63 = val_36.Length;
                val_62 = 0 + 1;
            }
            while(val_62 < val_63);
            
            }
            
                if(val_37 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_63 >= 1)
            {
                    var val_51 = 0;
                val_62 = ",";
                do
            {
                if(val_51 >= val_63)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_48 = 0;
                val_63 = val_63 + 0;
                val_65 = "Destroyed Utility Bones: "("Destroyed Utility Bones: ") + (val_36.Length + 0) + 32((val_36.Length + 0) + 32);
                int val_42 = val_63 - 1;
                if(val_51 != val_42)
            {
                    val_48 = 0;
                val_65 = val_65 + ",";
            }
            
                val_51 = val_51 + 1;
            }
            while(val_51 < (val_63 << ));
            
                val_47 = val_65;
                UnityEngine.Debug.LogWarning(message:  val_47);
            }
            
            }
            
            if(this.disableIK != false)
            {
                    if(this.skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.skeleton.ikConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_42 >= 1)
            {
                    var val_52 = 0;
                do
            {
                if(X11 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_44 = X11 + 0;
                if(((X11 + 0) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_52 = val_52 + 1;
                mem2[0] = 0;
            }
            while(val_52 < val_42);
            
            }
            
            }
            
            if(this.disableOtherConstraints != false)
            {
                    val_66 = this.skeleton;
                if(val_66 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.skeleton.transformConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_42 >= 1)
            {
                    var val_53 = 4;
                do
            {
                if((X11 + 24) == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_45 = val_53 - 4;
                if((X11 + 24 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                mem2[0] = 0;
                if((X11 + 24 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((X11 + 24 + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                mem2[0] = 0;
                if((X11 + 24 + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((X11 + 24 + 32 + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                mem2[0] = 0;
                if((X11 + 24 + 32 + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((X11 + 24 + 32 + 32 + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_53 = val_53 + 1;
                var val_46 = val_53 - 4;
                mem2[0] = 0;
            }
            while(val_46 < val_42);
            
                val_66 = this.skeleton;
                if(val_66 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
                if(this.skeleton.pathConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_42 >= 1)
            {
                    var val_54 = 4;
                do
            {
                if(val_46 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_47 = val_54 - 4;
                if((((4 + 1) - 4) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                mem2[0] = 0;
                if((((4 + 1) - 4) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((((4 + 1) - 4) + 32 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_54 = val_54 + 1;
                mem2[0] = 0;
            }
            while((val_54 - 4) < val_42);
            
            }
            
            }
            
            mem[1152921513292331872] = this;
            mem[1152921513292331880] = System.Void Spine.Unity.Modules.SkeletonRagdoll::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation skeletonRenderer);
            mem[1152921513292331856] = System.Void Spine.Unity.Modules.SkeletonRagdoll::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation skeletonRenderer);
            if(this.targetSkeletonComponent == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_55 = 0;
            val_55 = val_55 + 1;
            val_48 = 2;
            this.targetSkeletonComponent.add_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
        }
        public UnityEngine.Coroutine SmoothMix(float target, float duration)
        {
            return this.StartCoroutine(routine:  this.SmoothMixCoroutine(target:  target, duration:  duration));
        }
        private System.Collections.IEnumerator SmoothMixCoroutine(float target, float duration)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .target = target;
            .duration = duration;
            return (System.Collections.IEnumerator)new SkeletonRagdoll.<SmoothMixCoroutine>d__40();
        }
        public void SetSkeletonPosition(UnityEngine.Vector3 worldPosition)
        {
            if(this.isActive == false)
            {
                goto label_1;
            }
            
            UnityEngine.Vector3 val_2 = this.transform.position;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = worldPosition.x, y = worldPosition.y, z = worldPosition.z}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            this.transform.position = new UnityEngine.Vector3() {x = worldPosition.x, y = worldPosition.y, z = worldPosition.z};
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_6 = this.boneTable.Values.GetEnumerator();
            label_12:
            if(0.MoveNext() == false)
            {
                goto label_8;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector3 val_8 = 0.position;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            0.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            goto label_12;
            label_8:
            0.Dispose();
            this.UpdateSpineSkeleton(skeletonRenderer:  public System.Void Dictionary.ValueCollection.Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose());
            this.skeleton.UpdateWorldTransform();
            return;
            label_1:
            UnityEngine.Debug.LogWarning(message:  "Can\'t call SetSkeletonPosition while Ragdoll is not active!");
        }
        public void Remove()
        {
            var val_3;
            var val_4;
            this.isActive = false;
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_2 = this.boneTable.Values.GetEnumerator();
            label_7:
            if(val_4.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_3.gameObject);
            goto label_7;
            label_3:
            val_4.Dispose();
            UnityEngine.Object.Destroy(obj:  this.ragdollRoot.gameObject);
            this.boneTable.Clear();
            mem[1152921513292904000] = this;
            mem[1152921513292904008] = System.Void Spine.Unity.Modules.SkeletonRagdoll::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation skeletonRenderer);
            mem[1152921513292903984] = System.Void Spine.Unity.Modules.SkeletonRagdoll::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation skeletonRenderer);
            var val_9 = 0;
            val_9 = val_9 + 1;
            this.targetSkeletonComponent.remove_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
        }
        public UnityEngine.Rigidbody GetRigidbody(string boneName)
        {
            var val_5;
            Spine.Bone val_1 = this.skeleton.FindBone(boneName:  boneName);
            if(val_1 == null)
            {
                    return (UnityEngine.Rigidbody)val_5;
            }
            
            if((this.boneTable.ContainsKey(key:  val_1)) != false)
            {
                    UnityEngine.Rigidbody val_4 = this.boneTable.Item[val_1].GetComponent<UnityEngine.Rigidbody>();
                return (UnityEngine.Rigidbody)val_5;
            }
            
            val_5 = 0;
            return (UnityEngine.Rigidbody)val_5;
        }
        private void RecursivelyCreateBoneProxies(Spine.Bone b)
        {
            var val_20;
            float val_21;
            if((this.stopBoneNames.Contains(item:  b.data.name)) == true)
            {
                    return;
            }
            
            UnityEngine.GameObject val_2 = null;
            val_20 = val_2;
            val_2 = new UnityEngine.GameObject(name:  b.data.name);
            val_2.layer = this.colliderLayer;
            UnityEngine.Transform val_3 = val_2.transform;
            this.boneTable.Add(key:  b, value:  val_3);
            val_3.parent = val_3.transform;
            UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  b.worldX, y:  b.worldY, z:  0f);
            val_3.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            UnityEngine.Quaternion val_8 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  b.WorldRotationX - b.shearX);
            val_3.localRotation = new UnityEngine.Quaternion() {x = val_8.x, y = val_8.y, z = val_8.z, w = val_8.w};
            val_21 = b.WorldScaleX;
            UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_21, y:  b.WorldScaleY, z:  1f);
            val_3.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            System.Collections.Generic.List<UnityEngine.Collider> val_12 = this.AttachBoundingBoxRagdollColliders(b:  b);
            val_21 = b.data.length;
            if(val_21 == 0f)
            {
                    float val_20 = this.thickness;
                val_20 = val_20 * 0.5f;
                val_2.AddComponent<UnityEngine.SphereCollider>().radius = val_20;
            }
            else
            {
                    UnityEngine.BoxCollider val_14 = val_2.AddComponent<UnityEngine.BoxCollider>();
                UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  val_21, y:  this.thickness, z:  this.thickness);
                val_14.size = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
                float val_21 = 0.5f;
                val_21 = val_21 * val_21;
                UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_21, y:  0f);
                val_14.center = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            }
            
            val_2.AddComponent<UnityEngine.Rigidbody>().constraints = 8;
            ExposedList.Enumerator<T> val_18 = b.children.GetEnumerator();
            label_21:
            if(0.MoveNext() == false)
            {
                goto label_19;
            }
            
            goto label_21;
            label_19:
            0.Dispose();
        }
        private void UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation skeletonRenderer)
        {
            var val_7;
            var val_8;
            System.Collections.Generic.Dictionary<Spine.Bone, UnityEngine.Transform> val_23;
            Spine.Bone val_24;
            UnityEngine.Transform val_25;
            float val_26;
            float val_27;
            float val_28;
            var val_3 = ((this.skeleton.flipX == true) ? 1 : 0) ^ ((this.skeleton.flipY == true) ? 1 : 0);
            Dictionary.Enumerator<TKey, TValue> val_5 = this.boneTable.GetEnumerator();
            goto label_3;
            label_26:
            if(val_7 == (this.<StartingBone>k__BackingField))
            {
                goto label_4;
            }
            
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = this.boneTable;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = mem[val_7 + 32];
            val_24 = val_7 + 32;
            val_25 = val_23.Item[val_24];
            if(val_25 != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_4:
            val_25 = this.ragdollRoot;
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_7:
            UnityEngine.Vector3 val_11 = val_25.position;
            val_24 = 0;
            UnityEngine.Quaternion val_12 = val_25.rotation;
            val_23 = Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            val_23.position = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            val_23 = Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23.rotation = new UnityEngine.Quaternion() {x = val_12.x, y = val_12.y, z = val_12.z, w = val_12.w};
            val_23 = val_25;
            val_24 = 0;
            UnityEngine.Vector3 val_13 = val_23.localScale;
            if(Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper;
            val_24 = 0;
            val_23.localScale = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector3 val_14 = val_7.position;
            val_23 = val_7;
            val_24 = 0;
            UnityEngine.Vector3 val_15 = val_23.right;
            if(Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            UnityEngine.Vector3 val_16 = Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper.InverseTransformDirection(direction:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z});
            val_23 = Spine.Unity.Modules.SkeletonRagdoll.parentSpaceHelper;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            UnityEngine.Vector3 val_17 = val_23.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            val_23 = null;
            val_26 = val_17.x;
            val_27 = val_17.y;
            val_28 = val_16.y * 57.29578f;
            if((this.skeleton.flipY | this.skeleton.flipX) == false)
            {
                goto label_20;
            }
            
            if(val_7 == (this.<StartingBone>k__BackingField))
            {
                goto label_19;
            }
            
            if(val_3 == 0)
            {
                goto label_20;
            }
            
            val_28 = -val_28;
            val_27 = -val_27;
            if(val_7 != 0)
            {
                goto label_21;
            }
            
            throw new NullReferenceException();
            label_19:
            float val_22 = (val_3 != 0) ? -1f : 1f;
            val_27 = (this.skeleton.flipY == true) ? (-val_27) : (val_27);
            float val_23 = 180f;
            val_22 = val_22 * val_28;
            val_23 = val_22 + val_23;
            val_26 = (this.skeleton.flipX == true) ? (-val_26) : (val_26);
            val_28 = (this.skeleton.flipX == true) ? (val_23) : (val_22);
            label_20:
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            label_21:
            mem2[0] = UnityEngine.Mathf.Lerp(a:  val_7 + 48, b:  val_26, t:  this.mix);
            mem2[0] = UnityEngine.Mathf.Lerp(a:  val_7 + 52, b:  val_27, t:  this.mix);
            mem2[0] = UnityEngine.Mathf.Lerp(a:  val_7 + 56, b:  val_28, t:  this.mix);
            label_3:
            if(val_8.MoveNext() == true)
            {
                goto label_26;
            }
            
            val_8.Dispose();
        }
        private System.Collections.Generic.List<UnityEngine.Collider> AttachBoundingBoxRagdollColliders(Spine.Bone b)
        {
            Spine.Slot val_6;
            var val_7;
            Spine.Skin val_19;
            int val_20;
            Spine.Skin val_21;
            System.Collections.Generic.List<UnityEngine.Collider> val_1 = new System.Collections.Generic.List<UnityEngine.Collider>();
            if(this.boneTable == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_2 = this.boneTable.Item[b];
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = this.skeleton.skin;
            if(val_19 == null)
            {
                    if(this.skeleton.data == null)
            {
                    throw new NullReferenceException();
            }
            
                val_19 = this.skeleton.data.defaultSkin;
            }
            
            System.Collections.Generic.List<Spine.Attachment> val_4 = new System.Collections.Generic.List<Spine.Attachment>();
            if(this.skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.skeleton.slots == null)
            {
                    throw new NullReferenceException();
            }
            
            ExposedList.Enumerator<T> val_5 = this.skeleton.slots.GetEnumerator();
            label_29:
            if(val_7.MoveNext() == false)
            {
                goto label_8;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_6 + 24) != b)
            {
                goto label_29;
            }
            
            if(this.skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = this.skeleton.slots.IndexOf(item:  val_6);
            val_21 = val_19;
            if(val_21 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_21.FindAttachmentsForSlot(slotIndex:  val_20, attachments:  val_4);
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_10 = val_4.GetEnumerator();
            label_25:
            if(val_7.MoveNext() == false)
            {
                goto label_15;
            }
            
            if(val_6 == 0)
            {
                goto label_25;
            }
            
            if((val_6 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_12 = val_6 + 16.ToLower();
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20 = "ragdoll";
            if((val_12.Contains(value:  val_20)) == false)
            {
                goto label_25;
            }
            
            val_21 = val_2.gameObject;
            if(val_21 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.BoxCollider val_14 = val_21.AddComponent<UnityEngine.BoxCollider>();
            UnityEngine.Bounds val_15 = Spine.Unity.SkeletonUtility.GetBoundingBoxBounds(boundingBox:  val_6, depth:  this.thickness);
            val_20 = 0;
            UnityEngine.Vector3 val_16 = val_7.center;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14.center = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            UnityEngine.Vector3 val_17 = val_7.size;
            val_14.size = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_14);
            goto label_25;
            label_15:
            var val_18 = 0 + 1;
            mem2[0] = 272;
            val_7.Dispose();
            if(0 != 0)
            {
                goto label_26;
            }
            
            if((val_18 == 1) || ((96846736 + ((0 + 1)) << 2) != 272))
            {
                goto label_29;
            }
            
            var val_21 = 0;
            val_21 = val_21 ^ (val_18 >> 31);
            var val_19 = val_18 + val_21;
            goto label_29;
            label_8:
            var val_20 = 0 + 1;
            mem2[0] = 300;
            val_7.Dispose();
            return val_1;
            label_26:
            val_21 = X25;
            val_20 = 0;
            throw val_21;
        }
        private static float GetPropagatedRotation(Spine.Bone b)
        {
            if(b != null)
            {
                    float val_1 = b.arotation;
                if(b.parent == null)
            {
                    return (float)val_1;
            }
            
                do
            {
                val_1 = val_1 + b.parent.arotation;
            }
            while(b.parent.parent != null);
            
                return (float)val_1;
            }
            
            throw new NullReferenceException();
        }
        public SkeletonRagdoll()
        {
            this.startingBoneName = "";
            this.stopBoneNames = new System.Collections.Generic.List<System.String>();
            this.disableIK = true;
            this.useGravity = true;
            this.mix = 1f;
            this.thickness = ;
            this.rotationLimit = ;
            this.rootMass = 20f;
            this.massFalloffFactor = 0.4f;
            this.boneTable = new System.Collections.Generic.Dictionary<Spine.Bone, UnityEngine.Transform>();
        }
    
    }

}

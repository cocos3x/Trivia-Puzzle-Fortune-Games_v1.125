using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonRagdoll2D : MonoBehaviour
    {
        // Fields
        private static UnityEngine.Transform parentSpaceHelper;
        public string startingBoneName;
        public System.Collections.Generic.List<string> stopBoneNames;
        public bool applyOnStart;
        public bool disableIK;
        public bool disableOtherConstraints;
        public bool pinStartBone;
        public float gravityScale;
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
        private UnityEngine.Rigidbody2D <RootRigidbody>k__BackingField;
        private Spine.Bone <StartingBone>k__BackingField;
        private UnityEngine.Vector2 rootOffset;
        private bool isActive;
        
        // Properties
        public UnityEngine.Rigidbody2D RootRigidbody { get; set; }
        public Spine.Bone StartingBone { get; set; }
        public UnityEngine.Vector3 RootOffset { get; }
        public bool IsActive { get; }
        public UnityEngine.Rigidbody2D[] RigidbodyArray { get; }
        public UnityEngine.Vector3 EstimatedSkeletonPosition { get; }
        
        // Methods
        public UnityEngine.Rigidbody2D get_RootRigidbody()
        {
            return (UnityEngine.Rigidbody2D)this.<RootRigidbody>k__BackingField;
        }
        private void set_RootRigidbody(UnityEngine.Rigidbody2D value)
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
            return UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.rootOffset, y = V8.16B});
        }
        public bool get_IsActive()
        {
            return (bool)this.isActive;
        }
        private System.Collections.IEnumerator Start()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SkeletonRagdoll2D.<Start>d__32();
        }
        public UnityEngine.Rigidbody2D[] get_RigidbodyArray()
        {
            var val_8;
            var val_9;
            var val_10;
            if(this.isActive == false)
            {
                goto label_1;
            }
            
            int val_1 = this.boneTable.Count;
            val_8 = new UnityEngine.Rigidbody2D[0];
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
            val_8[val_9] = val_10.GetComponent<UnityEngine.Rigidbody2D>();
            label_5:
            if(0.MoveNext() == true)
            {
                goto label_11;
            }
            
            0.Dispose();
            return (UnityEngine.Rigidbody2D[])val_8;
            label_1:
            val_8 = new UnityEngine.Rigidbody2D[0];
            return (UnityEngine.Rigidbody2D[])val_8;
        }
        public UnityEngine.Vector3 get_EstimatedSkeletonPosition()
        {
            UnityEngine.Vector2 val_1 = this.<RootRigidbody>k__BackingField.position;
            UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, b:  new UnityEngine.Vector2() {x = this.rootOffset, y = V9.16B});
            return UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
        }
        public void Apply()
        {
            var val_6;
            var val_8;
            Spine.Skeleton val_46;
            var val_47;
            float val_48;
            UnityEngine.Collider2D val_49;
            UnityEngine.Transform val_50;
            float val_51;
            float val_52;
            float val_53;
            float val_54;
            float val_56;
            var val_58;
            var val_60;
            var val_61;
            int val_62;
            string val_64;
            Spine.Skeleton val_65;
            val_46 = this.skeleton;
            this.isActive = true;
            this.mix = 1f;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.Bone val_1 = val_46.FindBone(boneName:  this.startingBoneName);
            this.<StartingBone>k__BackingField = val_1;
            this.RecursivelyCreateBoneProxies(b:  val_1);
            val_46 = this.boneTable;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_2 = val_46.Item[val_1];
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Rigidbody2D val_3 = val_2.GetComponent<UnityEngine.Rigidbody2D>();
            this.<RootRigidbody>k__BackingField = val_3;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_47 = 0;
            val_3.isKinematic = this.pinStartBone;
            val_46 = this.<RootRigidbody>k__BackingField;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_48 = this.rootMass;
            val_46.mass = val_48;
            System.Collections.Generic.List<UnityEngine.Collider2D> val_4 = new System.Collections.Generic.List<UnityEngine.Collider2D>();
            val_46 = this.boneTable;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_5 = val_46.GetEnumerator();
            label_51:
            val_49 = public System.Boolean Dictionary.Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext();
            if(val_8.MoveNext() == false)
            {
                goto label_7;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = val_6.GetComponent<UnityEngine.Collider2D>();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = val_4;
            val_4.Add(item:  val_49);
            if(val_6 == val_1)
            {
                goto label_10;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_46 = this.boneTable;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = mem[val_6 + 32];
            val_49 = val_6 + 32;
            val_50 = val_46.Item[val_49];
            if(val_50 != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
            label_10:
            UnityEngine.GameObject val_12 = null;
            val_49 = "RagdollRoot";
            val_12 = new UnityEngine.GameObject(name:  val_49);
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_13 = val_12.transform;
            this.ragdollRoot = val_13;
            val_49 = this.transform;
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13.SetParent(parent:  val_49, worldPositionStays:  false);
            val_46 = this.skeleton;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = 0;
            if(val_1 != val_46.RootBone)
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_1.parent == null)
            {
                    throw new NullReferenceException();
            }
            
                val_8 = 0;
                val_46;
                val_49 = 0;
                val_46 = new UnityEngine.Vector3(x:  val_1.parent.worldX, y:  val_1.parent.worldY, z:  0f);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                val_46 = this.ragdollRoot;
                val_49 = 0;
                val_46.localPosition = new UnityEngine.Vector3() {x = val_46.x, y = val_46.y, z = val_46.z};
                if(val_1.parent == null)
            {
                    throw new NullReferenceException();
            }
            
                val_51 = val_1.parent.arotation;
                if(val_1.parent.parent != null)
            {
                    do
            {
                val_51 = val_51 + val_1.parent.parent.arotation;
            }
            while(val_1.parent.parent.parent != null);
            
            }
            
                val_52 = 0f;
                val_53 = 0f;
                val_54 = val_51;
                val_46 = 0;
                UnityEngine.Quaternion val_16 = UnityEngine.Quaternion.Euler(x:  val_52, y:  val_53, z:  val_54);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                this.ragdollRoot.localRotation = new UnityEngine.Quaternion() {x = val_16.x, y = val_16.y, z = val_16.z, w = val_16.w};
            }
            else
            {
                    if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_8 = 0;
                val_46;
                val_49 = 0;
                val_46 = new UnityEngine.Vector3(x:  val_1.worldX, y:  val_1.worldY, z:  0f);
                if(this.ragdollRoot == null)
            {
                    throw new NullReferenceException();
            }
            
                this.ragdollRoot.localPosition = new UnityEngine.Vector3() {x = val_46.x, y = val_46.y, z = val_46.z};
                val_56 = val_1.arotation;
                if(val_1.parent != null)
            {
                    do
            {
                val_56 = val_56 + val_1.parent.arotation;
            }
            while(val_1.parent.parent != null);
            
            }
            
                val_52 = 0f;
                val_53 = 0f;
                val_54 = val_56;
                UnityEngine.Quaternion val_17 = UnityEngine.Quaternion.Euler(x:  val_52, y:  val_53, z:  val_54);
                this.ragdollRoot.localRotation = new UnityEngine.Quaternion() {x = val_17.x, y = val_17.y, z = val_17.z, w = val_17.w};
            }
            
            val_50 = this.ragdollRoot;
            UnityEngine.Vector3 val_18 = val_6.position;
            val_49 = 0;
            UnityEngine.Transform val_19 = this.transform;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = 0;
            UnityEngine.Vector3 val_20 = val_19.position;
            UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, b:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z});
            val_48 = val_21.x;
            val_46 = 0;
            UnityEngine.Vector2 val_22 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_48, y = val_21.y, z = val_21.z});
            this.rootOffset = val_22;
            mem[1152921513296999148] = val_22.y;
            if(val_50 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_13:
            UnityEngine.Rigidbody2D val_23 = val_50.GetComponent<UnityEngine.Rigidbody2D>();
            if(val_23 == 0)
            {
                goto label_51;
            }
            
            val_49 = 0;
            UnityEngine.GameObject val_25 = val_6.gameObject;
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = public UnityEngine.HingeJoint2D UnityEngine.GameObject::AddComponent<UnityEngine.HingeJoint2D>();
            UnityEngine.HingeJoint2D val_26 = val_25.AddComponent<UnityEngine.HingeJoint2D>();
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_26.connectedBody = val_23;
            UnityEngine.Vector3 val_27 = val_6.position;
            UnityEngine.Vector3 val_28 = val_50.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_27.x, y = val_27.y, z = val_27.z});
            UnityEngine.Vector2 val_29 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_28.x, y = val_28.y, z = val_28.z});
            val_26.connectedAnchor = new UnityEngine.Vector2() {x = val_29.x, y = val_29.y};
            UnityEngine.Rigidbody2D val_30 = val_26.GetComponent<UnityEngine.Rigidbody2D>();
            val_49 = 0;
            UnityEngine.Rigidbody2D val_31 = val_26.connectedBody;
            if(val_31 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = 0;
            float val_32 = val_31.mass;
            if(val_30 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_32 = val_32 * this.massFalloffFactor;
            val_30.mass = val_32;
            0.min = -this.rotationLimit;
            0.max = this.rotationLimit;
            val_26.limits = new UnityEngine.JointAngleLimits2D() {m_LowerAngle = 0f, m_UpperAngle = 0f};
            val_26.useLimits = true;
            goto label_51;
            label_7:
            val_8.Dispose();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921513291969520 >= 1)
            {
                    if(1152921513291969520 >= 1)
            {
                    if(0 != 0)
            {
                    if(0 < 1152921513291969520)
            {
                    val_58 = 1152921513291969520;
            }
            else
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(X9 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_47 = 0;
                UnityEngine.Physics2D.IgnoreCollision(collider1:  null, collider2:  null);
            }
            
                val_60 = 0 + 1;
            }
            
                val_61 = 0 + 1;
            }
            
            T[] val_33 = this.GetComponentsInChildren<Spine.Unity.SkeletonUtilityBone>();
            if(val_33 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_33.Length != 0)
            {
                    System.Collections.Generic.List<System.String> val_34 = new System.Collections.Generic.List<System.String>();
                val_62 = val_33.Length;
                if(val_62 >= 1)
            {
                    val_60 = 1152921509851232320;
                do
            {
                if(null == null)
            {
                    throw new NullReferenceException();
            }
            
                UnityEngine.GameObject val_35 = 1152921506204592464.gameObject;
                if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_47 = public System.Void System.Collections.Generic.List<System.String>::Add(System.String item);
                val_34.Add(item:  val_35.name);
                val_46 = 1152921506204592464.gameObject;
                UnityEngine.Object.Destroy(obj:  val_46);
                val_62 = val_33.Length;
                val_61 = 0 + 1;
            }
            while(val_61 < val_62);
            
            }
            
                if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_62 >= 1)
            {
                    var val_47 = 0;
                val_61 = ",";
                do
            {
                if(val_47 >= val_62)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_47 = 0;
                val_62 = val_62 + 0;
                val_64 = "Destroyed Utility Bones: "("Destroyed Utility Bones: ") + (val_33.Length + 0) + 32((val_33.Length + 0) + 32);
                int val_39 = val_62 - 1;
                if(val_47 != val_39)
            {
                    val_47 = 0;
                val_64 = val_64 + ",";
            }
            
                val_47 = val_47 + 1;
            }
            while(val_47 < (val_62 << ));
            
                val_46 = val_64;
                UnityEngine.Debug.LogWarning(message:  val_46);
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
            
                if(val_39 >= 1)
            {
                    var val_48 = 0;
                do
            {
                if(X11 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_41 = X11 + 0;
                if(((X11 + 0) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_48 = val_48 + 1;
                mem2[0] = 0;
            }
            while(val_48 < val_39);
            
            }
            
            }
            
            if(this.disableOtherConstraints != false)
            {
                    val_65 = this.skeleton;
                if(val_65 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.skeleton.transformConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_39 >= 1)
            {
                    var val_49 = 4;
                do
            {
                if((X11 + 24) == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_42 = val_49 - 4;
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
            
                val_49 = val_49 + 1;
                var val_43 = val_49 - 4;
                mem2[0] = 0;
            }
            while(val_43 < val_39);
            
                val_65 = this.skeleton;
                if(val_65 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
                if(this.skeleton.pathConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_39 >= 1)
            {
                    var val_50 = 4;
                do
            {
                if(val_43 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_44 = val_50 - 4;
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
            
                val_50 = val_50 + 1;
                mem2[0] = 0;
            }
            while((val_50 - 4) < val_39);
            
            }
            
            }
            
            mem[1152921513297256336] = this;
            mem[1152921513297256344] = System.Void Spine.Unity.Modules.SkeletonRagdoll2D::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation animatedSkeleton);
            mem[1152921513297256320] = System.Void Spine.Unity.Modules.SkeletonRagdoll2D::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation animatedSkeleton);
            if(this.targetSkeletonComponent == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_51 = 0;
            val_51 = val_51 + 1;
            val_47 = 2;
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
            return (System.Collections.IEnumerator)new SkeletonRagdoll2D.<SmoothMixCoroutine>d__39();
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
            this.UpdateSpineSkeleton(animatedSkeleton:  public System.Void Dictionary.ValueCollection.Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose());
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
            mem[1152921513297827248] = this;
            mem[1152921513297827256] = System.Void Spine.Unity.Modules.SkeletonRagdoll2D::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation animatedSkeleton);
            mem[1152921513297827232] = System.Void Spine.Unity.Modules.SkeletonRagdoll2D::UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation animatedSkeleton);
            var val_9 = 0;
            val_9 = val_9 + 1;
            this.targetSkeletonComponent.remove_UpdateWorld(value:  new Spine.Unity.UpdateBonesDelegate());
        }
        public UnityEngine.Rigidbody2D GetRigidbody(string boneName)
        {
            var val_5;
            Spine.Bone val_1 = this.skeleton.FindBone(boneName:  boneName);
            if(val_1 == null)
            {
                    return (UnityEngine.Rigidbody2D)val_5;
            }
            
            if((this.boneTable.ContainsKey(key:  val_1)) != false)
            {
                    UnityEngine.Rigidbody2D val_4 = this.boneTable.Item[val_1].GetComponent<UnityEngine.Rigidbody2D>();
                return (UnityEngine.Rigidbody2D)val_5;
            }
            
            val_5 = 0;
            return (UnityEngine.Rigidbody2D)val_5;
        }
        private void RecursivelyCreateBoneProxies(Spine.Bone b)
        {
            UnityEngine.GameObject val_20;
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
            UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_21, y:  b.WorldScaleY, z:  0f);
            val_3.localScale = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            System.Collections.Generic.List<UnityEngine.Collider2D> val_12 = Spine.Unity.Modules.SkeletonRagdoll2D.AttachBoundingBoxRagdollColliders(b:  b, go:  val_2, skeleton:  this.skeleton);
            val_21 = b.data.length;
            if(val_21 == 0f)
            {
                    float val_20 = this.thickness;
                val_20 = val_20 * 0.5f;
                val_2.AddComponent<UnityEngine.CircleCollider2D>().radius = val_20;
            }
            else
            {
                    UnityEngine.BoxCollider2D val_14 = val_2.AddComponent<UnityEngine.BoxCollider2D>();
                UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_21, y:  this.thickness);
                val_14.size = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
                float val_21 = 0.5f;
                val_21 = val_21 * val_21;
                UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  val_21, y:  0f);
                val_14.offset = new UnityEngine.Vector2() {x = val_16.x, y = val_16.y};
            }
            
            val_2.AddComponent<UnityEngine.Rigidbody2D>().gravityScale = this.gravityScale;
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
        private void UpdateSpineSkeleton(Spine.Unity.ISkeletonAnimation animatedSkeleton)
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
            val_23 = Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            val_23.position = new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z};
            val_23 = Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23.rotation = new UnityEngine.Quaternion() {x = val_12.x, y = val_12.y, z = val_12.z, w = val_12.w};
            val_23 = val_25;
            val_24 = 0;
            UnityEngine.Vector3 val_13 = val_23.localScale;
            if(Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper;
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
            if(Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            UnityEngine.Vector3 val_16 = Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper.InverseTransformDirection(direction:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z});
            val_23 = Spine.Unity.Modules.SkeletonRagdoll2D.parentSpaceHelper;
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
        private static System.Collections.Generic.List<UnityEngine.Collider2D> AttachBoundingBoxRagdollColliders(Spine.Bone b, UnityEngine.GameObject go, Spine.Skeleton skeleton)
        {
            Spine.Slot val_4;
            var val_5;
            Spine.Skin val_14;
            Spine.Slot val_15;
            System.Collections.Generic.List<UnityEngine.Collider2D> val_1 = new System.Collections.Generic.List<UnityEngine.Collider2D>();
            if(skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = skeleton.skin;
            if(val_14 == null)
            {
                    if(skeleton.data == null)
            {
                    throw new NullReferenceException();
            }
            
                val_14 = skeleton.data.defaultSkin;
            }
            
            System.Collections.Generic.List<Spine.Attachment> val_2 = new System.Collections.Generic.List<Spine.Attachment>();
            if(skeleton.slots == null)
            {
                    throw new NullReferenceException();
            }
            
            ExposedList.Enumerator<T> val_3 = skeleton.slots.GetEnumerator();
            label_23:
            if(val_5.MoveNext() == false)
            {
                goto label_5;
            }
            
            val_15 = val_4;
            if(val_15 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_4 + 24) != b)
            {
                goto label_23;
            }
            
            if(skeleton.slots == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_14 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_14.FindAttachmentsForSlot(slotIndex:  skeleton.slots.IndexOf(item:  val_15), attachments:  val_2);
            List.Enumerator<T> val_8 = val_2.GetEnumerator();
            label_19:
            if(val_5.MoveNext() == false)
            {
                goto label_11;
            }
            
            if(val_4 == 0)
            {
                goto label_19;
            }
            
            if((val_4 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_10 = val_4 + 16.ToLower();
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_10.Contains(value:  "ragdoll")) == false)
            {
                goto label_19;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  Spine.Unity.SkeletonUtility.AddBoundingBoxAsComponent(box:  val_4, slot:  val_15, gameObject:  go, isTrigger:  false));
            goto label_19;
            label_11:
            val_15 = 0;
            var val_13 = 0 + 1;
            mem2[0] = 192;
            val_5.Dispose();
            if(val_15 != 0)
            {
                    throw val_15;
            }
            
            if((val_13 == 1) || ((101742304 + ((0 + 1)) << 2) != 192))
            {
                goto label_23;
            }
            
            var val_16 = 0;
            val_16 = val_16 ^ (val_13 >> 31);
            var val_14 = val_13 + val_16;
            goto label_23;
            label_5:
            var val_15 = 0 + 1;
            mem2[0] = 220;
            val_5.Dispose();
            return val_1;
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
        private static UnityEngine.Vector3 FlipScale(bool flipX, bool flipY)
        {
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  (flipX != true) ? -1f : 1f, y:  (flipY != true) ? -1f : 1f, z:  1f);
            return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        public SkeletonRagdoll2D()
        {
            this.startingBoneName = "";
            this.stopBoneNames = new System.Collections.Generic.List<System.String>();
            this.disableIK = true;
            this.massFalloffFactor = 0.4f;
            this.mix = 1f;
            this.gravityScale = ;
            this.thickness = ;
            this.rotationLimit = 20f;
            this.rootMass = 20f;
            this.boneTable = new System.Collections.Generic.Dictionary<Spine.Bone, UnityEngine.Transform>();
        }
    
    }

}

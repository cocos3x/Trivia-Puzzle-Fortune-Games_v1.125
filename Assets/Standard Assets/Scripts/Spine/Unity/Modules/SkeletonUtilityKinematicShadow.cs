using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonUtilityKinematicShadow : MonoBehaviour
    {
        // Fields
        public bool detachedShadow;
        public UnityEngine.Transform parent;
        public bool hideShadow;
        private UnityEngine.GameObject shadowRoot;
        private readonly System.Collections.Generic.List<Spine.Unity.Modules.SkeletonUtilityKinematicShadow.TransformPair> shadowTable;
        
        // Methods
        private void Start()
        {
            float val_35;
            UnityEngine.Transform val_36;
            UnityEngine.Object val_37;
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.gameObject);
            this.shadowRoot = val_2;
            UnityEngine.Object.Destroy(obj:  val_2.GetComponent<Spine.Unity.Modules.SkeletonUtilityKinematicShadow>());
            UnityEngine.Transform val_4 = this.shadowRoot.transform;
            UnityEngine.Vector3 val_6 = this.transform.position;
            val_4.position = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            UnityEngine.Quaternion val_8 = this.transform.rotation;
            val_4.rotation = new UnityEngine.Quaternion() {x = val_8.x, y = val_8.y, z = val_8.z, w = val_8.w};
            UnityEngine.Vector3 val_10 = UnityEngine.Vector3.right;
            UnityEngine.Vector3 val_11 = this.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            val_35 = val_11.z;
            UnityEngine.Vector3 val_13 = this.transform.position;
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.one;
            val_4.localScale = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
            if(this.detachedShadow != true)
            {
                    if(this.parent == 0)
            {
                    val_36 = this.transform.root;
            }
            else
            {
                    val_36 = this.parent;
            }
            
                val_4.parent = val_36;
            }
            
            if(this.hideShadow != false)
            {
                    this.shadowRoot.hideFlags = 1;
            }
            
            if(val_19.Length >= 1)
            {
                    do
            {
                T val_35 = this.shadowRoot.GetComponentsInChildren<UnityEngine.Joint>()[0];
                UnityEngine.Vector3 val_20 = val_35.connectedAnchor;
                val_35 = val_20.y;
                UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_20.x, y = val_35, z = val_20.z}, d:  UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, b:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_35}));
                val_35.connectedAnchor = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
                val_37 = 0 + 1;
            }
            while(val_37 < val_19.Length);
            
            }
            
            T[] val_23 = this.shadowRoot.GetComponentsInChildren<Spine.Unity.SkeletonUtilityBone>();
            if(val_22.Length < 1)
            {
                goto label_30;
            }
            
            var val_38 = 0;
            label_47:
            T val_36 = this.GetComponentsInChildren<Spine.Unity.SkeletonUtilityBone>()[val_38];
            val_37 = val_36.gameObject;
            if((val_37 == this.gameObject) || (val_23.Length < 1))
            {
                goto label_45;
            }
            
            var val_37 = 0;
            do
            {
                val_37 = val_23[val_37];
                if((val_37.GetComponent<UnityEngine.Rigidbody>()) != 0)
            {
                    if((System.String.op_Equality(a:  val_23[0x0][0] + 24, b:  val_22[0x0][0] + 24)) == true)
            {
                goto label_43;
            }
            
            }
            
                val_37 = val_37 + 1;
            }
            while(val_37 < val_23.Length);
            
            goto label_45;
            label_43:
            UnityEngine.Transform val_31 = val_37.transform;
            this.shadowTable.Add(item:  new TransformPair() {dest = val_36.transform, src = val_31});
            label_45:
            val_38 = val_38 + 1;
            if(val_38 < val_22.Length)
            {
                goto label_47;
            }
            
            label_30:
            Spine.Unity.Modules.SkeletonUtilityKinematicShadow.DestroyComponents(components:  val_23);
            Spine.Unity.Modules.SkeletonUtilityKinematicShadow.DestroyComponents(components:  val_31.GetComponentsInChildren<UnityEngine.Joint>());
            Spine.Unity.Modules.SkeletonUtilityKinematicShadow.DestroyComponents(components:  val_31.GetComponentsInChildren<UnityEngine.Rigidbody>());
            Spine.Unity.Modules.SkeletonUtilityKinematicShadow.DestroyComponents(components:  val_31.GetComponentsInChildren<UnityEngine.Collider>());
        }
        private static void DestroyComponents(UnityEngine.Component[] components)
        {
            int val_1 = components.Length;
            if(val_1 < 1)
            {
                    return;
            }
            
            val_1 = val_1 & 4294967295;
            var val_2 = 0;
            do
            {
                UnityEngine.Object.Destroy(obj:  1152921506204403984);
                val_2 = val_2 + 1;
                if(val_2 >= (long)val_1)
            {
                    return;
            }
            
            }
            while(val_2 < components.Length);
            
            throw new IndexOutOfRangeException();
        }
        private void FixedUpdate()
        {
            UnityEngine.Rigidbody val_1 = this.shadowRoot.GetComponent<UnityEngine.Rigidbody>();
            UnityEngine.Vector3 val_3 = this.transform.position;
            val_1.MovePosition(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            UnityEngine.Quaternion val_5 = this.transform.rotation;
            val_1.MoveRotation(rot:  new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w});
            if(W22 < 1)
            {
                    return;
            }
            
            var val_8 = 0;
            do
            {
                if(1152921513305912512 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Vector3 val_6 = localPosition;
                localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
                UnityEngine.Quaternion val_7 = localRotation;
                localRotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
                val_8 = val_8 + 1;
                if(val_8 >= W22)
            {
                    return;
            }
            
            }
            while(this.shadowTable != null);
            
            throw new NullReferenceException();
        }
        public SkeletonUtilityKinematicShadow()
        {
            this.hideShadow = true;
            this.shadowTable = new System.Collections.Generic.List<TransformPair>();
        }
    
    }

}

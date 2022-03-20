using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonUtilityEyeConstraint : SkeletonUtilityConstraint
    {
        // Fields
        public UnityEngine.Transform[] eyes;
        public float radius;
        public UnityEngine.Transform target;
        public UnityEngine.Vector3 targetPosition;
        public float speed;
        private UnityEngine.Vector3[] origins;
        private UnityEngine.Vector3 centerPoint;
        
        // Methods
        protected override void OnEnable()
        {
            float val_8;
            float val_9;
            float val_10;
            var val_11;
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            this.OnEnable();
            UnityEngine.Vector3 val_2 = this.eyes[0].localPosition;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
            val_8 = val_2.x;
            val_9 = val_2.y;
            val_10 = val_2.z;
            UnityEngine.Bounds val_4 = new UnityEngine.Bounds(center:  new UnityEngine.Vector3() {x = val_8, y = val_9, z = val_10}, size:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            this.origins = new UnityEngine.Vector3[0];
            val_11 = 0;
            var val_11 = 0;
            label_16:
            if(val_11 >= this.eyes.Length)
            {
                goto label_9;
            }
            
            UnityEngine.Vector3 val_6 = this.eyes[val_11].localPosition;
            this.origins[val_11] = val_6;
            this.origins[val_11] = val_6.y;
            this.origins[val_11] = val_6.z;
            val_11 = val_11 + 1;
            var val_7 = val_11 - 1;
            val_8 = this.origins[val_11];
            val_9 = this.origins[val_11];
            val_10 = this.origins[val_11];
            val_11 = val_11 + 12;
            val_4.m_Center.x.Encapsulate(point:  new UnityEngine.Vector3() {x = val_8, y = val_9, z = val_10});
            if(this.eyes != null)
            {
                goto label_16;
            }
            
            throw new NullReferenceException();
            label_9:
            UnityEngine.Vector3 val_8 = val_4.m_Center.x.center;
            this.centerPoint = val_8;
            mem[1152921513303457820] = val_8.y;
            mem[1152921513303457824] = val_8.z;
        }
        protected override void OnDisable()
        {
            if(UnityEngine.Application.isPlaying == false)
            {
                    return;
            }
            
            this.OnDisable();
        }
        public override void DoUpdate()
        {
            UnityEngine.Vector3 val_15;
            var val_16;
            float val_17;
            float val_18;
            if(this.target != 0)
            {
                    UnityEngine.Vector3 val_2 = this.target.position;
                val_15 = val_2.x;
                val_16 = val_2.y;
                val_17 = val_2.z;
                this.targetPosition = val_2;
                mem[1152921513304083204] = val_2.y;
                mem[1152921513304083208] = val_2.z;
            }
            else
            {
                    val_15 = this.targetPosition;
            }
            
            UnityEngine.Vector3 val_4 = this.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = this.centerPoint});
            val_18 = val_4.y;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_15, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = val_4.x, y = val_18, z = val_4.z});
            if(val_5.x.magnitude > 1f)
            {
                    val_5.x.Normalize();
            }
            
            var val_20 = 0;
            var val_19 = 0;
            do
            {
                if(val_19 >= this.eyes.Length)
            {
                    return;
            }
            
                UnityEngine.Vector3 val_8 = this.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = this.origins[val_20], y = this.origins[val_20], z = this.origins[val_20]});
                UnityEngine.Transform val_18 = this.eyes[val_19];
                UnityEngine.Vector3 val_9 = val_18.position;
                val_18 = val_5.x;
                UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_18, y = val_5.y, z = val_5.z}, d:  this.radius);
                UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, b:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
                val_15 = val_11.x;
                val_17 = val_11.z;
                UnityEngine.Vector3 val_14 = UnityEngine.Vector3.MoveTowards(current:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, target:  new UnityEngine.Vector3() {x = val_15, y = val_11.y, z = val_17}, maxDistanceDelta:  this.speed * UnityEngine.Time.deltaTime);
                val_18.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
                val_19 = val_19 + 1;
                val_20 = val_20 + 12;
            }
            while(this.eyes != null);
            
            throw new NullReferenceException();
        }
        public SkeletonUtilityEyeConstraint()
        {
            this.radius = 0.5f;
            this.speed = 10f;
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}

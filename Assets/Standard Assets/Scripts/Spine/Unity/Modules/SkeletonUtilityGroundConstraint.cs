using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonUtilityGroundConstraint : SkeletonUtilityConstraint
    {
        // Fields
        public UnityEngine.LayerMask groundMask;
        public bool use2D;
        public bool useRadius;
        public float castRadius;
        public float castDistance;
        public float castOffset;
        public float groundOffset;
        public float adjustSpeed;
        private UnityEngine.Vector3 rayOrigin;
        private UnityEngine.Vector3 rayDir;
        private float hitY;
        private float lastHitY;
        
        // Methods
        protected override void OnEnable()
        {
            this.OnEnable();
            UnityEngine.Vector3 val_2 = this.transform.position;
            this.lastHitY = val_2.y;
        }
        public override void DoUpdate()
        {
            float val_47;
            float val_48;
            float val_49;
            float val_50;
            float val_51;
            float val_52;
            UnityEngine.Vector3 val_2 = this.transform.position;
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  this.castOffset, y:  this.castDistance, z:  0f);
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            val_47 = val_4.y;
            this.rayOrigin = val_4;
            mem[1152921513304632168] = val_4.y;
            mem[1152921513304632172] = val_4.z;
            this.hitY = -3.402823E+38f;
            if(this.use2D == false)
            {
                goto label_4;
            }
            
            if(this.useRadius == false)
            {
                goto label_5;
            }
            
            UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_4.x, y = val_47, z = val_4.z});
            val_47 = this.castRadius;
            UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = this.rayDir, y = val_3.x, z = val_4.z});
            val_48 = this.groundOffset;
            val_49 = val_6.y;
            val_50 = val_5.x;
            val_51 = val_5.y;
            val_52 = val_47;
            UnityEngine.RaycastHit2D val_9 = UnityEngine.Physics2D.CircleCast(origin:  new UnityEngine.Vector2() {x = val_50, y = val_51}, radius:  val_52, direction:  new UnityEngine.Vector2() {x = val_6.x, y = val_49}, distance:  this.castDistance + val_48, layerMask:  UnityEngine.LayerMask.op_Implicit(mask:  new UnityEngine.LayerMask() {m_Mask = this.groundMask}));
            goto label_10;
            label_4:
            if(this.useRadius == false)
            {
                goto label_11;
            }
            
            val_48 = this.castRadius;
            val_50 = val_4.x;
            val_51 = val_47;
            val_52 = val_4.z;
            if((UnityEngine.Physics.SphereCast(origin:  new UnityEngine.Vector3() {x = val_50, y = val_51, z = val_52}, radius:  val_48, direction:  new UnityEngine.Vector3() {x = this.rayDir, y = V12.16B, z = V13.16B}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Normal = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Distance = 0f, m_UV = new UnityEngine.Vector2() {x = 0f, y = 0f}}, maxDistance:  this.castDistance + this.groundOffset, layerMask:  UnityEngine.LayerMask.op_Implicit(mask:  new UnityEngine.LayerMask() {m_Mask = this.groundMask}))) == true)
            {
                goto label_12;
            }
            
            goto label_22;
            label_5:
            UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_4.x, y = val_47, z = val_4.z});
            val_47 = val_13.y;
            UnityEngine.Vector2 val_14 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = this.rayDir, y = val_3.x, z = val_4.z});
            val_49 = this.castDistance;
            val_50 = val_13.x;
            val_51 = val_47;
            val_52 = val_14.x;
            UnityEngine.RaycastHit2D val_17 = UnityEngine.Physics2D.Raycast(origin:  new UnityEngine.Vector2() {x = val_50, y = val_51}, direction:  new UnityEngine.Vector2() {x = val_52, y = val_14.y}, distance:  val_49 + this.groundOffset, layerMask:  UnityEngine.LayerMask.op_Implicit(mask:  new UnityEngine.LayerMask() {m_Mask = this.groundMask}));
            label_10:
            if(val_3.x.collider == 0)
            {
                goto label_22;
            }
            
            UnityEngine.Vector2 val_22 = val_3.x.point;
            goto label_21;
            label_11:
            val_48 = this.castDistance;
            val_50 = val_4.x;
            val_51 = val_47;
            val_52 = val_4.z;
            if((UnityEngine.Physics.Raycast(origin:  new UnityEngine.Vector3() {x = val_50, y = val_51, z = val_52}, direction:  new UnityEngine.Vector3() {x = this.rayDir, y = V12.16B, z = V13.16B}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Normal = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Distance = 0f, m_UV = new UnityEngine.Vector2() {x = 0f, y = 0f}}, maxDistance:  val_48 + this.groundOffset, layerMask:  UnityEngine.LayerMask.op_Implicit(mask:  new UnityEngine.LayerMask() {m_Mask = this.groundMask}))) == false)
            {
                goto label_22;
            }
            
            label_12:
            UnityEngine.Vector3 val_26 = 0.point;
            label_21:
            val_50 = val_26.y + this.groundOffset;
            this.hitY = val_50;
            if(UnityEngine.Application.isPlaying == false)
            {
                goto label_27;
            }
            
            val_52 = this.adjustSpeed * UnityEngine.Time.deltaTime;
            val_50 = this.lastHitY;
            val_51 = this.hitY;
            goto label_26;
            label_22:
            if(UnityEngine.Application.isPlaying == false)
            {
                goto label_27;
            }
            
            UnityEngine.Vector3 val_31 = this.transform.position;
            val_52 = this.adjustSpeed * UnityEngine.Time.deltaTime;
            val_50 = this.lastHitY;
            val_51 = val_31.y;
            label_26:
            this.hitY = UnityEngine.Mathf.MoveTowards(current:  val_50, target:  val_51, maxDelta:  val_52);
            label_27:
            UnityEngine.Vector3 val_35 = this.transform.position;
            this.transform.position = new UnityEngine.Vector3() {x = val_35.x, y = UnityEngine.Mathf.Clamp(value:  val_35.y, min:  UnityEngine.Mathf.Min(a:  this.lastHitY, b:  this.hitY), max:  3.402823E+38f), z = val_35.z};
            UnityEngine.Vector3 val_40 = this.transform.localPosition;
            mem[34359738416] = val_40.x;
            UnityEngine.Vector3 val_42 = this.transform.localPosition;
            mem[34359738420] = val_42.y;
            this.lastHitY = this.hitY;
        }
        private void OnDrawGizmos()
        {
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.rayDir, y = V13.16B, z = V12.16B}, d:  UnityEngine.Mathf.Min(a:  this.castDistance, b:  S9 - this.hitY));
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.rayOrigin, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.rayDir, y = val_4.y, z = val_3.y}, d:  this.castDistance);
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.rayOrigin, y = V12.16B, z = V13.16B}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
            UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = this.rayOrigin, y = val_6.y, z = val_5.x}, to:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
            if(this.useRadius != false)
            {
                    float val_12 = this.castRadius;
                float val_13 = this.groundOffset;
                val_12 = val_4.x - val_12;
                val_13 = val_4.y - val_13;
                UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  val_12, y:  val_13, z:  val_4.z);
                float val_14 = this.castRadius;
                float val_15 = this.groundOffset;
                val_14 = val_4.x + val_14;
                val_15 = val_4.y - val_15;
                UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  val_14, y:  val_15, z:  val_4.z);
                UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, to:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
                float val_16 = this.castRadius;
                val_16 = val_6.x - val_16;
                UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  val_16, y:  val_6.y, z:  val_6.z);
                float val_17 = this.castRadius;
                UnityEngine.Vector3 val_10;
                val_17 = val_6.x + val_17;
                val_10 = new UnityEngine.Vector3(x:  val_17, y:  val_6.y, z:  val_6.z);
                UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, to:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            }
            
            UnityEngine.Color val_11 = UnityEngine.Color.red;
            UnityEngine.Gizmos.color = new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a};
            UnityEngine.Gizmos.DrawLine(from:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, to:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        }
        public SkeletonUtilityGroundConstraint()
        {
            this.adjustSpeed = 5f;
            this.castRadius = 0.1f;
            this.castDistance = 5f;
            UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0f, y:  -1f, z:  0f);
            this.rayDir = val_1.x;
            mem[1152921513304893016] = val_1.z;
            this = new UnityEngine.MonoBehaviour();
        }
    
    }

}

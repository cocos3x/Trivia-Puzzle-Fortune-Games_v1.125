using UnityEngine;

namespace EpicToonFX
{
    public class ETFXMouseOrbit : MonoBehaviour
    {
        // Fields
        public UnityEngine.Transform target;
        public float distance;
        public float xSpeed;
        public float ySpeed;
        public float yMinLimit;
        public float yMaxLimit;
        public float distanceMin;
        public float distanceMax;
        public float smoothTime;
        private float rotationYAxis;
        private float rotationXAxis;
        private float velocityX;
        private float velocityY;
        
        // Methods
        private void Start()
        {
            UnityEngine.Vector3 val_2 = this.transform.eulerAngles;
            this.rotationYAxis = val_2.y;
            this.rotationXAxis = val_2.x;
            if((UnityEngine.Object.op_Implicit(exists:  this.GetComponent<UnityEngine.Rigidbody>())) == false)
            {
                    return;
            }
            
            this.GetComponent<UnityEngine.Rigidbody>().freezeRotation = true;
        }
        private void LateUpdate()
        {
            float val_26;
            float val_28;
            if((UnityEngine.Object.op_Implicit(exists:  this.target)) == false)
            {
                    return;
            }
            
            if((UnityEngine.Input.GetMouseButton(button:  1)) != false)
            {
                    float val_3 = UnityEngine.Input.GetAxis(axisName:  "Mouse X");
                val_3 = this.xSpeed * val_3;
                val_3 = val_3 * this.distance;
                val_3 = val_3 * 0.02f;
                val_3 = this.velocityX + val_3;
                this.velocityX = val_3;
                float val_4 = UnityEngine.Input.GetAxis(axisName:  "Mouse Y");
                val_4 = this.ySpeed * val_4;
                val_4 = val_4 * 0.02f;
                val_26 = this.velocityY + val_4;
                this.velocityY = val_26;
            }
            else
            {
                    val_26 = this.velocityY;
            }
            
            float val_26 = this.velocityX;
            val_26 = this.rotationXAxis - val_26;
            val_26 = this.rotationYAxis + val_26;
            this.rotationYAxis = val_26;
            this.rotationXAxis = val_26;
            float val_5 = EpicToonFX.ETFXMouseOrbit.ClampAngle(angle:  val_26, min:  this.yMinLimit, max:  this.yMaxLimit);
            this.rotationXAxis = val_5;
            UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.Euler(x:  val_5, y:  this.rotationYAxis, z:  0f);
            float val_27 = -5f;
            val_27 = (UnityEngine.Input.GetAxis(axisName:  "Mouse ScrollWheel")) * val_27;
            val_27 = this.distance + val_27;
            this.distance = UnityEngine.Mathf.Clamp(value:  val_27, min:  this.distanceMin, max:  this.distanceMax);
            UnityEngine.Vector3 val_9 = this.target.position;
            UnityEngine.Vector3 val_11 = this.transform.position;
            val_28 = this.distance;
            if((UnityEngine.Physics.Linecast(start:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, end:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Normal = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Distance = 0f, m_UV = new UnityEngine.Vector2() {x = 0f, y = 0f}})) != false)
            {
                    val_28 = val_28 - 0.distance;
                this.distance = val_28;
            }
            
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  -val_28);
            UnityEngine.Vector3 val_15 = UnityEngine.Quaternion.op_Multiply(rotation:  new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w}, point:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            UnityEngine.Vector3 val_16 = this.target.position;
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
            this.transform.rotation = new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w};
            this.transform.position = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
            this.velocityX = UnityEngine.Mathf.Lerp(a:  this.velocityX, b:  0f, t:  UnityEngine.Time.deltaTime * this.smoothTime);
            this.velocityY = UnityEngine.Mathf.Lerp(a:  this.velocityY, b:  0f, t:  UnityEngine.Time.deltaTime * this.smoothTime);
        }
        public static float ClampAngle(float angle, float min, float max)
        {
            float val_4 = angle;
            float val_3 = -360f;
            float val_2 = (val_4 < 0) ? (val_4 + 360f) : (val_4);
            val_3 = val_2 + val_3;
            val_4 = (val_2 > 360f) ? (val_3) : (val_2);
            return UnityEngine.Mathf.Clamp(value:  val_4, min:  min, max:  max);
        }
        public ETFXMouseOrbit()
        {
            this.distance = ;
            this.xSpeed = ;
            this.ySpeed = 120f;
            this.yMinLimit = -20f;
            this.yMaxLimit = ;
            this.distanceMin = ;
            this.distanceMax = 15f;
            this.smoothTime = 2f;
        }
    
    }

}

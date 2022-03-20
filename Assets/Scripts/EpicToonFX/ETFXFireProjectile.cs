using UnityEngine;

namespace EpicToonFX
{
    public class ETFXFireProjectile : MonoBehaviour
    {
        // Fields
        public UnityEngine.GameObject[] projectiles;
        public UnityEngine.Transform spawnPosition;
        public int currentProjectile;
        public float speed;
        private EpicToonFX.ETFXButtonScript selectedProjectileButton;
        private UnityEngine.RaycastHit hit;
        
        // Methods
        private void Start()
        {
            this.selectedProjectileButton = UnityEngine.GameObject.Find(name:  "Button").GetComponent<EpicToonFX.ETFXButtonScript>();
        }
        private void Update()
        {
            float val_11;
            float val_12;
            var val_31;
            float val_36;
            if((UnityEngine.Input.GetKeyDown(key:  19)) != false)
            {
                    this.nextEffect();
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  100)) != false)
            {
                    this.nextEffect();
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  97)) != true)
            {
                    if((UnityEngine.Input.GetKeyDown(key:  20)) == false)
            {
                goto label_4;
            }
            
            }
            
            this.previousEffect();
            label_4:
            if(((UnityEngine.Input.GetKeyDown(key:  67)) != false) && (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() != true))
            {
                    UnityEngine.Vector3 val_9 = UnityEngine.Input.mousePosition;
                UnityEngine.Ray val_10 = UnityEngine.Camera.main.ScreenPointToRay(pos:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
                val_36 = 100f;
                if((UnityEngine.Physics.Raycast(ray:  new UnityEngine.Ray() {m_Origin = new UnityEngine.Vector3() {x = val_12, y = val_12, z = val_12}, m_Direction = new UnityEngine.Vector3() {x = val_12, y = val_11, z = val_11}}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = this.hit, y = this.hit, z = this.hit}, m_Normal = new UnityEngine.Vector3() {x = this.hit, y = this.hit, z = this.hit}, m_FaceID = this.hit, m_Distance = this.hit, m_UV = new UnityEngine.Vector2() {x = this.hit, y = this.hit}, m_Collider = this.hit}, maxDistance:  val_36)) != false)
            {
                    UnityEngine.Vector3 val_14 = this.spawnPosition.position;
                UnityEngine.Quaternion val_15 = UnityEngine.Quaternion.identity;
                UnityEngine.GameObject val_16 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.projectiles[this.currentProjectile], position:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, rotation:  new UnityEngine.Quaternion() {x = val_15.x, y = val_15.y, z = val_15.z, w = val_15.w});
                UnityEngine.Vector3 val_18 = this.hit.point;
                val_16.transform.LookAt(worldPosition:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z});
                UnityEngine.Vector3 val_21 = val_16.transform.forward;
                val_36 = val_21.x;
                UnityEngine.Vector3 val_22 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_36, y = val_21.y, z = val_21.z}, d:  this.speed);
                val_16.GetComponent<UnityEngine.Rigidbody>().AddForce(force:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z});
            }
            
            }
            
            UnityEngine.Vector3 val_24 = UnityEngine.Input.mousePosition;
            UnityEngine.Ray val_25 = UnityEngine.Camera.main.ScreenPointToRay(pos:  new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z});
            UnityEngine.Vector3 val_26 = val_12.origin;
            UnityEngine.Vector3 val_28 = UnityEngine.Input.mousePosition;
            UnityEngine.Ray val_29 = UnityEngine.Camera.main.ScreenPointToRay(pos:  new UnityEngine.Vector3() {x = val_28.x, y = val_28.y, z = val_28.z});
            UnityEngine.Vector3 val_32 = val_31.direction;
            UnityEngine.Vector3 val_33 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z}, d:  100f);
            UnityEngine.Color val_34 = UnityEngine.Color.yellow;
            UnityEngine.Debug.DrawRay(start:  new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z}, dir:  new UnityEngine.Vector3() {x = val_33.x, y = val_33.y, z = val_33.z}, color:  new UnityEngine.Color() {r = val_34.r, g = val_34.b, b = val_26.z});
        }
        public void nextEffect()
        {
            int val_2 = this.projectiles.Length;
            val_2 = val_2 - 1;
            this.currentProjectile = (this.currentProjectile >= val_2) ? 0 : (this.currentProjectile + 1);
            this.selectedProjectileButton.getProjectileNames();
        }
        public void previousEffect()
        {
            int val_1;
            val_1 = this.currentProjectile;
            if(val_1 <= 0)
            {
                    val_1 = this.projectiles.Length;
            }
            
            val_1 = val_1 - 1;
            this.currentProjectile = val_1;
            this.selectedProjectileButton.getProjectileNames();
        }
        public void AdjustSpeed(float newSpeed)
        {
            this.speed = newSpeed;
        }
        public ETFXFireProjectile()
        {
            this.speed = 500f;
        }
    
    }

}

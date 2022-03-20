using UnityEngine;
public class ETFXProjectileScript : MonoBehaviour
{
    // Fields
    public UnityEngine.GameObject impactParticle;
    public UnityEngine.GameObject projectileParticle;
    public UnityEngine.GameObject muzzleParticle;
    public float colliderRadius;
    public float collideOffset;
    
    // Methods
    private void Start()
    {
        UnityEngine.Vector3 val_2 = this.transform.position;
        UnityEngine.Quaternion val_4 = this.transform.rotation;
        UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.projectileParticle, position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w});
        this.projectileParticle = val_5;
        val_5.transform.parent = this.transform;
        if((UnityEngine.Object.op_Implicit(exists:  this.muzzleParticle)) == false)
        {
                return;
        }
        
        UnityEngine.Vector3 val_10 = this.transform.position;
        UnityEngine.Quaternion val_12 = this.transform.rotation;
        UnityEngine.GameObject val_13 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.muzzleParticle, position:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, rotation:  new UnityEngine.Quaternion() {x = val_12.x, y = val_12.y, z = val_12.z, w = val_12.w});
        this.muzzleParticle = val_13;
        UnityEngine.Object.Destroy(obj:  val_13, t:  1.5f);
    }
    private void FixedUpdate()
    {
        UnityEngine.GameObject val_51;
        float val_52;
        float val_53;
        float val_54;
        float val_55;
        float val_56;
        float val_57;
        float val_58;
        val_51 = 1152921509959238048;
        val_52 = 0;
        UnityEngine.Vector3 val_2 = this.GetComponent<UnityEngine.Rigidbody>().velocity;
        if(val_2.x.magnitude != 0f)
        {
                UnityEngine.Vector3 val_6 = this.GetComponent<UnityEngine.Rigidbody>().velocity;
            val_52 = val_6.x;
            val_53 = val_6.y;
            val_54 = val_6.z;
            UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_52, y = val_53, z = val_54});
            this.transform.rotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.transform.GetComponent<UnityEngine.SphereCollider>())) != false)
        {
                val_55 = this.transform.GetComponent<UnityEngine.SphereCollider>().radius;
        }
        else
        {
                val_55 = this.colliderRadius;
        }
        
        UnityEngine.Vector3 val_16 = this.transform.GetComponent<UnityEngine.Rigidbody>().velocity;
        if((this.transform.GetComponent<UnityEngine.Rigidbody>().useGravity) != false)
        {
                UnityEngine.Vector3 val_20 = UnityEngine.Physics.gravity;
            val_56 = val_20.x;
            val_57 = val_20.z;
            UnityEngine.Vector3 val_22 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_56, y = val_20.y, z = val_57}, d:  UnityEngine.Time.deltaTime);
            val_52 = val_16.x;
            val_53 = val_16.y;
            val_54 = val_16.z;
            UnityEngine.Vector3 val_23 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_52, y = val_53, z = val_54}, b:  new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z});
        }
        
        UnityEngine.Vector3 val_24 = val_23.x.normalized;
        UnityEngine.Vector3 val_27 = this.transform.GetComponent<UnityEngine.Rigidbody>().velocity;
        float val_51 = val_27.x.magnitude;
        val_58 = UnityEngine.Time.deltaTime;
        val_51 = val_51 * val_58;
        UnityEngine.Vector3 val_31 = this.transform.position;
        if((UnityEngine.Physics.SphereCast(origin:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z}, radius:  val_55, direction:  new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Normal = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Distance = 0f, m_UV = new UnityEngine.Vector2() {x = 0f, y = 0f}}, maxDistance:  val_51)) == false)
        {
                return;
        }
        
        UnityEngine.Vector3 val_34 = val_52.point;
        UnityEngine.Vector3 val_35 = val_52.normal;
        UnityEngine.Vector3 val_36 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z}, d:  this.collideOffset);
        UnityEngine.Vector3 val_37 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z}, b:  new UnityEngine.Vector3() {x = val_36.x, y = val_36.y, z = val_36.z});
        this.transform.position = new UnityEngine.Vector3() {x = val_37.x, y = val_37.y, z = val_37.z};
        UnityEngine.Vector3 val_39 = this.transform.position;
        val_58 = val_39.z;
        UnityEngine.Vector3 val_40 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_41 = val_52.normal;
        val_57 = val_41.x;
        UnityEngine.Quaternion val_42 = UnityEngine.Quaternion.FromToRotation(fromDirection:  new UnityEngine.Vector3() {x = val_40.x, y = val_40.y, z = val_40.z}, toDirection:  new UnityEngine.Vector3() {x = val_57, y = val_41.y, z = val_41.z});
        val_56 = val_42.y;
        val_55 = val_42.w;
        if(val_44.Length >= 2)
        {
                var val_53 = 1;
            val_55 = 2f;
            do
        {
            T val_52 = this.GetComponentsInChildren<UnityEngine.ParticleSystem>()[val_53];
            if((val_52.gameObject.name.Contains(value:  "Trail")) != false)
        {
                val_52.transform.SetParent(p:  0);
            UnityEngine.Object.Destroy(obj:  val_52.gameObject, t:  val_55);
        }
        
            val_53 = val_53 + 1;
        }
        while(val_53 < val_44.Length);
        
        }
        
        val_51 = this.projectileParticle;
        UnityEngine.Object.Destroy(obj:  val_51, t:  3f);
        UnityEngine.Object.Destroy(obj:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.impactParticle, position:  new UnityEngine.Vector3() {x = val_39.x, y = val_39.y, z = val_58}, rotation:  new UnityEngine.Quaternion() {x = val_42.x, y = val_56, z = val_42.z, w = val_55}), t:  3.5f);
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public ETFXProjectileScript()
    {
        this.colliderRadius = 1f;
        this.collideOffset = 0.15f;
    }

}

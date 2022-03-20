using UnityEngine;
public class LookAtTarget : MonoBehaviour
{
    // Fields
    public int level;
    public UnityEngine.Transform target;
    public float speed;
    private UnityEngine.Transform mTrans;
    
    // Methods
    private void Start()
    {
        this.mTrans = this.transform;
    }
    private void LateUpdate()
    {
        float val_11;
        float val_12;
        float val_13;
        if(this.target == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_2 = this.target.position;
        val_11 = val_2.x;
        val_12 = val_2.z;
        UnityEngine.Vector3 val_3 = this.mTrans.position;
        val_13 = val_3.y;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_11, y = val_2.y, z = val_12}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_13, z = val_3.z});
        if(val_4.x.magnitude <= 0.001f)
        {
                return;
        }
        
        UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        val_12 = val_6.z;
        UnityEngine.Quaternion val_7 = this.mTrans.rotation;
        val_13 = val_7.x;
        float val_8 = UnityEngine.Time.deltaTime;
        val_11 = val_8;
        val_8 = this.speed * val_11;
        UnityEngine.Quaternion val_10 = UnityEngine.Quaternion.Slerp(a:  new UnityEngine.Quaternion() {x = val_13, y = val_7.y, z = val_7.z, w = val_7.w}, b:  new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_12, w = val_6.w}, t:  UnityEngine.Mathf.Clamp01(value:  val_8));
        this.mTrans.rotation = new UnityEngine.Quaternion() {x = val_10.x, y = val_10.y, z = val_10.z, w = val_10.w};
    }
    public LookAtTarget()
    {
        this.speed = 8f;
    }

}

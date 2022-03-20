using UnityEngine;
public class Spin : MonoBehaviour
{
    // Fields
    public UnityEngine.Vector3 rotationsPerSecond;
    private UnityEngine.Rigidbody mRb;
    private UnityEngine.Transform mTrans;
    
    // Methods
    private void Start()
    {
        this.mTrans = this.transform;
        this.mRb = this.GetComponent<UnityEngine.Rigidbody>();
    }
    private void Update()
    {
        if(this.mRb != 0)
        {
                return;
        }
        
        this.ApplyDelta(delta:  UnityEngine.Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if(this.mRb == 0)
        {
                return;
        }
        
        this.ApplyDelta(delta:  UnityEngine.Time.deltaTime);
    }
    public void ApplyDelta(float delta)
    {
        float val_8 = delta;
        val_8 = val_8 * 360f;
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = this.rotationsPerSecond, y = V9.16B, z = V10.16B}, d:  val_8);
        UnityEngine.Quaternion val_2 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        if(this.mRb == 0)
        {
                UnityEngine.Quaternion val_4 = this.mTrans.rotation;
            UnityEngine.Quaternion val_5 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w}, rhs:  new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w});
            this.mTrans.rotation = new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w};
            return;
        }
        
        UnityEngine.Quaternion val_6 = this.mRb.rotation;
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w}, rhs:  new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w});
        this.mRb.MoveRotation(rot:  new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w});
    }
    public Spin()
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  0f, y:  0.1f, z:  0f);
        this.rotationsPerSecond = val_1.x;
        mem[1152921515533084928] = val_1.z;
    }

}

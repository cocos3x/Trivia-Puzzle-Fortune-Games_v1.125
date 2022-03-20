using UnityEngine;
public class CRotate : MonoBehaviour
{
    // Fields
    public float speed;
    public bool counterClockwise;
    
    // Methods
    private void Update()
    {
        float val_8 = this.speed;
        val_8 = (val_8 < 0f) ? (-val_8) : (val_8);
        this.speed = val_8;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.forward;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Multiply(d:  (this.counterClockwise == false) ? -1f : 1f, a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  UnityEngine.Time.deltaTime);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, d:  this.speed);
        this.transform.Rotate(eulers:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
    }
    public CRotate()
    {
    
    }

}

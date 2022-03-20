using UnityEngine;
public class PanWithMouse : IgnoreTimeScale
{
    // Fields
    public UnityEngine.Vector2 degrees;
    public float range;
    private UnityEngine.Transform mTrans;
    private UnityEngine.Quaternion mStart;
    private UnityEngine.Vector2 mRot;
    
    // Methods
    private void Start()
    {
        UnityEngine.Transform val_1 = this.transform;
        this.mTrans = val_1;
        UnityEngine.Quaternion val_2 = val_1.localRotation;
        this.mStart = val_2;
        mem[1152921515532231332] = val_2.y;
        mem[1152921515532231336] = val_2.z;
        mem[1152921515532231340] = val_2.w;
    }
    private void Update()
    {
        float val_16;
        float val_1 = this.UpdateRealTimeDelta();
        UnityEngine.Vector3 val_2 = UnityEngine.Input.mousePosition;
        float val_16 = (float)UnityEngine.Screen.width;
        float val_17 = 0.5f;
        val_16 = this.range;
        if(val_16 < 0)
        {
                val_16 = 0.1f;
            this.range = 0.1f;
        }
        
        val_16 = val_16 * val_17;
        val_17 = (float)UnityEngine.Screen.height * val_17;
        float val_5 = val_2.x - val_16;
        val_5 = val_5 / val_16;
        val_5 = val_5 / val_16;
        float val_18 = this.range;
        float val_7 = val_2.y - val_17;
        val_7 = val_7 / val_17;
        val_18 = val_7 / val_18;
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  UnityEngine.Mathf.Clamp(value:  val_5, min:  -1f, max:  1f), y:  UnityEngine.Mathf.Clamp(value:  val_18, min:  -1f, max:  1f));
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.Lerp(a:  new UnityEngine.Vector2() {x = this.mRot, y = -1f}, b:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, t:  val_1 * 5f);
        this.mRot = val_11;
        mem[1152921515532351540] = val_11.y;
        UnityEngine.Quaternion val_14 = UnityEngine.Quaternion.Euler(x:  -(val_11.y * S15), y:  val_11.x * this.degrees, z:  0f);
        UnityEngine.Quaternion val_15 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = this.mStart, y = -1f, z = this.mRot, w = val_1}, rhs:  new UnityEngine.Quaternion() {x = val_14.x, y = val_14.y, z = val_14.z, w = val_14.w});
        this.mTrans.localRotation = new UnityEngine.Quaternion() {x = val_15.x, y = val_15.y, z = val_15.z, w = val_15.w};
    }
    public PanWithMouse()
    {
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  5f, y:  3f);
        this.range = 1f;
        this.degrees = val_1.x;
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.zero;
        this.mRot = val_2;
        mem[1152921515532467636] = val_2.y;
    }

}

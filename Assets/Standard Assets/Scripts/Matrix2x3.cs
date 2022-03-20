using UnityEngine;
public struct UIGradientUtils.Matrix2x3
{
    // Fields
    public float m00;
    public float m01;
    public float m02;
    public float m10;
    public float m11;
    public float m12;
    
    // Methods
    public UIGradientUtils.Matrix2x3(float m00, float m01, float m02, float m10, float m11, float m12)
    {
        this = m00;
        this.m01 = m01;
        this.m02 = m02;
        this.m10 = m10;
        this.m11 = m11;
        this.m12 = m12;
    }
    public static UnityEngine.Vector2 op_Multiply(UIGradientUtils.Matrix2x3 m, UnityEngine.Vector2 v)
    {
        float val_4 = m.m10;
        float val_5 = m.m11;
        val_4 = v.x * val_4;
        val_5 = v.y * val_5;
        v.x = v.x * m.m00;
        v.y = v.y * m.m01;
        v.x = v.x - v.y;
        v.x = m.m02 + v.x;
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  v.x, y:  m.m12 + (val_4 + val_5));
        return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }

}

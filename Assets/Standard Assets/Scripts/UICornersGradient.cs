using UnityEngine;
public class UICornersGradient : BaseMeshEffect
{
    // Fields
    public UnityEngine.Color m_topLeftColor;
    public UnityEngine.Color m_topRightColor;
    public UnityEngine.Color m_bottomRightColor;
    public UnityEngine.Color m_bottomLeftColor;
    
    // Methods
    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        float val_8;
        float val_9;
        float val_10;
        byte val_13;
        var val_20;
        float val_21;
        float val_22;
        float val_23;
        UnityEngine.Color val_24;
        float val_25;
        float val_26;
        float val_27;
        if(this.enabled == false)
        {
                return;
        }
        
        UnityEngine.Rect val_4 = this.graphic.rectTransform.rect;
        val_21 = val_4.m_XMin;
        val_22 = val_4.m_Width;
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.right;
        val_23 = val_5.x;
        Matrix2x3 val_6 = UIGradientUtils.LocalPositionMatrix(rect:  new UnityEngine.Rect() {m_XMin = val_21, m_YMin = val_4.m_YMin, m_Width = val_22, m_Height = val_4.m_Height}, dir:  new UnityEngine.Vector2() {x = val_23, y = val_5.y});
        if(vh.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            vh.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_8, y = val_9, z = val_10});
            UnityEngine.Vector2 val_12 = UIGradientUtils.Matrix2x3.op_Multiply(m:  new Matrix2x3() {m00 = 0f, m01 = 0f, m02 = 0f, m10 = 0f, m11 = 0f, m12 = 0f}, v:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y});
            UnityEngine.Color val_14 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_13, g = val_13, b = val_13, a = val_13});
            val_24 = this.m_bottomLeftColor;
            val_26 = ???;
            val_27 = val_14.b;
            val_25 = val_14.g;
            val_24 = val_24;
            UnityEngine.Color val_15 = UIGradientUtils.Bilerp(a1:  new UnityEngine.Color() {r = val_24, g = val_25, b = val_27, a = val_26}, a2:  new UnityEngine.Color() {r = this.m_bottomRightColor, g = val_5.y, b = ???, a = ???}, b1:  new UnityEngine.Color() {r = this.m_topLeftColor, g = val_23, b = this.m_topRightColor, a = ???}, b2:  new UnityEngine.Color() {r = val_12.x, g = ???, b = val_5.y, a = ???}, t:  new UnityEngine.Vector2() {x = val_14.g, y = val_14.a});
            UnityEngine.Color val_16 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a}, b:  new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a});
            UnityEngine.Color32 val_17 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_16.r, g = val_16.g, b = val_16.b, a = val_16.a});
            val_13 = val_17.r;
            vh.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_20 = 0 + 1;
        }
        while(val_20 < vh.currentVertCount);
    
    }
    public UICornersGradient()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.m_topLeftColor = val_1;
        mem[1152921510481050948] = val_1.g;
        mem[1152921510481050952] = val_1.b;
        mem[1152921510481050956] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.m_topRightColor = val_2;
        mem[1152921510481050964] = val_2.g;
        mem[1152921510481050968] = val_2.b;
        mem[1152921510481050972] = val_2.a;
        UnityEngine.Color val_3 = UnityEngine.Color.white;
        this.m_bottomRightColor = val_3;
        mem[1152921510481050980] = val_3.g;
        mem[1152921510481050984] = val_3.b;
        mem[1152921510481050988] = val_3.a;
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.m_bottomLeftColor = val_4;
        mem[1152921510481050996] = val_4.g;
        mem[1152921510481051000] = val_4.b;
        mem[1152921510481051004] = val_4.a;
    }

}

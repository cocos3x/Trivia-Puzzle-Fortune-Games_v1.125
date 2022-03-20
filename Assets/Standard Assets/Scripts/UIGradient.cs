using UnityEngine;
public class UIGradient : BaseMeshEffect
{
    // Fields
    public UnityEngine.Color m_color1;
    public UnityEngine.Color m_color2;
    public float m_angle;
    public bool m_ignoreRatio;
    
    // Methods
    public void Refresh()
    {
        UnityEngine.UI.Graphic val_1 = this.graphic;
        goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_2D0;
    }
    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        float val_9;
        float val_10;
        float val_11;
        byte val_14;
        var val_21;
        float val_22;
        float val_23;
        float val_26;
        float val_27;
        if(this.enabled == false)
        {
                return;
        }
        
        UnityEngine.Rect val_4 = this.graphic.rectTransform.rect;
        val_21 = 1152921504858869760;
        val_22 = val_4.m_XMin;
        val_23 = val_4.m_Width;
        UnityEngine.Vector2 val_5 = UIGradientUtils.RotationDir(angle:  this.m_angle);
        val_26 = val_5.x;
        val_27 = val_5.y;
        if(this.m_ignoreRatio != true)
        {
                UnityEngine.Vector2 val_6 = UIGradientUtils.CompensateAspectRatio(rect:  new UnityEngine.Rect() {m_XMin = val_22, m_YMin = val_4.m_YMin, m_Width = val_23, m_Height = val_4.m_Height}, dir:  new UnityEngine.Vector2() {x = val_26, y = val_27});
            val_26 = val_6.x;
            val_27 = val_6.y;
        }
        
        Matrix2x3 val_7 = UIGradientUtils.LocalPositionMatrix(rect:  new UnityEngine.Rect() {m_XMin = val_22, m_YMin = val_4.m_YMin, m_Width = val_23, m_Height = val_4.m_Height}, dir:  new UnityEngine.Vector2() {x = val_26, y = val_27});
        if(vh.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            vh.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_9, y = val_10, z = val_11});
            UnityEngine.Vector2 val_13 = UIGradientUtils.Matrix2x3.op_Multiply(m:  new Matrix2x3() {m00 = 0f, m01 = 0f, m02 = 0f, m10 = 0f, m11 = 0f, m12 = 0f}, v:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y});
            val_22 = val_13.y;
            UnityEngine.Color val_15 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_14, g = val_14, b = val_14, a = val_14});
            val_23 = val_15.g;
            val_26 = val_15.a;
            UnityEngine.Color val_16 = UnityEngine.Color.Lerp(a:  new UnityEngine.Color() {r = this.m_color2, g = val_15.g, b = val_15.b, a = V16.16B}, b:  new UnityEngine.Color() {r = this.m_color1, g = val_27}, t:  val_22);
            UnityEngine.Color val_17 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_15.r, g = val_23, b = val_15.b, a = val_26}, b:  new UnityEngine.Color() {r = val_16.r, g = val_16.g, b = val_16.b, a = val_16.a});
            UnityEngine.Color32 val_18 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_17.r, g = val_17.g, b = val_17.b, a = val_17.a});
            val_14 = val_18.r;
            vh.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_21 = 0 + 1;
        }
        while(val_21 < vh.currentVertCount);
    
    }
    public UIGradient()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.m_color1 = val_1;
        mem[1152921510481427844] = val_1.g;
        mem[1152921510481427848] = val_1.b;
        mem[1152921510481427852] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.m_color2 = val_2;
        mem[1152921510481427860] = val_2.g;
        mem[1152921510481427864] = val_2.b;
        mem[1152921510481427868] = val_2.a;
        this.m_ignoreRatio = true;
    }

}

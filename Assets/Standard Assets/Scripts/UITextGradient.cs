using UnityEngine;
public class UITextGradient : BaseMeshEffect
{
    // Fields
    public UnityEngine.Color m_color1;
    public UnityEngine.Color m_color2;
    public float m_angle;
    
    // Methods
    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        byte val_11;
        var val_16;
        float val_17;
        var val_18;
        if(this.enabled == false)
        {
                return;
        }
        
        UnityEngine.Rect val_4 = this.graphic.rectTransform.rect;
        UnityEngine.Vector2 val_5 = UIGradientUtils.RotationDir(angle:  this.m_angle);
        val_17 = val_5.x;
        UnityEngine.Rect val_6 = new UnityEngine.Rect(x:  0f, y:  0f, width:  1f, height:  1f);
        Matrix2x3 val_7 = UIGradientUtils.LocalPositionMatrix(rect:  new UnityEngine.Rect() {m_XMin = val_6.m_XMin, m_YMin = val_6.m_YMin, m_Width = val_6.m_Width, m_Height = val_6.m_Height}, dir:  new UnityEngine.Vector2() {x = val_17, y = val_5.y});
        if(vh.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            vh.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_18 = null;
            val_18 = null;
            UnityEngine.Vector2[] val_17 = UIGradientUtils.ms_verticesPositions;
            var val_9 = 0 & 3;
            val_17 = val_17 + (((0 & 3)) << 3);
            UnityEngine.Vector2 val_10 = UIGradientUtils.Matrix2x3.op_Multiply(m:  new Matrix2x3() {m00 = 0f, m01 = 0f, m02 = 0f, m10 = 0f, m11 = 0f, m12 = 0f}, v:  new UnityEngine.Vector2() {x = (UIGradientUtils.ms_verticesPositions + ((0 & 3)) << 3) + 32, y = (UIGradientUtils.ms_verticesPositions + ((0 & 3)) << 3) + 32 + 4});
            val_17 = val_10.y;
            UnityEngine.Color val_12 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_11, g = val_11, b = val_11, a = val_11});
            UnityEngine.Color val_13 = UnityEngine.Color.Lerp(a:  new UnityEngine.Color() {r = this.m_color2, g = val_12.g, b = val_12.b, a = V16.16B}, b:  new UnityEngine.Color() {r = this.m_color1, g = val_5.y}, t:  val_17);
            UnityEngine.Color val_14 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_12.r, g = val_12.g, b = val_12.b, a = val_12.a}, b:  new UnityEngine.Color() {r = val_13.r, g = val_13.g, b = val_13.b, a = val_13.a});
            UnityEngine.Color32 val_15 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a});
            val_11 = val_15.r;
            vh.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_16 = 0 + 1;
        }
        while(val_16 < vh.currentVertCount);
    
    }
    public UITextGradient()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.m_color1 = val_1;
        mem[1152921510483104900] = val_1.g;
        mem[1152921510483104904] = val_1.b;
        mem[1152921510483104908] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.m_color2 = val_2;
        mem[1152921510483104916] = val_2.g;
        mem[1152921510483104920] = val_2.b;
        mem[1152921510483104924] = val_2.a;
    }

}

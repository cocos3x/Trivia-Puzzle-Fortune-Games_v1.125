using UnityEngine;
public class UITextCornersGradient : BaseMeshEffect
{
    // Fields
    public UnityEngine.Color m_topLeftColor;
    public UnityEngine.Color m_topRightColor;
    public UnityEngine.Color m_bottomRightColor;
    public UnityEngine.Color m_bottomLeftColor;
    
    // Methods
    public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
    {
        byte val_7;
        var val_12;
        var val_13;
        if(this.enabled == false)
        {
                return;
        }
        
        UnityEngine.Rect val_4 = this.graphic.rectTransform.rect;
        if(vh.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            vh.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_13 = null;
            val_13 = null;
            UnityEngine.Vector2[] val_13 = UIGradientUtils.ms_verticesPositions;
            val_13 = val_13 + (((0 & 3)) << 3);
            UnityEngine.Color val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = val_7, g = val_7, b = val_7, a = val_7});
            UnityEngine.Color val_9 = UIGradientUtils.Bilerp(a1:  new UnityEngine.Color() {r = this.m_bottomLeftColor, g = val_8.g, b = val_8.b, a = V16.16B}, a2:  new UnityEngine.Color() {r = this.m_bottomRightColor}, b1:  new UnityEngine.Color() {r = this.m_topLeftColor, g = val_13, b = this.m_topRightColor, a = 0 & 3}, b2:  new UnityEngine.Color() {r = (UIGradientUtils.ms_verticesPositions + ((0 & 3)) << 3) + 32}, t:  new UnityEngine.Vector2());
            UnityEngine.Color val_10 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a}, b:  new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a});
            UnityEngine.Color32 val_11 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
            val_7 = val_11.r;
            vh.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_12 = 0 + 1;
        }
        while(val_12 < vh.currentVertCount);
    
    }
    public UITextCornersGradient()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.m_topLeftColor = val_1;
        mem[1152921510482848196] = val_1.g;
        mem[1152921510482848200] = val_1.b;
        mem[1152921510482848204] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.m_topRightColor = val_2;
        mem[1152921510482848212] = val_2.g;
        mem[1152921510482848216] = val_2.b;
        mem[1152921510482848220] = val_2.a;
        UnityEngine.Color val_3 = UnityEngine.Color.white;
        this.m_bottomRightColor = val_3;
        mem[1152921510482848228] = val_3.g;
        mem[1152921510482848232] = val_3.b;
        mem[1152921510482848236] = val_3.a;
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.m_bottomLeftColor = val_4;
        mem[1152921510482848244] = val_4.g;
        mem[1152921510482848248] = val_4.b;
        mem[1152921510482848252] = val_4.a;
    }

}

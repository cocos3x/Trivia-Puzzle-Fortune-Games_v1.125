using UnityEngine;
public class BasicRay : MaskableGraphic
{
    // Fields
    public UnityEngine.Color innerColor;
    public UnityEngine.Color outerColor;
    public float shrinkSource;
    private UnityEngine.Texture m_Texture;
    
    // Properties
    public UnityEngine.Texture texture { get; set; }
    public override UnityEngine.Texture mainTexture { get; }
    
    // Methods
    public UnityEngine.Texture get_texture()
    {
        return (UnityEngine.Texture)this.m_Texture;
    }
    public void set_texture(UnityEngine.Texture value)
    {
        if(this.m_Texture == value)
        {
                return;
        }
        
        this.m_Texture = value;
        this.SetVerticesDirty();
        this.SetMaterialDirty();
    }
    protected override void OnRectTransformDimensionsChange()
    {
        this.OnRectTransformDimensionsChange();
        this.SetVerticesDirty();
        this.SetMaterialDirty();
    }
    public override UnityEngine.Texture get_mainTexture()
    {
        var val_2;
        var val_3;
        UnityEngine.Texture2D val_4;
        val_2 = this;
        if(this.m_Texture == 0)
        {
                val_2 = 1152921504810467328;
            val_3 = null;
            val_3 = null;
            val_4 = UnityEngine.UI.Graphic.s_WhiteTexture;
            return val_4;
        }
        
        val_4 = this.m_Texture;
        return val_4;
    }
    private UnityEngine.UIVertex[] SetVBO(UnityEngine.Vector2[] vertices, UnityEngine.Vector2[] uvs, UnityEngine.Color color1, UnityEngine.Color color2)
    {
        var val_10;
        byte val_13;
        UnityEngine.UIVertex[] val_1 = new UnityEngine.UIVertex[4];
        if(vertices.Length < 1)
        {
                return val_1;
        }
        
        var val_8 = 0;
        do
        {
            val_10 = null;
            val_10 = null;
            UnityEngine.Color val_2 = this.color;
            if(val_8 <= 1)
        {
                UnityEngine.Color val_3 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a}, b:  new UnityEngine.Color() {r = color2.r, g = color2.g, b = color2.b, a = color2.a});
            UnityEngine.Color32 val_4 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a});
            val_13 = val_4.r & 4294967295;
        }
        else
        {
                UnityEngine.Color val_5 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a}, b:  new UnityEngine.Color() {r = color1.r, g = color1.g, b = color1.b, a = color1.a});
            UnityEngine.Color32 val_6 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
            val_13 = val_6.r;
        }
        
            UnityEngine.Vector3 val_7 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = 1.187534E-20f, y = 1.187534E-20f});
            mem2[0] = val_7.x;
            mem2[0] = val_7.y;
            mem2[0] = val_7.z;
            mem2[0] = val_13;
            mem[1] = val_6.g;
            mem[2] = val_6.b;
            mem[3] = val_6.a;
            mem2[0] = null;
            mem2[0] = UnityEngine.UIVertex.s_DefaultColor.__il2cppRuntimeField_20;
            mem2[0] = UnityEngine.UIVertex.s_DefaultColor.__il2cppRuntimeField_20;
            val_8 = val_8 + 1;
            mem2[0] = UnityEngine.UIVertex.s_DefaultColor.__il2cppRuntimeField_58;
            val_1[84] = UnityEngine.UIVertex.s_DefaultColor.__il2cppRuntimeField_48;
        }
        while(val_8 < vertices.Length);
        
        return val_1;
    }
    private void AddRay(UnityEngine.UI.VertexHelper vh, UnityEngine.Vector2 source, UnityEngine.Vector2 end, float shrink = 1)
    {
        source.x = end.x - source.x;
        source.x = source.x * 0.5f;
        float val_2 = source.x + source.x;
        float val_3 = (1f - shrink) * source.x;
        source.x = val_2 - val_3;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  source.x, y:  source.y);
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_2 + val_3, y:  source.y);
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  source.x, y:  end.y);
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  0f, y:  0f);
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  1f, y:  0f);
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  1f, y:  1f);
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  0f, y:  1f);
        UnityEngine.Vector2[] val_12 = new UnityEngine.Vector2[4];
        val_12[0] = val_4.x;
        val_12[1] = val_6.x;
        val_12[2] = end;
        val_12[2] = end.y;
        val_12[3] = val_7.x;
        UnityEngine.Vector2[] val_13 = new UnityEngine.Vector2[4];
        val_13[0] = val_8.x;
        val_13[1] = val_9.x;
        val_13[2] = val_10.x;
        val_13[3] = val_11.x;
        UnityEngine.Color val_14 = this.color;
        UnityEngine.Color val_15 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = this.outerColor, g = end.x, b = source.x, a = source.y}, b:  new UnityEngine.Color() {r = val_14.r, g = val_14.g, b = val_14.b, a = val_14.a});
        UnityEngine.Color val_16 = this.color;
        UnityEngine.Color val_17 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = this.innerColor, g = val_2, b = 1f, a = val_3}, b:  new UnityEngine.Color() {r = val_16.r, g = val_16.g, b = val_16.b, a = val_16.a});
        vh.AddUIVertexQuad(verts:  this.SetVBO(vertices:  val_12, uvs:  val_13, color1:  new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a}, color2:  new UnityEngine.Color() {r = val_17.r, g = val_17.g, b = val_17.b, a = val_17.a}));
    }
    protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vh)
    {
        vh.Clear();
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  0f);
        UnityEngine.Vector2 val_3 = this.rectTransform.pivot;
        UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, b:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
        float val_23 = val_4.x;
        float val_24 = val_4.y;
        UnityEngine.Rect val_6 = this.rectTransform.rect;
        UnityEngine.Rect val_9 = this.rectTransform.rect;
        val_23 = val_23 * val_6.m_XMin.width;
        val_24 = val_24 * val_9.m_XMin.height;
        UnityEngine.Rect val_12 = this.rectTransform.rect;
        UnityEngine.Vector2 val_14 = UnityEngine.Vector2.right;
        UnityEngine.Vector2 val_15 = UnityEngine.Vector2.op_Multiply(d:  val_12.m_XMin.width, a:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y});
        UnityEngine.Vector2 val_16 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_23, y = val_24}, b:  new UnityEngine.Vector2() {x = val_15.x, y = val_15.y});
        UnityEngine.Rect val_18 = this.rectTransform.rect;
        UnityEngine.Vector2 val_20 = UnityEngine.Vector2.up;
        UnityEngine.Vector2 val_21 = UnityEngine.Vector2.op_Multiply(d:  val_18.m_XMin.height, a:  new UnityEngine.Vector2() {x = val_20.x, y = val_20.y});
        UnityEngine.Vector2 val_22 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_16.x, y = val_16.y}, b:  new UnityEngine.Vector2() {x = val_21.x, y = val_21.y});
        this.AddRay(vh:  vh, source:  new UnityEngine.Vector2() {x = val_23, y = val_24}, end:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y}, shrink:  this.shrinkSource);
    }
    public BasicRay()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  1f, g:  0.92f, b:  0.54f, a:  1f);
        UnityEngine.Color val_2;
        this.innerColor = val_1.r;
        val_2 = new UnityEngine.Color(r:  1f, g:  0.92f, b:  0.54f, a:  0.25f);
        this.outerColor = val_2.r;
        this.shrinkSource = 0.5f;
    }

}

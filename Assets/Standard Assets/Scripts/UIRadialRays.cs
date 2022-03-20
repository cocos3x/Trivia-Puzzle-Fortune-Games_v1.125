using UnityEngine;
public class UIRadialRays : MaskableGraphic
{
    // Fields
    public UnityEngine.Color innerColor;
    public UnityEngine.Color outerColor;
    public UnityEngine.Color innerGlowColor;
    private UnityEngine.Texture m_Texture;
    public int rayCount;
    public float rotation;
    public float innerGlowRadius;
    
    // Properties
    public override UnityEngine.Texture mainTexture { get; }
    public UnityEngine.Texture texture { get; set; }
    private float size { get; }
    
    // Methods
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
    private float get_size()
    {
        UnityEngine.Rect val_2 = this.rectTransform.rect;
        UnityEngine.Rect val_5 = this.rectTransform.rect;
        UnityEngine.Rect val_8 = this.rectTransform.rect;
        if(val_2.m_XMin.width <= val_5.m_XMin.height)
        {
                return (float)val_8.m_XMin.width;
        }
        
        float val_9 = val_8.m_XMin.height;
        return (float)val_8.m_XMin.width;
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
    protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vertexHelper)
    {
        UnityEngine.Vector2[] val_62;
        var val_63;
        float val_64;
        float val_65;
        float val_66;
        int val_67;
        var val_68;
        UnityEngine.Color val_69;
        float val_70;
        vertexHelper.Clear();
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  0f);
        UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  0f, y:  1f);
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  1f, y:  1f);
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  1f, y:  0f);
        val_63 = 1152921504762331136;
        float val_62 = (float)this.rayCount;
        val_64 = 0.25f;
        val_62 = 360f / val_62;
        val_65 = val_62 * val_64;
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
        val_66 = val_5.y;
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.zero;
        val_67 = this.rayCount;
        if((val_67 + 1) >= 1)
        {
                val_68 = 1152921504762277888;
            var val_64 = 0;
            val_64 = 1f;
            do
        {
            UnityEngine.Vector2 val_9 = this.rectTransform.pivot;
            float val_10 = this.size;
            val_10 = val_9.x * val_10;
            float val_11 = -(val_10 * this.innerGlowRadius);
            float val_63 = val_62;
            val_63 = val_63 * 0f;
            val_63 = val_63 - val_65;
            val_63 = val_63 + this.rotation;
            float val_12 = val_63 * 0.01745329f;
            UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  0f, y:  val_64);
            UnityEngine.Vector2 val_14 = new UnityEngine.Vector2(x:  val_64, y:  val_64);
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  val_64, y:  0f);
            UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  0f, y:  0f);
            UnityEngine.Vector2 val_19 = new UnityEngine.Vector2(x:  val_12 * val_11, y:  val_12 * val_11);
            UnityEngine.Vector2 val_20 = UnityEngine.Vector2.zero;
            UnityEngine.Vector2 val_21 = UnityEngine.Vector2.zero;
            val_66 = val_19.y;
            UnityEngine.Vector2[] val_22 = new UnityEngine.Vector2[4];
            val_62 = val_22;
            val_62[0] = val_5;
            val_62[1] = val_19.x;
            val_62[2] = val_20;
            val_62[3] = val_21;
            UnityEngine.Vector2[] val_23 = new UnityEngine.Vector2[4];
            val_23[0] = val_13.x;
            val_23[1] = val_14.x;
            val_23[2] = val_15.x;
            val_23[3] = val_16.x;
            UnityEngine.Color val_24 = new UnityEngine.Color(r:  this.innerGlowColor, g:  this.innerGlowColor, b:  val_11, a:  0f);
            val_65 = this.innerGlowColor;
            vertexHelper.AddUIVertexQuad(verts:  this.SetVBO(vertices:  val_22, uvs:  val_23, color1:  new UnityEngine.Color() {r = val_65, g = val_12, b = val_11, a = V14.16B}, color2:  new UnityEngine.Color() {r = val_24.r, g = val_24.g, b = val_24.b, a = val_24.a}));
            val_67 = this.rayCount;
            val_64 = val_64 + 1;
        }
        while(val_64 < (val_67 + 1));
        
        }
        
        if(val_67 < 1)
        {
                return;
        }
        
        val_68 = 1152921505116475808;
        do
        {
            UnityEngine.Vector2 val_28 = this.rectTransform.pivot;
            float val_31 = -(val_28.x * this.size);
            UnityEngine.Vector2 val_32 = this.rectTransform.pivot;
            float val_34 = this.size;
            val_34 = val_34 * 0.5f;
            val_34 = val_34 + (-5f);
            float val_36 = val_34 - (val_32.x * this.size);
            float val_67 = this.rotation;
            float val_37 = val_62 * 0f;
            float val_65 = val_65;
            val_65 = val_37 - val_65;
            val_65 = val_65 + val_67;
            float val_38 = val_65 * 0.01745329f;
            float val_66 = val_65;
            val_66 = val_66 + val_37;
            val_66 = val_66 + val_67;
            val_67 = val_66 * 0.01745329f;
            UnityEngine.Vector2 val_39 = new UnityEngine.Vector2(x:  0f, y:  1f);
            UnityEngine.Vector2 val_40 = new UnityEngine.Vector2(x:  1f, y:  1f);
            UnityEngine.Vector2 val_41 = new UnityEngine.Vector2(x:  1f, y:  0f);
            UnityEngine.Vector2 val_42 = new UnityEngine.Vector2(x:  0f, y:  0f);
            UnityEngine.Vector2 val_45 = new UnityEngine.Vector2(x:  val_38 * val_31, y:  val_38 * val_31);
            UnityEngine.Vector2 val_48 = new UnityEngine.Vector2(x:  val_67 * val_31, y:  val_67 * val_31);
            UnityEngine.Vector2 val_51 = new UnityEngine.Vector2(x:  val_36 * val_67, y:  val_36 * val_67);
            UnityEngine.Vector2 val_54 = new UnityEngine.Vector2(x:  val_36 * val_38, y:  val_36 * val_38);
            UnityEngine.Vector2[] val_55 = new UnityEngine.Vector2[4];
            val_62 = val_55;
            val_62[0] = val_45.x;
            val_62[1] = val_48.x;
            val_62[2] = val_51.x;
            val_62[3] = val_54.x;
            UnityEngine.Vector2[] val_56 = new UnityEngine.Vector2[4];
            val_56[0] = val_39.x;
            val_56[1] = val_40.x;
            val_56[2] = val_41.x;
            val_56[3] = val_42.x;
            UnityEngine.Color val_57 = this.color;
            UnityEngine.Color val_58 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = this.innerColor, g = val_38, b = val_67, a = val_67}, b:  new UnityEngine.Color() {r = val_57.r, g = val_57.g, b = val_57.b, a = val_57.a});
            val_69 = this.outerColor;
            val_66 = val_58.g;
            val_64 = val_58.a;
            UnityEngine.Color val_59 = this.color;
            UnityEngine.Color val_60 = UnityEngine.Color.op_Multiply(a:  new UnityEngine.Color() {r = val_69, g = val_36, b = 0.01745329f, a = 1f}, b:  new UnityEngine.Color() {r = val_59.r, g = val_59.g, b = val_59.b, a = val_59.a});
            vertexHelper.AddUIVertexQuad(verts:  this.SetVBO(vertices:  val_55, uvs:  val_56, color1:  new UnityEngine.Color() {r = val_58.r, g = val_66, b = val_58.b, a = val_64}, color2:  new UnityEngine.Color() {r = val_60.r, g = val_60.g, b = val_60.b, a = val_60.a}));
            val_70 = 0.01745329f;
            val_63 = 0 + 1;
        }
        while(val_63 < this.rayCount);
    
    }
    public UIRadialRays()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.innerColor = val_1;
        mem[1152921510478292468] = val_1.g;
        mem[1152921510478292472] = val_1.b;
        mem[1152921510478292476] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.outerColor = val_2;
        mem[1152921510478292484] = val_2.g;
        mem[1152921510478292488] = val_2.b;
        mem[1152921510478292492] = val_2.a;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.75f);
        this.rayCount = 16;
        this.innerGlowColor = val_3.r;
        this.innerGlowRadius = 0.75f;
    }

}

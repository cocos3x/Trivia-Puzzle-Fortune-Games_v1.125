using UnityEngine;
public class Gradient : BaseMeshEffect
{
    // Fields
    public Gradient.GradientDirection GradientType;
    public float Offset;
    public UnityEngine.Color32 StartColor;
    public UnityEngine.Color32 EndColor;
    
    // Methods
    public override void ModifyMesh(UnityEngine.UI.VertexHelper helper)
    {
        float val_7;
        float val_13;
        System.Collections.Generic.List<UnityEngine.UIVertex> val_16;
        float val_18;
        var val_19;
        var val_20;
        float val_22;
        if(this.IsActive() == false)
        {
                return;
        }
        
        if(helper.currentVertCount == 0)
        {
                return;
        }
        
        System.Collections.Generic.List<UnityEngine.UIVertex> val_3 = null;
        val_16 = val_3;
        val_3 = new System.Collections.Generic.List<UnityEngine.UIVertex>();
        helper.GetUIVertexStream(stream:  val_3);
        if(this.GradientType == 1)
        {
            goto label_5;
        }
        
        if(this.GradientType != 0)
        {
                return;
        }
        
        if((public System.Boolean UnityEngine.EventSystems.UIBehaviour::IsActive()) == 0)
        {
            goto label_7;
        }
        
        if(26661111 < 1)
        {
            goto label_8;
        }
        
        long val_16 = 26661111;
        val_18 = V10.16B;
        label_13:
        if(val_16 >= 26661111)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(S8 <= val_18)
        {
            goto label_10;
        }
        
        val_18 = V8.16B;
        goto label_11;
        label_10:
        if(S8 < 0)
        {
            goto label_12;
        }
        
        label_11:
        val_19 = V10.16B;
        label_12:
        val_16 = val_16 - 1;
        val_20 = 26661071;
        if(val_16 > 0)
        {
            goto label_13;
        }
        
        goto label_27;
        label_5:
        if((public System.Boolean UnityEngine.EventSystems.UIBehaviour::IsActive()) == 0)
        {
            goto label_15;
        }
        
        if(26661111 < 1)
        {
            goto label_16;
        }
        
        long val_17 = 26661111;
        val_22 = V10.16B;
        label_21:
        if(val_17 >= 26661111)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(S8 <= val_22)
        {
            goto label_18;
        }
        
        val_22 = V8.16B;
        goto label_19;
        label_18:
        if(S8 < 0)
        {
            goto label_20;
        }
        
        label_19:
        val_19 = V10.16B;
        label_20:
        val_17 = val_17 - 1;
        val_20 = 26661067;
        if(val_17 > 0)
        {
            goto label_21;
        }
        
        goto label_28;
        label_7:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((public System.Boolean UnityEngine.EventSystems.UIBehaviour::IsActive()) == 0)
        {
            goto label_23;
        }
        
        val_18 = V8.16B;
        goto label_27;
        label_15:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((public System.Boolean UnityEngine.EventSystems.UIBehaviour::IsActive()) == 0)
        {
            goto label_25;
        }
        
        val_22 = V8.16B;
        goto label_28;
        label_8:
        val_18 = V10.16B;
        val_19 = V10.16B;
        goto label_27;
        label_16:
        val_22 = V10.16B;
        val_19 = V10.16B;
        goto label_28;
        label_23:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        label_27:
        if(helper.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            helper.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            float val_18 = val_7;
            val_18 = val_18 - S8;
            val_18 = (1f / (S9 - S8)) * val_18;
            val_18 = val_18 - this.Offset;
            UnityEngine.Color32 val_8 = UnityEngine.Color32.Lerp(a:  new UnityEngine.Color32() {r = this.EndColor, g = this.EndColor, b = this.EndColor, a = this.EndColor}, b:  new UnityEngine.Color32() {r = this.StartColor, g = this.StartColor, b = this.StartColor, a = this.StartColor}, t:  val_18);
            helper.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_16 = 0 + 1;
        }
        while(val_16 < helper.currentVertCount);
        
        return;
        label_25:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        label_28:
        if(helper.currentVertCount < 1)
        {
                return;
        }
        
        do
        {
            helper.PopulateUIVertex(vertex: ref  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            float val_19 = val_13;
            val_19 = val_19 - S8;
            val_19 = (1f / (S9 - S8)) * val_19;
            val_19 = val_19 - this.Offset;
            UnityEngine.Color32 val_14 = UnityEngine.Color32.Lerp(a:  new UnityEngine.Color32() {r = this.EndColor, g = this.EndColor, b = this.EndColor, a = this.EndColor}, b:  new UnityEngine.Color32() {r = this.StartColor, g = this.StartColor, b = this.StartColor, a = this.StartColor}, t:  val_19);
            helper.SetUIVertex(vertex:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3(), normal = new UnityEngine.Vector3(), tangent = new UnityEngine.Vector4(), color = new UnityEngine.Color32(), uv0 = new UnityEngine.Vector2(), uv1 = new UnityEngine.Vector2(), uv2 = new UnityEngine.Vector2(), uv3 = new UnityEngine.Vector2()}, i:  0);
            val_16 = 0 + 1;
        }
        while(val_16 < helper.currentVertCount);
    
    }
    public Gradient()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        UnityEngine.Color32 val_2 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a});
        this.StartColor = val_2;
        UnityEngine.Color val_3 = UnityEngine.Color.black;
        UnityEngine.Color32 val_4 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a});
        this.EndColor = val_4;
    }

}

using UnityEngine;
public class RawImageSkew : RawImage
{
    // Fields
    public UnityEngine.Vector2 skewAmount;
    
    // Methods
    protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vh)
    {
        UnityEngine.Color val_1 = this.color;
        UnityEngine.Color32 val_2 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a});
        byte val_24 = val_2.r;
        vh.Clear();
        float val_23 = 0f;
        UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  1f, y:  val_23);
        float val_4 = 1f.xMax;
        val_23 = val_4.yMax + val_23;
        UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_4 + this.skewAmount, y:  val_23);
        val_24 = val_24 & 4294967295;
        vh.AddVert(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, color:  new UnityEngine.Color32() {r = val_24, g = val_24, b = val_24, a = val_24}, uv0:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
        float val_25 = -1f;
        UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  1f, y:  val_25);
        float val_9 = 1f.xMax;
        val_25 = val_9.yMin + val_25;
        UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  val_9 - this.skewAmount, y:  val_25);
        vh.AddVert(position:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, color:  new UnityEngine.Color32() {r = val_24, g = val_24, b = val_24, a = val_24}, uv0:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y});
        float val_26 = -1f;
        UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  0f, y:  val_26);
        float val_14 = 0f.xMin;
        val_26 = val_14.yMin - val_26;
        UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  val_14 - this.skewAmount, y:  val_26);
        vh.AddVert(position:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, color:  new UnityEngine.Color32() {r = val_24, g = val_24, b = val_24, a = val_24}, uv0:  new UnityEngine.Vector2() {x = val_17.x, y = val_17.y});
        float val_27 = 0f;
        UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  0f, y:  val_27);
        float val_19 = 0f.xMin;
        UnityEngine.Vector2 val_22;
        val_27 = val_19.yMax - val_27;
        val_22 = new UnityEngine.Vector2(x:  val_19 + this.skewAmount, y:  val_27);
        vh.AddVert(position:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, color:  new UnityEngine.Color32() {r = val_24, g = val_24, b = val_24, a = val_24}, uv0:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y});
        vh.AddTriangle(idx0:  0, idx1:  1, idx2:  2);
        vh.AddTriangle(idx0:  2, idx1:  3, idx2:  0);
    }
    public RawImageSkew()
    {
    
    }

}

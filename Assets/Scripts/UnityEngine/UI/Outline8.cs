using UnityEngine;

namespace UnityEngine.UI
{
    public class Outline8 : Shadow
    {
        // Methods
        protected Outline8()
        {
        
        }
        public override void ModifyMesh(UnityEngine.UI.VertexHelper vh)
        {
            if(this.IsActive() == false)
            {
                    return;
            }
            
            System.Collections.Generic.List<T> val_2 = UnityEngine.UI.ListPool<UnityEngine.UIVertex>.Get();
            vh.GetUIVertexStream(stream:  val_2);
            if(val_2.Capacity < 398135736)
            {
                    val_2.Capacity = 398135736;
            }
            
            UnityEngine.Color32 val_4 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color());
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_4.r & 4294967295, g = val_4.r & 4294967295, b = val_4.r & 4294967295, a = val_4.r & 4294967295}, start:  0, end:  0, x:  null, y:  null);
            UnityEngine.Color32 val_6 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color());
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_6.r & 4294967295, g = val_6.r & 4294967295, b = val_6.r & 4294967295, a = val_6.r & 4294967295}, start:  398135736, end:  0, x:  null, y:  -S1);
            UnityEngine.Color32 val_8 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {g = -S1});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_8.r & 4294967295, g = val_8.r & 4294967295, b = val_8.r & 4294967295, a = val_8.r & 4294967295}, start:  W23, end:  0, x:  -S0, y:  -S1);
            UnityEngine.Color32 val_10 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = -S0, g = -S1});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_10.r & 4294967295, g = val_10.r & 4294967295, b = val_10.r & 4294967295, a = val_10.r & 4294967295}, start:  398135736, end:  0, x:  -(-S0), y:  -(-S1));
            UnityEngine.Color32 val_12 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = -(-S0), g = -(-S1)});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_12.r & 4294967295, g = val_12.r & 4294967295, b = val_12.r & 4294967295, a = val_12.r & 4294967295}, start:  W23, end:  0, x:  0f, y:  -(-S1));
            UnityEngine.Color32 val_14 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = 0f, g = -(-S1)});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_14.r & 4294967295, g = val_14.r & 4294967295, b = val_14.r & 4294967295, a = val_14.r & 4294967295}, start:  398135736, end:  0, x:  0f, y:  0f);
            UnityEngine.Color32 val_16 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = 0f, g = 0f});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_16.r & 4294967295, g = val_16.r & 4294967295, b = val_16.r & 4294967295, a = val_16.r & 4294967295}, start:  W23, end:  0, x:  -0f, y:  0f);
            UnityEngine.Color32 val_18 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = -0f, g = 0f});
            this.ApplyShadowZeroAlloc(verts:  val_2, color:  new UnityEngine.Color32() {r = val_18.r & 4294967295, g = val_18.r & 4294967295, b = val_18.r & 4294967295, a = val_18.r & 4294967295}, start:  398135736, end:  0, x:  0f, y:  -(-0f));
            vh.Clear();
            vh.AddUIVertexTriangleStream(verts:  val_2);
            UnityEngine.UI.ListPool<UnityEngine.UIVertex>.Release(toRelease:  val_2);
        }
    
    }

}

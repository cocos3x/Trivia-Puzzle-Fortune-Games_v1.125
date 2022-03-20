using UnityEngine;
public static class UIGradientUtils
{
    // Fields
    private static UnityEngine.Vector2[] ms_verticesPositions;
    
    // Properties
    public static UnityEngine.Vector2[] VerticePositions { get; }
    
    // Methods
    public static UIGradientUtils.Matrix2x3 LocalPositionMatrix(UnityEngine.Rect rect, UnityEngine.Vector2 dir)
    {
        Matrix2x3 val_0;
        UnityEngine.Vector2 val_1 = rect.m_XMin.min;
        UnityEngine.Vector2 val_2 = rect.m_XMin.size;
        float val_3 = val_1.x / val_2.x;
        float val_7 = 0.5f;
        float val_4 = val_1.y / val_2.y;
        dir.y = dir.y / val_2.y;
        val_2.x = dir.x / val_2.x;
        val_3 = val_3 + val_7;
        val_7 = val_4 + val_7;
        val_0.m00 = val_2.x;
        val_0.m01 = dir.y;
        float val_6 = dir.x * val_3;
        val_4 = dir.y * val_7;
        val_3 = dir.y * val_3;
        val_7 = dir.x * val_7;
        val_6 = val_6 - val_4;
        val_3 = val_3 + val_7;
        val_6 = val_6 + (-0.5f);
        val_3 = val_3 + (-0.5f);
        val_2.y = dir.x / val_2.y;
        val_0.m02 = -val_6;
        val_0.m10 = dir.y / val_2.x;
        val_0.m11 = val_2.y;
        val_0.m12 = -val_3;
        return val_0;
    }
    public static UnityEngine.Vector2[] get_VerticePositions()
    {
        null = null;
        return (UnityEngine.Vector2[])UIGradientUtils.ms_verticesPositions;
    }
    public static UnityEngine.Vector2 RotationDir(float angle)
    {
        float val_2 = angle;
        val_2 = val_2 * 0.01745329f;
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  val_2, y:  val_2);
        return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public static UnityEngine.Vector2 CompensateAspectRatio(UnityEngine.Rect rect, UnityEngine.Vector2 dir)
    {
        float val_2 = rect.m_XMin.width;
        val_2 = rect.m_XMin.height / val_2;
        val_2 = dir.x * val_2;
        UnityEngine.Vector2 val_3 = val_2.normalized;
        return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }
    public static float InverseLerp(float a, float b, float v)
    {
        if(a == b)
        {
                return (float)0f;
        }
        
        v = v - a;
        a = b - a;
        0f = v / a;
        return (float)0f;
    }
    public static UnityEngine.Color Bilerp(UnityEngine.Color a1, UnityEngine.Color a2, UnityEngine.Color b1, UnityEngine.Color b2, UnityEngine.Vector2 t)
    {
        var val_1;
        float val_2;
        float val_3;
        float val_4;
        float val_5;
        UnityEngine.Color val_6 = UnityEngine.Color.LerpUnclamped(a:  new UnityEngine.Color() {r = a1.r, g = a1.g, b = a1.b, a = a1.a}, b:  new UnityEngine.Color() {r = a2.r, g = a2.g, b = a2.b, a = a2.a}, t:  b2.r);
        UnityEngine.Color val_7 = UnityEngine.Color.LerpUnclamped(a:  new UnityEngine.Color() {r = b1.r, g = val_2, b = b1.g, a = val_3}, b:  new UnityEngine.Color() {r = b1.b, g = val_5, b = b1.a, a = val_4}, t:  b2.r);
        return UnityEngine.Color.LerpUnclamped(a:  new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a}, b:  new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a}, t:  val_1);
    }
    public static void Lerp(UnityEngine.UIVertex a, UnityEngine.UIVertex b, float t, ref UnityEngine.UIVertex c)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.LerpUnclamped(a:  new UnityEngine.Vector3() {x = a.position.x, y = a.position.y, z = a.position.z}, b:  new UnityEngine.Vector3() {x = b.position.x, y = b.position.y, z = b.position.z}, t:  t);
        c.position.x = val_1.x;
        c.position.y = val_1.y;
        c.position.z = val_1.z;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.LerpUnclamped(a:  new UnityEngine.Vector3() {x = a.normal.x, y = a.normal.y, z = a.normal.z}, b:  new UnityEngine.Vector3() {x = b.normal.x, y = b.normal.y, z = b.normal.z}, t:  t);
        c.normal.x = val_2.x;
        c.normal.y = val_2.y;
        c.normal.z = val_2.z;
        UnityEngine.Color32 val_3 = UnityEngine.Color32.LerpUnclamped(a:  new UnityEngine.Color32() {r = a.color.r, g = a.color.r, b = a.color.r, a = a.color.r}, b:  new UnityEngine.Color32() {r = b.color.r, g = b.color.r, b = b.color.r, a = b.color.r}, t:  t);
        c.color.r = val_3.r;
        c.color.g = val_3.g;
        c.color.b = val_3.b;
        c.color.a = val_3.a;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector4.op_Implicit(v:  new UnityEngine.Vector4() {x = a.tangent.x, y = a.tangent.y, z = a.tangent.z, w = a.tangent.w});
        UnityEngine.Vector3 val_5 = UnityEngine.Vector4.op_Implicit(v:  new UnityEngine.Vector4() {x = b.tangent.x, y = b.tangent.y, z = b.tangent.z, w = b.tangent.w});
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.LerpUnclamped(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, t:  t);
        UnityEngine.Vector4 val_7 = UnityEngine.Vector4.op_Implicit(v:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        c.tangent.x = val_7.x;
        c.tangent.y = val_7.y;
        c.tangent.z = val_7.z;
        c.tangent.w = val_7.w;
        UnityEngine.Vector3 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = a.uv0.x, y = a.uv0.y});
        UnityEngine.Vector3 val_9 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = b.uv0.x, y = b.uv0.y});
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.LerpUnclamped(a:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, t:  t);
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
        c.uv0.x = val_11.x;
        c.uv0.y = val_11.y;
        UnityEngine.Vector3 val_12 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = a.uv1.x, y = a.uv1.y});
        UnityEngine.Vector3 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = b.uv1.x, y = b.uv1.y});
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.LerpUnclamped(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, t:  t);
        UnityEngine.Vector2 val_15 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
        c.uv1.x = val_15.x;
        c.uv1.y = val_15.y;
    }
    private static UIGradientUtils()
    {
        UnityEngine.Vector2[] val_1 = new UnityEngine.Vector2[4];
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.up;
        val_1[0] = val_2;
        val_1[0] = val_2.y;
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.one;
        val_1[1] = val_3;
        val_1[1] = val_3.y;
        UnityEngine.Vector2 val_4 = UnityEngine.Vector2.right;
        val_1[2] = val_4;
        val_1[2] = val_4.y;
        UnityEngine.Vector2 val_5 = UnityEngine.Vector2.zero;
        val_1[3] = val_5;
        val_1[3] = val_5.y;
        UIGradientUtils.ms_verticesPositions = val_1;
    }

}

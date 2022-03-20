using UnityEngine;
public static class SRMath
{
    // Methods
    public static float Ease(float from, float to, float t, SRMath.EaseType type)
    {
        if(type > 40)
        {
                throw new System.ArgumentOutOfRangeException(paramName:  "type");
        }
        
        var val_159 = 32557088 + (type) << 2;
        val_159 = val_159 + 32557088;
        goto (32557088 + (type) << 2 + 32557088);
    }
    public static float SpringLerp(float strength, float deltaTime)
    {
        var val_3;
        float val_4;
        var val_5;
        val_4 = strength;
        float val_3 = 1000f;
        val_3 = deltaTime * val_3;
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  val_3);
        if(val_1 >= 1)
        {
                val_4 = val_4 * 0.001f;
            do
        {
            val_3 = val_1 - 1;
            val_5 = UnityEngine.Mathf.Lerp(a:  0f, b:  1f, t:  val_4);
        }
        while(val_1 != 1);
        
            return (float)val_5;
        }
        
        val_5 = 0f;
        return (float)val_5;
    }
    public static float SpringLerp(float from, float to, float strength, float deltaTime)
    {
        return UnityEngine.Mathf.Lerp(a:  from, b:  to, t:  SRMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static UnityEngine.Vector3 SpringLerp(UnityEngine.Vector3 from, UnityEngine.Vector3 to, float strength, float deltaTime)
    {
        return UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = from.x, y = from.y, z = from.z}, b:  new UnityEngine.Vector3() {x = to.x, y = to.y, z = to.z}, t:  SRMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static UnityEngine.Quaternion SpringLerp(UnityEngine.Quaternion from, UnityEngine.Quaternion to, float strength, float deltaTime)
    {
        return UnityEngine.Quaternion.Slerp(a:  new UnityEngine.Quaternion() {x = from.x, y = from.y, z = from.z, w = from.w}, b:  new UnityEngine.Quaternion() {x = to.x, y = to.y, z = to.z, w = to.w}, t:  SRMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static float SmoothClamp(float value, float min, float max, float scrollMax, SRMath.EaseType easeType = 5)
    {
        float val_6 = value;
        if(val_6 < 0)
        {
                return (float)val_6;
        }
        
        val_6 = val_6 - min;
        float val_1 = scrollMax - min;
        val_1 = val_6 / val_1;
        float val_2 = UnityEngine.Mathf.Clamp01(value:  val_1);
        UnityEngine.Debug.Log(message:  val_2);
        float val_4 = UnityEngine.Mathf.Lerp(a:  val_6, b:  max, t:  SRMath.Ease(from:  0f, to:  1f, t:  val_2, type:  easeType));
        val_4 = val_4 + min;
        val_6 = UnityEngine.Mathf.Clamp(value:  val_4, min:  0f, max:  max);
        return (float)val_6;
    }
    public static float LerpUnclamped(float from, float to, float t)
    {
        float val_1 = 1f;
        val_1 = val_1 - t;
        from = val_1 * from;
        to = to * t;
        from = to + from;
        return (float)from;
    }
    public static UnityEngine.Vector3 LerpUnclamped(UnityEngine.Vector3 from, UnityEngine.Vector3 to, float t)
    {
        to.x = to.x * t;
        to.y = to.y * t;
        to.z = to.z * t;
        t = 1f - t;
        from.x = from.x * t;
        from.y = from.y * t;
        from.z = from.z * t;
        from.x = to.x + from.x;
        from.y = to.y + from.y;
        from.z = to.z + from.z;
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  from.x, y:  from.y, z:  from.z);
        return new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
    }
    public static float FacingNormalized(UnityEngine.Vector3 dir1, UnityEngine.Vector3 dir2)
    {
        dir1.x.Normalize();
        dir2.x.Normalize();
        return (float)UnityEngine.Mathf.InverseLerp(a:  -1f, b:  1f, value:  UnityEngine.Vector3.Dot(lhs:  new UnityEngine.Vector3() {x = dir1.x, y = dir1.y, z = dir1.z}, rhs:  new UnityEngine.Vector3() {x = dir2.x, y = dir2.y, z = dir2.z}));
    }
    public static float WrapAngle(float angle)
    {
        if(angle > (-180f))
        {
                float val_1 = -360f;
            val_1 = angle + val_1;
            angle = (angle > 180f) ? (val_1) : angle;
            return (float)angle;
        }
        
        angle = angle + 360f;
        return (float)angle;
    }
    public static float NearestAngle(float to, float angle1, float angle2)
    {
        return (float)((System.Math.Abs(UnityEngine.Mathf.DeltaAngle(current:  to, target:  angle1))) > (System.Math.Abs(UnityEngine.Mathf.DeltaAngle(current:  to, target:  angle2)))) ? angle2 : angle1;
    }
    public static int Wrap(int max, int value)
    {
        int val_2 = value;
        if((max & 2147483648) != 0)
        {
                throw new System.ArgumentOutOfRangeException(paramName:  "max", message:  "max must be greater than 0");
        }
        
        do
        {
            val_2 = val_2 + max;
        }
        while((-max) < 0);
        
        do
        {
            val_2 = val_2 - max;
        }
        while(val_2 >= max);
        
        return (int)val_2;
    }
    public static float Wrap(float max, float value)
    {
        float val_1;
        goto label_0;
        label_1:
        val_1 = value + max;
        label_0:
        if(val_1 < 0)
        {
            goto label_1;
        }
        
        goto label_2;
        label_3:
        val_1 = val_1 - max;
        label_2:
        if(val_1 >= max)
        {
            goto label_3;
        }
        
        return val_1;
    }
    public static float Average(float v1, float v2)
    {
        v1 = v1 + v2;
        v1 = v1 * 0.5f;
        return (float)v1;
    }
    public static float Angle(UnityEngine.Vector2 direction)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = direction.x, y = direction.y});
        float val_3 = UnityEngine.Vector3.Angle(from:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, to:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = direction.x, y = direction.y});
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, rhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        return (float)(val_6.z > 0f) ? (-val_3) : (val_3);
    }

}

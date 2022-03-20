using UnityEngine;
public static class NGUIMath
{
    // Methods
    public static float Lerp(float from, float to, float factor)
    {
        float val_1 = 1f;
        val_1 = val_1 - factor;
        from = val_1 * from;
        to = to * factor;
        from = to + from;
        return (float)from;
    }
    public static int ClampIndex(int val, int max)
    {
        if((val & 2147483648) != 0)
        {
                return 0;
        }
        
        return (int)(val < max) ? val : (max - 1);
    }
    public static int RepeatIndex(int val, int max)
    {
        if(max < 1)
        {
                return 0;
        }
        
        do
        {
            val = val + max;
        }
        while((-max) < 0);
        
        do
        {
            val = val - max;
        }
        while(val >= max);
        
        return (int)val;
    }
    public static float WrapAngle(float angle)
    {
        if(angle > 180f)
        {
                do
        {
            angle = angle + (-360f);
        }
        while(angle > 180f);
        
        }
        
        if(angle >= 0)
        {
                return angle;
        }
        
        do
        {
            angle = angle + 360f;
        }
        while(angle < 0);
        
        return angle;
    }
    public static float Wrap01(float val)
    {
        float val_2 = (float)UnityEngine.Mathf.FloorToInt(f:  val);
        val_2 = val - val_2;
        return (float)val_2;
    }
    public static int HexToDecimal(char ch)
    {
        if(((ch - 48) & 65535) > '6')
        {
                return 15;
        }
        
        return (int)32576976 + ((int)(short)(((ch - 48)) & 0xFFFF)) << 2;
    }
    public static char DecimalToHexChar(int num)
    {
        if(num > 15)
        {
                return 70;
        }
        
        if(num <= 9)
        {
                num = num + 48;
            return (char)num;
        }
        
        num = num + 55;
        return (char)num;
    }
    public static string DecimalToHex(int num)
    {
        return (string)num & 16777215.ToString(format:  "X6");
    }
    public static int ColorToInt(UnityEngine.Color c)
    {
        c.r = c.r * 255f;
        int val_7 = UnityEngine.Mathf.RoundToInt(f:  c.a * 255f);
        int val_8 = (UnityEngine.Mathf.RoundToInt(f:  c.g * 255f)) << 16;
        val_8 = val_8 | ((UnityEngine.Mathf.RoundToInt(f:  c.r)) << 24);
        val_8 = val_8 | ((UnityEngine.Mathf.RoundToInt(f:  c.b * 255f)) << 8);
        val_7 = val_8 | val_7;
        return (int)val_7;
    }
    public static UnityEngine.Color IntToColor(int val)
    {
        UnityEngine.Color val_1 = UnityEngine.Color.black;
        float val_4 = (float)val >> 24;
        float val_7 = 0.003921569f;
        float val_5 = (float)(uint)(val >> 16) & 255;
        float val_6 = (float)(uint)(val >> 8) & 255;
        val_4 = val_4 * val_7;
        val_5 = val_5 * val_7;
        val_6 = val_6 * val_7;
        val_7 = ((float)val & 255) * val_7;
        return new UnityEngine.Color() {r = val_4, g = val_5, b = val_6, a = val_7};
    }
    public static string IntToBinary(int val, int bits)
    {
        var val_7;
        string val_8;
        string val_9;
        var val_10;
        val_7 = bits;
        val_8 = "";
        if(val_7 < 1)
        {
                return (string)val_10;
        }
        
        do
        {
            if(val_7 <= 24)
        {
                if(((1 << val_7) & 16843008) == 0)
        {
                val_9 = val_8 + " ";
        }
        
        }
        
            int val_3 = val_7 - 1;
            val_3 = 1 << val_3;
            val_7 = val_7 - 1;
            val_10 = val_9 + (val_3 != val) ? (48 + 1) : 48.ToString()((val_3 != val) ? (48 + 1) : 48.ToString());
        }
        while(val_3 > val);
        
        return (string)val_10;
    }
    public static UnityEngine.Color HexToColor(uint val)
    {
        return NGUIMath.IntToColor(val:  val);
    }
    public static UnityEngine.Rect ConvertToTexCoords(UnityEngine.Rect rect, int width, int height)
    {
        float val_5;
        float val_6;
        float val_7;
        if(width == 0)
        {
                return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = val_5, m_Width = val_6, m_Height = val_7};
        }
        
        if(height == 0)
        {
                return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = val_5, m_Width = val_6, m_Height = val_7};
        }
        
        float val_1 = rect.m_XMin.xMin;
        val_1 = val_1 / (float)width;
        rect.m_XMin.xMin = val_1;
        float val_2 = rect.m_XMin.xMax;
        val_2 = val_2 / (float)width;
        rect.m_XMin.xMax = val_2;
        float val_3 = rect.m_XMin.yMax;
        val_3 = val_3 / (float)height;
        val_3 = 1f - val_3;
        rect.m_XMin.yMin = val_3;
        float val_4 = rect.m_XMin.yMin;
        val_4 = val_4 / (float)height;
        val_4 = 1f - val_4;
        rect.m_XMin.yMax = val_4;
        return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = val_5, m_Width = val_6, m_Height = val_7};
    }
    public static UnityEngine.Rect ConvertToPixels(UnityEngine.Rect rect, int width, int height, bool round)
    {
        float val_12;
        float val_13;
        float val_14;
        float val_15;
        float val_1 = rect.m_XMin.xMin;
        if(round != false)
        {
                val_1 = val_1 * (float)width;
            rect.m_XMin.xMin = (float)UnityEngine.Mathf.RoundToInt(f:  val_1);
            float val_3 = rect.m_XMin.xMax;
            val_3 = val_3 * (float)width;
            rect.m_XMin.xMax = (float)UnityEngine.Mathf.RoundToInt(f:  val_3);
            float val_5 = rect.m_XMin.yMax;
            val_15 = 1f;
            val_5 = val_15 - val_5;
            val_5 = val_5 * (float)height;
            rect.m_XMin.yMin = (float)UnityEngine.Mathf.RoundToInt(f:  val_5);
            float val_7 = rect.m_XMin.yMin;
            val_7 = val_15 - val_7;
            val_7 = val_7 * (float)height;
            int val_8 = UnityEngine.Mathf.RoundToInt(f:  val_7);
        }
        else
        {
                val_1 = val_1 * (float)width;
            rect.m_XMin.xMin = val_1;
            float val_9 = rect.m_XMin.xMax;
            val_9 = val_9 * (float)width;
            rect.m_XMin.xMax = val_9;
            float val_10 = rect.m_XMin.yMax;
            val_15 = 1f;
            val_10 = val_15 - val_10;
            val_10 = val_10 * (float)height;
            rect.m_XMin.yMin = val_10;
            float val_11 = rect.m_XMin.yMin;
            val_11 = val_15 - val_11;
            val_11 = val_11 * (float)height;
        }
        
        rect.m_XMin.yMax = val_11;
        return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = val_12, m_Width = val_13, m_Height = val_14};
    }
    public static UnityEngine.Rect MakePixelPerfect(UnityEngine.Rect rect)
    {
        rect.m_XMin.xMin = (float)UnityEngine.Mathf.RoundToInt(f:  rect.m_XMin.xMin);
        rect.m_XMin.yMin = (float)UnityEngine.Mathf.RoundToInt(f:  rect.m_XMin.yMin);
        rect.m_XMin.xMax = (float)UnityEngine.Mathf.RoundToInt(f:  rect.m_XMin.xMax);
        rect.m_XMin.yMax = (float)UnityEngine.Mathf.RoundToInt(f:  rect.m_XMin.yMax);
        return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = rect.m_YMin, m_Width = rect.m_Width, m_Height = rect.m_Height};
    }
    public static UnityEngine.Rect MakePixelPerfect(UnityEngine.Rect rect, int width, int height)
    {
        UnityEngine.Rect val_1 = NGUIMath.ConvertToPixels(rect:  new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = rect.m_YMin, m_Width = rect.m_Width, m_Height = rect.m_Height}, width:  width, height:  height, round:  true);
        val_1.m_XMin.xMin = (float)UnityEngine.Mathf.RoundToInt(f:  val_1.m_XMin.xMin);
        val_1.m_XMin.yMin = (float)UnityEngine.Mathf.RoundToInt(f:  val_1.m_XMin.yMin);
        val_1.m_XMin.xMax = (float)UnityEngine.Mathf.RoundToInt(f:  val_1.m_XMin.xMax);
        val_1.m_XMin.yMax = (float)UnityEngine.Mathf.RoundToInt(f:  val_1.m_XMin.yMax);
        UnityEngine.Rect val_10 = NGUIMath.ConvertToTexCoords(rect:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, width:  width, height:  height);
        return new UnityEngine.Rect() {m_XMin = val_10.m_XMin, m_YMin = val_10.m_YMin, m_Width = val_10.m_Width, m_Height = val_10.m_Height};
    }
    public static UnityEngine.Vector3 ApplyHalfPixelOffset(UnityEngine.Vector3 pos)
    {
        float val_2;
        float val_3;
        val_2 = pos.y;
        val_3 = pos.x;
        UnityEngine.RuntimePlatform val_1 = UnityEngine.Application.platform;
        if(val_1 > 10)
        {
                return new UnityEngine.Vector3() {x = val_3, y = val_2, z = pos.z};
        }
        
        var val_2 = 1;
        val_2 = val_2 << val_1;
        if((val_2 & 1156) != 0)
        {
                return new UnityEngine.Vector3() {x = val_3, y = val_2, z = pos.z};
        }
        
        val_3 = val_3 + (-0.5f);
        val_2 = val_2 + 0.5f;
        return new UnityEngine.Vector3() {x = val_3, y = val_2, z = pos.z};
    }
    public static UnityEngine.Vector3 ApplyHalfPixelOffset(UnityEngine.Vector3 pos, UnityEngine.Vector3 scale)
    {
        var val_9;
        float val_10;
        float val_11;
        val_10 = pos.y;
        val_11 = pos.x;
        UnityEngine.RuntimePlatform val_1 = UnityEngine.Application.platform;
        if(val_1 > 10)
        {
                return new UnityEngine.Vector3() {x = val_11, y = val_10, z = pos.z};
        }
        
        var val_9 = 1;
        val_9 = val_9 << val_1;
        if((val_9 & 1156) != 0)
        {
                return new UnityEngine.Vector3() {x = val_11, y = val_10, z = pos.z};
        }
        
        float val_10 = -0.5f;
        val_10 = val_11 + val_10;
        val_11 = ((UnityEngine.Mathf.RoundToInt(f:  scale.x)) == ((UnityEngine.Mathf.RoundToInt(f:  scale.x * 0.5f)) << 1)) ? (val_10) : (val_11);
        val_9 = UnityEngine.Mathf.RoundToInt(f:  scale.y);
        val_10 = (val_9 == ((UnityEngine.Mathf.RoundToInt(f:  scale.y * 0.5f)) << 1)) ? (val_10 + 0.5f) : (val_10);
        return new UnityEngine.Vector3() {x = val_11, y = val_10, z = pos.z};
    }
    public static UnityEngine.Vector2 ConstrainRect(UnityEngine.Vector2 minRect, UnityEngine.Vector2 maxRect, UnityEngine.Vector2 minArea, UnityEngine.Vector2 maxArea)
    {
        float val_10;
        float val_11;
        float val_12;
        float val_13;
        val_10 = maxArea.y;
        val_11 = maxArea.x;
        val_12 = minArea.y;
        val_13 = minArea.x;
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        float val_2 = maxRect.x - minRect.x;
        float val_3 = val_11 - val_13;
        float val_4 = maxRect.y - minRect.y;
        float val_5 = val_10 - val_12;
        if(val_2 > val_3)
        {
                val_2 = val_2 - val_3;
            val_13 = val_13 - val_2;
            val_11 = val_11 + val_2;
        }
        
        if(val_4 > val_5)
        {
                val_4 = val_4 - val_5;
            val_12 = val_12 - val_4;
            val_10 = val_10 + val_4;
        }
        
        float val_6 = val_13 - minRect.x;
        val_6 = val_1.x + val_6;
        float val_7 = maxRect.x - val_11;
        val_1.x = (minRect.x < 0) ? (val_6) : val_1.x;
        float val_8 = val_12 - minRect.y;
        val_7 = val_1.x - val_7;
        val_8 = val_1.y + val_8;
        val_1.x = (maxRect.x > val_11) ? (val_7) : (val_1.x);
        float val_9 = maxRect.y - val_10;
        val_1.y = (minRect.y < 0) ? (val_8) : val_1.y;
        val_9 = val_1.y - val_9;
        val_1.y = (maxRect.y > val_10) ? (val_9) : (val_1.y);
        return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public static UnityEngine.Vector3 SpringDampen(ref UnityEngine.Vector3 velocity, float strength, float deltaTime)
    {
        float val_6 = strength;
        float val_5 = -0.001f;
        val_5 = val_6 * val_5;
        val_6 = val_5 + 1f;
        float val_7 = 1000f;
        val_7 = deltaTime * val_7;
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  val_7);
        float val_8 = -1f;
        val_8 = val_6 + val_8;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = velocity.x, y = velocity.y, z = velocity.z}, d:  val_8 / val_6);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = velocity.x, y = velocity.y, z = velocity.z}, d:  val_6);
        velocity.x = val_4.x;
        velocity.y = val_4.y;
        velocity.z = val_4.z;
        return UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, d:  0.06f);
    }
    public static UnityEngine.Vector2 SpringDampen(ref UnityEngine.Vector2 velocity, float strength, float deltaTime)
    {
        float val_6 = strength;
        float val_5 = -0.001f;
        val_5 = val_6 * val_5;
        val_6 = val_5 + 1f;
        float val_7 = 1000f;
        val_7 = deltaTime * val_7;
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  val_7);
        float val_8 = -1f;
        val_8 = val_6 + val_8;
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = velocity.x, y = velocity.y}, d:  val_8 / val_6);
        UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = velocity.x, y = velocity.y}, d:  val_6);
        velocity.x = val_4.x;
        velocity.y = val_4.y;
        return UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, d:  0.06f);
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
        var val_3;
        float val_4;
        float val_5;
        val_4 = strength;
        val_5 = from;
        float val_3 = 1000f;
        val_3 = deltaTime * val_3;
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  val_3);
        if(val_1 < 1)
        {
                return (float)val_5;
        }
        
        val_4 = val_4 * 0.001f;
        do
        {
            val_3 = val_1 - 1;
            val_5 = UnityEngine.Mathf.Lerp(a:  val_5, b:  to, t:  val_4);
        }
        while(val_1 != 1);
        
        return (float)val_5;
    }
    public static UnityEngine.Vector2 SpringLerp(UnityEngine.Vector2 from, UnityEngine.Vector2 to, float strength, float deltaTime)
    {
        return UnityEngine.Vector2.Lerp(a:  new UnityEngine.Vector2() {x = from.x, y = from.y}, b:  new UnityEngine.Vector2() {x = to.x, y = to.y}, t:  NGUIMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static UnityEngine.Vector3 SpringLerp(UnityEngine.Vector3 from, UnityEngine.Vector3 to, float strength, float deltaTime)
    {
        return UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = from.x, y = from.y, z = from.z}, b:  new UnityEngine.Vector3() {x = to.x, y = to.y, z = to.z}, t:  NGUIMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static UnityEngine.Quaternion SpringLerp(UnityEngine.Quaternion from, UnityEngine.Quaternion to, float strength, float deltaTime)
    {
        return UnityEngine.Quaternion.Slerp(a:  new UnityEngine.Quaternion() {x = from.x, y = from.y, z = from.z, w = from.w}, b:  new UnityEngine.Quaternion() {x = to.x, y = to.y, z = to.z, w = to.w}, t:  NGUIMath.SpringLerp(strength:  strength, deltaTime:  deltaTime));
    }
    public static float RotateTowards(float from, float to, float maxAngle)
    {
        float val_2 = to - from;
        if(val_2 > 180f)
        {
                do
        {
            val_2 = val_2 + (-360f);
        }
        while(val_2 > 180f);
        
        }
        
        if(val_2 < 0)
        {
                do
        {
            val_2 = val_2 + 360f;
        }
        while(val_2 < 0);
        
        }
        
        if(System.Math.Abs(val_2) > maxAngle)
        {
                float val_1 = UnityEngine.Mathf.Sign(f:  val_2);
            val_2 = val_1 * maxAngle;
        }
        
        val_1 = val_2 + from;
        return (float)val_1;
    }
    private static float DistancePointToLineSegment(UnityEngine.Vector2 point, UnityEngine.Vector2 a, UnityEngine.Vector2 b)
    {
        float val_11;
        float val_12;
        float val_13;
        val_11 = a.y;
        val_12 = a.x;
        val_13 = point.y;
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = b.x, y = b.y}, b:  new UnityEngine.Vector2() {x = val_12, y = val_11});
        float val_2 = val_1.x.sqrMagnitude;
        if(val_2 == 0f)
        {
            
        }
        else
        {
                float val_11 = val_2;
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = point.x, y = val_13}, b:  new UnityEngine.Vector2() {x = val_12, y = val_11});
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = b.x, y = b.y}, b:  new UnityEngine.Vector2() {x = val_12, y = val_11});
            val_11 = (UnityEngine.Vector2.Dot(lhs:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, rhs:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y})) / val_11;
            if(val_11 < 0)
        {
            
        }
        else
        {
                if(val_11 > 1f)
        {
                val_12 = b.x;
            val_11 = b.y;
        }
        else
        {
                UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = b.x, y = b.y}, b:  new UnityEngine.Vector2() {x = val_12, y = val_11});
            UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Multiply(d:  val_11, a:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_12, y = val_11}, b:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            val_12 = val_8.x;
            val_11 = val_8.y;
        }
        
        }
        
            val_13 = val_13;
        }
        
        UnityEngine.Vector2 val_9 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = point.x, y = val_13}, b:  new UnityEngine.Vector2() {x = val_12, y = val_11});
        return (float)val_9.x.magnitude;
    }
    public static float DistanceToRectangle(UnityEngine.Vector2[] screenPoints, UnityEngine.Vector2 mousePos)
    {
        float val_12;
        var val_13;
        var val_15;
        var val_16;
        val_12 = mousePos.y;
        val_13 = 0;
        do
        {
            var val_1 = 0 + 1;
            val_1 = val_1 & 3;
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = screenPoints[val_1], y = screenPoints[val_1]});
            UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = screenPoints[4 & 3], y = screenPoints[4 & 3]});
            var val_5 = (val_2.y <= val_12) ? 1 : 0;
            val_5 = val_5 ^ ((val_4.y > val_12) ? 1 : 0);
            if((val_5 & 1) == 0)
        {
                val_4.x = val_4.x - val_2.x;
            val_4.x = (val_12 - val_2.y) * val_4.x;
            val_4.y = val_4.y - val_2.y;
            val_4.x = val_4.x / val_4.y;
            val_4.x = val_2.x + val_4.x;
            if(mousePos.x < 0)
        {
                val_13 = val_13 ^ 1;
        }
        
        }
        
            var val_8 = 0 + 1;
            val_15 = 0 + 1;
        }
        while(val_15 <= 3);
        
        val_16 = 0f;
        if((val_13 & 1) != 0)
        {
                return (float)(val_15 < 0) ? (val_15) : -1f;
        }
        
        var val_23 = 0;
        do
        {
            var val_9 = val_23 + 1;
            val_15 = (val_23 + 2) & 3;
            UnityEngine.Vector3 val_11 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = 1.187534E-20f, y = 1.187534E-20f});
            UnityEngine.Vector3 val_12 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = screenPoints[val_15], y = screenPoints[val_15]});
            UnityEngine.Vector2 val_13 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
            UnityEngine.Vector2 val_14 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            val_12 = val_12;
            float val_15 = NGUIMath.DistancePointToLineSegment(point:  new UnityEngine.Vector2() {x = mousePos.x, y = val_12}, a:  new UnityEngine.Vector2() {x = val_13.x, y = val_13.y}, b:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y});
            val_23 = val_23 + 1;
        }
        while(val_23 < 3);
        
        return (float)(val_15 < 0) ? (val_15) : -1f;
    }
    public static float DistanceToRectangle(UnityEngine.Vector3[] worldPoints, UnityEngine.Vector2 mousePos, UnityEngine.Camera cam)
    {
        UnityEngine.Vector2[] val_1 = new UnityEngine.Vector2[4];
        var val_5 = 0;
        do
        {
            var val_2 = val_5 + 1;
            UnityEngine.Vector3 val_3 = cam.WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = 1.187865E-20f, y = 1.187865E-20f, z = 1.187865E-20f});
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            val_5 = val_5 + 1;
            mem2[0] = val_4.x;
            mem2[0] = val_4.y;
        }
        while(val_5 < 3);
        
        return NGUIMath.DistanceToRectangle(screenPoints:  val_1, mousePos:  new UnityEngine.Vector2() {x = mousePos.x, y = mousePos.y});
    }

}

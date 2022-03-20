using UnityEngine;

namespace Spine
{
    public static class MathUtils
    {
        // Fields
        public const float PI = 3.141593;
        public const float PI2 = 6.283185;
        public const float RadDeg = 57.29578;
        public const float DegRad = 0.01745329;
        private const int SIN_BITS = 14;
        private const int SIN_MASK = 16383;
        private const int SIN_COUNT = 16384;
        private const float RadFull = 6.283185;
        private const float DegFull = 360;
        private const float RadToIndex = 2607.594;
        private const float DegToIndex = 45.51111;
        private static float[] sin;
        
        // Methods
        private static MathUtils()
        {
            var val_6 = 0;
            Spine.MathUtils.sin = new float[16384];
            do
            {
                float val_5 = 0f;
                val_5 = val_5 + 0.5f;
                val_5 = val_5 * (6.103516E-05f);
                val_5 = val_5 * 6.283185f;
                val_6 = val_6 + 1;
                mem2[0] = (float)(double)val_5;
            }
            while(val_6 < 16383);
            
            var val_8 = 0;
            do
            {
                float val_3 = 0f * 45.51111f;
                int val_7 = (int)(val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
                val_7 = val_7 & 16383;
                val_8 = val_8 + 90;
                val_7 = Spine.MathUtils.sin + val_7;
                mem2[0] = (float)(double)0f * 0.01745329f;
            }
            while(val_8 < 360);
        
        }
        public static float Sin(float radians)
        {
            null = null;
            System.Single[] val_4 = Spine.MathUtils.sin;
            float val_2 = 2607.594f;
            val_2 = radians * val_2;
            int val_3 = (int)(val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            val_3 = val_3 & 16383;
            val_4 = val_4 + val_3;
            return (float)(Spine.MathUtils.sin + (2607.594f == Infinityf ? (radians * 2607.594f) : (radians * 2607.594f) & 16383)) + 32;
        }
        public static float Cos(float radians)
        {
            null = null;
            System.Single[] val_4 = Spine.MathUtils.sin;
            float val_2 = 1.570796f;
            val_2 = radians + val_2;
            val_2 = val_2 * 2607.594f;
            int val_3 = (int)(val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            val_3 = val_3 & 16383;
            val_4 = val_4 + val_3;
            return (float)(Spine.MathUtils.sin + (1.570796f == Infinityf ? ((radians + 1.570796f) * 2607.594f) : ((radians + 1.570796f) * 2607.594f) & 16383)) + 32;
        }
        public static float SinDeg(float degrees)
        {
            null = null;
            System.Single[] val_4 = Spine.MathUtils.sin;
            float val_2 = 45.51111f;
            val_2 = degrees * val_2;
            int val_3 = (int)(val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            val_3 = val_3 & 16383;
            val_4 = val_4 + val_3;
            return (float)(Spine.MathUtils.sin + (45.51111f == Infinityf ? (degrees * 45.51111f) : (degrees * 45.51111f) & 16383)) + 32;
        }
        public static float CosDeg(float degrees)
        {
            null = null;
            System.Single[] val_4 = Spine.MathUtils.sin;
            float val_2 = 90f;
            val_2 = degrees + val_2;
            val_2 = val_2 * 45.51111f;
            int val_3 = (int)(val_2 == Infinityf) ? (-(double)val_2) : ((double)val_2);
            val_3 = val_3 & 16383;
            val_4 = val_4 + val_3;
            return (float)(Spine.MathUtils.sin + (90f == Infinityf ? ((degrees + 90f) * 45.51111f) : ((degrees + 90f) * 45.51111f) & 16383)) + 32;
        }
        public static float Atan2(float y, float x)
        {
            if(x == 0f)
            {
                    if(y > 0f)
            {
                    return (float)val_8;
            }
            
                var val_1 = (y != 0f) ? -1.570796f : 0f;
                return (float)val_8;
            }
            
            float val_2 = y / x;
            float val_7 = 1f;
            if(System.Math.Abs(val_2) < 0)
            {
                    float val_6 = 0.28f;
                val_6 = val_2 * val_6;
                val_6 = val_2 * val_6;
                val_7 = val_6 + val_7;
                val_7 = val_2 / val_7;
                if(x >= 0)
            {
                    return (float)val_8;
            }
            
                var val_3 = (y < 0) ? 1 : 0;
                val_7 = (30113224 + y < 0 ? 1 : 0) + val_7;
                return (float)val_8;
            }
            
            float val_8 = 0.28f;
            val_8 = (val_2 * val_2) + val_8;
            val_8 = val_2 / val_8;
            val_8 = 1.570796f - val_8;
            if(y >= 0)
            {
                    return (float)val_8;
            }
            
            val_8 = val_8 + (-3.141593f);
            return (float)val_8;
        }
        public static float Clamp(float value, float min, float max)
        {
            if(value >= 0)
            {
                    return (float)(value > max) ? max : value;
            }
            
            return (float)min;
        }
    
    }

}

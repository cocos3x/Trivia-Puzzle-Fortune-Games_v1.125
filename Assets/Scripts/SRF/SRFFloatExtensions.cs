using UnityEngine;

namespace SRF
{
    public static class SRFFloatExtensions
    {
        // Methods
        public static float Sqr(float f)
        {
            f = f * f;
            return (float)f;
        }
        public static float SqrRt(float f)
        {
            if(f <= _TYPE_MAX_)
            {
                    return (float)f;
            }
        
        }
        public static bool ApproxZero(float f)
        {
            return UnityEngine.Mathf.Approximately(a:  0f, b:  f);
        }
        public static bool Approx(float f, float f2)
        {
            return UnityEngine.Mathf.Approximately(a:  f, b:  f2);
        }
    
    }

}

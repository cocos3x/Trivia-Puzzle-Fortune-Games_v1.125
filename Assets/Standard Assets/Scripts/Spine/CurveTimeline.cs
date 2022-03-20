using UnityEngine;

namespace Spine
{
    public abstract class CurveTimeline : Timeline
    {
        // Fields
        protected const float LINEAR = 0;
        protected const float STEPPED = 1;
        protected const float BEZIER = 2;
        protected const int BEZIER_SIZE = 19;
        private float[] curves;
        
        // Properties
        public int FrameCount { get; }
        public abstract int PropertyId { get; }
        
        // Methods
        public int get_FrameCount()
        {
            if(this.curves != null)
            {
                    int val_3 = this.curves.Length;
                val_3 = val_3 * 1808407283;
                val_3 = val_3 >> 35;
                val_3 = val_3 + (val_3 >> 63);
                return (int)val_3 + 1;
            }
            
            throw new NullReferenceException();
        }
        public CurveTimeline(int frameCount)
        {
            if(frameCount <= 0)
            {
                    throw new System.ArgumentException(message:  "frameCount must be > 0: "("frameCount must be > 0: ") + frameCount, paramName:  "frameCount");
            }
            
            int val_2 = (frameCount * 19) - 19;
            this.curves = new float[0];
        }
        public abstract void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction); // 0
        public abstract int get_PropertyId(); // 0
        public void SetLinear(int frameIndex)
        {
            this.curves[frameIndex * 19] = 0f;
        }
        public void SetStepped(int frameIndex)
        {
            this.curves[frameIndex * 19] = 1f;
        }
        public void SetCurve(int frameIndex, float cx1, float cy1, float cx2, float cy2)
        {
            int val_1 = frameIndex * 19;
            int val_2 = val_1 + 1;
            val_1 = val_1 + 19;
            this.curves[val_1] = 2f;
            if(val_2 >= val_1)
            {
                    return;
            }
            
            float val_8 = cy1;
            cx2 = cx1 * cx2;
            float val_3 = val_8 + val_8;
            val_8 = val_8 - cy2;
            val_3 = cy2 - val_3;
            double val_9 = 1;
            val_8 = val_8 * 3;
            cy2 = val_3 * cy2;
            float val_4 = val_8 + val_9;
            val_4 = val_4 * 3;
            val_9 = cx2 + val_9;
            val_9 = val_9 + (val_4 * V6.2S);
            float val_6 = cy2 + cy2;
            float val_10 = val_9;
            do
            {
                this.curves[val_2] = val_10;
                val_6 = val_4 + val_6;
                val_2 = val_2 + 2;
                val_9 = val_9 + val_8;
                val_10 = val_10 + val_9;
            }
            while(val_2 < val_1);
        
        }
        public float GetCurvePercent(int frameIndex, float percent)
        {
            var val_11;
            float val_12;
            float val_13;
            float val_14;
            float val_15;
            float val_16;
            float val_1 = Spine.MathUtils.Clamp(value:  percent, min:  0f, max:  1f);
            int val_2 = frameIndex * 19;
            float val_9 = this.curves[val_2];
            if(val_9 == 0f)
            {
                    return (float)val_15;
            }
            
            if(val_9 == 1f)
            {
                    return (float)val_15;
            }
            
            val_11 = val_2 + 1;
            int val_3 = val_2 + 19;
            if(val_11 >= val_3)
            {
                goto label_7;
            }
            
            var val_10 = 0;
            val_2 = val_2 + 2;
            label_10:
            val_12 = this.curves[val_2 - 1];
            if(val_12 >= val_1)
            {
                goto label_9;
            }
            
            val_2 = val_2 + 1;
            val_10 = val_10 - 2;
            if(val_2 < val_3)
            {
                goto label_10;
            }
            
            val_11 = (val_2 + 2) - 1;
            goto label_11;
            label_7:
            val_12 = 0f;
            label_11:
            val_2 = val_11 - 1;
            val_13 = this.curves[val_2];
            val_1 = val_1 - val_12;
            val_14 = 1f - val_12;
            val_15 = val_1 * (1f - val_13);
            goto label_14;
            label_9:
            if(val_10 != 0)
            {
                    int val_7 = val_2 - 3;
                int val_8 = val_2 - 2;
            }
            else
            {
                    val_13 = 0f;
                val_16 = 0f;
            }
            
            float val_11 = this.curves[val_2];
            val_1 = val_1 - val_16;
            val_14 = val_12 - val_16;
            val_11 = val_11 - val_13;
            val_15 = val_1 * val_11;
            label_14:
            val_15 = val_15 / val_14;
            val_15 = val_13 + val_15;
            return (float)val_15;
        }
        public float GetCurveType(int frameIndex)
        {
            return (float)this.curves[frameIndex * 19];
        }
    
    }

}

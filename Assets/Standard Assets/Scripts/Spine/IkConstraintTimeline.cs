using UnityEngine;

namespace Spine
{
    public class IkConstraintTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 3;
        private const int PREV_TIME = -3;
        private const int PREV_MIX = -2;
        private const int PREV_BEND_DIRECTION = -1;
        private const int MIX = 1;
        private const int BEND_DIRECTION = 2;
        internal int ikConstraintIndex;
        internal float[] frames;
        
        // Properties
        public int IkConstraintIndex { get; set; }
        public float[] Frames { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public int get_IkConstraintIndex()
        {
            return (int)this.ikConstraintIndex;
        }
        public void set_IkConstraintIndex(int value)
        {
            this.ikConstraintIndex = value;
        }
        public float[] get_Frames()
        {
            return (System.Single[])this.frames;
        }
        public void set_Frames(float[] value)
        {
            this.frames = value;
        }
        public override int get_PropertyId()
        {
            return (int)this.ikConstraintIndex + 150994944;
        }
        public IkConstraintTimeline(int frameCount)
        {
            int val_1 = frameCount + (frameCount << 1);
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float mix, int bendDirection)
        {
            int val_1 = frameIndex + (frameIndex << 1);
            this.frames[val_1] = time;
            this.frames[val_1 + 1] = mix;
            val_1 = val_1 + 2;
            this.frames[val_1] = (float)bendDirection;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_13;
            int val_15;
            var val_1 = X9 + ((this.ikConstraintIndex) << 3);
            if(this.frames[0] <= time)
            {
                goto label_6;
            }
            
            if(pose == 1)
            {
                goto label_7;
            }
            
            if(pose != 0)
            {
                    return;
            }
            
            val_13 = mem[(X9 + (this.ikConstraintIndex) << 3) + 32 + 16];
            val_13 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16;
            mem2[0] = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 52;
            goto label_30;
            label_6:
            if((this.frames[((-12884901888) + ((this.frames.Length) << 32)) >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_3 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  3);
            float val_15 = this.frames[val_3 - 2];
            float val_16 = this.frames[val_3];
            val_16 = (this.frames[val_3 - 3]) - val_16;
            val_16 = (time - val_16) / val_16;
            val_16 = 1f - val_16;
            float val_7 = this.GetCurvePercent(frameIndex:  -1, percent:  val_16);
            if(pose == 0)
            {
                goto label_18;
            }
            
            float val_18 = this.frames[val_3 + 1];
            val_18 = val_18 - val_15;
            val_7 = val_7 * val_18;
            val_7 = val_15 + val_7;
            val_7 = val_7 - ((X9 + (this.ikConstraintIndex) << 3) + 32 + 40);
            val_7 = val_7 * alpha;
            val_7 = ((X9 + (this.ikConstraintIndex) << 3) + 32 + 40) + val_7;
            mem2[0] = val_7;
            if(direction != 0)
            {
                    return;
            }
            
            goto label_35;
            label_13:
            int val_9 = this.frames.Length << 32;
            if(pose == 0)
            {
                goto label_23;
            }
            
            var val_19 = -8589934592;
            val_19 = val_9 + val_19;
            float val_21 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 40;
            float val_20 = this.frames[val_19 >> 30];
            val_20 = val_20 - val_21;
            val_20 = val_20 * alpha;
            val_21 = val_21 + val_20;
            mem2[0] = val_21;
            if(direction != 0)
            {
                    return;
            }
            
            goto label_25;
            label_7:
            val_13 = mem[(X9 + (this.ikConstraintIndex) << 3) + 32 + 16];
            val_13 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16;
            float val_23 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 40;
            float val_22 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 52;
            val_22 = val_22 - val_23;
            val_22 = val_22 * alpha;
            val_23 = val_23 + val_22;
            mem2[0] = val_23;
            goto label_30;
            label_23:
            val_13 = mem[(X9 + (this.ikConstraintIndex) << 3) + 32 + 16];
            val_13 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16;
            val_9 = val_9 + (-8589934592);
            float val_25 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 52;
            float val_24 = this.frames[val_9 >> 30];
            val_24 = val_24 - val_25;
            val_24 = val_24 * alpha;
            val_25 = val_25 + val_24;
            mem2[0] = val_25;
            if(direction == 1)
            {
                goto label_30;
            }
            
            label_25:
            goto label_32;
            label_18:
            val_13 = mem[(X9 + (this.ikConstraintIndex) << 3) + 32 + 16];
            val_13 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16;
            float val_26 = this.frames[val_3 + 1];
            val_26 = val_26 - val_15;
            val_7 = val_7 * val_26;
            val_7 = val_15 + val_7;
            val_7 = val_7 - ((X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 52);
            val_7 = val_7 * alpha;
            val_7 = ((X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 52) + val_7;
            mem2[0] = val_7;
            if(direction != 1)
            {
                goto label_35;
            }
            
            label_30:
            val_15 = mem[(X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 48];
            val_15 = (X9 + (this.ikConstraintIndex) << 3) + 32 + 16 + 48;
            goto label_36;
            label_35:
            label_32:
            float val_27 = this.frames[val_3 - 1];
            val_27 = (val_27 == Infinityf) ? (-(double)val_27) : ((double)val_27);
            val_15 = (int)val_27;
            label_36:
            mem2[0] = val_15;
        }
    
    }

}

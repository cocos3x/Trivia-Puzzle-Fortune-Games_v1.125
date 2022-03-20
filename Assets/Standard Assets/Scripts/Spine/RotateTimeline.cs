using UnityEngine;

namespace Spine
{
    public class RotateTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 2;
        internal const int PREV_TIME = -2;
        internal const int PREV_ROTATION = -1;
        internal const int ROTATION = 1;
        internal int boneIndex;
        internal float[] frames;
        
        // Properties
        public int BoneIndex { get; set; }
        public float[] Frames { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public int get_BoneIndex()
        {
            return (int)this.boneIndex;
        }
        public void set_BoneIndex(int value)
        {
            this.boneIndex = value;
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
            return (int)this.boneIndex;
        }
        public RotateTimeline(int frameCount)
        {
            int val_1 = frameCount << 1;
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float degrees)
        {
            int val_1 = frameIndex << 1;
            this.frames[val_1] = time;
            var val_2 = (long)val_1;
            val_2 = val_2 | 1;
            this.frames[val_2] = degrees;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            float val_12;
            float val_13;
            float val_14;
            int val_24 = this.frames.Length;
            var val_1 = X9 + ((this.boneIndex) << 3);
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
            
            mem2[0] = (X9 + (this.boneIndex) << 3) + 32 + 16 + 52;
            return;
            label_6:
            var val_13 = -8589934592;
            val_13 = val_13 + ((this.frames.Length) << 32);
            if((this.frames[val_13 >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_2 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  2);
            float val_15 = this.frames[val_2];
            float val_17 = this.frames[val_2 - 1];
            val_15 = (this.frames[val_2 - 2]) - val_15;
            val_15 = (time - val_15) / val_15;
            val_15 = 1f - val_15;
            float val_8 = this.GetCurvePercent(frameIndex:  (val_2 >> 1) - 1, percent:  val_15);
            float val_18 = this.frames[val_2 + 1];
            float val_20 = -360f;
            double val_22 = Infinity;
            val_18 = val_18 - val_17;
            double val_19 = (double)val_18 / val_20;
            val_19 = val_19 + 16384.5;
            val_19 = (val_19 == val_22) ? (-val_19) : (val_19);
            var val_34 = 16384;
            var val_11 = val_34 - (int)val_19;
            val_11 = val_11 * 360;
            val_18 = val_18 - (float)val_11;
            val_8 = val_8 * val_18;
            val_8 = val_17 + val_8;
            if(pose == 0)
            {
                goto label_18;
            }
            
            var val_23 = 16384;
            val_8 = val_8 + ((X9 + (this.boneIndex) << 3) + 32 + 16 + 52);
            val_8 = val_8 - ((X9 + (this.boneIndex) << 3) + 32 + 56);
            val_20 = val_8 / val_20;
            double val_21 = (double)val_20;
            val_21 = val_21 + 16384.5;
            val_22 = (val_21 == val_22) ? (-val_21) : (val_21);
            val_23 = val_23 - (int)val_22;
            val_23 = val_23 * 360;
            val_8 = val_8 - (float)val_23;
            val_8 = val_8 * alpha;
            val_12 = ((X9 + (this.boneIndex) << 3) + 32 + 56) + val_8;
            goto label_28;
            label_13:
            val_24 = val_24 << 32;
            val_13 = mem[(X9 + (this.boneIndex) << 3) + 32 + 16 + 52];
            val_13 = (X9 + (this.boneIndex) << 3) + 32 + 16 + 52;
            val_24 = val_24 + (-4294967296);
            float val_25 = this.frames[val_24 >> 30];
            if(pose == 0)
            {
                goto label_24;
            }
            
            val_13 = val_13 + val_25;
            float val_26 = -360f;
            val_13 = val_13 - ((X9 + (this.boneIndex) << 3) + 32 + 56);
            val_26 = val_13 / val_26;
            double val_27 = (double)val_26;
            val_27 = val_27 + 16384.5;
            val_27 = (val_27 == Infinity) ? (-val_27) : (val_27);
            int val_28 = (int)val_27;
            val_28 = 16384 - val_28;
            val_28 = val_28 * 360;
            val_13 = val_13 - (float)val_28;
            val_13 = val_13 * alpha;
            val_12 = ((X9 + (this.boneIndex) << 3) + 32 + 56) + val_13;
            goto label_28;
            label_7:
            float val_29 = (X9 + (this.boneIndex) << 3) + 32 + 16 + 52;
            float val_30 = -360f;
            val_29 = val_29 - ((X9 + (this.boneIndex) << 3) + 32 + 56);
            val_30 = val_29 / val_30;
            double val_31 = (double)val_30;
            val_31 = val_31 + 16384.5;
            val_31 = (val_31 == Infinity) ? (-val_31) : (val_31);
            int val_32 = (int)val_31;
            val_32 = 16384 - val_32;
            val_32 = val_32 * 360;
            val_29 = val_29 - (float)val_32;
            val_29 = val_29 * alpha;
            val_12 = ((X9 + (this.boneIndex) << 3) + 32 + 56) + val_29;
            goto label_28;
            label_18:
            val_20 = val_8 / val_20;
            double val_33 = (double)val_20;
            val_33 = val_33 + 16384.5;
            val_22 = (val_33 == val_22) ? (-val_33) : (val_33);
            val_34 = val_34 - (int)val_22;
            val_34 = val_34 * 360;
            val_14 = mem[(X9 + (this.boneIndex) << 3) + 32 + 16 + 52];
            val_14 = (X9 + (this.boneIndex) << 3) + 32 + 16 + 52;
            val_8 = val_8 - (float)val_34;
            val_13 = val_8 * alpha;
            goto label_31;
            label_24:
            val_14 = val_25 * alpha;
            label_31:
            val_12 = val_13 + val_14;
            label_28:
            mem2[0] = val_12;
        }
    
    }

}

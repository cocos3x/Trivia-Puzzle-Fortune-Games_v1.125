using UnityEngine;

namespace Spine
{
    public class TranslateTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 3;
        protected const int PREV_TIME = -3;
        protected const int PREV_X = -2;
        protected const int PREV_Y = -1;
        protected const int X = 1;
        protected const int Y = 2;
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
            return (int)this.boneIndex + 16777216;
        }
        public TranslateTimeline(int frameCount)
        {
            int val_1 = frameCount + (frameCount << 1);
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float x, float y)
        {
            int val_1 = frameIndex + (frameIndex << 1);
            this.frames[val_1] = time;
            this.frames[val_1 + 1] = x;
            val_1 = val_1 + 2;
            this.frames[val_1] = y;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_19;
            var val_20;
            float val_21;
            float val_22;
            float val_23;
            Spine.ExposedList<Spine.Bone> val_19 = skeleton.bones;
            val_19 = val_19 + ((this.boneIndex) << 3);
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
            
            mem2[0] = X23 + 16 + 44;
            mem2[0] = X23 + 16 + 48;
            return;
            label_6:
            if((this.frames[((-12884901888) + ((this.frames.Length) << 32)) >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_2 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  3);
            float val_21 = this.frames[val_2 - 2];
            float val_22 = this.frames[val_2];
            float val_24 = this.frames[val_2 - 1];
            this.frames[val_2] = this.frames[val_2] >> 32;
            val_22 = (this.frames[val_2 - 3]) - val_22;
            val_22 = (time - val_22) / val_22;
            val_22 = 1f - val_22;
            float val_9 = this.GetCurvePercent(frameIndex:  (this.frames[val_2][this.frames[val_2] >> 63]) - 1, percent:  val_22);
            int val_10 = val_2 + 1;
            int val_11 = val_2 + 2;
            float val_12 = null - val_21;
            val_12 = val_9 * val_12;
            val_9 = val_9 * (null - val_24);
            val_19 = val_21 + val_12;
            val_20 = val_24 + val_9;
            if(X23 != 0)
            {
                goto label_20;
            }
            
            label_13:
            int val_14 = this.frames.Length << 32;
            var val_25 = -4294967296;
            val_25 = val_14 + val_25;
            val_14 = val_14 + (-8589934592);
            val_14 = val_14 >> 30;
            val_25 = val_25 >> 30;
            label_20:
            if(pose == 0)
            {
                goto label_23;
            }
            
            float val_15 = null + (X23 + 16 + 44);
            val_15 = val_15 - (X23 + 48);
            val_15 = val_15 * alpha;
            val_15 = (X23 + 48) + val_15;
            mem2[0] = val_15;
            val_21 = mem[X23 + 52];
            val_21 = X23 + 52;
            val_22 = null + (X23 + 16 + 48);
            goto label_25;
            label_23:
            float val_16 = null * alpha;
            val_16 = val_16 + (X23 + 16 + 44);
            mem2[0] = val_16;
            val_23 = (null * alpha) + (X23 + 16 + 48);
            goto label_27;
            label_7:
            float val_26 = X23 + 16 + 44;
            val_21 = mem[X23 + 48 + 4];
            val_21 = X23 + 48 + 4;
            val_26 = val_26 - (X23 + 48);
            val_26 = val_26 * alpha;
            val_26 = (X23 + 48) + val_26;
            mem2[0] = val_26;
            val_22 = mem[X23 + 16 + 48];
            val_22 = X23 + 16 + 48;
            label_25:
            val_22 = val_22 - val_21;
            val_22 = val_22 * alpha;
            val_23 = val_21 + val_22;
            label_27:
            mem2[0] = val_23;
        }
    
    }

}

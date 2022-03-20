using UnityEngine;

namespace Spine
{
    public class PathConstraintPositionTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 2;
        protected const int PREV_TIME = -2;
        protected const int PREV_VALUE = -1;
        protected const int VALUE = 1;
        internal int pathConstraintIndex;
        internal float[] frames;
        
        // Properties
        public override int PropertyId { get; }
        public int PathConstraintIndex { get; set; }
        public float[] Frames { get; set; }
        
        // Methods
        public override int get_PropertyId()
        {
            return (int)this.pathConstraintIndex + 184549376;
        }
        public PathConstraintPositionTimeline(int frameCount)
        {
            int val_1 = frameCount << 1;
            this.frames = new float[0];
        }
        public int get_PathConstraintIndex()
        {
            return (int)this.pathConstraintIndex;
        }
        public void set_PathConstraintIndex(int value)
        {
            this.pathConstraintIndex = value;
        }
        public float[] get_Frames()
        {
            return (System.Single[])this.frames;
        }
        public void set_Frames(float[] value)
        {
            this.frames = value;
        }
        public void SetFrame(int frameIndex, float time, float value)
        {
            int val_1 = frameIndex << 1;
            this.frames[val_1] = time;
            var val_2 = (long)val_1;
            val_2 = val_2 | 1;
            this.frames[val_2] = value;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            float val_10;
            float val_11;
            float val_12;
            Spine.ExposedList<Spine.PathConstraint> val_11 = skeleton.pathConstraints;
            val_11 = val_11 + ((this.pathConstraintIndex) << 3);
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
            
            mem2[0] = X23 + 16 + 64;
            return;
            label_6:
            var val_12 = -8589934592;
            val_12 = val_12 + ((this.frames.Length) << 32);
            if((this.frames[val_12 >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_1 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  2);
            float val_14 = this.frames[val_1];
            float val_16 = this.frames[val_1 - 1];
            var val_4 = (val_1 < 0) ? (val_1 + 1) : (val_1);
            val_14 = (this.frames[val_1 - 2]) - val_14;
            val_4 = val_4 >> 1;
            val_14 = (time - val_14) / val_14;
            val_14 = 1f - val_14;
            float val_7 = this.GetCurvePercent(frameIndex:  val_4 - 1, percent:  val_14);
            float val_17 = this.frames[val_1 + 1];
            val_17 = val_17 - val_16;
            val_7 = val_7 * val_17;
            val_10 = val_16 + val_7;
            if(X23 != 0)
            {
                goto label_18;
            }
            
            label_13:
            int val_9 = this.frames.Length << 32;
            val_9 = val_9 + (-4294967296);
            val_10 = this.frames[val_9 >> 30];
            label_18:
            if(pose != 0)
            {
                    val_11 = mem[X23 + 40];
                val_11 = X23 + 40;
            }
            else
            {
                    val_11 = mem[X23 + 16 + 64];
                val_11 = X23 + 16 + 64;
            }
            
            val_10 = val_10 - val_11;
            val_10 = val_10 * alpha;
            val_12 = val_11 + val_10;
            goto label_24;
            label_7:
            float val_18 = X23 + 16 + 64;
            val_18 = val_18 - (X23 + 40);
            val_18 = val_18 * alpha;
            val_12 = (X23 + 40) + val_18;
            label_24:
            mem2[0] = val_12;
        }
    
    }

}

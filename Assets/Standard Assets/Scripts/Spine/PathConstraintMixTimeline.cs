using UnityEngine;

namespace Spine
{
    public class PathConstraintMixTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 3;
        private const int PREV_TIME = -3;
        private const int PREV_ROTATE = -2;
        private const int PREV_TRANSLATE = -1;
        private const int ROTATE = 1;
        private const int TRANSLATE = 2;
        internal int pathConstraintIndex;
        internal float[] frames;
        
        // Properties
        public int PathConstraintIndex { get; set; }
        public float[] Frames { get; set; }
        public override int PropertyId { get; }
        
        // Methods
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
        public override int get_PropertyId()
        {
            return (int)this.pathConstraintIndex + 218103808;
        }
        public PathConstraintMixTimeline(int frameCount)
        {
            int val_1 = frameCount + (frameCount << 1);
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix)
        {
            int val_1 = frameIndex + (frameIndex << 1);
            this.frames[val_1] = time;
            this.frames[val_1 + 1] = rotateMix;
            val_1 = val_1 + 2;
            this.frames[val_1] = translateMix;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_19;
            var val_20;
            float val_21;
            Spine.ExposedList<Spine.PathConstraint> val_20 = skeleton.pathConstraints;
            val_20 = val_20 + ((this.pathConstraintIndex) << 3);
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
            
            mem2[0] = X23 + 16 + 72;
            mem2[0] = X23 + 16 + 76;
            return;
            label_6:
            if((this.frames[((-12884901888) + ((this.frames.Length) << 32)) >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_2 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  3);
            float val_22 = this.frames[val_2 - 2];
            float val_23 = this.frames[val_2];
            float val_25 = this.frames[val_2 - 1];
            this.frames[val_2] = this.frames[val_2] >> 32;
            val_23 = (this.frames[val_2 - 3]) - val_23;
            val_23 = (time - val_23) / val_23;
            val_23 = 1f - val_23;
            float val_9 = this.GetCurvePercent(frameIndex:  (this.frames[val_2][this.frames[val_2] >> 63]) - 1, percent:  val_23);
            int val_10 = val_2 + 1;
            int val_11 = val_2 + 2;
            float val_12 = null - val_22;
            val_12 = val_9 * val_12;
            val_9 = val_9 * (null - val_25);
            val_19 = val_22 + val_12;
            val_20 = val_25 + val_9;
            if(X23 != 0)
            {
                goto label_20;
            }
            
            label_13:
            int val_14 = this.frames.Length << 32;
            var val_26 = -4294967296;
            val_26 = val_14 + val_26;
            val_14 = val_14 + (-8589934592);
            val_14 = val_14 >> 30;
            val_26 = val_26 >> 30;
            label_20:
            if(pose == 0)
            {
                goto label_23;
            }
            
            float val_15 = null - (X23 + 48);
            float val_16 = null - (X23 + 48 + 4);
            val_15 = val_15 * alpha;
            val_16 = val_16 * alpha;
            val_15 = (X23 + 48) + val_15;
            val_21 = (X23 + 48 + 4) + val_16;
            mem2[0] = val_15;
            goto label_26;
            label_23:
            float val_17 = null - (X23 + 16 + 72);
            val_17 = val_17 * alpha;
            val_17 = (X23 + 16 + 72) + val_17;
            mem2[0] = val_17;
            float val_18 = null - (X23 + 16 + 76);
            val_18 = val_18 * alpha;
            val_21 = (X23 + 16 + 76) + val_18;
            goto label_26;
            label_7:
            float val_27 = X23 + 16 + 72;
            val_27 = val_27 - (X23 + 48);
            val_27 = val_27 * alpha;
            val_27 = (X23 + 48) + val_27;
            mem2[0] = val_27;
            float val_28 = X23 + 16 + 76;
            val_28 = val_28 - (X23 + 48 + 4);
            val_28 = val_28 * alpha;
            val_21 = (X23 + 48 + 4) + val_28;
            label_26:
            mem2[0] = val_21;
        }
    
    }

}

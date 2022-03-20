using UnityEngine;

namespace Spine
{
    public class TransformConstraintTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 5;
        private const int PREV_TIME = -5;
        private const int PREV_ROTATE = -4;
        private const int PREV_TRANSLATE = -3;
        private const int PREV_SCALE = -2;
        private const int PREV_SHEAR = -1;
        private const int ROTATE = 1;
        private const int TRANSLATE = 2;
        private const int SCALE = 3;
        private const int SHEAR = 4;
        internal int transformConstraintIndex;
        internal float[] frames;
        
        // Properties
        public int TransformConstraintIndex { get; set; }
        public float[] Frames { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public int get_TransformConstraintIndex()
        {
            return (int)this.transformConstraintIndex;
        }
        public void set_TransformConstraintIndex(int value)
        {
            this.transformConstraintIndex = value;
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
            return (int)this.transformConstraintIndex + 167772160;
        }
        public TransformConstraintTimeline(int frameCount)
        {
            int val_1 = frameCount + (frameCount << 2);
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix, float scaleMix, float shearMix)
        {
            int val_1 = frameIndex + (frameIndex << 2);
            this.frames[val_1] = time;
            this.frames[val_1 + 1] = rotateMix;
            this.frames[val_1 + 2] = translateMix;
            this.frames[val_1 + 3] = scaleMix;
            val_1 = val_1 + 4;
            this.frames[val_1] = shearMix;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_33;
            var val_34;
            var val_35;
            var val_36;
            float val_37;
            Spine.ExposedList<Spine.TransformConstraint> val_32 = skeleton.transformConstraints;
            val_32 = val_32 + ((this.transformConstraintIndex) << 3);
            if(this.frames[0] <= time)
            {
                goto label_6;
            }
            
            if(pose == 1)
            {
                goto label_8;
            }
            
            if(pose != 0)
            {
                    return;
            }
            
            mem2[0] = X23 + 16 + 48;
            mem2[0] = X23 + 16 + 52;
            mem2[0] = X23 + 16 + 56;
            mem2[0] = X23 + 16 + 60;
            return;
            label_6:
            if((this.frames[((-21474836480) + ((this.frames.Length) << 32)) >> 30]) <= time)
            {
                goto label_13;
            }
            
            int val_2 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  5);
            float val_34 = this.frames[val_2 - 4];
            float val_35 = this.frames[val_2];
            float val_37 = this.frames[val_2 - 3];
            float val_38 = this.frames[val_2 - 2];
            float val_39 = this.frames[val_2 - 1];
            this.frames[val_2] = this.frames[val_2] >> 63;
            val_35 = (this.frames[val_2 - 5]) - val_35;
            val_35 = (time - val_35) / val_35;
            val_35 = 1f - val_35;
            float val_11 = this.GetCurvePercent(frameIndex:  (this.frames[val_2][(this.frames[val_2] >> 32) >> 1]) - 1, percent:  val_35);
            int val_14 = val_2 + 3;
            int val_15 = val_2 + 4;
            float val_40 = this.frames[val_2 + 1];
            float val_41 = this.frames[val_2 + 2];
            val_40 = val_40 - val_34;
            val_41 = val_41 - val_37;
            val_40 = val_11 * val_40;
            val_41 = val_11 * val_41;
            val_11 = val_11 * (null - val_39);
            val_33 = val_34 + val_40;
            val_34 = val_37 + val_41;
            val_35 = val_38 + (val_11 * (null - val_38));
            val_36 = val_39 + val_11;
            if(X23 != 0)
            {
                goto label_24;
            }
            
            label_13:
            int val_19 = this.frames.Length << 32;
            var val_42 = -17179869184;
            var val_43 = -4294967296;
            val_42 = val_19 + val_42;
            val_43 = val_19 + val_43;
            val_19 = val_19 + (-8589934592);
            val_42 = val_42 >> 30;
            int val_21 = (val_19 + (-12884901888)) >> 30;
            val_19 = val_19 >> 30;
            int val_22 = val_43 >> 30;
            label_24:
            if(pose == 0)
            {
                goto label_27;
            }
            
            float val_23 = null - (X23 + 40);
            float val_24 = null - (X23 + 40 + 4);
            float val_25 = null - (X23 + 48);
            float val_26 = null - (X23 + 48 + 4);
            val_23 = val_23 * alpha;
            val_24 = val_24 * alpha;
            val_25 = val_25 * alpha;
            val_26 = val_26 * alpha;
            val_23 = (X23 + 40) + val_23;
            val_24 = (X23 + 40 + 4) + val_24;
            val_25 = (X23 + 48) + val_25;
            val_37 = (X23 + 48 + 4) + val_26;
            mem2[0] = val_23;
            mem2[0] = val_24;
            mem2[0] = val_25;
            goto label_30;
            label_27:
            float val_27 = null - (X23 + 16 + 48);
            val_27 = val_27 * alpha;
            val_27 = (X23 + 16 + 48) + val_27;
            mem2[0] = val_27;
            float val_28 = null - (X23 + 16 + 52);
            val_28 = val_28 * alpha;
            val_28 = (X23 + 16 + 52) + val_28;
            mem2[0] = val_28;
            float val_29 = null - (X23 + 16 + 56);
            val_29 = val_29 * alpha;
            val_29 = (X23 + 16 + 56) + val_29;
            mem2[0] = val_29;
            float val_30 = null - (X23 + 16 + 60);
            val_30 = val_30 * alpha;
            val_37 = (X23 + 16 + 60) + val_30;
            goto label_30;
            label_8:
            float val_44 = X23 + 16 + 48;
            val_44 = val_44 - (X23 + 40);
            val_44 = val_44 * alpha;
            val_44 = (X23 + 40) + val_44;
            mem2[0] = val_44;
            float val_45 = X23 + 16 + 52;
            val_45 = val_45 - (X23 + 40 + 4);
            val_45 = val_45 * alpha;
            val_45 = (X23 + 40 + 4) + val_45;
            mem2[0] = val_45;
            float val_46 = X23 + 16 + 56;
            val_46 = val_46 - (X23 + 48);
            val_46 = val_46 * alpha;
            val_46 = (X23 + 48) + val_46;
            mem2[0] = val_46;
            float val_47 = X23 + 16 + 60;
            val_47 = val_47 - (X23 + 48 + 4);
            val_47 = val_47 * alpha;
            val_37 = (X23 + 48 + 4) + val_47;
            label_30:
            mem2[0] = val_37;
        }
    
    }

}

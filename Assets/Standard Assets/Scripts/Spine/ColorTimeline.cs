using UnityEngine;

namespace Spine
{
    public class ColorTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 5;
        protected const int PREV_TIME = -5;
        protected const int PREV_R = -4;
        protected const int PREV_G = -3;
        protected const int PREV_B = -2;
        protected const int PREV_A = -1;
        protected const int R = 1;
        protected const int G = 2;
        protected const int B = 3;
        protected const int A = 4;
        internal int slotIndex;
        internal float[] frames;
        
        // Properties
        public int SlotIndex { get; set; }
        public float[] Frames { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public int get_SlotIndex()
        {
            return (int)this.slotIndex;
        }
        public void set_SlotIndex(int value)
        {
            this.slotIndex = value;
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
            return (int)this.slotIndex + 83886080;
        }
        public ColorTimeline(int frameCount)
        {
            int val_1 = frameCount + (frameCount << 2);
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float r, float g, float b, float a)
        {
            int val_1 = frameIndex + (frameIndex << 2);
            this.frames[val_1] = time;
            this.frames[val_1 + 1] = r;
            this.frames[val_1 + 2] = g;
            this.frames[val_1 + 3] = b;
            val_1 = val_1 + 4;
            this.frames[val_1] = a;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_41;
            var val_42;
            var val_43;
            var val_44;
            var val_45;
            var val_46;
            var val_47;
            var val_48;
            float val_49;
            float val_50;
            float val_51;
            float val_52;
            Spine.ExposedList<Spine.Slot> val_28 = skeleton.slots;
            val_28 = val_28 + ((this.slotIndex) << 3);
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
            
            mem2[0] = X23 + 16 + 40;
            mem2[0] = X23 + 16 + 44;
            mem2[0] = X23 + 16 + 48;
            mem2[0] = X23 + 16 + 52;
            return;
            label_6:
            if((this.frames[((-21474836480) + ((this.frames.Length) << 32)) >> 30]) > time)
            {
                    int val_2 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  5);
                float val_30 = this.frames[val_2 - 4];
                float val_31 = this.frames[val_2];
                float val_33 = this.frames[val_2 - 3];
                float val_34 = this.frames[val_2 - 2];
                float val_35 = this.frames[val_2 - 1];
                this.frames[val_2] = this.frames[val_2] >> 63;
                val_31 = (this.frames[val_2 - 5]) - val_31;
                val_31 = (time - val_31) / val_31;
                val_31 = 1f - val_31;
                float val_11 = this.GetCurvePercent(frameIndex:  (this.frames[val_2][(this.frames[val_2] >> 32) >> 1]) - 1, percent:  val_31);
                int val_14 = val_2 + 3;
                int val_15 = val_2 + 4;
                float val_36 = this.frames[val_2 + 1];
                float val_37 = this.frames[val_2 + 2];
                val_36 = val_36 - val_30;
                val_37 = val_37 - val_33;
                val_36 = val_11 * val_36;
                val_37 = val_11 * val_37;
                val_11 = val_11 * (null - val_35);
                val_41 = val_30 + val_36;
                val_42 = val_33 + val_37;
                val_43 = val_34 + (val_11 * (null - val_34));
                val_44 = val_35 + val_11;
            }
            else
            {
                    int val_19 = this.frames.Length << 32;
                var val_38 = -17179869184;
                var val_39 = -4294967296;
                val_38 = val_19 + val_38;
                val_39 = val_19 + val_39;
                val_19 = val_19 + (-8589934592);
                val_38 = val_38 >> 30;
                int val_21 = (val_19 + (-12884901888)) >> 30;
                val_19 = val_19 >> 30;
                int val_22 = val_39 >> 30;
            }
            
            if(alpha == 1f)
            {
                    mem2[0] = null;
                mem2[0] = null;
                mem2[0] = null;
                mem2[0] = null;
                return;
            }
            
            if(pose == 0)
            {
                goto label_29;
            }
            
            val_45 = X23 + 32;
            val_46 = X23 + 36;
            val_47 = X23 + 40;
            val_48 = X23 + 44;
            val_49 = val_48;
            val_50 = val_47;
            val_51 = val_46;
            val_52 = val_45;
            goto label_30;
            label_8:
            float val_40 = X23 + 16 + 40;
            val_40 = (X23 + 32) - val_40;
            val_40 = val_40 * alpha;
            val_40 = (X23 + 32) + val_40;
            mem2[0] = val_40;
            float val_41 = X23 + 16 + 44;
            val_41 = (X23 + 32 + 4) - val_41;
            val_41 = val_41 * alpha;
            val_41 = (X23 + 32 + 4) + val_41;
            mem2[0] = val_41;
            float val_42 = X23 + 16 + 48;
            val_42 = (X23 + 40) - val_42;
            val_42 = val_42 * alpha;
            val_42 = (X23 + 40) + val_42;
            mem2[0] = val_42;
            float val_43 = X23 + 16 + 52;
            val_43 = (X23 + 40 + 4) - val_43;
            val_43 = val_43 * alpha;
            val_43 = (X23 + 40 + 4) + val_43;
            mem2[0] = val_43;
            return;
            label_29:
            val_52 = (X23 + 16) + 40;
            val_51 = (X23 + 16) + 44;
            val_50 = (X23 + 16) + 48;
            val_49 = (X23 + 16) + 52;
            val_45 = X23 + 32;
            val_46 = X23 + 36;
            val_47 = X23 + 40;
            val_48 = X23 + 44;
            label_30:
            float val_23 = null - val_52;
            float val_24 = null - val_51;
            float val_25 = null - val_50;
            float val_26 = null - val_49;
            val_23 = val_23 * alpha;
            val_24 = val_24 * alpha;
            val_25 = val_25 * alpha;
            val_26 = val_26 * alpha;
            val_23 = val_52 + val_23;
            val_24 = val_51 + val_24;
            val_25 = val_50 + val_25;
            val_26 = val_49 + val_26;
            mem2[0] = val_23;
            mem2[0] = val_24;
            mem2[0] = val_25;
            mem2[0] = val_26;
        }
    
    }

}

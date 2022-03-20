using UnityEngine;

namespace Spine
{
    public class TwoColorTimeline : CurveTimeline
    {
        // Fields
        public const int ENTRIES = 8;
        protected const int PREV_TIME = -8;
        protected const int PREV_R = -7;
        protected const int PREV_G = -6;
        protected const int PREV_B = -5;
        protected const int PREV_A = -4;
        protected const int PREV_R2 = -3;
        protected const int PREV_G2 = -2;
        protected const int PREV_B2 = -1;
        protected const int R = 1;
        protected const int G = 2;
        protected const int B = 3;
        protected const int A = 4;
        protected const int R2 = 5;
        protected const int G2 = 6;
        protected const int B2 = 7;
        internal float[] frames;
        internal int slotIndex;
        
        // Properties
        public float[] Frames { get; }
        public int SlotIndex { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public float[] get_Frames()
        {
            return (System.Single[])this.frames;
        }
        public int get_SlotIndex()
        {
            return (int)this.slotIndex;
        }
        public void set_SlotIndex(int value)
        {
            if((value & 2147483648) != 0)
            {
                    throw new System.ArgumentOutOfRangeException(paramName:  "index must be >= 0.");
            }
            
            this.slotIndex = value;
        }
        public override int get_PropertyId()
        {
            return (int)this.slotIndex + 234881024;
        }
        public TwoColorTimeline(int frameCount)
        {
            int val_1 = frameCount << 3;
            this.frames = new float[0];
        }
        public void SetFrame(int frameIndex, float time, float r, float g, float b, float a, float r2, float g2, float b2)
        {
            int val_1 = frameIndex << 3;
            this.frames[val_1] = time;
            var val_8 = (long)val_1;
            this.frames[val_8 | 1] = r;
            this.frames[val_8 | 2] = g;
            this.frames[val_8 | 3] = b;
            this.frames[val_8 | 4] = a;
            this.frames[val_8 | 5] = r2;
            this.frames[val_8 | 6] = g2;
            val_8 = val_8 | 7;
            this.frames[val_8] = b2;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_71;
            var val_72;
            var val_73;
            var val_74;
            var val_75;
            var val_76;
            float val_77;
            var val_78;
            var val_79;
            var val_80;
            var val_81;
            var val_82;
            var val_83;
            var val_84;
            float val_85;
            float val_86;
            float val_87;
            float val_88;
            float val_89;
            float val_90;
            float val_91;
            Spine.ExposedList<Spine.Slot> val_45 = skeleton.slots;
            val_45 = val_45 + ((this.slotIndex) << 3);
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
            mem2[0] = X23 + 16 + 56;
            mem2[0] = X23 + 16 + 60;
            mem2[0] = X23 + 16 + 64;
            return;
            label_6:
            var val_46 = -34359738368;
            val_46 = val_46 + ((this.frames.Length) << 32);
            if((this.frames[val_46 >> 30]) > time)
            {
                    int val_1 = Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  8);
                float val_48 = this.frames[val_1 - 7];
                float val_49 = this.frames[val_1];
                float val_51 = this.frames[val_1 - 6];
                float val_52 = this.frames[val_1 - 5];
                float val_53 = this.frames[val_1 - 4];
                float val_54 = this.frames[val_1 - 3];
                float val_55 = this.frames[val_1 - 2];
                float val_56 = this.frames[val_1 - 1];
                var val_11 = (val_1 < 0) ? (val_1 + 7) : (val_1);
                val_49 = (this.frames[val_1 - 8]) - val_49;
                val_11 = val_11 >> 3;
                val_49 = (time - val_49) / val_49;
                val_49 = 1f - val_49;
                float val_14 = this.GetCurvePercent(frameIndex:  val_11 - 1, percent:  val_49);
                int val_20 = val_1 + 6;
                int val_21 = val_1 + 7;
                float val_57 = this.frames[val_1 + 1];
                float val_58 = this.frames[val_1 + 2];
                float val_59 = this.frames[val_1 + 3];
                float val_60 = this.frames[val_1 + 4];
                float val_61 = this.frames[val_1 + 5];
                val_58 = val_58 - val_51;
                val_59 = val_59 - val_52;
                val_60 = val_60 - val_53;
                val_57 = val_57 - val_48;
                val_61 = val_61 - val_54;
                val_57 = val_14 * val_57;
                val_58 = val_14 * val_58;
                val_59 = val_14 * val_59;
                val_14 = val_14 * (null - val_56);
                val_71 = val_48 + val_57;
                val_72 = val_51 + val_58;
                val_73 = val_52 + val_59;
                val_74 = val_53 + (val_14 * val_60);
                val_75 = val_54 + (val_14 * val_61);
                val_76 = val_55 + (val_14 * (null - val_55));
                val_77 = val_56 + val_14;
            }
            else
            {
                    int val_27 = this.frames.Length << 32;
                var val_62 = -17179869184;
                var val_63 = -4294967296;
                int val_28 = val_27 + (-30064771072);
                val_62 = val_27 + val_62;
                val_63 = val_27 + val_63;
                val_27 = val_27 + (-8589934592);
                val_28 = val_28 >> 30;
                int val_32 = (val_27 + (-25769803776)) >> 30;
                int val_33 = (val_27 + (-21474836480)) >> 30;
                int val_34 = val_62 >> 30;
                int val_35 = (val_27 + (-12884901888)) >> 30;
                val_27 = val_27 >> 30;
                int val_36 = val_63 >> 30;
            }
            
            if(alpha != 1f)
            {
                goto label_31;
            }
            
            mem2[0] = null;
            mem2[0] = null;
            mem2[0] = null;
            mem2[0] = null;
            mem2[0] = null;
            mem2[0] = null;
            goto label_33;
            label_31:
            if(pose == 0)
            {
                goto label_35;
            }
            
            val_78 = X23 + 32;
            val_79 = X23 + 36;
            val_80 = X23 + 40;
            val_81 = X23 + 44;
            val_82 = X23 + 48;
            val_83 = X23 + 52;
            val_84 = X23 + 56;
            val_85 = val_84;
            val_86 = val_83;
            val_87 = val_82;
            val_88 = val_81;
            val_89 = val_80;
            val_90 = val_79;
            val_91 = val_78;
            goto label_36;
            label_8:
            float val_64 = X23 + 16 + 40;
            val_64 = (X23 + 32) - val_64;
            val_64 = val_64 * alpha;
            val_64 = (X23 + 32) + val_64;
            mem2[0] = val_64;
            float val_65 = X23 + 16 + 44;
            val_65 = (X23 + 32 + 4) - val_65;
            val_65 = val_65 * alpha;
            val_65 = (X23 + 32 + 4) + val_65;
            mem2[0] = val_65;
            float val_66 = X23 + 16 + 48;
            val_66 = (X23 + 40) - val_66;
            val_66 = val_66 * alpha;
            val_66 = (X23 + 40) + val_66;
            mem2[0] = val_66;
            float val_67 = X23 + 16 + 52;
            val_67 = (X23 + 40 + 4) - val_67;
            val_67 = val_67 * alpha;
            val_67 = (X23 + 40 + 4) + val_67;
            mem2[0] = val_67;
            float val_68 = X23 + 16 + 56;
            val_68 = (X23 + 48) - val_68;
            val_68 = val_68 * alpha;
            val_68 = (X23 + 48) + val_68;
            mem2[0] = val_68;
            float val_69 = X23 + 16 + 60;
            val_69 = (X23 + 48 + 4) - val_69;
            val_69 = val_69 * alpha;
            val_69 = (X23 + 48 + 4) + val_69;
            mem2[0] = val_69;
            float val_70 = X23 + 16 + 64;
            val_70 = (X23 + 56) - val_70;
            val_70 = val_70 * alpha;
            val_77 = (X23 + 56) + val_70;
            label_33:
            mem2[0] = val_77;
            return;
            label_35:
            val_91 = (X23 + 16) + 40;
            val_90 = (X23 + 16) + 44;
            val_89 = (X23 + 16) + 48;
            val_88 = (X23 + 16) + 52;
            val_87 = (X23 + 16) + 56;
            val_86 = (X23 + 16) + 60;
            val_85 = (X23 + 16) + 64;
            val_78 = X23 + 32;
            val_79 = X23 + 36;
            val_80 = X23 + 40;
            val_81 = X23 + 44;
            val_82 = X23 + 48;
            val_83 = X23 + 52;
            val_84 = X23 + 56;
            label_36:
            float val_37 = null - val_91;
            float val_38 = null - val_90;
            float val_39 = null - val_89;
            float val_40 = null - val_88;
            float val_41 = null - val_87;
            float val_42 = null - val_86;
            float val_43 = null - val_85;
            val_37 = val_37 * alpha;
            val_38 = val_38 * alpha;
            val_39 = val_39 * alpha;
            val_40 = val_40 * alpha;
            val_41 = val_41 * alpha;
            val_42 = val_42 * alpha;
            val_43 = val_43 * alpha;
            val_37 = val_91 + val_37;
            val_38 = val_90 + val_38;
            val_39 = val_89 + val_39;
            val_40 = val_88 + val_40;
            val_41 = val_87 + val_41;
            val_42 = val_86 + val_42;
            val_43 = val_85 + val_43;
            mem2[0] = val_37;
            mem2[0] = val_38;
            mem2[0] = val_39;
            mem2[0] = val_40;
            mem2[0] = val_41;
            mem2[0] = val_42;
            mem2[0] = val_43;
        }
    
    }

}

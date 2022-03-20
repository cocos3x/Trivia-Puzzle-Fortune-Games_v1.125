using UnityEngine;

namespace Spine
{
    public class ScaleTimeline : TranslateTimeline
    {
        // Properties
        public override int PropertyId { get; }
        
        // Methods
        public override int get_PropertyId()
        {
            return (int)W8 + 33554432;
        }
        public ScaleTimeline(int frameCount)
        {
        
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            var val_23;
            var val_24;
            float val_25;
            float val_26;
            float val_27;
            val_24 = direction;
            Spine.ExposedList<Spine.Bone> val_21 = skeleton.bones;
            var val_1 = X9 + ((X10) << 3);
            if(skeleton.slots <= time)
            {
                goto label_7;
            }
            
            if(pose == 1)
            {
                goto label_8;
            }
            
            if(pose != 0)
            {
                    return;
            }
            
            mem2[0] = (X9 + (X10) << 3) + 32 + 16 + 56;
            mem2[0] = (X9 + (X10) << 3) + 32 + 16 + 60;
            return;
            label_7:
            var val_2 = (-12884901888) + ((skeleton.bones) << 32);
            val_2 = skeleton + (val_2 >> 30);
            if(((skeleton + ((ulong)(-12884901888 + (skeleton.bones) << 32)) >> 30).slots) > time)
            {
                    int val_3 = Spine.Animation.BinarySearch(values:  skeleton, target:  time, step:  3);
                int val_4 = val_3 - 2;
                int val_5 = val_3 - 1;
                val_23 = val_3;
                val_4 = skeleton + (val_4 << 2);
                val_5 = skeleton + (val_5 << 2);
                Spine.Skeleton val_7 = skeleton + (val_23 << 2);
                Spine.Skeleton val_8 = skeleton + ((val_23 - 3) << 2);
                Spine.ExposedList<Spine.Slot> val_19 = (skeleton + (val_3) << 2).slots;
                val_7 = val_7 >> 32;
                val_25 = time - val_19;
                val_19 = ((skeleton + ((val_3 - 3)) << 2).slots) - val_19;
                val_7 = val_7 + (val_7 >> 63);
                val_19 = val_25 / val_19;
                val_19 = 1f - val_19;
                float val_11 = this.GetCurvePercent(frameIndex:  val_7 - 1, percent:  val_19);
                int val_12 = val_23 + 1;
                val_12 = skeleton + (val_12 << 2);
                Spine.ExposedList<Spine.Slot> val_20 = (skeleton + ((val_3 + 1)) << 2).slots;
                Spine.Skeleton val_14 = skeleton + ((val_23 + 2) << 2);
                val_20 = val_20 - ((skeleton + ((val_3 - 2)) << 2).slots);
                val_11 = ((skeleton + ((val_3 - 2)) << 2).slots) + val_11;
                val_26 = val_11 * ((X9 + (X10) << 3) + 32 + 16 + 56);
            }
            else
            {
                    val_21 = val_21 << 32;
                var val_22 = -8589934592;
                val_22 = val_21 + val_22;
                val_22 = skeleton + (val_22 >> 30);
                val_21 = val_21 + (-4294967296);
                val_21 = skeleton + (val_21 >> 30);
                val_26 = ((skeleton + ((ulong)((skeleton.bones << 32) + -8589934592)) >> 30).slots) * ((X9 + (X10) << 3) + 32 + 16 + 56);
            }
            
            val_27 = 1f;
            if(alpha == val_27)
            {
                    mem2[0] = val_26;
                return;
            }
            
            if(val_24 != 1)
            {
                goto label_29;
            }
            
            val_24 = System.Math.Sign(value:  (X9 + (X10) << 3) + 32 + 60);
            int val_16 = System.Math.Sign(value:  (X9 + (X10) << 3) + 32 + 60);
            val_27 = System.Math.Abs(val_26) * (double)val_24;
            goto label_32;
            label_8:
            float val_24 = (X9 + (X10) << 3) + 32 + 16 + 56;
            val_24 = val_24 - ((X9 + (X10) << 3) + 32 + 60);
            val_24 = val_24 * alpha;
            val_24 = ((X9 + (X10) << 3) + 32 + 60) + val_24;
            mem2[0] = val_24;
            float val_25 = (X9 + (X10) << 3) + 32 + 16 + 60;
            val_25 = val_25 - ((X9 + (X10) << 3) + 32 + 60 + 4);
            val_25 = val_25 * alpha;
            val_25 = ((X9 + (X10) << 3) + 32 + 60 + 4) + val_25;
            mem2[0] = val_25;
            return;
            label_29:
            val_24 = System.Math.Sign(value:  val_26);
            int val_18 = System.Math.Sign(value:  val_26);
            double val_27 = (double)val_24;
            val_25 = (System.Math.Abs((X9 + (X10) << 3) + 32 + 60)) * val_27;
            label_32:
            val_27 = val_26 - val_25;
            val_27 = val_25 + val_27;
            mem2[0] = val_27;
        }
    
    }

}

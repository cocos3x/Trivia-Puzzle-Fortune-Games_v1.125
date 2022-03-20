using UnityEngine;

namespace Spine
{
    public class ShearTimeline : TranslateTimeline
    {
        // Properties
        public override int PropertyId { get; }
        
        // Methods
        public override int get_PropertyId()
        {
            return (int)W8 + 50331648;
        }
        public ShearTimeline(int frameCount)
        {
        
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            float val_17;
            float val_18;
            float val_19;
            float val_20;
            float val_21;
            Spine.ExposedList<Spine.Bone> val_17 = skeleton.bones;
            val_17 = val_17 + ((X10) << 3);
            if((X20 + 32) <= time)
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
            mem2[0] = X23 + 16 + 68;
            return;
            label_6:
            var val_1 = (-12884901888) + ((X20 + 24) << 32);
            val_1 = X20 + (val_1 >> 30);
            if(((X20 + ((ulong)(-12884901888 + (X20 + 24) << 32)) >> 30) + 32) <= time)
            {
                goto label_13;
            }
            
            int val_2 = Spine.Animation.BinarySearch(values:  X20, target:  time, step:  3);
            int val_3 = val_2 - 2;
            int val_4 = val_2 - 1;
            val_3 = X20 + (val_3 << 2);
            var val_6 = X20 + (val_2 << 2);
            var val_7 = X20 + ((val_2 - 3) << 2);
            val_4 = X20 + (val_4 << 2);
            float val_18 = (X20 + (val_2) << 2) + 32;
            val_6 = val_6 >> 32;
            val_18 = ((X20 + ((val_2 - 3)) << 2) + 32) - val_18;
            val_6 = val_6 + (val_6 >> 63);
            val_18 = (time - val_18) / val_18;
            val_18 = 1f - val_18;
            float val_11 = this.GetCurvePercent(frameIndex:  val_6 - 1, percent:  val_18);
            int val_12 = val_2 + 1;
            int val_13 = val_2 + 2;
            var val_14 = X20 + 32;
            float val_19 = (X20 + 32) + ((val_2 + 1)) << 2;
            float val_20 = (X20 + 32) + ((val_2 + 2)) << 2;
            val_19 = val_19 - ((X20 + ((val_2 - 2)) << 2) + 32);
            val_20 = val_20 - ((X20 + ((val_2 - 1)) << 2) + 32);
            val_19 = val_11 * val_19;
            val_11 = val_11 * val_20;
            val_17 = ((X20 + ((val_2 - 2)) << 2) + 32) + val_19;
            val_18 = ((X20 + ((val_2 - 1)) << 2) + 32) + val_11;
            if(X23 != 0)
            {
                goto label_20;
            }
            
            label_13:
            var val_15 = (X20 + 24) << 32;
            var val_21 = -4294967296;
            val_21 = val_15 + val_21;
            val_15 = val_15 + (-8589934592);
            var val_16 = X20 + 32;
            val_15 = val_15 >> 30;
            val_21 = val_21 >> 30;
            val_17 = mem[(X20 + 32) + (((X20 + 24 << 32) + -8589934592) >> 30)];
            val_17 = (X20 + 32) + (((X20 + 24 << 32) + -8589934592) >> 30);
            val_18 = mem[(X20 + 32) + (((X20 + 24 << 32) + -4294967296) >> 30)];
            val_18 = (X20 + 32) + (((X20 + 24 << 32) + -4294967296) >> 30);
            label_20:
            if(pose == 0)
            {
                goto label_23;
            }
            
            val_17 = val_17 + (X23 + 16 + 64);
            val_17 = val_17 - (X23 + 68);
            val_17 = val_17 * alpha;
            val_17 = (X23 + 68) + val_17;
            mem2[0] = val_17;
            val_19 = mem[X23 + 72];
            val_19 = X23 + 72;
            val_20 = val_18 + (X23 + 16 + 68);
            goto label_25;
            label_23:
            val_17 = val_17 * alpha;
            val_18 = val_18 * alpha;
            val_17 = val_17 + (X23 + 16 + 64);
            mem2[0] = val_17;
            val_21 = val_18 + (X23 + 16 + 68);
            goto label_27;
            label_7:
            float val_22 = X23 + 16 + 64;
            val_19 = mem[X23 + 68 + 4];
            val_19 = X23 + 68 + 4;
            val_22 = val_22 - (X23 + 68);
            val_22 = val_22 * alpha;
            val_22 = (X23 + 68) + val_22;
            mem2[0] = val_22;
            val_20 = mem[X23 + 16 + 68];
            val_20 = X23 + 16 + 68;
            label_25:
            val_20 = val_20 - val_19;
            val_20 = val_20 * alpha;
            val_21 = val_19 + val_20;
            label_27:
            mem2[0] = val_21;
        }
    
    }

}

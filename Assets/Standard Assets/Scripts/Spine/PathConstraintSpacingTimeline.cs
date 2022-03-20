using UnityEngine;

namespace Spine
{
    public class PathConstraintSpacingTimeline : PathConstraintPositionTimeline
    {
        // Properties
        public override int PropertyId { get; }
        
        // Methods
        public override int get_PropertyId()
        {
            return (int)W8 + 201326592;
        }
        public PathConstraintSpacingTimeline(int frameCount)
        {
        
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            float val_11;
            float val_12;
            float val_13;
            Spine.ExposedList<Spine.PathConstraint> val_11 = skeleton.pathConstraints;
            val_11 = val_11 + ((X10) << 3);
            if((X21 + 32) <= time)
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
            
            mem2[0] = X23 + 16 + 68;
            return;
            label_6:
            var val_12 = -8589934592;
            val_12 = val_12 + ((X21 + 24) << 32);
            val_12 = X21 + (val_12 >> 30);
            if(((X21 + ((ulong)(-8589934592 + (X21 + 24) << 32)) >> 30) + 32) <= time)
            {
                goto label_13;
            }
            
            int val_1 = Spine.Animation.BinarySearch(values:  X21, target:  time, step:  2);
            int val_2 = val_1 - 1;
            int val_3 = val_1 - 2;
            var val_4 = X21 + (val_1 << 2);
            val_3 = X21 + (val_3 << 2);
            float val_13 = (X21 + (val_1) << 2) + 32;
            val_2 = X21 + (val_2 << 2);
            var val_5 = (val_1 < 0) ? (val_1 + 1) : (val_1);
            val_13 = ((X21 + ((val_1 - 2)) << 2) + 32) - val_13;
            val_5 = val_5 >> 1;
            val_13 = (time - val_13) / val_13;
            val_13 = 1f - val_13;
            float val_8 = this.GetCurvePercent(frameIndex:  val_5 - 1, percent:  val_13);
            int val_9 = val_1 + 1;
            val_9 = X21 + (val_9 << 2);
            float val_14 = (X21 + ((val_1 + 1)) << 2) + 32;
            val_14 = val_14 - ((X21 + ((val_1 - 1)) << 2) + 32);
            val_8 = val_8 * val_14;
            val_11 = ((X21 + ((val_1 - 1)) << 2) + 32) + val_8;
            if(X23 != 0)
            {
                goto label_18;
            }
            
            label_13:
            var val_10 = (X21 + 24) << 32;
            val_10 = val_10 + (-4294967296);
            val_10 = X21 + (val_10 >> 30);
            val_11 = mem[(X21 + ((ulong)((X21 + 24 << 32) + -4294967296)) >> 30) + 32];
            val_11 = (X21 + ((ulong)((X21 + 24 << 32) + -4294967296)) >> 30) + 32;
            label_18:
            if(pose != 0)
            {
                    val_12 = mem[X23 + 44];
                val_12 = X23 + 44;
            }
            else
            {
                    val_12 = mem[X23 + 16 + 68];
                val_12 = X23 + 16 + 68;
            }
            
            val_11 = val_11 - val_12;
            val_11 = val_11 * alpha;
            val_13 = val_12 + val_11;
            goto label_24;
            label_7:
            float val_15 = X23 + 16 + 68;
            val_15 = val_15 - (X23 + 44);
            val_15 = val_15 * alpha;
            val_13 = (X23 + 44) + val_15;
            label_24:
            mem2[0] = val_13;
        }
    
    }

}

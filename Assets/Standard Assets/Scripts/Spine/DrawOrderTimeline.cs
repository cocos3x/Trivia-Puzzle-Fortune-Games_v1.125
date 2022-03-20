using UnityEngine;

namespace Spine
{
    public class DrawOrderTimeline : Timeline
    {
        // Fields
        internal float[] frames;
        private int[][] drawOrders;
        
        // Properties
        public float[] Frames { get; set; }
        public int[][] DrawOrders { get; set; }
        public int FrameCount { get; }
        public int PropertyId { get; }
        
        // Methods
        public float[] get_Frames()
        {
            return (System.Single[])this.frames;
        }
        public void set_Frames(float[] value)
        {
            this.frames = value;
        }
        public int[][] get_DrawOrders()
        {
            return (System.Int32[][])this.drawOrders;
        }
        public void set_DrawOrders(int[][] value)
        {
            this.drawOrders = value;
        }
        public int get_FrameCount()
        {
            if(this.frames != null)
            {
                    return (int)this.frames.Length;
            }
            
            throw new NullReferenceException();
        }
        public int get_PropertyId()
        {
            return 134217728;
        }
        public DrawOrderTimeline(int frameCount)
        {
            this.frames = new float[0];
            this.drawOrders = new System.Int32[][0];
        }
        public void SetFrame(int frameIndex, float time, int[] drawOrder)
        {
            this.frames[(long)frameIndex] = time;
            this.drawOrders[(long)frameIndex] = drawOrder;
        }
        public void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            int val_5;
            Spine.ExposedList<Spine.Slot> val_6;
            Spine.ExposedList<Spine.Slot> val_7;
            var val_8;
            val_5 = pose;
            val_7 = skeleton.slots;
            val_6 = skeleton.drawOrder;
            if((val_5 != 0) || (direction != 1))
            {
                goto label_3;
            }
            
            label_10:
            System.Array.Copy(sourceArray:  9496, sourceIndex:  0, destinationArray:  firedEvents, destinationIndex:  0, length:  direction);
            return;
            label_3:
            if(this.frames[0] <= time)
            {
                goto label_8;
            }
            
            if(val_5 != 0)
            {
                    return;
            }
            
            if(val_7 != null)
            {
                goto label_10;
            }
            
            label_8:
            val_8 = this.frames.Length - 1;
            if(this.frames[val_8] > time)
            {
                    val_8 = (Spine.Animation.BinarySearch(values:  this.frames, target:  time)) - 1;
            }
            
            System.Int32[] val_7 = this.drawOrders[val_8];
            if(val_7 != null)
            {
                    val_5 = this.drawOrders[(val_1 - 1)][0].Length;
                if(val_5 < 1)
            {
                    return;
            }
            
                var val_8 = 0;
                var val_2 = X24 + 32;
                do
            {
                Spine.ExposedList<Spine.Slot> val_3 = val_7 + (-9223372033231546496);
                mem2[0] = val_6;
                if((val_8 + 1) >= val_5)
            {
                    return;
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < (this.drawOrders[(val_1 - 1)][0].Length));
            
            }
            
            val_6.Clear(clearArray:  true);
            if(val_7 < 1)
            {
                    return;
            }
            
            do
            {
                val_6.Add(item:  public System.Boolean System.Collections.Generic.Dictionary<System.String, System.UriParser>::Remove(System.String key));
                val_5 = 0 + 1;
            }
            while(val_5 < val_7);
        
        }
    
    }

}

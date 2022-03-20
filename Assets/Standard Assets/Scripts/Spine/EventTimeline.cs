using UnityEngine;

namespace Spine
{
    public class EventTimeline : Timeline
    {
        // Fields
        internal float[] frames;
        private Spine.Event[] events;
        
        // Properties
        public float[] Frames { get; set; }
        public Spine.Event[] Events { get; set; }
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
        public Spine.Event[] get_Events()
        {
            return (Spine.Event[])this.events;
        }
        public void set_Events(Spine.Event[] value)
        {
            this.events = value;
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
            return 117440512;
        }
        public EventTimeline(int frameCount)
        {
            this.frames = new float[0];
            this.events = new Spine.Event[0];
        }
        public void SetFrame(int frameIndex, Spine.Event e)
        {
            this.frames[(long)frameIndex] = e.time;
            this.events[(long)frameIndex] = e;
        }
        public void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            System.Single[] val_2;
            var val_3;
            float val_4;
            int val_5;
            var val_6;
            val_3 = pose;
            val_4 = lastTime;
            if(firedEvents == null)
            {
                    return;
            }
            
            val_2 = this.frames;
            if(val_4 <= time)
            {
                goto label_3;
            }
            
            val_5 = this.frames.Length;
            val_4 = -1f;
            if(val_5 != 0)
            {
                goto label_5;
            }
            
            label_3:
            var val_2 = -4294967296;
            val_2 = val_2 + ((this.frames.Length) << 32);
            val_5 = this.frames.Length;
            if((val_2[val_2 >> 30]) <= val_4)
            {
                    return;
            }
            
            label_5:
            if(val_2[0] > time)
            {
                    return;
            }
            
            if(val_4 >= 0)
            {
                goto label_11;
            }
            
            val_6 = 0;
            goto label_14;
            label_11:
            int val_1 = Spine.Animation.BinarySearch(values:  val_2, target:  val_4);
            val_5 = this.frames.Length;
            var val_6 = (long)val_1;
            label_16:
            val_6 = val_6;
            if(val_6 <= 0)
            {
                goto label_14;
            }
            
            val_6 = val_6 - 1;
            if(val_2[val_6] == val_2[val_1])
            {
                goto label_16;
            }
            
            label_14:
            if(val_6 >= this.frames.Length)
            {
                    return;
            }
            
            val_3 = (long)val_6;
            do
            {
                if(val_2[val_3] > time)
            {
                    return;
            }
            
                firedEvents.Add(item:  this.events[val_3]);
                val_3 = val_3 + 1;
                if(val_3 >= (long)this.frames.Length)
            {
                    return;
            }
            
            }
            while(val_3 < this.frames.Length);
            
            throw new IndexOutOfRangeException();
        }
    
    }

}

using UnityEngine;

namespace Spine
{
    public class Animation
    {
        // Fields
        internal Spine.ExposedList<Spine.Timeline> timelines;
        internal float duration;
        internal string name;
        
        // Properties
        public string Name { get; }
        public Spine.ExposedList<Spine.Timeline> Timelines { get; set; }
        public float Duration { get; set; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.name;
        }
        public Spine.ExposedList<Spine.Timeline> get_Timelines()
        {
            return (Spine.ExposedList<Spine.Timeline>)this.timelines;
        }
        public void set_Timelines(Spine.ExposedList<Spine.Timeline> value)
        {
            this.timelines = value;
        }
        public float get_Duration()
        {
            return (float)this.duration;
        }
        public void set_Duration(float value)
        {
            this.duration = value;
        }
        public Animation(string name, Spine.ExposedList<Spine.Timeline> timelines, float duration)
        {
            string val_4;
            string val_5;
            val_1 = new System.Object();
            if(name == null)
            {
                goto label_1;
            }
            
            if(val_1 == null)
            {
                goto label_2;
            }
            
            this.name = name;
            this.timelines = val_1;
            this.duration = duration;
            return;
            label_1:
            val_4 = "name";
            val_5 = "name cannot be null.";
            goto label_3;
            label_2:
            System.ArgumentNullException val_2 = null;
            val_4 = "timelines";
            val_5 = "timelines cannot be null.";
            label_3:
            val_2 = new System.ArgumentNullException(paramName:  val_4, message:  val_5);
            throw val_2;
        }
        public void Apply(Spine.Skeleton skeleton, float lastTime, float time, bool loop, Spine.ExposedList<Spine.Event> events, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            float val_3;
            float val_4;
            var val_5;
            var val_6;
            val_3 = time;
            val_4 = lastTime;
            val_5 = this;
            bool val_2 = true;
            if(skeleton == null)
            {
                    throw new System.ArgumentNullException(paramName:  "skeleton", message:  "skeleton cannot be null.");
            }
            
            if((loop != false) && (this.duration != 0f))
            {
                    val_3 = val_3;
                if(val_4 > 0f)
            {
                    val_4 = val_4;
            }
            
            }
            
            if(41984000 < 1)
            {
                    return;
            }
            
            var val_6 = 0;
            label_14:
            val_2 = val_2 + 0;
            val_5 = mem[(true + 0) + 32];
            val_5 = (true + 0) + 32;
            var val_5 = val_5;
            if(((true + 0) + 32 + 294) == 0)
            {
                goto label_13;
            }
            
            var val_3 = (true + 0) + 32 + 176;
            var val_4 = 0;
            val_3 = val_3 + 8;
            label_12:
            if((((true + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_11;
            }
            
            val_4 = val_4 + 1;
            val_3 = val_3 + 16;
            if(val_4 < ((true + 0) + 32 + 294))
            {
                goto label_12;
            }
            
            goto label_13;
            label_11:
            val_5 = val_5 + ((((true + 0) + 32 + 176 + 8)) << 4);
            val_6 = val_5 + 304;
            label_13:
            val_5.Apply(skeleton:  skeleton, lastTime:  val_4, time:  val_3, events:  events, alpha:  alpha, pose:  pose, direction:  direction);
            val_6 = val_6 + 1;
            if(val_6 < 41984000)
            {
                goto label_14;
            }
        
        }
        internal static int BinarySearch(float[] values, float target, int step)
        {
            int val_7 = values.Length;
            int val_1 = val_7 / step;
            val_1 = val_1 - 2;
            if()
            {
                    return (int)val_8;
            }
            
            int val_2 = val_1 >> 1;
            int val_3 = val_2 + 1;
            label_4:
            float val_6 = values[(val_3 * step) << 2];
            val_1 = (val_6 > target) ? (val_2) : (val_1);
            var val_5 = (val_6 > target) ? 0 : (val_3);
            if(val_5 == val_1)
            {
                goto label_3;
            }
            
            val_2 = val_1 + val_5;
            val_2 = val_2 >> 1;
            val_3 = val_2 + 1;
            values[(val_3 * step) << 2] = val_3 * step;
            if((values[(val_3 * step) << 2]) < val_7)
            {
                goto label_4;
            }
            
            var val_8 = 0;
            throw new IndexOutOfRangeException();
            label_3:
            val_7 = val_1 + 1;
            val_8 = val_7 * val_8;
            return (int)val_8;
        }
        internal static int BinarySearch(float[] values, float target)
        {
            var val_6;
            int val_1 = values.Length - 2;
            if()
            {
                goto label_1;
            }
            
            int val_2 = val_1 >> 1;
            int val_3 = val_2 + 1;
            label_4:
            float val_5 = values[val_3 << 2];
            val_1 = (val_5 > target) ? (val_2) : (val_1);
            var val_4 = (val_5 > target) ? 0 : (val_3);
            if(val_4 == val_1)
            {
                goto label_3;
            }
            
            val_2 = val_1 + val_4;
            val_2 = val_2 >> 1;
            val_3 = val_2 + 1;
            if(val_3 < values.Length)
            {
                goto label_4;
            }
            
            throw new IndexOutOfRangeException();
            label_3:
            val_6 = val_1 + 1;
            return (int)val_6;
            label_1:
            val_6 = 1;
            return (int)val_6;
        }
        internal static int LinearSearch(float[] values, float target, int step)
        {
            var val_2;
            if(>=0)
            {
                    val_2 = 0;
                do
            {
                if(values[0] > target)
            {
                    return (int)val_2;
            }
            
                val_2 = val_2 + step;
            }
            while(val_2 <= (values.Length - step));
            
            }
            
            val_2 = 0;
            return (int)val_2;
        }
    
    }

}

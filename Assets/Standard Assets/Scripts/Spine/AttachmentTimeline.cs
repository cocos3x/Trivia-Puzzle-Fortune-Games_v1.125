using UnityEngine;

namespace Spine
{
    public class AttachmentTimeline : Timeline
    {
        // Fields
        internal int slotIndex;
        internal float[] frames;
        private string[] attachmentNames;
        
        // Properties
        public int SlotIndex { get; set; }
        public float[] Frames { get; set; }
        public string[] AttachmentNames { get; set; }
        public int FrameCount { get; }
        public int PropertyId { get; }
        
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
        public string[] get_AttachmentNames()
        {
            return (System.String[])this.attachmentNames;
        }
        public void set_AttachmentNames(string[] value)
        {
            this.attachmentNames = value;
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
            return (int)this.slotIndex + 67108864;
        }
        public AttachmentTimeline(int frameCount)
        {
            this.frames = new float[0];
            this.attachmentNames = new string[0];
        }
        public void SetFrame(int frameIndex, float time, string attachmentName)
        {
            this.frames[(long)frameIndex] = time;
            this.attachmentNames[(long)frameIndex] = attachmentName;
        }
        public void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            Spine.Attachment val_5;
            var val_6;
            Spine.ExposedList<Spine.Slot> val_4 = skeleton.slots;
            val_4 = val_4 + ((this.slotIndex) << 3);
            if((pose != 0) || (direction != 1))
            {
                goto label_5;
            }
            
            label_13:
            if((X19 + 16 + 72) == 0)
            {
                goto label_8;
            }
            
            val_5 = skeleton.GetAttachment(slotIndex:  this.slotIndex, attachmentName:  X19 + 16 + 72);
            goto label_20;
            label_5:
            if(this.frames[0] <= time)
            {
                goto label_12;
            }
            
            if(pose == 0)
            {
                goto label_13;
            }
            
            return;
            label_12:
            val_6 = this.frames.Length - 1;
            if(this.frames[val_6] > time)
            {
                    val_6 = (Spine.Animation.BinarySearch(values:  this.frames, target:  time, step:  1)) - 1;
            }
            
            string val_7 = this.attachmentNames[val_6];
            if(val_7 == null)
            {
                goto label_17;
            }
            
            val_5 = skeleton.GetAttachment(slotIndex:  this.slotIndex, attachmentName:  val_7);
            if(X19 != 0)
            {
                goto label_20;
            }
            
            label_8:
            val_5 = 0;
            goto label_20;
            label_17:
            val_5 = 0;
            label_20:
            X19.Attachment = val_5;
        }
    
    }

}

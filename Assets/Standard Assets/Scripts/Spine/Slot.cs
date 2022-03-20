using UnityEngine;

namespace Spine
{
    public class Slot
    {
        // Fields
        internal Spine.SlotData data;
        internal Spine.Bone bone;
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        internal float r2;
        internal float g2;
        internal float b2;
        internal bool hasSecondColor;
        internal Spine.Attachment attachment;
        internal float attachmentTime;
        internal Spine.ExposedList<float> attachmentVertices;
        
        // Properties
        public Spine.SlotData Data { get; }
        public Spine.Bone Bone { get; }
        public Spine.Skeleton Skeleton { get; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
        public float R2 { get; set; }
        public float G2 { get; set; }
        public float B2 { get; set; }
        public bool HasSecondColor { get; set; }
        public Spine.Attachment Attachment { get; set; }
        public float AttachmentTime { get; set; }
        public Spine.ExposedList<float> AttachmentVertices { get; set; }
        
        // Methods
        public Spine.SlotData get_Data()
        {
            return (Spine.SlotData)this.data;
        }
        public Spine.Bone get_Bone()
        {
            return (Spine.Bone)this.bone;
        }
        public Spine.Skeleton get_Skeleton()
        {
            if(this.bone != null)
            {
                    return (Spine.Skeleton)this.bone.skeleton;
            }
            
            throw new NullReferenceException();
        }
        public float get_R()
        {
            return (float)this.r;
        }
        public void set_R(float value)
        {
            this.r = value;
        }
        public float get_G()
        {
            return (float)this.g;
        }
        public void set_G(float value)
        {
            this.g = value;
        }
        public float get_B()
        {
            return (float)this.b;
        }
        public void set_B(float value)
        {
            this.b = value;
        }
        public float get_A()
        {
            return (float)this.a;
        }
        public void set_A(float value)
        {
            this.a = value;
        }
        public float get_R2()
        {
            return (float)this.r2;
        }
        public void set_R2(float value)
        {
            this.r2 = value;
        }
        public float get_G2()
        {
            return (float)this.g2;
        }
        public void set_G2(float value)
        {
            this.g2 = value;
        }
        public float get_B2()
        {
            return (float)this.b2;
        }
        public void set_B2(float value)
        {
            this.b2 = value;
        }
        public bool get_HasSecondColor()
        {
            if(this.data != null)
            {
                    return (bool)this.data.hasSecondColor;
            }
            
            throw new NullReferenceException();
        }
        public void set_HasSecondColor(bool value)
        {
            if(this.data != null)
            {
                    this.data.hasSecondColor = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public Spine.Attachment get_Attachment()
        {
            return (Spine.Attachment)this.attachment;
        }
        public void set_Attachment(Spine.Attachment value)
        {
            if(this.attachment == value)
            {
                    return;
            }
            
            this.attachment = value;
            this.attachmentTime = this.bone.skeleton.time;
            this.attachmentVertices.Clear(clearArray:  false);
        }
        public float get_AttachmentTime()
        {
            float val_1 = this.bone.skeleton.time;
            val_1 = val_1 - this.attachmentTime;
            return (float)val_1;
        }
        public void set_AttachmentTime(float value)
        {
            value = this.bone.skeleton.time - value;
            this.attachmentTime = value;
        }
        public Spine.ExposedList<float> get_AttachmentVertices()
        {
            return (Spine.ExposedList<System.Single>)this.attachmentVertices;
        }
        public void set_AttachmentVertices(Spine.ExposedList<float> value)
        {
            this.attachmentVertices = value;
        }
        public Slot(Spine.SlotData data, Spine.Bone bone)
        {
            string val_5;
            string val_6;
            this.attachmentVertices = new Spine.ExposedList<System.Single>();
            val_2 = new System.Object();
            if(data == null)
            {
                goto label_1;
            }
            
            if(val_2 == null)
            {
                goto label_2;
            }
            
            this.data = data;
            this.bone = val_2;
            this.SetToSetupPose();
            return;
            label_1:
            val_5 = "data";
            val_6 = "data cannot be null.";
            goto label_3;
            label_2:
            System.ArgumentNullException val_3 = null;
            val_5 = "bone";
            val_6 = "bone cannot be null.";
            label_3:
            val_3 = new System.ArgumentNullException(paramName:  val_5, message:  val_6);
            throw val_3;
        }
        public void SetToSetupPose()
        {
            Spine.Attachment val_2;
            this.r = this.data.r;
            this.g = this.data.g;
            this.b = this.data.b;
            this.a = this.data.a;
            if(this.data.attachmentName != null)
            {
                    this.attachment = 0;
                val_2 = this.bone.skeleton.GetAttachment(slotIndex:  this.data.index, attachmentName:  this.data.attachmentName);
            }
            else
            {
                    val_2 = 0;
            }
            
            this.Attachment = val_2;
        }
        public override string ToString()
        {
            if(this.data != null)
            {
                    return (string)this.data.name;
            }
            
            throw new NullReferenceException();
        }
    
    }

}

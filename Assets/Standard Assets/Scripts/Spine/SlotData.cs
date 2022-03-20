using UnityEngine;

namespace Spine
{
    public class SlotData
    {
        // Fields
        internal int index;
        internal string name;
        internal Spine.BoneData boneData;
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        internal float r2;
        internal float g2;
        internal float b2;
        internal bool hasSecondColor;
        internal string attachmentName;
        internal Spine.BlendMode blendMode;
        
        // Properties
        public int Index { get; }
        public string Name { get; }
        public Spine.BoneData BoneData { get; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
        public float R2 { get; set; }
        public float G2 { get; set; }
        public float B2 { get; set; }
        public bool HasSecondColor { get; set; }
        public string AttachmentName { get; set; }
        public Spine.BlendMode BlendMode { get; set; }
        
        // Methods
        public int get_Index()
        {
            return (int)this.index;
        }
        public string get_Name()
        {
            return (string)this.name;
        }
        public Spine.BoneData get_BoneData()
        {
            return (Spine.BoneData)this.boneData;
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
            return (bool)this.hasSecondColor;
        }
        public void set_HasSecondColor(bool value)
        {
            this.hasSecondColor = value;
        }
        public string get_AttachmentName()
        {
            return (string)this.attachmentName;
        }
        public void set_AttachmentName(string value)
        {
            this.attachmentName = value;
        }
        public Spine.BlendMode get_BlendMode()
        {
            return (Spine.BlendMode)this.blendMode;
        }
        public void set_BlendMode(Spine.BlendMode value)
        {
            this.blendMode = value;
        }
        public SlotData(int index, string name, Spine.BoneData boneData)
        {
            var val_4;
            string val_6;
            string val_7;
            this.r = 1;
            val_1 = new System.Object();
            if((index & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if(val_1 == null)
            {
                goto label_2;
            }
            
            if(boneData == null)
            {
                goto label_3;
            }
            
            this.index = index;
            this.name = val_1;
            this.boneData = boneData;
            return;
            label_1:
            System.ArgumentException val_2 = null;
            val_4 = val_2;
            val_2 = new System.ArgumentException(message:  "index must be >= 0.", paramName:  "index");
            throw val_4 = val_3;
            label_2:
            val_6 = "name";
            val_7 = "name cannot be null.";
            goto label_5;
            label_3:
            System.ArgumentNullException val_3 = null;
            val_6 = "boneData";
            val_7 = "boneData cannot be null.";
            label_5:
            val_3 = new System.ArgumentNullException(paramName:  val_6, message:  val_7);
            throw val_4;
        }
        public override string ToString()
        {
            return (string)this.name;
        }
    
    }

}

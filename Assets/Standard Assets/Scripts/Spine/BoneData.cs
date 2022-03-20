using UnityEngine;

namespace Spine
{
    public class BoneData
    {
        // Fields
        internal int index;
        internal string name;
        internal Spine.BoneData parent;
        internal float length;
        internal float x;
        internal float y;
        internal float rotation;
        internal float scaleX;
        internal float scaleY;
        internal float shearX;
        internal float shearY;
        internal Spine.TransformMode transformMode;
        
        // Properties
        public int Index { get; }
        public string Name { get; }
        public Spine.BoneData Parent { get; }
        public float Length { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Rotation { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float ShearX { get; set; }
        public float ShearY { get; set; }
        public Spine.TransformMode TransformMode { get; set; }
        
        // Methods
        public int get_Index()
        {
            return (int)this.index;
        }
        public string get_Name()
        {
            return (string)this.name;
        }
        public Spine.BoneData get_Parent()
        {
            return (Spine.BoneData)this.parent;
        }
        public float get_Length()
        {
            return (float)this.length;
        }
        public void set_Length(float value)
        {
            this.length = value;
        }
        public float get_X()
        {
            return (float)this.x;
        }
        public void set_X(float value)
        {
            this.x = value;
        }
        public float get_Y()
        {
            return (float)this.y;
        }
        public void set_Y(float value)
        {
            this.y = value;
        }
        public float get_Rotation()
        {
            return (float)this.rotation;
        }
        public void set_Rotation(float value)
        {
            this.rotation = value;
        }
        public float get_ScaleX()
        {
            return (float)this.scaleX;
        }
        public void set_ScaleX(float value)
        {
            this.scaleX = value;
        }
        public float get_ScaleY()
        {
            return (float)this.scaleY;
        }
        public void set_ScaleY(float value)
        {
            this.scaleY = value;
        }
        public float get_ShearX()
        {
            return (float)this.shearX;
        }
        public void set_ShearX(float value)
        {
            this.shearX = value;
        }
        public float get_ShearY()
        {
            return (float)this.shearY;
        }
        public void set_ShearY(float value)
        {
            this.shearY = value;
        }
        public Spine.TransformMode get_TransformMode()
        {
            return (Spine.TransformMode)this.transformMode;
        }
        public void set_TransformMode(Spine.TransformMode value)
        {
            this.transformMode = value;
        }
        public BoneData(int index, string name, Spine.BoneData parent)
        {
            var val_4;
            this.scaleX = 1;
            val_1 = new System.Object();
            if((index & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if(val_1 == null)
            {
                goto label_2;
            }
            
            this.index = index;
            this.name = val_1;
            this.parent = parent;
            return;
            label_1:
            System.ArgumentException val_2 = null;
            val_4 = val_2;
            val_2 = new System.ArgumentException(message:  "index must be >= 0", paramName:  "index");
            throw val_4 = val_3;
            label_2:
            System.ArgumentNullException val_3 = null;
            val_3 = new System.ArgumentNullException(paramName:  "name", message:  "name cannot be null.");
            throw val_4;
        }
        public override string ToString()
        {
            return (string)this.name;
        }
    
    }

}

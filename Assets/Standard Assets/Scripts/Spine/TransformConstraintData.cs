using UnityEngine;

namespace Spine
{
    public class TransformConstraintData
    {
        // Fields
        internal string name;
        internal int order;
        internal Spine.ExposedList<Spine.BoneData> bones;
        internal Spine.BoneData target;
        internal float rotateMix;
        internal float translateMix;
        internal float scaleMix;
        internal float shearMix;
        internal float offsetRotation;
        internal float offsetX;
        internal float offsetY;
        internal float offsetScaleX;
        internal float offsetScaleY;
        internal float offsetShearY;
        internal bool relative;
        internal bool local;
        
        // Properties
        public string Name { get; }
        public int Order { get; set; }
        public Spine.ExposedList<Spine.BoneData> Bones { get; }
        public Spine.BoneData Target { get; set; }
        public float RotateMix { get; set; }
        public float TranslateMix { get; set; }
        public float ScaleMix { get; set; }
        public float ShearMix { get; set; }
        public float OffsetRotation { get; set; }
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        public float OffsetScaleX { get; set; }
        public float OffsetScaleY { get; set; }
        public float OffsetShearY { get; set; }
        public bool Relative { get; set; }
        public bool Local { get; set; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.name;
        }
        public int get_Order()
        {
            return (int)this.order;
        }
        public void set_Order(int value)
        {
            this.order = value;
        }
        public Spine.ExposedList<Spine.BoneData> get_Bones()
        {
            return (Spine.ExposedList<Spine.BoneData>)this.bones;
        }
        public Spine.BoneData get_Target()
        {
            return (Spine.BoneData)this.target;
        }
        public void set_Target(Spine.BoneData value)
        {
            this.target = value;
        }
        public float get_RotateMix()
        {
            return (float)this.rotateMix;
        }
        public void set_RotateMix(float value)
        {
            this.rotateMix = value;
        }
        public float get_TranslateMix()
        {
            return (float)this.translateMix;
        }
        public void set_TranslateMix(float value)
        {
            this.translateMix = value;
        }
        public float get_ScaleMix()
        {
            return (float)this.scaleMix;
        }
        public void set_ScaleMix(float value)
        {
            this.scaleMix = value;
        }
        public float get_ShearMix()
        {
            return (float)this.shearMix;
        }
        public void set_ShearMix(float value)
        {
            this.shearMix = value;
        }
        public float get_OffsetRotation()
        {
            return (float)this.offsetRotation;
        }
        public void set_OffsetRotation(float value)
        {
            this.offsetRotation = value;
        }
        public float get_OffsetX()
        {
            return (float)this.offsetX;
        }
        public void set_OffsetX(float value)
        {
            this.offsetX = value;
        }
        public float get_OffsetY()
        {
            return (float)this.offsetY;
        }
        public void set_OffsetY(float value)
        {
            this.offsetY = value;
        }
        public float get_OffsetScaleX()
        {
            return (float)this.offsetScaleX;
        }
        public void set_OffsetScaleX(float value)
        {
            this.offsetScaleX = value;
        }
        public float get_OffsetScaleY()
        {
            return (float)this.offsetScaleY;
        }
        public void set_OffsetScaleY(float value)
        {
            this.offsetScaleY = value;
        }
        public float get_OffsetShearY()
        {
            return (float)this.offsetShearY;
        }
        public void set_OffsetShearY(float value)
        {
            this.offsetShearY = value;
        }
        public bool get_Relative()
        {
            return (bool)this.relative;
        }
        public void set_Relative(bool value)
        {
            this.relative = value;
        }
        public bool get_Local()
        {
            return (bool)this.local;
        }
        public void set_Local(bool value)
        {
            this.local = value;
        }
        public TransformConstraintData(string name)
        {
            this.bones = new Spine.ExposedList<Spine.BoneData>();
            if(name == null)
            {
                    throw new System.ArgumentNullException(paramName:  "name", message:  "name cannot be null.");
            }
            
            this.name = name;
        }
        public override string ToString()
        {
            return (string)this.name;
        }
    
    }

}

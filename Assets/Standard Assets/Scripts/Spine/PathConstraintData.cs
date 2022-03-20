using UnityEngine;

namespace Spine
{
    public class PathConstraintData
    {
        // Fields
        internal string name;
        internal int order;
        internal Spine.ExposedList<Spine.BoneData> bones;
        internal Spine.SlotData target;
        internal Spine.PositionMode positionMode;
        internal Spine.SpacingMode spacingMode;
        internal Spine.RotateMode rotateMode;
        internal float offsetRotation;
        internal float position;
        internal float spacing;
        internal float rotateMix;
        internal float translateMix;
        
        // Properties
        public string Name { get; }
        public int Order { get; set; }
        public Spine.ExposedList<Spine.BoneData> Bones { get; }
        public Spine.SlotData Target { get; set; }
        public Spine.PositionMode PositionMode { get; set; }
        public Spine.SpacingMode SpacingMode { get; set; }
        public Spine.RotateMode RotateMode { get; set; }
        public float OffsetRotation { get; set; }
        public float Position { get; set; }
        public float Spacing { get; set; }
        public float RotateMix { get; set; }
        public float TranslateMix { get; set; }
        
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
        public Spine.SlotData get_Target()
        {
            return (Spine.SlotData)this.target;
        }
        public void set_Target(Spine.SlotData value)
        {
            this.target = value;
        }
        public Spine.PositionMode get_PositionMode()
        {
            return (Spine.PositionMode)this.positionMode;
        }
        public void set_PositionMode(Spine.PositionMode value)
        {
            this.positionMode = value;
        }
        public Spine.SpacingMode get_SpacingMode()
        {
            return (Spine.SpacingMode)this.spacingMode;
        }
        public void set_SpacingMode(Spine.SpacingMode value)
        {
            this.spacingMode = value;
        }
        public Spine.RotateMode get_RotateMode()
        {
            return (Spine.RotateMode)this.rotateMode;
        }
        public void set_RotateMode(Spine.RotateMode value)
        {
            this.rotateMode = value;
        }
        public float get_OffsetRotation()
        {
            return (float)this.offsetRotation;
        }
        public void set_OffsetRotation(float value)
        {
            this.offsetRotation = value;
        }
        public float get_Position()
        {
            return (float)this.position;
        }
        public void set_Position(float value)
        {
            this.position = value;
        }
        public float get_Spacing()
        {
            return (float)this.spacing;
        }
        public void set_Spacing(float value)
        {
            this.spacing = value;
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
        public PathConstraintData(string name)
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

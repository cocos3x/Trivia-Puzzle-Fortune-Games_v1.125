using UnityEngine;

namespace Spine
{
    public class IkConstraintData
    {
        // Fields
        internal string name;
        internal int order;
        internal System.Collections.Generic.List<Spine.BoneData> bones;
        internal Spine.BoneData target;
        internal int bendDirection;
        internal float mix;
        
        // Properties
        public string Name { get; }
        public int Order { get; set; }
        public System.Collections.Generic.List<Spine.BoneData> Bones { get; }
        public Spine.BoneData Target { get; set; }
        public int BendDirection { get; set; }
        public float Mix { get; set; }
        
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
        public System.Collections.Generic.List<Spine.BoneData> get_Bones()
        {
            return (System.Collections.Generic.List<Spine.BoneData>)this.bones;
        }
        public Spine.BoneData get_Target()
        {
            return (Spine.BoneData)this.target;
        }
        public void set_Target(Spine.BoneData value)
        {
            this.target = value;
        }
        public int get_BendDirection()
        {
            return (int)this.bendDirection;
        }
        public void set_BendDirection(int value)
        {
            this.bendDirection = value;
        }
        public float get_Mix()
        {
            return (float)this.mix;
        }
        public void set_Mix(float value)
        {
            this.mix = value;
        }
        public IkConstraintData(string name)
        {
            this.bones = new System.Collections.Generic.List<Spine.BoneData>();
            this.bendDirection = 1;
            this.mix = 1f;
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

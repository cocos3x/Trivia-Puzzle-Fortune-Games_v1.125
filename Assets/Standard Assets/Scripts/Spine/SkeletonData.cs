using UnityEngine;

namespace Spine
{
    public class SkeletonData
    {
        // Fields
        internal string name;
        internal Spine.ExposedList<Spine.BoneData> bones;
        internal Spine.ExposedList<Spine.SlotData> slots;
        internal Spine.ExposedList<Spine.Skin> skins;
        internal Spine.Skin defaultSkin;
        internal Spine.ExposedList<Spine.EventData> events;
        internal Spine.ExposedList<Spine.Animation> animations;
        internal Spine.ExposedList<Spine.IkConstraintData> ikConstraints;
        internal Spine.ExposedList<Spine.TransformConstraintData> transformConstraints;
        internal Spine.ExposedList<Spine.PathConstraintData> pathConstraints;
        internal float width;
        internal float height;
        internal string version;
        internal string hash;
        internal float fps;
        internal string imagesPath;
        
        // Properties
        public string Name { get; set; }
        public Spine.ExposedList<Spine.BoneData> Bones { get; }
        public Spine.ExposedList<Spine.SlotData> Slots { get; }
        public Spine.ExposedList<Spine.Skin> Skins { get; set; }
        public Spine.Skin DefaultSkin { get; set; }
        public Spine.ExposedList<Spine.EventData> Events { get; set; }
        public Spine.ExposedList<Spine.Animation> Animations { get; set; }
        public Spine.ExposedList<Spine.IkConstraintData> IkConstraints { get; set; }
        public Spine.ExposedList<Spine.TransformConstraintData> TransformConstraints { get; set; }
        public Spine.ExposedList<Spine.PathConstraintData> PathConstraints { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Version { get; set; }
        public string Hash { get; set; }
        public string ImagesPath { get; set; }
        public float Fps { get; set; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.name;
        }
        public void set_Name(string value)
        {
            this.name = value;
        }
        public Spine.ExposedList<Spine.BoneData> get_Bones()
        {
            return (Spine.ExposedList<Spine.BoneData>)this.bones;
        }
        public Spine.ExposedList<Spine.SlotData> get_Slots()
        {
            return (Spine.ExposedList<Spine.SlotData>)this.slots;
        }
        public Spine.ExposedList<Spine.Skin> get_Skins()
        {
            return (Spine.ExposedList<Spine.Skin>)this.skins;
        }
        public void set_Skins(Spine.ExposedList<Spine.Skin> value)
        {
            this.skins = value;
        }
        public Spine.Skin get_DefaultSkin()
        {
            return (Spine.Skin)this.defaultSkin;
        }
        public void set_DefaultSkin(Spine.Skin value)
        {
            this.defaultSkin = value;
        }
        public Spine.ExposedList<Spine.EventData> get_Events()
        {
            return (Spine.ExposedList<Spine.EventData>)this.events;
        }
        public void set_Events(Spine.ExposedList<Spine.EventData> value)
        {
            this.events = value;
        }
        public Spine.ExposedList<Spine.Animation> get_Animations()
        {
            return (Spine.ExposedList<Spine.Animation>)this.animations;
        }
        public void set_Animations(Spine.ExposedList<Spine.Animation> value)
        {
            this.animations = value;
        }
        public Spine.ExposedList<Spine.IkConstraintData> get_IkConstraints()
        {
            return (Spine.ExposedList<Spine.IkConstraintData>)this.ikConstraints;
        }
        public void set_IkConstraints(Spine.ExposedList<Spine.IkConstraintData> value)
        {
            this.ikConstraints = value;
        }
        public Spine.ExposedList<Spine.TransformConstraintData> get_TransformConstraints()
        {
            return (Spine.ExposedList<Spine.TransformConstraintData>)this.transformConstraints;
        }
        public void set_TransformConstraints(Spine.ExposedList<Spine.TransformConstraintData> value)
        {
            this.transformConstraints = value;
        }
        public Spine.ExposedList<Spine.PathConstraintData> get_PathConstraints()
        {
            return (Spine.ExposedList<Spine.PathConstraintData>)this.pathConstraints;
        }
        public void set_PathConstraints(Spine.ExposedList<Spine.PathConstraintData> value)
        {
            this.pathConstraints = value;
        }
        public float get_Width()
        {
            return (float)this.width;
        }
        public void set_Width(float value)
        {
            this.width = value;
        }
        public float get_Height()
        {
            return (float)this.height;
        }
        public void set_Height(float value)
        {
            this.height = value;
        }
        public string get_Version()
        {
            return (string)this.version;
        }
        public void set_Version(string value)
        {
            this.version = value;
        }
        public string get_Hash()
        {
            return (string)this.hash;
        }
        public void set_Hash(string value)
        {
            this.hash = value;
        }
        public string get_ImagesPath()
        {
            return (string)this.imagesPath;
        }
        public void set_ImagesPath(string value)
        {
            this.imagesPath = value;
        }
        public float get_Fps()
        {
            return (float)this.fps;
        }
        public void set_Fps(float value)
        {
            this.fps = value;
        }
        public Spine.BoneData FindBone(string boneName)
        {
            var val_4;
            var val_5;
            if(boneName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "boneName", message:  "boneName cannot be null.");
            }
            
            if(41934848 >= 1)
            {
                    val_4 = 0;
                var val_1 = X22 + 32;
                do
            {
                val_5 = mem[(X22 + 32) + 0];
                val_5 = (X22 + 32) + 0;
                if((System.String.op_Equality(a:  (X22 + 32) + 0 + 24, b:  boneName)) == true)
            {
                    return (Spine.BoneData)val_5;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < 41934848);
            
            }
            
            val_5 = 0;
            return (Spine.BoneData)val_5;
        }
        public int FindBoneIndex(string boneName)
        {
            var val_4;
            if(boneName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "boneName", message:  "boneName cannot be null.");
            }
            
            if(41934848 >= 1)
            {
                    val_4 = 0;
                var val_1 = X22 + 32;
                do
            {
                if((System.String.op_Equality(a:  (X22 + 32) + 0 + 24, b:  boneName)) == true)
            {
                    return (int)val_4;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < 41934848);
            
            }
            
            val_4 = 0;
            return (int)val_4;
        }
        public Spine.SlotData FindSlot(string slotName)
        {
            var val_3;
            bool val_3 = true;
            if(slotName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "slotName", message:  "slotName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(true + 0) + 32];
                val_3 = (true + 0) + 32;
                if((System.String.op_Equality(a:  (true + 0) + 32 + 24, b:  slotName)) == true)
            {
                    return (Spine.SlotData)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.SlotData)val_3;
        }
        public int FindSlotIndex(string slotName)
        {
            var val_3;
            bool val_3 = true;
            if(slotName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "slotName", message:  "slotName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    val_3 = 0;
                do
            {
                val_3 = val_3 + 0;
                if((System.String.op_Equality(a:  (true + 0) + 32 + 24, b:  slotName)) == true)
            {
                    return (int)val_3;
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < W22);
            
            }
            
            val_3 = 0;
            return (int)val_3;
        }
        public Spine.Skin FindSkin(string skinName)
        {
            var val_5;
            var val_6;
            if(skinName == null)
            {
                goto label_1;
            }
            
            ExposedList.Enumerator<T> val_1 = this.skins.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_5 = 0;
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  11993091, b:  skinName)) == false)
            {
                goto label_5;
            }
            
            goto label_6;
            label_3:
            val_5 = 0;
            label_6:
            0.Dispose();
            return (Spine.Skin)val_5;
            label_1:
            System.ArgumentNullException val_4 = null;
            val_6 = val_4;
            val_4 = new System.ArgumentNullException(paramName:  "skinName", message:  "skinName cannot be null.");
            throw val_6;
        }
        public Spine.EventData FindEvent(string eventDataName)
        {
            var val_5;
            var val_6;
            if(eventDataName == null)
            {
                goto label_1;
            }
            
            ExposedList.Enumerator<T> val_1 = this.events.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_5 = 0;
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  11993091, b:  eventDataName)) == false)
            {
                goto label_5;
            }
            
            goto label_6;
            label_3:
            val_5 = 0;
            label_6:
            0.Dispose();
            return (Spine.EventData)val_5;
            label_1:
            System.ArgumentNullException val_4 = null;
            val_6 = val_4;
            val_4 = new System.ArgumentNullException(paramName:  "eventDataName", message:  "eventDataName cannot be null.");
            throw val_6;
        }
        public Spine.Animation FindAnimation(string animationName)
        {
            var val_3;
            bool val_3 = true;
            if(animationName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "animationName", message:  "animationName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(true + 0) + 32];
                val_3 = (true + 0) + 32;
                if((System.String.op_Equality(a:  (true + 0) + 32 + 32, b:  animationName)) == true)
            {
                    return (Spine.Animation)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.Animation)val_3;
        }
        public Spine.IkConstraintData FindIkConstraint(string constraintName)
        {
            var val_3;
            bool val_3 = true;
            if(constraintName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "constraintName", message:  "constraintName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(true + 0) + 32];
                val_3 = (true + 0) + 32;
                if((System.String.op_Equality(a:  (true + 0) + 32 + 16, b:  constraintName)) == true)
            {
                    return (Spine.IkConstraintData)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.IkConstraintData)val_3;
        }
        public Spine.TransformConstraintData FindTransformConstraint(string constraintName)
        {
            var val_3;
            bool val_3 = true;
            if(constraintName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "constraintName", message:  "constraintName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(true + 0) + 32];
                val_3 = (true + 0) + 32;
                if((System.String.op_Equality(a:  (true + 0) + 32 + 16, b:  constraintName)) == true)
            {
                    return (Spine.TransformConstraintData)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.TransformConstraintData)val_3;
        }
        public Spine.PathConstraintData FindPathConstraint(string constraintName)
        {
            var val_3;
            bool val_3 = true;
            if(constraintName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "constraintName", message:  "constraintName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    var val_4 = 0;
                do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(true + 0) + 32];
                val_3 = (true + 0) + 32;
                if(((true + 0) + 32 + 16.Equals(value:  constraintName)) == true)
            {
                    return (Spine.PathConstraintData)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.PathConstraintData)val_3;
        }
        public int FindPathConstraintIndex(string pathConstraintName)
        {
            var val_3;
            bool val_3 = true;
            if(pathConstraintName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "pathConstraintName", message:  "pathConstraintName cannot be null.");
            }
            
            if(W22 >= 1)
            {
                    val_3 = 0;
                do
            {
                val_3 = val_3 + 0;
                if(((true + 0) + 32 + 16.Equals(value:  pathConstraintName)) == true)
            {
                    return (int)val_3;
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < W22);
            
            }
            
            val_3 = 0;
            return (int)val_3;
        }
        public override string ToString()
        {
            if(this.name == null)
            {
                    return this.name.ToString();
            }
            
            return (string)this.name;
        }
        public SkeletonData()
        {
            this.bones = new Spine.ExposedList<Spine.BoneData>();
            this.slots = new Spine.ExposedList<Spine.SlotData>();
            this.skins = new Spine.ExposedList<Spine.Skin>();
            this.events = new Spine.ExposedList<Spine.EventData>();
            this.animations = new Spine.ExposedList<Spine.Animation>();
            this.ikConstraints = new Spine.ExposedList<Spine.IkConstraintData>();
            this.transformConstraints = new Spine.ExposedList<Spine.TransformConstraintData>();
            this.pathConstraints = new Spine.ExposedList<Spine.PathConstraintData>();
        }
    
    }

}

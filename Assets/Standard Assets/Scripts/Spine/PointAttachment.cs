using UnityEngine;

namespace Spine
{
    public class PointAttachment : Attachment
    {
        // Fields
        internal float x;
        internal float y;
        internal float rotation;
        
        // Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Rotation { get; set; }
        
        // Methods
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
        public PointAttachment(string name)
        {
        
        }
        public void ComputeWorldPosition(Spine.Bone bone, out float ox, out float oy)
        {
            if(bone != null)
            {
                    bone.LocalToWorld(localX:  this.x, localY:  this.y, worldX: out  1.960919E+21f, worldY: out  1.961487E+21f);
                return;
            }
            
            throw new NullReferenceException();
        }
        public float ComputeWorldRotation(Spine.Bone bone)
        {
            float val_1 = Spine.MathUtils.CosDeg(degrees:  this.rotation);
            float val_2 = Spine.MathUtils.SinDeg(degrees:  this.rotation);
            float val_4 = bone.a;
            float val_5 = bone.b;
            float val_6 = bone.c;
            val_4 = val_1 * val_4;
            val_5 = val_2 * val_5;
            val_6 = val_1 * val_6;
            val_2 = val_2 * bone.d;
            val_4 = val_4 + val_5;
            val_2 = val_6 + val_2;
            float val_3 = Spine.MathUtils.Atan2(y:  val_2, x:  val_4);
            val_3 = val_3 * 57.29578f;
            return (float)val_3;
        }
    
    }

}

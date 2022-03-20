using UnityEngine;

namespace Spine
{
    public class Bone : IUpdatable
    {
        // Fields
        public static bool yDown;
        internal Spine.BoneData data;
        internal Spine.Skeleton skeleton;
        internal Spine.Bone parent;
        internal Spine.ExposedList<Spine.Bone> children;
        internal float x;
        internal float y;
        internal float rotation;
        internal float scaleX;
        internal float scaleY;
        internal float shearX;
        internal float shearY;
        internal float ax;
        internal float ay;
        internal float arotation;
        internal float ascaleX;
        internal float ascaleY;
        internal float ashearX;
        internal float ashearY;
        internal bool appliedValid;
        internal float a;
        internal float b;
        internal float worldX;
        internal float c;
        internal float d;
        internal float worldY;
        internal bool sorted;
        
        // Properties
        public Spine.BoneData Data { get; }
        public Spine.Skeleton Skeleton { get; }
        public Spine.Bone Parent { get; }
        public Spine.ExposedList<Spine.Bone> Children { get; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Rotation { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float ShearX { get; set; }
        public float ShearY { get; set; }
        public float AppliedRotation { get; set; }
        public float AX { get; set; }
        public float AY { get; set; }
        public float AScaleX { get; set; }
        public float AScaleY { get; set; }
        public float AShearX { get; set; }
        public float AShearY { get; set; }
        public float A { get; }
        public float B { get; }
        public float C { get; }
        public float D { get; }
        public float WorldX { get; }
        public float WorldY { get; }
        public float WorldRotationX { get; }
        public float WorldRotationY { get; }
        public float WorldScaleX { get; }
        public float WorldScaleY { get; }
        public float WorldToLocalRotationX { get; }
        public float WorldToLocalRotationY { get; }
        
        // Methods
        public Spine.BoneData get_Data()
        {
            return (Spine.BoneData)this.data;
        }
        public Spine.Skeleton get_Skeleton()
        {
            return (Spine.Skeleton)this.skeleton;
        }
        public Spine.Bone get_Parent()
        {
            return (Spine.Bone)this.parent;
        }
        public Spine.ExposedList<Spine.Bone> get_Children()
        {
            return (Spine.ExposedList<Spine.Bone>)this.children;
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
        public float get_AppliedRotation()
        {
            return (float)this.arotation;
        }
        public void set_AppliedRotation(float value)
        {
            this.arotation = value;
        }
        public float get_AX()
        {
            return (float)this.ax;
        }
        public void set_AX(float value)
        {
            this.ax = value;
        }
        public float get_AY()
        {
            return (float)this.ay;
        }
        public void set_AY(float value)
        {
            this.ay = value;
        }
        public float get_AScaleX()
        {
            return (float)this.ascaleX;
        }
        public void set_AScaleX(float value)
        {
            this.ascaleX = value;
        }
        public float get_AScaleY()
        {
            return (float)this.ascaleY;
        }
        public void set_AScaleY(float value)
        {
            this.ascaleY = value;
        }
        public float get_AShearX()
        {
            return (float)this.ashearX;
        }
        public void set_AShearX(float value)
        {
            this.ashearX = value;
        }
        public float get_AShearY()
        {
            return (float)this.ashearY;
        }
        public void set_AShearY(float value)
        {
            this.ashearY = value;
        }
        public float get_A()
        {
            return (float)this.a;
        }
        public float get_B()
        {
            return (float)this.b;
        }
        public float get_C()
        {
            return (float)this.c;
        }
        public float get_D()
        {
            return (float)this.d;
        }
        public float get_WorldX()
        {
            return (float)this.worldX;
        }
        public float get_WorldY()
        {
            return (float)this.worldY;
        }
        public float get_WorldRotationX()
        {
            float val_1 = Spine.MathUtils.Atan2(y:  this.c, x:  this.a);
            val_1 = val_1 * 57.29578f;
            return (float)val_1;
        }
        public float get_WorldRotationY()
        {
            float val_1 = Spine.MathUtils.Atan2(y:  this.d, x:  this.b);
            val_1 = val_1 * 57.29578f;
            return (float)val_1;
        }
        public float get_WorldScaleX()
        {
            float val_1 = this.a * this.a;
            float val_2 = this.c * this.c;
            val_1 = val_1 + val_2;
            if(val_2 <= _TYPE_MAX_)
            {
                    return val_2;
            }
        
        }
        public float get_WorldScaleY()
        {
            float val_1 = this.b * this.b;
            float val_2 = this.d * this.d;
            val_1 = val_1 + val_2;
            if(val_2 <= _TYPE_MAX_)
            {
                    return val_2;
            }
        
        }
        public Bone(Spine.BoneData data, Spine.Skeleton skeleton, Spine.Bone parent)
        {
            string val_5;
            string val_6;
            this.children = new Spine.ExposedList<Spine.Bone>();
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
            this.skeleton = val_2;
            this.parent = parent;
            this.SetToSetupPose();
            return;
            label_1:
            val_5 = "data";
            val_6 = "data cannot be null.";
            goto label_3;
            label_2:
            System.ArgumentNullException val_3 = null;
            val_5 = "skeleton";
            val_6 = "skeleton cannot be null.";
            label_3:
            val_3 = new System.ArgumentNullException(paramName:  val_5, message:  val_6);
            throw val_3;
        }
        public void Update()
        {
            this.UpdateWorldTransform(x:  this.x, y:  this.y, rotation:  this.rotation, scaleX:  this.scaleX, scaleY:  this.scaleY, shearX:  this.shearX, shearY:  this.shearY);
        }
        public void UpdateWorldTransform()
        {
            this.UpdateWorldTransform(x:  this.x, y:  this.y, rotation:  this.rotation, scaleX:  this.scaleX, scaleY:  this.scaleY, shearX:  this.shearX, shearY:  this.shearY);
        }
        public void UpdateWorldTransform(float x, float y, float rotation, float scaleX, float scaleY, float shearX, float shearY)
        {
            bool val_70;
            float val_71;
            float val_72;
            float val_73;
            float val_74;
            float val_75;
            float val_78;
            float val_79;
            float val_80;
            float val_81;
            val_70 = static_value_0280A734;
            val_71 = shearY;
            float val_70 = shearX;
            val_72 = rotation;
            val_73 = y;
            val_74 = x;
            val_70 = true;
            this.ax = val_74;
            this.ay = val_73;
            this.arotation = val_72;
            this.ascaleX = scaleX;
            this.ashearY = val_71;
            this.appliedValid = true;
            this.ascaleY = scaleY;
            this.ashearX = val_70;
            if(this.parent == null)
            {
                goto label_1;
            }
            
            float val_63 = this.parent.a;
            val_75 = this.parent.b;
            val_63 = val_63 * val_74;
            val_63 = val_63 + (val_75 * val_73);
            val_63 = val_63 + this.parent.worldX;
            this.worldX = val_63;
            float val_2 = this.parent.c * val_74;
            val_2 = val_2 + (this.parent.d * val_73);
            val_2 = val_2 + this.parent.worldY;
            this.worldY = val_2;
            if(this.data.transformMode > 7)
            {
                goto label_3;
            }
            
            var val_64 = 32576512 + (this.data.transformMode) << 2;
            val_64 = val_64 + 32576512;
            goto (32576512 + (this.data.transformMode) << 2 + 32576512);
            label_1:
            val_70 = val_72 + val_70;
            val_75 = Spine.MathUtils.CosDeg(degrees:  val_70);
            float val_72 = 90f;
            val_72 = val_72 + val_72;
            val_71 = val_72 + val_71;
            val_72 = Spine.MathUtils.SinDeg(degrees:  val_70);
            val_78 = val_75 * scaleX;
            val_79 = (Spine.MathUtils.CosDeg(degrees:  val_71)) * scaleY;
            if(this.skeleton.flipX != false)
            {
                    val_74 = -val_74;
                val_78 = -val_78;
                val_79 = -val_79;
            }
            
            val_80 = val_72 * scaleX;
            val_81 = (Spine.MathUtils.SinDeg(degrees:  val_71)) * scaleY;
            if(((this.skeleton.flipY == true) ? 1 : 0) != ((Spine.Bone.yDown == true) ? 1 : 0))
            {
                    val_73 = -val_73;
                val_80 = -val_80;
                val_81 = -val_81;
            }
            
            this.a = val_78;
            this.b = val_79;
            this.c = val_80;
            this.d = val_81;
            float val_73 = this.skeleton.x;
            val_73 = val_74 + val_73;
            this.worldX = val_73;
            float val_74 = this.skeleton.y;
            val_74 = val_73 + val_74;
            this.worldY = val_74;
            return;
            label_3:
            if(this.skeleton.flipX != false)
            {
                    this.a = -this.a;
            }
            
            if(((this.skeleton.flipY == true) ? 1 : 0) == ((Spine.Bone.yDown == true) ? 1 : 0))
            {
                    return;
            }
            
            this.c = -this.c;
        }
        public void SetToSetupPose()
        {
            if(this.data != null)
            {
                    this.x = this.data.x;
                this.y = this.data.y;
                this.rotation = this.data.rotation;
                this.scaleX = this.data.scaleX;
                this.scaleY = this.data.scaleY;
                this.shearX = this.data.shearX;
                this.shearY = this.data.shearY;
                return;
            }
            
            throw new NullReferenceException();
        }
        internal void UpdateAppliedTransform()
        {
            float val_31;
            float val_32;
            float val_33;
            float val_34;
            float val_35;
            float val_36;
            float val_37;
            float val_38;
            this.appliedValid = true;
            if(this.parent == null)
            {
                goto label_1;
            }
            
            float val_33 = this.parent.a;
            float val_34 = this.parent.b;
            float val_30 = this.parent.worldX;
            float val_31 = this.worldY;
            float val_32 = 1f;
            val_30 = this.worldX - val_30;
            this.ashearX = 0f;
            float val_1 = val_33 * this.parent.d;
            val_31 = val_31 - this.parent.worldY;
            val_1 = val_1 - (val_34 * this.parent.c);
            float val_3 = this.parent.d * val_30;
            val_32 = val_32 / val_1;
            float val_4 = val_34 * val_31;
            val_31 = val_33 * val_31;
            val_30 = this.parent.c * val_30;
            val_3 = val_32 * val_3;
            val_4 = val_32 * val_4;
            val_31 = val_32 * val_31;
            val_30 = val_32 * val_30;
            float val_5 = val_33 * val_32;
            float val_6 = val_34 * val_32;
            val_33 = val_3 - val_4;
            val_34 = val_31 - val_30;
            this.ax = val_33;
            this.ay = val_34;
            float val_35 = this.a;
            float val_7 = this.parent.d * val_32;
            float val_8 = this.parent.c * val_32;
            val_31 = (val_7 * val_35) - (val_6 * this.c);
            float val_11 = val_5 * this.c;
            val_35 = val_8 * val_35;
            float val_12 = val_11 - val_35;
            float val_13 = val_31 * val_31;
            val_11 = val_12 * val_12;
            val_11 = val_13 + val_11;
            val_33 = val_7 * this.b;
            val_6 = val_6 * this.d;
            val_5 = val_5 * this.d;
            val_8 = val_8 * this.b;
            if(val_13 >= _TYPE_MAX_)
            {
                    val_32 = val_11;
            }
            
            val_34 = val_33 - val_6;
            val_8 = val_5 - val_8;
            this.ascaleX = val_32;
            if(val_32 <= 0.0001f)
            {
                goto label_5;
            }
            
            val_33 = (val_31 * val_8) - (val_12 * val_34);
            val_32 = val_33 / val_32;
            this.ascaleY = val_32;
            float val_16 = val_31 * val_34;
            val_16 = val_16 + (val_12 * val_8);
            float val_18 = Spine.MathUtils.Atan2(y:  val_16, x:  val_33);
            val_34 = 57.29578f;
            val_18 = val_18 * val_34;
            this.ashearY = val_18;
            val_35 = (Spine.MathUtils.Atan2(y:  val_12, x:  val_31)) * val_34;
            goto label_8;
            label_1:
            this.ax = this.worldX;
            this.ay = this.worldY;
            float val_20 = Spine.MathUtils.Atan2(y:  this.c, x:  this.a);
            val_34 = 57.29578f;
            val_20 = val_20 * val_34;
            this.arotation = val_20;
            val_31 = this.c;
            float val_21 = this.a * this.a;
            float val_22 = val_31 * val_31;
            val_22 = val_21 + val_22;
            if(val_21 >= _TYPE_MAX_)
            {
                    val_36 = val_22;
            }
            
            float val_36 = this.b;
            float val_37 = this.d;
            this.ascaleX = val_36;
            val_36 = val_36 * val_36;
            val_37 = val_37 * val_37;
            val_37 = val_36 + val_37;
            if(val_36 >= _TYPE_MAX_)
            {
                    val_37 = val_37;
            }
            
            float val_40 = this.a;
            float val_39 = this.b;
            float val_38 = this.d;
            this.ascaleY = val_37;
            val_38 = val_40 * val_38;
            val_39 = val_39 * this.c;
            val_40 = (val_40 * val_39) + (this.c * val_38);
            this.ashearX = 0f;
            float val_26 = Spine.MathUtils.Atan2(y:  val_40, x:  val_38 - val_39);
            val_26 = val_26 * val_34;
            this.ashearY = val_26;
            return;
            label_5:
            this.ascaleX = 0f;
            float val_27 = val_34 * val_34;
            float val_28 = val_8 * val_8;
            val_28 = val_27 + val_28;
            if(val_27 >= _TYPE_MAX_)
            {
                    val_38 = val_28;
            }
            
            this.ascaleY = val_38;
            this.ashearY = 0f;
            float val_29 = Spine.MathUtils.Atan2(y:  val_8, x:  val_34);
            val_29 = val_29 * (-57.29578f);
            val_35 = val_29 + 90f;
            label_8:
            this.arotation = val_35;
        }
        public void WorldToLocal(float worldX, float worldY, out float localX, out float localY)
        {
            float val_5 = this.a;
            float val_4 = this.b;
            float val_3 = this.d;
            worldX = worldX - this.worldX;
            float val_1 = val_5 * val_3;
            worldY = worldY - this.worldY;
            val_1 = val_1 - (val_4 * this.c);
            val_3 = val_3 * worldX;
            val_4 = val_4 * worldY;
            worldY = val_5 * worldY;
            worldX = this.c * worldX;
            val_5 = 1f / val_1;
            val_1 = val_3 * val_5;
            val_4 = val_5 * val_4;
            worldY = val_5 * worldY;
            worldX = worldX * val_5;
            val_5 = val_1 - val_4;
            worldX = worldY - worldX;
            localX = val_5;
            localY = worldX;
        }
        public void LocalToWorld(float localX, float localY, out float worldX, out float worldY)
        {
            float val_1 = this.a;
            float val_2 = this.b;
            val_1 = val_1 * localX;
            val_2 = val_2 * localY;
            val_1 = val_1 + val_2;
            val_1 = this.worldX + val_1;
            worldX = val_1;
            localX = this.c * localX;
            localY = this.d * localY;
            localX = localX + localY;
            localX = this.worldY + localX;
            worldY = localX;
        }
        public float get_WorldToLocalRotationX()
        {
            if(this.parent == null)
            {
                    return (float)this.arotation;
            }
            
            float val_1 = this.parent.a * this.c;
            val_1 = val_1 - (this.parent.c * this.a);
            float val_6 = Spine.MathUtils.Atan2(y:  val_1, x:  (this.parent.d * this.a) - (this.parent.b * this.c));
            val_6 = val_6 * 57.29578f;
            return (float)this.arotation;
        }
        public float get_WorldToLocalRotationY()
        {
            if(this.parent == null)
            {
                    return (float)this.arotation;
            }
            
            float val_1 = this.parent.a * this.d;
            val_1 = val_1 - (this.parent.c * this.b);
            float val_6 = Spine.MathUtils.Atan2(y:  val_1, x:  (this.parent.d * this.b) - (this.parent.b * this.d));
            val_6 = val_6 * 57.29578f;
            return (float)this.arotation;
        }
        public float WorldToLocalRotation(float worldRotation)
        {
            float val_1 = Spine.MathUtils.SinDeg(degrees:  worldRotation);
            float val_2 = Spine.MathUtils.CosDeg(degrees:  worldRotation);
            float val_5 = this.a;
            float val_8 = this.b;
            float val_6 = this.c;
            float val_7 = this.d;
            val_5 = val_1 * val_5;
            val_6 = val_2 * val_6;
            val_7 = val_2 * val_7;
            val_8 = val_1 * val_8;
            val_2 = val_5 - val_6;
            float val_4 = Spine.MathUtils.Atan2(y:  val_2, x:  val_7 - val_8);
            val_4 = val_4 * 57.29578f;
            return (float)val_4;
        }
        public float LocalToWorldRotation(float localRotation)
        {
            float val_1 = Spine.MathUtils.SinDeg(degrees:  localRotation);
            float val_2 = Spine.MathUtils.CosDeg(degrees:  localRotation);
            float val_5 = this.c;
            float val_6 = this.d;
            float val_7 = this.a;
            float val_8 = this.b;
            val_5 = val_2 * val_5;
            val_6 = val_1 * val_6;
            val_7 = val_2 * val_7;
            val_8 = val_1 * val_8;
            val_2 = val_5 + val_6;
            float val_4 = Spine.MathUtils.Atan2(y:  val_2, x:  val_7 + val_8);
            val_4 = val_4 * 57.29578f;
            return (float)val_4;
        }
        public void RotateWorld(float degrees)
        {
            float val_2 = Spine.MathUtils.SinDeg(degrees:  degrees);
            this.appliedValid = false;
            val_2 = (Spine.MathUtils.CosDeg(degrees:  degrees)) + val_2;
            this.a = V1.2S - V2.2S;
            this.c = val_2;
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

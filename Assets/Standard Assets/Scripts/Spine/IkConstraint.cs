using UnityEngine;

namespace Spine
{
    public class IkConstraint : IConstraint, IUpdatable
    {
        // Fields
        internal Spine.IkConstraintData data;
        internal Spine.ExposedList<Spine.Bone> bones;
        internal Spine.Bone target;
        internal float mix;
        internal int bendDirection;
        
        // Properties
        public Spine.IkConstraintData Data { get; }
        public int Order { get; }
        public Spine.ExposedList<Spine.Bone> Bones { get; }
        public Spine.Bone Target { get; set; }
        public int BendDirection { get; set; }
        public float Mix { get; set; }
        
        // Methods
        public Spine.IkConstraintData get_Data()
        {
            return (Spine.IkConstraintData)this.data;
        }
        public int get_Order()
        {
            if(this.data != null)
            {
                    return (int)this.data.order;
            }
            
            throw new NullReferenceException();
        }
        public Spine.ExposedList<Spine.Bone> get_Bones()
        {
            return (Spine.ExposedList<Spine.Bone>)this.bones;
        }
        public Spine.Bone get_Target()
        {
            return (Spine.Bone)this.target;
        }
        public void set_Target(Spine.Bone value)
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
        public IkConstraint(Spine.IkConstraintData data, Spine.Skeleton skeleton)
        {
            string val_10;
            string val_11;
            this.bones = new Spine.ExposedList<Spine.Bone>();
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
            this.mix = data.mix;
            this.bendDirection = data.bendDirection;
            this.bones = new Spine.ExposedList<Spine.Bone>(capacity:  1687683152);
            List.Enumerator<T> val_4 = data.bones.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_5;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(this.bones == null)
            {
                    throw new NullReferenceException();
            }
            
            this.bones.Add(item:  val_2.FindBone(boneName:  9733424));
            goto label_8;
            label_5:
            0.Dispose();
            this.target = val_2.FindBone(boneName:  data.target.name);
            return;
            label_1:
            val_10 = "data";
            val_11 = "data cannot be null.";
            goto label_10;
            label_2:
            System.ArgumentNullException val_8 = null;
            val_10 = "skeleton";
            val_11 = "skeleton cannot be null.";
            label_10:
            val_8 = new System.ArgumentNullException(paramName:  val_10, message:  val_11);
            throw val_8;
        }
        public void Apply()
        {
            this.Update();
        }
        public void Update()
        {
            if(W10 != 2)
            {
                    if(W10 != 1)
            {
                    return;
            }
            
                Spine.IkConstraint.Apply(bone:  this.bones, targetX:  this.target.worldX, targetY:  this.target.worldY, alpha:  this.mix);
                return;
            }
            
            Spine.IkConstraint.Apply(parent:  X10 + 32, child:  X10 + 32 + 8, targetX:  this.target.worldX, targetY:  this.target.worldY, bendDir:  this.bendDirection, alpha:  this.mix);
        }
        public override string ToString()
        {
            if(this.data != null)
            {
                    return (string)this.data.name;
            }
            
            throw new NullReferenceException();
        }
        public static void Apply(Spine.Bone bone, float targetX, float targetY, float alpha)
        {
            float val_8;
            float val_9;
            float val_11 = targetY;
            float val_8 = targetX;
            if(bone.appliedValid != true)
            {
                    bone.UpdateAppliedTransform();
            }
            
            float val_10 = bone.parent.b;
            float val_9 = bone.parent.d;
            val_8 = val_8 - bone.parent.worldX;
            float val_1 = bone.parent.a * val_9;
            float val_2 = val_11 - bone.parent.worldY;
            val_1 = val_1 - (val_10 * bone.parent.c);
            float val_4 = 1f / val_1;
            val_9 = val_9 * val_8;
            val_10 = val_10 * val_2;
            val_10 = val_9 - val_10;
            val_10 = val_4 * val_10;
            val_11 = val_10 - bone.ax;
            float val_5 = bone.parent.a * val_2;
            val_5 = val_5 - (bone.parent.c * val_8);
            val_5 = val_4 * val_5;
            val_5 = val_5 - bone.ay;
            float val_13 = 57.29578f;
            float val_14 = bone.arotation;
            float val_12 = (float)(double)val_5;
            val_12 = val_12 * val_13;
            val_12 = val_12 - bone.ashearX;
            val_12 = val_12 - val_14;
            val_13 = val_12 + 180f;
            float val_7 = (bone.ascaleX < 0) ? (val_13) : (val_12);
            if(val_7 <= 180f)
            {
                goto label_6;
            }
            
            val_9 = -360f;
            goto label_7;
            label_6:
            if(val_7 >= 0)
            {
                goto label_8;
            }
            
            val_9 = 360f;
            label_7:
            val_8 = val_7 + val_9;
            label_8:
            val_8 = val_8 * alpha;
            val_14 = val_14 + val_8;
            bone.UpdateWorldTransform(x:  bone.ax, y:  bone.ay, rotation:  val_14, scaleX:  bone.ascaleX, scaleY:  bone.ascaleY, shearX:  bone.ashearX, shearY:  bone.ashearY);
        }
        public static void Apply(Spine.Bone parent, Spine.Bone child, float targetX, float targetY, int bendDir, float alpha)
        {
            float val_59;
            float val_60;
            float val_61;
            float val_62;
            float val_63;
            float val_64;
            var val_65;
            float val_66;
            float val_67;
            float val_68;
            float val_69;
            float val_70;
            float val_71;
            float val_72;
            float val_73;
            float val_74;
            float val_75;
            float val_76;
            float val_77;
            float val_78;
            float val_79;
            float val_80;
            float val_81;
            float val_82;
            float val_83;
            float val_84;
            float val_85;
            float val_86;
            float val_87;
            val_59 = alpha;
            val_60 = targetY;
            if(val_59 != 0f)
            {
                goto label_1;
            }
            
            goto label_3;
            label_1:
            if(parent.appliedValid != true)
            {
                    parent.UpdateAppliedTransform();
            }
            
            if(child.appliedValid != true)
            {
                    child.UpdateAppliedTransform();
            }
            
            val_62 = parent.ax;
            val_61 = parent.ay;
            float val_55 = parent.ascaleY;
            float val_56 = child.ax;
            float val_57 = parent.b;
            var val_2 = (parent.ascaleX < 0) ? 0 : (0 + 1);
            float val_5 = (val_55 < 0) ? (-val_55) : (val_55);
            val_64 = (child.ascaleX < 0) ? (-child.ascaleX) : child.ascaleX;
            val_61 = val_61;
            val_62 = val_62;
            val_63 = (parent.ascaleX < 0) ? (-parent.ascaleX) : parent.ascaleX;
            val_55 = val_63 ?? val_5;
            if(val_55 > 0.0001f)
            {
                    val_65 = 0;
                val_66 = (val_56 * parent.a) + parent.worldX;
                val_67 = (val_56 * parent.c) + parent.worldY;
                val_68 = 0f;
            }
            else
            {
                    val_68 = child.ay;
                float val_10 = val_56 * parent.a;
                float val_11 = val_56 * parent.c;
                float val_12 = val_57 * val_68;
                val_10 = val_10 + val_12;
                val_11 = val_11 + (parent.d * val_68);
                val_66 = parent.worldX + val_10;
                val_67 = val_11 + parent.worldY;
                val_65 = 1;
            }
            
            float val_60 = parent.parent.a;
            float val_64 = parent.parent.b;
            val_69 = parent.parent.worldX;
            float val_67 = parent.parent.c;
            float val_61 = parent.parent.worldY;
            val_70 = 1f;
            float val_15 = val_60 * parent.parent.d;
            val_66 = val_66 - val_69;
            val_67 = val_67 - val_61;
            val_15 = val_15 - (val_64 * val_67);
            val_12 = val_67 * val_66;
            val_66 = parent.parent.d * val_66;
            val_67 = val_64 * val_67;
            float val_17 = val_70 / val_15;
            val_66 = val_66 - val_67;
            float val_19 = val_17 * ((val_60 * val_67) - val_12);
            val_66 = val_17 * val_66;
            val_56 = val_19 - val_61;
            val_57 = val_66 - val_62;
            val_63 = val_63;
            val_69 = val_69;
            val_64 = val_64;
            val_61 = val_61;
            val_62 = val_62;
            val_70 = 1f;
            val_66 = val_57 * val_57;
            val_19 = val_56 * val_56;
            val_66 = val_66 + val_19;
            if(val_56 >= _TYPE_MAX_)
            {
                    float val_63 = val_63;
                val_69 = val_69;
                val_61 = val_61;
                val_62 = val_62;
                val_70 = 1f;
                val_64 = val_64;
                val_63 = val_63;
                val_71 = val_66;
            }
            
            float val_58 = targetX;
            float val_59 = val_60;
            float val_65 = child.data.length;
            val_58 = val_58 - val_69;
            val_59 = val_59 - val_61;
            float val_20 = parent.parent.d * val_58;
            val_59 = val_60 * val_59;
            val_58 = val_67 * val_58;
            val_58 = val_59 - val_58;
            val_20 = val_20 - (val_64 * val_59);
            val_58 = val_17 * val_58;
            val_60 = val_58 - val_61;
            float val_23 = val_64 * val_65;
            val_61 = (val_17 * val_20) - val_62;
            float val_24 = val_63 * val_23;
            if(val_65 == 0)
            {
                goto label_17;
            }
            
            float val_25 = val_61 * val_61;
            val_25 = val_25 + (val_60 * val_60);
            val_25 = val_25 - (val_71 * val_71);
            val_25 = val_25 - (val_24 * val_24);
            val_25 = val_25 / ((val_71 + val_71) * val_24);
            val_72 = -1f;
            if(val_25 >= 0)
            {
                    val_72 = val_25;
                if(val_25 > val_70)
            {
                    val_72 = val_70;
            }
            
            }
            
            float val_31 = (float)bendDir * (float)(double)val_72;
            float val_32 = val_24 * val_72;
            val_72 = val_71 + val_32;
            float val_62 = (float)(double)val_31;
            val_62 = val_24 * val_62;
            float val_33 = val_60 * val_72;
            val_32 = val_61 * val_72;
            val_62 = val_60 * val_62;
            val_33 = val_33 - (val_61 * val_62);
            val_32 = val_32 + val_62;
            label_57:
            label_49:
            val_59 = ((float)(val_55 < 0) ? (-val_2) : (val_2)) * (float)(double)val_68;
            float val_35 = (float)(double)val_33 - val_59;
            val_60 = 180f;
            val_35 = val_35 * 57.29578f;
            val_35 = ((parent.ascaleX < 0) ? 180f : 0f) + val_35;
            val_73 = val_35 - parent.arotation;
            if(val_73 <= val_60)
            {
                goto label_24;
            }
            
            val_74 = -360f;
            goto label_25;
            label_24:
            if(val_73 >= 0)
            {
                goto label_26;
            }
            
            val_74 = 360f;
            label_25:
            val_73 = val_73 + val_74;
            label_26:
            val_74 = val_73 * val_59;
            val_74 = parent.arotation + val_74;
            parent.UpdateWorldTransform(x:  val_62, y:  val_61, rotation:  val_74, scaleX:  parent.scaleX, scaleY:  parent.ascaleY, shearX:  0f, shearY:  0f);
            float val_36 = val_31 + val_59;
            val_36 = val_36 * 57.29578f;
            val_36 = val_36 - child.ashearX;
            val_36 = val_36 * ((float)(val_55 < 0) ? (-val_2) : (val_2));
            val_36 = ((child.ascaleX < 0) ? 180f : 0f) + val_36;
            val_75 = val_36 - child.arotation;
            if(val_75 <= val_60)
            {
                goto label_27;
            }
            
            val_76 = -360f;
            goto label_28;
            label_27:
            if(val_75 >= 0)
            {
                goto label_29;
            }
            
            val_76 = 360f;
            label_28:
            val_75 = val_75 + val_76;
            label_29:
            val_75 = val_75 * val_59;
            val_76 = child.arotation + val_75;
            label_3:
            child.UpdateWorldTransform(x:  val_56, y:  val_68, rotation:  val_76, scaleX:  child.ascaleX, scaleY:  child.ascaleY, shearX:  child.ashearX, shearY:  child.ashearY);
            return;
            label_17:
            val_63 = val_24 * val_24;
            val_23 = val_5 * val_23;
            float val_37 = val_23 * val_23;
            val_64 = (val_61 * val_61) + (val_60 * val_60);
            float val_40 = val_71 * val_37;
            val_65 = val_64 * val_63;
            float val_66 = -2f;
            val_40 = val_71 * val_40;
            float val_42 = val_37 - val_63;
            val_40 = val_65 + val_40;
            float val_68 = -4f;
            val_66 = val_37 * val_66;
            float val_43 = val_71 * val_66;
            val_67 = val_40 - (val_63 * val_37);
            val_68 = val_42 * val_68;
            val_68 = val_68 * val_67;
            val_61 = (val_43 * val_43) + val_68;
            if(val_61 < 0f)
            {
                goto label_32;
            }
            
            if((float)(double)val_60 >= _TYPE_MAX_)
            {
                    val_77 = val_61;
            }
            
            val_77 = (val_43 < 0) ? (-val_77) : (val_77);
            val_77 = val_43 + val_77;
            val_77 = val_77 * (-0.5f);
            val_42 = val_77 / val_42;
            val_67 = val_67 / val_77;
            float val_70 = System.Math.Abs(val_67);
            float val_45 = (System.Math.Abs(val_42) < 0) ? (val_42) : (val_67);
            val_67 = val_45 * val_45;
            if(val_67 <= val_64)
            {
                goto label_38;
            }
            
            label_32:
            val_78 = 3.141593f;
            val_79 = val_71 - val_24;
            float val_48 = val_71 + val_24;
            float val_49 = (-(val_71 * val_24)) / (val_63 - val_37);
            val_80 = val_79 * val_79;
            float val_50 = val_48 * val_48;
            val_81 = 0f;
            if((val_49 < (-1f)) || (val_49 > 1f))
            {
                goto label_40;
            }
            
            val_82 = (float)(double)val_49;
            float val_71 = (float)(double)val_82;
            val_71 = val_24 * val_71;
            val_83 = val_71 + val_71;
            float val_72 = val_23;
            val_81 = val_72 * (float)(double)val_82;
            val_72 = val_81 * val_81;
            val_84 = (val_83 * val_83) + val_72;
            if(val_84 >= 0)
            {
                goto label_43;
            }
            
            val_85 = (float)(double)val_60;
            val_86 = val_81;
            val_80 = val_84;
            val_79 = val_83;
            val_78 = val_82;
            goto label_44;
            label_40:
            val_85 = (float)(double)val_60;
            val_84 = val_50;
            val_83 = val_48;
            val_82 = 0f;
            val_86 = 0f;
            goto label_50;
            label_38:
            if(val_64 >= _TYPE_MAX_)
            {
                    val_87 = val_64 - val_67;
            }
            
            val_63 = val_87 * (float)bendDir;
            float val_73 = val_79;
            val_68 = val_45 - val_71;
            val_73 = val_63 / val_73;
            val_45 = (float)(double)val_60 - (float)(double)val_63;
            float val_74 = val_63;
            val_74 = val_68 / val_74;
            goto label_49;
            label_43:
            val_78 = 3.141593f;
            val_79 = val_79;
            val_85 = (float)(double)val_60;
            val_86 = 0f;
            label_44:
            if(val_84 <= val_50)
            {
                    val_81 = 0f;
                val_84 = val_50;
                val_83 = val_48;
                val_82 = 0f;
            }
            
            label_50:
            val_84 = val_84 + val_80;
            val_84 = val_84 * 0.5f;
            if(val_64 <= val_84)
            {
                goto label_51;
            }
            
            float val_75 = (float)bendDir;
            val_85 = val_85 - ((float)(double)val_81 * val_75);
            val_75 = val_82 * val_75;
            goto label_57;
            label_51:
            val_79 = val_79;
            float val_76 = (float)bendDir;
            val_85 = val_85 - ((float)(double)val_86 * val_76);
            val_76 = val_78 * val_76;
            goto label_57;
        }
    
    }

}

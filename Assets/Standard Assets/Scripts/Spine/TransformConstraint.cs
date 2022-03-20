using UnityEngine;

namespace Spine
{
    public class TransformConstraint : IConstraint, IUpdatable
    {
        // Fields
        internal Spine.TransformConstraintData data;
        internal Spine.ExposedList<Spine.Bone> bones;
        internal Spine.Bone target;
        internal float rotateMix;
        internal float translateMix;
        internal float scaleMix;
        internal float shearMix;
        
        // Properties
        public Spine.TransformConstraintData Data { get; }
        public int Order { get; }
        public Spine.ExposedList<Spine.Bone> Bones { get; }
        public Spine.Bone Target { get; set; }
        public float RotateMix { get; set; }
        public float TranslateMix { get; set; }
        public float ScaleMix { get; set; }
        public float ShearMix { get; set; }
        
        // Methods
        public Spine.TransformConstraintData get_Data()
        {
            return (Spine.TransformConstraintData)this.data;
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
        public TransformConstraint(Spine.TransformConstraintData data, Spine.Skeleton skeleton)
        {
            string val_9;
            string val_10;
            val_1 = new System.Object();
            if(data == null)
            {
                goto label_1;
            }
            
            if(val_1 == null)
            {
                goto label_2;
            }
            
            this.data = data;
            this.rotateMix = data.rotateMix;
            this.translateMix = data.translateMix;
            this.scaleMix = data.scaleMix;
            this.shearMix = data.shearMix;
            this.bones = new Spine.ExposedList<Spine.Bone>();
            ExposedList.Enumerator<T> val_3 = data.bones.GetEnumerator();
            label_7:
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(this.bones == null)
            {
                    throw new NullReferenceException();
            }
            
            this.bones.Add(item:  val_1.FindBone(boneName:  9733424));
            goto label_7;
            label_4:
            0.Dispose();
            this.target = val_1.FindBone(boneName:  data.target.name);
            return;
            label_1:
            val_9 = "data";
            val_10 = "data cannot be null.";
            goto label_9;
            label_2:
            System.ArgumentNullException val_7 = null;
            val_9 = "skeleton";
            val_10 = "skeleton cannot be null.";
            label_9:
            val_7 = new System.ArgumentNullException(paramName:  val_9, message:  val_10);
            throw val_7;
        }
        public void Apply()
        {
            this.Update();
        }
        public void Update()
        {
            if(this.data == null)
            {
                goto label_0;
            }
            
            if(this.data.local == false)
            {
                goto label_1;
            }
            
            if(this.data.relative == false)
            {
                goto label_2;
            }
            
            this.ApplyRelativeLocal();
            return;
            label_1:
            if(this.data.relative == false)
            {
                goto label_3;
            }
            
            this.ApplyRelativeWorld();
            return;
            label_2:
            this.ApplyAbsoluteLocal();
            return;
            label_3:
            this.ApplyAbsoluteWorld();
            return;
            label_0:
            throw new NullReferenceException();
        }
        private void ApplyAbsoluteWorld()
        {
            float val_24;
            float val_25;
            float val_26;
            var val_27;
            float val_28;
            float val_29;
            float val_30;
            float val_31;
            float val_32;
            float val_33;
            float val_34;
            float val_35;
            float val_36;
            float val_24 = this.target.c;
            float val_23 = this.target.d;
            val_23 = this.target.a * val_23;
            val_24 = this.target.b * val_24;
            val_23 = val_23 - val_24;
            var val_1 = (val_23 > 0f) ? 1 : 0;
            if(W22 < 1)
            {
                    return;
            }
            
            float val_25 = this.target.a;
            float val_26 = val_24;
            float val_27 = this.target.b;
            float val_28 = val_23;
            float val_29 = this.data.offsetRotation;
            val_24 = this.data.offsetShearY;
            val_25 = val_25 * val_25;
            val_26 = val_26 * val_26;
            val_27 = val_27 * val_27;
            val_28 = val_28 * val_28;
            val_25 = val_25 + val_26;
            val_25 = this.rotateMix;
            val_26 = this.scaleMix;
            val_29 = (30113232 + this.target.d > 0 ? 1 : 0) * val_29;
            float val_3 = (30113232 + this.target.d > 0 ? 1 : 0) * val_24;
            var val_38 = 0;
            label_53:
            if(val_25 != 0f)
            {
                goto label_7;
            }
            
            val_27 = 0;
            goto label_8;
            label_7:
            float val_5 = Spine.MathUtils.Atan2(y:  mem[-74351394354111644], x:  mem[-74351394354111656]);
            val_5 = (Spine.MathUtils.Atan2(y:  val_24, x:  this.target.a)) - val_5;
            val_28 = val_29 + val_5;
            if(val_28 <= 3.141593f)
            {
                goto label_12;
            }
            
            val_29 = -6.283185f;
            goto label_13;
            label_12:
            if(val_28 >= 0)
            {
                goto label_14;
            }
            
            val_29 = 6.283185f;
            label_13:
            val_28 = val_28 + val_29;
            label_14:
            val_30 = val_25 * val_28;
            float val_6 = Spine.MathUtils.Cos(radians:  val_30);
            float val_7 = Spine.MathUtils.Sin(radians:  val_30);
            val_27 = 1;
            val_24 = val_29 - val_25;
            val_7 = (mem[-74351394354111656]) + val_7;
            mem2[-74351394354111656] = val_24;
            mem2[-74351394354111644] = val_7;
            label_8:
            if(this.translateMix != 0f)
            {
                    this.target.LocalToWorld(localX:  this.data.offsetX, localY:  this.data.offsetY, worldX: out  float val_8 = 8.245502E-38f, worldY: out  float val_9 = 8.2455E-38f);
                float val_31 = mem[-74351394354111648];
                float val_30 = 0f;
                val_27 = 1;
                val_30 = val_30 - val_31;
                val_30 = this.translateMix * val_30;
                val_31 = val_31 + val_30;
                mem2[-74351394354111648] = val_31;
                float val_32 = 0f;
                val_32 = val_32 - (mem[-74351394354111636]);
                val_32 = this.translateMix * val_32;
                val_32 = (mem[-74351394354111636]) + val_32;
                mem2[-74351394354111636] = val_32;
            }
            
            if(val_26 > 0f)
            {
                    float val_10 = (mem[-74351394354111656]) * (mem[-74351394354111656]);
                val_10 = val_10 + ((mem[-74351394354111644]) * (mem[-74351394354111644]));
                if((mem[-74351394354111644]) >= _TYPE_MAX_)
            {
                    val_31 = val_10;
            }
            
                if(val_31 > (1E-05f))
            {
                    val_32 = val_25;
                if(val_32 >= _TYPE_MAX_)
            {
                    val_32 = val_25;
            }
            
                val_32 = val_32 - val_31;
                val_32 = val_32 + this.data.offsetScaleX;
                val_32 = val_26 * val_32;
                val_32 = val_31 + val_32;
                val_31 = val_32 / val_31;
            }
            
                float val_33 = mem[-74351394354111656];
                float val_34 = mem[-74351394354111644];
                val_33 = val_31 * val_33;
                val_34 = val_31 * val_34;
                mem2[-74351394354111656] = val_33;
                mem2[-74351394354111644] = val_34;
                float val_12 = (mem[-74351394354111652]) * (mem[-74351394354111652]);
                val_12 = val_12 + ((mem[-74351394354111640]) * (mem[-74351394354111640]));
                if(val_31 >= _TYPE_MAX_)
            {
                    val_30 = val_12;
            }
            
                if(val_30 > (1E-05f))
            {
                    val_33 = val_3;
                if(val_33 >= _TYPE_MAX_)
            {
                    val_33 = val_27 + val_28;
            }
            
                val_33 = val_33 - val_30;
                val_33 = val_33 + this.data.offsetScaleY;
                val_33 = val_26 * val_33;
                val_33 = val_30 + val_33;
                val_30 = val_33 / val_30;
            }
            
                float val_35 = mem[-74351394354111652];
                float val_36 = mem[-74351394354111640];
                val_27 = 1;
                val_35 = val_30 * val_35;
                val_36 = val_30 * val_36;
                mem2[-74351394354111652] = val_35;
                mem2[-74351394354111640] = val_36;
            }
            
            if(this.shearMix <= 0f)
            {
                goto label_38;
            }
            
            float val_14 = Spine.MathUtils.Atan2(y:  mem[-74351394354111640], x:  mem[-74351394354111652]);
            float val_37 = Spine.MathUtils.Atan2(y:  val_24, x:  this.target.a);
            float val_17 = Spine.MathUtils.Atan2(y:  mem[-74351394354111644], x:  mem[-74351394354111656]);
            val_17 = val_14 - val_17;
            val_34 = ((Spine.MathUtils.Atan2(y:  val_23, x:  this.target.b)) - val_37) - val_17;
            if(val_34 <= 3.141593f)
            {
                goto label_42;
            }
            
            val_35 = -6.283185f;
            goto label_43;
            label_38:
            if(val_27 == 0)
            {
                goto label_44;
            }
            
            if((-17310996) != 0)
            {
                goto label_45;
            }
            
            label_42:
            if(val_34 >= 0)
            {
                goto label_47;
            }
            
            val_35 = 6.283185f;
            label_43:
            val_34 = val_34 + val_35;
            label_47:
            val_37 = val_3 + val_34;
            float val_19 = (mem[-74351394354111652]) * (mem[-74351394354111652]);
            val_19 = val_19 + ((mem[-74351394354111640]) * (mem[-74351394354111640]));
            val_37 = this.shearMix * val_37;
            if((mem[-74351394354111652]) >= _TYPE_MAX_)
            {
                    val_36 = val_19;
            }
            
            val_30 = val_14 + val_37;
            float val_21 = Spine.MathUtils.Cos(radians:  val_30);
            val_21 = val_36 * val_21;
            mem2[-74351394354111652] = val_21;
            float val_22 = Spine.MathUtils.Sin(radians:  val_30);
            val_22 = val_36 * val_22;
            mem2[-74351394354111640] = val_22;
            val_25 = val_25;
            val_26 = val_26;
            label_45:
            mem2[-74351394354111660] = 0;
            label_44:
            val_38 = val_38 + 1;
            if(val_38 < X22)
            {
                goto label_53;
            }
        
        }
        private void ApplyRelativeWorld()
        {
            float val_19;
            float val_20;
            float val_21;
            var val_22;
            float val_23;
            float val_24;
            float val_25;
            float val_26;
            float val_27;
            float val_28;
            float val_29;
            float val_30;
            float val_17 = this.target.c;
            float val_16 = this.target.d;
            val_16 = this.target.a * val_16;
            val_17 = this.target.b * val_17;
            val_16 = val_16 - val_17;
            var val_1 = (val_16 > 0f) ? 1 : 0;
            if(W22 < 1)
            {
                    return;
            }
            
            val_19 = this.data.offsetShearY;
            float val_22 = this.data.offsetRotation;
            float val_18 = this.target.a;
            float val_19 = val_17;
            float val_20 = this.target.b;
            float val_21 = val_16;
            val_18 = val_18 * val_18;
            val_19 = val_19 * val_19;
            val_20 = val_20 * val_20;
            val_21 = val_21 * val_21;
            val_18 = val_18 + val_19;
            val_22 = (30113232 + this.target.d > 0 ? 1 : 0) * val_22;
            float val_3 = (30113232 + this.target.d > 0 ? 1 : 0) * val_19;
            var val_28 = 0;
            val_20 = -1f;
            val_21 = 1f;
            label_43:
            if(this.rotateMix != 0f)
            {
                goto label_7;
            }
            
            val_22 = 0;
            goto label_8;
            label_7:
            val_23 = mem[-74351394354111656];
            val_24 = val_22 + (Spine.MathUtils.Atan2(y:  val_17, x:  this.target.a));
            if(val_24 <= 3.141593f)
            {
                goto label_12;
            }
            
            val_25 = -6.283185f;
            goto label_13;
            label_12:
            if(val_24 >= 0)
            {
                goto label_14;
            }
            
            val_25 = 6.283185f;
            label_13:
            val_24 = val_24 + val_25;
            label_14:
            val_26 = this.rotateMix * val_24;
            float val_6 = Spine.MathUtils.Sin(radians:  val_26);
            val_22 = 1;
            val_19 = val_25 - val_18;
            val_6 = (Spine.MathUtils.Cos(radians:  val_26)) + val_6;
            mem2[-74351394354111656] = val_19;
            mem2[-74351394354111644] = val_6;
            label_8:
            if(this.translateMix != 0f)
            {
                    this.target.LocalToWorld(localX:  this.data.offsetX, localY:  this.data.offsetY, worldX: out  float val_7 = 8.335881E-38f, worldY: out  float val_8 = 8.335878E-38f);
                float val_23 = 0f;
                val_22 = 1;
                val_23 = this.translateMix * val_23;
                val_23 = (mem[-74351394354111648]) + val_23;
                mem2[-74351394354111648] = val_23;
                float val_24 = 0f;
                val_24 = this.translateMix * val_24;
                val_24 = (mem[-74351394354111636]) + val_24;
                mem2[-74351394354111636] = val_24;
            }
            
            if(this.scaleMix > 0f)
            {
                    val_27 = val_18;
                if(val_27 >= _TYPE_MAX_)
            {
                    val_27 = val_18;
            }
            
                float val_25 = this.data.offsetScaleX;
                val_27 = val_27 + val_20;
                val_27 = val_27 + val_25;
                val_27 = this.scaleMix * val_27;
                val_27 = val_27 + val_21;
                val_25 = val_27 * (mem[-74351394354111656]);
                val_27 = val_27 * (mem[-74351394354111644]);
                mem2[-74351394354111644] = val_27;
                val_28 = val_3;
                mem2[-74351394354111656] = val_25;
                if(val_3 >= _TYPE_MAX_)
            {
                    val_28 = val_20 + val_21;
            }
            
                float val_26 = this.data.offsetScaleY;
                val_28 = val_28 + val_20;
                val_28 = val_28 + val_26;
                val_28 = this.scaleMix * val_28;
                val_28 = val_28 + val_21;
                val_26 = (mem[-74351394354111652]) * val_28;
                val_28 = (mem[-74351394354111640]) * val_28;
                val_22 = 1;
                mem2[-74351394354111652] = val_26;
                mem2[-74351394354111640] = val_28;
            }
            
            if(this.shearMix <= 0f)
            {
                goto label_28;
            }
            
            val_29 = (Spine.MathUtils.Atan2(y:  val_16, x:  this.target.b)) - (Spine.MathUtils.Atan2(y:  val_17, x:  this.target.a));
            if(val_29 <= 3.141593f)
            {
                goto label_31;
            }
            
            val_30 = -6.283185f;
            goto label_32;
            label_28:
            if(val_22 == 0)
            {
                goto label_33;
            }
            
            if((-17310996) != 0)
            {
                goto label_34;
            }
            
            label_31:
            if(val_29 >= 0)
            {
                goto label_36;
            }
            
            val_30 = 6.283185f;
            label_32:
            val_29 = val_29 + val_30;
            label_36:
            float val_27 = -1.570796f;
            val_27 = val_29 + val_27;
            val_27 = val_3 + val_27;
            val_29 = this.shearMix * val_27;
            float val_12 = (mem[-74351394354111652]) * (mem[-74351394354111652]);
            val_12 = val_12 + ((mem[-74351394354111640]) * (mem[-74351394354111640]));
            val_26 = val_29 + (Spine.MathUtils.Atan2(y:  mem[-74351394354111640], x:  mem[-74351394354111652]));
            if((mem[-74351394354111652]) >= _TYPE_MAX_)
            {
                    val_23 = val_12;
            }
            
            float val_14 = Spine.MathUtils.Cos(radians:  val_26);
            val_14 = val_23 * val_14;
            mem2[-74351394354111652] = val_14;
            float val_15 = Spine.MathUtils.Sin(radians:  val_26);
            val_20 = val_20;
            val_21 = val_21;
            val_15 = val_23 * val_15;
            mem2[-74351394354111640] = val_15;
            label_34:
            mem2[-74351394354111660] = 0;
            label_33:
            val_28 = val_28 + 1;
            if(val_28 < X22)
            {
                goto label_43;
            }
        
        }
        private void ApplyAbsoluteLocal()
        {
            float val_3;
            if(this.target.appliedValid != true)
            {
                    this.target.UpdateAppliedTransform();
            }
            
            if(W22 < 1)
            {
                    return;
            }
            
            var val_16 = 0;
            var val_1 = X23 + 32;
            do
            {
                if(((X23 + 32) + 0 + 104) == 0)
            {
                    (X23 + 32) + 0.UpdateAppliedTransform();
            }
            
                float val_6 = (X23 + 32) + 0 + 84;
                if(this.rotateMix != 0f)
            {
                    float val_2 = this.target.arotation;
                float val_3 = this.data.offsetRotation;
                val_2 = val_2 - val_6;
                val_2 = val_2 + val_3;
                val_3 = val_2 / (-360f);
                double val_4 = (double)val_3;
                val_4 = val_4 + 16384.5;
                val_4 = (val_4 == Infinity) ? (-val_4) : (val_4);
                int val_5 = (int)val_4;
                val_5 = 16384 - val_5;
                val_5 = val_5 * 360;
                val_2 = val_2 - (float)val_5;
                val_2 = this.rotateMix * val_2;
                val_6 = val_6 + val_2;
            }
            
                val_3 = mem[(X23 + 32) + 0 + 76];
                val_3 = (X23 + 32) + 0 + 76;
                if(this.translateMix != 0f)
            {
                    float val_7 = this.target.ax;
                val_7 = val_7 - val_3;
                val_7 = val_7 + this.data.offsetX;
                val_7 = V11.2S * val_7;
                val_3 = val_3 + val_7;
            }
            
                float val_9 = (X23 + 32) + 0 + 88;
                float val_11 = (X23 + 32) + 0 + 88 + 4;
                if(this.scaleMix > 0f)
            {
                    if(val_9 > (1E-05f))
            {
                    float val_8 = this.target.ascaleX;
                val_8 = val_8 - val_9;
                val_8 = val_8 + this.data.offsetScaleX;
                val_8 = this.scaleMix * val_8;
                val_8 = val_9 + val_8;
                val_9 = val_8 / val_9;
            }
            
                if(val_11 > (1E-05f))
            {
                    float val_10 = this.target.ascaleY;
                val_10 = val_10 - val_11;
                val_10 = val_10 + this.data.offsetScaleY;
                val_10 = this.scaleMix * val_10;
                val_10 = val_11 + val_10;
                val_11 = val_10 / val_11;
            }
            
            }
            
                if(this.shearMix > 0f)
            {
                    float val_12 = this.target.ashearY;
                float val_13 = this.data.offsetShearY;
                val_12 = val_12 - ((X23 + 32) + 0 + 100);
                val_12 = val_12 + val_13;
                val_13 = val_12 / (-360f);
                double val_14 = (double)val_13;
                val_14 = val_14 + 16384.5;
                val_14 = (val_14 == Infinity) ? (-val_14) : (val_14);
                int val_15 = (int)val_14;
                val_15 = 16384 - val_15;
                val_15 = val_15 * 360;
                val_12 = val_12 - (float)val_15;
                val_12 = this.shearMix * val_12;
                val_12 = ((X23 + 32) + 0 + 72) + val_12;
                mem2[0] = val_12;
            }
            
                (X23 + 32) + 0.UpdateWorldTransform(x:  val_3, y:  val_3, rotation:  val_6, scaleX:  val_9, scaleY:  val_11, shearX:  (X23 + 32) + 0 + 96, shearY:  (X23 + 32) + 0 + 100);
                val_16 = val_16 + 1;
            }
            while(val_16 < W22);
        
        }
        private void ApplyRelativeLocal()
        {
            float val_3;
            if(this.target.appliedValid != true)
            {
                    this.target.UpdateAppliedTransform();
            }
            
            if(W22 < 1)
            {
                    return;
            }
            
            var val_11 = 0;
            var val_1 = X23 + 32;
            do
            {
                if(((X23 + 32) + 0 + 104) == 0)
            {
                    (X23 + 32) + 0.UpdateAppliedTransform();
            }
            
                float val_3 = (X23 + 32) + 0 + 84;
                if(this.rotateMix != 0f)
            {
                    float val_2 = this.target.arotation;
                val_2 = val_2 + this.data.offsetRotation;
                val_2 = this.rotateMix * val_2;
                val_3 = val_3 + val_2;
            }
            
                val_3 = mem[(X23 + 32) + 0 + 76];
                val_3 = (X23 + 32) + 0 + 76;
                if(this.translateMix != 0f)
            {
                    float val_4 = this.target.ax;
                val_4 = val_4 + this.data.offsetX;
                val_4 = V11.2S * val_4;
                val_3 = val_3 + val_4;
            }
            
                float val_6 = (X23 + 32) + 0 + 88;
                float val_8 = (X23 + 32) + 0 + 88 + 4;
                if(this.scaleMix > 0f)
            {
                    if(val_6 > (1E-05f))
            {
                    float val_5 = this.target.ascaleX;
                val_5 = val_5 + (-1f);
                val_5 = val_5 + this.data.offsetScaleX;
                val_5 = this.scaleMix * val_5;
                val_5 = val_5 + 1f;
                val_6 = val_6 * val_5;
            }
            
                if(val_8 > (1E-05f))
            {
                    float val_7 = this.target.ascaleY;
                val_7 = val_7 + (-1f);
                val_7 = val_7 + this.data.offsetScaleY;
                val_7 = this.scaleMix * val_7;
                val_7 = val_7 + 1f;
                val_8 = val_8 * val_7;
            }
            
            }
            
                float val_10 = (X23 + 32) + 0 + 100;
                if(this.shearMix > 0f)
            {
                    float val_9 = this.target.ashearY;
                val_9 = val_9 + this.data.offsetShearY;
                val_9 = this.shearMix * val_9;
                val_10 = val_10 + val_9;
            }
            
                (X23 + 32) + 0.UpdateWorldTransform(x:  val_3, y:  val_3, rotation:  val_3, scaleX:  val_6, scaleY:  val_8, shearX:  (X23 + 32) + 0 + 96, shearY:  val_10);
                val_11 = val_11 + 1;
            }
            while(val_11 < W22);
        
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

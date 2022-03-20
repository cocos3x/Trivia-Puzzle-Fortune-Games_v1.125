using UnityEngine;

namespace Spine
{
    public class Skeleton
    {
        // Fields
        internal Spine.SkeletonData data;
        internal Spine.ExposedList<Spine.Bone> bones;
        internal Spine.ExposedList<Spine.Slot> slots;
        internal Spine.ExposedList<Spine.Slot> drawOrder;
        internal Spine.ExposedList<Spine.IkConstraint> ikConstraints;
        internal Spine.ExposedList<Spine.TransformConstraint> transformConstraints;
        internal Spine.ExposedList<Spine.PathConstraint> pathConstraints;
        internal Spine.ExposedList<Spine.IUpdatable> updateCache;
        internal Spine.ExposedList<Spine.Bone> updateCacheReset;
        internal Spine.Skin skin;
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        internal float time;
        internal bool flipX;
        internal bool flipY;
        internal float x;
        internal float y;
        
        // Properties
        public Spine.SkeletonData Data { get; }
        public Spine.ExposedList<Spine.Bone> Bones { get; }
        public Spine.ExposedList<Spine.IUpdatable> UpdateCacheList { get; }
        public Spine.ExposedList<Spine.Slot> Slots { get; }
        public Spine.ExposedList<Spine.Slot> DrawOrder { get; }
        public Spine.ExposedList<Spine.IkConstraint> IkConstraints { get; }
        public Spine.ExposedList<Spine.PathConstraint> PathConstraints { get; }
        public Spine.ExposedList<Spine.TransformConstraint> TransformConstraints { get; }
        public Spine.Skin Skin { get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
        public float Time { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool FlipX { get; set; }
        public bool FlipY { get; set; }
        public Spine.Bone RootBone { get; }
        
        // Methods
        public Spine.SkeletonData get_Data()
        {
            return (Spine.SkeletonData)this.data;
        }
        public Spine.ExposedList<Spine.Bone> get_Bones()
        {
            return (Spine.ExposedList<Spine.Bone>)this.bones;
        }
        public Spine.ExposedList<Spine.IUpdatable> get_UpdateCacheList()
        {
            return (Spine.ExposedList<Spine.IUpdatable>)this.updateCache;
        }
        public Spine.ExposedList<Spine.Slot> get_Slots()
        {
            return (Spine.ExposedList<Spine.Slot>)this.slots;
        }
        public Spine.ExposedList<Spine.Slot> get_DrawOrder()
        {
            return (Spine.ExposedList<Spine.Slot>)this.drawOrder;
        }
        public Spine.ExposedList<Spine.IkConstraint> get_IkConstraints()
        {
            return (Spine.ExposedList<Spine.IkConstraint>)this.ikConstraints;
        }
        public Spine.ExposedList<Spine.PathConstraint> get_PathConstraints()
        {
            return (Spine.ExposedList<Spine.PathConstraint>)this.pathConstraints;
        }
        public Spine.ExposedList<Spine.TransformConstraint> get_TransformConstraints()
        {
            return (Spine.ExposedList<Spine.TransformConstraint>)this.transformConstraints;
        }
        public Spine.Skin get_Skin()
        {
            return (Spine.Skin)this.skin;
        }
        public void set_Skin(Spine.Skin value)
        {
            this.skin = value;
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
        public float get_Time()
        {
            return (float)this.time;
        }
        public void set_Time(float value)
        {
            this.time = value;
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
        public bool get_FlipX()
        {
            return (bool)this.flipX;
        }
        public void set_FlipX(bool value)
        {
            this.flipX = value;
        }
        public bool get_FlipY()
        {
            return (bool)this.flipY;
        }
        public void set_FlipY(bool value)
        {
            this.flipY = value;
        }
        public Spine.Bone get_RootBone()
        {
            var val_1;
            if(W9 != 0)
            {
                    return (Spine.Bone)val_1;
            }
            
            val_1 = 0;
            return (Spine.Bone)val_1;
        }
        public Skeleton(Spine.SkeletonData data)
        {
            Spine.BoneData val_5;
            var val_6;
            Spine.ExposedList<Spine.Bone> val_35;
            var val_36;
            var val_37;
            this.updateCache = new Spine.ExposedList<Spine.IUpdatable>();
            Spine.ExposedList<Spine.Bone> val_2 = null;
            val_35 = val_2;
            val_2 = new Spine.ExposedList<Spine.Bone>();
            this.updateCacheReset = val_35;
            this.r = 1;
            if(data == null)
            {
                    throw new System.ArgumentNullException(paramName:  "data", message:  "data cannot be null.");
            }
            
            this.data = data;
            this.bones = new Spine.ExposedList<Spine.Bone>(capacity:  1700639200);
            ExposedList.Enumerator<T> val_4 = data.bones.GetEnumerator();
            label_14:
            if(val_6.MoveNext() == false)
            {
                goto label_4;
            }
            
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 32) != 0)
            {
                    if(this.bones == null)
            {
                    throw new NullReferenceException();
            }
            
                if(this.bones == null)
            {
                    throw new NullReferenceException();
            }
            
                Spine.ExposedList<Spine.Bone> val_8 = this.bones + ((val_5 + 32 + 16) << 3);
                Spine.Bone val_9 = null;
                val_35 = val_9;
                val_9 = new Spine.Bone(data:  val_5, skeleton:  this, parent:  X23);
                if(X23 == 0)
            {
                    throw new NullReferenceException();
            }
            
                if((X23 + 40) == 0)
            {
                    throw new NullReferenceException();
            }
            
                X23 + 40.Add(item:  val_9);
            }
            else
            {
                    Spine.Bone val_10 = null;
                val_35 = val_10;
                val_10 = new Spine.Bone(data:  val_5, skeleton:  this, parent:  0);
            }
            
            if(this.bones == null)
            {
                    throw new NullReferenceException();
            }
            
            this.bones.Add(item:  val_10);
            goto label_14;
            label_4:
            val_6.Dispose();
            this.slots = new Spine.ExposedList<Spine.Slot>(capacity:  1700639200);
            this.drawOrder = new Spine.ExposedList<Spine.Slot>(capacity:  1700639200);
            ExposedList.Enumerator<T> val_13 = data.slots.GetEnumerator();
            label_26:
            if(val_6.MoveNext() == false)
            {
                goto label_18;
            }
            
            Spine.ExposedList<Spine.Bone> val_33 = this.bones;
            if(val_33 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_33 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 32 + 16) >= W10)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_33 = val_33 + ((val_5 + 32 + 16) << 3);
            Spine.Slot val_15 = null;
            val_35 = val_15;
            val_15 = new Spine.Slot(data:  val_5, bone:  1152921504864034816);
            if(this.slots == null)
            {
                    throw new NullReferenceException();
            }
            
            this.slots.Add(item:  val_15);
            if(this.drawOrder == null)
            {
                    throw new NullReferenceException();
            }
            
            this.drawOrder.Add(item:  val_15);
            goto label_26;
            label_18:
            val_6.Dispose();
            this.ikConstraints = new Spine.ExposedList<Spine.IkConstraint>(capacity:  1700639200);
            ExposedList.Enumerator<T> val_17 = data.ikConstraints.GetEnumerator();
            label_31:
            if(val_6.MoveNext() == false)
            {
                goto label_29;
            }
            
            val_35 = this.ikConstraints;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35.Add(item:  new Spine.IkConstraint(data:  val_5, skeleton:  this));
            goto label_31;
            label_29:
            val_6.Dispose();
            if(0 != 1)
            {
                    var val_20 = (489 == 489) ? 1 : 0;
                val_20 = ((0 >= 0) ? 1 : 0) & val_20;
                val_36 = 0 - val_20;
            }
            else
            {
                    val_36 = 0;
            }
            
            this.transformConstraints = new Spine.ExposedList<Spine.TransformConstraint>(capacity:  1700639200);
            ExposedList.Enumerator<T> val_23 = data.transformConstraints.GetEnumerator();
            label_38:
            if(val_6.MoveNext() == false)
            {
                goto label_36;
            }
            
            val_35 = this.transformConstraints;
            if(val_35 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_35.Add(item:  new Spine.TransformConstraint(data:  val_5, skeleton:  this));
            goto label_38;
            label_36:
            val_6.Dispose();
            if(1 != 1)
            {
                    var val_26 = (579 == 579) ? 1 : 0;
                val_26 = ((1 >= 0) ? 1 : 0) & val_26;
                val_26 = 1 - val_26;
                val_26 = val_26 + 1;
                val_37 = (long)val_26;
            }
            else
            {
                    val_37 = 0;
            }
            
            this.pathConstraints = new Spine.ExposedList<Spine.PathConstraint>(capacity:  1700639200);
            ExposedList.Enumerator<T> val_29 = data.pathConstraints.GetEnumerator();
            label_45:
            if(0.MoveNext() == false)
            {
                goto label_43;
            }
            
            Spine.PathConstraint val_31 = null;
            val_35 = val_31;
            val_31 = new Spine.PathConstraint(data:  0, skeleton:  this);
            if(this.pathConstraints == null)
            {
                    throw new NullReferenceException();
            }
            
            this.pathConstraints.Add(item:  val_31);
            goto label_45;
            label_43:
            0.Dispose();
            this.UpdateCache();
            this.UpdateWorldTransform();
        }
        public void UpdateCache()
        {
            this.updateCache.Clear(clearArray:  true);
            this.updateCacheReset.Clear(clearArray:  true);
            if(1152921510602653856 >= 1)
            {
                    var val_4 = 0;
                do
            {
                var val_1 = X10 + 0;
                var val_5 = (X10 + 0) + 32;
                val_4 = val_4 + 1;
                mem2[0] = 0;
            }
            while(val_4 < 1152921510602653856);
            
            }
            
            var val_3 = (W25 + W24) + W26;
            if(val_3 < 1)
            {
                goto label_12;
            }
            
            var val_9 = 0;
            label_37:
            if(W24 < 1)
            {
                goto label_13;
            }
            
            var val_6 = 0;
            val_5 = val_5 + 32;
            label_19:
            if((((X10 + 0) + 32 + 32) + 0 + 16 + 24) == val_9)
            {
                goto label_18;
            }
            
            val_6 = val_6 + 1;
            if(val_6 < W24)
            {
                goto label_19;
            }
            
            label_13:
            if(W25 < 1)
            {
                goto label_20;
            }
            
            var val_7 = 0;
            val_5 = val_5 + 32;
            label_26:
            if(((((X10 + 0) + 32 + 32) + 32) + 0 + 16 + 24) == val_9)
            {
                goto label_25;
            }
            
            val_7 = val_7 + 1;
            if(val_7 < W25)
            {
                goto label_26;
            }
            
            label_20:
            if(W26 < 1)
            {
                goto label_36;
            }
            
            var val_8 = 0;
            val_5 = val_5 + 32;
            label_33:
            if((((((X10 + 0) + 32 + 32) + 32) + 32) + 0 + 16 + 24) == val_9)
            {
                goto label_32;
            }
            
            val_8 = val_8 + 1;
            if(val_8 < W26)
            {
                goto label_33;
            }
            
            goto label_36;
            label_18:
            this.SortIkConstraint(constraint:  ((X10 + 0) + 32 + 32) + 0);
            goto label_36;
            label_25:
            this.SortTransformConstraint(constraint:  (((X10 + 0) + 32 + 32) + 32) + 0);
            goto label_36;
            label_32:
            this.SortPathConstraint(constraint:  ((((X10 + 0) + 32 + 32) + 32) + 32) + 0);
            label_36:
            val_9 = val_9 + 1;
            if(val_9 < val_3)
            {
                goto label_37;
            }
            
            label_12:
            if(this.ikConstraints < 1)
            {
                    return;
            }
            
            var val_10 = 0;
            do
            {
                val_8 = val_8 + 0;
                this.SortBone(bone:  (0 + 0) + 32);
                val_10 = val_10 + 1;
            }
            while(val_10 < this.ikConstraints);
        
        }
        private void SortIkConstraint(Spine.IkConstraint constraint)
        {
            Spine.ExposedList<Spine.IUpdatable> val_2;
            this.SortBone(bone:  constraint.target);
            this.SortBone(bone:  0);
            if()
            {
                    val_2 = this.updateCache;
            }
            else
            {
                    val_2 = this;
                var val_1 = 38021 + 0;
                if((this.updateCache.Contains(item:  (38021 + 0) + 32)) != true)
            {
                    this.updateCacheReset.Add(item:  (38021 + 0) + 32);
            }
            
            }
            
            null.Add(item:  constraint);
            Spine.Skeleton.SortReset(bones:  mem[-2305843009213693912]);
            mem2[0] = 1;
        }
        private void SortPathConstraint(Spine.PathConstraint constraint)
        {
            Spine.IUpdatable val_1;
            Spine.Slot val_2;
            Spine.SkeletonData val_3;
            val_1 = constraint;
            val_2 = constraint.target;
            if(this.skin != null)
            {
                    this.SortPathConstraintAttachment(skin:  this.skin, slotIndex:  constraint.target.data.index, slotBone:  constraint.target.bone);
            }
            
            val_3 = this.data;
            if((this.data.defaultSkin != null) && (this.data.defaultSkin != this.skin))
            {
                    this.SortPathConstraintAttachment(skin:  this.data.defaultSkin, slotIndex:  constraint.target.data.index, slotBone:  constraint.target.bone);
                val_3 = this.data;
            }
            
            if(W24 < 1)
            {
                goto label_15;
            }
            
            var val_1 = 0;
            label_16:
            this.SortPathConstraintAttachment(skin:  Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg, slotIndex:  constraint.target.data.index, slotBone:  constraint.target.bone);
            val_1 = val_1 + 1;
            if(val_1 < X24)
            {
                    if(this.data != null)
            {
                goto label_16;
            }
            
            }
            
            label_15:
            if(constraint.target.attachment != null)
            {
                    this.SortPathConstraintAttachment(attachment:  constraint.target.attachment, slotBone:  constraint.target.bone);
            }
            
            if(constraint.target.data.index >= 1)
            {
                    do
            {
                this.SortBone(bone:  Spine.PathAttachment.__il2cppRuntimeField_byval_arg);
                val_2 = 0 + 1;
            }
            while(val_2 < constraint.target.data.index);
            
            }
            
            this.updateCache.Add(item:  val_1);
            if(constraint.target.data.index < 1)
            {
                    return;
            }
            
            do
            {
                Spine.Skeleton.SortReset(bones:  System.Byte[].__il2cppRuntimeField_28);
                val_1 = 0 + 1;
            }
            while(val_1 < constraint.target.data.index);
            
            if(constraint.target.data.index < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                val_2 = val_2 + 1;
                mem2[0] = 1;
            }
            while(val_2 < constraint.target.data.index);
        
        }
        private void SortTransformConstraint(Spine.TransformConstraint constraint)
        {
            Spine.IUpdatable val_3;
            Spine.TransformConstraint val_4 = constraint;
            this.SortBone(bone:  constraint.target);
            bool val_3 = constraint.data.local;
            if(val_3 == false)
            {
                goto label_4;
            }
            
            if(W23 < 1)
            {
                goto label_14;
            }
            
            var val_4 = 0;
            do
            {
                val_3 = val_3 + 0;
                val_3 = mem[(constraint.data.local + 0) + 32];
                val_3 = (constraint.data.local + 0) + 32;
                this.SortBone(bone:  (constraint.data.local + 0) + 32 + 32);
                if((this.updateCache.Contains(item:  val_3)) != true)
            {
                    this.updateCacheReset.Add(item:  val_3);
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W23);
            
            goto label_14;
            label_4:
            if(W23 >= 1)
            {
                    do
            {
                val_3 = val_3 + 0;
                this.SortBone(bone:  (constraint.data.local + 0) + 32);
                val_3 = 0 + 1;
            }
            while(val_3 < X23);
            
            }
            
            label_14:
            this.updateCache.Add(item:  val_4 = constraint);
            if(W23 < 1)
            {
                    return;
            }
            
            do
            {
                Spine.Skeleton.SortReset(bones:  System.Byte[].__il2cppRuntimeField_28);
                val_4 = 0 + 1;
            }
            while(val_4 < W23);
            
            if(W23 < 1)
            {
                    return;
            }
            
            var val_5 = 0;
            do
            {
                var val_2 = X10 + 0;
                val_5 = val_5 + 1;
                mem2[0] = 1;
            }
            while(val_5 < W23);
        
        }
        private void SortPathConstraintAttachment(Spine.Skin skin, int slotIndex, Spine.Bone slotBone)
        {
            Dictionary.Enumerator<TKey, TValue> val_1 = skin.attachments.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(0 != slotIndex)
            {
                goto label_5;
            }
            
            this.SortPathConstraintAttachment(attachment:  0, slotBone:  slotBone);
            goto label_5;
            label_3:
            0.Dispose();
        }
        private void SortPathConstraintAttachment(Spine.Attachment attachment, Spine.Bone slotBone)
        {
            Spine.Bone val_3 = slotBone;
            if(attachment == null)
            {
                    return;
            }
        
        }
        private void SortBone(Spine.Bone bone)
        {
            if(bone.sorted != false)
            {
                    return;
            }
            
            bone.sorted = true;
            this.updateCache.Add(item:  bone);
        }
        private static void SortReset(Spine.ExposedList<Spine.Bone> bones)
        {
            if(W19 < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            var val_1 = X20 + 32;
            do
            {
                val_2 = val_2 + 1;
                mem2[0] = 0;
            }
            while(val_2 < W19);
        
        }
        public void UpdateWorldTransform()
        {
            var val_4;
            var val_5;
            val_4 = this;
            if(true >= 1)
            {
                    var val_3 = 0;
                Spine.ExposedList<Spine.Bone> val_1 = this.updateCacheReset + 32;
                do
            {
                val_3 = val_3 + 1;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_4C = Spine.ExposedList<T>.__il2cppRuntimeField_this_arg;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_5C = Spine.ExposedList<T>.__il2cppRuntimeField_element_class;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_64 = Spine.ExposedList<T>.__il2cppRuntimeField_castClass;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_68 = 1;
            }
            while(val_3 < true);
            
            }
            
            if(41934848 < 1)
            {
                    return;
            }
            
            var val_7 = 0;
            label_16:
            var val_2 = X21 + 0;
            val_4 = mem[(X21 + 0) + 32];
            val_4 = (X21 + 0) + 32;
            var val_6 = val_4;
            if(((X21 + 0) + 32 + 294) == 0)
            {
                goto label_15;
            }
            
            var val_4 = (X21 + 0) + 32 + 176;
            var val_5 = 0;
            val_4 = val_4 + 8;
            label_14:
            if((((X21 + 0) + 32 + 176 + 8) + -8) == null)
            {
                goto label_13;
            }
            
            val_5 = val_5 + 1;
            val_4 = val_4 + 16;
            if(val_5 < ((X21 + 0) + 32 + 294))
            {
                goto label_14;
            }
            
            goto label_15;
            label_13:
            val_6 = val_6 + ((((X21 + 0) + 32 + 176 + 8)) << 4);
            val_5 = val_6 + 304;
            label_15:
            val_4.Update();
            val_7 = val_7 + 1;
            if(val_7 < 41934848)
            {
                goto label_16;
            }
        
        }
        public void SetToSetupPose()
        {
            this.SetBonesToSetupPose();
            this.SetSlotsToSetupPose();
        }
        public void SetBonesToSetupPose()
        {
            if(W20 >= 1)
            {
                    var val_5 = 0;
                var val_1 = X21 + 32;
                do
            {
                (X21 + 32) + 0.SetToSetupPose();
                val_5 = val_5 + 1;
            }
            while(val_5 < W20);
            
            }
            
            if((X21 + 24) >= 1)
            {
                    var val_6 = 0;
                Spine.ExposedList<Spine.IkConstraint> val_2 = this.ikConstraints + 32;
                do
            {
                val_6 = val_6 + 1;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_2C = ExposedList<T>.__il2cppRuntimeField_30;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_28 = ExposedList<T>.__il2cppRuntimeField_34;
            }
            while(val_6 < (X21 + 24));
            
            }
            
            if((X21 + 24) >= 1)
            {
                    var val_7 = 0;
                Spine.ExposedList<Spine.TransformConstraint> val_3 = this.transformConstraints + 32;
                do
            {
                val_7 = val_7 + 1;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_28 = ExposedList<T>.__il2cppRuntimeField_30;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_2C = ExposedList<T>.__il2cppRuntimeField_34;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_30 = ExposedList<T>.__il2cppRuntimeField_38;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_34 = ExposedList<T>.__il2cppRuntimeField_3C;
            }
            while(val_7 < (X21 + 24));
            
            }
            
            if((X21 + 24) < 1)
            {
                    return;
            }
            
            var val_8 = 0;
            Spine.ExposedList<Spine.PathConstraint> val_4 = this.pathConstraints + 32;
            do
            {
                val_8 = val_8 + 1;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_28 = ExposedList<T>.__il2cppRuntimeField_40;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_2C = ExposedList<T>.__il2cppRuntimeField_44;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_30 = ExposedList<T>.__il2cppRuntimeField_48;
                typeof(Spine.ExposedList<T>).__il2cppRuntimeField_34 = ExposedList<T>.__il2cppRuntimeField_4C;
            }
            while(val_8 < (X21 + 24));
        
        }
        public void SetSlotsToSetupPose()
        {
            var val_1;
            Spine.ExposedList<Spine.Slot> val_2;
            val_1 = this;
            val_2 = this.slots;
            this.drawOrder.Clear(clearArray:  true);
            if(W22 < 1)
            {
                    return;
            }
            
            var val_1 = 0;
            do
            {
                this.drawOrder.Add(item:  183);
                val_1 = val_1 + 1;
            }
            while(val_1 < X22);
            
            if(val_1 < 1)
            {
                    return;
            }
            
            do
            {
                183.SetToSetupPose();
                val_2 = 0 + 1;
            }
            while(val_2 < val_1);
        
        }
        public Spine.Bone FindBone(string boneName)
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
                if((System.String.op_Equality(a:  (X22 + 32) + 0 + 16 + 24, b:  boneName)) == true)
            {
                    return (Spine.Bone)val_5;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < 41934848);
            
            }
            
            val_5 = 0;
            return (Spine.Bone)val_5;
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
                if((System.String.op_Equality(a:  (X22 + 32) + 0 + 16 + 24, b:  boneName)) == true)
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
        public Spine.Slot FindSlot(string slotName)
        {
            var val_4;
            var val_5;
            if(slotName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "slotName", message:  "slotName cannot be null.");
            }
            
            if(41934848 >= 1)
            {
                    val_4 = 0;
                var val_1 = X22 + 32;
                do
            {
                val_5 = mem[(X22 + 32) + 0];
                val_5 = (X22 + 32) + 0;
                if((System.String.op_Equality(a:  (X22 + 32) + 0 + 16 + 24, b:  slotName)) == true)
            {
                    return (Spine.Slot)val_5;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < 41934848);
            
            }
            
            val_5 = 0;
            return (Spine.Slot)val_5;
        }
        public int FindSlotIndex(string slotName)
        {
            var val_4;
            if(slotName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "slotName", message:  "slotName cannot be null.");
            }
            
            if(41934848 >= 1)
            {
                    val_4 = 0;
                var val_1 = X22 + 32;
                do
            {
                if(((X22 + 32) + 0 + 16 + 24.Equals(value:  slotName)) == true)
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
        public void SetSkin(string skinName)
        {
            Spine.Skin val_1 = this.data.FindSkin(skinName:  skinName);
            if(val_1 == null)
            {
                    throw new System.ArgumentException(message:  "Skin not found: "("Skin not found: ") + ???(???), paramName:  "skinName");
            }
            
            this.SetSkin(newSkin:  val_1);
        }
        public void SetSkin(Spine.Skin newSkin)
        {
            if(newSkin != null)
            {
                    if(this.skin != null)
            {
                    newSkin.AttachAll(skeleton:  this, oldSkin:  this.skin);
            }
            else
            {
                    if(W24 >= 1)
            {
                    var val_3 = 0;
                do
            {
                var val_1 = X8 + 0;
                if(((X8 + 0) + 32 + 16 + 72) != 0)
            {
                    Spine.Attachment val_2 = newSkin.GetAttachment(slotIndex:  0, name:  (X8 + 0) + 32 + 16 + 72);
                if(val_2 != null)
            {
                    (X8 + 0) + 32.Attachment = val_2;
            }
            
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < W24);
            
            }
            
            }
            
            }
            
            this.skin = newSkin;
        }
        public Spine.Attachment GetAttachment(string slotName, string attachmentName)
        {
            return this.GetAttachment(slotIndex:  this.data.FindSlotIndex(slotName:  slotName), attachmentName:  attachmentName);
        }
        public Spine.Attachment GetAttachment(int slotIndex, string attachmentName)
        {
            Spine.Skin val_3;
            if(attachmentName == null)
            {
                    throw new System.ArgumentNullException(paramName:  "attachmentName", message:  "attachmentName cannot be null.");
            }
            
            if(this.skin != null)
            {
                    Spine.Attachment val_1 = this.skin.GetAttachment(slotIndex:  slotIndex, name:  attachmentName);
                if(val_1 != null)
            {
                    return val_1;
            }
            
            }
            
            val_3 = this.data.defaultSkin;
            if(val_3 == null)
            {
                    return val_1;
            }
            
            return val_3.GetAttachment(slotIndex:  slotIndex, name:  attachmentName);
        }
        public void SetAttachment(string slotName, string attachmentName)
        {
            int val_7;
            string val_8;
            string val_9;
            Spine.Attachment val_10;
            val_8 = attachmentName;
            val_9 = slotName;
            bool val_7 = true;
            if(val_9 == null)
            {
                    throw new System.ArgumentNullException(paramName:  "slotName", message:  "slotName cannot be null.");
            }
            
            if(W25 < 1)
            {
                goto label_3;
            }
            
            val_7 = 0;
            label_9:
            val_7 = val_7 + 0;
            if((System.String.op_Equality(a:  (true + 0) + 32 + 16 + 24, b:  val_9)) == true)
            {
                goto label_8;
            }
            
            val_7 = val_7 + 1;
            if(val_7 < W25)
            {
                goto label_9;
            }
            
            label_3:
            label_12:
            val_9 = "Slot not found: "("Slot not found: ") + val_9;
            System.Exception val_3 = null;
            val_8 = val_3;
            val_3 = new System.Exception(message:  val_9);
            throw val_8;
            label_8:
            if(val_8 == null)
            {
                goto label_10;
            }
            
            Spine.Attachment val_4 = this.GetAttachment(slotIndex:  val_7, attachmentName:  val_3);
            val_10 = val_4;
            if(val_4 != null)
            {
                goto label_11;
            }
            
            string val_5 = "Attachment not found: "("Attachment not found: ") + val_3 + ", for slot: "(", for slot: ") + val_9;
            goto label_12;
            label_10:
            val_10 = 0;
            label_11:
            (true + 0) + 32.Attachment = val_10;
        }
        public Spine.IkConstraint FindIkConstraint(string constraintName)
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
                if((System.String.op_Equality(a:  (true + 0) + 32 + 16 + 16, b:  constraintName)) == true)
            {
                    return (Spine.IkConstraint)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.IkConstraint)val_3;
        }
        public Spine.TransformConstraint FindTransformConstraint(string constraintName)
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
                if((System.String.op_Equality(a:  (true + 0) + 32 + 16 + 16, b:  constraintName)) == true)
            {
                    return (Spine.TransformConstraint)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.TransformConstraint)val_3;
        }
        public Spine.PathConstraint FindPathConstraint(string constraintName)
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
                if(((true + 0) + 32 + 16 + 16.Equals(value:  constraintName)) == true)
            {
                    return (Spine.PathConstraint)val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < W22);
            
            }
            
            val_3 = 0;
            return (Spine.PathConstraint)val_3;
        }
        public void Update(float delta)
        {
            delta = this.time + delta;
            this.time = delta;
        }
        public void GetBounds(out float x, out float y, out float width, out float height, ref float[] vertexBuffer)
        {
            var val_5;
            var val_6;
            System.Single[] val_7;
            val_6 = this;
            val_7 = vertexBuffer;
            if(val_7 == null)
            {
                    val_7 = new float[8];
            }
            
            if(W28 >= 1)
            {
                    val_5 = 1152921504863449088;
                var val_5 = 0;
                do
            {
                val_6 = mem[mem[1152921510606387936] + 64];
                val_6 = mem[1152921510606387936] + 64;
                if(val_6 != 0)
            {
                    if((mem[1152921510606387936] + 64 + 48) > val_1.Length)
            {
                    float[] val_3 = new float[0];
                val_7 = val_3;
            }
            
                val_6.ComputeWorldVertices(slot:  mem[1152921510606387936], start:  0, count:  mem[1152921510606387936] + 64 + 48, worldVertices:  val_3, offset:  0, stride:  2);
            }
            
                val_5 = val_5 + 1;
            }
            while(val_5 < W28);
            
            }
            
            mem2[0] = 1325400064;
            mem2[0] = 1325400064;
            mem2[0] = -813694976;
            mem2[0] = -813694976;
            vertexBuffer = ;
        }
    
    }

}

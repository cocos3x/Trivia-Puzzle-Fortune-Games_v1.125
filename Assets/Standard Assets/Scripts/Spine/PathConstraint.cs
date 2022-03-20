using UnityEngine;

namespace Spine
{
    public class PathConstraint : IConstraint, IUpdatable
    {
        // Fields
        private const int NONE = -1;
        private const int BEFORE = -2;
        private const int AFTER = -3;
        internal Spine.PathConstraintData data;
        internal Spine.ExposedList<Spine.Bone> bones;
        internal Spine.Slot target;
        internal float position;
        internal float spacing;
        internal float rotateMix;
        internal float translateMix;
        internal Spine.ExposedList<float> spaces;
        internal Spine.ExposedList<float> positions;
        internal Spine.ExposedList<float> world;
        internal Spine.ExposedList<float> curves;
        internal Spine.ExposedList<float> lengths;
        internal float[] segments;
        
        // Properties
        public int Order { get; }
        public float Position { get; set; }
        public float Spacing { get; set; }
        public float RotateMix { get; set; }
        public float TranslateMix { get; set; }
        public Spine.ExposedList<Spine.Bone> Bones { get; }
        public Spine.Slot Target { get; set; }
        public Spine.PathConstraintData Data { get; }
        
        // Methods
        public int get_Order()
        {
            if(this.data != null)
            {
                    return (int)this.data.order;
            }
            
            throw new NullReferenceException();
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
        public Spine.ExposedList<Spine.Bone> get_Bones()
        {
            return (Spine.ExposedList<Spine.Bone>)this.bones;
        }
        public Spine.Slot get_Target()
        {
            return (Spine.Slot)this.target;
        }
        public void set_Target(Spine.Slot value)
        {
            this.target = value;
        }
        public Spine.PathConstraintData get_Data()
        {
            return (Spine.PathConstraintData)this.data;
        }
        public PathConstraint(Spine.PathConstraintData data, Spine.Skeleton skeleton)
        {
            string val_15;
            string val_16;
            this.spaces = new Spine.ExposedList<System.Single>();
            this.positions = new Spine.ExposedList<System.Single>();
            this.world = new Spine.ExposedList<System.Single>();
            this.curves = new Spine.ExposedList<System.Single>();
            this.lengths = new Spine.ExposedList<System.Single>();
            this.segments = new float[10];
            val_7 = new System.Object();
            if(data == null)
            {
                goto label_1;
            }
            
            if(val_7 == null)
            {
                goto label_2;
            }
            
            this.data = data;
            this.bones = new Spine.ExposedList<Spine.Bone>(capacity:  1692675872);
            ExposedList.Enumerator<T> val_9 = data.bones.GetEnumerator();
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
            
            this.bones.Add(item:  val_7.FindBone(boneName:  9733424));
            goto label_8;
            label_5:
            0.Dispose();
            this.target = val_7.FindSlot(slotName:  data.target.name);
            this.position = data.position;
            this.spacing = data.spacing;
            this.rotateMix = data.rotateMix;
            this.translateMix = data.translateMix;
            return;
            label_1:
            val_15 = "data";
            val_16 = "data cannot be null.";
            goto label_10;
            label_2:
            System.ArgumentNullException val_13 = null;
            val_15 = "skeleton";
            val_16 = "skeleton cannot be null.";
            label_10:
            val_13 = new System.ArgumentNullException(paramName:  val_15, message:  val_16);
            throw val_13;
        }
        public void Apply()
        {
            this.Update();
        }
        public void Update()
        {
            var val_34;
            var val_35;
            Spine.PathConstraintData val_37;
            int val_38;
            Spine.SpacingMode val_39;
            var val_40;
            float val_41;
            float val_42;
            float val_43;
            float val_45;
            float val_46;
            float val_47;
            float val_48;
            float val_49;
            float val_50;
            float val_51;
            float val_53;
            float val_56;
            val_35 = this;
            if(this.target.attachment == null)
            {
                    return;
            }
            
            Spine.PathAttachment val_1 = (((Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.PathAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? this.target.attachment : 0;
            if(this.rotateMix <= 0f)
            {
                    if(this.translateMix <= 0f)
            {
                    return;
            }
            
            }
            
            val_37 = this.data;
            int val_2 = (this.data.rotateMode != 0) ? (null + 1) : (null);
            val_39 = this.data.spacingMode;
            val_34 = 1152921510530537664;
            Spine.ExposedList<T> val_3 = this.spaces.Resize(newSize:  val_2);
            if((val_39 != 0) && (this.data.rotateMode != 2))
            {
                    if(val_2 >= 2)
            {
                    do
            {
                var val_4 = 9 - 8;
                var val_6 = 9 + 1;
                mem2[0] = this.spacing;
            }
            while((9 - 7) < (long)val_2);
            
            }
            
                val_40 = 0;
            }
            else
            {
                    if(this.data.rotateMode == 2)
            {
                    val_40 = this.lengths.Resize(newSize:  256655360);
            }
            else
            {
                    val_40 = 0;
            }
            
                val_2 = val_2 - 1;
                if(val_2 >= 1)
            {
                    var val_41 = 0;
                val_34 = X26 + 32;
                do
            {
                val_41 = mem[(X26 + 32) + 0 + 16 + 40];
                val_41 = (X26 + 32) + 0 + 16 + 40;
                float val_38 = (X26 + 32) + 0 + 108;
                float val_39 = (X26 + 32) + 0 + 120;
                float val_9 = val_41 * val_39;
                val_38 = (val_41 * val_38) * (val_41 * val_38);
                val_39 = val_9 * val_9;
                val_38 = val_38 + val_39;
                if(val_9 >= _TYPE_MAX_)
            {
                    val_42 = val_38;
            }
            
                if(this.data.rotateMode == 2)
            {
                    var val_40 = 11993091;
                val_40 = val_40 + 0;
                mem2[0] = val_41;
            }
            
                val_43 = this.spacing;
                if(val_39 == 0)
            {
                    val_43 = 0f;
                float val_11 = System.Math.Max(val1:  val_43, val2:  this.spacing + val_41);
            }
            
                var val_12 = val_41 + 1;
                val_11 = val_42 * val_11;
                var val_13 = val_1 + 0;
                val_41 = val_41 + 1;
                val_11 = val_11 / val_41;
                mem2[0] = val_11;
            }
            while(val_41 < val_2);
            
                val_37 = val_37;
            }
            
                val_38 = val_2;
            }
            
            System.Single[] val_17 = this.ComputeWorldPositions(path:  val_1, spacesCount:  val_38, tangents:  (this.data.rotateMode == 0) ? 1 : 0, percentPosition:  ((this.data + 48) == 1) ? 1 : 0, percentSpacing:  (val_39 == 2) ? 1 : 0);
            float val_42 = val_17[0];
            float val_43 = val_17[0];
            if((this.data + 60) == 0f)
            {
                    var val_18 = (this.data.rotateMode == 1) ? 1 : 0;
            }
            else
            {
                    float val_45 = this.target.bone.c;
                float val_44 = this.target.bone.d;
                val_44 = this.target.bone.a * val_44;
                val_45 = this.target.bone.b * val_45;
                val_45 = val_44 - val_45;
                var val_19 = (val_45 > 0f) ? 1 : 0;
                float val_46 = this.data + 60;
                val_46 = val_46 * (30113232 + this.target.bone.c > 0 ? 1 : 0);
            }
            
            if(null < 1)
            {
                    return;
            }
            
            val_45 = 3.141593f;
            val_35 = 1152921504864407552;
            var val_52 = 0;
            val_39 = X26 + 32;
            label_85:
            val_34 = mem[(X26 + 32) + 0];
            val_34 = (X26 + 32) + 0;
            float val_47 = (X26 + 32) + 0 + 116;
            var val_20 = 5 - 2;
            float val_22 = val_43 - ((X26 + 32) + 0 + 128);
            val_46 = this.translateMix * (val_42 - val_47);
            val_22 = this.translateMix * val_22;
            val_47 = val_47 + val_46;
            val_47 = ((X26 + 32) + 0 + 128) + val_22;
            mem2[0] = val_47;
            mem2[0] = val_47;
            var val_23 = val_20 + 1;
            val_48 = val_17[val_20 << 2];
            val_49 = val_17[(5 - 1) << 2];
            val_42 = val_48 - val_42;
            float val_25 = val_49 - val_43;
            if(this.data.rotateMode == 2)
            {
                    var val_48 = 11993091;
                val_48 = val_48 + 0;
                val_41 = mem[(11993091 + 0) + 32];
                val_41 = (11993091 + 0) + 32;
                if(val_41 != 0f)
            {
                    float val_26 = val_42 * val_42;
                float val_27 = val_25 * val_25;
                val_27 = val_26 + val_27;
                if(val_26 >= _TYPE_MAX_)
            {
                    val_50 = val_27;
            }
            
                val_50 = val_50 / val_41;
                float val_49 = (X26 + 32) + 0 + 108;
                val_50 = val_50 + (-1f);
                val_50 = this.rotateMix * val_50;
                val_47 = 1f;
                val_50 = val_50 + val_47;
                val_49 = val_49 * val_50;
                val_50 = ((X26 + 32) + 0 + 120) * val_50;
                mem2[0] = val_49;
                mem2[0] = val_50;
            }
            
            }
            
            if(this.rotateMix <= 0f)
            {
                goto label_61;
            }
            
            val_51 = mem[(X26 + 32) + 0 + 120];
            val_51 = (X26 + 32) + 0 + 120;
            if(this.data.rotateMode == 0)
            {
                goto label_62;
            }
            
            var val_28 = val_52 + 1;
            val_51 = mem[(System.Math.__il2cppRuntimeField_cctor_finished + 0) + 36];
            val_51 = (System.Math.__il2cppRuntimeField_cctor_finished + 0) + 36;
            if(val_51 != 0f)
            {
                goto label_66;
            }
            
            goto label_68;
            label_62:
            label_68:
            val_53 = val_17[(5 - 3) << 2];
            goto label_70;
            label_66:
            val_51 = val_25;
            val_53 = Spine.MathUtils.Atan2(y:  val_51, x:  val_42);
            label_70:
            float val_51 = (X26 + 32) + 0 + 108;
            val_41 = val_53 - (Spine.MathUtils.Atan2(y:  val_51, x:  val_51));
            if(0 != 0)
            {
                    float val_32 = Spine.MathUtils.Cos(radians:  val_41);
                float val_33 = Spine.MathUtils.Sin(radians:  val_41);
                float val_50 = (X26 + 32) + 0 + 16 + 40;
                float val_34 = ((X26 + 32) + 0 + 108) * val_32;
                val_47 = val_51 * val_33;
                val_33 = ((X26 + 32) + 0 + 108) * val_33;
                val_46 = val_51 * val_32;
                val_34 = val_34 - val_47;
                val_33 = val_46 + val_33;
                val_34 = val_34 * val_50;
                val_33 = val_33 * val_50;
                val_45 = val_45;
                val_50 = val_34 - val_42;
                val_33 = val_33 - val_25;
                val_50 = this.rotateMix * val_50;
                val_33 = this.rotateMix * val_33;
                val_48 = val_48 + val_50;
                val_49 = val_49 + val_33;
            }
            else
            {
                    val_41 = val_46 + val_41;
            }
            
            if(val_41 <= val_45)
            {
                goto label_80;
            }
            
            val_56 = -6.283185f;
            goto label_81;
            label_80:
            if(val_41 >= 0)
            {
                goto label_82;
            }
            
            val_56 = 6.283185f;
            label_81:
            val_41 = val_41 + val_56;
            label_82:
            val_42 = this.rotateMix * val_41;
            float val_35 = Spine.MathUtils.Cos(radians:  val_42);
            float val_36 = Spine.MathUtils.Sin(radians:  val_42);
            val_51 = val_51 - ((X26 + 32) + 0 + 120);
            val_36 = ((X26 + 32) + 0 + 108) + val_36;
            mem2[0] = val_51;
            mem2[0] = val_36;
            label_61:
            val_52 = val_52 + 1;
            var val_37 = 5 + 3;
            mem2[0] = 0;
            if(val_52 < null)
            {
                goto label_85;
            }
        
        }
        private float[] ComputeWorldPositions(Spine.PathAttachment path, int spacesCount, bool tangents, bool percentPosition, bool percentSpacing)
        {
            System.Single[] val_80;
            System.Single[] val_81;
            bool val_82;
            Spine.Slot val_83;
            System.Single[] val_84;
            bool val_85;
            int val_86;
            int val_87;
            float val_88;
            var val_89;
            float val_90;
            var val_91;
            float val_92;
            float val_93;
            float val_94;
            float val_95;
            float val_96;
            float val_97;
            float val_98;
            float val_99;
            float val_101;
            float val_102;
            var val_103;
            val_81 = percentSpacing;
            val_82 = percentPosition;
            val_83 = this.target;
            float val_84 = this.position;
            val_84 = 1152921510530537664;
            int val_1 = spacesCount + (spacesCount << 1);
            Spine.ExposedList<T> val_3 = this.positions.Resize(newSize:  val_1 + 2);
            val_85 = path.closed;
            int val_4 = spacesCount * 715827883;
            val_4 = val_4 >> 32;
            val_86 = val_4 + (val_4 >> 63);
            if(path.constantSpeed == false)
            {
                goto label_5;
            }
            
            if(val_85 == false)
            {
                goto label_6;
            }
            
            int val_6 = spacesCount + 2;
            val_80 = val_81;
            Spine.ExposedList<T> val_7 = this.world.Resize(newSize:  val_6);
            int val_8 = spacesCount - 2;
            path.ComputeWorldVertices(slot:  val_83, start:  2, count:  val_8, worldVertices:  val_82, offset:  0, stride:  2);
            path.ComputeWorldVertices(slot:  val_83, start:  0, count:  2, worldVertices:  val_82, offset:  val_8, stride:  2);
            mem2[0] = percentPosition + 32;
            int val_9 = spacesCount + 1;
            val_9 = val_82 + (val_9 << 2);
            val_87 = val_6;
            val_85 = val_85;
            mem2[0] = percentPosition + 36;
            val_84 = 1152921510530537664;
            val_81 = val_80;
            goto label_14;
            label_5:
            val_80 = path.lengths;
            int val_10 = (val_85 == false) ? (1 + 1) : 1;
            val_10 = val_86 - val_10;
            val_88 = val_80[val_10];
            val_84 = (val_82 != true) ? (val_84 * val_88) : (val_84);
            if((spacesCount >= 1) && (val_81 != false))
            {
                    Spine.ExposedList<System.Single> val_85 = this.spaces;
                var val_87 = 0;
                val_85 = val_85 + 32;
                do
            {
                float val_86 = (this.spaces + 32) + 0;
                val_86 = val_88 * val_86;
                mem2[0] = val_86;
                val_87 = val_87 + 1;
            }
            while(val_87 < (long)spacesCount);
            
            }
            
            val_81 = val_85;
            Spine.ExposedList<T> val_12 = this.world.Resize(newSize:  8);
            if(spacesCount < 1)
            {
                    return (System.Single[])val_1;
            }
            
            var val_92 = 0;
            goto label_60;
            label_44:
            val_89 = val_84;
            goto label_27;
            label_60:
            Spine.ExposedList<System.Single> val_15 = this.spaces + 0;
            val_84 = val_84 + ((this.spaces + 0) + 32);
            if(val_81 == false)
            {
                goto label_29;
            }
            
            float val_88 = val_84;
            var val_90 = 0;
            val_88 = (val_88 < 0) ? (val_88 + val_88) : (val_88);
            label_27:
            int val_17 = 2 + (val_90 * 6);
            label_32:
            float val_89 = val_80[val_90];
            if(val_88 <= val_89)
            {
                goto label_31;
            }
            
            val_90 = val_90 + 1;
            val_17 = val_17 + 6;
            if(val_90 < path.lengths.Length)
            {
                goto label_32;
            }
            
            label_31:
            if(val_90 != 0)
            {
                    float val_91 = val_80[val_90 - 1];
                val_88 = val_88 - val_91;
                val_89 = val_89 - val_91;
            }
            
            val_90 = val_88 / val_89;
            if(0 == val_90)
            {
                goto label_36;
            }
            
            if((val_81 == false) || (val_10 != val_90))
            {
                goto label_38;
            }
            
            path.ComputeWorldVertices(slot:  val_83, start:  spacesCount - 4, count:  4, worldVertices:  val_84, offset:  0, stride:  2);
            path.ComputeWorldVertices(slot:  val_83, start:  0, count:  4, worldVertices:  val_84, offset:  4, stride:  2);
            if((public Spine.ExposedList<T> Spine.ExposedList<System.Single>::Resize(int newSize)) != 0)
            {
                goto label_39;
            }
            
            label_29:
            if(val_84 >= 0)
            {
                goto label_41;
            }
            
            if(0 != 2)
            {
                    path.ComputeWorldVertices(slot:  val_83, start:  2, count:  4, worldVertices:  val_84, offset:  0, stride:  2);
            }
            
            Spine.PathConstraint.AddBeforePosition(p:  val_84, temp:  val_84, i:  0, output:  val_1, o:  0);
            goto label_46;
            label_41:
            if(val_84 <= val_88)
            {
                goto label_44;
            }
            
            if(0 != 3)
            {
                    path.ComputeWorldVertices(slot:  val_83, start:  spacesCount - 6, count:  4, worldVertices:  val_84, offset:  0, stride:  2);
            }
            
            Spine.PathConstraint.AddAfterPosition(p:  val_84 - val_88, temp:  val_84, i:  0, output:  val_1, o:  0);
            goto label_46;
            label_38:
            path.ComputeWorldVertices(slot:  val_83, start:  val_17, count:  8, worldVertices:  val_84, offset:  0, stride:  2);
            label_36:
            label_39:
            if(tangents != false)
            {
                    val_91 = 1;
            }
            else
            {
                    if(val_92 != 0)
            {
                    var val_20 = (((this.spaces + 0) + 32) == 0f) ? 1 : 0;
            }
            else
            {
                    val_91 = 0;
            }
            
            }
            
            Spine.PathConstraint.AddCurvePosition(p:  val_90, x1:  "Sharing violation", y1:  1152921510530537664.__il2cppRuntimeField_24, cx1:  public System.String[] System.Text.RegularExpressions.Regex::Split(string input, int count, int startat), cy1:  1152921510530537664.__il2cppRuntimeField_2C, cx2:  public ExposedList.Enumerator<T> Spine.ExposedList<Spine.Animation>::GetEnumerator(), cy2:  1152921510530537664.__il2cppRuntimeField_34, x2:  System.Int32 System.Array::InternalArray__IndexOf<System.Collections.Generic.KeyValuePair<System.Int32, System.Int64>>(System.Collections.Generic.KeyValuePair<System.Int32, System.Int64> item), y2:  1152921510530537664.__il2cppRuntimeField_3C, output:  val_1, o:  0, tangents:  false);
            label_46:
            val_92 = val_92 + 1;
            val_82 = 0 + 3;
            if(val_92 < (long)spacesCount)
            {
                goto label_60;
            }
            
            return (System.Single[])val_1;
            label_6:
            val_87 = spacesCount - 4;
            Spine.ExposedList<T> val_21 = this.world.Resize(newSize:  val_87);
            val_86 = val_86 - 1;
            path.ComputeWorldVertices(slot:  val_83, start:  2, count:  val_87, worldVertices:  val_82, offset:  0, stride:  2);
            label_14:
            Spine.ExposedList<T> val_22 = this.curves.Resize(newSize:  val_86);
            if(val_86 < 1)
            {
                goto label_69;
            }
            
            val_84 = 7;
            label_85:
            var val_23 = val_84 - 3;
            var val_24 = val_84 - 2;
            var val_25 = val_84 - 1;
            var val_26 = val_84 - 5;
            bool val_27 = val_82 + 12;
            val_26 = val_82 + (val_26 << 2);
            float val_94 = (percentPosition + 12) + 32;
            float val_93 = (percentPosition + ((val_84 - 5)) << 2) + 32;
            val_23 = val_82 + (val_23 << 2);
            val_24 = val_82 + (val_24 << 2);
            float val_28 = val_94 + val_94;
            float val_29 = val_93 + val_93;
            val_25 = val_82 + (val_25 << 2);
            bool val_30 = val_82 + 28;
            val_28 = (percentPosition + 32 + 4) - val_28;
            val_29 = (percentPosition + 32) - val_29;
            float val_31 = val_93 - ((percentPosition + ((val_84 - 3)) << 2) + 32);
            val_28 = val_28 + ((percentPosition + ((val_84 - 2)) << 2) + 32);
            val_29 = val_29 + ((percentPosition + ((val_84 - 3)) << 2) + 32);
            float val_32 = val_94 - ((percentPosition + ((val_84 - 2)) << 2) + 32);
            val_28 = val_28 * 0.1875f;
            val_29 = val_29 * 0.1875f;
            val_32 = val_32 * 3f;
            val_93 = val_93 - (percentPosition + 32);
            val_32 = val_32 - (percentPosition + 32 + 4);
            val_93 = val_93 * 0.75f;
            val_32 = val_32 + ((percentPosition + 28) + 32);
            val_31 = val_31 * 3f;
            val_92 = val_32 * 0.09375f;
            float val_33 = val_29 + val_29;
            float val_95 = 0.1666667f;
            val_31 = val_31 - (percentPosition + 32);
            val_94 = val_94 - (percentPosition + 32 + 4);
            val_31 = val_31 + ((percentPosition + ((val_84 - 1)) << 2) + 32);
            val_94 = val_94 * 0.75f;
            float val_35 = val_31 * 0.09375f;
            float val_36 = val_28 + val_28;
            val_28 = val_94 + val_28;
            val_95 = val_35 * val_95;
            float val_38 = (val_93 + val_29) + val_95;
            float val_39 = val_28 + (val_92 * val_95);
            float val_40 = val_38 * val_38;
            float val_41 = val_39 * val_39;
            val_40 = val_40 + val_41;
            float val_42 = val_33 + val_35;
            float val_43 = val_36 + val_92;
            if(val_41 >= _TYPE_MAX_)
            {
                    val_93 = val_40;
            }
            
            val_33 = val_42 + val_38;
            float val_44 = val_43 + val_39;
            float val_45 = val_33 * val_33;
            val_45 = val_45 + (val_44 * val_44);
            val_88 = val_35 + val_42;
            val_43 = val_92 + val_43;
            if(val_36 >= _TYPE_MAX_)
            {
                    val_90 = val_45;
            }
            
            val_42 = val_88 + val_33;
            val_44 = val_43 + val_44;
            float val_47 = val_42 * val_42;
            val_47 = val_47 + (val_44 * val_44);
            if(val_33 >= _TYPE_MAX_)
            {
                    val_94 = val_47;
            }
            
            float val_49 = val_35 + val_88;
            float val_50 = val_92 + val_43;
            val_49 = val_49 + val_42;
            val_50 = val_50 + val_44;
            val_49 = val_49 * val_49;
            val_50 = val_50 * val_50;
            val_50 = val_49 + val_50;
            if(val_49 >= _TYPE_MAX_)
            {
                    val_95 = val_50;
            }
            
            float val_96 = 0f;
            val_96 = val_96 + val_93;
            val_96 = val_96 + val_90;
            val_96 = val_96 + val_94;
            val_96 = val_96 + val_95;
            m_value = val_96;
            val_80 = 0 + 1;
            if(val_80 >= (long)val_86)
            {
                goto label_84;
            }
            
            val_84 = val_84 + 6;
            if((val_84 + 1) < (percentPosition + 24))
            {
                goto label_85;
            }
            
            label_84:
            val_87 = val_87;
            goto label_87;
            label_69:
            val_96 = 0f;
            label_87:
            val_84 = (val_82 != true) ? (val_84 * val_96) : (val_84);
            if((spacesCount >= 1) && (val_81 != false))
            {
                    Spine.ExposedList<System.Single> val_97 = this.spaces;
                var val_99 = 0;
                val_97 = val_97 + 32;
                do
            {
                float val_98 = (this.spaces + 32) + 0;
                val_98 = val_96 * val_98;
                mem2[0] = val_98;
                val_99 = val_99 + 1;
            }
            while(val_99 < (long)spacesCount);
            
            }
            
            if(spacesCount < 1)
            {
                    return (System.Single[])val_1;
            }
            
            val_81 = this.segments;
            var val_116 = 0;
            var val_117 = 0;
            val_80 = 0;
            val_84 = 0;
            val_90 = 0f;
            label_145:
            Spine.ExposedList<System.Single> val_54 = this.spaces + 0;
            val_92 = mem[(this.spaces + 0) + 32];
            val_92 = (this.spaces + 0) + 32;
            val_84 = val_84 + val_92;
            if(val_85 == false)
            {
                goto label_96;
            }
            
            float val_100 = val_84;
            val_80 = 0;
            val_100 = (val_100 < 0) ? (val_96 + val_100) : (val_100);
            label_147:
            var val_101 = 6;
            val_101 = 7 + (val_80 * val_101);
            do
            {
                val_80 = val_80 + 1;
                val_101 = val_101 + 6;
            }
            while(val_80 < this.target.bone);
            
            if(val_80 != 0)
            {
                    Spine.Slot val_57 = val_83 + ((val_80 - 1) << 2);
                float val_104 = (this.target + ((val_80 - 1)) << 2).r;
                val_100 = val_100 - val_104;
                Spine.Slot.__il2cppRuntimeField_byval_arg = Spine.Slot.__il2cppRuntimeField_byval_arg - val_104;
            }
            
            if(0 != val_80)
            {
                    var val_59 = val_101 - 7;
                var val_60 = val_101 - 6;
                bool val_66 = val_82 + ((val_101 - 5) << 2);
                bool val_67 = val_82 + ((val_101 - 4) << 2);
                bool val_68 = val_82 + ((val_101 - 3) << 2);
                bool val_69 = val_82 + ((val_101 - 2) << 2);
                val_59 = val_82 + (val_59 << 2);
                val_60 = val_82 + (val_60 << 2);
                float val_103 = (percentPosition + (((val_80 * 6) + 7 - 4)) << 2) + 32;
                float val_107 = (percentPosition + (((val_80 * 6) + 7 - 6)) << 2) + 32;
                bool val_70 = val_82 + ((val_101 - 1) << 2);
                double val_102 = 3;
                val_102 = (val_103 - ((percentPosition + (((val_80 * 6) + 7 - 2)) << 2) + 32)) * val_102;
                val_103 = val_103 + val_103;
                val_101 = val_82 + (val_101 << 2);
                val_103 = val_107 - val_103;
                val_103 = val_103 + ((percentPosition + (((val_80 * 6) + 7 - 2)) << 2) + 32);
                val_104 = (val_103 - val_107) * val_104;
                float val_73 = val_103 * val_100;
                float val_105 = (percentPosition + ((val_80 * 6) + 7) << 2) + 32;
                val_102 = val_102 - val_107;
                val_105 = val_102 + val_105;
                float val_74 = val_105 * val_107;
                val_102 = val_74 * val_102;
                val_104 = (val_104 + val_73) + val_102;
                float val_106 = val_104;
                val_106 = val_106 + val_102;
                if(val_90 >= _TYPE_MAX_)
            {
                    val_97 = val_106;
            }
            
                val_81[0] = val_97;
                float val_108 = val_74;
                var val_109 = 0;
                val_107 = val_108 + (val_73 + val_73);
                val_74 = val_104 + val_107;
                var val_77 = ((System.Math.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
                do
            {
                val_108 = val_108 + val_74;
                var val_78 = val_109 + 1;
                if(val_74 >= _TYPE_MAX_)
            {
                    val_98 = val_108;
                float val_110 = val_107;
                float val_111 = val_74;
            }
            
                val_97 = val_97 + val_98;
                mem2[0] = val_97;
                val_109 = val_109 + 1;
                val_110 = val_74 + val_110;
                val_111 = val_111 + val_110;
                var val_79 = ((System.Math.__il2cppRuntimeField_12E & 512) != 0) ? 1 : 0;
            }
            while(val_109 < 7);
            
                val_88 = val_111;
                val_108 = val_108 + val_74;
                if(val_74 >= _TYPE_MAX_)
            {
                    val_99 = val_108;
            }
            
                float val_112 = val_74;
                val_97 = val_97 + val_99;
                val_81[8] = val_97;
                float val_113 = val_112;
                val_112 = val_112 + val_110;
                val_113 = val_113 + val_110;
                float val_80 = val_111 + val_112;
                val_113 = val_88 + val_113;
                val_113 = val_113 * val_113;
                val_80 = val_80 * val_80;
                val_80 = val_80 + val_113;
                if(val_113 >= _TYPE_MAX_)
            {
                    val_101 = val_80;
            }
            
                val_84 = 0;
                val_90 = val_97 + val_101;
                val_81[9] = val_90;
            }
            
            val_101 = (val_100 / Spine.Slot.__il2cppRuntimeField_byval_arg) * val_90;
            label_132:
            float val_114 = val_81[val_84];
            if(val_101 <= val_114)
            {
                goto label_131;
            }
            
            val_84 = val_84 + 1;
            if(val_84 < this.segments.Length)
            {
                goto label_132;
            }
            
            label_131:
            if(val_84 == 0)
            {
                goto label_134;
            }
            
            float val_115 = val_81[val_84 - 1];
            val_101 = val_101 - val_115;
            val_114 = val_114 - val_115;
            val_101 = val_101 / val_114;
            val_102 = val_101 + 0f;
            goto label_136;
            label_96:
            if(val_84 >= 0)
            {
                goto label_137;
            }
            
            Spine.PathConstraint.AddBeforePosition(p:  val_84, temp:  val_82, i:  0, output:  val_1, o:  0);
            goto label_144;
            label_134:
            val_102 = val_101 / val_114;
            label_136:
            val_102 = val_102 * 0.1f;
            if(tangents == false)
            {
                goto label_139;
            }
            
            val_103 = 1;
            goto label_142;
            label_139:
            if(val_116 == 0)
            {
                goto label_141;
            }
            
            var val_82 = (val_92 == 0f) ? 1 : 0;
            goto label_142;
            label_137:
            if(val_84 <= val_96)
            {
                goto label_143;
            }
            
            Spine.PathConstraint.AddAfterPosition(p:  val_84 - val_96, temp:  val_82, i:  val_87 - 4, output:  val_1, o:  0);
            goto label_144;
            label_141:
            val_103 = 0;
            label_142:
            Spine.PathConstraint.AddCurvePosition(p:  val_102, x1:  (percentPosition + (((val_80 * 6) + 7 - 7)) << 2) + 32, y1:  val_107, cx1:  (percentPosition + (((val_80 * 6) + 7 - 5)) << 2) + 32, cy1:  val_103, cx2:  (percentPosition + (((val_80 * 6) + 7 - 3)) << 2) + 32, cy2:  (percentPosition + (((val_80 * 6) + 7 - 2)) << 2) + 32, x2:  (percentPosition + (((val_80 * 6) + 7 - 1)) << 2) + 32, y2:  (percentPosition + ((val_80 * 6) + 7) << 2) + 32, output:  val_1, o:  0, tangents:  false);
            label_144:
            val_116 = val_116 + 1;
            val_117 = val_117 + 3;
            if(val_116 < (long)spacesCount)
            {
                goto label_145;
            }
            
            return (System.Single[])val_1;
            label_143:
            if(val_83 != null)
            {
                goto label_147;
            }
            
            throw new NullReferenceException();
        }
        private static void AddBeforePosition(float p, float[] temp, int i, float[] output, int o)
        {
            float val_11 = temp[i << 2];
            float val_13 = temp[(i + 1) << 2];
            float val_6 = Spine.MathUtils.Atan2(y:  (temp[(i + 3) << 2]) - val_13, x:  (temp[(i + 2) << 2]) - val_11);
            float val_7 = Spine.MathUtils.Cos(radians:  val_6);
            val_7 = val_7 * p;
            val_7 = val_11 + val_7;
            output[o << 2] = val_7;
            float val_8 = Spine.MathUtils.Sin(radians:  val_6);
            val_8 = val_8 * p;
            val_8 = val_13 + val_8;
            output[(o + 1) << 2] = val_8;
            output[(o + 2) << 2] = val_6;
        }
        private static void AddAfterPosition(float p, float[] temp, int i, float[] output, int o)
        {
            float val_11 = temp[(i + 2) << 2];
            float val_13 = temp[(i + 3) << 2];
            float val_6 = Spine.MathUtils.Atan2(y:  val_13 - (temp[(i + 1) << 2]), x:  val_11 - (temp[i << 2]));
            float val_7 = Spine.MathUtils.Cos(radians:  val_6);
            val_7 = val_7 * p;
            val_7 = val_11 + val_7;
            output[o << 2] = val_7;
            float val_8 = Spine.MathUtils.Sin(radians:  val_6);
            val_8 = val_8 * p;
            val_8 = val_13 + val_8;
            output[(o + 1) << 2] = val_8;
            output[(o + 2) << 2] = val_6;
        }
        private static void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, float[] output, int o, bool tangents)
        {
            float val_21;
            float val_22;
            float val_23;
            float val_24;
            float val_23 = x2;
            val_21 = p;
            val_22 = cy2;
            val_23 = cx1;
            val_24 = cx2;
            if(val_21 == 0f)
            {
                goto label_1;
            }
            
            val_22 = val_22;
            val_23 = val_23;
            val_24 = val_24;
            if((System.Single.IsNaN(f:  val_21)) == false)
            {
                goto label_2;
            }
            
            label_1:
            val_21 = 0.0001f;
            label_2:
            float val_21 = 1f;
            val_21 = val_21 - val_21;
            float val_22 = 3f;
            float val_2 = val_21 * val_21;
            float val_3 = val_21 * val_21;
            val_22 = val_2 * val_22;
            float val_4 = val_21 * val_3;
            float val_5 = val_21 * val_22;
            float val_6 = val_21 * val_21;
            val_21 = val_21 * val_22;
            float val_7 = val_4 * x1;
            float val_9 = val_21 * val_6;
            val_7 = val_7 + (val_5 * val_23);
            val_7 = (val_21 * val_24) + val_7;
            val_23 = (val_9 * val_23) + val_7;
            output[o << 2] = val_23;
            val_4 = val_4 * y1;
            val_21 = val_21 * val_22;
            val_4 = val_4 + (val_5 * cy1);
            val_21 = val_21 + val_4;
            val_9 = val_9 * y2;
            val_21 = val_9 + val_21;
            output[(o + 1) << 2] = val_21;
            if(tangents == false)
            {
                    return;
            }
            
            val_22 = val_22;
            val_23 = val_23;
            val_24 = val_24;
            float val_14 = val_2 * cy1;
            float val_15 = val_2 * val_23;
            float val_16 = val_3 * y1;
            val_14 = val_14 + val_14;
            val_15 = val_15 + val_15;
            val_24 = val_6 * val_24;
            val_16 = val_16 + val_14;
            float val_19 = (val_3 * x1) + val_15;
            val_16 = (val_6 * val_22) + val_16;
            val_19 = val_24 + val_19;
            val_16 = val_21 - val_16;
            val_19 = val_23 - val_19;
            output[(o + 2) << 2] = (float)(double)val_16;
        }
    
    }

}

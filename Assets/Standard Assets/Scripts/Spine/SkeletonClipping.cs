using UnityEngine;

namespace Spine
{
    public class SkeletonClipping
    {
        // Fields
        internal readonly Spine.Triangulator triangulator;
        internal readonly Spine.ExposedList<float> clippingPolygon;
        internal readonly Spine.ExposedList<float> clipOutput;
        internal readonly Spine.ExposedList<float> clippedVertices;
        internal readonly Spine.ExposedList<int> clippedTriangles;
        internal readonly Spine.ExposedList<float> clippedUVs;
        internal readonly Spine.ExposedList<float> scratch;
        internal Spine.ClippingAttachment clipAttachment;
        internal Spine.ExposedList<Spine.ExposedList<float>> clippingPolygons;
        
        // Properties
        public Spine.ExposedList<float> ClippedVertices { get; }
        public Spine.ExposedList<int> ClippedTriangles { get; }
        public Spine.ExposedList<float> ClippedUVs { get; }
        
        // Methods
        public Spine.ExposedList<float> get_ClippedVertices()
        {
            return (Spine.ExposedList<System.Single>)this.clippedVertices;
        }
        public Spine.ExposedList<int> get_ClippedTriangles()
        {
            return (Spine.ExposedList<System.Int32>)this.clippedTriangles;
        }
        public Spine.ExposedList<float> get_ClippedUVs()
        {
            return (Spine.ExposedList<System.Single>)this.clippedUVs;
        }
        public bool IsClipping()
        {
            return (bool)(this.clipAttachment != 0) ? 1 : 0;
        }
        public int ClipStart(Spine.Slot slot, Spine.ClippingAttachment clip)
        {
            Spine.ExposedList<System.Single> val_5;
            var val_6;
            Spine.Slot val_9;
            var val_10;
            Spine.ExposedList<System.Single> val_11;
            val_9 = slot;
            if(this.clipAttachment != null)
            {
                    val_10 = 0;
                return 1715543616;
            }
            
            this.clipAttachment = clip;
            Spine.ExposedList<T> val_1 = this.clippingPolygon.Resize(newSize:  41934848);
            clip.ComputeWorldVertices(slot:  val_9, start:  0, count:  41934848, worldVertices:  null, offset:  0, stride:  2);
            Spine.SkeletonClipping.MakeClockwise(polygon:  this.clippingPolygon);
            Spine.ExposedList<Spine.ExposedList<System.Single>> val_3 = this.triangulator.Decompose(verticesArray:  this.clippingPolygon, triangles:  this.triangulator.Triangulate(verticesArray:  this.clippingPolygon));
            this.clippingPolygons = val_3;
            ExposedList.Enumerator<T> val_4 = val_3.GetEnumerator();
            val_9 = 1152921510617339824;
            label_14:
            if(val_6.MoveNext() == false)
            {
                goto label_8;
            }
            
            val_11 = val_5;
            Spine.SkeletonClipping.MakeClockwise(polygon:  val_11);
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16 + 24) == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_11 = val_5;
            val_11.Add(item:  val_5 + 16 + 32);
            if((val_5 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_5.Add(item:  val_5 + 16 + 36);
            goto label_14;
            label_8:
            val_6.Dispose();
            return 1715543616;
        }
        public void ClipEnd(Spine.Slot slot)
        {
            if(this.clipAttachment == null)
            {
                    return;
            }
            
            if(slot != null)
            {
                    if(this.clipAttachment.endSlot != slot.data)
            {
                    return;
            }
            
                this.ClipEnd();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ClipEnd()
        {
            if(this.clipAttachment == null)
            {
                    return;
            }
            
            this.clipAttachment = 0;
            mem[1152921510617688256] = 0;
            this.clippedVertices.Clear(clearArray:  true);
            this.clippedTriangles.Clear(clearArray:  true);
            this.clippingPolygon.Clear(clearArray:  true);
        }
        public void ClipTriangles(float[] vertices, int verticesLength, int[] triangles, int trianglesLength, float[] uvs)
        {
            var val_51;
            Spine.ExposedList<System.Single> val_52;
            var val_53;
            Spine.ExposedList<System.Single> val_54;
            var val_55;
            val_51 = this;
            val_52 = this.clipOutput;
            val_53 = 1152921510517605088;
            this.clippedVertices.Clear(clearArray:  true);
            this.clippedUVs.Clear(clearArray:  true);
            this.clippedTriangles.Clear(clearArray:  true);
            if(trianglesLength < 1)
            {
                    return;
            }
            
            val_54 = 0;
            label_76:
            int val_55 = triangles[0];
            val_55 = (long)val_55 << 1;
            val_55 = val_55 | 1;
            int val_56 = triangles[4];
            val_56 = val_56 << 1;
            val_56 = (long)val_56 | 1;
            int val_57 = triangles[8];
            val_57 = val_57 << 1;
            val_57 = (long)val_57 | 1;
            if(this.clippingPolygons < 1)
            {
                goto label_53;
            }
            
            var val_60 = 0;
            System.Single[] val_2 = vertices + (((long)(int)((triangles[0x0][0] << 1))) << 2);
            System.Single[] val_3 = vertices + ((((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2);
            System.Single[] val_4 = uvs + (((long)(int)((triangles[0x0][0] << 1))) << 2);
            System.Single[] val_5 = uvs + ((((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2);
            System.Single[] val_6 = vertices + (((long)(int)((triangles[0x4][0] << 1))) << 2);
            System.Single[] val_7 = vertices + ((((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2);
            val_55 = vertices + (((long)(int)((triangles[0x8][0] << 1))) << 2);
            System.Single[] val_8 = vertices + ((((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2);
            System.Single[] val_9 = uvs + (((long)(int)((triangles[0x4][0] << 1))) << 2);
            System.Single[] val_10 = uvs + ((((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2);
            System.Single[] val_11 = uvs + (((long)(int)((triangles[0x8][0] << 1))) << 2);
            System.Single[] val_12 = uvs + ((((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2);
            float val_13 = ((vertices + (((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2) + 32) - ((vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32);
            float val_14 = ((vertices + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32) - ((vertices + ((long)(int)((triangles[0x4][0] << 1))) << 2) + 32);
            float val_15 = ((vertices + ((long)(int)((triangles[0x0][0] << 1))) << 2) + 32) - ((vertices + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32);
            float val_16 = ((vertices + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32) - ((vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32);
            val_16 = val_14 * val_16;
            val_16 = (val_15 * val_13) + val_16;
            float val_19 = 1f / val_16;
            label_52:
            var val_20 = X28 + 0;
            float val_58 = (vertices + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32;
            if((this.Clip(x1:  (vertices + ((long)(int)((triangles[0x0][0] << 1))) << 2) + 32, y1:  val_58, x2:  (vertices + ((long)(int)((triangles[0x4][0] << 1))) << 2) + 32, y2:  (vertices + (((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2) + 32, x3:  (vertices + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32, y3:  (vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32, clippingArea:  (X28 + 0) + 32, output:  val_52)) == false)
            {
                goto label_27;
            }
            
            if((public System.Void Spine.ExposedList<System.Single>::Clear(bool clearArray)) != 0)
            {
                    System.Single[] val_22 = 44390576 + uvs;
                Spine.ExposedList<T> val_23 = this.clippedVertices.Resize(newSize:  val_22);
                val_55 = 1152921510530537664;
                Spine.ExposedList<T> val_24 = this.clippedUVs.Resize(newSize:  val_22);
                if(val_53 >= 1)
            {
                    do
            {
                val_55 = 0 + 1;
                Spine.ExposedList<System.Int32> val_25 = this.clippedTriangles + (val_55 << 2);
                Spine.SkeletonClipping val_26 = val_51 + (((long)(int)(uvs[0x0])) << 2);
                (this + ((long)(int)(uvs[0x0])) << 2).clipOutput = Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
                Spine.SkeletonClipping val_27 = val_51 + (((long)(int)(uvs[0x0][0x1])) << 2);
                (this + ((long)(int)(uvs[0x0][0x1])) << 2).clipOutput = val_58;
                uvs[0][1] = uvs[0][1] - 1;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg) - ((vertices + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32);
                val_58 = val_58 - ((vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32);
                float val_28 = val_13 * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                float val_29 = val_14 * val_58;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (((vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32) - ((vertices + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32)) * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_58 = val_15 * val_58;
                val_28 = val_28 + val_29;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg) + val_58;
                float val_30 = val_19 * val_28;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = val_19 * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_28 = 1f - val_30;
                val_29 = ((uvs + ((long)(int)((triangles[0x0][0] << 1))) << 2) + 32) * val_30;
                val_28 = val_28 - (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_29 = val_29 + (((uvs + ((long)(int)((triangles[0x4][0] << 1))) << 2) + 32) * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg));
                val_29 = val_29 + (((uvs + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32) * val_28);
                Spine.ExposedList<System.Single> val_33 = this.clippedUVs + (((long)(int)(uvs[0x0])) << 2);
                mem2[0] = val_29;
                val_30 = ((uvs + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32) * val_30;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = ((uvs + (((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2) + 32) * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_28 = ((uvs + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32) * val_28;
                Spine.ExposedList<System.Single> val_34 = this.clippedUVs + (((long)(int)(uvs[0x0][0x1])) << 2);
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = val_30 + (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg) + val_28;
                mem2[0] = Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg;
            }
            while((val_55 + 1) < val_53);
            
            }
            
                Spine.ExposedList<T> val_36 = this.clippedTriangles.Resize(newSize:  1782773618);
                if(val_53 >= 6)
            {
                    val_55 = 22195287;
                var val_59 = 1;
                do
            {
                .clipOutput = val_54;
                .clipOutput = val_54 + val_59;
                Spine.ExposedList<System.Single> val_38 = val_54 + val_59;
                val_59 = val_59 + 1;
                val_38 = val_38 + 1;
                .clipOutput = val_38;
            }
            while(val_59 < val_55);
            
            }
            
                val_51 = val_51;
                val_52 = val_52;
                val_54 = 22195288;
            }
            
            val_60 = val_60 + 1;
            if(val_60 < this.clippingPolygons)
            {
                goto label_52;
            }
            
            goto label_53;
            label_27:
            Spine.ExposedList<T> val_39 = this.clippedVertices.Resize(newSize:  uvs[6]);
            Spine.ExposedList<T> val_40 = this.clippedUVs.Resize(newSize:  uvs[6]);
            string val_63 = "stub is not used in Mono";
            var val_41 = val_53 + ((uvs) << 2);
            mem2[0] = (vertices + ((long)(int)((triangles[0x0][0] << 1))) << 2) + 32;
            var val_42 = val_53 + (((long)(int)(uvs[0x1])) << 2);
            mem2[0] = (vertices + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32;
            var val_43 = val_53 + (((long)(int)(uvs[0x2])) << 2);
            mem2[0] = (vertices + ((long)(int)((triangles[0x4][0] << 1))) << 2) + 32;
            var val_44 = val_53 + (((long)(int)(uvs[0x3])) << 2);
            mem2[0] = (vertices + (((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2) + 32;
            var val_45 = val_53 + (((long)(int)(uvs[0x4])) << 2);
            mem2[0] = (vertices + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32;
            var val_46 = val_53 + (((long)(int)(uvs[0x5])) << 2);
            mem2[0] = (vertices + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32;
            var val_47 = val_63 + ((uvs) << 2);
            mem2[0] = (uvs + ((long)(int)((triangles[0x0][0] << 1))) << 2) + 32;
            var val_48 = val_63 + (((long)(int)(uvs[0x1])) << 2);
            mem2[0] = (uvs + (((long)(int)((triangles[0x0][0] << 1)) | 1)) << 2) + 32;
            var val_49 = val_63 + (((long)(int)(uvs[0x2])) << 2);
            mem2[0] = (uvs + ((long)(int)((triangles[0x4][0] << 1))) << 2) + 32;
            var val_50 = val_63 + (((long)(int)(uvs[0x3])) << 2);
            mem2[0] = (uvs + (((long)(int)((triangles[0x4][0] << 1)) | 1)) << 2) + 32;
            var val_51 = val_63 + (((long)(int)(uvs[0x4])) << 2);
            mem2[0] = (uvs + ((long)(int)((triangles[0x8][0] << 1))) << 2) + 32;
            val_63 = val_63 + (((long)(int)(uvs[0x5])) << 2);
            mem2[0] = (uvs + (((long)(int)((triangles[0x8][0] << 1)) | 1)) << 2) + 32;
            Spine.ExposedList<T> val_52 = this.clippedTriangles.Resize(newSize:  44390579);
            mem[221747664] = val_54;
            mem[221747668] = val_54 + 1;
            val_55 = 44390578;
            val_54 = val_54 + 3;
            mem[221747672] = val_54 + 2;
            label_53:
            var val_64 = 0;
            val_64 = val_64 + 3;
            if(val_64 < trianglesLength)
            {
                goto label_76;
            }
        
        }
        internal bool Clip(float x1, float y1, float x2, float y2, float x3, float y3, Spine.ExposedList<float> clippingArea, Spine.ExposedList<float> output)
        {
            var val_31;
            float val_32;
            float val_33;
            float val_34;
            float val_35;
            var val_36;
            val_32 = y3;
            val_33 = y2;
            val_34 = y1;
            bool val_33 = true;
            var val_1 = (val_33 < 0) ? 4 : (val_33);
            val_1 = val_1 & 4294967292;
            val_33 = val_33 - val_1;
            var val_2 = (val_33 < 2) ? this.scratch : output;
            var val_3 = (val_33 < 2) ? output : this.scratch;
            val_2.Clear(clearArray:  true);
            val_2.Add(item:  x1);
            val_2.Add(item:  val_34);
            val_2.Add(item:  x2);
            val_2.Add(item:  val_33);
            val_2.Add(item:  x3);
            val_2.Add(item:  val_32);
            val_2.Add(item:  x1);
            val_2.Add(item:  val_34);
            val_3.Clear(clearArray:  true);
            val_1 = val_1 - 4;
            label_27:
            long val_34 = 0;
            val_34 = val_34 | 1;
            var val_4 = 0 + 2;
            var val_5 = 0 + 3;
            var val_6 = (true < 0x2 ? this.scratch : output + 24) - 2;
            if(val_6 < 1)
            {
                goto label_21;
            }
            
            val_31 = mem[true < 0x2 ? this.scratch : output + 16];
            val_31 = true < 0x2 ? this.scratch : output + 16;
            var val_36 = 0;
            Spine.ExposedList<System.Single> val_7 = this.scratch + 0;
            Spine.ExposedList<System.Single> val_8 = this.scratch + (((0 | 1)) << 2);
            Spine.ExposedList<System.Single> val_9 = this.scratch + (val_4 << 2);
            val_5 = this.scratch + (val_5 << 2);
            float val_35 = (this.scratch + 0) + 32;
            val_33 = mem[(this.scratch + ((0 + 2)) << 2) + 32];
            val_33 = (this.scratch + ((0 + 2)) << 2) + 32;
            val_35 = val_35 - val_33;
            float val_10 = ((this.scratch + ((0 | 1)) << 2) + 32) - ((this.scratch + ((0 + 3)) << 2) + 32);
            val_35 = val_33 - val_35;
            val_32 = ((this.scratch + ((0 + 3)) << 2) + 32) - ((this.scratch + ((0 | 1)) << 2) + 32);
            label_20:
            var val_11 = val_36 + 1;
            var val_14 = val_31 + 0;
            val_11 = val_31 + (val_11 << 2);
            float val_38 = (true < 0x2 ? this.scratch : output + 16 + 0) + 32;
            val_36 = val_36 + 3;
            float val_37 = (true < 0x2 ? this.scratch : output + 16 + ((0 + 1)) << 2) + 32;
            var val_16 = val_31 + ((val_36 + 2) << 2);
            val_36 = val_31 + (val_36 << 2);
            val_34 = mem[(true < 0x2 ? this.scratch : output + 16 + ((0 + 3)) << 2) + 32];
            val_34 = (true < 0x2 ? this.scratch : output + 16 + ((0 + 3)) << 2) + 32;
            float val_17 = val_37 - ((this.scratch + ((0 + 3)) << 2) + 32);
            float val_18 = val_38 - val_33;
            val_17 = val_35 * val_17;
            val_18 = val_10 * val_18;
            float val_19 = val_34 - ((this.scratch + ((0 + 3)) << 2) + 32);
            val_17 = val_17 - val_18;
            float val_20 = ((true < 0x2 ? this.scratch : output + 16 + ((0 + 2)) << 2) + 32) - val_33;
            val_19 = val_35 * val_19;
            val_20 = val_10 * val_20;
            float val_21 = val_19 - val_20;
            if(val_17 <= 0f)
            {
                goto label_15;
            }
            
            if(val_21 <= 0f)
            {
                goto label_16;
            }
            
            val_3.Add(item:  (true < 0x2 ? this.scratch : output + 16 + ((0 + 2)) << 2) + 32);
            val_3.Add(item:  val_34);
            goto label_17;
            label_15:
            if(val_21 <= 0f)
            {
                goto label_18;
            }
            
            float val_22 = val_34 - val_37;
            float val_23 = ((true < 0x2 ? this.scratch : output + 16 + ((0 + 2)) << 2) + 32) - val_38;
            val_37 = ((this.scratch + ((0 | 1)) << 2) + 32) - val_37;
            val_38 = val_35 - val_38;
            val_37 = val_37 * val_23;
            val_38 = val_38 * val_22;
            val_22 = val_35 * val_22;
            val_23 = val_32 * val_23;
            val_38 = val_37 - val_38;
            val_32 = val_38 / (val_22 - val_23);
            val_38 = val_35 * val_32;
            val_38 = val_35 + val_38;
            val_3.Add(item:  val_38);
            float val_25 = val_32 * val_32;
            val_32 = val_32;
            val_35 = val_35;
            val_33 = val_33;
            val_25 = ((this.scratch + ((0 | 1)) << 2) + 32) + val_25;
            val_3.Add(item:  val_25);
            val_3.Add(item:  (true < 0x2 ? this.scratch : output + 16 + ((0 + 2)) << 2) + 32);
            val_36 = public System.Void Spine.ExposedList<System.Single>::Add(System.Single item);
            goto label_19;
            label_16:
            float val_26 = val_34 - val_37;
            float val_27 = ((true < 0x2 ? this.scratch : output + 16 + ((0 + 2)) << 2) + 32) - val_38;
            val_37 = ((this.scratch + ((0 | 1)) << 2) + 32) - val_37;
            val_38 = val_35 - val_38;
            val_37 = val_37 * val_27;
            val_38 = val_38 * val_26;
            val_26 = val_35 * val_26;
            val_27 = val_32 * val_27;
            val_38 = val_37 - val_38;
            val_34 = val_38 / (val_26 - val_27);
            val_38 = val_35 * val_34;
            val_38 = val_35 + val_38;
            val_3.Add(item:  val_38);
            val_36 = public System.Void Spine.ExposedList<System.Single>::Add(System.Single item);
            float val_29 = val_32 * val_34;
            val_29 = ((this.scratch + ((0 | 1)) << 2) + 32) + val_29;
            label_19:
            val_3.Add(item:  val_29);
            label_18:
            label_17:
            if((((val_11 + 1) + 1) - 1) < val_6)
            {
                goto label_20;
            }
            
            if((true < 0x2 ? output : this.scratch + 24) == (true < 0x2 ? output : this.scratch + 24))
            {
                goto label_21;
            }
            
            val_3.Add(item:  true < 0x2 ? output : this.scratch + 16 + 32);
            val_3.Add(item:  true < 0x2 ? output : this.scratch + 16 + 36);
            if(0 == val_1)
            {
                goto label_26;
            }
            
            val_2.Clear(clearArray:  true);
            if(val_4 < (this.scratch + 24))
            {
                goto label_27;
            }
            
            label_21:
            output.Clear(clearArray:  true);
            return true;
            label_26:
            if(val_3 != output)
            {
                    output.Clear(clearArray:  true);
                var val_39 = true < 0x2 ? output : this.scratch + 24;
                val_39 = val_39 - 2;
                if(val_39 < 1)
            {
                    return true;
            }
            
                var val_41 = 0;
                do
            {
                var val_40 = true < 0x2 ? output : this.scratch + 16;
                val_40 = val_40 + 0;
                output.Add(item:  (true < 0x2 ? output : this.scratch + 16 + 0) + 32);
                val_41 = val_41 + 1;
            }
            while(val_41 < (long)val_39);
            
                return true;
            }
            
            Spine.ExposedList<T> val_32 = output.Resize(newSize:  (output + 24) - 2);
            return true;
        }
        private static void MakeClockwise(Spine.ExposedList<float> polygon)
        {
            float val_14;
            var val_1 = W9 - 2;
            var val_2 = W9 - 1;
            val_1 = X8 + (val_1 << 2);
            float val_15 = (X8 + ((W9 - 2)) << 2) + 32;
            float val_17 = X8 + 32;
            var val_3 = W9 - 3;
            val_15 = val_15 * (X8 + 32 + 4);
            val_14 = val_15 - (val_17 * (X8 + 32 + ((W9 - 1)) << 2));
            if(val_3 >= 1)
            {
                    var val_16 = 1;
                do
            {
                var val_5 = val_16 + 2;
                var val_6 = X8 + 4;
                var val_7 = X8 + 32;
                val_16 = val_16 + 1;
                val_17 = val_17 * ((X8 + 32) + ((1 + 2)) << 2);
                val_17 = val_17 - (((X8 + 4) + 32) * ((X8 + 32) + 8));
                val_14 = val_14 + val_17;
            }
            while(val_16 < val_3);
            
            }
            
            if(val_14 < 0)
            {
                    return;
            }
            
            if(W9 < 2)
            {
                    return;
            }
            
            var val_9 = (X8 + 24) & 4294967295;
            var val_18 = 0;
            var val_11 = X8 + 36;
            var val_12 = W9 - 1;
            do
            {
                var val_13 = val_12 - 1;
                val_13 = X8 + (val_13 << 2);
                mem2[0] = (X8 + (((W9 - 1) - 1)) << 2) + 32;
                var val_14 = X8 + (val_12 << 2);
                mem2[0] = (X8 + ((W9 - 1)) << 2) + 32;
                mem2[0] = (X8 + 36) + -4;
                val_18 = val_18 + 2;
                mem2[0] = (X8 + 36) + -4 + 4;
                if(val_18 >= (X9 >> 1))
            {
                    return;
            }
            
                val_11 = val_11 + 8;
                val_12 = val_12 - 2;
            }
            while(val_18 < (X8 + 24));
            
            throw new IndexOutOfRangeException();
        }
        public SkeletonClipping()
        {
            this.triangulator = new Spine.Triangulator();
            this.clippingPolygon = new Spine.ExposedList<System.Single>();
            this.clipOutput = new Spine.ExposedList<System.Single>(capacity:  128);
            this.clippedVertices = new Spine.ExposedList<System.Single>(capacity:  128);
            this.clippedTriangles = new Spine.ExposedList<System.Int32>(capacity:  128);
            this.clippedUVs = new Spine.ExposedList<System.Single>(capacity:  128);
            this.scratch = new Spine.ExposedList<System.Single>();
        }
    
    }

}

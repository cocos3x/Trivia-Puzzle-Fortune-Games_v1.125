using UnityEngine;

namespace Spine
{
    internal class Triangulator
    {
        // Fields
        private readonly Spine.ExposedList<Spine.ExposedList<float>> convexPolygons;
        private readonly Spine.ExposedList<Spine.ExposedList<int>> convexPolygonsIndices;
        private readonly Spine.ExposedList<int> indicesArray;
        private readonly Spine.ExposedList<bool> isConcaveArray;
        private readonly Spine.ExposedList<int> triangles;
        private readonly Spine.Pool<Spine.ExposedList<float>> polygonPool;
        private readonly Spine.Pool<Spine.ExposedList<int>> polygonIndicesPool;
        
        // Methods
        public Spine.ExposedList<int> Triangulate(Spine.ExposedList<float> verticesArray)
        {
            int val_39;
            var val_40;
            var val_41;
            this.indicesArray.Clear(clearArray:  true);
            Spine.ExposedList<T> val_1 = this.indicesArray.Resize(newSize:  20969472);
            if(41938944 >= 2)
            {
                    var val_44 = 0;
                Spine.ExposedList<System.Single> val_2 = verticesArray + 32;
                do
            {
                mem2[0] = val_44;
                val_44 = val_44 + 1;
            }
            while(val_44 < 20969472);
            
            }
            
            Spine.ExposedList<T> val_3 = this.isConcaveArray.Resize(newSize:  20969472);
            if(41938944 >= 2)
            {
                    var val_45 = 0;
                val_39 = 20969472;
                var val_4 = X28 + 32;
                do
            {
                mem2[0] = Spine.Triangulator.IsConcave(index:  0, vertexCount:  20969472, vertices:  X21, indices:  verticesArray);
                val_45 = val_45 + 1;
            }
            while(val_45 < val_39);
            
            }
            
            this.triangles.Clear(clearArray:  true);
            int val_8 = (System.Math.Max(val1:  0, val2:  20969470)) << 2;
            this.triangles.EnsureCapacity(min:  val_8);
            if(41938944 >= 8)
            {
                goto label_17;
            }
            
            val_40 = 0;
            goto label_18;
            label_17:
            label_56:
            val_40 = 20969471;
            label_23:
            var val_9 = X28 + 0;
            val_41 = 0;
            var val_48 = 1;
            if(((X28 + 0) + 32) == 0)
            {
                goto label_21;
            }
            
            if(val_48 == 0)
            {
                goto label_27;
            }
            
            var val_10 = 2 / 0;
            val_10 = 2 - (val_10 * 0);
            if(val_48 < (X28 + 24))
            {
                goto label_23;
            }
            
            label_27:
            var val_11 = X28 + (val_41 << );
            if(((X28 + (val_41) << ) + 32) == 0)
            {
                goto label_48;
            }
            
            val_41 = val_41 - 1;
            if(val_41 >= 1)
            {
                goto label_27;
            }
            
            goto label_48;
            label_21:
            Spine.ExposedList<System.Single> val_12 = verticesArray + 83877884;
            var val_13 = W14 << 1;
            var val_46 = (long)val_13;
            val_46 = val_46 | 1;
            Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg) << 1;
            Spine.ExposedList<System.Single> val_14 = verticesArray + 4;
            val_14 = val_14 << 1;
            var val_47 = (long)val_14;
            val_47 = val_47 | 1;
            val_48 = val_48 + 1;
            val_48 = val_48 - ((val_48 / 0) * 0);
            if(val_48 == val_40)
            {
                goto label_40;
            }
            
            var val_16 = X21 + ((((long)(int)((W14 << 1)) | 1)) << 2);
            var val_18 = X21 + ((((long)(int)(((verticesArray + 4) << 1)) | 1)) << 2);
            val_13 = X21 + (val_13 << 2);
            val_14 = X21 + (val_14 << 2);
            label_49:
            var val_52 = (long)val_48;
            var val_22 = X28 + val_52;
            if(((X28 + (long)(int)((1 + 1) - (((1 + 1) / 0) * 0))) + 32) == 0)
            {
                goto label_47;
            }
            
            Spine.ExposedList<System.Single> val_23 = verticesArray + (((long)(int)((1 + 1) - (((1 + 1) / 0) * 0))) << 2);
            val_23 = val_23 << 1;
            var val_49 = (long)val_23;
            val_49 = val_49 | 1;
            var val_24 = X21 + ((((long)(int)(((verticesArray + ((long)(int)((1 + 1) - (((1 + 1) / 0) * 0))) << 2) << 1)) | 1)) << 2);
            float val_50 = (X21 + (((long)(int)(((verticesArray + ((long)(int)((1 + 1) - (((1 + 1) / 0) * 0))) << 2) << 1)) | 1)) << 2) + 32;
            val_23 = X21 + (val_23 << 2);
            float val_51 = (X21 + (((verticesArray + ((long)(int)((1 + 1) - (((1 + 1) / 0) * 0))) << 2) << 1)) << 2) + 32;
            float val_25 = val_50 - ((X21 + (((long)(int)((W14 << 1)) | 1)) << 2) + 32);
            float val_26 = ((X21 + (((long)(int)(((verticesArray + 4) << 1)) | 1)) << 2) + 32) - val_50;
            val_25 = ((X21 + (((verticesArray + 4) << 1)) << 2) + 32) * val_25;
            val_26 = ((X21 + ((W14 << 1)) << 2) + 32) * val_26;
            val_25 = val_25 + val_26;
            val_25 = ((((X21 + (((long)(int)((W14 << 1)) | 1)) << 2) + 32) - ((X21 + (((long)(int)(((verticesArray + 4) << 1)) | 1)) << 2) + 32)) * val_51) + val_25;
            if(val_25 < 0f)
            {
                goto label_47;
            }
            
            float val_28 = val_50 - ((X21 + (((long)(int)((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) | 1)) << 2) + 32);
            float val_29 = ((X21 + (((long)(int)((W14 << 1)) | 1)) << 2) + 32) - val_50;
            val_28 = ((X21 + ((W14 << 1)) << 2) + 32) * val_28;
            val_29 = ((X21 + ((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) << 2) + 32) * val_29;
            val_28 = val_28 + val_29;
            val_28 = ((((X21 + (((long)(int)((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) | 1)) << 2) + 32) - ((X21 + (((long)(int)((W14 << 1)) | 1)) << 2) + 32)) * val_51) + val_28;
            if(val_28 < 0f)
            {
                goto label_47;
            }
            
            float val_31 = val_50 - ((X21 + (((long)(int)(((verticesArray + 4) << 1)) | 1)) << 2) + 32);
            val_50 = ((X21 + (((long)(int)((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) | 1)) << 2) + 32) - val_50;
            val_31 = ((X21 + ((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) << 2) + 32) * val_31;
            val_50 = ((X21 + (((verticesArray + 4) << 1)) << 2) + 32) * val_50;
            val_50 = val_31 + val_50;
            val_51 = (((X21 + (((long)(int)(((verticesArray + 4) << 1)) | 1)) << 2) + 32) - ((X21 + (((long)(int)((Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg << 1)) | 1)) << 2) + 32)) * val_51;
            val_51 = val_51 + val_50;
            if(val_51 >= 0f)
            {
                goto label_48;
            }
            
            label_47:
            val_52 = val_52 + 1;
            val_52 = val_52 - ((val_52 / 0) * 0);
            if(val_52 != val_40)
            {
                goto label_49;
            }
            
            label_48:
            label_40:
            Spine.ExposedList<System.Single> val_33 = verticesArray + 83877884;
            this.triangles.Add(item:  val_8);
            this.triangles.Add(item:  Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
            var val_34 = val_41 + 1;
            val_34 = val_34 - ((val_34 / 0) * 0);
            val_34 = verticesArray + (val_34 << 2);
            this.triangles.Add(item:  Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
            this.indicesArray.RemoveAt(index:  0);
            this.isConcaveArray.RemoveAt(index:  0);
            var val_36 = val_41 + val_40;
            val_36 = val_36 - 1;
            var val_37 = val_36 / val_40;
            val_39 = val_36 - (val_37 * val_40);
            int val_38 = (val_41 == val_40) ? 0 : (val_41);
            val_37 = X28 + (val_39 << );
            mem2[0] = Spine.Triangulator.IsConcave(index:  val_39, vertexCount:  20969471, vertices:  X21, indices:  verticesArray);
            var val_43 = X28 + (val_38 << );
            mem2[0] = Spine.Triangulator.IsConcave(index:  val_38, vertexCount:  20969471, vertices:  X21, indices:  verticesArray);
            if(0 > 4)
            {
                goto label_56;
            }
            
            label_18:
            if(val_40 != 3)
            {
                    return (Spine.ExposedList<System.Int32>)this.triangles;
            }
            
            this.triangles.Add(item:  20969471);
            this.triangles.Add(item:  20969471);
            this.triangles.Add(item:  20969471);
            return (Spine.ExposedList<System.Int32>)this.triangles;
        }
        public Spine.ExposedList<Spine.ExposedList<float>> Decompose(Spine.ExposedList<float> verticesArray, Spine.ExposedList<int> triangles)
        {
            var val_56;
            Spine.ExposedList<System.Int32> val_57;
            Spine.ExposedList<System.Single> val_58;
            int val_59;
            float val_60;
            float val_61;
            float val_62;
            var val_63;
            Spine.ExposedList<Spine.ExposedList<System.Single>> val_64;
            float val_65;
            float val_66;
            var val_67;
            float val_68;
            if(41938944 >= 1)
            {
                    var val_57 = 0;
                do
            {
                var val_56 = this.convexPolygons + 16;
                val_56 = val_56 + 0;
                this.polygonPool.Free(obj:  (this.convexPolygons + 16 + 0) + 32);
                val_57 = val_57 + 1;
            }
            while(val_57 < 41938944);
            
            }
            
            this.convexPolygons.Clear(clearArray:  true);
            if(41938944 >= 1)
            {
                    var val_58 = 0;
                do
            {
                this.polygonIndicesPool.Free(obj:  "0:٠٪۰ۺ०॰০ৰ੦ੰ૦૰୦୰௧௰౦౰೦೰൦൰๐๚໐໚༠༪၀၊፩፲០៪᠐᠚０：");
                val_58 = val_58 + 1;
            }
            while(val_58 < 41938944);
            
            }
            
            this.convexPolygonsIndices.Clear(clearArray:  true);
            Spine.ExposedList<System.Int32> val_1 = this.polygonIndicesPool.Obtain();
            val_57 = val_1;
            val_1.Clear(clearArray:  true);
            Spine.ExposedList<System.Single> val_2 = this.polygonPool.Obtain();
            val_58 = val_2;
            val_2.Clear(clearArray:  true);
            if(1152921510517605088 < 1)
            {
                goto label_19;
            }
            
            var val_61 = 0;
            label_54:
            var val_3 = val_61 + 1;
            var val_5 = X28 + 0;
            int val_6 = ((X28 + 0) + 32) << 1;
            var val_59 = (long)val_6;
            val_59 = val_59 | 1;
            val_3 = X28 + (val_3 << 2);
            int val_7 = ((X28 + ((0 + 1)) << 2) + 32) << 1;
            var val_60 = (long)val_7;
            val_60 = val_60 | 1;
            val_61 = val_61 + 2;
            val_61 = X28 + (val_61 << 2);
            val_59 = ((X28 + ((0 + 2)) << 2) + 32) << 1;
            var val_62 = (long)val_59;
            val_62 = val_62 | 1;
            var val_8 = X27 + (val_6 << 2);
            var val_9 = X27 + ((((long)(int)(((X28 + 0) + 32 << 1)) | 1)) << 2);
            var val_10 = X27 + (val_7 << 2);
            var val_11 = X27 + ((((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2);
            var val_12 = X27 + (val_59 << 2);
            var val_13 = X27 + ((((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2);
            val_60 = mem[(X27 + (((long)(int)(((X28 + 0) + 32 << 1)) | 1)) << 2) + 32];
            val_60 = (X27 + (((long)(int)(((X28 + 0) + 32 << 1)) | 1)) << 2) + 32;
            val_61 = mem[(X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) + 32];
            val_61 = (X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) + 32;
            val_62 = mem[(X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 32];
            val_62 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 32;
            if(0 != val_6)
            {
                goto label_31;
            }
            
            var val_14 = val_11 - 4;
            var val_15 = val_11 - 3;
            var val_16 = val_11 - 2;
            val_11 = val_11 - 1;
            val_14 = val_13 + (val_14 << 2);
            val_15 = val_13 + (val_15 << 2);
            float val_66 = ((X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + (((X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) - 4)) << 2) + 32;
            float val_65 = ((X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + (((X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) - 3)) << 2) + 32;
            float val_67 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 32;
            float val_63 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 32 + (((X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) - 2)) << 2;
            float val_64 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 32 + (((X27 + (((long)(int)(((X28 + ((0 + 1)) << 2) + 32 << 1)) | 1)) << 2) - 1)) << 2;
            val_63 = val_63 - val_66;
            val_64 = val_64 - val_65;
            val_65 = val_65 * val_63;
            val_63 = (((X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32) * val_64) - (val_62 * val_63);
            val_66 = val_66 * val_64;
            val_65 = val_65 + val_63;
            val_66 = val_65 - val_66;
            float val_68 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 36;
            float val_69 = (X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 36 + 4;
            val_67 = val_67 - ((X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32);
            val_68 = val_68 - val_62;
            val_67 = val_67 * ((X27 + (((long)(int)(((X28 + ((0 + 2)) << 2) + 32 << 1)) | 1)) << 2) + 44);
            val_69 = val_68 * val_69;
            val_67 = val_69 - val_67;
            val_68 = ((X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32) * val_68;
            val_67 = (val_62 * val_67) + val_67;
            val_67 = val_67 - val_68;
            if((((val_66 < 0f) ? 0 : (0 + 1)) != 0) || (((val_67 < 0f) ? 0 : (0 + 1)) != 0))
            {
                goto label_42;
            }
            
            val_58.Add(item:  (X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32);
            val_58.Add(item:  val_62);
            val_57.Add(item:  val_59);
            goto label_44;
            label_31:
            label_42:
            if(val_13 >= 1)
            {
                    this.convexPolygons.Add(item:  val_58);
                this.convexPolygonsIndices.Add(item:  val_57);
            }
            else
            {
                    this.polygonPool.Free(obj:  val_58);
                this.polygonIndicesPool.Free(obj:  val_57);
            }
            
            Spine.ExposedList<System.Single> val_22 = this.polygonPool.Obtain();
            val_58 = val_22;
            val_22.Clear(clearArray:  true);
            val_58.Add(item:  (X27 + (((X28 + 0) + 32 << 1)) << 2) + 32);
            val_58.Add(item:  val_60);
            val_58.Add(item:  (X27 + (((X28 + ((0 + 1)) << 2) + 32 << 1)) << 2) + 32);
            val_58.Add(item:  val_61);
            val_58.Add(item:  (X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32);
            val_58.Add(item:  val_62);
            Spine.ExposedList<System.Int32> val_23 = this.polygonIndicesPool.Obtain();
            val_57 = val_23;
            val_23.Clear(clearArray:  true);
            val_57.Add(item:  val_6);
            val_57.Add(item:  val_7);
            val_57.Add(item:  val_59);
            float val_24 = ((X27 + (((X28 + ((0 + 1)) << 2) + 32 << 1)) << 2) + 32) - ((X27 + (((X28 + 0) + 32 << 1)) << 2) + 32);
            float val_25 = val_61 - val_60;
            float val_26 = val_25 * ((X27 + (((X28 + ((0 + 2)) << 2) + 32 << 1)) << 2) + 32);
            val_24 = val_60 * val_24;
            val_26 = val_26 - (val_24 * val_62);
            val_24 = val_24 + val_26;
            val_25 = ((X27 + (((X28 + 0) + 32 << 1)) << 2) + 32) * val_25;
            val_24 = val_24 - val_25;
            var val_28 = (val_24 < 0f) ? 0 : (0 + 1);
            label_44:
            var val_29 = (val_3 + 1) + 1;
            if(val_29 < 1152921510517605088)
            {
                goto label_54;
            }
            
            label_19:
            if(val_29 >= 1)
            {
                    this.convexPolygons.Add(item:  val_58);
                this.convexPolygonsIndices.Add(item:  val_57);
            }
            
            val_63 = mem[this.convexPolygons + 24];
            val_63 = this.convexPolygons + 24;
            val_64 = this.convexPolygons;
            if(val_63 < 1)
            {
                goto label_57;
            }
            
            var val_74 = 0;
            label_98:
            if(System == null)
            {
                goto label_61;
            }
            
            var val_30 = (this.convexPolygons + 16) + 0;
            val_57 = mem[(this.convexPolygons + 16 + 0) + 32];
            val_57 = (this.convexPolygons + 16 + 0) + 32;
            var val_71 = (this.convexPolygons + 16 + 0) + 32 + 16;
            var val_70 = (this.convexPolygons + 16 + 0) + 32 + 24;
            var val_31 = val_70 - 4;
            var val_32 = val_70 - 3;
            var val_33 = val_70 - 2;
            val_70 = val_70 - 1;
            val_31 = val_71 + (val_31 << 2);
            val_32 = val_71 + (val_32 << 2);
            val_33 = val_71 + (val_33 << 2);
            val_56 = mem[1152921507127934028];
            val_65 = mem[((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 2)) << 2) + 32];
            val_65 = ((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 2)) << 2) + 32;
            val_60 = mem[(this.convexPolygons + 16 + 0) + 32 + 16 + 32];
            val_60 = (this.convexPolygons + 16 + 0) + 32 + 16 + 32;
            val_66 = mem[(this.convexPolygons + 16 + 0) + 32 + 16 + 32 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 1)) << 2];
            val_66 = (this.convexPolygons + 16 + 0) + 32 + 16 + 32 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 1)) << 2;
            val_61 = mem[(this.convexPolygons + 16 + 0) + 32 + 16 + 36];
            val_61 = (this.convexPolygons + 16 + 0) + 32 + 16 + 36;
            float val_34 = val_65 - (((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 4)) << 2) + 32);
            float val_36 = val_66 - (((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 3)) << 2) + 32);
            val_34 = val_34 * val_61;
            val_34 = (val_36 * val_60) - val_34;
            val_34 = ((((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 3)) << 2) + 32) * val_34) + val_34;
            val_34 = val_34 - ((((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 4)) << 2) + 32) * val_36);
            val_67 = 0;
            var val_39 = (val_34 < 0f) ? 0 : (0 + 1);
            label_97:
            if(val_67 != val_74)
            {
                goto label_76;
            }
            
            val_67 = val_74;
            goto label_95;
            label_76:
            val_71 = val_71 + 0;
            if((((this.convexPolygons + 16 + 0) + 32 + 16 + 0) + 32 + 24) != 3)
            {
                goto label_95;
            }
            
            var val_40 = (this.convexPolygons + 16) + 0;
            var val_73 = (this.convexPolygons + 16 + 0) + 32 + 16;
            var val_72 = (this.convexPolygons + 16 + 0) + 32 + 24;
            var val_41 = val_72 - 2;
            val_72 = val_72 - 1;
            if((((this.convexPolygons + 16 + 0) + 32 + 16 + 0) + 32 + 16 + 36) != val_56)
            {
                goto label_95;
            }
            
            val_41 = val_73 + (val_41 << 2);
            val_73 = val_73 + (val_72 << 2);
            val_68 = mem[((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 2)) << 2) + 32];
            val_68 = ((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 2)) << 2) + 32;
            val_62 = mem[((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 1)) << 2) + 32];
            val_62 = ((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 1)) << 2) + 32;
            float val_42 = val_65 - (((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 4)) << 2) + 32);
            float val_43 = val_66 - (((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 3)) << 2) + 32);
            val_42 = val_42 * val_62;
            float val_46 = val_60 - val_68;
            float val_47 = val_61 - val_62;
            val_42 = (val_43 * val_68) - val_42;
            val_42 = ((((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 3)) << 2) + 32) * val_42) + val_42;
            float val_49 = ((this.convexPolygons + 16 + 0) + 32 + 16 + 44) * val_46;
            val_43 = val_43 * (((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 4)) << 2) + 32);
            val_49 = (((this.convexPolygons + 16 + 0) + 32 + 16 + 36 + 4) * val_47) - val_49;
            val_42 = val_42 - val_43;
            float val_50 = val_46 * val_62;
            val_50 = val_50 + val_49;
            if((((val_42 < 0f) ? 0 : (0 + 1)) != val_39) || ((((val_50 - (val_68 * val_47)) < 0f) ? 0 : (0 + 1)) != val_39))
            {
                goto label_95;
            }
            
            val_59 = mem[((this.convexPolygons + 16 + 0) + 32 + 16 + 0) + 32 + 16 + 40];
            val_59 = ((this.convexPolygons + 16 + 0) + 32 + 16 + 0) + 32 + 16 + 40;
            (this.convexPolygons + 16 + 0) + 32.Clear(clearArray:  true);
            ((this.convexPolygons + 16 + 0) + 32 + 16 + 0) + 32.Clear(clearArray:  true);
            val_57.Add(item:  val_68);
            val_57.Add(item:  val_62);
            Add(item:  val_59);
            val_64 = this.convexPolygons;
            val_67 = 0;
            goto label_96;
            label_95:
            val_62 = val_66;
            val_68 = val_65;
            val_66 = ((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 3)) << 2) + 32;
            val_65 = ((this.convexPolygons + 16 + 0) + 32 + 16 + (((this.convexPolygons + 16 + 0) + 32 + 24 - 4)) << 2) + 32;
            label_96:
            val_67 = val_67 + 1;
            if(val_67 < val_63)
            {
                goto label_97;
            }
            
            label_61:
            val_74 = val_74 + 1;
            if(val_74 < val_63)
            {
                goto label_98;
            }
            
            val_63 = mem[this.convexPolygons + 24];
            val_63 = this.convexPolygons + 24;
            label_57:
            int val_55 = val_63 - 1;
            if(val_74 < 0)
            {
                    return val_64;
            }
            
            val_63 = 1152921513232891520;
            val_59 = 1152921513232860560;
            do
            {
                var val_75 = this.convexPolygons + 16;
                val_75 = val_75 + (((long)(int)((this.convexPolygons + 24 - 1))) << 3);
                val_57 = mem[(this.convexPolygons + 16 + ((long)(int)((this.convexPolygons + 24 - 1))) << 3) + 32];
                val_57 = (this.convexPolygons + 16 + ((long)(int)((this.convexPolygons + 24 - 1))) << 3) + 32;
                if(((this.convexPolygons + 16 + ((long)(int)((this.convexPolygons + 24 - 1))) << 3) + 32 + 24) == 0)
            {
                    val_64.RemoveAt(index:  val_55);
                Spine.Triangulator val_76 = this;
                this.polygonPool.Free(obj:  val_57);
                val_76 = val_76 + (((long)(int)((this.convexPolygons + 24 - 1))) << 3);
                val_57 = mem[(this + ((long)(int)((this.convexPolygons + 24 - 1))) << 3) + 32];
                val_57 = (this + ((long)(int)((this.convexPolygons + 24 - 1))) << 3) + 32;
                this.convexPolygonsIndices.RemoveAt(index:  val_55);
                this.polygonIndicesPool.Free(obj:  val_57);
                val_64 = this.convexPolygons;
            }
            
                val_55 = val_55 - 1;
            }
            while(val_55 >= 0);
            
            return val_64;
        }
        private static bool IsConcave(int index, int vertexCount, float[] vertices, int[] indices)
        {
            int val_1 = index + vertexCount;
            val_1 = val_1 - 1;
            val_1 = val_1 - ((val_1 / vertexCount) * vertexCount);
            int val_3 = index + 1;
            val_3 = val_3 - ((val_3 / vertexCount) * vertexCount);
            int val_9 = indices[val_1 << 2];
            val_9 = val_9 << 1;
            var val_10 = (long)val_9;
            val_10 = val_10 | 1;
            int val_11 = indices[index << 2];
            val_11 = val_11 << 1;
            var val_12 = (long)val_11;
            val_12 = val_12 | 1;
            int val_13 = indices[val_3 << 2];
            val_13 = val_13 << 1;
            var val_5 = (long)val_13 | 1;
            float val_14 = vertices[(((long)(int)((indices[(index) << 2][0] << 1)) | 1)) << 2];
            float val_15 = vertices[(((long)(int)((indices[(((index + vertexCount) - 1) - ((((index + vertexCount) - 1) / vertexCount) * vertexCount)) << 2][0] << 1)) | 1)) << 2];
            float val_16 = vertices[val_9 << 2];
            float val_7 = val_15 - null;
            val_14 = val_14 - val_15;
            val_16 = val_16 * (null - val_14);
            val_7 = (vertices[val_11 << 2]) * val_7;
            val_16 = val_16 + val_7;
            val_14 = val_14 * null;
            val_16 = val_14 + val_16;
            return (bool)(val_16 < 0f) ? 1 : 0;
        }
        private static bool PositiveArea(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
        {
            p3y = p1y - p3y;
            p1y = p2y - p1y;
            p1x = (p3y - p2y) * p1x;
            p2x = p3y * p2x;
            p1x = p1x + p2x;
            p1y = p1y * p3x;
            p1x = p1y + p1x;
            return (bool)(p1x >= 0f) ? 1 : 0;
        }
        private static int Winding(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
        {
            p2x = p2x - p1x;
            p2y = p2y - p1y;
            p3x = p2y * p3x;
            p3y = p2x * p3y;
            p1y = p2x * p1y;
            p2x = p3x - p3y;
            p1x = p2y * p1x;
            p1y = p1y + p2x;
            p1x = p1y - p1x;
            return (int)(p1x < 0f) ? 0 : (0 + 1);
        }
        public Triangulator()
        {
            this.convexPolygons = new Spine.ExposedList<Spine.ExposedList<System.Single>>();
            this.convexPolygonsIndices = new Spine.ExposedList<Spine.ExposedList<System.Int32>>();
            this.indicesArray = new Spine.ExposedList<System.Int32>();
            this.isConcaveArray = new Spine.ExposedList<System.Boolean>();
            this.triangles = new Spine.ExposedList<System.Int32>();
            this.polygonPool = new Spine.Pool<Spine.ExposedList<System.Single>>(initialCapacity:  16, max:  2147483647);
            this.polygonIndicesPool = new Spine.Pool<Spine.ExposedList<System.Int32>>(initialCapacity:  16, max:  2147483647);
        }
    
    }

}

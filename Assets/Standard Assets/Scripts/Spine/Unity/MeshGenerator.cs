using UnityEngine;

namespace Spine.Unity
{
    [Serializable]
    public class MeshGenerator
    {
        // Fields
        public Spine.Unity.MeshGenerator.Settings settings;
        private const float BoundsMinDefault = ∞;
        private const float BoundsMaxDefault = -∞;
        private readonly Spine.ExposedList<UnityEngine.Vector3> vertexBuffer;
        private readonly Spine.ExposedList<UnityEngine.Vector2> uvBuffer;
        private readonly Spine.ExposedList<UnityEngine.Color32> colorBuffer;
        private readonly Spine.ExposedList<Spine.ExposedList<int>> submeshes;
        private UnityEngine.Vector2 meshBoundsMin;
        private UnityEngine.Vector2 meshBoundsMax;
        private float meshBoundsThickness;
        private int submeshIndex;
        private Spine.SkeletonClipping clipper;
        private float[] tempVerts;
        private int[] regionTriangles;
        private UnityEngine.Vector3[] normals;
        private UnityEngine.Vector4[] tangents;
        private UnityEngine.Vector2[] tempTanBuffer;
        private Spine.ExposedList<UnityEngine.Vector2> uv2;
        private Spine.ExposedList<UnityEngine.Vector2> uv3;
        
        // Properties
        public UnityEngine.Vector3[] VertexBuffer { get; }
        public UnityEngine.Vector2[] UVBuffer { get; }
        public UnityEngine.Color32[] ColorBuffer { get; }
        public int VertexCount { get; }
        
        // Methods
        public UnityEngine.Vector3[] get_VertexBuffer()
        {
            if(this.vertexBuffer != null)
            {
                    return (UnityEngine.Vector3[])this;
            }
            
            throw new NullReferenceException();
        }
        public UnityEngine.Vector2[] get_UVBuffer()
        {
            if(this.uvBuffer != null)
            {
                    return (UnityEngine.Vector2[])this;
            }
            
            throw new NullReferenceException();
        }
        public UnityEngine.Color32[] get_ColorBuffer()
        {
            if(this.colorBuffer != null)
            {
                    return (UnityEngine.Color32[])this;
            }
            
            throw new NullReferenceException();
        }
        public int get_VertexCount()
        {
            if(this.vertexBuffer != null)
            {
                    return (int)this;
            }
            
            throw new NullReferenceException();
        }
        public static void GenerateSingleSubmeshInstruction(Spine.Unity.SkeletonRendererInstruction instructionOutput, Spine.Skeleton skeleton, UnityEngine.Material material)
        {
            Spine.Skeleton val_7;
            Spine.Unity.SkeletonRendererInstruction val_8;
            var val_9;
            var val_10;
            var val_11;
            var val_12;
            var val_13;
            val_7 = skeleton;
            val_8 = instructionOutput;
            val_8.Clear();
            Spine.ExposedList<T> val_1 = instructionOutput.submeshInstructions.Resize(newSize:  1);
            Spine.ExposedList<T> val_2 = instructionOutput.attachments.Resize(newSize:  W22);
            if(W22 >= 1)
            {
                    var val_6 = 0;
                val_7 = X28 + 32;
                do
            {
                mem2[0] = instructionOutput.hasActiveClipping + 0 + 64;
                val_10 = 0;
                val_9 = 0;
                val_6 = val_6 + 1;
                val_11 = val_9 + 0;
                val_12 = val_10 + 0;
                val_13 = val_10 + 0;
            }
            while(val_6 < W22);
            
            }
            else
            {
                    val_11 = 0;
                val_12 = 0;
                val_13 = 0;
            }
            
            var val_7 = 0;
            val_7 = val_7 & 1;
            mem2[0] = val_7;
            mem2[0] = val_13;
            mem2[0] = 0;
            mem2[0] = ???;
            mem2[0] = 0;
            mem2[0] = val_7;
            mem2[0] = material;
            mem2[0] = 0;
            mem2[0] = val_11;
            mem2[0] = val_12;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = 0;
        }
        public static void GenerateSkeletonRendererInstruction(Spine.Unity.SkeletonRendererInstruction instructionOutput, Spine.Skeleton skeleton, System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material> customSlotMaterials, System.Collections.Generic.List<Spine.Slot> separatorSlots, bool generateMeshOverride, bool immutableTriangles = False)
        {
            bool val_21;
            Spine.Skeleton val_22;
            Spine.Unity.SkeletonRendererInstruction val_23;
            Spine.ExposedList<Spine.Slot> val_24;
            Spine.ExposedList<Spine.Unity.SubmeshInstruction> val_25;
            var val_26;
            var val_27;
            var val_28;
            var val_29;
            var val_30;
            var val_31;
            var val_32;
            var val_33;
            val_21 = immutableTriangles;
            val_22 = skeleton;
            val_23 = instructionOutput;
            val_24 = skeleton.drawOrder;
            val_23.Clear();
            Spine.ExposedList<T> val_1 = instructionOutput.attachments.Resize(newSize:  W27);
            if(customSlotMaterials == null)
            {
                goto label_6;
            }
            
            var val_3 = (customSlotMaterials.Count > 0) ? 1 : 0;
            if(separatorSlots == null)
            {
                goto label_7;
            }
            
            goto label_8;
            label_6:
            if(separatorSlots != null)
            {
                goto label_8;
            }
            
            label_7:
            label_8:
            if(W27 < 1)
            {
                goto label_10;
            }
            
            var val_24 = 0;
            val_26 = 0;
            label_71:
            Spine.ExposedList<Spine.Attachment> val_5 = instructionOutput.attachments + 0;
            val_24 = mem[(instructionOutput.attachments + 0) + 32 + 64];
            val_24 = (instructionOutput.attachments + 0) + 32 + 64;
            Spine.ExposedList<Spine.Attachment> val_6 = instructionOutput.attachments + 0;
            mem2[0] = val_24;
            val_27 = 0;
            val_29 = 0;
            val_28 = 1;
            if(0 != 0)
            {
                    var val_9 = (((instructionOutput.attachments + 0) + 32 + 16) == 0) ? 0 : 0;
                var val_10 = (((instructionOutput.attachments + 0) + 32 + 16) != 0) ? (val_24) : (!0);
            }
            
            if(0 < 1)
            {
                goto label_33;
            }
            
            label_37:
            if(val_10 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_10 = val_10 + 0;
            if(((instructionOutput.attachments + 0) + 32) == (((instructionOutput.attachments + 0) + 32 + 16 != 0 ? 0 : ( !0) + 0) + 32))
            {
                goto label_36;
            }
            
            val_24 = 1;
            if(val_24 < 0)
            {
                goto label_37;
            }
            
            label_33:
            if(val_28 == 0)
            {
                goto label_38;
            }
            
            label_46:
            if(val_26 < 1)
            {
                goto label_39;
            }
            
            val_22 = ???;
            val_25 = instructionOutput.submeshInstructions;
            if(((0 & 255) != 0) || (generateMeshOverride == false))
            {
                goto label_67;
            }
            
            val_24 = 1;
            Spine.ExposedList<T> val_11 = val_25.Resize(newSize:  1);
            mem[32] = val_22;
            mem[40] = 0;
            mem[44] = val_24;
            mem[48] = 0;
            mem[56] = 0;
            mem[60] = 0;
            mem[64] = 0;
            mem[57] = 0;
            mem[59] = 0;
            mem[68] = val_26;
            mem[72] = 0;
            val_26 = 0;
            mem[76] = 1;
            mem[79] = 0;
            mem[77] = 0;
            goto label_67;
            label_36:
            if(val_28 != 0)
            {
                goto label_46;
            }
            
            label_38:
            if(0 == 0)
            {
                goto label_47;
            }
            
            if((customSlotMaterials.TryGetValue(key:  (instructionOutput.attachments + 0) + 32, value: out  0)) == true)
            {
                goto label_49;
            }
            
            val_30 = 1179403647;
            val_31 = null;
            goto label_51;
            label_47:
            val_31 = null;
            if(val_29 == 0)
            {
                goto label_56;
            }
            
            val_30 = 1179403647;
            label_51:
            label_56:
            label_49:
            val_22 = ???;
            val_25 = instructionOutput.submeshInstructions;
            if((1 & 255) != 0)
            {
                goto label_63;
            }
            
            label_69:
            val_24 = val_24 + 1;
            Spine.ExposedList<T> val_16 = val_25.Resize(newSize:  val_24);
            var val_22 = instructionOutput.submeshInstructions + 16;
            val_22 = val_22 + (val_24 * 48);
            mem2[0] = val_22;
            mem2[0] = val_24;
            mem2[0] = val_24;
            mem2[0] = 0;
            mem2[0] = 1;
            mem2[0] = val_10;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = 0;
            var val_23 = 0;
            mem2[0] = val_26;
            mem2[0] = 0;
            mem2[0] = (val_10 >> 31) ^ 1;
            mem2[0] = 0;
            mem2[0] = 0;
            label_70:
            val_23 = val_23 + 0;
            val_26 = 0 + 0;
            goto label_67;
            label_63:
            if(val_26 < 1)
            {
                goto label_70;
            }
            
            if(mem[4306960435] != mem[4306960435])
            {
                goto label_69;
            }
            
            goto label_70;
            label_39:
            val_22 = ???;
            val_25 = instructionOutput.submeshInstructions;
            label_67:
            val_24 = val_24 + 1;
            if(val_24 < val_22)
            {
                goto label_71;
            }
            
            if(val_26 < 1)
            {
                goto label_72;
            }
            
            val_24 = val_26;
            val_21 = val_21;
            val_23 = val_23;
            Spine.ExposedList<T> val_20 = val_25.Resize(newSize:  val_24 + 1);
            var val_25 = instructionOutput.submeshInstructions + 16;
            val_25 = val_25 + (val_24 * 48);
            mem2[0] = val_22;
            mem2[0] = 0;
            mem2[0] = val_24;
            mem2[0] = val_22;
            mem2[0] = mem[4306960435];
            mem2[0] = val_10;
            mem2[0] = val_23;
            mem2[0] = 0;
            mem2[0] = 0;
            mem2[0] = val_24;
            mem2[0] = 0;
            mem2[0] = (val_10 >> 31) ^ 1;
            mem2[0] = 0;
            mem2[0] = 0;
            goto label_76;
            label_10:
            val_32 = 0;
            val_33 = 0;
            goto label_77;
            label_72:
            val_21 = val_21;
            val_23 = val_23;
            label_76:
            val_32 = 0;
            val_33 = 1;
            label_77:
            mem2[0] = val_32;
            mem2[0] = 1;
            mem2[0] = val_21;
        }
        public static void TryReplaceMaterials(Spine.ExposedList<Spine.Unity.SubmeshInstruction> workingSubmeshInstructions, System.Collections.Generic.Dictionary<UnityEngine.Material, UnityEngine.Material> customMaterialOverride)
        {
            UnityEngine.Material val_1 = 0;
            if(true < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                bool val_2 = customMaterialOverride.TryGetValue(key:  static_value_027FF030, value: out  val_1);
                val_3 = val_3 + 1;
            }
            while(val_3 < val_1);
        
        }
        public void Begin()
        {
            this.vertexBuffer.Clear(clearArray:  false);
            this.colorBuffer.Clear(clearArray:  false);
            this.uvBuffer.Clear(clearArray:  false);
            this.clipper.ClipEnd();
            this.meshBoundsThickness = 0f;
            this.meshBoundsMin = ;
            mem2[0] = 1;
            this.clipper.Clear(clearArray:  false);
            this.submeshIndex = 0;
        }
        public void AddSubmesh(Spine.Unity.SubmeshInstruction instruction, bool updateTriangles = True)
        {
            var val_69;
            Spine.Unity.MeshGenerator val_70;
            Spine.ExposedList<Spine.ExposedList<System.Int32>> val_71;
            bool val_72;
            float val_73;
            float val_74;
            float val_75;
            float val_76;
            var val_77;
            int val_78;
            Spine.Unity.MeshGenerator val_79;
            System.Single[] val_80;
            Spine.Unity.MeshGenerator val_94;
            Spine.Unity.MeshGenerator val_96;
            val_69 = 1152921513244839712;
            val_70 = this;
            val_71 = this.submeshes;
            if((W9 - 1) < this.submeshIndex)
            {
                    Spine.ExposedList<T> val_3 = val_71.Resize(newSize:  this.submeshIndex + 1);
                val_71 = this.submeshes;
                var val_4 = 41938944 + ((this.submeshIndex) << 3);
                if(((41938944 + (this.submeshIndex) << 3) + 32) == 0)
            {
                    var val_62 = mem[41938968];
                mem2[0] = new Spine.ExposedList<System.Int32>();
                val_70 = val_70;
                val_71 = val_71;
            }
            
            }
            
            val_62 = val_62 + ((this.submeshIndex) << 3);
            (mem[41938968] + (this.submeshIndex) << 3) + 32.Clear(clearArray:  false);
            UnityEngine.Color val_6 = UnityEngine.Color.white;
            UnityEngine.Color32 val_7 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a});
            float val_64 = instruction.skeleton.a;
            val_73 = mem[1152921513244807776];
            val_74 = mem[1152921513244807780];
            val_75 = mem[1152921513244807784];
            val_76 = mem[1152921513244807788];
            if((this.settings & 255) == 0)
            {
                    val_72 = instruction.hasClipping;
                if(val_72 != false)
            {
                    if((instruction.preActiveClippingSlotSource & 2147483648) == 0)
            {
                    Spine.ExposedList<Spine.Slot> val_8 = instruction.skeleton.drawOrder + ((instruction.preActiveClippingSlotSource) << 3);
                val_77 = 0;
                int val_10 = mem[1152921513244807800].ClipStart(slot:  (instruction.skeleton.drawOrder + (instruction.preActiveClippingSlotSource) << 3) + 32, clip:  null);
            }
            
                val_72 = 1;
            }
            
            }
            
            val_78 = instruction.startSlot;
            if(val_78 < instruction.endSlot)
            {
                    T[] val_63 = (mem[41938968] + (this.submeshIndex) << 3) + 32;
                val_63 = val_63 + 16;
                val_79 = val_70;
                val_64 = val_64 * 255f;
                do
            {
                Spine.ExposedList<Spine.Slot> val_14 = instruction.skeleton.drawOrder + (val_78 << 3);
                if(((instruction.skeleton.drawOrder + (instruction.startSlot) << 3) + 32 + 64) != 0)
            {
                    val_80 = mem[1152921513244807808];
            }
            
                if((val_72 != 0) && (((instruction.skeleton.drawOrder + (instruction.startSlot) << 3) + 32 + 64) != 0))
            {
                    int val_16 = this.clipper.ClipStart(slot:  (instruction.skeleton.drawOrder + (instruction.startSlot) << 3) + 32, clip:  (instruction.skeleton.drawOrder + (instruction.startSlot) << 3) + 32 + 64);
            }
            
                val_78 = val_78 + 1;
            }
            while(val_78 < instruction.endSlot);
            
                val_96 = 1152921513244807800;
            }
            else
            {
                    val_94 = val_70;
                val_96 = 1152921513244807800;
            }
            
            val_96.ClipEnd();
            mem[1152921513244807776] = val_73;
            mem[1152921513244807780] = val_74;
            mem[1152921513244807784] = val_75;
            mem[1152921513244807788] = val_76;
            float val_79 = (float)instruction.endSlot;
            val_79 = (this.settings >> 32) * val_79;
            mem[1152921513244807792] = val_79;
            var val_81 = (mem[41938968] + (this.submeshIndex) << 3) + 32 + 24;
            if(val_81 >= ((mem[41938968] + (this.submeshIndex) << 3) + 32 + 16 + 24))
            {
                goto label_132;
            }
            
            var val_80 = (long)val_81;
            val_80 = val_80 + 8;
            label_133:
            mem2[0] = 0;
            if((val_80 - 7) >= ((long)(mem[41938968] + (this.submeshIndex) << 3) + 32 + 16 + 24))
            {
                goto label_132;
            }
            
            val_81 = val_81 + 1;
            val_80 = val_80 + 1;
            if(val_81 < ((mem[41938968] + (this.submeshIndex) << 3) + 32 + 16 + 24))
            {
                goto label_133;
            }
            
            throw new IndexOutOfRangeException();
            label_132:
            int val_82 = this.submeshIndex;
            val_82 = val_82 + 1;
            this.submeshIndex = val_82;
        }
        public void BuildMesh(Spine.Unity.SkeletonRendererInstruction instruction, bool updateTriangles)
        {
            if(W21 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                this.AddSubmesh(instruction:  new Spine.Unity.SubmeshInstruction() {skeleton = X22 + 32, startSlot = X22 + 32, endSlot = X22 + 32, material = (X22 + 32) + 16, forceSeparate = (X22 + 32) + 16, preActiveClippingSlotSource = (X22 + 32) + 16, rawTriangleCount = (X22 + 32) + 16 + 16, rawVertexCount = (X22 + 32) + 16 + 16, rawFirstVertexIndex = (X22 + 32) + 16 + 16, hasClipping = (X22 + 32) + 16 + 16}, updateTriangles:  updateTriangles);
                val_3 = val_3 + 1;
            }
            while(val_3 < X21);
        
        }
        public void BuildMeshWithArrays(Spine.Unity.SkeletonRendererInstruction instruction, bool updateTriangles)
        {
            bool val_88;
            var val_89;
            var val_90;
            System.Single[] val_91;
            Spine.Unity.MeshGenerator val_92;
            float val_93;
            float val_94;
            float val_95;
            Spine.Unity.MeshGenerator val_96;
            float val_97;
            float val_98;
            float val_99;
            var val_100;
            var val_101;
            float val_102;
            long val_104;
            float val_108;
            float val_109;
            val_88 = updateTriangles;
            val_89 = mem[1152921513245135152];
            if((instruction + 36) > (mem[1152921513245135168] + 16 + 24))
            {
                    System.Array.Resize<UnityEngine.Vector3>(array: ref  T[] val_1 = mem[1152921513245135168] + 16, newSize:  instruction + 36);
                System.Array.Resize<UnityEngine.Vector2>(array: ref  mem[1152921513245135176] + 16, newSize:  instruction + 36);
                System.Array.Resize<UnityEngine.Color32>(array: ref  mem[1152921513245135184] + 16, newSize:  instruction + 36);
            }
            
            mem2[0] = instruction + 36;
            mem2[0] = instruction + 36;
            mem2[0] = instruction + 36;
            UnityEngine.Color val_4 = UnityEngine.Color.white;
            UnityEngine.Color32 val_5 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a});
            val_90 = 1152921504762331136;
            val_91 = mem[1152921513245135232];
            UnityEngine.Vector3 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = mem[1152921513245135200], y = mem[1152921513245135204]});
            val_92 = this;
            val_93 = val_6.x;
            val_94 = val_6.y;
            val_95 = val_6.z;
            UnityEngine.Vector3 val_7 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = mem[1152921513245135208], y = mem[1152921513245135212]});
            val_96 = this;
            val_97 = val_7.x;
            val_98 = val_7.y;
            val_99 = val_7.z;
            if((instruction + 24 + 24) < 1)
            {
                goto label_17;
            }
            
            val_92 = mem[mem[1152921513245135168] + 16];
            val_92 = mem[1152921513245135168] + 16;
            var val_110 = mem[1152921513245135160];
            val_110 = val_110 & 65280;
            var val_121 = 0;
            label_171:
            val_101 = 41868256;
            val_100 = 0;
            val_102 = 0f;
            if(val_110 != 0)
            {
                    if(mem[1152921513245135272] == 0)
            {
                    mem[1152921513245135272] = new Spine.ExposedList<UnityEngine.Vector2>();
                val_100 = val_100;
                mem[1152921513245135280] = new Spine.ExposedList<UnityEngine.Vector2>();
            }
            
                if((instruction + 36) > (mem[1152921513245179440] + 24))
            {
                    System.Array.Resize<UnityEngine.Vector2>(array: ref  T[] val_11 = 48397872, newSize:  instruction + 36);
                System.Array.Resize<UnityEngine.Vector2>(array: ref  1152921513245183536, newSize:  instruction + 36);
                val_100 = val_100;
            }
            
                mem[1152921513245183544] = instruction + 36;
                mem[1152921513245179448] = instruction + 36;
                if(val_101 < val_100)
            {
                    do
            {
                if(((mem[41810063852494624] + 64) != 0) && ((mem[41810063852494624] + 64 + 48) >= 1))
            {
                    do
            {
                var val_14 = mem[1152921513245179440] + 0;
                mem2[0] = mem[41810063852494624] + 48;
                mem2[0] = mem[41810063852494624] + 48 + 4;
                var val_15 = mem[1152921513245183536] + 0;
                mem2[0] = mem[41810063852494624] + 56;
                mem2[0] = 1065353216;
            }
            while(2 < (mem[41810063852494624] + 64 + 48));
            
            }
            
            }
            while(41868257 < val_100);
            
            }
            
            }
            
            if(val_101 >= val_100)
            {
                goto label_59;
            }
            
            label_169:
            if((mem[41810063852494624] + 64) == 0)
            {
                goto label_140;
            }
            
            val_102 = (val_89 >> 32) * (4.186826E+07f);
            if((mem[41810063852494624] + 64 + 48) > (mem[1152921513245135232] + 24))
            {
                    float[] val_26 = new float[0];
                val_91 = val_26;
                mem[1152921513245135232] = val_26;
            }
            
            mem[41810063852494624] + 64.ComputeWorldVertices(slot:  mem[41810063852494624], worldVertices:  val_26);
            float val_111 = mem[41810063852494624] + 44;
            float val_112 = mem[41810063852494624] + 32;
            val_111 = (val_102 * 255f) * val_111;
            val_111 = val_111 * (mem[41810063852494624] + 64 + 124);
            val_112 = (9.339396E-39f) * val_112;
            var val_28 = (val_111 < 0) ? ((int)val_111) : ((int)val_111);
            float val_29 = val_112 * (mem[41810063852494624] + 64 + 112);
            if((mem[1152921513245135160] & 255) != 0)
            {
                    float val_113 = mem[41810063852494624] + 36;
                val_29 = val_29 * ((float)val_28 & 255);
                val_113 = (1.390671161567E-309) * val_113;
                double val_114 = (double)val_29;
                val_113 = val_113 * (mem[41810063852494624] + 64 + 116);
                val_114 = val_113 * val_114;
                var val_31 = (val_29 < 0) ? ((int)val_29) : ((int)val_29);
                val_104 = (long)val_114;
                var val_32 = ((mem[41810063852494624] + 16 + 80) == 1) ? 0 : (val_28);
            }
            else
            {
                    val_29 = val_29 * 255f;
                float val_70 = (1.390671161567E-309) * (mem[41810063852494624] + 36);
                val_70 = val_70 * (mem[41810063852494624] + 64 + 116);
                val_70 = val_70 * 255f;
                val_104 = (long)val_70;
            }
            
            val_96 = this;
            val_100 = val_100;
            if(val_121 != 0)
            {
                goto label_141;
            }
            
            float val_122 = val_91[0];
            val_108 = val_91[0];
            float val_71 = (val_122 < 0) ? (val_122) : (val_93);
            float val_73 = (val_108 < 0) ? (val_108) : (val_94);
            if(val_108 > val_98)
            {
                goto label_145;
            }
            
            label_141:
            val_108 = val_98;
            label_145:
            if((mem[41810063852494624] + 64 + 48) >= 1)
            {
                    float val_123 = 255f;
                float val_124 = 255f;
                val_123 = val_123 & 255;
                val_124 = val_124 & 255;
                do
            {
                float val_125 = val_91[0];
                float val_126 = val_91[4];
                var val_74 = val_92 + (0 * 12);
                mem2[0] = val_125;
                var val_75 = val_92 + (0 * 12);
                mem2[0] = val_126;
                var val_76 = val_92 + (0 * 12);
                mem2[0] = val_102;
                var val_77 = X28 + 0;
                mem2[0] = (val_29 < 0) ? ((int)val_29) : ((int)val_29);
                var val_78 = (mem[41810063852494624] + 64 + 88) + 0;
                bool val_79 = val_88 + 0;
                mem2[0] = (mem[41810063852494624] + 64 + 88 + 0) + 32;
                var val_80 = (mem[41810063852494624] + 64 + 88) + 4;
                bool val_81 = val_88 + 0;
                mem2[0] = (mem[41810063852494624] + 64 + 88 + 4) + 32;
                if(val_125 < 0)
            {
                    val_93 = val_125;
            }
            else
            {
                    if(val_125 > ((val_122 > val_97) ? (val_122) : (val_97)))
            {
                    val_97 = val_125;
            }
            
            }
            
                if(val_126 < 0)
            {
                    val_94 = val_126;
            }
            else
            {
                    if(val_126 > val_108)
            {
                    val_108 = val_126;
            }
            
            }
            
                val_121 = val_121 + 1;
            }
            while((1 + 1) < (mem[41810063852494624] + 64 + 48));
            
            }
            
            val_98 = val_108;
            label_140:
            val_101 = val_101 + 1;
            if(val_101 < val_100)
            {
                goto label_169;
            }
            
            label_59:
            var val_127 = 0;
            val_127 = val_127 + 1;
            if(val_127 < (instruction + 24 + 24))
            {
                    if((instruction + 24) != 0)
            {
                goto label_171;
            }
            
            }
            
            val_88 = val_88;
            val_89 = val_89;
            val_90 = 1152921504762331136;
            val_95 = val_95;
            val_99 = val_99;
            val_109 = 0f;
            goto label_173;
            label_17:
            val_109 = 0f;
            label_173:
            UnityEngine.Vector2 val_83 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_93, y = val_94, z = val_95});
            mem[1152921513245135200] = val_83.x;
            mem[1152921513245135204] = val_83.y;
            UnityEngine.Vector2 val_84 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_97, y = val_98, z = val_99});
            mem[1152921513245135208] = val_84.x;
            mem[1152921513245135212] = val_84.y;
            float val_128 = val_89 >> 32;
            val_128 = val_109 * val_128;
            mem[1152921513245135216] = val_128;
            if(val_88 == false)
            {
                    return;
            }
            
            if((mem[1152921513245135192] + 24) < (instruction + 24 + 24))
            {
                    val_96 = instruction + 24 + 24;
                Spine.ExposedList<T> val_86 = mem[1152921513245135192].Resize(newSize:  val_96);
                if(val_96 >= 1)
            {
                    val_91 = 1152921510542416896;
                val_89 = 1152921510535503424;
                do
            {
                val_92 = mem[mem[1152921513245135192] + 16];
                val_92 = mem[1152921513245135192] + 16;
                var val_87 = val_92 + 0;
                if(((mem[1152921513245135192] + 16 + 0) + 32) != 0)
            {
                    (mem[1152921513245135192] + 16 + 0) + 32.Clear(clearArray:  false);
            }
            else
            {
                    var val_89 = val_92 + 0;
                mem2[0] = new Spine.ExposedList<System.Int32>();
            }
            
                val_96 = 0 + 1;
            }
            while(val_96 < (instruction + 24 + 24));
            
            }
            
            }
            
            if((instruction + 24 + 24) < 1)
            {
                    return;
            }
            
            val_96 = mem[instruction + 24 + 16];
            val_96 = instruction + 24 + 16;
            val_90 = 1152921504863608832;
            var val_134 = 0;
            label_234:
            val_101 = 0;
            var val_90 = (mem[1152921513245135192] + 16) + 0;
            val_91 = mem[(mem[1152921513245135192] + 16 + 0) + 32];
            val_91 = (mem[1152921513245135192] + 16 + 0) + 32;
            var val_91 = val_96 + (val_101 * 48);
            val_92 = mem[(val_101 * 48) + instruction + 24 + 16 + 32];
            val_92 = (val_101 * 48) + instruction + 24 + 16 + 32;
            var val_135 = (val_101 * 48) + instruction + 24 + 16 + 40;
            if(((val_101 * 48) + instruction + 24 + 16 + 64) <= ((mem[1152921513245135192] + 16 + 0) + 32 + 16 + 24))
            {
                goto label_199;
            }
            
            System.Array.Resize<System.Int32>(array: ref  T[] val_92 = (mem[1152921513245135192] + 16 + 0) + 32 + 16, newSize:  (val_101 * 48) + instruction + 24 + 16 + 64);
            goto label_203;
            label_199:
            if(((val_101 * 48) + instruction + 24 + 16 + 64) >= ((mem[1152921513245135192] + 16 + 0) + 32 + 16 + 24))
            {
                goto label_203;
            }
            
            var val_129 = (long)(val_101 * 48) + instruction + 24 + 16 + 64;
            val_129 = val_129 + 8;
            var val_130 = (val_101 * 48) + instruction + 24 + 16 + 64;
            label_204:
            mem2[0] = 0;
            if((val_129 - 7) >= ((long)(mem[1152921513245135192] + 16 + 0) + 32 + 16 + 24))
            {
                goto label_203;
            }
            
            val_130 = val_130 + 1;
            val_129 = val_129 + 1;
            if(val_130 < ((mem[1152921513245135192] + 16 + 0) + 32 + 16 + 24))
            {
                goto label_204;
            }
            
            label_203:
            mem2[0] = (val_101 * 48) + instruction + 24 + 16 + 64;
            if(val_135 >= ((val_101 * 48) + instruction + 24 + 16 + 40 + 4))
            {
                goto label_208;
            }
            
            var val_133 = 0;
            label_233:
            var val_94 = ((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16) + (val_135 << 3);
            if((((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64) == 0)
            {
                goto label_232;
            }
            
            var val_131 = ((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64 + 104 + 24;
            if(val_131 < 1)
            {
                goto label_218;
            }
            
            val_131 = val_131 & 4294967295;
            var val_96 = (((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64 + 104) + 32;
            label_223:
            var val_132 = (((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64 + 104 + 32) + 0;
            var val_98 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + ((val_133 + 0) << 2);
            var val_99 = 0 + 1;
            val_132 = val_132 + val_134;
            mem2[0] = val_132;
            if(val_99 >= (long)val_131)
            {
                goto label_222;
            }
            
            if(val_99 < (((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64 + 104 + 24))
            {
                goto label_223;
            }
            
            var val_100 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + 0;
            mem2[0] = val_134;
            var val_101 = val_133 + 1;
            var val_102 = val_134 + 2;
            val_101 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + (val_101 << 2);
            mem2[0] = val_102;
            var val_103 = val_133 + 2;
            var val_104 = val_134 + 1;
            val_103 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + (val_103 << 2);
            mem2[0] = val_104;
            var val_105 = val_133 + 3;
            val_105 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + (val_105 << 2);
            mem2[0] = val_102;
            var val_106 = val_133 + 4;
            val_106 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + (val_106 << 2);
            mem2[0] = val_134 + 3;
            var val_108 = val_133 + 5;
            val_108 = ((mem[1152921513245135192] + 16 + 0) + 32 + 16) + (val_108 << 2);
            val_133 = val_133 + 6;
            mem2[0] = val_104;
            val_134 = val_134 + 4;
            goto label_232;
            label_222:
            val_133 = val_133 + 0;
            val_133 = val_133 + 1;
            label_218:
            val_134 = val_134 + ((((val_101 * 48) + instruction + 24 + 16 + 32 + 40 + 16 + ((val_101 * 48) + instruction + 24 + 16 + 40) << 3) + 32 + 64 + 48) >> 1);
            label_232:
            val_135 = val_135 + 1;
            if(val_135 < ((val_101 * 48) + instruction + 24 + 16 + 40 + 4))
            {
                goto label_233;
            }
            
            label_208:
            if((val_101 + 1) < (instruction + 24 + 24))
            {
                goto label_234;
            }
        
        }
        public void ScaleVertexData(float scale)
        {
            if(41938944 >= 1)
            {
                    var val_6 = 0;
                do
            {
                UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = (X21 + 40) + -8, y = (X21 + 40) + -8 + 4, z = X21 + 40}, d:  scale);
                val_6 = val_6 + 1;
                mem2[0] = val_2.x;
                mem2[0] = val_2.y;
                mem2[0] = val_2.z;
            }
            while(val_6 < 41938944);
            
            }
            
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = this.meshBoundsMin, y = (X21 + 40) + -8 + 4}, d:  scale);
            this.meshBoundsMin = val_3;
            mem[1152921513245284068] = val_3.y;
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = this.meshBoundsMax, y = scale}, d:  scale);
            this.meshBoundsMax = val_4;
            mem[1152921513245284076] = val_4.y;
            this.meshBoundsThickness = this.meshBoundsThickness * scale;
        }
        private void AddAttachmentTintBlack(float r2, float g2, float b2, int vertexCount)
        {
            Spine.ExposedList<UnityEngine.Vector2> val_13;
            Spine.ExposedList<UnityEngine.Vector2> val_14;
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  r2, y:  g2);
            UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  b2, y:  1f);
            val_13 = this.uv2;
            if(val_13 == null)
            {
                    this.uv2 = new Spine.ExposedList<UnityEngine.Vector2>();
                val_13 = this.uv2;
                this.uv3 = new Spine.ExposedList<UnityEngine.Vector2>();
            }
            
            int val_5 = W22 + vertexCount;
            if(val_5 > this.vertexBuffer)
            {
                    System.Array.Resize<UnityEngine.Vector2>(array: ref  T[] val_6 = this.uv2 + 16, newSize:  val_5);
                val_14 = this;
                System.Array.Resize<UnityEngine.Vector2>(array: ref  this.uv3 + 16, newSize:  val_5);
                val_13 = this.uv2;
            }
            else
            {
                    val_14 = this.uv3;
            }
            
            mem2[0] = val_5;
            mem2[0] = val_5;
            if(vertexCount < 1)
            {
                    return;
            }
            
            var val_13 = 0;
            var val_8 = X22 << 32;
            do
            {
                var val_9 = X22 + val_13;
                var val_10 = val_8 >> 32;
                Spine.ExposedList<UnityEngine.Vector2> val_11 = this.uv2 + ((((X22 << 32) >> 32)) << 3);
                mem2[0] = val_1.x;
                val_13 = val_13 + 1;
                var val_12 = (this.uv3.version + 16) + ((((X22 << 32) >> 32)) << 3);
                val_8 = val_8 + 4294967296;
                mem2[0] = val_2.x;
            }
            while(val_13 < (long)vertexCount);
        
        }
        public void FillVertexData(UnityEngine.Mesh mesh)
        {
            UnityEngine.Mesh val_18;
            int val_19;
            UnityEngine.Vector2 val_20;
            UnityEngine.Vector3[] val_22;
            var val_23;
            val_18 = mesh;
            val_19 = mem[X20 + 24];
            val_19 = X20 + 24;
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            if(W24 < val_19)
            {
                    var val_2 = X20 + (X24 * 12);
                val_2 = val_2 + 40;
                do
            {
                mem2[0] = val_1.x;
                mem2[0] = val_1.y;
                mem2[0] = val_1.z;
            }
            while((X24 + 1) < (long)val_19);
            
            }
            
            val_18.vertices = X20;
            val_18.uv = X21;
            val_18.colors32 = X23;
            val_20 = this.meshBoundsMin;
            if((System.Single.IsInfinity(f:  val_20)) != false)
            {
                
            }
            else
            {
                    UnityEngine.Vector2 val_5 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = this.meshBoundsMax, y = V10.16B}, b:  new UnityEngine.Vector2() {x = this.meshBoundsMin, y = V8.16B});
                UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y}, d:  0.5f);
                UnityEngine.Vector2 val_7 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.meshBoundsMin, y = 0.5f}, b:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
                UnityEngine.Vector3 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
                0.center = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
                UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_6.x, y:  val_6.y, z:  this.meshBoundsThickness * 0.5f);
                val_20 = val_10.x;
                0.extents = new UnityEngine.Vector3() {x = val_20, y = val_10.y, z = val_10.z};
            }
            
            val_18.bounds = new UnityEngine.Bounds() {m_Center = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Extents = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}};
            if((((X24 * 12) + X20 + 40) + 12) != 0)
            {
                    val_22 = this.normals;
                if(val_22 != null)
            {
                    val_19 = this.normals.Length;
            }
            else
            {
                    UnityEngine.Vector3[] val_11 = new UnityEngine.Vector3[0];
                val_22 = val_11;
                val_19 = 0;
                this.normals = val_11;
            }
            
                if(val_19 < W23)
            {
                    System.Array.Resize<UnityEngine.Vector3>(array: ref  val_22, newSize:  W23);
                var val_15 = 12;
                val_15 = this.normals + (val_19 * val_15);
                val_23 = val_15 + 40;
                do
            {
                UnityEngine.Vector3 val_12 = UnityEngine.Vector3.back;
                val_19 = 0 + 1;
                mem2[0] = val_12.x;
                mem2[0] = val_12.y;
                mem2[0] = val_12.z;
            }
            while(val_19 < X23);
            
                val_22 = this.normals;
                val_18 = val_18;
            }
            
                val_18.normals = val_11;
            }
            
            if(mem[1152921513245744824] != 0)
            {
                    val_18.uv2 = val_11;
                val_18.uv3 = val_11;
            }
            
            if(this.uv3 == null)
            {
                    return;
            }
            
            Spine.Unity.MeshGenerator.SolveTangents2DEnsureSize(tangentBuffer: ref  this.tangents, tempTanBuffer: ref  this.tempTanBuffer, vertexCount:  W23);
            if(W26 >= 1)
            {
                    val_23 = X25 + 32;
                do
            {
                Spine.Unity.MeshGenerator.SolveTangents2DTriangles(tempTanBuffer:  mem[this.tempTanBuffer], triangles:  (X25 + 32) + 0 + 16, triangleCount:  (X25 + 32) + 0 + 24, vertices:  X20, uvs:  X21, vertexCount:  W23);
                val_19 = 0 + 1;
            }
            while(val_19 < W26);
            
            }
            
            Spine.Unity.MeshGenerator.SolveTangents2DBuffer(tangents:  mem[this.tangents], tempTanBuffer:  mem[this.tempTanBuffer], vertexCount:  W23);
            val_18.tangents = mem[this.tangents];
        }
        public void FillTriangles(UnityEngine.Mesh mesh)
        {
            mesh.subMeshCount = W20;
            if(W20 < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            var val_1 = X22 + 32;
            do
            {
                mesh.SetTriangles(triangles:  (X22 + 32) + 0 + 16, submesh:  0, calculateBounds:  false);
                val_2 = val_2 + 1;
            }
            while(val_2 < W20);
        
        }
        public void FillTrianglesSingle(UnityEngine.Mesh mesh)
        {
            mesh.SetTriangles(triangles:  mesh, submesh:  0, calculateBounds:  false);
        }
        public void TrimExcess()
        {
            this.vertexBuffer.TrimExcess();
            this.uvBuffer.TrimExcess();
            this.colorBuffer.TrimExcess();
            if(this.uv2 != null)
            {
                    this.uv2.TrimExcess();
            }
            
            if(this.uv3 != null)
            {
                    this.uv3.TrimExcess();
            }
            
            UnityEngine.Vector3[] val_1 = this.normals;
            if(val_1 != null)
            {
                    System.Array.Resize<UnityEngine.Vector3>(array: ref  val_1, newSize:  1152921513246079072);
            }
            
            UnityEngine.Vector4[] val_2 = this.tangents;
            if(val_2 == null)
            {
                    return;
            }
            
            System.Array.Resize<UnityEngine.Vector4>(array: ref  val_2, newSize:  1152921513246079072);
        }
        internal static void SolveTangents2DEnsureSize(ref UnityEngine.Vector4[] tangentBuffer, ref UnityEngine.Vector2[] tempTanBuffer, int vertexCount)
        {
            var val_5;
            if(tangentBuffer != null)
            {
                    if(tangentBuffer.Length >= vertexCount)
            {
                goto label_2;
            }
            
            }
            
            tangentBuffer = new UnityEngine.Vector4[0];
            label_2:
            if(tempTanBuffer == null)
            {
                goto label_3;
            }
            
            val_5 = vertexCount << 1;
            if(val_5 > tempTanBuffer.Length)
            {
                goto label_4;
            }
            
            return;
            label_3:
            val_5 = vertexCount << 1;
            label_4:
            tempTanBuffer = new UnityEngine.Vector2[0];
        }
        internal static void SolveTangents2DTriangles(UnityEngine.Vector2[] tempTanBuffer, int[] triangles, int triangleCount, UnityEngine.Vector3[] vertices, UnityEngine.Vector2[] uvs, int vertexCount)
        {
            if(triangleCount < 1)
            {
                    return;
            }
            
            var val_13 = 0;
            do
            {
                var val_1 = val_13 + 1;
                int val_11 = triangles[0];
                int val_12 = triangles[val_1 << 2];
                val_13 = val_13 + 2;
                int val_14 = triangles[val_13 << 2];
                UnityEngine.Vector2 val_15 = uvs[val_11];
                UnityEngine.Vector2 val_16 = uvs[val_11];
                float val_3 = null - val_15;
                val_15 = null - val_15;
                float val_4 = S6 - val_16;
                float val_5 = S16 - val_16;
                val_16 = val_3 * val_5;
                float val_6 = val_4 * val_15;
                val_16 = val_16 - val_6;
                val_6 = 1f / val_16;
                val_16 = (val_16 == 0f) ? 0f : (val_6);
                int val_7 = vertices + (val_11 * 12);
                float val_18 = (triangles[0x0][0] * 12) + vertices + 32;
                int val_8 = vertices + (val_12 * 12);
                float val_17 = (triangles[((0 + 1)) << 2][0] * 12) + vertices + 32;
                int val_9 = vertices + (val_14 * 12);
                val_17 = val_17 - val_18;
                val_18 = ((triangles[((0 + 2)) << 2][0] * 12) + vertices + 32) - val_18;
                val_4 = val_5 - val_4;
                tempTanBuffer[val_14] = val_4;
                tempTanBuffer[val_12] = val_4;
                tempTanBuffer[val_11] = val_4;
                val_14 = val_14 + vertexCount;
                val_15 = val_3 - val_15;
                val_15 = val_15 * val_16;
                tempTanBuffer[val_14] = val_15;
                val_12 = val_12 + vertexCount;
                tempTanBuffer[val_12] = val_15;
                val_11 = val_11 + vertexCount;
                tempTanBuffer[val_11] = val_15;
            }
            while(((val_1 + 1) + 1) < triangleCount);
        
        }
        internal static void SolveTangents2DBuffer(UnityEngine.Vector4[] tangents, UnityEngine.Vector2[] tempTanBuffer, int vertexCount)
        {
            var val_7;
            float val_8;
            float val_9;
            float val_10;
            val_7 = vertexCount;
            if(val_7 < 1)
            {
                    return;
            }
            
            var val_7 = 0;
            val_7 = val_7;
            do
            {
                float val_1 = null * null;
                float val_2 = null * null;
                val_2 = val_1 + val_2;
                if(val_1 >= _TYPE_MAX_)
            {
                    val_10 = val_2;
            }
            
                if((double)val_10 > (1E-05))
            {
                    val_10 = 1f / val_10;
                val_9 = null * val_10;
                val_8 = null * val_10;
            }
            
                UnityEngine.Vector2 val_5 = tempTanBuffer[(long)val_7 + val_7];
                UnityEngine.Vector2 val_6 = tempTanBuffer[(long)val_7 + val_7];
                val_5 = val_8 * val_5;
                val_6 = val_9 * val_6;
                val_7 = val_7 + 1;
                mem2[0] = val_9;
                mem2[0] = val_8;
                mem2[0] = 0;
                mem2[0] = (val_5 > val_6) ? 1f : -1f;
            }
            while(val_7 < (long)val_7);
        
        }
        public MeshGenerator()
        {
            this.settings = new Settings();
            this.vertexBuffer = new Spine.ExposedList<UnityEngine.Vector3>(capacity:  4);
            this.uvBuffer = new Spine.ExposedList<UnityEngine.Vector2>(capacity:  4);
            this.colorBuffer = new Spine.ExposedList<UnityEngine.Color32>(capacity:  4);
            Spine.ExposedList<Spine.ExposedList<System.Int32>> val_4 = new Spine.ExposedList<Spine.ExposedList<System.Int32>>();
            val_4.Add(item:  new Spine.ExposedList<System.Int32>(capacity:  6));
            this.submeshes = val_4;
            this.clipper = new Spine.SkeletonClipping();
            float[] val_7 = new float[8] {0f, 2.350989E-38f, 9.403955E-38f, 9.403955E-38f, 3.761582E-37f, 0f};
            this.tempVerts = val_7;
            this.regionTriangles = val_7;
        }
    
    }

}

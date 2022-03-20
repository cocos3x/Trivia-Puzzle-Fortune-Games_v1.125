using UnityEngine;

namespace Spine.Unity
{
    public class SkeletonRendererInstruction
    {
        // Fields
        public bool immutableTriangles;
        public readonly Spine.ExposedList<Spine.Unity.SubmeshInstruction> submeshInstructions;
        public bool hasActiveClipping;
        public int rawVertexCount;
        public readonly Spine.ExposedList<Spine.Attachment> attachments;
        
        // Methods
        public void Clear()
        {
            this.attachments.Clear(clearArray:  false);
            this.rawVertexCount = 0;
            this.hasActiveClipping = false;
            this.submeshInstructions.Clear(clearArray:  false);
        }
        public void SetWithSubset(Spine.ExposedList<Spine.Unity.SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
        {
            int val_12;
            Spine.ExposedList<Spine.Unity.SubmeshInstruction> val_13;
            val_12 = this;
            val_13 = this.submeshInstructions;
            val_13.Clear(clearArray:  false);
            int val_1 = endSubmesh - startSubmesh;
            Spine.ExposedList<T> val_2 = val_13.Resize(newSize:  val_1);
            if(val_1 >= 1)
            {
                    var val_11 = 0;
                int val_12 = 0;
                var val_3 = X10 + 77;
                do
            {
                int val_5 = instructions + ((startSubmesh + val_11) * 48);
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 68;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 76;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 32 + 16;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 64;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 32;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 79;
                mem2[0] = ((startSubmesh + 0) * 48) + instructions + 77;
                this.hasActiveClipping = ((((startSubmesh + 0) * 48) + instructions + 76) != 0) ? 1 : 0;
                val_11 = val_11 + 1;
                mem2[0] = val_12;
                val_12 = (((startSubmesh + 0) * 48) + instructions + 68) + val_12;
                val_3 = val_3 + 48;
            }
            while(val_11 < (long)val_1);
            
                this.rawVertexCount = val_12;
            }
            else
            {
                    this.rawVertexCount = 0;
            }
            
            int val_7 = endSubmesh - 1;
            var val_13 = 48;
            val_13 = instructions + (startSubmesh * val_13);
            val_7 = instructions + (val_7 * 48);
            int val_14 = ((endSubmesh - 1) * 48) + instructions + 44;
            this.attachments.Clear(clearArray:  false);
            val_14 = val_14 - ((startSubmesh * 48) + instructions + 40);
            Spine.ExposedList<T> val_8 = this.attachments.Resize(newSize:  val_14);
            if(val_14 < 1)
            {
                    return;
            }
            
            int val_9 = val_1 + 32;
            do
            {
                var val_10 = ((startSubmesh * 48) + instructions + 40) + 0;
                val_10 = ((startSubmesh * 48) + instructions + 40 + 16) + (val_10 << 3);
                val_12 = mem[((startSubmesh * 48) + instructions + 40 + 16 + (((startSubmesh * 48) + instructions + 40 + 0)) << 3) + 32 + 64];
                val_12 = ((startSubmesh * 48) + instructions + 40 + 16 + (((startSubmesh * 48) + instructions + 40 + 0)) << 3) + 32 + 64;
                m_value = val_12;
                val_13 = 0 + 1;
            }
            while(val_13 < (long)val_14);
        
        }
        public void Set(Spine.Unity.SkeletonRendererInstruction other)
        {
            this.immutableTriangles = other.immutableTriangles;
            this.hasActiveClipping = other.hasActiveClipping;
            this.rawVertexCount = other.rawVertexCount;
            this.attachments.Clear(clearArray:  false);
            int val_1 = other.attachments.Capacity;
            this.attachments.GrowIfNeeded(newCount:  val_1);
            mem2[0] = other.attachments;
            other.attachments.CopyTo(array:  val_1);
            this.submeshInstructions.Clear(clearArray:  false);
            int val_2 = other.submeshInstructions.Capacity;
            this.submeshInstructions.GrowIfNeeded(newCount:  val_2);
            mem2[0] = other.submeshInstructions;
            other.submeshInstructions.CopyTo(array:  val_2);
        }
        public static bool GeometryNotEqual(Spine.Unity.SkeletonRendererInstruction a, Spine.Unity.SkeletonRendererInstruction b)
        {
            var val_7;
            if(((a.hasActiveClipping == true) || (b.hasActiveClipping == true)) || (a.rawVertexCount != b.rawVertexCount))
            {
                goto label_24;
            }
            
            var val_1 = (a.immutableTriangles == false) ? 1 : 0;
            if(((val_1 == ((b.immutableTriangles == true) ? 1 : 0)) || (val_1 != W10)) || (val_1 != W12))
            {
                goto label_24;
            }
            
            if(W10 < 1)
            {
                goto label_12;
            }
            
            var val_7 = 0;
            var val_3 = X15 + 32;
            Spine.ExposedList<Spine.Attachment> val_4 = b.attachments + 32;
            label_18:
            if(((X15 + 32) + 0) != null)
            {
                goto label_24;
            }
            
            val_7 = val_7 + 1;
            if(val_7 < W10)
            {
                goto label_18;
            }
            
            label_12:
            if(val_1 < 1)
            {
                    return (bool)val_7;
            }
            
            var val_8 = 0;
            var val_5 = X12 + 72;
            Spine.ExposedList<Spine.Unity.SubmeshInstruction> val_6 = a.submeshInstructions + 72;
            label_29:
            if(((X12 + 72) + -4) != null)
            {
                goto label_24;
            }
            
            val_7 = 1;
            if(val_5 != null)
            {
                    return (bool)val_7;
            }
            
            if(((X12 + 72) + -8) != null)
            {
                    return (bool)val_7;
            }
            
            if(((X12 + 72) + -28) != null)
            {
                    return (bool)val_7;
            }
            
            if(((X12 + 72) + -32) != null)
            {
                    return (bool)val_7;
            }
            
            val_8 = val_8 + 1;
            val_7 = 0;
            val_5 = val_5 + 48;
            val_6 = val_6 + 48;
            if(val_8 < val_1)
            {
                goto label_29;
            }
            
            return (bool)val_7;
            label_24:
            val_7 = 1;
            return (bool)val_7;
        }
        public SkeletonRendererInstruction()
        {
            this.submeshInstructions = new Spine.ExposedList<Spine.Unity.SubmeshInstruction>();
            this.rawVertexCount = 0;
            this.attachments = new Spine.ExposedList<Spine.Attachment>();
        }
    
    }

}

using UnityEngine;

namespace Spine
{
    public class VertexAttachment : Attachment
    {
        // Fields
        private static int nextID;
        private static readonly object nextIdLock;
        internal readonly int id;
        internal int[] bones;
        internal float[] vertices;
        internal int worldVerticesLength;
        
        // Properties
        public int Id { get; }
        public int[] Bones { get; set; }
        public float[] Vertices { get; set; }
        public int WorldVerticesLength { get; set; }
        
        // Methods
        public int get_Id()
        {
            return (int)this.id;
        }
        public int[] get_Bones()
        {
            return (System.Int32[])this.bones;
        }
        public void set_Bones(int[] value)
        {
            this.bones = value;
        }
        public float[] get_Vertices()
        {
            return (System.Single[])this.vertices;
        }
        public void set_Vertices(float[] value)
        {
            this.vertices = value;
        }
        public int get_WorldVerticesLength()
        {
            return (int)this.worldVerticesLength;
        }
        public void set_WorldVerticesLength(int value)
        {
            this.worldVerticesLength = value;
        }
        public VertexAttachment(string name)
        {
            var val_3;
            var val_4;
            val_3 = null;
            val_3 = null;
            bool val_1 = false;
            System.Threading.Monitor.Enter(obj:  Spine.VertexAttachment.nextIdLock, lockTaken: ref  val_1);
            val_4 = null;
            val_4 = null;
            Spine.VertexAttachment.nextID = Spine.VertexAttachment.nextID + 1;
            this.id = Spine.VertexAttachment.nextID;
            if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  Spine.VertexAttachment.nextIdLock);
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
        
        }
        public void ComputeWorldVertices(Spine.Slot slot, float[] worldVertices)
        {
            this.ComputeWorldVertices(slot:  slot, start:  0, count:  this.worldVerticesLength, worldVertices:  worldVertices, offset:  0, stride:  2);
        }
        public void ComputeWorldVertices(Spine.Slot slot, int start, int count, float[] worldVertices, int offset, int stride = 2)
        {
            System.Single[] val_15;
            var val_16;
            var val_17;
            float val_18;
            float val_19;
            float val_20;
            float val_21;
            val_15 = this.vertices;
            int val_1 = count >> 1;
            val_1 = offset + (val_1 * stride);
            if(this.bones == null)
            {
                goto label_2;
            }
            
            if(start < 1)
            {
                goto label_3;
            }
            
            var val_27 = 0;
            var val_26 = 0;
            do
            {
                int val_25 = this.bones[0];
                val_26 = val_26 + 2;
                val_27 = val_27 + val_25;
                val_16 = val_27 + 1;
                val_17 = val_25 + 0;
            }
            while(val_26 < start);
            
            if(slot.bone.skeleton != null)
            {
                goto label_6;
            }
            
            label_2:
            if(val_1 <= offset)
            {
                    return;
            }
            
            do
            {
                int val_2 = start + 1;
                float val_28 = val_15[start];
                float val_29 = val_15[val_2];
                float val_3 = slot.bone.a * val_28;
                val_3 = val_3 + (slot.bone.b * val_29);
                val_3 = slot.bone.worldX + val_3;
                worldVertices[offset << 2] = val_3;
                val_28 = slot.bone.c * val_28;
                val_29 = slot.bone.d * val_29;
                offset = offset + stride;
                val_29 = val_28 + val_29;
                val_29 = slot.bone.worldY + val_29;
                start = val_2 + 1;
                worldVertices[(offset + 1) << 2] = val_29;
            }
            while(offset < val_1);
            
            return;
            label_3:
            val_17 = 0;
            val_16 = 0;
            label_6:
            if(W15 != 0)
            {
                    if(val_1 <= offset)
            {
                    return;
            }
            
                var val_6 = val_17 + 0;
                do
            {
                int val_30 = this.bones[0];
                val_16 = val_16 + 1;
                val_18 = 0f;
                val_19 = 0f;
                val_30 = val_30 + val_16;
                if(val_16 < val_30)
            {
                    do
            {
                int val_31 = this.bones[val_16 << 2];
                var val_7 = val_6 + 1;
                var val_8 = val_7 + 1;
                Spine.ExposedList<Spine.Bone> val_9 = slot.bone.skeleton.bones + ((this.bones[((val_16 + 1)) << 2][0]) << 3);
                float val_32 = val_15[val_6];
                Spine.ExposedList<System.Single> val_10 = slot.attachmentVertices + 4;
                float val_33 = val_15[val_7];
                val_32 = val_32 + (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_33 = val_33 + S7;
                float val_11 = val_32 * S4;
                val_32 = val_32 * S16;
                val_11 = val_11 + (val_33 * S5);
                float val_34 = val_15[val_6 + 2];
                val_33 = val_33 * S7;
                val_32 = val_32 + val_33;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg) + val_11;
                val_32 = S16 + val_32;
                val_16 = val_16 + 1;
                Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg = val_34 * (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_32 = val_34 * val_32;
                val_8 = val_8 + 1;
                val_19 = val_19 + (Spine.ExposedList<T>.__il2cppRuntimeField_byval_arg);
                val_18 = 0f + val_32;
            }
            while(val_16 < val_30);
            
                var val_14 = val_6 + 3;
            }
            
                worldVertices[offset << 2] = val_19;
                offset = offset + stride;
                worldVertices[(offset + 1) << 2] = val_18;
            }
            while(offset < val_1);
            
                return;
            }
            
            if(val_1 <= offset)
            {
                    return;
            }
            
            var val_16 = val_17 + 0;
            do
            {
                int val_35 = this.bones[0];
                val_16 = val_16 + 1;
                val_20 = 0f;
                val_21 = 0f;
                val_35 = val_35 + val_16;
                if(val_16 < val_35)
            {
                    do
            {
                int val_36 = this.bones[val_16 << 2];
                var val_17 = val_16 + 1;
                var val_18 = val_17 + 1;
                Spine.ExposedList<Spine.Bone> val_19 = slot.bone.skeleton.bones + ((this.bones[((val_16 + 1)) << 2][0]) << 3);
                float val_37 = val_15[val_16];
                float val_38 = val_15[val_17];
                float val_20 = val_37 * S2;
                val_37 = val_37 * S6;
                val_20 = val_20 + (val_38 * S3);
                float val_39 = val_15[val_16 + 2];
                val_38 = val_38 * S16;
                val_37 = val_37 + val_38;
                val_20 = S5 + val_20;
                val_37 = S6 + val_37;
                val_16 = val_16 + 1;
                val_20 = val_39 * val_20;
                val_39 = val_39 * val_37;
                val_21 = val_21 + val_20;
                val_20 = 0f + val_39;
                val_18 = val_18 + 1;
            }
            while(val_16 < val_35);
            
                var val_23 = val_16 + 3;
            }
            
                worldVertices[offset << 2] = val_21;
                offset = offset + stride;
                worldVertices[(offset + 1) << 2] = val_20;
            }
            while(offset < val_1);
        
        }
        public virtual bool ApplyDeform(Spine.VertexAttachment sourceAttachment)
        {
            return (bool)(this == sourceAttachment) ? 1 : 0;
        }
        private static VertexAttachment()
        {
            Spine.VertexAttachment.nextID = 0;
            Spine.VertexAttachment.nextIdLock = new System.Object();
        }
    
    }

}

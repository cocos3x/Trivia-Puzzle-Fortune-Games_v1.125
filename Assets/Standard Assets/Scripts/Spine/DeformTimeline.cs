using UnityEngine;

namespace Spine
{
    public class DeformTimeline : CurveTimeline
    {
        // Fields
        internal int slotIndex;
        internal float[] frames;
        internal float[][] frameVertices;
        internal Spine.VertexAttachment attachment;
        
        // Properties
        public int SlotIndex { get; set; }
        public float[] Frames { get; set; }
        public float[][] Vertices { get; set; }
        public Spine.VertexAttachment Attachment { get; set; }
        public override int PropertyId { get; }
        
        // Methods
        public int get_SlotIndex()
        {
            return (int)this.slotIndex;
        }
        public void set_SlotIndex(int value)
        {
            this.slotIndex = value;
        }
        public float[] get_Frames()
        {
            return (System.Single[])this.frames;
        }
        public void set_Frames(float[] value)
        {
            this.frames = value;
        }
        public float[][] get_Vertices()
        {
            return (System.Single[][])this.frameVertices;
        }
        public void set_Vertices(float[][] value)
        {
            this.frameVertices = value;
        }
        public Spine.VertexAttachment get_Attachment()
        {
            return (Spine.VertexAttachment)this.attachment;
        }
        public void set_Attachment(Spine.VertexAttachment value)
        {
            this.attachment = value;
        }
        public override int get_PropertyId()
        {
            if(this.attachment != null)
            {
                    int val_2 = this.attachment.id;
                val_2 = val_2 + this.slotIndex;
                return (int)val_2 + 100663296;
            }
            
            throw new NullReferenceException();
        }
        public DeformTimeline(int frameCount)
        {
            this.frames = new float[0];
            this.frameVertices = new System.Single[][0];
        }
        public void SetFrame(int frameIndex, float time, float[] vertices)
        {
            this.frames[(long)frameIndex] = time;
            this.frameVertices[(long)frameIndex] = vertices;
        }
        public override void Apply(Spine.Skeleton skeleton, float lastTime, float time, Spine.ExposedList<Spine.Event> firedEvents, float alpha, Spine.MixPose pose, Spine.MixDirection direction)
        {
            int val_22;
            Spine.ExposedList<Spine.Bone> val_24;
            Spine.ExposedList<Spine.Slot> val_22 = skeleton.slots;
            val_22 = val_22 + ((this.slotIndex) << 3);
            if(skeleton.pathConstraints == null)
            {
                    return;
            }
            
            var val_1 = (((Spine.ExposedList<T>.__il2cppRuntimeField_typeHierarchy + (Spine.VertexAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? skeleton.pathConstraints : 0;
            val_24 = skeleton.updateCacheReset;
            val_22 = this.frameVertices[0].Length;
            float val_2 = (this.frameVertices[0] == val_22) ? alpha : 1f;
            if(val_24.Capacity < val_22)
            {
                    val_24.Capacity = val_22;
            }
            
            mem2[0] = val_22;
            int val_27 = this.frames.Length;
            if(this.frames[0] <= time)
            {
                goto label_18;
            }
            
            if(pose == 0)
            {
                goto label_19;
            }
            
            if(pose != 1)
            {
                    return;
            }
            
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_26 = 0;
            do
            {
                int val_25 = skeleton.slots.version;
                val_25 = (1f - val_2) * val_25;
                version = val_25;
                val_26 = val_26 + 1;
            }
            while(val_26 < (long)val_22);
            
            return;
            label_18:
            val_27 = val_27 - 1;
            if(this.frames[val_27] <= time)
            {
                goto label_26;
            }
            
            int val_5 = Spine.Animation.BinarySearch(values:  this.frames, target:  time);
            val_24 = this.frameVertices[(long)val_5 - 1];
            float val_29 = this.frames[(long)val_5];
            System.Single[] val_31 = this.frameVertices[(long)val_5];
            val_29 = (this.frames[(long)val_5 - 1]) - val_29;
            val_29 = (time - val_29) / val_29;
            val_29 = 1f - val_29;
            float val_8 = this.GetCurvePercent(frameIndex:  (long)val_5 - 1, percent:  val_29);
            if(val_2 != 1f)
            {
                goto label_31;
            }
            
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_32 = 0;
            do
            {
                float val_9 = null - null;
                val_9 = val_8 * val_9;
                version = null + val_9;
                val_32 = val_32 + 1;
            }
            while(val_32 < (long)val_22);
            
            return;
            label_26:
            System.Single[] val_33 = this.frameVertices[(long)val_27];
            if(val_2 != 1f)
            {
                goto label_42;
            }
            
            System.Array.Copy(sourceArray:  val_33, sourceIndex:  0, destinationArray:  skeleton, destinationIndex:  0, length:  val_22);
            return;
            label_19:
            val_24.Clear(clearArray:  true);
            return;
            label_31:
            if(pose == 0)
            {
                goto label_43;
            }
            
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_34 = 0;
            do
            {
                float val_11 = null - null;
                val_11 = val_8 * val_11;
                float val_12 = null + val_11;
                val_12 = val_12 - skeleton.slots.version;
                val_12 = val_2 * val_12;
                val_12 = skeleton.slots.version + val_12;
                version = val_12;
                val_34 = val_34 + 1;
            }
            while(val_34 < (long)val_22);
            
            return;
            label_42:
            if(pose == 0)
            {
                goto label_53;
            }
            
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_36 = 0;
            do
            {
                int val_35 = skeleton.slots.version;
                float val_13 = null - val_35;
                val_13 = val_2 * val_13;
                val_35 = val_35 + val_13;
                version = val_35;
                val_36 = val_36 + 1;
            }
            while(val_36 < (long)val_22);
            
            return;
            label_43:
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_37 = 0;
            do
            {
                float val_14 = null - null;
                val_14 = val_8 * val_14;
                float val_15 = null + val_14;
                val_15 = val_2 * val_15;
                version = val_15;
                val_37 = val_37 + 1;
            }
            while(val_37 < (long)val_22);
            
            return;
            label_53:
            if(val_22 < 1)
            {
                    return;
            }
            
            var val_38 = 0;
            do
            {
                version = val_2 * null;
                val_38 = val_38 + 1;
            }
            while(val_38 < (long)val_22);
        
        }
    
    }

}

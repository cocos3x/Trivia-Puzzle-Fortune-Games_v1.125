using UnityEngine;

namespace Spine
{
    public class MeshAttachment : VertexAttachment
    {
        // Fields
        internal float regionOffsetX;
        internal float regionOffsetY;
        internal float regionWidth;
        internal float regionHeight;
        internal float regionOriginalWidth;
        internal float regionOriginalHeight;
        private Spine.MeshAttachment parentMesh;
        internal float[] uvs;
        internal float[] regionUVs;
        internal int[] triangles;
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        internal int hulllength;
        internal bool inheritDeform;
        private string <Path>k__BackingField;
        public object RendererObject;
        private float <RegionU>k__BackingField;
        private float <RegionV>k__BackingField;
        private float <RegionU2>k__BackingField;
        private float <RegionV2>k__BackingField;
        private bool <RegionRotate>k__BackingField;
        private int[] <Edges>k__BackingField;
        private float <Width>k__BackingField;
        private float <Height>k__BackingField;
        
        // Properties
        public int HullLength { get; set; }
        public float[] RegionUVs { get; set; }
        public float[] UVs { get; set; }
        public int[] Triangles { get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
        public string Path { get; set; }
        public float RegionU { get; set; }
        public float RegionV { get; set; }
        public float RegionU2 { get; set; }
        public float RegionV2 { get; set; }
        public bool RegionRotate { get; set; }
        public float RegionOffsetX { get; set; }
        public float RegionOffsetY { get; set; }
        public float RegionWidth { get; set; }
        public float RegionHeight { get; set; }
        public float RegionOriginalWidth { get; set; }
        public float RegionOriginalHeight { get; set; }
        public bool InheritDeform { get; set; }
        public Spine.MeshAttachment ParentMesh { get; set; }
        public int[] Edges { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        
        // Methods
        public int get_HullLength()
        {
            return (int)this.hulllength;
        }
        public void set_HullLength(int value)
        {
            this.hulllength = value;
        }
        public float[] get_RegionUVs()
        {
            return (System.Single[])this.regionUVs;
        }
        public void set_RegionUVs(float[] value)
        {
            this.regionUVs = value;
        }
        public float[] get_UVs()
        {
            return (System.Single[])this.uvs;
        }
        public void set_UVs(float[] value)
        {
            this.uvs = value;
        }
        public int[] get_Triangles()
        {
            return (System.Int32[])this.triangles;
        }
        public void set_Triangles(int[] value)
        {
            this.triangles = value;
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
        public string get_Path()
        {
            return (string)this.<Path>k__BackingField;
        }
        public void set_Path(string value)
        {
            this.<Path>k__BackingField = value;
        }
        public float get_RegionU()
        {
            return (float)this.<RegionU>k__BackingField;
        }
        public void set_RegionU(float value)
        {
            this.<RegionU>k__BackingField = value;
        }
        public float get_RegionV()
        {
            return (float)this.<RegionV>k__BackingField;
        }
        public void set_RegionV(float value)
        {
            this.<RegionV>k__BackingField = value;
        }
        public float get_RegionU2()
        {
            return (float)this.<RegionU2>k__BackingField;
        }
        public void set_RegionU2(float value)
        {
            this.<RegionU2>k__BackingField = value;
        }
        public float get_RegionV2()
        {
            return (float)this.<RegionV2>k__BackingField;
        }
        public void set_RegionV2(float value)
        {
            this.<RegionV2>k__BackingField = value;
        }
        public bool get_RegionRotate()
        {
            return (bool)this.<RegionRotate>k__BackingField;
        }
        public void set_RegionRotate(bool value)
        {
            this.<RegionRotate>k__BackingField = value;
        }
        public float get_RegionOffsetX()
        {
            return (float)this.regionOffsetX;
        }
        public void set_RegionOffsetX(float value)
        {
            this.regionOffsetX = value;
        }
        public float get_RegionOffsetY()
        {
            return (float)this.regionOffsetY;
        }
        public void set_RegionOffsetY(float value)
        {
            this.regionOffsetY = value;
        }
        public float get_RegionWidth()
        {
            return (float)this.regionWidth;
        }
        public void set_RegionWidth(float value)
        {
            this.regionWidth = value;
        }
        public float get_RegionHeight()
        {
            return (float)this.regionHeight;
        }
        public void set_RegionHeight(float value)
        {
            this.regionHeight = value;
        }
        public float get_RegionOriginalWidth()
        {
            return (float)this.regionOriginalWidth;
        }
        public void set_RegionOriginalWidth(float value)
        {
            this.regionOriginalWidth = value;
        }
        public float get_RegionOriginalHeight()
        {
            return (float)this.regionOriginalHeight;
        }
        public void set_RegionOriginalHeight(float value)
        {
            this.regionOriginalHeight = value;
        }
        public bool get_InheritDeform()
        {
            return (bool)this.inheritDeform;
        }
        public void set_InheritDeform(bool value)
        {
            this.inheritDeform = value;
        }
        public Spine.MeshAttachment get_ParentMesh()
        {
            return (Spine.MeshAttachment)this.parentMesh;
        }
        public void set_ParentMesh(Spine.MeshAttachment value)
        {
            this.parentMesh = value;
            if(value == null)
            {
                    return;
            }
            
            mem[1152921510556572176] = ???;
            mem[1152921510556572184] = ???;
            mem[1152921510556572192] = ???;
            this.regionUVs = value.regionUVs;
            this.triangles = value.triangles;
            this.hulllength = value.hulllength;
            this.<Edges>k__BackingField = value.<Edges>k__BackingField;
            this.<Width>k__BackingField = value.<Width>k__BackingField;
            this.<Height>k__BackingField = value.<Height>k__BackingField;
        }
        public int[] get_Edges()
        {
            return (System.Int32[])this.<Edges>k__BackingField;
        }
        public void set_Edges(int[] value)
        {
            this.<Edges>k__BackingField = value;
        }
        public float get_Width()
        {
            return (float)this.<Width>k__BackingField;
        }
        public void set_Width(float value)
        {
            this.<Width>k__BackingField = value;
        }
        public float get_Height()
        {
            return (float)this.<Height>k__BackingField;
        }
        public void set_Height(float value)
        {
            this.<Height>k__BackingField = value;
        }
        public MeshAttachment(string name)
        {
            this.r = 1;
        }
        public void UpdateUVs()
        {
            if(this.uvs == null)
            {
                goto label_1;
            }
            
            if(this.uvs.Length != this.regionUVs.Length)
            {
                goto label_3;
            }
            
            goto label_4;
            label_1:
            label_3:
            float[] val_1 = new float[0];
            this.uvs = val_1;
            label_4:
            float val_2 = (this.<RegionU2>k__BackingField) - (this.<RegionU>k__BackingField);
            float val_3 = (this.<RegionV2>k__BackingField) - (this.<RegionV>k__BackingField);
            if((this.<RegionRotate>k__BackingField) != false)
            {
                    if(val_1.Length < 1)
            {
                    return;
            }
            
                var val_8 = 0;
                do
            {
                float val_6 = this.regionUVs[(long)val_8 + 1];
                val_6 = val_2 * val_6;
                val_6 = (this.<RegionU>k__BackingField) + val_6;
                val_1[0] = val_6;
                float val_7 = this.regionUVs[0];
                val_8 = val_8 + 2;
                val_7 = val_3 * val_7;
                val_7 = ((this.<RegionV>k__BackingField) + val_3) - val_7;
                val_1[((long)(int)((0 + 1))) << 2] = val_7;
            }
            while(val_8 < val_1.Length);
            
                return;
            }
            
            if(val_1.Length < 1)
            {
                    return;
            }
            
            do
            {
                float val_9 = this.regionUVs[0];
                val_9 = val_2 * val_9;
                val_9 = (this.<RegionU>k__BackingField) + val_9;
                val_1[0] = val_9;
                float val_10 = this.regionUVs[1];
                val_10 = val_3 * val_10;
                val_10 = (this.<RegionV>k__BackingField) + val_10;
                val_1[4] = val_10;
            }
            while(2 < val_1.Length);
        
        }
        public override bool ApplyDeform(Spine.VertexAttachment sourceAttachment)
        {
            if(this == sourceAttachment)
            {
                    return true;
            }
            
            if(this.inheritDeform == false)
            {
                    return false;
            }
            
            return (bool)(this.parentMesh == sourceAttachment) ? 1 : 0;
        }
    
    }

}

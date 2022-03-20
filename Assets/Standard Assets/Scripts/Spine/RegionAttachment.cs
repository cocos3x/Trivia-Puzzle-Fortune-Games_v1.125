using UnityEngine;

namespace Spine
{
    public class RegionAttachment : Attachment
    {
        // Fields
        public const int BLX = 0;
        public const int BLY = 1;
        public const int ULX = 2;
        public const int ULY = 3;
        public const int URX = 4;
        public const int URY = 5;
        public const int BRX = 6;
        public const int BRY = 7;
        internal float x;
        internal float y;
        internal float rotation;
        internal float scaleX;
        internal float scaleY;
        internal float width;
        internal float height;
        internal float regionOffsetX;
        internal float regionOffsetY;
        internal float regionWidth;
        internal float regionHeight;
        internal float regionOriginalWidth;
        internal float regionOriginalHeight;
        internal float[] offset;
        internal float[] uvs;
        internal float r;
        internal float g;
        internal float b;
        internal float a;
        private string <Path>k__BackingField;
        public object RendererObject;
        
        // Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Rotation { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
        public string Path { get; set; }
        public float RegionOffsetX { get; set; }
        public float RegionOffsetY { get; set; }
        public float RegionWidth { get; set; }
        public float RegionHeight { get; set; }
        public float RegionOriginalWidth { get; set; }
        public float RegionOriginalHeight { get; set; }
        public float[] Offset { get; }
        public float[] UVs { get; }
        
        // Methods
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
        public float get_Rotation()
        {
            return (float)this.rotation;
        }
        public void set_Rotation(float value)
        {
            this.rotation = value;
        }
        public float get_ScaleX()
        {
            return (float)this.scaleX;
        }
        public void set_ScaleX(float value)
        {
            this.scaleX = value;
        }
        public float get_ScaleY()
        {
            return (float)this.scaleY;
        }
        public void set_ScaleY(float value)
        {
            this.scaleY = value;
        }
        public float get_Width()
        {
            return (float)this.width;
        }
        public void set_Width(float value)
        {
            this.width = value;
        }
        public float get_Height()
        {
            return (float)this.height;
        }
        public void set_Height(float value)
        {
            this.height = value;
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
        public float[] get_Offset()
        {
            return (System.Single[])this.offset;
        }
        public float[] get_UVs()
        {
            return (System.Single[])this.uvs;
        }
        public RegionAttachment(string name)
        {
            this.scaleX = 1;
            this.offset = new float[8];
            this.uvs = new float[8];
            this.r = 1;
        }
        public void UpdateOffset()
        {
            float val_1 = Spine.MathUtils.CosDeg(degrees:  this.rotation);
            float val_2 = Spine.MathUtils.SinDeg(degrees:  this.rotation);
            float val_5 = this.scaleY * (this.height / this.regionOriginalHeight);
            float val_18 = this.regionOffsetX;
            float val_8 = this.scaleX * (this.width / this.regionOriginalWidth);
            float val_9 = this.width * (-0.5f);
            float val_20 = this.x;
            float val_19 = this.y;
            val_9 = val_9 * this.scaleX;
            val_18 = val_18 * val_8;
            float val_10 = this.regionOffsetY * val_5;
            float val_11 = val_9 + val_18;
            val_10 = ((this.height * (-0.5f)) * this.scaleY) + val_10;
            val_18 = val_11 * val_1;
            float val_12 = val_10 * val_2;
            float val_13 = val_18 + val_20;
            val_18 = val_13 - val_12;
            this.offset[0] = val_18;
            float val_14 = val_10 * val_1;
            float val_15 = val_11 * val_2;
            val_14 = val_14 + val_19;
            this.offset[1] = val_15 + val_14;
            val_5 = val_5 * this.regionHeight;
            val_10 = val_10 + val_5;
            val_5 = val_10 * val_2;
            val_13 = val_13 - val_5;
            this.offset[2] = val_13;
            val_10 = val_10 * val_1;
            val_19 = val_10 + val_19;
            val_15 = val_15 + val_19;
            this.offset[3] = val_15;
            val_8 = val_8 * this.regionWidth;
            val_11 = val_11 + val_8;
            val_8 = val_11 * val_1;
            val_8 = val_8 + val_20;
            val_20 = val_8 - val_5;
            this.offset[4] = val_20;
            val_2 = val_11 * val_2;
            this.offset[5] = val_2 + val_19;
            val_12 = val_8 - val_12;
            this.offset[6] = val_12;
            val_2 = val_2 + val_14;
            this.offset[7] = val_2;
        }
        public void SetUVs(float u, float v, float u2, float v2, bool rotate)
        {
            if(rotate != false)
            {
                    this.uvs[4] = u;
                this.uvs[5] = v2;
                this.uvs[6] = u;
                this.uvs[7] = v;
                this.uvs[0] = u2;
                this.uvs[1] = v;
                this.uvs[2] = u2;
            }
            else
            {
                    this.uvs[2] = u;
                this.uvs[3] = v2;
                this.uvs[4] = u;
                this.uvs[5] = v;
                this.uvs[6] = u2;
                this.uvs[7] = v;
                this.uvs[0] = u2;
            }
            
            mem2[0] = v2;
        }
        public void ComputeWorldVertices(Spine.Bone bone, float[] worldVertices, int offset, int stride = 2)
        {
            float val_20 = bone.a;
            float val_21 = bone.b;
            float val_12 = this.offset[6];
            float val_13 = this.offset[7];
            float val_22 = bone.worldX;
            float val_23 = bone.c;
            float val_24 = bone.d;
            float val_25 = bone.worldY;
            float val_1 = val_20 * val_12;
            val_1 = val_1 + (val_21 * val_13);
            val_1 = val_22 + val_1;
            worldVertices[offset << 2] = val_1;
            val_12 = val_23 * val_12;
            val_13 = val_24 * val_13;
            val_13 = val_12 + val_13;
            val_13 = val_25 + val_13;
            worldVertices[(offset + 1) << 2] = val_13;
            int val_4 = stride + offset;
            float val_14 = this.offset[0];
            float val_15 = this.offset[1];
            float val_5 = val_20 * val_14;
            val_5 = val_5 + (val_21 * val_15);
            val_5 = val_22 + val_5;
            worldVertices[val_4 << 2] = val_5;
            val_14 = val_23 * val_14;
            val_15 = val_24 * val_15;
            val_14 = val_14 + val_15;
            val_14 = val_25 + val_14;
            worldVertices[(val_4 + 1) << 2] = val_14;
            val_4 = val_4 + stride;
            float val_16 = this.offset[2];
            float val_17 = this.offset[3];
            float val_8 = val_20 * val_16;
            val_8 = val_8 + (val_21 * val_17);
            val_8 = val_22 + val_8;
            worldVertices[val_4 << 2] = val_8;
            val_16 = val_23 * val_16;
            val_17 = val_24 * val_17;
            val_16 = val_16 + val_17;
            val_16 = val_25 + val_16;
            worldVertices[(val_4 + 1) << 2] = val_16;
            val_4 = val_4 + stride;
            float val_18 = this.offset[4];
            float val_19 = this.offset[5];
            val_20 = val_20 * val_18;
            val_21 = val_21 * val_19;
            val_21 = val_20 + val_21;
            val_22 = val_22 + val_21;
            worldVertices[val_4 << 2] = val_22;
            val_23 = val_23 * val_18;
            val_24 = val_24 * val_19;
            val_24 = val_23 + val_24;
            val_25 = val_25 + val_24;
            worldVertices[(val_4 + 1) << 2] = val_25;
        }
    
    }

}
